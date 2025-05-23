using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Web;


namespace Pbzx.Common
{
    public class Follow
    {
        /// <summary>

        /// 写日志文件

        /// </summary>

        /// <param name="sMsg"></param>

        public static void WriteLog(string sMsg)
        {

            if (sMsg != "")
            {

                //Random randObj = new Random(DateTime.Now.Millisecond);

                //int file = randObj.Next() + 1;

                //string filename = DateTime.Now.ToString("yyyyMMddhhmmss") + file + ".txt";

                //try
                //{
                //    string FilePath = System.Web.HttpContext.Current.Server.MapPath("\\FollowReport\\");

                //    if (!Directory.Exists(FilePath))
                //    {
                //        Directory.CreateDirectory(FilePath);

                //    }
                //    FileInfo fi = new FileInfo(FilePath + filename);

                //    if (!fi.Exists)
                //    {

                //        using (StreamWriter sw = fi.CreateText())
                //        {

                //            sw.WriteLine(DateTime.Now + "\n" + sMsg + "\n");

                //            sw.Close();

                //        }

                //    }

                //    else
                //    {

                //        using (StreamWriter sw = fi.AppendText())
                //        {

                //            sw.WriteLine(DateTime.Now + "\n" + sMsg + "\n");

                //            sw.Close();

                //        }

                //    }

                //}

                //catch
                //{

                //}
                string ErrTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string FilePath = System.Web.HttpContext.Current.Server.MapPath("\\FollowReport\\");
                if (!Directory.Exists(FilePath))
                {
                    Directory.CreateDirectory(FilePath);
                }
                string FileName = FilePath + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
                if (GetFileSize(FileName) > 1024 * 3)
                {
                    CopyToBak(FileName);
                }
                StreamWriter MySw = new StreamWriter(FileName, true);
                MySw.WriteLine("记录时间 : " + ErrTime);

                MySw.WriteLine(sMsg);
                MySw.WriteLine("\r\n*****************mxy*Error*Report*****************\r\n");
                MySw.Close();

            }

        }
        private static long GetFileSize(string FileName)
        {
            long strRe = 0;
            if (File.Exists(FileName))
            {
                FileStream MyFs = new FileStream(FileName, FileMode.Open);
                strRe = MyFs.Length / 1024;
                MyFs.Close();
                MyFs.Dispose();
            }
            return strRe;
        }
        private static void CopyToBak(string sFileName)
        {
            int FileCount = 0;
            string sBakName = "";
            do
            {
                FileCount++;
                sBakName = sFileName + "." + FileCount.ToString() + ".BAK";
            }
            while (File.Exists(sBakName));
            File.Copy(sFileName, sBakName);
            File.Delete(sFileName);
        }

    }
}
