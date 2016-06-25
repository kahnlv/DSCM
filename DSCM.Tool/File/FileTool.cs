using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using DSCM.Tool.Error;
using DSCM.Config;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;

namespace DSCM.Tool.File
{
    public class FileTool
    {
        /// <summary>
        /// 读取网页文件
        /// </summary>
        /// <param name="url"></param>
        public string ReadWebPage(string url)
        {
            try
            {
                System.Net.WebRequest wReq = System.Net.WebRequest.Create(url);     // Get the response 搜索instance.   
                System.Net.WebResponse wResp = wReq.GetResponse();     // Get the response stream.   
                System.IO.Stream respStream = wResp.GetResponseStream();     // Dim reader As StreamReader = New StreamReader(respStream)   
                System.IO.StreamReader reader = new StreamReader(respStream, Encoding.GetEncoding(PageConfig.PageCode));
                string str = reader.ReadToEnd();
                reader.Close();
                respStream.Close();
                wResp.Close();
                wReq.Abort();
                respStream.Dispose();
                return str;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.ToString());
            }
            return "";
        }

        public string Read(string path)
        {
            try
            {
                if (System.IO.File.Exists(path))
                {
                    StreamReader objReader = new StreamReader(path);
                    string sLine = "";
                    sLine = objReader.ReadToEnd();
                    objReader.Close();
                    return sLine;
                }
            }
            catch { }
            return "";
        }
        public void Write(string path, string str)
        {
            try
            {
                string _path = GetRootPath();
                if (path.LastIndexOf("/") > -1)
                {
                    try
                    {
                        _path = _path + path.Substring(0, path.LastIndexOf("/"));
                    }
                    catch { }
                }
                if (!Directory.Exists(_path))
                {
                    Directory.CreateDirectory(_path);
                }
                UTF8Encoding utf8WithBom = new System.Text.UTF8Encoding(true);
                //FileStream fs = new FileStream(path, FileMode.Create);
                StreamWriter sw = new StreamWriter(_path + path.Substring(path.LastIndexOf("/")), false, utf8WithBom);
                //开始写入
                sw.Write(str);
                //清空缓冲区
                sw.Flush();
                //关闭流
                sw.Close();
                //fs.Close();
            }
            catch { }
        }
        //网页生成
        public void WriteWebPage(string path, string file, string str)
        {
            StreamWriter sw = null;
            try
            {
                string gpath = GetRootPath();
                string path1 = gpath + path + "/" + file + ".html";
                string path2 = gpath + "temp/" + path + "/" + file + ".aspx";
                string temppath = gpath + "temp/" + path;

                if (System.IO.File.Exists(path1) && System.IO.File.Exists(path2))
                {
                    FileInfo f1 = new FileInfo(path1);
                    FileInfo f2 = new FileInfo(path2);
                    if (f1.LastWriteTime.Equals(f2.LastWriteTime))
                    { }
                    else
                    {
                        if (!Directory.Exists(temppath))
                        {
                            Directory.CreateDirectory(temppath);
                        }
                        UTF8Encoding utf8WithBom = new System.Text.UTF8Encoding(true);
                        // FileStream fs = new FileStream(path2, FileMode.Create);
                        sw = new StreamWriter(path2, false, utf8WithBom);
                        //开始写入
                        sw.Write(str);
                        //清空缓冲区
                        sw.Flush();
                        //关闭流
                        sw.Close();
                        //fs.Close();
                        f2.LastWriteTime = f1.LastWriteTime;
                    }
                }
                else
                {
                    if (!Directory.Exists(temppath))
                    {
                        Directory.CreateDirectory(temppath);
                    }
                    if (System.IO.File.Exists(path2))
                    {
                        System.IO.File.Delete(path2);
                    }
                    UTF8Encoding utf8WithBom = new System.Text.UTF8Encoding(true);
                    //FileStream fs = new FileStream(path2, FileMode.Create);
                    sw = new StreamWriter(path2, false, utf8WithBom);
                    //开始写入
                    sw.Write(str);
                    //清空缓冲区
                    sw.Flush();
                    //关闭流
                    sw.Close();
                    //fs.Close();
                    if (System.IO.File.Exists(path1) && System.IO.File.Exists(path2))
                    {
                        FileInfo f1 = new FileInfo(path1);
                        FileInfo f2 = new FileInfo(path2);
                        f2.LastWriteTime = f1.LastWriteTime;
                    }

                }

            }
            catch { try { if (sw != null) { sw.Close(); } } catch { } }
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

        public string GetHttpData(string Url)
        {
            string sException = null;
            string sRslt = null;
            WebResponse oWebRps = null;
            WebRequest oWebRqst = WebRequest.Create(Url);
            oWebRqst.Timeout = 5000;
            try
            {
                oWebRps = oWebRqst.GetResponse();
            }
            catch (WebException e)
            {
                sException = e.Message.ToString();
            }
            catch (Exception e)
            {
                sException = e.ToString();
            }
            finally
            {
                if (oWebRps != null)
                {
                    StreamReader oStreamRd = new StreamReader(oWebRps.GetResponseStream());
                    sRslt = oStreamRd.ReadToEnd();
                    oStreamRd.Close();
                    oWebRps.Close();
                }
            }
            return sRslt;
        }
    }
}
