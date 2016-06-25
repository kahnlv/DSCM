using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;

public partial class img_imgupload : Page
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
                            if (fex != ".jpg" && fex != ".JPG" && fex != ".gif" && fex != ".GIF" && fex != ".PNG" && fex != ".png")
                            {
                                strmsg.Append(Path.GetFileName(postedfile.FileName) + "---图片格式不对，只能是jpg或gif<br>");
                                break;
                            }

                            // postedfile.SaveAs(Server.MapPath("../Images/productImages") + @"\" + picName + fName1);
                            try
                            {
                                Random r = new Random();
                                string path = Server.MapPath("../data/upload/"  + date + "/big");
                                string filename = DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + DateTime.Now.Hour + "" + DateTime.Now.Minute + "" + DateTime.Now.Second + "" + DateTime.Now.Millisecond + "" + r.Next(0, 10000);
                                string samlImgPath = Server.MapPath("../data/upload/" + date + "/big");
                                string returnsamlPath = "/data/upload/" + date + "/big";//要返回的地址
                                string modPath = Server.MapPath("../data/upload/" + date + "/mod");
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
    private void GetThumbNail(string strFileName, string samlFilename, int iWidth, int iheight)
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

}