using System;
using System.Collections.Generic;
using System.Text;

namespace ScWebBrowser.entity
{
    /// <summary>
    /// ������ص�����
    /// </summary>
    public class WindowSetting
    {
        private string _title;
        /// <summary>
        /// �����ʼ������
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private bool fixtitle=false;
        /// <summary>
        /// �̶��������
        /// </summary>
        public bool Fixtitle
        {
            get { return fixtitle; }
            set { fixtitle = value; }
        }

        private int? _width = 1024;
        /// <summary>
        /// ���
        /// </summary>
        public int? Width
        {
            get { return _width; }
            set { _width = value; }
        }
        private int? _height = 768;
        /// <summary>
        /// �߶�
        /// </summary>
        public int? Height
        {
            get { return _height; }
            set { _height = value; }
        }
        private bool _toolbar = false;
        /// <summary>
        /// ���ù������Ƿ���ʾ
        /// </summary>
        public bool Toolbar
        {
            get { return _toolbar; }
            set { _toolbar = value; }
        }
        private bool _statusbar = false;
        /// <summary>
        /// ״̬���Ƿ���ʾ
        /// </summary>
        public bool Statusbar
        {
            get { return _statusbar; }
            set { _statusbar = value; }
        }
        private bool _resizable = true;
        /// <summary>
        /// �����ܷ���Ĵ�С
        /// </summary>
        public bool Resizable
        {
            get { return _resizable; }
            set { _resizable = value; }
        }
        private bool _fullscreen = false;
        /// <summary>
        /// �Ƿ�ȫ��
        /// </summary>
        public bool Fullscreen
        {
            get { return _fullscreen; }
            set { _fullscreen = value; }
        }
        private bool _show_in_taskbar = false;
        /// <summary>
        /// �Ƿ���ʾ��������
        /// </summary>
        public bool Show_in_taskbar
        {
            get { return _show_in_taskbar; }
            set { _show_in_taskbar = value; }
        }
        private bool _frame = true;
        /// <summary>
        /// �Ƿ���ʾ�߿�
        /// </summary>
        public bool Frame
        {
            get { return _frame; }
            set { _frame = value; }
        }
        private string _position = "center";
        /// <summary>
        /// ��ʼ����λ��
        /// </summary>
        public string Position
        {
            get { return _position; }
            set { _position = value; }
        }
        private int? _min_width;
        /// <summary>
        /// ��С���
        /// </summary>
        public int? Min_width
        {
            get { return _min_width; }
            set { _min_width = value; }
        }
        private int? _min_height;
        /// <summary>
        /// ��С�߶�
        /// </summary>
        public int? Min_height
        {
            get { return _min_height; }
            set { _min_height = value; }
        }
        private int? _max_width;
        /// <summary>
        /// �����
        /// </summary>
        public int? Max_width
        {
            get { return _max_width; }
            set { _max_width = value; }
        }
        private int? _max_height;
        /// <summary>
        /// ���߶�
        /// </summary>
        public int? Max_height
        {
            get { return _max_height; }
            set { _max_height = value; }
        }
        private bool _show = true;
        /// <summary>
        /// �Ƿ���ʾ
        /// </summary>
        public bool Show
        {
            get { return _show; }
            set { _show = value; }
        }

        private bool _kiosk = true;
        /// <summary>
        /// ȫ��ģʽ
        /// </summary>
        public bool Kiosk
        {
            get { return _kiosk; }
            set { _kiosk = value; }
        }

        private bool maximize = true;
        /// <summary>
        /// �Ƿ���ʾ��󻯰�ť
        /// </summary>
        public bool Maximize
        {
            get { return maximize; }
            set { maximize = value; }
        }

        private bool minimize = true;
        /// <summary>
        /// �Ƿ���ʾ��С����ť
        /// </summary>
        public bool Minimize
        {
            get { return minimize; }
            set { minimize = value; }
        }


        private bool _showerror = false;
        /// <summary>
        /// �Ƿ���ʾ�ű����������ʾ
        /// </summary>
        public bool Showerror
        {
            get { return _showerror; }
            set { _showerror = value; }
        }

        private bool modeless = false;
        /// <summary>
        /// �Ƿ�ģ̬������ģ̬���壬һ��Ҫ�ȵ���ǰ���ڹرղ��ܲ�����������
        /// </summary>
        public bool Modeless
        {
            get { return modeless; }
            set { modeless = value; }
        }

        private string url;
        /// <summary>
        /// �򿪴����WEB��ַ
        /// </summary>
        public string Url
        {
            get { return url; }
            set { url = value; }
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

        private bool isMainForm = false;
        /// <summary>
        /// �Ƿ������壬����Ϊ������
        /// </summary>
        public bool IsMainForm
        {
            get { return isMainForm; }
            set { isMainForm = value; }
        }

        private bool escKeyEnable = false;
        /// <summary>
        /// �Ƿ�����Esc���رմ���
        /// </summary>
        public bool EscKeyEnable
        {
            get { return escKeyEnable; }
            set { escKeyEnable = value; }
        }
    }
}
