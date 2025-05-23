<%@ Page Language="C#" AutoEventWireup="true" Codebehind="sendsms.aspx.cs" Inherits="sendsms" %> 
<%
    if (ErrorInfo.Length > 0)
    {
%>
        <Script>
            alert("<%=ErrorInfo%>");
        </Script>
<%    
    }
    else
    { 
%>        
        <script>alert("短信验证码已发送到您的手机！");parent.xianshidaoshiji();</script>
<%
    }

%>