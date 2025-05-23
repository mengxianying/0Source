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
using Aop.Api.Util;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// 创建该页面文件时，请留心该页面文件中无任何HTML代码及空格。
/// 该页面称作“通知页”，是异步被支付宝服务器所调用。
/// 当支付宝的订单状态改变时，支付宝服务器则会自动调用此页面，因此请做好自身网站订单信息与支付宝上的订单的同步工作
/// </summary>
public partial class Alipay_Notify : System.Web.UI.Page
{
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
            bool flag = AlipaySignature.RSACheckV1(sArray, config.alipay_public_key, config.charset, config.sign_type, false);
            if (flag)
            {
                //交易状态
                //判断该笔订单是否在商户网站中已经做过处理
                //如果没有做过处理，根据订单号（out_trade_no）在商户网站的订单系统中查到该笔订单的详细，并执行商户的业务程序
                //请务必判断请求时的total_amount与通知时获取的total_fee为一致的
                //如果有做过处理，不执行商户的业务程序

                //注意：
                //退款日期超过可退款期限后（如三个月可退款），支付宝系统发送该交易状态通知
                string trade_status = Request.Form["trade_status"];

                if (Request.Form["trade_status"] == "WAIT_BUYER_PAY")//   判断支付状态_等待买家付款（文档中有枚举表可以参考）            
                {
                    //更新自己数据库的订单语句，请自己填写一下
                    string strOrderNO = Request.Form["out_trade_no"];//订单号
                    string strPrice = Request.Form["total_fee"];//金额    如果你申请了商家购物卷功能，在返回信息里面请不要做金额的判断，否则会校验通过不了。
                }
                else if (Request.Form["trade_status"] == "TRADE_FINISHED" || Request.Form["trade_status"] == "TRADE_SUCCESS")//   判断支付状态_交易成功结束（文档中有枚举表可以参考）   
                {
                    //更新自己数据库的订单语句，请自己填写一下
                    string strOrderNO = Request.Form["out_trade_no"];//订单号
                    string strPrice = Request.Form["total_fee"];//金额   
                    WebFunc.UpdateOrder(strOrderNO, true, Request["total_fee"], "alipay@pinble.com", "（自动）", 16, "支付宝支付");
                }
                else
                {
                    //更新自己数据库的订单语句，请自己填写一下
                }
                Response.Write("success");     //返回给支付宝消息，成功，请不要改写这个success
                //success与fail及其他字符的区别在于，支付宝的服务器若遇到success时，则不再发送请求通知（即不再调用该页面，让该页面再次运行起来），
                //若不是success，则支付宝默认没有收到成功的信息，则会反复不停地调用该页面直到失效，有效调用时间是24小时以内。

                //最好写TXT文件，以记录下是否异步返回记录。

                ////写文本，纪录支付宝返回消息，比对md5计算结果（如网站不支持写txt文件，可改成写数据库）
                //string TOEXCELLR = "MD5结果:mysign=" + mysign + ",sign=" + sign + ",responseTxt=" + responseTxt;
                //StreamWriter fs = new StreamWriter(Server.MapPath("Notify_DATA/" + DateTime.Now.ToString().Replace(":", "")) + ".txt", false, System.Text.Encoding.Default);
                //fs.Write(TOEXCELLR);
                //fs.Close();            

//                string TempMsg = "订单号：" + Request.Form["out_trade_no"] + "\r\n订单状态：" + Request.Form["trade_status"] + "\r\n" + "交易号trade_no：" + Request.Form["trade_no"] + "\r\n价格：" + Request["total_fee"] + "\r\nsign：" + Request.Form["sign"] + "\r\nmysign：" + mysign + "\r\n结果：交易成功";
                string TempMsg = "订单号：" + Request.Form["out_trade_no"] + "\r\n订单状态：" + Request.Form["trade_status"] + "\r\n" + "交易号trade_no：" + Request.Form["trade_no"] + "\r\n价格：" + Request["total_fee"] + "\r\n结果：交易成功";
                Pbzx.Common.ErrorLog.WriteLogMeng("在线交易", TempMsg, true, true);
            }
            else
            {
                Response.Write("fail");
                //最好写TXT文件，以记录下是否异步返回记录。
                //写文本，纪录支付宝返回消息，比对md5计算结果（如网站不支持写txt文件，可改成写数据库）
                //string TOEXCELLR = "MD5结果:mysign=" + mysign + ",sign=" + sign + ",responseTxt=" + responseTxt;
                //Pbzx.Common.ErrorLog.WriteLogMeng("在线交易", "失败消息：" + TOEXCELLR, true, true);
                //StreamWriter fs = new StreamWriter(Server.MapPath("Notify_DATA/" + DateTime.Now.ToString().Replace(":", "")) + ".txt", false, System.Text.Encoding.Default);
                //fs.Write(TOEXCELLR);
                //fs.Close();
                string Name = Method.Get_UserName;
                if (Name == "0")
                {
                    Name = "游客";
                }
                Method.record_user_log(Name, "校验失败，数据可疑", "数据可疑", "恶意攻击");
            }
        }
        else
        {
            Pbzx.Common.ErrorLog.WriteLogMeng("在线交易", "GetRequestPost()返回参数个数为0", true, true);

        }
        /*
        string alipayNotifyURL = "https://www.alipay.com/cooperate/gateway.do?service=notify_verify";
        //string alipayNotifyURL = "http://notify.alipay.com/trade/notify_query.do?";//此路径是在上面链接地址无法起作用时替换使用。
        string partner = "2088002305122788"; 		//partner合作伙伴id（必须填写）
        string key = "42lcumkpbfse5czpoykj155l4sttuqij"; //partner 的对应交易安全校验码（必须填写）
        string _input_charset = "utf-8";//编码类型，完全根据客户自身的项目的编码格式而定，千万不要填错。否则极其容易造成MD5加密错误。

        alipayNotifyURL = alipayNotifyURL + "&partner=" + partner + "&notify_id=" + Request.Form["notify_id"];

        //获取支付宝ATN返回结果，true是正确的订单信息，false 是无效的
        string responseTxt = AliPay.Get_Http(alipayNotifyURL, 120000);

        //*******加密签名程序开始*******
        int i;
        NameValueCollection coll;
        //Load Form variables into NameValueCollection variable.
        coll = Request.Form;

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
                    prestr.Append(Sortedstr[i] + "=" + Request.Form[Sortedstr[i]]);
                }
                else
                {
                    prestr.Append(Sortedstr[i] + "=" + Request.Form[Sortedstr[i]] + "&");

                }
            }
        }

        prestr.Append(key);

        string mysign = AliPay.GetMD5(prestr.ToString(), _input_charset);
        //*******加密签名程序结束*******

        string sign = Request.Form["sign"];


        if (mysign == sign && responseTxt == "true")   //验证支付发过来的消息，签名是否正确，只要成功进如这个判断里，则表示该页面已被支付宝服务器成功调用
        //但判断内出现自身编写的程序相关错误导致通知给支付宝并不是发送success的消息或没有更新客户自身的数据库的情况，请自身程序编写好应对措施，否则查明原因时困难之极
        {
            if (Request.Form["trade_status"] == "WAIT_BUYER_PAY")//   判断支付状态_等待买家付款（文档中有枚举表可以参考）            
            {
                //更新自己数据库的订单语句，请自己填写一下
                string strOrderNO = Request.Form["out_trade_no"];//订单号
                string strPrice = Request.Form["total_fee"];//金额    如果你申请了商家购物卷功能，在返回信息里面请不要做金额的判断，否则会校验通过不了。
            }
            else if (Request.Form["trade_status"] == "TRADE_FINISHED" || Request.Form["trade_status"] == "TRADE_SUCCESS")//   判断支付状态_交易成功结束（文档中有枚举表可以参考）   
            {
                //更新自己数据库的订单语句，请自己填写一下
                string strOrderNO = Request.Form["out_trade_no"];//订单号
                string strPrice = Request.Form["total_fee"];//金额   
                WebFunc.UpdateOrder(strOrderNO, true, Request["total_fee"], "alipay@pinble.com", "（自动）", 16, "支付宝支付");
            }
            else
            {
                //更新自己数据库的订单语句，请自己填写一下
            }
            Response.Write("success");     //返回给支付宝消息，成功，请不要改写这个success
            //success与fail及其他字符的区别在于，支付宝的服务器若遇到success时，则不再发送请求通知（即不再调用该页面，让该页面再次运行起来），
            //若不是success，则支付宝默认没有收到成功的信息，则会反复不停地调用该页面直到失效，有效调用时间是24小时以内。

            //最好写TXT文件，以记录下是否异步返回记录。

            ////写文本，纪录支付宝返回消息，比对md5计算结果（如网站不支持写txt文件，可改成写数据库）
            //string TOEXCELLR = "MD5结果:mysign=" + mysign + ",sign=" + sign + ",responseTxt=" + responseTxt;
            //StreamWriter fs = new StreamWriter(Server.MapPath("Notify_DATA/" + DateTime.Now.ToString().Replace(":", "")) + ".txt", false, System.Text.Encoding.Default);
            //fs.Write(TOEXCELLR);
            //fs.Close();            

//            string TempMsg = "订单号：" + Request.Form["out_trade_no"] + "\r\n订单状态：" + Request.Form["trade_status"] + "\r\n" + "交易号trade_no：" + Request.Form["trade_no"] + "\r\n价格：" + Request["total_fee"] + "\r\nsign：" + Request.Form["sign"] + "\r\nmysign：" + mysign + "\r\n结果：交易成功";
//            Pbzx.Common.ErrorLog.WriteLogMeng("在线交易", TempMsg, true, true);
        }
        else
        {
            Response.Write("fail");
            //最好写TXT文件，以记录下是否异步返回记录。
            //写文本，纪录支付宝返回消息，比对md5计算结果（如网站不支持写txt文件，可改成写数据库）
            string TOEXCELLR = "MD5结果:mysign=" + mysign + ",sign=" + sign + ",responseTxt=" + responseTxt;
            Pbzx.Common.ErrorLog.WriteLogMeng("在线交易", "失败消息：" + TOEXCELLR,true,true);
            //StreamWriter fs = new StreamWriter(Server.MapPath("Notify_DATA/" + DateTime.Now.ToString().Replace(":", "")) + ".txt", false, System.Text.Encoding.Default);
            //fs.Write(TOEXCELLR);
            //fs.Close();
            string Name = Method.Get_UserName;
            if (Name == "0")
            {
                Name = "游客";
            }
            Method.record_user_log(Name, "校验失败，数据可疑", "数据可疑", "恶意攻击");
        }
        */
    }
    public Dictionary<string, string> GetRequestPost()
    {
        int i = 0;
        Dictionary<string, string> sArray = new Dictionary<string, string>();
        NameValueCollection coll;
        //coll = Request.Form;
        coll = Request.Form;

        String[] requestItem = coll.AllKeys;
        for (i = 0; i < requestItem.Length; i++)
        {
            sArray.Add(requestItem[i], Request.Params[requestItem[i]]);
        }
        return sArray;

    }
}
