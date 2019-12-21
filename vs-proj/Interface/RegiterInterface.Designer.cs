using System;
using Smobiler.Core;
namespace LibraryApp
{
    partial class RegiterInterface : Smobiler.Core.Controls.MobileForm
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
            this.panel1 = new Smobiler.Core.Controls.Panel();
            this.usernameLabel = new Smobiler.Core.Controls.Label();
            this.passwordLabel = new Smobiler.Core.Controls.Label();
            this.genderLabel = new Smobiler.Core.Controls.Label();
            this.name = new Smobiler.Core.Controls.Label();
            this.privilege = new Smobiler.Core.Controls.Label();
            this.genderChoice = new Smobiler.Core.Controls.SegmentedControl();
            this.privilegeChoice = new Smobiler.Core.Controls.SegmentedControl();
            this.nameInput = new Smobiler.Core.Controls.TextBox();
            this.usernameInput = new Smobiler.Core.Controls.TextBox();
            this.passwordInput = new Smobiler.Core.Controls.TextBox();
            this.RegiterBtn = new Smobiler.Core.Controls.Button();
            // 
            // panel1
            // 
            this.panel1.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.usernameLabel,
            this.passwordLabel,
            this.genderLabel,
            this.name,
            this.privilege,
            this.genderChoice,
            this.privilegeChoice,
            this.nameInput,
            this.usernameInput,
            this.passwordInput,
            this.RegiterBtn});
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 500);
            // 
            // usernameLabel
            // 
            this.usernameLabel.FontSize = 20F;
            this.usernameLabel.Location = new System.Drawing.Point(7, 209);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(100, 35);
            this.usernameLabel.Text = "新用户名";
            // 
            // passwordLabel
            // 
            this.passwordLabel.FontSize = 20F;
            this.passwordLabel.Location = new System.Drawing.Point(7, 250);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(100, 35);
            this.passwordLabel.Text = "新密码";
            // 
            // genderLabel
            // 
            this.genderLabel.FontSize = 20F;
            this.genderLabel.Location = new System.Drawing.Point(7, 165);
            this.genderLabel.Name = "genderLabel";
            this.genderLabel.Size = new System.Drawing.Size(100, 35);
            this.genderLabel.Text = "性别";
            // 
            // name
            // 
            this.name.FontSize = 20F;
            this.name.Location = new System.Drawing.Point(7, 121);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(100, 35);
            this.name.Text = "姓名";
            // 
            // privilege
            // 
            this.privilege.FontSize = 20F;
            this.privilege.Location = new System.Drawing.Point(7, 295);
            this.privilege.Name = "privilege";
            this.privilege.Size = new System.Drawing.Size(100, 35);
            this.privilege.Text = "权限";
            this.privilege.Visible = false;
            // 
            // genderChoice
            // 
            this.genderChoice.Items = new string[] {
        "男",
        "女"};
            this.genderChoice.Location = new System.Drawing.Point(116, 165);
            this.genderChoice.Name = "genderChoice";
            this.genderChoice.SelectedBackColor = System.Drawing.Color.DodgerBlue;
            this.genderChoice.SelectedColor = System.Drawing.Color.White;
            this.genderChoice.Size = new System.Drawing.Size(177, 35);
            this.genderChoice.UnSelectedBackColor = System.Drawing.Color.White;
            this.genderChoice.UnSelectedColor = System.Drawing.Color.DodgerBlue;
            // 
            // privilegeChoice
            // 
            this.privilegeChoice.Items = new string[] {
        "用户",
        "管理员"};
            this.privilegeChoice.Location = new System.Drawing.Point(116, 295);
            this.privilegeChoice.Name = "privilegeChoice";
            this.privilegeChoice.SelectedBackColor = System.Drawing.Color.DodgerBlue;
            this.privilegeChoice.SelectedColor = System.Drawing.Color.White;
            this.privilegeChoice.Size = new System.Drawing.Size(177, 35);
            this.privilegeChoice.UnSelectedBackColor = System.Drawing.Color.White;
            this.privilegeChoice.UnSelectedColor = System.Drawing.Color.DodgerBlue;
            this.privilegeChoice.Visible = false;
            // 
            // nameInput
            // 
            this.nameInput.Location = new System.Drawing.Point(116, 121);
            this.nameInput.Name = "nameInput";
            this.nameInput.Size = new System.Drawing.Size(177, 35);
            // 
            // usernameInput
            // 
            this.usernameInput.Location = new System.Drawing.Point(116, 209);
            this.usernameInput.Name = "usernameInput";
            this.usernameInput.Size = new System.Drawing.Size(177, 35);
            // 
            // passwordInput
            // 
            this.passwordInput.Location = new System.Drawing.Point(116, 250);
            this.passwordInput.Name = "passwordInput";
            this.passwordInput.Size = new System.Drawing.Size(177, 35);
            // 
            // RegiterBtn
            // 
            this.RegiterBtn.FontSize = 15F;
            this.RegiterBtn.Location = new System.Drawing.Point(88, 392);
            this.RegiterBtn.Name = "RegiterBtn";
            this.RegiterBtn.Size = new System.Drawing.Size(100, 30);
            this.RegiterBtn.Text = "注册";
            this.RegiterBtn.Press += new System.EventHandler(this.RegiterBtn_Press);
            // 
            // RegiterInterface
            // 
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.panel1});
            this.Name = "RegiterInterface";

        }
        #endregion

        private Smobiler.Core.Controls.Panel panel1;
        private Smobiler.Core.Controls.Label usernameLabel;
        private Smobiler.Core.Controls.Label passwordLabel;
        private Smobiler.Core.Controls.Label genderLabel;
        private Smobiler.Core.Controls.Label name;
        private Smobiler.Core.Controls.Label privilege;
        private Smobiler.Core.Controls.SegmentedControl genderChoice;
        private Smobiler.Core.Controls.SegmentedControl privilegeChoice;
        private Smobiler.Core.Controls.TextBox nameInput;
        private Smobiler.Core.Controls.TextBox usernameInput;
        private Smobiler.Core.Controls.TextBox passwordInput;
        private Smobiler.Core.Controls.Button RegiterBtn;
    }
}