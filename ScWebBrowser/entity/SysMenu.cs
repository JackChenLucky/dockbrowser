using System;
using System.Collections.Generic;
using System.Text;

namespace ScWebBrowser.entity
{
    public class SysMenu
    {
        private string menutype;
        /// <summary>
        /// 菜单类型
        /// </summary>
        public string Menutype
        {
            get { return menutype; }
            set { menutype = value; }
        }

        private string title;
        /// <summary>
        /// 文本
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
        ///单击回调函数名称
        /// </summary>
        public string Clickeventfunc
        {
            get { return clickeventfunc; }
            set { clickeventfunc = value; }
        }

        private List<SysMenu> submenu;
        //子菜单
        public List<SysMenu> Submenu
        {
            get { return submenu; }
            set { submenu = value; }
        }
    }
}
