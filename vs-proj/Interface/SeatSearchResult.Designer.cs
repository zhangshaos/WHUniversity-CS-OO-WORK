using System;
using Smobiler.Core;
namespace LibraryApp
{
    partial class SeatSearchResult : Smobiler.Core.Controls.MobileForm
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
            this.SeatSearchResultTitle = new Smobiler.Core.Controls.Title();
            this.SeatList = new Smobiler.Core.Controls.ListMenuView();
            // 
            // panel1
            // 
            this.panel1.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.SeatSearchResultTitle,
            this.SeatList});
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 500);
            // 
            // SeatSearchResultTitle
            // 
            this.SeatSearchResultTitle.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.SeatSearchResultTitle.Location = new System.Drawing.Point(150, 250);
            this.SeatSearchResultTitle.Name = "SeatSearchResultTitle";
            this.SeatSearchResultTitle.Size = new System.Drawing.Size(100, 30);
            this.SeatSearchResultTitle.Text = "选座查找结果";
            // 
            // SeatList
            // 
            this.SeatList.Location = new System.Drawing.Point(0, 30);
            this.SeatList.Name = "SeatList";
            this.SeatList.Size = new System.Drawing.Size(300, 470);
            this.SeatList.ItemActionPress += new Smobiler.Core.Controls.ListMenuViewItemPressEventHandler(this.SeatList_ItemActionPress);
            // 
            // SeatSearchResult
            // 
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.panel1});
            this.Name = "SeatSearchResult";

        }
        #endregion

        private Smobiler.Core.Controls.Panel panel1;
        private Smobiler.Core.Controls.Title SeatSearchResultTitle;
        private Smobiler.Core.Controls.ListMenuView SeatList;
    }
}