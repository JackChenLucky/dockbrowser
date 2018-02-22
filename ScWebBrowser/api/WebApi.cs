using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using ScWebBrowser.api;
using Microsoft.Win32;

namespace ScWebBrowser
{
    /// <summary>
    /// ������ṩ��JS���õ�API
    /// </summary>
    public class WebApi
    {
        /// <summary>
        /// ͨ��ָ���ķ�ʽ���ⲿ����
        /// </summary>
        /// <param name="pUrl">�ⲿ���ӵ�ַ</param>
        /// <param name="pType">1����ǰҳ��� 2���´����</param>
        public int OpenExternalUrl(string setting)
        {
            //ExternalUrlInfo exinfo = JsonConvert.DeserializeObject<ExternalUrlInfo>(setting);
            //if(exinfo.Opentype=="2"){
            //    frmWebBrowser fwb = new frmWebBrowser("","");
            //    Global.formList.Add(fwb);
            //    return Global.formList.Count;
            //}else{
            //    string BrowserPath = GetDefaultWebBrowserFilePath();
            //    System.Diagnostics.Process.Start(BrowserPath, exinfo.Url);
            //}
            return -1;
        }


        /*����
��������ʹ��ע�����ӹ��߷��� \SOFTWARE\Clients\StartMenuInternet\ ��¼��Ĭ�����������
        [HKEY_LOCAL_MACHINE\SOFTWARE\Clients\StartMenuInternet\Ĭ�����������\shell\open\command] ��¼������·��
        */
 ��������/// <summary>
        /// ��ȡĬ���������·��
        /// </summary>
        /// <returns></returns>
        public String GetDefaultWebBrowserFilePath()
        {
            string _BrowserKey1 = @"Software\Clients\StartmenuInternet\";
            string _BrowserKey2 = @"\shell\open\command";

            RegistryKey _RegistryKey = Registry.CurrentUser.OpenSubKey(_BrowserKey1, false);
            if (_RegistryKey == null)
                _RegistryKey = Registry.LocalMachine.OpenSubKey(_BrowserKey1, false);
            String _Result = _RegistryKey.GetValue("").ToString();
            _RegistryKey.Close();

            _RegistryKey = Registry.LocalMachine.OpenSubKey(_BrowserKey1 + _Result + _BrowserKey2);
            _Result = _RegistryKey.GetValue("").ToString();
            _RegistryKey.Close();

            if (_Result.Contains("\""))
            {
                _Result = _Result.TrimStart('"');
                _Result = _Result.Substring(0, _Result.IndexOf('"'));
            }
            return _Result;
        }
    }
}
