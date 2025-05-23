﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace JMailText
{
    public class BaseConfig
    {
        /// <summary>
        /// 得到配置文件
        /// </summary>
        /// <param name="Item"></param>
        /// <returns></returns>
        public static string getConfigParamvalue(string Item)
        {
            return string.Empty;
        }
        /// <summary>
        /// 读foosun.config取配置文件
        /// </summary>
        /// <param name="Target"></param>
        /// <returns></returns>
        static internal string GetConfigValue(string Target)
        {
            string currentLJ = HttpRuntime.AppDomainAppPath;
            string path = currentLJ + "\\xml\\Pinble.config";
            return GetConfigValue(Target, path);
        }
        /// <summary>
        /// 读foosun.config取配置文件
        /// </summary>
        /// <param name="Target"></param>
        /// <param name="ConfigPathName"></param>
        /// <returns></returns>
        static internal string GetConfigValue(string Target, string XmlPath)
        {
            System.Xml.XmlDocument xdoc = new XmlDocument();
            xdoc.Load(XmlPath);
            XmlElement root = xdoc.DocumentElement;
            XmlNodeList elemList = root.GetElementsByTagName(Target);
            try
            {
                return elemList[0].InnerText;
            }
            catch
            {
                return null;
            }
        }
    }
}