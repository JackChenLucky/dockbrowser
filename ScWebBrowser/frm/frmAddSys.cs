using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ScWebBrowser.entity;

namespace ScWebBrowser.frm
{
    public partial class frmAddSys : Form
    {

        private ScSystem scs = null;

        private Configure conf = null;

        private string sUrl = "";

        public frmAddSys(string pUrl)
        {
            sUrl = pUrl;
            InitializeComponent();
        }

        private void frmAddSys_Load(object sender, EventArgs e)
        {
            tb_address.Text = sUrl;
            FillDir();
        }

        private void FillDir()
        {
            conf = ConfigureHelper.getInitConfigure();
            cmb_updir.Items.Add("--上级目录--");
            List<ScSystem> upDirDs = new List<ScSystem>();
            ScSystem ssBlank = new ScSystem();
            ssBlank.Name = "";
            upDirDs.Add(ssBlank);
            foreach (ScSystem ss in conf.SysList)
            {
                if(ss.Pid=="0"){
                    upDirDs.Add(ss);
                }
            }

            cmb_updir.DataSource = upDirDs;
            cmb_updir.DisplayMember = "Name";
            cmb_updir.ValueMember = "Id";
            cmb_updir.SelectedIndex = 0;
        }

        private void cmb_updir_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
            {
                return;
            }
            e.DrawBackground();
            e.DrawFocusRectangle();
            e.Graphics.DrawString(cmb_updir.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds.X, e.Bounds.Y + 3);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_name.Text.Trim()))
            {
                MessageBox.Show("网页名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            scs = new ScSystem();
            scs.Deflt = cb_deflt.Checked ? "Y" : "N";
            if(cb_deflt.Checked){
                foreach(ScSystem ss in conf.SysList){
                    ss.Deflt = "N";
                }
            }
            scs.Name = tb_name.Text.Trim();
            scs.Url = tb_address.Text.Trim();
            List<ScSystem> ssList = new List<ScSystem>();
            if (cmb_updir.SelectedIndex == 0)
            {
                scs.Id = Convert.ToString(conf.SysList.Count + 1);
                scs.Pid = "0";
                conf.SysList.Add(scs);
                ssList = conf.SysList;
            }
            else
            {
                string selPid = (cmb_updir.SelectedItem as ScSystem).Id;
                bool sFlag = false;
                int sysIndex = 1;

                for (int i = 0; i < conf.SysList.Count; )
                {
                    if (conf.SysList[i].Id == selPid)
                    {
                        sFlag = true;
                        conf.SysList[i].Id = Convert.ToString(sysIndex++);
                        ssList.Add(conf.SysList[i]);
                        if (i == conf.SysList.Count - 1)
                        {
                            scs.Id = Convert.ToString(sysIndex++);
                            scs.Pid = ssList[ssList.Count - 1].Id;
                            ssList.Add(scs);
                        }
                    }
                    else if (sFlag && ((i + 1) >= conf.SysList.Count ? "-1" : conf.SysList[i + 1].Id) != selPid)
                    {
                        scs.Id = Convert.ToString(sysIndex++);
                        scs.Pid = ssList[ssList.Count - 1].Id;
                        ssList.Add(scs);
                        conf.SysList[i].Id = Convert.ToString(sysIndex++);
                        ssList.Add(conf.SysList[i]);
                        sFlag = false;
                    }
                    else
                    {
                        conf.SysList[i].Id = Convert.ToString(sysIndex++);
                        ssList.Add(conf.SysList[i]);
                    }
                    i++;
                }
            }
            //重置ID

            ConfigureHelper.SaveWebapp(ssList);
            MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
        }
    }
}