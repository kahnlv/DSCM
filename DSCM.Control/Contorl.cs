using System;
using System.Collections.Generic;
using System.Text;
using DSCM.Tool.File;
using System.Collections;
using System.IO;
using System.Web.UI;

namespace DSCM.Control
{
    public class Contorl
    {
        FileTool ft = new FileTool();
        public Contorl()
        {

        }

        public void ReadHtml(string path)
        {
            string html = ft.Read(path);

           string _h = JXArr( JXHtml(html));
        }

        ArrayList JXHtml(string html)
        {
            try
            {
                ArrayList al = new ArrayList();
                html = html.Replace("\r\n", "");
                string _html = "";
                while (html.IndexOf("<%") > -1)
                {
                    _html = html.Substring(0, html.IndexOf("<%"));
                    al.Add(_html);
                    html = html.Substring(html.IndexOf("<%"));
                    _html = html.Substring(0, html.IndexOf("%>") + 2);
                    al.Add(_html);
                    html = html.Substring(html.IndexOf("%>") + 2);
                }
                al.Add(html);
                return al;
            }
            catch { }
            return null;
        }

        string JXArr(ArrayList al)
        {
            string _s = "string sss=\"\";string html= \"\";";
            StringBuilder html = new StringBuilder();
            foreach (string str in al)
            {
                if (str.IndexOf("<%") > -1)
                {
                    if (str.IndexOf("<%=") > -1)
                    {
                        html.Append("\r\nhtml+=" + str.Replace("<%=", "").Replace("%>", "") + ";");
                    }
                    else
                    {
                        html.Append(str.Replace("<%", "").Replace("%>", ""));
                    }
                }
                else
                {
                    html.Append("\r\nhtml+=\"" + str + "\";");
                }
            }
            return _s + html.ToString();
        }



        /// <summary>        
        /// Aspx生成静态页       
        /// /// </summary>        
        /// <param name="strUrl">AspUrl</param>        
        /// <param name="strSavePath">HtmlPath</param>        
        /// <returns></returns>        
        public string ExecAspxToHtml(string strUrl)        
        {           
            try            
            {               
                StringWriter strHTML = new StringWriter();               
                Page myPage = new Page();
                myPage.Server.Execute(strUrl, strHTML, false);
                return strHTML.ToString();           
            }         
            catch(Exception ex)
            {           
                return ex.ToString(); 
            }      
        }
    }
}
