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
                    <input type="submit" name="submit" value="����µĿ�����Ϣ">
                </div>
            </th>
            <th width="33%" scope="col">
                <div align="center">
                    <input type="submit" name="submit" value="ɾ�����һ���н���Ϣ" onclick="{if(confirm('��ȷ��Ҫɾ����?')){return true;}return false;}">
                </div>
            </th>
            <th width="33%" scope="col">
                <div align="right">
                    <input type="button" name="button" value="��  ��" onclick="javascript:history.back(1)">
                </div>
            </th>
        </tr>
    </table>
</form>
<table width="80%" border="1">
    <tr bgcolor="#0000FF">
        <th width="12%" height="20" scope="col">
            <font color="#FFFFFF">��������</font></th>
        <th width="14%" scope="col">
            <font color="#FFFFFF">�����ں�</font></th>
        <th width="11%" scope="col">
            <font color="#FFFFFF">��������</font></th>
        <th width="11%" scope="col">
            <font color="#FFFFFF">����</font></th>
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
            <a href='#' onclick='window.open ("?action=getip&tip=<%=row("OpIp")%>", "newwindow", "height=150, width=200, top=100, left=500,toolbar=no, menubar=no, scrollbars=no, resizable=no, location=no, status=no")��'>
                <%=row("OpIp")%>
            </a>
        </td>
        <td>
            <%=row("OpName")%>
        </td>
        <td>
            <div align="center">
                <a href="CpdataAdmin.aspx?cpid=4&flag=TC7XC&subflag=modifyrequest&date=<%=row("date")%>&issue=<%=row("issue")%>">
                    �޸�</a></div>
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

		
         //���ǲʿ���Ϊ��ÿ�ܶ������塢����
        switch(sdate.DayOfWeek)
        {
            case 1: //������
                sdate = sdate.AddDays(2);//�¸����ڶ�
                break;
            case 3:   //���ڶ� 
                 sdate = sdate.AddDays(3);//�¸�������
                break;
            case 6: // ������
                 sdate = sdate.AddDays(3);// �¸������� 
                break;
        }
		
		if(sdate > DateTime.Now)
        { 
			Response.Write("<br><br><font color=blue>���������Ѿ�¼�룬�뵽���ڿ���������¼���µ����ݣ�</font><br><br><br><a href='javascript:history.back(1)'>����������ǲʿ�����Ϣ����</a><br>");
		}
        //���괦�� 
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

                <script>setInterval("jnkc.innerHTML=new Date().toLocaleString()+' ����'+'��һ����������'.charAt(new Date().getDay());",1000);
                </script>

            </th>
            <tr>
                <td class="forumRow" width="30%">
                    <div align="right">
                        �����ںţ�</div>
                </td>
                <td class="forumRow">
                    <input name="issue" type="text" value="<%=sissue%>" maxlength="7" <%if bModify = true then response.Write "readonly='1'  style='color:#999999;'"%>>
                    ����ʽ��2004101��</td>
            </tr>
        </tr>
        <tr>
        <td width="30%" class="forumRow">
            <div align="right">
                �������ڣ�</div>
        </td>
        <td width="70%" class="forumRow">
            <input name="date" type="text" value="<%=sdate%>" maxlength="10" <%if bModify = true then response.Write "readonly='1' style='color:#999999;'"%>>
            ����ʽ��2004-6-4��</td>
        </tr>
        <tr>
            <td class="forumRow">
                <div align="right">
                    �������룺</div>
            </td>
            <td class="forumRow">
                <input name="code" type="text" value="<%=code%>" maxlength="7">
                ����ʽ��1234567��</td>
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
                    <input type="submit" name="submit" value="<%if (bModify==false){response.Write("��  ��");} else{ response.Write("��  ��")} %>">
            </td>
            <td class="forumRow">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <input type="button" name="back" value="��  ��" onclick="javascript:history.back(1)"></td>
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
		if bModify = true then	' �޸�
			response.Write("<br><br><font color=blue>�޸�ʧ�ܣ����ڹ���Ա��ϵ��</font><br><br>")
			rs.close()
			set rs = nothing
			call webend()
			response.end()
		end if
		' ����
		rs.addnew()
		rs("date") = sdate
		rs("issue") = issue
	else
		if bModify = false then	' ����
			response.write("<br><br><font color=blue>�ÿ������ڵĿ�����Ϣ�Ѿ����ڣ����ʧ�ܣ�</font><br><br><a href='javascript:history.back(1)'>�������±༭</a><br>")
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
			strtemp = strtemp + "��"
		else
			strtemp = strtemp + "С"
		end if
	next
	rs("bigsmall") = strtemp
	rs("bigsmallmoney") = bigsmallmoney
	strtemp = ""
	for i=1 to 7 
		if cint(mid(code, i, 1)) mod 2 = 0 then 
			strtemp = strtemp + "˫"
		else
			strtemp = strtemp + "��"
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
		response.Write("<br><br><font color=blue>�޸Ŀ�����Ϣ�ɹ���</font><br><br><a href='dataadmin.asp?flag=TC7XC'>����������ǲʿ�����Ϣ�б�</a><br>")
		tmsg="�޸Ŀ�����Ϣ�ɹ���"
		tflag="TC7XC"
		turlmsg="����������ǲʿ�����Ϣ�б�"
	else
		response.Write("<br><br><font color=blue>���ӿ�����Ϣ�ɹ���</font><br><br><a href='dataadmin.asp?flag=TC7XC'>����������ǲʿ�����Ϣ�б�</a><br>")
		tmsg="���ӿ�����Ϣ�ɹ���"
		tflag="TC7XC"
		turlmsg="����������ǲʿ�����Ϣ�б�"
	end if
	call makeindex2(tmsg,tflag,turlmsg)
  }%>
  
  
  
<%
sub TC7XC_del_code()
	sql = "select top 1 * from TC7XCData order by date desc"
	set rs = server.CreateObject("ADODB.RecordSet")
	rs.open sql, conn_cst, 1, 3
		if rs.bof and rs.eof then
		response.write("<br><br><font color=blue>û�п�ɾ���Ŀ�����Ϣ��</font><br><br><a href='javascript:history.back(1)'>����</a><br>")
		tmsg="û�п�ɾ���Ŀ�����Ϣ��"
		tflag="TC7XC"
		turlmsg="����������ǲʿ�����Ϣ�б�"
	else
		rs.delete()
		response.Write("<br><br><font color=blue>ɾ�����������Ϣ�ɹ���</font><br><br><a href='dataadmin.asp?flag=TC7XC'>����������ǲʿ�����Ϣ�б�</a><br>")
		tmsg="ɾ�����������Ϣ�ɹ���"
		tflag="TC7XC"
		turlmsg="����������ǲʿ�����Ϣ�б�"
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
                    <input type="submit" name="submit" value="����µ��н���Ϣ">
                </div>
            </th>
            <th width="33%" scope="col">
                <div align="center">
                    <input type="submit" name="submit" value="ɾ�����һ���н���Ϣ">
                </div>
            </th>
            <th width="33%" scope="col">
                <div align="right">
                    <input type="button" name="button" value="��  ��" onclick="javascript:history.back(1)">
                </div>
            </th>
        </tr>
    </table>
</form>
<table width="80%" border="1">
    <tr bgcolor="#0000FF">
        <th width="12%" height="20" scope="col">
            <font color="#FFFFFF">��������</font></th>
        <th width="14%" scope="col">
            <font color="#FFFFFF">�����ں�</font></th>
        <th width="11%" scope="col">
            <font color="#FFFFFF">��������</font></th>
        <th width="11%" scope="col">
            <font color="#FFFFFF">����</font></th>
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
                    �޸�</a></div>
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
		
		' ���ǲʿ���Ϊ��ÿ�ܶ������塢����
		select case DatePart("w", sdate) 
		case 1 ' ������
			sdate = DateAdd("d", 2, sdate)	' �¸����ڶ�
		case 3 ' ���ڶ�
			sdate = DateAdd("d", 3, sdate)	' �¸�������
		case 6 ' ������
			sdate = DateAdd("d", 2, sdate)	' �¸�������
		end select
		
		if sdate > date() then 
			response.write("<br><br><font color=blue>���������Ѿ�¼�룬�뵽���ڿ���������¼���µ����ݣ�</font><br><br><br><a href='javascript:history.back(1)'>����������ǲʿ�����Ϣ����</a><br>")
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
                    �������ڣ�</div>
            </td>
            <td width="70%">
                <input name="date" type="text" value="<%=sdate%>" maxlength="10">
                ����ʽ��2004-6-4��</td>
        </tr>
        <tr>
            <td>
                <div align="right">
                    �����ںţ�</div>
            </td>
            <td>
                <input name="issue" type="text" value="<%=sissue%>" maxlength="7">
                ����ʽ��2004101��</td>
        </tr>
        <tr>
            <td>
                <div align="right">
                    �������룺</div>
            </td>
            <td>
                <input name="code" type="text" value="<%=code%>" maxlength="7">
                ����ʽ��1234567��</td>
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
                    <input type="submit" name="submit" value="<%if bModify=false then response.Write("��  ��") else response.Write("��  ��") end if%>">
            </td>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input
                    type="button" name="back" value="��  ��" onclick="javascript:history.back(1)"></td>
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
		if bModify = true then	' �޸�
			response.Write("<br><br><font color=blue>�޸�ʧ�ܣ����ڹ���Ա��ϵ��</font><br><br>")
			rs.close()
			set rs = nothing
			call webend()
			response.end()
		end if
		' ����
		rs.addnew()
		rs("date") = sdate
		rs("issue") = issue
	else
		if bModify = false then	' ����
			response.write("<br><br><font color=blue>�ÿ������ڵĿ�����Ϣ�Ѿ����ڣ����ʧ�ܣ�</font><br><br><a href='javascript:history.back(1)'>�������±༭</a><br>")
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
			strtemp = strtemp + "��"
		else
			strtemp = strtemp + "С"
		end if
	next
	rs("bigsmall") = strtemp
	rs("bigsmallmoney") = bigsmallmoney
	strtemp = ""
	for i=1 to 7 
		if cint(mid(code, i, 1)) mod 2 = 0 then 
			strtemp = strtemp + "˫"
		else
			strtemp = strtemp + "��"
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
		response.Write("<br><br><font color=blue>�޸Ŀ�����Ϣ�ɹ���</font><br><br><a href='dataadmin.asp?flag=TC7XC'>����������ǲʿ�����Ϣ�б�</a><br>")
		tmsg="�޸Ŀ�����Ϣ�ɹ���"
		tflag="TC7XC"
		turlmsg="����������ǲʿ�����Ϣ�б�"
	else
		response.Write("<br><br><font color=blue>���ӿ�����Ϣ�ɹ���</font><br><br><a href='dataadmin.asp?flag=TC7XC'>����������ǲʿ�����Ϣ�б�</a><br>")
		tmsg="���ӿ�����Ϣ�ɹ���"
		tflag="TC7XC"
		turlmsg="����������ǲʿ�����Ϣ�б�"
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
		response.write("<br><br><font color=blue>û�п�ɾ���Ŀ�����Ϣ��</font><br><br><a href='javascript:history.back(1)'>����</a><br>")
		tmsg="û�п�ɾ���Ŀ�����Ϣ��"
		tflag="TC7XC"
		turlmsg="����������ǲʿ�����Ϣ�б�"
	else
		rs.delete()
		response.Write("<br><br><font color=blue>ɾ�����������Ϣ�ɹ���</font><br><br><a href='dataadmin.asp?flag=TC7XC'>����������ǲʿ�����Ϣ�б�</a><br>")
		tmsg="ɾ�����������Ϣ�ɹ���"
		tflag="TC7XC"
		turlmsg="����������ǲʿ�����Ϣ�б�"
	end if
	
	rs.close()
	set rs = nothing
	call makeindex2(tmsg,tflag,turlmsg)
end sub
%>--%>