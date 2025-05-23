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
    <title>ƴ�����߲���ͨ��� -������ͨ����Ʊ����ٷ���վ</title>
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
        <!--TOP��ʼ--->
        <uc6:Head ID="Head1" runat="server" />
        <!---��沿��      --->
        <div class="bodyw MT5" runat="server" id="divGold" visible="false">
            <asp:DataList ID="dlGold" runat="server" RepeatColumns="4" RepeatDirection="Horizontal"
                Width="100%" EnableViewState="False">
                <ItemTemplate>
                    <%#GetAdPic(Eval("PlaceName"))%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:DataList></div>
        <!---���ֹ�沿��-->
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
        <!---����--->
        <div class="bodyw MT5">
            <div class="D_L1">
                <div class="D_Award box2">
                    <div class="title">
                        <p>
                            <a href="javascript:void(0)" onclick="refresh()" title="ˢ�����¿�����Ϣ" class="kai more">ˢ�����¿�����Ϣ</a><span>���¿���</span>
                        </p>
                    </div>
                    <div id="PresentInformation">
                    </div>
                </div>
                <uc1:UcPicAds ID="UcPicAds2" runat="server" PlaceType="��ҳ��һ" />
                <div class="MT6 D_Broken box2">
                    <div class="title">
                        <p>
                            <span>������ͨ��������</span></p>
                    </div>
                    <div style="margin-top: -5px">
                        <uc2:Uc_Flash ID="Uc_Flash2" runat="server" PlaceType="�����˶���" />
                    </div>
                    <div class="content" style="margin-top: -5px">
                        <table width="98%" border="0" align="center" style="border-top: 1px;" cellpadding="0"
                            cellspacing="0">
                            <tr>
                                <td align="left">
                                    <asp:DataList ID="dthaoc" runat="server" CellPadding="0">
                                        <ItemTemplate>
                                            &nbsp;��<a href="/Broker.aspx?ID=<%#Input.Encrypt(Eval("ID").ToString()) %>" target="_blank"><%#Eval("Btitle")%></a>
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
                            <span>���¸���</span>
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
                <uc1:UcPicAds ID="UcPicAds3" runat="server" PlaceType="��ҳ���" />
                <div class="MT5 D_Broken box2">
                    <div class="title">
                        <p>
                            <span>���߿ͷ�</span></p>
                    </div>
                    <div class="content" style="margin-left: 10px;">
                        <uc3:UC_QQ ID="UC_QQ1" runat="server"></uc3:UC_QQ>
                    </div>
                </div>
            </div>
            <div class="D_R1">
                <div class="zhong" style="width: 100%">
                    <!---����--->
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
                                                        ��<a href='<%# Eval("SavePath") %>' target="_blank" title='<%#Eval("NvarTitle") %>'><%# GetShortTitle(Eval("NvarTitle"), Eval("NvarShortTitle"),32)%></a>
                                                    </ItemTemplate>
                                                </asp:DataList>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                    <!---��վ����--->
                    <div class="D_RC1">
                        <div class="box4 D_public2">
                            <div class="title">
                                <p>
                                    <a href="/Bulletin.htm" class="more" target="_blank">����>></a><span>��վ����</span></p>
                            </div>
                            <div class="content" style="text-align: left;">
                                <asp:DataList ID="dtBulletin" runat="server" Width="100%">
                                    <ItemTemplate>
                                        ��<a href='<%# Eval("SavePath") %>' target="_blank" title='<%#Eval("NvarTitle") %>'><%# GetShortIsTop(Eval("NvarTitle"), Eval("NvarShortTitle"), Eval("BitIsTop"))%></a>
                                    </ItemTemplate>
                                </asp:DataList>
                            </div>
                        </div>
                    </div>
                </div>
                <!--�м���--->
                <div class="MT8">
                    <uc2:Uc_Flash ID="Uc_Flash1" runat="server" PlaceType="��ҳ�м�_�����������" />
                </div>
                <!--����б�--->
                <div id="focus" class="MT" style="height: 485px;">
                    <!-- focus begin-->
                    <div id="tag_contain">
                        <div id="nav">
                            <ul>
                             <li class="tag_label_on" onmouseover="javascript:qiehuan(4)" id="mynav4"><a href="/Soft.aspx?TypeID=9EC738CA1E37E0AB"
                                    target="_blank"><span>���ΰ�</span></a></li>
                                <li class="tag_label" id="mynav0" onmouseover="javascript:qiehuan(0)" style="border-left-width: 0px">
                                    <a href="/Soft.aspx?TypeID=BD7047AA5DC586D6" target="_blank"><span>רҵ��</span></a></li>
                                <li class="tag_label" onmouseover="javascript:qiehuan(1)" id="mynav1"><a href="/Soft.aspx?TypeID=810AEC991080AF29"
                                    target="_blank"><span>��ɱ��</span></a></li>
                                <li class="tag_label" onmouseover="javascript:qiehuan(2)" id="mynav2"><a href="/Soft.aspx?TypeID=C03CB17CF88E1B5A"
                                    target="_blank"><span>��׼��</span></a></li>
                                <li class="tag_label" onmouseover="javascript:qiehuan(3)" id="mynav3"><a href="/Soft.aspx?TypeID=F11BAE67EF766FB0"
                                    target="_blank"><span>��Ѱ�</span></a></li>
                               
                                <li id="priceZhuan" >
                                <!--
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td align="right" height="27" valign="bottom">
                                                &nbsp;&nbsp;&nbsp;&nbsp;<span id="spPriceZi">����</span><span id="spWLP"
                                                    class="red">150Ԫ/������&nbsp;270Ԫ/������&nbsp;480Ԫ/һ��</span><span id='spPriceDay' class="blue">���죺<font color="red">3Ԫ/��</font></span>
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
                                                    <asp:TemplateField HeaderText="�������">
                                                        <ItemTemplate>
                                                            <a href="/Soft_explain.aspx?ID=<%#Pbzx.Common.Input.Encrypt(Eval("pb_SoftID").ToString()) %>"
                                                                target="_blank">&nbsp;<%#Eval("pb_SoftName")%></a>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="30%" Height="22px" HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="�汾��">
                                                        <ItemTemplate>
                                                            <%#Eval("pb_SoftVersion")%>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="11%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="˵����">
                                                        <ItemTemplate>
                                                            <!--Pbzx.Web.WebFunc.GetTop2DownLoad()[0]+-->
                                                            <a href='<%# Eval("pb_illuminate")%>'>˵����</a>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="���ۼ۸�">
                                                        <ItemTemplate>
                                                            <%#Eval("pb_DemoUrl")%>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="14%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="�������">
                                                        <ItemTemplate>
                                                            <a href='<%# Pbzx.Common.WebInit.webBaseConfig.WebUrl +"ProductDownload.aspx?id="+ Eval("pb_SoftID")+"&reUrl=1" %>'>
                                                                ��ͨ����</a>&nbsp;&nbsp;<a href='<%# Pbzx.Common.WebInit.webBaseConfig.WebUrl +"ProductDownload.aspx?id="+ Eval("pb_SoftID")+"&reUrl=2" %>'>��������</a>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="ע�Ṻ��">
                                                        <ItemTemplate>
                                                            <%#Eval("pb_TypeName").ToString() == "��Ʊϵͳ" ? "<a style='cursor: pointer' onclick=\"$('#dialog1').attr('title','��ʾ'); $('#dialog1').html('<p style=padding:20px >��Ʊϵͳ�ݲ�֧�����Ϲ���������Ҫ����ƴ�����߿ͷ���ϵ��</p>'); $('#dialog1').dialog({autoOpen: false,modal: true,width: 450, buttons: {'ȷ��':function() {$(this).dialog('close');$('#dialog1').dialog('destroy'); } } });$('#dialog1').dialog('open');\" >����</a>" : "<a href='/addtoshoppingcart.aspx?productID=" + Eval("pb_SoftID") + "' style='cursor: pointer' target='_blank' >����</a>"%>
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
                                                    <asp:TemplateField HeaderText="�������">
                                                        <ItemTemplate>
                                                            <a href="/Soft_explain.aspx?ID=<%#Pbzx.Common.Input.Encrypt(Eval("pb_SoftID").ToString()) %>"
                                                                target="_blank">&nbsp;<%#Eval("pb_SoftName")%></a>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="30%" Height="22px" HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="�汾��">
                                                        <ItemTemplate>
                                                            <%#Eval("pb_SoftVersion")%>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="11%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="˵����">
                                                        <ItemTemplate>
                                                            <!--Pbzx.Web.WebFunc.GetTop2DownLoad()[0]+-->
                                                            <a href='<%# Eval("pb_illuminate")%>'>˵����</a>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="���ۼ۸�">
                                                        <ItemTemplate>
                                                            <%#Eval("pb_DemoUrl")%>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="14%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="�������">
                                                        <ItemTemplate>
                                                            <a href='<%# Pbzx.Common.WebInit.webBaseConfig.WebUrl +"ProductDownload.aspx?id="+ Eval("pb_SoftID")+"&reUrl=1" %>'>
                                                                ��ͨ����</a>&nbsp;&nbsp;<a href='<%# Pbzx.Common.WebInit.webBaseConfig.WebUrl +"ProductDownload.aspx?id="+ Eval("pb_SoftID")+"&reUrl=2" %>'>��������</a>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="ע�Ṻ��">
                                                        <ItemTemplate>
                                                            <a href='/addtoshoppingcart.aspx?productID=<%#Eval("pb_SoftID") %>' style="cursor: pointer"
                                                                target="_blank">����</a>
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
                                                    <asp:TemplateField HeaderText="�������">
                                                        <ItemTemplate>
                                                            <a href="/Soft_explain.aspx?ID=<%#Pbzx.Common.Input.Encrypt(Eval("pb_SoftID").ToString()) %>"
                                                                target="_blank">&nbsp;<%#Eval("pb_SoftName")%></a>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="30%" Height="22px" HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="�汾��">
                                                        <ItemTemplate>
                                                            <%#Eval("pb_SoftVersion")%>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="11%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="˵����">
                                                        <ItemTemplate>
                                                            <!--Pbzx.Web.WebFunc.GetTop2DownLoad()[0]+-->
                                                            <a href='<%# Eval("pb_illuminate")%>'>˵����</a>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="���ۼ۸�">
                                                        <ItemTemplate>
                                                            <%#Eval("pb_DemoUrl")%>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="14%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="�������">
                                                        <ItemTemplate>
                                                            <a href='<%# Pbzx.Common.WebInit.webBaseConfig.WebUrl +"ProductDownload.aspx?id="+ Eval("pb_SoftID")+"&reUrl=1" %>'>
                                                                ��ͨ����</a>&nbsp;&nbsp;<a href='<%# Pbzx.Common.WebInit.webBaseConfig.WebUrl +"ProductDownload.aspx?id="+ Eval("pb_SoftID")+"&reUrl=2" %>'>��������</a>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="ע�Ṻ��">
                                                        <ItemTemplate>
                                                            <a href='/addtoshoppingcart.aspx?productID=<%#Eval("pb_SoftID") %>' style="cursor: pointer"
                                                                target="_blank">����</a>
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
                                                    <asp:TemplateField HeaderText="�������">
                                                        <ItemTemplate>
                                                            <a href="/Soft_explain.aspx?ID=<%#Pbzx.Common.Input.Encrypt(Eval("pb_SoftID").ToString()) %>"
                                                                target="_blank">&nbsp;<%#Eval("pb_SoftName")%></a>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="30%" Height="22px" HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="�汾��">
                                                        <ItemTemplate>
                                                            <%#Eval("pb_SoftVersion")%>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="11%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="˵����">
                                                        <ItemTemplate>
                                                            <!--Pbzx.Web.WebFunc.GetTop2DownLoad()[0]+-->
                                                            <a href='<%# Eval("pb_illuminate")%>'>˵����</a>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="���ۼ۸�">
                                                        <ItemTemplate>
                                                            <%#Eval("pb_RegUrl")%>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="14%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="�������">
                                                        <ItemTemplate>
                                                            <a href='<%# Pbzx.Common.WebInit.webBaseConfig.WebUrl +"ProductDownload.aspx?id="+ Eval("pb_SoftID")+"&reUrl=1" %>'>
                                                                ��ͨ����</a>&nbsp;&nbsp;<a href='<%# Pbzx.Common.WebInit.webBaseConfig.WebUrl +"ProductDownload.aspx?id="+ Eval("pb_SoftID")+"&reUrl=2" %>'>��������</a>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="ע�Ṻ��">
                                                        <ItemTemplate>
                                                            ���
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
                                                    <asp:TemplateField HeaderText="�������">
                                                        <ItemTemplate>
                                                            <a href="/Soft_explain.aspx?ID=<%#Pbzx.Common.Input.Encrypt(Eval("pb_SoftID").ToString()) %>"
                                                                target="_blank">&nbsp;<%#Eval("pb_SoftName")%></a>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="30%" Height="22px" HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="�汾��">
                                                        <ItemTemplate>
                                                            <%#Eval("pb_SoftVersion")%>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="11%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="˵����">
                                                        <ItemTemplate>
                                                            <!--Pbzx.Web.WebFunc.GetTop2DownLoad()[0]+-->
                                                            <a href='<%# Eval("pb_illuminate")%>'>˵����</a>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="���ۼ۸�">
                                                        <ItemTemplate>
                                                            <%#Eval("pb_DemoUrl")%>
                                                         </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="14%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="�������">
                                                        <ItemTemplate>
                                                            <a href='<%# Pbzx.Common.WebInit.webBaseConfig.WebUrl +"ProductDownload.aspx?id="+ Eval("pb_SoftID")+"&reUrl=1" %>'>
                                                                ��ͨ����</a>&nbsp;&nbsp;<a href='<%# Pbzx.Common.WebInit.webBaseConfig.WebUrl +"ProductDownload.aspx?id="+ Eval("pb_SoftID")+"&reUrl=2" %>'>��������</a>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="20%" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="ע�Ṻ��">
                                                        <ItemTemplate>
                                                            <a href='/addtoshoppingcart.aspx?productID=<%#Eval("pb_SoftID") %>' style="cursor: pointer"
                                                                target="_blank">����</a>
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
                            &nbsp;���߹������̣�<font color="#000000">ѡ�����ͨ�����Ʒ-������򣬽��빺�ﳵ-��д����-����-��������֧��-ע��ɹ�</font>
                            <%--<a href="/RegistrationMode.htm">
                            ע�Ṻ��˵��</a>--%>
                            <br />
                            &nbsp;�������̣�<font color="#000000">ѡ�����ͨ�����Ʒ-���л��ʾֻ��-��ϵ�ͷ�-�ṩע����Ϣ-ע��ɹ�</font>
                        </div>
                    </div>
                </div>
                <div class="Bodywidth" id="ban" runat="server">
                    <uc1:UcPicAds ID="UcPicAds1" runat="server" Direction="1" PlaceType="��ҳ�м�_��վ������������" />
                </div>
                <div class="MT Bodywidth">
                    <div class="D_LC1" style=" width:370px;">
                        <div class="box4 D_public">
                            <div class="title">
                                <p>
                                    <a href="/Source.aspx" class="more" target="_blank">����>></a><span>��Դ����</span></p>
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
                                                            ��<a href="/Source_explain.aspx?ID=<%#Pbzx.Common.Input.Encrypt(Eval("PBnet_SoftID").ToString()) %>"
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
                                    <a href="<%=Pbzx.Common.WebInit.ask.WebUrl %>" class="more" target="_blank">����>></a><span>ƴ
                                        �� ��</span></p>
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
                                    <a href="/School.htm" class="more" target="_blank">����>></a><span>���ѧԺ</span></p>
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
                                                    ��<a href='<%# Eval("SavePath") %>' target="_blank" title='<%#Eval("NvarTitle") %>'><%# GetShortTitle(Eval("NvarTitle"), Eval("NvarShortTitle"),56)%></a>
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
                                    <a href="http://bbs.pinble.com/index.asp" class="more" target="_blank">����>></a><span>�ȵ���̳</span></p>
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
                    <a href="/links.aspx" class="more" target="_blank">����>></a><span>��������</span></p>
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
                                                <img src='<%#Eval("NteLogoUrl")%>' alt="ͼƬ�޷�������ʾ" border="0" width="88" height="31" />
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
