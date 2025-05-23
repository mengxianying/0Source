<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcMoney_Log.ascx.cs"
    Inherits="Pbzx.Web.UserCenter.Contorls.UcMoney_Log" %>

<script src="/javascript/calendar.js" type="text/javascript"></script>

<table width="800" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            &nbsp; 类别：<asp:DropDownList ID="ddlType" runat="server">
                <asp:ListItem Selected="True" Value="">所有</asp:ListItem>
                <asp:ListItem Value="0">充值</asp:ListItem>
                <asp:ListItem Value="1">取款</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            状态：<asp:DropDownList ID="ddlState" runat="server">
                <asp:ListItem Selected="True" Value="">所有</asp:ListItem>
                <asp:ListItem Value="0">处理中</asp:ListItem>
                <asp:ListItem Value="1">已处理</asp:ListItem>
                <asp:ListItem Value="2">错误</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            <asp:RadioButtonList ID="rblIsCancel" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="-1">全部</asp:ListItem>
                <asp:ListItem Value="0" Selected="True">未取消</asp:ListItem>
                <asp:ListItem Value="1">已取消</asp:ListItem>
            </asp:RadioButtonList>
        </td>
                
        <td>
           日期
        </td>
        <td>
            <asp:TextBox ID="txtCreateTime1" title='开始时间' onfocus="calendar();" runat="server"
                Width="90px" MaxLength="20"></asp:TextBox>&nbsp;至&nbsp;<asp:TextBox ID="txtCreateTime2"
                    title='结束时间' onfocus="calendar();" runat="server" Width="90px" MaxLength="20"></asp:TextBox>
        </td>
        <td>  <asp:RadioButtonList ID="rblDate" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Selected="True">全部</asp:ListItem>
                <asp:ListItem Value="0">日期</asp:ListItem>
            </asp:RadioButtonList>
          
        </td>
        <td>
            <asp:Button ID="btnLook" runat="server" OnClick="btnLook_Click" Text="查找" class="input_btn2" />&nbsp;&nbsp;<asp:Button
                ID="btnReset" runat="server" Text="重置" OnClick="btnReset_Click" class="input_btn2" /></td>
    </tr>
</table>
