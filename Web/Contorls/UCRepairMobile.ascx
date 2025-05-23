<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UCRepairMobile.ascx.cs" Inherits="Pbzx.Web.Contorls.UcRepairMobile" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<script type="text/javascript" src="/javascript/SearchAjax.js"></script>

<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:Panel ID="p3" runat="server" Width="100%" Visible="true">
    <table width="80%" border="0" align="center" cellpadding="0" cellspacing="0"> 
        <tr>
            <td align="right">
                验证数字:</td>
            <td align="left">
                <asp:TextBox ID="txtMSN" runat="server" Width="210px" MaxLength="20"></asp:TextBox>
                
                <img src="../BoilingSoft/checkcode.aspx?gulsss=<%=System.Guid.NewGuid()%>" id="CHECKCODEIMG"   onclick="javascript:this.src='../BoilingSoft/checkcode.aspx?actcc='+Math.random()" alt="看不清？(点击后更换)" title="看不清？(点击后更换)"    style="cursor:pointer;display:inline-block; vertical-align:middle; height:38px;  cursor:pointer; border-radius:4px"/>
                </td>
        </tr>
          <tr>
            <td align="right" style="height: 40px">
                手机号码:
            </td>
            <td align="left" style="height: 40px">
                <asp:TextBox ID="txtQQ" runat="server" Width="210px" MaxLength="20"></asp:TextBox>  
                </td>
        </tr>
          <tr>
            <td align="right" style="height: 40px">
                手机验证码:
            </td>
            <td align="left" style="height: 40px">
                <asp:TextBox ID="TextBox1" runat="server" Width="210px" MaxLength="20"></asp:TextBox>  
                <input type="button" value="发送验证码" onclick="javascript:tosendsms();" />          
                <iframe name="Runwin" id="Runwin" style="display:none;"></iframe>
                <script type="text/javascript">
                    function tosendsms() {
                        if (document.getElementById("UcRegBase1_txtQQ").value != "" && document.getElementById("UcRegBase1_txtMSN").value != "") {
                            document.getElementById("Runwin").src = "/BoilingSoft/sendsms.aspx?act=sendsms&mobile=" + document.getElementById("UcRegBase1_txtQQ").value + "&checkcode=" + document.getElementById("UcRegBase1_txtMSN").value + "";
                        }
                    }
                </script>
                </td>
        </tr>
         <tr>
            <td valign="bottom" align="center" style="height: 50px">
                <asp:ImageButton ID="btnSave" runat="server" OnClick="btnSave_Click" type="Button" value="保存" /> 
                
            </td>
        </tr>
    </table>
</asp:Panel>
 

         