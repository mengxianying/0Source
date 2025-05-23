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

        #region//getFileSize:ȡ��ָ���ļ��Ĵ�С.
        /// <summary>
        /// ȡ��ָ���ļ��Ĵ�С.
        /// </summary>
        /// <param name="FilePath">�ļ��ľ���·��.</param>
        /// <returns>��KBΪ��λ�����ļ���С.</returns>
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

        #region//deleteFileFromFolder:ɾ��ָ�����ļ����е������ļ�.
        /// <summary>
        /// ɾ��ָ�����ļ����е������ļ�.
        /// </summary>
        /// <param name="folderPath">�ļ���·��.</param>
        /// <returns>���ر�ɾ���ļ�������.</returns>
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

        #region//deleteFile:ɾ��ָ�����ļ�.
        /// <summary>
        /// ɾ��ָ�����ļ�.
        /// </summary>
        /// <param name="filePath">�ļ�·��.</param>
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

        #region//loadFile:��ȡָ���ļ��ı�����
        /// <summary>
        /// ��ȡָ���ļ��ı�����.
        /// </summary>
        /// <param name="filePath">�ļ�·��.</param>
        /// <returns>�ı�����</returns>
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

        #region//saveFile:����ָ���ļ��ı�����
        /// <summary>
        /// ����ָ���ļ��ı�����.
        /// </summary>
        /// <param name="filePath">�ļ�·��.</param>
        /// <param name="filePath">�ı�����.</param>
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
        /// ����aspxҳ��·����html���ɵ�ָ��·��
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
