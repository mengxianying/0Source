using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Pbzx.Common;
using Common;
using System.Xml;
using System.Collections.Generic;
using Maticsoft.DBUtility;
namespace Pbzx.Web.PB_Manage
{
    public partial class AdPlaceSum : AdminBasic
    {
        //string xmlPath = "xml/AdTypeConfig.xml";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Method.BindAdChanl(this.ddlNewChannel);
                Method.BindAdClass(this.ddlNewType);
                LoadData();                
            }
        }

        private void LoadData()
        {
            Pbzx.BLL.SaveAdPlaceType saveBll = new Pbzx.BLL.SaveAdPlaceType();
            List<Pbzx.Model.ObjAdPlace> ls = saveBll.GetAllList();
            this.MyGridView.DataSource = ls;
            this.MyGridView.DataBind();
            for (int i = 0; i <= MyGridView.Rows.Count - 1; i++)
            {
                Pbzx.Model.ObjAdPlace model = ls[i];                
                DropDownList ddl = (DropDownList)MyGridView.Rows[i].FindControl("DropDownList1");
                Method.BindAdChanl(ddl);
                ddl.SelectedValue = ((int)((EadChanl)Enum.Parse(typeof(EadChanl), model.Channel))).ToString();

                DropDownList ddlType = (DropDownList)MyGridView.Rows[i].FindControl("ddlType");
                Method.BindAdClass(ddlType);
                ddlType.SelectedValue = model.TypeID.ToString();

                RadioButtonList rblIsOpen = (RadioButtonList)MyGridView.Rows[i].FindControl("rblIsOpen");
                rblIsOpen.Items[0].Selected = model.IsOpen;
                rblIsOpen.Items[1].Selected = !model.IsOpen;
            }
        }
        protected void btnInit_Click(object sender, EventArgs e)
        {
            string[] MyArray = Enum.GetNames(typeof(EadPlaceType));
            Array MyValue = Enum.GetValues(typeof(EadPlaceType));
            Pbzx.Common.MyXML xml = new Pbzx.Common.MyXML("\\xml\\AdTypeConfig.xml");
            XmlNode root = xml.GetXmlRoot();
            root.RemoveAll();

            for (int i = 0; i < MyArray.Length;i++ )
            {
                XmlNode tempNode = xml.XmlDoc.CreateElement("child_"+i);
                XmlAttribute xmlAttrID =  xml.XmlDoc.CreateAttribute("id");
                XmlAttribute xmlAttrName = xml.XmlDoc.CreateAttribute("name");
                XmlAttribute xmlAttrChannel = xml.XmlDoc.CreateAttribute("channel");
                XmlAttribute xmlAttrRowAndCol = xml.XmlDoc.CreateAttribute("rowAndCol");
                XmlAttribute xmlAttrPlaceWidth = xml.XmlDoc.CreateAttribute("PlaceWidth");
                XmlAttribute xmlAttrPlaceHeight = xml.XmlDoc.CreateAttribute("PlaceHeight");
                XmlAttribute xmlAttrTypeID = xml.XmlDoc.CreateAttribute("TypeID");
                XmlAttribute xmlIsOpen = xml.XmlDoc.CreateAttribute("IsOpen");
                //
                xmlAttrID.Value = i.ToString();
                xmlAttrName.Value = MyArray[i];
                xmlAttrChannel.Value = Enum.Parse(typeof(EadChanl), "0").ToString();
                xmlAttrRowAndCol.Value = "0*0";
                xmlAttrPlaceWidth.Value = "0";
                xmlAttrPlaceHeight.Value = "0";
                xmlAttrTypeID.Value = "0";
                xmlIsOpen.Value = "1";
               
                tempNode.Attributes.Append(xmlAttrID);
                tempNode.Attributes.Append(xmlAttrName);
                tempNode.Attributes.Append(xmlAttrChannel);
                tempNode.Attributes.Append(xmlAttrRowAndCol);
                tempNode.Attributes.Append(xmlAttrPlaceWidth);
                tempNode.Attributes.Append(xmlAttrPlaceHeight);
                tempNode.Attributes.Append(xmlAttrTypeID);
                tempNode.Attributes.Append(xmlIsOpen);

                root.AppendChild(tempNode);
            }
            xml.SaveXmlDocument();
        }

        protected string GetAllList()
        {
            return "";
        }

        protected void MyGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            MyGridView.EditIndex = e.NewEditIndex;
            //TextBox txtRow = ((TextBox)MyGridView.Rows[e.NewEditIndex].FindControl("txtRow"));
            //TextBox txtCol = ((TextBox)MyGridView.Rows[e.NewEditIndex].FindControl("txtCol"));
            //string value = txtRow.Text;
            //txtRow.Text = value.Split(new char[] { '*' })[0];
            //txtCol.Text = value.Split(new char[] { '*' })[1];
            LoadData();            
        }

        protected void MyGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            MyGridView.EditIndex = -1;
            LoadData();
        }

        protected void MyGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string id = MyGridView.DataKeys[e.RowIndex].Values[0].ToString();
            string name = ((TextBox)MyGridView.Rows[e.RowIndex].FindControl("txtName")).Text;
            string chanel = ((DropDownList)MyGridView.Rows[e.RowIndex].FindControl("DropDownList1")).SelectedItem.Text;
            string rowAndCol = ((TextBox)MyGridView.Rows[e.RowIndex].FindControl("txtRow")).Text;

            string PlaceWidth = ((TextBox)MyGridView.Rows[e.RowIndex].FindControl("txtPlaceWidth")).Text;
            string PlaceHeight = ((TextBox)MyGridView.Rows[e.RowIndex].FindControl("txtPlaceHeight")).Text;

            string typeID = ((DropDownList)MyGridView.Rows[e.RowIndex].FindControl("ddlType")).SelectedValue;
            bool  isOpen = ((RadioButtonList)MyGridView.Rows[e.RowIndex].FindControl("rblIsOpen")).Items[0].Selected;  

            string[] rowCols = rowAndCol.Split(new char[]{'*'});
            int introw = 0;
            int intcol = 0;
            int pWidth = 0;
            int pHeight = 0;
            if (rowCols.Length == 2 && int.TryParse(rowCols[0], out introw) && int.TryParse(rowCols[1], out intcol))
            {
                if(!int.TryParse(PlaceWidth,out pWidth))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "error2", JS.Alert("宽度设置不正确！\\r\\n请填写数字"));
                    return;
                }
                if (!int.TryParse(PlaceHeight, out pHeight))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "error2", JS.Alert("高度设置不正确！\\r\\n请填写数字"));
                    return;
                }

                Pbzx.Model.ObjAdPlace model = new Pbzx.Model.ObjAdPlace();
                model.Id = int.Parse(id);
                model.Name = name;
                model.Channel = chanel;
                model.RowAndCol = rowAndCol;
                model.PlaceWidth = pWidth;
                model.PlaceHeight = pHeight;
                model.TypeID = int.Parse(typeID);
                model.IsOpen = isOpen;

                Pbzx.BLL.SaveAdPlaceType saveBll = new Pbzx.BLL.SaveAdPlaceType();
                if (saveBll.Update(model))
                {                    
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "error1", JS.Alert("更新失败！"));
                    return;
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "error2", JS.Alert("行列设置不正确！\\r\\n例：[3行2列请填写：3*2]"));
                return;
            }
            MyGridView.EditIndex = -1;
            LoadData();            
        }

        protected void btnAdPlaces_Click(object sender, EventArgs e)
        {
            DbHelperSQL.ExecuteSql(" truncate table PBnet_AdvPlace ");
            Pbzx.BLL.SaveAdPlaceType saveBll = new Pbzx.BLL.SaveAdPlaceType();
            List<Pbzx.Model.ObjAdPlace> ls = saveBll.GetAllList();
            int count = 0;
            for(int i= 0; i<ls.Count ; i++)
            {
                Pbzx.Model.ObjAdPlace tempModel = ls[i];
                string[] rowCols = tempModel.RowAndCol.Split(new char[] { '*'});
                int introw = 0;
                int intcol = 0;
                if (rowCols.Length == 2 && int.TryParse(rowCols[0], out introw) && int.TryParse(rowCols[1], out intcol))
                {
                    for (int j = 0; j < introw;j++ )
                    {
                        for (int k = 0; k < intcol; k++ )
                        {
                            count++;
                            Pbzx.Model.PBnet_AdvPlace pModel = new Pbzx.Model.PBnet_AdvPlace();
                            pModel.ChannelID = ((int)((EadChanl)Enum.Parse(typeof(EadChanl), tempModel.Channel)));
                            pModel.ID = count;
                            pModel.PlaceHeight = tempModel.PlaceHeight;
                            pModel.PlaceName = tempModel.Name + "第" + (j + 1) + "行，第" + (k + 1) + "列";
                            pModel.PlacePosition = (j + 1) + "*" + (k + 1);
                            pModel.PlaceType = tempModel.Name;
                            pModel.PlaceWidth = tempModel.PlaceWidth;
                            pModel.TypeID = tempModel.TypeID;
                            Pbzx.BLL.PBnet_AdvPlace pBll = new Pbzx.BLL.PBnet_AdvPlace();
                            pBll.Add(pModel);
                        }
                    }                 
                }    
            }
            Response.Redirect("AdvPlace_Manage.aspx");
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {

            //string[] MyArray = Enum.GetNames(typeof(EadPlaceType));
            //Array MyValue = Enum.GetValues(typeof(EadPlaceType));
            Pbzx.Common.MyXML xml = new Pbzx.Common.MyXML("\\xml\\AdTypeConfig.xml");
            XmlNode root = xml.GetXmlRoot();
            int last = (int.Parse(root.ChildNodes[root.ChildNodes.Count - 1].Attributes["id"].Value) +1);



            XmlNode tempNode = xml.XmlDoc.CreateElement("child_" + last);
                XmlAttribute xmlAttrID = xml.XmlDoc.CreateAttribute("id");
                XmlAttribute xmlAttrName = xml.XmlDoc.CreateAttribute("name");
                XmlAttribute xmlAttrChannel = xml.XmlDoc.CreateAttribute("channel");
                XmlAttribute xmlAttrRowAndCol = xml.XmlDoc.CreateAttribute("rowAndCol");
                XmlAttribute xmlAttrPlaceWidth = xml.XmlDoc.CreateAttribute("PlaceWidth");
                XmlAttribute xmlAttrPlaceHeight = xml.XmlDoc.CreateAttribute("PlaceHeight");
                XmlAttribute xmlAttrTypeID = xml.XmlDoc.CreateAttribute("TypeID");
                XmlAttribute xmlIsOpen = xml.XmlDoc.CreateAttribute("IsOpen");
                //
                xmlAttrID.Value = last.ToString();
                xmlAttrName.Value = this.txtNewName.Text;
                xmlAttrChannel.Value = Enum.Parse(typeof(EadChanl), this.ddlNewChannel.SelectedValue).ToString();
                xmlAttrRowAndCol.Value = this.txtRowAndCol.Text;
                xmlAttrPlaceWidth.Value = this.txtNewWidth.Text;
                xmlAttrPlaceHeight.Value = this.txtNewHeight.Text;
                xmlAttrTypeID.Value = this.ddlNewType.SelectedValue;
                xmlIsOpen.Value = this.rblNewOpen.Items[0].Selected ? "1" : "0"; 

                tempNode.Attributes.Append(xmlAttrID);
                tempNode.Attributes.Append(xmlAttrName);
                tempNode.Attributes.Append(xmlAttrChannel);
                tempNode.Attributes.Append(xmlAttrRowAndCol);
                tempNode.Attributes.Append(xmlAttrPlaceWidth);
                tempNode.Attributes.Append(xmlAttrPlaceHeight);
                tempNode.Attributes.Append(xmlAttrTypeID);
                tempNode.Attributes.Append(xmlIsOpen);

                root.AppendChild(tempNode);

            xml.SaveXmlDocument();
            Response.Redirect("AdPlaceSum.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.divAdd.Visible = false;
            this.divList.Visible = true;
        }

        protected void btmAdd_Click(object sender, EventArgs e)
        {
            Pbzx.Common.MyXML xml = new Pbzx.Common.MyXML("\\xml\\AdTypeConfig.xml");
            XmlNode root = xml.GetXmlRoot();
            int last = (int.Parse(root.ChildNodes[root.ChildNodes.Count - 1].Attributes["id"].Value)+1);
            this.txtNewID.Text = last.ToString();
            this.txtNewID.Enabled = false;

            this.divAdd.Visible = true;
            this.divList.Visible = false;
        }

        protected void lbtnUpdateIndex_Click(object sender, EventArgs e)
        {
            WebFunc.RefPagesByPageName("首页");
        }

        //protected DataTable GetDataFromGrid()
        //{
        //    DataTable dt1 = new DataTable("Table1");
        //    dt1.Columns.Add("编号");
        //    dt1.Columns.Add("广告位类别名称");
        //    dt1.Columns.Add("所属频道");
        //    dt1.Columns.Add("行列数");
        //    dt1.Columns.Add("单个广告位宽度");
        //    dt1.Columns.Add("单个广告位高度");
        //    dt1.Columns.Add("所属类别");
        //    dt1.Columns.Add("是否开启");
        //    dt1.Columns.Add("操作");
        //    for (int i = 0; i < MyGridView.Rows.Count; i++)
        //    {
        //        GridViewRow gRow = MyGridView.Rows[i];
        //        DataRow newRow = dt1.NewRow();
        //        newRow[0] = MyGridView.DataKeys[i].Value;
        //        newRow[1] = ((TextBox)gRow.FindControl("txtId")).Text;
        //        newRow[2] = ((TextBox)gRow.FindControl("txtName")).Text;
        //        newRow[3] = ((DropDownList)gRow.FindControl("DropDownList1")).SelectedValue;
        //        newRow[4] = ((TextBox)gRow.FindControl("txtRow")).Text;
        //        newRow[5] = ((TextBox)gRow.FindControl("txtPlaceWidth")).Text;
        //        newRow[6] = ((TextBox)gRow.FindControl("txtPlaceHeight")).Text;
        //        newRow[7] = ((DropDownList)gRow.FindControl("ddlType")).SelectedValue;
        //        newRow[7] = ((RadioButtonList)gRow.FindControl("rblIsOpen")).Items[0].Selected;
        //        dt1.Rows.Add(newRow);
        //    }
        //    dt1.AcceptChanges();
        //    return dt1;
        //}

        //protected void btmAdd_Click(object sender, EventArgs e)
        //{
        //    DataTable dt = this.GetDataFromGrid();
        //    DataRow newRow = dt.NewRow();
        //   // newRow["状态"] = "1";
        //    dt.Rows.Add(newRow);
        //    this.MyGridView.DataSource = dt;
        //    this.MyGridView.DataBind();
        //}
        //protected void Button2_Click(object sender, EventArgs e)
        //{
        //    DataTable dt = this.GetDataFromGrid();
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        if (row["ID"] != null)
        //        {
        //            //更新该行记录到数据库
        //        }
        //        else
        //        {
        //            //插入该行记录到数据库
        //        }
        //    }
        //}




        //protected void MyGridView_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //}
        //#region  备用

        ////恢复GridView正常状态
        //private void ResetParameter()
        //{
        //   // gvParameter.EditIndex = -1;
        //    LoadParameter("");
        //}

        ////加载XML并显示在GridView里
        //private void LoadParameter(string shapeType)
        //{
        //    DataSet dsRule = new DataSet();
        //    dsRule.ReadXml(xmlPath);

        //    DataTable dtRule = dsRule.Tables[shapeType];

        //    gvParameter.DataSource = dtRule;
        //    gvParameter.DataBind();
        //}

        ////新增事件
        //protected void lnbAddNew_Click(object sender, EventArgs e)
        //{
        //    if (ddlShapeType.SelectedValue.Length == 0)
        //    {
        //        lblMsg.Visible = true;
        //        lblMsg.Text = "Warning: Please select shape type !";
        //        return;
        //    }
        //    else if (gvParameter.Rows.Count == 0)
        //    {
        //        lblMsg.Visible = true;
        //        lblMsg.Text = "Warning: [" + ddlShapeType.SelectedValue + "] table not exists !";
        //        return;
        //    }

        //    DataSet ds = new DataSet();
        //    ds.ReadXml(xmlPath);
        //    DataTable dt = ds.Tables[ddlShapeType.SelectedValue];

        //    DataRow dr = dt.NewRow();
        //    dt.Rows.Add(dr);

        //    ds.WriteXml(xmlPath);   //将修改写入Table.xml

        //    ResetParameter();
        //}

        ////编辑事件
        //protected void gvParameter_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    gvParameter.EditIndex = e.NewEditIndex;
        //    LoadParameter(ddlShapeType.SelectedValue);

        //    GridViewRow row = gvParameter.Rows[e.NewEditIndex];

        //    //前面2列是Delete、Edit,故从第三列开始
        //    for (int i = 2; i < row.Cells.Count; i++)
        //    {
        //        TextBox tb = (TextBox)row.Cells[i].Controls[0];
        //        tb.Width = 50;
        //    }
        //}

        ////更新事件
        //protected void gvParameter_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    GridViewRow row = gvParameter.Rows[e.RowIndex]; //获得当前行

        //    int numCell = row.Cells.Count;  //共几列单元格(包含Edit和Delete 2列)
        //    int currentRow = row.DataItemIndex; //对应DataSet对应的行索引

        //    DataSet ds = new DataSet();
        //    ds.ReadXml(xmlPath);
        //    DataRow dr;

        //    dr = ds.Tables[ddlShapeType.SelectedValue].Rows[row.DataItemIndex];  //找到对应与DataSet行

        //    string[] str = null;   //此数组定义表的列名

        //    switch (ddlShapeType.SelectedValue)
        //    {
        //        case "SOP":
        //            {
        //                str = new string[] { "PitchY", "T", "B", "WM", "WM1", "WP", "WP1", "R", "LM", "WCM", "WCP" };
        //                break;
        //            }
        //        case "DCHIP":
        //            {
        //                str = new string[] { "BodySize", "L", "W", "D", "T", "S", "R", "Wm", "Lm" };
        //                break;
        //            }
        //    }

        //    int j = 0;
        //    //从第3列开始,前面有2列是Edit和Delete
        //    for (int i = 2; i < numCell; i++)
        //    {
        //        string cText = ((TextBox)row.Cells[i].Controls[0]).Text;

        //        dr[str[j]] = cText;

        //        j++;
        //    }

        //    ds.WriteXml(xmlPath);   //将修改写入Table.xml

        //    ResetParameter();
        //}

        ////取消修改
        //protected void gvParameter_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        //{
        //    ResetParameter();
        //}

        ////删除事件
        //protected void gvParameter_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    GridViewRow row = gvParameter.Rows[e.RowIndex];

        //    int curr = row.RowIndex;
        //    DataSet ds = new DataSet();
        //    ds.ReadXml(xmlPath);

        //    DataRow dr = ds.Tables[ddlShapeType.SelectedValue].Rows[curr];
        //    dr.Delete();
        //    ds.WriteXml(xmlPath);

        //    ResetParameter();
        //}

        //#endregion


    }
}
