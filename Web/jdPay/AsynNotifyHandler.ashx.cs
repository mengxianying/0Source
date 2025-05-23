using jdPay.PropertyUtil;
using jdPay.responseObj;
using jdPay.signature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace jdPay
{
    /// <summary>
    /// AsynNotifyHandler 的摘要说明
    /// </summary>
    public class AsynNotifyHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            byte[] byts = new byte[context.Request.InputStream.Length];
            context.Request.InputStream.Read(byts, 0, byts.Length);

            string req = Encoding.UTF8.GetString(byts);
            String deskey = PropertyUtils.getProperty("wepay.merchant.desKey");
            String pubKey = PropertyUtils.getProperty("wepay.jd.rsaPublicKey");
            String error = "";
            try
            {
                error = "success";
                AsynNotifyResponse anyResponse = XMLUtil.decryptResXml<AsynNotifyResponse>(pubKey, deskey, req);
                System.Diagnostics.Debug.WriteLine("异步通知订单号：" + anyResponse.tradeNum + ",状态：" + anyResponse.status);
            }
            catch
            {
                error = "fail";
            }
           
            context.Response.ContentType = "text/plain";
            context.Response.Write(error);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}