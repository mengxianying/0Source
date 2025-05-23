using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.Common;
using System.Xml;

namespace Common
{
    public struct ChannelAttr
    {
        /// <summary>
        /// xmlƵ��
        /// </summary>

        ///Ƶ�����ID
        public string id;
        /// <summary>
        /// Ƶ���������ɵ�htmlҳ��ַ
        /// </summary>
        public string html;
        /// <summary>
        /// Ƶ��ģ���ַaspxҳ
        /// </summary>
        public string aspx;
        /// <summary>
        /// Ƶ������
        /// </summary>
        public string name;        
    }

    public class Channel
    {
        MyXML xml = new MyXML("\\xml\\ChannelUrl.xml");
        private ChannelAttr temp;
        public ChannelAttr this[string _myIndex]
        {
            get
            {                
                XmlNodeList xnls = xml.GetAllChilds();
                foreach (XmlNode node in xnls)
                {
                    if (node.Attributes["name"].Value == _myIndex)
                    {
                        //                      temp = new CpNodeAttr();
                        temp.id = node.Attributes["id"].Value;
                        temp.html = node.Attributes["html"].Value;
                        temp.aspx = node.Attributes["aspx"].Value;
                        temp.name = node.Attributes["name"].Value;
                        break;
                    }
                }
                return temp;
            }
            set
            {
                XmlNodeList xnls = xml.GetAllChilds();
                foreach (XmlNode node in xnls)
                {
                    if (node.Attributes["name"].Value == _myIndex)
                    {
                        xml.SetAttributeValue(@"Urls/Channel", "id", value.id);
                        xml.SetAttributeValue(@"Urls/Channel", "html", value.html);
                        xml.SetAttributeValue(@"Urls/Channel", "aspx", value.aspx);
                        xml.SetAttributeValue(@"Urls/Channel", "name", value.name);
                        xml.Save();
                        temp = value;
                        break;
                    }
                }
            }
        }
    }
}
