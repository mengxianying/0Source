<%@ Page Language="C#" AutoEventWireup="true" Codebehind="KJInfo_Manage.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.KJInfo_Manage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="Pbzx.Common" %>
<html>
<head runat="server">
    <title>开奖信息管理</title>
    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />

    <script language="javascript" src="JScript/javascript.js" type="text/javascript"></script>

    <script type="text/javascript">
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager2" runat="server">
            </asp:ScriptManager>
            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#7694D2">
                <tr>
                    <td bgcolor="#F3F3F3">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="Right_bg1">
                                    <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                                        <tr>
                                            <td width="7%" style="height: 20px">
                                            </td>
                                            <td width="65%" align="center" style="height: 20px">
                                                <a href="KJInfo_Manage.aspx" class="zilan">管理首页</a>&nbsp;|&nbsp;
                                                <asp:LinkButton ID="lbtnUpdateIndex"
                                                    runat="server" ForeColor="White" OnClick="lbtnUpdateIndex_Click">更新全部</asp:LinkButton>&nbsp;|&nbsp;<asp:LinkButton ID="lbtnQG"
                                                    runat="server" ForeColor="White" OnClick="lbtnQG_Click">更新全国</asp:LinkButton>&nbsp;|&nbsp;<asp:LinkButton ID="lbtnGS"
                                                    runat="server" ForeColor="White" OnClick="lbtnGS_Click">更新各省</asp:LinkButton>&nbsp;&nbsp;|&nbsp;<asp:LinkButton ID="lbtnGP"
                                                    runat="server" ForeColor="White" OnClick="lbtnGP_Click">更新高频</asp:LinkButton>&nbsp;</td>
                                            <td id="jnkcsh" width="28%" align="center" style="height: 20px">

                                                <script type="text/javascript">setInterval("jnkcsh.innerHTML=new Date().toLocaleString()+' 星期'+'日一二三四五六'.charAt(new Date().getDay());",1000);
                                                </script>

                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" cellpadding="2" cellspacing="1" bgcolor="#CED7F7">
                            <tr bgcolor="#F2F8FB">
                                <td valign="top">
                                    <asp:Repeater ID="rptCpBigSort" runat="server">
                                        <ItemTemplate>
                                            <table width="100%" cellpadding="1" cellspacing="1" border="0">
                                                <tr style="line-height: 24px;">
                                                    <td width="9%" align="left" class="bold" valign="top">
                                                        <asp:Label ID="lblClass" runat="server" Text='<%# Eval("NvarClass") %>'></asp:Label>&nbsp;
                                                    </td>
                                                    <td  width="91%">
                                                        <%#FormartClass(Eval("NvarClass"))%>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="0" cellspacing="1" class="MT">
                <tr>
                    <td>
                        <div id="divFrame" style="background-color: #AFDAF0">
                            <iframe frameborder="0" src="" id="ShowPage1" name="ShowPage1" scrolling="no" noresize="noresize" marginwidth="0" marginheight="0" border="no"
                                style="width: 100%, OVERFLOW:SCROLL; overflow-y: HIDDEN,OVERFLOW:SCROLL; overflow-x: HIDDEN;"
                                height="550" width="100%"></iframe>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
