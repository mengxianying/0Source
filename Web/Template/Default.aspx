<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Default1.aspx.cs" Inherits="Pbzx.Web.Template.Default" %>

<%@ Register Src="../Contorls/UC_QQ.ascx" TagName="UC_QQ" TagPrefix="uc3" %>
<%@ Register Src="../Contorls/Uc_Flash.ascx" TagName="Uc_Flash" TagPrefix="uc2" %>
<%@ Register Src="../Contorls/UcPicAds.ascx" TagName="UcPicAds" TagPrefix="uc1" %>
<%@ Register Src="../Contorls/Head.ascx" TagName="Head" TagPrefix="uc6" %>
<%@ Register Src="../Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc7" %>
<%@ Import Namespace="Pbzx.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" " http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>拼搏在线彩神通软件 -『彩神通』彩票软件官方网站</title>
    <meta name="keywords" content='<%= Pbzx.Common.Method.GetWebDescribe("Default", "keywords") %>' />
    <meta name="description" content='<%= Pbzx.Common.Method.GetWebDescribe("Default", "description") %>' />
    <meta name="author" content='<%= Pbzx.Common.Method.GetWebDescribe("Default", "author") %>' />
    <meta name="robots" content="all" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/soft.css" rel="stylesheet" type="text/css" />
    <link href="/css/kaijiang.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript" src="/javascript/soft.js"></script>

    <meta http-equiv="X-UA-Compatible" content="IE=7" />

    <script type="text/javascript" src="/javascript/jquery-1.3.2.js"></script>

    <script type="text/javascript" src="/javascript/Default.js"></script>

</head>
<body>
    <form id="Form1" runat="server">
        <!--TOP开始--->
        <uc6:Head ID="Head1" runat="server" />
        <!---广告部分      --->
        <div class="bodyw MT5" runat="server" id="divGold" visible="false">
            <asp:DataList ID="dlGold" runat="server" RepeatColumns="4" RepeatDirection="Horizontal"
                Width="100%" EnableViewState="False">
                <ItemTemplate>
                    <%#GetAdPic(Eval("PlaceName"))%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:DataList></div>
        <!---文字广告部分-->
        <div class="bodyw" runat="server" id="divText" visible="false">
            <table width="100%" border="0" cellpadding="4" cellspacing="1" bgcolor="#CCCCCC">
                <tr>
                    <td bgcolor="#FFFFFF">
                        <asp:DataList ID="dlletter" runat="server" RepeatColumns="8" RepeatDirection="Horizontal"
                            Width="100%" EnableViewState="False">
                            <ItemTemplate>
                                <%#Getletter(Eval("PlaceName"))%>

                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:DataList>
                    </td>
                </tr>
            </table>
        </div>
        <!---主体--->
        <div class="bodyw MT5">
            <div class="D_L1">
                <div class="D_Award box2">
                    <div class="title">
                        <p>
                            <a href="javascript:void(0)" onclick="refresh()" title="刷新最新开奖信息" class="kai more">刷新最新开奖信息</a><span>最新开奖</span>
                        </p>
                    </div>
                    <div id="PresentInformation">
                    </div>
                </div>
                <uc1:UcPicAds ID="UcPicAds2" runat="server" PlaceType="首页左一" />
                <div class="MT6 D_Broken box2">
                    <div class="title">
                        <p>
                            <span>『彩神通』经纪人</span></p>
                    </div>
                    <div style="margin-top: -5px">
                        <uc2:Uc_Flash ID="Uc_Flash2" runat="server" PlaceType="经纪人动画" />
                    </div>
                    <div class="content" style="margin-top: -5px">
                        <table width="98%" border="0" align="center" style="border-top: 1px;" cellpadding="0"
                            cellspacing="0">
                            <tr>
                                <td align="left">
                                    <asp:DataList ID="dthaoc" runat="server" CellPadding="0">
                                        <ItemTemplate>
                                            &nbsp;·<a href="/Broker.aspx?ID=<%#Input.Encrypt(Eval("ID").ToString()) %>" target="_blank"><%#Eval("Btitle")%></a>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="MT D_Broken box5">
                    <div class="title">
                        <p>
                            <span>最新更新</span>
                        </p>
                    </div>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="center">
                                <div id="soft" style="width: 99%;" runat="server">
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <uc1:UcPicAds ID="UcPicAds3" runat="server" PlaceType="首页左二" />
                <div class="MT5 D_Broken box2">
                    <div class="title">
                        <p>
                            <span>在线客服</span></p>
                    </div>
                    <div class="content" style="margin-left: 10px;">
                        <uc3:UC_QQ ID="UC_QQ1" runat="server"></uc3:UC_QQ>
                    </div>
                </div>
            </div>
            <div class="D_R1">
                <div class="zhong" style="width: 100%">
                    <!---新闻--->
                    <div class="D_LCN1">
                        <div class="D_P">
                            <div id="dvContent" style="margin-bottom: 0px; margin-left: 0px; width: 99%;">
                                <table width="100%" cellpadding="0" cellspacing="0" style="margin-bottom: 2px;">
                                    <tr>
                                        <td align="center">
                                            <div class="xia_7margin" id="divTop3">
                                                <ul>
                                                    <li>
                                                        <asp:Label ID="lblNewsTop" runat="server" Text=""></asp:Label></li>
                                                </ul>
                                                <asp:DataList ID="dlNewsTop3" runat="server" Width="100%" RepeatColumns="3" RepeatDirection="Horizontal">
                                                    <ItemTemplate>
                                                        <a href='<%# Eval("SavePath") %>' target="_blank" title='<%#Eval("NvarTitle") %>'>
                                                            <%# GetShortTitle(Eval("NvarTitle"), Eval("NvarShortTitle"),20)%>
                                                        </a>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:DataList>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <div style="margin-left: 7px;">
                                                <asp:DataList ID="dlNewsTopList" runat="server" Width="99%" RepeatColumns="2" RepeatDirection="Horizontal"
                                                    ShowFooter="False" ShowHeader="False">
                                                    <ItemTemplate>
                                                        ·<a href='<%# Eval("SavePath") %>' target="_blank" title='<%#Eval("NvarTitle") %>'><%# GetShortTitle(Eval("NvarTitle"), Eval("NvarShortTitle"),32)%></a>
                                                    </ItemTemplate>
                                                </asp:DataList>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                    <!---网站公告--->
                    <div class="D_RC1">
                        <div class="box4 D_public2">
                            <div class="title">
                                <p>
                                    <a href="/Bulletin.htm" class="more" target="_blank">更多>></a><span>网站公告</span></p>
                            </div>
                            <div class="content" style="text-align: left;">
                                <asp:DataList ID="dtBulletin" runat="server" Width="100%">
                                    <ItemTemplate>
                                        ·<a href='<%# Eval("SavePath") %>' target="_blank" title='<%#Eval("NvarTitle") %>'><%# GetShortIsTop(Eval("NvarTitle"), Eval("NvarShortTitle"), Eval("BitIsTop"))%></a>
                                    </ItemTemplate>
                                </asp:DataList>
                            </div>
                        </div>
                    </div>
                </div>
                <!--中间广告--->
                <div class="MT8">
                    <uc2:Uc_Flash ID="Uc_Flash1" runat="server" PlaceType="首页中间_软件下面广告区" />
                </div>
                <!--软件列表--->
                <div id="focus" class="MT" style="height: 485px;">
                    <!-- focus begin-->
                    <div id="tag_contain">
                        <div id="nav">
                            <ul>
                             <li class="tag_label_on" onmouseover="javascript:qiehuan(4)" id="mynav4"><a href="/Soft.aspx?TypeID=9EC738CA1E37E0AB"
                                    target="_blank"><span>遨游版</span></a></li>
                                <li class="tag_label" id="mynav0" onmouseover="javascript:qiehuan(0)" style="border-left-width: 0px">
                                    <a href="/Soft.aspx?TypeID=BD7047AA5DC586D6" target="_blank"><span>专业版</span></a></li>
                                <li class="tag_label" onmouseover="javascript:qiehuan(1)" id="mynav1"><a href="/Soft.aspx?TypeID=810AEC991080AF29"
                                    target="_blank"><span>胆杀版</span></a></li>
                                <li class="tag_label" onmouseover="javascript:qiehuan(2)" id="mynav2"><a href="/Soft.aspx?TypeID=C03CB17CF88E1B5A"
                                    target="_blank"><span>标准版</span></a></li>
                                <li class="tag_label" onmouseover="javascript:qiehuan(3)" id="mynav3"><a href="/Soft.aspx?TypeID=F11BAE67EF766FB0"
                                    target="_blank"><span>免费版</span></a></li>
                               
                                <li id="priceZhuan" >
                                <!--
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td align="right" height="27" valign="bottom">
                                                &nbsp;&nbsp;&nbsp;&nbsp;<span id="spPriceZi">网络</span><span id="spWLP"
                                                    class="red">150元/三个月&nbsp;270元/六个月&nbsp;480元/一年</span><span id='spPriceDay' class="blue">按天：<font color="red">3元/天</font></span>
                                            </td>
                                        </tr>
                                    </table>
                                    -->
                                </li>
                            </ul>
                        </div>
                        <table width="50%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td height="15">
                                </td>
                            </tr>
                        </table>
                        <div class="Content_pd">
                            <div id="qh_con0" style="display: none">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td align="center">
                                            <asp:GridView ID="zhuanye" runat="server" Width="96%" DataKeyNames="pb_SoftID" AutoGenerateColumns="False"
                                                CssClass="GridView_Table" Height="380px">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="软件名称">
                                                        <ItemTemplate>
                                                            <a href="/Soft_explain.aspx?ID=<%#Pbzx.Common.Input.Encrypt(Eval("pb_SoftID").ToString()) %>"
                                                                target="_blank">&nbsp;<%#Eval("pb_SoftName")%></a>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="30%" Height="22px" HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="版本号">
                                                        <ItemTemplate>
                                                            <%#Eval("pb_SoftVersion")%>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="11%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="说明书">
                                                        <ItemTemplate>
                                                            <!--Pbzx.Web.WebFunc.GetTop2DownLoad()[0]+-->
                                                            <a href='<%# Eval("pb_illuminate")%>'>说明书</a>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="销售价格">
                                                        <ItemTemplate>
                                                            <%#Eval("pb_DemoUrl")%>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="14%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="软件下载">
                                                        <ItemTemplate>
                                                            <a href='<%# Pbzx.Common.WebInit.webBaseConfig.WebUrl +"ProductDownload.aspx?id="+ Eval("pb_SoftID")+"&reUrl=1" %>'>
                                                                网通下载</a>&nbsp;&nbsp;<a href='<%# Pbzx.Common.WebInit.webBaseConfig.WebUrl +"ProductDownload.aspx?id="+ Eval("pb_SoftID")+"&reUrl=2" %>'>电信下载</a>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="注册购买">
                                                        <ItemTemplate>
                                                            <%#Eval("pb_TypeName").ToString() == "出票系统" ? "<a style='cursor: pointer' onclick=\"$('#dialog1').attr('title','提示'); $('#dialog1').html('<p style=padding:20px >出票系统暂不支持网上购买，如有需要请与拼搏在线客服联系！</p>'); $('#dialog1').dialog({autoOpen: false,modal: true,width: 450, buttons: {'确定':function() {$(this).dialog('close');$('#dialog1').dialog('destroy'); } } });$('#dialog1').dialog('open');\" >购买</a>" : "<a href='/addtoshoppingcart.aspx?productID=" + Eval("pb_SoftID") + "' style='cursor: pointer' target='_blank' >购买</a>"%>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <HeaderStyle CssClass="GridView_Header" />
                                                <RowStyle CssClass="GridView_Row" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="qh_con1" style="display: none">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td align="center">
                                            <asp:GridView ID="dansha" runat="server" Width="96%" DataKeyNames="pb_SoftID" AutoGenerateColumns="False"
                                                CssClass="GridView_Table" OnDataBound="dansha_DataBound" Height="380px">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="软件名称">
                                                        <ItemTemplate>
                                                            <a href="/Soft_explain.aspx?ID=<%#Pbzx.Common.Input.Encrypt(Eval("pb_SoftID").ToString()) %>"
                                                                target="_blank">&nbsp;<%#Eval("pb_SoftName")%></a>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="30%" Height="22px" HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="版本号">
                                                        <ItemTemplate>
                                                            <%#Eval("pb_SoftVersion")%>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="11%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="说明书">
                                                        <ItemTemplate>
                                                            <!--Pbzx.Web.WebFunc.GetTop2DownLoad()[0]+-->
                                                            <a href='<%# Eval("pb_illuminate")%>'>说明书</a>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="销售价格">
                                                        <ItemTemplate>
                                                            <%#Eval("pb_DemoUrl")%>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="14%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="软件下载">
                                                        <ItemTemplate>
                                                            <a href='<%# Pbzx.Common.WebInit.webBaseConfig.WebUrl +"ProductDownload.aspx?id="+ Eval("pb_SoftID")+"&reUrl=1" %>'>
                                                                网通下载</a>&nbsp;&nbsp;<a href='<%# Pbzx.Common.WebInit.webBaseConfig.WebUrl +"ProductDownload.aspx?id="+ Eval("pb_SoftID")+"&reUrl=2" %>'>电信下载</a>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="注册购买">
                                                        <ItemTemplate>
                                                            <a href='/addtoshoppingcart.aspx?productID=<%#Eval("pb_SoftID") %>' style="cursor: pointer"
                                                                target="_blank">购买</a>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <HeaderStyle CssClass="GridView_Header" />
                                                <RowStyle CssClass="GridView_Row" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="qh_con2" style="display: none">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td align="center">
                                            <asp:GridView ID="biaozhun" runat="server" Width="96%" DataKeyNames="pb_SoftID" AutoGenerateColumns="False"
                                                CssClass="GridView_Table" OnDataBound="biaozhun_DataBound" Height="380px">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="软件名称">
                                                        <ItemTemplate>
                                                            <a href="/Soft_explain.aspx?ID=<%#Pbzx.Common.Input.Encrypt(Eval("pb_SoftID").ToString()) %>"
                                                                target="_blank">&nbsp;<%#Eval("pb_SoftName")%></a>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="30%" Height="22px" HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="版本号">
                                                        <ItemTemplate>
                                                            <%#Eval("pb_SoftVersion")%>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="11%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="说明书">
                                                        <ItemTemplate>
                                                            <!--Pbzx.Web.WebFunc.GetTop2DownLoad()[0]+-->
                                                            <a href='<%# Eval("pb_illuminate")%>'>说明书</a>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="销售价格">
                                                        <ItemTemplate>
                                                            <%#Eval("pb_DemoUrl")%>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="14%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="软件下载">
                                                        <ItemTemplate>
                                                            <a href='<%# Pbzx.Common.WebInit.webBaseConfig.WebUrl +"ProductDownload.aspx?id="+ Eval("pb_SoftID")+"&reUrl=1" %>'>
                                                                网通下载</a>&nbsp;&nbsp;<a href='<%# Pbzx.Common.WebInit.webBaseConfig.WebUrl +"ProductDownload.aspx?id="+ Eval("pb_SoftID")+"&reUrl=2" %>'>电信下载</a>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="注册购买">
                                                        <ItemTemplate>
                                                            <a href='/addtoshoppingcart.aspx?productID=<%#Eval("pb_SoftID") %>' style="cursor: pointer"
                                                                target="_blank">购买</a>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <HeaderStyle CssClass="GridView_Header" />
                                                <RowStyle CssClass="GridView_Row" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="qh_con3" style="display: none">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td align="center">
                                            <asp:GridView ID="mianfei" runat="server" Width="96%" DataKeyNames="pb_SoftID" AutoGenerateColumns="False"
                                                CssClass="GridView_Table" OnDataBound="mianfei_DataBound" Height="380px">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="软件名称">
                                                        <ItemTemplate>
                                                            <a href="/Soft_explain.aspx?ID=<%#Pbzx.Common.Input.Encrypt(Eval("pb_SoftID").ToString()) %>"
                                                                target="_blank">&nbsp;<%#Eval("pb_SoftName")%></a>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="30%" Height="22px" HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="版本号">
                                                        <ItemTemplate>
                                                            <%#Eval("pb_SoftVersion")%>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="11%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="说明书">
                                                        <ItemTemplate>
                                                            <!--Pbzx.Web.WebFunc.GetTop2DownLoad()[0]+-->
                                                            <a href='<%# Eval("pb_illuminate")%>'>说明书</a>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="销售价格">
                                                        <ItemTemplate>
                                                            <%#Eval("pb_RegUrl")%>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="14%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="软件下载">
                                                        <ItemTemplate>
                                                            <a href='<%# Pbzx.Common.WebInit.webBaseConfig.WebUrl +"ProductDownload.aspx?id="+ Eval("pb_SoftID")+"&reUrl=1" %>'>
                                                                网通下载</a>&nbsp;&nbsp;<a href='<%# Pbzx.Common.WebInit.webBaseConfig.WebUrl +"ProductDownload.aspx?id="+ Eval("pb_SoftID")+"&reUrl=2" %>'>电信下载</a>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="注册购买">
                                                        <ItemTemplate>
                                                            免费
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <HeaderStyle CssClass="GridView_Header" />
                                                <RowStyle CssClass="GridView_Row" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="qh_con4" style="display: block">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td align="center">
                                            <asp:GridView ID="aoyou" runat="server" Width="96%" DataKeyNames="pb_SoftID" AutoGenerateColumns="False"
                                                CssClass="GridView_Table" OnDataBound="aoyou_DataBound" Height="380px">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="软件名称">
                                                        <ItemTemplate>
                                                            <a href="/Soft_explain.aspx?ID=<%#Pbzx.Common.Input.Encrypt(Eval("pb_SoftID").ToString()) %>"
                                                                target="_blank">&nbsp;<%#Eval("pb_SoftName")%></a>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="30%" Height="22px" HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="版本号">
                                                        <ItemTemplate>
                                                            <%#Eval("pb_SoftVersion")%>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="11%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="说明书">
                                                        <ItemTemplate>
                                                            <!--Pbzx.Web.WebFunc.GetTop2DownLoad()[0]+-->
                                                            <a href='<%# Eval("pb_illuminate")%>'>说明书</a>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="销售价格">
                                                        <ItemTemplate>
                                                            <%#Eval("pb_DemoUrl")%>
                                                         </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="14%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="软件下载">
                                                        <ItemTemplate>
                                                            <a href='<%# Pbzx.Common.WebInit.webBaseConfig.WebUrl +"ProductDownload.aspx?id="+ Eval("pb_SoftID")+"&reUrl=1" %>'>
                                                                网通下载</a>&nbsp;&nbsp;<a href='<%# Pbzx.Common.WebInit.webBaseConfig.WebUrl +"ProductDownload.aspx?id="+ Eval("pb_SoftID")+"&reUrl=2" %>'>电信下载</a>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="注册购买">
                                                        <ItemTemplate>
                                                            <a href='/addtoshoppingcart.aspx?productID=<%#Eval("pb_SoftID") %>' style="cursor: pointer"
                                                                target="_blank">购买</a>
                                                        </ItemTemplate>

                                                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <HeaderStyle CssClass="GridView_Header" />
                                                <RowStyle CssClass="GridView_Row" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <table width="50%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td height="15">
                                </td>
                            </tr>
                        </table>
                        <div class="D_saybg">
                            &nbsp;在线购买流程：<font color="#000000">选择彩神通软件产品-点击购买，进入购物车-填写订单-结算-进入在线支付-注册成功</font>
                            <%--<a href="/RegistrationMode.htm">
                            注册购买说明</a>--%>
                            <br />
                            &nbsp;汇款购买流程：<font color="#000000">选择彩神通软件产品-银行或邮局汇款-联系客服-提供注册信息-注册成功</font>
                        </div>
                    </div>
                </div>
                <div class="Bodywidth" id="ban" runat="server">
                    <uc1:UcPicAds ID="UcPicAds1" runat="server" Direction="1" PlaceType="首页中间_网站公告下面广告区" />
                </div>
                <div class="MT Bodywidth">
                    <div class="D_LC1" style=" width:370px;">
                        <div class="box4 D_public">
                            <div class="title">
                                <p>
                                    <a href="/Source.aspx" class="more" target="_blank">更多>></a><span>资源下载</span></p>
                            </div>
                            <div class="content" style="text-align: left;">
                                <table width="100%" border="0" cellspacing="1" cellpadding="0" class="MT3">
                                    <tr>
                                        <td>
                                            <asp:Repeater ID="rptVideo1" runat="server">
                                                <HeaderTemplate>
                                                    <table width="99%" border="0" cellpadding="5" cellspacing="0" style="margin-left: 7px;">
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            ·<a href="/Source_explain.aspx?ID=<%#Pbzx.Common.Input.Encrypt(Eval("PBnet_SoftID").ToString()) %>"
                                                                target="_blank"><%# Pbzx.Common.StrFormat.CutStringByNum(Eval("PBnet_SoftName").ToString(),56)%></a></td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    </table>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="box4 D_public MT D_News">
                            <div class="title">
                                <p>
                                    <a href="<%=Pbzx.Common.WebInit.ask.WebUrl %>" class="more" target="_blank">更多>></a><span>拼
                                        搏 吧</span></p>
                            </div>
                            <div class="content" style="text-align: left;">
                                <div>
                                    <iframe src="/Default_Ask.aspx?t=<%=DateTime.Now.Ticks %>>" onload="{TuneHeight('FM_Id_Ask','FM_Id_Ask');}" name="FM_Id_Ask"
                                        id="FM_Id_Ask" width="100%" marginwidth="0" marginheight="0" frameborder="0"
                                        height="182" scrolling="no"></iframe>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="D_RC2">
                        <div class="box4 D_public">
                            <div class="title">
                                <p>
                                    <a href="/School.htm" class="more" target="_blank">更多>></a><span>软件学院</span></p>
                            </div>
                            <div class="content" style="text-align: left;">
                                <table width="97%" border="0" cellspacing="1" cellpadding="0" style="margin-left: 8px;
                                    margin-top: 5px;">
                                    <tr>
                                        <td>
                                            <asp:DataList ID="dtShool" runat="server" Width="100%" ShowFooter="False" ShowHeader="False">
                                                <HeaderTemplate>
                                                    <table width="97%" border="0" cellspacing="1" cellpadding="0" style="margin-left: 8px;
                                                        margin-top: 5px;">
                                                        <tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    ·<a href='<%# Eval("SavePath") %>' target="_blank" title='<%#Eval("NvarTitle") %>'><%# GetShortTitle(Eval("NvarTitle"), Eval("NvarShortTitle"),56)%></a>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    </tr> </table>
                                                </FooterTemplate>
                                            </asp:DataList>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="box4 D_public MT D_News" style="margin-top:9px;">
                            <div class="title">
                                <p>
                                    <a href="http://bbs.pinble.com/index.asp" class="more" target="_blank">更多>></a><span>热点论坛</span></p>
                            </div>
                            <div class="content">
                                <iframe src="/Default_BBS.aspx?t=<%=DateTime.Now.Ticks %>" onload="{TuneHeight('FM_Id_BBS','FM_Id_BBSl');}"
                                    name="FM_Id_BBS" id="FM_Id_BBS" width="100%" marginwidth="0" height="182" marginheight="0"
                                    frameborder="0" scrolling="no"></iframe>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="boxlink D_link MT bodyw">
            <div class="title">
                <p>
                    <a href="/links.aspx" class="more" target="_blank">更多>></a><span>友情链接</span></p>
            </div>
            <div class="D_link_list">
                <table width="30%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td height="2">
                        </td>
                    </tr>
                </table>
                <table width="98%" border="0" align="center" cellpadding="2" cellspacing="0">
                    <tr>
                        <td>
                            <div style="margin-left: 14px;">
                                <asp:Repeater ID="RptText" runat="server">
                                    <ItemTemplate>
                                        <div class="LinkLeft">
                                            <a href=" <%#Eval("NteSiteUrl")%>" title="<%#Eval("IntSiteName")%>" target="_blank">
                                                <%#Eval("IntSiteName") %>
                                            </a>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div>
                                <asp:Repeater ID="RptPic" runat="server">
                                    <ItemTemplate>
                                        <div class="LinkLeft">
                                            <a href=" <%#Eval("NteSiteUrl")%>" title="<%#Eval("IntSiteName")%>" target="_blank">
                                                <img src='<%#Eval("NteLogoUrl")%>' alt="图片无法正常显示" border="0" width="88" height="31" />
                                            </a>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </td>
                    </tr>
                </table>
                <table width="30%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td height="6">
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <uc7:Footer ID="Footer1" runat="server" />
    </form>
</body>

<!-- <script src="/javascript/kf/PinbleService.js"></script> -->
</html>
