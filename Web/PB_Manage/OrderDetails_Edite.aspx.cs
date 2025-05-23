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
using Maticsoft.DBUtility;
using System.Collections.Generic;

namespace Pbzx.Web.PB_Manage
{
    public partial class OrderDetails_Edite : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {                
                if(!string.IsNullOrEmpty(Request["OrderDetailID"]))
                {
                    string[] strExpressSz = WebInit.webBaseConfig.Express.Split(new char[] {','});
                    foreach(string strTemp in strExpressSz)
                    {
                        this.ddlKDGS.Items.Add(new ListItem(strTemp, strTemp));
                    }
                }
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string errMsg = "";
            if(txtSoftDogID.Text.Length < 9)
            {
                errMsg += "软件狗编号必须是9位数字";
            }

            string result = "";
            result += "软件狗编号："+Input.FilterAll(this.txtSoftDogID.Text)+"；";
            result += "快递公司：" + Input.FilterAll(this.ddlKDGS.SelectedItem.Text) + "；";
            result += "快递单号：" + Input.FilterAll(this.txtKDDH.Text) + "。";
            string orderID = Input.FilterAll(Request["OrderDetailID"]);
           
            if (!string.IsNullOrEmpty(orderID))
            {
                Pbzx.BLL.PBnet_OrderDetail orderDetailBll = new Pbzx.BLL.PBnet_OrderDetail();
                List<Pbzx.Model.PBnet_OrderDetail> lsDetail =  orderDetailBll.GetModelList("OrderID='"+orderID+"' ");
                foreach(Pbzx.Model.PBnet_OrderDetail model in lsDetail)
                {
                    string regType1 = model.RegType.Split(new char[] {'|'})[0];
                    if (regType1 == "7" || regType1 == "6")
                    {
                        model.Serial = result;
                        model.State = 1;
                        orderDetailBll.Update(model);
                    }
                }
                Pbzx.BLL.PBnet_Orders orderBll = new Pbzx.BLL.PBnet_Orders();
                Pbzx.Model.PBnet_Orders orderModel = orderBll.GetModel(orderID);
                orderModel.IsPay = 3;
                orderModel.Result = "已完成";
                orderBll.Update(orderModel);
            }
            Response.Write("<script language='javascript'>alert('修改成功！');window.returnValue ='yes';window.close()</script>");
           
        }


    }
}
