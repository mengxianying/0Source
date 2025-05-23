using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace qcloudsms
{
    public class SmsSingleSender : SmsBase
    {
        private string url = "https://yun.tim.qq.com/v5/tlssmssvr/sendsms";

        public SmsSingleSender(int appid, string appkey) : base(new DefaultHTTPClient())
        { 
        
        }

        public SmsSingleSender(int appid, string appkey, IHTTPClient httpclient)
            : base(httpclient)
        { }

        /// <summary>
        /// Send single SMS message with template paramters.
        /// </summary>
        /// <param name="nationCode">nation dialing code, e.g. China is 86, USA is 1</param>
        /// <param name="phoneNumber">phone number</param>
        /// <param name="templateId">template id</param>
        /// <param name="parameters">template parameters</param>
        /// <param name="sign">Sms user sign</param>
        /// <param name="extend">extend field, default is empty string</param>
        /// <param name="ext">ext field, content will be returned by server as it is</param>
        /// <returns>SmsSingleSenderResult</returns>
        public SmsSingleSenderResult sendWithParam(string nationCode, string phoneNumber, int templateId,
            string[] parameters, string sign, string extend, string ext)
        {

            long random = SmsSenderUtil.getRandom();
            long now = SmsSenderUtil.getCurrentTime();

            JSONObjectBuilder body = new JSONObjectBuilder()
                .Put("tel", (new JSONObjectBuilder()).Put("nationcode", nationCode).Put("mobile", phoneNumber).Build())
                .Put("sig", SmsSenderUtil.calculateSignature(appkey, random, now, phoneNumber))
                .Put("tpl_id", templateId)
                .PutArray("params", parameters)
                .Put("sign", !String.IsNullOrEmpty(sign) ? sign : "")
                .Put("time", now)
                .Put("extend", !String.IsNullOrEmpty(extend) ? extend : "")
                .Put("ext", !String.IsNullOrEmpty(ext) ? ext : "");

            HTTPRequest req = new HTTPRequest(HTTPMethod.POST, this.url)
                .addHeader("Conetent-Type", "application/json")
                .addQueryParameter("sdkappid", this.appid)
                .addQueryParameter("random", random)
                .setConnectionTimeout(60 * 1000)
                .setRequestTimeout(60 * 1000)
                .setBody(body.Build().ToString());

            // May throw HttpRequestException
            HTTPResponse res = httpclient.fetch(req);

            // May throw HTTPException
            handleError(res);

            SmsSingleSenderResult result = new SmsSingleSenderResult();
            // May throw JSONException
            result.parseFromHTTPResponse(res);

            return result;
        }
    }
}
