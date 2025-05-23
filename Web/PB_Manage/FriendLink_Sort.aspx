<%@ Page Language="C#" AutoEventWireup="true" Codebehind="FriendLink_Sort.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.FriendLink_Sort" %>

<%@ Register Src="Controls/UcPrintLineSearch.ascx" TagName="UcPrintLineSearch" TagPrefix="uc2" %>
<%@ Register Src="Controls/UcFriendLink.ascx" TagName="UcFriendLink" TagPrefix="uc3" %>
<%@ Register Src="Controls/UcProductSearch.ascx" TagName="UcProductSearch" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html>
<head id="Head1" runat="server">
    <title>友情链接排序</title>
    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />
    <%--stylecss/Admin-darkgreen.css--%>

    <script language="javascript" src="JScript/javascript.js" type="text/javascript"></script>

    <style type="text/css">
<!--
.reorderCue {
	border:dashed thin black;
	width:100%;
	height:25px;
}
.itemArea {
	margin-left:15px;
	font-size:1em;
	text-align:left;
}
/*Reorder List*/
.dragHandle {
	width:100%;
	height:15px;
	background-color:Blue;
	background-image:url(images/bg-menu-main.png);
	cursor:move;
	border:outset thin white;
}
.dragHandle1 { margin: 0px 0px; padding: 0px; cursor: move; display: block; border: 1px solid #fff; width:100%;}
.callbackStyle {
	border:thin blue inset;		
}

.callbackStyle table {
	background-color:#5377A9;	
	color:Black;
}
-->
</style>

    <script type="text/javascript" language="javascript">
    function SetAll() {   
        var items = document.getElementsByName("tbI");   
    } 
    </script>

</head>
<body onload="SetAll();">
    <form id="form1" runat="server">
        <div>
            <%-- onclick="alert(document.getElementById('bd').style.width);"--%>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#7694D2">
                <tr>
                    <td bgcolor="#F3F3F3">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="Right_bg1">
                                    <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                                        <tr>
                                            <td width="91%" align="left">
                                                当前位置：友情链接息管理>>友情链接显示排序</td>
                                            <td width="9%" align="right">
                                               </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellspacing="0" cellpadding="4">
                            <tr>
                                <td align="CENTER">
                                    <a href="FriendLink_Manage.aspx">友情链接管理首页</a> | <a href="FriendLink_Editor.aspx">添加友情链接信息</a>&nbsp;
                                    | <a href="FriendLink_Sort.aspx">产品显示排序</a></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#E7A427"
                class="MT">
                <tr>
                    <td bgcolor="#F7FBFF" align="left">
                        <%--  <uc3:UcFriendLink ID="UcFriendLink2" runat="server" ReUrl="FriendLink_Sort.aspx" />--%>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
                class="MT">
                <tr bgcolor="#ffffff">
                    <td>
                        <asp:UpdatePanel ID="UpLinks" runat="server">
                            <ContentTemplate>
                                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                    <tr align="center">
                                        <td class="menu_b" width="10%">
                                            位置序号
                                        </td>
                                        <td class="menu_b" width="10%">
                                            链接类型
                                        </td>
                                        <td class="menu_b" width="25%">
                                            站点名称
                                        </td>
                                        <td class="menu_b" width="20%">
                                            站点URL
                                        </td>
                                        <td class="menu_b" width="15%">
                                            是否审核
                                        </td>
                                        <td class="menu_b" width="20%">
                                            更新时间
                                        </td>
                                    </tr>
                                </table>
                                <cc1:ReorderList ID="ReorderList1" runat="server" PostBackOnReorder="true" DataSourceID="ObjDCProduct"
                                    CallbackCssStyle="callbackStyle" DataKeyField="IntID" SortOrderField="SortOrder"
                                    AllowReorder="True">
                                    <ItemTemplate>
                                        <div class="itemArea">
                                        </div>
                                    </ItemTemplate>
                                    <ReorderTemplate>
                                        <div class="reorderCue">
                                            鼠标松开 放在此位置！
                                        </div>
                                    </ReorderTemplate>
                                    <DragHandleTemplate>
                                        <div class="dragHandle1" name="dvN" onmouseover="this.style.backgroundColor='E4E8EF'"
                                            onmouseout="this.style.backgroundColor=''">
                                            <table id="tbI" runat="server" style="border: 1px; border-style: solid; width: 750"
                                                cellpadding="0" cellspacing="0">
                                                <tr align="center" title="用鼠标拖动此行，改变位置将重新排序！">
                                                    <td width="10%">
                                                        <%#Eval("SortOrder")%>
                                                    </td>
                                                    <td width="25%">
                                                        <asp:Label ID="Label2" runat="server" Text='<%# Pbzx.Common.Method.GetLinksType(Eval("IntLinkType"))%>' />
                                                    </td>
                                                    <td width="10%">
                                                        <asp:Label ID="Label3" runat="server" Text='<%# HttpUtility.HtmlEncode(Convert.ToString(Eval("IntSiteName"))) %>' />
                                                    </td>
                                                    <td width="20%">
                                                        <asp:Label ID="Label4" runat="server" Text='<%#Eval("NteSiteUrl") %>' />
                                                    </td>
                                                    <td width="15%">
                                                        <%# Convert.ToBoolean(Eval("BitIsOK")) ? "已审核" : "未审核"%>
                                                    </td>
                                                    <td width="20%">
                                                        <%#Eval("ModifyTime","{0:yyyy-MM-dd}")%>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </DragHandleTemplate>
                                </cc1:ReorderList>
                                <asp:ObjectDataSource ID="ObjDCProduct" runat="server" DataObjectTypeName="Pbzx.Model.PBnet_Links"
                                    SelectMethod="GetProductListSort" TypeName="Pbzx.BLL.PBnet_Links" UpdateMethod="Update">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="" Name="strWhere" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
