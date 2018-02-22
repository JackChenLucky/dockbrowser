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
    /// Ϊ�������ṩ�Զ����µĹ���
    /// </summary>
    public class Updater
    {
        /// <summary>
        /// ��鵱ǰ�汾�Ƿ���Ҫ����,
        /// �����Ҫ���·���
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
                //1������http���󣬻�ȡ��ǰ�����°汾�İ汾���뼰���ص�ַ
                string versionFile = HttpGet(update_server);
                UpdateFiles files = JsonConvert.DeserializeObject<UpdateFiles>(versionFile);
                //IDΪ1��Ϊϵͳ����������Ϊϵͳ�Ĳ���������Զ����²��������̨��־��������������ȣ�ϵͳ֧����Сģ�����С����������κβ������
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
                Global.ShowWarning("��ȡ�Զ�������Ϣʧ��:" + ex.Message);
                return string.Empty;
            }
        }
    }
}
