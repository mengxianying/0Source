/*
*********************************************************
Software Develop & Design Tools System
北京贝格瑞安科技有限公司 
Copyright 2019 www.boilingsoft.com
********************************************************** 
*/
using System;
using System.Data; 
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security; 
using System.Web.UI; 
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts; 
using System.Web.UI.HtmlControls;
using Pbzx.Common;
using System.Data.OleDb; 
using System.Data.SqlClient; 
using System.Collections.Specialized; 
using System.Net;
using System.IO; 
using System.Text;
using Maticsoft.DBUtility;
using System.Text.RegularExpressions;

public partial class getm : System.Web.UI.Page 
{
    String Action = "";
    public String ErrorInfo = "";
    public String MOBILE = "";

    protected void Page_Load(object sender, EventArgs e) 
    { 

        if (!Page.IsPostBack)
        { 
            try
            {
                Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");
                Response.AddHeader("P3P", "CP=CAO PSA OUR");
                Action = Request.Params["act"];
                if (Action != null && Action.Equals("getm"))
                {
                    getmpro();
                }
            }
            catch (Exception eself) 
            {
                ErrorInfo = "发送短信错误" + eself.ToString();
            }            
        } 
    }

    public void getmpro()
    {
        try
        {
            DataSet xx = DbHelperSQL.Query("select isnull(MOBILE,'') as MOBILE from PBnet_UserTable  where UserName = '" + Method.Get_UserName + "'");
            MOBILE = xx.Tables[0].Rows[0]["MOBILE"].ToString().Trim();
        }
        catch(Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
} 