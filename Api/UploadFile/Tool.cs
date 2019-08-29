using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace UploadFile
{
    public class Tool
    {
        /// <summary>
        /// 每次发送短信成功写日志
        /// </summary>
        /// <param name="text"></param>
        /// <param name="logend"></param>
        public static void WriteLog(string text)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            path = System.IO.Path.Combine(path
            , "Logs\\");

            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            string fileFullName = System.IO.Path.Combine(path
            , string.Format("{0}.txt", DateTime.Now.ToString("yyyy-MM-dd")));


            using (StreamWriter output = System.IO.File.AppendText(fileFullName))
            {
                output.WriteLine(text);

                output.Close();
            }
        }
    }
}