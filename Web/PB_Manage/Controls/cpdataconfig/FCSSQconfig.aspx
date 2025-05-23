<%@ Page Language="C#" AutoEventWireup="true" Codebehind="FCSSQconfig.aspx.cs" Inherits="Pbzx.Web.PB_Manage.Controls.cpdataconfig.FCSSQconfig" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Import Namespace="Pbzx.Common" %>
<html>
<head id="Head1" runat="server">
    <title>双色球开奖信息</title>
    <link type="text/css" rel="stylesheet" href="../../StyleCss/StyleCss.css" />

    <script type="text/javascript" language="javascript" src="../../JScript/javascript.js"></script>

</head>
<body onload="GridViewColor();">
    <form id="form1" runat="server">
        <div style="width: 100%;">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <div style="width: 100%;">
                <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
                    align='center'>
                    <tr bgcolor="#F3F3F3">
                        <td height='22' align='center'>
                            <asp:Label ID="lblLinkAdd" runat="server" Text=""></asp:Label></td>
                    </tr>
                </table>
                <div runat="server" id="divList" visible="true">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="Right_bg2">
                                <table width="95%" border="0" cellspacing="0" cellpadding="0" align="center">
                                    <tr>                                       
                                        <td align="left">
                                            <asp:Button ID="btnDivAdd" runat="server" Text="添加新的开奖信息" OnClick="btnDivAdd_Click" />
                                        </td>
                                        <td align="right">
                                            <asp:Button ID="btnDel" runat="server" Text="删除最近开奖日期" OnClick="btnDel_Click"  OnClientClick="return confirm('你确定要删除吗?');" />
                                        </td>
                                         <td align="right">
                                            <%--<asp:Button ID="btnList" runat="server" Text="返回" OnClick="btnList_Click" />--%>
                                            期号：<asp:TextBox ID="txt_Condition" runat="server" Width="100px"></asp:TextBox>&nbsp;

                                        <asp:Button ID="Search" runat="server" Text="搜索" onclick="Search_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <div style="position:absolute; width:100%; height:398px; overflow-y:scroll">
                    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#7694D2">
                        <tr bgcolor="#F3F3F3">
                            <td>
                                <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" Width="100%"
                                    CellPadding="0"  CssClass="GridView_Table">
                                    <Columns>
                                        <asp:TemplateField HeaderText="开奖日期" SortExpression="date">
                                            <ItemStyle Width="16%" />
                                            <ItemTemplate>
                                                   <%# Eval("date","{0:yyyy-MM-dd}") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="开奖期号" SortExpression="issue">
                                            <ItemStyle Width="10%" />
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("issue") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="红球号码" SortExpression="redcode">
                                            <ItemStyle Width="16%" />
                                            <ItemTemplate>
                                                <font color="#FF0000">
                                                    <%# Method.FormartCode(Eval("redcode").ToString()," ") %>
                                                </font>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="篮球号码" SortExpression="code">
                                            <ItemStyle Width="8%" />
                                            <ItemTemplate>
                                                <font color="#0000FF">
                                                    <%# Eval("bluecode") %>
                                                </font>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="星期天">
                                            <ItemStyle Width="7%" />
                                            <ItemTemplate>
                                                <font color="#0000FF">
                                                    <%# Eval("bluecode2")%>
                                                </font>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="最近修改时间" SortExpression="LastModifyTime">
                                            <ItemStyle Width="16%" />
                                            <ItemTemplate>
                                                <%# Eval("LastModifyTime", "{0:yyyy-MM-dd HH:mm:ss}")%> 
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="录入员IP" SortExpression="OpIp">
                                            <ItemStyle Width="13%" />
                                            <ItemTemplate>
                                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("OpIp") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="录入员" SortExpression="OpName">
                                            <ItemStyle Width="9%" />
                                            <ItemTemplate>
                                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("OpName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="操作">
                                            <ItemStyle Width="5%" />
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtnUpdate" runat="server" CommandArgument='<%# Eval("issue") %>'
                                                    OnCommand="LinkButton1_Command">修改</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <RowStyle CssClass="GridView_Row" />
                                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle CssClass="GridView_Pager" />
                                    <HeaderStyle Font-Bold="True" CssClass="GridView_Header" />
                                    <AlternatingRowStyle CssClass="GridView_AlternatingRow" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                    </div>
                </div>
                <div id="divAdd" runat="server" visible="false">
                    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#7694D2">
                        <tr>
                            <td bgcolor="#F3F3F3">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td class="Right_bg2" id="jnkc" align="center">

                                            <script type="text/javascript">setInterval("jnkc.innerHTML=new Date().toLocaleString()+' 星期'+'日一二三四五六'.charAt(new Date().getDay());",1000);
                                            </script>

                                        </td>
                                    </tr>
                                </table>
                                <table width="100%" cellpadding="2" cellspacing="1" bgcolor="#CED7F7">
                                    <tr bgcolor="#F2F8FB">
                                        <td class="bold" width="25%">
                                            开奖期号:
                                        </td>
                                        <td width="75%">
                                            <asp:TextBox ID="txtIssue" MaxLength="7" runat="server"></asp:TextBox>
                                            （格式：2004101）</td>
                                    </tr>
                                    <tr bgcolor="#F2F8FB">
                                        <td class="bold">
                                            开奖日期:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDate" runat="server" MaxLength="10"></asp:TextBox>
                                            （格式：2004-6-4）</td>
                                    </tr>
                                    <tr bgcolor="#F2F8FB">
                                        <td class="bold">
                                            红球号码:
                                        </td>
                                        <td class="forumRow">
                                            <asp:TextBox ID="txtRedcode1" MaxLength="2" runat="server" Height="20px" Width="26px"
                                                onkeyup='CheckCode(this,"txtRedcode2")' onfocus="javascript:this.select()"></asp:TextBox>
                                            <asp:TextBox ID="txtRedcode2" runat="server" Height="20px" MaxLength="2" Width="26px"
                                                onkeyup='CheckCode(this,"txtRedcode3")' onfocus="javascript:this.select()"></asp:TextBox>
                                            <asp:TextBox ID="txtRedcode3" runat="server" Height="20px" MaxLength="2" Width="26px"
                                                onkeyup='CheckCode(this,"txtRedcode4")' onfocus="javascript:this.select()"></asp:TextBox>
                                            <asp:TextBox ID="txtRedcode4" runat="server" Height="20px" MaxLength="2" Width="26px"
                                                onkeyup='CheckCode(this,"txtRedcode5")' onfocus="javascript:this.select()"></asp:TextBox>
                                            <asp:TextBox ID="txtRedcode5" runat="server" Height="20px" MaxLength="2" Width="26px"
                                                onkeyup='CheckCode(this,"txtRedcode6")' onfocus="javascript:this.select()"></asp:TextBox>
                                            <asp:TextBox ID="txtRedcode6" runat="server" Height="20px" MaxLength="2" Width="26px"
                                                onkeyup='CheckCode(this,"txtBluecode")' onfocus="javascript:this.select()"></asp:TextBox>&nbsp; （格式：01 02 03 04
                                            05 06；范围：01-33）</td>
                                    </tr>
                                    <tr bgcolor="#F2F8FB">
                                        <td class="bold">
                                            蓝球号码:</td>
                                        <td>
                                            <asp:TextBox ID="txtBluecode" runat="server" Height="20px" MaxLength="2" Width="26px"
                                                onkeyup='CheckCode(this,"txtBluecode2")' onfocus="javascript:this.select()"></asp:TextBox>（格式：01；范围：01-16）</td>
                                    </tr>
                                    <tr bgcolor="#F2F8FB">
                                        <td class="bold">
                                            &nbsp;快乐星期天:</td>
                                        <td class="forumRow">
                                            <asp:TextBox ID="txtBluecode2" runat="server" Height="20px" MaxLength="2" Width="26px"
                                                onkeyup='CheckCode(this,"btnSave")' onfocus="javascript:this.select()"></asp:TextBox>（格式：01，<font color="#ff0000">如果没有则填00</font>）</td>
                                    </tr>
                                    <tr bgcolor="#F2F8FB">
                                        <td>
                                        </td>
                                        <td class="forumRow">
                                            &nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="btnSave" runat="server" Text="添加" OnClick="btnSave_Click" />&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="btnClear" runat="server" Text="返回" OnClick="btnClear_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#7694D2">
                        <tr class="Right_bg2">
                            <td class="forumRow" align="center">
                                <b>临时剪贴编辑器<font color="#ff0000">（注意：本窗口的内容仅做临时剪贴使用，信息不保存）</font></b></td>
                        </tr>
                        <tr  bgcolor="#F3F3F3">
                            <td align="center" valign="middle" Height="280px">
                                <asp:TextBox ID="TextBox1" runat="server" Height="260px" TextMode="MultiLine" Width="96%"></asp:TextBox></td>
                        </tr>
                    </table>
                </div>
                <asp:HiddenField ID="HiddenField1" runat="server" Value="0" />
                <asp:RangeValidator ID="rvd1" runat="server" ControlToValidate="txtRedcode1" MaximumValue="33"
                    MinimumValue="01" Type="Integer" ErrorMessage="号码范围不对(01-33)" Display="None"></asp:RangeValidator>
                <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" HighlightCssClass="validatorCalloutHighlight" 
                    TargetControlID="rvd1">
                </cc1:ValidatorCalloutExtender>
                <asp:RangeValidator ID="rvd2" runat="server" ControlToValidate="txtRedcode2" MaximumValue="33"
                    MinimumValue="01" Type="Integer" ErrorMessage="号码范围不对(01-33)" Display="None"></asp:RangeValidator>
                <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" HighlightCssClass="validatorCalloutHighlight"
                    TargetControlID="rvd2">
                </cc1:ValidatorCalloutExtender>
                <asp:RangeValidator ID="rvd3" runat="server" ControlToValidate="txtRedcode3" MaximumValue="33"
                    MinimumValue="01" Type="Integer" ErrorMessage="号码范围不对(01-33)" Display="None"></asp:RangeValidator>
                <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="rvd3">
                </cc1:ValidatorCalloutExtender>
                <asp:RangeValidator ID="rvd4" runat="server" ControlToValidate="txtRedcode4" MaximumValue="33"
                    MinimumValue="01" Type="Integer" ErrorMessage="号码范围不对(01-33)" Display="None"></asp:RangeValidator>
                <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="rvd4">
                </cc1:ValidatorCalloutExtender>
                <asp:RangeValidator ID="rvd5" runat="server" ControlToValidate="txtRedcode5" MaximumValue="33"
                    MinimumValue="01" Type="Integer" ErrorMessage="号码范围不对(01-33)" Display="None"></asp:RangeValidator>
                <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" TargetControlID="rvd5">
                </cc1:ValidatorCalloutExtender>
                <asp:RangeValidator ID="rvd6" runat="server" ControlToValidate="txtRedcode6" MaximumValue="33"
                    MinimumValue="01" Type="Integer" ErrorMessage="号码范围不对(01-33)" Display="None"></asp:RangeValidator>
                <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" TargetControlID="rvd6">
                </cc1:ValidatorCalloutExtender>
                <asp:RangeValidator ID="rvd7" runat="server" ControlToValidate="txtBluecode" MaximumValue="16"
                    MinimumValue="01" Type="Integer" ErrorMessage="号码范围不对(01-16)" Display="None"></asp:RangeValidator>
                <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" TargetControlID="rvd7">
                </cc1:ValidatorCalloutExtender>
                <asp:RangeValidator ID="rvdT" runat="server" ControlToValidate="txtBluecode2" MaximumValue="16"
                    MinimumValue="00" Type="Integer" ErrorMessage="号码范围不对(01-16)" Display="None"></asp:RangeValidator>
                <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server" TargetControlID="rvdT">
                </cc1:ValidatorCalloutExtender>
                <br />
                <cc1:FilteredTextBoxExtender ID="ftb1" runat="server" TargetControlID="txtRedcode1"
                    FilterType="Numbers">
                </cc1:FilteredTextBoxExtender>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtRedcode2"
                    FilterType="Numbers">
                </cc1:FilteredTextBoxExtender>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtRedcode3"
                    FilterType="Numbers">
                </cc1:FilteredTextBoxExtender>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtRedcode4"
                    FilterType="Numbers">
                </cc1:FilteredTextBoxExtender>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtRedcode5"
                    FilterType="Numbers">
                </cc1:FilteredTextBoxExtender>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txtRedcode6"
                    FilterType="Numbers">
                </cc1:FilteredTextBoxExtender>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txtBluecode"
                    FilterType="Numbers">
                </cc1:FilteredTextBoxExtender>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" TargetControlID="txtBluecode2"
                    FilterType="Numbers">
                </cc1:FilteredTextBoxExtender>
            </div>
            <asp:HiddenField ID="hfNewsID" runat="server" Value="0" />
        </div>
    </form>
</body>
</html>
