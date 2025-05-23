<%@ Page Language="C#" AutoEventWireup="true" Codebehind="detailsorder.aspx.cs" Inherits="Pbzx.Web.UserCenter.detailsorder" %>

<%@ Register Src="../Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc3" %>
<%@ Register Src="../Contorls/OrderDetail2.ascx" TagName="OrderDetail2" TagPrefix="uc2" %>
<%@ Register Src="../Contorls/OrderDetail.ascx" TagName="OrderDetail" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>查看订单_拼搏在线彩神通软件</title>
    <link href="/css/user_center.css" rel="stylesheet" type="text/css" />

    <script src="/javascript/calendar.js" type="text/javascript"></script>

    <link type="text/css" href="/css/start/jquery-ui-1.7.2.custom.css" rel="stylesheet" />

    <script type="text/javascript" src="/javascript/jquery-1.3.2.js"></script>

    <script type="text/javascript" src="/javascript/jquery.blockUI.js"></script>

    <script type="text/javascript" src="/javascript/jquery-ui-1.7.2.custom.min.js"></script>

    <script type="text/javascript" src="/javascript/Header.js"></script>

    <script type="text/javascript">
        function isnum()
        {
            if(event.keyCode<46||event.keyCode>57 || event.keyCode==47)
            {
                event.keyCode=0;
            }
        }
        function CheckIsValidateUser(user)
        {    
//           //"/reg.aspx?checkUserNameInput="+escape(user)
//            $.get("/reg.aspx",{checkUserNameInput:escape(user)},function(data)
//            {            
//            });            
            var data = $.ajax({ 
              url:"/reg.aspx?checkUserNameInput="+escape(user), 
              async: false 
            }).responseText; 
            if(data == "true")
            {
                return confirm("您确定要给"+user+"开通临时使用权限吗？");
            }
            else
            {
                alert("此用户名不存在，或者已经被锁定，请核实后提交。");
                return false;
            }
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <div id="dialog1" title="拼搏在线彩神通软件网站提醒" style="display: none;">
                <p>
                    提醒内容</p>
            </div>
            <div id="dialog2" title="拼搏在线彩神通软件网站提醒" style="display: none;">
                <p>
                    提醒内容</p>
            </div>
            <table width="920" border="0" align="center" cellpadding="2" cellspacing="0">
                <tr>
                    <td width="213">
                        <table width="158px" height="72px" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="158" height="72" align="center">
                                    <a href='http://www.pinble.com/'><img border='0' src='/Images/Web/PinbleLogo.gif'  width='158' height='72'></a>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td width="707" height="70">
                        <table width="93%" border="0" cellpadding="0" cellspacing="0" bgcolor="#E6E6E6">
                            <tr>
                                <td class="mshu_menushang" id="step1" runat="server">
                                    1.提交订单</td>
                                <td id="step2" runat="server">
                                    2.付款</td>
                                <td id="step3" runat="server">
                                    3.款项到达</td>
                                <td id="step4" runat="server">
                                    4.开通（发货）</td>
                                <td id="step5" runat="server" class="mshu_menushangOut">
                                    5.开通确认</td>
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
                                    &nbsp;&nbsp;<span class="mshu_font16black">订单号：<span class="mshu_font16red"><asp:Label
                                        ID="lblOrderID" runat="server"></asp:Label></span><span class="mshu_font16red"></span>
                                        （<asp:Label ID="lblTipName" runat="server"></asp:Label>，<asp:Label ID="lblPayTypeName"
                                            runat="server"></asp:Label>）</span><asp:Label ID="lblOrderDate" runat="server"></asp:Label></td>
                            </tr>
                        </table>
                        <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="mshu_borderxia" style="height: 130px">
                                    <table width="96%" border="0" align="center" cellpadding="1" cellspacing="0">
                                        <tr>
                                            <td colspan="4" class="mshu_font14black" height="30" valign="bottom" align="left">
                                                收货人信息</td>
                                        </tr>
                                        <tr>
                                            <td width="5%" align="right">
                                                姓名：</td>
                                            <td width="34%" align="left">
                                                <asp:Label ID="lblUserName" runat="server"></asp:Label></td>
                                            <td width="6%" align="right">
                                                电话：</td>
                                            <td width="55%" align="left">
                                                <asp:Label ID="lblReceiverPhone" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                邮编：</td>
                                            <td align="left">
                                                <asp:Label ID="lblPostalCode" runat="server"></asp:Label></td>
                                            <td align="right">
                                                Email：</td>
                                            <td align="left">
                                                <asp:Label ID="lblReceiverEmail" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                地址：</td>
                                            <td colspan="3" align="left">
                                                <asp:Label ID="lblReceiverAddress" runat="server"></asp:Label></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="mshu_borderxia">
                                    <table width="96%" border="0" align="center" cellpadding="1" cellspacing="0">
                                        <tr>
                                            <td class="mshu_font14black" height="30" valign="bottom" align="left">
                                                软件清单
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:UpdatePanel ID="UpShoppingCart" runat="server">
                                                    <ContentTemplate>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <div id="dvProductList">
                                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="OrderID,RegType,Serial,State,pb_SoftName,TempOpen,CstID,OrderDetailID"
                                                        GridLines="Horizontal" OnRowDataBound="GridView1_RowDataBound" Width="100%" CssClass="GridView_Table1"
                                                        OnRowCreated="GridView1_RowCreated" CellPadding="4" BorderColor="#53E1FF" BorderStyle="Solid"
                                                        BorderWidth="1px">
                                                        <FooterStyle HorizontalAlign="Right" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="软件名称">
                                                                <ItemTemplate>
                                                                    ·<a href="/Soft_explain.aspx?ID=<%#Pbzx.Common.Input.Encrypt(Eval("pb_SoftID").ToString()) %>"
                                                                        title='<%#Eval("pb_SoftName")%>' class="S_title1" target="_blank">
                                                                        <%#Eval("pb_SoftName")%>
                                                                    </a>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" Width="20%" />
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="注册方式">
                                                                <ItemTemplate>
                                                                    <%# Pbzx.Web.WebFunc.CheckRegTye(Eval("RegType"), Eval("pb_TypeName"), Eval("pb_DemoUrl"), Eval("pb_RegUrl"))%>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" Width="38%" />
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="售价" HtmlEncode="False">
                                                                <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="处理结果">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblResult" runat="server"></asp:Label>
                                                                    <asp:Panel ID="pnlTempOpen" runat="server" Visible="false">
                                                                        使用者用户名：<asp:TextBox ID="txtUserName" onfocus="this.select()" CssClass="shop_intput_border"
                                                                            MaxLength="12" runat="server" OnTextChanged="txtUserName_TextChanged" Width="120px"
                                                                            AutoPostBack="false"></asp:TextBox>
                                                                        <asp:Button ID="btnTempOpen" runat="server" Text="开通临时使用" OnClick="btnTempOpen_Click" />
                                                                    </asp:Panel>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" Width="26%" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <HeaderStyle Font-Bold="True" CssClass="GridView_Header1" BackColor="#DFF7FF" />
                                                        <RowStyle CssClass="GridView_Row1" BorderStyle="None" />
                                                        <PagerSettings Mode="NumericFirstLast" Visible="False" />
                                                    </asp:GridView>
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td style="width: 80%">
                                                                <asp:Label ID="lblJSXX" runat="server"></asp:Label></td>
                                                            <td align="center" colspan="2">
                                                                &nbsp;<%--  <span class="shop14black">总数量:<span class="shop14red"><asp:Label ID="lblSumQuatity"
                                                                    runat="server" Text="0"></asp:Label></span>&nbsp;总价格:<span class="shop14red"><asp:Label
                                                                        ID="lblSumBookPrice" runat="server" Text="0.00"></asp:Label></span> </span>--%></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" colspan="3">
                                                                <asp:Label ID="lblYFJE" runat="server"></asp:Label></td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span class="mshu_font16black">订单处理结果：</span><span class="mshu_font16red"><asp:Label
                                                    ID="lblOrderResult" runat="server" Text=""></asp:Label></span>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td height="6">
                                </td>
                            </tr>
                        </table>
                        <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0" id="tbRemark"
                            runat="server" visible="true">
                            <tr>
                                <td>
                                    <table width="96%" border="0" align="center" cellpadding="1" cellspacing="0">
                                        <tr>
                                            <td colspan="2" class="mshu_font14black" height="25" valign="bottom" align="left">
                                                请填写付款信息（<font color="red">请务必如实填写，以便客服查询</font>）</td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="mshu_font14black" colspan="2" valign="bottom" style="height: 27px">
                                                付款方式：<asp:DropDownList ID="ddlBankName" runat="server">
                                                </asp:DropDownList><span style="color: #ff0000">*</span> &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                                &nbsp;&nbsp; 付款金额：<asp:TextBox ID="txtHKJE" runat="server" MaxLength="10" onkeypress="isnum()"
                                                    Width="80px"></asp:TextBox><span style="color: #ff0000">*</span>元 &nbsp; &nbsp;
                                                &nbsp; &nbsp;汇款日期：<asp:TextBox ID="txtHKRQ" runat="server" onfocus="calendar();"></asp:TextBox><span
                                                    style="color: #ff0000">*</span></td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="mshu_font14black" colspan="2" style="height: 27px" valign="bottom">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="请选择付款方式！"
                                                    ControlToValidate="ddlBankName" InitialValue=""></asp:RequiredFieldValidator>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtHKJE"
                                                    ErrorMessage="付款金额不能为空！"></asp:RequiredFieldValidator>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtHKRQ"
                                                    ErrorMessage="汇款日期不能为空！"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="mshu_font14black" colspan="2" height="27" valign="bottom">
                                                留言：</td>
                                        </tr>
                                        <tr>
                                            <td width="65%">
                                                &nbsp;<asp:TextBox ID="txtRemark" runat="server" Rows="7" TextMode="MultiLine" Width="530px" MaxLength="200"></asp:TextBox>
                                                <table width="100%" border="0" cellspacing="0" cellpadding="6">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:ImageButton ID="ibtnHasPay" runat="server" AlternateText="我已付款" OnClick="ibtnHasPay_Click"
                                                                ImageUrl="/Images/Web/orderz_btn.gif" />&nbsp;&nbsp;&nbsp;
                                                            <asp:ImageButton ID="ibtnSave" runat="server" ImageUrl="/Images/Web/orderz_btn2b.gif"
                                                                OnClientClick="window.opener=null;window.open('','_self');window.close();" AlternateText="关闭" />
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="35%" valign="top">
                                                备注：请填写寄款人账户名称或流水号，以方便我们核实您的汇款。 &nbsp;<br />
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
