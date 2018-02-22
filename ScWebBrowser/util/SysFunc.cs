using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace ScWebBrowser.util
{
    public class SysFunc
    {
        #region 清理缓存及零时目录
        public enum ShowCommands : int
        {
        SW_HIDE = 0,
        SW_SHOWNOrmAL = 1,
        SW_NOrmAL = 1,
        SW_SHOWMINIMIZED = 2,
        SW_SHOWMAXIMIZED = 3,
        SW_MAXIMIZE = 3,
        SW_SHOWNOACTIVATE = 4,
        SW_SHOW = 5,
        SW_MINIMIZE = 6,
        SW_SHOWMINNOACTIVE = 7,
        SW_SHOWNA = 8,
        SW_RESTORE = 9,
        SW_SHOWDEFAULT = 10,
        SW_FORCEMINIMIZE = 11,
        SW_MAX = 11
        }
        [DllImport("shell32.dll")]
        static extern IntPtr ShellExecute( IntPtr hwnd, string lpOperation, string lpFile, string lpParameters, string lpDirectory, ShowCommands nShowCmd);

        /// <summary>
        /// 删除临时文件
        /// </summary>
        public static void CleanTempFiles()
        {
            //清除IE临时文件
            ShellExecute(IntPtr.Zero, "open", "rundll32.exe", " InetCpl.cpl,ClearMyTracksByProcess 8", "", ShowCommands.SW_HIDE);
        }

        /// <summary>
        /// 清理Cookies
        /// </summary>
        public static void CleanCookies()
        {
            ShellExecute(IntPtr.Zero, "open", "rundll32.exe", " InetCpl.cpl,ClearMyTracksByProcess 2", "", ShowCommands.SW_HIDE);
        }

        /// <summary>
        /// 清理历史记录
        /// </summary>
        public static void CleanHistory()
        {
            ShellExecute(IntPtr.Zero, "open", "rundll32.exe", " InetCpl.cpl,ClearMyTracksByProcess 1", "", ShowCommands.SW_HIDE);
        }

        /// <summary>
        /// 清理表单数据
        /// </summary>
        public static void CleanFormData()
        {
            ShellExecute(IntPtr.Zero, "open", "rundll32.exe", " InetCpl.cpl,ClearMyTracksByProcess 16", "", ShowCommands.SW_HIDE);
        }

        /// <summary>
        /// 清理保存的密码
        /// </summary>
        public static void CleanPassword()
        {
            ShellExecute(IntPtr.Zero, "open", "rundll32.exe", " InetCpl.cpl,ClearMyTracksByProcess 32", "", ShowCommands.SW_HIDE);
        }

        /// <summary>
        /// 清理所有 Internet临时文件 Cookies 历史记录  表单数据 密码
        /// </summary>
        public static void CleanAll()
        {
            ShellExecute(IntPtr.Zero, "open", "rundll32.exe", " InetCpl.cpl,ClearMyTracksByProcess 255", "", ShowCommands.SW_HIDE);
        }
        #endregion
    }
}
