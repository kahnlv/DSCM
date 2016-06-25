/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/8 15:39:09 
* File name：DSCM 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Collections.Specialized;
using dscm.Library.self;
using System.Web.SessionState;

namespace DSCM.Web
{
    public class URLWrite : IHttpModule, IRequiresSessionState
	{
        public void Dispose()
        {

        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(BeginRequest);
            context.EndRequest += new EventHandler(EndRequest);
            context.AcquireRequestState += new EventHandler(context_AcquireRequestState);
        }

        void context_AcquireRequestState(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            PostGet(application);
        }


        void BeginRequest(object sender, EventArgs e)
        {
            HttpApplication http = sender as HttpApplication;
            if (http.Context.Request.Url.OriginalString.IndexOf("/index.aspx") != -1)
            {
                //http.Context.Server.Transfer("default.aspx");
            }
            
        }

        void EndRequest(object sender, EventArgs e)
        {
            HttpApplication http = sender as HttpApplication;
            //http.Context.Response.Write("哈哈!结束");
        }

        private void PostGet(HttpApplication http)
        {
            DSCMSave dscmSave = new DSCMSave();
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
            for (int i = 0; i < http.Context.Request.Form.AllKeys.Length; i++)
            {
                if (!form.ContainsKey(http.Context.Request.Form.AllKeys[i]))
                {

                    form.Add(http.Context.Request.Form.AllKeys[i], HtmlEncode(http.Context.Request.Form[http.Context.Request.Form.AllKeys[i]]));
                }
                else
                {
                    form[http.Context.Request.Form.AllKeys[i]] = HtmlEncode(http.Context.Request.Form[http.Context.Request.Form.AllKeys[i]]);
                }
            }
            foreach (string qstr in http.Context.Request.QueryString.AllKeys)
            {
                if ((qstr + "").Length > 0)
                {
                    if (!QueryString.ContainsKey(qstr))
                    {
                        QueryString.Add(qstr, HtmlEncode(http.Context.Request.QueryString[qstr]));
                    }
                    else
                    {
                        QueryString[qstr] = HtmlEncode(http.Context.Request.QueryString[qstr]);
                    }
                }
            }
            dscmSave.SetObject("Form", form, http);
            dscmSave.SetObject("QueryString", QueryString, http);
        }

        /// <summary>
        /// html转码
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string HtmlEncode(string html)
        {
            return HttpUtility.HtmlEncode(html);//System.Net.WebUtility.HtmlEncode(html);            
        }

        /// <summary>
        /// html解码
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string HtmlDecode(string html)
        {
            return HttpUtility.HtmlDecode(html);//System.Net.WebUtility.HtmlDecode(html);  
        }

	}
}
