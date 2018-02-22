using System;
using System.Collections.Generic;
using System.Text;
using ScWebBrowser.entity;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
namespace ScWebBrowser
{
    /// <summary>
    /// ά��һ��ϵͳ��ȫ�ֱ���
    /// </summary>
    public class Global
    {
        /// <summary>
        /// ���Ӵ���ί���¼�
        /// </summary>
        public delegate void dialogClose();
        /// <summary>
        /// ϵͳ�Ĵ����б�
        /// </summary>
        public static List<frmScBrowser> formList = new List<frmScBrowser>();

        /// <summary>
        /// ϵͳĬ������
        /// </summary>
        public static Configure sysConfig;

        public static string gAppPath = System.AppDomain.CurrentDomain.BaseDirectory;


        public static WindowSetting GetWindowSetting(string setting)
        {
            WindowSetting inWindowSetting = JsonConvert.DeserializeObject<WindowSetting>(setting);
            WindowSetting  newWindowSetting =  Global.sysConfig.WindowConfig;
            newWindowSetting.Title = string.IsNullOrEmpty(inWindowSetting.Title) ? newWindowSetting.Title : inWindowSetting.Title;
            newWindowSetting.Fixtitle = inWindowSetting.Fixtitle;
            newWindowSetting.Width = inWindowSetting.Width == null ? newWindowSetting.Width : inWindowSetting.Width;
            newWindowSetting.Height = inWindowSetting.Height == null ? newWindowSetting.Height : inWindowSetting.Height;
            newWindowSetting.Modeless = inWindowSetting.Modeless;
            newWindowSetting.Url = ConfigureHelper.getWebUrl(inWindowSetting.Url,""); ;
            newWindowSetting.Viewmodel = string.IsNullOrEmpty(inWindowSetting.Viewmodel) ? newWindowSetting.Viewmodel : inWindowSetting.Viewmodel;
            newWindowSetting.Fullscreen = inWindowSetting.Fullscreen;
            newWindowSetting.Statusbar = inWindowSetting.Statusbar;
            newWindowSetting.Resizable = inWindowSetting.Resizable;
            newWindowSetting.Maximize = inWindowSetting.Maximize;
            newWindowSetting.Minimize = inWindowSetting.Minimize;
            newWindowSetting.EscKeyEnable = inWindowSetting.EscKeyEnable;
            return newWindowSetting;
        }

        #region ��Ϣ��ʾ��
        public static void ShowTip(string pMsg)
        {
            MessageBox.Show(pMsg, "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowWarning(string pMsg)
        {
            MessageBox.Show(pMsg, "������Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowError(string pMsg)
        {
            MessageBox.Show(pMsg, "������Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult ShowYesNoAndTips(string pMsg)
        {
            return MessageBox.Show(pMsg,"��ʾ��Ϣ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        }

        public static DialogResult ShowYesNoAndWarning(string pMsg)
        {
            return MessageBox.Show(pMsg, "������Ϣ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        public static DialogResult ShowYesNoAndWarning(Form pForm,string pMsg)
        {
            return MessageBox.Show(pForm, pMsg, "������Ϣ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        public static DialogResult ShowYesNoAndError(string pMsg)
        {
            return MessageBox.Show(pMsg, "������Ϣ", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
        }

        public static DialogResult ShowYesNoCancelAndTips(string pMsg)
        {
            return MessageBox.Show(pMsg, "��ʾ��Ϣ", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
        }

        public static DialogResult ConfirmYesNo(string pMsg)
        {
            return MessageBox.Show(pMsg, "ȷ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static DialogResult ConfirmYesNoCancel(string pMsg)
        {
            return MessageBox.Show(pMsg, "ȷ��", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }
        #endregion


        public static bool isLocalHtml(string pUrl)
        {
            //�ж��Ƿ���HTTP����https��ͷ
            if (pUrl.StartsWith("http://") || pUrl.StartsWith("https://"))
            {
                return false;
            }
            return true;
        }

        public static string getFile(string pFileOrPath)
        {
            string sFileOrPath = "";
            if (pFileOrPath.StartsWith("http://") || pFileOrPath.StartsWith("https://")||Path.IsPathRooted(Path.GetDirectoryName(pFileOrPath)))
            {
                sFileOrPath = pFileOrPath;
            }
            else
            {
                sFileOrPath = Global.gAppPath + pFileOrPath.Replace("/", "\\");
            }
            return sFileOrPath;
        }

        public static float getLogPiex()
        {
            float returnValue = 96;
            try
            {
                RegistryKey key = Registry.CurrentUser;
                RegistryKey pixeKey = key.OpenSubKey("Control Panel\\Desktop");
                if (pixeKey != null)
                {
                    object pixels = pixeKey.GetValue("LogPixels");
                    if (pixels != null)
                    {
                        returnValue = float.Parse(pixels.ToString());
                    }
                    pixeKey.Close();
                }
                else
                {
                    pixeKey = key.OpenSubKey("Control Panel\\Desktop\\WindowMetrics");
                    if (pixeKey != null)
                    {
                        object pixels = pixeKey.GetValue("AppliedDPI");
                        if (pixels != null)
                        {
                            returnValue = float.Parse(pixels.ToString());
                        }
                        pixeKey.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                returnValue = 96;
            }
            return returnValue;
        }
    }
}
