using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smobiler.Core;
using Smobiler.Core.Controls;
using cz;

namespace LibraryApp
{
    partial class LoginInterface : Smobiler.Core.Controls.MobileForm
    {
        DateTime toasttime;

        string password;

        public LoginInterface() : base()
        {
            //This call is required by the SmobilerForm.
            InitializeComponent();

            password = "";
        }

        private void LoginButton_Press(object sender, EventArgs e)
        {
            string username=UserNameInput.Text;
            string password = this.password;

            //根据登陆函数返回结果进行下一步
            switch(Login(username, password))
            {
                case Error.OK:
                    {
                        Toast("登录成功");
                        ManagerSystem.Instance.CurrentAccountId = username;
                        if (ManagerSystem.Instance.MyAccount.GetRole() == "user")
                        {
                            CommonUserInterface commonUserInterface = new CommonUserInterface();
                            Show(commonUserInterface);
                        }
                        else
                        {
                            AdministratorInterface administratorInterface = new AdministratorInterface();
                            Show(administratorInterface);
                        }
                    }
                    break;
                case Error.CONNECT_ERROR:
                    {
                        Toast("网络链接失败");
                    }
                    break;
                case Error.USER_PWD_ERROR:
                    {
                        Toast("密码错误");
                    }
                    break;
                case Error.USER_UNEXISTED:
                    {
                        Toast("用户不存在");
                    }
                    break;
                default:
                    {
                        Toast("未知错误");
                    }
                    break;
            }
        }

        private void RegiterButton_Press(object sender, EventArgs e)
        {
            RegiterInterface regiterInterface = new RegiterInterface();
            Show(regiterInterface);
        }

        private Error Login(string username, string password)
        {
            //登录操作
            //设置参数
            Dictionary<string, string> login_info = new Dictionary<string, string>();
            login_info.Add("usrID", username);
            login_info.Add("usrPwd", password);
            //调用服务方法
            return ManagerSystem.Instance.MyAccount.Login(ref login_info);
        }

        //has bug!!!!!!!!!!!!!!
        /// <summary>
        /// 手机自带回退按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmWork_KeyDown(object sender, KeyDownEventArgs e)
        {
            if (e.KeyCode == KeyCode.Back)
            {
                HandleToast();
            }
        }
        /// <summary>
        /// Toast
        /// </summary>
        private void HandleToast()
        {
            if (toasttime.AddSeconds(3) >= DateTime.Now)
            {
                this.Client.Exit();
            }
            else
            {
                toasttime = DateTime.Now;
                this.Toast("再按一次退出系统", ToastLength.SHORT);
            }
        }

        private void PasswordInput_TextChanged(object sender, EventArgs e)
        {
            if(PasswordInput.Text.Length>password.Length)
            {
                password += PasswordInput.Text[PasswordInput.Text.Length - 1];
                PasswordInput.Text=PasswordInput.Text.Replace(PasswordInput.Text[PasswordInput.Text.Length - 1], '*');
            }
            else
            {
                password=password.Remove(password.Length - 1, 1);
            }
        }
    }
}