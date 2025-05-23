<%@ Page Language="C#" AutoEventWireup="true" Codebehind="School_Coutent_List.aspx.cs"
    Inherits="Pbzx.Web.School_Coutent_List" %>

<%@ Register Src="Contorls/UcSchol_list.ascx" TagName="UcSchol_list" TagPrefix="uc1" %>

<%@ Register Src="~/Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc3" %>
<%@ Register Src="~/Contorls/Head.ascx" TagName="Head" TagPrefix="uc2" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head  runat="server">
    <meta name="author" content="{$Author$}" />
    <meta name="Copyright" content="{$Copyright$}" />
    <meta name="Keywords" content="{$Keywords$}" />
    <meta name="Description" content="{$Summary$}" />
    <title>软件学院_拼搏在线彩神通软件</title>
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/bulletin.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript" src="/javascript/SearchAjax.js"> </script>

    <script type="text/javascript" language="javascript" src="/reg.aspx?SchoolClick={$id$}"> </script>

    <style type="text/css">
<!--
 .pagination{ padding: 2px; } 
  .pagination ul{ margin: 0; padding: 0; text-align: left; /*Set to "right" to right align pagination interface*/ font-size: 16px; }  
  .pagination li{margin-left: 5px; list-style-type: none; display: inline; padding-bottom: 1px; }  
  .pagination a, .pagination a:visited{ padding: 0 5px; border: 1px solid #9aafe5; text-decoration: none;  color: #2e6ab1; }  .pagination a:hover, .pagination a:active{ border: 1px solid #2b66a5; color: #000; background-color: lightyellow; }  
  .pagination li.currentpage{ font-weight: bold; padding: 0 5px; border: 1px solid navy; background-color: #2e6ab1; color: #FFF; }  .pagination li.disablepage{ padding: 0 5px; border: 1px solid #929292; color: #929292; font-size: 13px; }
  .pagination li.nextpage{ font-weight: bold; }  
  * html .pagination li.currentpage, * html .pagination li.disablepage{ /*IE 6 and below. Adjust non linked LIs slightly to account for bugs*/ margin-right: 5px; padding-right: 0; }  
.STYLE3 {font-size: 12px; padding:10px; }
-->
</style>
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/demos.css" rel="stylesheet" type="text/css" />
    <link href="/css/school.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/demos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form name="form1" runat="server" id="form1">
        <uc2:Head ID="Head1" runat="server" />
        <!--主体部分--->
        <div class="bodyw MT">
            <!--左边--->
            <div id="C_list_rw1">
                <uc1:UcSchol_list id="UcSchol_list1" runat="server"></uc1:UcSchol_list>
            </div>
            <!--右边--->
            <div id="C_lw1x">
                <div class="C_c1">
                    <div class="title">
                        <p>
                            <span  style="text-align: left; margin-left: 33px;">当前位置：<a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>"  target="_self"
                                class="school">拼搏在线彩神通软件首页</a> >> <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>School.htm"
                                    class="school" target="_self">软件学院</a> >>                               
                                <asp:Label ID="lblTypeName" runat="server" Text=""></asp:Label>
                            </span></p>
                    </div>
                    <div class="content">
                        <asp:Repeater ID="rpt_list" runat="server">
                            <HeaderTemplate>
                                <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr bgcolor="#ffffff">
                                    <td width="3%" style="height: 27px">
                                        <img src="/Images/Web/B_li2.gif" width="11" height="10" /></td>
                                    <td width="79%" align="left">
                                        <a href="<%# Eval("SavePath") %>" target="_blank">
                                            <%# Pbzx.Common.StrFormat.CutStringByNum(Eval("NvarTitle"),76)%>
                                        </a>
                                    </td>
                                    <td width="18%">
                                        <%# Eval("DatDateAndTime", "{0:yyyy-MM-dd}")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <tr bgcolor="#F0F1FF">
                                    <td width="3%" style="height: 27px">
                                        <img src="/Images/Web/B_li2.gif" width="11" height="10" /></td>
                                    <td width="79%" align="left">
                                        <a href="<%# Eval("SavePath") %>" target="_blank">
                                            <%# Pbzx.Common.StrFormat.CutStringByNum(Eval("NvarTitle"),76)%>
                                        </a>
                                    </td>
                                    <td width="18%">
                                        <%# Eval("DatDateAndTime", "{0:yyyy-MM-dd}")%>
                                    </td>
                                </tr>
                            </AlternatingItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                        <asp:Literal ID="litContent" runat="server"></asp:Literal>
                        <table width="98%" border="0" align="center" cellpadding="0" cellspacing="1">
                            <tr>
                                <td align="center">
                                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoTextAlign="Center"
                                        FirstPageText="首页┊" LastPageText="尾页" NextPageText="下一页┊" OnPageChanged="AspNetPager1_PageChanged"
                                        PrevPageText="上一页┊" ShowCustomInfoSection="Right" ShowNavigationToolTip="True"
                                        Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                                        class="pagestyle" CustomInfoSectionWidth="35%" HorizontalAlign="Center" PageSize="25">
                                    </webdiyer:AspNetPager>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <!--网站底部--->
        <uc3:Footer ID="Footer1" runat="server" />
    </form>
</body>

<!-- <script src="/javascript/kf/PinbleService.js"></script> -->

</html>

<script type="text/javascript" language="javascript">
  //  document.getElementById('click').innerText=clickcount;
</script>

