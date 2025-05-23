<%@ Page Language="C#" AutoEventWireup="true" Codebehind="OrderDetails.aspx.cs" Inherits="Pbzx.Web.PB_Manage.OrderDetails" %>

<%@ Register Src="../Contorls/OrderInfo.ascx" TagName="OrderInfo" TagPrefix="uc2" %>
<%@ Register Src="../Contorls/OrderDetail.ascx" TagName="OrderDetail" TagPrefix="uc1" %>
<html>
<head id="Head1">
    <title>订单清单</title>
 <link type="text/css" rel="stylesheet" href="stylecss/css.css" />

    <script type="text/javascript" language="javascript">
        function OpenEdite(id)
        {
            var result =  window.showModalDialog('OrderDetails_Edite.aspx?OrderDetailID='+id+'&type=<%=strType %>','','dialogHeight:327px;dialogWidth:410px;center:yes;help:no;resizable:no;scroll:yes;status:no; scrollbars:No;toolbar:no;menubar:no;location:no;')                        
            if(result == 'yes')
            {
               location.reload();    
            }
        }
        
        function OpenEdite1(id)
        {
            var result =  window.showModalDialog('OrderDetails_EditeRG.aspx?OrderDetailID='+id+'&type=<%=strType %>','','dialogHeight:410px;dialogWidth:590px;center:yes;help:no;resizable:no;scroll:yes;status:no; scrollbars:No;toolbar:no;menubar:no;location:no;')                        
            if(result == 'yes')
            {
               location.reload();    
            }
        }
        
       function isnum()
       {
            if(event.keyCode<46||event.keyCode>57 || event.keyCode==47)
            {
                event.keyCode=0;
            }
       } 
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#7694D2"
                class="MT">
                <tr>
                    <td bgcolor="#F3F3F3">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="Right_bg1">
                                    <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                                        <tr>
                                            <td width="91%" align="left">
                                                当前位置：订单详细</td>
                                            <td width="9%" align="right">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" cellpadding="2" cellspacing="1" bgcolor="#CED7F7">
                            <tr bgcolor="#F2F8FB">
                                <td>
                                    <div id="dvProductList">
                                        <table style="width: 90%" runat="server" id="tbOrderType">
                                            <tr style="line-height: 30px;">
                                                <td>
                                                    &nbsp;&nbsp; 注：
                                                    <asp:Label ID="lblState" runat="server"></asp:Label></td>
                                            </tr>
                                        </table>
                                        <table style="width: 100%">
                                            <tr>
                                                <td height="20" bgcolor="#FFF4DD" align="left" colspan="6" background="/Images/Web/shop_serve.jpg">
                                                    &nbsp;<b class="bTitle">购买软件清单</b></td>
                                            </tr>
                                        </table>
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="OrderDetailID,OrderID,RegType,State,Serial"
                                            GridLines="Horizontal" OnRowDataBound="GridView1_RowDataBound" ShowFooter="True"
                                            Width="100%" CssClass="GridView_Table1" OnRowCreated="GridView1_RowCreated">
                                            <FooterStyle HorizontalAlign="Right" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="软件名称">
                                                    <ItemTemplate>
                                                        <a href="/Soft_explain.aspx?ID=<%#Pbzx.Common.Input.Encrypt(Eval("pb_SoftID").ToString()) %>"
                                                            title='<%#Eval("pb_SoftName")%>' class="S_title1" target="_blank">
                                                            <%#Eval("pb_SoftName")%>
                                                        </a>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" Width="20%" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="注册方式">
                                                    <ItemTemplate>
                                                        <%# CheckRegTye(Eval("RegType"), Eval("pb_TypeName"), Eval("pb_DemoUrl"), Eval("pb_RegUrl"))%>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" Width="35%" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="售价" HtmlEncode="False">
                                                    <HeaderStyle HorizontalAlign="Center" Width="6%" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="处理结果" HtmlEncode="False" DataField="Serial">
                                                    <HeaderStyle HorizontalAlign="Center" Width="20%" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="状态">
                                                    <ItemTemplate>
                                                        <%# Pbzx.Web.WebFunc.GetOrderDetailState(Eval("State"))%>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" Width="11%" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="操作">
                                                    <ItemTemplate>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" Width="8%" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle Font-Bold="True" CssClass="GridView_Header1" />
                                            <RowStyle CssClass="GridView_Row1" />
                                            <PagerSettings Mode="NumericFirstLast" Visible="False" />
                                        </asp:GridView>
                                        <%--                                        <table style="width: 100%">
                                            <tr>
                                                <td style="width: 40%" align="center">
                                                </td>
                                                <td style="width: 20%">
                                                </td>
                                                <td style="width: 40%" align="center">
                                                    <span class="shop14black">总数量:<span class="shop14red"><asp:Label ID="lblSumQuatity"
                                                        runat="server" Text="0"></asp:Label></span>&nbsp;总价格:<span class="shop14red"><asp:Label
                                                            ID="lblSumBookPrice" runat="server" Text="0.00"></asp:Label></span> </span>
                                                </td>
                                            </tr>
                                        </table>--%>
                                    </div>
                                    <div id="dvOrderInfo">
                                    </div>
                                    <uc2:OrderInfo ID="OrderInfo1" runat="server" />
                                    <div id="dvCancel" runat="server" visible="false">
                                        订单已经取消
                                    </div>
                                    <div id="dvSuccess" runat="server" visible="false">
                                        <div>
                                            开通成功！
                                        </div>
                                        <table style="width: 98%;">
                                            <tr bgcolor="#f2f8fb" style="line-height: 30px">
                                                <td class="bold" style="width: 20%">
                                                    用户实际付款信息：</td>
                                                <td colspan="3">
                                                    实际汇款方式：<asp:Label ID="lblSJHKFS" runat="server"></asp:Label>
                                                    &nbsp;&nbsp; &nbsp;实际汇款金额：<asp:Label ID="lblSJHKJE" runat="server"></asp:Label>
                                                    &nbsp; &nbsp; &nbsp;处理结果：<asp:Label ID="lblSJResult" runat="server"></asp:Label></td>
                                            </tr>
                                        </table>
                                    </div>
                                    <table style="width: 98%;" id="zhifu" runat="server">
                                        <tr bgcolor="#f2f8fb" style="line-height: 30px">
                                            <td class="bold" style="width: 15%">
                                                用户付款信息：</td>
                                            <td colspan="3">
                                                汇款方式：<asp:Label ID="lblHKFS" runat="server"></asp:Label>
                                                &nbsp;&nbsp; &nbsp;汇款金额：<asp:Label ID="lblHKJE" runat="server"></asp:Label>
                                                &nbsp; &nbsp; &nbsp;汇款日期：<asp:Label ID="lblHKRQ" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr bgcolor="#f2f8fb" style="line-height: 30px;">
                                            <td class="bold" style="width: 15%">
                                                用户留言备注：</td>
                                            <td colspan="3">
                                                <asp:Label ID="lblUserRemark" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr bgcolor="#f2f8fb" style="line-height: 30px;">
                                            <td class="bold" style="width: 15%">
                                                审核操作：</td>
                                            <td colspan="3">
                                                <table style="width: 80%">
                                                    <tr>
                                                        <td colspan="3">
                                                            <table>
                                                                <tr>
                                                                    <td style="width: 100px; height: 38px;" align="left">
                                                                        实际付款方式：</td>
                                                                    <td align="left" style="width: 20%; height: 38px;">
                                                                        <asp:DropDownList ID="ddlPayType" runat="server">
                                                                        </asp:DropDownList><span style="color: #ff0000">*</span></td>
                                                                    <td style="width: 50%; height: 38px;">
                                                                        <span style="color: #ff0000"></span>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 100px" align="left">
                                                                        实际付款金额：</td>
                                                                    <td align="center" style="width: 20%">
                                                                        <asp:TextBox ID="txtHasPayed" onkeypress="isnum()" runat="server" Width="80px" MaxLength="12">0</asp:TextBox><span
                                                                            style="color: #ff0000">*</span>元</td>
                                                                    <td style="width: 50%">
                                                                        &nbsp;&nbsp;
                                                                        <asp:CheckBox ID="chbCZ" runat="server" Text="将多汇金额充入用户账号" /></td>
                                                                </tr>
                                                            </table>
                                                            处理结果（如果未通过，请简要说明原因）：</td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <asp:TextBox ID="txtResult" runat="server" TextMode="MultiLine" Height="57px" MaxLength="200"
                                                                Width="376px"></asp:TextBox></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <%--<tr bgcolor="#f2f8fb">
                                            <td class="bold" style="width: 15%; height: 23px;">
                                                订单状态:</td>
                                            <td colspan="3" style="height: 23px">
                                                <asp:RadioButtonList ID="rblOrderStaticTip" runat="server" RepeatDirection="Horizontal"
                                                    RepeatLayout="Flow" OnSelectedIndexChanged="rblOrderStaticTip_SelectedIndexChanged"
                                                    AutoPostBack="True">
                                                </asp:RadioButtonList>&nbsp; （当查到用户款项准确无误后，请先在上面的“购买软件清单”中给用户输入注册码，然后订单状态中选择“已开通”）</td>
                                        </tr>
                                        <tr bgcolor="#f2f8fb">
                                            <td class="bold" style="width: 15%">
                                                是否取消：</td>
                                            <td colspan="3">
                                                <asp:CheckBox ID="chbIsCancel" runat="server" AutoPostBack="True" OnCheckedChanged="chbIsCancel_CheckedChanged"
                                                    Text="是" /></td>
                                        </tr>
                                        <tr bgcolor="#f2f8fb">
                                            <td class="bold" style="width: 15%">
                                                已付款：</td>
                                            <td colspan="3">
                                                <asp:TextBox ID="txtHasPay" runat="server" Width="80px" MaxLength="8">0</asp:TextBox>元</td>
                                        </tr>--%>
                                    </table>
                                </td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="center">
                                    <asp:Button ID="btnRight" runat="server" Text="款项已足-开通软件" OnClientClick="return confirm('您确定要开通软件吗？')"
                                        OnClick="btnRight_Click" />
                                    &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;
                                    <asp:Button ID="btnUpdate" runat="server" Text="款项不足-处理失败" OnClientClick="return Confirm('您确定要执行此操作吗？')"
                                        OnClick="btnUpdate_Click" />
                                    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
                                    <asp:Button ID="btnNoPay" runat="server" Text="未付款" OnClientClick="return Confirm('您确定要执行此操作吗？')"
                                        OnClick="btnNoPay_Click" />
                                    &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;
                                    <input type="button" value="关闭" onclick="window.opener=null;window.open('','_self');window.close();" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
