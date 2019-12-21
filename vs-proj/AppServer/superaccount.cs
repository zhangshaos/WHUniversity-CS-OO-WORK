// 时间: 2019-12-12
// 版本: 19.12.12
// 摘要: 这个文件中包含了SuperAccount类的定义和实现
// 作者: 高靓洁
#define DEBUG
#undef DEBUG


using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using cz;



namespace superaccount
{
    public class SuperAccount : Account
    {
        // 管理员对资源的增删改
        // 输入: 资源信息
        // e.g. { 
        //  "resourceID" : "001",
        //  "positionX"  : "50"
        //  "positionY"  : "50"
        //  "positionZ"  : "2"
        //  "isUsable"   : "true"
        //  "isWithPower": "true"
        //  "isNearWindow":"false"
        // }
        // 输出: 返回值:OK, CONNECT_ERROR,  PARAM_FORMAT_ERROR, UNKNOWN_ERROR



        public SuperAccount()
        {
            conn_ = new MySqlConnection("server=47.97.220.237;port=3306;user=root;password=123456;database=librarydb;");
            user_table_name_ = "user";
            res_table_name_ = "resource";
            rcd_table_name_ = "record";
            role_table_name_ = "role";
            illrcd_table_name_ = "defaultRecord";

        }
        public SuperAccount(string conn, string user_table_name, string res_table_name, string rcd_table_name, string role_table_name, string illrcd_table_name) : base(conn, user_table_name, res_table_name, rcd_table_name, role_table_name, illrcd_table_name)
        {
            conn_ = new MySqlConnection(conn);
            user_table_name_ = user_table_name;
            res_table_name_ = res_table_name;
            rcd_table_name_ = rcd_table_name;
            role_table_name_ = role_table_name;
            illrcd_table_name_ = illrcd_table_name;
        }
        ~SuperAccount()
        {
            // conn_.Close();
        }

        // 管理员对资源的增加
        // 输入: 资源信息
        // e.g. { 
        //  "resourceID" : "001",
        //  "positionX"  : "50"
        //  "positionY"  : "50"
        //  "positionZ"  : "2"
        //  "isUsable"   : "true"
        //  "isWithPower": "true"
        //  "isNearWindow":"false"
        // }
        // 输出: 返回值:OK, CONNECT_ERROR,  PARAM_FORMAT_ERROR, UNKNOWN_ERROR
        public Error AddResource(ref Dictionary<string, string> resource_info)
        {
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
                string sql = "insert ignore into " + res_table_name_ + " values (@resourceID,@positionX,@positionY,@positionZ,@isUsable,@isWithPower,@isNearWindow);";
                MySqlCommand cmd = new MySqlCommand(sql, conn_);
                cmd.Parameters.AddWithValue("resourceID", int.Parse(resource_info["resourceID"]));
                cmd.Parameters.AddWithValue("positionX", int.Parse(resource_info["positionX"]));
                cmd.Parameters.AddWithValue("positionY", int.Parse(resource_info["positionY"]));
                cmd.Parameters.AddWithValue("positionZ", int.Parse(resource_info["positionZ"]));
                cmd.Parameters.AddWithValue("isUsable", resource_info["isUsable"]);
                cmd.Parameters.AddWithValue("isWithPower", resource_info["isWithPower"]);
                cmd.Parameters.AddWithValue("isNearWindow", resource_info["isNearWindow"]);

                cmd.ExecuteNonQuery();
                return Error.OK;
            }
            catch (ArgumentNullException e)
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

        // 管理员对资源的删除
        // 输入: 资源编号
        // e.g. { 
        //  "resourceID" : "001",
        // }
        // 输出: 返回值:OK, CONNECT_ERROR,  PARAM_FORMAT_ERROR, UNKNOWN_ERROR, RES_UNEXISTED
        public Error DelResource(ref Dictionary<string, string> resource_info)
        {
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
                string sql = "delete from " + res_table_name_ + " where resourceID=@resourceID;";
                MySqlCommand cmd = new MySqlCommand(sql, conn_);
                cmd.Parameters.AddWithValue("resourceID", int.Parse(resource_info["resourceID"]));

                int iRet = cmd.ExecuteNonQuery();
                if (iRet > 0)
                    return Error.OK;
                else
                    return Error.RES_UNEXISTED;
            }
            catch (MySqlException e)
            {

                return Error.UNKNOWN_ERROR;

            }
            finally
            {
                conn_.Close();
            }
        }

        // 管理员对资源的更新
        // 输入: 资源编号
        // e.g. { 
        //  "resourceID" : "001",
        //  "positionX"  : "50"
        //  "positionY"  : "50"
        //  "positionZ"  : "2"
        //  "isUsable"   : "true"
        //  "isWithPower": "true"
        //  "isNearWindow":"false"
        // }
        // 输出: 返回值:OK, CONNECT_ERROR,  PARAM_FORMAT_ERROR, UNKNOWN_ERROR, RES_UNEXISTED
        public Error UpdateResource(ref Dictionary<string, string> resource_info)
        {
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
                string sql = "update resource set positionX=@positionX,positionY=@positionY,positionZ=@positionZ,isUsable=@isUsable,isWithPower=@isWithPower,isNearWindow=@isNearWindow where resourceID=@resourceID;";
                MySqlCommand cmd = new MySqlCommand(sql, conn_);
                cmd.Parameters.AddWithValue("resourceID", int.Parse(resource_info["resourceID"]));
                cmd.Parameters.AddWithValue("positionX", int.Parse(resource_info["positionX"]));
                cmd.Parameters.AddWithValue("positionY", int.Parse(resource_info["positionY"]));
                cmd.Parameters.AddWithValue("positionZ", int.Parse(resource_info["positionZ"]));
                cmd.Parameters.AddWithValue("isUsable", resource_info["isUsable"]);
                cmd.Parameters.AddWithValue("isWithPower", resource_info["isWithPower"]);
                cmd.Parameters.AddWithValue("isNearWindow", resource_info["isNearWindow"]);

                int iRet = cmd.ExecuteNonQuery();
                if (iRet > 0)
                    return Error.OK;
                else
                    return Error.RES_UNEXISTED;
            }
            catch (ArgumentNullException e)
            {
#if (DEBUG)
                Console.WriteLine(e.Message);
#endif
                return Error.PARAM_FORMAT_ERROR;
            }
            /*catch (MySqlException e)
            {
                return Error.UNKNOWN_ERROR;
            }*/
            finally
            {
                conn_.Close();
            }
        }

        // 管理员对用户的删除
        // 输入: 用户编号
        // e.g. { 
        //  "usrID" : "20170001",
        // }
        // 输出: 返回值:OK, CONNECT_ERROR,  PARAM_FORMAT_ERROR, UNKNOWN_ERROR
        public Error DelUser(ref Dictionary<string, string> user_info)
        {
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
                string sql = "delete from " + user_table_name_ + " where usrID =@usrID;";
                MySqlCommand cmd = new MySqlCommand(sql, conn_);
                cmd.Parameters.AddWithValue("usrID", user_info["usrID"]);
                int iRet = cmd.ExecuteNonQuery();
                if (iRet > 0)
                    return Error.OK;
                else
                    return Error.USER_UNEXISTED;
            }
            catch (ArgumentNullException e)
            {
#if (DEBUG)
                Console.WriteLine(e.Message);
#endif
                return Error.PARAM_FORMAT_ERROR;
            }
            catch (FormatException e)
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
                {
                    return Error.UNKNOWN_ERROR;
                }
            }
            finally
            {
                conn_.Close();
            }
        }

    }
}