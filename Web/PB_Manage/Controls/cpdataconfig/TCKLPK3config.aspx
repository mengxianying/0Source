<%@ Page Language="C#" AutoEventWireup="true" Codebehind="TCKLPK3config.aspx.cs" Inherits="Pbzx.Web.PB_Manage.Controls.cpdataconfig.TCKLPK3config" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Import Namespace="Pbzx.Common" %>
<html>
<head id="Head1" runat="server">
    <title></title>
    <link type="text/css" rel="stylesheet" href="../../StyleCss/StyleCss.css" />

    <script type="text/javascript" language="javascript" src="../../JScript/javascript.js"></script>

</head>
<body  onload="GridViewColor();">
    <form id="form1" runat="server">
        <div style="width: 100%;">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <div style="width: 100%;">
                <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
                    align='center'>
                    <tr bgcolor="#F3F3F3">
                        <td height='22' align='center'>
                            <asp:Label ID="lblLinkAdd" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="Right_bg2">
                            <table width="95%" border="0" cellspacing="2" cellpadding="0" align="center">
                                <tr>
                                    <td align="left">
                                        <asp:Button ID="btnDivAdd" runat="server" Text="添加新的开奖信息" OnClick="btnDivAdd_Click" />
                                    </td>
                                    <td align="center">
                                        <asp:Button ID="btnBatchAdd" runat="server" Text="批量添加开奖信息" OnClick="btnBatchAdd_Click" />
                                    </td>
                                    <td align="right">
                                        <asp:Button ID="btnDel" runat="server" Text="删除最近开奖日期" OnClick="btnDel_Click" OnClientClick="return confirm('你确定要删除吗?');" />
                                    </td>
                                    <td align="right">
                                       <%-- <asp:Button ID="btnList" runat="server" Text="返回" OnClick="btnList_Click" />--%>
                                       期号：<asp:TextBox ID="txt_Condition" runat="server"></asp:TextBox>&nbsp;

                                        <asp:Button ID="Search" runat="server" Text="搜索" onclick="Search_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <div runat="server" id="divList" visible="true" style="position:absolute; width:100%; height:398px; overflow-y:scroll">
                    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#7694D2">
                        <tr bgcolor="#F3F3F3">
                            <td>
                                <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="GridView_Table" 
                                    CellPadding="0">
                                    <Columns>
                                        <asp:TemplateField HeaderText="开奖日期" SortExpression="date">
                                            <ItemStyle Width="17%" />
                                            <ItemTemplate>
                                                <%# Eval("date", "{0:yyyy-MM-dd HH:mm:ss}")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="开奖期号" SortExpression="issue">
                                            <ItemStyle Width="13%" />
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("issue") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="开奖号码" SortExpression="redcode">
                                            <ItemStyle Width="14%" />
                                            <ItemTemplate>
                                                <font color="#FF0000">
                                                    <%# string.IsNullOrEmpty(Eval("code").ToString())? "未输入" : Eval("code")%>
                                                </font>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="最近修改时间" SortExpression="LastModifyTime">
                                            <ItemStyle Width="19%" />
                                            <ItemTemplate>
                                                <%# Eval("LastModifyTime", "{0:yyyy-MM-dd HH:mm:ss}")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="录入员IP" SortExpression="OpIp">
                                            <ItemStyle Width="14%" />
                                            <ItemTemplate>
                                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("OpIp") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="录入员" SortExpression="OpName">
                                            <ItemStyle Width="13%" />
                                            <ItemTemplate>
                                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("OpName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="操作">
                                            <ItemStyle Width="10%" />
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtnUpdate" runat="server" OnClientClick="changeTab(1)" CommandArgument='<%# Eval("issue") %>'
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
                                            <asp:TextBox ID="txtIssue" MaxLength="8" runat="server"></asp:TextBox>
                                            （格式：14050931）</td>
                                    </tr>
                                    <tr bgcolor="#F2F8FB">
                                        <td class="bold">
                                            开奖日期:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDate" runat="server" MaxLength="20"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr bgcolor="#F2F8FB">
                                        <td class="bold">
                                            开奖号码:</td>
                                        <td>
                                            <asp:TextBox ID="txtcode" runat="server" Height="20px" MaxLength="6" Width="149px"
                                                onkeyup='this.value=this.value.toLocaleUpperCase()'></asp:TextBox>（<span style="color: #ff0000">注意：长度6位.数据中的10要输入T，如格式：4T1235</span>）</td>
                                    </tr>
                                    <tr bgcolor="#F2F8FB">
                                        <td>
                                        </td>
                                        <td class="forumRow">
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="btnSave" runat="server" Text="添加" OnClick="btnSave_Click" />&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="btnClear" runat="server" Text="返回" OnClick="btnClear_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" class="forumRow" colspan="2">
                                            临时剪贴编辑器（<font color="#ff0000">注意：本窗口的内容仅做临时剪贴使用，信息不保存）</font></td>
                                    </tr>
                                    <tr>
                                        <td align="center" class="forumRow" colspan="2">
                                            <asp:TextBox ID="TextBox2" runat="server" Height="260px" TextMode="MultiLine" Width="96%"></asp:TextBox></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="divBatchAdd" runat="server" visible="false">
                    <table style="width: 100%">
                        <tr>
                            <td align="center" class="forumRow" colspan="2">
                                批量数据录入（<font color="#ff0000">一期数据为一行，前面期号后面奖号。如：14050932 4T1235）</font></td>
                        </tr>
                        <tr>
                            <td align="center" class="forumRow" colspan="2">
                                <asp:TextBox ID="txtBatch" runat="server" Height="260px" TextMode="MultiLine" Width="96%"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="center" class="forumRow" colspan="2">
                                <asp:Button ID="batchOK" runat="server" Text="添加" OnClick="batchOK_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <cc1:FilteredTextBoxExtender ID="ftb1" runat="server" TargetControlID="txtcode" FilterType="Custom"
                    ValidChars="123456789ATJQKatjqk">
                </cc1:FilteredTextBoxExtender>
                <cc1:FilteredTextBoxExtender ID="ftbe" runat="server" TargetControlID="txtBatch"
                    FilterType="Custom" ValidChars="0123456789ATJQKatjqk        
">
                </cc1:FilteredTextBoxExtender>
            </div>
            <asp:HiddenField ID="hfNewsID" runat="server" Value="0" />
        </div>
    </form>
</body>
</html>
