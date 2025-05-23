using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// config 的摘要说明
/// </summary>
public class config
{
    public config()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    // 应用ID,您的APPID
    public static string app_id = "2088002305122788";

    // 支付宝网关
    public static string gatewayUrl = "https://openapi.alipay.com/gateway.do";

    // 商户私钥，您的原始格式RSA私钥
    public static string private_key = "MIICXQIBAAKBgQDF8BCsHwarQz0cFl4OrPy0oDfKgta6KBut3ZZQ3tRhJNWEjA3OTYBaRyE1XzVU94gApCUTrw2hBmHw1s3+zEZyLe5Ji/Wp1fuR/aLDt7QXIrq/p9sOrASZM8haPIKHcvxazC7vf6bRa487pXzNR5iDJD5mfF4mbDMOjy7J5VhnnQIDAQABAoGBAJRBNkulRXp7d0cVXcfCO9kSdBdDno96QRkd8luKOyqzyxVnTWPrWqrDwhTWxfxpFr3cNEUlBaFJRYx9Z3dkC5JiCzm+J8xYpW37fBGiTeI5bqcXp7flS6QuDOXKcO5UXMYNkumlFkxnYn+HU5wNDe9x2lr6xusBw5+UB5DBkGxlAkEA705itozBTjXKi3xad3Fp/7pwGbiv2ANb4V9KzzYIlXkGmffhbCquLrG3lOvBtQko8YbPm1UpoXwxMHSaHoCHSwJBANO+6EgPABcn89f2JMCSwjW2z05OWPtXLHJxIl9Cx+HXUr6X9UG/4C6WJVoRvqOhJjlnc/kKlZ7ghFkNaDxzc7cCQQCbNKKPNSEWYYrZBrEB8LvH0RpthDwABMWtmQlC9Q+CKjle2McKSXAo9rhTTMiYarV0WHQDkatrgcnBXI6so72bAkApbH6aojydSxacGC5Gci+GPJY/tnoX6YzrcpCL3E+oMeyhFq9HRpc/5eW2wiPudPc6Ya/Bd72fkEKz/Th4IwnvAkBjn/4+OQOqZwiUi9B+3WRwKbEtmOwjuiY56aBn94UDA9KaXGpm03L5NbuL/pWjuQQybK46O04saycqG2Fgkt9l";

    // 支付宝公钥,查看地址：https://openhome.alipay.com/platform/keyManage.htm 对应APPID下的支付宝公钥。
    public static string alipay_public_key = "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCnxj/9qwVfgoUh/y2W89L6BkRAFljhNhgPdyPuBV64bfQNN1PjbCzkIM6qRdKBoLPXmKKMiFYnkd6rAoprih3/PrQEB/VsW8OoM8fxn67UDYuyBTqA23MML9q1+ilIZwBC2AQ2UBVOrFXfFl75p6/B5KsiNG9zpgmLCUYuLkxpLQIDAQAB";

    // 签名方式
//    public static string sign_type = "RSA2";
    public static string sign_type = "RSA";

    // 编码格式
    public static string charset = "UTF-8";
}