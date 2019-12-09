// 时间: 2019-11-29
// 版本: 19.11.29
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
        // 输入: 注册信息
        // e.g. { 
        //  "name" : "xxx",
        //  "gender" : "male/female",
        //  "stu_id" : "1388", // < int32's Maximum
        //  "pwd" : "****",
        //  "privilege" : "0/1"
        // }
        // 输出: 返回值:OK, CONNECT_ERROR, USER_REGISTERED, PARAM_FORMAT_ERROR, UNKNOWN_ERROR
        // 此函数可以重入,不抛出异常.
        public virtual Error Register(ref Dictionary<string, string> register_info) {
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
                string sql = "insert into user values(@name,@gender,@stu_id,@pwd,@privilege,0);";
                MySqlCommand cmd = new MySqlCommand(sql, conn_);
                cmd.Parameters.AddWithValue("name", register_info["name"]);
                cmd.Parameters.AddWithValue("gender", register_info["gender"]);
                cmd.Parameters.AddWithValue("stu_id", int.Parse(register_info["stu_id"]));
                cmd.Parameters.AddWithValue("pwd", register_info["pwd"]);
                cmd.Parameters.AddWithValue("privilege", int.Parse(register_info["privilege"]));
                cmd.ExecuteNonQuery();
                return Error.OK;
            } catch (KeyNotFoundException e) {
#if (DEBUG)
                Console.WriteLine(e.Message);
#endif
                return Error.PARAM_FORMAT_ERROR;
            } catch (ArgumentNullException e) {
#if (DEBUG)
                Console.WriteLine(e.Message);
#endif
                return Error.PARAM_FORMAT_ERROR;
            } catch (FormatException e) {
#if (DEBUG)
                Console.WriteLine(e.Message);
#endif
                return Error.PARAM_FORMAT_ERROR;
            } catch (OverflowException e) {
#if (DEBUG)
                Console.WriteLine(e.Message);
#endif
                return Error.PARAM_FORMAT_ERROR;
            } catch (MySqlException e) {
#if (DEBUG)
                Console.WriteLine("Catch exception from cmd.ExecuteNonQuery(): " + e.Message + "Code:" + e.Code.ToString() +
                        "Number" + e.Number.ToString());
#endif
                if (e.Code == 0 && e.Number == 1062) {
                    // 这两个数字数字是从MySQL反馈中得到的,不可移植
                    return Error.USER_REGISTERED;
                } else {
                    return Error.UNKNOWN_ERROR;
                }
            } finally {
                conn_.Close();
            }
        }

        // 输入:登录信息
        // e.g. {
        //  "stu_id" : "xxx",
        //  "pwd" : "xxx"
        // }
        // 输出:返回值:OK, CONNECT_ERROR, USER_UNEXISTED, USER_PWD_ERROR, PARAM_FORMAT_ERROR, UNKNOWN_ERROR
        // 此函数可以重入,不抛出异常
        // 
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
                string sql = "select pwd from user where stu_id = @stu_id;";
                MySqlCommand cmd = new MySqlCommand(sql, conn_);
                cmd.Parameters.AddWithValue("stu_id", int.Parse(login_info["stu_id"]));
                MySqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read()) {
                    return Error.USER_UNEXISTED;
                } else {
                    if (reader.GetString("pwd") == login_info["pwd"]) {
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
            } catch (ArgumentNullException e) {
#if (DEBUG)
                Console.WriteLine(e.Message);
#endif
                return Error.PARAM_FORMAT_ERROR;
            } catch (FormatException e) {
#if (DEBUG)
                Console.WriteLine(e.Message);
#endif
                return Error.PARAM_FORMAT_ERROR;
            } catch (OverflowException e) {
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

        // 输入账号和密码,返回账号的详细信息,格式如下:
        // {
        //  "valid" : "true",
        //  "name" : "xxx",
        //  "gender" : "male/female",
        //  "stu_id" : "学号",
        //  "pwd" : "****",
        //  "privilege" : "0/1"
        //  "illegal" : "0/1"
        // }
        // 当"valid"无效时,如下:
        // {
        //  "valid" : "false",
        //  "msg" : "xxxxxx"
        // }
        // 此函数可以重入,不抛出异常
        public virtual Dictionary<string, string> AccountDetails(int stu_id, string pwd) {
            try {
                conn_.Open();
            } catch (MySqlException e) {
#if (DEBUG)
                Console.WriteLine("Catch exception from conn_.Open(): " + e.Message);
#endif
                conn_.Close();
                return new Dictionary<string, string> {
                    { "valid", "false" },
                    { "msg", "Open DB error!"}
                };
            }

            try {
                string sql = "select * from user where stu_id = @param;";
                MySqlCommand cmd = new MySqlCommand(sql, conn_);
                cmd.Parameters.AddWithValue("param", stu_id);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read()) {
                    return new Dictionary<string, string> {
                        { "valid", "false" },
                        { "msg", "The account doesn't exist!" }
                    };
                } else {
                    Dictionary<string, string> info = new Dictionary<string, string> {
                        { "valid", "true" },
                        { "name", reader.GetString("name") },
                        { "gender", reader.GetString("gender") },
                        { "stu_id", reader.GetInt32("stu_id").ToString() },
                        { "pwd", reader.GetString("pwd") },
                        { "privilege", reader.GetInt32("privilege").ToString() },
                        { "illegal", reader.GetInt32("illegal").ToString() }
                    };
                    if (info["pwd"] == pwd) {
                        return info;
                    } else {
                        return new Dictionary<string, string> {
                            { "valid", "false" },
                            { "msg", "Password doesn't match!" }
                        };
                    }
                }
            } catch (MySqlException e) {
#if (DEBUG)
                Console.WriteLine(e.Message);
#endif
                return new Dictionary<string, string> {
                    { "valid", "false" },
                    { "msg", "Unknown MySQL Error!"}
                };
            } finally {
                conn_.Close();
            }
        }

        public Account() {
            conn_ = new MySqlConnection("server=47.97.220.237;port=3306;user=root;password=123456; database=librarydb;");
            user_table_name_ = "user";
        }
        public Account(string conn, string user_table_name) {
            conn_ = new MySqlConnection(conn);
            user_table_name_ = user_table_name;
        }
        ~Account() {
            //conn_.Close(); // 数据库Open,Close留给程序员自己做...
        }
        private MySqlConnection conn_;
        private string user_table_name_;
    }
}
