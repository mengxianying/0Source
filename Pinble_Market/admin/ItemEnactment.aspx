<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ItemEnactment.aspx.cs"
    ValidateRequest="false" Inherits="Pinble_Market.admin.ItemEnactment" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Src="../Contorls/MakFooter.ascx" TagName="MakFooter" TagPrefix="uc2" %>
<%@ Register Src="../Contorls/head.ascx" TagName="head" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加新项目</title>
    <link href="../Css/input.css" rel="stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript" src="../JS/jquery-1.3.2.js"></script>

    <link href="../Css/head.css" rel="stylesheet" type="text/css" />
    <link href="../Css/css.css" rel="stylesheet" type="text/css" />
</head>
<body style="color: #484848; background: #F1F9FB url(../image/top_bg2.gif) repeat-x;
    margin: 0; padding: 0;">
    <uc1:head ID="Head1" runat="server" />
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

        <div class="img" style="text-align: left;">
            <img src="../image/s_img_logo.png" alt="" />
            <font color='red'>设定一个彩种条件，设定成功后可以在条件发布选项中发布设定的条件。已设定过，将不再显示！</font></div>
        <div id="wrap">
            <div style="margin-top: 10px; margin-bottom: 10px;" class="main">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="s_box1">
                            <!--项目列表开始-->
                            <table width="98%" border="0" cellspacing="0" cellpadding="8" class="table_s_all">
                                <tr>
                                    <td align="right">
                                        彩&nbsp;&nbsp;&nbsp;&nbsp;种：</td>
                                    <td align="left">
                                        &nbsp;<asp:DropDownList ID="ddlSofts" runat="server" OnSelectedIndexChanged="ddlSofts_SelectedIndexChanged"
                                            AutoPostBack="True" Width="150px" AppendDataBoundItems="True">
                                            <asp:ListItem Selected="True">=请选择彩种=</asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp; &nbsp; &nbsp; 条件名称：
                                        <asp:DropDownList ID="ddlxianmo" runat="server" Width="150px" AppendDataBoundItems="True">
                                            <asp:ListItem Selected="True">=请选择条件=</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:Label ID="labmsgtype" runat="server" ForeColor="Red"></asp:Label></td>
                                </tr>
                                <tr id="sfms" runat="server">
                                    <td align="right">
                                        收费模式：</td>
                                    <td align="left">
                                        &nbsp;<asp:DropDownList ID="ddlsf" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlsf_SelectedIndexChanged"
                                            Width="87px">
                                        </asp:DropDownList>
                                        <asp:Label ID="sfmsgs" runat="server" ForeColor="Red"></asp:Label></td>
                                </tr>
                                <tr id="money" runat="server">
                                    <td class="right">
                                        价&nbsp;&nbsp;&nbsp;&nbsp;格：</td>
                                    <td class="left" align="left">
                                        ￥<asp:TextBox ID="txtprice" runat="server" Enabled="False" Width="43px" MaxLength="5">免费</asp:TextBox>
                                        /月&nbsp;&nbsp;&nbsp;&nbsp;（<span style="color: #ff0000">注意！必须通过10期试用期才能改为收费项目。</span>）
                                        折扣：<asp:TextBox ID="txtzk" runat="server" Width="40px" MaxLength="3" Enabled="False">0</asp:TextBox>（折扣规则）
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        设置状态：</td>
                                    <td align="left">
                                        <asp:RadioButtonList ID="radbut" runat="server" RepeatDirection="Horizontal" Font-Bold="False"
                                            Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"
                                            AutoPostBack="True" OnSelectedIndexChanged="radbut_SelectedIndexChanged">
                                            <asp:ListItem Value="0" Selected="True">开放</asp:ListItem>
                                            <%--  <asp:ListItem Value="1" Enabled="false">锁定</asp:ListItem>--%>
                                            <asp:ListItem Value="2">关闭</asp:ListItem>
                                        </asp:RadioButtonList><asp:Label ID="labstatusmsg" runat="server" ForeColor="Green">(开放期，发布后其他用户可以订购此项目！)</asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        发布设置：</td>
                                    <td align="left">
                                        <asp:RadioButtonList ID="rdbtfabu" runat="server" RepeatDirection="Horizontal" AutoPostBack="True"
                                            OnSelectedIndexChanged="rdbtfabu_SelectedIndexChanged">
                                            <asp:ListItem Value="0" Selected="True">立即发布</asp:ListItem>
                                            <asp:ListItem Value="1" Enabled="False">设置时间</asp:ListItem>
                                        </asp:RadioButtonList>
                                        条件发布后会在前台显示。
                                        <div id="txtDate" runat="server" visible="false">
                                            &nbsp;
                                            <asp:DropDownList ID="ddlDateH" runat="server">
                                            </asp:DropDownList>年&nbsp;
                                            <asp:DropDownList ID="ddlDateY" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDateY_SelectedIndexChanged">
                                            </asp:DropDownList>月
                                            <asp:DropDownList ID="ddlDateR" runat="server">
                                            </asp:DropDownList>日
                                            <asp:DropDownList ID="ddlDateS" runat="server">
                                            </asp:DropDownList>时
                                            <asp:DropDownList ID="ddlDateF" runat="server">
                                            </asp:DropDownList>分
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        条件说明：</td>
                                    <td align="left">
                                        <asp:TextBox ID="txtsay" CssClass="multieditbox" runat="server" Height="100px" TextMode="MultiLine"
                                            Width="300px" MaxLength="50"></asp:TextBox><asp:Label ID="labSaymsg" runat="server"
                                                Text="（简明扼要的介绍一下设定的条件）"></asp:Label></td>
                                </tr>
                                <tr style="display: none">
                                    <td align="right">
                                        推荐设置:</td>
                                    <td align="left">
                                        <asp:RadioButtonList ID="rdbttuijian" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True" Value="0">不推荐</asp:ListItem>
                                            <asp:ListItem Value="1">推荐</asp:ListItem>
                                        </asp:RadioButtonList></td>
                                </tr>
                                <tr style="display: none">
                                    <td align="right">
                                        限看人数:</td>
                                    <td align="left">
                                        <asp:RadioButtonList ID="rdbtnlenght" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rdbtnlenght_SelectedIndexChanged"
                                            RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True" Value="0">不限制</asp:ListItem>
                                            <asp:ListItem Value="1">限制</asp:ListItem>
                                        </asp:RadioButtonList>
                                        <div id="Div2" runat="server" visible="false">
                                            <asp:TextBox ID="txtxz" CssClass="asptext" runat="server" Width="45px"></asp:TextBox>(设定每天最多可以给多少人查看。)
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" CssClass="buttonok" Text="确 定"
                                            Width="82px" />&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnresult" Visible="false" CssClass="buttonok" Width="82px" runat="server"
                                            Text="返 回" OnClick="btnresult_Click" />&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <!--项目列表结束-->
                            若要终止所经营的项目，要提前一个月停止新用户的定制，对已定制的用户要服务到期满为止，不得随意中断或终止服务；
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <uc2:MakFooter ID="MakFooter1" runat="server" />
    </form>
</body>
</html>
