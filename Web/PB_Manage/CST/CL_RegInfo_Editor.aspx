<%@ Page Language="C#" AutoEventWireup="true" Codebehind="CL_RegInfo_Editor.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.CST.CL_RegInfo_Editor" %>
<html>
<head id="Head1" runat="server">
    <title>打印注册信息查看</title>
    <link type="text/css" rel="stylesheet" href="../stylecss/css.css" />

    <script type="text/javascript" language="javascript">
             function getDate()
        {
          var d,s,t;
          d=new Date();
          s=d.getFullYear().toString(10)+"-";
          t=d.getMonth()+1;
          s+=(t>9?"":"0")+t+"-";
          t=d.getDate();
          s+=(t>9?"":"0")+t+" ";
          t=d.getHours();
          s+=(t>9?"":"0")+t+":";
          t=d.getMinutes();
          s+=(t>9?"":"0")+t+":";
          t=d.getSeconds();
          s+=(t>9?"":"0")+t;
          return s;
        }     
        function getnowtime()
        {
            document.getElementById('<%=txtPayTime.ClientID%>').value=getDate();              
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%--  <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="Right_bg1">
                    <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                        <tr>
                            <td align="CENTER">
                               <a href="CL_RegInfo_Manage.aspx" class="zilan">管理打印注册信息</a> |&nbsp;
                                    <a href="CL_RegInfo_Editor.aspx" class="zilan">添加打印注册信息</a></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>--%>
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
                                                当前位置：打印注册信息查看</td>
                                            <td width="9%" align="right">
                                              </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" cellpadding="2" cellspacing="1" bgcolor="#CED7F7">
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    ID号:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblId" runat="server"></asp:Label></td>
                                <td class="bold">
                                    客户姓名:</td>
                                <td>
                                    &nbsp;<asp:TextBox ID="txtUserName" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F1F1F1">
                                <td class="bold">
                                    软件名称:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblSoftwareType" runat="server"></asp:Label></td>
                                <td class="bold">
                                    付费方式:</td>
                                <td>
                                    &nbsp;<asp:TextBox ID="txtPayType" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F1F1F1">
                                <td class="bold">
                                    SNs:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblSNs" runat="server"></asp:Label></td>
                                <td class="bold">
                                    付费金额:</td>
                                <td>
                                    &nbsp;<asp:TextBox ID="txtPayMoney" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F1F1F1">
                                <td class="bold">
                                    注册时间:</td>
                                <td>
                                    <asp:Label ID="lblCreateTime" runat="server"></asp:Label></td>
                                <td class="bold">
                                    付费状态:</td>
                                <td>
                                    <asp:RadioButtonList ID="rblPayStatus" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True" Value="1">未付费</asp:ListItem>
                                        <asp:ListItem Value="2">已付费</asp:ListItem>
                                        <asp:ListItem Value="3">免费</asp:ListItem>
                                    </asp:RadioButtonList></td>
                            </tr>
                            <tr bgcolor="#F1F1F1">
                                <td class="bold">
                                    操作员:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblOperator" runat="server"></asp:Label></td>
                                <td class="bold">
                                    付费时间:</td>
                                <td>
                                    &nbsp;<asp:TextBox ID="txtPayTime" runat="server"></asp:TextBox><input type="button"
                                        value="获取当前时间" onclick="javascript:getnowtime()" style="width: 101px" /></td>
                            </tr>
                            <tr bgcolor="#F1F1F1">
                                <td class="bold">
                                    注册方式:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblRegisterType" runat="server"></asp:Label></td>
                                <td class="bold">
                                    付费信息:</td>
                                <td>
                                    &nbsp;<asp:TextBox ID="txtPayDetails" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F1F1F1">
                                <td class="bold">
                                    代理名:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblAgentName" runat="server"></asp:Label></td>
                                <td class="bold">
                                    客户邮件:</td>
                                <td>
                                    &nbsp;<asp:TextBox ID="txtUserEmail" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F1F1F1">
                                <td class="bold">
                                    卡信息:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblCardInfo" runat="server"></asp:Label></td>
                                <td class="bold">
                                    客户电话:</td>
                                <td>
                                    &nbsp;<asp:TextBox ID="txtUserTel" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F1F1F1">
                                <td class="bold">
                                    客户地址:</td>
                                <td colspan="3">
                                    &nbsp;
                                    <asp:TextBox ID="txtUserAddress" runat="server" Width="400px"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F1F1F1">
                                <td class="bold">
                                    备注信息:</td>
                                <td colspan="3">
                                    &nbsp;<asp:TextBox ID="txtRemarks" runat="server" Rows="7" TextMode="MultiLine" Width="520px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr bgcolor="#F1F1F1">
                                <td colspan="4" align="center">
                                    &nbsp;
                                    <asp:Button ID="btn_OK" runat="server" OnClick="btn_OK_Click" Text="确定提交" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   <input type="button" value="关闭" onclick="window.opener=null;window.open('','_self');window.close();" />
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
