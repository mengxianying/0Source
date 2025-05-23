<%@ Page Language="C#" AutoEventWireup="true" Codebehind="SoftConfig_Editor.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.CST.SoftConfig_Editor" %>

<html>
<head id="Head1" runat="server">
    <title>软件配置信息编辑</title>
    <link type="text/css" rel="stylesheet" href="../stylecss/css.css" />

    <script language="javascript" src="../JScript/javascript.js" type="text/javascript"></script>

    <script language="javascript" src="../../javascript/rcolor.gbk.js" type="text/javascript"></script>

    <link href="/system_dntb/skin/default/toolbar.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
    function setValue()
    {       
        document.getElementById("txtCstName").value=document.getElementById("txtSoftwareName").value +" "+ document.getElementById("txtInstallName").value;
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
                                    <a href="SoftConfig_Manage.aspx" class="zilan">软件配置管理 </a>|&nbsp; <a href="SoftConfig_Editor.aspx"
                                        class="zilan">添加软件配置</a>
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
                                                当前位置：
                                                <asp:Label ID="lblAction" runat="server"></asp:Label>软件配置信息</td>
                                            <td width="9%" align="right">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" cellpadding="2" cellspacing="1" bgcolor="#CED7F7">
                            <tr bgcolor="#F2F8FB">
                                <td class="bold" width="25%">
                                    软件类型:</td>
                                <td width="75%">
                                    <asp:TextBox ID="txtSoftwareType" runat="server" Width="100px" MaxLength="3" 
                                        AutoPostBack="True" ontextchanged="txtSoftwareType_TextChanged"></asp:TextBox>&nbsp;<font
                                        color="red">*(格式：数字)</font>&nbsp;</td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    软件类型名:</td>
                                <td>
                                    <asp:TextBox ID="txtSoftwareName" runat="server" Width="150px" MaxLength="200" onblur="setValue()"></asp:TextBox>
                                    <font color="red">*</font>&nbsp;<asp:DropDownList ID="ddlSoftType" runat="server"
                                        AutoPostBack="True" OnSelectedIndexChanged="ddlSoftType_SelectedIndexChanged">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    软件类型名的颜色:</td>
                                <td>
                                    <asp:TextBox ID="txtSoftwareNameColor" runat="server" onfocus="rcolor(this, true)"></asp:TextBox>
                                    <font color="red">*</font>&nbsp;</td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    安装类型:</td>
                                <td>
                                    <font color="red"><asp:DropDownList ID="ddlInstallType" runat="server"
                                        AutoPostBack="True" 
                                        OnSelectedIndexChanged="ddlInstallType_SelectedIndexChanged">
                                        <asp:ListItem>0</asp:ListItem>
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem Value="5"></asp:ListItem>
                                        <asp:ListItem>6</asp:ListItem>
                                        <asp:ListItem>7</asp:ListItem>
                                        <asp:ListItem>8</asp:ListItem>
                                        <asp:ListItem>9</asp:ListItem>
                                        <asp:ListItem>10</asp:ListItem>
                                        <asp:ListItem Value="11"></asp:ListItem>
                                        <asp:ListItem>12</asp:ListItem>
                                        <asp:ListItem>13</asp:ListItem>
                                        <asp:ListItem>14</asp:ListItem>
                                        <asp:ListItem Value="15"></asp:ListItem>
                                    </asp:DropDownList>*</font> <span style="color: #ff0000">(格式：数字)</span></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    安装类型名:</td>
                                <td>
                                    <span style="color: Red;">
                                        <asp:TextBox ID="txtInstallName" runat="server" Width="150px" onblur="setValue()"></asp:TextBox>
                                        <font color="red">*</font>&nbsp;</span></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    安装类型名颜色</td>
                                <td class="Manage_Header">
                                    <asp:TextBox ID="txtInstallNameColor" runat="server" Width="150px" onfocus="rcolor(this, true)"></asp:TextBox>
                                    <font color="red">*</font>&nbsp;</td>
                            </tr>
                            <tr bgcolor="#f2f8fb">
                                <td class="bold">
                                    软件ID</td>
                                <td>
                                    <asp:Label ID="lblID" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    软件名:</td>
                                <td>
                                    <asp:TextBox ID="txtCstName" runat="server" Width="150px"></asp:TextBox>
                                    &nbsp;<font color="red">*</font>&nbsp;</td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    年费用:</td>
                                <td>
                                    <asp:TextBox ID="txtYearMoney" runat="server" MaxLength="8">0</asp:TextBox>元 <font
                                        color="red">*</font> <span style="color: #ff0000">(格式：数字)</span></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    终身费用:</td>
                                <td>
                                    <asp:TextBox ID="txtLifeMoney" runat="server" MaxLength="8">0</asp:TextBox>元 <font
                                        color="red">*</font> <span style="color: #ff0000">(格式：数字)</span></td>
                            </tr>
                            <tr bgcolor="#f2f8fb">
                                <td class="bold">
                                    使用情况:</td>
                                <td>
                                    <asp:RadioButtonList ID="rblFlage" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True" Value="1">正常</asp:ListItem>
                                        <asp:ListItem Value="0">内部使用</asp:ListItem>
                                    </asp:RadioButtonList></td>
                            </tr>
                            <tr bgcolor="#f2f8fb">
                                <td class="bold" style="height: 28px">
                                    版本类型名:</td>
                                <td style="height: 28px">
                                    <asp:TextBox ID="txtVersionTypeName" runat="server" MaxLength="200" onblur="setValue()"
                                        Width="150px"></asp:TextBox><span style="color: #ff0000">*</span>
                                    <asp:DropDownList ID="ddlVersionTypeName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlVersionTypeName_SelectedIndexChanged">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr bgcolor="#f2f8fb">
                                <td class="bold" style="height: 28px">
                                    版本类型值:</td>
                                <td style="height: 28px">
                                    <asp:TextBox ID="txtVersionType" runat="server" MaxLength="200" onblur="setValue()"
                                        Width="150px"></asp:TextBox><span style="color: #ff0000">*</span></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td>
                                </td>
                                <td style="height: 30px">
                                    &nbsp; &nbsp; &nbsp;<asp:Button ID="btn_Save" runat="server" CssClass="K2046_Button"
                                        Text="保存" OnClick="btn_Save_Click" />
                                    &nbsp; &nbsp;
                                    <asp:Button ID="btClose" runat="server" Text="取消" OnClick="btClose_Click" />
                                    <asp:HiddenField ID="hfNewsID" runat="server" Value="0" />
                                    &nbsp;
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
