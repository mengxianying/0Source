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
    /// MyXml 的摘要说明
    /// </summary>
    public class MyXML
    {
        private string FileName;
        private XmlElement _element; 
        public MyXML()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        #region 变量
        /**/
        /// <summary>
        /// Xml文件所在路径类型
        /// </summary>
        /// <remarks>Xml文件所在路径类型</remarks>
        public enum enumXmlPathType
        {
            /**/
            /// <summary>
            /// 绝对路径
            /// </summary>
            AbsolutePath,
            /**/
            /// <summary>
            /// 虚拟路径
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


        #region 属性
        private string _xmlFilePath="";
        /**/
        /// <summary>
        /// 文件路径
        /// </summary>
        /// <remarks>文件路径</remarks>
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
        /// 文件路径类型
        /// </summary>
        public enumXmlPathType XmlFilePathTyp
        {
            set
            {
                XmlFilePathType = value;
            }
        }
        #endregion

        #region 构造函数
        /**/
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempXmlFilePath"></param>
        public XmlDocument MyXml(string tempXmlFilePath)
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //

            this.XmlFilePathType = enumXmlPathType.VirtualPath;
            this.XmlFilePath = tempXmlFilePath;
           // XmlDoc.Load(XmlFilePath);
            return GetXmlDocument();
           
        }

        /**/
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="tempXmlFilePath">文件路径</param>
        /// <param name="tempXmlFilePathType">类型</param>
        public XmlDocument MyXml(string tempXmlFilePath, enumXmlPathType tempXmlFilePathType)
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            this.XmlFilePathType = tempXmlFilePathType;
            this.XmlFilePath = tempXmlFilePath;
            return GetXmlDocument();
        }
        #endregion


        /**/
        ///<summary>
        ///获取XmlDocument实体类
        ///</summary>    
        /// <returns>指定的Xml描述文件的一个Xmldocument实例</returns>
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
            //定义事件处理
            XmlDoc.NodeChanged += new XmlNodeChangedEventHandler(this.nodeUpdateEvent);
            XmlDoc.NodeInserted += new XmlNodeChangedEventHandler(this.nodeInsertEvent);
            XmlDoc.NodeRemoved += new XmlNodeChangedEventHandler(this.nodeDeleteEvent);
            return XmlDoc;
        }
        
        #region 读取指定节点的指定属性值
        /**/
        /// <summary>
        /// 功能:
        /// 读取指定节点的指定属性值    
        /// </summary>
        /// <param name="strNode">节点名称</param>
        /// <param name="strAttribute">此节点的属性</param>
        /// <returns></returns>
        public string GetXmlNodeAttributeValue(string strNode, string strAttribute)
        {
            string strReturn = "";
            try
            {
                //根据指定路径获取节点
                XmlNode XmlNode = XmlDoc.SelectSingleNode(strNode);
                if (!(XmlNode == null))
                {//获取节点的属性，并循环取出需要的属性值
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




        #region 读取指定节点的值
        /**/
        /// <summary>
        /// 功能:
        /// 读取指定节点的值    
        /// </summary>
        /// <param name="strNode">节点名称</param>
        /// <returns></returns>
        public string GetXmlNodeValue(string strNode)
        {
            string strReturn = String.Empty;

            try
            {
                //根据路径获取节点
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

        #region 设置节点值
        /**/
        /// <summary>
        /// 功能:
        /// 设置节点值        
        /// </summary>
        /// <param name="strNode">节点的名称</param>
        /// <param name="newValue">节点值</param>
        public void SetXmlNodeValue(string XmlNodePath, string XmlNodeValue)
        {
            try
            {
                //可以批量为符合条件的节点进行付值
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
             * 根据指定路径获取节点
            XmlNode XmlNode = XmlDoc.SelectSingleNode(XmlNodePath) ;            
            //设置节点值
            if (!(XmlNode==null))
                XmlNode.InnerText = XmlNodeValue ;*/
            }
            catch (XmlException Xmle)
            {
                throw Xmle;
            }
        }
        #endregion

        #region 设置节点的属性值
        /**/
        /// <summary>
        /// 功能:
        /// 设置节点的属性值    
        /// </summary>
        /// <param name="XmlNodePath">节点名称</param>
        /// <param name="XmlNodeAttribute">属性名称</param>
        /// <param name="XmlNodeAttributeValue">属性值</param>
        //public void SetXmlNodeAttributeValue(string XmlNodePath, string XmlNodeAttribute, string XmlNodeAttributeValue)
        //{
        //    try
        //    {
        //        //可以批量为符合条件的节点的属性付值
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
        //        /*单个节点
        //    //根据指定路径获取节点
        //    XmlNode XmlNode = XmlDoc.SelectSingleNode(XmlNodePath) ;
        //    if (!(XmlNode==null))
        //    {//获取节点的属性，并循环取出需要的属性值
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

        #region 添加
        /**/
        /// <summary>
        /// 获取Xml文件的根元素
        /// </summary>
        public XmlNode GetXmlRoot()
        {
            return XmlDoc.DocumentElement;
        }

        /**/
        /// <summary>
        /// 在根节点下添加父节点
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
        /// 向一个已经存在的父节点中插入一个子节点
        /// </summary>
        /// <param name="parentNodePath">父节点</param>
        /// <param name="childNodePath">字节点名称</param>
        public void AddChildNode(string parentNodePath, string childnodename)
        {
            try
            {
                XmlNode parentXmlNode = XmlDoc.SelectSingleNode(parentNodePath);
                if (!((parentXmlNode) == null))//如果此节点存在
                {
                    XmlNode childXmlNode = XmlDoc.CreateElement(childnodename);
                    parentXmlNode.AppendChild(childXmlNode);
                }
                else
                {//如果不存在就放父节点添加
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
        /// 向一个节点的属性赋值，如果没有该属性则创建
        /// </summary>
        /// <param name="NodePath">节点路径</param>
        /// <param name="NodeAttribute">属性名</param>
        /// <param name="value">属性值</param>
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
        ///  向一个节点添加属性,并付值
        /// </summary>
        /// <param name="NodePath">节点</param>
        /// <param name="NodeAttribute">属性名</param>
        /// <param name="NodeAttributeValue">属性值</param>
        public void AddAttribute(string NodePath, string NodeAttribute, string NodeAttributeValue)
        {
            privateAddAttribute(NodePath, NodeAttribute, NodeAttributeValue);
        }
        #endregion

        #region 删除
        /**/
        /// <summary>
        /// 删除节点的一个属性
        /// </summary>
        /// <param name="NodePath">节点所在的xpath表达式</param>
        /// <param name="NodeAttribute">属性名</param>
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
        /// 删除节点,当其属性值等于给定的值时
        /// </summary>
        /// <param name="NodePath">节点所在的xpath表达式</param>
        /// <param name="NodeAttribute">属性</param>
        /// <param name="NodeAttributeValue">值</param>
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
        /// 删除节点
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

        #region Xml文档事件
        /**/
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="args"></param>
        private void nodeInsertEvent(Object src, XmlNodeChangedEventArgs args)
        {
            //保存设置
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
            //保存设置
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
            //保存设置
            SaveXmlDocument();
        }
        #endregion

        #region 保存Xml文件
        /**/
        /// <summary>
        /// 功能: 
        /// 保存Xml文件
        /// 
        /// </summary>
        public void SaveXmlDocument()
        {
            try
            {
                //保存设置的结果
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
        /// 功能: 
        /// 保存Xml文件    
        /// </summary>
        public void SaveXmlDocument(string tempXmlFilePath)
        {
            try
            {
                //保存设置的结果
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
        /// 获得所有根节点下的子结点的集合
        /// </summary>
        /// <returns>根节点的所有子结点</returns>
        public XmlNodeList GetAllChilds()
        {
            //先建立一个XML DOM
            XmlDocument doc = new XmlDocument();
            //读入XML文件
            doc.Load(FileName);
            _element = doc.DocumentElement;
            return _element.ChildNodes;
        }





        #region 保存XML文件
        /// <summary>
        /// 保存XML文件
        /// </summary>        
        public void Save()
        {
            //先建立一个XML DOM
            XmlDocument doc = new XmlDocument();
            //读入XML文件
            doc.Load(FileName);

            //保存XML文件
            doc.Save(this.FileName);
        }
        #endregion //保存XML文件


        #region 获取指定XPath表达式节点的属性值
        /// <summary>
        /// 获取指定XPath表达式节点的属性值
        /// </summary>
        /// <param name="xPath">XPath表达式,
        /// 范例1: @"Skill/First/SkillItem", 等效于 @"//Skill/First/SkillItem"
        /// 范例2: @"Table[USERNAME='a']" , []表示筛选,USERNAME是Table下的一个子节点.
        /// 范例3: @"ApplyPost/Item[@itemName='岗位编号']",@itemName是Item节点的属性.
        /// </param>
        /// <param name="attributeName">属性名</param>
        public string GetAttributeValue(string xPath, string attributeName)
        {
            //先建立一个XML DOM
            XmlDocument doc = new XmlDocument();
            //读入XML文件
            doc.Load(FileName);
            _element = doc.DocumentElement;
            //返回XPath节点的属性值
            return _element.SelectSingleNode(xPath).Attributes[attributeName].Value;
        }
        #endregion


        #region 给指定XPath表达式节点的属性赋值
        /// <summary>
        /// 设置XPath表达式节点的属性值
        /// </summary>
        /// <param name="xPath">XPath表达式,
        /// 范例1: @"Skill/First/SkillItem", 等效于 @"//Skill/First/SkillItem"
        /// 范例2: @"Table[USERNAME='a']" , []表示筛选,USERNAME是Table下的一个子节点.
        /// 范例3: @"ApplyPost/Item[@itemName='岗位编号']",@itemName是Item节点的属性.
        /// </param>
        /// <param name="attributeName">属性名</param>
        public void SetAttributeValue(string xPath, string attributeName, string value)
        {
            //先建立一个XML DOM
            XmlDocument doc = new XmlDocument();
            //读入XML文件
            doc.Load(FileName);
            _element = doc.DocumentElement;
            //返回XPath节点的属性值
            _element.SelectSingleNode(xPath).Attributes[attributeName].Value = value;
        }
        #endregion



        public static System.Collections.Specialized.NameValueCollection GetXMLValues(string XmlFile)
        {
            XmlDocument doc = new XmlDocument();
            //读入XML文件
            doc.Load(XmlFile);
            //建立一个节点。
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
