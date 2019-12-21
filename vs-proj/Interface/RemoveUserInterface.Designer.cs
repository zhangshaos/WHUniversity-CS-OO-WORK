using System;
using Smobiler.Core;
namespace LibraryApp
{
    partial class RemoveUserInterface : Smobiler.Core.Controls.MobileForm
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
            this.UserIdInputPanel = new Smobiler.Core.Controls.Panel();
            this.UserIdLabel = new Smobiler.Core.Controls.Label();
            this.UserIdTextBox = new Smobiler.Core.Controls.TextBox();
            this.SreachButton = new Smobiler.Core.Controls.Button();
            this.InfoShowPanel = new Smobiler.Core.Controls.Panel();
            this.ShowNameLabel = new Smobiler.Core.Controls.Label();
            this.ShowGenderLabel = new Smobiler.Core.Controls.Label();
            this.ShowPrivilegeWindowLabel = new Smobiler.Core.Controls.Label();
            this.RemoveButton = new Smobiler.Core.Controls.Button();
            // 
            // UserIdInputPanel
            // 
            this.UserIdInputPanel.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.UserIdLabel,
            this.UserIdTextBox});
            this.UserIdInputPanel.Location = new System.Drawing.Point(0, 55);
            this.UserIdInputPanel.Name = "UserIdInputPanel";
            this.UserIdInputPanel.Size = new System.Drawing.Size(300, 37);
            // 
            // UserIdLabel
            // 
            this.UserIdLabel.FontSize = 17F;
            this.UserIdLabel.Location = new System.Drawing.Point(34, 0);
            this.UserIdLabel.Name = "UserIdLabel";
            this.UserIdLabel.Size = new System.Drawing.Size(100, 35);
            this.UserIdLabel.Text = "用户号";
            // 
            // UserIdTextBox
            // 
            this.UserIdTextBox.Location = new System.Drawing.Point(134, 0);
            this.UserIdTextBox.Name = "UserIdTextBox";
            this.UserIdTextBox.Size = new System.Drawing.Size(132, 35);
            // 
            // SreachButton
            // 
            this.SreachButton.FontSize = 15F;
            this.SreachButton.Location = new System.Drawing.Point(86, 106);
            this.SreachButton.Name = "SreachButton";
            this.SreachButton.Size = new System.Drawing.Size(100, 30);
            this.SreachButton.Text = "搜索";
            this.SreachButton.Visible = false;
            this.SreachButton.Press += new System.EventHandler(this.SreachButton_Press);
            // 
            // InfoShowPanel
            // 
            this.InfoShowPanel.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.ShowNameLabel,
            this.ShowGenderLabel,
            this.ShowPrivilegeWindowLabel});
            this.InfoShowPanel.Location = new System.Drawing.Point(0, 151);
            this.InfoShowPanel.Name = "InfoShowPanel";
            this.InfoShowPanel.Size = new System.Drawing.Size(300, 178);
            this.InfoShowPanel.Visible = false;
            // 
            // ShowNameLabel
            // 
            this.ShowNameLabel.FontSize = 17F;
            this.ShowNameLabel.Location = new System.Drawing.Point(24, 3);
            this.ShowNameLabel.Name = "ShowNameLabel";
            this.ShowNameLabel.Size = new System.Drawing.Size(100, 35);
            this.ShowNameLabel.Text = "姓名";
            // 
            // ShowGenderLabel
            // 
            this.ShowGenderLabel.FontSize = 17F;
            this.ShowGenderLabel.Location = new System.Drawing.Point(24, 63);
            this.ShowGenderLabel.Name = "ShowGenderLabel";
            this.ShowGenderLabel.Size = new System.Drawing.Size(100, 35);
            this.ShowGenderLabel.Text = "性别";
            // 
            // ShowPrivilegeWindowLabel
            // 
            this.ShowPrivilegeWindowLabel.FontSize = 17F;
            this.ShowPrivilegeWindowLabel.Location = new System.Drawing.Point(24, 122);
            this.ShowPrivilegeWindowLabel.Name = "ShowPrivilegeWindowLabel";
            this.ShowPrivilegeWindowLabel.Size = new System.Drawing.Size(100, 35);
            this.ShowPrivilegeWindowLabel.Text = "权限";
            // 
            // RemoveButton
            // 
            this.RemoveButton.FontSize = 15F;
            this.RemoveButton.Location = new System.Drawing.Point(86, 363);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(100, 30);
            this.RemoveButton.Text = "删除";
            this.RemoveButton.Press += new System.EventHandler(this.RemoveButton_Press);
            // 
            // RemoveUserInterface
            // 
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.UserIdInputPanel,
            this.SreachButton,
            this.InfoShowPanel,
            this.RemoveButton});
            this.Name = "RemoveUserInterface";

        }
        #endregion

        private Smobiler.Core.Controls.Panel UserIdInputPanel;
        private Smobiler.Core.Controls.Label UserIdLabel;
        private Smobiler.Core.Controls.TextBox UserIdTextBox;
        private Smobiler.Core.Controls.Button SreachButton;
        private Smobiler.Core.Controls.Panel InfoShowPanel;
        private Smobiler.Core.Controls.Label ShowNameLabel;
        private Smobiler.Core.Controls.Label ShowGenderLabel;
        private Smobiler.Core.Controls.Label ShowPrivilegeWindowLabel;
        private Smobiler.Core.Controls.Button RemoveButton;
    }
}