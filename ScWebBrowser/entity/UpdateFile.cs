using System;
using System.Collections.Generic;
using System.Text;

namespace ScWebBrowser.entity
{
    public class UpdateFile
    {
        private string id;
        /// <summary>
        /// �ļ���ID
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private string type;
        /// <summary>
        /// ���ͣ�Ӱ�����غ�򿪵ķ�ʽ
        /// </summary>
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        private string version;
        /// <summary>
        /// �ļ��汾
        /// </summary>
        public string Version
        {
            get { return version; }
            set { version = value; }
        }

        private string file;
        /// <summary>
        /// �ļ���ַ������
        /// </summary>
        public string File
        {
            get { return file; }
            set { file = value; }
        }
    }
}
