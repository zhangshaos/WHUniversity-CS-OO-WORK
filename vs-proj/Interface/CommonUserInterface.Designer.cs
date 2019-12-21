using System;
using Smobiler.Core;
namespace LibraryApp
{
    partial class CommonUserInterface : Smobiler.Core.Controls.MobileForm
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
            Smobiler.Core.Controls.IconMenuViewGroup iconMenuViewGroup2 = new Smobiler.Core.Controls.IconMenuViewGroup();
            Smobiler.Core.Controls.IconMenuViewItem iconMenuViewItem3 = new Smobiler.Core.Controls.IconMenuViewItem();
            Smobiler.Core.Controls.IconMenuViewItem iconMenuViewItem4 = new Smobiler.Core.Controls.IconMenuViewItem();
            this.CommonUserCenterTitle = new Smobiler.Core.Controls.Title();
            this.iconMenuView1 = new Smobiler.Core.Controls.IconMenuView();
            this.CheckInButton = new Smobiler.Core.Controls.Button();
            this.CheckOutButton = new Smobiler.Core.Controls.Button();
            // 
            // CommonUserCenterTitle
            // 
            this.CommonUserCenterTitle.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.CommonUserCenterTitle.Location = new System.Drawing.Point(150, 250);
            this.CommonUserCenterTitle.Name = "CommonUserCenterTitle";
            this.CommonUserCenterTitle.Size = new System.Drawing.Size(100, 43);
            this.CommonUserCenterTitle.Text = "用户";
            // 
            // iconMenuView1
            // 
            iconMenuViewGroup2.FontSize = 0F;
            iconMenuViewGroup2.IconBorderRadius = 0;
            iconMenuViewGroup2.ItemHeight = 0;
            iconMenuViewItem3.Icon = "wheelchair";
            iconMenuViewItem3.ID = "chooseSeat";
            iconMenuViewItem3.ImageType = Smobiler.Core.Controls.ImageEx.ImageStyle.FontIcon;
            iconMenuViewItem3.Text = "选座";
            iconMenuViewItem4.Icon = "male";
            iconMenuViewItem4.ID = "UserInfo";
            iconMenuViewGroup2.Items.AddRange(new Smobiler.Core.Controls.IconMenuViewItem[] {
            iconMenuViewItem3,
            iconMenuViewItem4});
            this.iconMenuView1.Groups.AddRange(new Smobiler.Core.Controls.IconMenuViewGroup[] {
            iconMenuViewGroup2});
            this.iconMenuView1.Location = new System.Drawing.Point(0, 43);
            this.iconMenuView1.Name = "iconMenuView1";
            this.iconMenuView1.Size = new System.Drawing.Size(300, 393);
            this.iconMenuView1.ItemPress += new Smobiler.Core.Controls.IconMenuViewItemPressClickHandler(this.iconMenuView1_ItemPress);
            // 
            // CheckInButton
            // 
            this.CheckInButton.BackColor = System.Drawing.Color.DarkTurquoise;
            this.CheckInButton.FontSize = 17F;
            this.CheckInButton.Location = new System.Drawing.Point(0, 436);
            this.CheckInButton.Name = "CheckInButton";
            this.CheckInButton.Size = new System.Drawing.Size(300, 30);
            this.CheckInButton.Text = "签到";
            this.CheckInButton.Press += new System.EventHandler(this.CheckInButton_Press);
            // 
            // CheckOutButton
            // 
            this.CheckOutButton.BackColor = System.Drawing.Color.LightSlateGray;
            this.CheckOutButton.FontSize = 17F;
            this.CheckOutButton.Location = new System.Drawing.Point(0, 466);
            this.CheckOutButton.Name = "CheckOutButton";
            this.CheckOutButton.Size = new System.Drawing.Size(300, 34);
            this.CheckOutButton.Text = "签退";
            this.CheckOutButton.Press += new System.EventHandler(this.CheckOutButton_Press);
            // 
            // CommonUserInterface
            // 
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.CommonUserCenterTitle,
            this.iconMenuView1,
            this.CheckInButton,
            this.CheckOutButton});
            this.Name = "CommonUserInterface";

        }
        #endregion

        private Smobiler.Core.Controls.Title CommonUserCenterTitle;
        private Smobiler.Core.Controls.IconMenuView iconMenuView1;
        private Smobiler.Core.Controls.Button CheckInButton;
        private Smobiler.Core.Controls.Button CheckOutButton;
    }
}