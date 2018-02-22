using System;
using System.Collections.Generic;
using System.Text;

namespace ScWebBrowser.entity
{
    public class TrayBalloonTipOption
    {
        private int timeout;
        /// <summary>
        /// 气泡关闭时间
        /// </summary>
        public int Timeout
        {
            get { return timeout; }
            set { timeout = value; }
        }

        private int balloontipicon;
        ///<summary>
        ///气球Tip提示图标
        ///无图标：None = 0,
        ///信息图标：Info = 1,
        ///警告图标：Warning = 2,
        ///错误图标：Error = 3,
        ///</summary>
        public int Balloontipicon
        {
            get { return balloontipicon; }
            set { balloontipicon = value; }
        }

        private string balloontiptext;
        /// <summary>
        /// 气球Tip的文本
        /// </summary>
        public string Balloontiptext
        {
            get { return balloontiptext; }
            set { balloontiptext = value; }
        }

        private string balloontiptitle;
        /// <summary>
        /// 气球Tip提示的标题
        /// </summary>
        public string Balloontiptitle
        {
            get { return balloontiptitle; }
            set { balloontiptitle = value; }
        }
    }
}
