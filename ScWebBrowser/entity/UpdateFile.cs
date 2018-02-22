using System;
using System.Collections.Generic;
using System.Text;

namespace ScWebBrowser.entity
{
    public class UpdateFile
    {
        private string id;
        /// <summary>
        /// 文件的ID
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private string type;
        /// <summary>
        /// 类型，影响下载后打开的方式
        /// </summary>
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        private string version;
        /// <summary>
        /// 文件版本
        /// </summary>
        public string Version
        {
            get { return version; }
            set { version = value; }
        }

        private string file;
        /// <summary>
        /// 文件地址及名称
        /// </summary>
        public string File
        {
            get { return file; }
            set { file = value; }
        }
    }
}
