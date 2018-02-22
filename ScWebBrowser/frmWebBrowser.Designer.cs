namespace ScWebBrowser
{
    partial class frmWebBrowser
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWebBrowser));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsddb_sys = new System.Windows.Forms.ToolStripDropDownButton();
            this.tss_setting = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_clear = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dsddb = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.自定义ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tssl_version = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.browserControl1 = new ScWebBrowser.BrowserControl();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.tsddb_sys,
            this.tss_setting,
            this.tssl_clear,
            this.toolStripStatusLabel1,
            this.dsddb,
            this.tssl_version});
            this.statusStrip1.Location = new System.Drawing.Point(0, 511);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(951, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel.Image")));
            this.toolStripStatusLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripStatusLabel.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.toolStripStatusLabel.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(493, 22);
            this.toolStripStatusLabel.Spring = true;
            this.toolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsddb_sys
            // 
            this.tsddb_sys.Image = ((System.Drawing.Image)(resources.GetObject("tsddb_sys.Image")));
            this.tsddb_sys.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddb_sys.Margin = new System.Windows.Forms.Padding(0);
            this.tsddb_sys.Name = "tsddb_sys";
            this.tsddb_sys.Size = new System.Drawing.Size(94, 22);
            this.tsddb_sys.Text = "切换系统";
            // 
            // tss_setting
            // 
            this.tss_setting.Image = ((System.Drawing.Image)(resources.GetObject("tss_setting.Image")));
            this.tss_setting.IsLink = true;
            this.tss_setting.Margin = new System.Windows.Forms.Padding(0);
            this.tss_setting.Name = "tss_setting";
            this.tss_setting.Size = new System.Drawing.Size(81, 22);
            this.tss_setting.Text = "系统设置";
            this.tss_setting.Click += new System.EventHandler(this.tss_setting_Click);
            // 
            // tssl_clear
            // 
            this.tssl_clear.Image = ((System.Drawing.Image)(resources.GetObject("tssl_clear.Image")));
            this.tssl_clear.IsLink = true;
            this.tssl_clear.Margin = new System.Windows.Forms.Padding(0);
            this.tssl_clear.Name = "tssl_clear";
            this.tssl_clear.Size = new System.Drawing.Size(81, 22);
            this.tssl_clear.Text = "清理缓存";
            this.tssl_clear.ToolTipText = "清理cookies和缓存";
            this.tssl_clear.Click += new System.EventHandler(this.tssl_clear_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(79, 22);
            this.toolStripStatusLabel1.Text = "版本:V1.0.1";
            // 
            // dsddb
            // 
            this.dsddb.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem9,
            this.toolStripMenuItem8,
            this.toolStripMenuItem7,
            this.toolStripMenuItem6,
            this.toolStripMenuItem5,
            this.toolStripMenuItem4,
            this.toolStripMenuItem3,
            this.toolStripSeparator1,
            this.自定义ToolStripMenuItem});
            this.dsddb.Image = ((System.Drawing.Image)(resources.GetObject("dsddb.Image")));
            this.dsddb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dsddb.Margin = new System.Windows.Forms.Padding(0);
            this.dsddb.Name = "dsddb";
            this.dsddb.Size = new System.Drawing.Size(74, 22);
            this.dsddb.Text = "100%";
            this.dsddb.Click += new System.EventHandler(this.dsddb_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(120, 24);
            this.toolStripMenuItem9.Text = "200%";
            this.toolStripMenuItem9.Click += new System.EventHandler(this.toolStripMenuItem9_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(120, 24);
            this.toolStripMenuItem8.Text = "175%";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.toolStripMenuItem8_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(120, 24);
            this.toolStripMenuItem7.Text = "150%";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(120, 24);
            this.toolStripMenuItem6.Text = "125%";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Checked = true;
            this.toolStripMenuItem5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(120, 24);
            this.toolStripMenuItem5.Text = "100%";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(120, 24);
            this.toolStripMenuItem4.Text = "75%";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(120, 24);
            this.toolStripMenuItem3.Text = "50%";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(117, 6);
            // 
            // 自定义ToolStripMenuItem
            // 
            this.自定义ToolStripMenuItem.Name = "自定义ToolStripMenuItem";
            this.自定义ToolStripMenuItem.Size = new System.Drawing.Size(120, 24);
            this.自定义ToolStripMenuItem.Text = "自定义";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "圣辰网络科技";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(158, 74);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(157, 24);
            this.toolStripMenuItem1.Text = "系统设置(&S)";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // tssl_version
            // 
            this.tssl_version.IsLink = true;
            this.tssl_version.Margin = new System.Windows.Forms.Padding(0);
            this.tssl_version.Name = "tssl_version";
            this.tssl_version.Size = new System.Drawing.Size(29, 22);
            this.tssl_version.Text = "IE7";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(157, 24);
            this.toolStripMenuItem2.Text = "退出系统(&E)";
            // 
            // browserControl1
            // 
            this.browserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browserControl1.Location = new System.Drawing.Point(0, 0);
            this.browserControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.browserControl1.Name = "browserControl1";
            this.browserControl1.Size = new System.Drawing.Size(951, 511);
            this.browserControl1.TabIndex = 0;
            // 
            // frmWebBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 533);
            this.Controls.Add(this.browserControl1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmWebBrowser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmWebBrowser";
            this.Load += new System.EventHandler(this.frmWebBrowser_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripDropDownButton tsddb_sys;
        private BrowserControl browserControl1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripStatusLabel tss_setting;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tssl_clear;
        private System.Windows.Forms.ToolStripDropDownButton dsddb;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 自定义ToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel tssl_version;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }
}