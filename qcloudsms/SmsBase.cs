using System;


namespace qcloudsms
{
    public class SmsBase
    {
        protected int appid = 1400530114;
        protected string appkey = "078725ce170a46ec1f9c5e9e32365acf";
        protected IHTTPClient httpclient { get; set; }

        public SmsBase(IHTTPClient httpclient)
        {
            this.httpclient = httpclient;
        }

        /**
         * Handle http status error
         *
         * @param response   raw http response
         * @return response  raw http response
         * @throws HTTPException  http status exception
         */
        public HTTPResponse handleError(HTTPResponse response)
        {
            if (response.statusCode < 200 || response.statusCode >= 300)
            {
                throw new HTTPException(response.statusCode, response.reason);
            }
            return response;
        }
    }
}