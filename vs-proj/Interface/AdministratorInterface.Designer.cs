using System;
using Smobiler.Core;
namespace LibraryApp
{
    partial class AdministratorInterface : Smobiler.Core.Controls.MobileForm
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
            Smobiler.Core.Controls.IconMenuViewGroup iconMenuViewGroup1 = new Smobiler.Core.Controls.IconMenuViewGroup();
            Smobiler.Core.Controls.IconMenuViewItem iconMenuViewItem1 = new Smobiler.Core.Controls.IconMenuViewItem();
            Smobiler.Core.Controls.IconMenuViewItem iconMenuViewItem2 = new Smobiler.Core.Controls.IconMenuViewItem();
            this.panel1 = new Smobiler.Core.Controls.Panel();
            this.AdministratorTitle = new Smobiler.Core.Controls.Title();
            this.AbilityMenuView = new Smobiler.Core.Controls.IconMenuView();
            // 
            // panel1
            // 
            this.panel1.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.AdministratorTitle,
            this.AbilityMenuView});
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 500);
            // 
            // AdministratorTitle
            // 
            this.AdministratorTitle.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.AdministratorTitle.Location = new System.Drawing.Point(63, 109);
            this.AdministratorTitle.Name = "AdministratorTitle";
            this.AdministratorTitle.Size = new System.Drawing.Size(100, 40);
            // 
            // AbilityMenuView
            // 
            iconMenuViewGroup1.FontSize = 0F;
            iconMenuViewGroup1.IconBorderRadius = 0;
            iconMenuViewGroup1.ItemHeight = 0;
            iconMenuViewItem1.Icon = "folder-o";
            iconMenuViewItem1.ID = "ResourceManage";
            iconMenuViewItem1.ImageType = Smobiler.Core.Controls.ImageEx.ImageStyle.FontIcon;
            iconMenuViewItem1.Text = "资源管理";
            iconMenuViewItem2.Icon = "male";
            iconMenuViewItem2.ID = "RemoveUser";
            iconMenuViewItem2.ImageType = Smobiler.Core.Controls.ImageEx.ImageStyle.FontIcon;
            iconMenuViewItem2.Text = "移除用户";
            iconMenuViewGroup1.Items.AddRange(new Smobiler.Core.Controls.IconMenuViewItem[] {
            iconMenuViewItem1,
            iconMenuViewItem2});
            this.AbilityMenuView.Groups.AddRange(new Smobiler.Core.Controls.IconMenuViewGroup[] {
            iconMenuViewGroup1});
            this.AbilityMenuView.Location = new System.Drawing.Point(0, 40);
            this.AbilityMenuView.Name = "AbilityMenuView";
            this.AbilityMenuView.Size = new System.Drawing.Size(300, 300);
            this.AbilityMenuView.ItemPress += new Smobiler.Core.Controls.IconMenuViewItemPressClickHandler(this.AbilityMenuView_ItemPress);
            // 
            // AdministratorInterface
            // 
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.panel1});
            this.Name = "AdministratorInterface";

        }
        #endregion

        private Smobiler.Core.Controls.Panel panel1;
        private Smobiler.Core.Controls.Title AdministratorTitle;
        private Smobiler.Core.Controls.IconMenuView AbilityMenuView;
    }
}