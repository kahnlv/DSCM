/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/7 11:17:59 
* File name：Json 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
*/

using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace DSCM.Tool.Tools
{
    public class Json
    {
        public static T Read<T>(string js)
        {
            StringReader sr = new StringReader(js);
            JsonSerializer serializer = new JsonSerializer();
            T t = serializer.Deserialize<T>(new JsonTextReader(sr));
            return t;
        }
    }
}
