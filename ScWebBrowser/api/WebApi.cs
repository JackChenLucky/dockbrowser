using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using ScWebBrowser.api;
using Microsoft.Win32;

namespace ScWebBrowser
{
    /// <summary>
    /// 浏览器提供给JS调用的API
    /// </summary>
    public class WebApi
    {
        /// <summary>
        /// 通过指定的方式打开外部链接
        /// </summary>
        /// <param name="pUrl">外部链接地址</param>
        /// <param name="pType">1、当前页面打开 2、新窗体打开</param>
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


        /*　　
　　　　使用注册表监视工具发现 \SOFTWARE\Clients\StartMenuInternet\ 记录了默认浏览器名字
        [HKEY_LOCAL_MACHINE\SOFTWARE\Clients\StartMenuInternet\默认浏览器名字\shell\open\command] 记录了物理路径
        */
 　　　　/// <summary>
        /// 获取默认浏览器的路径
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
