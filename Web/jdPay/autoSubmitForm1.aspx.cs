using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace jdPay
{
    public partial class autoSubmitForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PayStartForm1 pf = Context.Handler as PayStartForm1;
            this.batchForm.Action = pf.payUrl;
            this.version.Value = pf.orderInfo.getVaule("version");
            this.merchant.Value = pf.orderInfo.getVaule("merchant");
            this.device.Value = pf.orderInfo.getVaule("device");
            this.tradeNum.Value = pf.orderInfo.getVaule("tradeNum");
            this.tradeName.Value = pf.orderInfo.getVaule("tradeName");
            this.tradeDesc.Value = pf.orderInfo.getVaule("tradeDesc");
            this.tradeTime.Value = pf.orderInfo.getVaule("tradeTime");
            this.amount.Value = pf.orderInfo.getVaule("amount");
            this.currency.Value = pf.orderInfo.getVaule("currency");
            this.note.Value = pf.orderInfo.getVaule("note");
            this.callbackUrl.Value = pf.orderInfo.getVaule("callbackUrl");
            this.notifyUrl.Value = pf.orderInfo.getVaule("notifyUrl");
            this.ip.Value = pf.orderInfo.getVaule("ip");
            this.userType.Value = pf.orderInfo.getVaule("userType");
            this.userId.Value = pf.orderInfo.getVaule("userId");
            this.expireTime.Value = pf.orderInfo.getVaule("expireTime");
            this.orderType.Value = pf.orderInfo.getVaule("orderType");
            this.industryCategoryCode.Value = pf.orderInfo.getVaule("industryCategoryCode");
            this.specCardNo.Value = pf.orderInfo.getVaule("specCardNo");
            this.specId.Value = pf.orderInfo.getVaule("specId");
            this.specName.Value = pf.orderInfo.getVaule("specName");
            this.sign.Value = pf.orderInfo.getVaule("sign");
        }
    }
}