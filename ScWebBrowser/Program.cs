using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using ScWebBrowser.entity;

namespace ScWebBrowser
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            
            //判断是否生成配置文件
            string file = System.AppDomain.CurrentDomain.BaseDirectory + "application.ini";
            if (!File.Exists(file))
            {
                SettingForm settingForm = new SettingForm();
                settingForm.ShowDialog();
            }
            //Updater update = new Updater();
            //update.CheckUpdate();
            //获取默认的系统配置
            Global.sysConfig = ConfigureHelper.getInitConfigure();
            //判断是否指定参数
            if (args != null && args.Length > 0)
            {
                Global.sysConfig.WindowConfig.Url = args[0];
                Global.sysConfig.WindowConfig.Viewmodel = args.Length > 1 ? args[1] : "";
            }
            else
            {
                Global.sysConfig.WindowConfig.Url = Global.sysConfig.MainUrl;
                Global.sysConfig.WindowConfig.Viewmodel = Global.sysConfig.DefaultViewModel;
            }

            Global.sysConfig.WindowConfig.IsMainForm = true;
            
            /*
            string setting = Global.sysConfig.GetSetting();
            frmScBrowser main = new frmScBrowser(setting);
            Global.formList.Add(main);
            main.LoadUrl(Global.sysConfig.WindowConfig.Url, "IE11");
            Application.Run(main);
             */
            Application.Run(new MainForm());
        }
    }
}