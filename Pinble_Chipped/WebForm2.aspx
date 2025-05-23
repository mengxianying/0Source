<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Pinble_Chipped.WebForm2" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="双色球奖项分配："></asp:Label><br />
        一等奖：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        二等奖：<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        三等奖：<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" Text="分配奖金" onclick="Button1_Click" />
        <br />
        <asp:Label ID="Label2" runat="server" Text="七乐彩："></asp:Label><br />
        一等奖：<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        二等奖：<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        三等奖：<asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button2" runat="server" Text="分配奖金" onclick="Button2_Click" />
        <br />
        <asp:Label ID="Label3" runat="server" Text="七星彩："></asp:Label>
        <br />
        一等奖：<asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
        二等奖：<asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
        三等奖：<asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button3" runat="server" Text="分配奖金" onclick="Button3_Click" />
        <br />
        <asp:Label ID="Label4" runat="server" Text="大乐透："></asp:Label>
        <br />
        一等奖：<asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
        二等奖：<asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
        三等奖：<asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button4" runat="server" Text="分配奖金" onclick="Button4_Click" />
        <br />
        <asp:Label ID="Label5" runat="server" Text="22选5："></asp:Label>
        <br />
        一等奖：<asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
        二等奖：<asp:TextBox ID="TextBox14" runat="server"></asp:TextBox>
        三等奖：<asp:TextBox ID="TextBox15" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button5" runat="server" Text="分配奖金" onclick="Button5_Click" />
        <br />
    </div>
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            EnableModelValidation="True" onrowcreated="GridView1_RowCreated">
            <Columns>
                <asp:BoundField HeaderText="序号" />
                <asp:TemplateField HeaderText="编号">
                <ItemTemplate>
                    <%# Eval("QNumber")%>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="发布人">
                <ItemTemplate>
                <%# Eval("UserName")%>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="发布方式">
                <ItemTemplate>
                <%# Eval("") %>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="发布号码">
                <ItemTemplate>
                <%# Eval("ChoiceNum")%>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="中奖标识">
                <ItemTemplate>
                <%# Eval("bounsAllost")%>
                </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                                                    FirstPageText="第一页" LastPageText="最后一页" NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged"
                                                    PrevPageText="上一页" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                                                    Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                                                    CustomInfoSectionWidth="35%" HorizontalAlign="Center">
                                                </webdiyer:AspNetPager>
    </div>
    </form>
</body>
</html>
