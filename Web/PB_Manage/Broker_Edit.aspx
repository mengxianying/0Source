<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Broker_Edit.aspx.cs" Inherits="Pbzx.Web.PB_Manage.Broker_Edit" %>

<html>
<head runat="server">
    <title>经纪人信息查看</title>

    <script language="javascript" src="JScript/javascript.js" type="text/javascript"></script>

    <script language="javascript" src="JScript/javascript.js" type="text/javascript"></script>

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
            document.getElementById('<%=txtCreateTime.ClientID%>').value=getDate();              
        }
    </script>

    <link href="StyleCss/css.css" rel="stylesheet" type="text/css">
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
                                                当前位置：经纪人信息查看</td>
                                            <td width="9%" align="right">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" cellpadding="2" cellspacing="1" bgcolor="#CED7F7">
                            <tr bgcolor="#F2F8FB">
                                <td width="16%" class="bold">
                                    用户名:</td>
                                <td width="19%">
                                    &nbsp;<asp:Label ID="lblUserName" runat="server"></asp:Label><span class="red12"></span></td>
                                <td width="15%" class="bold">
                                    折扣等级:</td>
                                <td width="50%">
                                    &nbsp;<asp:DropDownList ID="ddlgrade" runat="server">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    申请时间:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblApply_time" runat="server" Text=""></asp:Label><span class="red12"></span></td>
                                <td class="bold">
                                    折扣值:</td>
                                <td>
                                    &nbsp;<asp:DropDownList ID="ddlrate" runat="server">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    最后登录时间:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblLastLogin_time" runat="server"></asp:Label></td>
                                <td class="bold">
                                    状态:</td>
                                <td>
                                    <asp:DropDownList ID="ddlsate" runat="server">
                                        <asp:ListItem Selected="True" Value="0">未审核</asp:ListItem>
                                        <asp:ListItem Value="1">正常</asp:ListItem>
                                        <asp:ListItem Value="3">未通过</asp:ListItem>
                                        <asp:ListItem Value="2">锁定</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    本年度交易总额:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblYear_tradeMoney" runat="server"></asp:Label>
                                    <span class="red12"></span>
                                </td>
                                <td class="bold">
                                    审核者:</td>
                                <td>
                                    &nbsp;<asp:TextBox ID="txtManager" runat="server" Width="120"></asp:TextBox><span
                                        class="red12"></span></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    本年度获益总额:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblYear_incomeMoney" runat="server"></asp:Label></td>
                                <td valign="top" class="bold">
                                    审核时间:</td>
                                <td valign="top">
                                    &nbsp;<asp:TextBox ID="txtCreateTime" runat="server"></asp:TextBox>
                                    <input type="button" value="获取当前时间" onclick="javascript:getnowtime()" style="width: 101px" /><br />
                                    时间格式为“年-月-日 时:分:秒”，如：<font color="#0000FF">2003-5-12 12:32:47</font> <span style="color: #ff0000">
                                        *<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCreateTime"
                                            ErrorMessage="添加时间不能为空" Display="Dynamic"></asp:RequiredFieldValidator></span></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    总交易金额:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblTotal_tradeMoney" runat="server"></asp:Label></td>
                                <td rowspan="4
								" valign="top" class="bold">
                                    备注信息：
                                </td>
                                <td rowspan="4" valign="top">
                                    &nbsp;<asp:TextBox ID="txtRemark" runat="server" Rows="6" TextMode="MultiLine" Width="280px"></asp:TextBox>
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnUp" runat="server" Text="确定提交" OnClick="btnUp_Click" />
                                    &nbsp;<span class="red12"></span> &nbsp;<span class="red12"></span></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    总获益金额:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblTotal_incomeMoney" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    本年度起始时间:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblYearStart_time" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    最后交易时间:</td>
                                <td>
                                    <span class="red12">&nbsp;<asp:Label ID="lblLastTrade_time" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#7694D2"
                class="MT" id="really" runat="server" visible="false">
                <tr>
                    <td bgcolor="#F3F3F3">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="Right_bg1">
                                    <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                                        <tr>
                                            <td width="91%" align="left">
                                                用户真实信息</td>
                                            <td width="9%" align="right">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" cellpadding="2" cellspacing="1" bgcolor="#CED7F7">
                            <tr bgcolor="#F2F8FB">
                                <td width="15%" class="bold">
                                    真实姓名:</td>
                                <td width="36%">
                                    &nbsp;<asp:Label ID="lblRealName" runat="server"></asp:Label></td>
                                <td width="15%" class="bold">
                                    性别:</td>
                                <td width="34%">
                                    &nbsp;<asp:Label ID="lblSex" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    身份证号:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblCardID" runat="server"></asp:Label></td>
                                <td class="bold">
                                    出生年月:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblBirthday" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    联系电话:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblTelphone" runat="server"></asp:Label></td>
                                <td class="bold">
                                    E-mail:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblEmail" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    手机号码:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblMobile" runat="server"></asp:Label></td>
                                <td class="bold">
                                    QQ号码:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblQQ" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    省份:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblProvince" runat="server"></asp:Label></td>
                                <td class="bold">
                                    MSN:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblMSN" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    城市:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblCity" runat="server"></asp:Label></td>
                                <td class="bold">
                                    邮编:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblPostCode" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    详细地址:</td>
                                <td colspan="3">
                                    &nbsp;<asp:Label ID="lblAddress" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    银行卡号:</td>
                                <td>
                                    &nbsp;
                                    <asp:Label ID="lblAccountNumber" runat="server"></asp:Label></td>
                                <td class="bold">
                                    发卡银行:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblBankName" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    开户行:</td>
                                <td colspan="3">
                                    &nbsp;<asp:Label ID="lblBankInfo" runat="server"></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
