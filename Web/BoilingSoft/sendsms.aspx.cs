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
using System.Security.Cryptography;

public partial class sendsms : System.Web.UI.Page
{
    String Action = "";
    public String ErrorInfo = "";

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            try
            {

                Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");
                Response.AddHeader("P3P", "CP=CAO PSA OUR");
                Action = Request.Params["act"];
                if (Action != null && Action.Equals("sendsms"))
                {
                    sendsmspro();
                }

            }
            catch (Exception eself)
            {
                ErrorInfo = "发送短信错误" + eself.ToString();
            }
        }
    }






    public void sendsmspro()
    {
        try
        {
            if (Session["CHECKCODEIMG"] != null)
            {
                if (Request.Params["checkcode"] != null)
                {
                    if (Session["CHECKCODEIMG"].ToString().Equals(Input.FilterAll(Request.Params["checkcode"])))
                    {
                        string strMobile = Input.FilterAll(Request.Params["mobile"].ToString().Trim());
                        string strIP = System.Web.HttpContext.Current.Request.UserHostAddress;
                        int IP_ValideCode_Count = WebInit.webBaseConfig.IP_ValideCode_Count;

                        if (strMobile != null)
                        {
                            //检查手机号码是否正确
                            if (!Regex.IsMatch(strMobile, @"^1[3-9]\d{9}$") && strMobile.Length != 11)
                            {
                                ErrorInfo = "对不起，该手机号码" + strMobile + "不正确！。";
                                return;
                            }
                            else if (DbHelperSQLBBS.Exists("select top 1 UserID from dbo.Dv_User where MOBILE='" + strMobile + "' "))
                            {
                                //检查手机号码是否已经注册
                                ErrorInfo = "对不起，该手机号码" + strMobile + "已被使用。";
                                return;
                            }
                            else if (DbHelperSQL.Exists("select top 1 MOBILE FROM dbo.PBnet_TBL_SMS WHERE (MOBILE = '" + strMobile + "') and DATEDIFF(SECOND, CREATE_TIME, GETDATE()) < 60 ORDER BY CREATE_TIME DESC"))
                            {
                                //检查是否在60秒内连续发送短信
                                ErrorInfo = "请勿连续点击发送按钮，如果没收到验证码请60秒后再发送。";
                                return;
                            }
                            else if (DbHelperSQL.Query("SELECT MOBILE FROM dbo.PBnet_TBL_SMS WHERE MOBILE = '" + strMobile + "' AND CONVERT(Nvarchar, CREATE_TIME, 111) = CONVERT(Nvarchar, GETDATE(), 111)").Tables[0].Rows.Count >= 3)
                            {
                                //检查手机号码当天是否已经发送3次短信
                                ErrorInfo = "对不起，该手机号码" + strMobile + "今天已发送3次验证码，请改天再发。";
                                return;
                            }
                            //                            else if (DbHelperSQL.Query("SELECT IP  FROM dbo.PBnet_TBL_SMS WHERE Len(IP) > 0 and IP = '" + strIP + "' AND CONVERT(Nvarchar, CREATE_TIME, 111) = CONVERT(Nvarchar, GETDATE(), 111)").Tables[0].Rows.Count > IP_ValideCode_Count)
                            //                            {
                            //                                //检查当前IP当天是否已经发送3次短信
                            ////                              ErrorInfo = "对不起，该IP地址" + strIP + " 今天发送验证码次数已经超额，请改天再发。";
                            //                                ErrorInfo = "对不起，今天发送验证码次数已经超额，请改天再发。";
                            //                                return;
                            //                            }
                            else if (DbHelperSQL.Exists("SELECT top 1 MOBILE FROM dbo.PBnet_TBL_SMS WHERE MOBILE = '" + strMobile + "' AND (SEND_STATE = 'W') AND CONVERT(Nvarchar, CREATE_TIME, 111) = CONVERT(Nvarchar, GETDATE(), 111)"))
                            {
                                //检查手机号码是否正在发送短信
                                ErrorInfo = "正在发送验证码，请勿重复发送。";
                                return;
                            }

                            string[] str = new string[4];
                            string serverCode = "";
                            //生成随机生成器 
                            Random random = new Random();
                            for (int i = 0; i < 4; i++)
                            {
                                str[i] = random.Next(10).ToString().Substring(0, 1);
                            }
                            foreach (string s in str)
                            {
                                serverCode += s;
                            }
                            //String shoujiayanzhengma = System.Guid.NewGuid().ToString().Trim().Substring(0, 4);
                            String shoujiayanzhengma = serverCode;

                            // 启用高防后IP地址都一样了，不再插入IP地址
                            strIP = "";

                            String zsql = "insert into dbo.PBnet_TBL_SMS (SMS_GUID,CREATE_TIME,SEND_STATE,USERNAME,USERPASSWORD,EMAIL, MOBILE,TENCENT_TEMPLATEID,PARAS,SEND_TIME,IP) values(newid(),getdate(),'W','" + Session["Username"].ToString() + "','" + Session["Password"].ToString() + "','" + Session["Email"].ToString() + "','" + strMobile + "','985155','" + shoujiayanzhengma + "',null,'" + strIP + "')";
                            //Response.Write(zsql);

                            int result = 0;
                            result = DbHelperSQL.ExecuteSql(zsql);
                            Session["MOBILE_CHECKCODE"] = shoujiayanzhengma;
                        }
                        else
                        {
                            ErrorInfo = "手机号码不能为空";
                        }
                    }
                    else
                    {
                        ErrorInfo = "验证数字填写错误";
                    }
                }
                else
                {
                    ErrorInfo = "验证数字不能为空";
                }
            }
            else
            {
                ErrorInfo = "验证数字已过期";
            }


        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
}