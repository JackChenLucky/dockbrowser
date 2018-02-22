using System;
using System.Collections.Generic;
using System.Text;

namespace ScWebBrowser.entity
{
    public class TrayOption
    {
        private string title;
        /// <summary>
        /// ���̵ı���
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string icon;
        /// <summary>
        /// ͼ��
        /// </summary>
        public string Icon
        {
            get { return icon; }
            set { icon = value; }
        }


        private List<SysMenu> menus;
        /// <summary>
        /// �˵�
        /// </summary>
        public List<SysMenu> Menus
        {
            get { return menus; }
            set { menus = value; }
        }
    }
}
