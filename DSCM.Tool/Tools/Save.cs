using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using DSCM.Config;
using System.Web;
using System.Web.SessionState;
using System.Collections.Specialized;
using System.Management;
using System.Runtime.InteropServices;
using dscm.Library.MD5JM;
using System.IO;
using System.Web.UI;

namespace dscm.Library.self
{
    public class DSCMSave : Page
    {
        [DllImport("Iphlpapi.dll")]
        static extern int SendARP(Int32 DestIP, Int32 SrcIP, ref Int64 MacAddr, ref Int32 PhyAddrLen);
        [DllImport("Ws2_32.dll")]
        static extern Int32 inet_addr(string ipaddr);
        Random r = new Random();
        static Dictionary<string, Dictionary<string, string>> DicStr = new Dictionary<string, Dictionary<string, string>>();
        static Dictionary<string, Dictionary<string, ArrayList>> DicArr = new Dictionary<string, Dictionary<string, ArrayList>>();
        static Dictionary<string, Dictionary<string, Object>> DicObject = new Dictionary<string, Dictionary<string, Object>>();
        HttpCookie cookie = new HttpCookie(PageConfig._COOKIE);
        public string upload(string path, string name)
        {
            try
            {
                HttpPostedFile postedfile = Request.Files[name];
                string date = DateTime.Now.ToShortDateString();
                string imgSrc = "";
                System.Text.StringBuilder strmsg = new System.Text.StringBuilder("");
                if (postedfile.ContentLength / 5120 > 5120)//单个文件不能大于1024k
                {
                    strmsg.Append(Path.GetFileName(postedfile.FileName) + "---不能大于1024k<br>");
                    return strmsg.ToString();
                }
                string fex = Path.GetExtension(postedfile.FileName);
                if (fex != ".jpg" && fex != ".JPG" && fex != ".gif" && fex != ".GIF")
                {
                    strmsg.Append(Path.GetFileName(postedfile.FileName) + "---图片格式不对，只能是jpg或gif<br>");
                    return strmsg.ToString();
                }
                try
                {
                    Random r = new Random();
                    path = path + date;
                    string filename = DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + DateTime.Now.Hour + "" + DateTime.Now.Minute + "" + DateTime.Now.Second + "" + DateTime.Now.Millisecond + "" + r.Next(0, 10000);
                    string bigImgPath = path + "\\big";
                    string samlImgPath = path + "\\saml";
                    bigImgPath = Server.MapPath(bigImgPath);
                    samlImgPath = Server.MapPath(samlImgPath);

                    if (!Directory.Exists(bigImgPath))
                    {
                        Directory.CreateDirectory(bigImgPath);
                    }
                    if (!Directory.Exists(samlImgPath))
                    {
                        Directory.CreateDirectory(samlImgPath);
                    }
                    postedfile.SaveAs(bigImgPath + "\\" + filename + fex);
                    GetThumbNail(bigImgPath + "\\" + filename + fex, samlImgPath + "\\" + filename + fex, 100, 75);
                    imgSrc = path + "/big/" + filename + fex;
                    strmsg.Append(imgSrc);
                }
                catch
                { }
                return strmsg.ToString();
            }
            catch { }
            return "";
        }
        public string upload(string path, HttpPostedFile postedfile)
        {
            try
            {
                string date = DateTime.Now.ToShortDateString();
                string imgSrc = "";
                System.Text.StringBuilder strmsg = new System.Text.StringBuilder("");
                if (postedfile.ContentLength / 5120 > 5120)//单个文件不能大于1024k
                {
                    strmsg.Append(Path.GetFileName(postedfile.FileName) + "---不能大于1024k<br>");
                    return strmsg.ToString();
                }
                string fex = Path.GetExtension(postedfile.FileName);
                if (fex != ".jpg" && fex != ".JPG" && fex != ".gif" && fex != ".GIF" && fex != ".png" && fex != ".PNG")
                {
                    strmsg.Append(Path.GetFileName(postedfile.FileName) + "---图片格式不对，只能是jpg或gif<br>");
                    return strmsg.ToString();
                }
                try
                {
                    Random r = new Random();
                    path = path + date;
                    string filename = DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + DateTime.Now.Hour + "" + DateTime.Now.Minute + "" + DateTime.Now.Second + "" + DateTime.Now.Millisecond + "" + r.Next(0, 10000);
                    string bigImgPath = path + "\\big";
                    string samlImgPath = path + "\\saml";
                    bigImgPath = Server.MapPath(bigImgPath);
                    samlImgPath = Server.MapPath(samlImgPath);

                    if (!Directory.Exists(bigImgPath))
                    {
                        Directory.CreateDirectory(bigImgPath);
                    }
                    if (!Directory.Exists(samlImgPath))
                    {
                        Directory.CreateDirectory(samlImgPath);
                    }
                    postedfile.SaveAs(bigImgPath + "\\" + filename + fex);
                    GetThumbNail(bigImgPath + "\\" + filename + fex, samlImgPath + "\\" + filename + fex, 100, 75);
                    imgSrc = path + "/big/" + filename + fex;
                    strmsg.Append(imgSrc);
                }
                catch
                { }
                return strmsg.ToString();
            }
            catch { }
            return "";
        }

        /// <summary>
        /// 得到缩略图
        /// </summary>
        /// <paramname="strFileName">文件名</param>
        /// <paramname="iWidth">宽度</param>
        /// <paramname="iheight">高度</param>
        /// <paramname="strContentType"></param>
        /// <paramname="blnGetFromFile">是否从文件创建Image对象</param>
        /// <paramname="ImgStream"></param>
        private void GetThumbNail(string strFileName, string samlFilename, int iWidth, int iheight)
        {
            try
            {
                System.Drawing.Image oImg;
                oImg = System.Drawing.Image.FromFile(strFileName);
                oImg = oImg.GetThumbnailImage(iWidth, iheight, null, IntPtr.Zero);   //GetThumbnailImage方法是返回此Image对象的缩略图
                string strFileExt = strFileName.Substring(strFileName.LastIndexOf("."));  //得到图片的后缀
                oImg.Save(samlFilename); //(MemStream, GetImageType(strContentType));
                oImg.Dispose();
            }
            catch { }
        }

        /// <summary>
        /// 得到图片的类型
        /// </summary>
        /// <paramname="strContentType"></param>
        /// <returns></returns>
        private System.Drawing.Imaging.ImageFormat GetImageType(object strContentType)
        {
            if ((strContentType.ToString().ToLower()) == "image/pjpeg")
            {
                return System.Drawing.Imaging.ImageFormat.Jpeg;
            }
            else if ((strContentType.ToString().ToLower()) == "image/gif")
            {
                return System.Drawing.Imaging.ImageFormat.Gif;
            }
            else if ((strContentType.ToString().ToLower()) == "image/bmp")
            {
                return System.Drawing.Imaging.ImageFormat.Bmp;
            }
            else if ((strContentType.ToString().ToLower()) == "image/tiff")
            {
                return System.Drawing.Imaging.ImageFormat.Tiff;
            }
            else if ((strContentType.ToString().ToLower()) == "image/x-icon")
            {
                return System.Drawing.Imaging.ImageFormat.Icon;
            }
            else if ((strContentType.ToString().ToLower()) == "image/x-png")
            {
                return System.Drawing.Imaging.ImageFormat.Png;
            }
            else if ((strContentType.ToString().ToLower()) == "image/x-emf")
            {
                return System.Drawing.Imaging.ImageFormat.Emf;
            }
            else if ((strContentType.ToString().ToLower()) == "image/x-exif")
            {
                return System.Drawing.Imaging.ImageFormat.Exif;
            }
            else if ((strContentType.ToString().ToLower()) == "image/x-wmf")
            {
                return System.Drawing.Imaging.ImageFormat.Wmf;
            }
            else
            {
                return System.Drawing.Imaging.ImageFormat.MemoryBmp;
            }
        }

        public string LastPage()
        {
            if (Request.UrlReferrer != null)
            {
                //如果能获取来路地址
                return Request.UrlReferrer.ToString();
            }
            else
            {
                //没有来路地址
                return "";
            }
        }


        /// <summary>
        /// 删除数组中的元素,不区分大小写
        /// </summary>
        /// <param name="strArr"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public string[] strRemove(string[] strArr, string str)
        {
            List<string> _Arr = new List<string>();
            for (int i = 0; i < strArr.Length; i++)
            {
                if (!strArr[i].ToLower().Equals(str.ToLower()))
                {
                    _Arr.Add(strArr[i]);
                }
            }
            string[] _strArr = new string[_Arr.Count];
            int j = 0;
            foreach (string _str in _Arr)
            {
                _strArr[j] = _str;
                j++;
            }

            return _strArr;
        }
        /// <summary>
        /// 前台输出   
        /// </summary>
        /// <param name="str"></param>
        /// <param name="type">“JS（大写）,STR(大写)”</param>
        public void PageWrite(string str, string type)
        {
            try
            {
                switch (type)
                {
                    case "JS":
                        Response.Write("<script>alert('" + str + "');</script>");
                        break;
                    case "STR":
                        Response.Write(str);
                        break;
                }
            }
            catch { }
        }

        /// <summary>
        /// 前台输出   
        /// </summary>
        /// <param name="str"></param>
        /// <param name="type">“JS（大写）,STR(大写)”</param>
        /// <param name="type">“只有JS 类型参数才会生效”</param>
        public void PageWrite(string str, string type, string url)
        {
            try
            {
                switch (type)
                {
                    case "JS":
                        Response.Write("<script>alert('" + str + "');location='" + url + "';</script>");
                        break;
                    case "STR":
                        Response.Write(str);
                        break;
                }
            }
            catch { }
        }

        /// <summary>
        /// 跳转页面
        /// </summary>
        /// <param name="url"></param>
        public void Jump(string url)
        {
            Response.Write("<script>location='" + url + "';</script>");
        }
        public void Cookies(string key, string value)
        {
            try
            {
                HttpCookie cookie = new HttpCookie(key, value);
                cookie.HttpOnly = true;
                cookie.Expires = DateTime.Now.AddDays(7);

                HttpContext.Current.Response.AppendCookie(cookie);
                HttpContext.Current.Response.SetCookie(cookie);
            }
            catch { }
        }
        public string Cookies(string key)
        {
            bool bl = false;
            foreach (string cook in HttpContext.Current.Response.Cookies.AllKeys)
            {
                if (cook.Equals(key))
                {
                    bl = true;
                    break;
                }
            }

            if (bl)
            {
                try
                {
                    return HttpContext.Current.Response.Cookies[key].Value;
                }
                catch { }
            }
            return "";
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        public void Save(string key, object obj)
        {
            if (null == obj)
            {
                Session.Timeout = 20;
                Session[key] = obj;

                HttpCookie cookie = HttpContext.Current.Request.Cookies[key];

                if (null != cookie)
                {
                    cookie.Expires = DateTime.Now.AddDays(-1);
                    HttpContext.Current.Response.Cookies.Set(cookie);
                }
            }
            else
            {
                HttpCookie cookie = new HttpCookie(key);
                cookie.Value = obj.ToString();
                cookie.Expires = DateTime.Now.AddDays(120);

                HttpContext.Current.Response.Cookies.Set(cookie);

                if (null == HttpContext.Current.Request.Cookies[key])
                {
                    HttpContext.Current.Response.Cookies.Add(cookie);
                }
                else
                {
                    HttpContext.Current.Response.Cookies.Set(cookie);
                }
            }
        }

        public object Save(string key)
        {
            if (key.ToLower().Equals("clear"))
            {
                Session.Clear();
                return "";
            }
            else
            {
                object value = "";

                HttpCookie cookie = HttpContext.Current.Request.Cookies[key];

                if (HttpContext.Current == null ||
                    HttpContext.Current.Session == null || HttpContext.Current.Session[key] == null)
                {
                    if (null == cookie)
                    {
                        return "";
                    }
                    else
                    {
                        value = cookie.Value;
                        Session[key] = value;
                    }
                }
                else
                {
                    if (null != Session[key])
                    {
                        value = Session[key];
                    }
                }

                return value;
            }
        }

        /// <summary>
        /// 需要添加System.Web的引用
        /// </summary>
        public HttpResponse Response
        {
            get { return HttpContext.Current.Response; }
        }
        /// <summary>
        /// 需要添加System.Web的引用
        /// </summary>
        public HttpRequest Request
        {
            get { return HttpContext.Current.Request; }
        }
        /// <summary>
        /// 需要添加System.Web的引用
        /// </summary>
        public HttpSessionState Session
        {
            get { return HttpContext.Current.Session; }
        }

        public string Randem
        {
            get { return r.Next().ToString(); }
        }
        #region 存储自定义对象 <S></S>

        public void SelfObject<T>(string key, T obj)
        {
            T model = Activator.CreateInstance<T>();
            Save(key, obj);
        }
        public T SelfObject<T>(string key)
        {
            T model = Activator.CreateInstance<T>();
            try
            {
                model = (T)Save(key);
            }
            catch { }
            return model;
        }

        #endregion
        #region 自定义存储字符串 <S></S>
        /// <summary>
        /// 存储字符串
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetString(string key, string value)
        {
            try
            {
                if (HttpContext.Current.Session != null)
                {
                    if (DicStr.ContainsKey(HttpContext.Current.Session.SessionID))
                    {
                        if (DicStr[HttpContext.Current.Session.SessionID].ContainsKey(key))
                        {
                            DicStr[HttpContext.Current.Session.SessionID][key] = value;
                        }
                        else
                        {
                            DicStr[HttpContext.Current.Session.SessionID].Add(key, value);
                        }
                    }
                    else
                    {
                        try
                        {
                            Dictionary<string, string> d = new Dictionary<string, string>();
                            d.Add(key, value);
                            DicStr.Add(HttpContext.Current.Session.SessionID, d);
                        }
                        catch { }
                    }
                }
            }
            catch { }
        }
        public string GetString(string key)
        {
            try
            {
                if (HttpContext.Current.Session != null)
                {
                    if (DicStr.ContainsKey(HttpContext.Current.Session.SessionID))
                    {
                        if (DicStr[HttpContext.Current.Session.SessionID].ContainsKey(key))
                        {
                            return DicStr[HttpContext.Current.Session.SessionID][key];
                        }
                    }
                }
            }
            catch { }
            return "";
        }
        #endregion
        #region 自定义存储object对象 <O></O>
        /// <summary>
        /// 存储object对象
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetObject(string key, object value)
        {
            try
            {
                string ss = HttpContext.Current.Session.SessionID;
                if (ss != null)
                {
                    if (DicObject.ContainsKey(HttpContext.Current.Session.SessionID))
                    {
                        if (DicObject[HttpContext.Current.Session.SessionID].ContainsKey(key))
                        {
                            DicObject[HttpContext.Current.Session.SessionID][key] = value;
                        }
                        else
                        {
                            DicObject[HttpContext.Current.Session.SessionID].Add(key, value);
                        }
                    }
                    else
                    {
                        Dictionary<string, object> d = new Dictionary<string, object>();
                        d.Add(key, value);
                        DicObject.Add(HttpContext.Current.Session.SessionID, d);
                    }
                }
            }
            catch { }
        }
        public void SetObject(string key, object value, HttpApplication http)
        {
            try
            {
                string ss = http.Context.Session.SessionID;
                if (ss != null)
                {
                    if (DicObject.ContainsKey(ss))
                    {
                        if (DicObject[ss].ContainsKey(key))
                        {
                            DicObject[ss][key] = value;
                        }
                        else
                        {
                            DicObject[ss].Add(key, value);
                        }
                    }
                    else
                    {
                        Dictionary<string, object> d = new Dictionary<string, object>();
                        d.Add(key, value);
                        DicObject.Add(ss, d);
                    }
                }
            }
            catch { }
        }
        public object GetObject(string key)
        {
            try
            {
                if (DicObject.ContainsKey(HttpContext.Current.Session.SessionID))
                {
                    if (DicObject[HttpContext.Current.Session.SessionID].ContainsKey(key))
                    {
                        return DicObject[HttpContext.Current.Session.SessionID][key];
                    }
                }
            }
            catch { }
            return null;
        }
        #endregion
        #region 自定义存储ArrayList <A></A>
        /// <summary>
        /// 存储object对象
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetArrayList(string key, ArrayList value)
        {
            try
            {
                if (DicArr.ContainsKey(HttpContext.Current.Session.SessionID))
                {
                    if (DicArr[HttpContext.Current.Session.SessionID].ContainsKey(key))
                    {
                        DicArr[HttpContext.Current.Session.SessionID][key] = value;
                    }
                    else
                    {
                        DicArr[HttpContext.Current.Session.SessionID].Add(key, value);
                    }
                }
                else
                {
                    Dictionary<string, ArrayList> d = new Dictionary<string, ArrayList>();
                    d.Add(key, value);
                    DicArr.Add(HttpContext.Current.Session.SessionID, d);
                }
            }
            catch { }
        }
        public object GetArrayList(string key)
        {
            try
            {
                if (DicArr.ContainsKey(HttpContext.Current.Session.SessionID))
                {
                    if (DicArr[HttpContext.Current.Session.SessionID].ContainsKey(key))
                    {
                        return DicArr[HttpContext.Current.Session.SessionID][key];
                    }
                }
            }
            catch { }
            return null;
        }
        #endregion
        #region 
        public string Form(string key)
        {
            try
            {
                Dictionary<string, string> form = new Dictionary<string, string>();
                Dictionary<string, string> QueryString = new Dictionary<string, string>();
                object formobj = GetObject("Form");
                form = formobj as Dictionary<string, string>;
                if (form != null)
                {
                    if (form.ContainsKey(key))
                    {
                        return form[key];
                    }
                }
            }
            catch { }
            return "";
        }
        public string QueryString(string key)
        {
            try
            {
                Dictionary<string, string> querystring = new Dictionary<string, string>();
                object formobj = GetObject("QueryString");
                querystring = formobj as Dictionary<string, string>;
                if (querystring != null)
                {
                    if (querystring.ContainsKey(key))
                    {
                        return querystring[key];
                    }
                }
            }
            catch { }
            return "";
        }
        public void Clear(string key)
        {
            try
            {
                if (DicStr.ContainsKey(HttpContext.Current.Session.SessionID))
                {
                    DicStr[HttpContext.Current.Session.SessionID].Clear();
                }
                if (DicObject.ContainsKey(HttpContext.Current.Session.SessionID))
                {
                    DicObject[HttpContext.Current.Session.SessionID].Clear();
                }
                if (DicArr.ContainsKey(HttpContext.Current.Session.SessionID))
                {
                    DicArr[HttpContext.Current.Session.SessionID].Clear();
                }
            }
            catch { }
        }
        public void RemoveStr(string key)
        {
            try
            {
                if (DicStr.ContainsKey(HttpContext.Current.Session.SessionID))
                {
                    DicStr[HttpContext.Current.Session.SessionID][key] = "";
                }
            }
            catch { }
        }
        public void RemoveObj(string key)
        {
            try
            {
                if (DicObject.ContainsKey(HttpContext.Current.Session.SessionID))
                {
                    DicObject[HttpContext.Current.Session.SessionID].Clear();
                }
            }
            catch { }
        }
        public void RemoveArr(string key)
        {
            try
            {
                if (DicArr.ContainsKey(HttpContext.Current.Session.SessionID))
                {
                    DicArr[HttpContext.Current.Session.SessionID].Clear();
                }
            }
            catch { }
        }
        #endregion
        #region 自定公共方法


        public string Md5(string str)
        {
            try
            {
                md5 m5 = new md5();
                return m5.EncryptDES(str);
            }
            catch { }
            return "";
        }

        public string Guid
        {
            get { return System.Guid.NewGuid().ToString(); }
        }
        /// <summary>
        /// 获取用户IP
        /// </summary>
        /// <returns></returns>
        public string GetUserIp()
        {
            string userIP = "未获取用户IP";
            try
            {
                if (System.Web.HttpContext.Current == null
            || System.Web.HttpContext.Current.Request == null
            || System.Web.HttpContext.Current.Request.ServerVariables == null)
                    return "";
                string CustomerIP = "";

                //CDN加速后取到的IP 
                CustomerIP = System.Web.HttpContext.Current.Request.Headers["Cdn-Src-Ip"];
                if (!string.IsNullOrEmpty(CustomerIP))
                {
                    return CustomerIP;
                }

                CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];


                if (!String.IsNullOrEmpty(CustomerIP))
                    return CustomerIP;

                if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
                {
                    CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    if (CustomerIP == null)
                        CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }
                else
                {
                    CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

                }

                if (string.Compare(CustomerIP, "unknown", true) == 0)
                    return System.Web.HttpContext.Current.Request.UserHostAddress;
                return CustomerIP;
            }
            catch { }

            return userIP;
        }

        /// <summary>
        /// 获取本机MAC
        /// </summary>
        /// <returns></returns>
        public string getMac()
        {
            try
            {
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc2 = mc.GetInstances();
                foreach (ManagementObject mo in moc2)
                {
                    if ((bool)mo["IPEnabled"] == true)
                    {
                        return mo["MacAddress"].ToString();
                        mo.Dispose();
                    }
                }
            }
            catch { }
            return "";
        }


        ///<summary>
        /// SendArp获取MAC地址只能用于局域网
        ///</summary>
        ///<param name="RemoteIP">目标机器的IP地址如(192.168.1.1)</param>
        ///<returns>目标机器的mac 地址</returns>
        public static string GetMacAddress(string RemoteIP)
        {
            try
            {
                StringBuilder macAddress = new StringBuilder();
                try
                {
                    Int32 remote = inet_addr(RemoteIP);
                    Int64 macInfo = new Int64();
                    Int32 length = 6;
                    SendARP(remote, 0, ref macInfo, ref length);
                    string temp = Convert.ToString(macInfo, 16).PadLeft(12, '0').ToUpper();
                    int x = 12;
                    for (int i = 0; i < 6; i++)
                    {
                        if (i == 5)
                        {
                            macAddress.Append(temp.Substring(x - 2, 2));
                        }
                        else
                        {
                            macAddress.Append(temp.Substring(x - 2, 2) + "-");
                        }
                        x -= 2;
                    }
                    return macAddress.ToString();
                }
                catch
                {
                    return macAddress.ToString();
                }
            }
            catch { }
            return "";
        }

        public void showPage(string say, string url)
        {
            try
            {
                Save("dumppage_say", say);
                Save("dumppage_url", url);
                Response.Redirect("/data/public/succe.aspx");
            }
            catch { }
        }
        #endregion
    }
}
