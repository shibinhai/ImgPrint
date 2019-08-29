using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UploadFile
{
    public partial class DeleFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["start"] != null && Request["end"] != null && Request["type"] != null)
                {
                    string type = Request["type"].ToString();
                    if (type=="all")
                    {
                        //全部删除
                        int start = Convert.ToInt32(Request["start"]);
                        int end = Convert.ToInt32(Request["end"]);
                        for (int i = start; i <= end; i++)
                        {
                            string imgUrl = "\\images\\" + i;
                            imgUrl = Request.MapPath(imgUrl);
                            // 1、首先判断文件或者文件路径是否存在
                            if (Directory.Exists(imgUrl))
                            {
                                // 3.1、删除文件夹
                                Directory.Delete(imgUrl, true);
                            }
                        }
                        Response.Write("删除成功");
                    }
                    if (type=="one")
                    {
                        //删除单条记录 
                        string imgurl = Request["imgurl"].ToString();
                        imgurl = Request.MapPath(imgurl);
                        // 1、首先判断文件或者文件路径是否存在
                        if (File.Exists(imgurl))
                        {
                            // 3.1、删除文件
                            File.Delete(imgurl);
                        }
                        Response.Write("删除成功");
                    }


                }
            }
        }
    }
}