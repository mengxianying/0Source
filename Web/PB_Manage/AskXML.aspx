<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AskXML.aspx.cs" Inherits="Pbzx.Web.PB_Manage.AskXML" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>拼搏吧频道XML设置</title>
    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />
    <style type="text/css">
        .style1
        {
            width: 20%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" cellpadding="0" cellspacing="1" border="0" align="center" bgcolor="#7694D2">
            <tr bgcolor="#f2f8fb">
                <td background="images/Us_table _bg.jpg">
                    <table width="100%" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td background="images/Us_table _bg.jpg" class="webconfigbg">
                                <strong>拼搏吧频道XML设置</strong>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table width="100%" cellpadding="2" cellspacing="1" border="0" align="center" bgcolor="#CED7F7">
                        <tr bgcolor="#f2f8fb">
                            <td colspan="4" align="left">
                                <strong>拼搏吧栏目模块显示数设置：</strong> 单位（条）
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td width="21%" align="right">
                                待解决的问题：
                            </td>
                            <td width="19%" align="left">
                                <asp:TextBox ID="txtCommend" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td width="16%" align="right">
                                近期热点数：
                            </td>
                            <td width="44%" align="left">
                                <asp:TextBox ID="txtHot" runat="server" Width="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right">
                                <span>悬赏分问题</span>：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtPoint" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td align="right">
                                新解决的问题：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtStateY" runat="server" Width="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right">
                                精华推荐：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtStateN" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td align="right">
                                拼搏吧最新公告：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtBarBulletin" runat="server" Width="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td style="height: 28px">
                            </td>
                            <td align="left" colspan="3" style="height: 28px">
                                <asp:Button ID="btnIndex" runat="server" Text="提交修改" OnClick="btnIndex_Click" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table width="100%" cellpadding="2" cellspacing="1" border="0" align="center" bgcolor="#CED7F7">
                        <tr bgcolor="#f2f8fb">
                            <td colspan="4" align="left">
                                <strong>拼搏吧积分设置：</strong>
                            </td>
                        </tr>
                        <%--  <tr bgcolor="#f2f8fb">
                                <td width="181" align="right">
                                    拼搏吧标题：</td>
                                <td align="left" colspan="3">
                                    <asp:TextBox ID="txtWebTitle" runat="server"></asp:TextBox></td>
                            </tr>--%>
                        <tr bgcolor="#f2f8fb">
                            <td width="270" align="right">
                                提问上线后被管理员删除所扣除的积分：
                            </td>
                            <td width="168" align="left">
                                <asp:TextBox ID="txtwenkf" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td width="306" align="right">
                                用户回答被提问者采纳为最佳答案所得积分：
                            </td>
                            <td width="188" align="left">
                                <asp:TextBox ID="txtdajiadf" runat="server" Width="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right">
                                回答上线后被管理员删除所扣除的积分：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtdakf" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td align="right">
                                用户注册时获得的积分：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtregf" runat="server" Width="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right">
                                用户回答一个问题所得的积分：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtdadf" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td align="right">
                                问题被选为精华推荐提问者所得的积分：
                            </td>
                            <td width="188" align="left">
                                <asp:TextBox ID="txttjwendf" runat="server" Width="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right">
                                用户匿名提问所需积分：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtmdf" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td align="right">
                                问题被选为精华推荐最佳回答者所得的积分：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txttjdadf" runat="server" Width="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right">
                                问题过期未处理所扣除的积分：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtgqkf" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td align="right">
                                &nbsp;多少天后设为过期问题：
                            </td>
                            <td width="188" align="left">
                                <asp:TextBox ID="txtOverTime" runat="server" Width="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <%--                            <tr bgcolor="#f2f8fb">
                                <td align="right">
                                    处理过期问题：</td>
                                <td align="left">
                              <asp:TextBox ID="txtclwendf" runat="server" Width="60px"></asp:TextBox>暂时没用到</td>
                                <td align="right">
                                    评论被删除后，评论者的积分将被扣除分：
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtplkf" runat="server" Width="60px"></asp:TextBox>
                                </td>
                            </tr>--%>
                        <tr bgcolor="#f2f8fb">
                            <td>
                            </td>
                            <td align="left" colspan="3">
                                <asp:Button ID="btnjf" runat="server" Text="提交修改" OnClick="btnIndex_Click" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table width="100%" cellpadding="2" cellspacing="1" border="0" align="center" bgcolor="#CED7F7">
                        <tr bgcolor="#f2f8fb">
                            <td colspan="4" align="left">
                                <strong>拼搏吧发帖回帖设置：</strong>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td width="21%" align="right">
                                限制地区：
                            </td>
                            <td width="19%" align="left">
                                <asp:TextBox ID="txtxzaddress" runat="server" Width="268px" Height="99px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                            <td align="right" class="style1">
                                限制字符：
                            </td>
                            <td width="44%" align="left" rowspan="2">
                                <asp:TextBox ID="txtxzzf" runat="server" Width="366px" Height="185px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right">
                                屏蔽IP：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtxzip" runat="server" Width="267px" Height="87px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                            <td align="right" class="style1">
                                &nbsp;
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right">
                                消息提示：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtmsg" runat="server" Width="266px"></asp:TextBox>
                            </td>
                            <td align="right" class="style1">
                                审核：
                            </td>
                            <td align="left">
                                <asp:RadioButtonList ID="rdblistsh" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1">启用审核</asp:ListItem>
                                    <asp:ListItem Value="0">关闭审核</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td style="height: 28px">
                            </td>
                            <td align="left" colspan="3" style="height: 28px">
                                <asp:Button ID="btnyz" runat="server" Text="提交修改" OnClick="btnyz_Click" />
                            </td>
                        </tr>
                    </table>
                            <br />
                        <table width="100%" cellpadding="2" cellspacing="1" border="0" align="center" bgcolor="#CED7F7">
                        <tr bgcolor="#f2f8fb">
                            <td colspan="4" style="height: 18px; text-align: left">
                                <strong>拼搏吧用户登录限制IP管理</strong>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td style="text-align: center; width: 53px;">
                                限制IP：
                            </td>
                            <td style="width: 102px; text-align: center">
                                <asp:TextBox ID="txtuserloginip" runat="server" Height="96px" TextMode="MultiLine" 
                                    Width="163px"></asp:TextBox>
                            </td>
                            <td style="width: 58px; text-align: center">
                                限制省份：&nbsp;
                            </td>
                            <td style="width: 30px; text-align: center">
                                <asp:TextBox ID="txtuserloginaddress" runat="server" Height="98px" TextMode="MultiLine" 
                                    Width="174px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td style="text-align: center; height: 29px;" colspan="4">
                                <asp:Button ID="btnuserlogin" runat="server" OnClick="btnuserlogin_Click" Text="保存修改" 
                                    Width="75px" />&nbsp;
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
