using System;
using System.Collections.Generic;
using System.Text;
using ScWebBrowser.entity;
using Newtonsoft.Json;
using System.Net;
using System.IO;

namespace ScWebBrowser
{
    /// <summary>
    /// 为本程序提供自动更新的功能
    /// </summary>
    public class Updater
    {
        /// <summary>
        /// 检查当前版本是否需要更新,
        /// 如果需要更新返回
        /// </summary>
        /// <param name="pVersion"></param>
        public string CheckUpdate()
        {
            string file =  System.AppDomain.CurrentDomain.BaseDirectory + "application.ini"; 
            IniFileHelper ifh = new IniFileHelper(file);
            bool update = bool.Parse(ifh.IniReadValue("application", "update", "false"));
            string updateFileUrl = "";
            if(update){
                string pVersion = ifh.IniReadValue("application", "version", "0.0.0");
                string update_server = ifh.IniReadValue("application", "update_server", "");
                //1、发起http请求，获取当前的最新版本的版本号码及下载地址
                string versionFile = HttpGet(update_server);
                UpdateFiles files = JsonConvert.DeserializeObject<UpdateFiles>(versionFile);
                //ID为1的为系统主程序，其他为系统的插件，例如自动更新插件、控制台日志插件、诊间结算插件等，系统支持最小模块运行。即不加载任何插件运行
                if(files!=null){
                    foreach (UpdateFile uf in files.Filelist)
                    {
                        if(uf.Id=="1"&&pVersion!=uf.Version){
                            try
                            {
                                System.Diagnostics.Process.Start(Global.gAppPath + @"plugins\\updater\\Updater.exe", string.Format("{0} {1} {2} {3}", update_server.Replace("version.json", uf.File), Global.gAppPath, "ScWebBrowser.exe", uf.Version));
                            }
                            catch (Exception ex)
                            {
                                Global.ShowWarning(ex.Message);
                            }
                            System.Environment.Exit(0);
                        }
                    }
                }
            }   
            return updateFileUrl;
        }

        public bool OpenLocalExe(string pFile)
        {
            
            return true;
        }

        public string HttpGet(string Url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                string retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();

                return retString;
            }catch(Exception ex){
                Global.ShowWarning("获取自动更新信息失败:" + ex.Message);
                return string.Empty;
            }
        }
    }
}
