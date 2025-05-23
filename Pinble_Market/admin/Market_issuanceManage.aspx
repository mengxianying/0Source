<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Market_issuanceManage.aspx.cs"
    Inherits="Pinble_Market.admin.Market_issuanceManage" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="../Contorls/MakFooter.ascx" TagName="MakFooter" TagPrefix="uc2" %>
<%@ Register Src="../Contorls/head.ascx" TagName="head" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>发布项目管理</title>
    <link href="../Css/head.css" rel="stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript" src="../JS/GridView.js"></script>
        <style type="text/css">
       #wq {   
 BACKGROUND: #ffffff; WIDTH: expression(this.offsetParent.clientWidth<800?"800px":"1024px"); min-width: 800px; overflow:hidden;  
}
    </style>

</head>
<body onload="GridViewColor();">
    <form id="form1" runat="server">
        <div id="wq">
            <uc1:head ID="Head1" runat="server" />
            <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top: 5px">
                <tr>
                    <td align="left" valign="top">
                        <div class="isearch">
                            <div class="bg">
                                搜索：
                                <input id="susername" name="username" type="text" class="n" title="关键字：期号" />
                                <asp:ImageButton ID="Ibtn_scout" runat="server" ImageUrl="../image/ieaarchBtn.gif" CssClass="isearchBtn" OnClick="Ibtn_scout_Click" />
                                (说明：请输入期号查询) &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:LinkButton ID="lbtn_order" runat="server" OnClick="lbtn_order_Click">按期号顺序排列</asp:LinkButton>
                                &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;<asp:LinkButton ID="lbtn_desc" runat="server" OnClick="lbtn_desc_Click">按期号倒序排列</asp:LinkButton>
                            </div>
                            <div class="keyword">
                                <img src="../image/hot.gif" width="22" height="10" />
                                <span id="super_list" style="color: #FF0000">说明： (选择条件购买，购买的单个条件每一期都有商户发布的不同的条件内容可以查看。免费的条件可以直接查看)
                                </span>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
            <div style="margin-top: 5px; margin-bottom: 5px; border: 0px">
                <asp:GridView ID="myGridView" runat="server" AutoGenerateColumns="False" CellPadding="3"
                    BackColor="#97BEE7" CellSpacing="1" GridLines="None" Width="100%" AllowPaging="True"
                    OnRowCreated="GridView1_RowCreated" OnRowDataBound="GridView1_RowDataBound">
                    <PagerSettings Mode="NumericFirstLast" Visible="False" />
                    <%--               <FooterStyle CssClass="GridView_Footer" />--%>
                    <Columns>
                        <asp:BoundField HeaderText="序号" />
                        <asp:TemplateField HeaderText="条件名称">
                            <ItemTemplate>
                                <asp:Label ID="lab_Name" runat="server"></asp:Label>   <%#Eval("itemradio")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="期号">
                            <ItemTemplate>
                                <%# Eval("ExpectNum")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="条件号码">
                            <ItemTemplate>
                                <%#Pbzx.Common.Input.GetSubString(Eval("Content").ToString(),8)%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="发布时间">
                            <ItemTemplate>
                                <%# string.Format("{0:u}",Convert.ToDateTime(Eval("IssueTime"))).Substring(0,10) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText="评价">
                            <ItemTemplate>
                                <asp:LinkButton ID="Btn_appraise" runat="server" CommandArgument='<%# Eval("ItemId") %>'
                                    OnCommand="Btn_appraise_Command">评价此期</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <%--                <asp:CommandField HeaderText="编辑" ShowEditButton="True" />--%>
                        <%--<asp:CommandField HeaderText="删除" ShowDeleteButton="True" />--%>
                    </Columns>
                    <HeaderStyle Font-Bold="True" CssClass="form" />
                </asp:GridView>
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td>
                            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                                FirstPageText="首页" LastPageText="尾页" NextPageText="下页" OnPageChanged="AspNetPager1_PageChanged"
                                PrevPageText="上页" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                                Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                                class="pagestyle" CustomInfoSectionWidth="35%" HorizontalAlign="Center" PageSize="20">
                            </webdiyer:AspNetPager>
                            <asp:Literal ID="litContent" runat="server"></asp:Literal>
                        </td>
                    </tr>
                </table>
            </div>
            <uc2:MakFooter ID="MakFooter1" runat="server" />
        </div>
    </form>
</body>
</html>
