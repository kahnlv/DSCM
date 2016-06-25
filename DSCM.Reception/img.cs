/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/22 10:57:10 
* File name：img 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
*/

using System;
using System.Collections.Generic;
using System.Text;
using Sooyie.Common;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using dscm.Library.self;

namespace DSCM.Reception
{
    public class img : DSCMSave
    {
        public void index_DSCM()
        {
            byte[] bt = new byte[0];
            RandImage ri = new RandImage();
            Image im = ri.GetImage();
            MemoryStream ms = new MemoryStream();
            im.Save(ms, ImageFormat.Jpeg);
            bt = ms.ToArray();
            ms.Close();
            ms.Dispose();
            Save("CODE", ri.YANZHENG);
            Response.BinaryWrite(bt);
        }
    }
}
