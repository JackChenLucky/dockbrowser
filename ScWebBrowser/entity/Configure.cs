using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ScWebBrowser.entity
{
    public class Configure
    {
        private string _version;
        /// <summary>
        /// 版本
        /// </summary>
        public string Version
        {
            get { return _version; }
            set { _version = value; }
        }

        private string _main;
        /// <summary>
        /// 启动访问页面
        /// </summary>
        public string Main
        {
            get { return _main; }
            set { _main = value; }
        }


        private string defaultsys;
        /// <summary>
        /// 默认系统
        /// </summary>
        public string Defaultsys
        {
            get { return defaultsys; }
            set { defaultsys = value; }
        }

        private string mainUrl;
        /// <summary>
        /// 默认访问的WEB地址
        /// </summary>
        public string MainUrl
        {
            get { return mainUrl; }
            set { mainUrl = value; }
        }

        private string defaultViewModel;
        /// <summary>
        /// 默认页的渲染模式
        /// </summary>
        public string DefaultViewModel
        {
            get { return defaultViewModel; }
            set { defaultViewModel = value; }
        }

        WindowSetting windowConfig;
        /// <summary>
        /// 配置文件配置的系统默认窗体配置
        /// </summary>
        public WindowSetting WindowConfig
        {
            get { return windowConfig; }
            set { windowConfig = value; }
        }

        List<ScSystem> sysList = new List<ScSystem>();
        /// <summary>
        /// 所有系统列表
        /// </summary>
        public List<ScSystem> SysList
        {
            get { return sysList; }
            set { sysList = value; }
        }

        public string GetSetting()
        {
            return JsonConvert.SerializeObject(this.windowConfig);
        }
    }


    public class ScSystem
    {
        private string id;
        /// <summary>
        /// 节点ID
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private string pid;
        /// <summary>
        /// 父节点ID
        /// </summary>
        public string Pid
        {
            get { return pid; }
            set { pid = value; }
        }

        private string name;
        /// <summary>
        /// 节点名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string url;
        /// <summary>
        /// 链接地址
        /// </summary>
        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        private string scsysid;
        /// <summary>
        /// 圣辰系统ID
        /// </summary>
        public string Scsysid
        {
            get { return scsysid; }
            set { scsysid = value; }
        }

        private string deflt;
        /// <summary>
        /// 是否默认访问的地址
        /// </summary>
        public string Deflt
        {
            get { return deflt; }
            set { deflt = value; }
        }

        private string viewmodel;
        /// <summary>
        /// 渲染模式
        /// </summary>
        public string Viewmodel
        {
            get { return viewmodel; }
            set { viewmodel = value; }
        }

        public static ScSystem GetScSystem(string pSysStr)
        {
            ScSystem ss = new ScSystem();
            string[] ssArry = pSysStr.Split(new char[] { '|' });
            //1|0|Y|门诊医生工作站|http://localhost:8080/emr
            ss.id = ssArry.Length > 0 ? ssArry[0] : "";
            ss.pid =  ssArry.Length > 1 ?ssArry[1] : "";
            ss.deflt =  ssArry.Length > 2 ?ssArry[2] : "N";
            ss.name =  ssArry.Length > 3 ?ssArry[3] : "";
            ss.url = ssArry.Length > 4 ? ssArry[4] : "";
            ss.viewmodel = ssArry.Length > 5 ? ssArry[5] : "IE7";
            return ss;
        }
    }
}
