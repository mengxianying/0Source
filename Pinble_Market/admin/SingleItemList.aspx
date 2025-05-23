<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SingleItemList.aspx.cs" Inherits="Pinble_Market.admin.SingleItemList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link type="text/css" rel="stylesheet" href="../Css/css.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="gv_ItemListNum" runat="server" AutoGenerateColumns="False" BorderStyle="Solid" CellPadding="0" Width="100%" AllowPaging="True" CssClass="GridView_Table" OnRowDataBound="gv_ItemListNum_RowDataBound">
            <PagerSettings Mode="NumericFirstLast" Visible="False" />
               <FooterStyle CssClass="GridView_Footer" />
            <Columns>
                <asp:TemplateField HeaderText="期号">
                <ItemTemplate>
                    <%# Eval("ExpectNum") %>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="彩种">
                <ItemTemplate>
                    <asp:Label ID="lab_lottery" runat="server"></asp:Label>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="条件内容">
                    <ItemTemplate>
                     <asp:Label ID="lab_condition" runat="server"></asp:Label>  <font color="red"><%# Eval("itemradio") %>  <%# Eval("itemcheck") %> </font> 
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:HyperLinkField HeaderText="号码内容" Text="号码内容" DataNavigateUrlFields="Content" DataNavigateUrlFormatString="?GoodsID={0}" Target="mainframe" DataTextField="Content" >
                    </asp:HyperLinkField>
<%--                    <asp:TemplateField HeaderText="本期奖号">
                        <ItemTemplate>
                            <asp:Label ID="lab_awardNum" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="是否中奖">
                    <ItemTemplate>
                        <asp:Label ID="lab_Num" runat="server" ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="评价">
                <ItemTemplate>
                <a href="">评价</a>
                </ItemTemplate>
                </asp:TemplateField>
            </Columns>    
            <RowStyle CssClass="GridView_Row" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <PagerStyle CssClass="GridView_Pager" />
                <HeaderStyle Font-Bold="True" CssClass="GridView_Header" />
                <AlternatingRowStyle CssClass="GridView_AlternatingRow" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
