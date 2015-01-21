using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CxTitan
{
    public static class SystemGlobals
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["AvantechConnectionString"].ConnectionString;
        
        public static string IP;
        public static int ScanTime;
        public static int ConnectionTimeOut;
        public static int SendTimeOut;
        public static int ReceiveTimeOut;
        public static int DOSlotNum;
        public static int AOSlotNum;
        public static int AISlotNum;
        public static int DIOSlotNum;
        public static int DISlotNum;
        public static int DIO_DIindex = 0;
        public static int DIO_DOindex = 1;

        #region // UI related
        public static Form JanusPageReturn;
        public static ConnectPage objConnectPage = new ConnectPage();
        public static MagazinePage objMagazinePage = new MagazinePage();
        public static Main objMain = new Main();

        public static string LanguageCode = "English";

        // Show Splash
        public static void ShowSplash()
        {
            Splash splash = new Splash();
            splash.StartPosition = FormStartPosition.CenterScreen;
            splash.SetWaitTime(20);
            splash.ShowDialog();
            splash.Close();
            splash.Dispose();
            splash = null;
        }
        #endregion

        #region // status variables
        
        #endregion

    }
}
