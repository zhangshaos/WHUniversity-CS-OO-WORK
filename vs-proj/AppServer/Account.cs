// 时间: 2019-12-9
// 版本: 19.12.9
// 摘要: 这个文件中包含了Account类的定义和实现
// 作者: 章星明
#define DEBUG
#undef DEBUG

using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace cz
{
    public enum Error
    {
        OK = 0,
        PARAM_FORMAT_ERROR, // 函数输入参数格式有问题
        CONNECT_ERROR,      // 打开数据库失败
        USER_REGISTERED,
        USER_UNEXISTED,
        USER_PWD_ERROR,
        RES_RESERVED,       // 资源已经被预定了
        RES_UNEXISTED,       //资源不存在，无法删除

        USER_BANNED,
        USER_ALREADY_CHECKED_IN,
        USER_ALREADY_CHECKED_OUT,
        USER_ARRIVE_TOO_EARLY,
        RCD_NO_AVALIABLE_RESERVATION,
        UNKNOWN_ERROR
    }
    // 用于管理账号注册,登录,获取账号详细信息等功能的类
    // 例子:
    //  Account root = new Account();
    //  Dictionary<string, string> register = new Dictionary<string, string> {
    //      // 此处填入账号信息,参考Register()函数的注释
    //  };
    //  Error err = root.Register(ref register);
    //  ...Check err...
    //  Dictionary<string, string> login = new Dictionary<string, string> {
    //      // 此处填入账号,和密码,参考Login()函数的注释
    //  };
    //  Error err = root.Login(ref login);
    //  ...Check err...
    //  Dictionary<string, string> details = new Dictionary<string, string>();
    //  Error err = root.AccountDetails(ref details, 账号, 密码);
    //  ...Check err...
    public class Account
    {
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
        public virtual Error Register(ref Dictionary<string, string> register_info)
        {
            // 先确认账号是否已经注册过了
            // Warns: 不要调整Login()与下文conn_.Open()的顺序,否则会造成多次打开数据库!
            Dictionary<string, string> login = new Dictionary<string, string>();
            try
            {
                login = new Dictionary<string, string>{
                    {"usrID", register_info["usrID"]},
                    {"usrPwd", register_info["usrPwd"]}
                };
            }
            catch (KeyNotFoundException)
            {
#if (DEBUG)
                Console.WriteLine(e.Message);
#endif
                return Error.PARAM_FORMAT_ERROR;
            }

            switch (Login(ref login))
            {
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

            try
            {
                conn_.Open();
            }
            catch (MySqlException e)
            {
                conn_.Close();
#if (DEBUG)
                Console.WriteLine("Catch exception from conn_.Open(): " + e.Message);
#endif
                return Error.CONNECT_ERROR;
            }

            try
            {
                string sql = "insert into " + user_table_name_ + " values(@name,@gender,@usrID,@usrPwd,@role,@status);";
                MySqlCommand cmd = new MySqlCommand(sql, conn_);
                cmd.Parameters.AddWithValue("user", user_table_name_);
                cmd.Parameters.AddWithValue("name", register_info["name"]);
                cmd.Parameters.AddWithValue("gender", register_info["gender"]);
                cmd.Parameters.AddWithValue("usrID", register_info["usrID"]);
                cmd.Parameters.AddWithValue("usrPwd", register_info["usrPwd"]);
                cmd.Parameters.AddWithValue("role", "user");
                cmd.Parameters.AddWithValue("status", "0");
                cmd.ExecuteNonQuery();
                return Error.OK;
            }
            catch (KeyNotFoundException e)
            {
#if (DEBUG)
                Console.WriteLine(e.Message);
#endif
                return Error.PARAM_FORMAT_ERROR;
            }
            catch (MySqlException e)
            {
#if (DEBUG)
                Console.WriteLine("Catch exception from cmd.ExecuteNonQuery(): " + e.Message + "Code:" + e.Code.ToString() +
                        "Number" + e.Number.ToString());
#endif
                return Error.UNKNOWN_ERROR;
            }
            finally
            {
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
        public virtual Error Login(ref Dictionary<string, string> login_info)
        {
            try
            {
                conn_.Open();
            }
            catch (MySqlException e)
            {
#if (DEBUG)
                Console.WriteLine("Catch exception from conn_.Open(): " + e.Message);
#endif
                conn_.Close();
                return Error.CONNECT_ERROR;
            }

            try
            {
                string sql = "select * from " + user_table_name_ + " where usrID = @usrID;";
                MySqlCommand cmd = new MySqlCommand(sql, conn_);
                // cmd.Parameters.AddWithValue("user", user_table_name_); This cause err?
                cmd.Parameters.AddWithValue("usrID", login_info["usrID"]);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    return Error.USER_UNEXISTED;
                }
                else
                {
                    if (reader.GetString("usrPwd") == login_info["usrPwd"])
                    {
                        name_ = reader.GetString("name");
                        gender_ = reader.GetString("gender");
                        id_ = reader.GetInt32("usrID");
                        role_ = reader.GetString("role");
                        status_ = reader.GetString("accountStatus");
                        return Error.OK;
                    }
                    else
                    {
                        return Error.USER_PWD_ERROR;
                    }
                }
            }
            catch (KeyNotFoundException e)
            {
#if (DEBUG)
                Console.WriteLine(e.Message);
#endif
                return Error.PARAM_FORMAT_ERROR;
            }
            catch (MySqlException e)
            {
#if (DEBUG)
                Console.WriteLine(e.Message);
#endif
                return Error.UNKNOWN_ERROR;
            }
            finally
            {
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
        public virtual Error AccountDetails(ref Dictionary<string, string> details, int usrid, string pwd)
        {
            try
            {
                conn_.Open();
            }
            catch (MySqlException e)
            {
#if (DEBUG)
                Console.WriteLine("Catch exception from conn_.Open(): " + e.Message);
#endif
                conn_.Close();
                details.Clear();
                return Error.CONNECT_ERROR;
            }

            try
            {
                string sql = "select * from " + user_table_name_ + " where usrID = @param;";
                MySqlCommand cmd = new MySqlCommand(sql, conn_);
                cmd.Parameters.AddWithValue("user", user_table_name_);
                cmd.Parameters.AddWithValue("param", usrid);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    return Error.USER_UNEXISTED;
                }
                else
                {
                    details = new Dictionary<string, string> {
                        { "name",   reader.GetString("name") },
                        { "gender", reader.GetString("gender") },
                        { "usrID",  reader.GetInt32("usrID").ToString() },
                        { "usrPwd", reader.GetString("usrPwd") },
                        { "role",   reader.GetString("role") },
                        { "status", reader.GetString("accountStatus") }
                    };
                    if (details["usrPwd"] == pwd)
                    {
                        return Error.OK;
                    }
                    else
                    {
                        details.Clear();
                        return Error.USER_PWD_ERROR;
                    }
                }
            }
            catch (MySqlException e)
            {
#if (DEBUG)
                Console.WriteLine(e.Message);
#endif
                details.Clear();
                return Error.UNKNOWN_ERROR;
            }
            finally
            {
                conn_.Close();
            }
        }

        /* 建立新预约
         * 参数为起止时间、资源id
         * 条件：
         * 1. 用户没有被ban
         * 2. 起止时间符合逻辑
         * 3. 自己看注释吧累了
         */
        public Error SetNewReservation(DateTime StartTime, DateTime EndTime, int ResourceID)
        {
            // 检查账户状态
            if (status_ == "banned")
            {
                return Error.USER_BANNED;
            }
            // 检查申请时间是否合理
            else if (DateTime.Compare(StartTime, EndTime) >= 0)
            {
                return Error.PARAM_FORMAT_ERROR;
            }
            else
            {
                // 检查连接
                try
                {
                    conn_.Open();
                }
                catch (MySqlException e)
                {
#if (DEBUG)
                Console.WriteLine("Catch exception from conn_.Open(): " + e.Message);
#endif
                    conn_.Close();
                    return Error.CONNECT_ERROR;
                }


                try
                {
                    // 判断用户所请求的时间是否自己有预约
                    string sqlQuery =
                        "SELECT startTime,endTime FROM " + rcd_table_name_ +
                        " WHERE usrID=" + id_ +
                        " AND recordStatus <> 3";
                    MySqlCommand SQLcmd = new MySqlCommand(sqlQuery, conn_);
                    MySqlDataReader SQLreader = SQLcmd.ExecuteReader();
                    while (SQLreader.Read())
                    {
                        if (DateTime.Compare(SQLreader.GetDateTime("startTime"), EndTime) >= 0 ||
                           DateTime.Compare(SQLreader.GetDateTime("endTime"), StartTime) <= 0)
                        {

                        }
                        else
                        {
                            return Error.PARAM_FORMAT_ERROR;
                        }
                    }
                    SQLreader.Close();

                    // 判断请求资源ID在所请求的时间段是否可用
                    SQLcmd.CommandText = "SELECT startTime,endTime FROM " + rcd_table_name_ +
                        " WHERE resourceID=" + Convert.ToString(ResourceID) +
                        " AND recordStatus <> 3";
                    SQLreader = SQLcmd.ExecuteReader();
                    while (SQLreader.Read())
                    {
                        if (DateTime.Compare(SQLreader.GetDateTime("startTime"), EndTime) >= 0 ||
                           DateTime.Compare(SQLreader.GetDateTime("endTime"), StartTime) <= 0)
                        {

                        }
                        else
                        {
                            return Error.PARAM_FORMAT_ERROR;
                        }
                    }
                    SQLreader.Close();

                    // 如果走到这还没有返回，那就说明这个申请的预约没问题
                    SQLcmd.CommandText = "INSERT INTO " + rcd_table_name_ +
                        "(usrID, resourceID, startTime, endTime, recordStatus)" +
                        "VALUES(@usrID, @resourceID, @startTime, @endTime, @recordStatus)";
                    // SQLcmd.Parameters.AddWithValue("recordDate", StartTime);
                    SQLcmd.Parameters.AddWithValue("usrID", id_);
                    SQLcmd.Parameters.AddWithValue("resourceID", ResourceID);
                    SQLcmd.Parameters.AddWithValue("startTime", StartTime);
                    SQLcmd.Parameters.AddWithValue("endTime", EndTime);
                    SQLcmd.Parameters.AddWithValue("recordStatus", 1);
                    SQLcmd.ExecuteNonQuery();

                    return Error.OK;
                }
                catch (KeyNotFoundException e)
                {
#if (DEBUG)
                Console.WriteLine(e.Message);
#endif
                    return Error.PARAM_FORMAT_ERROR;
                }
                catch (MySqlException e)
                {
#if (DEBUG)
                Console.WriteLine("Catch exception from cmd.ExecuteNonQuery(): " + e.Message + "Code:" + e.Code.ToString() +
                        "Number" + e.Number.ToString());
#endif
                    return Error.UNKNOWN_ERROR;
                } // end of catch 
                finally
                {
                    conn_.Close();
                }
            }
        }

        // 这个函数可以让用户违约状态
        public Error UpdateUserStatus(int timesToUpdate)
        {
            switch (timesToUpdate)
            {
                case 0:
                    break;
                case 1:
                    {
                        switch (status_)
                        {
                            case "0":
                                status_ = "1";
                                break;
                            case "1":
                                status_ = "2";
                                break;
                            default:
                                status_ = "banned";
                                break;
                        }
                        break;
                    }
                case 2:
                    {
                        switch (status_)
                        {
                            case "0":
                                status_ = "2";
                                break;
                            default:
                                status_ = "banned";
                                break;
                        }
                        break;
                    }
                case 3:
                    {
                        status_ = "banned";
                        break;
                    }
            }

            int statusTemp;

            switch (status_)
            {
                case "0":
                    statusTemp = 1; break;
                case "1":
                    statusTemp = 2; break;
                case "2":
                    statusTemp = 3; break;
                case "banned":
                    statusTemp = 4; break;
                default:
                    statusTemp = 4; break;
            }

            try
            {
                string sqlQuery =
                          "UPDATE " + user_table_name_ +
                          " SET accountStatus = " + statusTemp +
                          " WHERE usrID = " + id_;
                MySqlCommand SQLcmd = new MySqlCommand(sqlQuery, conn_);
                SQLcmd.ExecuteNonQuery();
                return Error.OK;
            }
            catch (MySqlException e)
            {
                throw;
            } // end of catch 

        }

        /* 签到函数，要求签到时间为预约前后三十分钟
         * 用户被ban，返回USER_BANNED
         * 用户有正在使用的资源，返回USER_ALREADY_CHECKED_IN
         * 
         */
        public Error CheckIn(DateTime CheckInTime)
        {
            // 查询账户状态
            if (status_ == "banned")
            {
                return Error.USER_BANNED;
            }
            else
            {
                // 检查连接
                try
                {
                    conn_.Open();
                }
                catch (MySqlException e)
                {
#if (DEBUG)
                Console.WriteLine("Catch exception from conn_.Open(): " + e.Message);
#endif
                    conn_.Close();
                    return Error.CONNECT_ERROR;
                }

                try
                {
                    // 标记用户是否当前确实正在使用资源，用于检索用户“正在使用”的记录
                    bool isAlreadyCheckedIn = false;
                    // 标记是否来得太早了，用于检索用户“已预约”的记录
                    bool isTooEarly = false;

                    // 标记用户“正在使用”却没有签退的预约
                    List<int> toSetToEndUse = new List<int>();

                    // 记录违约情况
                    List<int> toWriteAsUsing = new List<int>();
                    List<int> toWriteAsEndUse = new List<int>();
                    int toWriteProperUse = -1;

                    /////////////////////////////////////////////////////////////////////////////
                    /// 检查用户是否有正在使用的预约
                    /// 如果是因为上次没有签退，则修改之为结束
                    /// 如果是的确正在使用资源，就返回

                    string sqlQuery =
                        "SELECT startTime,endTime,recordNum FROM " + rcd_table_name_ +
                        " WHERE usrID=" + Convert.ToString(id_) +
                        " AND recordStatus = 2";
                    MySqlCommand SQLcmd = new MySqlCommand(sqlQuery, conn_);
                    MySqlDataReader SQLreader = SQLcmd.ExecuteReader();
                    while (SQLreader.Read())
                    {
                        // 如果发现有正在使用的记录的结束时间已经小于当前的签到时间
                        if (DateTime.Compare(SQLreader.GetDateTime("endTime"), CheckInTime) < 0)
                        {
                            toSetToEndUse.Add(SQLreader.GetInt32("recordNum"));
                        }
                        else
                        {
                            // 还是要搜索完所有“正在使用”的记录，所以这里先标一下而不是直接返回
                            isAlreadyCheckedIn = true;
                        }
                    }
                    SQLreader.Close();

                    if (isAlreadyCheckedIn)
                    {
                        return Error.USER_ALREADY_CHECKED_IN;
                    }

                    foreach (int counter_i in toSetToEndUse)
                    {
                        string sqlQuery1 =
                          "UPDATE " + rcd_table_name_ +
                          " SET recordStatus = 3 " +
                          " WHERE recordNum = " + Convert.ToString(counter_i);
                        MySqlCommand SQLcmd1 = new MySqlCommand(sqlQuery1, conn_);
                        SQLcmd1.ExecuteNonQuery();
                    }


                    // 检查用户正在使用的预约结束
                    /////////////////////////////////////////////////////////////////////////////


                    // 检查用户的所有已预约的记录，秋后算账.jpg
                    SQLcmd.CommandText =
                        "SELECT startTime,endTime,recordNum FROM " + rcd_table_name_ +
                        " WHERE usrID=" + Convert.ToString(id_) +
                        " AND recordStatus = 1";
                    SQLreader = SQLcmd.ExecuteReader();
                    while (SQLreader.Read())
                    {
                        // 读出用户已预约的记录，因为可能用户预约之后鸽掉了整次预约
                        TimeSpan temp = CheckInTime - SQLreader.GetDateTime("startTime");

                        // 如果签到时间在预约时间以后超过了三十分钟
                        if (temp.Minutes > 30)
                        {
                            // 如果良心发现只是迟到，没有鸽掉整次预约
                            if (CheckInTime < SQLreader.GetDateTime("endTime"))
                            {
                                toWriteAsUsing.Add(SQLreader.GetInt32("recordNum"));
                            }
                            else
                            {
                                // 修改这次预约为“结束”
                                toWriteAsEndUse.Add(SQLreader.GetInt32("recordNum"));
                            }
                        }

                        // 如果来得太早
                        else if (temp.Minutes < -30)
                        {
                            isTooEarly = true;
                        }
                        // 如果正常时间抵达
                        else
                        {
                            // 发现有正常预约则不认为是早到
                            isTooEarly = false;
                            toWriteProperUse = SQLreader.GetInt32("recordNum");
                        }
                    }
                    SQLreader.Close();

                    /////////////////////////////////////////// 处理异常预约 ///////////////////////////////////////////////

                    // 修改两个List的对应内容

                    foreach (int counter_i in toWriteAsEndUse)
                    {
                        string sqlQuery1 =
                          "UPDATE " + rcd_table_name_ +
                          " SET recordStatus = 3 " +
                          " WHERE recordNum = " + Convert.ToString(counter_i);
                        MySqlCommand SQLcmd1 = new MySqlCommand(sqlQuery1, conn_);
                        SQLcmd1.ExecuteNonQuery();
                    }

                    foreach (int counter_i in toWriteAsUsing)
                    {
                        string sqlQuery1 =
                          "UPDATE " + rcd_table_name_ +
                          " SET recordStatus = 2, exactStartTime = @time" +
                          " WHERE recordNum = " + Convert.ToString(counter_i);
                        MySqlCommand SQLcmd1 = new MySqlCommand(sqlQuery1, conn_);
                        SQLcmd1.Parameters.AddWithValue("@time", CheckInTime);
                        SQLcmd1.ExecuteNonQuery();
                    }

                    // 写入违约表

                    foreach (int counter_i in toWriteAsEndUse)
                    {
                        string sqlQuery1 =
                        "INSERT INTO " + illrcd_table_name_ +
                        "(recordNum, usrID, defaultReason)" +
                        "VALUES(@recordNum, @usrID, @defaultReason)";
                        MySqlCommand SQLcmd1 = new MySqlCommand(sqlQuery1, conn_);
                        SQLcmd1.Parameters.AddWithValue("recordNum", counter_i);
                        SQLcmd1.Parameters.AddWithValue("usrID", id_);
                        SQLcmd1.Parameters.AddWithValue("defaultReason", 2);
                        SQLcmd1.ExecuteNonQuery();
                    }

                    foreach (int counter_i in toWriteAsUsing)
                    {
                        string sqlQuery1 =
                        "INSERT INTO " + illrcd_table_name_ +
                        "(recordNum, usrID, defaultReason)" +
                        "VALUES(@recordNum, @usrID, @defaultReason)";
                        MySqlCommand SQLcmd1 = new MySqlCommand(sqlQuery1, conn_);
                        SQLcmd1.Parameters.AddWithValue("recordNum", counter_i);
                        SQLcmd1.Parameters.AddWithValue("usrID", id_);
                        SQLcmd1.Parameters.AddWithValue("defaultReason", 2);
                        SQLcmd1.ExecuteNonQuery();
                    }


                    // 更新用户状态
                    UpdateUserStatus(toWriteAsEndUse.Count + toWriteAsUsing.Count);


                    /////////////////////////////////////////// 处理过早签到 ///////////////////////////////////////////
                    if (isTooEarly)
                    {
                        return Error.USER_ARRIVE_TOO_EARLY;
                    }

                    /////////////////////////////////////////// 处理正常预约 ///////////////////////////////////////////////
                    // 如果还是默认值，提示没有可用预约
                    if (toWriteProperUse == -1)
                    {
                        return Error.RCD_NO_AVALIABLE_RESERVATION;
                    }
                    else
                    {
                        // 修改为正在使用，写入时间
                        string sqlQuery1 =
                          "UPDATE " + rcd_table_name_ +
                          " SET recordStatus = 2, exactStartTime = @time" +
                          " WHERE recordNum = " + toWriteProperUse;
                        MySqlCommand SQLcmd1 = new MySqlCommand(sqlQuery1, conn_);
                        SQLcmd1.Parameters.AddWithValue("@time", CheckInTime);
                        SQLcmd1.ExecuteNonQuery();

                        return Error.OK;
                    }

                } // end of try
                catch (MySqlException e)
                {
#if (DEBUG)
                Console.WriteLine("Catch exception from cmd.ExecuteNonQuery(): " + e.Message + "Code:" + e.Code.ToString() +
                        "Number" + e.Number.ToString());
#endif
                    return Error.UNKNOWN_ERROR;
                } // end of catch 
                finally
                {
                    conn_.Close();
                }
            }
        }

        /* 签退函数
         * 需要检查：
         * 用户是否有未签退预约
         *        
         */
        public Error CheckOut(DateTime CheckOutTime)
        {
            try
            {
                conn_.Open();
            }
            catch (MySqlException e)
            {
#if (DEBUG)
                Console.WriteLine("Catch exception from conn_.Open(): " + e.Message);
#endif
                conn_.Close();
                return Error.CONNECT_ERROR;
            }

            try
            {
                // 检查用户是否有正在使用的预约，没有的话你签退啥
                string sqlQuery =
                    "SELECT startTime,endTime,recordNum FROM " + rcd_table_name_ +
                    " WHERE usrID=" + Convert.ToString(id_) +
                    " AND recordStatus = 2";
                MySqlCommand SQLcmd = new MySqlCommand(sqlQuery, conn_);
                MySqlDataReader SQLreader = SQLcmd.ExecuteReader();

                // 查找是否有正在使用的预约

                int tempCount = 0; // 记录正在使用的预约的数目
                while (SQLreader.Read())
                {
                    ++tempCount;
                }
                SQLreader.Close();

                if (tempCount == 0)
                {
                    // 如果没有正在使用的预约
                    return Error.USER_ALREADY_CHECKED_OUT;
                }
                else
                {
                    // 暂存所有正在使用的预约
                    List<int> recordList = new List<int>();
                    List<int> toWriteAsTooEarly = new List<int>();

                    bool leaveTooEarly = false;

                    SQLreader = SQLcmd.ExecuteReader();

                    while (SQLreader.Read())
                    {
                        // 计算提前签退的时间
                        TimeSpan temp = CheckOutTime - SQLreader.GetDateTime("endTime");

                        // 如果提前了三十分钟
                        if (temp.Minutes > 30)
                        {
                            toWriteAsTooEarly.Add(SQLreader.GetInt32("recordNum"));
                            leaveTooEarly = true;
                        }
                        recordList.Add(SQLreader.GetInt32("recordNum"));
                    }
                    SQLreader.Close();

                    // 修改record表中recordNum在List里面的记录为结束
                    foreach (int counter_i in recordList)
                    {
                        string sqlQuery1 =
                          "UPDATE " + rcd_table_name_ +
                          " SET recordStatus = 3, exactEndTime = @time" +
                          " WHERE recordNum = " + Convert.ToString(counter_i);
                        MySqlCommand SQLcmd1 = new MySqlCommand(sqlQuery1, conn_);
                        SQLcmd1.Parameters.AddWithValue("@time", CheckOutTime);
                        SQLcmd1.ExecuteNonQuery();
                    }

                    if (leaveTooEarly)
                    {
                        // 写违约表
                        foreach (int counter_i in toWriteAsTooEarly)
                        {
                            string sqlQuery1 =
                            "INSERT INTO " + illrcd_table_name_ +
                            "(recordNum, usrID, defaultReason)" +
                            "VALUES(@recordNum, @usrID, @defaultReason)";
                            MySqlCommand SQLcmd1 = new MySqlCommand(sqlQuery1, conn_);
                            SQLcmd1.Parameters.AddWithValue("recordNum", counter_i);
                            SQLcmd1.Parameters.AddWithValue("usrID", id_);
                            SQLcmd1.Parameters.AddWithValue("defaultReason", 1);
                            SQLcmd1.ExecuteNonQuery();
                        }

                        // 更新用户状态
                        UpdateUserStatus(1);
                    }

                    return Error.OK;
                }
            }
            catch (MySqlException e)
            {
#if (DEBUG)
                Console.WriteLine("Catch exception from cmd.ExecuteNonQuery(): " + e.Message + "Code:" + e.Code.ToString() +
                        "Number" + e.Number.ToString());
#endif
                return Error.UNKNOWN_ERROR;
            } // end of catch 
            finally
            {
                conn_.Close();
            }
        }

        public string GetName()
        {
            return name_;
        }
        public string GetGender()
        {
            return gender_;
        }
        public int GetId()
        {
            return id_;
        }
        public string GetRole()
        {
            return role_;
        }
        public string GetStatus()
        {
            return status_;
        }

        public Account()
        {
            conn_ = new MySqlConnection("server=47.97.220.237;port=3306;user=root;password=123456;database=librarydb;");
            user_table_name_ = "user";
            res_table_name_ = "resource";
            rcd_table_name_ = "record";
            role_table_name_ = "role";
            illrcd_table_name_ = "defaultRecord";
        }
        public Account(string conn, string user_table_name, string res_table_name, string rcd_table_name, string role_table_name, string illrcd_table_name)
        {
            conn_ = new MySqlConnection(conn);
            user_table_name_ = user_table_name;
            res_table_name_ = res_table_name;
            rcd_table_name_ = rcd_table_name;
            role_table_name_ = role_table_name;
            illrcd_table_name_ = illrcd_table_name;
        }
        ~Account()
        {
            //conn_.Close(); // 数据库Open,Close留给程序员自己做...
        }
        protected string user_table_name_;
        protected string res_table_name_;
        protected string rcd_table_name_;
        protected string role_table_name_;
        protected string illrcd_table_name_;
        protected MySqlConnection conn_;

        protected string name_;
        protected string gender_;
        protected int id_;
        protected string role_;
        protected string status_;
    }
}