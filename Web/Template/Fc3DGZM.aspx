<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Fc3DGZM.aspx.cs" Inherits="Pbzx.Web.Template.Fc3DGZM" %>

<%@ Import Namespace="Maticsoft.DBUtility" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="Pbzx.Common" %>
<%@ Register Src="../Contorls/Head.ascx" TagName="Head" TagPrefix="uc2" %>
<%@ Register Src="../Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>福彩3D_试机号_开奖号_关注码_拼搏在线彩神通软件</title>
    <meta name="keywords" content="福彩3D,试机号,关注码,福彩 ,福利彩票" />
    <meta name="description" content="彩神通关注码、金码" />
    <meta name="robots" content="all" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />

        <style type="text/css">
<!--
body {
	font-family: "宋体";
	font-size: 14px;
	line-height: 170%;
	color: #000000;
	margin: 0px;
	padding: 0px;
}
td{ text-align:center;}
h1 {
	color: #03005C;
	line-height: 100%;
}
.style1
{
    text-align: right;
}
-->
</style>
</head>
<body>
    <form id="form2" runat="server">
        <uc2:Head ID="Head1" runat="server" />
       <div class="bodyw MT">
            <!---右边开奖部分--->
            <div class="kai_rw">
                       <div>
            <table width="100%" border="0" align="center" cellpadding="2" cellspacing="0" bgcolor="#FFFFFF">
                <tr>
                    <td width="62%" height="22" valign="bottom">
                        <h3 class="style1">福彩3D试机号开奖号关注码历史记录统计</h3>
                    </td>
                    <td width="38%" align="right" class="style1" valign="bottom">
                       <a align="right" href="<%=WebInit.webBaseConfig.WebUrl%>pb_cstp3.htm">查看体彩排列三试机号开奖号关注码历史记录统计&nbsp;&nbsp;&nbsp;&nbsp;</a>
                    </td>
                </tr>
                <tr>
                        <table width="100%" border="0" align="center" cellpadding="2" cellspacing="1" bgcolor="#CECECE">
                            <tr>
                                <td width="17%" bgcolor="#FFDEA4">
                                    <strong>期号</strong></td>
                                <%--<td width="5%" bgcolor="#FFDEA4" >
                                    <strong>机</strong></td>
                                <td width="7%" bgcolor="#FFDEA4">
                                    <strong>球</strong></td>--%>
                                <td width="14%" bgcolor="#FFDEA4">
                                    <strong>模拟试机号</strong></td>
                                <td width="14%" bgcolor="#FFDEA4">
                                    <strong>开奖号</strong></td>
                                <td width="10%" bgcolor="#FFDEA4">
                                    <strong>金码</strong></td>
                                <td width="10%" bgcolor="#FFDEA4">
                                    <strong>银码</strong></td>
                                <td width="10%" bgcolor="#FFDEA4">
                                    <strong>铜码</strong></td>
                                <td width="13%" bgcolor="#FFDEA4">
                                    <strong>中出</strong></td>
                            </tr>
                            <%                               
                                DataTable dt = DbHelperSQL1.Query("select top 31 issue,code,machine,ball,testcode,AttentionCode from FC3DData where code IS NOT NULL and len(code)>0  order  by issue desc ").Tables[0];
                                int row_count = 0;
                                int jin_count = 0;
                                int yin_count = 0;
                                int tong_count = 0;
                                int totalCount = 0;
                                for (int i = dt.Rows.Count - 2; i >= 0;i--)
                                {
                                    bool isFound = false;
                                    DataRow row = dt.Rows[i];
                                    int j = i + 1;                                                                       
                                    string code = row["code"].ToString();
                                    object objAttentionCode = row["AttentionCode"];
                                    string myAttentionCode = "";
                                    if (objAttentionCode != null && objAttentionCode.ToString() !="")
                                    { 
                                        myAttentionCode = row["AttentionCode"].ToString();
                                    }
                                    else
                                    {
                                        string[] temResult = Pbzx.Web.WebFunc.CalGZM(dt.Rows[i + 1]["code"].ToString(), dt.Rows[i + 1]["testcode"].ToString(), row["testcode"].ToString());
                                        myAttentionCode = temResult[0] + temResult[1] + temResult[2];
                                        DbHelperSQL1.ExecuteSql("update FC3DData set AttentionCode='" + myAttentionCode + "' where code='" + row["code"].ToString() + "' ");         
                                    }
                                    string AttentionCode = myAttentionCode;
                                    
                                    string[] gzResult = Pbzx.Common.Method.FormartCSTgzCode(code, AttentionCode);
                                    
                                    if (gzResult[0].Contains("*"))
                                    {
                                       jin_count++;
                                       isFound = true;
                                    }
                                    if(gzResult[1].Contains("*"))
                                    {
                                       yin_count++;
                                       isFound = true;
                                    }
                                    if(gzResult[2].Contains("*"))
                                    {
                                        tong_count++;
                                        isFound = true;
                                    }
                                    if(isFound)
                                    {
                                        totalCount++;
                                    }
                            %>
                            <tr>
                                <td bgcolor="#FFFFFF">
                                    <%=row["issue"].ToString()%>&nbsp;</td>
                               <%-- <td bgcolor="#FFFFFF">
                                     <%=row["machine"].ToString()%></td>
                                <td bgcolor="#FFFFFF">
                                     <%=row["ball"].ToString()%></td>--%>
                                <td bgcolor="#FFFFFF">
                                    <%=row["testcode"].ToString()%></td>
                                <td bgcolor="#FFFFFF">
                                   <%=row["code"].ToString()%></td>
                              
                                    <%=Fmt(gzResult[0])%>  
                               
                                    <%=Fmt(gzResult[1])%>
                                
                                    <%=Fmt(gzResult[2])%>
                                <td bgcolor="#FFFFFF">
                                    中 <%=gzResult[3]%>个</td>
                            </tr>
                            <%
                                }
                            %>
                        </table>
                        <table width="100%" border="0" align="center" cellpadding="4" cellspacing="0" bgcolor="#F9EBDF">
                            <tr>
                                <td width="45%" style="text-align: left; padding-left: 6px;">
                                    <strong>统计期数：30</strong></td>
                                <td width="11%">
                                    <strong><%=jin_count.ToString() %></strong></td>
                                <td width="10%">
                                    <strong><%=yin_count.ToString()%></strong></td>
                                <td width="10%">
                                    <strong><%=tong_count.ToString()%></strong></td>
                                <td width="13%">
                                    <strong>中<%=totalCount.ToString()%>期</strong></td>
                            </tr>
                        </table>
                </tr>
            </table>
        </div>
            </div>
           </div>
                <uc1:Footer ID="Footer1" runat="server" />
                
                
    </form>
</body>
<!-- <script src="/javascript/kf/PinbleService.js"></script> -->
</html>
