<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcType.ascx.cs" Inherits="Pinble_Ask.Contorls.UcType" %>
<div class="mlbox1">
    <div class="mlbox1_title">
        �������
    </div>
    <div class="mlbox1_content1">
        �ѽ����������<%=HasAnswers%><br />
        �������������<%=NoAnswers%><br />
        �����û�����<%=UserCount %></div>
    <div class="mlbox1_content2">
        <asp:Repeater ID="rptCpBigSort" runat="server">
            <ItemTemplate>
                <a href='QuestionList.aspx?type=<%#Pbzx.Common.Input.Encrypt(Eval("Id").ToString())%>'
                    class="Linl14B" target="_self">
                    <%# Eval("TypeName")%>
                </a>
                <br />
                <%#FormartClass(Eval("Id"))%>
                <br />
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
