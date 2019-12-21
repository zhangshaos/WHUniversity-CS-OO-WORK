using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smobiler.Core;
using Smobiler.Core.Controls;

namespace LibraryApp
{
    partial class ResourceManageInterface : Smobiler.Core.Controls.MobileForm
    {
        Dictionary<string, string> resourceInputInfo;
        public ResourceManageInterface() : base()
        {
            //This call is required by the SmobilerForm.
            InitializeComponent();
            resourceInputInfo = new Dictionary<string, string>();
            resourceInputInfo.Add("resourceID", "");
            resourceInputInfo.Add("positionX","");
            resourceInputInfo.Add("positionY","");
            resourceInputInfo.Add("positionZ","");
            resourceInputInfo.Add("isUsable","");
            resourceInputInfo.Add("isNearWindow","");
            resourceInputInfo.Add("isWithPower","");

            ResourceIdInputPanel.Visible = true;
            InfoInputPanel.Visible = true;
            AddButton.Visible = true;
        }

        private void UpdateButton_Press(object sender, EventArgs e)
        {
            UpdateResourceInputInfo();
            cz.Error r = ManagerSystem.Instance.MySuperAccount.UpdateResource(ref resourceInputInfo);
            switch (r)
            {
                case cz.Error.OK:
                    {
                        Toast("修改成功");
                    }
                    break;
                case cz.Error.CONNECT_ERROR:
                    {
                        Toast("网络连接错误");
                    }
                    break;
                default:
                    {
#if(DEBUG)
                        Toast(r.ToString());
#else
                        Toast("未知错误");
#endif
                    }
                    break;
            }    
        }

        private void RemoveButton_Press(object sender, EventArgs e)
        {
            Dictionary<string, string> p = new Dictionary<string, string>();
            p.Add("resourceID", ResourceIdTextBox.Text);
            cz.Error r = ManagerSystem.Instance.MySuperAccount.DelResource(ref p);
            switch (r)
            {
                case cz.Error.OK:
                    {
                        Toast("删除成功");
                    }
                    break;
                case cz.Error.CONNECT_ERROR:
                    {
                        Toast("网络连接错误");
                    }
                    break;
                default:
                    {
#if(DEBUG)
                        Toast(r.ToString());
#else
                        Toast("未知错误");
#endif
                    }
                    break;
            }
        }

        private void AddButton_Press(object sender, EventArgs e)
        {
            UpdateResourceInputInfo();
            cz.Error r = ManagerSystem.Instance.MySuperAccount.AddResource(ref resourceInputInfo);
            switch (r)
            {
                case cz.Error.OK:
                    {
                        Toast("添加成功");
                    }
                    break;
                case cz.Error.CONNECT_ERROR:
                    {
                        Toast("网络连接错误");
                    }
                    break;
                default:
                    {
#if(DEBUG)
                        Toast(r.ToString());
#else
                        Toast("未知错误");
#endif
                    }
                    break;
            }
        }

        private void SreachButton_Press(object sender, EventArgs e)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            if (SearchResource(ref result))
            {
                if (result.Count>0)
                    switch (ManageChoice.SelectedItem)
                    {
                        case "删除":
                            {
                                FillInfoShowPanel(result);
                                InfoShowPanel.Visible = true;
                                RemoveButton.Visible = true;
                            }
                            break;
                        case "修改":
                            {
                                FillInfoInputPanel(result);
                                InfoInputPanel.Visible = true;
                                UpdateButton.Visible = true;
                            }
                            break;
                        case "查询":
                            {
                                FillInfoShowPanel(result);
                                InfoShowPanel.Visible = true;
                            }
                            break;
                    }
                else
                {
                    Toast("未找到相应号码资源");
                }
            }
        }

        private void ManageChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reset();
            switch(ManageChoice.SelectedItem)
            {
                case "添加":
                    {
                        ResourceIdInputPanel.Visible = true;
                        InfoInputPanel.Visible = true;
                        AddButton.Visible = true;
                    }
                    break;
                case "删除":
                    {
                        ResourceIdInputPanel.Visible = true;
                        SreachButton.Visible = true;
                    }
                    break;
                case "修改":
                    {
                        ResourceIdInputPanel.Visible = true;
                        SreachButton.Visible = true;
                    }
                    break;
                case "查询":
                    {
                        ResourceIdInputPanel.Visible = true;
                        SreachButton.Visible = true;
                    }
                    break;
            }
        }

        //My Methods
        private bool SearchResource(ref Dictionary<string,string> result)
        {
            ExhibitResources.Error r = ManagerSystem.Instance.MyExhibitSeatHandle.ResourceDetail(int.Parse(ResourceIdTextBox.Text), ref result);
            switch (r)
            {
                case ExhibitResources.Error.OP_SUCCESS:
                    {
                        return true;
                    }
                    break;
                case ExhibitResources.Error.CONNECTION_ERROR:
                    {
                        Toast("网络连接错误");
                    }
                    break;
                default:
                    {
#if(DEBUG)
                        Toast(r.ToString());
#else
                        Toast("未知错误");
#endif
                    }
                    break;
            }
            return false;
        }

        private void FillInfoShowPanel(Dictionary<string, string> info)
        {
            PosShowLabel.Text = "位置: x:" + info["positionX"] + " y:" + info["positionY"] + " z:" + info["positionZ"];
            ShowUsableLabel.Text = (info["isUsable"] == "true") ? "可用" : "不可用";
            ShowIsNearWindowLabel.Text = (info["isNearWindow"] == "true") ? "靠窗" : "不靠窗";
            ShowWithPowerLabel.Text = (info["isWithPower"] == "true") ? "有电源" : "无电源";
        }

        private void FillInfoInputPanel(Dictionary<string, string> info)
        {
            PosXTextBox.Text = info["positionX"];
            PosYTextBox.Text = info["positionY"];
            PosZTextBox.Text = info["positionZ"];
            YorNChoice1.SelectedIndex = (info["isUsable"] == "true") ? 0 : 1;
            YorNChoice2.SelectedIndex = (info["isNearWindow"] == "true") ? 0 : 1;
            YorNChoice3.SelectedIndex = (info["isWithPower"] == "true") ? 0 : 1;
        }

        private void UpdateResourceInputInfo()
        {
            resourceInputInfo["resourceID"] = ResourceIdTextBox.Text;
            resourceInputInfo["positionX"] = PosXTextBox.Text;
            resourceInputInfo["positionY"] = PosYTextBox.Text;
            resourceInputInfo["positionZ"] = PosZTextBox.Text;
            resourceInputInfo["isUsable"] = (YorNChoice1.SelectedIndex == 0) ? "true" : "false";
            resourceInputInfo["isNearWindow"] = (YorNChoice2.SelectedIndex == 0) ? "true" : "false";
            resourceInputInfo["isWithPower"] = (YorNChoice3.SelectedIndex == 0) ? "true" : "false";
        }

        private void Reset()
        {
            ResourceIdInputPanel.Visible = false;
            ResourceIdTextBox.Text = "";

            InfoInputPanel.Visible = false;
            PosXTextBox.Text = "";
            PosYTextBox.Text = "";
            PosZTextBox.Text = "";
            YorNChoice1.SelectedIndex = 0;
            YorNChoice2.SelectedIndex = 0;
            YorNChoice3.SelectedIndex = 0;

            InfoShowPanel.Visible = false;

            AddButton.Visible = false;
            RemoveButton.Visible = false;
            UpdateButton.Visible = false;
            SreachButton.Visible = false;
        }
    }
}