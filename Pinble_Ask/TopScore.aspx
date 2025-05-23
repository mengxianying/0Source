<%@ Page Language="C#" AutoEventWireup="true" Codebehind="TopScore.aspx.cs" Inherits="Pinble_Ask.TopScore" %>

<%@ Register Src="Contorls/UcJsADs.ascx" TagName="UcJsADs" TagPrefix="uc7" %>
<%@ Register Src="Contorls/UcPicAds.ascx" TagName="UcPicAds" TagPrefix="uc6" %>
<%@ Register Src="Contorls/UcMark.ascx" TagName="UcMark" TagPrefix="uc5" %>
<%@ Register Src="Contorls/Bulletin_r.ascx" TagName="Bulletin_r" TagPrefix="uc4" %>
<%@ Register Src="Contorls/UcSearch.ascx" TagName="UcSearch" TagPrefix="uc3" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="Contorls/UcAskHead.ascx" TagName="UcAskHead" TagPrefix="uc1" %>
<%@ Register Src="Contorls/UcAskFoot.ascx" TagName="UcAskFoot" TagPrefix="uc2" %>
<%@ Import Namespace="Pbzx.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>积分排行榜_拼搏吧_拼搏在线彩神通软件</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />    
    <link href="css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/demos.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/demos.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div>
            <uc1:UcAskHead ID="UcAskHead1" runat="server" />
            
            <div class="main">
                <div align="left">
                    <div class="Link_Xia">
                        <a href="/">拼搏吧</a> >>积分排行榜
                    </div>
                </div>
            </div>
            <div class="main">
                <uc6:UcPicAds ID="UcPicAds1" runat="server" />
                <uc7:UcJsADs ID="UcJsADs1" runat="server" />
            </div>
      
            <div class="main">         
                <div class="Listl">
                    <div class="class_title">
                        <asp:Label ID="lbltitle" runat="server" Text="积分排行榜"></asp:Label>
                    </div>
                    <div class="class_content3">
                        <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" Width="95%"
                            HorizontalAlign="Center" BorderWidth="0px" OnRowDataBound="MyGridView_RowDataBound"
                            GridLines="Horizontal" BorderStyle="None">
                            <Columns>
                                <asp:TemplateField HeaderText="排名">
                                    <ItemStyle Width="8%" />
                                    <ItemTemplate>
                                      &nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&amp;nbsp;用户名">
                                    <ItemTemplate>
                                        <a target='_blank' href='UserShow.aspx?name=<%# Input.Encrypt(Eval("ID").ToString())%>'>
                                            <%#Eval("UserName") %>
                                        </a>
                                    </ItemTemplate>
                                    <ItemStyle Width="20%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="头衔">
                                    <ItemTemplate>
                                        <a href='Help.aspx#n5' target='_blank'>
                                            <%# Method.GetUserTitle(Convert.ToString(Convert.ToInt32(Eval("Score")) - Convert.ToInt32(Eval("Pointpenalty")) - Convert.ToInt32(Eval("OtherPointpenalty"))))%>
                                        </a>
                                    </ItemTemplate>
                                    <ItemStyle Width="20%" HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="等级">
                                    <ItemTemplate>
                                        <a href='Help.aspx#n5' target='_blank'>
                                            <%# Method.GetUserGrade(Convert.ToString(Convert.ToInt32(Eval("Score")) - Convert.ToInt32(Eval("Pointpenalty")) - Convert.ToInt32(Eval("OtherPointpenalty"))))%>
                                        </a>
                                    </ItemTemplate>
                                    <ItemStyle Width="17%" HorizontalAlign="Center" />
                                    <ControlStyle CssClass="list_xia2" />
                                    <HeaderStyle  HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="积分">
                                    <ItemTemplate>
                                        <%# Convert.ToInt32(Eval("Score")) - Convert.ToInt32(Eval("Pointpenalty")) - Convert.ToInt32(Eval("OtherPointpenalty"))%>
                                        分
                                    </ItemTemplate>
                                    <ItemStyle Width="15%"  HorizontalAlign="Center"  />
                                    <ControlStyle CssClass="list_xia2" />
                                    <HeaderStyle HorizontalAlign="Center"/>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle Height="27px" BackColor="#F4F8FF" BorderColor="#F4F8FF" />
                            <RowStyle BorderColor="#FFC0FF" />
                        </asp:GridView>
                    </div>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <img src="/images/A_list_classbg3.jpg" width="730" height="7" /></td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="mMT">
                        <tr>
                            <td>
                                <img alt="" src="/images/A_List_bg2.jpg" width="730" height="7" /></td>
                        </tr>
                        <tr>
                            <td background="/images/A_list_classbg2.jpg">
                                <uc3:UcSearch ID="UcSearch1" runat="server"></uc3:UcSearch>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <img src="/images/A_list_classbg3.jpg" width="730" height="7" /></td>
                        </tr>
                    </table>
                </div>
            
                <div class="mr">
                    <div class="Listr_title">
                        <table width="93%" cellpadding="0" cellspacing="0" border="0"  align="center">
                            <tr>
                                <td width="40%">
                                    &nbsp;<font color="#E57B01"><b>最新公告</b></font>
                                </td>
                                <td width="60%" align="right">
                                    <a href="/Bulletin_Ask.aspx" target="_blank"><font color="#E57B01">更多>></font></a>&nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="Listr_content">
                        <uc4:Bulletin_r ID="Bulletin_r1" runat="server" Count="8" TitleLength="18" IntChannelID="13"
                            ClassCss="Linl12Green"></uc4:Bulletin_r>
                    </div>
                    <div>
                        <img src="images/A_list_rbg3.jpg" /></div>
                    <div class="Listr2_title mMT">
                        <table width="93%" cellpadding="0" cellspacing="0" border="0"  align="center">
                            <tr>
                                <td  width="40%">
                                    <font color="#003399"><b>积分排行榜</b></font>
                                </td>
                                <td  width="60%" align="right">
                                    <a href="TopScore.aspx" target="_blank">更多>></a>&nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="Listr2_content">
                        <uc5:UcMark ID="UcMark1" runat="server" />
                      </div>
                    <div>
                        <img alt="" src="images/A_list_rbg6.jpg" /></div>
                </div>
            </div>
            <uc2:UcAskFoot ID="UcAskFoot1" runat="server" />
        </div>
    </form>
</body>
<!-- <script src="/javascript/kf/PinbleService.js"></script> -->
</html>
