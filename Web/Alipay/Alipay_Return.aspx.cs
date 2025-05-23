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
using System.Text;
using System.Collections.Specialized;
using System.IO;
using Gateway;
using Pbzx.Web;
using Pbzx.Common;
using System.Collections.Generic;
using System.Linq;
using Aop.Api.Util;

/// <summary>
/// 创建该页面文件时，请留心该页面文件是可以对其进行美工处理的，原因在于支付完成以后，当前窗口会从支付宝的页面跳转回这个页面。
/// 该页面称作“返回页”，是同步被支付宝服务器所调用，可当作是支付完成后的提示信息页，如“您的某某某订单，多少金额已支付成功”。
/// </summary>
public partial class Alipay_Return : System.Web.UI.Page
{
    protected string orderDetailUrl = "#";
    public string orderId = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        /* 实际验证过程建议商户添加以下校验。
        1、商户需要验证该通知数据中的out_trade_no是否为商户系统中创建的订单号，
        2、判断total_amount是否确实为该订单的实际金额（即商户订单创建时的金额），
        3、校验通知中的seller_id（或者seller_email) 是否为out_trade_no这笔单据的对应的操作方（有的时候，一个商户可能有多个seller_id/seller_email）
        4、验证app_id是否为该商户本身。
        */
        Dictionary<string, string> sArray = GetRequestPost();
        if (sArray.Count != 0)
        {
//            Pbzx.Common.ErrorLog.WriteLogMeng("在线交易", "sArray.Count=" + sArray.Count.ToString() + "\r\n", true, true);
//            Pbzx.Common.ErrorLog.WriteLogMeng("在线交易", "flag开始\r\n", true, true);
            bool flag = AlipaySignature.RSACheckV1(sArray, config.alipay_public_key, config.charset, config.sign_type, false);
//            Pbzx.Common.ErrorLog.WriteLogMeng("在线交易", "flag=" + flag.ToString() + "\r\n", true, true);
            if (flag)
            {
                //交易状态
                //判断该笔订单是否在商户网站中已经做过处理
                //如果没有做过处理，根据订单号（out_trade_no）在商户网站的订单系统中查到该笔订单的详细，并执行商户的业务程序
                //请务必判断请求时的total_amount与通知时获取的total_fee为一致的
                //如果有做过处理，不执行商户的业务程序

                //注意：
                //退款日期超过可退款期限后（如三个月可退款），支付宝系统发送该交易状态通知
                //string trade_status = Request.Form["trade_status"];

                //更新自己数据库的订单语句，请自己填写一下
                //            string strOrderNO = Request.QueryString["out_trade_no"];//订单号
                string strOrderID = Request.QueryString["out_trade_no"];//订单号
                string strPrice = Request.QueryString["total_fee"];//金额
                string strTradeStatus = Request.QueryString["TRADE_STATUS"];//订单状态
//                Pbzx.Common.ErrorLog.WriteLogMeng("在线交易", "strOrderID=" + strOrderID + "\r\n", true, true);
//                Pbzx.Common.ErrorLog.WriteLogMeng("在线交易", "strTradeStatus=" + strTradeStatus + "\r\n", true, true);
                if (string.IsNullOrEmpty(strOrderID) || string.IsNullOrEmpty(strPrice) || string.IsNullOrEmpty(strTradeStatus))
                {
                    this.tbOrder.Visible = false;
                    Pbzx.Common.ErrorLog.WriteLogMeng("在线交易", "订单号：为空，直接返回;\r\n", true, true);
                    return;
                }
                this.tbOrder.Visible = true;
                //            string strOrderID = Request["out_trade_no"];
                DataTable dtOrders = WebFunc.GetDsOrder(strOrderID);
                decimal payJE = 0;
                if (dtOrders.TableName == "PBnet_Orders")
                {
                    payJE = Convert.ToDecimal(dtOrders.Rows[0]["SumPrice"]);
                }
                else if (dtOrders.TableName == "PBnet_Charge")
                {
                    payJE = Convert.ToDecimal(dtOrders.Rows[0]["PayMoney"]);
                }

                Pbzx.Common.ErrorLog.WriteLogMeng("在线交易", "订单号：" + strOrderID + "；订单返回价格：" + payJE + "；结果：返回成功", true, true);
                this.lblOrderID.Text = strOrderID;
                this.lblOrderDate.Text = dtOrders.Rows[0]["OrderDate"].ToString();
                this.lblAmount.Text = payJE.ToString("0.00");
                this.lblResult.Text = "支付成功！";
                orderDetailUrl = WebFunc.GetReturnUrl(strOrderID);
                Response.Write("success");     //返回给支付宝消息，成功
            }
            else
            {
                this.lblResult.Text = "支付失败！";
                string strOrderID = Request.QueryString["out_trade_no"];//订单号
                Pbzx.Common.ErrorLog.WriteLogMeng("在线交易", "订单号：" + strOrderID + "；结果：订单返回失败;", true, true);
                //string msg = "http://www2.pinble.com/Alipay/Alipay_Notify.aspx?body=%E6%95%B0%E5%AD%97%E4%B8%89%E3%80%8E%E5%BD%A9%E7%A5%9E%E9%80%9A%E3%80%8F%E4%B8%93%E4%B8%9A%E7%89%88&buyer_email=770598513%40qq.com&buyer_id=2088202990777162&exterface=trade_create_by_buyer&is_success=T&notify_id=RqPnCoPT3K9%252Fvwbh3I%252BKCJaa0xEB5GhUSUtx9xMhpYGIOrBlU%252BFs1r3sof6Bh5yhdRSN&notify_time=2010-03-27+11%3A01%3A51&notify_type=trade_status_sync&out_trade_no=ST10032748300001&payment_type=1&seller_email=alipay%40pinble.com&seller_id=2088002305122788&subject=%E6%8B%BC%E6%90%8F%E5%9C%A8%E7%BA%BF%E5%BD%A9%E7%A5%A8%E7%BD%91%E8%AE%A2%E5%8D%95%E5%8F%B7%EF%BC%9AST10032748300001&total_fee=0.01&trade_no=2010032735431599&trade_status=TRADE_FINISHED&sign=5605288ce4446731aad3ff62148a0a49&sign_type=MD5";
                this.tbOrder.Visible = false;

                //Response.Write("------------------------------------------");
                //Response.Write("<br>Result:responseTxt=" + responseTxt);
                //Response.Write("<br>Result:mysign=" + mysign);
                //Response.Write("<br>Result:sign=" + sign);
                //Response.Write("支付失败");                                             //支付失败，提示信息
                string Name = Method.Get_UserName;
                if (Name == "0")
                {
                    Name = "游客";
                }
                Method.record_user_log(Name, "校验失败，数据可疑", "数据可疑", "恶意攻击");

                Response.Write("fail");
                return;
            }
        }
        else
        {
            Pbzx.Common.ErrorLog.WriteLogMeng("在线交易", "GetRequestPost()返回参数个数为0", true, true);

        }
        
        /*
        orderId = Request["out_trade_no"];
        string alipayNotifyURL = "https://www.alipay.com/cooperate/gateway.do?service=notify_verify";
        //string alipayNotifyURL = "http://notify.alipay.com/trade/notify_query.do?";//此路径是在上面链接地址无法起作用时替换使用。
        string key = "42lcumkpbfse5czpoykj155l4sttuqij"; //partner 的对应交易安全校验码（必须填写）
        string partner = "2088002305122788"; 		//partner合作伙伴id（必须填写）
        string _input_charset = "utf-8";//编码类型，完全根据客户自身的项目的编码格式而定，千万不要填错。否则极其容易造成MD5加密错误。

        alipayNotifyURL = alipayNotifyURL + "&partner=" + partner + "&notify_id=" + Request.QueryString["notify_id"];

        //获取支付宝ATN返回结果，true是正确的订单信息，false 是无效的
        string responseTxt = AliPay.Get_Http(alipayNotifyURL, 120000);

        //*******加密签名程序开始//*******
        int i;
        NameValueCollection coll;
        //Load Form variables into NameValueCollection variable.
        coll = Request.QueryString;

        // Get names of all forms into a string array.
        String[] requestarr = coll.AllKeys;

        //进行排序；
        string[] Sortedstr = AliPay.BubbleSort(requestarr);

        //构造待md5摘要字符串 ；

        StringBuilder prestr = new StringBuilder();

        for (i = 0; i < Sortedstr.Length; i++)
        {
            if (Request.Form[Sortedstr[i]] != "" && Sortedstr[i] != "sign" && Sortedstr[i] != "sign_type")
            {
                if (i == Sortedstr.Length - 1)
                {
                    prestr.Append(Sortedstr[i] + "=" + Request.QueryString[Sortedstr[i]]);
                }
                else
                {
                    prestr.Append(Sortedstr[i] + "=" + Request.QueryString[Sortedstr[i]] + "&");

                }
            }
        }

        prestr.Append(key);

        //生成Md5摘要；
        string mysign = AliPay.GetMD5(prestr.ToString(), _input_charset);
        //*******加密签名程序结束*******
        string sign = Request.QueryString["sign"];
        //Response.Write(prestr.ToString());  //调试用，支付宝服务器返回时的完整路径。       
        if (mysign == sign && responseTxt == "true")   //验证支付发过来的消息，签名是否正确
        {
            //更新自己数据库的订单语句，请自己填写一下
//            string strOrderNO = Request.QueryString["out_trade_no"];//订单号
            string strOrderID = Request.QueryString["out_trade_no"];//订单号
            string strPrice = Request.QueryString["total_fee"];//金额
            string strTradeStatus = Request.QueryString["TRADE_STATUS"];//订单状态
            if (string.IsNullOrEmpty(strOrderID) || string.IsNullOrEmpty(strPrice) || string.IsNullOrEmpty(strTradeStatus))
            {
                this.tbOrder.Visible = false;
                Pbzx.Common.ErrorLog.WriteLogMeng("在线交易", "订单号：为空，直接返回;\r\n", true, true);
                return;
            }
            this.tbOrder.Visible = true;
//            string strOrderID = Request["out_trade_no"];
            DataTable dtOrders = WebFunc.GetDsOrder(strOrderID);
            decimal payJE = 0;
            if (dtOrders.TableName == "PBnet_Orders")
            {
                payJE = Convert.ToDecimal(dtOrders.Rows[0]["SumPrice"]);
            }
            else if (dtOrders.TableName == "PBnet_Charge")
            {
                payJE = Convert.ToDecimal(dtOrders.Rows[0]["PayMoney"]);
            }

            Pbzx.Common.ErrorLog.WriteLogMeng("在线交易", "订单号：" + strOrderID + "；订单返回价格：" + payJE + "；结果：返回成功", true, true);
            this.lblOrderID.Text = strOrderID;
            this.lblOrderDate.Text = dtOrders.Rows[0]["OrderDate"].ToString();
            this.lblAmount.Text = payJE.ToString("0.00");
            this.lblResult.Text = "支付成功！";
            orderDetailUrl = WebFunc.GetReturnUrl(strOrderID);
            //Response.Write("success");     //返回给支付宝消息，成功
        }
        else if (responseTxt == "true")
        {
            this.lblResult.Text = "支付失败！";
            string strOrderID = Request.QueryString["out_trade_no"];//订单号
            Pbzx.Common.ErrorLog.WriteLogMeng("在线交易", "mysign：" + mysign + "；\r\n sign：" + sign + "；\r\n responseTxt：" + responseTxt, true, true);
            Pbzx.Common.ErrorLog.WriteLogMeng("在线交易", "订单号：" + strOrderID + "；结果：订单返回失败;", true, true);
            //string msg = "http://www2.pinble.com/Alipay/Alipay_Notify.aspx?body=%E6%95%B0%E5%AD%97%E4%B8%89%E3%80%8E%E5%BD%A9%E7%A5%9E%E9%80%9A%E3%80%8F%E4%B8%93%E4%B8%9A%E7%89%88&buyer_email=770598513%40qq.com&buyer_id=2088202990777162&exterface=trade_create_by_buyer&is_success=T&notify_id=RqPnCoPT3K9%252Fvwbh3I%252BKCJaa0xEB5GhUSUtx9xMhpYGIOrBlU%252BFs1r3sof6Bh5yhdRSN&notify_time=2010-03-27+11%3A01%3A51&notify_type=trade_status_sync&out_trade_no=ST10032748300001&payment_type=1&seller_email=alipay%40pinble.com&seller_id=2088002305122788&subject=%E6%8B%BC%E6%90%8F%E5%9C%A8%E7%BA%BF%E5%BD%A9%E7%A5%A8%E7%BD%91%E8%AE%A2%E5%8D%95%E5%8F%B7%EF%BC%9AST10032748300001&total_fee=0.01&trade_no=2010032735431599&trade_status=TRADE_FINISHED&sign=5605288ce4446731aad3ff62148a0a49&sign_type=MD5";
            this.tbOrder.Visible = false;

            //Response.Write("------------------------------------------");
            //Response.Write("<br>Result:responseTxt=" + responseTxt);
            //Response.Write("<br>Result:mysign=" + mysign);
            //Response.Write("<br>Result:sign=" + sign);
            //Response.Write("支付失败");                                             //支付失败，提示信息
            string Name = Method.Get_UserName;
            if (Name == "0")
            {
                Name = "游客";
            }
            Method.record_user_log(Name, "校验失败，数据可疑", "数据可疑", "恶意攻击");
            return;
        }
        */
    }
    public Dictionary<string, string> GetRequestPost()
    {
        int i = 0;
        Dictionary<string, string> sArray = new Dictionary<string, string>();
        NameValueCollection coll;

        int num = Request.QueryString.Count;
        foreach (string key in Request.QueryString.AllKeys)
        {
            sArray.Add(key, Request.QueryString[key]);
        }

 
        /*
        //coll = Request.Form;
        coll = Request.Form;
        String[] requestItem = coll.AllKeys;
        for (i = 0; i < requestItem.Length; i++)
        {
            //sArray.Add(requestItem[i], Request.Form[requestItem[i]]);
            sArray.Add(requestItem[i], Request.Params[requestItem[i]]);
        }
        */
        return sArray;

    }
}
