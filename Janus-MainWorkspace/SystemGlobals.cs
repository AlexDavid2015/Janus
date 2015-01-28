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
        public static Form loginPageReturn;// Login form return
        public static ConnectPage objConnectPage = new ConnectPage();
        public static MagazinePage objMagazinePage = new MagazinePage();
        public static Main objMain = new Main();// Main Page
        public static JanusAutomatic objJanusAutomatic = new JanusAutomatic();// Automatic page
        public static JanusManual objJanusManual = new JanusManual();// Janus Manual page
        public static Programs objPrograms = new Programs();// Programs page
        public static Log objLog = new Log();// Log page
        public static Setup objSetup = new Setup();// Setup page
        public static Utilities objUtilities = new Utilities();// Utilities page
        public static UsersPage objUsersPage = new UsersPage();// Users page

        // Show Splash
        public static void ShowSplash()
        {
            Splash splash = new Splash();
            splash.StartPosition = FormStartPosition.CenterScreen;
            splash.SetWaitTime(15);
            splash.ShowDialog();
            splash.Close();
            splash.Dispose();
            splash = null;
        }
        #endregion

        #region // status variables
        public static clsUser CurrentUser;// current User
        #endregion

        #region // UI access levels
        public const int MainUiSections = 7;
        #endregion

        #region // Last Cycles and Last recipe id
        public static long Cycles;// Cycles
        public static long ShiftCycles;// ShiftCycles
        public static long ServiceCycles;//ServiceCycles
        public static string IDLastRecipe;// ID of LastRecipe
        #endregion

        #region // Language
        public static string LanguageCode = "English";// default is English
        #endregion
    }
}
