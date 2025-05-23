<%@ Register Src="../../Contorls/Head.ascx" TagName="Head" TagPrefix="uc1" %>
<%@ Register Src="../../Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>

<script language="C#" runat="server">
    /**
 * @Description: 快钱人民币支付网关接口范例
 * @Copyright (c) 上海快钱信息服务有限公司
 * @version 2.0
 */

    /*
    在本文件中，商家应从数据库中，查询到订单的状态信息以及订单的处理结果。给出支付人响应的提示。

    本范例采用最简单的模式，直接从receive页面获取支付状态提示给用户。
    '*/
    protected string msgResult = "";
    protected string orderDetailsUrl = "#";
    public string orderId = "";
    void Page_Load(Object sender, EventArgs E)
    {
        msgResult = Request["msg"];
        //以下输出订单提示
        if (string.IsNullOrEmpty(Request["orderId"]))
        {
            Response.Write("支付信息有误！");
            Response.End();
            return;
        }
        orderId = Pbzx.Common.Input.FilterAll(Request["orderId"].ToString().Trim());
        System.Data.DataTable dtOrder = Pbzx.Web.WebFunc.GetDsOrder(orderId);
        if (dtOrder == null)
        {
            Lab_msg.Text = "支付失败[订单错误]";
            return;
        }
        else if (msgResult != "success")
        {
            Lab_msg.Text = "支付失败（订单支付金额有误或者该订单已经支付完成）";
            return;
        }
        string orderAmount = "";
        string orderDate = "";
        if (dtOrder.TableName == "PBnet_Orders" || dtOrder.TableName == "PBnet_Orders_Delegates")
        {
            orderAmount = dtOrder.Rows[0]["HasPayedPrice"].ToString();
        }
        else if (dtOrder.TableName == "PBnet_Charge")
        {
            orderAmount = decimal.Parse(dtOrder.Rows[0]["HasPayedPrice"].ToString());
        }
        orderDate = dtOrder.Rows[0]["OrderDate"].ToString();
        Lab_orderId.Text = orderId;
        Lab_orderAmount.Text = orderAmount;
        Lab_orderDate.Text = orderDate;
        Lab_msg.Text = "支付成功！";
        orderDetailsUrl = Pbzx.Web.WebFunc.GetReturnUrl(orderId);

    }
</script>

<!doctype html public "-//w3c//dtd html 4.0 transitional//en" >
<html>
<head>
    <title>快钱神州行网关支付结果 - 拼搏在线彩神通软件</title>
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
    <meta content="C#" name="CODE_LANGUAGE" />
    <meta content="JavaScript" name="vs_defaultClientScript" />
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
    <style type="text/css">
			BODY { FONT-SIZE: 9pt }
			INPUT { FONT-SIZE: 9pt }
			TD { FONT-SIZE: 9pt }
		</style>
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/demos.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/demos.css" rel="stylesheet" type="text/css" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div align="center">
        <uc1:Head ID="Head1" runat="server" />
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
                    <table width="85%" border="0" cellpadding="4" cellspacing="1" bgcolor="#C9CCD3">
                        <tr>
                            <td bgcolor="#F4FBFF">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="12%">
                                            <img src="/Images/Web/buy_okli.gif" border="0" /></td>
                                        <td width="88%" align="left">
                                            <span class="buy_oktitle">
                                                <asp:Label ID="payMsg" ForeColor="#E10900" runat="server">支付结果</asp:Label></span></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table width="85%" border="0" cellspacing="0" cellpadding="4">
                        <%
                            if (msgResult == "success")
                            {
                        %>
                        <tr>
                            <td width="12%" align="right" class="order_xia buy_okbiao">
                                订&nbsp;单&nbsp;号：</td>
                            <td width="37%" align="left" class="order_xia buy_okshuo">
                                <asp:Label ID="Lab_orderId" runat="Server" />
                            </td>
                            <td width="12%" align="right" class="order_xia buy_okbiao">
                                支付时间：</td>
                            <td width="39%" align="left" class="order_xia buy_okshuo">
                                <font color="#000080">
                                    <asp:Label ID="Lab_orderDate" runat="Server" />
                                </font>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="order_xia buy_okbiao">
                                支付方式：</td>
                            <td align="left" class="order_xia buy_okshuo">
                                <font color="#000080">快钱[99bill] </font>
                            </td>
                            <td align="right" class="order_xia buy_okbiao">
                                支付金额：</td>
                            <td align="left" class="order_xia buy_okshuo">
                                <font color="#000080">
                                    <asp:Label ID="Lab_orderAmount" runat="Server" />
                                    元</font></td>
                        </tr>
                        <tr>
                            <td align="right" class="order_xia buy_okbiao">
                                支付结果：</td>
                            <td align="left" class="order_xia buy_okshuo" colspan="3">
                                     <font color="#e10900"><asp:Label ID="Lab_msg" runat="Server" /></font>
                            </td>
                        </tr>
                       
                        <%
                            }
                        %>
                    </table>
                    <table width="85%" border="0" cellspacing="0" cellpadding="2">
                        <tr>
                            <td align="left">
                                <b>注：</b>在支付完1-3分钟后，我们将收到您的支付信息，并自动完成相应的操作；<br/>
                                  <%
                                    string strOrderType = Pbzx.Web.WebFunc.GetOrderType(orderId);
                                    if (strOrderType == "0")
                                    {
                                    %>          
                                    &nbsp; &nbsp; 请到用户中心，在“我的订单”中找到您刚刚支付完成的订单，然后点击订单号，查看注册信息。
                                  <%}
                                    else if (strOrderType =="2")
                                    {%>
                                    &nbsp; &nbsp; 请到用户中心查看您的帐户余额；或点击“我的帐户”，在“充值/取款”中找到您刚刚支付完成的订单，然后点击订单号，查看详细信息。                                    
                                  <%}
                                %>
                                </td>
                        </tr>
                    </table>
                    <table width="85%" border="0" cellspacing="0" cellpadding="2">
                        <tr>
                            <td align="center">
                               <a href="<%=orderDetailsUrl %>">
                                    <img src="/Images/Web/see_register.jpg"   border="0" /></a></td>
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
    </div>
    <uc2:Footer ID="Footer1" runat="server" />
</body>
</html>
