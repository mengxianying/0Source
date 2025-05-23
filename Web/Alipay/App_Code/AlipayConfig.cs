using System.Web;
using System.Text;
using System.IO;
using System.Net;
using System;
using System.Collections.Generic;

namespace Com.Alipay
{
    /// <summary>
    /// 类名：Config
    /// 功能：基础配置类
    /// 详细：设置帐户有关信息及返回路径
    /// 版本：3.4
    /// 修改日期：2016-03-08
    /// 说明：
    /// 以下代码只是为了方便商户测试而提供的样例代码，商户可以根据自己网站的需要，按照技术文档编写,并非一定要使用该代码。
    /// 该代码仅供学习和研究支付宝接口使用，只是提供一个参考。
    /// </summary>
    public class Config
    {

        //↓↓↓↓↓↓↓↓↓↓请在这里配置您的基本信息↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

        // 合作身份者ID，签约账号，以2088开头由16位纯数字组成的字符串，查看地址：https://b.alipay.com/order/pidAndKey.htm
        public static string partner = "2088002305122788";

        // 收款支付宝账号，以2088开头由16位纯数字组成的字符串，一般情况下收款账号就是签约账号
        public static string seller_id = partner;
		
		//商户的私钥,原始格式，RSA公私钥生成：https://doc.open.alipay.com/doc2/detail.htm?spm=a219a.7629140.0.0.nBDxfy&treeId=58&articleId=103242&docType=1
        public static string private_key = "MIICXQIBAAKBgQDF8BCsHwarQz0cFl4OrPy0oDfKgta6KBut3ZZQ3tRhJNWEjA3OTYBaRyE1XzVU94gApCUTrw2hBmHw1s3+zEZyLe5Ji/Wp1fuR/aLDt7QXIrq/p9sOrASZM8haPIKHcvxazC7vf6bRa487pXzNR5iDJD5mfF4mbDMOjy7J5VhnnQIDAQABAoGBAJRBNkulRXp7d0cVXcfCO9kSdBdDno96QRkd8luKOyqzyxVnTWPrWqrDwhTWxfxpFr3cNEUlBaFJRYx9Z3dkC5JiCzm+J8xYpW37fBGiTeI5bqcXp7flS6QuDOXKcO5UXMYNkumlFkxnYn+HU5wNDe9x2lr6xusBw5+UB5DBkGxlAkEA705itozBTjXKi3xad3Fp/7pwGbiv2ANb4V9KzzYIlXkGmffhbCquLrG3lOvBtQko8YbPm1UpoXwxMHSaHoCHSwJBANO+6EgPABcn89f2JMCSwjW2z05OWPtXLHJxIl9Cx+HXUr6X9UG/4C6WJVoRvqOhJjlnc/kKlZ7ghFkNaDxzc7cCQQCbNKKPNSEWYYrZBrEB8LvH0RpthDwABMWtmQlC9Q+CKjle2McKSXAo9rhTTMiYarV0WHQDkatrgcnBXI6so72bAkApbH6aojydSxacGC5Gci+GPJY/tnoX6YzrcpCL3E+oMeyhFq9HRpc/5eW2wiPudPc6Ya/Bd72fkEKz/Th4IwnvAkBjn/4+OQOqZwiUi9B+3WRwKbEtmOwjuiY56aBn94UDA9KaXGpm03L5NbuL/pWjuQQybK46O04saycqG2Fgkt9l";

        //支付宝的公钥，查看地址：https://b.alipay.com/order/pidAndKey.htm 
        //public static string alipay_public_key = "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCnxj/9qwVfgoUh/y2W89L6BkRAFljhNhgPdyPuBV64bfQNN1PjbCzkIM6qRdKBoLPXmKKMiFYnkd6rAoprih3/PrQEB/VsW8OoM8fxn67UDYuyBTqA23MML9q1+ilIZwBC2AQ2UBVOrFXfFl75p6/B5KsiNG9zpgmLCUYuLkxpLQIDAQAB";
        public static string alipay_public_key = "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCnxj/9qwVfgoUh/y2W89L6BkRAFljhNhgPdyPuBV64bfQNN1PjbCzkIM6qRdKBoLPXmKKMiFYnkd6rAoprih3/PrQEB/VsW8OoM8fxn67UDYuyBTqA23MML9q1+ilIZwBC2AQ2UBVOrFXfFl75p6/B5KsiNG9zpgmLCUYuLkxpLQIDAQAB";
		
        // 服务器异步通知页面路径，需http://格式的完整路径，不能加?id=123这类自定义参数,必须外网可以正常访问
        //public static string notify_url = "http://商户网关地址/alipay.wap.create.direct.pay.by.user-CSHARP-UTF-8/notify_url.aspx";
        public static string notify_url = "http://www.pinble.com/alipay/alipay_notify.aspx";

        // 页面跳转同步通知页面路径，需http://格式的完整路径，不能加?id=123这类自定义参数，必须外网可以正常访问
        //public static string return_url = "http://商户网关地址/alipay.wap.create.direct.pay.by.user-CSHARP-UTF-8/return_url.aspx";
        public static string return_url = "http://www.pinble.com/alipay/alipay_return.aspx";

        // 签名方式
        public static string sign_type = "RSA";

        // 调试用，创建TXT日志文件夹路径，见AlipayCore.cs类中的LogResult(string sWord)打印方法。
        //public static string log_path = HttpRuntime.AppDomainAppPath.ToString() + "log/";
        public static string log_path = System.Web.HttpContext.Current.Server.MapPath("\\ErrorReport\\");

        // 字符编码格式 目前支持utf-8
        public static string input_charset = "utf-8";

        // 支付类型 ，无需修改
        public static string payment_type = "1";

        // 调用的接口名，无需修改
        public static string service = "alipay.wap.create.direct.pay.by.user";

        //↑↑↑↑↑↑↑↑↑↑请在这里配置您的基本信息↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

    }
}