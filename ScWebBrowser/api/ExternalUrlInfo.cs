using System;
using System.Collections.Generic;
using System.Text;
using ScWebBrowser.entity;

namespace ScWebBrowser.api
{
    public class ExternalUrlInfo
    {
        private string url;
        /// <summary>
        /// url
        /// </summary>
        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        private string opentype;
        /// <summary>
        /// �򿪷�ʽ
        /// </summary>
        public string Opentype
        {
            get { return opentype; }
            set { opentype = value; }
        }

        private string viewmodel;
        /// <summary>
        /// ��Ⱦģʽ
        /// </summary>
        public string Viewmodel
        {
            get { return viewmodel; }
            set { viewmodel = value; }
        }

        private WindowSetting window;
        /// <summary>
        /// �򿪴�������ѡ��
        /// </summary>
        public WindowSetting Window
        {
            get { return window; }
            set { window = value; }
        }
    }
}
