<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Module_Manage.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.Module_Manage" %>

<html>
<head id="Head1" runat="server">
    <title>后台栏目信息</title>

    <script language="javascript" src="JScript/javascript.js" type="text/javascript"></script>

    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />

    <script language="javascript" type="text/javascript">
        function ParentChange(sender){            
            if(sender.value == "0"){                
                document.getElementById("txtUrl").disabled = true;
            }
            else{
                document.getElementById("txtUrl").disabled = false;
            }
        }
        

        function OpenEdite(TbName,PrimaryKey,ColName,ColName2,SortID,StrWhere,myWidth,myHeight)
        {
            var aa =''; 
            var result = window.open('PopFram/PublicSort.aspx?TbName='+TbName+'&PrimaryKey='+PrimaryKey+'&ColName='+ColName+'&ColName2='+ColName2+'&SortID='+SortID+'&StrWhere='+StrWhere+'', 'newwindow', 'height='+myHeight+', width='+myWidth+', top='+(screen.height-500)/2+',left='+(screen.width-800)/2+' toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, status=no');
            //,'','dialogHeight:800px;dialogWidth:600px;center:yes;help:no;resizable:no;scroll:yes;status:no; scrollbars:No;toolbar:no;menubar:no;location:no;' 
            if(aa == 'yes')
            {
            location.reload(); 
            }
        }
    </script>

</head>
<%--onload="GridViewColor();"--%>
<body>
    <form id="form1" runat="server">
        <div id="divOperator" runat="server" visible="false">
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
                                                <asp:Label ID="lblAction" runat="server"></asp:Label>模块</td>
                                            <td width="9%" align="right">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" align="center" cellpadding="2" cellspacing="1" bgcolor="#CED7F7">
                            <tr bgcolor="#F2F8FB">
                                <td class="bold" style="width: 317px">
                                    模块名称</td>
                                <td>
                                    <asp:TextBox ID="txtName" runat="server" MaxLength="50" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr bgcolor="#F2F8FB" class="bold">
                                <td style="width: 317px">
                                    模块地址</td>
                                <td align="left">
                                    <asp:TextBox ID="txtUrl" runat="server" MaxLength="500" Width="500px"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold" style="width: 317px">
                                    父分类</td>
                                <td>
                                    <asp:DropDownList ID="ddlParent" runat="server" DataTextField="Name" DataValueField="ID"
                                        Width="200px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr bgcolor="#f2f8fb">
                                <td class="bold" style="width: 317px">
                                    排序编号</td>
                                <td>
                                    <asp:TextBox ID="txtSortID" runat="server" MaxLength="5" Width="60px"></asp:TextBox>（非根类别指本类别内排序编号）</td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold" style="width: 317px">
                                    菜单显示</td>
                                <td>
                                    <asp:CheckBox ID="cbMenu" runat="server" /></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td colspan="2" align="center" style="height: 30px">
                                    <asp:Button ID="btn_Save" runat="server" CssClass="K2046_Button" Text="保存" OnClick="btn_Save_Click" />
                                    <asp:Button ID="btnCancel" runat="server" CssClass="K2046_Button" Text="取消" OnClick="btnCancel_Click" />
                                    <asp:HiddenField ID="hfID" runat="server" Value="0" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <div id="divList" runat="server">
            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#7694D2">
                <tr>
                    <td bgcolor="#F3F3F3">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="Right_bg1">
                                    <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                                        <tr>
                                            <td width="91%" align="left">
                                                模块管理</td>
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
                                    <a href="Module_Manage.aspx">模块管理</a> | <a href="#" onclick="OpenEdite('PBnet_Module','ID','Name','LinkUrl','Sort','and Depth=0','800','600')">
                                        模块显示排序</a> |
                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">新增模块</asp:LinkButton>
                                    |
                                    <asp:LinkButton ID="lblSortAll" runat="server" OnClick="lblSortAll_Click">生成整体排序字段</asp:LinkButton>
                                    <%--<a href="#" onclick="OpenEdite('PBnet_NewsType','IntNewsTypeID','VarTypeName','IntOrderID','IntSortID','')">
                                        主模块显示排序</a>--%>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#7694D2"
                class="MT">
                <tr>
                    <td bgcolor="#ffffff">
                        <asp:DataList ID="dlRoot" runat="server" Width="100%" ShowFooter="False" ShowHeader="False">
                            <HeaderTemplate>
                                <table width="100%" cellpadding="2" cellspacing="1" border="0" align="center" bgcolor="#7694D2">
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr bgcolor="#D2E4FF">
                                    <td>
                                        <table width="100%" cellpadding="0" cellspacing="0" border="0" align="center" background="images/admin_orderbg.jpg">
                                            <tr>
                                                <td style="width: 30%" height="25">
                                                    &nbsp;&nbsp;<b><%#Eval("Name")%></b>
                                                    <%# Eval("Depth").ToString() == "0" ? " <a href='#' onclick=\"OpenEdite('PBnet_Module','ID','Name','LinkUrl','Sort','and RootID=" + Eval("ID") + " and Depth>0 ','900','750')\" > 子模块排序</a>" : ""%>
                                                </td>
                                                <td style="width: 35%">
                                                    路径
                                                </td>
                                                <td style="width: 18%" align="center">
                                                    编号
                                                </td>
                                                <td style="width: 10%">
                                                    <asp:LinkButton ID="LinkButton" CommandArgument='<%# Eval("ID") %>' runat="server"
                                                        OnCommand="LinkButton_Command">编辑</asp:LinkButton>
                                                </td>
                                                <td style="width: 7%">
                                                    <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("ID") %>'
                                                        OnCommand="LinkButton2_Command">删除</asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr bgcolor="#ffffff">
                                    <td>
                                        <asp:DataList runat="server" ID="ChildDataList" GridLines="None" ShowFooter="False"
                                            ShowHeader="False" Width="100%" CellPadding="0" CellSpacing="0" Headerstyle-Font-Name="Arial"
                                            HeaderStyle-Font-Size="8" Font-Name="Arial" Font-Size="8" DataSource='<%# DataBinder.Eval(Container, "DataItem.myrelation") %>'>
                                            <HeaderTemplate>
                                                <table width="100%" cellpadding="2" cellspacing="1" border="0" align="center" bgcolor="#7694D2">
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr bgcolor="#ffffff">
                                                    <td style="width: 30%">
                                                        &nbsp;&nbsp;&nbsp;├─<%#Eval("Name")%>
                                                    </td>
                                                    <td style="width: 35%">
                                                        <%#Eval("URL")%>
                                                    </td>
                                                    <td style="width: 18%" align="center">
                                                        <%#Eval("Sort")%>
                                                    </td>
                                                    <td style="width: 10%">
                                                        <asp:LinkButton ID="LinkButton" CommandArgument='<%# Eval("ID") %>' runat="server"
                                                            OnCommand="LinkButton_Command">编辑</asp:LinkButton>
                                                    </td>
                                                    <td style="width: 7%">
                                                        <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("ID") %>'
                                                            OnCommand="LinkButton2_Command">删除</asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </table>
                                            </FooterTemplate>
                                        </asp:DataList>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:DataList>
                    </td>
                </tr>
            </table>
            <asp:ObjectDataSource ID="odsMaster" runat="server" SelectMethod="GetListBySort"
                TypeName="Pbzx.BLL.PBnet_Module"></asp:ObjectDataSource>
        </div>
    </form>
</body>
</html>
