using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace ScWebBrowser
{
    public class IniFileHelper
    {
        public string inipath;

        //����API����

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        /// <summary> 
        /// ���췽�� 
        /// </summary> 
        /// <param name="INIPath">�ļ�·��</param> 
        public IniFileHelper(string INIPath)
        {
            inipath = INIPath;
        }

        public IniFileHelper() { }

        /// <summary> 
        /// д��INI�ļ� 
        /// </summary> 
        /// <param name="Section">��Ŀ����(�� [TypeName] )</param> 
        /// <param name="Key">��</param> 
        /// <param name="Value">ֵ</param> 
        public void IniWriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, this.inipath);
        }
        /// <summary> 
        /// ����INI�ļ� 
        /// </summary> 
        /// <param name="Section">��Ŀ����(�� [TypeName] )</param> 
        /// <param name="Key">��</param> 
        public string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(500);
            int i = GetPrivateProfileString(Section, Key, "", temp, 500, this.inipath);
            return temp.ToString();
        }

        public string IniReadValue(string Section, string Key,string pDeflt)
        {
            StringBuilder temp = new StringBuilder(500);
            int i = GetPrivateProfileString(Section, Key, "", temp, 500, this.inipath);
            if (string.IsNullOrEmpty(temp.ToString()))
            {
                return pDeflt;
            }
            else
            {

                return  temp.ToString();
            }
        }
        /// <summary> 
        /// ��֤�ļ��Ƿ���� 
        /// </summary> 
        /// <returns>����ֵ</returns> 
        public bool ExistINIFile()
        {
            return File.Exists(inipath);
        }
    }
}