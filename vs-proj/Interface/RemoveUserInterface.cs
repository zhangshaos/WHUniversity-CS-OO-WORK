using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smobiler.Core;
using Smobiler.Core.Controls;

namespace LibraryApp
{
    partial class RemoveUserInterface : Smobiler.Core.Controls.MobileForm
    {
        public RemoveUserInterface() : base()
        {
            //This call is required by the SmobilerForm.
            InitializeComponent();
        }

        private void SreachButton_Press(object sender, EventArgs e)
        {
//            Dictionary<string, string> user_info = new Dictionary<string, string>();
//            user_info.Add("usrID", UserIdTextBox.Text);
//            cz.Error r = ManagerSystem.Instance.MyAccount.DelUser(ref user_info);
//            switch(r)
//            {
//                case cz.Error.OK:
//                    {
//                        FillInfoShowPanel();
//                        InfoShowPanel.Visible = true;
//                        RemoveButton.Visible = true;
//                    }
//                    break;
//                case cz.Error.CONNECT_ERROR:
//                    {
//                        Toast("网络链接错误");
//                    }
//                    break;
//                default:
//                    {
//#if (DEBUG)
//                        Toast(r.ToString());
//#else
//                        Toast("未知错误");
//#endif
//                    }
//                    break;
            }


        private void RemoveButton_Press(object sender, EventArgs e)
        {
            Dictionary<string, string> user_info = new Dictionary<string, string>();
            user_info.Add("usrID", UserIdTextBox.Text);
            cz.Error r = ManagerSystem.Instance.MySuperAccount.DelUser(ref user_info);
            switch (r)
            {
                case cz.Error.OK:
                    {
                        Toast("删除成功");
                    }
                    break;
                case cz.Error.CONNECT_ERROR:
                    {
                        Toast("网络链接错误");
                    }
                    break;
                default:
                    {
#if (DEBUG)
                        Toast(r.ToString());
#else
                        Toast("未知错误");
#endif
                    }
                    break;
            }
        }

        //private void FillInfoShowPanel()
        //{

        //}
    }
}