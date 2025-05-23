<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndexChanlCount.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.IndexChanlCount" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>栏目显示数设置</title>
    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />
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
                                <strong>栏目显示数设置</strong>
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
                                <strong>首页栏目模块显示数设置：</strong> 单位（条）
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td width="18%" align="right">
                                新闻资讯：
                            </td>
                            <td width="16%" align="left">
                                <asp:TextBox ID="txtNews" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td width="13%" align="right">
                                网站公告：
                            </td>
                            <td width="53%" align="left">
                                <asp:TextBox ID="txtBulletin" runat="server" Width="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right">
                                <span>最新更新（</span>商品）：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtUpdateProduct" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td align="right">
                                最新更新（资源）：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtUpdateSoft" runat="server" Width="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right">
                                资源下载：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtSoft" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td align="right">
                                软件学院：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtSchool" runat="server" Width="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right">
                                拼搏吧：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtBar" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td align="right">
                                热点论坛：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtBbs" runat="server" Width="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right">
                                文字链接：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtLinkCount" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td align="right">
                                图片链接：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="LinkCountPic" runat="server" Width="60px"></asp:TextBox>
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
                                <strong>网站公告显示数设置：</strong> 单位（条）
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td width="18%" align="right">
                                公告类别：
                            </td>
                            <td width="16%" align="left">
                                <asp:TextBox ID="txtBType" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td width="13%" align="right">
                            </td>
                            <td width="53%" align="left">
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right">
                                最新公告：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtBUpdate" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td align="right">
                                热点公告：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtBNewHot" runat="server" Width="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td>
                            </td>
                            <td align="left" colspan="3">
                                <asp:Button ID="btnGongGao" runat="server" Text="提交修改" OnClick="btnIndex_Click" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table width="100%" cellpadding="2" cellspacing="1" border="0" align="center" bgcolor="#CED7F7">
                        <tr bgcolor="#f2f8fb">
                            <td colspan="4" align="left">
                                <strong>新闻资讯显示数设置：</strong> 单位（条）
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td width="18%" align="right">
                                资讯类别：
                            </td>
                            <td width="16%" align="left">
                                <asp:TextBox ID="txtNType" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td width="13%" align="right">
                            </td>
                            <td width="53%" align="left">
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right">
                                最新资讯：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtNUpdate" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td align="right">
                                热点资讯：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtNNewHot" runat="server" Width="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td>
                            </td>
                            <td align="left" colspan="3">
                                <asp:Button ID="btnNews" runat="server" Text="提交修改" OnClick="btnIndex_Click" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <!-- 软件内嵌设置-->
                    <table width="100%" cellpadding="2" cellspacing="1" border="0" align="center" bgcolor="#CED7F7">
                        <tr bgcolor="#f2f8fb">
                            <td colspan="4" align="left">
                                <strong>软件内嵌设置显示数设置：</strong> 单位（条）
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td width="18%" align="right">
                                软件信息显示字数：
                            </td>
                            <td width="16%" align="left">
                                <asp:TextBox ID="txtSoftLength" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td align="right" style="width: 91px">
                                显示条数：
                            </td>
                            <td width="53%" align="left">
                                <asp:TextBox ID="txtSoftCount" runat="server" Width="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right">
                                公告信息显示字数：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtCstLength" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td align="right" style="width: 91px">
                                显示条数：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtCstCount" runat="server" Width="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td>
                            </td>
                            <td align="left" colspan="3">
                                <asp:Button ID="Button2" runat="server" Text="提交修改" OnClick="btnIndex_Click" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table width="100%" cellpadding="2" cellspacing="1" border="0" align="center" bgcolor="#CED7F7">
                        <tr bgcolor="#f2f8fb">
                            <td colspan="4" align="left">
                                <strong>频道公告显示条数设置：</strong> 单位（条）
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right" width="18%">
                                经纪人公告：
                            </td>
                            <td align="left" width="16%">
                                <asp:TextBox ID="txtBrokerBulletin" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td align="right" width="13%">
                            </td>
                            <td align="left" width="53%">
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td>
                            </td>
                            <td align="left" colspan="3">
                                <asp:Button ID="Button1" runat="server" Text="提交修改" OnClick="btnIndex_Click" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table width="100%" cellpadding="2" cellspacing="1" border="0" align="center" bgcolor="#CED7F7">
                        <tr bgcolor="#f2f8fb">
                            <td colspan="4" align="left">
                                <strong>软件学院显示数设置：</strong> 单位（条）
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td width="18%" align="right">
                                软件学院类别：
                            </td>
                            <td width="16%" align="left">
                                <asp:TextBox ID="txtShoolType" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td width="13%" align="right">
                                &nbsp;
                            </td>
                            <td width="53%" align="left">
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right">
                                中间列表显示：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtScholCenterList" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td align="right">
                                热点软件学院：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtScholHot" runat="server" Width="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right">
                                最新商品信息：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtScholsoft" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td align="right">
                                最新资源信息：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtScholsoure" runat="server" Width="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td>
                            </td>
                            <td align="left" colspan="3">
                                <asp:Button ID="btnShool" runat="server" Text="提交修改" OnClick="btnIndex_Click" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table width="100%" cellpadding="2" cellspacing="1" border="0" align="center" bgcolor="#CED7F7">
                        <tr bgcolor="#f2f8fb">
                            <td colspan="4" align="left">
                                <strong>商品资源下载配置</strong> 单位（条）
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right" width="18%">
                                最新商品显示长度：
                            </td>
                            <td align="left" width="16%">
                                <asp:TextBox ID="Softlength" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td align="right" width="13%">
                                最新商品下载行数：
                            </td>
                            <td align="left" width="53%">
                                <asp:TextBox ID="Softlie" runat="server" Width="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="#f2f8fb">
                            <td align="right" width="18%">
                                商品总下载显示长度：
                            </td>
                            <td align="left" width="16%">
                                <asp:TextBox ID="Softxzlength" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td align="right" width="13%">
                                商品总下载显示行数：
                            </td>
                            <td align="left" width="53%">
                                <asp:TextBox ID="Softxzlie" runat="server" Width="60px"></asp:TextBox>
                            </td>
                        </tr>

                            <tr bgcolor="#f2f8fb">
                            <td align="right" width="18%">
                                本月商品长度配置：
                            </td>
                            <td align="left" width="16%">
                                <asp:TextBox ID="SoftMlength" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td align="right" width="13%">
                                本月商品行数配置：
                            </td>
                            <td align="left" width="53%">
                                <asp:TextBox ID="SoftMlie" runat="server" Width="60px"></asp:TextBox>
                            </td>
                        </tr>


                        <tr bgcolor="#f2f8fb">
                            <td align="right" width="18%">
                                最新资源显示长度：
                            </td>
                            <td align="left" width="16%">
                                <asp:TextBox ID="Sourcelegth" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td align="right" width="13%">
                                最新资源显示行数：
                            </td>
                            <td align="left" width="53%">
                                <asp:TextBox ID="Sourcelie" runat="server" Width="60px"></asp:TextBox>
                            </td>
                        </tr>

                              <tr bgcolor="#f2f8fb">
                            <td align="right" width="18%">
                                资源总下载显示长度：
                            </td>
                            <td align="left" width="16%">
                                <asp:TextBox ID="Sourcecountlegth" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td align="right" width="13%">
                                资源总下载显示行数：
                            </td>
                            <td align="left" width="53%">
                                <asp:TextBox ID="Sourcecountlie" runat="server" Width="60px"></asp:TextBox>
                            </td>
                        </tr>


                              <tr bgcolor="#f2f8fb">
                            <td align="right" width="18%">
                                本月资源显示长度：
                            </td>
                            <td align="left" width="16%">
                                <asp:TextBox ID="SourceMlegth" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td align="right" width="13%">
                                本月资源显示行数：
                            </td>
                            <td align="left" width="53%">
                                <asp:TextBox ID="SourceMlie" runat="server" Width="60px"></asp:TextBox>
                            </td>
                        </tr>


                        <tr bgcolor="#f2f8fb">
                            <td>
                            </td>
                            <td align="left" colspan="3">
                                <asp:Button ID="btnzyok" runat="server" Text="提交修改" OnClick="btnIndex_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <br />
    </div>
    </form>
</body>
</html>
