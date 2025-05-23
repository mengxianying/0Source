using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Globalization;
using net.pay.cncard.Security;
using System.Configuration;
using Pbzx.Common;
namespace Pbzx.Web.PortSampleForDotNet
{
    /// <summary>
    /// Summary description for SendOrder.
    /// </summary>
    public partial class SendOrder : System.Web.UI.Page
    {

        protected string c_mid;			//商户编号，在申请商户成功后即可获得，可以在申请商户成功的邮件中获取该编号
        protected string c_order;		//商户网站生成的订单号，不能重复
        protected string c_name;		//商户订单中的收货人姓名
        protected string c_address;		//商户订单中的收货人地址
        protected string c_tel;			//商户订单中的收货人电话
        protected string c_post;		//商户订单中的收货人邮编
        protected string c_email;		//商户订单中的收货人Email
        protected string c_orderamount;	//商户订单总金额
        protected string c_ymd;			//商户订单的产生日期，格式为"yyyymmdd"，如20050102
        protected string c_moneytype;	//支付币种，0为人民币
        protected string c_retflag;		//商户订单支付成功后是否需要返回商户指定的文件，0：不用返回 1：需要返回
        protected string c_paygate;		//如果在商户网站选择银行则设置该值，具体值可参见《云网支付@网技术接口手册》附录一；如果来云网支付@网选择银行此项为空值。
        protected string c_returl;		//如果c_retflag为1时，该值代表支付成功后返回的文件的路径
        protected string c_memo1;		//商户需要在支付结果通知中转发的商户参数一
        protected string c_memo2;		//商户需要在支付结果通知中转发的商户参数二
        protected string c_signstr;		//商户对订单信息进行MD5签名后的字符串
        protected string c_pass;		//支付密钥，请登录商户管理后台，在帐户信息->基本信息->安全信息中的支付密钥项
        protected string notifytype;	//0普通通知方式/1服务器通知方式，空值为普通通知方式
        protected string c_language;	//对启用了国际卡支付时，可使用该值定义消费者在银行支付时的页面语种，值为：0银行页面显示为中文/1银行页面显示为英文


        protected void Page_Load(object sender, System.EventArgs e)
        {
            ViewState["Type"] = "0";
            if (!string.IsNullOrEmpty(Request["type"]))
            {
                if (Request["type"] == "1")
                {
                    ViewState["Type"] = "1";
                }
            }
            LoginSort login = new LoginSort();
            if (!login["manager_user"])
            {
                Response.Redirect("/login.aspx");
                return;
            }

            if (Request["OrderID"] == "")
            {
                Response.Write("<script>alert('对不起！订单编号错误！');history.go(-1);</script>");
                return;
            }

            //接收订单号
            if (string.IsNullOrEmpty(Request["OrderID"]))
            {
                if (string.IsNullOrEmpty(Request["ChargeID"]))
                {
                    Response.Write("<script>alert('对不起！订单编号错误！');history.go(-1);</script>");
                    return;
                }
                else
                {
                    if (!WebFunc.CheckOrderIsValidate(Request["ChargeID"]))
                    {
                        Response.Write("<script>alert('对不起！该订单已取消或者已失效！');history.go(-1);</script>");
                        return;
                    }
                    DataSet ds = new Pbzx.BLL.PBnet_Charge().GetList(" OrderID='" + Input.FilterAll(Request["ChargeID"]) + "' ");
                    DataRow row = null;
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        row = ds.Tables[0].Rows[0];
                        c_orderamount = Convert.ToDecimal(ds.Tables[0].Rows[0]["PayMoney"]).ToString("0.00");
                    }
                    else
                    {
                        Response.Write("<script>alert('对不起！订单错误！');history.go(-1);</script>");
                        return;
                    }
                    Pbzx.BLL.PBnet_PayType payTypeBLL = new Pbzx.BLL.PBnet_PayType();
                    Pbzx.Model.PBnet_PayType payModel = payTypeBLL.GetModel(Convert.ToInt32(row["PayTypeID"]));
                    // Put user code to initialize the page here
                    DateTime dt = DateTime.Now;
                    string timeStr = dt.ToString("HHmmss", DateTimeFormatInfo.InvariantInfo);
                    c_mid = ConfigurationManager.AppSettings["c_mid"].ToString();
                    c_pass = ConfigurationManager.AppSettings["c_pass"].ToString();
                    Pbzx.Model.PBnet_UserTable realUser = Pbzx.BLL.PBnet_UserTable.GetCurrentRealInfoUser();
                    c_name = realUser.RealName;
                    c_address = realUser.Address;
                    c_tel = realUser.Telphone;
                    c_post = realUser.PostCode;
                    c_email = realUser.Email;
                    c_ymd = string.Format("{0:yyyyMMdd}", DateTime.Parse(row["OrderDate"].ToString().Trim()));
                    c_order = row["OrderID"].ToString();
                    //c_orderamount = "0.01";
                    c_moneytype = "0";
                    c_retflag = "1";
                    string pay = "";
                    //if (payModel != null)
                    //{
                    //    pay = payModel.PayValue.ToString();
                    //}
                    c_paygate = pay;
                    c_returl = WebInit.webBaseConfig.WebUrl + "YunWangCncard/GetPayNotify.aspx";	//该地址为商户接收云网支付结果通知的页面，请提交完整文件名(对应范例文件：GetPayNotify.aspx)
                    c_memo1 = row["PayTypeID"].ToString(); //Server.UrlEncode(row["PayTypeName"] + "|" + row["PortTypeName"]);
                    c_language = "0";
                    notifytype = "1";
                    // + c_name + c_address + c_tel + c_post + c_email
                    string srcStr = c_mid + c_order + c_orderamount + c_ymd + c_moneytype + c_retflag + c_returl + c_paygate + c_memo1 + c_memo2 + notifytype + c_language + c_pass;
                    c_signstr = cnSecurity.EncryptMD5(srcStr);
                    Pbzx.Common.ErrorLog.WriteLogMeng("在线交易", "云网支付开始，订单号：" + c_order, true, true);
                }
            }
            else
            {
                if (!WebFunc.CheckOrderIsValidate(Request["OrderID"]))
                {
                    Response.Write("<script>alert('对不起！该订单已取消或者已失效！');history.go(-1);</script>");
                    return;
                }
                DataTable dtOrders = WebFunc.GetDsOrder(Request["OrderID"]);
                if (dtOrders == null)
                {
                    Page.RegisterStartupScript(Pbzx.Web.WebFunc.GetGuid(), Pbzx.Common.JS.myAlert1("", "对不起！订单错误！", 400, "1", "history.go(-1);", "", false, false));
                    return;
                }
                DataRow row = dtOrders.Rows[0];
                decimal payJE = 0;
                if (dtOrders.TableName == "PBnet_Orders" || dtOrders.TableName == "PBnet_Orders_Delegates")
                {
                    payJE = Convert.ToDecimal(dtOrders.Rows[0]["HasNotPayedPrice"]);
                }
                else if (dtOrders.TableName == "PBnet_Charge")
                {
                    payJE = Convert.ToDecimal(dtOrders.Rows[0]["PayMoney"]) - Convert.ToDecimal(dtOrders.Rows[0]["HasPayedPrice"]);
                }

                c_orderamount = string.Format("{0:f}", payJE);
                //_TipID = Convert.ToInt32(ds.Tables[0].Rows[0]["TipID"]);
                Pbzx.BLL.PBnet_PayType payTypeBLL = new Pbzx.BLL.PBnet_PayType();
                Pbzx.Model.PBnet_PayType payModel = payTypeBLL.GetModel(Convert.ToInt32(row["PayTypeID"]));
                // Put user code to initialize the page here
                DateTime dt = DateTime.Now;
                string timeStr = dt.ToString("HHmmss", DateTimeFormatInfo.InvariantInfo);
                c_mid = ConfigurationManager.AppSettings["c_mid"].ToString();
                c_pass = ConfigurationManager.AppSettings["c_pass"].ToString();
                c_name = "";// row["ReceiverName"].ToString();
                c_address = "";// row["ReceiverAddress"].ToString();
                c_tel = "";// row["ReceiverPhone"].ToString();
                c_post = "";// row["ReceiverPostalCode"].ToString();
                c_email = "";// row["ReceiverEmail"].ToString();
                c_ymd = string.Format("{0:yyyyMMdd}", DateTime.Parse(row["OrderDate"].ToString().Trim()));
                c_order = row["OrderID"].ToString();
                //c_orderamount = "0.01";
                c_moneytype = "0";
                c_retflag = "1";
                string pay = "";
                if (payModel != null)
                {
                    pay = payModel.PayValue.ToString();
                }
                c_paygate = pay;
                c_returl = WebInit.webBaseConfig.WebUrl + "YunWangCncard/GetPayNotify.aspx";	//该地址为商户接收云网支付结果通知的页面，请提交完整文件名(对应范例文件：GetPayNotify.aspx)
                c_memo1 = "PayTypeName"; //Server.UrlEncode(row["PayTypeName"] + "|" + row["PortTypeName"]);             
                c_language = "0";
                notifytype = "1";
                // + c_name + c_address + c_tel + c_post  + c_email  
                string srcStr = c_mid + c_order + c_orderamount + c_ymd + c_moneytype + c_retflag + c_returl + c_paygate + c_memo1 + c_memo2 + notifytype + c_language + c_pass;
                c_signstr = cnSecurity.EncryptMD5(srcStr);
                Pbzx.Common.ErrorLog.WriteLogMeng("在线交易", "云网支付开始，订单号：" + c_order, true, true);
            }
        }

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

        }
        #endregion
    }
}















































































//<td align="left">
//                              <input type="hidden" name="c_name" value="<%=c_name%>"></td>
//                          <td align="left">
//                              <input type="hidden" name="c_address" value="<%=c_address%>"></td>
//                          <td align="left">
//                              <input type="hidden" name="c_tel" value="<%=c_tel%>"></td>
//                          <td align="left">
//                              <input type="hidden" name="c_post" value="<%=c_post%>"></td>
//                          <td align="left">
//                              <input type="hidden" name="c_email" value="<%=c_email%>"></td>