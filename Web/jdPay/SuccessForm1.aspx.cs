using jdPay.PropertyUtil;
using jdPay.signature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pbzx.Common;

namespace jdPay
{
    public partial class SuccessForm1 : System.Web.UI.Page
    {
        private SortedDictionary<String, String> resDic = new SortedDictionary<string, string>();
        public String errorMsg
        {
            get { return "验证签名失败"; }
        }
        public SortedDictionary<String, String> tradeResultRes
        {
            get { return resDic; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Pbzx.Common.ErrorLog.WriteLogMeng("京东在线交易", "京东支付接收页面回调开始-----", true, true);

            System.Diagnostics.Debug.WriteLine("接收页面回调请求开始--------------------------------------");
            
            String desKey = PropertyUtils.getProperty("wepay.merchant.desKey");
            byte[] key = Convert.FromBase64String(desKey);
            String tradeNum = Request.Params["tradeNum"];
//            Pbzx.Common.ErrorLog.WriteLogMeng("京东在线交易", "tradeNum=" + tradeNum, true, true);
            resDic.AddOrPeplace("tradeNum", Des3.Des3DecryptECB(key, tradeNum));
            String tradeAmount = Request.Params["amount"];
//            Pbzx.Common.ErrorLog.WriteLogMeng("京东在线交易", "tradeAmount=" + tradeAmount, true, true);
            resDic.AddOrPeplace("amount", Des3.Des3DecryptECB(key, tradeAmount));
            String tradeCurrency = Request.Params["currency"];
//            Pbzx.Common.ErrorLog.WriteLogMeng("京东在线交易", "tradeCurrency=" + tradeCurrency, true, true);
            resDic.AddOrPeplace("currency", Des3.Des3DecryptECB(key, tradeCurrency));
            String tradeDate = Request.Params["tradeTime"];
//            Pbzx.Common.ErrorLog.WriteLogMeng("京东在线交易", "tradeDate=" + tradeDate, true, true);
            resDic.AddOrPeplace("tradeTime", Des3.Des3DecryptECB(key, tradeDate));
            String tradeNote = Request.Params["note"];
//            Pbzx.Common.ErrorLog.WriteLogMeng("京东在线交易", "tradeNote=" + tradeNote, true, true);
            resDic.AddOrPeplace("note", Des3.Des3DecryptECB(key, tradeNote));
            String tradeStatus = Request.Params["status"];
//            Pbzx.Common.ErrorLog.WriteLogMeng("京东在线交易", "tradeStatus=" + tradeStatus, true, true);
            resDic.AddOrPeplace("status", Des3.Des3DecryptECB(key, tradeStatus));

            String sign = Request.Params["sign"];
            System.Diagnostics.Debug.WriteLine("sign:" + sign);
//            Pbzx.Common.ErrorLog.WriteLogMeng("京东在线交易", "京东支付同步接收页面回调sign-----"+sign, true, true);

            String strSourceData = SignUtil.signString(resDic, new List<String>());
            System.Diagnostics.Debug.WriteLine("strSourceData:" + strSourceData);

//            Pbzx.Common.ErrorLog.WriteLogMeng("京东在线交易", "京东支付同步接收页面回调strSourceData-----" + strSourceData, true, true);

            String wyPubKey = PropertyUtils.getProperty("wepay.jd.rsaPublicKey");
            byte[] decryptArr = RSACoder.decryptByPublicKey(sign, wyPubKey);
            String decrypStr = Encoding.UTF8.GetString(decryptArr);
            String sha256SourceSignString = SHAUtil.encryptSHA256(strSourceData);
            System.Diagnostics.Debug.WriteLine("sha256SourceSignString:" + sha256SourceSignString);
            System.Diagnostics.Debug.WriteLine("decrypStr:"+decrypStr);

//            Pbzx.Common.ErrorLog.WriteLogMeng("京东在线交易", "京东支付同步接收页面回调sha256SourceSignString-----" + sha256SourceSignString, true, true);

//            Pbzx.Common.ErrorLog.WriteLogMeng("京东在线交易", "京东支付同步接收页面回调decrypStr-----" + decrypStr, true, true);

            //服务器通知url（Alipay_Notify.aspx文件所在路经），必须是完整的路径地址
            string fail_url = WebInit.webBaseConfig.WebUrl + "jdPay/FailForm1.aspx"; //服务器通知返回接口
            //服务器返回url（Alipay_Return.aspx文件所在路经），必须是完整的路径地址
            string success_url = WebInit.webBaseConfig.WebUrl + "jdPay/SuccessPageForm1.aspx"; //重定下地址

            try
            {
                if (!decrypStr.Equals(sha256SourceSignString))
                {
                    Pbzx.Common.ErrorLog.WriteLogMeng("京东在线交易", "京东支付同步接收页面验签失败。。", true, true);
                    System.Diagnostics.Debug.WriteLine("验签失败");
                    Server.Transfer("~/jdPay/FailForm1.aspx");
                }
                else
                {
                    Pbzx.Common.ErrorLog.WriteLogMeng("京东在线交易", "京东支付同步接收页面验签成功。。", true, true);
                    System.Diagnostics.Debug.WriteLine("验签成功");
                   
                }

            }
            catch (Exception ex)
            {
                Pbzx.Common.ErrorLog.WriteLogMeng("京东在线交易", "" + ex.Message, true, true);
            }
            finally
            {
                Server.Transfer("~/jdPay/SuccessPageForm1.aspx", false);
            }

        }
    }
}