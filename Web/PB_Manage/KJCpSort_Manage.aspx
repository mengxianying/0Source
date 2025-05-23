<%@ Page Language="C#" AutoEventWireup="true" Codebehind="KJCpSort_Manage.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.KJCpSort_Manage" EnableEventValidation="false" %>

<%@ Register Src="Controls/UcLottery.ascx" TagName="UcLottery" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head runat="server">
    <title>开奖彩种管理</title>
    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />

    <script language="javascript" src="JScript/javascript.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">        
        function OpenEdite(TbName,PrimaryKey,ColName,ColName2,SortID,StrWhere,myWidth,myHeight) 
        {
            var aa =''; 
            var result = window.open('PopFram/PublicSort.aspx?TbName='+TbName+'&PrimaryKey='+PrimaryKey+'&ColName='+ColName+'&ColName2='+ColName2+'&SortID='+SortID+'&StrWhere='+StrWhere+'', 'newwindow', 'height='+myHeight+', width='+myWidth+', top='+(screen.height-500)/2+',left='+(screen.width-800)/2+' toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, status=no');
            //,'','dialogHeight:800px;dialogWidth:600px;center:yes;help:no;resizable:no;scroll:yes;status:no; scrollbars:No;toolbar:no;menubar:no;location:no;' 
            if(aa == 'yes')
            {
                location.reload(); 
            }
        }
    </script>

</head>
<body onload="GridViewColor();">
    <form id="form2" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div>
            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#7694D2">
                <tr>
                    <td bgcolor="#F3F3F3">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="Right_bg1">
                                    <table width="99%" border="0" cellspacing="0" cellpadding="0" align="center">
                                        <tr>
                                            <td width="100%" align="left" height="26px;">
                                                当前位置：<asp:Label ID="labAction" runat="server" />彩种管理 &nbsp;全国：<asp:Label ID="lblRef1"
                                                    runat="server" Text=""></asp:Label>&nbsp;各省：<asp:Label ID="lblRef2" runat="server"
                                                        Text=""></asp:Label>&nbsp;&nbsp; 高频（超）：<asp:Label ID="lblGaoPinSuper" runat="server" Text="GaoPinSuper"></asp:Label></td>
                                        </tr>
                                    </table>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" align="center">
                                        <tr>
                                            <td class="Right_bg1" width="100%" align="left" height="26px;">
                                                &nbsp;&nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;高频（快）：<asp:Label ID="lblGaoPinFast"
                                                    runat="server" Text=""></asp:Label>&nbsp; 高频（中）：<asp:Label ID="lblGaoPinMid" runat="server"
                                                        Text=""></asp:Label>&nbsp; 高频（慢）：<asp:Label ID="lblGaoPinSlow" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellspacing="0" cellpadding="3">
                            <tr>
                                <td align="CENTER">
                                    <a href="KJCpSort_Manage.aspx">管理彩种首页</a> |<asp:LinkButton ID="lbtnUpdateKJ" runat="server"
                                        Text="更新前台开奖信息" OnClick="lbtnUpdateKJ_Click"></asp:LinkButton>| <a href="KJCpSort_Editor.aspx">
                                            增加彩种</a> | <a href="#" onclick="OpenEdite('PBnet_LotteryMenu','IntId','NvarName','NvarApp_name','NvarOrderId','and NvarClass=\'全国福彩\'','800','700')">
                                                全国福彩排序</a> | <a href="#" onclick="OpenEdite('PBnet_LotteryMenu','IntId','NvarName','NvarApp_name','NvarOrderId','and NvarClass=\'全国体彩\'','800','700')">
                                                    全国体彩排序</a> | <a href="#" onclick="OpenEdite('PBnet_LotteryMenu','IntId','NvarName','NvarApp_name','NvarOrderId','and NvarClass=\'各省福彩\'','800','700')">
                                                        各省福彩排序</a> | <a href="#" onclick="OpenEdite('PBnet_LotteryMenu','IntId','NvarName','NvarApp_name','NvarOrderId','and NvarClass=\'各省体彩\'','800','700')">
                                                            各省体彩排序</a> | <a href="#" onclick="OpenEdite('PBnet_LotteryMenu','IntId','NvarName','NvarApp_name','NvarOrderId','and NvarClass=\'高频福彩\'','800','700')">
                                                                高频福彩排序</a> | <a href="#" onclick="OpenEdite('PBnet_LotteryMenu','IntId','NvarName','NvarApp_name','NvarOrderId','and NvarClass=\'高频体彩\'','800','700')">
                                                                    高频体彩排序</a></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#E7A427"
                class="MT">
                <tr>
                    <td bgcolor="#F7FBFF" align="left">
                        <uc1:UcLottery ID="UcLottery1" runat="server"></uc1:UcLottery>
                    </td>
                </tr>
            </table>
            <%--            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>--%>
            <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
                class="MT">
                <tr bgcolor="#F1F1F1">
                    <td>
                        <asp:GridView ID="MyGridView" runat="server" Width="100%" AutoGenerateColumns="False"
                            DataKeyNames="IntId" CssClass="GridView_Table" OnRowDeleting="MyGridView_RowDeleting"
                            CellPadding="0" OnRowDataBound="MyGridView_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="IntId" HeaderText="序号" ItemStyle-Width="6%" />
                                <asp:BoundField DataField="NvarName" HeaderText="彩种名称" SortExpression="NvarName">
                                    <ItemStyle Width="12%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="所属类别" SortExpression="NvarClass">
                                    <ItemTemplate>
                                        <a href='KJCpSort_Manage.aspx?NvarClass=<%# Eval("NvarClass") %>'>
                                            <%# Eval("NvarClass") %>
                                        </a>
                                    </ItemTemplate>
                                    <ItemStyle Width="12%" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="NvarOrderId" HeaderText="本类排序编号" Visible="False" SortExpression="IntClass_OrderId">
                                    <ItemStyle Width="5%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NvarApp_name" HeaderText="数据库表名" SortExpression="NvarApp_name">
                                    <ItemStyle Width="10%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NvarLott_date" HeaderText="刷新间隔" SortExpression="NvarLott_date">
                                    <ItemStyle Width="8%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="前台是否显示">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnShow" runat="server" CommandArgument='<%# Eval("IntId") %>'
                                            OnCommand="lbtnShow_Command"><%# Convert.ToBoolean(Eval("BitIs_show")) ? "显示" : "<font color=red>不显</font>"%></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="12%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="是否刷新">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnRefresh" runat="server" CommandArgument='<%# Eval("IntId")+"&"+Eval("NvarApp_name") %>'
                                            OnCommand="lbtnRefresh_Command"><%# Convert.ToBoolean(Eval("IsRefresh")) ? "刷新" : "<font color=red>不刷</font>"%></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="12%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="是否启用">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnState" runat="server" CommandArgument='<%# Eval("IntId") %>'
                                            OnCommand="lbtnState_Command"><%# Convert.ToBoolean(Eval("BitState")) ? "启用" : "<font color=red>禁用</font>"%></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="12%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="模板">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnUpdateQX" runat="server" CommandArgument='<%# Eval("NvarName")+"&"+ Eval("NvarApp_name")+"&"+Eval("NvarLott_date")+"&"+Eval("Url") %>'
                                            OnCommand="lbtnUpdateQX_Command">更新</asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="6%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="编辑">
                                    <ItemTemplate>
                                        <a href='KJCpSort_Editor.aspx?ID=<%#Eval("IntId")%>'>编辑</a>
                                    </ItemTemplate>
                                    <ItemStyle Width="6%" />
                                </asp:TemplateField>
                                <asp:CommandField HeaderText="删除" ShowDeleteButton="True" DeleteText="&lt;div id=&quot;de&quot; onclick=&quot;JavaScript:return confirm('确定删除吗？')&quot;&gt;删除&lt;/div&gt; ">
                                    <ItemStyle Width="6%" Wrap="True" />
                                </asp:CommandField>
                            </Columns>
                            <RowStyle CssClass="GridView_Row" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <PagerStyle CssClass="GridView_Pager" />
                            <HeaderStyle Font-Bold="True" CssClass="GridView_Header" />
                            <AlternatingRowStyle CssClass="GridView_AlternatingRow" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <%--                </ContentTemplate>
            </asp:UpdatePanel>--%>
        </div>
        <table cellpadding="2" cellspacing="0" border="0" width="100%">
            <tr>
                <td style="height: 32px" valign="bottom">
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" BackColor="Transparent"
                        FirstPageText="首页" LastPageText="尾页" NextPageText="下页" OnPageChanged="AspNetPager1_PageChanged"
                        PrevPageText="上页" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                        Width="100%" HorizontalAlign="Center" class="pagestyle" CustomInfoSectionWidth="30%"
                        CustomInfoStyle='vertical-align:middle;'>
                    </webdiyer:AspNetPager>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Literal ID="litContent" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
