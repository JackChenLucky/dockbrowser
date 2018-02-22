using System;
using System.Collections.Generic;
using System.Text;

namespace ScWebBrowser.entity
{
    public class TrayBalloonTipOption
    {
        private int timeout;
        /// <summary>
        /// ���ݹر�ʱ��
        /// </summary>
        public int Timeout
        {
            get { return timeout; }
            set { timeout = value; }
        }

        private int balloontipicon;
        ///<summary>
        ///����Tip��ʾͼ��
        ///��ͼ�꣺None = 0,
        ///��Ϣͼ�꣺Info = 1,
        ///����ͼ�꣺Warning = 2,
        ///����ͼ�꣺Error = 3,
        ///</summary>
        public int Balloontipicon
        {
            get { return balloontipicon; }
            set { balloontipicon = value; }
        }

        private string balloontiptext;
        /// <summary>
        /// ����Tip���ı�
        /// </summary>
        public string Balloontiptext
        {
            get { return balloontiptext; }
            set { balloontiptext = value; }
        }

        private string balloontiptitle;
        /// <summary>
        /// ����Tip��ʾ�ı���
        /// </summary>
        public string Balloontiptitle
        {
            get { return balloontiptitle; }
            set { balloontiptitle = value; }
        }
    }
}
