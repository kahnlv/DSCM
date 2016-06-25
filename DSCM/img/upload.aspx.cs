/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/3/25 17:04:01 
* File name：upload 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
*/

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;

public partial class img_upload : Page
{
    public bool succe = false;
    public string imageSrc = "";
    public string imageValue = "";

    public string imgSrc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!this.IsPostBack)
            {
                if (Session["user_name"] != null)
                {
                    imageSrc = Request.QueryString["src"] != null ? Request.QueryString["src"] : "";
                    imageValue = Request.QueryString["value"] != null ? Request.QueryString["value"] : "";
                    if (imageSrc.Equals(""))
                        imageSrc = Request.Form["src"] != null ? Request.Form["src"] : "";
                    if (imageValue.Equals(""))
                        imageValue = Request.Form["value"] != null ? Request.Form["value"] : "";

                    string user = Session["user_name"].ToString();
                    string date = DateTime.Now.ToShortDateString();
                    //获取传参
                    System.Text.StringBuilder strmsg = new System.Text.StringBuilder("");
                    HttpFileCollection files = Request.Files;
                    for (int ifile = 0; ifile < files.Count; ifile++)
                    {
                        if (files[ifile].FileName.Length > 0)
                        {
                            System.Web.HttpPostedFile postedfile = files[ifile];
                            if (postedfile.ContentLength / 2048 > 2048)//单个文件不能大于1024k
                            {
                                strmsg.Append(Path.GetFileName(postedfile.FileName) + "---不能大于1024k<br>");
                                break;
                            }
                            string fex = Path.GetExtension(postedfile.FileName);
                            if (fex != ".jpg" && fex != ".JPG" && fex != ".gif" && fex != ".GIF")
                            {
                                strmsg.Append(Path.GetFileName(postedfile.FileName) + "---图片格式不对，只能是jpg或gif<br>");
                                break;
                            }

                            // postedfile.SaveAs(Server.MapPath("../Images/productImages") + @"\" + picName + fName1);
                            try
                            {
                                Random r = new Random();
                                string path = Server.MapPath("../data/upload/" + user + "/" + date + "/big");
                                string filename = DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + DateTime.Now.Hour + "" + DateTime.Now.Minute + "" + DateTime.Now.Second + "" + DateTime.Now.Millisecond + "" + r.Next(0, 10000);
                                string samlImgPath = Server.MapPath("../data/upload/" + user + "/" + date + "/saml");
                                string returnsamlPath = "/data/upload/" + user + "/" + date + "/saml";//要返回的地址
                                string modPath = Server.MapPath("../data/upload/" + user + "/" + date + "/mod");
                                if (!Directory.Exists(path))
                                {
                                    Directory.CreateDirectory(path);
                                }
                                if (!Directory.Exists(samlImgPath))
                                {
                                    Directory.CreateDirectory(samlImgPath);
                                }
                                if (!Directory.Exists(modPath))
                                {
                                    Directory.CreateDirectory(modPath);
                                }
                                postedfile.SaveAs(path + "/" + filename + fex);
                                GetThumbNail(path + "/" + filename + fex, samlImgPath + "/" + filename + fex, 100, 75);
                                GetThumbNail(path + "/" + filename + fex, modPath + "/" + filename + fex, 240, 135);
                                imgSrc = returnsamlPath + "/" + filename + fex;
                                succe = true;
                            }
                            catch
                            {
                                Response.Write("<script>parent.location.reload();</script>");
                            }
                        }
                    }
                }
                else
                {
                    Response.Write("<script>parent.location.reload();</script>");
                }
            }
        }
        catch (Exception ex) { Response.Write(ex.ToString()); }
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
    private void GetThumbNail(string strFileName,string samlFilename, int iWidth, int iheight)
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
}
