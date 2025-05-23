<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cut_valueSXF.aspx.cs" Inherits="Pbzx.Web.PB_Manage.Cut_valueSXF" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<base target="_self">
<head id="Head1" runat="server">
    <title>用户扣款</title>

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
                汇款手续费填写</div>
            <table width="100%" border="0" cellspacing="1" cellpadding="5" bgcolor="#CCCCCC"
                style="text-align: center;">
                &nbsp;<tr class="font12px_003399" style="background: #F1F1F1; height: 20px;">
                    <td width="25%" align="right">
                        订单号：</td>
                    <td align="left" class="font12px_003399" width="85%">
                                    &nbsp;<asp:TextBox ID="txtOrderID" runat="server" MaxLength="30"></asp:TextBox><span
                                        style="color: #ff0000">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                            runat="server" ControlToValidate="txtOrderID" ErrorMessage="订单号不能为空"></asp:RequiredFieldValidator>
                        
                   </td>
                </tr>
                <tr class="font12px_003399" style="background: #F1F1F1; height: 20px;">
                    <td align="right" width="25%">
                        手续费金额：</td>
                    <td align="left" class="black">
                        &nbsp;<asp:TextBox ID="txtTradeMoney" runat="server" MaxLength="10" onkeypress="isnum()"></asp:TextBox><span
                            style="color: #ff0000">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTradeMoney"
                            ErrorMessage="扣款金额不能为空"></asp:RequiredFieldValidator></td>
                </tr>
                <tr class="font12px_003399" style="background: #f1f1f1; height: 20px">
                    <td align="right">
                        银行名称：</td>
                    <td align="left" class="black">
                        &nbsp;<asp:DropDownList ID="ddlBankName" runat="server">
                        </asp:DropDownList></td>
                </tr>
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
