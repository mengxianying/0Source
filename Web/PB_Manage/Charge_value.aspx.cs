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
using Maticsoft.DBUtility;
using Pbzx.Common;

namespace Pbzx.Web.PB_Manage
{
    public partial class Charge_value : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                //DataTable dt = DbHelperSQL.Query("select * from PBnet_PayType where PayValue >= 0").Tables[0];
                //foreach (DataRow row in dt.Rows)
                //{
                //    ddlPayType.Items.Add(new ListItem(row["PayTypeName"].ToString(), row["PayTypeID"].ToString()));
                //}
                //ddlPayType.Items.Insert(0, new ListItem("����", "-1"));
                //ddlPayType.Items[0].Selected = true;
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {            
            Pbzx.BLL.PBnet_Charge chargeBLL = new Pbzx.BLL.PBnet_Charge();
            Pbzx.Model.PBnet_Charge model = new Pbzx.Model.PBnet_Charge();
            model.Remark = this.txtDetails.Text;
            model.OrderDate = DateTime.Now;
           // model.OrderID = CreateOrderID();
            model.OrderID = Method.CreateOrderID("CZ", "PBnet_Charge");
            decimal mo = 0;
            if (!decimal.TryParse(this.txtPayMoney.Text, out mo))
            {
                ClientScript.RegisterStartupScript(GetType(), "error", "alert('������ó�ֵ����ȷ')", true);
                return;
            }
            else if (mo < 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "error", "alert('������ó�ֵ����ȷ')", true);
                return;
            }
            //if(string.IsNullOrEmpty(this.ddlPayType.SelectedValue))
            //{
            //    ClientScript.RegisterStartupScript(GetType(), "error", "alert('��ѡ��֧����ʽ��')", true);
            //    return;
            //}
            model.PayMoney = mo;
            Pbzx.BLL.PBnet_UserTable utBLL = new Pbzx.BLL.PBnet_UserTable();
            Pbzx.Model.PBnet_UserTable ut = utBLL.GetModelName(Input.FilterAll(this.txtUname.Text));
            ut.CurrentMoney += mo;
            utBLL.Update(ut);
            model.State = 1;
            model.Type = 0;
            model.Result = "��ֵ�ɹ���";
            model.PayNum = "";// txtPayNum.Text;
            model.HasPayedPrice = decimal.Parse(txtPayMoney.Text);
            model.RealName = this.txtRealName.Text;
            model.IsPay = 1;
            model.UserID = Convert.ToInt32(DbHelperSQLBBS.GetSingle("select top 1 UserID from Dv_User where UserName='"+this.txtUname.Text.Trim()+"' "));
            model.UserName = txtUname.Text;
            model.c_memo1 = "";// this.ddlPayType.SelectedItem.Text;
            model.PayTypeID = 1;// Convert.ToInt32(this.ddlPayType.SelectedValue);
            model.PayTypeName = "";// this.ddlPayType.SelectedItem.Text;       
            model.UserIP = Request.UserHostAddress;
            int result = chargeBLL.Add(model);

            /////////////////д�뽻����Ϣ��//////////////////////////////////////////////
            Pbzx.BLL.PBnet_UserTradeInfo tradeBll = new Pbzx.BLL.PBnet_UserTradeInfo();
            Pbzx.Model.PBnet_UserTradeInfo tradeModel = new Pbzx.Model.PBnet_UserTradeInfo();
            tradeModel.Account_UserName = "";
            tradeModel.AccountNumber = "";
            tradeModel.BankName = "";
            tradeModel.CurrentMoney = 0;

            Pbzx.Model.PBnet_UserTable userRealModel = Pbzx.BLL.PBnet_UserTable.GetRealInfoByUname(Input.FilterAll(this.txtUname.Text));
            if (userRealModel != null)
            {
                tradeModel.Account_UserName = userRealModel.RealName;
                tradeModel.AccountNumber = userRealModel.AccountNumber;
                tradeModel.BankName = userRealModel.BankName;
                tradeModel.CurrentMoney = userRealModel.CurrentMoney ;
            }
            tradeModel.ForeignKey_id = model.OrderID.ToString();
            tradeModel.OperateManager = WebFunc.GetCurrentAdmin();
            string strRemark = DateTime.Now + "��̨����Ա���û�[" + this.txtUname.Text + "]��ֵ" + Math.Round(mo, 2) + "Ԫ����ֵ������" + model.OrderID + "��";
            if (!string.IsNullOrEmpty(this.txtDetails.Text))
            {
                strRemark += "��ע��Ϣ��"+this.txtDetails.Text;
            }
            tradeModel.Remark = strRemark;
            tradeModel.TradeMoney = Math.Round(mo, 2);
            tradeModel.TradeTime = DateTime.Now;
            tradeModel.UserName = this.txtUname.Text;
            tradeModel.TradeType = 313;
            
            tradeBll.Add(tradeModel);
            /////////////////д�뽻����Ϣ��//////////////////////////////////////////////

            if (result > 0)
            {
                Response.Write("<script language='javascript'>alert('��ֵ�ɹ���');window.returnValue ='1';self.close();</script>");
            }
            else
            {
                Response.Write("<script language='javascript'>alert('��ֵʧ�ܣ�');window.returnValue ='0';self.close();</script>");
            }



        }

    }
}
