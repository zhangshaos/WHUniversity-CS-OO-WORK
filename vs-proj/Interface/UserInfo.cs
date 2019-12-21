using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smobiler.Core;
using Smobiler.Core.Controls;

namespace LibraryApp
{
    partial class UserInfo : Smobiler.Core.Controls.MobileForm
    {
        public UserInfo() : base()
        {
            //This call is required by the SmobilerForm.
            InitializeComponent();
            NameLabel.Text += ManagerSystem.Instance.MyAccount.GetName();
            GenderLabel.Text += ManagerSystem.Instance.MyAccount.GetGender();
            IdLabel.Text += ManagerSystem.Instance.MyAccount.GetId();
            privilegeLabel.Text += ManagerSystem.Instance.MyAccount.GetRole();
        }
    }
}