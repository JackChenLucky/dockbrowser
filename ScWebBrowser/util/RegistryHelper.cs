using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace ScWebBrowser.util
{
    class RegistryHelper
    {
        /// <summary>
        /// ��ȡָ�����Ƶ�ע����ֵ
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetRegistryData(RegistryKey root, string subkey, string name)
        {
            string registData = "";
            RegistryKey myKey = root.OpenSubKey(subkey, true);
            if (myKey != null)
            {
                registData = myKey.GetValue(name).ToString();
            }

            return registData;
        }

        /// <summary>
        /// ��ע�����д����
        /// </summary>
        /// <param name="name"></param>
        /// <param name="tovalue"></param> 
        public void SetRegistryData(RegistryKey root, string subkey, string name, string value)
        {
            RegistryKey aimdir = root.CreateSubKey(subkey);
            aimdir.SetValue(name, value, RegistryValueKind.DWord);
        }

        /// <summary>
        /// ɾ��ע�����ָ����ע�����
        /// </summary>
        /// <param name="name"></param>
        public void DeleteRegist(RegistryKey root, string subkey, string name)
        {
            string[] subkeyNames;
            RegistryKey myKey = root.OpenSubKey(subkey, true);
            subkeyNames = myKey.GetSubKeyNames();
            foreach (string aimKey in subkeyNames)
            {
                if (aimKey == name)
                    myKey.DeleteSubKeyTree(name);
            }
        }

        /// <summary>
        /// �ж�ָ��ע������Ƿ����
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsRegistryExist(RegistryKey root, string subkey, string name)
        {
            bool _exit = false;
            string[] subkeyNames;
            RegistryKey myKey = root.OpenSubKey(subkey, true);
            subkeyNames = myKey.GetSubKeyNames();
            foreach (string keyName in subkeyNames)
            {
                if (keyName == name)
                {
                    _exit = true;
                    return _exit;
                }
            }

            return _exit;
        }
    }
}