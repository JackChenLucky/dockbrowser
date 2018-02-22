using System;
using System.Collections.Generic;
using System.Text;

namespace ScWebBrowser.entity
{
    public class ScPlugin
    {
        /// <summary>
        /// 插件唯一ID
        /// </summary>
        private string id;
        /// <summary>
        /// 插件名称
        /// </summary>
        private string pluginName;

        /// <summary>
        /// 插件描述
        /// </summary>
        private string descrption;

        /// <summary>
        /// 版本
        /// </summary>
        private string version;


        /// <summary>
        /// 初始化当前插件
        /// </summary>
        /// <returns></returns>
        public string InitPlugIn(string pInData)
        {
            return "";
        }

        /// <summary>
        /// 调用插件
        /// </summary>
        /// <param name="pInData"></param>
        /// <returns></returns>
        public string InvokePlugin(string pInData)
        {
            return "";
        }

        /// <summary>
        /// 释放插件资源
        /// </summary>
        /// <param name="pInData"></param>
        /// <returns></returns>
        public string ReleasePlugin(string pInData)
        {
            return "";
        }

    }
}
