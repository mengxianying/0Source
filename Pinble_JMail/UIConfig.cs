using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Configuration;

namespace JMailText
{
    public class UIConfig
    {

        #region 邮件配置
        public static string SmtpServerAddress = BaseConfig.GetConfigValue("SmtpServerAddress");
        public static string SmtpUserName = BaseConfig.GetConfigValue("SmtpUserName");
        public static string SmtpUserPwd = BaseConfig.GetConfigValue("SmtpUserPwd");
        public static string SmtpFromEmail = BaseConfig.GetConfigValue("SmtpFromEmail");

        public static string SmtpFromName = BaseConfig.GetConfigValue("SmtpFromName");
        public static int SmtpPort = int.Parse(BaseConfig.GetConfigValue("SmtpPort"));
        public static bool SmtpEnableSsl = false;
        #endregion

        public static string copyright = BaseConfig.GetConfigValue("copyRight");
        public static string titlemore = BaseConfig.GetConfigValue("titlemore");
        public static string commperPageNum = BaseConfig.GetConfigValue("commperPageNum");
        public static string splitPageCount = BaseConfig.GetConfigValue("splitPageCount");
        public static string enableAutoPage = BaseConfig.GetConfigValue("enableAutoPage");
        public static string titlenew = BaseConfig.GetConfigValue("titlenew");
       
        //增加连接是否弹出新窗口参数设置 开始
        public static string Linktagert = BaseConfig.GetConfigValue("Linktagert");
        public static string Linktagertimg = BaseConfig.GetConfigValue("Linktagertimg");
        //结束

        
       

        #region 刷新缓存
        /// <summary>
        /// 刷新缓存
        /// </summary>
        public static void RefurbishCatch()
        {
            UIConfig con = new UIConfig();

            SmtpServerAddress = con.getCatchParam("SmtpServerAddress");
            SmtpUserName = con.getCatchParam("SmtpUserName");
            SmtpUserPwd = con.getCatchParam("SmtpUserPwd");
            SmtpFromEmail = con.getCatchParam("SmtpFromEmail");
            SmtpFromName = con.getCatchParam("SmtpFromName");
            SmtpPort = int.Parse(con.getCatchParam("SmtpPort"));
            SmtpEnableSsl = bool.Parse(con.getCatchParam("SmtpEnableSsl"));

            copyright = con.getCatchParam("copyRight");
            titlemore = con.getCatchParam("titlemore");
            commperPageNum = con.getCatchParam("commperPageNum");
            splitPageCount = con.getCatchParam("splitPageCount");
            enableAutoPage = con.getCatchParam("enableAutoPage");
            titlenew = con.getCatchParam("titlenew");
        }
        /// <summary>
        /// 刷新缓存
        /// </summary>
        private string getCatchParam(string Target)
        {
            string path = HttpRuntime.AppDomainAppPath + "\\xml\\Pinble.config";
            System.Xml.XmlDocument xdoc = new XmlDocument();
            xdoc.Load(path);
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

        #endregion

 
    }
}