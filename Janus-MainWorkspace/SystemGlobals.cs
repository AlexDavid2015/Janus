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

        #region // Input globals
        public static string InputVal;
        public static string InputTyp;
        #endregion

        #region // "IsLike" Algorithm
        /// <summary>
        /// Implement's VB's Like operator logic.
        /// </summary>
        public static bool IsLike(this string s, string pattern)
        {
            // Characters matched so far
            int matched = 0;

            // Loop through pattern string
            for (int i = 0; i < pattern.Length; )
            {
                // Check for end of string
                if (matched >= s.Length)
                    return false;

                // Get next pattern character
                char c = pattern[i++];
                if (c == '[') // Character list
                {
                    // Test for exclude character
                    bool exclude = (i < pattern.Length && pattern[i] == '!');
                    if (exclude)
                        i++;
                    // Build character list
                    int j = pattern.IndexOf(']', i);
                    if (j < 0)
                        j = s.Length;
                    HashSet<char> charList = CharListToSet(pattern.Substring(i, j - i));
                    i = j + 1;

                    if (charList.Contains(s[matched]) == exclude)
                        return false;
                    matched++;
                }
                else if (c == '?') // Any single character
                {
                    matched++;
                }
                else if (c == '#') // Any single digit
                {
                    if (!Char.IsDigit(s[matched]))
                        return false;
                    matched++;
                }
                else if (c == '*') // Zero or more characters
                {
                    if (i < pattern.Length)
                    {
                        // Matches all characters until
                        // next character in pattern
                        char next = pattern[i];
                        int j = s.IndexOf(next, matched);
                        if (j < 0)
                            return false;
                        matched = j;
                    }
                    else
                    {
                        // Matches all remaining characters
                        matched = s.Length;
                        break;
                    }
                }
                else // Exact character
                {
                    if (c != s[matched])
                        return false;
                    matched++;
                }
            }
            // Return true if all characters matched
            return (matched == s.Length);
        }

        /// <summary>
        /// Converts a string of characters to a HashSet of characters. If the string
        /// contains character ranges, such as A-Z, all characters in the range are
        /// also added to the returned set of characters.
        /// </summary>
        /// <param name="charList">Character list string</param>
        private static HashSet<char> CharListToSet(string charList)
        {
            HashSet<char> set = new HashSet<char>();

            for (int i = 0; i < charList.Length; i++)
            {
                if ((i + 1) < charList.Length && charList[i + 1] == '-')
                {
                    // Character range
                    char startChar = charList[i++];
                    i++; // Hyphen
                    char endChar = (char)0;
                    if (i < charList.Length)
                        endChar = charList[i++];
                    for (int j = startChar; j <= endChar; j++)
                        set.Add((char)j);
                }
                else set.Add(charList[i]);
            }
            return set;
        }
        #endregion
    }
}
