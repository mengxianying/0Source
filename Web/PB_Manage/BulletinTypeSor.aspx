﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BulletinTypeSor.aspx.cs" Inherits="Pbzx.Web.PB_Manage.BulletinTypeSor" %>

<%@ Register Src="Controls/UcSort.ascx" TagName="UcSort" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:UcSort ID="UcSort1" runat="server" ColName="VarTypeName" PrimaryKey="IntNewsTypeID"
            SortID="IntSortID" TbName="PBnet_BulletinType" />
    
    </div>
    </form>
</body>
</html>
