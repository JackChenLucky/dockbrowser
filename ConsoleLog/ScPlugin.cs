using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleLog
{
    public class ScPlugin
    {
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
        /// 显示插件，如果插件不支持窗体显示，不需完成此方法
        /// </summary>
        /// <returns></returns>
        public string ShowPlugin()
        {
            return "";
        }

        /// <summary>
        /// 关闭插件
        /// </summary>
        /// <returns></returns>
        public string HidePlugIn()
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
