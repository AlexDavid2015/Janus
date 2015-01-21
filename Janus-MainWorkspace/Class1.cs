using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
namespace CxTitan
{
    public static class Class1
    {
        // AI : 12 channels
        public static double AI_0;
        public static double AI_1;
        public static double AI_2;
        public static double AI_3;
        public static double AI_4;
        public static double AI_5;
        public static double AI_6;
        public static double AI_7;
        public static double AI_8;
        public static double AI_9;
        public static double AI_10;
        public static double AI_11;

        // DI: 24 + 12 = 36 channels
        // 5040
        public static bool DI_0;
        public static bool DI_1;
        public static bool DI_2;
        public static bool DI_3;
        public static bool DI_4;
        public static bool DI_5;
        public static bool DI_6;
        public static bool DI_7;
        public static bool DI_8;
        public static bool DI_9;
        public static bool DI_10;
        public static bool DI_11;
        public static bool DI_12;
        public static bool DI_13;
        public static bool DI_14;
        public static bool DI_15;
        public static bool DI_16;
        public static bool DI_17;
        public static bool DI_18;
        public static bool DI_19;
        public static bool DI_20;
        public static bool DI_21;
        public static bool DI_22;
        public static bool DI_23;
        // 5045
        public static bool DI_24;
        public static bool DI_25;
        public static bool DI_26;
        public static bool DI_27;
        public static bool DI_28;
        public static bool DI_29;
        public static bool DI_30;
        public static bool DI_31;
        public static bool DI_32;
        public static bool DI_33;
        public static bool DI_34;
        public static bool DI_35;

        // DO: 24 + 12 = 36 channels
        // 5046
        public static bool DO_0;
        public static bool DO_1;
        public static bool DO_2;
        public static bool DO_3;
        public static bool DO_4;
        public static bool DO_5;
        public static bool DO_6;
        public static bool DO_7;
        public static bool DO_8;
        public static bool DO_9;
        public static bool DO_10;
        public static bool DO_11;
        public static bool DO_12;
        public static bool DO_13;
        public static bool DO_14;
        public static bool DO_15;
        public static bool DO_16;
        public static bool DO_17;
        public static bool DO_18;
        public static bool DO_19;
        public static bool DO_20;
        public static bool DO_21;
        public static bool DO_22;
        public static bool DO_23;
        // 5045
        public static bool DO_24;
        public static bool DO_25;
        public static bool DO_26;
        public static bool DO_27;
        public static bool DO_28;
        public static bool DO_29;
        public static bool DO_30;
        public static bool DO_31;
        public static bool DO_32;
        public static bool DO_33;
        public static bool DO_34;
        public static bool DO_35;


        // AO: 8 channels
        public static double AO_0;
        public static double AO_1;
        public static double AO_2;
        public static double AO_3;
        public static double AO_4;
        public static double AO_5;
        public static double AO_6;
        public static double AO_7;
    }
}
