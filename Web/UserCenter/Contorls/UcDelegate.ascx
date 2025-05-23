<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcDelegate.ascx.cs" Inherits="Pbzx.Web.UserCenter.Contorls.UcDelegate" %>
<script src="../../javascript/calendar.js" type="text/javascript"></script>

<table width="795" border="0" cellspacing="0" cellpadding="0">
    <tr>
     <td> &nbsp;编号:</td>
    <td>    
        <asp:TextBox ID="txtOrderID" runat="server" Width="103px" ></asp:TextBox>
    </td>
    <td>收货姓名:</td>
    <td><asp:TextBox ID="txtReceiverName" runat="server" Width="52px"></asp:TextBox></td>        
    <td>状态:</td>
     <td>
        <asp:DropDownList ID="ddlTipName" runat="server" Width="68px">
        </asp:DropDownList></td>   
        <td>
      日期:</td>
        <td>
            <asp:TextBox ID="txtCreateTime1" runat="server" Width="64" onfocus="calendar();"></asp:TextBox></td>
        <td>
            至</td>
        <td>
            <asp:TextBox ID="txtCreateTime2" runat="server" Width="64" onfocus="calendar();"></asp:TextBox></td>
       
        <td>
            <asp:RadioButtonList ID="rblDateType" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="1">更新时间</asp:ListItem>            
                <asp:ListItem Value="" Selected="True">无日期限制</asp:ListItem>
            </asp:RadioButtonList></td>
        <td>
            <asp:Button ID="btnOK" runat="server" Text="查找" OnClick="btnOK_Click" class="input_btn2" />&nbsp;<asp:Button ID="btnReset" runat="server" Text="重置" OnClick="btnReset_Click" class="input_btn2" /></td>
         </tr>
</table>
    
<%--    <table width="580" border="0" cellspacing="0" cellpadding="0">
    <tr> 
       </tr>
</table>--%>