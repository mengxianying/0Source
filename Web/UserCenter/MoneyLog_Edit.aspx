<%@ Page Language="C#" AutoEventWireup="true" Codebehind="MoneyLog_Edit.aspx.cs"
    Inherits="Pbzx.Web.UserCenter.MoneyLog_Edit" %>

<%@ Register Src="../Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc3" %>
<%@ Register Src="../Contorls/OrderDetail2.ascx" TagName="OrderDetail2" TagPrefix="uc2" %>
<%@ Register Src="../Contorls/OrderDetail.ascx" TagName="OrderDetail" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <script src="/javascript/calendar.js" type="text/javascript"></script>

    <title>查看订单_拼搏在线彩神通软件</title>
    <link href="/css/user_center.css" rel="stylesheet" type="text/css" />
    <link type="text/css" href="/css/start/jquery-ui-1.7.2.custom.css" rel="stylesheet" />

    <script type="text/javascript" src="/javascript/jquery-1.3.2.js"></script>

    <script type="text/javascript" src="/javascript/jquery.blockUI.js"></script>

    <script type="text/javascript" src="/javascript/jquery-ui-1.7.2.custom.min.js"></script>

    <script type="text/javascript" src="/javascript/Header.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="dialog1" title="拼搏在线彩神通软件网站提醒" style="display: none;">
                <p>
                    提醒内容</p>
            </div>
            <div id="dialog2" title="拼搏在线彩神通软件网站提醒" style="display: none;">
                <p>
                    提醒内容</p>
            </div>
            <table width="920" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="228">
                        <table width="158px" height="72px" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="158" height="72" align="center">
                                    <a href='http://www.pinble.com/'><img border='0' src='/Images/Web/PinbleLogo.gif'  width='158' height='72'></a>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td width="692" height="70">
                        <table width="20%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td height="6" colspan="2">
                                </td>
                            </tr>
                            <tr>
                                <td width="20%">
                                    &nbsp;</td>
                                <td width="80%" class="mshu_menushangGo2" id="step1" runat="server">
                                    我的交易
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table width="920" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td height="25" valign="top" bgcolor="#AACDED">
                        <img src="/Images/Web/orderz_topbg1.gif" width="920" height="8" /></td>
                </tr>
                <tr>
                    <td background="/Images/Web/orderz_topbg2.gif">
                        <table width="95%" border="0" align="center" cellpadding="2" cellspacing="0">
                            <tr>
                                <td height="36" valign="bottom" class="mshu_borderxia" align="left">
                                    &nbsp;&nbsp;<span class="mshu_font16black">订单编号：<span class="mshu_font16red">
                                        <asp:Label ID="lblOrderID" runat="server"></asp:Label></span><span class="mshu_font16red"></span>
                                        （<asp:Label ID="lblState" runat="server"></asp:Label>）</span><asp:Label ID="lblOrderDate"
                                            runat="server"></asp:Label></td>
                            </tr>
                        </table>
                        <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="mshu_borderxia">
                                    <table width="96%" border="0" align="center" cellpadding="3" cellspacing="0">
                                        <tr>
                                            <td colspan="4" class="mshu_font14black" height="30" valign="bottom" align="left">
                                                基本信息</td>
                                        </tr>
                                        <tr>
                                            <td width="10%" align="right">
                                                真实姓名：</td>
                                            <td width="29%" align="left">
                                                <asp:Label ID="lblRealName" runat="server"></asp:Label></td>
                                            <td width="8%" align="right">
                                                付款方式：</td>
                                            <td width="53%" align="left">
                                                <asp:Label ID="lblPayTypeName" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                交易类型：</td>
                                            <td align="left">
                                                <asp:Label ID="lblType" runat="server"></asp:Label></td>
                                            <td align="right">
                                                付款金额：</td>
                                            <td align="left">
                                                <asp:Label ID="lblPayMoney" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                处理结果：</td>
                                            <td colspan="3" align="left">
                                                <asp:Label ID="lblResult" runat="server"></asp:Label></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0" id="tbRemark"
                            runat="server" visible="true">
                            <tr>
                                <td>
                                    <table width="96%" border="0" align="center" cellpadding="1" cellspacing="0">
                                        <tr>
                                            <td colspan="2" class="mshu_font14black" height="30" valign="bottom" align="left">
                                                请填写付款信息(<font color="red">请务必如实填写，以便客服查询</font>)</td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="mshu_font14black" colspan="2" valign="bottom" style="height: 30px">
                                                汇款方式：<asp:DropDownList ID="ddlBankName" runat="server">
                                                </asp:DropDownList><span style="color: #ff0000">*</span> &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                                &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; 汇款金额：<asp:TextBox ID="txtHKJE" runat="server" MaxLength="10"
                                                    onkeypress="isnum()" Width="80px"></asp:TextBox><span style="color: #ff0000">*</span>元
                                                &nbsp; &nbsp; &nbsp; &nbsp;汇款日期：<asp:TextBox ID="txtHKRQ" runat="server" onfocus="calendar();"></asp:TextBox><span
                                                    style="color: #ff0000">*</span></td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="mshu_font14black" colspan="2" style="height: 30px" valign="bottom">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtHKJE"
                                                    ErrorMessage="付款金额不能为空"></asp:RequiredFieldValidator>
                                                &nbsp; &nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtHKRQ"
                                                    ErrorMessage="汇款日期不能为空"></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="mshu_font14black" colspan="2" height="30" valign="bottom">
                                                留言：</td>
                                        </tr>
                                        <tr>
                                            <td width="65%">
                                                &nbsp;<asp:TextBox ID="txtRemark" runat="server" Rows="7" TextMode="MultiLine" Width="530px" MaxLength="200"></asp:TextBox>
                                                <table width="100%" border="0" cellspacing="0" cellpadding="6">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:ImageButton ID="ibtnHasPay" runat="server" AlternateText="我已付款" OnClick="ibtnHasPay_Click"
                                                                ImageUrl="/Images/Web/orderz_btn.gif" ImageAlign="Middle" />&nbsp;
                                                            <asp:ImageButton ID="ibtnSave" runat="server" ImageUrl="/Images/Web/orderz_btn2b.gif"
                                                                align="absmiddle" OnClientClick="window.opener=null;window.open('','_self');window.close();" AlternateText="关闭" ImageAlign="Middle" />
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="35%" valign="top">
                                              备注：请填写寄款人账户名称或流水号，以方便我们核实您的汇款。
                                                &nbsp;<br />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table id="tbCancel" runat="server" visible="false" style="width: 92%">
                            <tr>
                                <td align="center">
                                    <strong><span style="color: #ff0000">该订单已取消</span></strong>
                                </td>
                            </tr>
                        </table>
                         <table id="tbFinish" runat="server" visible="false" style="width: 92%">
                            <tr>
                                <td align="center">
                                    <strong><span style="color: #ff0000">交易已完成</span></strong>
                                </td>
                            </tr>
                        </table>
                        
                    </td>
                </tr>
                <tr>
                    <td>
                        <img src="/Images/Web/orderz_topbg3.gif" width="920" height="5" /></td>
                </tr>
            </table>
        </div>
        <uc3:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
