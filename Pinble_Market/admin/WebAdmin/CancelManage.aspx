<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CancelManage.aspx.cs" Inherits="Pinble_Market.admin.WebAdmin.CancelManage" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>退订管理</title>
    <link type="text/css" rel="stylesheet" href="../../Css/css.css" />
    <link href="../../Css/head.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../../JS/GridView.js"></script>
    <link href="../../Css/start/jquery-ui-1.7.2.custom.css" rel="stylesheet" type="text/css" />

</head>
<body onload="GridViewColor();">
    <form id="form1" runat="server">
        &nbsp;<div style=" margin-top:5px; margin-bottom:5px;">
        <asp:GridView ID="myGridView" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" CellPadding="3" BackColor="#97BEE7" CellSpacing="1" GridLines="None" Width="99%"  BorderStyle="Solid" AllowPaging="True" OnRowCreated="myGridView_RowCreated" OnRowDeleting="myGridView_RowDeleting" OnRowDataBound="myGridView_RowDataBound">
            <Columns>
                <asp:BoundField HeaderText="序号" />
                <asp:TemplateField HeaderText="申请人">
                <ItemTemplate>
                <%# Eval("CancelName")%>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="退订项目">
                 <ItemTemplate>
                     <asp:Label ID="lab_item" runat="server"></asp:Label>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="退订理由">
                <ItemStyle HorizontalAlign="Left" />
                    <ItemTemplate>
                        <%# Eval("Other") %>
                      说明：<font color='red'>  <%#Pbzx.Common.Input.GetSubString(Eval("CancelSake").ToString(),20)%></font>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="申请时间">
                 <ItemTemplate>
                    <%# Eval("CTime") %>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="状态">
                 <ItemTemplate>
                     <asp:Label ID="lab_state" runat="server"></asp:Label>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="批准时间">
                 <ItemTemplate>
                    
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="查看">
                    <ItemTemplate>
                            
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtn_cancel" runat="server" CommandArgument="<%# Eval("CancelItem") %>">退款</asp:LinkButton> <asp:LinkButton
                            ID="lbtn_Annul" runat="server" CommandArgument="<%# Eval("CancelItem") %>">驳回</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowDeleteButton="True" HeaderText="删除" />
                  
            </Columns>
            <HeaderStyle Font-Bold="True" CssClass="form"/>
        </asp:GridView>
          <table cellpadding="0" cellspacing="0" border="0" width="98%">
                    <tr>
                        <td> 
                            
                            <asp:Literal ID="litContent" runat="server"></asp:Literal>
                            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                            FirstPageText="第一页" LastPageText="最后一页" NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged"
                            PrevPageText="上一页" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                            Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                            CustomInfoSectionWidth="35%" HorizontalAlign="Center">
                            </webdiyer:AspNetPager>
                            
                            </td>
                    </tr>
           </table>
                
    </div>
    </form>
</body>
</html>
