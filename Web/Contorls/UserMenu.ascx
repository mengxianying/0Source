<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserMenu.ascx.cs" Inherits="Pbzx.Web.Contorls.UserMenu" %>
    <div>
    <table width="100%"  border="0" align="center" cellpadding="0" cellspacing="0" class="vihuang">
	<tr>
		<td>
			<table width="100%" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td align="center">
						<table width="100%" border="0" cellspacing="0" cellpadding="0">
							<tr><td><img src="/images/Web/u_hygl.gif" width="209" height="27" /></td></tr>
							<tr>
								<td align="center" style="height: 44px">
									<table width="100%" border="0" cellspacing="0" cellpadding="0" style="padding-top:7px;">
										<tr>
											<td height="7" style="letter-spacing:3px;"><a href="#" target="mainFrame"  class='red'  >我要充值</a></td>
											<td height="7" style="letter-spacing:3px;"><a href="#" target="mainFrame" class="red" >我要取款</a></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td align="center" >
									<table border="0" cellpadding="0" cellspacing="0" class="u_1" style="margin-bottom:5px">
										<tr><td height="34" onclick="hiddentable()" style="cursor:hand;"><a href="UserCenter.aspx"><img src="/images/Web/head_icon.gif" width="195" height="34" border="0" alt="我的首页" /></a></td></tr>
									</table>
									
									<table border="0" cellpadding="0" cellspacing="0" class="u_2" style="margin-bottom:5px">
										<tr><td height="34" onclick="hiddentable()" style="cursor:hand;"><a href="m_log.aspx" target="mainFrame" onClick="return adv_reg('');"><img src="/images/Web/head_icon.gif" width="195" height="34" border="0" alt="我的帐户" /></a></td></tr>
									</table>
									
									<table border="0" cellpadding="0" cellspacing="0" class="u_4" style="margin-bottom:5px">
										<tr><td height="34" onclick="showtable()" style="cursor:hand;"><img src="/images/Web/head_icon.gif" width="195" height="34" border="0" alt="我的参与" ></td></tr>
									</table>
									
									<table width="100" border="0" cellspacing="0" cellpadding="0" id="table1" style="display:none;">										
										<tr>
											<td><img src="/images/Web/fqsj.gif" width="13" height="13" /></td>
											<td align="left">&nbsp;<a href="Myask.asp" target="mainFrame" class="blue">拼&nbsp;搏&nbsp;吧</a></td>
										</tr>
											<tr>
											<td><img src="/images/Web/fqsj.gif" width="13" height="13" /></td>
											<td align="left">&nbsp;<a href="Myask.asp" target="mainFrame" class="blue">经&nbsp;纪&nbsp;人</a></td>
										</tr>
									</table>
									<table border="0" cellpadding="0" cellspacing="0" class="u_7" style="margin-bottom:5px">
										<tr><td height="34" onclick="hiddentable()" style="cursor:hand;"><a href="Md_userinfo.asp?act=MdUserInfo" target="mainFrame"><img src="/images/Web/head_icon.gif" width="195" height="34" border="0" alt="我的资料" /></a></td></tr>
									</table>
								</td>
							</tr>
						</table>
						<table width="152" height="20" border="0" cellpadding="0" cellspacing="0" class="black">
							<tr>
								<td colspan="3" style="padding-left:3px; " align="left"> 客服电话： <br>
									<span class="red">010-62132803</span><br>客服及保障邮箱：<br>
									<span class="red">service@pinble.com</span><br>意见及投诉邮箱：<br>
									<span class="red">webmaster@pinble.com</span>
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
