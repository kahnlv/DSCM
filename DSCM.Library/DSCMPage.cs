using dscm.Library.ClassOp;
using dscm.Library.MD5JM;
using dscm.Library.self;
using dscm.Tools.Sql;
using DSCM.Control;
using DSCM.Model;
using DSCM.Tool.File;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;

namespace DSCM.Library
{
    public class Page : System.Web.UI.Page
    {

        //public Contorl contorl = new Contorl();
        public Contorl contorl
        {
            get { return new Contorl(); }
        }
        ConfigSql cs = new ConfigSql();
        public DSCMSave dscmSave = new DSCMSave();
        public WebModel model = new WebModel();
        public OpAnalytical Op = new OpAnalytical();//动态生成库
        public string PageTitle = "";
        public string Act = "";
        public Page() { }
        public md5 Md5 = new md5();
        public FileTool Filetool = new FileTool();
        public string Url = "";

        /// <summary>
        /// 总条数
        /// </summary>
        public int allcount = 0;
        /// <summary>
        /// 当前页
        /// </summary>
        public int count = 0;
        /// <summary>
        /// 分页字符串
        /// </summary>
        public string pagestr = "";
        ///分页显示
        ///

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                Url = Request.Url.ToString();
                ///获取网站标题
                PageTitle = ReadConfig("DSCMTITLE");
                string pageClass = ReadConfig("PAGECLASS");
                string act = SafeRequest("ds");
                string op = SafeRequest("cm");
                //验证授权
                //int sq = DSCMSeting.ReadSet();
                //if (1 == 1)
                //{
                string pagename = System.IO.Path.GetFileName(Request.Path).ToString();
                string pagepath = System.IO.Path.GetDirectoryName(Request.Path);

                if (pagename.Equals("index.aspx") && !act.Equals(""))
                {
                    string pageclass = ReadConfig("PAGECLASS");
                    if (op.Equals("")) op = "index";
                    Random r = new Random();
                    string pageUrl = pagepath + "\\templates\\default\\" + act + "_" + op + ".aspx";//templates/default
                    string _path = GetRootPath() + pageUrl;
                    object obj = Op.OpAssembly("bin/" + pageclass + ".dll", pageclass + "." + act, op + "_DSCM", null);
                    dscmSave.SetObject(act, obj);
                    if (File.Exists(_path))
                    {
                        string str = contorl.ExecAspxToHtml(pageUrl + "?t=" + r.Next());
                        Response.Write(str);
                    }
                    dscmSave.Clear("");
                }
                else
                {
                    EmpInfo(this, e);
                }
                //}
                //else
                //{
                //    PageWrite("请购买正版授权，联系QQ：421765057", "STR");
                //    //Response.Redirect(DSCMSeting.Ds_Url + "?rr=" + sq);
                //}
            }
            catch (Exception ex) { Response.Write("程序运行错误。错误：" + ex.ToString()); }
        }

        public void Cookies(string key, string value)
        {
            dscmSave.Cookies(key, value);
        }
        public string Cookies(string key)
        {
            return dscmSave.Cookies(key);
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        public void Save(string key, object obj)
        {
            dscmSave.Save(key, obj);
        }
        public object Save(string key)
        {
            return dscmSave.Save(key); ;
        }

        private void PostGet()
        {
            Dictionary<string, string> form = new Dictionary<string, string>();
            Dictionary<string, string> QueryString = new Dictionary<string, string>();
            Dictionary<string, string> _f = dscmSave.GetObject("Form") as Dictionary<string, string>;
            Dictionary<string, string> _q = dscmSave.GetObject("QueryString") as Dictionary<string, string>;

            if (_f != null)
            {
                foreach (KeyValuePair<string, string> Dicf in _f)
                {
                    if (!form.ContainsKey(Dicf.Key))
                    {
                        form.Add(Dicf.Key, Dicf.Value);
                    }
                    else
                    {
                        form[Dicf.Key] = Dicf.Value;
                    }
                }
            }
            if (_q != null)
            {
                foreach (KeyValuePair<string, string> Dicf in _q)
                {
                    if (!QueryString.ContainsKey(Dicf.Key))
                    {
                        QueryString.Add(Dicf.Key, Dicf.Value);
                    }
                    else
                    {
                        QueryString[Dicf.Key] = Dicf.Value;
                    }
                }
            }
            for (int i = 0; i < Request.Form.AllKeys.Length; i++)
            {
                if (!form.ContainsKey(Request.Form.AllKeys[i]))
                {
                    form.Add(Request.Form.AllKeys[i], Request.Form[Request.Form.AllKeys[i]]);
                }
                else
                {
                    form[Request.Form.AllKeys[i]] = Request.Form[Request.Form.AllKeys[i]];
                }
            }
            foreach (string qstr in Request.QueryString.AllKeys)
            {
                if (!QueryString.ContainsKey(qstr))
                {
                    QueryString.Add(qstr, Request.QueryString[qstr]);
                }
                else
                {
                    QueryString[qstr] = Request.QueryString[qstr];
                }
            }
            dscmSave.SetObject("Form", form);
            dscmSave.SetObject("QueryString", QueryString);
        }

        private void ClearPostGet()
        {
            dscmSave.RemoveObj("Form");
            dscmSave.RemoveObj("QueryString");
        }

        public string ReadConfig(string key)
        {
            try
            {
                return System.Web.Configuration.WebConfigurationManager.AppSettings[key];
            }
            catch { return ""; }
        }

        public virtual void EmpInfo(object sender, EventArgs e) { }

        /// <summary>
        /// 框架存取方法
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string DSCMResquest(string str)
        {
            string cs = "";
            try
            {
                Dictionary<string, string> form = dscmSave.GetObject("Form") as Dictionary<string, string>;
                if (form.ContainsKey(str))
                {
                    cs = form[str];
                }
            }
            catch (Exception ex) { }
            try
            {
                Dictionary<string, string> form = dscmSave.GetObject("QueryString") as Dictionary<string, string>;
                if (form.ContainsKey(str))
                {
                    cs = form[str];
                }
            }
            catch (Exception ex1) { }
            return cs;
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
        /// 跳转页面
        /// </summary>
        /// <param name="url"></param>
        public void Jump(string url)
        {
            Response.Write("<script>location='" + url + "';</script>");
        }
        /// <summary>
        /// 获取传参
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string SafeRequest(string str)
        {
            try
            {
                foreach (string s in Request.Form.AllKeys)
                {
                    if (s.Equals(str))
                    {
                        return Request.Form[s].ToString();
                    }
                }
            }
            catch (Exception ex) { }
            try
            {
                foreach (string s in Request.QueryString.AllKeys)
                {
                    if (s.Equals(str))
                    {
                        return Request.QueryString[s].ToString();
                    }
                }
            }
            catch (Exception ex1) { }
            return "";
        }

        /// <summary>
        /// 中文转unicode
        /// </summary>
        /// <returns></returns>
        public string chtounicode(string str)
        {
            string outStr = "";
            if (!string.IsNullOrEmpty(str))
            {
                for (int i = 0; i < str.Length; i++)
                {
                    outStr += "/u" + ((int)str[i]).ToString("x");
                }
            }
            return outStr;
        }
        /// <summary>
        /// unicode转中文
        /// </summary>
        /// <returns></returns>
        public string unicodetoch(string str)
        {
            string outStr = "";
            if (!string.IsNullOrEmpty(str))
            {
                string[] strlist = str.Replace("/", "").Split('u');
                try
                {
                    for (int i = 1; i < strlist.Length; i++)
                    {
                        //将unicode字符转为10进制整数，然后转为char中文字符  
                        outStr += (char)int.Parse(strlist[i], System.Globalization.NumberStyles.HexNumber);
                    }
                }
                catch (FormatException ex)
                {
                    outStr = ex.Message;
                }
            }
            return outStr;
        }

        /// <summary>
        /// 获取url全路径
        /// </summary>
        /// <returns></returns>
        public string AllUrl()
        {
            return Request.Url.ToString();
        }

        /// <summary>
        /// 获取域名
        /// </summary>
        /// <returns></returns>
        public string UrlHost()
        {
            return HttpContext.Current.Request.Url.Host;
        }

        /// <summary>
        /// 取得网站根目录的物理路径
        /// </summary>
        /// <returns></returns>
        public string GetRootPath()
        {
            string AppPath = "";
            HttpContext HttpCurrent = HttpContext.Current;
            if (HttpCurrent != null)
            {
                AppPath = HttpCurrent.Server.MapPath("~");
            }
            else
            {
                AppPath = AppDomain.CurrentDomain.BaseDirectory;
                if (Regex.Match(AppPath, @"\\$", RegexOptions.Compiled).Success)
                    AppPath = AppPath.Substring(0, AppPath.Length - 1);
            }
            return AppPath;
        }

        public T[] SqlAll<T>(string table, string[] colm, string where)
        {
            return SQL.ReadAll<T>(table, colm, where); ;
        }
        public T[] SqlAll<T>(string table, string where, int count)
        {
            return SQL.ReadAll<T>(table, where, count); ;
        }
        public T Sql<T>(string table, string[] colm, string where)
        {
            return SQL.Read<T>(table, colm, where); ;
        }
        public T Sql<T>(string table, string where)
        {
            return SQL.Read<T>(table, where); ;
        }

        public string Guid()
        {
            return System.Guid.NewGuid().ToString();
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
    }
}
