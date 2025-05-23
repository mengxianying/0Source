<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Ask_Type_Edit.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.Ask_Type_Edit" %>

<html>
<head runat="server">
    <title>问题类别添加 - 拼搏吧 </title>
    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />
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
        function isnum()
        {
            if(event.keyCode<46||event.keyCode>57 || event.keyCode==47)
            {
                event.keyCode=0;
            }
        }  

</script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="Right_bg1">
                        <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                            <tr>
                                <td align="CENTER">
                                    <a href="Ask_Type.aspx" class="zilan">管理问题类别</a> |&nbsp; <a href="Ask_Type_Edit.aspx"
                                        class="zilan">添加问题类别</a> |&nbsp; <a href="#" onclick="OpenEdite('PBnet_ask_Type','Id','TypeName','Depth','OrderID','','800','600')" class="zilan">问题类别排序显示</a>
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
                                <td class="Right_bg1">
                                    <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                                        <tr>
                                            <td width="91%" align="left">
                                                当前位置：<asp:Label ID="lblAction" runat="server"></asp:Label>问题类别</td>
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
                                    问题类别名称:</td>
                                <td width="75%">
                                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    根类别:</td>
                                <td>
                                    <asp:DropDownList ID="ddlParent" runat="server" DataTextField="TypeName" DataValueField="Id" OnSelectedIndexChanged="ddlParent_SelectedIndexChanged" AutoPostBack="True">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                             <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    审核：</td>
                                <td align="left">
                                    <asp:CheckBox ID="cbMenu" runat="server" /></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    排序编号:</td>
                                <td>
                                    &nbsp;<asp:TextBox ID="txtIntOrderID" runat="server" onkeypress="isnum()" Width="50px" >0</asp:TextBox></td>
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
    </form>
</body>
</html>
