<%@ Page Language="C#" AutoEventWireup="true" Codebehind="LotteryOneList.aspx.cs"
    Inherits="Pbzx.Web.LotteryOneList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>开奖详细信息_拼搏在线彩神通软件</title>
    <meta name="keywords" content="开奖详细信息,体彩,福彩,福利彩票,体育彩票" />
    <meta name="description" content="" />
    <meta name="robots" content="all" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/lottery.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
<!--
body {
	background-color: #FFFFFF;
	background-image: url(images/Web/bai_bg.jpg);
}
-->
</style>
</head>
<body onload="parent.document.getElementById('FM_Id').height=document.body.scrollHeight">
    <form id="form1" runat="server">
        <div>
            <div class="kai_lwone">
                <table width="100%" border="0" cellspacing="0" cellpadding="2" class="kai_rbg3">
                    <tr>
                        <td width="50%" class="kai_rbg_zi">
                            <%=caizhongName%>
                            开奖信息</td>
                        <td width="50%" align="right">
                            开奖周期：<font color="#A20010"><%=riQi%>&nbsp;&nbsp;</font>
                        </td>
                    </tr>
                </table>
                <table width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#B6CBE8"
                    class="MT6">
                    <tr>
                        <td>
                            <asp:GridView ID="MyGridView" runat="server" Width="100%" AutoGenerateColumns="False"
                                DataKeyNames="issue" CellPadding="0" OnRowDataBound="MyGridView_RowDataBound">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <div style="height: 26px; background-color: #E9F3FE" class="L_zi1">
                                                开奖时间</div>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# FormatData(Eval("date")) %>
                                        </ItemTemplate>
                                        <ItemStyle Width="25%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <div style="height: 26px; background-color: #E9F3FE" class="L_zi1">
                                                期号</div>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#Eval("issue") %>
                                        </ItemTemplate>
                                        <ItemStyle Width="20%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <div style="height: 26px; background-color: #E9F3FE" class="L_zi1">
                                                开奖号码</div>
                                        </HeaderTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="55%" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblHao" runat="server" Text=""></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                                <RowStyle BackColor="White" BorderColor="#B6CBE8" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td height="26" valign="middle" bgcolor="#f5f5f5" class="boder_xia">
                            <asp:Literal ID="litContent" runat="server"></asp:Literal>
                            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                                ShowBoxThreshold="10" NavigationButtonType="Image" ButtonImageNameExtension="n"
                                CpiButtonImageNameExtension="r" ImagePath="~/Images/Web/navigation/" NumericButtonType="Image"
                                PagingButtonType="Image" ShowNavigationToolTip="True" OnPageChanged="AspNetPager1_PageChanged"
                                ShowCustomInfoSection="Right" ShowInputBox="Always" Width="100%" BackColor="Transparent"
                                CustomInfoStyle='vertical-align:middle;' class="pagestyle" CustomInfoSectionWidth="35%"
                                HorizontalAlign="Center" NumericButtonCount="7">
                            </webdiyer:AspNetPager>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="kai_rwone">
                
            </div>
        </div>
    </form>
</body>
</html>
