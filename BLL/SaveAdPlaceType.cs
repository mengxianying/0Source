using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Pbzx.Common;

namespace Pbzx.BLL
{
    public  class SaveAdPlaceType
    {
        public List<Pbzx.Model.ObjAdPlace> GetAllList()
        {
            List<Pbzx.Model.ObjAdPlace> lsResult = new List<Pbzx.Model.ObjAdPlace>();
            string[] MyArray = Enum.GetNames(typeof(EadPlaceType));
            Array MyValue = Enum.GetValues(typeof(EadPlaceType));


            Pbzx.Common.MyXML xml = new Pbzx.Common.MyXML("\\xml\\AdTypeConfig.xml");
            XmlNode root = xml.GetXmlRoot();

            //root.RemoveAll();

            for (int i = 0; i < root.ChildNodes.Count; i++)
            {
                Pbzx.Model.ObjAdPlace objModel = new Pbzx.Model.ObjAdPlace();
                XmlNode tempNode = root.SelectSingleNode("/root/child_"+i);
                if(tempNode == null)
                {
                    break;
                }
                objModel.Id = int.Parse(tempNode.Attributes["id"].Value);
                objModel.Name = tempNode.Attributes["name"].Value;
                objModel.Channel = tempNode.Attributes["channel"].Value;
                objModel.RowAndCol = tempNode.Attributes["rowAndCol"].Value;
                int width = 0;
                int height = 0;
                if (!string.IsNullOrEmpty(tempNode.Attributes["PlaceWidth"].Value))
                {
                    width = int.Parse(tempNode.Attributes["PlaceWidth"].Value);
                }
                if (!string.IsNullOrEmpty(tempNode.Attributes["PlaceHeight"].Value))
                {
                    height = int.Parse(tempNode.Attributes["PlaceHeight"].Value);
                }
                objModel.PlaceWidth = width;
                objModel.PlaceHeight = height;
                int typeid = 0;
                
                if (tempNode.Attributes["TypeID"] != null && !string.IsNullOrEmpty(tempNode.Attributes["TypeID"].Value))
                {
                    typeid = int.Parse(tempNode.Attributes["TypeID"].Value);
                }
                objModel.TypeID =typeid;

                bool open = true;

                if (tempNode.Attributes["IsOpen"] != null && !string.IsNullOrEmpty(tempNode.Attributes["IsOpen"].Value))
                {
                    open = tempNode.Attributes["IsOpen"].Value == "1" ? true : false; 
                }
                objModel.IsOpen = open;
            
                lsResult.Add(objModel);
            }

            if (lsResult.Count > 1)
            {
                Pbzx.Model.ObjAdPlace adM = new Pbzx.Model.ObjAdPlace();
                lsResult.Sort(adM);
            }

            return lsResult;
        }

        public bool Update(Pbzx.Model.ObjAdPlace model)
        {
            try
            {
                Pbzx.Common.MyXML xml = new Pbzx.Common.MyXML("\\xml\\AdTypeConfig.xml");
                XmlNode root = xml.GetXmlRoot();
                XmlNode tempNode = root.SelectSingleNode("/root/child_" + model.Id);
                tempNode.Attributes["id"].Value = model.Id.ToString();
                tempNode.Attributes["name"].Value = model.Name;
                tempNode.Attributes["channel"].Value = model.Channel;
                tempNode.Attributes["rowAndCol"].Value = model.RowAndCol;
                tempNode.Attributes["PlaceWidth"].Value = model.PlaceWidth.ToString();
                tempNode.Attributes["PlaceHeight"].Value = model.PlaceHeight.ToString();
                tempNode.Attributes["TypeID"].Value = model.TypeID.ToString();
                tempNode.Attributes["IsOpen"].Value = model.IsOpen ? "1" : "0"; 
                xml.SaveXmlDocument();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
