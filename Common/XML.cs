using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Web.Caching;
using System.Web;
using System.Configuration;
using System.Data;

namespace Pbzx.Common
{
    /// <summary>
    /// MyXml ��ժҪ˵��
    /// </summary>
    public class MyXML
    {
        private string FileName;
        private XmlElement _element; 
        public MyXML()
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
            //
        }
        #region ����
        /**/
        /// <summary>
        /// Xml�ļ�����·������
        /// </summary>
        /// <remarks>Xml�ļ�����·������</remarks>
        public enum enumXmlPathType
        {
            /**/
            /// <summary>
            /// ����·��
            /// </summary>
            AbsolutePath,
            /**/
            /// <summary>
            /// ����·��
            /// </summary>
            VirtualPath
        }

        //private string XmlFilePath ;
        private enumXmlPathType XmlFilePathType;
        public XmlDocument XmlDoc = new XmlDocument();

        public MyXML(string path)
        {
            this.FileName = HttpRuntime.AppDomainAppPath + path;
            XmlDoc = MyXml(path);
        }

        #endregion


        #region ����
        private string _xmlFilePath="";
        /**/
        /// <summary>
        /// �ļ�·��
        /// </summary>
        /// <remarks>�ļ�·��</remarks>
        public string XmlFilePath
        {
            get
            {
                return this._xmlFilePath;
            }
            set
            {
                _xmlFilePath = value;

            }
        }

        /**/
        /// <summary>
        /// �ļ�·������
        /// </summary>
        public enumXmlPathType XmlFilePathTyp
        {
            set
            {
                XmlFilePathType = value;
            }
        }
        #endregion

        #region ���캯��
        /**/
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempXmlFilePath"></param>
        public XmlDocument MyXml(string tempXmlFilePath)
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
            //

            this.XmlFilePathType = enumXmlPathType.VirtualPath;
            this.XmlFilePath = tempXmlFilePath;
           // XmlDoc.Load(XmlFilePath);
            return GetXmlDocument();
           
        }

        /**/
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="tempXmlFilePath">�ļ�·��</param>
        /// <param name="tempXmlFilePathType">����</param>
        public XmlDocument MyXml(string tempXmlFilePath, enumXmlPathType tempXmlFilePathType)
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
            //
            this.XmlFilePathType = tempXmlFilePathType;
            this.XmlFilePath = tempXmlFilePath;
            return GetXmlDocument();
        }
        #endregion


        /**/
        ///<summary>
        ///��ȡXmlDocumentʵ����
        ///</summary>    
        /// <returns>ָ����Xml�����ļ���һ��Xmldocumentʵ��</returns>
        private XmlDocument GetXmlDocument()
        {
            XmlDocument doc = null;

            if (this.XmlFilePathType == enumXmlPathType.AbsolutePath)
            {
                doc = GetXmlDocumentFromFile(XmlFilePath);
            }
            else if (this.XmlFilePathType == enumXmlPathType.VirtualPath)
            {
                doc = GetXmlDocumentFromFile(HttpContext.Current.Server.MapPath(XmlFilePath));
            }
            return doc;
        }

        private XmlDocument GetXmlDocumentFromFile(string tempXmlFilePath)
        {
            string XmlFileFullPath = tempXmlFilePath;
            XmlDoc.Load(XmlFileFullPath);
            //�����¼�����
            XmlDoc.NodeChanged += new XmlNodeChangedEventHandler(this.nodeUpdateEvent);
            XmlDoc.NodeInserted += new XmlNodeChangedEventHandler(this.nodeInsertEvent);
            XmlDoc.NodeRemoved += new XmlNodeChangedEventHandler(this.nodeDeleteEvent);
            return XmlDoc;
        }
        
        #region ��ȡָ���ڵ��ָ������ֵ
        /**/
        /// <summary>
        /// ����:
        /// ��ȡָ���ڵ��ָ������ֵ    
        /// </summary>
        /// <param name="strNode">�ڵ�����</param>
        /// <param name="strAttribute">�˽ڵ������</param>
        /// <returns></returns>
        public string GetXmlNodeAttributeValue(string strNode, string strAttribute)
        {
            string strReturn = "";
            try
            {
                //����ָ��·����ȡ�ڵ�
                XmlNode XmlNode = XmlDoc.SelectSingleNode(strNode);
                if (!(XmlNode == null))
                {//��ȡ�ڵ�����ԣ���ѭ��ȡ����Ҫ������ֵ
                    XmlAttributeCollection XmlAttr = XmlNode.Attributes;

                    for (int i = 0; i < XmlAttr.Count; i++)
                    {
                        if (XmlAttr.Item(i).Name == strAttribute)
                        {
                            strReturn = XmlAttr.Item(i).Value;
                            break;
                        }
                    }
                }
            }
            catch (XmlException Xmle)
            {
                throw Xmle;
            }
            return strReturn;
        }
        #endregion




        #region ��ȡָ���ڵ��ֵ
        /**/
        /// <summary>
        /// ����:
        /// ��ȡָ���ڵ��ֵ    
        /// </summary>
        /// <param name="strNode">�ڵ�����</param>
        /// <returns></returns>
        public string GetXmlNodeValue(string strNode)
        {
            string strReturn = String.Empty;

            try
            {
                //����·����ȡ�ڵ�
                XmlNode XmlNode = XmlDoc.SelectSingleNode(strNode);
                if (!(XmlNode == null))
                    strReturn = XmlNode.InnerText;
            }
            catch (XmlException Xmle)
            {
                throw Xmle;
            }
            return strReturn;
        }
        #endregion

        #region ���ýڵ�ֵ
        /**/
        /// <summary>
        /// ����:
        /// ���ýڵ�ֵ        
        /// </summary>
        /// <param name="strNode">�ڵ������</param>
        /// <param name="newValue">�ڵ�ֵ</param>
        public void SetXmlNodeValue(string XmlNodePath, string XmlNodeValue)
        {
            try
            {
                //��������Ϊ���������Ľڵ���и�ֵ
                XmlNodeList XmlNode = this.XmlDoc.SelectNodes(XmlNodePath);
                if (!(XmlNode == null))
                {
                    foreach (XmlNode xn in XmlNode)
                    {
                        xn.InnerText = XmlNodeValue;
                    }
                }
                /**/
                /*
             * ����ָ��·����ȡ�ڵ�
            XmlNode XmlNode = XmlDoc.SelectSingleNode(XmlNodePath) ;            
            //���ýڵ�ֵ
            if (!(XmlNode==null))
                XmlNode.InnerText = XmlNodeValue ;*/
            }
            catch (XmlException Xmle)
            {
                throw Xmle;
            }
        }
        #endregion

        #region ���ýڵ������ֵ
        /**/
        /// <summary>
        /// ����:
        /// ���ýڵ������ֵ    
        /// </summary>
        /// <param name="XmlNodePath">�ڵ�����</param>
        /// <param name="XmlNodeAttribute">��������</param>
        /// <param name="XmlNodeAttributeValue">����ֵ</param>
        //public void SetXmlNodeAttributeValue(string XmlNodePath, string XmlNodeAttribute, string XmlNodeAttributeValue)
        //{
        //    try
        //    {
        //        //��������Ϊ���������Ľڵ�����Ը�ֵ
        //        XmlNodeList XmlNode = this.XmlDoc.SelectNodes(XmlNodePath);
        //        if (!(XmlNode == null))
        //        {
        //            foreach (XmlNode xn in XmlNode)
        //            {
        //                XmlAttributeCollection XmlAttr = xn.Attributes;
        //                for (int i = 0; i < XmlAttr.Count; i++)
        //                {
        //                    if (XmlAttr.Item(i).Name == XmlNodeAttribute)
        //                    {
        //                        XmlAttr.Item(i).Value = XmlNodeAttributeValue;
        //                        break;
        //                    }
        //                }
        //            }
        //        }
        //        /**/
        //        /*�����ڵ�
        //    //����ָ��·����ȡ�ڵ�
        //    XmlNode XmlNode = XmlDoc.SelectSingleNode(XmlNodePath) ;
        //    if (!(XmlNode==null))
        //    {//��ȡ�ڵ�����ԣ���ѭ��ȡ����Ҫ������ֵ
        //        XmlAttributeCollection XmlAttr = XmlNode.Attributes ;
        //        for(int i=0 ; i<XmlAttr.Count ; i++)
        //        {
        //            if ( XmlAttr.Item(i).Name == XmlNodeAttribute )
        //            {
        //                XmlAttr.Item(i).Value = XmlNodeAttributeValue;
        //                break ;
        //            }
        //        }    
        //    }
        //    */
        //    }
        //    catch (XmlException Xmle)
        //    {
        //        throw Xmle;
        //    }
        //}
        #endregion

        #region ���
        /**/
        /// <summary>
        /// ��ȡXml�ļ��ĸ�Ԫ��
        /// </summary>
        public XmlNode GetXmlRoot()
        {
            return XmlDoc.DocumentElement;
        }

        /**/
        /// <summary>
        /// �ڸ��ڵ�����Ӹ��ڵ�
        /// </summary>
        public void AddParentNode(string parentNode)
        {
            try
            {
                XmlNode root = GetXmlRoot();
                XmlNode parentXmlNode = XmlDoc.CreateElement(parentNode);
                root.AppendChild(parentXmlNode);
            }
            catch (XmlException Xmle)
            {
                throw Xmle;
            }
        }

        /**/
        /// <summary>
        /// ��һ���Ѿ����ڵĸ��ڵ��в���һ���ӽڵ�
        /// </summary>
        /// <param name="parentNodePath">���ڵ�</param>
        /// <param name="childNodePath">�ֽڵ�����</param>
        public void AddChildNode(string parentNodePath, string childnodename)
        {
            try
            {
                XmlNode parentXmlNode = XmlDoc.SelectSingleNode(parentNodePath);
                if (!((parentXmlNode) == null))//����˽ڵ����
                {
                    XmlNode childXmlNode = XmlDoc.CreateElement(childnodename);
                    parentXmlNode.AppendChild(childXmlNode);
                }
                else
                {//��������ھͷŸ��ڵ����
                    //this.GetXmlRoot().AppendChild(childXmlNode);
                }

            }
            catch (XmlException Xmle)
            {
                throw Xmle;
            }
        }

        /**/
        /// <summary>
        /// ��һ���ڵ�����Ը�ֵ�����û�и������򴴽�
        /// </summary>
        /// <param name="NodePath">�ڵ�·��</param>
        /// <param name="NodeAttribute">������</param>
        /// <param name="value">����ֵ</param>
        public void SetAttribute(string NodePath, string NodeAttribute,string value)
        {
            try
            {
                XmlNode nodePath = XmlDoc.SelectSingleNode(NodePath);
                XmlAttribute attr = nodePath.Attributes[NodeAttribute];
                if (attr == null)
                {
                    XmlAttribute nodeAttribute = this.XmlDoc.CreateAttribute(NodeAttribute);
                    nodeAttribute.Value = value;
                    nodePath.Attributes.Append(nodeAttribute);
                }
                else
                {
                    attr.Value = value;
                }

            }
            catch(XmlException xmlE)
            {
                throw xmlE;
            }
        }
        /**/
        /// <summary>
        /// 
        /// </summary>
        /// <param name="NodePath"></param>
        /// <param name="NodeAttribute"></param>
        /// <param name="NodeAttributeValue"></param>
        private void privateAddAttribute(string NodePath, string NodeAttribute, string NodeAttributeValue)
        {
            try
            {
                XmlNode nodePath = XmlDoc.SelectSingleNode(NodePath);
                if (!(nodePath == null))
                {
                    XmlAttribute nodeAttribute = this.XmlDoc.CreateAttribute(NodeAttribute);
                    nodeAttribute.Value = NodeAttributeValue;
                    nodePath.Attributes.Append(nodeAttribute);
                }
            }
            catch (XmlException Xmle)
            {
                throw Xmle;
            }
        }
        /**/
        /// <summary>
        ///  ��һ���ڵ��������,����ֵ
        /// </summary>
        /// <param name="NodePath">�ڵ�</param>
        /// <param name="NodeAttribute">������</param>
        /// <param name="NodeAttributeValue">����ֵ</param>
        public void AddAttribute(string NodePath, string NodeAttribute, string NodeAttributeValue)
        {
            privateAddAttribute(NodePath, NodeAttribute, NodeAttributeValue);
        }
        #endregion

        #region ɾ��
        /**/
        /// <summary>
        /// ɾ���ڵ��һ������
        /// </summary>
        /// <param name="NodePath">�ڵ����ڵ�xpath���ʽ</param>
        /// <param name="NodeAttribute">������</param>
        public void DeleteAttribute(string NodePath, string NodeAttribute)
        {
            XmlNodeList nodePath = this.XmlDoc.SelectNodes(NodePath);
            if (!(nodePath == null))
            {
                foreach (XmlNode tempxn in nodePath)
                {
                    XmlAttributeCollection XmlAttr = tempxn.Attributes;
                    for (int i = 0; i < XmlAttr.Count; i++)
                    {
                        if (XmlAttr.Item(i).Name == NodeAttribute)
                        {
                            tempxn.Attributes.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
        }

        /**/
        /// <summary>
        /// ɾ���ڵ�,��������ֵ���ڸ�����ֵʱ
        /// </summary>
        /// <param name="NodePath">�ڵ����ڵ�xpath���ʽ</param>
        /// <param name="NodeAttribute">����</param>
        /// <param name="NodeAttributeValue">ֵ</param>
        public void DeleteAttribute(string NodePath, string NodeAttribute, string NodeAttributeValue)
        {
            XmlNodeList nodePath = this.XmlDoc.SelectNodes(NodePath);
            if (!(nodePath == null))
            {
                foreach (XmlNode tempxn in nodePath)
                {
                    XmlAttributeCollection XmlAttr = tempxn.Attributes;
                    for (int i = 0; i < XmlAttr.Count; i++)
                    {
                        if (XmlAttr.Item(i).Name == NodeAttribute && XmlAttr.Item(i).Value == NodeAttributeValue)
                        {
                            tempxn.Attributes.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
        }
        /**/
        /// <summary>
        /// ɾ���ڵ�
        /// </summary>
        /// <param name="tempXmlNode"></param>
        /// <remarks></remarks>
        public void DeleteXmlNode(string tempXmlNode)
        {
            XmlNodeList nodePath = this.XmlDoc.SelectNodes(tempXmlNode);
            if (!(nodePath == null))
            {
                foreach (XmlNode xn in nodePath)
                {
                    xn.ParentNode.RemoveChild(xn);
                }
            }
        }

        #endregion

        #region Xml�ĵ��¼�
        /**/
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="args"></param>
        private void nodeInsertEvent(Object src, XmlNodeChangedEventArgs args)
        {
            //��������
            SaveXmlDocument();
        }
        /**/
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="args"></param>
        private void nodeDeleteEvent(Object src, XmlNodeChangedEventArgs args)
        {
            //��������
            SaveXmlDocument();
        }
        /**/
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="args"></param>
        private void nodeUpdateEvent(Object src, XmlNodeChangedEventArgs args)
        {
            //��������
            SaveXmlDocument();
        }
        #endregion

        #region ����Xml�ļ�
        /**/
        /// <summary>
        /// ����: 
        /// ����Xml�ļ�
        /// 
        /// </summary>
        public void SaveXmlDocument()
        {
            try
            {
                //�������õĽ��
                if (this.XmlFilePathType == enumXmlPathType.AbsolutePath)
                {
                    SaveXml(XmlFilePath);
                }
                else if (this.XmlFilePathType == enumXmlPathType.VirtualPath)
                {
                    SaveXml(HttpContext.Current.Server.MapPath(XmlFilePath));
                }
            }
            catch (XmlException Xmle)
            {
                throw Xmle;
            }
        }

        /**/
        /// <summary>
        /// ����: 
        /// ����Xml�ļ�    
        /// </summary>
        public void SaveXmlDocument(string tempXmlFilePath)
        {
            try
            {
                //�������õĽ��
                SaveXml(tempXmlFilePath);
            }
            catch (XmlException Xmle)
            {
                throw Xmle;
            }
        }
        /**/
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filepath"></param>
        private void SaveXml(string filepath)
        {
            XmlDoc.Save(filepath);
        }







        #endregion

        /// <summary>
        /// ������и��ڵ��µ��ӽ��ļ���
        /// </summary>
        /// <returns>���ڵ�������ӽ��</returns>
        public XmlNodeList GetAllChilds()
        {
            //�Ƚ���һ��XML DOM
            XmlDocument doc = new XmlDocument();
            //����XML�ļ�
            doc.Load(FileName);
            _element = doc.DocumentElement;
            return _element.ChildNodes;
        }





        #region ����XML�ļ�
        /// <summary>
        /// ����XML�ļ�
        /// </summary>        
        public void Save()
        {
            //�Ƚ���һ��XML DOM
            XmlDocument doc = new XmlDocument();
            //����XML�ļ�
            doc.Load(FileName);

            //����XML�ļ�
            doc.Save(this.FileName);
        }
        #endregion //����XML�ļ�


        #region ��ȡָ��XPath���ʽ�ڵ������ֵ
        /// <summary>
        /// ��ȡָ��XPath���ʽ�ڵ������ֵ
        /// </summary>
        /// <param name="xPath">XPath���ʽ,
        /// ����1: @"Skill/First/SkillItem", ��Ч�� @"//Skill/First/SkillItem"
        /// ����2: @"Table[USERNAME='a']" , []��ʾɸѡ,USERNAME��Table�µ�һ���ӽڵ�.
        /// ����3: @"ApplyPost/Item[@itemName='��λ���']",@itemName��Item�ڵ������.
        /// </param>
        /// <param name="attributeName">������</param>
        public string GetAttributeValue(string xPath, string attributeName)
        {
            //�Ƚ���һ��XML DOM
            XmlDocument doc = new XmlDocument();
            //����XML�ļ�
            doc.Load(FileName);
            _element = doc.DocumentElement;
            //����XPath�ڵ������ֵ
            return _element.SelectSingleNode(xPath).Attributes[attributeName].Value;
        }
        #endregion


        #region ��ָ��XPath���ʽ�ڵ�����Ը�ֵ
        /// <summary>
        /// ����XPath���ʽ�ڵ������ֵ
        /// </summary>
        /// <param name="xPath">XPath���ʽ,
        /// ����1: @"Skill/First/SkillItem", ��Ч�� @"//Skill/First/SkillItem"
        /// ����2: @"Table[USERNAME='a']" , []��ʾɸѡ,USERNAME��Table�µ�һ���ӽڵ�.
        /// ����3: @"ApplyPost/Item[@itemName='��λ���']",@itemName��Item�ڵ������.
        /// </param>
        /// <param name="attributeName">������</param>
        public void SetAttributeValue(string xPath, string attributeName, string value)
        {
            //�Ƚ���һ��XML DOM
            XmlDocument doc = new XmlDocument();
            //����XML�ļ�
            doc.Load(FileName);
            _element = doc.DocumentElement;
            //����XPath�ڵ������ֵ
            _element.SelectSingleNode(xPath).Attributes[attributeName].Value = value;
        }
        #endregion



        public static System.Collections.Specialized.NameValueCollection GetXMLValues(string XmlFile)
        {
            XmlDocument doc = new XmlDocument();
            //����XML�ļ�
            doc.Load(XmlFile);
            //����һ���ڵ㡣
            XmlNodeList ChildList = doc.DocumentElement.ChildNodes;
            System.Collections.Specialized.NameValueCollection result = new System.Collections.Specialized.NameValueCollection();
            foreach (XmlNode child in doc.DocumentElement.ChildNodes)
            {
                result.Add(child.Name, child.InnerText);
            }
            return result;
        }


    }
}
