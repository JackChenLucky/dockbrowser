using System;
using System.Collections.Generic;
using System.Text;

namespace ScWebBrowser.entity
{
    public class SysMenu
    {
        private string menutype;
        /// <summary>
        /// �˵�����
        /// </summary>
        public string Menutype
        {
            get { return menutype; }
            set { menutype = value; }
        }

        private string title;
        /// <summary>
        /// �ı�
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string image;

        public string Image
        {
            get { return image; }
            set { image = value; }
        }

        private string clickeventfunc;
        /// <summary>
        ///�����ص���������
        /// </summary>
        public string Clickeventfunc
        {
            get { return clickeventfunc; }
            set { clickeventfunc = value; }
        }

        private List<SysMenu> submenu;
        //�Ӳ˵�
        public List<SysMenu> Submenu
        {
            get { return submenu; }
            set { submenu = value; }
        }
    }
}
