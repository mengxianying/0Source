<%@ Page Language="C#" AutoEventWireup="true" Codebehind="PageCount.aspx.cs" Inherits="Pinble_Market.admin.WebAdmin.PageCount" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <style type="text/css">
    body {
	font-size: 12px;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table border="0" style="height: 172px; width: 672px;" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width: 148px">
                        前台列表显示条数：</td>
                    <td style="width: 155px">
                        <asp:TextBox ID="txtwebcount" runat="server" Width="72px"></asp:TextBox>
                        条</td>
                    <td style="width: 250px">
                        商户收费标准：</td>
                    <td style="width: 234px">
                        <asp:TextBox ID="txtprice" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 148px; height: 39px;">
                        后台列表显示条数：</td>
                    <td style="width: 155px; height: 39px;">
                        <asp:TextBox ID="txtmanagecount" runat="server" Width="72px"></asp:TextBox>条</td>
                    <td style="width: 250px; height: 39px;">
                    </td>
                    <td style="width: 234px; height: 39px;">
                        <asp:Button ID="btnok" runat="server" OnClick="btnok_Click" Text="保存" Width="67px" /></td>
                </tr>
                <tr>
                    <td style="width: 148px; height: 15px">
                        商户发布项目默认配置：</td>
                    <td style="width: 155px; height: 15px">
                    </td>
                    <td style="width: 250px; height: 15px">
                    </td>
                    <td style="width: 234px; height: 15px">
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 19px">
                        <table >
                            <tr>
                                <td style="width: 63px; height: 25px">
                                    是否开放：</td>
                                <td style="height: 25px">
                                    <asp:RadioButtonList ID="rdoisoff" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True" Value="0">否</asp:ListItem>
                                        <asp:ListItem Value="1">是</asp:ListItem>
                                    </asp:RadioButtonList></td>
                            </tr>
                            <tr>
                                <td style="width: 63px; height: 10px">
                                    是否置顶：</td>
                                <td style="height: 10px">
                                    <asp:RadioButtonList ID="rdoistop" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True" Value="0">否</asp:ListItem>
                                        <asp:ListItem Value="1">是</asp:ListItem>
                                    </asp:RadioButtonList></td>
                            </tr>
                            <tr>
                                <td style="width: 63px; height: 10px">
                                    是否推荐：</td>
                                <td style="height: 10px">
                                    <asp:RadioButtonList ID="rdoistuijian" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True" Value="0">否</asp:ListItem>
                                        <asp:ListItem Value="1">是</asp:ListItem>
                                    </asp:RadioButtonList></td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 250px; height: 19px">
                        <table>
                            <tr>
                                <td style="width: 63px; height: 25px">
                                    最小金额：</td>
                                <td style="height: 25px">
                                    <asp:TextBox ID="txtbegmomery" runat="server" Width="77px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="width: 63px; height: 10px">
                                    最大金额：</td>
                                <td style="height: 10px">
                                    <asp:TextBox ID="txtendmomery" runat="server" Width="77px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="width: 63px; height: 10px">
                                    提成比率：</td>
                                <td style="height: 10px">
                                    <asp:TextBox ID="txtticheng" runat="server" Width="77px"></asp:TextBox></td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 234px; height: 19px" valign="bottom">
                        <asp:Button ID="btnokSH" runat="server" OnClick="btnokSH_Click" Text="保 存" Width="67px" /></td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 48px" valign="top">
                        <table style="width: 272px" border="0" cellpadding="0" cellspacing="0">
                            <tr style="background-color: Green">
                                <td style="height: 20px; width: 101px;">
                                    <strong>彩种：3D</strong> &nbsp;&nbsp;
                                </td>
                                <td align="right">
                                    <asp:LinkButton ID="linkbut3D" runat="server" Width="76px" OnClick="linkbut3D_Click">添加项目名称</asp:LinkButton>&nbsp;
                                    &nbsp;</td>
                            </tr>
                            <tr valign="top">
                                <td colspan="2">
                                    <asp:GridView ID="grid3d" runat="server" AutoGenerateColumns="False" Width="281px"
                                        OnRowCommand="grid3d_RowCommand" OnRowDataBound="grid3d_RowDataBound" BackColor="White"
                                        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black"
                                        GridLines="Vertical">
                                        <Columns>
                                            <asp:BoundField DataField="number" HeaderText="编号">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="name" HeaderText="名称" />
                                            <asp:TemplateField HeaderText="操作">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton9" runat="server" CommandArgument='<%# BindBJ("3D",Eval("number"),Eval("name"))  %>'
                                                        CommandName="BJ">编辑</asp:LinkButton>&nbsp;
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# BindDE("3D",Eval("number")) %>'
                                                        CommandName="DE">删除</asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="#CCCC99" />
                                        <RowStyle BackColor="#F7F7DE" />
                                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                        <table style="width: 269px" cellpadding="0" cellspacing="0">
                            <tr style="background-color: Green">
                                <td style="height: 20px; width: 101px;">
                                    <strong>彩种：七星彩</strong> &nbsp;&nbsp;
                                </td>
                                <td style="height: 20px" align="right">
                                    <asp:LinkButton ID="linkbutqxc" runat="server" Width="80px" OnClick="linkbutqxc_Click">添加项目名称</asp:LinkButton>
                                    &nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="height: 17px">
                                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" Width="282px"
                                        OnRowCommand="grid3d_RowCommand" OnRowDataBound="grid3d_RowDataBound" BackColor="White"
                                        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black"
                                        GridLines="Vertical">
                                        <Columns>
                                            <asp:BoundField DataField="number" HeaderText="编号">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="name" HeaderText="名称" />
                                            <asp:TemplateField HeaderText="编辑">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton9" runat="server" CommandArgument='<%# BindBJ("七星彩",Eval("number"),Eval("name"))  %>'
                                                        CommandName="BJ">编辑</asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# BindDE("七星彩",Eval("number")) %>'
                                                        CommandName="DE">删除</asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="#CCCC99" />
                                        <RowStyle BackColor="#F7F7DE" />
                                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                        <table style="width: 279px" cellpadding="0" cellspacing="0">
                            <tr style="background-color: Green">
                                <td style="width: 161px; height: 20px;">
                                    <strong>彩种：排列五</strong> &nbsp;&nbsp;
                                </td>
                                <td style="width: 161px; height: 20px; text-align: right">
                                    <asp:LinkButton ID="linkbutplw" runat="server" Width="78px" OnClick="linkbutplw_Click">添加项目名称</asp:LinkButton>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" Width="283px"
                                        OnRowCommand="grid3d_RowCommand" OnRowDataBound="grid3d_RowDataBound" BackColor="White"
                                        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black"
                                        GridLines="Vertical">
                                        <Columns>
                                            <asp:BoundField DataField="number" HeaderText="编号">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="name" HeaderText="名称" />
                                            <asp:TemplateField HeaderText="编辑">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton9" runat="server" CommandArgument='<%# BindBJ("排列5",Eval("number"),Eval("name"))  %>'
                                                        CommandName="BJ">编辑</asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# BindDE("排列5",Eval("number")) %>'
                                                        CommandName="DE">删除</asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="#CCCC99" />
                                        <RowStyle BackColor="#F7F7DE" />
                                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                        <table cellpadding="0" cellspacing="0">
                            <tr style="background-color: Green">
                                <td style="height: 20px">
                                    <strong>彩种：22选5</strong> &nbsp;&nbsp;&nbsp;
                                </td>
                                <td style="height: 20px; text-align: right">
                                    <asp:LinkButton ID="linkbut22x5" runat="server" OnClick="linkbut22x5_Click">添加项目名称</asp:LinkButton>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="False" Width="284px"
                                        OnRowCommand="grid3d_RowCommand" OnRowDataBound="grid3d_RowDataBound" BackColor="White"
                                        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black"
                                        GridLines="Vertical">
                                        <Columns>
                                            <asp:BoundField DataField="number" HeaderText="编号">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="name" HeaderText="名称" />
                                            <asp:TemplateField HeaderText="编辑">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton9" runat="server" CommandArgument='<%# BindBJ("22选5",Eval("number"),Eval("name"))  %>'
                                                        CommandName="BJ">编辑</asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# BindDE("22选5",Eval("number")) %>'
                                                        CommandName="DE">删除</asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="#CCCC99" />
                                        <RowStyle BackColor="#F7F7DE" />
                                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td colspan="2" style="height: 48px" valign="top">
                        <table cellpadding="0" cellspacing="0">
                            <tr style="background-color: Green">
                                <td style="height: 20px">
                                    <strong>彩种：七乐彩</strong> &nbsp;&nbsp;&nbsp;
                                </td>
                                <td style="height: 20px; text-align: right">
                                    <asp:LinkButton ID="linkbutqlc" runat="server" OnClick="linkbutqlc_Click">添加项目名称</asp:LinkButton>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="280px"
                                        OnRowCommand="grid3d_RowCommand" OnRowDataBound="grid3d_RowDataBound" BackColor="White"
                                        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black"
                                        GridLines="Vertical">
                                        <Columns>
                                            <asp:BoundField DataField="number" HeaderText="编号">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="name" HeaderText="名称" />
                                            <asp:TemplateField HeaderText="编辑">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton9" runat="server" CommandArgument='<%# BindBJ("七乐彩",Eval("number"),Eval("name"))  %>'
                                                        CommandName="BJ">编辑</asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# BindDE("七乐彩",Eval("number")) %>'
                                                        CommandName="DE">删除</asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="#CCCC99" />
                                        <RowStyle BackColor="#F7F7DE" />
                                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                        <table cellpadding="0" cellspacing="0">
                            <tr style="background-color: Green">
                                <td style="height: 20px">
                                    <strong>彩种：双色球</strong> &nbsp;&nbsp;&nbsp;
                                </td>
                                <td style="height: 20px; text-align: right">
                                    <asp:LinkButton ID="linkbutssq" runat="server" OnClick="linkbutssq_Click">添加项目名称</asp:LinkButton>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" Width="280px"
                                        OnRowCommand="grid3d_RowCommand" OnRowDataBound="grid3d_RowDataBound" BackColor="White"
                                        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black"
                                        GridLines="Vertical">
                                        <Columns>
                                            <asp:BoundField DataField="number" HeaderText="编号">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="name" HeaderText="名称" />
                                            <asp:TemplateField HeaderText="编辑">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton9" runat="server" CommandArgument='<%# BindBJ("双色球",Eval("number"),Eval("name"))  %>'
                                                        CommandName="BJ">编辑</asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# BindDE("双色球",Eval("number")) %>'
                                                        CommandName="DE">删除</asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="#CCCC99" />
                                        <RowStyle BackColor="#F7F7DE" />
                                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                        <table cellpadding="0" cellspacing="0">
                            <tr style="background-color: Green">
                                <td style="height: 20px">
                                    <strong>彩种：大乐透</strong> &nbsp;&nbsp;&nbsp;
                                </td>
                                <td style="height: 20px; text-align: right">
                                    <asp:LinkButton ID="linkbutdlt" runat="server" OnClick="linkbutdlt_Click">添加项目名称</asp:LinkButton>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="height: 17px">
                                    <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" Width="280px"
                                        OnRowCommand="grid3d_RowCommand" OnRowDataBound="grid3d_RowDataBound" BackColor="White"
                                        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black"
                                        GridLines="Vertical">
                                        <Columns>
                                            <asp:BoundField DataField="number" HeaderText="编号">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="name" HeaderText="名称" />
                                            <asp:TemplateField HeaderText="编辑">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton9" runat="server" CommandArgument='<%# BindBJ("大乐透",Eval("number"),Eval("name"))  %>'
                                                        CommandName="BJ">编辑</asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# BindDE("大乐透",Eval("number")) %>'
                                                        CommandName="DE">删除</asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="#CCCC99" />
                                        <RowStyle BackColor="#F7F7DE" />
                                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                        <table cellpadding="0" cellspacing="0">
                            <tr style="background-color: Green">
                                <td style="height: 20px">
                                    <strong>彩种：31选7 </strong>&nbsp;&nbsp;
                                </td>
                                <td style="height: 20px; text-align: right">
                                    <asp:LinkButton ID="linkbut31xq7" runat="server" OnClick="linkbut31xq7_Click">添加项目名称</asp:LinkButton>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="GridView8" runat="server" AutoGenerateColumns="False" Width="279px"
                                        OnRowCommand="grid3d_RowCommand" OnRowDataBound="grid3d_RowDataBound" BackColor="White"
                                        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black"
                                        GridLines="Vertical">
                                        <Columns>
                                            <asp:BoundField DataField="number" HeaderText="编号">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="name" HeaderText="名称" />
                                            <asp:TemplateField HeaderText="编辑">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton9" runat="server" CommandArgument='<%# BindBJ("31选7",Eval("number"),Eval("name"))  %>'
                                                        CommandName="BJ">编辑</asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# BindDE("31选7",Eval("number")) %>'
                                                        CommandName="DE">删除</asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="#CCCC99" />
                                        <RowStyle BackColor="#F7F7DE" />
                                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
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
