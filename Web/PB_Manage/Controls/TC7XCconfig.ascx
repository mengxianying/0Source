<%@ Control Language="C#" AutoEventWireup="true" Codebehind="TC7XCconfig.ascx.cs"
    Inherits="Pbzx.Web.PB_Manage.Controls.TC7XCconfig" %>
<%@ Import Namespace="System.Data" %>
<%  Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic(); %>

<%   void TC7XC_editcode_main(){  basficDAL.IsCst = true;%>
<form name="form1" method="post" action="CpdataAdmin.aspx?flag=TC7XC&subflag=request">
    <table width="80%" border="0">
        <tr>
            <th width="33%" scope="col">
                <div align="left">
                    <input type="submit" name="submit" value="添加新的开奖信息">
                </div>
            </th>
            <th width="33%" scope="col">
                <div align="center">
                    <input type="submit" name="submit" value="删除最近一期中奖信息" onclick="{if(confirm('你确定要删除吗?')){return true;}return false;}">
                </div>
            </th>
            <th width="33%" scope="col">
                <div align="right">
                    <input type="button" name="button" value="返  回" onclick="javascript:history.back(1)">
                </div>
            </th>
        </tr>
    </table>
</form>
<table width="80%" border="1">
    <tr bgcolor="#0000FF">
        <th width="12%" height="20" scope="col">
            <font color="#FFFFFF">开奖日期</font></th>
        <th width="14%" scope="col">
            <font color="#FFFFFF">开奖期号</font></th>
        <th width="11%" scope="col">
            <font color="#FFFFFF">开奖号码</font></th>
        <th width="11%" scope="col">
            <font color="#FFFFFF">操作</font></th>
    </tr>
    <%
        string issue="";
        string sql = "select top 30 * from TC7XCData order by date desc";
        
        DataTable dt = basicDAL.GetLisBySql(sql);
        foreach(DataRow row in dt.Rows)
        {
            issue = row["issue"].ToString();      
    %>
    <tr>
        <td>
            <div align="center">
                <%=row("date")%>
            </div>
        </td>
        <td>
            <div align="center">
                <%=issue%>
            </div>
        </td>
        <td>
            <div align="center">
                <font color="#FF0000">
                    <%=row("code")%>
                </font>
            </div>
        </td>
        <td>
            <%=row("LastModifyTime")%>
        </td>
        <td>
            <a href='#' onclick='window.open ("?action=getip&tip=<%=row("OpIp")%>", "newwindow", "height=150, width=200, top=100, left=500,toolbar=no, menubar=no, scrollbars=no, resizable=no, location=no, status=no")　'>
                <%=row("OpIp")%>
            </a>
        </td>
        <td>
            <%=row("OpName")%>
        </td>
        <td>
            <div align="center">
                <a href="CpdataAdmin.aspx?cpid=4&flag=TC7XC&subflag=modifyrequest&date=<%=row("date")%>&issue=<%=row("issue")%>">
                    修改</a></div>
        </td>
    </tr>
    <%
        }
    %>
</table>
<%} %>
<%
void TC7XC_add_code_main(object bModify,object sdate,object sissue)
{
    string code, money, first, second, summoney, bigsmallmoney, oddevenmoney, subflag;
    	
	if (bool.Parse(bModify.ToString()) == false )
    {
		string  sql = "select top 1 * from TC7XCData order by date desc";
	    DataTable dt = basicDAL.GetLisBySql(sql);
        
		DateTime sdate = DateTime.Parse(dt.Rows[0]["date"].ToString());
        int tempInt = int.Parse(dt.Rows[0]["issue"].ToString()) +1;
		string sissue = tempInt.ToString();

		
         //七星彩开奖为：每周二、周五、周日
        switch(sdate.DayOfWeek)
        {
            case 1: //星期天
                sdate = sdate.AddDays(2);//下个星期二
                break;
            case 3:   //星期二 
                 sdate = sdate.AddDays(3);//下个星期五
                break;
            case 6: // 星期五
                 sdate = sdate.AddDays(3);// 下个星期天 
                break;
        }
		
		if(sdate > DateTime.Now)
        { 
			Response.Write("<br><br><font color=blue>最新数据已经录入，请到下期开奖日再来录入新的数据！</font><br><br><br><a href='javascript:history.back(1)'>返回体彩七星彩开奖信息管理</a><br>");
		}
        //跨年处理 
        if(sdate.Year != sissue.Substring(0,4))
        {
            sissue = DateTime.Now.Year+"001";
        }
            
	 	code = "";
		money = "";
		first = "5000000";
		second = "";
		summoney = 0;
		bigsmallmoney = 0;
		oddevenmoney = 0;
		subflag = "add";
    }
	else
    {
		sql = "select * from TC7XCData where issue='" + sissue + "'";
		DataTable dt = basicDAL.GetLisBySql(sql);
		sdate = dt.Rows[0]["date"];
		sissue = dt.Rows[0]["issue"];
		code =dt.Rows[0]["code"];
		summoney = dt.Rows[0]["summoney"];
        
		bigsmallmoney = dt.Rows[0]["bigsmallmoney"];
		oddevenmoney = dt.Rows[0]["oddevenmoney"];
		money = dt.Rows[0]["money"];
		first = dt.Rows[0]["first"];
		second = dt.Rows[0]["second"];		
		subflag = "modify";
	}
%>
<form name="form1" method="post" action="CpdataAdmin.aspx?cpid=4&flag=TC7XC&subflag=<%=subflag%>"
    onsubmit="return CheckTC7XCData(this)">
    <table width="98%" border="0" align="center" cellpadding="0" cellspacing="1" style="border: 1 solid #808080">
        <tr>
            <th colspan="2" height="22">
                <div id="jnkc" align="center">
                </div>

                <script>setInterval("jnkc.innerHTML=new Date().toLocaleString()+' 星期'+'日一二三四五六'.charAt(new Date().getDay());",1000);
                </script>

            </th>
            <tr>
                <td class="forumRow" width="30%">
                    <div align="right">
                        开奖期号：</div>
                </td>
                <td class="forumRow">
                    <input name="issue" type="text" value="<%=sissue%>" maxlength="7" <%if bModify = true then response.Write "readonly='1'  style='color:#999999;'"%>>
                    （格式：2004101）</td>
            </tr>
        </tr>
        <tr>
        <td width="30%" class="forumRow">
            <div align="right">
                开奖日期：</div>
        </td>
        <td width="70%" class="forumRow">
            <input name="date" type="text" value="<%=sdate%>" maxlength="10" <%if bModify = true then response.Write "readonly='1' style='color:#999999;'"%>>
            （格式：2004-6-4）</td>
        </tr>
        <tr>
            <td class="forumRow">
                <div align="right">
                    开奖号码：</div>
            </td>
            <td class="forumRow">
                <input name="code" type="text" value="<%=code%>" maxlength="7">
                （格式：1234567）</td>
        </tr>
        <tr>
            <td class="forumRow">
                &nbsp;</td>
            <td class="forumRow">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="forumRow">
                <div align="right">
                    <input type="submit" name="submit" value="<%if (bModify==false){response.Write("增  加");} else{ response.Write("修  改")} %>">
            </td>
            <td class="forumRow">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <input type="button" name="back" value="返  回" onclick="javascript:history.back(1)"></td>
        </tr>
    </table>
</form>
<% 
}
%>





























<%--

<%
  void  TC7XC_add_code(object bModify, object sdate, object issue,object code,object money,object first,object second,object summoney,object bigsmallmoney,object oddevenmoney)
  {
	sql = "select * from TC7XCData where issue='" + issue + "'"
	
	rs.open sql, conn_cst, 1, 3
	if rs.bof and rs.eof then
		if bModify = true then	' 修改
			response.Write("<br><br><font color=blue>修改失败，请于管理员联系！</font><br><br>")
			rs.close()
			set rs = nothing
			call webend()
			response.end()
		end if
		' 增加
		rs.addnew()
		rs("date") = sdate
		rs("issue") = issue
	else
		if bModify = false then	' 增加
			response.write("<br><br><font color=blue>该开奖日期的开奖信息已经存在，添加失败！</font><br><br><a href='javascript:history.back(1)'>返回重新编辑</a><br>")
			rs.close()
			set rs = nothing
			call webend()
			response.end()
		end if
	end if
	dim i, ntemp, strtemp
	rs("date") = sdate
	rs("issue") = issue
	rs("code") = code
	rs("money") = money
	rs("first") = first
	rs("second") = second
	ntemp = 0
	for i=1 to 7 
		ntemp = ntemp + cint(mid(code, i, 1))
	next
	rs("sum") = cstr(ntemp)
	rs("summoney") = summoney
	strtemp = ""
	for i=1 to 7 
		if cint(mid(code, i, 1)) > 4 then 
			strtemp = strtemp + "大"
		else
			strtemp = strtemp + "小"
		end if
	next
	rs("bigsmall") = strtemp
	rs("bigsmallmoney") = bigsmallmoney
	strtemp = ""
	for i=1 to 7 
		if cint(mid(code, i, 1)) mod 2 = 0 then 
			strtemp = strtemp + "双"
		else
			strtemp = strtemp + "单"
		end if
	next
	rs("oddeven") = strtemp
	rs("oddevenmoney") = oddevenmoney
	rs("LastModifyTime") = now()
	rs.update()
	rs.close()
	set rs = nothing
	dim tmsg,tflag,turlmsg
	if bModify = true then
		response.Write("<br><br><font color=blue>修改开奖信息成功！</font><br><br><a href='dataadmin.asp?flag=TC7XC'>返回体彩七星彩开奖信息列表</a><br>")
		tmsg="修改开奖信息成功！"
		tflag="TC7XC"
		turlmsg="返回体彩七星彩开奖信息列表"
	else
		response.Write("<br><br><font color=blue>增加开奖信息成功！</font><br><br><a href='dataadmin.asp?flag=TC7XC'>返回体彩七星彩开奖信息列表</a><br>")
		tmsg="增加开奖信息成功！"
		tflag="TC7XC"
		turlmsg="返回体彩七星彩开奖信息列表"
	end if
	call makeindex2(tmsg,tflag,turlmsg)
  }%>
  
  
  
<%
sub TC7XC_del_code()
	sql = "select top 1 * from TC7XCData order by date desc"
	set rs = server.CreateObject("ADODB.RecordSet")
	rs.open sql, conn_cst, 1, 3
		if rs.bof and rs.eof then
		response.write("<br><br><font color=blue>没有可删除的开奖信息！</font><br><br><a href='javascript:history.back(1)'>返回</a><br>")
		tmsg="没有可删除的开奖信息！"
		tflag="TC7XC"
		turlmsg="返回体彩七星彩开奖信息列表"
	else
		rs.delete()
		response.Write("<br><br><font color=blue>删除最近开奖信息成功！</font><br><br><a href='dataadmin.asp?flag=TC7XC'>返回体彩七星彩开奖信息列表</a><br>")
		tmsg="删除最近开奖信息成功！"
		tflag="TC7XC"
		turlmsg="返回体彩七星彩开奖信息列表"
	end if
	
	rs.close()
	set rs = nothing
	call makeindex2(tmsg,tflag,turlmsg)
end sub
%>
<%
sub TC7XC_editcode_main()
%>
<form name="form1" method="post" action="dataadmin.asp?flag=TC7XC&subflag=request">
    <table width="80%" border="0">
        <tr>
            <th width="33%" scope="col">
                <div align="left">
                    <input type="submit" name="submit" value="添加新的中奖信息">
                </div>
            </th>
            <th width="33%" scope="col">
                <div align="center">
                    <input type="submit" name="submit" value="删除最近一期中奖信息">
                </div>
            </th>
            <th width="33%" scope="col">
                <div align="right">
                    <input type="button" name="button" value="返  回" onclick="javascript:history.back(1)">
                </div>
            </th>
        </tr>
    </table>
</form>
<table width="80%" border="1">
    <tr bgcolor="#0000FF">
        <th width="12%" height="20" scope="col">
            <font color="#FFFFFF">开奖日期</font></th>
        <th width="14%" scope="col">
            <font color="#FFFFFF">开奖期号</font></th>
        <th width="11%" scope="col">
            <font color="#FFFFFF">开奖号码</font></th>
        <th width="11%" scope="col">
            <font color="#FFFFFF">操作</font></th>
    </tr>
    <%
	dim issue, issue2
	sql = "select top 30 * from TC7XCData order by date desc"
	set rs = server.CreateObject("ADODB.RecordSet")
	rs.open sql, conn_cst, 1, 1
	do while not rs.eof
		issue = rs("issue")
    %>
    <tr>
        <td>
            <div align="center">
                <%=rs("date")%>
            </div>
        </td>
        <td>
            <div align="center">
                <%=issue%>
            </div>
        </td>
        <td>
            <div align="center">
                <font color="#FF0000">
                    <%=rs("code")%>
                </font>
            </div>
        </td>
        <td>
            <div align="center">
                <a href="dataadmin.asp?flag=TC7XC&subflag=modifyrequest&date=<%=rs("date")%>&issue=<%=rs("issue")%>">
                    修改</a></div>
        </td>
    </tr>
    <%
		rs.movenext()
	loop
	rs.close()
	set rs = nothing
    %>
</table>
<%
end sub
%>
<%
sub TC7XC_add_code_main(bModify, sdate, sissue)
	dim code, money, first, second, summoney, bigsmallmoney, oddevenmoney, subflag
	set rs = server.CreateObject("ADODB.RecordSet")
	if bModify = false then
		sql = "select top 1 * from TC7XCData order by date desc"
		rs.open sql, conn_cst, 1, 1
		sdate = rs("date")
		rs.close()
		
		sql = "select top 1 * from TC7XCData order by date desc"
		rs.open sql, conn_cst, 1, 1
		sissue = cstr(clng(rs("issue")) + 1)
		rs.close()
		
		' 七星彩开奖为：每周二、周五、周日
		select case DatePart("w", sdate) 
		case 1 ' 星期天
			sdate = DateAdd("d", 2, sdate)	' 下个星期二
		case 3 ' 星期二
			sdate = DateAdd("d", 3, sdate)	' 下个星期五
		case 6 ' 星期五
			sdate = DateAdd("d", 2, sdate)	' 下个星期天
		end select
		
		if sdate > date() then 
			response.write("<br><br><font color=blue>最新数据已经录入，请到下期开奖日再来录入新的数据！</font><br><br><br><a href='javascript:history.back(1)'>返回体彩七星彩开奖信息管理</a><br>")
			exit sub
		end if 
		code = ""
		money = ""
		first = "5000000"
		second = ""
		summoney = 0
		bigsmallmoney = 0
		oddevenmoney = 0
		subflag = "add"
	else
		sql = "select * from TC7XCData where issue='" + sissue + "'"
		rs.open sql, conn_cst, 1, 1
		sdate = rs("date")
		sissue = rs("issue")
		code = rs("code")
		summoney = rs("summoney")
		bigsmallmoney = rs("bigsmallmoney")
		oddevenmoney = rs("oddevenmoney")
		money = rs("money")
		first = rs("first")
		second = rs("second")
		rs.close()
		subflag = "modify"
	end if
	set rs = nothing
%>
<form name="form1" method="post" action="dataadmin.asp?flag=TC7XC&subflag=<%=subflag%>"
    onsubmit="return CheckTC7XCData(this)">
    <table width="80%" border="0">
        <tr>
            <td width="30%">
                <div align="right">
                    开奖日期：</div>
            </td>
            <td width="70%">
                <input name="date" type="text" value="<%=sdate%>" maxlength="10">
                （格式：2004-6-4）</td>
        </tr>
        <tr>
            <td>
                <div align="right">
                    开奖期号：</div>
            </td>
            <td>
                <input name="issue" type="text" value="<%=sissue%>" maxlength="7">
                （格式：2004101）</td>
        </tr>
        <tr>
            <td>
                <div align="right">
                    开奖号码：</div>
            </td>
            <td>
                <input name="code" type="text" value="<%=code%>" maxlength="7">
                （格式：1234567）</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <div align="right">
                    <input type="submit" name="submit" value="<%if bModify=false then response.Write("增  加") else response.Write("修  改") end if%>">
            </td>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input
                    type="button" name="back" value="返  回" onclick="javascript:history.back(1)"></td>
        </tr>
    </table>
</form>
<%
end sub
%>
<%
sub TC7XC_add_code(bModify, sdate, issue, code, money, first, second, summoney, bigsmallmoney, oddevenmoney)
	sql = "select * from TC7XCData where issue='" + issue + "'"
	set rs = server.CreateObject("ADODB.RecordSet")
	rs.open sql, conn_cst, 1, 3
	if rs.bof and rs.eof then
		if bModify = true then	' 修改
			response.Write("<br><br><font color=blue>修改失败，请于管理员联系！</font><br><br>")
			rs.close()
			set rs = nothing
			call webend()
			response.end()
		end if
		' 增加
		rs.addnew()
		rs("date") = sdate
		rs("issue") = issue
	else
		if bModify = false then	' 增加
			response.write("<br><br><font color=blue>该开奖日期的开奖信息已经存在，添加失败！</font><br><br><a href='javascript:history.back(1)'>返回重新编辑</a><br>")
			rs.close()
			set rs = nothing
			call webend()
			response.end()
		end if
	end if
	dim i, ntemp, strtemp
	rs("date") = sdate
	rs("issue") = issue
	rs("code") = code
	rs("money") = money
	rs("first") = first
	rs("second") = second
	ntemp = 0
	for i=1 to 7 
		ntemp = ntemp + cint(mid(code, i, 1))
	next
	rs("sum") = cstr(ntemp)
	rs("summoney") = summoney
	strtemp = ""
	for i=1 to 7 
		if cint(mid(code, i, 1)) > 4 then 
			strtemp = strtemp + "大"
		else
			strtemp = strtemp + "小"
		end if
	next
	rs("bigsmall") = strtemp
	rs("bigsmallmoney") = bigsmallmoney
	strtemp = ""
	for i=1 to 7 
		if cint(mid(code, i, 1)) mod 2 = 0 then 
			strtemp = strtemp + "双"
		else
			strtemp = strtemp + "单"
		end if
	next
	rs("oddeven") = strtemp
	rs("oddevenmoney") = oddevenmoney
	rs("LastModifyTime") = now()
	rs.update()
	rs.close()
	set rs = nothing
	dim tmsg,tflag,turlmsg
	if bModify = true then
		response.Write("<br><br><font color=blue>修改开奖信息成功！</font><br><br><a href='dataadmin.asp?flag=TC7XC'>返回体彩七星彩开奖信息列表</a><br>")
		tmsg="修改开奖信息成功！"
		tflag="TC7XC"
		turlmsg="返回体彩七星彩开奖信息列表"
	else
		response.Write("<br><br><font color=blue>增加开奖信息成功！</font><br><br><a href='dataadmin.asp?flag=TC7XC'>返回体彩七星彩开奖信息列表</a><br>")
		tmsg="增加开奖信息成功！"
		tflag="TC7XC"
		turlmsg="返回体彩七星彩开奖信息列表"
	end if
	call makeindex2(tmsg,tflag,turlmsg)
end sub
%>
<%
sub TC7XC_del_code()
	sql = "select top 1 * from TC7XCData order by date desc"
	set rs = server.CreateObject("ADODB.RecordSet")
	rs.open sql, conn_cst, 1, 3
		if rs.bof and rs.eof then
		response.write("<br><br><font color=blue>没有可删除的开奖信息！</font><br><br><a href='javascript:history.back(1)'>返回</a><br>")
		tmsg="没有可删除的开奖信息！"
		tflag="TC7XC"
		turlmsg="返回体彩七星彩开奖信息列表"
	else
		rs.delete()
		response.Write("<br><br><font color=blue>删除最近开奖信息成功！</font><br><br><a href='dataadmin.asp?flag=TC7XC'>返回体彩七星彩开奖信息列表</a><br>")
		tmsg="删除最近开奖信息成功！"
		tflag="TC7XC"
		turlmsg="返回体彩七星彩开奖信息列表"
	end if
	
	rs.close()
	set rs = nothing
	call makeindex2(tmsg,tflag,turlmsg)
end sub
%>--%>