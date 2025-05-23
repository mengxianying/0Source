using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pbzx.Web;

namespace jdPay
{
    public partial class SuccessPageForm1 : System.Web.UI.Page
    {
        protected string v_oid;		// 订单号
        protected string tradeTimeStr;
        protected string v_amountStr;
        protected string statusStr;
        protected string orderDetailUrl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SuccessForm1 sf = Context.Handler as SuccessForm1;
                string tradeNum = sf.tradeResultRes.getVaule("tradeNum");
                v_oid = tradeNum.Split(new char[] { '_' })[1];
                tradeTimeStr = sf.tradeResultRes.getVaule("tradeTime");
                v_amountStr = Math.Round(Convert.ToDecimal(sf.tradeResultRes.getVaule("amount")), 2)/100 + "";
                orderDetailUrl = WebFunc.GetReturnUrl(v_oid);
                statusStr = sf.tradeResultRes.getVaule("status");

            }
            catch (Exception ex)
            {
                Pbzx.Common.ErrorLog.WriteLogMeng("京东在线交易", "京东支付同步成功页面PageForm==-----" + ex.Message+"|", true, true);
            }

            //this.status.InnerHtml = sf.tradeResultRes.getVaule("status")+"成功";
        }
    }
}