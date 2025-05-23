<%@ Page Language="C#" AutoEventWireup="true" Codebehind="CL_PrintLine_Hao.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.CST.CL_PrintLine_Hao" %>

<html>
<head runat="server">
    <title>修改打印线信息</title>
    <link type="text/css" rel="stylesheet" href="../stylecss/css.css" />
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
                                                当前位置：修改打印线信息</td>
                                            <td width="9%" align="right">
                                                </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" cellpadding="2" cellspacing="1" bgcolor="#CED7F7">
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    序列号:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblSN" runat="server"></asp:Label></td>
                                <td class="bold" style="width: 130px">
                                    入库时间:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblAcceptTime" runat="server"></asp:Label></td>
                            </tr>
                              <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    创建时间:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblCreateTime" runat="server"></asp:Label></td>
                                <td class="bold" style="width: 130px">
                                    入库者:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblAccepter" runat="server"></asp:Label></td>
                            </tr>
                                    
                                      <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    创建者:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblCreator" runat="server"></asp:Label></td>
                                <td class="bold" style="width: 130px">
                                    销售时间:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblSellTime" runat="server"></asp:Label></td>
                            </tr>
                              <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    状态:</td>
                                <td>
                                    &nbsp;<asp:DropDownList ID="ddlStatus" runat="server">
                                        <asp:ListItem Value="0">新创建</asp:ListItem>
                                        <asp:ListItem Value="1">已入库</asp:ListItem>
                                        <asp:ListItem Value="2">已销售</asp:ListItem>
                                        <asp:ListItem Value="3">已丢失</asp:ListItem>
                                        <asp:ListItem Value="4">已损坏</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td class="bold" style="width: 130px">
                                    销售者:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblSeller" runat="server"></asp:Label></td>
                            </tr>
                                      <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    类型:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblType" runat="server"></asp:Label></td>
                                <td class="bold" style="width: 130px">
                                    </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                                      <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    类型备注信息 :</td>
                                <td colspan="3">
                                    &nbsp;<asp:TextBox ID="txtRemarks" runat="server" Rows="7" TextMode="MultiLine" Width="500px"></asp:TextBox></td>
                          
                            </tr>
                              <tr bgcolor="#F2F8FB">
                                <td>
                                    </td>
                                <td colspan="3">
                               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btn_add" runat="server" Text="确定" OnClick="btn_add_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btn_reset" runat="server" Text="取消" OnClick="btn_reset_Click" /></td>
                            </tr>
                         
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
