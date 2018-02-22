using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ScWebBrowser.api;
using Newtonsoft.Json;
using ScWebBrowser.util;
using ScWebBrowser.entity;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using WinFormsUI.Docking;

namespace ScWebBrowser
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public partial class frmScBrowser : DockContent
    {
        #region ��������
        WindowSetting windowSetting;

        private string sUrl;

        public string sViewModel;

        public bool sIsMainForm = false;

        public bool isQuit = false;

        public string sReturnData = string.Empty;

        private NotifyIcon tray = null;

        #endregion
        public frmScBrowser(string setting)
        {
            windowSetting = JsonConvert.DeserializeObject<WindowSetting>(setting);
            InitializeComponent();
            InitForm();
            InitSysList();
        }

        /// <summary>
        /// ��ʼ������
        /// </summary>
        private void InitForm()
        {
            sUrl = windowSetting.Url;
            sViewModel = windowSetting.Viewmodel;
            sIsMainForm = windowSetting.IsMainForm;
            //����Ĭ�ϵ����ô���Ϊ����������
            Global.sysConfig.WindowConfig.IsMainForm = false;
            (this.scweb.ActiveXInstance as SHDocVw.WebBrowser).NewWindow3 += new SHDocVw.DWebBrowserEvents2_NewWindow3EventHandler(frmScBrowser_NewWindow3);
            (this.scweb.ActiveXInstance as SHDocVw.WebBrowser).NewWindow2 += new SHDocVw.DWebBrowserEvents2_NewWindow2EventHandler(frmScBrowser_NewWindow2);
            (this.scweb.ActiveXInstance as SHDocVw.WebBrowser).StatusTextChange += new SHDocVw.DWebBrowserEvents2_StatusTextChangeEventHandler(frmScBrowser_StatusTextChange);
            (this.scweb.ActiveXInstance as SHDocVw.WebBrowser).TitleChange += new SHDocVw.DWebBrowserEvents2_TitleChangeEventHandler(frmScBrowser_TitleChange);
            this.scweb.Quit += new EventHandler(scweb_Quit);
            #region ���ݴ����������ô���
            if (windowSetting.Kiosk)
            {
                windowSetting.Statusbar = false;
                windowSetting.Toolbar = false;
                windowSetting.Frame = false;
                windowSetting.Fullscreen = true;
            }
            this.Text = windowSetting.Title;
            this.Width = windowSetting.Width.Value;
            this.Height = windowSetting.Height.Value;
            if (windowSetting.Min_width != null && windowSetting.Min_height != null)
            {
                this.MinimumSize = new Size(windowSetting.Min_width.Value, windowSetting.Min_height.Value);
            }

            if (windowSetting.Max_width != null && windowSetting.Max_height != null)
            {
                this.MaximumSize = new Size(windowSetting.Max_width.Value, windowSetting.Max_height.Value);
            }

            if (!windowSetting.Statusbar)
            {
                this.statusStrip.Visible = false;
            }

            if (!windowSetting.Resizable)
            {
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
            }

            if (!windowSetting.Show_in_taskbar)
            {
                this.ShowInTaskbar = false;
            }

            if (!windowSetting.Frame)
            {
                this.FormBorderStyle = FormBorderStyle.None;
            }

            string position = windowSetting.Position;
            if (position.IndexOf(",") >= 0)
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = new Point();
            }
            else
            {
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            this.MaximizeBox = windowSetting.Maximize;
            this.MinimizeBox = windowSetting.Minimize;

            if (windowSetting.Fullscreen)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            this.scweb.ScriptErrorsSuppressed = !windowSetting.Showerror;
            #endregion
        }

        void scweb_Quit(object sender, EventArgs e)
        {
            if (!isQuit)
            {
                this.Close();
            }
        }


        void frmScBrowser_TitleChange(string Text)
        {
            if(!windowSetting.Fixtitle){
                this.Text = Text;
            }
        }


        /// �ڴ����д��ƶ���URL�����ƶ���Ⱦģʽ
        /// </summary>
        /// <param name="pUrl"></param>
        /// <param name="pViewModel"></param>
        public void LoadUrl(string pUrl, string pViewModel)
        {
            sUrl = pUrl;
            sViewModel = string.IsNullOrEmpty(pViewModel) ? "IE7" : pViewModel;
            tssl_version.Text = sViewModel;
            ViewModelHelper.SetViewModel((ScWebBrowser.Constants.Browser_��Ⱦģʽ)Enum.Parse(typeof(ScWebBrowser.Constants.Browser_��Ⱦģʽ), sViewModel));
            this.tssl_status.Text = sUrl;
            this.scweb.Navigate(sUrl);
        }

        #region ���ϵͳ�б�
        private void InitSysList()
        {
            foreach (ScSystem ss in Global.sysConfig.SysList)
            {
                if (ss.Pid == "0")
                {
                    ToolStripMenuItem tsmi = new ToolStripMenuItem();
                    tsmi.Text = ss.Name;
                    tsmi.Tag = ss;
                    tsmi.Checked = ss.Deflt == "Y";
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
            tsmiself.Text = "����Զ���(+)";
            tsmiself.Click += new EventHandler(tsmiself_Click);
            tsddb_sys.DropDownItems.Add(tsmiself);

        }

        void tsmiself_Click(object sender, EventArgs e)
        {

            frm.frmAddSys frm = new ScWebBrowser.frm.frmAddSys(this.scweb.Url.ToString());
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (MessageBox.Show("���ñ���ɹ�����Ҫ��������������Ч���Ƿ�����������", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Restart();
                }
            }
        }

        private void InitSybSysList(ToolStripMenuItem tsmi)
        {
            string pId = (tsmi.Tag as ScSystem).Id;
            foreach (ScSystem ss in Global.sysConfig.SysList)
            {
                if (ss.Pid == pId)
                {
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
        #endregion

        #region webapi exe�ṩ��JS���õķ���

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

        public void SetReturnData(string sRetData)
        {
            this.DialogResult = DialogResult.OK;
            sReturnData = sRetData;
            this.Close();
        }

        public void CloseWindow()
        {
            this.Close();
        }

        public void SetDefaultContextMenu(bool sFlag)
        {
            this.scweb.IsWebBrowserContextMenuEnabled = sFlag;
        }

        #region ����Tray
        public void CreateTray(string option)
        {
            if(tray==null){
               tray = new NotifyIcon();
            }
            TrayOption opt = JsonConvert.DeserializeObject<TrayOption>(option);
            if (!string.IsNullOrEmpty(opt.Icon))
            {
                tray.Icon = new Icon(Global.gAppPath + opt.Icon.Replace("/", "\\"));
            }
            else
            {
                tray.Icon = null;
            }
            tray.Text = opt.Title;
            if(opt.Menus!=null){
                tray.ContextMenuStrip = CreateMenu(opt.Menus);
            }
            tray.Visible = true;
        }
        /// <summary>
        /// ɾ������
        /// </summary>
        public void DeleteTray()
        {
            tray.Visible = false;
            tray = null;
        }
        /// <summary>
        /// ��ʾ������ʾ
        /// </summary>
        /// <param name="option"></param>
        public void ShowBalloonTip(string option)
        {
            TrayBalloonTipOption tbto = JsonConvert.DeserializeObject<TrayBalloonTipOption>(option);
            if(tray!=null){
                tray.ShowBalloonTip(tbto.Timeout,tbto.Balloontiptitle,tbto.Balloontiptext,(ToolTipIcon)tbto.Balloontipicon);
            }
        }

        #endregion
        /// <summary>
        /// �����˵�
        /// </summary>
        /// <returns></returns>
        public ContextMenuStrip CreateMenu(List<SysMenu> pMenus)
        {
            ContextMenuStrip menus = new ContextMenuStrip();
            foreach (SysMenu menu in pMenus)
            {
                if (string.IsNullOrEmpty(menu.Menutype)||menu.Menutype == Convert.ToString(((int)Constants.Menu_�˵�����.label)))
                {
                    ToolStripMenuItem tsi = new ToolStripMenuItem();
                    tsi.Text = menu.Title;
                    if(!string.IsNullOrEmpty(menu.Image)){
                        tsi.Image = Image.FromFile(Global.getFile(menu.Image));
                    }
                    tsi.Tag = menu;
                    tsi.Click += new EventHandler(menu_Click);
                    menus.Items.Add(tsi);
                }else if(menu.Menutype == Convert.ToString(((int)Constants.Menu_�˵�����.sperator))){
                    ToolStripSeparator tss = new ToolStripSeparator();
                    tss.Tag = menu;
                    menus.Items.Add(tss);
                }else{
                    Global.ShowWarning("Ŀǰ�˵�ֻ֧����ͨ�ı��˵��ͷָ��߲˵���");
                }
            }
            return menus;
        }

        #region
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string CaptureScreen()
        {
            Image baseImage = new Bitmap(PrimaryScreen.DESKTOP.Width, PrimaryScreen.DESKTOP.Height);
            Graphics g = Graphics.FromImage(baseImage);
            g.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(PrimaryScreen.DESKTOP.Width, PrimaryScreen.DESKTOP.Height));
            g.Dispose();
            if (!Directory.Exists("ScreenTemp"))
            {
                Directory.CreateDirectory("ScreenTemp");
            }
            string imgfile = string.Format("ScreenTemp\\{0}.jpg", DateTime.Now.ToString("yyyyMMddHHmmss"));
            baseImage.Save(imgfile, ImageFormat.Jpeg);
            return Global.gAppPath + imgfile;
        }
        #endregion

        #region Plugin
        /// <summary>
        /// ���ò��
        /// </summary>
        /// <param name="pInData"></param>
        /// <returns></returns>
        public string InvokePlugin(string pPluginName,string pInData)
        {
            try
            {
                //���س���(dll�ļ���ַ)��ʹ��Assembly��   
                Assembly assembly = Assembly.LoadFile(Global.gAppPath + "plugins/App_Code.dll");  

            }catch(Exception ex){

            }
            return "";
        }

        #endregion

        void menu_Click(object sender, EventArgs e)
        {
            ToolStripItem tsi = sender as ToolStripItem;
            SysMenu sMenu = tsi.Tag as SysMenu;
            ExecScript(sMenu.Clickeventfunc,new object[]{JsonConvert.SerializeObject(sMenu)});
        }

        private void opeWeb(string pUrl, string pViewModel)
        {
            if (MessageBox.Show("�Ƿ����´����д�ָ��ϵͳ��", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string[] arg = new string[2];
                arg[0] = ConfigureHelper.getWebUrl(Global.sysConfig.Main, pUrl);
                arg[1] = pViewModel;
                StartProcess(System.Reflection.Assembly.GetExecutingAssembly().Location, arg);
            }
            else
            {
                this.scweb.Navigate(ConfigureHelper.getWebUrl(Global.sysConfig.Main, pUrl));
            }
        }

        private Object ExecScript(string func,Object[] parms)
        {
            return scweb.Document.InvokeScript(func,parms);
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
                //ͨ�����²������Կ���exe��������ʽ��������� myprocess.StartInfo.����Ĳ����������޽��淽ʽ����exe��
                myprocess.StartInfo.UseShellExecute = false;
                myprocess.Start();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("����Ӧ�ó���ʱ����ԭ��" + ex.Message);
            }
            return false;
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="setting"></param>
        /// <returns></returns>
        public string CreateBrowserWindow(string setting)
        {
            if (string.IsNullOrEmpty(setting))
            {
                return "��������!";
            }
            string result = string.Empty;
            WindowSetting windowSetting = Global.GetWindowSetting(setting);
            setting = JsonConvert.SerializeObject(windowSetting);
            frmScBrowser newWindow = new frmScBrowser(setting);
            if (windowSetting.Modeless)
            {
                newWindow.LoadUrl(windowSetting.Url, windowSetting.Viewmodel);
                newWindow.Visible = false;
                if (newWindow.ShowDialog(this) == DialogResult.OK)
                {
                    result = newWindow.sReturnData;
                }
                newWindow.Dispose();
            }
            else
            {
                newWindow.LoadUrl(windowSetting.Url,windowSetting.Viewmodel);
                newWindow.Show();
                Global.formList.Add(newWindow);
            }
            return result;
        }

        #endregion

        void frmScBrowser_StatusTextChange(string pText)
        {
            tssl_status.Text = pText;
            if (pText == "���" || string.IsNullOrEmpty(pText))
            {
                tssl_status.Image = global::ScWebBrowser.Properties.Resources.ie;
            }
            else
            {
                tssl_status.Image = global::ScWebBrowser.Properties.Resources._5_130H2191323;
                
            }
        }

        void frmScBrowser_NewWindow2(ref object ppDisp, ref bool Cancel)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void frmScBrowser_NewWindow3(ref object ppDisp, ref bool Cancel, uint dwFlags, string bstrUrlContext, string bstrUrl)
        {
            if (!bstrUrl.Contains("/index.jsp"))
            {
                Global.sysConfig.WindowConfig.Url = bstrUrl;
                Global.sysConfig.WindowConfig.Viewmodel = sViewModel;
                CreateBrowserWindow(Global.sysConfig.GetSetting());
                frmScBrowser frm = Global.formList[Global.formList.Count-1];
                ppDisp = frm.scweb.ActiveXInstance;
                Cancel = true;
            }
            else
            {
                this.scweb.Navigate(bstrUrl);
                Cancel = true;
            }
        }

        private void frmScBrowser_Load(object sender, EventArgs e)
        {
            SetStateBar();
            this.scweb.ObjectForScripting = this;
        }

        private void SetStateBar()
        {
            foreach(ToolStripItem tsi in statusStrip.Items){
                if (tsi.Name != "tssl_status" && tsi.Name != "tssl_blank")
                {
                    tsi.Visible = sIsMainForm;
                }
            }

        }



        private void tssl_setting_Click(object sender, EventArgs e)
        {
            SettingForm sf = new SettingForm();
            if (sf.ShowDialog() == DialogResult.OK)
            {
                if (MessageBox.Show("���ñ���ɹ�����Ҫ��������������Ч���Ƿ�����������", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Restart();
                }
            }
        }

        #region ������
        private void tsddb_clean_DoubleClick(object sender, EventArgs e)
        {
            SysFunc.CleanAll();
        }

        private void tis_��������_Click(object sender, EventArgs e)
        {
            SysFunc.CleanAll();
        }

        private void tis_��������ݼ�����_Click(object sender, EventArgs e)
        {
            SysFunc.CleanFormData();
        }

        private void tis_����Cookies_Click(object sender, EventArgs e)
        {
            SysFunc.CleanCookies();
        }

        private void tsi_������ʷ��¼_Click(object sender, EventArgs e)
        {
            SysFunc.CleanHistory();
        }

        private void tsi_������ʱ�ļ�_Click(object sender, EventArgs e)
        {
            SysFunc.CleanTempFiles();
        }

        #endregion

        private void mainNotify_DoubleClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmScBrowser_FormClosing(object sender, FormClosingEventArgs e)
        {
            isQuit = true;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch(keyData){
                case Keys.Escape:
                    if(windowSetting.EscKeyEnable){
                        btnExit_Click(this.btnExit, new EventArgs());
                    }
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}