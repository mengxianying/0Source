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
    public partial class ChargeDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {

            DataSet dsPayType = DbHelperSQL.Query("select PayTypeID,PayTypeName from PBnet_PayType where FTypeID<>'0' ");
            this.ddlPayType.DataSource = dsPayType;
            this.ddlPayType.DataTextField = "PayTypeName";
            this.ddlPayType.DataValueField = "PayTypeID";
            this.ddlPayType.DataBind();
            this.ddlPayType.Items.Insert(0, new ListItem("请选择", ""));
            this.ddlPayType.Items[0].Selected = true;

            string orderID = Input.FilterAll(Request["ID"]);

            if (!string.IsNullOrEmpty(orderID))
            {
                Pbzx.BLL.PBnet_Charge MyBll = new Pbzx.BLL.PBnet_Charge();
                Pbzx.Model.PBnet_Charge MyModel = MyBll.GetModel(int.Parse(orderID));

                lblOrderID.Text = MyModel.OrderID;
                lblState.Text = MyBll.GetState(MyModel.State,MyModel.IsCancel);
                lblOrderDate.Text = MyModel.OrderDate.ToString();

                lblRealName.Text = MyModel.RealName;
                lblPayTypeName.Text = MyModel.PayTypeName;
                lblPayMoney.Text =  Convert.ToDecimal(MyModel.PayMoney).ToString("0.00") + "元";
  
                lblUpdateStaticDate.Text = MyModel.UpdateStaticDate.ToString();
                

                lblHasPay.Text = Convert.ToDecimal(MyModel.HasPayedPrice).ToString("0.00") + "元";

                lblIP.Text = MyModel.UserIP + "(" + WebFunc.GetIpName(MyModel.UserIP) + ")";

                ////////////////用户信息//////////////////////////////////////
                string c_memo2 = MyModel.c_memo2;
                string[] hkInfoSZ = c_memo2.Split(new char[] {'|'});
                if(hkInfoSZ.Length > 3)
                {
                    this.lblHKFS.Text = hkInfoSZ[0];
                    this.lblHKJE.Text = hkInfoSZ[1]+"元";
                    this.lblHKRQ.Text = hkInfoSZ[2];
                }
                lblUserRemark.Text = MyModel.Remark;
                



                int  payTypeID = (int)MyModel.PayTypeID;
                Pbzx.BLL.PBnet_PayType payBll = new Pbzx.BLL.PBnet_PayType();

                string type = payBll.GetModel(payTypeID).PayValue.ToString();


                if (type == "1")
                {
                    //  this.rblOrderStaticTip.Enabled = true;
                    this.lblStateZS.Text = "";
                    tbOrderType.Visible = false;
                }
                else
                {
                    //  this.rblOrderStaticTip.Enabled = false;
                    this.lblStateZS.Text = "<font color='red'>此订单属于自动处理订单，若无特殊情况，请不用人工干预！</font>";
                    tbOrderType.Visible = true;
                }

                if (MyModel.IsCancel == 1 || MyModel.IsCancel == 2)
                {
                    this.dvCancel.Visible = true;
                    this.dvSuccess.Visible = false;
                    this.zhifu.Visible = false;
                    btnRight.Enabled = false;
                    this.btnFail.Enabled = false;
                }
                else
                {
                    this.dvCancel.Visible = false;
                    if (MyModel.State == 0 || MyModel.State == 2)
                    {
                        this.dvSuccess.Visible = false;
                        this.zhifu.Visible = true;
                        btnRight.Enabled = true;
                    }
                    else
                    {
                        this.lblSJHKFS.Text = MyModel.PayTypeName;
                        this.lblSJHKJE.Text = Convert.ToDecimal(MyModel.HasPayedPrice).ToString("0.00")+"元";
                        this.lblSJResult.Text = MyModel.Result;
                        this.dvSuccess.Visible = true;
                        this.zhifu.Visible = false;
                        btnRight.Enabled = false;
                        this.btnFail.Enabled = false;
                    }
                }

            }
        }

        protected void btnRight_Click(object sender, EventArgs e)
        {
            if (this.ddlPayType.SelectedValue == "")
            {
                Response.Write(JS.Alert("请选择实际付款方式！"));
                return;
            }
            string orderID = Input.FilterAll(Request["ID"]);
            Pbzx.BLL.PBnet_Charge chargeBll = new Pbzx.BLL.PBnet_Charge();
            Pbzx.Model.PBnet_Charge chargeModel = chargeBll.GetModel(int.Parse(orderID));
            if (!WebFunc.CheckOrderIsValidate(chargeModel.OrderID))
            {
                Response.Write(JS.Alert("此订单已经处理，或者已经取消！"));
                return;
            }
            chargeModel.State = 1;
            chargeModel.IsPay = 1;
            string orderamount = this.txtHasPayed.Text;
            decimal myamount = 0;
            if(!decimal.TryParse(orderamount,out myamount))
            {
                Response.Write(JS.Alert("实际充值金额输入有误！"));
                return;
            }
            if (myamount < 0 )
            {
                Response.Write(JS.Alert("实际充值金额输入有误！"));
                return;
            }

            //Pbzx.Model.PBnet_UserTable uRealInfo = 
            Pbzx.BLL.PBnet_UserTable uRealInfoBll = new Pbzx.BLL.PBnet_UserTable();
            List<Pbzx.Model.PBnet_UserTable> lsUser =  uRealInfoBll.GetModelList(" UserName='" + chargeModel.UserName + "' ");
            Pbzx.Model.PBnet_UserTable uRealInfo = lsUser[0];
            if(uRealInfo.CurrentMoney == null)
            {
                uRealInfo.CurrentMoney = 0;
            }
            uRealInfo.CurrentMoney += myamount;
            uRealInfo.LastTrade_time = DateTime.Now;
            Pbzx.BLL.PBnet_UserTable userBll = new Pbzx.BLL.PBnet_UserTable();
            userBll.Update(uRealInfo);
            chargeModel.HasPayedPrice = myamount;           
            chargeModel.PayNum = "";
            chargeModel.Result = DateTime.Now + "后台管理员[" + WebFunc.GetCurrentAdmin() + "]给用户[" + uRealInfo.UserName + "]充值" + Math.Round(myamount,2) + "元，充值成功！";
            chargeModel.Type = 0;
            chargeModel.UpdateStaticDate = DateTime.Now;
            chargeModel.PayTypeID = int.Parse(ddlPayType.SelectedValue);
            chargeModel.PayTypeName = ddlPayType.SelectedItem.Text;
            chargeBll.Update(chargeModel);
            BindData();
            string strResult = Input.FilterAll(this.txtResult.Text);
            if (!string.IsNullOrEmpty(strResult))
            {
                int result = DbHelperSQL.ExecuteSql(" update  PBnet_Charge set Result='" + Input.FilterAll(strResult) + "'  where Id='" + chargeModel.Id + "'   ");
            }
            Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("用户充值", "时间：" + DateTime.Now + ",充值用户名：" + uRealInfo.UserName + "；审核通过，操作者：" + WebFunc.GetCurrentAdmin());
            Response.Write(JS.Alert("操作成功！"));
            BindData();

            /////////////////写入交易信息表//////////////////////////////////////////////
            Pbzx.BLL.PBnet_UserTradeInfo tradeBll = new Pbzx.BLL.PBnet_UserTradeInfo();
            Pbzx.Model.PBnet_UserTradeInfo tradeModel = new Pbzx.Model.PBnet_UserTradeInfo();
            tradeModel.Account_UserName = "";
            tradeModel.AccountNumber = "";
            tradeModel.BankName = "";
            tradeModel.CurrentMoney = 0;
            Pbzx.Model.PBnet_UserTable userRealModel = Pbzx.BLL.PBnet_UserTable.GetRealInfoByUname(chargeModel.UserName);
            if (userRealModel != null)
            {
                tradeModel.Account_UserName = userRealModel.RealName;
                tradeModel.AccountNumber = userRealModel.AccountNumber;
                tradeModel.BankName = userRealModel.BankName;
                tradeModel.CurrentMoney = userRealModel.CurrentMoney ;
            }
            tradeModel.ForeignKey_id = chargeModel.OrderID.ToString();
            tradeModel.OperateManager = WebFunc.GetCurrentAdmin();
            tradeModel.Remark = DateTime.Now + "后台管理员给用户[" + chargeModel.UserName + "]充值" +Math.Round(myamount,2) + "元，充值订单号" + chargeModel.OrderID;
            tradeModel.TradeMoney = Math.Round(myamount, 2);
            tradeModel.TradeTime = DateTime.Now;
            tradeModel.UserName = chargeModel.UserName;
            tradeModel.TradeType = 311;
            tradeBll.Add(tradeModel);
            /////////////////写入交易信息表//////////////////////////////////////////////

        }

        protected void btnFail_Click(object sender, EventArgs e)
        {
            string orderID = Input.FilterAll(Request["ID"]);
            Pbzx.BLL.PBnet_Charge chargeBll = new Pbzx.BLL.PBnet_Charge();
            Pbzx.Model.PBnet_Charge chargeModel = chargeBll.GetModel(int.Parse(orderID));
            if (!WebFunc.CheckOrderIsValidate(chargeModel.OrderID))
            {
                Response.Write(JS.Alert("此订单已经处理，或者已经取消！"));
                return;
            }
            chargeModel.State = 2;
            decimal myamount = 0;
            chargeModel.HasPayedPrice = 0;
            chargeModel.IsPay = 1;
            chargeModel.PayNum = "";
            chargeModel.Result = "用户在线充值审核失败（未付款）";
            chargeModel.Type = 0;
            chargeModel.UpdateStaticDate = DateTime.Now;
            chargeBll.Update(chargeModel);
            BindData();
            string strResult = Input.FilterAll(this.txtResult.Text);
            if (!string.IsNullOrEmpty(strResult))
            {
                int result = DbHelperSQL.ExecuteSql(" update  PBnet_Charge set Result='" + Input.FilterAll(strResult) + "'  where Id='" + chargeModel.Id + "'   ");
            }
            Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("用户充值", "时间：" + DateTime.Now + ",充值用户名：" + chargeModel.UserName + "；审核失败（未充值），操作者：" + WebFunc.GetCurrentAdmin());
            Response.Write(JS.Alert("操作成功！"));
            BindData();
        }
    }
}
