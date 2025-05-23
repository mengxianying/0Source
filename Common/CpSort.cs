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
        /// xml����
        /// </summary>

        ///��������
        public string name;
        /// <summary>
        /// �����ں�
        /// </summary>
        public string issue;
        /// <summary>
        /// ��������
        /// </summary>
        public string code;
        /// <summary>
        /// ��������
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
        /// ����3D�Ŀ���ʱ��
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
        /// ����3D�Ŀ�������
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
        /// ����3D�Ի��ſ���ʱ��
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
