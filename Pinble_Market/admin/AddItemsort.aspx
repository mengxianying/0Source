<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddItemsort.aspx.cs" Inherits="Pinble_Market.admin.AddItemsort"
    EnableEventValidation="false" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加项目类别</title>
    <style type="text/css">
        body, td, th
        {
            font-size: 12px;
        }
        .table
        {
            border: 1px solid #9cdae7;
        }
        .left
        {
            text-align: left;
            background-color: #ffffff;
        }
        .right
        {
            text-align: right;
            background-color: #ffffff;
        }
    </style>
    <link href="../Css/index.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <asp:MultiView ID="MutViwe" runat="server" ActiveViewIndex="0">
                    <asp:View runat="server" ID="ri1">
                        <table style="width: 100%; border: 0;" align="center" cellpadding="0" cellspacing="1"
                            bgcolor="#93bee2">
                            <tr>
                                <td class="right" width="20%">
                                    彩种选择：
                                </td>
                                <td class="left" colspan="2">
                                    <asp:DropDownList ID="DdtList" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                        OnSelectedIndexChanged="DdtList_SelectedIndexChanged" Width="100px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="right">
                                    服务类别：
                                </td>
                                <td class="left" colspan="2">
                                    <asp:DropDownList ID="Ddtservice" runat="server" DataTextField="name" DataValueField="number"
                                        AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="Ddtservice_SelectedIndexChanged"
                                        Width="100px">
                                        <asp:ListItem Selected="True">--请选择--</asp:ListItem>
                                    </asp:DropDownList>
                                    （说明： 设定类别。&nbsp; 例如：组选，直选，红球预测，蓝球预测。前台商户可以选择）
                                </td>
                            </tr>
                            <tr>
                                <td class="right">
                                    项目名称：
                                </td>
                                <td class="left" colspan="2">
                                    <asp:TextBox ID="txtxiangm" runat="server" ReadOnly="True"></asp:TextBox>（项目名称=彩种+服务类别，自动生成不能修改）
                                </td>
                            </tr>
                            <tr>
                                <td class="right" style="height: 41px">
                                    设置：
                                </td>
                                <td class="left" colspan="2" style="height: 41px">
                                    <asp:RadioButtonList ID="Rbtlist1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged"
                                        RepeatDirection="Horizontal" Width="166px">
                                        <asp:ListItem Value="0" Selected="True">默认设置</asp:ListItem>
                                        <asp:ListItem Value="1">详细设置</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" style="text-align: center" bgcolor="#ffffff">
                                    <asp:Button ID="BtnOk" runat="server" OnClick="BtnOk_Click" CssClass="buttoncss"
                                        Text="完 成" Width="76px" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" style="text-align: center;">
                                    说明：选择默认设置，使用网站自己的默认配置的数据，不用每次都去选择和设置服务的详细信息。如果自己想设置 那就选择详细设置。
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View runat="server" ID="ri2">
                        <div style="text-align: center">
                            <table style="width: 100%; border: 0;" align="center" cellpadding="0" cellspacing="1"
                                bgcolor="#93bee2">
                                <tr>
                                    <td class="right">
                                        服务名称：
                                    </td>
                                    <td class="left" style="width: 193px">
                                        <label id="lab_lotteryName">
                                            &nbsp; &nbsp;&nbsp;
                                            <asp:Label ID="labmc" runat="server" Text="XXX"></asp:Label>
                                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                        </label>
                                        （彩种+类别=服务名称）
                                    </td>
                                </tr>
                                <tr>
                                    <td class="right">
                                        开关：
                                    </td>
                                    <td class="left" style="width: 193px">
                                        <asp:RadioButtonList ID="RBtkaiguan" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True" Value="0">开放</asp:ListItem>
                                            <asp:ListItem Value="1">关闭</asp:ListItem>
                                            <asp:ListItem Value="2">只对商户开放</asp:ListItem>
                                            <asp:ListItem Value="3">只对高级商户开放</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="right">
                                        是否置顶：
                                    </td>
                                    <td class="left" style="width: 193px">
                                        <asp:RadioButtonList ID="Rbtzhiding" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True" Value="1">是</asp:ListItem>
                                            <asp:ListItem Value="2">否</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="right">
                                        是否允许上传：
                                    </td>
                                    <td class="left" style="width: 193px">
                                        <input id="Radio7" type="radio" value="rad_7" name="rad" />
                                        是&nbsp;
                                        <input id="Radio8" type="radio" value="rad_8" name="rad" checked="CHECKED" />&nbsp;
                                        否（点击看效果）
                                    </td>
                                    <td align="center">
                                    </td>
                                </tr>
                                <tr id="tr_up">
                                    <td class="right">
                                        上传方案参数：
                                    </td>
                                    <td class="left" style="width: 193px">
                                        <input id="Checkbox1" type="checkbox" />
                                        TXT &nbsp;
                                        <input id="Checkbox2" type="checkbox" />EXCEL &nbsp;<input id="Checkbox3" type="checkbox" />
                                        word &nbsp;<input id="Checkbox4" type="checkbox" />html &nbsp;<input id="Checkbox5"
                                            type="checkbox" />
                                        image &nbsp;
                                    </td>
                                    <td align="center">
                                    </td>
                                </tr>
                                <tr id="smallmoeny">
                                    <td class="right">
                                        最小金额：
                                    </td>
                                    <td class="left" style="width: 193px">
                                        <asp:TextBox ID="txtbeginMoney" runat="server"></asp:TextBox>（元）
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr id="bigmoeny">
                                    <td class="right">
                                        最大金额：
                                    </td>
                                    <td class="left" style="width: 193px">
                                        <asp:TextBox ID="txtendMoney" runat="server"></asp:TextBox>（元）
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="right">
                                        提成参数：
                                    </td>
                                    <td class="left" style="width: 193px">
                                        <asp:TextBox ID="txtticheng" runat="server"></asp:TextBox>（%）
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="right" style="height: 42px">
                                        允许多期：
                                    </td>
                                    <td class="left" style="height: 42px; width: 193px;">
                                        <asp:RadioButtonList ID="Rbtduoqi" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="1" Selected="True">允许</asp:ListItem>
                                            <asp:ListItem Value="0">不允许</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td style="height: 42px">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align: center; height: 37px;" bgcolor="#ffffff">
                                        &nbsp; &nbsp; &nbsp;<asp:Button ID="butResult" runat="server" OnClick="butResult_Click"
                                            Text="<<上一步" CssClass="buttoncss" />
                                        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click"
                                            Text="完 成" Width="77px" CssClass="buttoncss" />
                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:View>
                </asp:MultiView>
            </div>
        </ContentTemplate>

    </asp:UpdatePanel>
    </form>
</body>
</html>
