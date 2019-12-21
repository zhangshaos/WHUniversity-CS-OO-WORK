using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cz;
using ExhibitResources;
using superaccount;

namespace LibraryApp
{
    class ManagerSystem
    {
        private static ManagerSystem instance;
        public static ManagerSystem Instance
        {
            get
            {
                if (instance == null)
                    instance = new ManagerSystem();
                return instance;
            }
        }

        private ManagerSystem()
        {
            MyAccount = new Account();
            MyExhibitSeatHandle = new ExhibitSeatHandle();
            MySuperAccount = new SuperAccount();
        }

        ~ManagerSystem()
        {

        }

        public string CurrentAccountId { get; set; }
        public Account MyAccount { get; private set; }
        public SuperAccount MySuperAccount { get; private set; }
        public ExhibitSeatHandle MyExhibitSeatHandle { get; private set; }
    }
}
