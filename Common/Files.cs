using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Common
{
    public class Files
    {

        public static void Delete()
        {
        }

        #region//getFileSize:取得指定文件的大小.
        /// <summary>
        /// 取得指定文件的大小.
        /// </summary>
        /// <param name="FilePath">文件的绝对路径.</param>
        /// <returns>以KB为单位返回文件大小.</returns>
        public static long getFileSize(string FilePath)
        {
            long result = 0;
            if (File.Exists(FilePath))
            {
                FileStream MyFs = new FileStream(FilePath, FileMode.Open);
                result = MyFs.Length / 1024;
                MyFs.Close();
                MyFs.Dispose();
            }
            return result;
        }
        #endregion

        #region//deleteFileFromFolder:删除指定的文件夹中的所有文件.
        /// <summary>
        /// 删除指定的文件夹中的所有文件.
        /// </summary>
        /// <param name="folderPath">文件夹路径.</param>
        /// <returns>返回被删除文件的数量.</returns>
        public static int deleteFileFromFolder(string folderPath)
        {
            int qdkRe = 0;
            try
            {
                string[] fileList = Directory.GetFiles(folderPath);
                for (int ii = 0; ii < fileList.Length; ii++)
                {
                    File.Delete(fileList[ii]);
                    qdkRe++;
                }
            }
            catch (Exception Ex)
            {
                ErrorLog.WriteLog(Ex);
            }
            return qdkRe;
        }
        #endregion

        #region//deleteFile:删除指定的文件.
        /// <summary>
        /// 删除指定的文件.
        /// </summary>
        /// <param name="filePath">文件路径.</param>
        /// <returns>true/false</returns>
        public static bool deleteFile(string filePath)
        {
            bool result = false;
            if (File.Exists(filePath))
            {
                try
                {
                    File.Delete(filePath);
                    result = true;
                }
                catch (Exception Ex)
                {
                    ErrorLog.WriteLog(Ex);
                }
            }
            return result;
        }
        #endregion

        #region//loadFile:读取指定文件文本内容
        /// <summary>
        /// 读取指定文件文本内容.
        /// </summary>
        /// <param name="filePath">文件路径.</param>
        /// <returns>文本内容</returns>
        public static string loadFile(string filePath)
        {
            string result = "";
            if (File.Exists(filePath))
            {
                try
                {
                    FileStream fs = new FileStream(filePath, FileMode.Open);
                    StreamReader sr = new StreamReader(fs);
                    result = sr.ReadToEnd();
                    sr.Close();
                    fs.Close();
                    
                }
                catch (Exception Ex)
                {
                    ErrorLog.WriteLog(Ex);
                }
                
            }
            return result;
        }
        #endregion

        #region//saveFile:保存指定文件文本内容
        /// <summary>
        /// 保存指定文件文本内容.
        /// </summary>
        /// <param name="filePath">文件路径.</param>
        /// <param name="filePath">文本内容.</param>
        /// <returns>true/false</returns>
        public static bool saveFile(string filePath,string text)
        {
            bool result = false;
            if (File.Exists(filePath))
            {
                try
                {
                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.Write(text);
                    sw.Flush();
                    sw.Close();
                    fs.Close();
                    result = true;
                }
                catch (Exception Ex)
                {
                    ErrorLog.WriteLog(Ex);
                }

            }
            return result;
        }
        #endregion

        /// <summary>
        /// 根据aspx页面路径将html生成到指定路径
        /// </summary>
        /// <param name="hmlPath"></param>
        /// <param name="aspxPath"></param>
        public static bool Create(string hmlPath, string aspxPath)
        {
            try
            {
                DirectoryFile.CreateFile(System.Web.HttpContext.Current.Server.MapPath(hmlPath));
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(System.Web.HttpContext.Current.Server.MapPath(hmlPath), false, System.Text.Encoding.GetEncoding(Pbzx.Common.WebInit.webBaseConfig.Encoding)))
                {                    
                    System.Web.HttpContext.Current.Server.Execute(aspxPath, sw, true);
                   
                    sw.Close();                 
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }

}
