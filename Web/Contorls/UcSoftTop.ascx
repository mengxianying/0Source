<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcSoftTop.ascx.cs" Inherits="Pbzx.Web.Contorls.UcSoftTop" %>
<table width="97%" border="0" cellspacing="0" cellpadding="4" align="center">
    <tr>
        <td class="xia_line">
            <asp:DataList ID="dlProductTop" runat="server" RepeatColumns="2" RepeatDirection="Horizontal">
                <ItemTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="6">
                        <tr>
                            <td width="130" align="center">
                                <img src='<%#Eval("PBnet_SoftPicUrl")%>' width="130" height="93" hspace="0" vspace="0"
                                    alt="" /></td>
                            <td width="230">
                                <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                    <tr>
                                        <td align="left">
                                            <a href="Source_explain.aspx?ID=<%#Pbzx.Common.Input.Encrypt(Eval("PBnet_SoftID").ToString()) %>">
                                                <%#Eval("PBnet_SoftName")%>
                                            </a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            版本：<%#Eval("PBnet_SoftVersion")%></td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            等级：<img border="0" src="/images/Web/star<%#Eval("pb_Stars") %>.gif" alt="星" /></td>
                                    </tr>
                                    <%--  <tr>
                                        <td align="left">
                                            价格：<span class="S_zi3">￥<%#Eval("pb_DemoUrl")%>&nbsp;￥<%#Eval("pb_RegUrl")%></span></td>
                                    </tr>--%>
                                    <tr>
                                        <td align="left">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="20%">
                                                        下载：</td>
                                                    <td width="7%">
                                                        <img src="/images/Web/download1.gif" width="12" height="12" alt="" /></td>
                                                    <td width="33%" align="left">
                                                        <a href='<%# Pbzx.Common.WebInit.webBaseConfig.WebUrl +"SoftDownLoad.aspx?id="+ Eval("PBnet_SoftID")+"&reUrl=1" %>'>
                                                            北方联通</a></td>
                                                    <td width="7%">
                                                        <img src="/images/Web/download1.gif" width="12" height="12" alt="" /></td>
                                                    <td width="33%" align="left">
                                                        <a href='<%# Pbzx.Common.WebInit.webBaseConfig.WebUrl +"SoftDownLoad.aspx?id="+ Eval("PBnet_SoftID")+"&reUrl=1" %>'>
                                                            南方电信</a></td>
                                                </tr>
                                            </table>
                                        </td>
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
