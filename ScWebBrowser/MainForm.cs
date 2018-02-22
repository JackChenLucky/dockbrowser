using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinFormsUI.Docking;

namespace ScWebBrowser
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public partial class MainForm : Form
    {
        private DummyTaskList m_taskList = new DummyTaskList();
        private frmScBrowser browser = new frmScBrowser(Global.sysConfig.GetSetting());

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            browser.LoadUrl(Global.sysConfig.WindowConfig.Url, "IE11");
            m_taskList.Show(dockPanel, DockState.DockLeft);
            browser.Show(dockPanel,DockState.Document);//È«²¿ÆÌÂú
        }
    }
}