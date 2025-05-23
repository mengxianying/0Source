<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcProductTop.ascx.cs"
    Inherits="Pbzx.Web.Contorls.UcProductTop" %>
<table width="97%" border="0" cellspacing="0" cellpadding="4" align="center">
  <tr>
    <td class="xia_line">
    <asp:DataList ID="dlProductTop" runat="server" RepeatColumns="2" RepeatDirection="Horizontal">
        <ItemTemplate>
            <table width="100%" border="0" cellspacing="0" cellpadding="6">
                <tr>
                    <td width="140" align="center">
                        <img src='<%#Eval("pb_SoftPicUrl")%>' width="130" height="97" hspace="0" vspace="0"
                            alt="" /></td>
                    <td width="212">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td align="left">
                                    <a href="Soft_explain.aspx?ID=<%#Pbzx.Common.Input.Encrypt(Eval("pb_SoftID").ToString()) %>">
                                        <%#Eval("pb_SoftName")%>
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    版本：<%#Eval("pb_SoftVersion")%></td>
                            </tr>
                            <tr>
                                <td align="left">
                                    等级：<img border="0" src="/images/Web/star<%#Eval("pb_Stars") %>.gif" alt="星" /></td>
                            </tr>
                            <tr>
                                <td align="left">
<!--                                    价格：<span class="S_zi3">￥<%#Eval("pb_DemoUrl")%>&nbsp;￥<%#Eval("pb_RegUrl")%></span></td>
-->                                    价格：<span class="S_zi3">￥<%#Eval("pb_DemoUrl")%>&nbsp;</span></td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <a href='addtoshoppingcart.aspx?productID=<%#Eval("pb_SoftID") %>'>
                                        <img alt='购买' src='/Images/Web/buy_btn.jpg' align='middle' border='0' /></a>&nbsp;<a
                                            href="/UserCenter/AddToFavorites.aspx?productID=<%#Eval("pb_SoftID") %>&classId=<%#Eval("pb_ClassID") %>"><img
                                                src="/Images/Web/collection_btn.jpg" border="0" align="middle" alt="收藏" /></a></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
</td>
  </tr>
</table>