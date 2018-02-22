namespace ScWebBrowser
{
    partial class frmScBrowser
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScBrowser));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tssl_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsddb_sys = new System.Windows.Forms.ToolStripDropDownButton();
            this.tssl_setting = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsddb_clean = new System.Windows.Forms.ToolStripDropDownButton();
            this.tis_清理表单数据及密码 = new System.Windows.Forms.ToolStripMenuItem();
            this.tis_清理Cookies = new System.Windows.Forms.ToolStripMenuItem();
            this.tsi_清理历史记录 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsi_清理临时文件 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tis_清理所有 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tssl_version = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_blank = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnExit = new System.Windows.Forms.Button();
            this.scweb = new ScWebBrowser.SckjWebBrowser();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.AutoSize = false;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl_status,
            this.tsddb_sys,
            this.tssl_setting,
            this.tsddb_clean,
            this.toolStripStatusLabel1,
            this.toolStripDropDownButton1,
            this.tssl_version,
            this.tssl_blank});
            this.statusStrip.Location = new System.Drawing.Point(0, 598);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1036, 23);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // tssl_status
            // 
            this.tssl_status.Image = global::ScWebBrowser.Properties.Resources._5_130H2191323;
            this.tssl_status.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tssl_status.Margin = new System.Windows.Forms.Padding(0);
            this.tssl_status.Name = "tssl_status";
            this.tssl_status.Size = new System.Drawing.Size(531, 23);
            this.tssl_status.Spring = true;
            this.tssl_status.Text = "完成";
            this.tssl_status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsddb_sys
            // 
            this.tsddb_sys.Image = global::ScWebBrowser.Properties.Resources.favicon;
            this.tsddb_sys.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddb_sys.Margin = new System.Windows.Forms.Padding(0, -1, 0, 0);
            this.tsddb_sys.Name = "tsddb_sys";
            this.tsddb_sys.Size = new System.Drawing.Size(98, 24);
            this.tsddb_sys.Text = "切换系统";
            // 
            // tssl_setting
            // 
            this.tssl_setting.Image = global::ScWebBrowser.Properties.Resources.设置;
            this.tssl_setting.IsLink = true;
            this.tssl_setting.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.tssl_setting.Margin = new System.Windows.Forms.Padding(0);
            this.tssl_setting.Name = "tssl_setting";
            this.tssl_setting.Size = new System.Drawing.Size(85, 23);
            this.tssl_setting.Text = "系统设置";
            this.tssl_setting.Click += new System.EventHandler(this.tssl_setting_Click);
            // 
            // tsddb_clean
            // 
            this.tsddb_clean.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tis_清理表单数据及密码,
            this.tis_清理Cookies,
            this.tsi_清理历史记录,
            this.tsi_清理临时文件,
            this.toolStripSeparator1,
            this.tis_清理所有});
            this.tsddb_clean.ForeColor = System.Drawing.Color.Blue;
            this.tsddb_clean.Image = global::ScWebBrowser.Properties.Resources.clear;
            this.tsddb_clean.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddb_clean.Margin = new System.Windows.Forms.Padding(0, -1, 0, 0);
            this.tsddb_clean.Name = "tsddb_clean";
            this.tsddb_clean.Size = new System.Drawing.Size(98, 24);
            this.tsddb_clean.Text = "清理缓存";
            this.tsddb_clean.DoubleClick += new System.EventHandler(this.tsddb_clean_DoubleClick);
            // 
            // tis_清理表单数据及密码
            // 
            this.tis_清理表单数据及密码.Name = "tis_清理表单数据及密码";
            this.tis_清理表单数据及密码.Size = new System.Drawing.Size(213, 24);
            this.tis_清理表单数据及密码.Text = "清理表单数据及密码";
            this.tis_清理表单数据及密码.Click += new System.EventHandler(this.tis_清理表单数据及密码_Click);
            // 
            // tis_清理Cookies
            // 
            this.tis_清理Cookies.Name = "tis_清理Cookies";
            this.tis_清理Cookies.Size = new System.Drawing.Size(213, 24);
            this.tis_清理Cookies.Text = "清理Cookies";
            this.tis_清理Cookies.Click += new System.EventHandler(this.tis_清理Cookies_Click);
            // 
            // tsi_清理历史记录
            // 
            this.tsi_清理历史记录.Name = "tsi_清理历史记录";
            this.tsi_清理历史记录.Size = new System.Drawing.Size(213, 24);
            this.tsi_清理历史记录.Text = "清理历史记录";
            this.tsi_清理历史记录.Click += new System.EventHandler(this.tsi_清理历史记录_Click);
            // 
            // tsi_清理临时文件
            // 
            this.tsi_清理临时文件.Name = "tsi_清理临时文件";
            this.tsi_清理临时文件.Size = new System.Drawing.Size(213, 24);
            this.tsi_清理临时文件.Text = "清理临时文件";
            this.tsi_清理临时文件.Click += new System.EventHandler(this.tsi_清理临时文件_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(210, 6);
            // 
            // tis_清理所有
            // 
            this.tis_清理所有.Name = "tis_清理所有";
            this.tis_清理所有.Size = new System.Drawing.Size(213, 24);
            this.tis_清理所有.Text = "清理所有All";
            this.tis_清理所有.Click += new System.EventHandler(this.tis_清理所有_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(88, 23);
            this.toolStripStatusLabel1.Text = "版本:V2.0.1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem8,
            this.toolStripMenuItem7,
            this.toolStripMenuItem6,
            this.toolStripMenuItem5,
            this.toolStripMenuItem4,
            this.toolStripMenuItem3,
            this.toolStripMenuItem2});
            this.toolStripDropDownButton1.Image = global::ScWebBrowser.Properties.Resources.zoom_in;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Margin = new System.Windows.Forms.Padding(0, -1, 0, 0);
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(78, 24);
            this.toolStripDropDownButton1.Text = "100%";
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(118, 24);
            this.toolStripMenuItem8.Text = "200%";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(118, 24);
            this.toolStripMenuItem7.Text = "175%";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(118, 24);
            this.toolStripMenuItem6.Text = "150%";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(118, 24);
            this.toolStripMenuItem5.Text = "125%";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Checked = true;
            this.toolStripMenuItem4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(118, 24);
            this.toolStripMenuItem4.Text = "100%";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(118, 24);
            this.toolStripMenuItem3.Text = "75%";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(118, 24);
            this.toolStripMenuItem2.Text = "50%";
            // 
            // tssl_version
            // 
            this.tssl_version.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tssl_version.IsLink = true;
            this.tssl_version.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.tssl_version.Margin = new System.Windows.Forms.Padding(0);
            this.tssl_version.Name = "tssl_version";
            this.tssl_version.Size = new System.Drawing.Size(30, 23);
            this.tssl_version.Text = "IE7";
            // 
            // tssl_blank
            // 
            this.tssl_blank.Margin = new System.Windows.Forms.Padding(0);
            this.tssl_blank.Name = "tssl_blank";
            this.tssl_blank.Size = new System.Drawing.Size(13, 23);
            this.tssl_blank.Text = "|";
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(935, 572);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Visible = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // scweb
            // 
            this.scweb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scweb.Location = new System.Drawing.Point(0, 0);
            this.scweb.MinimumSize = new System.Drawing.Size(20, 20);
            this.scweb.Name = "scweb";
            this.scweb.Size = new System.Drawing.Size(1036, 598);
            this.scweb.TabIndex = 0;
            this.scweb.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // frmScBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 621);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.scweb);
            this.Controls.Add(this.statusStrip);
            this.DockAreas = WinFormsUI.Docking.DockAreas.Document;
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmScBrowser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "数据加载中,请稍后...";
            this.Load += new System.EventHandler(this.frmScBrowser_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmScBrowser_FormClosing);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SckjWebBrowser scweb;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tssl_status;
        private System.Windows.Forms.ToolStripStatusLabel tssl_version;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripDropDownButton tsddb_clean;
        private System.Windows.Forms.ToolStripMenuItem tis_清理表单数据及密码;
        private System.Windows.Forms.ToolStripMenuItem tis_清理Cookies;
        private System.Windows.Forms.ToolStripMenuItem tsi_清理历史记录;
        private System.Windows.Forms.ToolStripMenuItem tsi_清理临时文件;
        private System.Windows.Forms.ToolStripMenuItem tis_清理所有;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel tssl_setting;
        private System.Windows.Forms.ToolStripDropDownButton tsddb_sys;
        private System.Windows.Forms.ToolStripStatusLabel tssl_blank;
        private System.Windows.Forms.Button btnExit;
    }
}