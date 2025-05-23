<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Ask.aspx.cs" Inherits="Pinble_Ask.Ask"
    EnableEventValidation="false" ValidateRequest="false"  %>

<%@ Register Src="Contorls/UcAskHead.ascx" TagName="UcAskHead" TagPrefix="uc1" %>
<%@ Register Src="Contorls/UcAskFoot.ascx" TagName="UcAskFoot" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>提问_拼搏吧_拼搏在线彩神通软件</title>
    <meta name="keywords" content="拼搏吧 知识搜索 提问 回答 彩票问题 福利彩票 体育彩票" />
    <meta name="description" content="" />    
    <link href="css/css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    <!--
    .lt {float:left; width:80px; font-size:12px; font-weight:bold;color:#16397b;}
    .rt {font-size:12px;color:#16397b;}
    .rt {margin:0 0 0px 85px; font-size:12px;color:#16397b;}
    .STYLE1 {color: #FF0000}
    -->
</style>

    <script type="text/javascript" src="/javascript/SearchAjax.js"></script>

    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/start/jquery-ui-1.7.2.custom.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:UcAskHead ID="UcAskHead1" runat="server" />
            <!---当前位置----->
            <div class="main">
                <div align="left">
                    <a href="Default.aspx" class="Link_Xia">拼搏吧</a> > 提问
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                </div>
            </div>
            <!---主体开始----->
            <div class="main">
                <div>
                    <div class="Askbg1">
                    </div>
                    <div class="Askbg2">
                        提问
                    </div>
                    <div class="Askbg3">
                    </div>
                </div>
                <table width="95%" border="0" cellpadding="4" cellspacing="0">
                    <tr>
                        <td colspan="2" height="6">
                        </td>
                    </tr>
                    <tr>
                        <td width="12%" align="right" class="f14black">
                            您的提问：</td>
                        <td width="88%" align="left" class="f14black">
                            <asp:TextBox ID="txtTitle" runat="server" class="f14gray" MaxLength="55" Width="541px"></asp:TextBox>
                            <span class="f12gray">请尽量简明扼要</span></td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" class="f14black">
                            问题说明：</td>
                        <td align="left" class="f14black">
                            &nbsp;<asp:TextBox ID="txtContent" class="f14gray" runat="server" TextMode="MultiLine"
                                Text="问题说明越详细，回答也会越准确！" Columns="50" Height="162px" Rows="6" Width="534px" onfocus="if(this.value=='问题说明越详细，回答也会越准确！'){this.value=''}"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" class="f14black">
                            分类选择：</td>
                        <td align="left" class="f14black">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="28%">
                                                &nbsp;<asp:ListBox ID="libBigType" runat="server" class="input1" Style="width: 220px"
                                                    Height="180px" AutoPostBack="True" OnSelectedIndexChanged="libBigType_SelectedIndexChanged">
                                                </asp:ListBox></td>
                                            <td width="2%">
                                                <b>→</b></td>
                                            <td width="28%">
                                                &nbsp;<asp:ListBox ID="libType" runat="server" class="input1" Style="width: 220px"
                                                    Height="180px"></asp:ListBox></td>
                                            <td width="42%" class="f12gray">
                                                请您选择正确的分类
                                                <br />
                                                以使您的问题尽快得到解答。</td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="f14black">
                            悬赏积分：</td>
                        <td align="left" class="f14black">
                            <asp:DropDownList ID="ddlLargessPoint" runat="server" Width="96px">
                                <asp:ListItem Selected="True">0</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>15</asp:ListItem>
                                <asp:ListItem>20</asp:ListItem>
                                <asp:ListItem>30</asp:ListItem>
                                <asp:ListItem>40</asp:ListItem>
                                <asp:ListItem>50</asp:ListItem>
                                <asp:ListItem>60</asp:ListItem>
                                <asp:ListItem>70</asp:ListItem>
                                <asp:ListItem>80</asp:ListItem>
                                <asp:ListItem>90</asp:ListItem>
                                <asp:ListItem>100</asp:ListItem>
                            </asp:DropDownList>
                            您目前的积分：<asp:Label ID="lblScore" runat="server"></asp:Label>。&nbsp;&nbsp;<img src="images/tips.gif"
                                width="16" height="16">悬赏积分越多，您的问题会越受关注，从而得到更佳答案。</td>
                    </tr>
                    <tr>
                        <td align="right" class="f14black">
                            匿名设定：</td>
                        <td align="left" class="f14black">
                            <asp:CheckBox ID="chkIsAnonymous" runat="server" />&nbsp; 您可以对问题设定匿名，但您需要多付出<asp:Label
                                ID="lblNM" runat="server"></asp:Label>个积分</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnOK" runat="server" Text="提交问题" class="f15black" OnClick="btnOK_Click" /></td>
                    </tr>
                </table>
            </div>
            <!---版权开始----->
           <uc2:UcAskFoot ID="UcAskFoot1" runat="server"></uc2:UcAskFoot>
        </div>
    </form>
</body>
<!-- <script src="/javascript/kf/PinbleService.js"></script> -->
</html>
