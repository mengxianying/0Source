<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcMark.ascx.cs" Inherits="Pinble_Ask.Contorls.UcMark" %>
<%@ Import Namespace="Pbzx.Common" %>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="93%"
    DataKeyNames="ID" OnRowDataBound="GridView1_RowDataBound" ShowHeader="False"
    GridLines="None" CellPadding="0">
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
               <a href='UserShow.aspx?name="<%# Input.Encrypt(Eval("ID").ToString())%>"' target='_blank'><img src="images/N<%=BianHao++  %>.jpg" width="15" height="12" border='0' alt="" /></a>
               
            </ItemTemplate>
            <ItemStyle Width="16%" HorizontalAlign="Center" />
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <a target="_blank" href='UserShow.aspx?name=<%# Input.Encrypt(Eval("ID").ToString()) %>'>
                    <%#Eval("UserName")%>
                </a>
            </ItemTemplate>
            <ItemStyle Width="60%" HorizontalAlign="Left" />
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <%# Convert.ToInt32(Eval("Score")) - Convert.ToInt32(Eval("Pointpenalty")) - Convert.ToInt32(Eval("OtherPointpenalty"))%>
                ·Ö
            </ItemTemplate>
            <ItemStyle Width="24%" CssClass="f12gray" />
        </asp:TemplateField>
        
    </Columns>
</asp:GridView>
