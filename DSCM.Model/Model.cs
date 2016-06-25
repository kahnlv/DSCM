using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web.UI;
using System.Globalization;
using System.Reflection;

namespace DSCM.Model
{
    public class WebModel : Page
    {
        /// <summary>
        /// 加载自定义控件无参数方法
        /// </summary>
        /// <param name="path">控件地址</param>
        /// <returns></returns>
        public string Contorl(string path)
        {
            try
            {
                Control c = Page.LoadControl(path);
                string str = ReturnControl(c);
                return str;
            }
            catch (Exception ex) { return ex.ToString(); }
        }
        /// <summary>
        /// 加载自定义控件有方法无参数
        /// </summary>
        /// <param name="path">控件地址</param>
        /// <param name="function">方法名称</param>
        /// <returns></returns>
        public string Contorl(string path, string function)
        {
            try
            {
                Control c = Page.LoadControl(path);
                Type tc = c.GetType();
                System.Reflection.MethodInfo m = tc.GetMethod(function); //xx为控件中函数
                if (m != null)
                    m.Invoke(c, null);//调用
                string str = ReturnControl(c);
                return str;
            }
            catch (Exception ex) { return ex.ToString(); }
        }
        /// <summary>
        /// 加载自定义控件有方法参数
        /// </summary>
        /// <param name="path">控件地址</param>
        /// <param name="function">方法名称</param>
        /// <param name="obj">传递的参数，每个参数的类型一定要对应</param>
        /// <returns></returns>
        public string Contorl(string path,string function,object[]obj)
        {
            try
            {
                Control c = Page.LoadControl(path);
                Type tc = c.GetType();
                System.Reflection.MethodInfo m = tc.GetMethod(function); //xx为控件中函数
                if(m != null)
                m.Invoke(c, obj);//调用
                string str = ReturnControl(c);
                return str;
            }
            catch (Exception ex) { return ex.ToString(); }
        }

        string ReturnControl(Control control)
        {
            try
            {
                StringWriter sw = new StringWriter(CultureInfo.InvariantCulture);
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                control.RenderControl(htw);
                htw.Flush();
                htw.Close();
                return sw.ToString();
            }
            catch (Exception ex) { return ex.ToString(); }
        } 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">地址</param>
        /// <param name="bl">保留传参</param>
        /// <returns></returns>
        public string ReadModel(string path)
        {
            return ExecAspxToHtml(path,false);
        }


        /// <summary>        
        /// Aspx生成静态页       
        /// /// </summary>        
        /// <param name="strUrl">AspUrl</param>        
        /// <param name="strSavePath">HtmlPath</param>        
        /// <returns></returns>        
        string ExecAspxToHtml(string strUrl,bool bl)
        {
            try
            {
                StringWriter strHTML = new StringWriter();
                Page myPage = new Page();
                myPage.Server.Execute(strUrl, strHTML, bl);
                return strHTML.ToString();
            }
            catch(Exception ex)
            {
                return "错误：" + ex.ToString();
            }
        }
    }
}
