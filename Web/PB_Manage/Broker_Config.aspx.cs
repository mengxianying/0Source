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

namespace Pbzx.Web.PB_Manage
{
    public partial class Broker_Config : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             if (!Page.IsPostBack)
             {
                   if (Request.QueryString["ID"] != null)
                   {
                       MyBindData(Request.QueryString["id"]);
                       divOperator.Visible = true;
                       divList.Visible = false;
                   }
                   else if(ViewState["myid"] != null)
                   {
                       MyBindData(ViewState["myid"].ToString());
                       divOperator.Visible = true;
                       divList.Visible = false;
                   }
                 
            }  
        }

        private void MyBindData(string myid )
        {
            Pbzx.BLL.PBnet_broker_Config MyBLL = new Pbzx.BLL.PBnet_broker_Config();
            Pbzx.Model.PBnet_broker_Config MyModel;

            string str = myid;
            MyModel = MyBLL.GetModel(Convert.ToInt32(str));

            this.txtgrade.Text = MyModel.Discount_grade.ToString();
            this.txtgradeName.Text = MyModel.Discount_gradeName;
            this.txtrate.Text = MyModel.Discount_rate.ToString();
            this.txttradeMoney.Text = MyModel.Min_tradeMoney.ToString();
        }
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            string strErrMsg = "";
            if (this.txtgradeName.Text.Trim() == "")
            {
                strErrMsg += "�ȼ��ǳƲ���Ϊ��.\\r\\n";
            }
            if (this.txtgrade.Text.Trim() != "")
            {
                if (!OperateText.IsNumber(this.txtgrade.Text))
                {
                    strErrMsg += "�ۿ۵ȼ���������.\\r\\n";
                }
            }
            if (this.txtrate.Text.Trim() != "")
            {
                if (!OperateText.IsNumber(this.txtrate.Text))
                {
                    strErrMsg += "�ۿ�ֵ��������.\\r\\n";
                }
            }
            if (this.txttradeMoney.Text.Trim() != "")
            {
                if (!OperateText.IsNumber(this.txttradeMoney.Text))
                {
                    strErrMsg += "�ۿ۵���ͽ��׽�������.\\r\\n";
                }
               
            }
            if (strErrMsg != "")
            {
                strErrMsg = "���ύ�������Ϣ�д������´���:\\r\\n\\r\\n" + strErrMsg + "\\r\\n���޸ĺ��������ύ.";
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                return;
            }

            Pbzx.BLL.PBnet_broker_Config MyBLL = new Pbzx.BLL.PBnet_broker_Config();
            Pbzx.Model.PBnet_broker_Config MyModel;

           int intid =Convert.ToInt32(Request.QueryString["id"]);
           if (intid > 0)
           {
               MyModel = MyBLL.GetModel(intid);
           }
           else
           {
               MyModel = new Pbzx.Model.PBnet_broker_Config();
           }

           MyModel.Discount_grade =int.Parse(this.txtgrade.Text);
           

           MyModel.Min_tradeMoney = decimal.Parse(this.txttradeMoney.Text);
           if (intid > 0)
           {
               DbHelperSQL.ExecuteSql(" update PBnet_broker set Discount_gradeName='" + this.txtgradeName.Text + "' , Discount_rate='" + this.txtrate.Text + "' where Discount_gradeName='" + MyModel.Discount_gradeName + "' and Discount_rate='" + MyModel.Discount_rate + "'  ");
               MyModel.Discount_gradeName = this.txtgradeName.Text;
               MyModel.Discount_rate = int.Parse(this.txtrate.Text);
               if (MyBLL.Update(MyModel))
               {                   
                   ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("Broker_Config.aspx"));
                   Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("�޸�", "�޸��ۿ�������Ϣ[" + MyModel.Discount_grade + ":" + MyModel.Discount_gradeName + "].");                 
               }
               else
               {
                   ClientScript.RegisterClientScriptBlock(this.GetType(), "err", JS.Alert("�ۿ������޸�ʧ��."));
               }

           }
           else
           {
               MyModel.Discount_gradeName = this.txtgradeName.Text;
               MyModel.Discount_rate = int.Parse(this.txtrate.Text);
               if (MyBLL.Add(MyModel))
               {
                   ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("Broker_Config.aspx"));
                   Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("���", "��Ӿ������ۿ�[" + MyModel.Discount_grade + ":" + MyModel.Discount_gradeName + "].");
               }
               else
               {
                   ClientScript.RegisterClientScriptBlock(this.GetType(), "err", JS.Alert("�ۿ�������Ϣ���ʧ��."));
               }
           }

        }
        protected void MyGridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex >= 0)
            {
                TableCell MyCell = e.Row.Cells[6];
                MyCell.Attributes.Add("onclick", "return confirm('��ȷ��Ҫɾ����?');");
            }
        }
        protected void DelModule(string e)
        {

            int ModuleID = Convert.ToInt32(e);
            Pbzx.BLL.PBnet_broker_Config ModuleBLL = new Pbzx.BLL.PBnet_broker_Config();
            Pbzx.Model.PBnet_broker_Config ConfigMedel=ModuleBLL.GetModel(ModuleID);
            string strNvname = ConfigMedel.Discount_gradeName.ToString();
            if (ModuleBLL.Delete(ModuleID))
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("ɾ��", "ɾ���������ۿ�[" + ModuleID + "].");
                //  ClientScript.RegisterClientScriptBlock(this.GetType(), "delok", JS.Alert("�ɹ�ɾ���������."));
                ClientScript.RegisterClientScriptBlock(this.GetType(), "redirect", JS.Replace("Broker_Config.aspx"));
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "nodel", JS.Alert("ɾ���ۿ�����ʧ��."));
            }
        }
        protected void LinkButton2_Command(object sender, CommandEventArgs e)
        {
            
            DelModule(e.CommandArgument.ToString());
        }
        protected void LinkButton_Command(object sender, CommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();            
            divOperator.Visible = true;
            divList.Visible = false;
            ViewState["myid"] = id;
            Response.Redirect("Broker_Config.aspx?id="+id);
        }
        //protected void ShowEditor(string e)
        //{

        //    int ModuleID = Convert.ToInt32(e);
        //    Pbzx.Model.PBnet_broker_Config MyModule = new Pbzx.BLL.PBnet_broker_Config().GetModel(ModuleID);
           
        //    //this.ddlIntOrderID.SelectedValue = MyModule.IntOrderID;
        //    //hfID.Value = MyModule.IntNewsTypeID.ToString();
        //    //cbMenu.Checked = MyModule.BitIsAuditing;
        //    //if (MyModule.Depth > 0)
        //    //{
        //    //    Method.sltListBox(ref ddlParent, MyModule.RootID.ToString());
        //    //    // txtUrl.Attributes.Remove("disabled");
        //    //}
        //    //else
        //    //{
        //    //    ddlParent.SelectedIndex = 0;

        //    //}
        //    //ddlParent.Enabled = (MyModule.Depth > 0);
        //    divOperator.Visible = true;
        //    divList.Visible = false;
        //}
        protected void btn_add_Click(object sender, EventArgs e)
        {
          //  this.IsAuthority(1);
            divOperator.Visible = true;
            divList.Visible = false;
        }

        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = "(" + id.ToString() + ")";
            }
        }

        protected void btn_gl_Click(object sender, EventArgs e)
        {
            divOperator.Visible = false;
            divList.Visible = true;
        }
    }
}
