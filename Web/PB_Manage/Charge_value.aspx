<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Charge_value.aspx.cs" Inherits="Pbzx.Web.PB_Manage.Charge_value" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<base target="_self">
<head runat="server">
    <title>用户充值</title>
    <script type="text/javascript" src="/javascript/jquery-1.3.2.js"></script>

    <script type="text/javascript">
          $(document).ready(function() {  
             $("#btnCheck").click(function()
                    {
                        $.get("/reg.aspx",{SelectUserRealName:$("#txtUname").val()},function(data)
                        {
                            if(data == "")
                            {
                                alert("该用户未升级为高级用户，或者被锁定。");
                            }
                            else
                            {
                                alert("该用户存在，真实姓名为："+data);
                                $("#txtRealName").val(data);
                            }
                        });
                    });
                        		
              });       
              
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
            <div class="title" style="height: 30px; line-height: 30px;">
                用户账户充值</div>
            <table width="100%" border="0" cellspacing="1" cellpadding="5" bgcolor="#CCCCCC"
                style="text-align: center;">
                &nbsp;<tr class="font12px_003399" style="background: #F1F1F1; height: 20px;">
                    <td width="15%">
                        用&nbsp;户&nbsp;名</td>
                    <td align="left" class="font12px_003399" width="85%">
                        <table width="100%">
                            <tr>
                                <td style="width:160px;">
                                    &nbsp;<asp:TextBox ID="txtUname" runat="server" MaxLength="30"></asp:TextBox><span
                                        style="color: #ff0000">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                            runat="server" ControlToValidate="txtUname" ErrorMessage="用户名不能为空"></asp:RequiredFieldValidator>
                                </td>
                                <td align="left" style="width:90px;">
                                  
                                    <input type="button" name="btnCheck" id="btnCheck" value="检测用户"></td>
                                <td style="width: 90px;" align="right">
                                    <span style="color: #ff0000"><span style="color: #000000">真实姓名</span></span></td>
                                <td align="center">
                                    <asp:TextBox ID="txtRealName" runat="server" MaxLength="30"></asp:TextBox><span style="color: #ff0000">*</span>
                                    &nbsp;
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRealName"
                                        ErrorMessage="真实姓名不能为空"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                        <!--<input type="button" name="button2" id="button2" value="按钮" onClick="add_option();">-->
                        &nbsp;</td>
                </tr>
                <tr class="font12px_003399" style="background: #F1F1F1; height: 20px;">
                    <td>
                        充值金额</td>
                    <td align="left" class="black">
                        &nbsp;<asp:TextBox ID="txtPayMoney" runat="server" MaxLength="10" onkeypress="isnum()"></asp:TextBox><span
                            style="color: #ff0000">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPayMoney"
                            ErrorMessage="充值金额不能为空"></asp:RequiredFieldValidator></td>
                </tr>
                <%--                <tr class="font12px_003399" style="background: #F1F1F1; height: 20px;">
                    <td>
                        支付方式</td>
                    <td align="left" class="black">
                        <asp:DropDownList ID="ddlPayType" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr class="font12px_003399" style="background: #F1F1F1; height: 20px;">
                    <td>
                        支付账号</td>
                    <td align="left" class="black">
                        <asp:TextBox ID="txtPayNum" runat="server" MaxLength="20" Width="240px"></asp:TextBox>
                    </td>
                </tr>--%>
                <tr class="font12px_003399" style="background: #F1F1F1;">
                    <td>
                        备注信息</td>
                    <td align="left" class="black">
                        <asp:TextBox ID="txtDetails" runat="server" Height="131px" MaxLength="195" TextMode="MultiLine"
                            Width="80%"></asp:TextBox></td>
                </tr>
                <tr class="font12px_003399" style="background: #F1F1F1;">
                    <td colspan="2">
                        <div class="title" style="height: 30px; line-height: 30px; text-align: center; padding-top: 3px;">
                            <span class="title" style="height: 30px; line-height: 30px; text-align: center; padding-top: 3px;">
                                <asp:Button ID="btnOK" runat="server" Text="提交" OnClick="btnOK_Click" />
                                &nbsp;</span>&nbsp;&nbsp;&nbsp;
                            <input class="btn" id="Button2" type="reset" value="重　写" />&nbsp;&nbsp;&nbsp;
                            <input class="btn" id="Button3" type="button" value="取　消" onclick="javascript:window.close();" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
