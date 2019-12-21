using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smobiler.Core;
using Smobiler.Core.Controls;
using ExhibitResources;

namespace LibraryApp
{
    partial class SeatSearchResult : Smobiler.Core.Controls.MobileForm
    {
        private DateTime startTime;
        private DateTime endTime;

        public SeatSearchResult() : base()
        {
            //This call is required by the SmobilerForm.
            InitializeComponent();
        }

        public SeatSearchResult(List<int> SeatIdList,DateTime startTime,DateTime endTime) : this()
        {
            this.startTime = startTime;
            this.endTime = endTime;

            ListMenuViewGroup listMenuViewGroup1 = new Smobiler.Core.Controls.ListMenuViewGroup();
            listMenuViewGroup1.IconBorderRadius = 0;

            //临时计数器，搜索结果过多，后期优化
            int count = 0;

            if (SeatIdList != null)
                foreach (int id in SeatIdList)
                {
                    AddItemToSeatList(listMenuViewGroup1, id);


                    count++;
                    if (count > 10) break;

                }

            this.SeatList.Groups.AddRange(new Smobiler.Core.Controls.ListMenuViewGroup[] {
            listMenuViewGroup1});
        }

        private void AddItemToSeatList(ListMenuViewGroup listMenuViewGroup, int id)
        {
            Dictionary<string, string> seatDetail = new Dictionary<string, string>();
            switch(ManagerSystem.Instance.MyExhibitSeatHandle.ResourceDetail(id, ref seatDetail))
            {
                case Error.OP_SUCCESS:
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
#if (DEBUG)
                case Error.PARAM_FORMAT_ERROR:
                    {
                        Toast("错误：传递数据格式错误");
                    }
                    break;
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

            ListMenuViewItem listMenuViewItem = new Smobiler.Core.Controls.ListMenuViewItem();
            listMenuViewItem.Action = "预订";
            listMenuViewItem.Content = "座位号:"+seatDetail["resourceID"];
            listMenuViewItem.Icon = "wheelchair";
            listMenuViewItem.ImageType = Smobiler.Core.Controls.ImageEx.ImageStyle.FontIcon;
            listMenuViewItem.SubContent =
                "位置：" + seatDetail["positionX"] + "," + seatDetail["positionY"] + "," + seatDetail["positionZ"]
                + " 靠窗：" + (seatDetail["isNearWindow"] == "true" ? "是" : "否")
                + " 有电源：" + (seatDetail["isWithPower"] == "true" ? "是" : "否");
            listMenuViewGroup.Items.AddRange(new Smobiler.Core.Controls.ListMenuViewItem[] {
            listMenuViewItem});
        }

        private void SeatList_ItemActionPress(object sender, ListMenuViewItemPressEventArgs e)
        {
            //未测试
            try
            {
                cz.Error r = ManagerSystem.Instance.MyAccount.SetNewReservation(startTime, endTime, int.Parse(e.Item.Content.Split(':')[1]));
                switch (r)
                {
                    case cz.Error.OK:
                        {
                            Toast("预约成功");
                            Form.Close();
                        }
                        break;
                    case cz.Error.PARAM_FORMAT_ERROR:
                        {
                            Toast("您在该时间段已有预约");
                        }
                        break;
                    case cz.Error.CONNECT_ERROR:
                        {
                            Toast("网络连接错误");
                        }
                        break;
                    default:
                        {
#if (DEBUG)
                            Toast(r.ToString());
#endif
                            Toast("未知错误,预约失败");
                        }
                        break;
                }
            }
#if(DEBUG)
            catch(FormatException excrption)
            {
                Toast("资源ID格式错误");
            }
#endif
            catch(Exception excrption)
            {
                Toast("未知错误");
            }
        }


    }
}