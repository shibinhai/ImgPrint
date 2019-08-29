using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UploadFile
{
    public partial class Upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string imgurl = "\\images\\" + DateTime.Now.ToString("yyyyMMdd");
                imgurl = Request.MapPath(imgurl);
                if (System.IO.Directory.Exists(imgurl))  //己经存在
                {
                    //Directory.Delete(imgurl); //images\20190328 已存在，直接在里面存图片即可
                }
                else
                {
                    System.IO.Directory.CreateDirectory(imgurl); //images\20190328 不存在，先创建文件夹
                }
                Tool.WriteLog("这是文件夹路劲" + imgurl);
                foreach (string f in Request.Files.AllKeys)
                {
                    HttpPostedFile file = Request.Files[f];

                    file.SaveAs(imgurl + "\\" + file.FileName);
                }
                Response.Write("ok");

            }
            catch (Exception ex)
            {
                Tool.WriteLog("上传接口出现异常" + ex.Message);
            }
        }
    }
}