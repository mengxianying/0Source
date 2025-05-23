<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Soft_Sort.aspx.cs" Inherits="Pbzx.Web.PB_Manage.Soft_Sort" %>

<%@ Register Src="Controls/UcProductSearch.ascx" TagName="UcProductSearch" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html>
<head id="Head1" runat="server">
    <title>资源排序</title>
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
        //alert(items.length); 
        //for (var j=0; j<items.length; j++) {        
        //    items[j].style.width = "900";   
        //}   
    } 
    </script>

</head>
<body onload="SetAll();">
    <%-- id='bd' onload="setWidth()"--%>
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
                                                当前位置：软件信息管理>>资源显示排序</td>
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
                                    <a href="Soft_Manage.aspx">资源管理首页</a> | <a href="Soft_Editor.aspx">添加资源信息</a>&nbsp;
                                    | <a href="Soft_Sort.aspx">资源显示排序</a> | <a href="SoftDeleted.aspx">资源回收站</a>|
                                    <asp:LinkButton ID="lbtnCreate" runat="server" Text="更新首页商品" OnClick="lbtnCreate_Click"></asp:LinkButton></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#E7A427"
                class="MT">
                <tr>
                    <td bgcolor="#F7FBFF" align="left">
                        <uc1:UcProductSearch ID="UcProductSearch1" Url="ProductReorderList.aspx" runat="server" />
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
                class="MT">
                <tr bgcolor="#ffffff">
                    <td>
                        <asp:UpdatePanel ID="UpProduct" runat="server">
                            <ContentTemplate>
                                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                    <tr align="center">
                                        <td class="menu_b" width="10%">
                                            位置序号
                                        </td>
                                        <td class="menu_b" width="25%">
                                            名称
                                        </td>
                                        <td class="menu_b" width="10%">
                                            版本
                                        </td>
                                        <td class="menu_b" width="20%">
                                            类别
                                        </td>
                                        <td class="menu_b" width="15%">
                                            软件大小
                                        </td>
                                        <td class="menu_b" width="20%">
                                            更新时间
                                        </td>
                                    </tr>
                                </table>
                                <cc1:ReorderList ID="ReorderList1" runat="server" PostBackOnReorder="true" DataSourceID="ObjDCProduct"
                                    CallbackCssStyle="callbackStyle" DataKeyField="PBnet_SoftID" SortOrderField="countid"
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
                                                        <%#Eval("countid")%>
                                                    </td>
                                                    <td width="25%">
                                                        <asp:Label ID="Label2" runat="server" Text='<%# HttpUtility.HtmlEncode(Convert.ToString(Eval("pb_SoftName"))) %>' />
                                                    </td>
                                                    <td width="10%">
                                                        <asp:Label ID="Label3" runat="server" Text='<%# HttpUtility.HtmlEncode(Convert.ToString(Eval("pb_SoftVersion"))) %>' />
                                                    </td>
                                                    <td width="20%">
                                                        <asp:Label ID="Label4" runat="server" Text='<%# HttpUtility.HtmlEncode(Pbzx.BLL.PBnet_SoftClass.GetNameByID(int.Parse(Eval("pb_ClassID").ToString()))) %>' />
                                                    </td>
                                                    <td width="15%">
                                                        <%#Eval("pb_SoftSize") %>
                                                        KB
                                                    </td>
                                                    <td width="20%">
                                                        <%#Eval("pb_UpdateTime")%>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </DragHandleTemplate>
                                </cc1:ReorderList>
                                <asp:ObjectDataSource ID="ObjDCProduct" runat="server" DataObjectTypeName="Pbzx.Model.PBnet_Soft"
                                    SelectMethod="GetProductListSort" TypeName="Pbzx.BLL.PBnet_Soft" UpdateMethod="Update">
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
