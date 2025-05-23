<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="trackAd.aspx.cs" Inherits="Pinble_Chipped.admin.trackAd" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>追号管理</title>
    <link type="text/css" rel="stylesheet" href="../Css/style.css" />
    <script type="text/javascript" src="../jQuery/jquery-1.4.4.js"></script>
    <script type="text/javascript" src="../jQuery/jquery.XYTipsWindow.min.2.7.js"></script>
    <script type="text/javascript" charset="gb2312" src="../js/public.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" 
            EnableModelValidation="True" onrowdeleting="MyGridView_RowDeleting" 
            onrowcreated="MyGridView_RowCreated" 
            onrowdatabound="MyGridView_RowDataBound" onrowediting="MyGridView_RowEditing" 
            onrowupdating="MyGridView_RowUpdating">
            <Columns>
                <asp:TemplateField HeaderText="选择">
                    <ItemTemplate>
                        <asp:CheckBox ID="cb" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="序号" />
                <asp:TemplateField HeaderText="订单号">
                <ItemTemplate>
                  <a href='trackAd.aspx?prar=<%# Eval("tn_orderNum")%>'><%# Eval("tn_orderNum")%></a> 
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="会员名">
                <ItemTemplate>
                    <a href='trackAd.aspx?prar=<%# Eval("tn_username")%>'><%# Eval("tn_username")%></a>   
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="彩种">
                <ItemTemplate>
                  <a href="trackAd.aspx?prar=<%# Eval("tn_playname") %>"> <asp:Label ID="lab_lottery" runat="server"></asp:Label></a>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="停止条件">
                <ItemTemplate>
                    <%# Eval("tn_stopCondition")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txt_stopCondition" runat="server"></asp:TextBox>
                </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="期号">
                <ItemTemplate>
                    <%# Eval("tn_issue")%>
                </ItemTemplate>
                
                </asp:TemplateField>
                <asp:TemplateField HeaderText="购奖号码">
                <ItemTemplate>
            
                    <a href="javascript:void(0)" onclick="view_s('<%# Eval("tn_num") %>','<%# Eval("tn_playname") %>')">号码详情</a>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="倍数">
                <ItemTemplate>
                    <%# Eval("tn_multiple")%>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="花费金额">
                <ItemTemplate>
                    ￥<%# Eval("tn_money")%>元
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="短信提醒">
                <ItemTemplate>
                    <%# Convert.ToInt32(Eval("tn_message"))==1 ? "提醒":"不提醒"%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txt_message" runat="server"></asp:TextBox>
                </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="添加时间">
                <ItemTemplate>
                    <%# Eval("tn_time")%>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="中奖金额">
                <ItemTemplate>
                    <%# Eval("tn_Inward")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txt_Inward" runat="server"></asp:TextBox>
                </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="状态">
                <ItemTemplate>
                    <asp:Label ID="lab_state" runat="server"></asp:Label>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField HeaderText="编辑" ShowEditButton="True" />
                <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
         <table cellpadding="0" cellspacing="0" border="0" width="100%" style="margin-top: 10px;
            margin-bottom: 15px">
            <tr>
                <td>
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                        FirstPageText="首页" LastPageText="尾页" NextPageText="下页" OnPageChanged="AspNetPager1_PageChanged"
                        PrevPageText="上页" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                        Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                        class="pagestyle" CustomInfoSectionWidth="35%" HorizontalAlign="Center" PageSize="20">
                    </webdiyer:AspNetPager>
                    
                </td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td align="left">
                        <asp:CheckBox ID="cb_full" runat="server" AutoPostBack="true" OnCheckedChanged="cb_full_CheckedChanged" />全选
                        <asp:Button ID="btn_delete" runat="server" Text="删除" OnClick="btn_delete_Click" />
                        <asp:Button ID="btn_cancel" runat="server" Text="取消" OnClick="btn_cancel_Click" />
                    </td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>
