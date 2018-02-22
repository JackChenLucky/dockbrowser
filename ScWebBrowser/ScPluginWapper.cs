using System;
using System.Collections.Generic;
using System.Text;
using ScWebBrowser.entity;
using System.IO;
using System.Xml.Serialization;

namespace ScWebBrowser
{
    public class ScPluginWapper
    {
        private string pluginDir = Global.gAppPath+"\\plugins";

        List<ScPlugin> plugins = new List<ScPlugin>();

        public ScPluginWapper()
        {
            LoadPlugins();
        }

        /// <summary>
        /// �������еĲ��
        /// </summary>
        private void LoadPlugins()
        {
           //1��ɨ�����в��Ŀ¼�µĲ��
            DirectoryInfo di = new DirectoryInfo(pluginDir);
            foreach(DirectoryInfo subDir in di.GetDirectories()){
                FileInfo[] fis = subDir.GetFiles("plugin.xml");
                if(fis.Length>0){
                    string filename = fis[0].FullName;

                }
            }
        }

        /// <summary>
        /// ��ʼ�����
        /// </summary>
        public void InitPlugins()
        {
            foreach(ScPlugin sp in plugins){
                sp.InitPlugIn("");
            }
        }


        public T DESerializer<T>(string strXML) where T : class
        {
            try
            {
                using (StringReader sr = new StringReader(strXML))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    return serializer.Deserialize(sr) as T;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
