using dscm.Library.self;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace DSCM.Reception
{
    public class LoadImg : DSCMSave
    {
        public void loadimg_DSCM()
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            string returnsamlPath = "";
            System.Text.StringBuilder strmsg = new System.Text.StringBuilder("");
            try
            {
                string date = DateTime.Now.ToShortDateString();
                //获取传参
                HttpFileCollection files = Context.Request.Files;
                for (int ifile = 0; ifile < files.Count; ifile++)
                {
                    if (files[ifile].FileName.Length > 0)
                    {
                        System.Web.HttpPostedFile postedfile = files[ifile];
                        if (postedfile.ContentLength / 2048 > 2048)//单个文件不能大于1024k
                        {
                            strmsg.Append(Path.GetFileName(postedfile.FileName) + "---不能大于1024k");
                            break;
                        }
                        string fex = Path.GetExtension(postedfile.FileName);
                        if (fex != ".jpg" && fex != ".JPG" && fex != ".gif" && fex != ".GIF" && fex != ".PNG" && fex != ".png")
                        {
                            strmsg.Append(Path.GetFileName(postedfile.FileName) + "---图片格式不对，只能是jpg或gif");
                            break;
                        }
                        try
                        {
                            Random r = new Random();
                            string path = Server.MapPath("../data/upload/" + date + "/big");
                            string filename = DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + DateTime.Now.Hour + "" + DateTime.Now.Minute + "" + DateTime.Now.Second + "" + DateTime.Now.Millisecond + "" + r.Next(0, 10000);
                            returnsamlPath = "/data/upload/" + date + "/big/" + filename + fex;//要返回的地址

                            if (!Directory.Exists(path))
                            {
                                Directory.CreateDirectory(path);
                            }

                            postedfile.SaveAs(path + "/" + filename + fex);
                        }
                        catch (Exception ex)
                        {
                            result.Add("success", false);
                            result.Add("msg", ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Add("success", false);
                result.Add("msg", ex.Message);
            }
            if (returnsamlPath.Equals(""))
            {
                result.Add("success", false);
                result.Add("msg", strmsg.ToString());
            }
            else
            {
                result.Add("success", true);
                result.Add("msg", returnsamlPath);
            }
            Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }
    }
}
