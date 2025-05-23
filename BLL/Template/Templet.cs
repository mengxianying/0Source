using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Pbzx.BLL
{
    public class Templet
    {
        /// <summary>
        /// �޸��ļ���(�ļ���)����
        /// </summary>
        /// <param name="path">·��</param>
        /// <param name="oldname">ԭʼ����</param>
        /// <param name="newname">������</param>
        /// <param name="type">0Ϊ�ļ���,1Ϊ�ļ�</param>
        /// <returns>�ɹ�����1</returns>

        public int EidtName(string path, string oldname, string newname, int type)
        {
            int result = 0;
            if (type == 0)
            {
                if (Directory.Exists(path + "\\" + oldname))
                {
                    try
                    {
                        Directory.Move(path + "\\" + oldname, path + "\\" + newname.Replace(".", ""));
                    }
                    catch (IOException e)
                    {
                        throw new Exception(e.ToString());
                    }
                    result = 1;
                }
                else
                {
                    throw new Exception("�������ݴ���!");
                }
            }
            else
            {
                if (File.Exists(path + "\\" + oldname))
                {
                    try
                    {
                        File.Move(path + "\\" + oldname, path + "\\" + newname);
                    }
                    catch (Exception e)
                    {
                        throw new Exception(e.ToString());
                    }
                    result = 1;
                }
                else
                {
                    throw new Exception("�������ݴ���!");
                }
            }
            return result;
        }



        /// <summary>
        /// ɾ���ļ����ļ���
        /// </summary>
        /// <param name="path">·��</param>
        /// <param name="filename">����</param>
        /// <param name="type">0�����ļ���,1�����ļ�</param>
        /// <returns>����ֵ</returns>


        public int Del(string path, string filename, int type)
        {
            int result = 0;
            if (type == 0)
            {
                if (Directory.Exists(path + "\\" + filename))
                {
                    try
                    {
                        Directory.Delete(path, true);
                    }
                    catch (Exception e)
                    {
                        throw new IOException(e.ToString());
                    }
                    result = 1;
                }
                else
                {
                    throw new IOException("��������!");
                }
            }
            else
            {
                if (File.Exists(path + "\\" + filename))
                {
                    try
                    {
                        File.Delete(path + "\\" + filename);
                    }
                    catch (Exception e)
                    {
                        throw new IOException(e.ToString());
                    }
                    result = 1;
                }
                else
                {
                    throw new IOException("��������!");
                }
            }
            return result;
        }

        /// <summary>
        /// ����ļ���
        /// </summary>
        /// <param name="path">��ǰ·��</param>
        /// <param name="filename">�ļ�������</param>
        /// <returns></returns>

        public int AddDir(string path, string filename)
        {
            int result = 0;
            if (Directory.Exists(path + "\\" + filename))
            {
                throw new IOException("���ļ����Ѵ���!");
            }
            else
            {
                try
                {
                    Directory.CreateDirectory(path + "\\" + filename.Replace(".", ""));
                }
                catch (IOException e)
                {
                    throw new IOException(e.ToString());
                }
                result = 1;
            }
            return result;
        }
        /// <summary>
        /// ��ȡ��ǰĿ¼�ĸ�Ŀ¼
        /// </summary>
        /// <param name="path">��ǰĿ¼</param>
        /// <param name="temppath">��ǰ��ģ��Ŀ¼</param>
        /// <returns></returns>

        public string PathPre(string path, string temppath)
        {
            if (path != null)
            {
                int i, j;
                i = path.LastIndexOf(temppath);
                j = path.Length - i;
                path = path.Substring(i, j);
            }
            else
            {
                path = temppath;
            }
            return path;
        }

        /// <summary>
        /// �����ļ�
        /// </summary>
        /// <param name="path">·��</param>
        /// <param name="fileContent">�ļ�����</param>
        /// <returns></returns>

        public int saveFile(string path, string fileContent)
        {
            int result = 0;
            if (File.Exists(path))
            {
                try
                {
                    StreamWriter Fso = new StreamWriter(path);
                    Fso.WriteLine(fileContent);
                    Fso.Close();
                    Fso.Dispose();
                }
                catch (IOException e)
                {
                    throw new IOException(e.ToString());
                }
                result = 1;
            }
            else
            {
                throw new Exception("�ļ��Ѿ���ɾ��!");
            }
            return result;
        }

        /// <summary>
        /// ��ʾ�ļ�����
        /// </summary>
        /// <param name="path">�ļ�·��</param>
        /// <returns></returns>

        public string showFileContet(string path)
        {
            string str_content = "";
            if (File.Exists(path))
            {
                try
                {
                    StreamReader Fso = new StreamReader(path);
                    str_content = Fso.ReadToEnd();
                    Fso.Close();
                    Fso.Dispose();
                }
                catch (IOException e)
                {
                    throw new IOException(e.ToString());
                }
            }
            else
            {
                throw new Exception("�Ҳ�����Ӧ���ļ�!");
            }
            return str_content;
        }
    }    
}
