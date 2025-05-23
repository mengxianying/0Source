using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Pbzx.Common;
using System.Xml;

namespace Pinble_Wap
{
    public class WapWebInit
    {
        private static string currentLJ = HttpRuntime.AppDomainAppPath;
        private static string currentXU = HttpRuntime.AppDomainAppVirtualPath;
        /// <summary>
        ///  3D��Ϣ
        /// </summary>
        private static WapBase _web3DBaseConfig;
        /// <summary>
        /// 3D��Ϣ
        /// </summary>
        public static WapBase web3DBaseConfig
        {
            get
            {
                XmlDocument XmlDoc;
                XmlNodeList NodeList;
                XmlDoc = new XmlDocument();

                XmlDoc.Load(currentLJ + "\\Xml\\BeginInformation.xml");

                NodeList = XmlDoc.GetElementsByTagName("YearStart");
                _web3DBaseConfig.YearStart = NodeList[0].Attributes["value"].Value;

                NodeList = XmlDoc.GetElementsByTagName("YearEnd");
                _web3DBaseConfig.YearEnd = NodeList[0].Attributes["value"].Value;


                NodeList = XmlDoc.GetElementsByTagName("_3D");
                _web3DBaseConfig.Issue = NodeList[0].Attributes["issue"].Value;
                _web3DBaseConfig.Testcode = NodeList[0].Attributes["testcode"].Value;
                _web3DBaseConfig.Code = NodeList[0].Attributes["code"].Value;
                _web3DBaseConfig.TCode = NodeList[0].Attributes["decode"].Value;
                _web3DBaseConfig.Date = NodeList[0].Attributes["date"].Value;
                _web3DBaseConfig.AttentionCode = NodeList[0].Attributes["attentionCode"].Value;
                _web3DBaseConfig.Machine = NodeList[0].Attributes["machine"].Value;
                _web3DBaseConfig.Ball = NodeList[0].Attributes["ball"].Value;
                return _web3DBaseConfig;
            }
            set
            {
                XmlDocument XmlDoc;
                XmlNodeList NodeList;
                XmlDoc = new XmlDocument();
                XmlDoc.Load(currentLJ + "\\Xml\\BeginInformation.xml");

                //NodeList = XmlDoc.GetElementsByTagName("YearStart");
                //NodeList[0].Attributes["value"].Value = value.YearStart;

                //NodeList = XmlDoc.GetElementsByTagName("YearEnd");
                //NodeList[0].Attributes["value"].Value = value.YearEnd;

                NodeList = XmlDoc.GetElementsByTagName("_3D");
                //�ں�
                NodeList = XmlDoc.GetElementsByTagName("issus");
                NodeList[0].Attributes["issus"].Value = value.Issue;
                //�Ի���
                NodeList = XmlDoc.GetElementsByTagName("testcode");
                NodeList[0].Attributes["testcode"].Value = value.Testcode;
                //��������
                NodeList = XmlDoc.GetElementsByTagName("code");
                NodeList[0].Attributes["code"].Value = value.Code;

                NodeList = XmlDoc.GetElementsByTagName("decode");
                NodeList[0].Attributes["decode"].Value = value.TCode;
                //�޸�ʱ��
                NodeList = XmlDoc.GetElementsByTagName("date");
                NodeList[0].Attributes["date"].Value = value.Date;
                //AttentionCode
                NodeList = XmlDoc.GetElementsByTagName("attentionCode");
                NodeList[0].Attributes["attentionCode"].Value = value.AttentionCode;

                //����
                NodeList = XmlDoc.GetElementsByTagName("machine");
                NodeList[0].Attributes["machine"].Value = value.Machine;
                //����
                NodeList = XmlDoc.GetElementsByTagName("ball");
                NodeList[0].Attributes["ball"].Value = value.Ball;

                XmlDoc.Save(currentLJ + "\\Xml\\BeginInformation.xml");
            }
        }

        #region ����5
        /// <summary>
        /// ����5
        /// </summary>
        /// 
        private static WapBase _webpl5BaseConfig;

        public static WapBase webpl5BaseConfig
        {
            get
            {
                XmlDocument XmlDoc;
                XmlNodeList NodeList;
                XmlDoc = new XmlDocument();

                XmlDoc.Load(currentLJ + "\\Xml\\BeginInformation.xml");


                NodeList = XmlDoc.GetElementsByTagName("pl5");
                _webpl5BaseConfig.Issue = NodeList[0].Attributes["issue"].Value;
                _webpl5BaseConfig.Code = NodeList[0].Attributes["code5"].Value;
                _webpl5BaseConfig.Date = NodeList[0].Attributes["date"].Value;
                return _webpl5BaseConfig;
            }
            set
            {
                XmlDocument XmlDoc;
                XmlNodeList NodeList;
                XmlDoc = new XmlDocument();
                XmlDoc.Load(currentLJ + "\\Xml\\BeginInformation.xml");

                NodeList = XmlDoc.GetElementsByTagName("pl5");
                //�ں�
                NodeList[0].Attributes["issus"].Value = value.Issue;
                //��������
                NodeList[0].Attributes["code5"].Value = value.Code;
                //�޸�ʱ��
                NodeList[0].Attributes["date"].Value = value.Date;

                XmlDoc.Save(currentLJ + "\\Xml\\BeginInformation.xml");
            }
        }
        #endregion

        #region ���ǲ�
        /// <summary>
        /// ���ǲ�
        /// </summary>
        /// 
        private static WapBase _webqxcBaseConfig;

        public static WapBase webqxcBaseConfig
        {
            get
            {
                XmlDocument XmlDoc;
                XmlNodeList NodeList;
                XmlDoc = new XmlDocument();

                XmlDoc.Load(currentLJ + "\\Xml\\BeginInformation.xml");


                NodeList = XmlDoc.GetElementsByTagName("qxc");
                _webqxcBaseConfig.Issue = NodeList[0].Attributes["issue"].Value;
                _webqxcBaseConfig.Code = NodeList[0].Attributes["code"].Value;
                _webqxcBaseConfig.Date = NodeList[0].Attributes["date"].Value;
                return _webqxcBaseConfig;
            }
            set
            {
                XmlDocument XmlDoc;
                XmlNodeList NodeList;
                XmlDoc = new XmlDocument();
                XmlDoc.Load(currentLJ + "\\Xml\\BeginInformation.xml");

                NodeList = XmlDoc.GetElementsByTagName("qxc");
                //�ں�
                NodeList[0].Attributes["issus"].Value = value.Issue;
                //��������
                NodeList[0].Attributes["code"].Value = value.Code;
                //�޸�ʱ��
                NodeList[0].Attributes["date"].Value = value.Date;

                XmlDoc.Save(currentLJ + "\\Xml\\BeginInformation.xml");
            }
        }
        #endregion

        #region ���ֲ�
        /// <summary>
        /// ���ֲ�
        /// </summary>
        /// 
        private static WapBase _webqclBaseConfig;

        public static WapBase webqclBaseConfig
        {
            get
            {
                XmlDocument XmlDoc;
                XmlNodeList NodeList;
                XmlDoc = new XmlDocument();

                XmlDoc.Load(currentLJ + "\\Xml\\BeginInformation.xml");


                NodeList = XmlDoc.GetElementsByTagName("qcl");
                _webqclBaseConfig.Issue = NodeList[0].Attributes["issue"].Value;
                _webqclBaseConfig.Code = NodeList[0].Attributes["code"].Value;
                _webqclBaseConfig.TCode = NodeList[0].Attributes["tcode"].Value;
                _webqclBaseConfig.Date = NodeList[0].Attributes["date"].Value;
                return _webqclBaseConfig;
            }
            set
            {
                XmlDocument XmlDoc;
                XmlNodeList NodeList;
                XmlDoc = new XmlDocument();
                XmlDoc.Load(currentLJ + "\\Xml\\BeginInformation.xml");

                NodeList = XmlDoc.GetElementsByTagName("qcl");
                //�ں�
                NodeList[0].Attributes["issus"].Value = value.Issue;
                //��������
                NodeList[0].Attributes["code"].Value = value.Code;
                //��������2
                NodeList[0].Attributes["tcode"].Value = value.TCode;
                //�޸�ʱ��
                NodeList[0].Attributes["date"].Value = value.Date;

                XmlDoc.Save(currentLJ + "\\Xml\\BeginInformation.xml");
            }
        }
        #endregion

        #region ����˫ɫ��
        /// <summary>
        /// ����˫ɫ��
        /// </summary>
        /// 
        private static WapBase _webssqBaseConfig;

        public static WapBase webssqBaseConfig
        {
            get
            {
                XmlDocument XmlDoc;
                XmlNodeList NodeList;
                XmlDoc = new XmlDocument();

                XmlDoc.Load(currentLJ + "\\Xml\\BeginInformation.xml");


                NodeList = XmlDoc.GetElementsByTagName("ssq");
                _webssqBaseConfig.Issue = NodeList[0].Attributes["issue"].Value;
                _webssqBaseConfig.Code = NodeList[0].Attributes["redcode"].Value;
                _webssqBaseConfig.TCode = NodeList[0].Attributes["bluecode"].Value;
                _webssqBaseConfig.Date = NodeList[0].Attributes["date"].Value;
                return _webssqBaseConfig;
            }
            set
            {
                XmlDocument XmlDoc;
                XmlNodeList NodeList;
                XmlDoc = new XmlDocument();
                XmlDoc.Load(currentLJ + "\\Xml\\BeginInformation.xml");

                NodeList = XmlDoc.GetElementsByTagName("ssq");
                //�ں�
                NodeList[0].Attributes["issus"].Value = value.Issue;
                //��������
                NodeList[0].Attributes["redcode"].Value = value.Code;
                //��������2
                NodeList[0].Attributes["bluecode"].Value = value.TCode;
                //�޸�ʱ��
                NodeList[0].Attributes["date"].Value = value.Date;

                XmlDoc.Save(currentLJ + "\\Xml\\BeginInformation.xml");
            }
        }
        #endregion

        #region ����͸
        /// <summary>
        /// ����͸
        /// </summary>
        /// 
        private static WapBase _webdltBaseConfig;

        public static WapBase webdltBaseConfig
        {
            get
            {
                XmlDocument XmlDoc;
                XmlNodeList NodeList;
                XmlDoc = new XmlDocument();

                XmlDoc.Load(currentLJ + "\\Xml\\BeginInformation.xml");


                NodeList = XmlDoc.GetElementsByTagName("dlt");
                _webdltBaseConfig.Issue = NodeList[0].Attributes["issue"].Value;
                _webdltBaseConfig.Code = NodeList[0].Attributes["code"].Value;
                _webdltBaseConfig.TCode = NodeList[0].Attributes["code2"].Value;
                _webdltBaseConfig.Date = NodeList[0].Attributes["date"].Value;
                return _webdltBaseConfig;
            }
            set
            {
                XmlDocument XmlDoc;
                XmlNodeList NodeList;
                XmlDoc = new XmlDocument();
                XmlDoc.Load(currentLJ + "\\Xml\\BeginInformation.xml");

                NodeList = XmlDoc.GetElementsByTagName("dlt");
                //�ں�
                NodeList[0].Attributes["issus"].Value = value.Issue;
                //��������
                NodeList[0].Attributes["code"].Value = value.Code;
                //��������2
                NodeList[0].Attributes["code2"].Value = value.TCode;
                //�޸�ʱ��
                NodeList[0].Attributes["date"].Value = value.Date;

                XmlDoc.Save(currentLJ + "\\Xml\\BeginInformation.xml");
            }
        }
        #endregion

        #region 22ѡ5
        /// <summary>
        /// 22ѡ5
        /// </summary>
        /// 
        private static WapBase _webeexwBaseConfig;

        public static WapBase webeexwBaseConfig
        {
            get
            {
                XmlDocument XmlDoc;
                XmlNodeList NodeList;
                XmlDoc = new XmlDocument();

                XmlDoc.Load(currentLJ + "\\Xml\\BeginInformation.xml");
                NodeList = XmlDoc.GetElementsByTagName("eexw");
                _webeexwBaseConfig.Issue = NodeList[0].Attributes["issue"].Value;
                _webeexwBaseConfig.Code = NodeList[0].Attributes["code"].Value;
                _webeexwBaseConfig.Date = NodeList[0].Attributes["date"].Value;
                return _webeexwBaseConfig;
            }
            set
            {
                XmlDocument XmlDoc;
                XmlNodeList NodeList;
                XmlDoc = new XmlDocument();
                XmlDoc.Load(currentLJ + "\\Xml\\BeginInformation.xml");

                NodeList = XmlDoc.GetElementsByTagName("eexw");
                //�ں�
                NodeList[0].Attributes["issus"].Value = value.Issue;
                //��������
                NodeList[0].Attributes["code"].Value = value.Code;
                //�޸�ʱ��
                NodeList[0].Attributes["date"].Value = value.Date;

                XmlDoc.Save(currentLJ + "\\Xml\\BeginInformation.xml");
            }
        }
        #endregion
    }
}
