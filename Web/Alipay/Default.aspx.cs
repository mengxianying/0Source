using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Gateway;
using Pbzx.Common;
using Pbzx.Web;
using System.Text;
using Com.Alipay;
using System.Collections.Generic;
using System.IO;
using System.Xml;

public partial class _Default : System.Web.UI.Page
{
    protected string v_oid = "";
    protected string v_amount = "";
    protected string amount = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request["OrderID"]) && Request["OrderID"] != "")
        {
            ViewState["Type"] = WebFunc.GetOrderType(Input.FilterAll(Request["OrderID"]));
            if (!WebFunc.CheckOrderIsValidate(Request["OrderID"]))
            {
                Page.RegisterStartupScript(Pbzx.Web.WebFunc.GetGuid(), Pbzx.Common.JS.myAlert1("", "对不起！该订单已取消或者已失效！", 400, "1", "history.go(-1);", "", false, false));
                return;
            }
            DataTable dtOrders = WebFunc.GetDsOrder(Request["OrderID"]);
            if (dtOrders == null)
            {
                Page.RegisterStartupScript(Pbzx.Web.WebFunc.GetGuid(), Pbzx.Common.JS.myAlert1("", "对不起！订单错误！", 400, "1", "history.go(-1);", "", false, false));
                return;
            }
            decimal payJE = 0;
            if (dtOrders.TableName == "PBnet_Orders")
            {
                payJE = Convert.ToDecimal(dtOrders.Rows[0]["HasNotPayedPrice"]);
            }
            else if (dtOrders.TableName == "PBnet_Charge")
            {
                payJE = Convert.ToDecimal(dtOrders.Rows[0]["PayMoney"]) - Convert.ToDecimal(dtOrders.Rows[0]["HasPayedPrice"]);
            }
            v_oid = Request["OrderID"];
            v_amount = payJE.ToString("0.00");
            amount = v_amount;
        }
        else
        {
            Page.RegisterStartupScript(Pbzx.Web.WebFunc.GetGuid(), Pbzx.Common.JS.myAlert1("", "对不起！订单错误！", 400, "1", "history.go(-1);", "", false, false));
            return;
        }
    }
    protected void BtnAlipay_Click(object sender, EventArgs e)
    {
        //        Pbzx.Common.ErrorLog.WriteLogMeng("在线交易", "支付宝订单开始，订单号：" + Request["OrderID"], true, true);
        //业务参数赋值；
        DataTable dtOrder = WebFunc.GetDsOrder(Input.FilterAll(Request["OrderID"]));
        DataSet dsDetails = null;
        DataRow row = null;
        if (dtOrder != null)
        {
            row = dtOrder.Rows[0];
            string out_trade_no = row["OrderID"].ToString();
            if (!WebFunc.CheckOrderIsValidate(Request["OrderID"]))
            {
                Page.RegisterStartupScript(Pbzx.Web.WebFunc.GetGuid(), Pbzx.Common.JS.myAlert1("", "对不起！该订单已取消或者已失效！", 400, "1", "history.go(-1);", "", false, false));
                return;
            }
            string subject = "拼搏在线彩神通软件订单号：" + row["OrderID"]; //subject//商品名称，也可称为订单名称，该接口并不是单一的只能买一样东西，可把一次支付当作一次下订单
//            string gateway = "https://www.alipay.com/cooperate/gateway.do?";	//支付接口
            string service = "create_direct_pay_by_user";                       //服务名称，这个是识别是何接口实现何功能的标识，请勿修改
//            string seller_email = "alipay@pinble.com";                     //商家签约时的支付宝帐号，即收款的支付宝帐号
//            string sign_type = "MD5";                                           //加密类型,签名方式“不用改”
//            string key = "42lcumkpbfse5czpoykj155l4sttuqij";                    //安全校验码，与partner是一组，获取方式是：用签约时支付宝帐号登陆支付宝网站www.alipay.com，在商家服务我的商家里即可查到。
            string partner = "2088002305122788";                                //商户ID，合作身份者ID，合作伙伴ID
            string _input_charset = "utf-8";                                    //编码类型，完全根据客户自身的项目的编码格式而定，千万不要填错。否则极其容易造成MD5加密错误。

            if (dtOrder.TableName == "PBnet_Orders")
            {
                //Pbzx.Common.ErrorLog.WriteLogMeng("在线交易", "验证支付宝订单，此订单为商品订单。",true);
                dsDetails = new Pbzx.BLL.PBnet_OrderDetail().SelectOrderDetailByOrderID(out_trade_no);
                StringBuilder sbBody = new StringBuilder("");
                //业务参数赋值；
                string show_url = WebInit.webBaseConfig.WebUrl + "UserCenter/OrderShow/" + ViewState["Type"].ToString() + "-" + out_trade_no + ".htm";  //show_url商品展示地址，这个链接的作用是在支付宝收银台的商品链接旁边有个下划线“详情”的链接，而点链接弹出的一个新页面便是这个商品展示地址的页面。+ out_trade_no + "&type=" + ViewState["Type"]                

                foreach (DataRow rowDetails in dsDetails.Tables[0].Rows)
                {
                    sbBody.AppendLine(rowDetails["pb_SoftName"].ToString());//+ WebFunc.CheckRegTye(rowDetails["RegType"], rowDetails["pb_TypeName"], rowDetails["pb_DemoUrl"], rowDetails["pb_RegUrl"]));
                }
                string body = StrFormat.CutStringByNum(sbBody.ToString(), 380);		//商品描述，即备注
                string total_fee = Convert.ToDecimal(row["HasNotPayedPrice"]).ToString("0.00");                        //商品价格，也可称为订单的总金额
                //服务器通知url（Alipay_Notify.aspx文件所在路经），必须是完整的路径地址
                string notify_url = WebInit.webBaseConfig.WebUrl + "Alipay/Alipay_Notify.aspx"; //服务器通知返回接口
                //服务器返回url（Alipay_Return.aspx文件所在路经），必须是完整的路径地址
                string return_url = WebInit.webBaseConfig.WebUrl + "Alipay/Alipay_Return.aspx"; //重定下地址
                //构造数组；
                //以下数组即是参与加密的参数，若参数的值不允许为空，若该参数为空，则不要成为该数组的元素
                /*
                string[] para ={
                                "service="+service,
                                "partner=" + partner,
                                "seller_email=" + seller_email,
                                "out_trade_no=" + out_trade_no,
                                "subject=" + subject,
                                "body=" + body,
                                "total_fee=" + total_fee, 
                                "show_url=" + show_url,
                                "payment_type=1",
                                "notify_url=" + notify_url,
                                "return_url=" + return_url,
                                "_input_charset="+_input_charset
                                };
                //支付URL生成
                string aliay_url = AliPay.CreatUrl(
                    gateway,//GET方式传递参数时请去掉注释
                    para,
                    _input_charset,
                    sign_type,
                    key
                    );
                //以下是GET方式传递参数
                Response.Redirect(aliay_url);               
                */
                SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();
                sParaTemp.Add("partner", partner);
                sParaTemp.Add("seller_id", "2088002305122788");
                sParaTemp.Add("_input_charset", _input_charset);
                sParaTemp.Add("service", service);
                sParaTemp.Add("payment_type", "1");
                sParaTemp.Add("notify_url", notify_url);
                sParaTemp.Add("return_url", return_url);
                sParaTemp.Add("out_trade_no", out_trade_no);
                sParaTemp.Add("subject", subject);
                sParaTemp.Add("total_fee", total_fee);
                sParaTemp.Add("show_url", show_url);
                //sParaTemp.Add("app_pay","Y");//启用此参数可唤起钱包APP支付。
                sParaTemp.Add("body", body);

                //建立请求
                string sHtmlText = Submit.BuildRequest(sParaTemp, "get", "确认");
                Response.Write(sHtmlText);
                
            }
            else if (dtOrder.TableName == "PBnet_Charge")
            {

                //Pbzx.Common.ErrorLog.WriteLogMeng("在线交易", "验证订单，此订单为充值订单。",true);
                StringBuilder sbBody = new StringBuilder("");
                //业务参数赋值；
                string show_url = WebInit.webBaseConfig.WebUrl + "UserCenter/OrderShow/" + ViewState["Type"].ToString() + "-" + out_trade_no + ".htm";  //show_url商品展示地址，这个链接的作用是在支付宝收银台的商品链接旁边有个下划线“详情”的链接，而点链接弹出的一个新页面便是这个商品展示地址的页面。+ out_trade_no + "&type=" + ViewState["Type"]                                                  
                string body = "拼搏在线彩神通软件用户充值";		//商品描述，即备注    
                decimal tempPrice = Convert.ToDecimal(row["PayMoney"]) - Convert.ToDecimal(row["HasPayedPrice"]);
                string total_fee = tempPrice.ToString("0.00");                        //商品价格，也可称为订单的总金额

                //服务器通知url（Alipay_Notify.aspx文件所在路经），必须是完整的路径地址
                string notify_url = WebInit.webBaseConfig.WebUrl + "Alipay/Alipay_Notify.aspx"; //服务器通知返回接口
                //服务器返回url（Alipay_Return.aspx文件所在路经），必须是完整的路径地址
                string return_url = WebInit.webBaseConfig.WebUrl + "Alipay/Alipay_Return.aspx"; //重定下地址
                //构造数组；
                //以下数组即是参与加密的参数，若参数的值不允许为空，若该参数为空，则不要成为该数组的元素
                /*
               string[] para ={
                               "service="+service,
                               "partner=" + partner,
                               "seller_email=" + seller_email,
                               "out_trade_no=" + out_trade_no,
                               "subject=" + subject,
                               "body=" + body,
                               "total_fee=" + total_fee, 
                               "show_url=" + show_url,
                               "payment_type=1",
                               "notify_url=" + notify_url,
                               "return_url=" + return_url,
                               "_input_charset="+_input_charset
                               };
               //支付URL生成
               
               string aliay_url = AliPay.CreatUrl(
                   gateway,//GET方式传递参数时请去掉注释
                   para,
                   _input_charset,
                   sign_type,
                   key
                   );
               //以下是GET方式传递参数
               Response.Redirect(aliay_url);
               */
                #region //以下是POST方式传递参数
                //Response.Write("<form name='alipaysubmit' method='post' action='https://www.alipay.com/cooperate/gateway.do?_input_charset=utf-8'>");
                //Response.Write("<input type='hidden' name='service' value=" + service + ">");
                //Response.Write("<input type='hidden' name='partner' value=" + partner + ">");
                //Response.Write("<input type='hidden' name='seller_email' value=" + seller_email + ">");
                //Response.Write("<input type='hidden' name='out_trade_no' value=" + out_trade_no + ">");
                //Response.Write("<input type='hidden' name='subject' value=" + subject + ">");
                //Response.Write("<input type='hidden' name='body' value=" + body + ">");
                //Response.Write("<input type='hidden' name='total_fee' value=" + total_fee + ">");
                //Response.Write("<input type='hidden' name='show_url' value=" + show_url + ">");
                //Response.Write("<input type='hidden' name='return_url' value=" + return_url + ">");
                //Response.Write("<input type='hidden' name='notify_url' value=" + notify_url + ">");
                //Response.Write("<input type='hidden' name='payment_type' value=1>");
                //Response.Write("<input type='hidden' name='sign' value=" + aliay_url + ">");
                //Response.Write("<input type='hidden' name='sign_type' value=" + sign_type + ">");
                //Response.Write("</form>");
                //Response.Write("<script>");
                //Response.Write("document.alipaysubmit.submit()");
                //Response.Write("</script>");
                #endregion


                ////////////////////////////////////////////////////////////////////////////////////////////////

                //把请求参数打包成数组
                SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();
                sParaTemp.Add("partner", partner);
                sParaTemp.Add("seller_id", "2088002305122788");
                sParaTemp.Add("_input_charset", _input_charset);
                sParaTemp.Add("service", service);
                sParaTemp.Add("payment_type", "1");
                sParaTemp.Add("notify_url", notify_url);
                sParaTemp.Add("return_url", return_url);
                sParaTemp.Add("out_trade_no", out_trade_no);
                sParaTemp.Add("subject", subject);
                sParaTemp.Add("total_fee", total_fee);
                sParaTemp.Add("show_url", show_url);
                //sParaTemp.Add("app_pay","Y");//启用此参数可唤起钱包APP支付。
                sParaTemp.Add("body", body);                

                //建立请求
                string sHtmlText = Submit.BuildRequest(sParaTemp, "get", "确认");
                Response.Write(sHtmlText);
            }
        }
    }
}
