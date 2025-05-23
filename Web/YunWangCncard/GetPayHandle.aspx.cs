using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;
using net.pay.cncard.Security;

namespace Pbzx.Web.PortSampleForDotNet
{
	/// <summary>
	/// Summary description for GetPayHandle.
	/// </summary>
	public partial class GetPayHandle : System.Web.UI.Page
	{
		protected string c_mid;			//商户编号，在申请商户成功后即可获得，可以在申请商户成功的邮件中获取该编号
		protected string c_order;		//商户提供的订单号
		protected string c_orderamount; //商户提供的订单总金额，以元为单位，小数点后保留两位，如：13.05
		protected string c_ymd;			//商户传输过来的订单产生日期，格式为"yyyymmdd"，如20050102
		protected string c_transnum;	//云网支付网关提供的该笔订单的交易流水号，供日后查询、核对使用；
		protected string c_succmark;	//交易成功标志，Y-成功 N-失败
		protected string c_moneytype;	//支付币种，0为人民币
		protected string c_cause;		//如果订单支付失败，则该值代表失败原因
		protected string c_memo1;		//商户提供的需要在支付结果通知中转发的商户参数一
		protected string c_memo2;		//商户提供的需要在支付结果通知中转发的商户参数二
		protected string c_signstr;		//云网支付网关对已上信息进行MD5加密后的字符串

        protected string orderDetailUrl = "#";
	
		protected void Page_Load(object sender, System.EventArgs e)
		{

            
			// Put user code to initialize the page here
			c_mid			= Request["c_mid"];			
			c_order			= Request["c_order"];		
			c_orderamount	= Request["c_orderamount"];	
			c_ymd			= Request["c_ymd"];			
			c_transnum		= Request["c_transnum"];		
			c_succmark		= Request["c_succmark"];				
			c_moneytype		= Request["c_moneytype"];	
			c_cause			= Request["c_cause"];				
			c_memo1			= Request["c_memo1"];		
			c_memo2			= Request["c_memo2"];		
			c_signstr		= Request["c_signstr"];
			
			//---校验信息完整性---
			if(c_mid==null || c_order==null || c_orderamount==null || c_ymd==null || c_moneytype==null || c_transnum==null || c_succmark==null || c_signstr==null)
			{
				Response.Write("支付信息有误 !");
				Response.End();
				return;
			}

			//请定义商户号
			string MerchantID;
            MerchantID = ConfigurationManager.AppSettings["c_mid"].ToString();

			//请定义支付密钥
			string c_pass;
            c_pass = ConfigurationManager.AppSettings["c_pass"].ToString();

			//校验商户编号
			if(MerchantID!=c_mid)
			{
				Response.Write("提交的商户编号有误 !");
				Response.End();
				return;
			}

			//对支付通知信息进行MD5加密
			string srcStr,r_signstr;
			srcStr = c_mid + c_order + c_orderamount + c_ymd + c_transnum + c_succmark + c_moneytype + c_memo1 + c_memo2 + c_pass;
			r_signstr = cnSecurity.EncryptMD5(srcStr);

			//校验商户网站对通知信息的MD5加密的结果和云网支付网关提供的MD5加密结果是否一致
			if(r_signstr!=c_signstr)
			{
				Response.Write("签名验证失败 !");
				Response.End();
				return;
			}
            ViewState["Type"] = WebFunc.GetOrderType(c_order);

            DataTable dtOrders = WebFunc.GetDsOrder(c_order);
            if (dtOrders == null)
            {
                Page.RegisterStartupScript(Pbzx.Web.WebFunc.GetGuid(), Pbzx.Common.JS.myAlert1("", "对不起！订单错误！", 400, "1", "history.go(-1);", "", false, false));
                return;
            }
            decimal payJE = 0;
            if (dtOrders.TableName == "PBnet_Orders" || dtOrders.TableName == "PBnet_Orders_Delegates")
            {
                payJE = Convert.ToDecimal(dtOrders.Rows[0]["HasNotPayedPrice"]);
            }
            else if (dtOrders.TableName == "PBnet_Charge")
            {
                payJE = Convert.ToDecimal(dtOrders.Rows[0]["PayMoney"]) - Convert.ToDecimal(dtOrders.Rows[0]["HasPayedPrice"]);
            }


			//校验返回的支付结果的格式是否正确
			if(c_succmark!="Y" && c_succmark!="N")
			{
				Response.Write("参数提交有误 !");
				Response.End();
				return;
			}

			//根据返回的支付结果，商户网站可自行给用户显示说明
			if(c_succmark=="Y")
			{
                orderDetailUrl = WebFunc.GetReturnUrl(c_order);
			}
			else if(c_succmark=="N")
			{
				
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
