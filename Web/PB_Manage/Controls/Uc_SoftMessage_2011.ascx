<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Uc_SoftMessage_2011.ascx.cs" Inherits="Pbzx.Web.PB_Manage.Controls.Uc_SoftMessage_2011" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<style>
.MyCalendar .ajax__calendar_container {
    border:1px solid #646464;
    background-color: lemonchiffon;
    color: red;
}
.MyCalendar .ajax__calendar_other .ajax__calendar_day,
.MyCalendar .ajax__calendar_other .ajax__calendar_year {
    color: black;
}
.MyCalendar .ajax__calendar_hover .ajax__calendar_day,
.MyCalendar .ajax__calendar_hover .ajax__calendar_month,
.MyCalendar .ajax__calendar_hover .ajax__calendar_year {
    color: black;
}
.MyCalendar .ajax__calendar_active .ajax__calendar_day,
.MyCalendar .ajax__calendar_active .ajax__calendar_month,
.MyCalendar .ajax__calendar_active .ajax__calendar_year {
    color: black;
    font-weight:bold;
}
</style>
<table border="1" cellspacing="0" cellpadding="1" style="border-color:#C1FFE4; width: 882px;" >
    <tr style="border-color:#C1FFE4;">
        <td colspan="2" style="width: 350px; border-color:#C1FFE4;">
            标题：
            <asp:TextBox ID="txtTitleSerch" runat="server" Width="142px"></asp:TextBox></td>
        <td colspan="4" style="width: 469px;border-color:#C1FFE4; ">
                &nbsp;日期段:从<cc1:CalendarExtender ID="CalendarExtender1" CssClass="MyCalendar" runat="server" TargetControlID="txtCreateTime1" Format="yyyy-MM-dd">
                </cc1:CalendarExtender>
                <asp:TextBox ID="txtCreateTime1" runat="server" Width="100px"></asp:TextBox>至<cc1:CalendarExtender ID="CalendarExtender2" CssClass="MyCalendar" runat="server" Format="yyyy-MM-dd" TargetControlID="txtCreateTime2">
                </cc1:CalendarExtender>
                <asp:TextBox ID="txtCreateTime2" runat="server" Width="100px" ></asp:TextBox></td>
            <td style="width: 338px;border-color:#C1FFE4;">
                <asp:RadioButtonList ID="rblDateType" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">发布时间</asp:ListItem>
                    <asp:ListItem Value="2">开始时间</asp:ListItem>
                    <asp:ListItem Value="3" Selected="True">截止时间</asp:ListItem>
                    <asp:ListItem Value="4" Selected="True">无限制</asp:ListItem>
                </asp:RadioButtonList></td>
    </tr>
    <tr>
    <td colspan="2" style="width: 350px;border-color:#C1FFE4;">
        软件限定：<asp:DropDownList ID="DropList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AppendDataBoundItems="True">
             <asp:ListItem Value="0">所有</asp:ListItem>
         </asp:DropDownList>
          <asp:DropDownList ID="DropList2" runat="server" AppendDataBoundItems="True">
              <asp:ListItem Value="0">所有</asp:ListItem>
          </asp:DropDownList></td>
      <td style="width: 469px;border-color:#C1FFE4;" colspan="4">
           注册限定：<asp:DropDownList ID="DropList3" runat="server" AppendDataBoundItems="True" DataTextField="name" DataValueField="number">
                <asp:ListItem Value="00">所有</asp:ListItem>
            </asp:DropDownList>&nbsp; 用户限定：<asp:DropDownList ID="DropList4" runat="server" AppendDataBoundItems="True" DataTextField="name" DataValueField="number">
                 <asp:ListItem Value="00">所有</asp:ListItem>
              </asp:DropDownList>
              &nbsp;&nbsp;</td>
          <td style="width: 338px;border-color:#C1FFE4; ">
              &nbsp;
              <asp:Button ID="btnOK" runat="server" Text="查找" OnClick="btnOK_Click" Width="86px" />&nbsp;&nbsp;
              <asp:Button ID="btnReset" runat="server" Text="重置" OnClick="btnReset_Click" Width="88px" /></td>
    </tr>
</table>
</ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="DropList1" />
    </Triggers>
</asp:UpdatePanel>