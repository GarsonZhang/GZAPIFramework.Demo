using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace GZAPIFramework.Biz
{
    public class Log
    {
        /// <summary>
        /// 写日志，指定日志文件
        /// </summary>
        /// <param name="File"></param>
        /// <param name="Msg"></param>
        public static void Add(string Msg)
        {

            try
            {
                string File = System.IO.Path.GetFullPath(HostingEnvironment.MapPath("~/App_Data/") + "log.txt");
                string path = Path.GetDirectoryName(File);
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                    System.IO.File.CreateText(File).Dispose();
                }
                else if (!System.IO.File.Exists(File))
                {
                    System.IO.File.CreateText(File).Dispose();
                }
                using (TextWriter writer2 = System.IO.File.AppendText(File))
                {
                    writer2.WriteLine(Msg);
                    writer2.WriteLine(" ");
                }
            }
            catch //(Exception ex)
            {

            }
        }
        public static void AddIOS(string Msg)
        {

            try
            {
                string File = System.IO.Path.GetFullPath(HostingEnvironment.MapPath("~/App_Data/") + "logIOS.txt");
                string path = Path.GetDirectoryName(File);
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                    System.IO.File.CreateText(File).Dispose();
                }
                else if (!System.IO.File.Exists(File))
                {
                    System.IO.File.CreateText(File).Dispose();
                }
                using (TextWriter writer2 = System.IO.File.AppendText(File))
                {
                    writer2.WriteLine(Msg);
                    writer2.WriteLine(" ");
                }
            }
            catch //(Exception ex)
            {

            }
        }

        public static void AddAndroid(string Msg)
        {

            try
            {
                string File = System.IO.Path.GetFullPath(HostingEnvironment.MapPath("~/App_Data/") + "logAndroid.txt");
                string path = Path.GetDirectoryName(File);
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                    System.IO.File.CreateText(File).Dispose();
                }
                else if (!System.IO.File.Exists(File))
                {
                    System.IO.File.CreateText(File).Dispose();
                }
                using (TextWriter writer2 = System.IO.File.AppendText(File))
                {
                    writer2.WriteLine(Msg);
                    writer2.WriteLine(" ");
                }
            }
            catch //(Exception ex)
            {

            }
        }

        public static void AddCustomer(string fileName, string Msg)
        {

            try
            {
                string File = System.IO.Path.GetFullPath(string.Format("{0}{1}.txt", HostingEnvironment.MapPath("~/App_Data/"), fileName));
                string path = Path.GetDirectoryName(File);
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                    System.IO.File.CreateText(File).Dispose();
                }
                else if (!System.IO.File.Exists(File))
                {
                    System.IO.File.CreateText(File).Dispose();
                }
                using (TextWriter writer2 = System.IO.File.AppendText(File))
                {
                    writer2.WriteLine(Msg);
                    writer2.WriteLine(" ");
                }
            }
            catch //(Exception ex)
            {

            }
        }

    }
}
