using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ScWebBrowser.entity;
using ScWebBrowser.util;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace ScWebBrowser
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1301:AvoidDuplicateAccelerators")]
    [System.Runtime.InteropServices.ComVisible(true)]
    public partial class frmWebBrowser : Form
    {
        private bool isFullScreen = false;

        private Configure conf;

        private string sUrl;

        public string sViewModel;

        public frmWebBrowser(string pUrl,string pViewModel)
        {
            sUrl = pUrl;
            sViewModel = pViewModel;
            InitializeComponent();
            this.browserControl1.WebBrowser.ObjectForScripting = this;
            this.browserControl1.WebBrowser.StatusTextChanged += new EventHandler(WebBrowser_StatusTextChanged);
            this.browserControl1.WebBrowser.DocumentTitleChanged += new EventHandler(WebBrowser_DocumentTitleChanged);
            InitApp();
        }

        public Object getAutomationObject()
        {
            return this.browserControl1.WebBrowser.Application;
        }

        private void InitApp()
        {
            conf = ConfigureHelper.getInitConfigure();
            if (conf.Kiosk)
            {
                conf.Statusbar = false;
                conf.Toolbar = false;
                conf.Frame = false;
                conf.Fullscreen = true;
            }
            this.Text = conf.Title;
            this.Width = conf.Width.Value;
            this.Height = conf.Height.Value;
            if (conf.Min_width != null && conf.Min_height != null)
            {
                this.MinimumSize = new Size(conf.Min_width.Value, conf.Min_height.Value);
            }

            if (conf.Max_width != null && conf.Max_height != null)
            {
                this.MaximumSize = new Size(conf.Max_width.Value, conf.Max_height.Value);
            }

            if (!conf.Statusbar)
            {
                this.statusStrip1.Visible = false;
            }

            if (!conf.Resizable)
            {
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
            }

            if (!conf.Show_in_taskbar)
            {
                this.ShowInTaskbar = false;
            }

            if (!conf.Frame)
            {
                this.FormBorderStyle = FormBorderStyle.None;
            }

            string position = conf.Position;
            if (position.IndexOf(",") >= 0)
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = new Point();
            }
            else
            {
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            if (string.IsNullOrEmpty(sUrl))
            {
                foreach (ScSystem ss in conf.SysList)
                {
                    if (ss.Deflt == "Y")
                    {
                        sUrl = ConfigureHelper.getWebUrl(conf.Main, ss.Url);
                        if(string.IsNullOrEmpty(sViewModel)){
                            sViewModel = ss.Viewmodel;
                        }
                        break;
                    }
                }
            }

            if (string.IsNullOrEmpty(sUrl))
            {
                sUrl = conf.Main;
            }
            if(string.IsNullOrEmpty(sViewModel)){
                sViewModel = "IE7";//默认IE7
            }
            tssl_version.Text = sViewModel;
            ViewModelHelper.SetViewModel((ScWebBrowser.Constants.Browser_渲染模式)Enum.Parse(typeof(ScWebBrowser.Constants.Browser_渲染模式), sViewModel));
            InitSysList();
        }

        private void InitSysList()
        {
            foreach(ScSystem ss in conf.SysList){
                if(ss.Pid=="0"){
                    ToolStripMenuItem tsmi = new ToolStripMenuItem();
                    tsmi.Text = ss.Name;
                    tsmi.Tag = ss;
                    tsmi.Checked = ss.Deflt=="Y";
                    InitSybSysList(tsmi);
                    tsddb_sys.DropDownItems.Add(tsmi);
                    if (tsmi.DropDownItems.Count == 0 && !string.IsNullOrEmpty(ss.Url))
                    {
                        tsmi.Click += new EventHandler(tsmisub_Click);
                    }
                }
            }
            ToolStripSeparator sp = new ToolStripSeparator();
            tsddb_sys.DropDownItems.Add(sp);
            ToolStripMenuItem tsmiself = new ToolStripMenuItem();
            tsmiself.Text = "添加自定义(+)";
            tsmiself.Click += new EventHandler(tsmiself_Click);
            tsddb_sys.DropDownItems.Add(tsmiself);

        }

        void tsmiself_Click(object sender, EventArgs e)
        {

            frm.frmAddSys frm = new ScWebBrowser.frm.frmAddSys(this.browserControl1.WebBrowser.Url.ToString());
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (MessageBox.Show("配置保存成功，需要重新启动才能生效，是否立即重启？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Restart();
                }
            }
        }

        private void InitSybSysList(ToolStripMenuItem tsmi)
        {
            string pId = (tsmi.Tag as ScSystem).Id;
            foreach (ScSystem ss in conf.SysList)
            {
                if(ss.Pid == pId){
                    ToolStripMenuItem tsmisub = new ToolStripMenuItem();
                    tsmisub.Checked = ss.Deflt == "Y";
                    tsmisub.Click += new EventHandler(tsmisub_Click);
                    tsmisub.Text = ss.Name;
                    tsmisub.Tag = ss;
                    tsmi.DropDownItems.Add(tsmisub);
                }
            }
        }

        void tsmisub_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
            ScSystem ss = tsmi.Tag as ScSystem;
            if (ss.Url.Substring(1, 1) == ":")
            {
                OpenLocalExe(ss.Url);
            }
            else
            {
                opeWeb(ss.Url, ss.Viewmodel);
            }
        }


        void WebBrowser_StatusTextChanged(object sender, EventArgs e)
        {
            // First, see if the active page is calling, or another page
            ExtendedWebBrowser ewb = sender as ExtendedWebBrowser;
            // Return if we got nothing (shouldn't happen)
            if (ewb == null) return;

            // Yep, send the event that updates the status bar text
            this.toolStripStatusLabel.Text = ewb.StatusText;
        }

        void WebBrowser_DocumentTitleChanged(object sender, EventArgs e)
        {
            // Update the title of the tab page of the control.
            ExtendedWebBrowser ewb = sender as ExtendedWebBrowser;
            // Return if we got nothing (shouldn't happen)
            if (ewb == null) return;

            string documentTitle = ewb.DocumentTitle;
            if (!string.IsNullOrEmpty(documentTitle)&&!conf.Fixtitle)
            {
                this.Text = ewb.DocumentTitle;
            }
        }

        private void frmWebBrowser_Load(object sender, EventArgs e)
        {
            this.browserControl1.Tag = this;
            this.Visible = conf.Show;
            if (conf.Fullscreen)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            this.browserControl1.WebBrowser.ScriptErrorsSuppressed = !conf.Showerror;
            tsmi = toolStripMenuItem5;
            this.toolStripStatusLabel.Text = sUrl;
            this.browserControl1.WebBrowser.Navigate(sUrl);
        }

        #region webapi exe提供给JS调用的方法

        public bool OpenLocalExe(string pFile)
        {
            try
            {
                System.Diagnostics.Process.Start(pFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        public string CallLocalApi(string pMethod, string pParm)
        {
            return "";
        }
        #endregion

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F11:
                    return true;

            }
            return base.ProcessCmdKey(ref msg, keyData);   //其他键按默认处理
        }

        private void tssl_link_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SettingForm sf = new SettingForm();
            if (sf.ShowDialog() == DialogResult.OK)
            {
                if (MessageBox.Show("配置保存成功，需要重新启动才能生效，是否立即重启？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Restart();
                }
            }
        }

        private void opeWeb(string pUrl,string pViewModel)
        {
            if (MessageBox.Show("是否在新窗口中打开指定系统？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string[] arg = new string[2];
                arg[0] = ConfigureHelper.getWebUrl(conf.Main,pUrl);
                arg[1] = pViewModel;
                StartProcess(System.Reflection.Assembly.GetExecutingAssembly().Location, arg);
            }
            else
            {
                this.browserControl1.WebBrowser.Navigate(ConfigureHelper.getWebUrl(conf.Main, pUrl));
            }
        }

        public bool StartProcess(string filename, string[] args)
        {
            try
            {
                string s = "";
                foreach (string arg in args)
                {
                    s = s + arg + " ";
                }
                s = s.Trim();
                Process myprocess = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo(filename, s);
                myprocess.StartInfo = startInfo;
                //通过以下参数可以控制exe的启动方式，具体参照 myprocess.StartInfo.下面的参数，如以无界面方式启动exe等
                myprocess.StartInfo.UseShellExecute = false;
                myprocess.Start();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("启动应用程序时出错！原因：" + ex.Message);
            }
            return false;
        }

        private void tss_setting_Click(object sender, EventArgs e)
        {
            SettingForm sf = new SettingForm();
            if (sf.ShowDialog()==DialogResult.OK)
            {
                if(MessageBox.Show("配置保存成功，需要重新启动才能生效，是否立即重启？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes){
                    Application.Restart();
                }
            }
        }

        private void tssl_clear_Click(object sender, EventArgs e)
        {
            SysFunc.CleanAll();
        }

        #region 缩放

        private ToolStripMenuItem tsmi;

        private void SetBrowserZoom(ToolStripMenuItem pTsmi,string per)
        {
            if (tsmi!=null)
            {
                tsmi.Checked = false;
            }
            pTsmi.Checked = true;
            tsmi = pTsmi;
            this.browserControl1.WebBrowser.Zoom(int.Parse(per.Replace("%","")));;
            dsddb.Text = per;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            SetBrowserZoom(toolStripMenuItem3, "50%");
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            SetBrowserZoom(toolStripMenuItem4,"75%");
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            SetBrowserZoom(toolStripMenuItem5,"100%");
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            SetBrowserZoom(toolStripMenuItem6,"125%");
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            SetBrowserZoom(toolStripMenuItem7,"150%");
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            SetBrowserZoom(toolStripMenuItem8,"175%");
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            SetBrowserZoom(toolStripMenuItem9,"200%");
        }

        #endregion

        private void dsddb_Click(object sender, EventArgs e)
        {

        }

    }
}