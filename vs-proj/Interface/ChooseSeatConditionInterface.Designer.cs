using System;
using Smobiler.Core;
namespace LibraryApp
{
    partial class ChooseSeatConditionInterface : Smobiler.Core.Controls.MobileForm
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
            this.ConditionTitle = new Smobiler.Core.Controls.Title();
            this.SearchSeatButton = new Smobiler.Core.Controls.Button();
            this.panel2 = new Smobiler.Core.Controls.Panel();
            this.windowConlabel = new Smobiler.Core.Controls.Label();
            this.powerConlabel = new Smobiler.Core.Controls.Label();
            this.windowCheckBox = new Smobiler.Core.Controls.CheckBox();
            this.powerCheckBox = new Smobiler.Core.Controls.CheckBox();
            this.EndTimeLabel = new Smobiler.Core.Controls.Label();
            this.StartTimeLabel = new Smobiler.Core.Controls.Label();
            this.StartTimePicker = new Smobiler.Core.Controls.DatePicker();
            this.EndTimePicker = new Smobiler.Core.Controls.DatePicker();
            // 
            // panel1
            // 
            this.panel1.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.ConditionTitle,
            this.SearchSeatButton,
            this.panel2});
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 500);
            // 
            // ConditionTitle
            // 
            this.ConditionTitle.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ConditionTitle.Location = new System.Drawing.Point(150, 250);
            this.ConditionTitle.Name = "ConditionTitle";
            this.ConditionTitle.Size = new System.Drawing.Size(100, 30);
            this.ConditionTitle.Text = "选座条件";
            // 
            // SearchSeatButton
            // 
            this.SearchSeatButton.FontSize = 15F;
            this.SearchSeatButton.Location = new System.Drawing.Point(98, 436);
            this.SearchSeatButton.Name = "SearchSeatButton";
            this.SearchSeatButton.Size = new System.Drawing.Size(100, 30);
            this.SearchSeatButton.Text = "开始搜索";
            this.SearchSeatButton.Press += new System.EventHandler(this.SearchSeatButton_Press);
            // 
            // panel2
            // 
            this.panel2.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.windowConlabel,
            this.powerConlabel,
            this.windowCheckBox,
            this.powerCheckBox,
            this.EndTimeLabel,
            this.StartTimeLabel,
            this.StartTimePicker,
            this.EndTimePicker});
            this.panel2.Location = new System.Drawing.Point(0, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 391);
            // 
            // windowConlabel
            // 
            this.windowConlabel.FontSize = 17F;
            this.windowConlabel.Location = new System.Drawing.Point(31, 116);
            this.windowConlabel.Name = "windowConlabel";
            this.windowConlabel.Size = new System.Drawing.Size(100, 35);
            this.windowConlabel.Text = "靠窗";
            // 
            // powerConlabel
            // 
            this.powerConlabel.FontSize = 17F;
            this.powerConlabel.Location = new System.Drawing.Point(31, 174);
            this.powerConlabel.Name = "powerConlabel";
            this.powerConlabel.Size = new System.Drawing.Size(100, 35);
            this.powerConlabel.Text = "有电源";
            // 
            // windowCheckBox
            // 
            this.windowCheckBox.Location = new System.Drawing.Point(164, 123);
            this.windowCheckBox.Name = "windowCheckBox";
            this.windowCheckBox.Size = new System.Drawing.Size(22, 22);
            this.windowCheckBox.Style = Smobiler.Core.Controls.CheckBoxStyle.Circular;
            // 
            // powerCheckBox
            // 
            this.powerCheckBox.Location = new System.Drawing.Point(164, 181);
            this.powerCheckBox.Name = "powerCheckBox";
            this.powerCheckBox.Size = new System.Drawing.Size(22, 22);
            this.powerCheckBox.Style = Smobiler.Core.Controls.CheckBoxStyle.Circular;
            // 
            // EndTimeLabel
            // 
            this.EndTimeLabel.FontSize = 17F;
            this.EndTimeLabel.Location = new System.Drawing.Point(31, 63);
            this.EndTimeLabel.Name = "EndTimeLabel";
            this.EndTimeLabel.Size = new System.Drawing.Size(100, 35);
            this.EndTimeLabel.Text = "结束时间";
            // 
            // StartTimeLabel
            // 
            this.StartTimeLabel.FontSize = 17F;
            this.StartTimeLabel.Location = new System.Drawing.Point(31, 14);
            this.StartTimeLabel.Name = "StartTimeLabel";
            this.StartTimeLabel.Size = new System.Drawing.Size(100, 35);
            this.StartTimeLabel.Text = "开始时间";
            // 
            // StartTimePicker
            // 
            this.StartTimePicker.BackColor = System.Drawing.Color.White;
            this.StartTimePicker.Location = new System.Drawing.Point(131, 14);
            this.StartTimePicker.Mode = Smobiler.Core.Controls.DatePickerMode.DateTime;
            this.StartTimePicker.Name = "StartTimePicker";
            this.StartTimePicker.Size = new System.Drawing.Size(162, 35);
            // 
            // EndTimePicker
            // 
            this.EndTimePicker.BackColor = System.Drawing.Color.White;
            this.EndTimePicker.Location = new System.Drawing.Point(131, 63);
            this.EndTimePicker.Mode = Smobiler.Core.Controls.DatePickerMode.DateTime;
            this.EndTimePicker.Name = "EndTimePicker";
            this.EndTimePicker.Size = new System.Drawing.Size(162, 35);
            // 
            // ChooseSeatConditionInterface
            // 
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.panel1});
            this.Name = "ChooseSeatConditionInterface";

        }
        #endregion

        private Smobiler.Core.Controls.Panel panel1;
        private Smobiler.Core.Controls.Title ConditionTitle;
        private Smobiler.Core.Controls.Button SearchSeatButton;
        private Smobiler.Core.Controls.Panel panel2;
        private Smobiler.Core.Controls.Label windowConlabel;
        private Smobiler.Core.Controls.Label powerConlabel;
        private Smobiler.Core.Controls.CheckBox windowCheckBox;
        private Smobiler.Core.Controls.CheckBox powerCheckBox;
        private Smobiler.Core.Controls.Label EndTimeLabel;
        private Smobiler.Core.Controls.Label StartTimeLabel;
        private Smobiler.Core.Controls.DatePicker StartTimePicker;
        private Smobiler.Core.Controls.DatePicker EndTimePicker;
    }
}