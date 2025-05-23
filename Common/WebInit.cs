using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Web;

namespace Pbzx.Common
{
    public class WebInit
    {

        /// <summary>
        /// 文件目录设置
        /// </summary>
        private static WebFolderConfig _webFolderConfig;

        private static string currentLJ = HttpRuntime.AppDomainAppPath;
        private static string currentXU = HttpRuntime.AppDomainAppVirtualPath;
        /// <summary>
        /// 文件目录设置
        /// </summary>
        public static WebFolderConfig webFolderConfig
        {
            get
            {

                XmlDocument XmlDoc;
                XmlNodeList NodeList;
                XmlDoc = new XmlDocument();
                XmlDoc.Load(currentLJ + "\\XML\\WebConfig.xml");
                NodeList = XmlDoc.GetElementsByTagName("ArticleUrl");
                _webFolderConfig.ArticleUrl = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("BulletinUrl");
                _webFolderConfig.BulletinUrl = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("BulletinUrl");
                _webFolderConfig.BulletinUrl = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("JSUrl");
                _webFolderConfig.JSUrl = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("SpecialUrl");
                _webFolderConfig.SpecialUrl = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("TemplateUrl");
                _webFolderConfig.TemplateUrl = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("UpfileUrl");
                _webFolderConfig.UpfileUrl = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("UpModiaUrl");
                _webFolderConfig.UpModiaUrl = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("UpPhotoUrl");
                _webFolderConfig.UpPhotoUrl = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("UserUrl");
                _webFolderConfig.UserUrl = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("SchoolUrl");
                _webFolderConfig.SchoolUrl = NodeList[0].Attributes["value"].Value;

                return _webFolderConfig;
            }
            set
            {
                XmlDocument XmlDoc;
                XmlNodeList NodeList;
                XmlDoc = new XmlDocument();
                XmlDoc.Load(currentLJ + "\\XML\\WebConfig.xml");

                NodeList = XmlDoc.GetElementsByTagName("ArticleUrl");
                NodeList[0].Attributes["value"].Value = value.ArticleUrl;//BulletinUrl

                NodeList = XmlDoc.GetElementsByTagName("BulletinUrl");
                NodeList[0].Attributes["value"].Value = value.BulletinUrl;//BulletinUrl

                NodeList = XmlDoc.GetElementsByTagName("JSUrl");
                NodeList[0].Attributes["value"].Value = value.JSUrl;

                NodeList = XmlDoc.GetElementsByTagName("SpecialUrl");
                NodeList[0].Attributes["value"].Value = value.SpecialUrl;

                NodeList = XmlDoc.GetElementsByTagName("TemplateUrl");
                NodeList[0].Attributes["value"].Value = value.TemplateUrl.ToString();

                NodeList = XmlDoc.GetElementsByTagName("UpfileUrl");
                NodeList[0].Attributes["value"].Value = value.UpfileUrl;

                NodeList = XmlDoc.GetElementsByTagName("UpModiaUrl");
                NodeList[0].Attributes["value"].Value = value.UpModiaUrl;

                NodeList = XmlDoc.GetElementsByTagName("UpPhotoUrl");
                NodeList[0].Attributes["value"].Value = value.UpPhotoUrl;

                NodeList = XmlDoc.GetElementsByTagName("UserUrl");
                NodeList[0].Attributes["value"].Value = value.UserUrl;

                NodeList = XmlDoc.GetElementsByTagName("SchoolUrl");
                NodeList[0].Attributes["value"].Value = value.SchoolUrl;

                XmlDoc.Save(currentLJ + "\\XML\\WebConfig.xml");
            }
        }

        /// <summary>
        /// 系统基本信息
        /// </summary>
        private static WebBaseConfig _webBaseConfig;
        /// <summary>
        /// 系统基本信息
        /// </summary>
        public static WebBaseConfig webBaseConfig
        {
            get
            {
                XmlDocument XmlDoc;
                XmlNodeList NodeList;
                XmlDoc = new XmlDocument();



                XmlDoc.Load(currentLJ + "\\Xml\\WebConfig.xml");
                NodeList = XmlDoc.GetElementsByTagName("WebName");
                _webBaseConfig.WebName = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("WebTitle");
                _webBaseConfig.WebTitle = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("WebUrl");
                _webBaseConfig.WebUrl = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("Copyright");
                _webBaseConfig.Copyright = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("WebKey");
                _webBaseConfig.WebKey = NodeList[0].Attributes["value"].Value;


                NodeList = XmlDoc.GetElementsByTagName("Buy");
                _webBaseConfig.Buy = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("WebDescription");
                _webBaseConfig.WebDescription = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("WebPageNum");
                _webBaseConfig.WebPageNum = Convert.ToInt32(NodeList[0].Attributes["value"].Value);

                NodeList = XmlDoc.GetElementsByTagName("WebPageNum2");
                _webBaseConfig.WebPageNum2 = Convert.ToInt32(NodeList[0].Attributes["value"].Value);



                NodeList = XmlDoc.GetElementsByTagName("PaginAtion");
                _webBaseConfig.PaginAtion = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("BackCssStyleUrl");
                _webBaseConfig.BackCssStyleUrl = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("ArticleOverDue");
                _webBaseConfig.ArticleOverDue = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("LeachInfo");
                _webBaseConfig.LeachInfo = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("HitsOfHot");
                _webBaseConfig.HitsOfHot = int.Parse(NodeList[0].Attributes["value"].Value);

                NodeList = XmlDoc.GetElementsByTagName("SoftdogPrice");
                _webBaseConfig.SoftdogPrice = decimal.Parse(NodeList[0].Attributes["value"].Value);

                NodeList = XmlDoc.GetElementsByTagName("Days");
                _webBaseConfig.Days = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("PopSoftClassCol");
                _webBaseConfig.PopSoftClassCol = int.Parse(NodeList[0].Attributes["value"].Value);

                NodeList = XmlDoc.GetElementsByTagName("Encoding");
                _webBaseConfig.Encoding = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("ChatUrl");
                _webBaseConfig.ChatUrl = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("Express");
                _webBaseConfig.Express = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("Nslide");
                _webBaseConfig.Nslide = int.Parse(NodeList[0].Attributes["value"].Value);

                NodeList = XmlDoc.GetElementsByTagName("YearStart");
                _webBaseConfig.YearStart = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("YearEnd");
                _webBaseConfig.YearEnd = NodeList[0].Attributes["value"].Value;


                NodeList = XmlDoc.GetElementsByTagName("UserGet");
                _webBaseConfig.UserGet = decimal.Parse(NodeList[0].Attributes["value"].Value);


                NodeList = XmlDoc.GetElementsByTagName("IP_ValideCode_Count");
                _webBaseConfig.IP_ValideCode_Count = int.Parse(NodeList[0].Attributes["value"].Value);

                NodeList = XmlDoc.GetElementsByTagName("DowloadTips");
                _webBaseConfig.DowloadTips = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("FirstPageTcodeDisp");
                _webBaseConfig.FirstPageTcodeDisp = NodeList[0].Attributes["value"].Value;

                return _webBaseConfig;
            }
            set
            {
                XmlDocument XmlDoc;
                XmlNodeList NodeList;
                XmlDoc = new XmlDocument();
                XmlDoc.Load(currentLJ + "\\Xml\\WebConfig.xml");

                NodeList = XmlDoc.GetElementsByTagName("WebName");
                NodeList[0].Attributes["value"].Value = value.WebName;

                NodeList = XmlDoc.GetElementsByTagName("WebTitle");
                NodeList[0].Attributes["value"].Value = value.WebTitle;

                NodeList = XmlDoc.GetElementsByTagName("WebUrl");
                NodeList[0].Attributes["value"].Value = value.WebUrl;

                NodeList = XmlDoc.GetElementsByTagName("Copyright");
                NodeList[0].Attributes["value"].Value = value.Copyright;

                NodeList = XmlDoc.GetElementsByTagName("WebPageNum");
                NodeList[0].Attributes["value"].Value = value.WebPageNum.ToString();



                NodeList = XmlDoc.GetElementsByTagName("Buy");
                NodeList[0].Attributes["value"].Value = value.Buy.ToString();

                NodeList = XmlDoc.GetElementsByTagName("WebPageNum2");
                NodeList[0].Attributes["value"].Value = value.WebPageNum2.ToString();

                NodeList = XmlDoc.GetElementsByTagName("PaginAtion");
                NodeList[0].Attributes["value"].Value = value.PaginAtion;

                NodeList = XmlDoc.GetElementsByTagName("BackCssStyleUrl");
                NodeList[0].Attributes["value"].Value = value.BackCssStyleUrl;

                NodeList = XmlDoc.GetElementsByTagName("ArticleOverDue");
                NodeList[0].Attributes["value"].Value = value.ArticleOverDue;

                NodeList = XmlDoc.GetElementsByTagName("LeachInfo");
                NodeList[0].Attributes["value"].Value = value.LeachInfo;

                NodeList = XmlDoc.GetElementsByTagName("HitsOfHot");
                NodeList[0].Attributes["value"].Value = value.HitsOfHot.ToString();

                NodeList = XmlDoc.GetElementsByTagName("SoftdogPrice");
                NodeList[0].Attributes["value"].Value = value.SoftdogPrice.ToString();


                NodeList = XmlDoc.GetElementsByTagName("Days");
                NodeList[0].Attributes["value"].Value = value.Days;

                NodeList = XmlDoc.GetElementsByTagName("PopSoftClassCol");
                NodeList[0].Attributes["value"].Value = value.PopSoftClassCol.ToString();

                NodeList = XmlDoc.GetElementsByTagName("Encoding");
                NodeList[0].Attributes["value"].Value = value.Encoding;

                NodeList = XmlDoc.GetElementsByTagName("ChatUrl");
                NodeList[0].Attributes["value"].Value = value.ChatUrl;

                NodeList = XmlDoc.GetElementsByTagName("Express");
                NodeList[0].Attributes["value"].Value = value.Express;

                NodeList = XmlDoc.GetElementsByTagName("Nslide");
                NodeList[0].Attributes["value"].Value = value.Nslide.ToString();

                NodeList = XmlDoc.GetElementsByTagName("YearStart");
                NodeList[0].Attributes["value"].Value = value.YearStart;

                NodeList = XmlDoc.GetElementsByTagName("YearEnd");
                NodeList[0].Attributes["value"].Value = value.YearEnd;

                NodeList = XmlDoc.GetElementsByTagName("UserGet");
                NodeList[0].Attributes["value"].Value = value.UserGet.ToString();

                NodeList = XmlDoc.GetElementsByTagName("IP_ValideCode_Count");
                NodeList[0].Attributes["value"].Value = value.IP_ValideCode_Count.ToString();

                NodeList = XmlDoc.GetElementsByTagName("DowloadTips");
                NodeList[0].Attributes["value"].Value = value.DowloadTips;

                NodeList = XmlDoc.GetElementsByTagName("FirstPageTcodeDisp");
                NodeList[0].Attributes["value"].Value = value.FirstPageTcodeDisp.ToString();


                XmlDoc.Save(currentLJ + "\\Xml\\WebConfig.xml");
            }
        }


        ///// <summary>
        ///// 各种彩票缓存时间信息
        ///// </summary>
        //private static WebCpSort _webCpSort;

        ///// <summary>
        ///// 各种彩票缓存时间信息
        ///// </summary>
        //public static WebCpSort webCpSort
        //{
        //    get
        //    {
        //        XmlDocument XmlDoc;
        //        XmlNodeList NodeList;
        //        XmlDoc = new XmlDocument();

        //        XmlDoc.Load(currentLJ + "\\Xml\\CpSortTime.xml");
        //        NodeList = XmlDoc.GetElementsByTagName("FC3DData");
        //        _webCpSort.FC3DData = NodeList[0].Attributes["value"].Value;

        //        NodeList = XmlDoc.GetElementsByTagName("FC_3DTest");
        //        _webCpSort.FC_3DTest = NodeList[0].Attributes["value"].Value;
        //        return _webCpSort;
        //    }
        //    set
        //    {
        //        XmlDocument XmlDoc;
        //        XmlNodeList NodeList;
        //        XmlDoc = new XmlDocument();
        //        XmlDoc.Load(currentLJ + "\\Xml\\CpSortTime.xml");

        //        NodeList = XmlDoc.GetElementsByTagName("FC3DData");
        //        NodeList[0].Attributes["value"].Value = value.FC3DData;

        //        NodeList = XmlDoc.GetElementsByTagName("FC_3DTest");
        //        NodeList[0].Attributes["value"].Value = value.FC_3DTest;               
        //    }
        //}

        #region 根据是否反回名称

        /// <summary>
        /// 根据是否标志反回名称
        /// </summary>
        /// <param name="flag">是否标志</param>
        /// <param name="TrueName">为真时的名称</param>
        /// <param name="FalseName">为假时的名称</param>
        /// <returns>返回的名称</returns>
        public static string GetNameByFlag(bool flag, string TrueName, string FalseName)
        {
            try
            {

                if (flag)
                {
                    return TrueName;
                }
                else
                {
                    return FalseName;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        /// <summary>
        /// 用户设置
        /// 时间：2009-7-27
        /// </summary>
        private static UserConfig _userConfig;

        /// <summary>
        /// 用户设置
        /// </summary>
        public static UserConfig userConfig
        {
            get
            {
                XmlDocument XmlDoc;
                XmlNodeList NodeList;
                XmlDoc = new XmlDocument();
                XmlDoc.Load(currentLJ + "\\XML\\WebConfig.xml");

                NodeList = XmlDoc.GetElementsByTagName("UserNameMin");
                _userConfig.UserNameMin = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("UserNameLong");
                _userConfig.UserNameLong = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("PassWordMin");
                _userConfig.PassWordMin = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("PassWordLong");
                _userConfig.PassWordLong = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("OnLoginNum");
                _userConfig.OnLoginNum = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("Facefile");
                _userConfig.Facefile = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("IsSendEmail");
                _userConfig.IsSendEmail = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("OnLineTime");
                _userConfig.OnLineTime = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("FolderSpace");
                _userConfig.FolderSpace = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("PassWordQuestion");
                _userConfig.PassWordQuestion = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("UnUserName");
                _userConfig.UnUserName = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("PersonRegeditAgreement");
                _userConfig.PersonRegeditAgreement = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("PersonRegeditAgreementGao");
                _userConfig.PersonRegeditAgreementGao = NodeList[0].Attributes["value"].Value;


                NodeList = XmlDoc.GetElementsByTagName("BrokerAgreement");
                _userConfig.BrokerAgreement = NodeList[0].Attributes["value"].Value;


                NodeList = XmlDoc.GetElementsByTagName("AgentAgreement");
                _userConfig.AgentAgreement = NodeList[0].Attributes["value"].Value;



                NodeList = XmlDoc.GetElementsByTagName("Banks");
                _userConfig.Banks = NodeList[0].Attributes["value"].Value;

                return _userConfig;
            }
            set
            {
                XmlDocument XmlDoc;
                XmlNodeList NodeList;
                XmlDoc = new XmlDocument();
                XmlDoc.Load(currentLJ + "\\XML\\WebConfig.xml");

                NodeList = XmlDoc.GetElementsByTagName("UserNameMin");
                NodeList[0].Attributes["value"].Value = value.UserNameMin;

                NodeList = XmlDoc.GetElementsByTagName("UserNameLong");
                NodeList[0].Attributes["value"].Value = value.UserNameLong;

                NodeList = XmlDoc.GetElementsByTagName("PassWordMin");
                NodeList[0].Attributes["value"].Value = value.PassWordMin;

                NodeList = XmlDoc.GetElementsByTagName("PassWordLong");
                NodeList[0].Attributes["value"].Value = value.PassWordLong;

                NodeList = XmlDoc.GetElementsByTagName("OnLoginNum");
                NodeList[0].Attributes["value"].Value = value.OnLoginNum;

                NodeList = XmlDoc.GetElementsByTagName("Facefile");
                NodeList[0].Attributes["value"].Value = value.Facefile;

                NodeList = XmlDoc.GetElementsByTagName("IsSendEmail");
                NodeList[0].Attributes["value"].Value = value.IsSendEmail;

                NodeList = XmlDoc.GetElementsByTagName("OnLineTime");
                NodeList[0].Attributes["value"].Value = value.OnLineTime;

                NodeList = XmlDoc.GetElementsByTagName("FolderSpace");
                NodeList[0].Attributes["value"].Value = value.FolderSpace;

                NodeList = XmlDoc.GetElementsByTagName("PassWordQuestion");
                NodeList[0].Attributes["value"].Value = value.PassWordQuestion;

                NodeList = XmlDoc.GetElementsByTagName("UnUserName");
                NodeList[0].Attributes["value"].Value = value.UnUserName;

                NodeList = XmlDoc.GetElementsByTagName("PersonRegeditAgreement");
                NodeList[0].Attributes["value"].Value = value.PersonRegeditAgreement;

                NodeList = XmlDoc.GetElementsByTagName("PersonRegeditAgreementGao");
                NodeList[0].Attributes["value"].Value = value.PersonRegeditAgreementGao;

                NodeList = XmlDoc.GetElementsByTagName("BrokerAgreement");
                NodeList[0].Attributes["value"].Value = value.BrokerAgreement;

                NodeList = XmlDoc.GetElementsByTagName("AgentAgreement");
                NodeList[0].Attributes["value"].Value = value.AgentAgreement;

                NodeList = XmlDoc.GetElementsByTagName("Banks");
                NodeList[0].Attributes["value"].Value = value.Banks;

                XmlDoc.Save(HttpContext.Current.Server.MapPath("~/XML/WebConfig.xml"));
            }
        }

        /// <summary>
        /// 彩票超市设置
        /// 创建人: zhouwei
        /// 创建时间: 2010-11-9
        /// </summary>
        private static Market _market;


        public static Market market
        {
            get
            {
                XmlDocument XmlDoc;
                XmlDoc = new XmlDocument();
                XmlDoc.Load(currentLJ + "\\Xml\\WebConfig.xml");

                //获取彩票超市配置的名称
                _market.WebName = XmlDoc.SelectSingleNode("root/Market/WebName").Attributes["value"].Value;

                //获取配置标题
                _market.WebTitle = XmlDoc.SelectSingleNode("root/Market/WebTitle").Attributes["value"].Value;

                //获取配置的路径 http://Market.pinble2.com
                _market.WebUrl = XmlDoc.SelectSingleNode("root/Market/WebUrl").Attributes["value"].Value;

                //版权所有
                _market.Copyright = XmlDoc.SelectSingleNode("root/Market/Copyright").Attributes["value"].Value;

                //关键字
                _market.WebKey = XmlDoc.SelectSingleNode("root/Market/WebKey").Attributes["value"].Value;

                //说明
                _market.WebDescription = XmlDoc.SelectSingleNode("root/Market/WebDescription").Attributes["value"].Value;

                //每页显示的条数
                _market.WebPageNum = Convert.ToInt32(XmlDoc.SelectSingleNode("root/Market/WebPageNum").Attributes["value"].Value);

                return _market;


            }
        }

        /// <summary>
        /// 合买代购平台设置
        /// 创建人：周伟
        /// 创建时间：2011-2-15
        /// </summary>
        private static tobuy _tobuy;

        public static tobuy tobuy
        {
            get
            {
                XmlDocument XmlDoc;
                XmlDoc = new XmlDocument();
                XmlDoc.Load(currentLJ + "\\Xml\\WebConfig.xml");

                //获取彩票超市配置的名称
                _tobuy.WebName = XmlDoc.SelectSingleNode("root/tobuy/WebName").Attributes["value"].Value;

                //获取配置标题
                _tobuy.WebTitle = XmlDoc.SelectSingleNode("root/tobuy/WebTitle").Attributes["value"].Value;

                //获取配置的路径 http://tobuy.pinble2.com
                _tobuy.WebUrl = XmlDoc.SelectSingleNode("root/tobuy/WebUrl").Attributes["value"].Value;

                //版权所有
                _tobuy.Copyright = XmlDoc.SelectSingleNode("root/tobuy/Copyright").Attributes["value"].Value;

                //关键字
                _tobuy.WebKey = XmlDoc.SelectSingleNode("root/tobuy/WebKey").Attributes["value"].Value;

                //说明
                _tobuy.WebDescription = XmlDoc.SelectSingleNode("root/tobuy/WebDescription").Attributes["value"].Value;


                return _tobuy;


            }
        }

        /// <summary>
        /// 拼搏擂台平台设置
        /// 创建人：周伟
        /// 创建时间：2011-6-1
        /// </summary>
        private static match _match;

        public static match match
        {
            get
            {
                XmlDocument XmlDoc;
                XmlDoc = new XmlDocument();
                XmlDoc.Load(currentLJ + "\\Xml\\WebConfig.xml");

                //获取彩票超市配置的名称
                _match.WebName = XmlDoc.SelectSingleNode("root/match/WebName").Attributes["value"].Value;

                //获取配置标题
                _match.WebTitle = XmlDoc.SelectSingleNode("root/match/WebTitle").Attributes["value"].Value;

                //获取配置的路径 http://Challenge.pinble2.com
                _match.WebUrl = XmlDoc.SelectSingleNode("root/match/WebUrl").Attributes["value"].Value;

                //版权所有
                _match.Copyright = XmlDoc.SelectSingleNode("root/match/Copyright").Attributes["value"].Value;

                //关键字
                _match.WebKey = XmlDoc.SelectSingleNode("root/match/WebKey").Attributes["value"].Value;

                //说明
                _match.WebDescription = XmlDoc.SelectSingleNode("root/match/WebDescription").Attributes["value"].Value;


                return _match;


            }
        }
        /// <summary>
        /// 大底比拼平台设置
        /// 创建人：周伟
        /// 创建时间：2011-6-1
        /// </summary>
        private static num _num;

        public static num num
        {
            get
            {
                XmlDocument XmlDoc;
                XmlDoc = new XmlDocument();
                XmlDoc.Load(currentLJ + "\\Xml\\WebConfig.xml");

                //获取彩票超市配置的名称
                _num.WebName = XmlDoc.SelectSingleNode("root/num/WebName").Attributes["value"].Value;

                //获取配置标题
                _num.WebTitle = XmlDoc.SelectSingleNode("root/num/WebTitle").Attributes["value"].Value;

                //获取配置的路径 http://DataRivalry.pinble2.com
                _num.WebUrl = XmlDoc.SelectSingleNode("root/num/WebUrl").Attributes["value"].Value;

                //版权所有
                _num.Copyright = XmlDoc.SelectSingleNode("root/num/Copyright").Attributes["value"].Value;

                //关键字
                _num.WebKey = XmlDoc.SelectSingleNode("root/num/WebKey").Attributes["value"].Value;

                //说明
                _num.WebDescription = XmlDoc.SelectSingleNode("root/num/WebDescription").Attributes["value"].Value;


                return _num;


            }
        }

        /// <summary>
        /// 短信平台设置
        /// 创建人：周伟
        /// 创建时间：2011-6-1
        /// </summary>
        private static sms _sms;

        public static sms sms
        {
            get
            {
                XmlDocument XmlDoc;
                XmlDoc = new XmlDocument();
                XmlDoc.Load(currentLJ + "\\Xml\\WebConfig.xml");

                //获取彩票超市配置的名称
                _sms.WebName = XmlDoc.SelectSingleNode("root/sms/WebName").Attributes["value"].Value;

                //获取配置标题
                _sms.WebTitle = XmlDoc.SelectSingleNode("root/sms/WebTitle").Attributes["value"].Value;

                //获取配置的路径 http://sms.pinble2.com
                _sms.WebUrl = XmlDoc.SelectSingleNode("root/sms/WebUrl").Attributes["value"].Value;

                //版权所有
                _sms.Copyright = XmlDoc.SelectSingleNode("root/sms/Copyright").Attributes["value"].Value;

                //关键字
                _sms.WebKey = XmlDoc.SelectSingleNode("root/sms/WebKey").Attributes["value"].Value;

                //说明
                _sms.WebDescription = XmlDoc.SelectSingleNode("root/sms/WebDescription").Attributes["value"].Value;


                return _sms;


            }
        }


        /// <summary>
        /// 拼搏吧xml设置
        /// </summary>
        private static Ask _ask;

        /// <summary>WebUrl
        /// 拼搏吧xml设置
        /// </summary>
        public static Ask ask
        {
            get
            {
                XmlDocument XmlDoc;
                XmlDoc = new XmlDocument();

                XmlDoc.Load(currentLJ + "\\Xml\\WebConfig.xml");

                _ask.WebName = XmlDoc.SelectSingleNode("root/Ask/WebName").Attributes["value"].Value;

                _ask.WebTitle = XmlDoc.SelectSingleNode("root/Ask/WebTitle").Attributes["value"].Value;

                _ask.WebUrl = XmlDoc.SelectSingleNode("root/Ask/WebUrl").Attributes["value"].Value;

                _ask.Copyright = XmlDoc.SelectSingleNode("root/Ask/Copyright").Attributes["value"].Value;

                _ask.WebKey = XmlDoc.SelectSingleNode("root/Ask/WebKey").Attributes["value"].Value;

                _ask.WebDescription = XmlDoc.SelectSingleNode("root/Ask/WebDescription").Attributes["value"].Value;

                _ask.WebPageNum = Convert.ToInt32(XmlDoc.SelectSingleNode("root/Ask/WebPageNum").Attributes["value"].Value);

                _ask.AskHighLargessPoint = int.Parse(XmlDoc.SelectSingleNode("root/Ask/AskHighLargessPoint").Attributes["value"].Value);
                return _ask;
            }
            //set
            //{
            //    XmlDocument XmlDoc;
            //    XmlNodeList NodeList;
            //    XmlDoc = new XmlDocument();
            //    XmlDoc.Load(HttpContext.Current.Server.MapPath("~/Xml/WebConfig.xml"));
            //    NodeList = XmlDoc.GetElementsByTagName("WebName");
            //    NodeList[0].Attributes["value"].Value = value.WebName;

            //    NodeList = XmlDoc.GetElementsByTagName("WebTitle");
            //    NodeList[0].Attributes["value"].Value = value.WebTitle;

            //    NodeList = XmlDoc.GetElementsByTagName("WebUrl");
            //    NodeList[0].Attributes["value"].Value = value.WebUrl;

            //    NodeList = XmlDoc.GetElementsByTagName("Copyright");
            //    NodeList[0].Attributes["value"].Value = value.Copyright;


            //    NodeList = XmlDoc.GetElementsByTagName("WebPageNum");
            //    NodeList[0].Attributes["value"].Value = value.WebPageNum.ToString();

            //    NodeList = XmlDoc.GetElementsByTagName("AskHighLargessPoint");
            //    NodeList[0].Attributes["value"].Value = value.AskHighLargessPoint.ToString();

            //}
        }


        /// <summary>
        /// 页面显示配置xml设置
        /// </summary>
        private static PageConfig _pageConfig;

        /// <summary>
        ///页面显示配置xml设置
        /// </summary>
        public static PageConfig pageConfig
        {
            get
            {
                XmlDocument XmlDoc;
                XmlNodeList NodeList;
                XmlDoc = new XmlDocument();
                XmlDoc.Load(currentLJ + "\\Xml\\WebConfig.xml");
                ////首页
                NodeList = XmlDoc.GetElementsByTagName("IndexNewsCount");
                _pageConfig.IndexNewsCount = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("IndexBulletinCount");
                _pageConfig.IndexBulletinCount = NodeList[0].Attributes["value"].Value;


                NodeList = XmlDoc.GetElementsByTagName("IndexNewUpdateProduct");
                _pageConfig.IndexNewUpdateProduct = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("IndexNewUpdateSoft");
                _pageConfig.IndexNewUpdateSoft = NodeList[0].Attributes["value"].Value;


                NodeList = XmlDoc.GetElementsByTagName("IndexSoft");
                _pageConfig.IndexSoft = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("IndexSchool");
                _pageConfig.IndexSchool = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("IndexBar");
                _pageConfig.IndexBar = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("IndexBbs");
                _pageConfig.IndexBbs = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("IndexLinkCount");
                _pageConfig.IndexLinkCount = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("IndexLinkCountPic");
                _pageConfig.IndexLinkCountPic = NodeList[0].Attributes["value"].Value;

                ////公告
                NodeList = XmlDoc.GetElementsByTagName("BulletinTypeCount");
                _pageConfig.BulletinTypeCount = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("BulletinNewUpdateCount");
                _pageConfig.BulletinNewUpdateCount = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("BulletinNewHotCount");
                _pageConfig.BulletinNewHotCount = NodeList[0].Attributes["value"].Value;

                ////资讯
                NodeList = XmlDoc.GetElementsByTagName("NewsTypeCount");
                _pageConfig.NewsTypeCount = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("NewsNewUpdateCount");
                _pageConfig.NewsNewUpdateCount = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("NewsNewHotCount");
                _pageConfig.NewsNewHotCount = NodeList[0].Attributes["value"].Value;


                ////学院
                NodeList = XmlDoc.GetElementsByTagName("ScholTypeCount");
                _pageConfig.ScholTypeCount = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("ScholHotCount");
                _pageConfig.ScholHotCount = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("ScholCenterList");
                _pageConfig.ScholCenterList = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("Scholsoft");
                _pageConfig.Scholsoft = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("Scholsoure");
                _pageConfig.Scholsoure = NodeList[0].Attributes["value"].Value;

                ////频道条数公告设置

                NodeList = XmlDoc.GetElementsByTagName("BrokerBulletin");
                _pageConfig.BrokerBulletin = NodeList[0].Attributes["value"].Value;

                ////软件内嵌
                NodeList = XmlDoc.GetElementsByTagName("SoftLength");
                _pageConfig.SoftLength = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("SoftCount");
                _pageConfig.SoftCount = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("CstLength");
                _pageConfig.CstLength = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("CstCount");
                _pageConfig.CstCount = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("Softlength");
                _pageConfig.Softlength = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("Softlie");
                _pageConfig.Softlie = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("Softxzlength");
                _pageConfig.Softxzlength = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("Softxzlie");
                _pageConfig.Softxzlie = NodeList[0].Attributes["value"].Value;


                NodeList = XmlDoc.GetElementsByTagName("SoftMlength");
                _pageConfig.SoftMlength = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("SoftMlie");
                _pageConfig.SoftMlie = NodeList[0].Attributes["value"].Value;


                NodeList = XmlDoc.GetElementsByTagName("Sourcelegth");
                _pageConfig.Sourcelegth = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("Sourcelie");
                _pageConfig.Sourcelie = NodeList[0].Attributes["value"].Value;


                NodeList = XmlDoc.GetElementsByTagName("Sourcecountlegth");
                _pageConfig.Sourcecountlegth = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("Sourcecountlie");
                _pageConfig.Sourcecountlie = NodeList[0].Attributes["value"].Value;


                NodeList = XmlDoc.GetElementsByTagName("SourceMlegth");
                _pageConfig.SourceMlegth = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("SourceMlie");
                _pageConfig.SourceMlie = NodeList[0].Attributes["value"].Value;
                return _pageConfig;
            }
            set
            {
                XmlDocument XmlDoc;
                XmlNodeList NodeList;
                XmlDoc = new XmlDocument();
                XmlDoc.Load(HttpContext.Current.Server.MapPath("~/Xml/WebConfig.xml"));

                ////首页
                NodeList = XmlDoc.GetElementsByTagName("IndexNewsCount");
                NodeList[0].Attributes["value"].Value = value.IndexNewsCount;

                NodeList = XmlDoc.GetElementsByTagName("IndexBulletinCount");
                NodeList[0].Attributes["value"].Value = value.IndexBulletinCount;

                NodeList = XmlDoc.GetElementsByTagName("IndexNewUpdateProduct");
                NodeList[0].Attributes["value"].Value = value.IndexNewUpdateProduct;

                NodeList = XmlDoc.GetElementsByTagName("IndexNewUpdateSoft");
                NodeList[0].Attributes["value"].Value = value.IndexNewUpdateSoft;

                NodeList = XmlDoc.GetElementsByTagName("IndexSoft");
                NodeList[0].Attributes["value"].Value = value.IndexSoft;

                NodeList = XmlDoc.GetElementsByTagName("IndexSchool");
                NodeList[0].Attributes["value"].Value = value.IndexSchool;

                NodeList = XmlDoc.GetElementsByTagName("IndexBar");
                NodeList[0].Attributes["value"].Value = value.IndexBar;

                NodeList = XmlDoc.GetElementsByTagName("IndexBbs");
                NodeList[0].Attributes["value"].Value = value.IndexBbs;

                NodeList = XmlDoc.GetElementsByTagName("IndexLinkCount");
                NodeList[0].Attributes["value"].Value = value.IndexLinkCount;

                NodeList = XmlDoc.GetElementsByTagName("IndexLinkCountPic");
                NodeList[0].Attributes["value"].Value = value.IndexLinkCountPic;

                ////公告
                NodeList = XmlDoc.GetElementsByTagName("BulletinTypeCount");
                NodeList[0].Attributes["value"].Value = value.BulletinTypeCount;

                NodeList = XmlDoc.GetElementsByTagName("BulletinNewUpdateCount");
                NodeList[0].Attributes["value"].Value = value.BulletinNewUpdateCount;

                NodeList = XmlDoc.GetElementsByTagName("BulletinNewHotCount");
                NodeList[0].Attributes["value"].Value = value.BulletinNewHotCount;

                ////资讯
                NodeList = XmlDoc.GetElementsByTagName("NewsTypeCount");
                NodeList[0].Attributes["value"].Value = value.NewsTypeCount;

                NodeList = XmlDoc.GetElementsByTagName("NewsNewUpdateCount");
                NodeList[0].Attributes["value"].Value = value.NewsNewUpdateCount;

                NodeList = XmlDoc.GetElementsByTagName("NewsNewHotCount");
                NodeList[0].Attributes["value"].Value = value.NewsNewHotCount;


                ////学院

                NodeList = XmlDoc.GetElementsByTagName("ScholTypeCount");
                NodeList[0].Attributes["value"].Value = value.ScholTypeCount;

                NodeList = XmlDoc.GetElementsByTagName("ScholHotCount");
                NodeList[0].Attributes["value"].Value = value.ScholHotCount;

                NodeList = XmlDoc.GetElementsByTagName("ScholCenterList");
                NodeList[0].Attributes["value"].Value = value.ScholCenterList;

                NodeList = XmlDoc.GetElementsByTagName("Scholsoft");
                NodeList[0].Attributes["value"].Value = value.Scholsoft;

                NodeList = XmlDoc.GetElementsByTagName("Scholsoure");
                NodeList[0].Attributes["value"].Value = value.Scholsoure;


                ////频道条数公告设置


                NodeList = XmlDoc.GetElementsByTagName("BrokerBulletin");
                NodeList[0].Attributes["value"].Value = value.BrokerBulletin;

                ////软件内嵌条数设置
                NodeList = XmlDoc.GetElementsByTagName("SoftLength");
                NodeList[0].Attributes["value"].Value = value.SoftLength;

                NodeList = XmlDoc.GetElementsByTagName("SoftCount");
                NodeList[0].Attributes["value"].Value = value.SoftCount;

                NodeList = XmlDoc.GetElementsByTagName("CstLength");
                NodeList[0].Attributes["value"].Value = value.CstLength;

                NodeList = XmlDoc.GetElementsByTagName("CstCount");
                NodeList[0].Attributes["value"].Value = value.CstCount;


                NodeList = XmlDoc.GetElementsByTagName("Softlength");
                NodeList[0].Attributes["value"].Value = value.Softlength;

                NodeList = XmlDoc.GetElementsByTagName("Softlie");
                NodeList[0].Attributes["value"].Value = value.Softlie;

                NodeList = XmlDoc.GetElementsByTagName("Softxzlength");
                NodeList[0].Attributes["value"].Value = value.Softxzlength;

                NodeList = XmlDoc.GetElementsByTagName("Softxzlie");
                NodeList[0].Attributes["value"].Value = value.Softxzlie;

                NodeList = XmlDoc.GetElementsByTagName("SoftMlength");
                NodeList[0].Attributes["value"].Value = value.SoftMlength;

                NodeList = XmlDoc.GetElementsByTagName("SoftMlie");
                NodeList[0].Attributes["value"].Value = value.SoftMlie;


                NodeList = XmlDoc.GetElementsByTagName("Sourcelegth");
                NodeList[0].Attributes["value"].Value = value.Sourcelegth;

                NodeList = XmlDoc.GetElementsByTagName("Sourcelie");
                NodeList[0].Attributes["value"].Value = value.Sourcelie;


                NodeList = XmlDoc.GetElementsByTagName("Sourcecountlegth");
                NodeList[0].Attributes["value"].Value = value.Sourcecountlegth;

                NodeList = XmlDoc.GetElementsByTagName("Sourcecountlie");
                NodeList[0].Attributes["value"].Value = value.Sourcecountlie;


                NodeList = XmlDoc.GetElementsByTagName("SourceMlegth");
                NodeList[0].Attributes["value"].Value = value.SourceMlegth;

                NodeList = XmlDoc.GetElementsByTagName("SourceMlie");
                NodeList[0].Attributes["value"].Value = value.SourceMlie;

                XmlDoc.Save(HttpContext.Current.Server.MapPath("~/XML/WebConfig.xml"));
            }
        }


        /// <summary>
        /// 拼搏吧xml设置
        /// </summary>
        private static SiteConfig _siteconfig;

        /// <summary>
        ///拼搏吧xml设置
        /// </summary>
        public static SiteConfig siteconfig
        {


            get
            {

                string tempLJ = currentLJ.Substring(0, currentLJ.Length - 1);

                XmlDocument doc = new XmlDocument();
                string path = HttpContext.Current.Server.MapPath("~/xml/WebConfig.xml");
                doc.Load(path);
                XmlNode node1 = doc.SelectSingleNode("/root/Ask/BarLJ");
                XmlElement xe1 = (XmlElement)node1;
                string barWJJ = xe1.Attributes["value"].Value;

                string currentASK = tempLJ.Substring(0, tempLJ.LastIndexOf("\\")) + "\\" + barWJJ;

                XmlDocument XmlDoc;
                XmlNodeList NodeList;
                XmlDoc = new XmlDocument();


                //string currentASK = (currentLJ.Substring(0, currentLJ.Length - 1)).Substring(0, (currentLJ.Substring(0, currentLJ.Length - 1)).LastIndexOf("\\")) + "\\Pinble_Ask";

                XmlDoc.Load(currentASK + "\\Xml\\AskConfig.xml");
                ////首页
                NodeList = XmlDoc.GetElementsByTagName("WebTitle");
                _siteconfig.WebTitle = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("wenkf");
                _siteconfig.wenkf = NodeList[0].Attributes["value"].Value;


                NodeList = XmlDoc.GetElementsByTagName("dakf");
                _siteconfig.dakf = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("dajiadf");
                _siteconfig.dajiadf = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("regf");
                _siteconfig.regf = NodeList[0].Attributes["value"].Value;


                NodeList = XmlDoc.GetElementsByTagName("dadf");
                _siteconfig.dadf = NodeList[0].Attributes["value"].Value;


                NodeList = XmlDoc.GetElementsByTagName("tjwendf");
                _siteconfig.tjwendf = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("tjdadf");
                _siteconfig.tjdadf = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("mdf");
                _siteconfig.mdf = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("gqkf");
                _siteconfig.gqkf = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("clwendf");
                _siteconfig.clwendf = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("OverTime");
                _siteconfig.OverTime = NodeList[0].Attributes["value"].Value;

                //页面显示条数

                NodeList = XmlDoc.GetElementsByTagName("CommendNum");
                _siteconfig.CommendNum = NodeList[0].Attributes["value"].Value;


                NodeList = XmlDoc.GetElementsByTagName("HotNum");
                _siteconfig.HotNum = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("PointNum");
                _siteconfig.PointNum = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("StateNNum");
                _siteconfig.StateNNum = NodeList[0].Attributes["value"].Value;


                NodeList = XmlDoc.GetElementsByTagName("StateYNum");
                _siteconfig.StateYNum = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("plkf");
                _siteconfig.plkf = NodeList[0].Attributes["value"].Value;


                NodeList = XmlDoc.GetElementsByTagName("BarBulletin");
                _siteconfig.BarBulletin = NodeList[0].Attributes["value"].Value;



                return _siteconfig;
            }
            set
            {
                string tempLJ = currentLJ.Substring(0, currentLJ.Length - 1);

                XmlDocument doc = new XmlDocument();
                string path = HttpContext.Current.Server.MapPath("~/xml/WebConfig.xml");
                doc.Load(path);
                XmlNode node1 = doc.SelectSingleNode("/root/Ask/BarLJ");
                XmlElement xe1 = (XmlElement)node1;
                string barWJJ = xe1.Attributes["value"].Value;

                string currentASK = tempLJ.Substring(0, tempLJ.LastIndexOf("\\")) + "\\" + barWJJ;

                XmlDocument XmlDoc;
                XmlNodeList NodeList;
                XmlDoc = new XmlDocument();
                XmlDoc.Load(currentASK + "\\Xml\\AskConfig.xml");
                //  XmlDoc.Load(HttpContext.Current.Server.MapPath("~/Xml/WebConfig.xml"));


                NodeList = XmlDoc.GetElementsByTagName("WebTitle");
                NodeList[0].Attributes["value"].Value = value.WebTitle;


                NodeList = XmlDoc.GetElementsByTagName("wenkf");
                NodeList[0].Attributes["value"].Value = value.wenkf;


                NodeList = XmlDoc.GetElementsByTagName("dakf");
                NodeList[0].Attributes["value"].Value = value.dakf;


                NodeList = XmlDoc.GetElementsByTagName("dajiadf");
                NodeList[0].Attributes["value"].Value = value.dajiadf;


                NodeList = XmlDoc.GetElementsByTagName("regf");
                NodeList[0].Attributes["value"].Value = value.regf;


                NodeList = XmlDoc.GetElementsByTagName("dadf");
                NodeList[0].Attributes["value"].Value = value.dadf;


                NodeList = XmlDoc.GetElementsByTagName("tjwendf");
                NodeList[0].Attributes["value"].Value = value.tjwendf;


                NodeList = XmlDoc.GetElementsByTagName("tjdadf");
                NodeList[0].Attributes["value"].Value = value.tjdadf;

                NodeList = XmlDoc.GetElementsByTagName("mdf");
                NodeList[0].Attributes["value"].Value = value.mdf;


                NodeList = XmlDoc.GetElementsByTagName("gqkf");
                NodeList[0].Attributes["value"].Value = value.gqkf;


                NodeList = XmlDoc.GetElementsByTagName("clwendf");
                NodeList[0].Attributes["value"].Value = value.clwendf;


                NodeList = XmlDoc.GetElementsByTagName("OverTime");
                NodeList[0].Attributes["value"].Value = value.OverTime;

                //页面显示条数                
                NodeList = XmlDoc.GetElementsByTagName("CommendNum");
                NodeList[0].Attributes["value"].Value = value.CommendNum;


                NodeList = XmlDoc.GetElementsByTagName("HotNum");
                NodeList[0].Attributes["value"].Value = value.HotNum;


                NodeList = XmlDoc.GetElementsByTagName("PointNum");
                NodeList[0].Attributes["value"].Value = value.PointNum;


                NodeList = XmlDoc.GetElementsByTagName("StateNNum");
                NodeList[0].Attributes["value"].Value = value.StateNNum;

                NodeList = XmlDoc.GetElementsByTagName("StateYNum");
                NodeList[0].Attributes["value"].Value = value.StateYNum;

                NodeList = XmlDoc.GetElementsByTagName("plkf");
                NodeList[0].Attributes["value"].Value = value.plkf;

                NodeList = XmlDoc.GetElementsByTagName("BarBulletin");
                NodeList[0].Attributes["value"].Value = value.BarBulletin;

                XmlDoc.Save(currentASK + "\\Xml\\AskConfig.xml");


            }

        }
        /// <summary>
        /// 彩票超市xml设置
        /// </summary>
        private static MarketConfig _marketconfig;

        /// <summary>
        ///彩票超市xml设置
        /// </summary>
        public static MarketConfig marketconfig
        {


            get
            {
                string tempLJ = currentLJ.Substring(0, currentLJ.Length - 1);

                XmlDocument doc = new XmlDocument();
                string path = HttpContext.Current.Server.MapPath("~/xml/WebConfig.xml");
                doc.Load(path);
                XmlNode node1 = doc.SelectSingleNode("/root/Market/BarLJ");
                XmlElement xe1 = (XmlElement)node1;
                string barWJJ = xe1.Attributes["value"].Value;

                string currentASK = tempLJ.Substring(0, tempLJ.LastIndexOf("\\")) + "\\" + barWJJ;

                XmlDocument XmlDoc;
                XmlNodeList NodeList;
                XmlDoc = new XmlDocument();

                XmlDoc.Load(currentASK + "\\Xml\\MarketConfig.xml");

                /////////////////////////////////////////////begin首页推荐项目
                //显示条数获取
                NodeList = XmlDoc.GetElementsByTagName("commenditem");
                _marketconfig.ItemCount = NodeList[0].Attributes["value"].Value;
                //首页推荐项目显示名称获取
                NodeList = XmlDoc.GetElementsByTagName("commenditem");
                _marketconfig.ItemName = NodeList[0].Attributes["name"].Value;
                ////////////////////////////////////////////End

                /////////////////////////////////////////////begin商家排行项目
                //显示条数获取
                NodeList = XmlDoc.GetElementsByTagName("shoparray");
                _marketconfig.ShopCount = NodeList[0].Attributes["value"].Value;
                //首页推荐项目显示名称获取
                NodeList = XmlDoc.GetElementsByTagName("shoparray");
                _marketconfig.ShopName = NodeList[0].Attributes["name"].Value;
                ////////////////////////////////////////////End

                /////////////////////////////////////////////begin项目服务信息
                //显示条数获取
                NodeList = XmlDoc.GetElementsByTagName("itemmessage");
                _marketconfig.ItemServerCount = NodeList[0].Attributes["value"].Value;
                //首页推荐项目显示名称获取
                NodeList = XmlDoc.GetElementsByTagName("itemmessage");
                _marketconfig.ItemServerName = NodeList[0].Attributes["name"].Value;
                ////////////////////////////////////////////End

                /////////////////////////////////////////////begin彩种详细信息
                //显示条数获取
                NodeList = XmlDoc.GetElementsByTagName("itemparticular");
                _marketconfig.ParticularCount = NodeList[0].Attributes["value"].Value;
                //首页推荐项目显示名称获取
                NodeList = XmlDoc.GetElementsByTagName("itemparticular");
                _marketconfig.ParticularName = NodeList[0].Attributes["name"].Value;
                ////////////////////////////////////////////End
                return _marketconfig;
            }
            set
            {
                string tempLJ = currentLJ.Substring(0, currentLJ.Length - 1);

                XmlDocument doc = new XmlDocument();
                string path = HttpContext.Current.Server.MapPath("~/xml/WebConfig.xml");
                doc.Load(path);
                XmlNode node1 = doc.SelectSingleNode("/root/Market/BarLJ");
                XmlElement xe1 = (XmlElement)node1;
                string barWJJ = xe1.Attributes["value"].Value;

                string currentASK = tempLJ.Substring(0, tempLJ.LastIndexOf("\\")) + "\\" + barWJJ;
                XmlDocument XmlDoc;
                XmlNodeList NodeList;
                XmlDoc = new XmlDocument();

                XmlDoc.Load(currentASK + "\\Xml\\MarketConfig.xml");
                //////////////////////////////////////////////////////
                //首页推荐项目显示条数设置
                NodeList = XmlDoc.GetElementsByTagName("commenditem");
                NodeList[0].Attributes["value"].Value = value.ItemCount;

                //首页推荐项目显示名称设置
                NodeList = XmlDoc.GetElementsByTagName("commenditem");
                NodeList[0].Attributes["name"].Value = value.ItemName;
                ////////////////////////////////////////////////////////

                //////////////////////////////////////////////////////
                //首页推荐项目显示条数设置
                NodeList = XmlDoc.GetElementsByTagName("shoparray");
                NodeList[0].Attributes["value"].Value = value.ShopCount;

                //首页推荐项目显示名称设置
                NodeList = XmlDoc.GetElementsByTagName("shoparray");
                NodeList[0].Attributes["name"].Value = value.ShopName;
                ////////////////////////////////////////////////////////

                //////////////////////////////////////////////////////
                //首页推荐项目显示条数设置
                NodeList = XmlDoc.GetElementsByTagName("itemmessage");
                NodeList[0].Attributes["value"].Value = value.ItemServerCount;

                //首页推荐项目显示名称设置
                NodeList = XmlDoc.GetElementsByTagName("itemmessage");
                NodeList[0].Attributes["name"].Value = value.ItemServerName;
                ////////////////////////////////////////////////////////

                //////////////////////////////////////////////////////
                //首页推荐项目显示条数设置
                NodeList = XmlDoc.GetElementsByTagName("itemparticular");
                NodeList[0].Attributes["value"].Value = value.ParticularCount;

                //首页推荐项目显示名称设置
                NodeList = XmlDoc.GetElementsByTagName("itemparticular");
                NodeList[0].Attributes["name"].Value = value.ParticularName;
                ////////////////////////////////////////////////////////

                XmlDoc.Save(currentASK + "\\Xml\\MarketConfig.xml");
            }

        }

        /// <summary>
        /// 平台时间设置
        /// </summary>
        private static PlatformTimeConfig _timeconfig;

        /// <summary>
        ///平台时间设置
        /// </summary>
        public static PlatformTimeConfig timeconfig
        {


            get
            {
                XmlDocument XmlDoc;
                XmlNodeList NodeList;
                XmlDoc = new XmlDocument();
                XmlDoc.Load(currentLJ+"\\Xml\\TimeConfig.xml");

                NodeList = XmlDoc.GetElementsByTagName("FC3DDataTime");
                _timeconfig.FC3DDataTime = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("FC7LCTime");
                _timeconfig.FC7LCTime = NodeList[0].Attributes["value"].Value;


                NodeList = XmlDoc.GetElementsByTagName("FCSSDataTime");
                _timeconfig.FCSSDataTime = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("TCPL35DataTime");
                _timeconfig.TCPL35DataTime = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("TC7XCDataTime");
                _timeconfig.TC7XCDataTime = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("TCDLTDataTime");
                _timeconfig.TCDLTDataTime = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("LottCompulsory");
                _timeconfig.LottCompulsory = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("ExecutionTime");
                _timeconfig.ExecutionTime = NodeList[0].Attributes["value"].Value;


                return _timeconfig;
            }
            set
            {
                XmlDocument XmlDoc;
                XmlNodeList NodeList;
                XmlDoc = new XmlDocument();
                XmlDoc.Load(HttpContext.Current.Server.MapPath("~/Xml/TimeConfig.xml"));

                ////首页
                NodeList = XmlDoc.GetElementsByTagName("FC3DDataTime");
                NodeList[0].Attributes["value"].Value = value.FC3DDataTime;

                NodeList = XmlDoc.GetElementsByTagName("FC7LCTime");
                NodeList[0].Attributes["value"].Value = value.FC7LCTime;

                NodeList = XmlDoc.GetElementsByTagName("FCSSDataTime");
                NodeList[0].Attributes["value"].Value = value.FCSSDataTime;

                NodeList = XmlDoc.GetElementsByTagName("TCPL35DataTime");
                NodeList[0].Attributes["value"].Value = value.TCPL35DataTime;

                NodeList = XmlDoc.GetElementsByTagName("TC7XCDataTime");
                NodeList[0].Attributes["value"].Value = value.TC7XCDataTime;

                NodeList = XmlDoc.GetElementsByTagName("TCDLTDataTime");
                NodeList[0].Attributes["value"].Value = value.TCDLTDataTime;

                NodeList = XmlDoc.GetElementsByTagName("LottCompulsory");
                NodeList[0].Attributes["value"].Value = value.LottCompulsory;

                NodeList = XmlDoc.GetElementsByTagName("ExecutionTime");
                NodeList[0].Attributes["value"].Value = value.ExecutionTime;



                XmlDoc.Save(HttpContext.Current.Server.MapPath("~/XML/TimeConfig.xml"));
            }
        }

        /// <summary>
        /// 平台时间设置
        /// </summary>
        private static PlatformEndTimeConfig _endtimeconfig;

        /// <summary>
        ///平台时间设置
        /// </summary>
        public static PlatformEndTimeConfig endtimeconfig
        {


            get
            {
                XmlDocument XmlDoc;
                XmlNodeList NodeList;
                XmlDoc = new XmlDocument();
                XmlDoc.Load(currentLJ + "\\Xml\\WebConfig.xml");
                //XmlDoc.Load("E:\\0Source\\Pinble_DataRivalry" + "\\Xml\\WebConfig.xml");
                NodeList = XmlDoc.GetElementsByTagName("FC3DEndTime");
                _endtimeconfig.FC3DEndTime = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("FCSSQEndTime");
                _endtimeconfig.FCSSQEndTime = NodeList[0].Attributes["value"].Value;


                NodeList = XmlDoc.GetElementsByTagName("TCPL35EndTime");
                _endtimeconfig.TCPL35EndTime = NodeList[0].Attributes["value"].Value;

                return _endtimeconfig;
            }
            set
            {
                XmlDocument XmlDoc;
                XmlNodeList NodeList;
                XmlDoc = new XmlDocument();
                XmlDoc.Load(HttpContext.Current.Server.MapPath("~/Xml/WebConfig.xml"));

                ////首页
                NodeList = XmlDoc.GetElementsByTagName("FC3DEndTime");
                NodeList[0].Attributes["value"].Value = value.FC3DEndTime;

                NodeList = XmlDoc.GetElementsByTagName("FCSSQEndTime");
                NodeList[0].Attributes["value"].Value = value.FCSSQEndTime;

                NodeList = XmlDoc.GetElementsByTagName("TCPL35EndTime");
                NodeList[0].Attributes["value"].Value = value.TCPL35EndTime;


                XmlDoc.Save(HttpContext.Current.Server.MapPath("~/XML/WebConfig.xml"));
            }
        }

        /// <summary>
        /// 大底单选配置
        /// </summary>
        private static SwitchConfig _switch;

        /// <summary>
        ///大底单选配置
        /// </summary>
        public static SwitchConfig switchconfig
        {


            get
            {
                XmlDocument XmlDoc;
                XmlNodeList NodeList;
                XmlDoc = new XmlDocument();
                XmlDoc.Load(currentLJ + "\\Xml\\Switchxml.xml");

                NodeList = XmlDoc.GetElementsByTagName("Switch");
                _switch.Switch = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("LeastRange");
                _switch.LeastRange = NodeList[0].Attributes["value"].Value;


                NodeList = XmlDoc.GetElementsByTagName("MaximumRange");
                _switch.MaximumRange = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("InTwo");
                _switch.InTwo = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("InOne");
                _switch.InOne = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("InZero");
                _switch.InZero = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("InTwoUpperlimit");
                _switch.InTwoUpperlimit = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("InTwoLowerlimit");
                _switch.InTwoLowerlimit = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("InOneUpperlimit");
                _switch.InOneUpperlimit = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("InOneLowerlimit");
                _switch.InOneLowerlimit = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("InZeroUpperlimit");
                _switch.InZeroUpperlimit = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("InZeroLowerlimit");
                _switch.InZeroLowerlimit = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("IntegralTwo");
                _switch.IntegralTwo = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("IntegralOne");
                _switch.IntegralOne = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("IntegralZero");
                _switch.IntegralZero = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("IntegralGroup");
                _switch.IntegralGroup = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("CoinTwo");
                _switch.CoinTwo = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("CoinOne");
                _switch.CoinOne = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("CoinZero");
                _switch.CoinZero = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("CoinGroup");
                _switch.CoinGroup = NodeList[0].Attributes["value"].Value;


                return _switch;
            }
            set
            {
                XmlDocument XmlDoc;
                XmlNodeList NodeList;
                XmlDoc = new XmlDocument();
                XmlDoc.Load(HttpContext.Current.Server.MapPath("~/Xml/Switchxml.xml"));

                ////首页
                NodeList = XmlDoc.GetElementsByTagName("Switch");
                NodeList[0].Attributes["value"].Value = value.Switch;

                NodeList = XmlDoc.GetElementsByTagName("LeastRange");
                NodeList[0].Attributes["value"].Value = value.LeastRange;

                NodeList = XmlDoc.GetElementsByTagName("MaximumRange");
                NodeList[0].Attributes["value"].Value = value.MaximumRange;

                NodeList = XmlDoc.GetElementsByTagName("InTwo");
                NodeList[0].Attributes["value"].Value = value.InTwo;

                NodeList = XmlDoc.GetElementsByTagName("InOne");
                NodeList[0].Attributes["value"].Value = value.InOne;

                NodeList = XmlDoc.GetElementsByTagName("InZero");
                NodeList[0].Attributes["value"].Value = value.InZero;

                NodeList = XmlDoc.GetElementsByTagName("InTwoUpperlimit");
                NodeList[0].Attributes["value"].Value = value.InTwoUpperlimit;

                NodeList = XmlDoc.GetElementsByTagName("InTwoLowerlimit");
                NodeList[0].Attributes["value"].Value = value.InTwoLowerlimit;

                NodeList = XmlDoc.GetElementsByTagName("InOneUpperlimit");
                NodeList[0].Attributes["value"].Value = value.InOneUpperlimit;

                NodeList = XmlDoc.GetElementsByTagName("InOneLowerlimit");
                NodeList[0].Attributes["value"].Value = value.InOneLowerlimit;

                NodeList = XmlDoc.GetElementsByTagName("InZeroUpperlimit");
                NodeList[0].Attributes["value"].Value = value.InZeroUpperlimit;

                NodeList = XmlDoc.GetElementsByTagName("InZeroLowerlimit");
                NodeList[0].Attributes["value"].Value = value.InZeroLowerlimit;

                NodeList = XmlDoc.GetElementsByTagName("IntegralTwo");
                NodeList[0].Attributes["value"].Value = value.IntegralTwo;

                NodeList = XmlDoc.GetElementsByTagName("IntegralOne");
                NodeList[0].Attributes["value"].Value = value.IntegralOne;

                NodeList = XmlDoc.GetElementsByTagName("IntegralZero");
                NodeList[0].Attributes["value"].Value = value.IntegralZero;

                NodeList = XmlDoc.GetElementsByTagName("IntegralGroup");
                NodeList[0].Attributes["value"].Value = value.IntegralGroup;

                NodeList = XmlDoc.GetElementsByTagName("CoinTwo");
                NodeList[0].Attributes["value"].Value = value.CoinTwo;

                NodeList = XmlDoc.GetElementsByTagName("CoinOne");
                NodeList[0].Attributes["value"].Value = value.CoinOne;

                NodeList = XmlDoc.GetElementsByTagName("CoinZero");
                NodeList[0].Attributes["value"].Value = value.CoinZero;

                NodeList = XmlDoc.GetElementsByTagName("CoinGroup");
                NodeList[0].Attributes["value"].Value = value.CoinGroup;


                XmlDoc.Save(HttpContext.Current.Server.MapPath("~/XML/Switchxml.xml"));
            }
        }


        /// <summary>
        /// 大底组选配置
        /// </summary>
        private static GroupNumConfig _groupNum;

        /// <summary>
        ///大底组选配置
        /// </summary>
        public static GroupNumConfig groupNumconfig
        {


            get
            {
                XmlDocument XmlDoc;
                XmlNodeList NodeList;
                XmlDoc = new XmlDocument();
                XmlDoc.Load(currentLJ + "\\Xml\\GroupNum.xml");

                NodeList = XmlDoc.GetElementsByTagName("LeastRange");
                _groupNum.LeastRange = NodeList[0].Attributes["value"].Value;


                NodeList = XmlDoc.GetElementsByTagName("MaximumRange");
                _groupNum.MaximumRange = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("InTwo");
                _groupNum.InTwo = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("InOne");
                _groupNum.InOne = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("InZero");
                _groupNum.InZero = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("InTwozt");
                _groupNum.InTwozt = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("InOnezt");
                _groupNum.InOnezt= NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("InZerozt");
                _groupNum.InZerozt = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("InTwobz");
                _groupNum.InTwobz = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("InOnebz");
                _groupNum.InOnebz = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("InZerobz");
                _groupNum.InZerobz = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("InTwoUpperlimit");
                _groupNum.InTwoUpperlimit = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("InTwoLowerlimit");
                _groupNum.InTwoLowerlimit = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("InOneUpperlimit");
                _groupNum.InOneUpperlimit = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("InOneLowerlimit");
                _groupNum.InOneLowerlimit = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("InZeroUpperlimit");
                _groupNum.InZeroUpperlimit = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("InZeroLowerlimit");
                _groupNum.InZeroLowerlimit = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("IntegralTwo");
                _groupNum.IntegralTwo = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("IntegralOne");
                _groupNum.IntegralOne = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("IntegralZero");
                _groupNum.IntegralZero = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("IntegralGroup");
                _groupNum.IntegralGroup = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("CoinTwo");
                _groupNum.CoinTwo = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("CoinOne");
                _groupNum.CoinOne = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("CoinZero");
                _groupNum.CoinZero = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("CoinGroup");
                _groupNum.CoinGroup = NodeList[0].Attributes["value"].Value;


                return _groupNum;
            }
            set
            {
                XmlDocument XmlDoc;
                XmlNodeList NodeList;
                XmlDoc = new XmlDocument();
                XmlDoc.Load(HttpContext.Current.Server.MapPath("~/Xml/GroupNum.xml"));

                NodeList = XmlDoc.GetElementsByTagName("LeastRange");
                NodeList[0].Attributes["value"].Value = value.LeastRange;

                NodeList = XmlDoc.GetElementsByTagName("MaximumRange");
                NodeList[0].Attributes["value"].Value = value.MaximumRange;

                NodeList = XmlDoc.GetElementsByTagName("InTwo");
                NodeList[0].Attributes["value"].Value = value.InTwo;

                NodeList = XmlDoc.GetElementsByTagName("InOne");
                NodeList[0].Attributes["value"].Value = value.InOne;

                NodeList = XmlDoc.GetElementsByTagName("InZero");
                NodeList[0].Attributes["value"].Value = value.InZero;

                NodeList = XmlDoc.GetElementsByTagName("InTwozt");
                NodeList[0].Attributes["value"].Value = value.InTwozt;

                NodeList = XmlDoc.GetElementsByTagName("InOnezt");
                NodeList[0].Attributes["value"].Value = value.InOnezt;

                NodeList = XmlDoc.GetElementsByTagName("InZerozt");
                NodeList[0].Attributes["value"].Value = value.InZerozt;

                NodeList = XmlDoc.GetElementsByTagName("InTwobz");
                NodeList[0].Attributes["value"].Value = value.InTwobz;

                NodeList = XmlDoc.GetElementsByTagName("InOnebz");
                NodeList[0].Attributes["value"].Value = value.InOnebz;

                NodeList = XmlDoc.GetElementsByTagName("InZerobz");
                NodeList[0].Attributes["value"].Value = value.InZerobz;

                NodeList = XmlDoc.GetElementsByTagName("InTwoUpperlimit");
                NodeList[0].Attributes["value"].Value = value.InTwoUpperlimit;

                NodeList = XmlDoc.GetElementsByTagName("InTwoLowerlimit");
                NodeList[0].Attributes["value"].Value = value.InTwoLowerlimit;

                NodeList = XmlDoc.GetElementsByTagName("InOneUpperlimit");
                NodeList[0].Attributes["value"].Value = value.InOneUpperlimit;

                NodeList = XmlDoc.GetElementsByTagName("InOneLowerlimit");
                NodeList[0].Attributes["value"].Value = value.InOneLowerlimit;

                NodeList = XmlDoc.GetElementsByTagName("InZeroUpperlimit");
                NodeList[0].Attributes["value"].Value = value.InZeroUpperlimit;

                NodeList = XmlDoc.GetElementsByTagName("InZeroLowerlimit");
                NodeList[0].Attributes["value"].Value = value.InZeroLowerlimit;

                NodeList = XmlDoc.GetElementsByTagName("IntegralTwo");
                NodeList[0].Attributes["value"].Value = value.IntegralTwo;

                NodeList = XmlDoc.GetElementsByTagName("IntegralOne");
                NodeList[0].Attributes["value"].Value = value.IntegralOne;

                NodeList = XmlDoc.GetElementsByTagName("IntegralZero");
                NodeList[0].Attributes["value"].Value = value.IntegralZero;

                NodeList = XmlDoc.GetElementsByTagName("IntegralGroup");
                NodeList[0].Attributes["value"].Value = value.IntegralGroup;

                NodeList = XmlDoc.GetElementsByTagName("CoinTwo");
                NodeList[0].Attributes["value"].Value = value.CoinTwo;

                NodeList = XmlDoc.GetElementsByTagName("CoinOne");
                NodeList[0].Attributes["value"].Value = value.CoinOne;

                NodeList = XmlDoc.GetElementsByTagName("CoinZero");
                NodeList[0].Attributes["value"].Value = value.CoinZero;

                NodeList = XmlDoc.GetElementsByTagName("CoinGroup");
                NodeList[0].Attributes["value"].Value = value.CoinGroup;


                XmlDoc.Save(HttpContext.Current.Server.MapPath("~/XML/GroupNum.xml"));
            }
        }

        /// <summary>
        /// 擂台积分设置
        /// </summary>
        private static lottIntegral _lottint;

        /// <summary>
        ///擂台积分设置
        /// </summary>
        public static lottIntegral lottintconfig
        {
            get {
                XmlDocument XmlDoc;
                XmlNodeList NodeList;
                XmlDoc = new XmlDocument();
                XmlDoc.Load(currentLJ + "\\Xml\\lottIntegral.xml");

                NodeList = XmlDoc.GetElementsByTagName("h3HitOne");
                _lottint.h3HitOne = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("h3HitTwo");
                _lottint.h3HitTwo = NodeList[0].Attributes["value"].Value;


                NodeList = XmlDoc.GetElementsByTagName("h3HitThree");
                _lottint.h3HitThree = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("h6HitOne");
                _lottint.h6HitOne = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("h6HitTwo");
                _lottint.h6HitTwo = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("h6HitThree");
                _lottint.h6HitThree = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("h6HitFour");
                _lottint.h6HitFour = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("h6HitFive");
                _lottint.h6HitFive = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("h6HitSix");
                _lottint.h6HitSix = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("s3hHit");
                _lottint.s3hHit = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("s6hHit");
                _lottint.s6hHit = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("lHit");
                _lottint.lHit = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("l3Hit");
                _lottint.l3Hit = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("s3lHit");
                _lottint.s3lHit = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("s6lHit");
                _lottint.s6lHit = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("h3l61Hit");
                _lottint.h3l61Hit = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("h3l60Hit");
                _lottint.h3l60Hit = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("h3l51Hit");
                _lottint.h3l51Hit = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("h3l50Hit");
                _lottint.h3l50Hit = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("h3l41Hit");
                _lottint.h3l41Hit = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("h3l40Hit");
                _lottint.h3l40Hit = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("h3l31Hit");
                _lottint.h3l31Hit = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("h3l30Hit");
                _lottint.h3l30Hit = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("h3l21Hit");
                _lottint.h3l21Hit = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("h3l20Hit");
                _lottint.h3l20Hit = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("h3l11Hit");
                _lottint.h3l11Hit = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("h3l01Hit");
                _lottint.h3l01Hit = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("h2l61Hit");
                _lottint.h2l61Hit = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("h2l60Hit");
                _lottint.h2l60Hit = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("h2l51Hit");
                _lottint.h2l51Hit = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("h2l50Hit");
                _lottint.h2l50Hit = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("h2l41Hit");
                _lottint.h2l41Hit = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("h2l40Hit");
                _lottint.h2l40Hit = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("h2l31Hit");
                _lottint.h2l31Hit = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("h2l30Hit");
                _lottint.h2l30Hit = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("h2l21Hit");
                _lottint.h2l21Hit = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("h2l20Hit");
                _lottint.h2l20Hit = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("h2l11Hit");
                _lottint.h2l11Hit = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("h2l01Hit");
                _lottint.h2l01Hit = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("ddHit");
                _lottint.ddHit = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("sdHitOne");
                _lottint.sdHitOne = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("sdHitTwo");
                _lottint.sdHitTwo = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("GroupHit");
                _lottint.GroupHit = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("dirHit");
                _lottint.dirHit = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("sMHitOne");
                _lottint.sMHitOne = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("sMHitTwo");
                _lottint.sMHitTwo = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("dKHit");
                _lottint.dKHit = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("dhHit");
                _lottint.dhHit = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("shHit");
                _lottint.shHit = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("dw5Hit");
                _lottint.dw5Hit = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("dw3Hit");
                _lottint.dw3Hit = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("m5Hit");
                _lottint.m5Hit = NodeList[0].Attributes["value"].Value;



                return _lottint;
            }
            set
            {
                XmlDocument XmlDoc;
                XmlNodeList NodeList;
                XmlDoc = new XmlDocument();
                XmlDoc.Load(HttpContext.Current.Server.MapPath("~/Xml/lottIntegral.xml"));

                NodeList = XmlDoc.GetElementsByTagName("h3HitOne");
                NodeList[0].Attributes["value"].Value = value.h3HitOne;

                NodeList = XmlDoc.GetElementsByTagName("h3HitTwo");
                NodeList[0].Attributes["value"].Value = value.h3HitTwo;

                NodeList = XmlDoc.GetElementsByTagName("h3HitThree");
                NodeList[0].Attributes["value"].Value = value.h3HitThree;

                NodeList = XmlDoc.GetElementsByTagName("h6HitOne");
                NodeList[0].Attributes["value"].Value = value.h6HitOne;

                NodeList = XmlDoc.GetElementsByTagName("h6HitTwo");
                NodeList[0].Attributes["value"].Value = value.h6HitTwo;

                NodeList = XmlDoc.GetElementsByTagName("h6HitThree");
                NodeList[0].Attributes["value"].Value = value.h6HitThree;

                NodeList = XmlDoc.GetElementsByTagName("h6HitFour");
                NodeList[0].Attributes["value"].Value = value.h6HitFour;

                NodeList = XmlDoc.GetElementsByTagName("h6HitFive");
                NodeList[0].Attributes["value"].Value = value.h6HitFive;

                NodeList = XmlDoc.GetElementsByTagName("h6HitSix");
                NodeList[0].Attributes["value"].Value = value.h6HitSix;

                NodeList = XmlDoc.GetElementsByTagName("s3hHit");
                NodeList[0].Attributes["value"].Value = value.s3hHit;

                NodeList = XmlDoc.GetElementsByTagName("s6hHit");
                NodeList[0].Attributes["value"].Value = value.s6hHit;

                NodeList = XmlDoc.GetElementsByTagName("lHit");
                NodeList[0].Attributes["value"].Value = value.lHit;

                NodeList = XmlDoc.GetElementsByTagName("l3Hit");
                NodeList[0].Attributes["value"].Value = value.l3Hit;

                NodeList = XmlDoc.GetElementsByTagName("s3lHit");
                NodeList[0].Attributes["value"].Value = value.s3lHit;

                NodeList = XmlDoc.GetElementsByTagName("s6lHit");
                NodeList[0].Attributes["value"].Value = value.s6lHit;

                NodeList = XmlDoc.GetElementsByTagName("h3l61Hit");
                NodeList[0].Attributes["value"].Value = value.h3l61Hit;

                NodeList = XmlDoc.GetElementsByTagName("h3l60Hit");
                NodeList[0].Attributes["value"].Value = value.h3l60Hit;

                NodeList = XmlDoc.GetElementsByTagName("h3l51Hit");
                NodeList[0].Attributes["value"].Value = value.h3l51Hit;

                NodeList = XmlDoc.GetElementsByTagName("h3l50Hit");
                NodeList[0].Attributes["value"].Value = value.h3l50Hit;

                NodeList = XmlDoc.GetElementsByTagName("h3l41Hit");
                NodeList[0].Attributes["value"].Value = value.h3l41Hit;

                NodeList = XmlDoc.GetElementsByTagName("h3l40Hit");
                NodeList[0].Attributes["value"].Value = value.h3l40Hit;

                NodeList = XmlDoc.GetElementsByTagName("h3l31Hit");
                NodeList[0].Attributes["value"].Value = value.h3l31Hit;

                NodeList = XmlDoc.GetElementsByTagName("h3l30Hit");
                NodeList[0].Attributes["value"].Value = value.h3l30Hit;

                NodeList = XmlDoc.GetElementsByTagName("h3l21Hit");
                NodeList[0].Attributes["value"].Value = value.h3l21Hit;

                NodeList = XmlDoc.GetElementsByTagName("h3l20Hit");
                NodeList[0].Attributes["value"].Value = value.h3l20Hit;

                NodeList = XmlDoc.GetElementsByTagName("h3l11Hit");
                NodeList[0].Attributes["value"].Value = value.h3l11Hit;

                NodeList = XmlDoc.GetElementsByTagName("h3l01Hit");
                NodeList[0].Attributes["value"].Value = value.h3l01Hit;



                NodeList = XmlDoc.GetElementsByTagName("h2l61Hit");
                NodeList[0].Attributes["value"].Value = value.h2l61Hit;

                NodeList = XmlDoc.GetElementsByTagName("h2l60Hit");
                NodeList[0].Attributes["value"].Value = value.h2l60Hit;

                NodeList = XmlDoc.GetElementsByTagName("h2l51Hit");
                NodeList[0].Attributes["value"].Value = value.h2l51Hit;

                NodeList = XmlDoc.GetElementsByTagName("h2l50Hit");
                NodeList[0].Attributes["value"].Value = value.h2l50Hit;

                NodeList = XmlDoc.GetElementsByTagName("h2l41Hit");
                NodeList[0].Attributes["value"].Value = value.h2l41Hit;

                NodeList = XmlDoc.GetElementsByTagName("h2l40Hit");
                NodeList[0].Attributes["value"].Value = value.h2l40Hit;

                NodeList = XmlDoc.GetElementsByTagName("h2l31Hit");
                NodeList[0].Attributes["value"].Value = value.h2l31Hit;

                NodeList = XmlDoc.GetElementsByTagName("h2l30Hit");
                NodeList[0].Attributes["value"].Value = value.h2l30Hit;

                NodeList = XmlDoc.GetElementsByTagName("h2l21Hit");
                NodeList[0].Attributes["value"].Value = value.h2l21Hit;

                NodeList = XmlDoc.GetElementsByTagName("h2l20Hit");
                NodeList[0].Attributes["value"].Value = value.h2l20Hit;

                NodeList = XmlDoc.GetElementsByTagName("h2l11Hit");
                NodeList[0].Attributes["value"].Value = value.h2l11Hit;

                NodeList = XmlDoc.GetElementsByTagName("h2l01Hit");
                NodeList[0].Attributes["value"].Value = value.h2l01Hit;

                NodeList = XmlDoc.GetElementsByTagName("ddHit");
                NodeList[0].Attributes["value"].Value = value.ddHit;

                NodeList = XmlDoc.GetElementsByTagName("sdHitOne");
                NodeList[0].Attributes["value"].Value = value.sdHitOne;

                NodeList = XmlDoc.GetElementsByTagName("sdHitTwo");
                NodeList[0].Attributes["value"].Value = value.sdHitTwo;

                NodeList = XmlDoc.GetElementsByTagName("GroupHit");
                NodeList[0].Attributes["value"].Value = value.GroupHit;

                NodeList = XmlDoc.GetElementsByTagName("dirHit");
                NodeList[0].Attributes["value"].Value = value.dirHit;

                NodeList = XmlDoc.GetElementsByTagName("sMHitOne");
                NodeList[0].Attributes["value"].Value = value.sMHitOne;

                NodeList = XmlDoc.GetElementsByTagName("sMHitTwo");
                NodeList[0].Attributes["value"].Value = value.sMHitTwo;

                NodeList = XmlDoc.GetElementsByTagName("dKHit");
                NodeList[0].Attributes["value"].Value = value.dKHit;

                NodeList = XmlDoc.GetElementsByTagName("dhHit");
                NodeList[0].Attributes["value"].Value = value.dhHit;

                NodeList = XmlDoc.GetElementsByTagName("shHit");
                NodeList[0].Attributes["value"].Value = value.shHit;

                NodeList = XmlDoc.GetElementsByTagName("dw5Hit");
                NodeList[0].Attributes["value"].Value = value.dw5Hit;

                NodeList = XmlDoc.GetElementsByTagName("dw3Hit");
                NodeList[0].Attributes["value"].Value = value.dw3Hit;

                NodeList = XmlDoc.GetElementsByTagName("m5Hit");
                NodeList[0].Attributes["value"].Value = value.m5Hit;



                XmlDoc.Save(HttpContext.Current.Server.MapPath("~/XML/lottIntegral.xml"));
            }

        }
    }
}
