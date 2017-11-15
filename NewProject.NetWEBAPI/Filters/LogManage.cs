using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FamilyMYYT.Filters
{
    /// <summary>
    /// 自定义日志记录器
    /// </summary>
    public class LogManage
    {
        private LogManage() { }

        private static LogManage Instance;

        private static object locked => new object();
        public static LogManage GetInstance()
        {
            if (Instance == null)
            {
                lock (locked)
                {
                    if (Instance == null)
                    {
                        Instance = new LogManage();
                    }
                }
            }
            return Instance;
        }
        /// <summary>
        /// WirteFile
        /// </summary>
        /// <param name="str"></param>
        public void Info(string str, string fileurl = "~/App_Data/Info.log")
        {
            var mappedPath = MapPath(fileurl);
            if (!File.Exists(mappedPath))
            {
                try
                {
                    //创建文件
                    FileStream fs = new FileStream(mappedPath, FileMode.Create, FileAccess.ReadWrite);
                    StreamWriter sw = new StreamWriter(fs);
                    //写入数据
                    sw.WriteLine("记录时间：" + DateTime.Now + "------" + str);
                    sw.Close();
                    fs.Close();
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                //追加文件
                FileStream fs = new FileStream(mappedPath, FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                //写入数据
                sw.WriteLine("记录时间：" + DateTime.Now + "------" + str);
                sw.Close();
                fs.Close();
            }
        }
        public void Error(string str)
        {
            Info(str, "~/App_Data/Error.log");
        }
        static string MapPath(string url)
        {
            if (HttpContext.Current != null)
                return HttpContext.Current.Server.MapPath(url);
            return System.Web.Hosting.HostingEnvironment.MapPath(url);
        }
    }
}