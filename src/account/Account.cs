// 时间: 2019-12-9
// 版本: 19.12.9
// 摘要: 这个文件中包含了Account类的定义和实现
// 作者: 章星明
#define DEBUG
#undef DEBUG

using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace cz {
    public enum Error {
        OK = 0,
        PARAM_FORMAT_ERROR, // 函数输入参数格式有问题
        CONNECT_ERROR,      // 打开数据库失败
        USER_REGISTERED,
        USER_UNEXISTED,
        USER_PWD_ERROR,
        RES_RESERVED,       // 资源已经被预定了
        UNKNOWN_ERROR
    }
    // 用于管理账号注册,登录,获取账号详细信息等功能的类
    // 例子:
    //  Account root = new Account();
    //  Dictionary<string, string> register = new Dictionary<string, string> {
    //      // 此处填入账号信息,参考Register()函数的注释
    //  };
    //  Error err = root.Register(ref register);
    //  Dictionary<string, string> login = new Dictionary<string, string> {
    //      // 此处填入账号,和密码,参考Login()函数的注释
    //  };
    //  Error err = root.Login(ref login);
    //  Dictionary<string, string> details = root.AccountDetails(账号, 密码); // 接下来解析details,参考AccountDetails()
    public class Account {
        // 注册普通用户的账号
        // 输入: 注册信息
        // e.g. { 
        //  "name" : "xxx",
        //  "gender" : "男/女",
        //  "usrID" : "1388", // < int32's Maximum
        //  "usrPwd" : "****"
        // }
        // 输出: 返回值:OK, CONNECT_ERROR, USER_REGISTERED, PARAM_FORMAT_ERROR, UNKNOWN_ERROR
        // 此函数可以重入,不抛出异常.
        public virtual Error Register(ref Dictionary<string, string> register_info) {
            // 先确认账号是否已经注册过了
            // Warns: 不要调整Login()与下文conn_.Open()的顺序,否则会造成多次打开数据库!
            Dictionary<string, string> login = new Dictionary<string, string>();
            try {
                login = new Dictionary<string, string>{
                    {"usrID", register_info["usrID"]},
                    {"usrPwd", register_info["usrPwd"]}
                };
            } catch (KeyNotFoundException) {
#if (DEBUG)
                Console.WriteLine(e.Message);
#endif
                return Error.PARAM_FORMAT_ERROR;
            }
            
            switch (Login(ref login)) {
                case Error.USER_UNEXISTED:
                    break; // 正常情况下直接从这里break出去
                case Error.OK:
                case Error.USER_PWD_ERROR:
                    return Error.USER_REGISTERED;
                case Error.CONNECT_ERROR:
                    return Error.CONNECT_ERROR;
                case Error.PARAM_FORMAT_ERROR:
                    return Error.PARAM_FORMAT_ERROR;
                case Error.UNKNOWN_ERROR:
                    return Error.UNKNOWN_ERROR;
                default:
                    return Error.UNKNOWN_ERROR;
            }

            try {
                conn_.Open();
            } catch (MySqlException e) {
                conn_.Close();
#if (DEBUG)
                Console.WriteLine("Catch exception from conn_.Open(): " + e.Message);
#endif
                return Error.CONNECT_ERROR;
            }

            try {                
                string sql = "insert into " + user_table_name_ + " values(@name,@gender,@usrID,@usrPwd,@role,@status);";
                MySqlCommand cmd = new MySqlCommand(sql, conn_);
                cmd.Parameters.AddWithValue("user",     user_table_name_);
                cmd.Parameters.AddWithValue("name",     register_info["name"]);
                cmd.Parameters.AddWithValue("gender",   register_info["gender"]);
                cmd.Parameters.AddWithValue("usrID",    register_info["usrID"]);
                cmd.Parameters.AddWithValue("usrPwd",   register_info["usrPwd"]);
                cmd.Parameters.AddWithValue("role",     "user");
                cmd.Parameters.AddWithValue("status",   "0");
                cmd.ExecuteNonQuery();
                return Error.OK;
            } catch (KeyNotFoundException e) {
#if (DEBUG)
                Console.WriteLine(e.Message);
#endif
                return Error.PARAM_FORMAT_ERROR;
            } catch (MySqlException e) {
#if (DEBUG)
                Console.WriteLine("Catch exception from cmd.ExecuteNonQuery(): " + e.Message + "Code:" + e.Code.ToString() +
                        "Number" + e.Number.ToString());
#endif
                return Error.UNKNOWN_ERROR;
            } finally {
                conn_.Close();
            }
        }

        // 输入:登录信息
        // e.g. {
        //  "usrID" : "xxx",
        //  "usrPwd" : "xxx"
        // }
        // 输出:返回值:OK, CONNECT_ERROR, USER_UNEXISTED, USER_PWD_ERROR, PARAM_FORMAT_ERROR, UNKNOWN_ERROR
        // 此函数可以重入,不抛出异常
        // 函数执行期间,可能会修改naem_,gender_,id_,role_,status_
        public virtual Error Login(ref Dictionary<string, string> login_info) {
            try {
                conn_.Open();
            } catch (MySqlException e) {
#if (DEBUG)
                Console.WriteLine("Catch exception from conn_.Open(): " + e.Message);
#endif
                conn_.Close();
                return Error.CONNECT_ERROR;
            }

            try {
                string sql = "select * from " + user_table_name_ + " where usrID = @usrID;";
                MySqlCommand cmd = new MySqlCommand(sql, conn_);
                // cmd.Parameters.AddWithValue("user", user_table_name_); This cause err?
                cmd.Parameters.AddWithValue("usrID", login_info["usrID"]);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read()) {
                    return Error.USER_UNEXISTED;
                } else {
                    if (reader.GetString("usrPwd") == login_info["usrPwd"]) {
                        name_   = reader.GetString("name");
                        gender_ = reader.GetString("gender");
                        id_     = reader.GetInt32("usrID");
                        role_   = reader.GetString("role");
                        status_ = reader.GetString("accountStatus");
                        return Error.OK;
                    } else {
                        return Error.USER_PWD_ERROR;
                    }
                }
            } catch (KeyNotFoundException e) {
#if (DEBUG)
                Console.WriteLine(e.Message);
#endif
                return Error.PARAM_FORMAT_ERROR;
            } catch (MySqlException e) {
#if (DEBUG)
                Console.WriteLine(e.Message);
#endif
                return Error.UNKNOWN_ERROR;
            } finally {
                conn_.Close();
            }
        }

        // 输入账号和密码,
        // 如果返回值为OK, 返回账号的详细信息到 @details中,格式如下:
        // {
        //  "name" : "xxx",
        //  "gender" : "男/女",
        //  "usrID" : "学号",
        //  "usrPwd" : "****",
        //  "role" : "user/recordAdmin/resourceAdmin/superAdmin"
        //  "status" : "0/1/2/banned" : 表示违规次数
        // }
        // 如果返回值为CONNECT_ERROR, USER_UNEXISTED, USER_PWD_ERROR, UNKNOWN_ERROR, @details会被清空
        // 此函数可以重入,不抛出异常
        public virtual Error AccountDetails(ref Dictionary<string, string> details, int usrid, string pwd) {
            try {
                conn_.Open();
            } catch (MySqlException e) {
#if (DEBUG)
                Console.WriteLine("Catch exception from conn_.Open(): " + e.Message);
#endif
                conn_.Close();
                details.Clear();
                return Error.CONNECT_ERROR;
            }

            try {
                string sql = "select * from " + user_table_name_ + " where usrID = @param;";
                MySqlCommand cmd = new MySqlCommand(sql, conn_);
                cmd.Parameters.AddWithValue("user", user_table_name_);
                cmd.Parameters.AddWithValue("param", usrid);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read()) {
                    return Error.USER_UNEXISTED;
                } else {
                    details = new Dictionary<string, string> {
                        { "name",   reader.GetString("name") },
                        { "gender", reader.GetString("gender") },
                        { "usrID",  reader.GetInt32("usrID").ToString() },
                        { "usrPwd", reader.GetString("usrPwd") },
                        { "role",   reader.GetString("role") },
                        { "status", reader.GetString("accountStatus") }
                    };
                    if (details["usrPwd"] == pwd) {
                        return Error.OK;
                    } else {
                        details.Clear();
                        return Error.USER_PWD_ERROR;
                    }
                }
            } catch (MySqlException e) {
#if (DEBUG)
                Console.WriteLine(e.Message);
#endif
                details.Clear();
                return Error.UNKNOWN_ERROR;
            } finally {
                conn_.Close();
            }
        }

        public string GetName() {
            return name_;
        }
        public string GetGender() {
            return gender_;
        }
        public int GetId() {
            return id_;
        }
        public string GetRole() {
            return role_;
        }
        public string GetStatus() {
            return status_;
        }

        public Account() {
            conn_ = new MySqlConnection("server=47.97.220.237;port=3306;user=root;password=123456;database=librarydb;");
            user_table_name_    = "user";
            res_table_name_     = "resource";
            rcd_table_name_     = "record";
            role_table_name_    = "role";
            illrcd_table_name_  = "defaultRecord";
        }
        public Account(string conn, string user_table_name, string res_table_name, string rcd_table_name, string role_table_name, string illrcd_table_name) {
            conn_ = new MySqlConnection(conn);
            user_table_name_    = user_table_name;
            res_table_name_     = res_table_name;
            rcd_table_name_     = rcd_table_name;
            role_table_name_    = role_table_name;
            illrcd_table_name_  = illrcd_table_name;
        }
        ~Account() {
            //conn_.Close(); // 数据库Open,Close留给程序员自己做...
        }
        private string  user_table_name_;
        private string  res_table_name_;
        private string  rcd_table_name_;
        private string  role_table_name_;
        private string  illrcd_table_name_;
        private MySqlConnection conn_;

        private string  name_;
        private string  gender_;
        private int     id_;
        private string  role_;
        private string  status_;
    }
}
