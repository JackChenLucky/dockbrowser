using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ionic.Zip;
using System.IO;

namespace Updater
{
    public partial class frmUpdater : Form
    {
        private string sFileUrl = string.Empty;

        public string sUnzipDir = string.Empty;

        public string sStartCmd = string.Empty;

        public string sVersion = string.Empty;

        private string sTempFileName = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)+"\\update.zip";

        public frmUpdater()
        {
            InitializeComponent();
        }

        public frmUpdater(string pFileUrl)
        {
            sFileUrl = pFileUrl;
            InitializeComponent();
        }

        private void ll_cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定取消更新下载？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //停止下载，并删除已经创建的临时文件
            }
        }

        private void bw_update_DoWork(object sender, DoWorkEventArgs e)
        {
            DownloadFile();
        }

        private void bw_update_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
            label2.Text = e.ProgressPercentage + "%";
        }

        private void bw_update_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Error!=null)
            {
                MessageBox.Show(e.Error.ToString());
                return;
            }
            if (!e.Cancelled)
            {
                if(!string.IsNullOrEmpty(sUnzipDir)){
                    UnZipFile(sUnzipDir, sTempFileName);
                    System.IO.File.Delete(sTempFileName);
                }

                this.Close();
            }
        }

        private void frmUpdater_Load(object sender, EventArgs e)
        {
            bw_update.RunWorkerAsync();
        }


        private void DownloadFile()
        {
            int percent = 0;
            try
            {
                System.Net.HttpWebRequest Myrq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(sFileUrl);
                System.Net.HttpWebResponse myrp = (System.Net.HttpWebResponse)Myrq.GetResponse();
                long totalBytes = myrp.ContentLength;
                System.IO.Stream st = myrp.GetResponseStream();
                System.IO.Stream so = new System.IO.FileStream(sTempFileName, System.IO.FileMode.Create);
                long totalDownloadedByte = 0;
                byte[] by = new byte[1024];
                int osize = st.Read(by, 0, (int)by.Length);
                while (osize > 0)
                {
                    totalDownloadedByte = osize + totalDownloadedByte;
                    System.Windows.Forms.Application.DoEvents();
                    so.Write(by, 0, osize);
                    osize = st.Read(by, 0, (int)by.Length);

                    percent = Convert.ToInt32(Math.Round((totalDownloadedByte * 1.0 / totalBytes), 2) * 100);
                    bw_update.ReportProgress(percent);
                    System.Threading.Thread.Sleep(10);
                }
                so.Close();
                st.Close();
            }
            catch (System.Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// 解压zip文件
        /// </summary>
        /// <param name="targetDirectory">解压后目录</param>
        /// <param name="zipFileName">压缩包文件名</param>
        /// <returns>解压结果是否成功</returns>
        public bool UnZipFile(string targetDirectory, string zipFileName)
        {
            bool result = true;
            try
            {
                using (ZipFile zip = new ZipFile(zipFileName))
                {
                    zip.ExtractAll(targetDirectory);
                }
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }


    }
}