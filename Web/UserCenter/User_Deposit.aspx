<%@ Page Language="C#" AutoEventWireup="true" Codebehind="User_Deposit.aspx.cs" Inherits="Pbzx.Web.UserCenter.User_Deposit" %>

<%@ Register Src="../Contorls/UcRegRealInfo.ascx" TagName="UcRegRealInfo" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>我要充值</title>
    <link href="../css/user_center.css" rel="stylesheet" type="text/css" />
    <link type="text/css" href="/css/demos.css" rel="stylesheet" />
    <link type="text/css" href="/css/css.css" rel="stylesheet" />

    <script type="text/javascript" src="/javascript/jquery-1.3.2.js"></script>

    <script type="text/javascript" src="/javascript/jquery.blockUI.js"></script>

    <script type="text/javascript" src="/UserCenter/js/advance.js"></script>

    <script type="text/javascript">
    function Charge_value(n){
          var i;         
          for(i=0;i < 11;i++)
          {
           document.getElementById("Charge"+i).style.display = "none";          
          }
          document.getElementById("Charge"+n).style.display = ""; 
          document.getElementById("Charge0").style.display = "";
          
          if(n<5)
          {    
            document.getElementById("radio"+n).checked = true;
         //document.frm_take_money.pay_type.value=document.getElementById("radio"+n).value;
          }
          else          
          {
              for(j=1;j < 5;j++)
              {
                 document.getElementById("radio"+j).checked = false;
              }
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
<body style="height: 360px;">
    <form id="form1" runat="server">
        <div>
            <div>
                <table width="805" border="0" align="center" cellpadding="3" cellspacing="0" class="uc_MT10">
                    <tr>
                        <td width="20" class="uc_xia" height="25">
                            <img src="../images/web/Uc_li.gif" alt="" /></td>
                        <td width="785" class="uc_xia" valign="bottom" align="left">
                            <span class="uc_font_blue14">请选择充值方式</span></td>
                    </tr>
                </table>
                <table width="805" border="0" cellpadding="0" cellspacing="1" bgcolor="#FFFFFF" align="center">
                    <tr>
                        <td colspan="6" align="left">
                            <img src="../images/web/u_line.gif" height="1" /></td>
                    </tr>
                    <tr bgcolor="#F9F9F9">
                        <td width="20%" height="25" align="center">
                            <span class="black" onclick="Charge_value(1)" style="cursor: hand;">
                                <img src="../images/web/kuaiqian.jpg" width="111" height="44" style="vertical-align: middle;" /></span></td>
                        <td width="20%" align="center">
                            <span class="black" onclick="Charge_value(2)" style="cursor: hand;">
                                <img src="../images/web/wangyin.jpg" style="vertical-align: middle;" /></span></td>
                        <td width="20%" align="center">
                            <span class="black" onclick="Charge_value(3)" style="cursor: hand;">
                                <img src="../images/web/yunwang.jpg" style="vertical-align: middle;" /></span></td>
                        <td width="20%" align="center">
                            <span class="black" onclick="Charge_value(4)" style="cursor: hand;">
                                <img src="/images/web/Pay_treasure.jpg" width="111" height="44" /></span></td>
                        <td width="20%" align="center">
                            <span class="black" onclick="Charge_value(10)" style="cursor: hand;">
                                <img src="../images/web/post.gif" width="111" height="44" /></span></td>
                    </tr>
                    <tr bgcolor="#F9F9F9">
                        <td height="15" colspan="5">
                        </td>
                    </tr>
                    <tr bgcolor="#F9F9F9">
                        <td height="25" align="center">
                            <span class="black" onclick="Charge_value(9)" style="cursor: hand;">
                                <img src="../images/web/zsb_logo_130x30.gif" /></span></td>
                        <td align="center">
                            <span class="black" onclick="Charge_value(5)" style="cursor: hand;">
                                <img src="../images/web/icbc_logo_130x30.gif" /></span></td>
                        <td align="center">
                            <span class="black" onclick="Charge_value(6)" style="cursor: hand;">
                                <img src="../images/web/jsb_logo_130x30.gif" /></span></td>
                        <td align="center">
                            <span class="black" onclick="Charge_value(7)" style="cursor: hand;">
                                <img src="../images/web/comm_logo_130x30.gif" /></span></td>
                        <td align="center">
                            <span class="black" onclick="Charge_value(8)" style="cursor: hand;">
                                <img src="../images/web/abc_logo_130x30.gif" /></span></td>
                    </tr>
                </table>
                <table border="0" cellpadding="0" cellspacing="1" width="805" style="margin-top: 10px;"
                    align="center">
                    <tr>
                        <td colspan="6" style="height: 1px" align="left">
                            <img src="../images/web/u_line.gif" height="1" /></td>
                    </tr>
                </table>
                <table width="780" border="0" cellpadding="0" cellspacing="1" bgcolor="#FFFFFF" style="margin-top: 10px;
                    display: none" id="Charge0" align="center">
                    <tr align="left">
                        <td width="20%" height="25">
                            帐户余额：<asp:Label ID="lblBalance" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <span class="uc_font_red">充值金额：</span><asp:TextBox ID="txMoney" runat="server" MaxLength="8"
                                onkeypress="isnum()" Width="80px"></asp:TextBox>元<span class="uc_font_red">*</span>
                        </td>
                        <td>
                            <asp:ImageButton ID="ibtnCharge" runat="server" ImageUrl="/Images/Web/n_b06.gif"
                                OnClick="ibtnCharge_Click" /></td>
                    </tr>
                </table>
                <table width="805" align="center" border="0" cellpadding="0" cellspacing="1" bgcolor="#FFFFFF"
                    style="margin-top: 10px; display: none" id="Charge1">
                    <tr align="left" bgcolor="#F9F9F9">
                        <td height="25" bgcolor="#F9F9F9" class="black" style="padding-left: 30px;">
                            <img src="../images/web/kuaiqian.jpg" width="111" height="44" style="vertical-align: middle;"
                                alt="" />
                            <input runat="server" name="radio" type="radio" id="radio1" value="99bill"  />
                            <span class="red">说明：</span>如果您没有开通网上支付功能请带齐您的开户资料到银行柜台申请办理。
                        </td>
                    </tr>
                </table>
                <table width="805" align="center" border="0" cellpadding="0" cellspacing="1" bgcolor="#FFFFFF"
                    style="margin-top: 10px; display: none" id="Charge2">
                    <tr align="left" bgcolor="#F9F9F9">
                        <td height="25" bgcolor="#F9F9F9" class="black" style="padding-left: 30px;">
                            <img src="../images/web/wangyin.jpg" style="vertical-align: middle;" />
                            <input runat="server" type="radio" name="radio" id="radio2" value="chinabank"  />
                            <span class="red">说明：</span>如果您没有开通网上支付功能请带齐您的开户资料到银行柜台申请办理。</td>
                    </tr>
                </table>
                <table width="805" align="center" border="0" cellpadding="0" cellspacing="1" bgcolor="#FFFFFF"
                    style="margin-top: 10px; display: none" id="Charge3">
                    <tr align="left" bgcolor="#F9F9F9">
                        <td height="25" bgcolor="#F9F9F9" class="black" style="padding-left: 30px;">
                            <img src="../images/web/yunwang.jpg" style="vertical-align: middle;" />
                            <input runat="server" type="radio" name="radio" id="radio3" value="cncard" />
                            <span class="red">说明：</span>如果您没有开通网上支付功能请带齐您的开户资料到银行柜台申请办理。
                        </td>
                    </tr>
                </table>
                <table width="805" align="center" border="0" cellpadding="0" cellspacing="1" bgcolor="#FFFFFF"
                    style="margin-top: 10px; display: none" id="Charge4">
                    <tr align="left" bgcolor="#F9F9F9">
                        <td height="25" bgcolor="#F9F9F9" class="black" style="padding-left: 30px;">
                            <img src="../images/web/Pay_treasure.jpg" style="vertical-align: middle;" />
                            <input runat="server" type="radio" name="radio" id="radio4" value="alipay" />
                            <span class="red">说明：</span>如果您没有开通网上支付功能请带齐您的开户资料到银行柜台申请办理。
                        </td>
                    </tr>
                </table>
                <table width="805" align="center" border="0" cellpadding="0" cellspacing="1" bgcolor="#FFFFFF"
                    style="margin-top: 10px; display: none" id="Charge9">
                    <tr align="left" bgcolor="#F9F9F9">
                        <td height="25" bgcolor="#F9F9F9" class="black" style="padding-left: 30px;">
                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#f1f1f1">
                                <tr height="30" bgcolor="#FFFFFF" align="center" class="black">
                                    <td width="25%">
                                        <img src="../images/web/zsb_logo_130x30.gif" alt="" style="vertical-align: middle;" />&nbsp;
                                        </td>
                                    <td width="10%">
                                        徐春华</td>
                                    <td width="25%">
                                        6225 8801 0299 0190</td>
                                    <td width="40%">
                                        <a href="http://www.cmbchina.com/" target="_blank" class="blue">http://www.cmbchina.com</a></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table width="805" align="center" border="0" cellpadding="0" cellspacing="1" bgcolor="#FFFFFF"
                    style="margin-top: 10px; display: none" id="Charge5">
                    <tr align="left" bgcolor="#F9F9F9">
                        <td height="25" bgcolor="#F9F9F9" class="black" style="padding-left: 30px;">
                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#f1f1f1">
                                <tr height="30" bgcolor="#FFFFFF" align="center" class="black">
                                    <td width="25%">
                                        <img src="../images/web/icbc_logo_130x30.gif" alt="" /></td>
                                    <td width="10%">
                                        徐春华</td>
                                    <td width="25%">
                                        9558 8002 0020 3039892</td>
                                    <td width="40%">
                                        <a href="http://www.icbc.com.cn" target="_blank" class="blue">http://www.icbc.com.cn</a></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table width="805" align="center" border="0" cellpadding="0" cellspacing="1" bgcolor="#FFFFFF"
                    style="margin-top: 10px; display: none" id="Charge6">
                    <tr align="left" bgcolor="#F9F9F9">
                        <td height="25" bgcolor="#F9F9F9" class="black" style="padding-left: 30px;">
                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#f1f1f1">
                                <tr height="30" bgcolor="#FFFFFF" align="center" class="black">
                                    <td width="25%">
                                        <img src="../images/web/jsb_logo_130x30.gif"></td>
                                    <td width="10%">
                                        徐春华</td>
                                    <td width="25%">
                                        4367 4200 1315 0118 036</td>
                                    <td width="40%">
                                        <a href="http://www.ccb.com/portal/cn/home/index.html" target="_blank" class="blue">
                                            http://www.ccb.com</a></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table width="805" align="center" border="0" cellpadding="0" cellspacing="1" bgcolor="#FFFFFF"
                    style="margin-top: 10px; display: none" id="Charge7">
                    <tr align="left" bgcolor="#F9F9F9">
                        <td height="25" bgcolor="#F9F9F9" class="black" style="padding-left: 30px;">
                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#f1f1f1">
                                <tr height="30" bgcolor="#FFFFFF" align="center" class="black">
                                    <td width="25%">
                                        <img src="../images/web/comm_logo_130x30.gif" alt="" /></td>
                                    <td width="10%">
                                        徐春华</td>
                                    <td width="25%">
                                        405512 2591 9570709</td>
                                    <td width="40%">
                                        <a href="http://www.bankcomm.com/jh/cn/index.html" target="_blank" class="blue">http://www.bankcomm.com</a></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table width="805" align="center" border="0" cellpadding="0" cellspacing="1" bgcolor="#FFFFFF"
                    style="margin-top: 10px; display: none" id="Charge8">
                    <tr align="left" bgcolor="#F9F9F9">
                        <td height="25" bgcolor="#F9F9F9" class="black" style="padding-left: 30px;">
                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#f1f1f1">
                                <tr height="30" bgcolor="#FFFFFF" align="center" class="black">
                                    <td width="25%">
                                        <img src="../images/web/abc_logo_130x30.gif" alt="" /></td>
                                    <td width="10%">
                                        徐春华</td>
                                    <td width="25%">
                                        95599 8001 43116 58117</td>
                                    <td width="40%">
                                        <a href="http://www.abchina.com/cn/hq/index.jsp/lang=cn/index.html" target="_blank"
                                            class="blue">http://www.abchina.com</a></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#FFFFFF"
                    style="margin-top: 10px; display: none" id="Charge10">
                    <tr align="left" bgcolor="#F9F9F9">
                        <td height="25" bgcolor="#F9F9F9" class="black" style="padding-left: 30px;">
                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#f1f1f1">
                                <tr height="30" bgcolor="#FFFFFF" class="black">
                                    <td width="25%" align="center">
                                        <span class="black" style="cursor: hand;">
                                            <img src="../images/web/post.gif" width="111" height="44" alt="" /></span></td>
                                    <td>
                                        收款人：徐春华 &nbsp;&nbsp;卡　号：95510 01000 01091 2584
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table width="805" align="center" border="0" cellpadding="0" cellspacing="1" bgcolor="#FFFFFF"
                    style="margin-top: 10px;">
                    <tr align="left" bgcolor="#F9F9F9">
                        <td height="25" bgcolor="#F9F9F9" class="black" align="left">
                            <img src="../images/web/u_line.gif" height="1" /></td>
                    </tr>
                    <tr align="left" bgcolor="#F9F9F9">
                        <td height="25" bgcolor="#F9F9F9" class="black" style="padding-left: 20px;">
                            <span class="red"><strong>汇款后请及时与客服联系，以便确认充值</strong></span><br />
                            客服电话：010-62132803
                            <br />
                            客服QQ：416883852
                            <br />
                            客服E-MAIL：sale@pinble.com （非上班时间充值请发邮件）<br />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
