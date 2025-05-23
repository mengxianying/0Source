<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Cancel.aspx.cs" Inherits="Pinble_Market.admin.Cancel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>会员中心-找回密码</title>
    <meta content="0" http-equiv="Expires" />
    <meta content="no-cache" http-equiv="Cache-Control" />
    <meta content="no-cache" http-equiv="Pragma" />
    <meta name="keywords" content="拼搏会员" />
    <meta name="description" content="拼搏" />
    <link rel="stylesheet" type="text/css" href="../css/refund.css">
    <meta name="GENERATOR" content="MSHTML 8.00.7600.16700" />
    <script language="javascript" src="../JS/jquery-1.3.2.js" type="text/javascript"></script>
</head>
<body style="background-color: #effcff">
<form id="form1" runat="server">
    <div id="rwrap">
        <!--头-->
        <div class="return_mid">
            <div class="mid_t">
            </div>
            <div class="mid_c">
                <div class="title">
                    申请退款</div>
                <div class="return_way">
                    请填写申请退款原由</div>
                <div class="return_main">
                    <table width="550" class="table_s_all" border="0" cellspacing="0" cellpadding="0">
                        <tbody>
                                <tr>
                                    <td rowspan="3">
                                        退款原因：</td>
                                    <td width="424" height="25">
                                        <asp:CheckBox ID="cb1" runat="server" Text="连续5期以上没有接收到发布的条件" />
                                    </td>
                                </tr>
                                <tr>
                                    <td height="25">
                                        <asp:CheckBox ID="cb2" runat="server" Text="发布的条件效率太低" />
                                        
                                        </td>
                                </tr>
                                <tr>
                                    <td height="25">
                                        <asp:CheckBox ID="cb3" runat="server" Text="购买错误" />
                                      </td>
                                </tr>

                                <tr>
                                    <td align="left">
                                        申请说明：</td>
                                    <td>
                                       <asp:TextBox ID="txt_gut" runat="server" Height="101px" TextMode="MultiLine" Width="277px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td height="25" align="left">
                                        商户发布的信息：</td>
                                    <td height="25">
                                        <input type="radio" name="radiobutton" value="radiobutton" />
                                        不接收
                                        <input type="radio" name="radiobutton" value="radiobutton" />
                                        接收</td>
                                </tr>
                        </tbody>
                    </table>
                    <div class="btn_s_c">
                        <asp:Button ID="Button1" runat="server" Text="提交" OnClick="Button1_Click" /> </div>
                    <div class="btn_s_c">
                        <asp:Button ID="Button2" runat="server" Text="取消" OnClick="Button2_Click" /></div>
                </div>
            </div>
            <div class="mid_b">
            </div>
        </div>
    </div>
    </form>
</body>
</html>
