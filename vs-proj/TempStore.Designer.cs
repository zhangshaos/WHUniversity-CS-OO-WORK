using System;
using Smobiler.Core;
namespace 图书馆系统APP
{
    partial class TempStore : Smobiler.Core.Controls.MobileForm
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
            this.mySqlDataAdapter1 = new MySql.Data.MySqlClient.MySqlDataAdapter();
            this.AddButton = new Smobiler.Core.Controls.Button();
            this.ResourceIdInputPanel = new Smobiler.Core.Controls.Panel();
            this.ResourceIdLabel = new Smobiler.Core.Controls.Label();
            this.ResourceIdTextBox = new Smobiler.Core.Controls.TextBox();
            this.InfoShowPanel = new Smobiler.Core.Controls.Panel();
            this.ShowPosLabel = new Smobiler.Core.Controls.Label();
            this.ShowUsableLabel = new Smobiler.Core.Controls.Label();
            this.ShowIsNearWindowLabel = new Smobiler.Core.Controls.Label();
            this.ShowWithPowerLabel = new Smobiler.Core.Controls.Label();
            this.SreachButton = new Smobiler.Core.Controls.Button();
            this.RemoveButton = new Smobiler.Core.Controls.Button();
            this.UpdateButton = new Smobiler.Core.Controls.Button();
            this.InfoInputPanel = new Smobiler.Core.Controls.Panel();
            this.YorNChoice3 = new Smobiler.Core.Controls.SegmentedControl();
            this.YorNChoice2 = new Smobiler.Core.Controls.SegmentedControl();
            this.YorNChoice1 = new Smobiler.Core.Controls.SegmentedControl();
            this.PosZTextBox = new Smobiler.Core.Controls.TextBox();
            this.PosYTextBox = new Smobiler.Core.Controls.TextBox();
            this.PosXTextBox = new Smobiler.Core.Controls.TextBox();
            this.WithPowerLabel = new Smobiler.Core.Controls.Label();
            this.IsNearWindowLabel = new Smobiler.Core.Controls.Label();
            this.IsUsableLabel = new Smobiler.Core.Controls.Label();
            this.PosZLabel = new Smobiler.Core.Controls.Label();
            this.PosYLabel = new Smobiler.Core.Controls.Label();
            this.PosXLabel = new Smobiler.Core.Controls.Label();
            this.PosLabel = new Smobiler.Core.Controls.Label();
            // 
            // mySqlDataAdapter1
            // 
            this.mySqlDataAdapter1.DeleteCommand = null;
            this.mySqlDataAdapter1.InsertCommand = null;
            this.mySqlDataAdapter1.SelectCommand = null;
            this.mySqlDataAdapter1.UpdateCommand = null;
            // 
            // AddButton
            // 
            this.AddButton.FontSize = 15F;
            this.AddButton.Location = new System.Drawing.Point(81, 434);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(100, 30);
            this.AddButton.Text = "添加";
            // 
            // ResourceIdInputPanel
            // 
            this.ResourceIdInputPanel.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.ResourceIdLabel,
            this.ResourceIdTextBox});
            this.ResourceIdInputPanel.Location = new System.Drawing.Point(0, 148);
            this.ResourceIdInputPanel.Name = "ResourceIdInputPanel";
            this.ResourceIdInputPanel.Size = new System.Drawing.Size(300, 37);
            // 
            // ResourceIdLabel
            // 
            this.ResourceIdLabel.FontSize = 17F;
            this.ResourceIdLabel.Location = new System.Drawing.Point(34, 0);
            this.ResourceIdLabel.Name = "ResourceIdLabel";
            this.ResourceIdLabel.Size = new System.Drawing.Size(100, 35);
            this.ResourceIdLabel.Text = "资源号";
            // 
            // ResourceIdTextBox
            // 
            this.ResourceIdTextBox.Location = new System.Drawing.Point(134, 0);
            this.ResourceIdTextBox.Name = "ResourceIdTextBox";
            this.ResourceIdTextBox.Size = new System.Drawing.Size(132, 35);
            // 
            // InfoShowPanel
            // 
            this.InfoShowPanel.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.ShowPosLabel,
            this.ShowUsableLabel,
            this.ShowIsNearWindowLabel,
            this.ShowWithPowerLabel});
            this.InfoShowPanel.Location = new System.Drawing.Point(0, 151);
            this.InfoShowPanel.Name = "InfoShowPanel";
            this.InfoShowPanel.Size = new System.Drawing.Size(300, 203);
            // 
            // ShowPosLabel
            // 
            this.ShowPosLabel.FontSize = 17F;
            this.ShowPosLabel.Location = new System.Drawing.Point(24, 3);
            this.ShowPosLabel.Name = "ShowPosLabel";
            this.ShowPosLabel.Size = new System.Drawing.Size(100, 35);
            this.ShowPosLabel.Text = "位置";
            // 
            // ShowUsableLabel
            // 
            this.ShowUsableLabel.FontSize = 17F;
            this.ShowUsableLabel.Location = new System.Drawing.Point(24, 63);
            this.ShowUsableLabel.Name = "ShowUsableLabel";
            this.ShowUsableLabel.Size = new System.Drawing.Size(100, 35);
            this.ShowUsableLabel.Text = "是否可用";
            // 
            // ShowIsNearWindowLabel
            // 
            this.ShowIsNearWindowLabel.FontSize = 17F;
            this.ShowIsNearWindowLabel.Location = new System.Drawing.Point(24, 113);
            this.ShowIsNearWindowLabel.Name = "ShowIsNearWindowLabel";
            this.ShowIsNearWindowLabel.Size = new System.Drawing.Size(100, 35);
            this.ShowIsNearWindowLabel.Text = "是否靠窗";
            // 
            // ShowWithPowerLabel
            // 
            this.ShowWithPowerLabel.FontSize = 17F;
            this.ShowWithPowerLabel.Location = new System.Drawing.Point(24, 164);
            this.ShowWithPowerLabel.Name = "ShowWithPowerLabel";
            this.ShowWithPowerLabel.Size = new System.Drawing.Size(100, 35);
            this.ShowWithPowerLabel.Text = "是否有电源";
            // 
            // SreachButton
            // 
            this.SreachButton.FontSize = 15F;
            this.SreachButton.Location = new System.Drawing.Point(81, 434);
            this.SreachButton.Name = "SreachButton";
            this.SreachButton.Size = new System.Drawing.Size(100, 30);
            this.SreachButton.Text = "搜索";
            // 
            // RemoveButton
            // 
            this.RemoveButton.FontSize = 15F;
            this.RemoveButton.Location = new System.Drawing.Point(81, 434);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(100, 30);
            this.RemoveButton.Text = "删除";
            // 
            // UpdateButton
            // 
            this.UpdateButton.FontSize = 15F;
            this.UpdateButton.Location = new System.Drawing.Point(81, 434);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(100, 30);
            this.UpdateButton.Text = "修改";
            // 
            // InfoInputPanel
            // 
            this.InfoInputPanel.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.PosLabel,
            this.PosXLabel,
            this.PosYLabel,
            this.PosZLabel,
            this.IsUsableLabel,
            this.IsNearWindowLabel,
            this.WithPowerLabel,
            this.PosXTextBox,
            this.PosYTextBox,
            this.PosZTextBox,
            this.YorNChoice1,
            this.YorNChoice2,
            this.YorNChoice3});
            this.InfoInputPanel.Location = new System.Drawing.Point(0, 185);
            this.InfoInputPanel.Name = "InfoInputPanel";
            this.InfoInputPanel.Size = new System.Drawing.Size(300, 203);
            // 
            // YorNChoice3
            // 
            this.YorNChoice3.Items = new string[] {
        "是",
        "否"};
            this.YorNChoice3.Location = new System.Drawing.Point(124, 171);
            this.YorNChoice3.Name = "YorNChoice3";
            this.YorNChoice3.SelectedBackColor = System.Drawing.Color.DodgerBlue;
            this.YorNChoice3.SelectedColor = System.Drawing.Color.White;
            this.YorNChoice3.Size = new System.Drawing.Size(137, 35);
            this.YorNChoice3.UnSelectedBackColor = System.Drawing.Color.White;
            this.YorNChoice3.UnSelectedColor = System.Drawing.Color.DodgerBlue;
            // 
            // YorNChoice2
            // 
            this.YorNChoice2.Items = new string[] {
        "是",
        "否"};
            this.YorNChoice2.Location = new System.Drawing.Point(124, 128);
            this.YorNChoice2.Name = "YorNChoice2";
            this.YorNChoice2.SelectedBackColor = System.Drawing.Color.DodgerBlue;
            this.YorNChoice2.SelectedColor = System.Drawing.Color.White;
            this.YorNChoice2.Size = new System.Drawing.Size(137, 35);
            this.YorNChoice2.UnSelectedBackColor = System.Drawing.Color.White;
            this.YorNChoice2.UnSelectedColor = System.Drawing.Color.DodgerBlue;
            // 
            // YorNChoice1
            // 
            this.YorNChoice1.Items = new string[] {
        "是",
        "否"};
            this.YorNChoice1.Location = new System.Drawing.Point(124, 85);
            this.YorNChoice1.Name = "YorNChoice1";
            this.YorNChoice1.SelectedBackColor = System.Drawing.Color.DodgerBlue;
            this.YorNChoice1.SelectedColor = System.Drawing.Color.White;
            this.YorNChoice1.Size = new System.Drawing.Size(137, 35);
            this.YorNChoice1.UnSelectedBackColor = System.Drawing.Color.White;
            this.YorNChoice1.UnSelectedColor = System.Drawing.Color.DodgerBlue;
            // 
            // PosZTextBox
            // 
            this.PosZTextBox.Location = new System.Drawing.Point(207, 38);
            this.PosZTextBox.Name = "PosZTextBox";
            this.PosZTextBox.Size = new System.Drawing.Size(48, 35);
            // 
            // PosYTextBox
            // 
            this.PosYTextBox.Location = new System.Drawing.Point(124, 38);
            this.PosYTextBox.Name = "PosYTextBox";
            this.PosYTextBox.Size = new System.Drawing.Size(48, 35);
            // 
            // PosXTextBox
            // 
            this.PosXTextBox.Location = new System.Drawing.Point(46, 38);
            this.PosXTextBox.Name = "PosXTextBox";
            this.PosXTextBox.Size = new System.Drawing.Size(48, 35);
            // 
            // WithPowerLabel
            // 
            this.WithPowerLabel.FontSize = 17F;
            this.WithPowerLabel.Location = new System.Drawing.Point(24, 171);
            this.WithPowerLabel.Name = "WithPowerLabel";
            this.WithPowerLabel.Size = new System.Drawing.Size(100, 35);
            this.WithPowerLabel.Text = "是否有电源";
            // 
            // IsNearWindowLabel
            // 
            this.IsNearWindowLabel.FontSize = 17F;
            this.IsNearWindowLabel.Location = new System.Drawing.Point(24, 128);
            this.IsNearWindowLabel.Name = "IsNearWindowLabel";
            this.IsNearWindowLabel.Size = new System.Drawing.Size(100, 35);
            this.IsNearWindowLabel.Text = "是否靠窗";
            // 
            // IsUsableLabel
            // 
            this.IsUsableLabel.FontSize = 17F;
            this.IsUsableLabel.Location = new System.Drawing.Point(24, 85);
            this.IsUsableLabel.Name = "IsUsableLabel";
            this.IsUsableLabel.Size = new System.Drawing.Size(100, 35);
            this.IsUsableLabel.Text = "是否可用";
            // 
            // PosZLabel
            // 
            this.PosZLabel.Location = new System.Drawing.Point(185, 38);
            this.PosZLabel.Name = "PosZLabel";
            this.PosZLabel.Size = new System.Drawing.Size(22, 35);
            this.PosZLabel.Text = "Z";
            // 
            // PosYLabel
            // 
            this.PosYLabel.Location = new System.Drawing.Point(102, 38);
            this.PosYLabel.Name = "PosYLabel";
            this.PosYLabel.Size = new System.Drawing.Size(22, 35);
            this.PosYLabel.Text = "Y";
            // 
            // PosXLabel
            // 
            this.PosXLabel.Location = new System.Drawing.Point(24, 38);
            this.PosXLabel.Name = "PosXLabel";
            this.PosXLabel.Size = new System.Drawing.Size(22, 35);
            this.PosXLabel.Text = "X";
            // 
            // PosLabel
            // 
            this.PosLabel.FontSize = 17F;
            this.PosLabel.Location = new System.Drawing.Point(24, 3);
            this.PosLabel.Name = "PosLabel";
            this.PosLabel.Size = new System.Drawing.Size(100, 35);
            this.PosLabel.Text = "位置";
            // 
            // TempStore
            // 
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.InfoInputPanel,
            this.AddButton,
            this.ResourceIdInputPanel,
            this.InfoShowPanel,
            this.SreachButton,
            this.RemoveButton,
            this.UpdateButton});
            this.Name = "TempStore";

        }
        #endregion
        private MySql.Data.MySqlClient.MySqlDataAdapter mySqlDataAdapter1;
        private Smobiler.Core.Controls.Button AddButton;
        private Smobiler.Core.Controls.Panel ResourceIdInputPanel;
        private Smobiler.Core.Controls.Label ResourceIdLabel;
        private Smobiler.Core.Controls.TextBox ResourceIdTextBox;
        private Smobiler.Core.Controls.Panel InfoShowPanel;
        private Smobiler.Core.Controls.Label ShowPosLabel;
        private Smobiler.Core.Controls.Label ShowUsableLabel;
        private Smobiler.Core.Controls.Label ShowIsNearWindowLabel;
        private Smobiler.Core.Controls.Label ShowWithPowerLabel;
        private Smobiler.Core.Controls.Button SreachButton;
        private Smobiler.Core.Controls.Button RemoveButton;
        private Smobiler.Core.Controls.Button UpdateButton;
        private Smobiler.Core.Controls.Panel InfoInputPanel;
        private Smobiler.Core.Controls.Label PosLabel;
        private Smobiler.Core.Controls.Label PosXLabel;
        private Smobiler.Core.Controls.Label PosYLabel;
        private Smobiler.Core.Controls.Label PosZLabel;
        private Smobiler.Core.Controls.Label IsUsableLabel;
        private Smobiler.Core.Controls.Label IsNearWindowLabel;
        private Smobiler.Core.Controls.Label WithPowerLabel;
        private Smobiler.Core.Controls.TextBox PosXTextBox;
        private Smobiler.Core.Controls.TextBox PosYTextBox;
        private Smobiler.Core.Controls.TextBox PosZTextBox;
        private Smobiler.Core.Controls.SegmentedControl YorNChoice1;
        private Smobiler.Core.Controls.SegmentedControl YorNChoice2;
        private Smobiler.Core.Controls.SegmentedControl YorNChoice3;
    }
}