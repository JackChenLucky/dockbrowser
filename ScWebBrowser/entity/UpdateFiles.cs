using System;
using System.Collections.Generic;
using System.Text;

namespace ScWebBrowser.entity
{
    public class UpdateFiles
    {
        List<UpdateFile> filelist = new List<UpdateFile>();

        public List<UpdateFile> Filelist
        {
            get { return filelist; }
            set { filelist = value; }
        }
    }
}
