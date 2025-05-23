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
using Pbzx.Common;
using System.Globalization;
using Pbzx.Web;

public partial class Send : System.Web.UI.Page
{
    //必要的交易信息
    protected string v_amount;       // 订单金额
    protected string v_moneytype;    // 币种
    protected string v_md5info;      // 对拼凑串MD5私钥加密后的值
    protected string v_mid;		 // 商户号
    protected string v_url;		 // 返回页地址
    protected string v_oid;		 // 推荐订单号构成格式为 年月日-商户号-小时分钟秒

    //收货信息
    protected string v_rcvname;      // 收货人
    protected string v_rcvaddr;      // 收货地址
    protected string v_rcvtel;       // 收货人电话
    protected string v_rcvpost;      // 收货人邮编
    protected string v_rcvemail;     // 收货人邮件
    protected string v_rcvmobile;    // 收货人手机号

    //订货人信息
    protected string v_ordername;    // 订货人姓名
    protected string v_orderaddr;    // 订货人地址
    protected string v_ordertel;     // 订货人电话
    protected string v_orderpost;    // 订货人邮编
    protected string v_orderemail;   // 订货人邮件
    protected string v_ordermobile;  // 订货人手机号
    protected string pmode_id;
    //两个备注
    protected string remark1;
    protected string remark2;

    protected void Page_Load(object sender, EventArgs e)
    {
        #region
        ViewState["Type"] = "0";
        if (!string.IsNullOrEmpty(Request["type"]))
        {
            if (Request["type"] == "1")
            {
                ViewState["Type"] = "1";
            }
        }
        LoginSort login = new LoginSort();
        if (!login["manager_user"])
        {
            Response.Redirect("/login.aspx");
            return;
        }
        #endregion
        v_mid = ConfigurationManager.AppSettings["c_mid"].ToString();// 商户号，这里为测试商户号1001，替换为自己的商户号即可
        v_url = WebInit.webBaseConfig.WebUrl + "chinabank/Receive.aspx"; // 商户自定义返回接收支付结果的页面
        // MD5密钥要跟订单提交页相同，如Send.asp里的 key = "test" ,修改""号内 test 为您的密钥
        string key = ConfigurationManager.AppSettings["c_pass"].ToString(); 			 // 如果您还没有设置MD5密钥请登陆我们为您提供商户后台，地址：https://merchant3.chinabank.com.cn/
        // 登陆后在上面的导航栏里可能找到“B2C”，在二级导航栏里有“MD5密钥设置”
        // 建议您设置一个16位以上的密钥或更高，密钥最多64位，但设置16位已经足够了

        //Pbzx.Common.ErrorLog.WriteLogMeng("\r\n网银在线验证订单，此订单为。");

        if (string.IsNullOrEmpty(Request["OrderID"]) || Request["OrderID"] == "")
        {
            Page.RegisterStartupScript(Pbzx.Web.WebFunc.GetGuid(), Pbzx.Common.JS.myAlert1("", "对不起！订单错误！", 400, "1", "history.go(-1);", "", false, false));

            return;
        }
        else
        {
            if (!WebFunc.CheckOrderIsValidate(Request["OrderID"]))
            {
                Page.RegisterStartupScript(Pbzx.Web.WebFunc.GetGuid(), Pbzx.Common.JS.myAlert1("", "对不起！该订单已取消或者已失效！", 400, "1", "history.go(-1);", "", false, false));
                return;
            }
            DataTable dtOrders = WebFunc.GetDsOrder(Request["OrderID"]);
            if (dtOrders == null)
            {
                Page.RegisterStartupScript(Pbzx.Web.WebFunc.GetGuid(), Pbzx.Common.JS.myAlert1("", "对不起！订单错误！", 400, "1", "history.go(-1);", "", false, false));
                return;
            }
//            Pbzx.Common.ErrorLog.WriteLogMeng("在线交易", "网银在线订单开始，订单号：" + Request["OrderID"], true, true);

            decimal payJE = 0;
            if (dtOrders.TableName == "PBnet_Orders" || dtOrders.TableName == "PBnet_Orders_Delegates")
            {
                payJE = Convert.ToDecimal(dtOrders.Rows[0]["HasNotPayedPrice"]);
            }
            else if (dtOrders.TableName == "PBnet_Charge")
            {
                payJE = Convert.ToDecimal(dtOrders.Rows[0]["PayMoney"]) - Convert.ToDecimal(dtOrders.Rows[0]["HasPayedPrice"]);
            }
            v_amount = string.Format("{0:f}", Convert.ToDecimal(payJE));
            v_moneytype = "CNY";
            v_oid = Input.FilterAll(Request["OrderID"]);
            string text = v_amount + v_moneytype + v_oid + v_mid + v_url + key; // 拼凑加密串
            v_md5info = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(text, "md5").ToUpper();
        }
    }
}
