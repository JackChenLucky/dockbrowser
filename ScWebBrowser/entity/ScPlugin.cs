using System;
using System.Collections.Generic;
using System.Text;

namespace ScWebBrowser.entity
{
    public class ScPlugin
    {
        /// <summary>
        /// ���ΨһID
        /// </summary>
        private string id;
        /// <summary>
        /// �������
        /// </summary>
        private string pluginName;

        /// <summary>
        /// �������
        /// </summary>
        private string descrption;

        /// <summary>
        /// �汾
        /// </summary>
        private string version;


        /// <summary>
        /// ��ʼ����ǰ���
        /// </summary>
        /// <returns></returns>
        public string InitPlugIn(string pInData)
        {
            return "";
        }

        /// <summary>
        /// ���ò��
        /// </summary>
        /// <param name="pInData"></param>
        /// <returns></returns>
        public string InvokePlugin(string pInData)
        {
            return "";
        }

        /// <summary>
        /// �ͷŲ����Դ
        /// </summary>
        /// <param name="pInData"></param>
        /// <returns></returns>
        public string ReleasePlugin(string pInData)
        {
            return "";
        }

    }
}
