<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ChannelManage_Template.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.ChannelManage_Template" %>

<html>
<head id="Head1" runat="server">
    <title>模板生成信息</title>
    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />

    <script language="javascript" src="JScript/javascript.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
    
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
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div id="divOperator" runat="server" visible="false">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="Right_bg1">
                        <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                            <tr>
                                <td align="CENTER">
                                    <asp:LinkButton ID="LinkButton3" runat="server" OnClick="btn_gl_Click" Font-Bold="True"
                                        ForeColor="White">模板生成管理</asp:LinkButton>
                                    |&nbsp;
                                    <asp:LinkButton ID="LinkButton4" runat="server" OnClick="btn_add_Click" Font-Bold="True"
                                        ForeColor="White">添加栏目模板</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="4" cellspacing="1" bgcolor="#7694D2"
                class="MT">
                <tr bgcolor="#F2F8FB">
                    <td class="bold" width="25%">
                        频道名称:</td>
                    <td width="75%">
                        <asp:TextBox ID="txtName" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr bgcolor="#F2F8FB">
                    <td class="bold">
                        频道类别:</td>
                    <td>
                        <asp:DropDownList ID="ddlParent" runat="server" DataTextField="PageName" DataValueField="MapID">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr bgcolor="#F2F8FB">
                    <td class="bold">
                        Aspx页面地址:</td>
                    <td align="left">
                        <asp:TextBox ID="txtAspx" runat="server" Width="380px"></asp:TextBox>
                    </td>
                </tr>
                <tr bgcolor="#F2F8FB">
                    <td class="bold">
                        最终html页面地址:</td>
                    <td align="left">
                        <asp:TextBox ID="txtHtml" runat="server" Width="380px"></asp:TextBox>
                    </td>
                </tr>
                <tr bgcolor="#F2F8FB">
                    <td>
                    </td>
                    <td align="left">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btn_Save" runat="server" CssClass="K2046_Button" Text="保存" OnClick="btn_Save_Click" />
                        <asp:Button ID="btnCancel" runat="server" CssClass="K2046_Button" Text="取消" OnClick="btnCancel_Click" />
                        <asp:HiddenField ID="hfID" runat="server" Value="0" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="divList" runat="server">
            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#7694D2">
                <tr>
                    <td bgcolor="#F3F3F3">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="Right_bg1" style="height: 26px">
                                    <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                                        <tr>
                                            <td width="91%" align="left">
                                                当前位置：模板生成管理</td>
                                            <td width="9%" align="right">
                                                </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellspacing="0" cellpadding="4">
                            <tr>
                                <td align="CENTER">
                                    <a style="text-decoration: un"></a><a href="#" onclick="OpenEdite('PBnet_UrlMaping','MapID','PageName','Html','OrderID','and Depth=0 and TypeID=1 ','800','600')">
                                        主栏目显示排序</a> |&nbsp;
                                    <asp:LinkButton ID="btn_add" runat="server" OnClick="btn_add_Click">添加栏目模板</asp:LinkButton></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
                    <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
                        class="MT">
                        <tr bgcolor="#ffffff">
                            <td>
                                <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" BorderStyle="Solid"
                                    CellPadding="0" Width="100%" DataKeyNames="MapID" CssClass="GridView_Table" OnRowDataBound="MyGridView_RowDataBound">
                                    <FooterStyle CssClass="GridView_Footer" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="全选">
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chbSelect" runat="server" onclick="javascript:if(this.checked==true){AllChecked();}else{UnAllChecked();}" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <input type="checkbox" name="sel" value="<%#Eval("MapID") %>" /></ItemTemplate>
                                            <ItemStyle Width="4%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="序号">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("MapID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="模板名称">
                                            <ItemTemplate>
                                                <div align="left" style="padding-left: 5px;">
                                                    <%# showModule(Eval("RootID"),Eval("PageName"), Eval("Depth"))%>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="HTML地址">
                                            <ItemTemplate>
                                                <a href='<%#Eval("Html").ToString().Replace("~", "")%>' style="cursor: pointer;"
                                                    target="_blank">
                                                    <%#Eval("Html")%>
                                                </a>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ASPX地址">
                                            <ItemTemplate>
                                                <a href='<%#Eval("Aspx").ToString().Replace("~", "")%>' style="cursor: pointer;"
                                                    target="_blank">
                                                    <%#Eval("Aspx")%>
                                                </a>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="生成">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" CommandArgument='<%# Eval("MapID") %>' runat="server"
                                                    OnCommand="LinkButton1_Command">生成</asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="6%" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle CssClass="GridView_Pager" />
                                    <HeaderStyle Font-Bold="True" CssClass="GridView_Header" />
                                    <AlternatingRowStyle CssClass="GridView_AlternatingRow" />
                                    <RowStyle CssClass="GridView_Row" />
                                    <PagerSettings Mode="NumericFirstLast" Visible="False" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                    <table cellpadding="4" cellspacing="0" width="100%">
                        <tr>
                            <td style="width: 20%">
                                <b>数据批量操作：</b></td>
                            <td colspan="4" style="width: 80%">
                                <table style="width: 100%">
                                    <tr>
                                        <td colspan="3">
                                            <asp:Button ID="btnCreate" runat="server" Text="批量生成" OnClientClick="return CheckBatchUpdate('批量生成')"
                                                OnClick="btnCreate_Click" Height="26px" /></td>
                                        <td colspan="3">
                                            &nbsp;<asp:Button ID="btnAllCreate" runat="server" Text="全部生成" OnClientClick="return CheckBatchUpdate('全部生成')"
                                                OnClick="btnAllCreate_Click" Height="26px" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td style="width: 10px;">
                            </td>
                        </tr>
                    </table>
        </div>
    </form>
</body>
</html>
