using System;
using Smobiler.Core;
namespace LibraryApp
{
    partial class ResourceManageInterface : Smobiler.Core.Controls.MobileForm
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
            this.BasePanel = new Smobiler.Core.Controls.Panel();
            this.ManageChoice = new Smobiler.Core.Controls.SegmentedControl();
            this.ResourceIdInputPanel = new Smobiler.Core.Controls.Panel();
            this.ResourceIdLabel = new Smobiler.Core.Controls.Label();
            this.ResourceIdTextBox = new Smobiler.Core.Controls.TextBox();
            this.SreachButton = new Smobiler.Core.Controls.Button();
            this.InfoInputPanel = new Smobiler.Core.Controls.Panel();
            this.PosLabel = new Smobiler.Core.Controls.Label();
            this.PosXLabel = new Smobiler.Core.Controls.Label();
            this.PosYLabel = new Smobiler.Core.Controls.Label();
            this.PosZLabel = new Smobiler.Core.Controls.Label();
            this.IsUsableLabel = new Smobiler.Core.Controls.Label();
            this.IsNearWindowLabel = new Smobiler.Core.Controls.Label();
            this.WithPowerLabel = new Smobiler.Core.Controls.Label();
            this.PosXTextBox = new Smobiler.Core.Controls.TextBox();
            this.PosYTextBox = new Smobiler.Core.Controls.TextBox();
            this.PosZTextBox = new Smobiler.Core.Controls.TextBox();
            this.YorNChoice1 = new Smobiler.Core.Controls.SegmentedControl();
            this.YorNChoice2 = new Smobiler.Core.Controls.SegmentedControl();
            this.YorNChoice3 = new Smobiler.Core.Controls.SegmentedControl();
            this.InfoShowPanel = new Smobiler.Core.Controls.Panel();
            this.PosShowLabel = new Smobiler.Core.Controls.Label();
            this.ShowUsableLabel = new Smobiler.Core.Controls.Label();
            this.ShowIsNearWindowLabel = new Smobiler.Core.Controls.Label();
            this.ShowWithPowerLabel = new Smobiler.Core.Controls.Label();
            this.AddButton = new Smobiler.Core.Controls.Button();
            this.UpdateButton = new Smobiler.Core.Controls.Button();
            this.RemoveButton = new Smobiler.Core.Controls.Button();
            // 
            // BasePanel
            // 
            this.BasePanel.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.ManageChoice,
            this.ResourceIdInputPanel,
            this.SreachButton,
            this.InfoInputPanel,
            this.InfoShowPanel,
            this.AddButton,
            this.UpdateButton,
            this.RemoveButton});
            this.BasePanel.Name = "BasePanel";
            this.BasePanel.Size = new System.Drawing.Size(300, 500);
            // 
            // ManageChoice
            // 
            this.ManageChoice.Items = new string[] {
        "添加",
        "删除",
        "修改",
        "查询"};
            this.ManageChoice.Location = new System.Drawing.Point(50, 39);
            this.ManageChoice.Name = "ManageChoice";
            this.ManageChoice.SelectedBackColor = System.Drawing.Color.DodgerBlue;
            this.ManageChoice.SelectedColor = System.Drawing.Color.White;
            this.ManageChoice.Size = new System.Drawing.Size(200, 35);
            this.ManageChoice.UnSelectedBackColor = System.Drawing.Color.White;
            this.ManageChoice.UnSelectedColor = System.Drawing.Color.DodgerBlue;
            this.ManageChoice.SelectedIndexChanged += new System.EventHandler(this.ManageChoice_SelectedIndexChanged);
            // 
            // ResourceIdInputPanel
            // 
            this.ResourceIdInputPanel.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.ResourceIdLabel,
            this.ResourceIdTextBox});
            this.ResourceIdInputPanel.Location = new System.Drawing.Point(0, 89);
            this.ResourceIdInputPanel.Name = "ResourceIdInputPanel";
            this.ResourceIdInputPanel.Size = new System.Drawing.Size(300, 37);
            this.ResourceIdInputPanel.Visible = false;
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
            // SreachButton
            // 
            this.SreachButton.FontSize = 15F;
            this.SreachButton.Location = new System.Drawing.Point(93, 134);
            this.SreachButton.Name = "SreachButton";
            this.SreachButton.Size = new System.Drawing.Size(100, 30);
            this.SreachButton.Text = "搜索";
            this.SreachButton.Visible = false;
            this.SreachButton.Press += new System.EventHandler(this.SreachButton_Press);
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
            this.InfoInputPanel.Location = new System.Drawing.Point(0, 146);
            this.InfoInputPanel.Name = "InfoInputPanel";
            this.InfoInputPanel.Size = new System.Drawing.Size(300, 203);
            this.InfoInputPanel.Visible = false;
            // 
            // PosLabel
            // 
            this.PosLabel.FontSize = 17F;
            this.PosLabel.Location = new System.Drawing.Point(24, 3);
            this.PosLabel.Name = "PosLabel";
            this.PosLabel.Size = new System.Drawing.Size(100, 35);
            this.PosLabel.Text = "位置";
            // 
            // PosXLabel
            // 
            this.PosXLabel.Location = new System.Drawing.Point(24, 38);
            this.PosXLabel.Name = "PosXLabel";
            this.PosXLabel.Size = new System.Drawing.Size(22, 35);
            this.PosXLabel.Text = "X";
            // 
            // PosYLabel
            // 
            this.PosYLabel.Location = new System.Drawing.Point(102, 38);
            this.PosYLabel.Name = "PosYLabel";
            this.PosYLabel.Size = new System.Drawing.Size(22, 35);
            this.PosYLabel.Text = "Y";
            // 
            // PosZLabel
            // 
            this.PosZLabel.Location = new System.Drawing.Point(185, 38);
            this.PosZLabel.Name = "PosZLabel";
            this.PosZLabel.Size = new System.Drawing.Size(22, 35);
            this.PosZLabel.Text = "Z";
            // 
            // IsUsableLabel
            // 
            this.IsUsableLabel.FontSize = 17F;
            this.IsUsableLabel.Location = new System.Drawing.Point(24, 85);
            this.IsUsableLabel.Name = "IsUsableLabel";
            this.IsUsableLabel.Size = new System.Drawing.Size(100, 35);
            this.IsUsableLabel.Text = "是否可用";
            // 
            // IsNearWindowLabel
            // 
            this.IsNearWindowLabel.FontSize = 17F;
            this.IsNearWindowLabel.Location = new System.Drawing.Point(24, 128);
            this.IsNearWindowLabel.Name = "IsNearWindowLabel";
            this.IsNearWindowLabel.Size = new System.Drawing.Size(100, 35);
            this.IsNearWindowLabel.Text = "是否靠窗";
            // 
            // WithPowerLabel
            // 
            this.WithPowerLabel.FontSize = 17F;
            this.WithPowerLabel.Location = new System.Drawing.Point(24, 171);
            this.WithPowerLabel.Name = "WithPowerLabel";
            this.WithPowerLabel.Size = new System.Drawing.Size(100, 35);
            this.WithPowerLabel.Text = "是否有电源";
            // 
            // PosXTextBox
            // 
            this.PosXTextBox.Location = new System.Drawing.Point(46, 38);
            this.PosXTextBox.Name = "PosXTextBox";
            this.PosXTextBox.Size = new System.Drawing.Size(48, 35);
            // 
            // PosYTextBox
            // 
            this.PosYTextBox.Location = new System.Drawing.Point(124, 38);
            this.PosYTextBox.Name = "PosYTextBox";
            this.PosYTextBox.Size = new System.Drawing.Size(48, 35);
            // 
            // PosZTextBox
            // 
            this.PosZTextBox.Location = new System.Drawing.Point(207, 38);
            this.PosZTextBox.Name = "PosZTextBox";
            this.PosZTextBox.Size = new System.Drawing.Size(48, 35);
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
            // InfoShowPanel
            // 
            this.InfoShowPanel.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.PosShowLabel,
            this.ShowUsableLabel,
            this.ShowIsNearWindowLabel,
            this.ShowWithPowerLabel});
            this.InfoShowPanel.Location = new System.Drawing.Point(0, 174);
            this.InfoShowPanel.Name = "InfoShowPanel";
            this.InfoShowPanel.Size = new System.Drawing.Size(300, 221);
            this.InfoShowPanel.Visible = false;
            // 
            // PosShowLabel
            // 
            this.PosShowLabel.FontSize = 17F;
            this.PosShowLabel.Location = new System.Drawing.Point(24, 3);
            this.PosShowLabel.Name = "PosShowLabel";
            this.PosShowLabel.Size = new System.Drawing.Size(229, 35);
            this.PosShowLabel.Text = "位置";
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
            // AddButton
            // 
            this.AddButton.FontSize = 15F;
            this.AddButton.Location = new System.Drawing.Point(81, 434);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(100, 30);
            this.AddButton.Text = "添加";
            this.AddButton.Visible = false;
            this.AddButton.Press += new System.EventHandler(this.AddButton_Press);
            // 
            // UpdateButton
            // 
            this.UpdateButton.FontSize = 15F;
            this.UpdateButton.Location = new System.Drawing.Point(81, 434);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(100, 30);
            this.UpdateButton.Text = "修改";
            this.UpdateButton.Visible = false;
            this.UpdateButton.Press += new System.EventHandler(this.UpdateButton_Press);
            // 
            // RemoveButton
            // 
            this.RemoveButton.FontSize = 15F;
            this.RemoveButton.Location = new System.Drawing.Point(81, 434);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(100, 30);
            this.RemoveButton.Text = "删除";
            this.RemoveButton.Visible = false;
            this.RemoveButton.Press += new System.EventHandler(this.RemoveButton_Press);
            // 
            // ResourceManageInterface
            // 
            this.Controls.AddRange(new Smobiler.Core.Controls.MobileControl[] {
            this.BasePanel});
            this.Name = "ResourceManageInterface";

        }
        #endregion

        private Smobiler.Core.Controls.Panel BasePanel;
        private Smobiler.Core.Controls.SegmentedControl ManageChoice;
        private Smobiler.Core.Controls.Panel ResourceIdInputPanel;
        private Smobiler.Core.Controls.Label ResourceIdLabel;
        private Smobiler.Core.Controls.TextBox ResourceIdTextBox;
        private Smobiler.Core.Controls.Button SreachButton;
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
        private Smobiler.Core.Controls.Panel InfoShowPanel;
        private Smobiler.Core.Controls.Label PosShowLabel;
        private Smobiler.Core.Controls.Label ShowUsableLabel;
        private Smobiler.Core.Controls.Label ShowIsNearWindowLabel;
        private Smobiler.Core.Controls.Label ShowWithPowerLabel;
        private Smobiler.Core.Controls.Button AddButton;
        private Smobiler.Core.Controls.Button UpdateButton;
        private Smobiler.Core.Controls.Button RemoveButton;
    }
}