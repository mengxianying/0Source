<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Note_Details.aspx.cs" Inherits="Pinble_Sms.Note.Note_Details" %>

<%@ Register Src="../Contorls/MakFooter.ascx" TagName="MakFooter" TagPrefix="uc2" %>
<%@ Register Src="../Contorls/head.ascx" TagName="head" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>短信定制确认</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Language" content="zh_cn" />
    <style type="text/css">
        body, td
        {
            margin: 0 0 0 0;
            font-size: 12px;
            color: #000;
            text-align: center;
        }
        
        #mainLayM
        {
            overflow: auto;
            height: auto;
            margin: auto;
            width: 423px !important;
            width: 423px;
            border-bottom: 1px solid #A5C2E4;
            border-right: 1px solid #A5C2E4;
            border-left: 1px solid #A5C2E4;
            border-top: 1px solid #A5C2E4;
        }
    </style>
    <script language="javascript" type="text/javascript">
        function dz() {
            if (confirm("确定要订购吗！订购成功后，将会扣除相应金额！")) {
                document.getElementById('<%=linkbtn.ClientID %>').click();
            }
        }
    </script>
</head>
<body>
    <uc1:head ID="head" runat="server" />
    <form id="form1" runat="server">
    <div id="mainLayM" style="width: 423px;" runat="server">
        <br />
        <table style="width: 366px">
            <tr>
                <td style="width: 122px; text-align: right; height: 28px;">
                    订购类型名称：
                </td>
                <td style="width: 171px; text-align: left; height: 28px;">
                    <asp:Label ID="lblottoryType" runat="server" Text="--"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 122px; text-align: right; height: 35px;">
                    付费方式：
                </td>
                <td style="width: 171px; text-align: left; height: 35px;">
                    <asp:DropDownList ID="droppricelist" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 122px; height: 37px; text-align: right">
                    手机号码：
                </td>
                <td style="width: 171px; height: 37px; text-align: left">
                    <asp:TextBox ID="txtPhone" runat="server" MaxLength="11" Width="109px"></asp:TextBox>
                    <br />
                    <asp:Label ID="labmsg1" runat="server" Text="  " ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 122px; text-align: right; height: 41px;">
                    续费方式：
                </td>
                <td style="width: 171px; text-align: left; height: 41px;">
                    <asp:RadioButtonList ID="rdbutjF" runat="server" RepeatDirection="Horizontal" AutoPostBack="True"
                        OnSelectedIndexChanged="rdbutjF_SelectedIndexChanged">
                        <asp:ListItem Selected="True" Value="0">手动续费</asp:ListItem>
                        <asp:ListItem Value="1">自动续费</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td style="text-align: left">
                    (<span style="color: #ff3300">提示：<asp:Label ID="labmsg" runat="server" Text="您选择手动续费，当服务期满后，系统会自动停止对您的短信服务！"></asp:Label></span>)
                </td>
            </tr>
            <tr>
                <td style="width: 122px; text-align: right; height: 38px;">
                    <asp:Button ID="btnregist" runat="server" OnClick="btnregist_Click" Text="返回列表" />
                </td>
                <td style="width: 171px; height: 38px;">
                    <input id="Button2" type="button" onclick="dz()" style="width: 65px" value="定制" />
                    <asp:LinkButton ID="linkbtn" OnClick="btnOK_Click" runat="server"></asp:LinkButton>
                </td>
            </tr>
        </table>
        &nbsp;&nbsp;
        <br />
    </div>
    </form>
    <uc2:MakFooter ID="MakFooter" runat="server" />
</body>
</html>
