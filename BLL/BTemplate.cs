using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.Common;

namespace Pbzx.BLL
{
    /// <summary>
    /// ����ģ�崴���ļ�
    /// </summary>
    public class BTemplate
    {
        /// <summary>
        /// ��ȡģ������
        /// </summary>
        /// <param name="TemplateFile">ģ���ļ���ַ</param>
        /// <returns>ģ������,���Ϊnull���ַ����</returns>
        public string GetTemplateContent(string TemplatePath)
        {
            if (DirectoryFile.IsCreateFile(TemplatePath))
            {
                return DirectoryFile.ReadFile(TemplatePath);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// �����ļ�
        /// </summary>
        /// <param name="FilePath">�ļ���ַ</param>
        /// <param name="Content">�ļ�����</param>
        /// <returns>���Ϊfalse��·�����Ի���ļ��Ѵ���</returns>
        public bool CreateFile(string FilePath, string Content)
        {
            if (!DirectoryFile.IsCreateFile(FilePath))
            {
                try
                {
                    DirectoryFile.WriteFile(FilePath, Content);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
            {
                if (DeleteFile(FilePath))
                {
                    DirectoryFile.WriteFile(FilePath, Content);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// ɾ���ļ�
        /// </summary>
        /// <param name="FilePath">ɾ����ַ</param>
        public bool DeleteFile(string FilePath)
        {
            if (DirectoryFile.IsCreateFile(FilePath))
            {
                try
                {
                    DirectoryFile.FileDel(FilePath);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }




    }
}
