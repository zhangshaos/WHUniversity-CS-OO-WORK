using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smobiler.Core;
using Smobiler.Core.Controls;

namespace LibraryApp
{
    partial class CommonUserInterface : Smobiler.Core.Controls.MobileForm
    {
        public CommonUserInterface() : base()
        {
            //This call is required by the SmobilerForm.
            InitializeComponent();
            CommonUserCenterTitle.Text = "用户：" + ManagerSystem.Instance.CurrentAccountId;
        }

        private void iconMenuView1_ItemPress(object sender, IconMenuViewItemPressEventArgs e)
        {
            MenuItem(e.Item.ID);
        }

        /// <summary>
        /// 菜单点击事件方法
        /// </summary>
        /// <param name="id"></param>
        private void MenuItem(string id)
        {
            switch(id)
            {
                case "chooseSeat":
                    {
                        ChooseSeatConditionInterface chooseSeatConditionInterface = new ChooseSeatConditionInterface();
                        Show(chooseSeatConditionInterface);
                    }
                    break;
                case "UserInfo":
                    {
                        UserInfo userInfo = new UserInfo();
                        Show(userInfo);
                    }
                    break;
            }
        }

        private void CheckInButton_Press(object sender, EventArgs e)
        {
            switch (ManagerSystem.Instance.MyAccount.CheckIn(DateTime.Now))
            {
                case cz.Error.OK:
                    {
                        Toast("签到成功，签到时间："+DateTime.Now);
                    }
                    break;
                case cz.Error.USER_BANNED:
                    {
                        Toast("由于迟到早退，您的账户已被禁用");
                    }
                    break;
                case cz.Error.USER_ALREADY_CHECKED_IN:
                    {
                        Toast("您已签到");
                    }
                    break;
                case cz.Error.USER_ARRIVE_TOO_EARLY:
                    {
                        Toast("未到预约时间");
                    }
                    break;
                case cz.Error.RCD_NO_AVALIABLE_RESERVATION:
                    {
                        Toast("无可用预约");
                    }
                    break;
                case cz.Error.CONNECT_ERROR:
                    {
                        Toast("网络错误");
                    }
                    break;
                default:
                    {
                        Toast("签到失败");
                    }
                    break;
            }

        }

        private void CheckOutButton_Press(object sender, EventArgs e)
        {
            switch (ManagerSystem.Instance.MyAccount.CheckOut(DateTime.Now))
            {
                case cz.Error.OK:
                    {
                        Toast("签退成功，签退时间：" + DateTime.Now);
                    }
                    break;
                case cz.Error.USER_ALREADY_CHECKED_OUT:
                    {
                        Toast("当前无使用中预约");
                    }
                    break;
                case cz.Error.CONNECT_ERROR:
                    {
                        Toast("网络错误");
                    }
                    break;
                default:
                    {
                        Toast("签退失败");
                    }
                    break;
            }
        }
    }
}