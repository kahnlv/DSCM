/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/3/21 14:01:36 
* File name：Regedit 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace DSCM.Config
{
    public class Regedit
    {
        ArrayList dscmRegedit = new ArrayList();

        public ArrayList DscmRegedit
        {
            get { return dscmRegedit; }
            set { dscmRegedit = value; }
        }
    }
}
