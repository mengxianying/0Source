<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Agent_menu.ascx.cs"
    Inherits="Pbzx.Web.Contorls.Agent_menu" %>
<%@ Import Namespace="Pbzx.Common" %>

<script type="text/javascript" language="javascript" src="/javascript/SearchAjax.js"></script>

<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td class="A_lbg1">
            ����ר��</td>
    </tr>
</table>
<table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#CCCCCC">
    <tr>
        <td align="center" bgcolor="#FFFFFF">
            <table width="152" border="0" cellspacing="6" cellpadding="0">
                <tr>
                    <td class="A_menu brokerhang" style="width: 140px; padding-left: 17px;" valign="bottom">
                        <a href="/Agent.aspx">�������б� </a>
                    </td>
                </tr>
                <asp:Repeater ID="rptClass" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td class="A_menu brokerhang" style="width: 140px; padding-left: 17px;" valign="bottom">
                                <a href="/Agent_Content.aspx?ID=<%#Input.Encrypt(Eval("ID").ToString()) %>">
                                    <%#Eval("Purpose")%>
                                </a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td class="A_menu brokerhang" style="width: 140px; padding-left: 17px;" valign="bottom">
                        <a href="#" onclick="CheckIsDaili();" style="cursor: pointer;">���������� </a>
                    </td>
                    <%--href="/UserCenter/shengqing.aspx"--%>
                </tr>
            </table>
        </td>
    </tr>
</table>
<table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC"
    class="MT6">
    <tr>
        <td bgcolor="#FFFFFF">
            <img src="/Images/Web/ad_xuzhi.jpg" width="158" height="118" /></td>
    </tr>
    <tr>
        <td bgcolor="#FFFFFF">
            <table width="100%" border="0" cellpadding="3" cellspacing="1" bgcolor="#FFFFFF">
                <tr>
                    <td align="left" bgcolor="#F2F8FD" style="height: 68px">
                        &nbsp;&nbsp;�������û�д�������ҹ�˾�г��ƹ㲿��ϵ��<br />
                        <font color="#115599">�绰��010-62132803<br />
                            &nbsp;&nbsp;QQ��<a target="blank" href="tencent://message/?uin=524669918&Site=www.pinble.com&Menu=yes">524669918</a><br />
                             EMAIL��service@pinble.com
                        </font></td>
                </tr>
            </table>
        </td>
    </tr>
</table>
