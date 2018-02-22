namespace Updater
{
    partial class frmUpdater
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdater));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ll_cancel = new System.Windows.Forms.LinkLabel();
            this.bw_update = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 36);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(423, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(410, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "正在从http://192.168.188.86:8080/emr/webbrowser下载";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "0%";
            // 
            // ll_cancel
            // 
            this.ll_cancel.AutoSize = true;
            this.ll_cancel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ll_cancel.LinkColor = System.Drawing.Color.Red;
            this.ll_cancel.Location = new System.Drawing.Point(364, 75);
            this.ll_cancel.Name = "ll_cancel";
            this.ll_cancel.Size = new System.Drawing.Size(67, 15);
            this.ll_cancel.TabIndex = 4;
            this.ll_cancel.TabStop = true;
            this.ll_cancel.Text = "取消下载";
            this.ll_cancel.Click += new System.EventHandler(this.ll_cancel_Click);
            // 
            // bw_update
            // 
            this.bw_update.WorkerReportsProgress = true;
            this.bw_update.WorkerSupportsCancellation = true;
            this.bw_update.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_update_DoWork);
            this.bw_update.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_update_RunWorkerCompleted);
            this.bw_update.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bw_update_ProgressChanged);
            // 
            // frmUpdater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 105);
            this.Controls.Add(this.ll_cancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUpdater";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "下载中";
            this.Load += new System.EventHandler(this.frmUpdater_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel ll_cancel;
        private System.ComponentModel.BackgroundWorker bw_update;
    }
}