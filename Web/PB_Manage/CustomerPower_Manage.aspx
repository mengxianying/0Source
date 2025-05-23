<%@ Page Language="C#" AutoEventWireup="true" Codebehind="CustomerPower_Manage.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.CustomerPower_Manage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head id="Head1" runat="server">
    <title>常用功能设置</title>
    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />

    <script src="JScript/jquery-1.3.2.js" type="text/javascript" language="javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
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
                                                当前位置：常用功能设置</td>
                                            <td width="9%" align="right">
                                                <%--  <asp:Button ID="Button2" runat="server" Text=">>返回" OnClientClick="history.back();return false;" />--%>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" OnRowCreated="MyGridView_RowCreated"
                                        DataKeyNames="ID,RootID,Depth,FlagMenu" BorderStyle="None" BorderWidth="0px"
                                        CellPadding="0" ShowHeader="False">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Panel ID="pnlSub" runat="server">
                                                        <div class="Root_Module">
                                                            <%# getChild(Eval("Name"), Eval("RootID"))%>
                                                            </b>
                                                        </div>
                                                    </asp:Panel>
                                                    <asp:DataList ID="dlChild" DataSource="<%# Dview %>" runat="server" RepeatColumns="9"
                                                        RepeatDirection="Horizontal">
                                                        <ItemTemplate>
                                                            <div class="Module_Right">
                                                                &nbsp;&nbsp;<%# showRights(Eval("Name"), Eval("URL"), Eval("ID"))%></div>
                                                        </ItemTemplate>
                                                    </asp:DataList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <RowStyle BorderStyle="None" BorderWidth="0px" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <table style="width: 300px;">
                                        <tr>
                                            <td>
                                                <input id="btnall" onclick=' $("input[name=myPower.aspx]").each(function(){ $(this).attr("checked",true);})'
                                                    type="button" value="全选" />
                                            </td>
                                            <td>
                                                <input id="antiAll" onclick=' $("input[name=myPower.aspx]").each(function(){ $(this).attr("checked",!this.checked);})'
                                                    type="button" value="反选" /></td>
                                            <td>
                                                &nbsp;<input id="delAll" onclick=' $("input[name=myPower.aspx]").each(function(){ $(this).attr("checked",false);})'
                                                    type="button" value="清空" /></td>
                                            <td>
                                                <asp:Button ID="btnOk" runat="server" OnClick="btnOk_Click" Text="保存" />
                                            </td>
                                        </tr>
                                    </table>
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

<script type="text/javascript">
  $(document).ready(function() {  
// //取消选择
// $("#delAll").click(function(){  
//  $("input[name='myPower.aspx']").each(function(){
//   $(this).attr("checked",false);
//  });  
// });
// 
// //反向选择
// $("#antiAll").click(function(){
//  $("input[name='myPower.aspx']").each(function(){
//   $(this).attr("checked",!this.checked);              
//     });     
 });
 

</script>

