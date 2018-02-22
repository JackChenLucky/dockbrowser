using System;
using System.Collections.Generic;
using System.Text;
using ScWebBrowser.entity;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ScWebBrowser
{
    public class ConfigureHelper
    {
        private static Configure globalConfigure;
        /// <summary>
        /// 获取系统初始化时的系统配置
        /// </summary>
        /// <returns></returns>
        public static Configure getInitConfigure()
        {
            Configure conf = new Configure();
            string sectionName = "window";
            string file = System.AppDomain.CurrentDomain.BaseDirectory+"application.ini";
            IniFileHelper ini = new IniFileHelper(file);
            conf.Main = ini.IniReadValue(sectionName, "main", "about:blank");
           
            try
            {
                #region 默认窗体配配置
                WindowSetting windowConf = new WindowSetting();
                windowConf.Title = ini.IniReadValue(sectionName, "title", "杭州圣辰网络科技有限公司");
                windowConf.Fixtitle = bool.Parse(ini.IniReadValue(sectionName, "fixtitle", "false"));
                windowConf.Width = int.Parse(ini.IniReadValue(sectionName, "width", "1024"));
                windowConf.Height = int.Parse(ini.IniReadValue(sectionName, "height", "768"));
                windowConf.Toolbar = bool.Parse(ini.IniReadValue(sectionName, "toolbar", "true"));
                windowConf.Statusbar = bool.Parse(ini.IniReadValue(sectionName, "statusbar", "true"));
                windowConf.Resizable = bool.Parse(ini.IniReadValue(sectionName, "resizable", "true"));
                windowConf.Fullscreen = bool.Parse(ini.IniReadValue(sectionName, "fullscreen", "false"));
                windowConf.Show_in_taskbar = bool.Parse(ini.IniReadValue(sectionName, "show_in_taskbar", "true"));
                windowConf.Frame = bool.Parse(ini.IniReadValue(sectionName, "frame", "true"));
                windowConf.Position = ini.IniReadValue(sectionName, "position", "center");

                string min_width = ini.IniReadValue(sectionName, "min_width");
                if (!string.IsNullOrEmpty(min_width))
                {
                    windowConf.Min_width = int.Parse(min_width);
                }
                string min_height = ini.IniReadValue(sectionName, "min_height");
                if (!string.IsNullOrEmpty(min_height))
                {
                    windowConf.Min_height = int.Parse(min_height);
                }
                string max_width = ini.IniReadValue(sectionName, "max_width");
                if (!string.IsNullOrEmpty(max_width))
                {
                    windowConf.Max_width = int.Parse(max_width);
                }
                string max_height = ini.IniReadValue(sectionName, "max_height");
                if (!string.IsNullOrEmpty(max_height))
                {
                    windowConf.Max_height = int.Parse(max_height);
                }
                windowConf.Show = bool.Parse(ini.IniReadValue(sectionName, "show", "true"));
                windowConf.Kiosk = bool.Parse(ini.IniReadValue(sectionName, "kiosk", "false"));
                windowConf.Showerror = bool.Parse(ini.IniReadValue(sectionName, "showerror", "false"));

                conf.WindowConfig = windowConf;
                #endregion

                conf.Defaultsys = ini.IniReadValue("scwebapp", "defaultmain", "0");
                conf.DefaultViewModel = ini.IniReadValue("scwebapp", "defaultviewmodel", Enum.GetName(typeof(ScWebBrowser.Constants.Browser_渲染模式), ScWebBrowser.Constants.Browser_渲染模式.IE7));
                int count = int.Parse(ini.IniReadValue("webapp", "webcount", "5"));//默认5个系统
                int gIndex = 1;
                while(gIndex<=count){
                    ScSystem si = null;
                    if (gIndex <= 5)
                    {
                        si = ScSystem.GetScSystem(ini.IniReadValue("webapp", "weburl" + gIndex, getDfltUrl(gIndex.ToString())));
                    }
                    else
                    {
                        si = ScSystem.GetScSystem(ini.IniReadValue("webapp", "weburl" + gIndex,""));
                    }
                    if(si!=null){
                        if (si.Deflt == "Y")
                        {
                            conf.MainUrl = ConfigureHelper.getWebUrl(conf.Main, si.Url);
                            conf.DefaultViewModel = si.Viewmodel;
                        }
                        conf.SysList.Add(si);
                    }
                    gIndex++;
                }
                //如果系统没有默认访问的his系统，则访问首页
                conf.MainUrl = string.IsNullOrEmpty(conf.MainUrl) ?  getWebUrl(conf.Main,"") : conf.MainUrl;
                return conf;
            }catch(Exception ex){
                MessageBox.Show("解析配置文件失败！"+ex.Message,"提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return conf;
            }
        }

        public static string getWebUrl(string pMainUrl,string pUrl)
        {
            //string Pattern = @"^(http|https|ftp)\://[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&$%\$#\=~])*$";
            //Regex r = new Regex(Pattern);
            //Match m = r.Match(pUrl);

            string sUrl = "";
            if (Global.isLocalHtml(pMainUrl))
            {
                if (Global.isLocalHtml(pUrl))
                {
                    sUrl = Global.gAppPath + pMainUrl.Replace("/", "\\");
                }
                else
                {
                    sUrl = pUrl;
                }
            }
            else
            {
                sUrl = pMainUrl + pUrl;
            }
            return sUrl;
        }

        public static string getDfltUrl(string pSysid)
        {
            switch (pSysid)
            {
                case "1":
                    return "1|0|N|门诊医生工作站|/emr|IE7";
                case "2":
                    return "2|0|N|住院护士工作站|/emr/ipn|IE7";
                case "3":
                    return "3|0|N|院长查询系统|/emr/dig|IE7";
                case "4":
                    return "4|0|N|院感系统|/emr/cpq|IE7";
                case "5":
                    return "5|0|N|护士电子病历|/emr/cemr|IE7";
                default:
                    return "1|0|N|门诊医生工作站|/emr|IE7";
            }
        }

        public static void SaveWebapp(List<ScSystem> pSysList)
        {
            string file = System.AppDomain.CurrentDomain.BaseDirectory + "application.ini";
            IniFileHelper ini = new IniFileHelper(file);
            ini.IniWriteValue("webapp", "webcount", pSysList.Count.ToString());
            int count = 1;
            foreach (ScSystem ss in pSysList)
            {
                ini.IniWriteValue("webapp", "weburl" + count, getUrlText(ss));
                count++;
            }
        }

        private static string getUrlText(ScSystem ss)
        {
            return string.Format("{0}|{1}|{2}|{3}|{4}|{5}", ss.Id, ss.Pid, ss.Deflt, ss.Name, ss.Url, string.IsNullOrEmpty(ss.Viewmodel) ? "IE7" : ss.Viewmodel);
        }
    }
}
