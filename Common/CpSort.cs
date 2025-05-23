using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Xml;

namespace Pbzx.Common
{
    public struct CpNodeAttr
    {
        /// <summary>
        /// xml彩种
        /// </summary>

        ///彩种名称
        public string name;
        /// <summary>
        /// 彩种期号
        /// </summary>
        public string issue;
        /// <summary>
        /// 开奖号码
        /// </summary>
        public string code;
        /// <summary>
        /// 开奖日期
        /// </summary>
        public string Lott_date;
        /// <summary>
        /// 
        /// </summary>
        public string value;
    }

    public class CpSort
    {

        MyXML xml = null;
        private ArrayList ls = new ArrayList();
        public CpSort(string xmlPath)
        {
            xml = new MyXML(xmlPath);
        }
        private CpNodeAttr temp;
        public CpNodeAttr this[string _myIndex]
        {
            get
            {
                XmlNode node = xml.GetXmlRoot().SelectSingleNode("//" + _myIndex);
                temp.value = "aa";
                if (node != null)
                {
                    temp.Lott_date = node.Attributes["date"].Value;
                }
                return temp;
            }
        }

        private string _fC3DDataValue;

        /// <summary>
        /// 福彩3D的开奖时间
        /// </summary>
        public string FC3DDataValue
        {
            get
            {
                _fC3DDataValue = xml.GetAttributeValue(@"WebCpSort/FC3DData", "value");
                return _fC3DDataValue;
            }
            set
            {
                xml.SetAttributeValue(@"WebCpSort/FC3DData", "value", value);
                xml.Save();
                _fC3DDataValue = value;
            }
        }

        private string _fC3DDataDate;
        /// <summary>
        /// 福彩3D的开奖周期
        /// </summary>
        public string FC3DDataDate
        {
            get
            {
                _fC3DDataDate = xml.GetAttributeValue(@"WebCpSort/FC3DData", "Lott_date");
                return _fC3DDataDate;
            }
            set
            {
                xml.SetAttributeValue(@"WebCpSort/FC3DData", "Lott_date", value);
                xml.Save();
                _fC3DDataDate = value;
            }
        }

        private string _fC3DDataTestValue;
        /// <summary>
        /// 福彩3D试机号开奖时间
        /// </summary>
        public string FC3DDataTestValue
        {
            get
            {
                _fC3DDataTestValue = xml.GetAttributeValue(@"WebCpSort/FC3DDataTest", "value");
                return _fC3DDataTestValue;
            }
            set
            {
                xml.SetAttributeValue(@"WebCpSort/FC3DDataTest", "value", value);
                xml.Save();
                _fC3DDataTestValue = value;
            }
        }




    }
}
