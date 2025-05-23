using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.Common;

namespace Pbzx.BLL
{
    /// <summary>
    /// 根据模板创建文件
    /// </summary>
    public class BTemplate
    {
        /// <summary>
        /// 获取模板内容
        /// </summary>
        /// <param name="TemplateFile">模板文件地址</param>
        /// <returns>模板内容,如果为null则地址出错</returns>
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
        /// 生成文件
        /// </summary>
        /// <param name="FilePath">文件地址</param>
        /// <param name="Content">文件内容</param>
        /// <returns>如果为false，路径不对或该文件已存在</returns>
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
        /// 删除文件
        /// </summary>
        /// <param name="FilePath">删除地址</param>
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
