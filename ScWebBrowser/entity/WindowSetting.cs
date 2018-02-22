using System;
using System.Collections.Generic;
using System.Text;

namespace ScWebBrowser.entity
{
    /// <summary>
    /// 窗体相关的配置
    /// </summary>
    public class WindowSetting
    {
        private string _title;
        /// <summary>
        /// 窗体初始化标题
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private bool fixtitle=false;
        /// <summary>
        /// 固定窗体标题
        /// </summary>
        public bool Fixtitle
        {
            get { return fixtitle; }
            set { fixtitle = value; }
        }

        private int? _width = 1024;
        /// <summary>
        /// 宽度
        /// </summary>
        public int? Width
        {
            get { return _width; }
            set { _width = value; }
        }
        private int? _height = 768;
        /// <summary>
        /// 高度
        /// </summary>
        public int? Height
        {
            get { return _height; }
            set { _height = value; }
        }
        private bool _toolbar = false;
        /// <summary>
        /// 设置工具栏是否显示
        /// </summary>
        public bool Toolbar
        {
            get { return _toolbar; }
            set { _toolbar = value; }
        }
        private bool _statusbar = false;
        /// <summary>
        /// 状态栏是否显示
        /// </summary>
        public bool Statusbar
        {
            get { return _statusbar; }
            set { _statusbar = value; }
        }
        private bool _resizable = true;
        /// <summary>
        /// 窗体能否更改大小
        /// </summary>
        public bool Resizable
        {
            get { return _resizable; }
            set { _resizable = value; }
        }
        private bool _fullscreen = false;
        /// <summary>
        /// 是否全屏
        /// </summary>
        public bool Fullscreen
        {
            get { return _fullscreen; }
            set { _fullscreen = value; }
        }
        private bool _show_in_taskbar = false;
        /// <summary>
        /// 是否显示再任务栏
        /// </summary>
        public bool Show_in_taskbar
        {
            get { return _show_in_taskbar; }
            set { _show_in_taskbar = value; }
        }
        private bool _frame = true;
        /// <summary>
        /// 是否显示边框
        /// </summary>
        public bool Frame
        {
            get { return _frame; }
            set { _frame = value; }
        }
        private string _position = "center";
        /// <summary>
        /// 初始化的位置
        /// </summary>
        public string Position
        {
            get { return _position; }
            set { _position = value; }
        }
        private int? _min_width;
        /// <summary>
        /// 最小宽度
        /// </summary>
        public int? Min_width
        {
            get { return _min_width; }
            set { _min_width = value; }
        }
        private int? _min_height;
        /// <summary>
        /// 最小高度
        /// </summary>
        public int? Min_height
        {
            get { return _min_height; }
            set { _min_height = value; }
        }
        private int? _max_width;
        /// <summary>
        /// 最大宽度
        /// </summary>
        public int? Max_width
        {
            get { return _max_width; }
            set { _max_width = value; }
        }
        private int? _max_height;
        /// <summary>
        /// 最大高度
        /// </summary>
        public int? Max_height
        {
            get { return _max_height; }
            set { _max_height = value; }
        }
        private bool _show = true;
        /// <summary>
        /// 是否显示
        /// </summary>
        public bool Show
        {
            get { return _show; }
            set { _show = value; }
        }

        private bool _kiosk = true;
        /// <summary>
        /// 全屏模式
        /// </summary>
        public bool Kiosk
        {
            get { return _kiosk; }
            set { _kiosk = value; }
        }

        private bool maximize = true;
        /// <summary>
        /// 是否显示最大化按钮
        /// </summary>
        public bool Maximize
        {
            get { return maximize; }
            set { maximize = value; }
        }

        private bool minimize = true;
        /// <summary>
        /// 是否显示最小化按钮
        /// </summary>
        public bool Minimize
        {
            get { return minimize; }
            set { minimize = value; }
        }


        private bool _showerror = false;
        /// <summary>
        /// 是否显示脚本错误及相关提示
        /// </summary>
        public bool Showerror
        {
            get { return _showerror; }
            set { _showerror = value; }
        }

        private bool modeless = false;
        /// <summary>
        /// 是否模态阻塞，模态窗体，一定要等到当前窗口关闭才能操作其他窗体
        /// </summary>
        public bool Modeless
        {
            get { return modeless; }
            set { modeless = value; }
        }

        private string url;
        /// <summary>
        /// 打开窗体的WEB地址
        /// </summary>
        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        private string viewmodel;
        /// <summary>
        /// 渲染模式
        /// </summary>
        public string Viewmodel
        {
            get { return viewmodel; }
            set { viewmodel = value; }
        }

        private bool isMainForm = false;
        /// <summary>
        /// 是否主窗体，否则为弹出框
        /// </summary>
        public bool IsMainForm
        {
            get { return isMainForm; }
            set { isMainForm = value; }
        }

        private bool escKeyEnable = false;
        /// <summary>
        /// 是否允许Esc键关闭窗体
        /// </summary>
        public bool EscKeyEnable
        {
            get { return escKeyEnable; }
            set { escKeyEnable = value; }
        }
    }
}
