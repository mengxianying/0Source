<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="login.ascx.cs" Inherits="Pinble_Chipped.Contorls.login" %>
<script src="../jQuery/jquery-1.4.4.js" type="text/javascript"></script>
<script type="text/javascript" src="../js/Header.js"></script>
<script type="text/javascript" src="../js/jquery.blockUI.js"></script>
<script type="text/javascript" src="../js/jquery-ui-1.7.2.custom.min.js"></script>
<script type="text/javascript" src="../js/SearchAjax.js?date=new date().gettime()"></script>
<script src="../jQuery/jquery.XYTipsWindow.2.7.js" type="text/javascript"></script>
<div id="divLogin" style="display: none; cursor: default;">
</div>
<div>
    <table width="95%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td colspan="2" align="right" width="90%">
                <div align="right" style="vertical-align: middle">
                    <span id='aloginShow' style="cursor: pointer; color: #003399;">[<a href="#" onclick="BtnURl()"
                        id='a1'>µ«¬º</a>]&nbsp;</span> <span id="spUser"></span><span style="display: none;"
                            id="userCenter">
                            <label id="moneyID">
                                ******</label>
                            <a id="ckmoney" onclick="checkmoney()" href="#">œ‘ æ”‡∂Ó</a> <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>/UserCenter/User_Center.aspx"
                                target="_blank">&nbsp;≥‰÷µ÷––ƒ&nbsp;</a> </span>|<a href="#" id='aLoginOut' style="display: none;">&nbsp;ÕÀ≥ˆ</a>
                    <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>/Register.aspx" id='aNewUserReg'
                        target="_blank">[◊¢≤·]</a>
                </div>
            </td>
        </tr>
    </table>
</div>
<script>
    function checkmoney() {
        if (document.getElementById("ckmoney").innerHTML == "œ‘ æ”‡∂Ó") {
            document.getElementById("ckmoney").innerHTML = "“˛≤ÿ”‡∂Ó";
            document.getElementById("moneyID").innerHTML = "<%=Pbzx.BLL.publicMethod.GetMoney()%>";
        } else {
            document.getElementById("ckmoney").innerHTML = "œ‘ æ”‡∂Ó";
            document.getElementById("moneyID").innerHTML = "******";
        }
    }
    function BtnURl() {
        location = 'LoginPage.aspx?refUrl=' + location.href.split('/')[location.href.split('/').length - 1];
    }
</script>
