using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smobiler.Core;
using Smobiler.Core.Controls;

namespace LibraryApp
{
    partial class AdministratorInterface : Smobiler.Core.Controls.MobileForm
    {
        public AdministratorInterface() : base()
        {
            //This call is required by the SmobilerForm.
            InitializeComponent();
        }

        private void AbilityMenuView_ItemPress(object sender, IconMenuViewItemPressEventArgs e)
        {
            MenuItem(e.Item.ID);
        }

        /// <summary>
        /// 菜单点击事件方法
        /// </summary>
        /// <param name="id"></param>
        private void MenuItem(string id)
        {
            switch (id)
            {
                case "ResourceManage":
                    {
                        ResourceManageInterface resourceManageInterface = new ResourceManageInterface();
                        Show(resourceManageInterface);
                    }
                    break;
                case "RemoveUser":
                    {
                        RemoveUserInterface removeUserInterface = new RemoveUserInterface();
                        Show(removeUserInterface);
                    }
                    break;
            }
        }
    }
}