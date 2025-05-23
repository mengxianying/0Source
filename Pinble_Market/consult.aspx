<%@ Page Language="C#" AutoEventWireup="true" Codebehind="consult.aspx.cs" Inherits="Pinble_Market.consult" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<%@ Register Src="Contorls/head.ascx" TagName="head" TagPrefix="uc1" %>
<%@ Register Src="Contorls/MakFooter.ascx" TagName="MakFooter" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>主页查询</title>
        <style type="text/css">
       #wq {   
 BACKGROUND: #ffffff; WIDTH: expression(this.offsetParent.clientWidth<800?"800px":"1024px"); min-width: 800px; overflow:hidden;  
}
    </style>
    <link href="Css/title.css" rel="Stylesheet" type="text/css" />
</head>
<body> 
<div id="wq">
    <form id="form1" runat="server">
       <uc1:head ID="Head1" runat="server" />
         <div style=" font-family:黑体; BACKGROUND: url(../X_images/titile_bg.jpg) repeat-x; height:40px; font-size:16px; width:100%; font-weight:bold;">
                <div class="return_title">
                    搜索结果</div>
                <div class="return_re">
                    <a href="javascript:history.go(-1);">返回</a>
                </div>
            </div>
            <table width="100%" border="0" cellspacing="1" bgcolor="#97BEE7" style="margin-bottom: 5px; margin-top:5px;">
                <asp:Repeater ID="myRep" runat="server" OnItemDataBound="myRep_ItemDataBound">
                    <HeaderTemplate>
                        <tr class="form">
                            <td>
                                序号
                            </td>
                            <td>
                                彩种
                            </td>
                            <td>
                                项目条件
                            </td>
                            <td>
                                最新发布
                            </td>
                            <td>
                                发布人
                            </td>
                            <td>
                                状态
                            </td>
                            <td>
                                内容
                            </td>
                            <td>
                                历史
                            </td>
                            <td>
                                购买/关注
                            </td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr style='background-color: <%#(Container.ItemIndex%2==0) ? "#FFFFFF":"#daeff6"%>'>
                            <td>
                                <%# (Container.ItemIndex + 1) + (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize%>
                            </td>
                            <td>
                                <%# Eval("NvarName") %>
                            </td>
                            <td>
                                <%# Eval("TypeName") %>
                            </td>
                            <td>
                                <asp:Label ID="lab_ExpectNum" runat="server" ></asp:Label>
                            </td>
                            <td>
                                <%# Eval("UserId") %>
                            </td>
                            <td>
                                <asp:Label ID="lab_charge" runat="server"></asp:Label>
                            </td>
                            <td>
                                <%# Eval("say") %>
                            </td>
                            <td>
                                <a href='History.aspx?lottery=<%#Pbzx.Common.Input.Encrypt( Eval("NvarName").ToString()) %>&name=<%# Pbzx.Common.Input.Encrypt(Eval("TypeName").ToString()) %>&user=<%#Pbzx.Common.Input.Encrypt(Eval("UserId").ToString())  %>'
                                    target="_blank">查看</a>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:Repeater>
                <tr>
                    <td colspan="9" style="background-color: #FFFFFF;">
                        <asp:Label ID="litContent" runat="server"></asp:Label>
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                            FirstPageText="第一页" LastPageText="最后一页" NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged"
                            PrevPageText="上一页" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                            Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                            CustomInfoSectionWidth="35%" HorizontalAlign="Center">
                        </webdiyer:AspNetPager>
                    </td>
                </tr>
            </table>
       
        <uc2:MakFooter ID="MakFooter1" runat="server" />
    </form> 
    </div>
</body>
</html>
