<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Nslide.aspx.cs" Inherits="Pbzx.Web.PB_Manage.Nslide" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>新闻幻灯片管理 - 新闻管理</title>
    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />

    <script language="javascript" src="JScript/javascript.js" type="text/javascript"></script>

    <script language="JavaScript" type="text/javascript" src="/configuration/js/Prototype.js"></script>

    <script language="JavaScript" type="text/javascript" src="/configuration/js/Public.js"></script>

    <script language="javascript" type="text/javascript">
        function ParentChange(sender){            
//            if(sender.value == "0"){                
//                document.getElementById("txtUrl").disabled = true;
//            }
//            else{
//                document.getElementById("txtUrl").disabled = false;
//            }
        }
        
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
                                        ForeColor="White">管理幻灯片</asp:LinkButton>
                                    |&nbsp;
                                    <asp:LinkButton ID="LinkButton4" runat="server" OnClick="btn_add_Click" Font-Bold="True"
                                        ForeColor="White">添加幻灯片</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#7694D2"
                class="MT">
                <tr>
                    <td bgcolor="#F3F3F3">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="Right_bg1" style="height: 26px">
                                    <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                                        <tr>
                                            <td width="91%" align="left">
                                                当前位置：<asp:Label ID="lblAction" runat="server"></asp:Label>幻灯片添加</td>
                                            <td width="9%" align="right">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#A4D5EE">
                            <tr bgcolor="#F2F8FB">
                                <td class="bold" width="25%">
                                    幻灯片链接路径：</td>
                                <td width="75%">
                                    <asp:TextBox ID="txtLinkUrl" runat="server" Width="268px"></asp:TextBox>
                                    <span style="color: #ff0000">*</span>(注：使用全路径，例：http://www.pinble.com)</td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    幻灯片图片：</td>
                                <td>
                                    <table cellpadding="0" cellspacing="0" border="0">
                                        <tr bgcolor="#F2F8FB">
                                            <td>
                                                <span onmouseover="javascript:ShowDivPic(this,document.form1.txtThumb.value,'.jpg',1);"
                                                    onmouseout="javascript:hiddDivPic();" style="cursor: pointer;">
                                                    <asp:TextBox ID="txtThumb" runat="server" Width="268px"></asp:TextBox>
                                                </span>
                                            </td>
                                            <td>
                                                <div style="width: 200px; padding-left: 5px;">
                                                    <div style="margin-left: -8px;">
                                                        <%--  <asp:FileUpload ID="FileUploadThumb" runat="server" Width="0px" />--%>
                                                        <%--  <span id="ThumbImageState" class="Upload_Selected">已选择 <a onclick="Upload_Clear(this,'FileUploadThumb','txtThumb');">
                                                            清除</a></span>--%>
                                                        &nbsp;&nbsp;<img src="/Images/Web/s.gif" alt="选择已有图片" border="0" style="cursor: pointer;"
                                                            onclick="selectFile('pic',document.form1.txtThumb,480,600);document.form1.txtThumb.focus();" />
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                    <span style="color: #ff0000">*</span>（注：请上传508*240大小，或者同比例放大的图片）</td>
                            </tr>
                            <tr bgcolor="#f2f8fb">
                                <td class="bold" style="height: 26px">
                                    幻灯片说明：</td>
                                <td style="height: 26px">
                                    <asp:TextBox ID="txtTitle" runat="server" MaxLength="200" Width="300px"></asp:TextBox><span
                                        style="color: #ff0000">*</span>(注：关于此幻灯片的简要说明)</td>
                            </tr>
                            <tr bgcolor="#f2f8fb">
                                <td class="bold" style="height: 26px">
                                    幻灯片排序编号：</td>
                                <td style="height: 26px">
                                    <asp:TextBox ID="txtNOrder" runat="server" Width="22px"></asp:TextBox><span style="color: #ff0000">*</span>(注：请输入数字)</td>
                            </tr>
                            <tr bgcolor="#f2f8fb">
                                <td class="bold" style="height: 26px">
                                    是否启用：</td>
                                <td style="height: 26px">
                                    <asp:CheckBox ID="chbIsEnable" runat="server" Checked="True" /></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td colspan="2" align="center" style="height: 30px">
                                    <asp:Button ID="btn_Save" runat="server" CssClass="K2046_Button" Text="保存" OnClick="btn_Save_Click" />
                                    <asp:Button ID="btnCancel" runat="server" CssClass="K2046_Button" Text="取消" OnClick="btnCancel_Click" />
                                    <asp:HiddenField ID="hfID" runat="server" Value="0" />
                                </td>
                            </tr>
                        </table>
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
                                                当前位置：幻灯片管理</td>
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
                                    <asp:LinkButton ID="btn_gl" runat="server" OnClick="btn_gl_Click">管理幻灯片</asp:LinkButton>
                                    |&nbsp;
                                    <asp:LinkButton ID="btn_add" runat="server" OnClick="btn_add_Click">添加幻灯片</asp:LinkButton>|&nbsp;<a
                                        href="#" onclick="OpenEdite('PBnet_Nslide','ID','Title','LinkUrl','NOrder','','800','600')">
                                        幻灯片显示排序</a></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
<%--            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>--%>
                    <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
                        class="MT">
                        <tr bgcolor="#ffffff">
                            <td>
                                <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" BorderStyle="Solid"
                                    CellPadding="0" Width="100%" DataKeyNames="ID" OnRowCreated="MyGridView_RowCreated"
                                    CssClass="GridView_Table" OnRowDataBound="MyGridView_RowDataBound">
                                    <FooterStyle CssClass="GridView_Footer" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="序号">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ID") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="幻灯片链接路径">
                                            <ItemTemplate>
                                                <%#Eval("LinkUrl")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="幻灯片图片">
                                            <ItemTemplate>
                                                <%#Eval("PicUrl")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="排序">
                                            <ItemTemplate>
                                                <%#Eval("NOrder")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="启用">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtnShow" runat="server" CommandArgument='<%# Eval("ID") %>'
                                                    OnCommand="lbtnShow_Command"><%# Convert.ToBoolean(Eval("IsEnable")) ? "启用" : "<font color=red>不启用</font>"%></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="编辑">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton" CommandArgument='<%# Eval("ID") %>' runat="server"
                                                    OnCommand="LinkButton_Command">编辑</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="删除">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("ID") %>'
                                                    OnClientClick="return Confirm('确定要删除吗？')" OnCommand="LinkButton2_Command">删除</asp:LinkButton>
                                            </ItemTemplate>
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
              <%--  </ContentTemplate>
            </asp:UpdatePanel>--%>
        </div>
    </form>
</body>
</html>
