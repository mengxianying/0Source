using Pbzx.Common;
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
using Pbzx.Web;
using System.Collections.Generic;

namespace Pbzx.Web.PortSampleForDotNet
{
	/// <summary>
	/// Summary description for GetPayNotify.
	/// </summary>
	public partial class GetPayNotify : System.Web.UI.Page
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
		protected System.Web.UI.WebControls.Label payMsg;

		protected void Page_Load(object sender, System.EventArgs e)
		{
            ViewState["Type"] = "0";
            //jmail
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
            ViewState["Type"] = WebFunc.GetOrderType(c_order);

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
            //Pbzx.Common.ErrorLog.WriteLogMeng("在线交易","云网支付，签名验证成功",true,true);

			//校验商户订单系统中是否有通知信息返回的订单信息
			string connStr;
			string chkSQL="";
			connStr = ConfigurationManager.AppSettings["ConnectionString"].ToString();
            ////////此处修改
            if (ViewState["Type"].ToString() == "0")
            {
                chkSQL = @"select top 1 * from PBnet_Orders where OrderID=@OrderID";
            }
            else if (ViewState["Type"].ToString() == "1")
            {
                chkSQL = @"select top 1 * from PBnet_Orders where OrderID=@OrderID";
            }
            else if (ViewState["Type"].ToString() == "2")
            {
                chkSQL = @"select top 1 * from PBnet_Charge where OrderID=@OrderID";
            }
			SqlConnection conn = new SqlConnection(connStr);
			SqlCommand myComm = new SqlCommand(chkSQL);            
            myComm.Parameters.Add("@OrderID", c_order);
			SqlDataReader myReader;

			try
			{
				myComm.Connection = conn;
				myComm.Connection.Open();
				myReader = myComm.ExecuteReader();
			}
			catch(Exception ex)
			{
				Response.Write(ex.Message);
				Response.End();
				return;
			}

			if(!myReader.Read())
			{
				Response.Write("未找到该订单信息 !");
				Response.End();
				return;
			}

			//校验商户订单系统中记录的订单金额和云网支付网关通知信息中的金额是否一致
            # region 此处修改


            #endregion
            DataTable dtOrder = WebFunc.GetDsOrder(c_order);
            double r_orderamount = 0;
            if (dtOrder.TableName == "PBnet_Orders" || dtOrder.TableName == "PBnet_Orders_Delegates")
            {
                r_orderamount = Convert.ToDouble(dtOrder.Rows[0]["HasNotPayedPrice"]);
            }
            else if (dtOrder.TableName == "PBnet_Charge")
            {
                r_orderamount = Convert.ToDouble(dtOrder.Rows[0]["PayMoney"]) - Convert.ToDouble(dtOrder.Rows[0]["HasPayedPrice"]);
            }

			if(Convert.ToInt32(double.Parse(c_orderamount)) != Convert.ToInt32(r_orderamount))
			{
				Response.Write("支付金额有误 !");
				Response.End();
				return;
			}

			//校验商户订单系统中记录的订单生成日期和云网支付网关通知信息中的订单生成日期是否一致
			string r_ymd;
            // 此处修改
            r_ymd = string.Format("{0:yyyyMMdd}", DateTime.Parse(myReader["OrderDate"].ToString().Trim()));

			if(r_ymd!=c_ymd)
			{
				Response.Write("订单时间有误 !");
				Response.End();
				return;
			}

			//校验商户系统中记录的需要在支付结果通知中转发的参数和云网支付网关通知信息中提供的参数是否一致
			string r_memo1,r_memo2;

            #region 此处修改校验参数
            r_memo1 = myReader["PayTypeID"].ToString().Trim();
            r_memo2 = ViewState["Type"].ToString();
            #endregion

            //if(r_memo1!=c_memo1 || r_memo2!=c_memo2)
            //{
            //    Response.Write("自定义参数提交有误 !");
            //    Response.End();
            //    return;
            //}

            //Pbzx.Common.ErrorLog.WriteLogMeng("在线交易","\r\n云网支付，在返回页面中校验返回的支付结果：==" + c_succmark);


			//校验返回的支付结果的格式是否正确
			if(c_succmark!="Y" && c_succmark!="N")
			{
				Response.Write("参数提交有误 !");
				Response.End();
				return;
			}

         


			//根据返回的支付结果，商户进行自己的发货等操作
            if (c_succmark == "Y")
            {
                WebFunc.UpdateOrder(c_order, true, r_orderamount.ToString(), "cncard@pinble.com", "（自动）", 13, "云网支付");
                Pbzx.Common.ErrorLog.WriteLogMeng("在线交易","云网支付，订单号："+c_order+"\r\n结果：支付成功！",true,true);
                Response.Write("<result>1</result><reURL>" + WebInit.webBaseConfig.WebUrl + "YunWangCncard/GetPayHandle.aspx</reURL>");
			    Response.End();
            }
            else
            {
                Pbzx.Common.ErrorLog.WriteLogMeng("在线交易", "云网支付，订单号：" + c_order + "\r\n结果：校验失败，数据可疑！", true, true);
                string Name = Method.Get_UserName;
                if (Name == "0")
                {
                    Name = "游客";
                }
                Method.record_user_log(Name, "校验失败，数据可疑", "数据可疑", "恶意攻击");
            }
            Response.End();
			//输出支付结果通知反馈
			//<result>：值固定为1，表示商户已成功收到网关的支付成功的通知。
			//<reURL> ：商户显示给用户处理结果页面的URL(对应范例文件：GetPayHandle.aspx)

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
