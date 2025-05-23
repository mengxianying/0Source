using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Common
{
    /// <summary>
    /// 
    /// ErrorLog ��ժҪ˵��
    /// 
    /// ������ : ͨ������׽,��������TXT�ı���¼��վ���Ŀ¼�µ�[ErrorReport]Ŀ¼.
    /// 
    /// �������� : ����־�ļ�����3*1024ǧ�ֽ�ʱ���Զ������з�ʽ������־.
    /// 
    /// ע������ : ��־�ļ��Ǵ����վ��[����]��Ŀ¼��[ErrLog]Ŀ¼.
    /// 
    /// �����д : mxy
    /// 
    /// ��ϵ��ʽ : mxy.2006@163.com
    /// 
    /// </summary>
    public class ErrorLog
    {
        /// <summary>
        /// ���������ı�����ʽ��¼����.
        /// </summary>
        /// <param name="Ex">������쳣.</param>
        public static void WriteLog(Exception Ex)
        {
            string ErrorLog_OnOff = System.Configuration.ConfigurationManager.AppSettings["SysErrorLog_OnOff"];
            if (string.IsNullOrEmpty(ErrorLog_OnOff) || ErrorLog_OnOff == "" || ErrorLog_OnOff == "on")
            {
                try
                {
                    string ErrTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string ErrSource = Ex.Source;
                    string ErrTargetSite = Ex.TargetSite.ToString();
                    string ErrMsg = Ex.Message;
                    string ErrStackTrace = Ex.StackTrace;
                    string FilePath = System.Web.HttpContext.Current.Server.MapPath("\\ErrorReport\\");
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
                    MySw.WriteLine("����ʱ�� : " + ErrTime);
                    MySw.WriteLine("������� : " + ErrSource);
                    MySw.WriteLine("�쳣���� : " + ErrTargetSite);
                    MySw.WriteLine("������Ϣ : " + ErrMsg);
                    MySw.WriteLine("��ջ���� : ");
                    MySw.WriteLine(ErrStackTrace);
                    MySw.WriteLine("\r\n*****************mxy*Error*Report*****************\r\n");
                    MySw.Close();
                    //MySw.Dispose();
                }
                catch (Exception ex)
                {
                }
            }
        }


        /// <summary>
        /// ���������ı�����ʽ��¼����.
        /// </summary>
        /// <param name="Ex">������쳣.</param>
        public static void WriteLogMeng(string type,string msg,bool addIP,bool addUrl)
        {
            string ErrorLog_OnOff = System.Configuration.ConfigurationManager.AppSettings["AppErrorLog_OnOff"];
            if (string.IsNullOrEmpty(ErrorLog_OnOff) || ErrorLog_OnOff == "" || ErrorLog_OnOff == "on")
            {
                try
                {
                    string ErrTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string FilePath = System.Web.HttpContext.Current.Server.MapPath("\\ErrorReport\\");
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
                    MySw.WriteLine("----------------------------------------------------------------");
                    string strIP = System.Web.HttpContext.Current.Request.UserHostAddress;
                    string strIPName = "";
                    if(addIP)
                    {
                        strIPName += "[" + strIP + "(" + Method.S_getIPaddress(strIP) + ")]";
                    }
                    string strUrl = "";
                    if(addUrl)
                    {
                        strUrl += "[" + System.Web.HttpContext.Current.Request.FilePath + "]";
                    }
                    MySw.WriteLine( "��" + type + "��" + "[" + DateTime.Now.ToString("MM-dd HH:mm:ss.ffff") + "] " + strUrl + " " + strIPName);
                    MySw.WriteLine("��"+msg);
                    MySw.WriteLine("----------------------------------------------------------------\r\n");
                    MySw.Close();
                    //MySw.Dispose();
                }
                catch (Exception ex)
                {

                }
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
