<%@ Register Src="../../Contorls/Head.ascx" TagName="Head" TagPrefix="uc3" %>
<%@ Register Src="../../Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc4" %>

<script language="C#" runat="server">
    /**
 * @Description: 快钱神州行支付网关接口范例
 * @Copyright (c) 上海快钱信息服务有限公司
 * @version 2.0
 */
    public string strOrderID = "";
    public string strOrderAmount = "";
    void Page_Load(Object sender, EventArgs E)
    {

        //神州行网关账户号
        ///请与快钱技术联系索取
        merchantAcctId.Value = ConfigurationManager.AppSettings["SZX_mid"];

        //设置神州行网关密钥
        ///区分大小写
        String key = ConfigurationManager.AppSettings["SZX_key"];


        //字符集.固定选择值。可为空。
        ///只能选择1、2、3、5
        ///1代表UTF-8; 2代表GBK; 3代表gb2312; 5 代表big5
        ///默认值为1
        inputCharset.Value = "1";

        //服务器接受支付结果的后台地址.与[pageUrl]不能同时为空。必须是绝对地址。
        ///快钱通过服务器连接的方式将交易结果发送到[bgUrl]对应的页面地址，在商户处理完成后输出的<result>如果为1，页面会转向到<redirecturl>对应的地址。
        ///如果快钱未接收到<redirecturl>对应的地址，快钱将把支付结果GET到[pageUrl]对应的页面。
        bgUrl.Value = Pbzx.Common.WebInit.webBaseConfig.WebUrl + "99bill/SZX/receive.aspx";

        //接受支付结果的页面地址.与[bgUrl]不能同时为空。必须是绝对地址。
        ///如果[bgUrl]为空，快钱将支付结果GET到[pageUrl]对应的地址。
        ///如果[bgUrl]不为空，并且[bgUrl]页面指定的<redirecturl>地址不为空，则转向到<redirecturl>对应的地址.
        pageUrl.Value = "";

        //网关版本.固定值
        ///快钱会根据版本号来调用对应的接口处理程序。
        ///本代码版本号固定为v2.0
        version.Value = "v2.0";

        //语言种类.固定选择值。
        ///只能选择1、2、3
        ///1代表中文；2代表英文
        ///默认值为1
        language.Value = "1";

        //签名类型.固定值
        ///1代表MD5签名
        ///当前版本固定为1
        signType.Value = "1";

        if (string.IsNullOrEmpty(Pbzx.Common.Input.FilterAll(Request["OrderID"])) || Request["OrderID"] == "")
        {
            Page.RegisterStartupScript(Pbzx.Web.WebFunc.GetGuid(), Pbzx.Common.JS.myAlert1("", "订单错误！", 400, "1", "history.go(-1);", "", false, false));
            return;
        }
        strOrderID = Pbzx.Common.Input.FilterAll(Request["OrderID"]);
        System.Data.DataTable dtOrder = Pbzx.Web.WebFunc.GetDsOrder(strOrderID);
        if (dtOrder == null)
        {
            Page.RegisterStartupScript(Pbzx.Web.WebFunc.GetGuid(), Pbzx.Common.JS.myAlert1("", "订单错误！", 400, "1", "history.go(-1);", "", false, false));
            return;
        }
        if (!Pbzx.Web.WebFunc.CheckOrderIsValidate(Request["OrderID"]))
        {
            Page.RegisterStartupScript(Pbzx.Web.WebFunc.GetGuid(), Pbzx.Common.JS.myAlert1("", "对不起！该订单已取消或者已失效！", 400, "1", "history.go(-1);", "", false, false));
            return;
        }


        string payName = "";
        string payContact = "";

        string strProductName = "";
        string strProductDesc = "";

        if (dtOrder.TableName == "PBnet_Orders" || dtOrder.TableName == "PBnet_Orders_Delegates")
        {
            payName = dtOrder.Rows[0]["ReceiverName"].ToString();
            payContact = dtOrder.Rows[0]["ReceiverEmail"].ToString();
            strOrderAmount = dtOrder.Rows[0]["HasNotPayedPrice"].ToString();

            Pbzx.BLL.PBnet_OrderDetail orderDetailBll = new Pbzx.BLL.PBnet_OrderDetail();
            System.Data.DataTable tbDetail = orderDetailBll.SelectOrderDetailByOrderID(strOrderID).Tables[0];
            //StringBuilder sbDetail = new StringBuilder("");
            //for (int i = 0; i < tbDetail.Rows.Count; i++)
            //{
            //    sbDetail.Append(i + "、" + tbDetail.Rows[i]["pb_SoftName"] + "；");
            //}
            if (dtOrder.TableName == "PBnet_Orders")
            {
                strProductName = "拼搏在线用户订单";
                strProductDesc = "拼搏在线用户订单订单号：" + strOrderID;
            }
            else
            {
                strProductName = "拼搏在线代理用户订单";
                strProductDesc = "拼搏在线代理用户订单，订单号：" + strOrderID;
            }
            //strProductName += Pbzx.Common.StrFormat.CutStringByNum(sbDetail, 100);
            //strProductDesc += Pbzx.Common.StrFormat.CutStringByNum(sbDetail, 300);
        }
        else if (dtOrder.TableName == "PBnet_Charge")
        {
            payName = dtOrder.Rows[0]["RealName"].ToString();
            payContact = "";
            strOrderAmount = dtOrder.Rows[0]["PayMoney"].ToString();
            strProductName = "拼搏在线用户充值订单，充值金额：" + Convert.ToDecimal(strOrderAmount).ToString("0.00") + "元";
            strProductDesc = "拼搏在线用户充值订单，订单号：" + strOrderID;
        }

        Pbzx.Common.ErrorLog.WriteLogMeng("在线交易", "快钱（神州行网关）订单开始，订单号：" + orderId.Value, true, true);

        //支付人姓名
        ///可为中文或英文字符
        payerName.Value = payName;

        //支付人联系方式类型.固定选择值
        ///只能选择1
        ///1代表Email
        payerContactType.Value = "1";

        //支付人联系方式
        ///只能选择Email或手机号
        payerContact.Value = payContact;

        //商户订单号
        ///由字母、数字、或[-][_]组成
        orderId.Value = strOrderID;

        //订单金额
        ///以分为单位，必须是整型数字
        ///比方2，代表0.02元
        orderAmount.Value = Convert.ToInt32(decimal.Parse(strOrderAmount) * 100).ToString();
        //支付方式.固定选择值
        ///可选择00、41、42、52
        ///00 代表快钱默认支付方式，目前为神州行卡密支付和快钱账户支付；41 代表快钱账户支付；42 代表神州行卡密支付和快钱账户支付；52 代表神州行卡密支付
        payType.Value = "00";

        //全额支付标志
        ///只能选择数字 0 或 1
        ///0 代表非全额支付方式，支付完成后返回订单金额为商户提交的订单金额。如果预付费卡面额小于订单金额时，返回支付结果为失败；预付费卡面额大于或等于订单金额时，返回支付结果为成功；
        ///1 代表全额支付方式，支付完成后返回订单金额为用户预付费卡的面额。只要预付费卡销卡成功，返回支上海快钱信息服务有限公司 版权所有 第 6 页付结果都为成功。
        fullAmountFlag.Value = "0";

        //订单提交时间
        ///14位数字。年[4位]月[2位]日[2位]时[2位]分[2位]秒[2位]
        ///如；20080101010101
        orderTime.Value = Convert.ToDateTime(dtOrder.Rows[0]["OrderDate"]).ToString("yyyyMMddHHmmss");

        //商品名称
        ///可为中文或英文字符
        productName.Value = strProductName;


        //商品数量
        ///可为空，非空时必须为数字
        productNum.Value = "1";

        //商品代码
        ///可为字符或者数字
        productId.Value = "";

        //商品描述
        productDesc.Value = strProductDesc;

        //扩展字段1
        ///在支付结束后原样返回给商户
        ext1.Value = "";

        //扩展字段2
        ///在支付结束后原样返回给商户
        ext2.Value = "";






        //对所有可能含有中文字符的参数进行编码
        payerName.Value = System.Web.HttpUtility.UrlEncode(payerName.Value, Encoding.GetEncoding("UTF-8")).ToUpper();
        productName.Value = System.Web.HttpUtility.UrlEncode(productName.Value, Encoding.GetEncoding("UTF-8")).ToUpper();
        productDesc.Value = System.Web.HttpUtility.UrlEncode(productDesc.Value, Encoding.GetEncoding("UTF-8")).ToUpper();
        ext1.Value = System.Web.HttpUtility.UrlEncode(ext1.Value, Encoding.GetEncoding("UTF-8")).ToUpper();
        ext2.Value = System.Web.HttpUtility.UrlEncode(ext2.Value, Encoding.GetEncoding("UTF-8")).ToUpper();



        //生成加密签名串
        ///请务必按照如下顺序和规则组成加密串！
        String signMsgVal = "";
        signMsgVal = appendParam(signMsgVal, "inputCharset", inputCharset.Value);
        signMsgVal = appendParam(signMsgVal, "bgUrl", bgUrl.Value);
        signMsgVal = appendParam(signMsgVal, "pageUrl", pageUrl.Value);
        signMsgVal = appendParam(signMsgVal, "version", version.Value);
        signMsgVal = appendParam(signMsgVal, "language", language.Value);
        signMsgVal = appendParam(signMsgVal, "signType", signType.Value);
        signMsgVal = appendParam(signMsgVal, "merchantAcctId", merchantAcctId.Value);
        signMsgVal = appendParam(signMsgVal, "payerName", payerName.Value);
        signMsgVal = appendParam(signMsgVal, "payerContactType", payerContactType.Value);
        signMsgVal = appendParam(signMsgVal, "payerContact", payerContact.Value);
        signMsgVal = appendParam(signMsgVal, "orderId", orderId.Value);
        signMsgVal = appendParam(signMsgVal, "orderAmount", orderAmount.Value);
        signMsgVal = appendParam(signMsgVal, "payType", payType.Value);
        signMsgVal = appendParam(signMsgVal, "fullAmountFlag", fullAmountFlag.Value);
        signMsgVal = appendParam(signMsgVal, "orderTime", orderTime.Value);
        signMsgVal = appendParam(signMsgVal, "productName", productName.Value);
        signMsgVal = appendParam(signMsgVal, "productNum", productNum.Value);
        signMsgVal = appendParam(signMsgVal, "productId", productId.Value);
        signMsgVal = appendParam(signMsgVal, "productDesc", productDesc.Value);
        signMsgVal = appendParam(signMsgVal, "ext1", ext1.Value);
        signMsgVal = appendParam(signMsgVal, "ext2", ext2.Value);
        signMsgVal = appendParam(signMsgVal, "key", key);

        signMsg.Value = GetMD5(signMsgVal, "utf-8").ToUpper();


    }

    //功能函数。将变量值不为空的参数组成字符串
    String appendParam(String returnStr, String paramId, String paramValue)
    {
        if (returnStr != "")
        {

            if (paramValue != "")
            {

                returnStr += "&" + paramId + "=" + paramValue;
            }

        }
        else
        {

            if (paramValue != "")
            {
                returnStr = paramId + "=" + paramValue;
            }
        }

        return returnStr;
    }
    //功能函数。将变量值不为空的参数组成字符串。结束



    //功能函数。将字符串进行编码格式转换，并进行MD5加密，然后返回。开始
    private static string GetMD5(string dataStr, string codeType)
    {
        System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] t = md5.ComputeHash(System.Text.Encoding.GetEncoding(codeType).GetBytes(dataStr));
        System.Text.StringBuilder sb = new System.Text.StringBuilder(32);
        for (int i = 0; i < t.Length; i++)
        {
            sb.Append(t[i].ToString("x").PadLeft(2, '0'));
        }
        return sb.ToString();
    }
    //功能函数。将字符串进行编码格式转换，并进行MD5加密，然后返回。结束
</script>

<!doctype html public "-//w3c//dtd html 4.0 transitional//en" >
<html>
<head>
    <title>使用快钱支付 - 拼搏在线彩神通软件</title>
    <meta http-equiv="content-type" content="text/html; charset=gb2312" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/demos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <uc3:Head ID="Head1" runat="server" />
    <table width="990" border="0" align="center" cellpadding="0" cellspacing="0" class="MT">
        <tr>
            <td colspan="3">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="12%">
                            <img src="/Images/Web/order_bg1a.jpg" width="120" height="44" border="0" /></td>
                        <td width="87%" align="right" background="/Images/Web/order_bg1b.jpg" class="order_red">
                            请认真审核您的信息</td>
                        <td width="1%">
                            <img src="/Images/Web/order_bg1c.jpg" width="10" height="44" border="0" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="10" background="/Images/Web/order_bg2a.jpg">
                &nbsp;</td>
            <td width="970" align="center" bgcolor="#FFFFFF">
                <br />
                <table width="90%" border="0" cellpadding="8" cellspacing="0">
                    <tr>
                        <td class="order_14black" align="center">
                            您的订单<span class="order_14red"><%=strOrderID%></span> 已经提交，您需要支付：<span class="order_14red"><%=decimal.Parse(strOrderAmount).ToString("0.00")%>元</span></td>
                    </tr>
                    <tr>
                        <td class="order_14black" align="center">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="40%" border="0" align="center" cellpadding="2" cellspacing="0">
                                <tr>
                                    <td>
                                        <img src="/images/web/kuaiqian.jpg" width="111" height="44" alt="" border="0" /></td>
                                    <td align="left">
                                        <table width="90%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td height="0">
                                                </td>
                                            </tr>
                                        </table>
                                        <!-- <input type="submit" name="submit" value="付款" id="Submit1" class="order_wangyinbtn" onclick="return Submit1_onclick()" />  -->
                                        <form name="kqPay" method="post" action="https://www.99bill.com/szxgateway/recvMerchantInfoAction.htm">
                                            <input type="hidden" id="inputCharset" name="inputCharset" runat="server" />
                                            <input type="hidden" id="bgUrl" name="bgUrl" runat="server" />
                                            <input type="hidden" id="pageUrl" name="pageUrl" runat="server" />
                                            <input type="hidden" id="version" name="version" runat="server" />
                                            <input type="hidden" id="language" name="language" runat="server" />
                                            <input type="hidden" id="signType" name="signType" runat="server" />
                                            <input type="hidden" id="merchantAcctId" name="merchantAcctId" runat="server" />
                                            <input type="hidden" id="payerName" name="payerName" runat="server" />
                                            <input type="hidden" id="payerContactType" name="payerContactType" runat="server" />
                                            <input type="hidden" id="payerContact" name="payerContact" runat="server" />
                                            <input type="hidden" id="orderId" name="orderId" runat="server" />
                                            <input type="hidden" id="orderAmount" name="orderAmount" runat="server" />
                                            <input type="hidden" id="payType" name="payType" runat="server" />
                                            <input type="hidden" id="fullAmountFlag" name="fullAmountFlag" runat="server" />
                                            <input type="hidden" id="orderTime" name="orderTime" runat="server" />
                                            <input type="hidden" id="productName" name="productName" runat="server" />
                                            <input type="hidden" id="productNum" name="productNum" runat="server" />
                                            <input type="hidden" id="productId" name="productId" runat="server" />
                                            <input type="hidden" id="productDesc" name="productDesc" runat="server" />
                                            <input type="hidden" id="ext1" name="ext1" runat="server" />
                                            <input type="hidden" id="ext2" name="ext2" runat="server" />
                                            <input type="hidden" id="signMsg" name="signMsg" runat="server" />
                                            <input type="submit" id="submit" class="order_kuaiqian" value="" /></form>
                                    </td>
                                </tr>
                            </table>
                            <table width="90%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td height="6">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table width="90%" border="0" cellspacing="0" cellpadding="2">
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
            <td width="10" background="/Images/Web/order_bg2c.jpg">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <img src="/Images/Web/order_bg3a.jpg" width="10" height="10" border="0" /></td>
            <td background="/Images/Web/order_bg3b.jpg">
            </td>
            <td>
                <img src="/Images/Web/order_bg3c.jpg" width="10" height="10" border="0" /></td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
            </td>
        </tr>
    </table>
    <uc4:Footer ID="Footer1" runat="server" />
</body>
</html>
