using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CxTitan
{
    public class clsUser
    {
        private int iD;
        private string userName;
        private string passWord;
        private short level;

        public clsUser()
        {
            InitializeUser();
        }

        public void InitializeUser()
        {
            iD = 0;
            userName = "No user logged in..";
            level = 0;
        }

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string PassWord
        {
            get { return passWord; }
            set { passWord = value; }
        }

        public short Level
        {
            get { return level; }
            set { level = value; }
        }
    }
}
