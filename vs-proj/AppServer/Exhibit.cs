/* �����ռ䡢�ࡢ����������˹��������, e.g. ExhibitResources
 * �ֲ����������������շ���������e.g. mySqlCommand
 * �����ȫ��д�»�������
 */

///
/// LOG:
/// 12/17 ��ڶ������ݿ���Ӧ��ţ����
/// 12/17 �����ж�ʱ����߼���ţ����
///

// #define DEBUGGING

#if (DEBUGGING)

#define DEBUG_SieveAvaliable
#define DEBUG_ResourceDetail

#endif

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MySql.Data.MySqlClient;


namespace ExhibitResources
{
    ///////////////////////////////////// ���� /////////////////////////////////////

    /// <summary>
    /// �������ͣ�������Ϊ�����ķ���ֵ
    /// </summary>
    public enum Error
    {
        OP_SUCCESS,
        OP_FAILED,

        QUERY_NO_RESULT,

        CONNECTION_ERROR,
        VERIFICATION_ERROR,

        PARAM_FORMAT_ERROR,
        OVERFLOW_ERROR,

        UNKNOWN_ERROR,
        RESERVED_ERROR
    }

    /// <summary>
    /// �������ռ��е�ȫ�ֱ���������SQL���ӡ�����ĺ�
    /// </summary>
    public class GlobalVar
    {
        public const int SEAT_CONDITION_NUM = 5;
        // public static int BOOK_CONDITION_NUM = 5;
    }


    /* ���캯�� */
    public class ResourcesPosition
    {
        public int x;
        public int y;
        public int z;

        public ResourcesPosition(int xx, int yy, int zz)
        {
            x = xx;
            y = yy;
            z = zz;
        }
    };

    ///////////////////////////////////// �� /////////////////////////////////////

    /// <summary>
    /// ��Դ�Ļ���
    /// </summary>
    class ExhibitBaseHandle
    {
        /// <summary>
        /// ����conditionָ����������ѯ���ݿ⣬������ԴID����Դλ��
        /// </summary>
        /// <param name="sieveCondition">
        /// ��ѯ����, Ĭ��Ϊ0����Ҫ��
        /// 1��Ҫ��
        /// -1��Ҫ�󲻣�
        /// e.g. 
        /// "isNearWindow" : "1"
        /// "isHavingPower" : "1"
        /// </param>
        /// <param name="eligibleResources">
        /// ���ط�����������ԴID�Լ�����
        /// </param>
        public virtual Error SieveAvaliable(
            Dictionary<string, string> sieveCondition,
            DateTime startTime,
            DateTime endTime,
            ref Dictionary<int, ResourcesPosition> eligibleResources)
        {
            // ��ɲ����ڸ�����д��ô�̯ࣨ�֣�
            return Error.OP_SUCCESS;
        }

        /// <summary>
        /// ���Ҷ�ӦID�µ���Դ��Ϣ, ����ֵΪ��ֵ����ʽ��ʾ������
        /// </summary>
        /// <param name="id">
        /// ��ԴID������������Դ
        /// </param>
        /// <param name="resourceStatus">
        /// ��Դϸ�����������޸�
        /// </param>
        public virtual Error ResourceDetail(int id, ref Dictionary<string, string> resourceStatus)
        {
            return Error.OP_SUCCESS;
        }

        public ExhibitBaseHandle()
        {
            conn_ = new MySqlConnection("server=47.97.220.237;port=3306;user=root;password=123456;database=librarydb;");
            user_table_name_ = "user";
            res_table_name_ = "resource";
            rcd_table_name_ = "record";
            role_table_name_ = "role";
            illrcd_table_name_ = "defaultRecord";
        }

        public ExhibitBaseHandle(string conn, string user_table_name, string res_table_name, string rcd_table_name, string role_table_name, string illrcd_table_name)
        {
            conn_ = new MySqlConnection(conn);
            user_table_name_ = user_table_name;
            res_table_name_ = res_table_name;
            rcd_table_name_ = rcd_table_name;
            role_table_name_ = role_table_name;
            illrcd_table_name_ = illrcd_table_name;
        }

        protected string user_table_name_;
        protected string res_table_name_;
        protected string rcd_table_name_;
        protected string role_table_name_;
        protected string illrcd_table_name_;
        protected MySqlConnection conn_;
    }

    /// <summary>
    /// ��λ����
    /// </summary>
    class ExhibitSeatHandle : ExhibitBaseHandle
    {
        public ExhibitSeatHandle()
        {
            conn_ = new MySqlConnection("server=47.97.220.237;port=3306;user=root;password=123456;database=librarydb;");
            user_table_name_ = "user";
            res_table_name_ = "resource";
            rcd_table_name_ = "record";
            role_table_name_ = "role";
            illrcd_table_name_ = "defaultRecord";
        }

        public ExhibitSeatHandle(string conn, string user_table_name, string res_table_name, string rcd_table_name, string role_table_name, string illrcd_table_name)
        {
            conn_ = new MySqlConnection(conn);
            user_table_name_ = user_table_name;
            res_table_name_ = res_table_name;
            rcd_table_name_ = rcd_table_name;
            role_table_name_ = role_table_name;
            illrcd_table_name_ = illrcd_table_name;
        }

        /// <summary>
        /// ����conditionָ����������ѯ���ݿ⣬������ԴID����Դλ��
        /// </summary>
        /// <param name="sieveCondition">
        /// ��ѯ����, Ĭ��Ϊ0����Ҫ��
        /// 1��Ҫ��
        /// -1��Ҫ�󲻣�
        /// e.g. 
        /// "isNearWindow" : "1"
        /// "isHavingPower" : "1"
        /// </param>
        /// <param name="eligibleResources">
        /// ���ط�����������ԴID�Լ�����
        /// </param>
        public override Error SieveAvaliable(
            Dictionary<string, string> sieveCondition,
            DateTime startTime,
            DateTime endTime,
            ref Dictionary<int, ResourcesPosition> eligibleResources)
        {
            // �����ֹʱ����Ȼ�ʼʱ����ڽ���ʱ��
            if (DateTime.Compare(startTime, endTime) >= 0)
            {
                return Error.PARAM_FORMAT_ERROR;
            }

            // �����ݿ⣬ȷ����������
            try
            {
                conn_.Open();
#if (DEBUG_SieveAvaliable)
                Console.WriteLine("SieveAvaliable:Connected.\n");
#endif
            }
            catch (MySqlException e)
            {
#if (DEBUG_SieveAvaliable)
                Console.WriteLine("SieveAvaliable: " + e.Message);
#endif
                conn_.Close();
                switch (e.Number)
                {
                    case 0:
                        {
                            Console.WriteLine("Cannot connect to server. Contact admini.\n");
                            return Error.CONNECTION_ERROR;
                        }
                    case 1045:
                        {
                            Console.WriteLine("Invalid username/password, please try again\n");
                            return Error.VERIFICATION_ERROR;
                        }
                    default:
                        {
                            break;
                        }
                }
            } // end of catch



            // ִ�в���
            try
            {
                string sqlQuery = "SELECT resourceID,positionX,positionY,positionZ FROM " + res_table_name_ + " WHERE isUsable=1";
                // �ȴ����û�������
                if (sieveCondition.ContainsKey("isNearWindow"))
                {
                    int temp = Convert.ToInt32(sieveCondition["isNearWindow"]);
                    switch (temp)
                    {
                        case 0:
                            {
                                break;
                            }
                        case 1:
                            {
                                sqlQuery += " AND isNearWindow=1 ";
                                break;
                            }
                        case -1:
                            {
                                sqlQuery += " AND isNearWindow=2 ";
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }

                if (sieveCondition.ContainsKey("isWithPower"))
                {
                    int temp = Convert.ToInt32(sieveCondition["isWithPower"]);
                    switch (temp)
                    {
                        case 0:
                            {
                                break;
                            }
                        case 1:
                            {
                                sqlQuery += " AND isWithPower=1 ";
                                break;
                            }
                        case -1:
                            {
                                sqlQuery += " AND isWithPower=2 ";
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }

                MySqlCommand SQLcmd = new MySqlCommand(sqlQuery, conn_);
                MySqlDataReader SQLreader = SQLcmd.ExecuteReader();
                eligibleResources.Clear();
                while (SQLreader.Read())
                {
#if (DEBUG_SieveAvaliable)
                Console.WriteLine(
                    SQLreader.GetInt32("res_num") +
                    SQLreader.GetInt32("positionx") +
                    SQLreader.GetInt32("positiony") +
                    SQLreader.GetInt32("positionz")
                    );
#endif
                    ResourcesPosition tempPosition = new ResourcesPosition(SQLreader.GetInt32("positionX"), SQLreader.GetInt32("positionY"), SQLreader.GetInt32("positionZ"));
                    eligibleResources.Add(SQLreader.GetInt32("resourceID"), tempPosition);
                }
                SQLreader.Close();

                if (eligibleResources.Count != 0)
                {
                    // �����ʱ��ɸѡ���ô����
                    if (SieveByTime(startTime, endTime, ref eligibleResources) == Error.QUERY_NO_RESULT)
                    {
                        return Error.QUERY_NO_RESULT;
                    }
                    else
                    {
                        // ����ԴID��������һ��
                        //var dicSort = from objDic in eligibleResources orderby objDic.Key select objDic;
                        //eligibleResources.Clear();
                        //foreach (KeyValuePair<int, ResourcesPosition> kvp in dicSort)
                        //{
                        //    eligibleResources.Add(kvp.Key, kvp.Value);
                        //}
                        return Error.OP_SUCCESS;
                    }
                }
                else
                {
                    return Error.QUERY_NO_RESULT;
                }
            } // end of try
            catch (KeyNotFoundException e)
            {
#if (DEBUG_SieveAvaliable)
                Console.WriteLine(e.Message);
#endif
                return Error.PARAM_FORMAT_ERROR;
            }
            catch (ArgumentNullException e)
            {
#if (DEBUG_SieveAvaliable)
                Console.WriteLine(e.Message);
#endif
                return Error.PARAM_FORMAT_ERROR;
            }
            catch (FormatException e)
            {
#if (DEBUG_SieveAvaliable)
                Console.WriteLine(e.Message);
#endif
                return Error.PARAM_FORMAT_ERROR;
            }
            catch (OverflowException e)
            {
#if (DEBUG_SieveAvaliable)
                Console.WriteLine(e.Message);
#endif
                return Error.OVERFLOW_ERROR;
            }
            catch (MySqlException e)
            {
#if (DEBUG_SieveAvaliable)
                Console.WriteLine(
                    "Catch exception from cmd.ExecuteNonQuery(): " 
                    + e.Message + "Code:" + e.Code.ToString() +
                    "Number" + e.Number.ToString());
#endif
                return Error.UNKNOWN_ERROR;
            } // end of catch
            finally
            {
                conn_.Close();
            }
        }

        public Error SieveByTime(DateTime startTime, DateTime endTime, ref Dictionary<int, ResourcesPosition> eligibleResources)
        {
            // ִ�в���
            try
            {
                // ���ֵ���ÿһ����¼��ԤԼ����״̬Ϊ��ԤԼ������ʹ�õ�ԤԼ�������ʱ���ͻ�ľͰ������ֵ���ɾ��
                List<int> pairsToDel = new List<int>();
                foreach (KeyValuePair<int, ResourcesPosition> kvp in eligibleResources)
                {
                    string sqlQuery =
                        "SELECT startTime,endTime FROM " + rcd_table_name_ +
                        " WHERE resourceID=" + Convert.ToString(kvp.Key) +
                        " AND recordStatus <> 3";
                    MySqlCommand SQLcmd = new MySqlCommand(sqlQuery, conn_);
                    MySqlDataReader SQLreader = SQLcmd.ExecuteReader();
                    while (SQLreader.Read())
                    {
                        // �߼�û���꣬������ɱ
                        if (DateTime.Compare(SQLreader.GetDateTime("startTime"), endTime) >= 0 ||
                            DateTime.Compare(SQLreader.GetDateTime("endTime"), startTime) <= 0)
                        {
                            // ��ô����OK��
                        }
                        else
                        {
                            pairsToDel.Add(kvp.Key);
                            // eligibleResources.Remove(kvp.Key);
                        }
                    }
                    SQLreader.Close();
                }

                for (int i = 0; i < pairsToDel.Count; ++i)
                {
                    eligibleResources.Remove(pairsToDel[i]);
                }

                if (eligibleResources.Count == 0)
                {
                    return Error.QUERY_NO_RESULT;
                }
                else
                {
                    return Error.OP_SUCCESS;
                }
            }
            catch (KeyNotFoundException e)
            {
                throw;
            }
            catch (ArgumentNullException e)
            {
                throw;
            }
            catch (FormatException e)
            {
                throw;
            }
            catch (OverflowException e)
            {
                throw;
            }
            catch (MySqlException e)
            {
                throw;
            } // end of catch
        }

        /// <summary>
        /// ���Ҷ�ӦID�µ���Դ��Ϣ, ����ֵΪ��ֵ����ʽ��ʾ������
        /// </summary>
        /// <param name="id">
        /// ��ԴID������������Դ
        /// </param>
        /// <param name="resourceStatus">
        /// ��Դϸ��
        /// type = seat, ��λ
        /// window = 1 ����
        /// power = 1 �е�Դ
        /// usable = 1 ����
        /// </param>
        public override Error ResourceDetail(int id, ref Dictionary<string, string> resourceStatus)
        {
            // �����ݿ⣬ȷ����������
            try
            {
                conn_.Open();
#if (DEBUG_ResourceDetail)
                Console.WriteLine("ResourceDetail:Connected.\n");
#endif
            }
            catch (MySqlException e)
            {
#if (DEBUG_ResourceDetail)
                Console.WriteLine("ResourceDetail: " + e.Message);
#endif
                conn_.Close();
                switch (e.Number)
                {
                    case 0:
                        {
                            Console.WriteLine("Cannot connect to server. Contact admini.\n");
                            return Error.CONNECTION_ERROR;
                        }
                    case 1045:
                        {
                            Console.WriteLine("Invalid username/password, please try again\n");
                            return Error.VERIFICATION_ERROR;
                        }
                    default:
                        {
                            break;
                        }
                }
            } // end of catch

            try
            {
                string sqlQuery = string.Format("SELECT * FROM " + res_table_name_ + " WHERE resourceID='{0}'", id);
                MySqlCommand SQLcmd = new MySqlCommand(sqlQuery, conn_);
                MySqlDataReader SQLreader = SQLcmd.ExecuteReader();
                resourceStatus.Clear();

                while (SQLreader.Read())
                {
                    resourceStatus.Add("resourceID", Convert.ToString(SQLreader.GetInt32("resourceID")));
                    resourceStatus.Add("positionX", Convert.ToString(SQLreader.GetInt32("positionX")));
                    resourceStatus.Add("positionY", Convert.ToString(SQLreader.GetInt32("positionY")));
                    resourceStatus.Add("positionZ", Convert.ToString(SQLreader.GetInt32("positionZ")));
                    resourceStatus.Add("isNearWindow", SQLreader.GetString("isNearWindow"));
                    resourceStatus.Add("isWithPower", SQLreader.GetString("isWithPower"));
                    resourceStatus.Add("isUsable", SQLreader.GetString("isUsable"));
                }
                return Error.OP_SUCCESS;
                // do something
            }
            catch (KeyNotFoundException e)
            {
#if (DEBUG_ResourceDetail)
                Console.WriteLine(e.Message);
#endif
                return Error.PARAM_FORMAT_ERROR;
            }
            catch (ArgumentNullException e)
            {
#if (DEBUG_ResourceDetail)
                Console.WriteLine(e.Message);
#endif
                return Error.PARAM_FORMAT_ERROR;
            }
            catch (FormatException e)
            {
#if (DEBUG_ResourceDetail)
                Console.WriteLine(e.Message);
#endif
                return Error.PARAM_FORMAT_ERROR;
            }
            catch (OverflowException e)
            {
#if (DEBUG_ResourceDetail)
                Console.WriteLine(e.Message);
#endif
                return Error.OVERFLOW_ERROR;
            }
            catch (MySqlException e)
            {
#if (DEBUG_ResourceDetail)
                Console.WriteLine(
                    "Catch exception from cmd.ExecuteNonQuery(): " 
                    + e.Message + "Code:" + e.Code.ToString() +
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
}

// end of file