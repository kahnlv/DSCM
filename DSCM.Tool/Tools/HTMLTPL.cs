using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using DSCM.Tool.File;

namespace dscm.Library
{
    public class HTPL
    {
        FileTool fc = new FileTool();
        public string funSb(string path)
        {
            return fc.Read(fc.GetRootPath() + path).Replace("/r", "").Replace("/n", "");
        }

        public void jxHtml(string html)
        {
            jxFor(html);
        }

        private void jxFor(string html)
        {
            string _html = "";
            ArrayList al = new ArrayList();
            while (true)
            {
                try
                {
                    if (html.IndexOf("<for>") < 0)
                    {
                        break;
                    }
                    _html += html.Substring(0, html.IndexOf("<for>")) + "$for";
                    html = html.Substring(html.IndexOf("<for>"));
                    string _for = "";
                    _for = html.Substring(0, html.IndexOf("</for>"));
                    html = html.Substring(html.IndexOf("</for>") + 6);
                    al.Add(_for);      
                }
                catch { break; }
            }
            _html += html;
        }
    }
}
