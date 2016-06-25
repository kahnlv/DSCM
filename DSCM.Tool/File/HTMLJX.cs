using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Hosting;
using System.IO;
using System.Web;

namespace dscm.Tools.FileRW
{
    public class HTMLJX : MarshalByRefObject
    {
        /// 
        /// 创建
        /// 
        /// 需要解析的页面的根目录，在网站项目中使用时，不能和网站同一个目录，但可以是网站的子目录
        /// 
        public static HTMLJX Create(string appPath)
        {
            return (HTMLJX)ApplicationHost.CreateApplicationHost(typeof(HTMLJX), "/", appPath);
        }

        public string GetPageContent(string page, string query)
        {
            StringBuilder sb = new StringBuilder();
            using (System.IO.StringWriter sw = new StringWriter(sb))
            {
                SimpleWorkerRequest swr = new SimpleWorkerRequest(page, query, sw);
                //对HttpRuntime这个类的理解可以去Google"asp.net的Http管道"
                HttpRuntime.ProcessRequest(swr);
            }
            return sb.ToString();
        }
    }
}
