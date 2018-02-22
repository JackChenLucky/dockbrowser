using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Updater
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// FileUrl
        /// unzipDir
        /// startexe
        /// version
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string pFileUrl = args[0];
            string unzipDir = string.Empty;
            if(args.Length>1){
                unzipDir = args[1];
            }
            string startCmd = string.Empty;
            if(args.Length>2){
                startCmd = args[2];
            }

            string version = string.Empty;
            if (args.Length > 3)
            {
                version = args[3];
            }

            frmUpdater fu = new frmUpdater(pFileUrl);
            fu.sUnzipDir = unzipDir;
            fu.sStartCmd = startCmd;
            fu.sVersion = version;
            Application.Run(fu);
        }
    }
}