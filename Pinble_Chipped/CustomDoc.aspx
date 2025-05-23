<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomDoc.aspx.cs" Inherits="Pinble_Chipped.CustomDoc" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="Contorls/login.ascx" TagName="login" TagPrefix="uc1" %>
<%@ Register Src="Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>定制跟单</title>
    <link href="cssNew/hmbuy.css" rel="stylesheet" type="text/css" />
    <link href="Css/logion.css" rel="stylesheet" type="text/css" />
    <link type="text/css" rel="Stylesheet" href="Css/Title.css" />
    <link type="text/css" rel="stylesheet" href="Css/footer.css" />
    <link type="text/css" rel="stylesheet" href="Css/style.css" />

    <script type="text/javascript" src="jQuery/jquery-1.4.4.js"></script>
    <script type="text/javascript" src="jQuery/jquery.XYTipsWindow.2.7.js"></script>
    <script language="javascript" type="text/javascript" charset="gb2312" src="js/public.js?date=new date().gettime()"></script>
    <style>
    .a{color:# #0b80c0;text-decoration:none;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <!--header部分-->
    <div class="header">
        <div class="logo">
        </div>
        <div class="login_info">
            <uc1:login ID="login1" runat="server" />
        </div>
    </div>
    <!--header部分-->
    <%--合买方案begin--%>
    <div id="doc">
        <div id="main">
            <div class="content">
                <div class="c-wrap">
                    <div class="c-inner">
                        <div class="an_title p-l0">
                        <ul class="l" id="stype_t">
                                <li><a href="CustomDoc.aspx?IntId=0" title="" class="on">全部方案</a></li>
                                <li><a href="CustomDoc.aspx?IntId=3">双色球</a> </li>
                                <li><a href="CustomDoc.aspx?IntId=6">大乐透</a> </li>
                                <li><a href="CustomDoc.aspx?IntId=2">七乐彩</a> </li>
                                <li><a href="CustomDoc.aspx?IntId=1">3D</a> </li>
                                <li><a href="CustomDoc.aspx?IntId=9999">排列三</a> </li>
                                <li><a href="CustomDoc.aspx?IntId=4">排列五</a> </li>
                                <li><a href="CustomDoc.aspx?IntId=5">七星彩</a> </li>
                            </ul>
                            <span>置顶规则<s class="i-qw"></s>
                            </span>
                        </div>
                        <div class="c-search">
                            <span class="l">
                                <asp:TextBox ID="findstr" runat="server" CssClass="c-s-txt"></asp:TextBox>
                                <asp:Button ID="Button1" runat="server" CssClass="m-r btn_Lblue_s" 
                                Text="搜索" onclick="Button1_Click" />
                                <span class="c-s-hot"></span></span>
                        </div>
                        <div id="n1">
                            <div id="list_data">
                                <table width="100%" cellspacing="0" cellpadding="0" border="0" class="rec_table">
                                    <asp:Repeater ID="rep_list" runat="server" 
                                        onitemdatabound="rep_list_ItemDataBound">
                                        <HeaderTemplate>
                                            <tr>
                                                <td>
                                                    序号
                                                </td>
                                                <td>
                                                    用户名
                                                </td>
                                                <td>
                                                    返奖率
                                                </td>
                                                <td>
                                                    累计中奖金额
                                                </td>
                                                <td>
                                                    已定制人数
                                                </td>
                                                <td colspan="2">
                                                    每次认购金额 / 定制次数
                                                </td>
                                                <td>
                                                    冻结金额
                                                </td>
                                                <td>
                                                    操作
                                                </td>
                                            </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr style='background-color: <%#(Container.ItemIndex%2==0) ? "#12564a":"#daeff6"%>'>
                                                <td>
                                                    <%# (Container.ItemIndex + 1) + (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize%>
                                                </td>
                                                <td>
                                                    <a href="PersonalPage.aspx?name=<%# Eval("UserName") %>" target="mainFrame">
                                                        <%# Eval("UserName")%>
                                                    </a>
                                                </td>
                                                <td>
                                                 <asp:Label ID="lab_ReturnAward" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lab_CumAmount" runat="server"></asp:Label>
                                                       
                                                </td>
                                                <td>
                                                    <asp:Label ID="lab_cus" runat="server"></asp:Label>
                                                   
                                                </td>
                                                <td colspan="2">
                                                    <input id="tbMoney_<%# (Container.ItemIndex + 1) + (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize%>" type="text" class="btn_cy" value="1" onkeyup="this.value=this.value.replace(/[^\d]/g,'');" onbeforepaste="BeforePaste();" style="width:45px" /> 元 / <input id="txtNum_<%# (Container.ItemIndex + 1) + (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize%>"  type="text" class="btn_cy" onkeyup="this.value=this.value.replace(/[^\d]/g,'');Range(this);" onbeforepaste="BeforePaste();" value="10" style="width:45px" />次
                                                </td>

                                                <td>
                                                    <asp:Label ID="lab_Frozen" runat="server" ></asp:Label>元
                                                </td>
                                                <td>
                                                 <input id="btn_Frozen_<%# (Container.ItemIndex + 1) + (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize%>"
                                                                        type="button" class="btn_cy" value="定制" onclick="Frozen('<%# Eval("playName") %>','<%# Eval("UserName") %>','<%# (Container.ItemIndex + 1) + (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize%>')" />
                                                    
                                                    <a href='Tracking.aspx?name=<%# Eval("UserName") %>&lotId=<%# Eval("playName") %>'>详情</a>
                                                </td>
                                                
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                    <asp:Label ID="litContent" runat="server"></asp:Label></table>
                            </div>
                            <div id="changesize">
                                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                                    FirstPageText="第一页" LastPageText="最后一页" NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged"
                                    PrevPageText="上一页" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                                    Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                                    CustomInfoSectionWidth="35%" HorizontalAlign="Center">
                                </webdiyer:AspNetPager>
                            </div>
                            <div class="c-intro">
<%--                                <dl class="clearfix">
                                    <dt>战绩说明：</dt><dd><ul class="c-i-list">
                                        <li>
                                            <img src="" alt="" width="13" height="14" />
                                            金杯：直选合买成功每中5注一等奖得一个金杯</li>
                                    </ul>
                                    </dd>
                                </dl>
                                <dl class="clearfix m-t20">
                                    <dt>*%+*%保： </dt>
                                    <dd>
                                        <ol class="c-i-list">
                                            <li>1）保指保底，保底是由发起人设定在合买截止时，如果方案尚未满员，将以保底时所承诺的金额最大限度的促进方案满员。保底金额最低为方案总金额的20%。</li>
                                            <li>2）*%+*%保，指进度百分比+保底百分比。</li>
                                        </ol>
                                    </dd>
                                </dl>--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--合买方案end--%>
    <uc2:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
