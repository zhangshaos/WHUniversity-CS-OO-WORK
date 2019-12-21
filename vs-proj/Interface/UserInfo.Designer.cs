using System;
using Smobiler.Core;
namespace LibraryApp
{
    partial class UserInfo : Smobiler.Core.Controls.MobileForm
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
            this.NameLabel = new Smobiler.Core.Controls.Label();
            this.GenderLabel = new Smobiler.Core.Controls.Label();
            this.IdLabel = new Smobiler.Core.Controls.Label();
            this.privilegeLabel = new Smobiler.Core.Controls.Label();
            // 
            // panel1
            // 
            this.panel1.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.NameLabel,
            this.GenderLabel,
            this.IdLabel,
            this.privilegeLabel});
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 500);
            // 
            // NameLabel
            // 
            this.NameLabel.FontSize = 17F;
            this.NameLabel.Location = new System.Drawing.Point(22, 116);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(258, 35);
            this.NameLabel.Text = "姓名：";
            // 
            // GenderLabel
            // 
            this.GenderLabel.FontSize = 17F;
            this.GenderLabel.Location = new System.Drawing.Point(22, 151);
            this.GenderLabel.Name = "GenderLabel";
            this.GenderLabel.Size = new System.Drawing.Size(258, 35);
            this.GenderLabel.Text = "性别：";
            // 
            // IdLabel
            // 
            this.IdLabel.FontSize = 17F;
            this.IdLabel.Location = new System.Drawing.Point(22, 186);
            this.IdLabel.Name = "IdLabel";
            this.IdLabel.Size = new System.Drawing.Size(258, 35);
            this.IdLabel.Text = "用户名(ID)：";
            // 
            // privilegeLabel
            // 
            this.privilegeLabel.FontSize = 17F;
            this.privilegeLabel.Location = new System.Drawing.Point(22, 221);
            this.privilegeLabel.Name = "privilegeLabel";
            this.privilegeLabel.Size = new System.Drawing.Size(258, 35);
            this.privilegeLabel.Text = "权限：";
            // 
            // UserInfo
            // 
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.panel1});
            this.Name = "UserInfo";

        }
        #endregion

        private Smobiler.Core.Controls.Panel panel1;
        private Smobiler.Core.Controls.Label NameLabel;
        private Smobiler.Core.Controls.Label GenderLabel;
        private Smobiler.Core.Controls.Label IdLabel;
        private Smobiler.Core.Controls.Label privilegeLabel;
    }
}