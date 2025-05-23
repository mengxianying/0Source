<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcSoftOnlineSearch2011.ascx.cs" Inherits="Pbzx.Web.PB_Manage.Controls.UcSoftOnlineSearch2011" %>
<script src="../../javascript/calendar.js" type="text/javascript"></script>
<script src="/PB_Manage/JScript/Language_Nation.js" type="text/javascript"></script>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<table border="0" cellspacing="0" cellpadding="1" >
    <tr onmouseover="javascript:this.bgColor='#D9FFFF';" onmouseout="javascript:this.bgColor='#F9F9F9';">
        <td style="height: 29px">
            &nbsp;认&nbsp;证&nbsp;码:</td>
        <td style="height: 29px">
            <asp:TextBox ID="txtHDSN" runat="server" Width="120"></asp:TextBox></td>
        <td style="height: 29px">
            <asp:CheckBox ID="chkYuan" runat="server" /></td>
        <td style="height: 29px">
            原
        </td>
        <td style="height: 29px">
            注册码:
        </td>
        <td style="height: 29px">
            <asp:TextBox ID="txtAct_RN" runat="server" Width="166"></asp:TextBox>
        </td>
        <td style="height: 29px">
            注册方式:
        </td>
        <td style="height: 29px">
            <asp:DropDownList ID="ddlAct_RegType" runat="server" Width="60px" AppendDataBoundItems="True">
                <asp:ListItem>所有</asp:ListItem>
            </asp:DropDownList>&nbsp;
        </td>
        <td style="height: 29px">
            <asp:RadioButtonList ID="rblCheckHDSN" runat="server" Font-Size="12px" RepeatDirection="Horizontal"
                Height="18px">
                <asp:ListItem Selected="True" Value="">全部</asp:ListItem>
                <asp:ListItem Value="2">非法</asp:ListItem>
                <asp:ListItem Value="3">错位</asp:ListItem>
                <asp:ListItem Value="4">过期</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td style="width: 70px; height: 29px; text-align: right;">
            用户全局ID</td>
        <td style="width: 105px; height: 29px">
            <asp:TextBox ID="txtGloba" runat="server"></asp:TextBox></td>
    </tr>
</table>
<table border="0" cellspacing="0" cellpadding="0" style="width: 892px">
    <tr onmouseover="javascript:this.bgColor='#D9FFFF';" onmouseout="javascript:this.bgColor='#F9F9F9';">
        <td style="width: 303px">
            <asp:UpdatePanel ID="UpSoftType" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                                &nbsp;软件类型:</td>
                            <td>
                                <asp:DropDownList ID="ddlSoftwareType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSoftwareType_SelectedIndexChanged">
                                </asp:DropDownList></td>
                            <td>
                                安装类型:</td>
                            <td>
                                <asp:DropDownList ID="ddlInstallType" runat="server">
                                    <asp:ListItem Value="">所有</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td>
            版本号:
        </td>
        <td>
            <asp:TextBox ID="txtVersion" runat="server" Width="79px"></asp:TextBox>
        </td>
        <td>
            操作系统:</td>
        <td style="width: 79px">
            <asp:DropDownList ID="ddlOSVersion" runat="server">
            </asp:DropDownList></td>
        <td style="width: 33px">
            &nbsp; IP:</td>
        <td>
            &nbsp;<asp:TextBox ID="txtIP" runat="server" Width="122px"></asp:TextBox>
        </td>
        <td style="text-align: right">
            用户类型：</td>
        <td>
            <asp:DropDownList ID="ddlgbltype" runat="server">
                <asp:ListItem Selected="True" Value="0">全部</asp:ListItem>
                <asp:ListItem Value="i">IDE硬盘</asp:ListItem>
                <asp:ListItem Value="s">SATA硬盘</asp:ListItem>
                <asp:ListItem Value="c">C盘卷标</asp:ListItem>
                <asp:ListItem Value="n">未获成功</asp:ListItem>
                <asp:ListItem Value="v">虚拟机</asp:ListItem>
            </asp:DropDownList></td>
    </tr>
</table>
<table border="0" cellspacing="0" cellpadding="1">
    <tr onmouseover="javascript:this.bgColor='#D9FFFF';" onmouseout="javascript:this.bgColor='#F9F9F9';">
        <td>
            &nbsp;日期段:
        </td>
        <td>
            <span>从<asp:TextBox ID="txtCreateTime1" onfocus="calendar();" runat="server" Width="90"></asp:TextBox></span>
        </td>
        <td>
            至<asp:TextBox ID="txtCreateTime2" onfocus="calendar();" runat="server" Width="90"></asp:TextBox>
        </td>
        <td>
            &nbsp;
            日期方式
        </td>
        <td style="width: 292px">
            <asp:RadioButtonList ID="rblDateType" runat="server" Font-Size="12px" RepeatDirection="Horizontal">
                <asp:ListItem Value="1">最近登录日期</asp:ListItem>
                <asp:ListItem Value="2">第一次登陆日期</asp:ListItem>
                <asp:ListItem Value="" Selected="True">无日期限制</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td>
            <asp:Button ID="btnOK" runat="server" Text="查找" OnClick="btnOK_Click" Width="71px" />
        </td>
        <td>
            <asp:Button ID="btnReset" runat="server" Text="重置" OnClick="btnReset_Click" Width="70px" />
        </td>
    </tr>
</table>
