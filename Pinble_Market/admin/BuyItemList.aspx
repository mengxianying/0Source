<%@ Page Language="C#" AutoEventWireup="true" Codebehind="BuyItemList.aspx.cs" Inherits="Pinble_Market.admin.BuyItemList" %>

<%@ Register Src="../Contorls/MakFooter.ascx" TagName="MakFooter" TagPrefix="uc2" %>

<%@ Register Src="../Contorls/head.ascx" TagName="head" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>购买信息页</title>
    <link href="../Css/input.css" rel="stylesheet" type="text/css" />
    <link href="../Css/head.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../JS/GridView.js"></script>
    <link href="../Css/title.css" rel="Stylesheet" type="text/css" />
    
</head>
<body onload="GridViewColor();">
    <form id="form1" runat="server">
    <uc1:head ID="Head1" runat="server" />
        <div id="wrap" style="margin-top:10px; margin-bottom:10px;">
        <div class="Title">
                <div class="return_title">
                    用户 <font color='red'><%= Pbzx.Common.Method.Get_UserName.ToString() %></font> 的购买记录明细</div>
                <div class="return_re">
                    <a href="javascript:history.go(-1);">返回上一页</a>
                </div>
            </div>
        <table width="99%" border="0" cellspacing="0" cellpadding="0" style="margin-bottom: 10px">
                <tr>
                    <td align="left" valign="top">
                        <div class="isearch">
                            <div class="bg">
                                搜索：
                                <input id="susername" name="username" type="text" class="n" title="关键字：会员名、价格、彩种、期限、条件名称、续费状态" autocomplete="off" />
                                <asp:ImageButton ID="Ibtn_scout" runat="server" ImageUrl="../image/ieaarchBtn.gif" CssClass="isearchBtn" OnClick="Ibtn_scout_Click" />(关键字：会员名、价格、彩种、期限、条件名称、续费状态)
                            </div>
                            <div class="keyword">
                                <img src="../image/hot.gif" alt="" width="22" height="10" />
                                <span id="super_list" style="color: #FF0000">提示：如果商户有3期以上的条件没有按时发布，客户就可申请退订此服务。订制已经超过一星期的。按实际的比例来收取一定的服务费。其它金额返还客户。</span></div>
                        </div>
                    </td>
                </tr>
            </table>
            <asp:GridView ID="myGridView" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" CellPadding="3" BackColor="#97BEE7" CellSpacing="1" GridLines="None" Width="99%" AllowPaging="True" OnRowCreated="myGridView_RowCreated" OnRowDataBound="myGridView_RowDataBound" OnRowEditing="myGridView_RowEditing" OnRowUpdating="myGridView_RowUpdating" OnRowCancelingEdit="myGridView_RowCancelingEdit">
                <PagerSettings Mode="NumericFirstLast" Visible="False" />
                <Columns>
                    <asp:BoundField HeaderText="序号">
                        <HeaderStyle Height="24px" />
                        <ItemStyle Font-Size="14px" Height="24px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="彩种">
                    <ItemTemplate>
                        <asp:Label ID="Lab_Lottery" runat="server"></asp:Label>
                     </ItemTemplate>
                       
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="条件">
                    <ItemTemplate>
                     <a href='Market_issuanceManage.aspx?id=<%# Pbzx.Common.Input.Encrypt(Eval("issueInfoId").ToString()) %>&time=<%# Pbzx.Common.Input.Encrypt(Eval("BeginTime").ToString()) %>' target="_blank"> <asp:Label ID="Lab_Name" runat="server"></asp:Label></a> 
                    </ItemTemplate>
                       
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="商家">
                    <ItemTemplate>
                        <asp:Label ID="lab_shopName" runat="server"></asp:Label>
                    </ItemTemplate>
                        
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="价格">
                    <ItemTemplate><%# Eval("Price").ToString().Split('.')[0] %>彩金币</ItemTemplate>
                        
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="购买期限">
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddl_Term" runat="server">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate><%# Eval("Term") %>个月</ItemTemplate>
                        
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="订购时间">
                    <ItemTemplate> <%# string.Format("{0:u}", Eval("BeginTime")).Substring(0, 10) %></ItemTemplate>
                       
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="到期时间">
                    <ItemTemplate><%# string.Format("{0:u}", Eval("EndTime")).Substring(0, 10) %></ItemTemplate>
                        
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="状态">
                    <EditItemTemplate>
                          <asp:DropDownList ID="ddl_Continue" runat="server" >
                            </asp:DropDownList>
                    </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Lab_Continue" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                            <asp:CommandField HeaderText="续费设置" ShowEditButton="True" EditText="续费" />
                    <asp:TemplateField HeaderText="退订">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtn_cancel" runat="server" CommandArgument='<%# Eval("issueInfoId") %>' OnCommand="lbtn_cancel_Command">申请退款</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
                <HeaderStyle Font-Bold="True" CssClass="form"/>
            </asp:GridView>
            
                   <table cellpadding="0" cellspacing="0" border="0" width="98%">
                    <tr>
                        <td>
                            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                                FirstPageText="首页" LastPageText="尾页" NextPageText="下页" OnPageChanged="AspNetPager1_PageChanged"
                                PrevPageText="上页" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                                Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                                class="pagestyle" CustomInfoSectionWidth="35%" HorizontalAlign="Center" PageSize="20" InputBoxClass="asptext" SubmitButtonClass="buttoncss" TextAfterInputBox="   ">
                            </webdiyer:AspNetPager>
                            <asp:Literal ID="litContent" runat="server"></asp:Literal>
                            </td>
                    </tr>
                </table>
                
        </div>
        
        <uc2:MakFooter ID="MakFooter1" runat="server" />
    </form>
</body>
</html>
