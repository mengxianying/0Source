<%@ Page Language="C#" AutoEventWireup="true" Codebehind="KJCpSort_Order.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.KJCpSort_Order" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html>
<head id="Head1" runat="server">
    <title>开奖彩种排序</title>
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
	width:100x;
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
</head>
<body>
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
                                                当前位置：彩种信息管理>>彩种显示排序</td>
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
                                    <a href="KJCpSort_Manage.aspx">管理彩种首页</a> | <a href="KJCpSort_Editor.aspx">增加彩种</a>
                                    | <a href="KJCpSort_Order.aspx">彩种显示排序</a></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
                class="MT">
                <tr bgcolor="#ffffff">
                    <td>
                        <asp:UpdatePanel ID="UpSortOrder" runat="server">
                            <ContentTemplate>
                                <cc1:ReorderList ID="ReorderList1" runat="server" PostBackOnReorder="true" DataSourceID="ObjDCProduct"
                                    CallbackCssStyle="callbackStyle" DataKeyField="IntId" SortOrderField="NvarOrderId"
                                    AllowReorder="True" Width="100%">
                                    <EmptyListTemplate>
                                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                            <tr align="center">
                                                <td style="width: 10%" class="menu_b">
                                                    位置序号
                                                </td>
                                                <td style="width: 25%;" class="menu_b">
                                                    彩种名称
                                                </td>
                                                <td style="width: 18%;" class="menu_b">
                                                    所属类别
                                                </td>
                                                <td style="width: 10%;" class="menu_b">
                                                    App名称
                                                </td>
                                                <td style="width: 10%;" class="menu_b">
                                                    开奖日期
                                                </td>
                                                <td style="width: 27%;" class="menu_b">
                                                    开奖信息页面
                                                </td>
                                            </tr>
                                        </table>
                                    </EmptyListTemplate>
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
                                        <div class="dragHandle1" onmouseover="this.style.backgroundColor='E4E8EF'" onmouseout="this.style.backgroundColor=''">
                                            <table width="740" style="border: 1px; border-style: solid;" cellpadding="0" cellspacing="0">
                                                <tr align="center" title="用鼠标拖动此行，改变位置将重新排序！">
                                                    <td style="width: 10%;">
                                                        <%#Eval("NvarOrderId")%>
                                                    </td>
                                                    <td style="width: 25%;">
                                                        <%#Eval("NvarName")%>
                                                    </td>
                                                    <td style="width: 18%;">
                                                        <%# Eval("NvarClass")%>
                                                    </td>
                                                    <td style="width: 10%;">
                                                        <%# Eval("NvarApp_name")%>
                                                    </td>
                                                    <td style="width: 10%;">
                                                        <%#Eval("NvarLott_date")%>
                                                        KB
                                                    </td>
                                                    <td style="width: 27%;">
                                                        <%#Eval("Url")%>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </DragHandleTemplate>
                                    <EmptyListTemplate>
                                    </EmptyListTemplate>
                                </cc1:ReorderList>
                                <asp:ObjectDataSource ID="ObjDCProduct" runat="server" DataObjectTypeName="Pbzx.Model.PBnet_LotteryMenu"
                                    SelectMethod="GetProductListSort" TypeName="Pbzx.BLL.PBnet_LotteryMenu" UpdateMethod="Update">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue=" 1=1 order by intclass_orderId,nvarclass " Name="strWhere"
                                            Type="String" />
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
