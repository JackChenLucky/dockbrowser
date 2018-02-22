using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Microsoft.Win32;

namespace ScWebBrowser.util
{
    public class ViewModelHelper
    {
        /// <summary>
        /// �����������Ⱦģʽ
        /// </summary>
        /// <param name="sViewModel"></param>
        public static void SetViewModel(ScWebBrowser.Constants.Browser_��Ⱦģʽ pViewModel)
        {
            string exeName = Process.GetCurrentProcess().ProcessName + ".exe";
            RegistryKey hklm = Registry.LocalMachine;
            RegistryHelper rh = new RegistryHelper();
            try
            {
                string subkey = @"SOFTWARE\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION";
                if (!rh.IsRegistryExist(Registry.LocalMachine, subkey, exeName))
                {
                    RegistryKey rk = hklm.OpenSubKey(subkey, true);
                    rk.SetValue(exeName, (int)pViewModel + "", RegistryValueKind.DWord);
                }
                else
                {
                    rh.SetRegistryData(Registry.LocalMachine, subkey, exeName, (int)pViewModel + "");
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
