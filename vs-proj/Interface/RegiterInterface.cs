using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smobiler.Core;
using Smobiler.Core.Controls;
using cz;

namespace LibraryApp
{
    partial class RegiterInterface : Smobiler.Core.Controls.MobileForm
    {
        public RegiterInterface() : base()
        {
            //This call is required by the SmobilerForm.
            InitializeComponent();
        }

        private void RegiterBtn_Press(object sender, EventArgs e)
        {
            string name = nameInput.Text;
            string gender = genderChoice.SelectedItem;//string gender = (genderChoice.SelectedItem == "男") ? "male" : "female";
            string stu_id = usernameInput.Text;
            string pwd = passwordInput.Text;
            string privilege = (privilegeChoice.SelectedItem == "管理员") ? "1" : "0";
            switch(Register(name, gender, stu_id, pwd, privilege))
            {
                case Error.OK:
                    {
                        Toast("注册成功");
                        this.Form.Close();
                    }
                    break;
                case Error.CONNECT_ERROR:
                    {
                        Toast("网络链接失败");
                    }
                    break;
                case Error.USER_REGISTERED:
                    {
                        Toast("该用户已注册");
                    }
                    break;
#if DEBUG
                case Error.PARAM_FORMAT_ERROR:
                    {
                        Toast("参数格式错误");
                    }
                    break;
#endif
                default:
                    {
                        Toast("未知错误");
                    }
                    break;
            }
        }

        private Error Register(string name, string gender, string stu_id, string pwd, string privilege)
        {
            //整合注册信息
            Dictionary<string, string> register_info = new Dictionary<string, string>();
            register_info.Add("name", name);
            register_info.Add("gender", gender);
            register_info.Add("usrID", stu_id);
            register_info.Add("usrPwd", pwd);
            register_info.Add("privilege", privilege);


            return ManagerSystem.Instance.MyAccount.Register(ref register_info);
        }
    }
}