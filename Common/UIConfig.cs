using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Configuration;
using System.Web;

namespace Pbzx.Common
{
    public class UIConfig
    {
        #region ƴ������
        public static string WebDAL = ConfigurationManager.AppSettings["WebDAL"];
        public static string dataRe = ConfigurationManager.AppSettings["dataRe"];
        public static string mssql = ConfigurationManager.AppSettings["mssql"];
        //public static string CssPath = ConfigurationManager.AppSettings["manner"];
        public static string CssPath()
        {
            return BaseConfig.GetConfigValue("manner");
        }
       // public static string returnCopyRight = verConfig.isTryversion + verConfig.helpcenterStr + verConfig.ForumStr;
        public static string HeadTitle = BaseConfig.GetConfigValue("headTitle");
        public static string sHeight = BaseConfig.GetConfigValue("sHeight");
        public static string sWidth = BaseConfig.GetConfigValue("sWidth");
        public static string isLinkTF = BaseConfig.GetConfigValue("isLinkTF");
        public static string dirMana = BaseConfig.GetConfigValue("dirMana");
        public static string dirUser = BaseConfig.GetConfigValue("dirUser");
        public static string dirDumm = BaseConfig.GetConfigValue("dirDumm");
        public static string UserdirFile = BaseConfig.GetConfigValue("UserdirFile");
        public static string protPass = BaseConfig.GetConfigValue("protPass");
        public static string protRand = BaseConfig.GetConfigValue("protRand");
        public static string dirTemplet = BaseConfig.GetConfigValue("dirTemplet");
        public static string dirSite = BaseConfig.GetConfigValue("dirSite");
        public static string dirFile = BaseConfig.GetConfigValue("dirFile");
        public static string dirHtml = BaseConfig.GetConfigValue("dirHtml");
        public static string saveContent = BaseConfig.GetConfigValue("saveContent");
        public static string indeData = BaseConfig.GetConfigValue("indeData");
        public static string Logfilename = BaseConfig.GetConfigValue("Logfilename");
        public static string dirPige = BaseConfig.GetConfigValue("dirPige");
        public static string dirPigeDate = BaseConfig.GetConfigValue("dirPigeDate");
        public static string publicfreshinfo = BaseConfig.GetConfigValue("publicfreshinfo");
        public static string constPass = BaseConfig.GetConfigValue("constPass");
        public static string filePass = BaseConfig.GetConfigValue("filePass");
        public static string filePath = BaseConfig.GetConfigValue("filePath");
        public static string sqlConnData = BaseConfig.GetConfigValue("sqlConnData");

        #region �ʼ�����
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
        //ʱ�䣺2008-07-15 �޸��ߣ�����ӭ
        //���������Ƿ񵯳��´��ڲ������� ��ʼ
        public static string Linktagert = BaseConfig.GetConfigValue("Linktagert");
        public static string Linktagertimg = BaseConfig.GetConfigValue("Linktagertimg");
        //����

        
        /// <summary>
        /// ȫ�������Զ�ˢ��ʱ��
        /// </summary>
        /// date:2009-08-27�� ��
        public static string CpRefurbishTime = BaseConfig.GetConfigValue("CpRefurbishTime");

        /// <summary>
        /// ��ҳ���¹����Զ�ˢ��ʱ��
        /// </summary>
        /// date:2009-09-03�� ��
        public static string Bulletin_RefurbishTime = BaseConfig.GetConfigValue("Bulletin_RefurbishTime");


        #endregion


        #region ƴ��������

        /// <summary>
        /// ��վ����
        /// </summary>
        public static string WebTitle = BaseConfigAsk.GetConfigValue("WebTitle");
        /// <summary>
        /// �������ߺ󱻹���Աɾ�����۳��Ļ���
        /// </summary>
        public static string wenkf = BaseConfigAsk.GetConfigValue("wenkf");
        /// <summary>
        /// �ش����ߺ󱻹���Աɾ�����۳��Ļ���
        /// </summary>
        public static string dakf = BaseConfigAsk.GetConfigValue("dakf");
        /// <summary>
        /// �û��ش������߲���Ϊ��Ѵ����õĻ���
        /// </summary>
        public static string dajiadf = BaseConfigAsk.GetConfigValue("dajiadf");

        /// <summary>
        /// �û�ע��ʱ��õĻ���
        /// </summary>
        public static string regf = BaseConfigAsk.GetConfigValue("regf");
        /// <summary>
        /// �û��ش�һ���������õĻ���
        /// </summary>
        public static string dadf = BaseConfigAsk.GetConfigValue("dadf");

        /// <summary>
        /// ���ⱻѡΪ�����Ƽ����������õĻ���
        /// </summary>
        public static string tjwendf = BaseConfigAsk.GetConfigValue("tjwendf");
        /// <summary>
        /// ���ⱻѡΪ�����Ƽ���ѻش������õĻ���
        /// </summary>
        public static string tjdadf = BaseConfigAsk.GetConfigValue("tjdadf");
        /// <summary>
        /// �û����������������
        /// </summary>
        public static string mdf = BaseConfigAsk.GetConfigValue("mdf");

        /// <summary>
        /// ����15���ڲ��������۳��Ļ���
        /// </summary>
        public static string gqkf = BaseConfigAsk.GetConfigValue("gqkf");


        /// <summary>
        /// �����������
        /// </summary>
        public static string clwendf = BaseConfigAsk.GetConfigValue("clwendf");



        /// <summary>
        /// ���������Ϊ��������
        /// </summary>
        public static string OverTime = BaseConfigAsk.GetConfigValue("OverTime");


        #endregion



        public string snportpass()
        {
            return BaseConfig.GetConfigValue("portpass");
        }
        /// <summary>
        /// ȡ�ò�������ÿҳ��ʾ��¼������
        /// </summary>
        /// <returns>������ֵ��</returns>
        public static int GetPageSize()
        {

            int n = Convert.ToInt32(BaseConfig.GetConfigValue("PageSize"));
            if (n < 1)
                throw new Exception("ÿҳ��¼��������С��1!");
            return n;
        }

        #region ˢ�»���
        /// <summary>
        /// ˢ�»���
        /// </summary>
        public static void RefurbishCatch()
        {
            UIConfig con = new UIConfig();
            HeadTitle = con.getCatchParam("headTitle");
            sHeight = con.getCatchParam("sHeight");
            sWidth = con.getCatchParam("sWidth");
            isLinkTF = con.getCatchParam("isLinkTF");
            dirMana = con.getCatchParam("dirMana");
            dirUser = con.getCatchParam("dirUser");
            dirDumm = con.getCatchParam("dirDumm");
            UserdirFile = con.getCatchParam("UserdirFile");
            protPass = con.getCatchParam("protPass");
            protRand = con.getCatchParam("protRand");
            dirTemplet = con.getCatchParam("dirTemplet");
            dirSite = con.getCatchParam("dirSite");
            dirFile = con.getCatchParam("dirFile");
            dirHtml = con.getCatchParam("dirHtml");
            saveContent = con.getCatchParam("saveContent");
            indeData = con.getCatchParam("indeData");
            Logfilename = con.getCatchParam("Logfilename");
            dirPige = con.getCatchParam("dirPige");
            dirPigeDate = con.getCatchParam("dirPigeDate");
            publicfreshinfo = con.getCatchParam("publicfreshinfo");
            constPass = con.getCatchParam("constPass");
            filePass = con.getCatchParam("filePass");
            filePath = con.getCatchParam("filePath");
            sqlConnData = con.getCatchParam("sqlConnData");

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
        /// ˢ�»���
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

    /// <summary>
    /// ƴ�������ö�ȡ������
    /// </summary>
    public class BaseConfigAsk
    {
        /// <summary>
        /// �õ������ļ�
        /// </summary>
        /// <param name="Item"></param>
        /// <returns></returns>
        public static string getConfigParamvalue(string Item)
        {
            return string.Empty;
        }
        /// <summary>
        /// ��foosun.configȡ�����ļ�
        /// </summary>
        /// <param name="Target"></param>
        /// <returns></returns>
        static internal string GetConfigValue(string Target)
        {
            string path = HttpRuntime.AppDomainAppPath + "\\xml\\AskConfig.xml";
            return GetConfigValue(Target, path);
        }
        /// <summary>
        /// ��foosun.configȡ�����ļ�
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
