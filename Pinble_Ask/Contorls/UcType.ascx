<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcType.ascx.cs" Inherits="Pinble_Ask.Contorls.UcType" %>
<div class="mlbox1">
    <div class="mlbox1_title">
        问题分类
    </div>
    <div class="mlbox1_content1">
        已解决问题数：<%=HasAnswers%><br />
        待解决问题数：<%=NoAnswers%><br />
        参与用户数：<%=UserCount %></div>
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
