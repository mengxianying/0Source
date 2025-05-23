<%@ Page Language="C#" AutoEventWireup="true" Codebehind="AddProduct.aspx.cs" Inherits="Pbzx.Web.UserCenter.AddProduct"
    EnableEventValidation="False" ViewStateEncryptionMode="Never" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>购买产品 -- 拼搏在线彩神通软件</title>
    <link href="../css/user_center.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript">
    function isnum()
    {
        if(event.keyCode<45||event.keyCode>57)
        {
        event.keyCode=0;
        }
    }   
    function Del(obj)
    {                
       $(obj).parent().parent().remove();
    }                        
    </script>

    <link type="text/css" href="/css/start/jquery-ui-1.7.2.custom.css" rel="stylesheet" />

    <script type="text/javascript" src="/javascript/jquery-1.3.2.js"></script>

    <script type="text/javascript" src="/javascript/jquery.blockUI.js"></script>

    <script type="text/javascript" src="/javascript/jquery-ui-1.7.2.custom.min.js"></script>

    <script type="text/javascript" src="/javascript/Header.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <div id="dialog1" title="拼搏在线彩神通软件网站提醒" style="display: none;">
                <p>
                    提醒内容</p>
            </div>
            <div id="dialog2" title="拼搏在线彩神通软件网站提醒" style="display: none;">
                <p>
                    提醒内容</p>
            </div>
            <asp:Panel ID="pnlAdd" runat="server" Width="100%">
                <table width="800" border="0" align="center" cellpadding="3" cellspacing="0" class="uc_MT10">
                    <tr>
                        <td width="20" class="uc_xia" height="25">
                            <img src="/Images/web/Uc_li.gif" alt="" /></td>
                        <td width="660" class="uc_xia" valign="bottom">
                            <span class="uc_font_blue14">软件选择</span></td>
                        <td width="120">                        
                            <asp:ImageButton ID="ImageButton1" runat="server" OnClick="ImageButton1_Click" ImageUrl="~/Images/Web/delegate_Gou.gif" /></td>
                    </tr>
                </table>
                <asp:UpdatePanel ID="UpAddProduct" runat="server">
                    <ContentTemplate>
                        <table width="800" border="0" cellpadding="4" cellspacing="1" bgcolor="#DDDDDD" align="center">
                            <tr>
                                <td width="200" align="right" valign="top" bgcolor="#F6F6F6">
                                    软件名称：
                                </td>
                                <td align="left" bgcolor="#FFFFFF" width="600">
                                    <asp:DropDownList ID="ddlSoftList" runat="server" Width="170px" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlSoftList_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" bgcolor="#F6F6F6">
                                    软件注册方式：
                                </td>
                                <td align="left" bgcolor="#FFFFFF">
                                    <asp:DropDownList ID="ddlRegType" runat="server" OnSelectedIndexChanged="ddlRegType_SelectedIndexChanged"
                                        AutoPostBack="True" Width="170px">
                                        <asp:ListItem Value="-1">请选择</asp:ListItem>
                                        <asp:ListItem Text="网络注册方式" Value="8"></asp:ListItem>
                                        <asp:ListItem Text="单机绑定方式" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="软件狗方式(用以前软件狗)" Value="9"></asp:ListItem>
                                        <asp:ListItem Text="软件狗方式(购买新软件狗)" Value="7"></asp:ListItem>
                                        <asp:ListItem Text="软件狗方式(绑定新软件狗)" Value="6"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Panel ID="pnlUserName" runat="server" Visible="false">
                                        用户名：<asp:TextBox ID="txtUserName" onfocus="this.select()" CssClass="shop_intput_border"
                                            MaxLength="12" runat="server" OnTextChanged="txtUserName_TextChanged" Width="115px"
                                            AutoPostBack="True"></asp:TextBox>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlRZM" runat="server" Visible="false">
                                        认证码：<asp:TextBox ID="txtRZM" onfocus="this.select()" CssClass="shop_intput_border"
                                            runat="server" MaxLength="16" OnTextChanged="txtRZM_TextChanged" Width="115px"
                                            AutoPostBack="True"></asp:TextBox>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" bgcolor="#F6F6F6">
                                    选择软件单价：
                                </td>
                                <td align="left" bgcolor="#FFFFFF">
                                    <asp:RadioButtonList ID="radio_8" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow" OnSelectedIndexChanged="radio_8_SelectedIndexChanged">
                                    </asp:RadioButtonList>
                                    <asp:Panel runat="server" ID='pnlDays' Visible="false" Style="text-align: left;">
                                        天数：
                                        <asp:TextBox ID="txtDays" runat="server" onfocus="this.select()" onkeypress="isnum()"
                                            Style="width: 30px;" CssClass="shop_intput_border" Text='50' MaxLength="4" AutoPostBack="True"
                                            OnTextChanged="txtDays_TextChanged"></asp:TextBox>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" bgcolor="#F6F6F6">
                                    数量：</td>
                                <td align="left" bgcolor="#FFFFFF">
                                    <asp:TextBox ID="txtQuatity" runat="server" onfocus="this.select()" onkeypress="isnum()"
                                        Style="width: 30px;" CssClass="shop_intput_border" Text='1' MaxLength="3" AutoPostBack="True"
                                        OnTextChanged="txtQuatity_TextChanged"></asp:TextBox><font color="red"></font></td>
                            </tr>
                            <tr>
                                <td align="right" bgcolor="#F6F6F6">
                                    价格：</td>
                                <td align="left" bgcolor="#FFFFFF">
                                    <asp:Label ID="lblPrice" runat="server" Text='0' ForeColor="Red"></asp:Label>元</td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <table width="90%">
                    <tr>
                        <td align="center" height="36">
                            &nbsp;<asp:ImageButton ID="ibnAdd" runat="server" ImageUrl="~/Images/Web/order_save.gif"
                                OnClick="ibnAdd_Click" /></td>
                        <td width="100">
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="pnlList" runat="server" Width="100%" Visible="false">
                <table width="800" border="0" align="center" cellpadding="2" cellspacing="0" class="uc_MT10">
                    <tr>
                        <td width="20" class="uc_xia" height="25">
                            <img src="../images/web/Uc_li.gif" alt="" /></td>
                        <td width="720" class="uc_xia" valign="bottom">
                            <span class="uc_font_blue14">商品列表</span></td>
                        <td valign="bottom" class="uc_xia" width="60">
                        </td>
                    </tr>
                </table>
                <table width="800" border="0" align="center" cellpadding="2" cellspacing="0">
                    <tr>
                        <td>
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="CartID,RegType"
                                GridLines="Horizontal" OnRowDataBound="GridView1_RowDataBound" Width="100%" CssClass="GridViewStyle"
                                BorderWidth="0px">
                                <FooterStyle HorizontalAlign="Right" />
                                <Columns>
                                    <asp:TemplateField HeaderText="软件名称">
                                        <ItemTemplate>
                                            &nbsp;<a href="/Soft_explain.aspx?ID=<%#Pbzx.Common.Input.Encrypt(Eval("pb_SoftID").ToString()) %>"
                                                title='<%#Eval("pb_SoftName")%>' class="S_title1">
                                                <%#Eval("pb_SoftName")%>
                                            </a>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" Width="25%" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="注册方式">
                                        <ItemTemplate>
                                            <%# CheckRegTye(Eval("RegType"), Eval("pb_TypeName"), Eval("pb_DemoUrl"), Eval("pb_RegUrl"))%>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" Width="40%" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <FooterStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="数量">
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblQuantity" runat="server" Text='<%#Eval("Quatity") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="总售价" HtmlEncode="False">
                                        <HeaderStyle HorizontalAlign="Center" Width="12%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="操作">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbtnEdite" runat="server" Text="编辑" CommandArgument='<%# Eval("CartID") %>'
                                                OnCommand="lbtnEdite_Command"></asp:LinkButton>|
                                            <asp:LinkButton ID="lbtnDel" runat="server" Text="删除" OnClientClick="return confirm('你确定删除此商品？')"
                                                CommandArgument='<%# Eval("CartID") %>' OnCommand="lbtnDel_Command"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Width="10%" HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                                <RowStyle CssClass="RowStyle" />
                                <HeaderStyle CssClass="HeaderStyle" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                <table width="800" border="0" align="center" cellpadding="4" cellspacing="0">
                    <tr>
                        <td width="206" align="center">
                            <asp:ImageButton ID="btnbuy" runat="server" ImageUrl="~/Images/Web/order_buy2.gif"
                                OnClick="btnbuy_Click" /></td>
                        <td width="187">
                            &nbsp;</td>
                        <td width="383" align="center">
                            <span class="uc_font_black">总数量：<span class="uc_font_red14"><asp:Label ID="lblSumQuatity"
                                runat="server" Text="0"></asp:Label></span>&nbsp;总价格：<span class="uc_font_red14"><asp:Label
                                    ID="lblSumBookPrice" runat="server" Text="0.00"></asp:Label></span></span>&nbsp;&nbsp;<asp:ImageButton
                                        ID="btnsendp" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/Web/order_sendprice.gif"
                                        OnClick="btnsendp_Click" />
                        </td>
                    </tr>
                </table>
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            </asp:Panel>
            <asp:HiddenField ID="hdfID" runat="server" Value="0" />
        </div>
    </form>
</body>
</html>
