using System;
using Smobiler.Core;
namespace LibraryApp
{
    partial class LoginInterface : Smobiler.Core.Controls.MobileForm
    {
        #region "SmobilerForm generated code "

        //SmobilerForm overrides dispose to clean up the component list.
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }


        //NOTE: The following procedure is required by the SmobilerForm
        //It can be modified using the SmobilerForm.  
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.UserName = new Smobiler.Core.Controls.Label();
            this.Password = new Smobiler.Core.Controls.Label();
            this.UserNameInput = new Smobiler.Core.Controls.TextBox();
            this.PasswordInput = new Smobiler.Core.Controls.TextBox();
            this.LoginButton = new Smobiler.Core.Controls.Button();
            this.RegiterButton = new Smobiler.Core.Controls.Button();
            // 
            // UserName
            // 
            this.UserName.FontSize = 20F;
            this.UserName.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Center;
            this.UserName.Location = new System.Drawing.Point(12, 183);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(100, 35);
            this.UserName.Text = "用户名";
            // 
            // Password
            // 
            this.Password.FontSize = 20F;
            this.Password.HorizontalAlignment = Smobiler.Core.Controls.HorizontalAlignment.Center;
            this.Password.Location = new System.Drawing.Point(12, 239);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(100, 35);
            this.Password.Text = "密码";
            // 
            // UserNameInput
            // 
            this.UserNameInput.Location = new System.Drawing.Point(120, 183);
            this.UserNameInput.Name = "UserNameInput";
            this.UserNameInput.Size = new System.Drawing.Size(169, 35);
            // 
            // PasswordInput
            // 
            this.PasswordInput.Location = new System.Drawing.Point(120, 239);
            this.PasswordInput.Name = "PasswordInput";
            this.PasswordInput.Size = new System.Drawing.Size(169, 35);
            this.PasswordInput.TextChanged += new System.EventHandler(this.PasswordInput_TextChanged);
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(100, 300);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(100, 30);
            this.LoginButton.Text = "登录";
            this.LoginButton.Press += new System.EventHandler(this.LoginButton_Press);
            // 
            // RegiterButton
            // 
            this.RegiterButton.BackColor = System.Drawing.Color.Turquoise;
            this.RegiterButton.Location = new System.Drawing.Point(100, 343);
            this.RegiterButton.Name = "RegiterButton";
            this.RegiterButton.Size = new System.Drawing.Size(100, 30);
            this.RegiterButton.Text = "注册";
            this.RegiterButton.Press += new System.EventHandler(this.RegiterButton_Press);
            // 
            // LoginInterface
            // 
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.UserName,
            this.Password,
            this.UserNameInput,
            this.PasswordInput,
            this.LoginButton,
            this.RegiterButton});
            this.Name = "LoginInterface";

        }
        #endregion

        private Smobiler.Core.Controls.Label UserName;
        private Smobiler.Core.Controls.Label Password;
        private Smobiler.Core.Controls.TextBox UserNameInput;
        private Smobiler.Core.Controls.TextBox PasswordInput;
        private Smobiler.Core.Controls.Button LoginButton;
        private Smobiler.Core.Controls.Button RegiterButton;
    }
}