using System;
using System.Collections.Generic;
using System.Text;

namespace ScWebBrowser
{
    public class Constants
    {
        public const string SYS_EMR = "1";

        public const string SYS_IPN = "2";

        public const string SYS_DIG = "3";

        public const string SYS_CPQ = "4";

        public const string SYS_CEMR = "5";


        public enum Browser_渲染模式
        {
            IE7 = 0x1B58,
            IE8 = 0x1F40,
            IE9 = 0x2328,
            IE10 = 0x02710,
            IE11 = 0x2AF8,
            Chrome = 0
        }

        public enum Menu_菜单类型
        {
            label = 1,
            combox=2,
            sperator=3,
            text=4
        }
    }
}
