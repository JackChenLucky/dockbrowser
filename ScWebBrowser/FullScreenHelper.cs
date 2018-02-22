using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;

namespace ScWebBrowser
{
    public class FullScreenHelper
    {
        /// <summary>  
        /// ����ȫ������ȡ��ȫ��  
        /// </summary>  
        /// <param name="fullscreen">true:ȫ�� false:�ָ�</param>  
        /// <param name="rectOld">���õ�ʱ�򣬴˲�������ԭʼ�ߴ磬�ָ�ʱ�ô˲������ûָ�</param>  
        /// <returns>���ý��</returns>  
        public static Boolean SetFormFullScreen(Form form,Boolean fullscreen)//, ref Rectangle rectOld
        {
            form.SuspendLayout();
            Rectangle rectOld = Rectangle.Empty;
            Int32 hwnd = 0;
            hwnd = FindWindow("Shell_TrayWnd", null);//��ȡ�������ľ��

            if (hwnd == 0) return false;

            if (fullscreen)//ȫ��
            {
                ShowWindow(hwnd, SW_HIDE);//����������
                form.FormBorderStyle = FormBorderStyle.None;
                form.WindowState = FormWindowState.Maximized;
                form.Activate();//
            }
            else//��ԭ 
            {
                form.WindowState = FormWindowState.Normal;
                form.FormBorderStyle = FormBorderStyle.Sizable;
                ShowWindow(hwnd, SW_SHOW);//��ʾ������
                form.Activate();
            }
            form.ResumeLayout(false);
            return true;
        }

        #region user32.dll

        public const Int32 SPIF_UPDATEINIFILE = 0x1;
        public const Int32 SPI_SETWORKAREA = 47;
        public const Int32 SPI_GETWORKAREA = 48;
        public const Int32 SW_SHOW = 5;
        public const Int32 SW_HIDE = 0;

        [DllImport("user32.dll", EntryPoint = "ShowWindow")]
        public static extern Int32 ShowWindow(Int32 hwnd, Int32 nCmdShow);

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        private static extern Int32 FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
        private static extern Int32 SystemParametersInfo(Int32 uAction, Int32 uParam, ref Rectangle lpvParam, Int32 fuWinIni);

        #endregion
    }
}
