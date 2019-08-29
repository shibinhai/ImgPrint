using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace Util
{
    public class FileHelper
    {
        /// <summary>
        /// 文件下载目录
        /// </summary>
        public static string _directory = ConfigurationSettings.AppSettings["Download_Dic"];

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="url">下载地址</param>
        /// <returns>文件名称</returns>
        public static string DownloadFile(string url)
        {
            try
            {
                string fileName = CreateFileName(url);
                if (File.Exists(_directory + fileName))
                {
                    File.Delete(_directory + fileName);
                }

                if (!Directory.Exists(_directory))
                {
                    Directory.CreateDirectory(_directory);
                }
                WebClient client = new WebClient();
                client.DownloadFile(url, _directory + fileName);
                return fileName;
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 创建文件名称
        /// </summary>
        public static string CreateFileName(string url)
        {
            string fileName = "";
            string fileExt = url.Substring(url.LastIndexOf(".")).Trim().ToLower();
            Random rnd = new Random();
            fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + rnd.Next(10, 99).ToString() + fileExt;
            fileName = System.IO.Path.GetFileName(url);//文件名  “Default.aspx”
            return fileName;
        }
    }
}
