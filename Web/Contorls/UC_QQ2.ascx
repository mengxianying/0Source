<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_QQ2.ascx.cs" Inherits="Pbzx.Web.Contorls.UC_QQ2" %>
 <asp:DataList ID="dtQq" runat="server" Width="100%">
            <HeaderTemplate>
            </HeaderTemplate>
            <ItemTemplate>
                <table width="96%" border="0" cellspacing="0" align="center"  cellpadding="1">
                    <tr>
                        <td align="right" width="45%" class="QQ_zi">
                            <font color="#003399">
                                <%# Eval("Team")%>
                            </font></td>
                        <td align="left" width="55%">
                            <%# Eval("Tel")%>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="QQ_zi">
                            QQ：</td>
                        <td align="left">
                            <a href="tencent://message/?uin=<%# Eval("VarQQNumber")%>&Site=www.pinble.com&Menu=yes">
                                <img src='http://wpa.qq.com/pa?p=1:<%# Eval("VarQQNumber")%>:8' border="0" alt="点击这里给我发消息" /></a></td>
                    </tr>
                </table>
            </ItemTemplate>
            <FooterTemplate>
            </FooterTemplate>
        </asp:DataList>