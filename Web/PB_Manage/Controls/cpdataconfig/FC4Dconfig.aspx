<%@ Page Language="C#" AutoEventWireup="true" Codebehind="FC4Dconfig.aspx.cs" Inherits="Pbzx.Web.PB_Manage.Controls.cpdataconfig.FC4Dconfig" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html>
<head runat="server">
    <title>上海4D开奖信息管理</title>
    <link type="text/css" rel="stylesheet" href="../../StyleCss/StyleCss.css" />

    <script src="../../JScript/javascript.js" type="text/javascript"></script>

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
                    <table width="95%" border="0" cellspacing="0" cellpadding="0" align="center">
                        <tr>
                            <td align="left">
                                <asp:Button ID="btnDivAdd" runat="server" Text="添加新的开奖信息" OnClick="btnDivAdd_Click" />
                            </td>
                            <td align="right">
                                <asp:Button ID="btnDel" runat="server" Text="删除最近开奖日期" OnClick="btnDel_Click" OnClientClick="return confirm('你确定要删除吗?');" />
                            </td>
                            <td align="right">
                                <%--<input type="button" value="返回" onclick="history.back(1)" style="width: 62px; height: 23px;" />--%>
                                期号：<asp:TextBox ID="txt_Condition" runat="server" Width="100px"></asp:TextBox>&nbsp;

                                        <asp:Button ID="Search" runat="server" Text="搜索" onclick="Search_Click" />
                            </td>
                        </tr>
                    </table>
                    <div style="position:absolute; width:100%; height:398px; overflow-y:scroll">
                    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#7694D2">
                        <tr bgcolor="#F3F3F3">
                            <td>
                                <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" BorderStyle="Solid"
                                    CellPadding="0" Width="100%" DataKeyNames="issue" CssClass="GridView_Table" PageSize="15">
                                    <Columns>
                                        <asp:TemplateField HeaderText="开奖日期" SortExpression="date">
                                            <ItemStyle Width="15%" />
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
                                        <asp:TemplateField HeaderText="上海4D开奖号码" SortExpression="code">
                                            <ItemStyle Width="12%" />
                                            <ItemTemplate>
                                                <font color="#990033">
                                                    <%#Eval("code")%>
                                                </font>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="最近修改日期" SortExpression="LastModifytime">
                                            <ItemStyle Width="16%" />
                                            <ItemTemplate>
                                                <%# Eval("LastModifyTime", "{0:yyyy-MM-dd HH:mm:ss}")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="录入员IP" SortExpression="OpIp">
                                            <ItemStyle Width="10%" />
                                            <ItemTemplate>
                                                <a href='#' title='<%#GetIp(Eval("OpIp"))%>'>
                                                    <%#Eval("OpIp") %>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="录入员" SortExpression="OpName">
                                            <ItemStyle Width="9%" />
                                            <ItemTemplate>
                                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("OpName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="操作">
                                            <ItemStyle Width="8%" />
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
                                            开奖期号：
                                        </td>
                                        <td width="75%">
                                            <asp:TextBox ID="txtIssue" MaxLength="7" runat="server"></asp:TextBox>
                                            （<asp:Label ID="lblIssue" runat="server"></asp:Label>）</td>
                                    </tr>
                                    <tr bgcolor="#F2F8FB">
                                        <td class="bold">
                                            开奖日期：
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDate" runat="server" MaxLength="10"></asp:TextBox>
                                            （格式：2006-6-8）</td>
                                    </tr>
                                    <tr bgcolor="#F2F8FB">
                                        <td class="bold">
                                            开奖号码：
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCode" MaxLength="4" runat="server"></asp:TextBox>
                                            （<asp:Label ID="lblFW" runat="server"></asp:Label>
                                            &nbsp;
                                            <asp:Label ID="lblCodeFW" runat="server"></asp:Label>）</td>
                                    </tr>
                                    <tr bgcolor="#F2F8FB">
                                        <td>
                                        </td>
                                        <td class="forumRow">
                                            &nbsp;&nbsp;<asp:Button ID="btnSave" runat="server" Text="添加" OnClick="btnSave_Click" />&nbsp;&nbsp;
                                            &nbsp;
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
                <asp:HiddenField ID="hfNewsID" runat="server" Value="0" />
                <br />
                <cc1:FilteredTextBoxExtender ID="ftb1" runat="server" TargetControlID="txtCode" FilterType="Numbers">
                </cc1:FilteredTextBoxExtender>
            </div>
        </div>
    </form>
</body>
</html>
