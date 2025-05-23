using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Xml;

namespace Pbzx.Common
{
    /// <summary>
    /// �ļ��в���
    /// </summary>
    public class DirectoryFile
    {
        /// <summary>
        /// FileDirectoryUtility ��,�����������쳣����
        /// </summary>
        public DirectoryFile()
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
            //
            
        }


        #region Ŀ¼����
        /// <summary>
        /// ·���ָ��
        /// </summary>
        private const string PATH_SPLIT_CHAR = "\\";

        #region ��ȡ�ļ�������Ŀ¼
        /// <summary>
        /// ��ȡ�ļ�������Ŀ¼
        /// </summary>
        /// <param name="tagarturl">Ŀ���ļ�</param>
        /// <returns>�������ݣ����tagarturlΪ���򷵻�null</returns>
        public static string GetDirectoryByFile(string tagarturl)
        {
            if (string.IsNullOrEmpty(tagarturl))
            {
                string resurl = "";
                //string[] urls = BasicProcedure.GetStringsByFlag(tagarturl, @"\\");
                string[] urls = tagarturl.Split(new char[] { '\\' });

                for (int i = 0; i < urls.Length - 1; i++)
                {
                    resurl += urls[i] + '\\';
                }
                return resurl;
            }
            else
                return null;
        }
        #endregion


        /// <summary>
        /// ����ָ��Ŀ¼�������ļ�,��������Ŀ¼����Ŀ¼�е��ļ�
        /// </summary>
        /// <param name="sourceDir">ԭʼĿ¼</param>
        /// <param name="targetDir">Ŀ��Ŀ¼</param>
        /// <param name="overWrite">���Ϊtrue,��ʾ����ͬ���ļ�,���򲻸���</param>
        public static void CopyFiles(string sourceDir, string targetDir, bool overWrite)
        {
            CopyFiles(sourceDir, targetDir, overWrite, false);
        }

        /// <summary>
        /// ����ָ��Ŀ¼�������ļ�
        /// </summary>
        /// <param name="sourceDir">ԭʼĿ¼</param>
        /// <param name="targetDir">Ŀ��Ŀ¼</param>
        /// <param name="overWrite">���Ϊtrue,����ͬ���ļ�,���򲻸���</param>
        /// <param name="copySubDir">���Ϊtrue,����Ŀ¼,���򲻰���</param>
        public static void CopyFiles(string sourceDir, string targetDir, bool overWrite, bool copySubDir)
        {
            //���Ƶ�ǰĿ¼�ļ�
            foreach (string sourceFileName in Directory.GetFiles(sourceDir))
            {
                string targetFileName = Path.Combine(targetDir, sourceFileName.Substring(sourceFileName.LastIndexOf(PATH_SPLIT_CHAR) + 1));

                if (File.Exists(targetFileName))
                {
                    if (overWrite == true)
                    {
                        File.SetAttributes(targetFileName, FileAttributes.Normal);
                        File.Copy(sourceFileName, targetFileName, overWrite);
                    }
                }
                else
                {
                    File.Copy(sourceFileName, targetFileName, overWrite);
                }
            }
            //������Ŀ¼
            if (copySubDir)
            {
                foreach (string sourceSubDir in Directory.GetDirectories(sourceDir))
                {
                    string targetSubDir = Path.Combine(targetDir, sourceSubDir.Substring(sourceSubDir.LastIndexOf(PATH_SPLIT_CHAR) + 1));
                    if (!Directory.Exists(targetSubDir))
                        Directory.CreateDirectory(targetSubDir);
                    CopyFiles(sourceSubDir, targetSubDir, overWrite, true);
                }
            }
        }

        /// <summary>
        /// ����ָ��Ŀ¼�������ļ�,��������Ŀ¼
        /// </summary>
        /// <param name="sourceDir">ԭʼĿ¼</param>
        /// <param name="targetDir">Ŀ��Ŀ¼</param>
        /// <param name="overWrite">���Ϊtrue,����ͬ���ļ�,���򲻸���</param>
        public static void MoveFiles(string sourceDir, string targetDir, bool overWrite)
        {
            MoveFiles(sourceDir, targetDir, overWrite, false);
        }

        /// <summary>
        /// ����ָ��Ŀ¼�������ļ�
        /// </summary>
        /// <param name="sourceDir">ԭʼĿ¼</param>
        /// <param name="targetDir">Ŀ��Ŀ¼</param>
        /// <param name="overWrite">���Ϊtrue,����ͬ���ļ�,���򲻸���</param>
        /// <param name="moveSubDir">���Ϊtrue,����Ŀ¼,���򲻰���</param>
        public static void MoveFiles(string sourceDir, string targetDir, bool overWrite, bool moveSubDir)
        {
            //�ƶ���ǰĿ¼�ļ�
            foreach (string sourceFileName in Directory.GetFiles(sourceDir))
            {
                string targetFileName = Path.Combine(targetDir, sourceFileName.Substring(sourceFileName.LastIndexOf(PATH_SPLIT_CHAR) + 1));
                if (File.Exists(targetFileName))
                {
                    if (overWrite == true)
                    {
                        File.SetAttributes(targetFileName, FileAttributes.Normal);
                        File.Delete(targetFileName);
                        File.Move(sourceFileName, targetFileName);
                    }
                }
                else
                {
                    File.Move(sourceFileName, targetFileName);
                }
            }
            if (moveSubDir)
            {
                foreach (string sourceSubDir in Directory.GetDirectories(sourceDir))
                {
                    string targetSubDir = Path.Combine(targetDir, sourceSubDir.Substring(sourceSubDir.LastIndexOf(PATH_SPLIT_CHAR) + 1));
                    if (!Directory.Exists(targetSubDir))
                        Directory.CreateDirectory(targetSubDir);
                    MoveFiles(sourceSubDir, targetSubDir, overWrite, true);
                    Directory.Delete(sourceSubDir);
                }
            }
        }

        /// <summary>
        /// ɾ��ָ��Ŀ¼�������ļ�����������Ŀ¼
        /// </summary>
        /// <param name="targetDir">����Ŀ¼</param>
        public static void DeleteFiles(string targetDir)
        {
            DeleteFiles(targetDir, false);
        }

        /// <summary>
        /// ɾ��ָ��Ŀ¼�������ļ�����Ŀ¼
        /// </summary>
        /// <param name="targetDir">����Ŀ¼</param>
        /// <param name="delSubDir">���Ϊtrue,��������Ŀ¼�Ĳ���</param>
        public static void DeleteFiles(string targetDir, bool delSubDir)
        {
            foreach (string fileName in Directory.GetFiles(targetDir))
            {
                File.SetAttributes(fileName, FileAttributes.Normal);
                File.Delete(fileName);
            }
            if (delSubDir)
            {
                DirectoryInfo dir = new DirectoryInfo(targetDir);
                foreach (DirectoryInfo subDi in dir.GetDirectories())
                {
                    DeleteFiles(subDi.FullName, true);
                    subDi.Delete();
                }
            }
        }



        /// <summary>
        /// �ж�ָ��Ŀ¼�Ƿ񴴽�
        /// </summary>
        /// <param name="targetDir"></param>
        public static bool IsCreateDirectory(string targetDir)
        {
            return Directory.Exists(targetDir);
        }

        /// <summary>
        /// ����ָ��Ŀ¼
        /// </summary>
        /// <param name="targetDir"></param>
        public static void CreateDirectory(string targetDir)
        {
            DirectoryInfo dir = new DirectoryInfo(targetDir);
            if (!dir.Exists)
                dir.Create();
        }


        /// <summary>
        /// ������Ŀ¼
        /// </summary>
        /// <param name="targetDir">Ŀ¼·��</param>
        /// <param name="subDirName">��Ŀ¼����</param>
        public static void CreateDirectory(string parentDir, string subDirName)
        {
            CreateDirectory(parentDir + PATH_SPLIT_CHAR + subDirName);
        }

        /// <summary>
        /// ɾ��ָ��Ŀ¼
        /// </summary>
        /// <param name="targetDir">Ŀ¼·��</param>
        public static void DeleteDirectory(string targetDir)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(targetDir);
            if (dirInfo.Exists)
            {
                DeleteFiles(targetDir, true);
                dirInfo.Delete(true);

            }
        }

        /// <summary>
        /// ɾ��ָ��Ŀ¼��������Ŀ¼,�������Ե�ǰĿ¼�ļ���ɾ��
        /// </summary>
        /// <param name="targetDir">Ŀ¼·��</param>
        public static void DeleteSubDirectory(string targetDir)
        {
            foreach (string subDir in Directory.GetDirectories(targetDir))
            {
                DeleteDirectory(subDir);
            }
        }

        /// <summary>
        /// ��ָ��Ŀ¼�µ���Ŀ¼���ļ�����xml�ĵ�
        /// </summary>
        /// <param name="targetDir">��Ŀ¼</param>
        /// <returns>����XmlDocument����</returns>
        public static XmlDocument CreateXml(string targetDir)
        {
            XmlDocument myDocument = new XmlDocument();
            XmlDeclaration declaration = myDocument.CreateXmlDeclaration("1.0", "utf-8", null);
            myDocument.AppendChild(declaration);
            XmlElement rootElement = myDocument.CreateElement(targetDir.Substring(targetDir.LastIndexOf(PATH_SPLIT_CHAR) + 1));
            myDocument.AppendChild(rootElement);
            foreach (string fileName in Directory.GetFiles(targetDir))
            {
                XmlElement childElement = myDocument.CreateElement("File");
                childElement.InnerText = fileName.Substring(fileName.LastIndexOf(PATH_SPLIT_CHAR) + 1);
                rootElement.AppendChild(childElement);
            }
            foreach (string directory in Directory.GetDirectories(targetDir))
            {
                XmlElement childElement = myDocument.CreateElement("Directory");
                childElement.SetAttribute("Name", directory.Substring(directory.LastIndexOf(PATH_SPLIT_CHAR) + 1));
                rootElement.AppendChild(childElement);
                CreateBranch(directory, childElement, myDocument);
            }
            return myDocument;
        }

        /// <summary>
        /// ����Xml��֧
        /// </summary>
        /// <param name="targetDir">��Ŀ¼</param>
        /// <param name="xmlNode">��Ŀ¼XmlDocument</param>
        /// <param name="myDocument">XmlDocument����</param>
        private static void CreateBranch(string targetDir, XmlElement xmlNode, XmlDocument myDocument)
        {
            foreach (string fileName in Directory.GetFiles(targetDir))
            {
                XmlElement childElement = myDocument.CreateElement("File");
                childElement.InnerText = fileName.Substring(fileName.LastIndexOf(PATH_SPLIT_CHAR) + 1);
                xmlNode.AppendChild(childElement);
            }
            foreach (string directory in Directory.GetDirectories(targetDir))
            {
                XmlElement childElement = myDocument.CreateElement("Directory");
                childElement.SetAttribute("Name", directory.Substring(directory.LastIndexOf(PATH_SPLIT_CHAR) + 1));
                xmlNode.AppendChild(childElement);
                CreateBranch(directory, childElement, myDocument);
            }
        }

        #endregion


        #region �ļ�����

        private bool _alreadyDispose = false;

        #region ���캯��


        protected virtual void Dispose(bool isDisposing)
        {
            if (_alreadyDispose) return;
            //if (isDisposing)
            //{
            //     if (xml != null)
            //     {
            //         xml = null;
            //     }
            //}
            _alreadyDispose = true;
        }
        #endregion

        #region IDisposable ��Ա

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region ȡ���ļ���׺��
        /****************************************
          * �������ƣ�GetPostfixStr
          * ����˵����ȡ���ļ���׺��
          * ��     ����filename:�ļ�����
          * ����ʾ�У�
          *            string filename = "aaa.aspx";        
          *            string s = EC.FileObj.GetPostfixStr(filename);         
         *****************************************/
        /// <summary>
        /// ȡ��׺��
        /// </summary>
        /// <param name="filename">�ļ���</param>
        /// <returns>.gif|.html��ʽ</returns>
        public static string GetPostfixStr(string filename)
        {
            int start = filename.LastIndexOf(".");
            int length = filename.Length;
            string postfix = filename.Substring(start, length - start);
            return postfix;
        }
        #endregion

        #region �ж��ļ��Ƿ����
        /// <summary>
        /// �ж��ļ��Ƿ����
        /// </summary>
        /// <param name="Path">�ļ���ַ</param>
        /// <returns></returns>
        public static bool IsCreateFile(string Path)
        {
            return File.Exists(Path);
        }
        #endregion

        #region �����ļ�
        /****************************************
          * �������ƣ�CreateFile
          * ����˵���������ļ�
          * ��     ����Path:�ļ�·��
          * ����ʾ�У�
          *            string Path = Server.MapPath("Default2.aspx");       
          *            EC.FileObj.WriteFile(Path,Strings);
         *****************************************/
        /// <summary>
        /// �����ļ�
        /// </summary>
        /// <param name="Path">�ļ�·��</param>
        /// <param name="Strings">�ļ�����</param>
        public static void CreateFile(string Path)
        {
            if (!System.IO.File.Exists(Path))
            {
                System.IO.FileStream f = System.IO.File.Create(Path);
                f.Close();
            }
        }
        #endregion


        #region д�ļ�
        /****************************************
          * �������ƣ�WriteFile
          * ����˵����д�ļ�,�Ḳ�ǵ���ǰ������
          * ��     ����Path:�ļ�·��,Strings:�ı�����
          * ����ʾ�У�
          *            string Path = Server.MapPath("Default2.aspx");       
          *            string Strings = "������д�����ݰ�";
          *            EC.FileObj.WriteFile(Path,Strings);
         *****************************************/
        /// <summary>
        /// д�ļ�
        /// </summary>
        /// <param name="Path">�ļ�·��</param>
        /// <param name="Strings">�ļ�����</param>
        public static void WriteFile(string Path, string Strings)
        {
            string targetDir = Path.Substring(0,(Path.LastIndexOf(@"/")+1));
            CreateDirectory(targetDir);
            if (!System.IO.File.Exists(Path))
            {
                System.IO.FileStream f = System.IO.File.Create(Path);
                f.Close();
            }
            System.IO.StreamWriter f2 = new System.IO.StreamWriter(Path, false, System.Text.Encoding.GetEncoding(WebInit.webBaseConfig.Encoding));
            f2.Write(Strings);
            f2.Close();
            f2.Dispose();
        }
        #endregion

        #region ���ļ�
        /****************************************
          * �������ƣ�ReadFile
          * ����˵������ȡ�ı�����
          * ��     ����Path:�ļ�·��
          * ����ʾ�У�
          *            string Path = Server.MapPath("Default2.aspx");       
          *            string s = EC.FileObj.ReadFile(Path);
         *****************************************/
        /// <summary>
        /// ���ļ�
        /// </summary>
        /// <param name="Path">�ļ�·��</param>
        /// <returns></returns>
        public static string ReadFile(string Path)
        {
            string s = "";
            if (!System.IO.File.Exists(Path))
                s = "��������Ӧ��Ŀ¼";
            else
            {
                StreamReader f2 = new StreamReader(Path, System.Text.Encoding.GetEncoding("gb2312"));
                s = f2.ReadToEnd();
                f2.Close();
                f2.Dispose();
            }

            return s;
        }
        #endregion

        #region ׷���ļ�
        /****************************************
          * �������ƣ�FileAdd
          * ����˵����׷���ļ�����
          * ��     ����Path:�ļ�·��,strings:����
          * ����ʾ�У�
          *            string Path = Server.MapPath("Default2.aspx");     
          *            string Strings = "��׷������";
          *            EC.FileObj.FileAdd(Path, Strings);
         *****************************************/
        /// <summary>
        /// ׷���ļ�
        /// </summary>
        /// <param name="Path">�ļ�·��</param>
        /// <param name="strings">����</param>
        public static void FileAdd(string Path, string strings)
        {
            StreamWriter sw = File.AppendText(Path);
            sw.Write(strings);
            sw.Flush();
            sw.Close();
        }
        #endregion

        #region �����ļ�
        /****************************************
          * �������ƣ�FileCoppy
          * ����˵���������ļ�
          * ��     ����OrignFile:ԭʼ�ļ�,NewFile:���ļ�·��
          * ����ʾ�У�
          *            string orignFile = Server.MapPath("Default2.aspx");     
          *            string NewFile = Server.MapPath("Default3.aspx");
          *            EC.FileObj.FileCoppy(OrignFile, NewFile);
         *****************************************/
        /// <summary>
        /// �����ļ�
        /// </summary>
        /// <param name="OrignFile">ԭʼ�ļ�</param>
        /// <param name="NewFile">���ļ�·��</param>
        public static void FileCoppy(string orignFile, string NewFile)
        {
            File.Copy(orignFile, NewFile, true);
        }

        #endregion

        #region ɾ���ļ�
        /****************************************
          * �������ƣ�FileDel
          * ����˵����ɾ���ļ�
          * ��     ����Path:�ļ�·��
          * ����ʾ�У�
          *            string Path = Server.MapPath("Default3.aspx");    
          *            EC.FileObj.FileDel(Path);
         *****************************************/
        /// <summary>
        /// ɾ���ļ�
        /// </summary>
        /// <param name="Path">·��</param>
        public static void FileDel(string Path)
        {
            File.Delete(Path);
        }
        #endregion

        #region �ƶ��ļ�
        /****************************************
          * �������ƣ�FileMove
          * ����˵�����ƶ��ļ�
          * ��     ����OrignFile:ԭʼ·��,NewFile:���ļ�·��
          * ����ʾ�У�
          *             string orignFile = Server.MapPath("../˵��.txt");    
          *             string NewFile = Server.MapPath("../../˵��.txt");
          *             EC.FileObj.FileMove(OrignFile, NewFile);
         *****************************************/
        /// <summary>
        /// �ƶ��ļ�
        /// </summary>
        /// <param name="OrignFile">ԭʼ·��</param>
        /// <param name="NewFile">��·��</param>
        public static void FileMove(string orignFile, string NewFile)
        {
            File.Move(orignFile, NewFile);
        }
        #endregion

        #region �ڵ�ǰĿ¼�´���Ŀ¼
        /****************************************
          * �������ƣ�FolderCreate
          * ����˵�����ڵ�ǰĿ¼�´���Ŀ¼
          * ��     ����OrignFolder:��ǰĿ¼,NewFloder:��Ŀ¼
          * ����ʾ�У�
          *            string orignFolder = Server.MapPath("test/");    
          *            string NewFloder = "new";
          *            EC.FileObj.FolderCreate(OrignFolder, NewFloder); 
         *****************************************/
        /// <summary>
        /// �ڵ�ǰĿ¼�´���Ŀ¼
        /// </summary>
        /// <param name="OrignFolder">��ǰĿ¼</param>
        /// <param name="NewFloder">��Ŀ¼</param>
        public static void FolderCreate(string orignFolder, string NewFloder)
        {
            Directory.SetCurrentDirectory(orignFolder);
            Directory.CreateDirectory(NewFloder);
        }
        #endregion

        #region �ݹ�ɾ���ļ���Ŀ¼���ļ�
        /****************************************
          * �������ƣ�DeleteFolder
          * ����˵�����ݹ�ɾ���ļ���Ŀ¼���ļ�
          * ��     ����dir:�ļ���·��
          * ����ʾ�У�
          *            string dir = Server.MapPath("test/");  
          *            EC.FileObj.DeleteFolder(dir);       
         *****************************************/
        /// <summary>
        /// �ݹ�ɾ���ļ���Ŀ¼���ļ�
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        public static void DeleteFolder(string dir)
        {
            if (Directory.Exists(dir)) //�����������ļ���ɾ��֮ 
            {
                foreach (string d in Directory.GetFileSystemEntries(dir))
                {
                    if (File.Exists(d))
                        File.Delete(d); //ֱ��ɾ�����е��ļ� 
                    else
                        DeleteFolder(d); //�ݹ�ɾ�����ļ��� 
                }
                Directory.Delete(dir); //ɾ���ѿ��ļ��� 
            }

        }

        #endregion

        #region ��ָ���ļ����������������copy��Ŀ���ļ������� ��Ŀ���ļ���Ϊֻ�����Ծͻᱨ��
        /****************************************
          * �������ƣ�CopyDir
          * ����˵������ָ���ļ����������������copy��Ŀ���ļ������� ��Ŀ���ļ���Ϊֻ�����Ծͻᱨ��
          * ��     ����srcPath:ԭʼ·��,aimPath:Ŀ���ļ���
          * ����ʾ�У�
          *            string srcPath = Server.MapPath("test/");  
          *            string aimPath = Server.MapPath("test1/");
          *            EC.FileObj.CopyDir(srcPath,aimPath);   
         *****************************************/
        /// <summary>
        /// ָ���ļ����������������copy��Ŀ���ļ�������
        /// </summary>
        /// <param name="srcPath">ԭʼ·��</param>
        /// <param name="aimPath">Ŀ���ļ���</param>
        public static void CopyDir(string srcPath, string aimPath)
        {
            try
            {
                // ���Ŀ��Ŀ¼�Ƿ���Ŀ¼�ָ��ַ�����������������֮
                if (aimPath[aimPath.Length - 1] != Path.DirectorySeparatorChar)
                    aimPath += Path.DirectorySeparatorChar;
                // �ж�Ŀ��Ŀ¼�Ƿ����������������½�֮
                if (!Directory.Exists(aimPath))
                    Directory.CreateDirectory(aimPath);
                // �õ�ԴĿ¼���ļ��б��������ǰ����ļ��Լ�Ŀ¼·����һ������
                //�����ָ��copyĿ���ļ�������ļ���������Ŀ¼��ʹ������ķ���
                //string[] fileList = Directory.GetFiles(srcPath);
                string[] fileList = Directory.GetFileSystemEntries(srcPath);
                //�������е��ļ���Ŀ¼
                foreach (string file in fileList)
                {
                    //�ȵ���Ŀ¼��������������Ŀ¼�͵ݹ�Copy��Ŀ¼������ļ�

                    if (Directory.Exists(file))
                        CopyDir(file, aimPath + Path.GetFileName(file));
                    //����ֱ��Copy�ļ�
                    else
                        File.Copy(file, aimPath + Path.GetFileName(file), true);
                }

            }
            catch (Exception ee)
            {
                throw new Exception(ee.ToString());
            }
        }



        #endregion
        #endregion

    }
}
