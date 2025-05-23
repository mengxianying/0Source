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

namespace Pbzx.Web.UserCenter
{
    public partial class MoneyLog_Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                string orderID = Input.FilterAll(Request["OrderID"]);

                if (!string.IsNullOrEmpty(orderID))
                {
                    txtHKRQ.Text = DateTime.Now.ToShortDateString();
                    ///绑定银行名称
                    DataSet dsBank = DbHelperSQL.Query("select PayTypeName,PayTypeID from PBnet_PayType where PayValue='1' and FTypeID<>'0'  ");

                    ddlBankName.DataSource = dsBank;
                    ddlBankName.DataTextField = "PayTypeName";
                    ddlBankName.DataValueField = "PayTypeID";
                    ddlBankName.DataBind();
                    ddlBankName.Items.Insert(0, new ListItem("请选择", ""));
                    ddlBankName.Items[0].Selected = true;

                    Pbzx.BLL.PBnet_Charge MyBll = new Pbzx.BLL.PBnet_Charge();
                    Pbzx.Model.PBnet_Charge MyModel = MyBll.GetModelByOrderId(orderID);
                    if (MyModel.UserName != Method.Get_UserName)
                    {
                        Page.RegisterStartupScript(WebFunc.GetGuid(), JS.myAlert1("", "您没有权限查看该订单！", 500, "1", "window.close();", "", false, false));
                        return;
                    }

                    if (MyModel.IsCancel == 1 || MyModel.IsCancel ==2)
                    {
                        tbFinish.Visible = false;
                        this.tbRemark.Visible = false;
                        this.tbCancel.Visible = true;
                    }
                    else if (MyModel.State == 1)
                    {
                        tbFinish.Visible = true;
                        this.tbRemark.Visible = false;
                        this.tbCancel.Visible = false;
                    }
                    else
                    {
                        if (MyModel.PayTypeID == 1)
                        {
                            tbRemark.Visible = false;
                        }
                        else
                        { 
                            tbRemark.Visible = true;
                        }
                        tbFinish.Visible = false;                        
                        tbCancel.Visible = false;
                    }

                    lblOrderID.Text = MyModel.OrderID;
                    lblState.Text = MyBll.GetState(MyModel.State,MyModel.IsCancel);
                    if (MyModel.IsCancel ==1)
                    {
                        lblState.Text = "用户取消";
                    }
                    else if (MyModel.IsCancel == 2)
                    {
                        lblState.Text = "系统取消";
                    }
                    lblOrderDate.Text = MyModel.OrderDate.ToString();

                    lblRealName.Text = MyModel.RealName;
                    lblPayTypeName.Text = MyModel.PayTypeName;
                    lblPayMoney.Text = string.Format("{0:C2}", Convert.ToDecimal(MyModel.PayMoney)); 
                    lblType.Text = MyBll.GetZY(MyModel.Type);
                    //lblUpdateStaticDate.Text = MyModel.UpdateStaticDate.ToString();
                    lblResult.Text = MyModel.Result;
                    if (MyModel.IsCancel == 1)
                    {
                        lblResult.Text = "用户取消";
                    }
                    else if (MyModel.IsCancel == 2)
                    {
                        lblResult.Text = "系统取消";
                    }
                    txtRemark.Text = Input.FilterHTML(MyModel.Remark);
                    string[] pars = MyModel.c_memo2.Split(new char[] { '|' });
                    if (pars.Length > 3)
                    {
                        this.ddlBankName.SelectedValue = pars[3];
                        this.txtHKJE.Text = pars[1];
                        this.txtHKRQ.Text = pars[2];
                    }
                    txtRemark.Text = MyModel.Remark;

                    if(string.IsNullOrEmpty(MyModel.Result))
                    {
                        lblResult.Text = lblState.Text;
                        if(MyModel.State == 0)
                        {
                            if (MyModel.IsPay == 1)
                            {
                                this.lblResult.Text = "等待审核";
                            }
                            else
                            {
                                this.lblResult.Text = "等待汇款";
                            }
                        }
                       
                    }
                }         
            }

        }


        protected void ibtnHasPay_Click(object sender, ImageClickEventArgs e)
        {

            string orderID = Input.FilterAll(Request["OrderID"]);
            string strErr = "";
            decimal dePayType = 0.00M;
            if (this.ddlBankName.SelectedValue == "")
            {
                strErr += "您选择付款方式！<br/>";
            }

            if (!decimal.TryParse(this.txtHKJE.Text, out dePayType))
            {
                strErr += "您输入的付款金额格式不正确！<br/>";
            }
            DateTime dtHKRQ = DateTime.Now;
            if (!DateTime.TryParse(this.txtHKRQ.Text, out dtHKRQ))
            {
                strErr += "您输入的汇款日期格式不正确！<br/>";
            }
            else
            {
                if (DateTime.Parse(this.txtHKRQ.Text) > DateTime.Now)
                {
                    strErr += "请输入准确的汇款日期！<br/>";
                }
            }

            if (!string.IsNullOrEmpty(strErr))
            {
                Page.RegisterStartupScript(WebFunc.GetGuid(), JS.myAlert1("", strErr, 500, "1", "", "", false, false));
                return;
            }


            Pbzx.BLL.PBnet_Charge MyBll = new Pbzx.BLL.PBnet_Charge();
            Pbzx.Model.PBnet_Charge MyModel = MyBll.GetModelByOrderId(orderID);
            if (MyModel.IsPay ==  2)
            {
                Page.RegisterStartupScript(WebFunc.GetGuid(), JS.myAlert1("提示！", "您的汇款确认已提交过，无需重复提交！<br/>请耐心等待客服审核！", 500, "1", "window.returnValue ='yes';window.close();", "", false, false));
                return;
            }

            MyModel.c_memo2 = this.ddlBankName.SelectedItem.Text + "|" + this.txtHKJE.Text + "|" + this.txtHKRQ.Text + "|" + this.ddlBankName.SelectedValue;

            MyModel.Remark = Input.FilterHTML(this.txtRemark.Text.Trim());
            MyModel.IsPay = 2;

            if (MyBll.Update(MyModel))
            {
               //Page.RegisterStartupScript(WebFunc.GetGuid(), JS.myAlert1("提示！", "您的汇款确认已提交，请等待客服审核！", 500, "1", "window.returnValue ='yes';window.close();", "", false, false));
                Response.Write("<script>alert('提交成功！');window.opener.location.reload();window.opener.focus();window.opener=null;window.open('','_self');window.close();</script>");
                return;
            }
            else
            {
                Page.RegisterStartupScript(WebFunc.GetGuid(), JS.myAlert1("", "提交失败！请与拼搏在线彩神通软件客服联系！", 500, "1", "", "", false, false));
            }
        }
    }
}
