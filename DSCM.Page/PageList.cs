using System;
using System.Collections.Generic;
using System.Web;
using dscm.Library.self;
using System.Collections.Specialized;
namespace DSCM.Page
{
   
    /// <summary>
    ///PageList 的摘要说明
    /// </summary>
    public class PageList : DSCMSave
    {
        public int Count = 0;
        int allPage = 0;
        int width = 0;
        string url = "";
        string pageCont = "1";
        public PageList()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url">当前页面地址</param>
        /// <param name="page">当前页数</param>
        /// <param name="allPage">总页数</param>
        /// <param name="i">分页样式</param>
        public string WabPage(int allPage,int width,int i)
        {
            this.allPage = allPage;
            this.width = width;
            if (allPage == 0) return "";
            url = HttpContext.Current.Request.Url.AbsolutePath;
            Dictionary<string, string> nvc = GetObject("QueryString") as Dictionary<string, string>;
            string pram = "";
            foreach (string str in nvc.Keys)
            {
                if (!str.Equals("page"))
                {
                    if (pram.Equals(""))
                    {
                        pram += "?" + str + "=" + nvc[str];
                    }
                    else
                    {
                        pram += "&" + str + "=" + nvc[str];
                    }
                }
                else
                {
                    pageCont = nvc[str];
                }
            }
            if (pram.Equals(""))
            {
                url = url + "?page=";
            }
            else
            {
                url = url + pram + "&page=";
            }


            switch (i)
            {
                case 1:
                   return p1();
                case 2:
                   return p2();
                default: return "";
            }
        }

        string p2()
        {
            int _page = 0;
            int _i = 1;
            int.TryParse(pageCont, out _page);
            Count = _page;
            string html = "";
            if (allPage == 1 || pageCont.Equals("1"))
            {
                html += "<a href=\"javascript:void(0)\">首页</a>  ";
            }
            else
            {
                html += "<a href=\"" + url + "1\">首页</a> ";
            }
            if (_page < 1 || pageCont.Equals("1"))
            {
                html += "<a href=\"javascript:void(0)\">&lt;</a> ";
            }
            else
            {
                html += "<a href=\"" + url + ((_page - 1) < 0 ? "1" : (_page - 1) + "") + "\">&lt;</a> ";
            }

            if (_page > 3)
            {
                _i = _page - 2;
            }
            if (_page > allPage - 5)
            {
                _i = allPage - 4;
            }

            if (_i >= 2)
            {
                html += "<em>...</em>";
            }
            for (int i = _i; i < (_i + 5); i++)
            {
                if (i > 0)
                {
                    if (i == _page)
                    {
                        html += "<a href=\"#\" class=\"actived\">" + i + "</a>";
                    }
                    else
                    {
                        html += "<a href=\"" + url + i + "\">" + i + "</a>";
                    }
                    if (i == allPage) break;
                }
            }
            if (_page == allPage)
            {
                html += "<a href=\"javascript:void(0)\">&gt;</a>";
            }
            else
            {
                if (_page < allPage - 3)
                {
                    html += "<em>...</em>";
                }
                html += "<a href=\"" + url + (_page + 1) + "\">&gt;</a>";
            }

            if (allPage == 1 || _page == allPage)
            {
                html += "<a href=\"javascript:void(0)\">尾页</a>";
            }
            else
            {
                html += "<a href=\"" + url + allPage + "\">尾页</a>";
            }

            return html;
        }

        string p1()
        {
            int _page = 0;
            int _i = 1;
            int.TryParse(pageCont, out _page);
            Count = _page;
            string html = "<style>"
            + ".dx-fenye ul li{ float:left; margin:0 5px;} "
            + ".dx-fenye ul li a{ padding:4px 12px; color:#3c3c3c;background: -webkit-gradient(linear,left top,left bottom,from(#fff),to(#f5f5f5));background: -moz-linear-gradient(top,#fff,#f5f5f5);border: 1px solid #ccc;border-radius: 4px;-webkit-border-radius: 4px;-moz-border-radius: 4px; text-decoration:none;} "
            + ".dx-fenye ul li span{ padding:4px 10px;} "
            + ".dx-fenye ul li .current{ background: -webkit-gradient(linear,left top,left bottom,from(#eee),to(#eee));background: -moz-linear-gradient(top,#eee,#eee);border: 1px solid #ccc;} "
            + "</style>"
            + "<div class=\"dx-fenye\" style=\"width:" + width + "px; margin:0 auto;\"> "
            + "<ul> ";
            if (allPage == 1 || pageCont.Equals("1"))
            {
                html += "<li><span class=\"dscm_fffffff\">首页</span></li> ";
            }
            else
            {
                html += "<li><a href=\"" + url + "1\">首页</a></li> ";
            }
            if (_page < 1 || pageCont.Equals("1"))
            {
                html += "<li><span>上一页</span></li> ";
            }
            else
            {
                html += "<li><a href=\"" + url + ((_page - 1) < 0 ? "1" : (_page - 1) + "") + "\">上一页</a></li> ";
            }

            if (_page > 3)
            {
                _i = _page - 2;
            }
            if (_page > allPage - 5)
            {
                _i = allPage - 4;
            }

            if (_i >= 2)
            {
                html += "<li><span >...</span></li> ";
            }
            for (int i = _i; i < (_i + 5); i++)
            {
                if (i > 0)
                {
                    if (i == _page)
                    {
                        html += "<li><span class=\"current\">" + i + "</span></li> ";
                    }
                    else
                    {
                        html += "<li><a href=\"" + url + i + "\">" + i + "</a></li> ";
                    }
                    if (i == allPage) break;
                }
            }
            if (_page == allPage)
            {
                html += "<li><span>下一页</span></li> ";
            }
            else
            {
                if (_page < allPage - 3)
                {
                    html += "<li><span >...</span></li> ";
                }
                html += "<li><a href=\"" + url + (_page + 1) + "\">下一页</a></li> ";
            }

            if (allPage == 1 || _page == allPage)
            {
                html += "<li><span >尾页</span></li> "
                + "</ul> "
                + "</div> ";
            }
            else
            {
                html += "<li><a href=\"" + url + allPage + "\">尾页</a></li> "
                + "</ul> "
                + "</div> ";
            }

            return html;
        }
    }
}