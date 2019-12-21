using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smobiler.Core;
using Smobiler.Core.Controls;
using ExhibitResources;

namespace LibraryApp
{
    partial class ChooseSeatConditionInterface : Smobiler.Core.Controls.MobileForm
    {
        public ChooseSeatConditionInterface() : base()
        {
            //This call is required by the SmobilerForm.
            InitializeComponent();
        }

        private void SearchSeatButton_Press(object sender, EventArgs e)
        {
            if(StartTimePicker.Value.Date != EndTimePicker.Value.Date)
            {
                Toast("开始时间和结束时间必须在同一天");
                return;
            }
            if (StartTimePicker.Value.AddMinutes(30d) > EndTimePicker.Value)
            {
                Toast("结束时间需晚于开始时间30分钟以上");
                return;
            }

            Dictionary<string, string> searchCondition = new Dictionary<string, string>();
            if (windowCheckBox.Checked)
            {
                searchCondition.Add("isNearWindow", "1");
            }
            if (powerCheckBox.Checked)
            {
                searchCondition.Add("isWithPower", "1");
            }

            List<int> resultId;
            if (SearchSeat(searchCondition, out resultId))
            {
                SeatSearchResult seatSearchResult = new SeatSearchResult(resultId, StartTimePicker.Value, EndTimePicker.Value);
                Show(seatSearchResult);
            }
        }


        private bool SearchSeat(Dictionary<string, string> condition, out List<int> searchResults)
        {
            Dictionary<int, ResourcesPosition> result = new Dictionary<int, ResourcesPosition>();
            List<int> r = null;
            switch (ManagerSystem.Instance.MyExhibitSeatHandle.SieveAvaliable(condition, StartTimePicker.Value, EndTimePicker.Value, ref result))
            {
                case Error.OP_SUCCESS:
                    {
                        if (result.Count > 0)
                        {
                            searchResults = result.Keys.ToList();
                            return true;
                        }
                        else
                        {
                            //原来没有Error.QUERY_NO_RESULT时候使用，现在保留做个保险
                            Toast("没有符合条件的结果");
                        }
                    }
                    break;
                case Error.QUERY_NO_RESULT:
                    {
                        Toast("没有符合条件的结果");
                        Form.Close();
                    }
                    break;
                case Error.CONNECTION_ERROR:
                    {
                        Toast("网络链接错误");
                    }
                    break;
                case Error.RESERVED_ERROR:
                    {
                        Toast("你存在未处理的违约记录");
                        Form.Close();
                    }
                    break;
                case Error.PARAM_FORMAT_ERROR:
                    {
                        if (DateTime.Compare(StartTimePicker.Value, EndTimePicker.Value) >= 0)
                            Toast("开始时间不能晚于或等于结束时间");
                        else
                        {
#if (DEBUG)
                            Toast("错误：传递数据格式错误");
#else
                            Toast("未知错误");
#endif
                        }
                    }
                    break;
#if (DEBUG)
                case Error.OVERFLOW_ERROR:
                    {
                        Toast("错误：栈溢出");
                    }
                    break;
#endif
                default:
                    {
                        Toast("未知错误");
                    }
                    break;
            }
            searchResults = null;
            return false;
        }
    }
}