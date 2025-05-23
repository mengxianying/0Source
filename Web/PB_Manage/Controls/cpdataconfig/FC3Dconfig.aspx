<%@ Page Language="C#" AutoEventWireup="true" Codebehind="FC3Dconfig.aspx.cs" Inherits="Pbzx.Web.PB_Manage.Controls.cpdataconfig.FC3Dconfig" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Import Namespace="Pbzx.Common" %>
<html>
<head id="Head1" runat="server">
    <title>福彩3D</title>
    <link type="text/css" rel="stylesheet" href="../../StyleCss/StyleCss.css" />
    <script type="text/javascript" language="javascript" src="../../JScript/javascript.js"></script>
</head>
<body onload="GridViewColor();">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div style="width: 100%;">
            <div style="width: 100%;">
                <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
                    align='center'>
                    <tr bgcolor="#F3F3F3">
                        <td height='22' align='center'>
                            <asp:Label ID="lblLinkAdd" runat="server" Text=""></asp:Label></td>
                    </tr>
                </table>
                <div runat="server" id="divList" visible="true" >
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="Right_bg2">
                                <table width="95%" border="0" cellspacing="0" cellpadding="0" align="center">
                                    <tr>
                                        <td align="left">
                                            <asp:Button ID="btnDivAdd" runat="server" Text="添加新的开奖信息" OnClick="btnDivAdd_Click" />
                                        </td>
                                        <td align="right">
                                            <asp:Button ID="btnDel" runat="server" Text="删除最近开奖日期" OnClick="btnDel_Click" OnClientClick="return confirm('你确定要删除吗?');" />
                                        </td>
                                        <td align="right">
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
                                    CellPadding="0" CssClass="GridView_Table">
                                    <Columns>
                                        <asp:TemplateField HeaderText="开奖日期" SortExpression="date">
                                            <ItemStyle Width="16%" />
                                            <ItemTemplate>
                                                <%# Eval("date","{0:yyyy-MM-dd}") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="期号" SortExpression="issue">
                                            <ItemStyle Width="8%" />
                                            <ItemTemplate>
                                                <%# Eval("issue") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="机球信息" SortExpression="redcode">
                                            <ItemStyle Width="8%" />
                                            <ItemTemplate>
                                                <font color="#FF00FF">
                                                    <%#Eval("machine")%>机<%#Eval("ball")%>球 </font>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="试机号" SortExpression="code">
                                            <ItemStyle Width="8%" />
                                            <ItemTemplate>
                                                <font color="#9933FF">
                                                    <%# Eval("testcode")%>
                                                </font>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="开奖号码">
                                            <ItemStyle Width="10%" />
                                            <ItemTemplate>
                                                <font color="#0000FF">
                                                    <%# Eval("code")%>
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
                                                <a href='#' title='<%#GetIp(Eval("OpIp"))%>'>
                                                    <%#Eval("OpIp") %>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="录入员" SortExpression="OpName">
                                            <ItemStyle Width="10%" />
                                            <ItemTemplate>
                                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("OpName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="操作">
                                            <ItemStyle Width="10%" />
                                            <ItemTemplate>
                                                &nbsp;<asp:LinkButton ID="lbtnUpdate" runat="server" OnClientClick="changeTab(1)"
                                                    CommandArgument='<%# Eval("issue") %>' OnCommand="LinkButton1_Command">修改</asp:LinkButton>
                                                &nbsp; &nbsp;
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
                                            <asp:TextBox ID="txtIssue" runat="server"></asp:TextBox>
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
                                    <tr bgcolor="#F2F8FB" runat="server" visible="false" id="trjqh">
                                        <td class="bold" style="height: 26px">
                                            机球号:
                                        </td>
                                        <td style="height: 26px">
                                            <asp:RadioButtonList ID="rblMachineAndBall" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Selected="True" Value="1-1">1机1球</asp:ListItem>
                                                <asp:ListItem Value="1-2">1机2球</asp:ListItem>
                                                <asp:ListItem Value="2-1">2机1球</asp:ListItem>
                                                <asp:ListItem Value="2-2">2机2球</asp:ListItem>
                                            </asp:RadioButtonList></td>
                                    </tr>
                                    <tr bgcolor="#F2F8FB">
                                        <td class="bold" style="height: 26px">
                                            试机号:</td>
                                        <td style="height: 26px">
                                            <asp:TextBox ID="txtTestcode" runat="server" Height="20px" MaxLength="3" Width="100px"></asp:TextBox>（格式：123）</td>
                                    </tr>
                                    <tr bgcolor="#F2F8FB">
                                        <td class="bold">
                                            &nbsp;开奖号码:</td>
                                        <td>
                                            <asp:TextBox ID="txtCode" runat="server" Height="20px" MaxLength="3" Width="100px"></asp:TextBox>（格式：123）</td>
                                    </tr>
                                    <tr bgcolor="#F2F8FB">
                                        <td>
                                        </td>
                                        <td>
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
                        <tr bgcolor="#F3F3F3">
                            <td align="center" valign="middle" height="280px">
                                <asp:TextBox ID="TextBox1" runat="server" Height="260px" TextMode="MultiLine" Width="96%"></asp:TextBox></td>
                        </tr>
                    </table>
                </div>
                <cc1:FilteredTextBoxExtender ID="ftb1" runat="server" TargetControlID="txtCode" FilterType="Numbers">
                </cc1:FilteredTextBoxExtender>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtTestcode"
                    FilterType="Numbers">
                </cc1:FilteredTextBoxExtender>
            </div>
        </div>
    </form>
</body>
</html>
