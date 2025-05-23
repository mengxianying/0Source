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
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using Pbzx.BLL;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Threading;

public partial class RepairMobile : System.Web.UI.Page
{
    public string strErrMsg = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.Params["UID"] != null)
            {
                txtEmail.Enabled = false;
                string UID, DecUID;
                string OrgUID = Request.Params["UID"].ToString();
                DecUID = HttpUtility.UrlDecode(OrgUID, System.Text.Encoding.GetEncoding("GB2312"));
                UID = Input.FilterAll(DecUID);
                Session["UID"] = UID;

                //if (Method.Get_UserName  =="0" ) {
                //    Response.Redirect("/");
                //}

                //看密码是否正确
                DataSet ds = DbHelperSQLBBS.Query("select top 1 UserEmail,UserID,UserName,UserPassword,LockUser,UserClass,MOBILE from Dv_User where UserName='" + UID + "'");
                DataRow rowData = ds.Tables[0].Rows[0];
                if (rowData != null)
                {
                    Session["txtUserPassword"] = rowData["UserPassword"].ToString();
                    object objEmail = rowData["UserEmail"];

                    if (objEmail == null || (objEmail is string && string.IsNullOrEmpty(objEmail.ToString())))
                    {
                        txtEmail.Enabled = true;
                        Session["dvEmail"] = "new";

                    }
                    else
                    {
                        txtEmail.Text = rowData["UserEmail"].ToString();
                        txtEmail.Enabled = false;
                        Session["dvEmail"] = "old";
                        Session["txtEmail"] = rowData["UserEmail"].ToString();
                        //
                    }
                }



            }
            else {
                Response.Redirect("/");
            }
        }
    }

    // 下一步按钮通用处理
    protected void btnNext_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            int currentStep = Convert.ToInt32(((Button)sender).CommandArgument);
            string strErrMsg = SaveStepData(currentStep);
            if (string.IsNullOrEmpty(strErrMsg))
            {
                MultiView1.ActiveViewIndex = currentStep;
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), Pbzx.Web.WebFunc.GetGuid(), JS.myAlert1("", "您提交的信息中存在以下错误:<br/><br/>" + strErrMsg + "<br/>请修改后再重新提交.", 500, "1", "", "", false, false));
                return;
            }
        }
    }

    // 上一步按钮处理
    protected void btnPrev_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex--;
    }

    // 保存步骤数据
    private string SaveStepData(int step)
    {
        var data = (Dictionary<string, string>)ViewState["RegistrationData"];
        string strErrMsg = "";
        switch (step)
        {
            case 1:
                //检查邮箱信息
                strErrMsg = checkEmail();
                Session["txtEmail"] = Input.FilterAll(this.txtEmail.Text.Trim());
               
                if (strErrMsg != "")
                {
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), Pbzx.Web.WebFunc.GetGuid(), JS.myAlert1("", "您提交的注册信息中存在以下错误:<br/><br/>" + strErrMsg + "<br/>请修改后再重新提交.", 500, "1", "", "", false, false));
                    break;
                }
                else
                {
                    //data["Email"] = Input.FilterAll(txtEmail.Text);
                    //Session["Email"] = Input.FilterAll(txtEmail.Text);
                    break;
                }
            case 2:
                //检查手机信息
                strErrMsg = checkPhone();
                if (strErrMsg != "")
                {
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), Pbzx.Web.WebFunc.GetGuid(), JS.myAlert1("", "您提交的注册信息中存在以下错误:<br/><br/>" + strErrMsg + "<br/>请修改后再重新提交.", 500, "1", "", "", false, false));
                    break;
                }
                else
                {
                    //data["Mobile"] = Input.FilterAll(txtQQ.Text);
                    //btnSave.Visible = true;
                    break;
                }

        }
        ViewState["RegistrationData"] = data;
        return strErrMsg;


    }


    public void goupdate()
    {
        try
        {
            string UID, DecUID;
            string OrgUID = Request.Params["UID"].ToString();
            DecUID = HttpUtility.UrlDecode(OrgUID, System.Text.Encoding.GetEncoding("GB2312"));
            UID = Input.FilterAll(DecUID);

            //手机
            String mobile = Input.FilterAll(txtQQ.Text);

            //手机验证码
            String mobilecheckcode = Input.FilterAll(txtPhoneCode.Text);



            //object objMobile = DbHelperSQLBBS.GetSingle("select top 1 Mobile from dbo.Dv_User where UserName='" + UID + "' ");
            strErrMsg = "";
            if (string.IsNullOrEmpty(mobile))
            {
                strErrMsg = "手机号码不能为空!";
            }
            else if (!Regex.IsMatch(mobile, @"^1[3-9]\d{9}$"))
            {
                strErrMsg += "手机号码" + mobile + "不正确!<br/>";
                Pbzx.Common.ErrorLog.WriteLogMeng("手机号码不正确", "mobile = " + mobile, true, true);
            }
            //            else if (objMobile != null && !string.IsNullOrEmpty(objMobile.ToString()))
            //            {
            //                Pbzx.Common.ErrorLog.WriteLogMeng("手机号", objMobile.ToString() + "=" + objMobile.ToString().Length, true, true);
            //                if (objMobile.ToString().Length == 11)
            //                {
            //                    strErrMsg = "手机号码已经验证通过，不需要再次验证!";
            //                }
            //            }
            else if (string.IsNullOrEmpty(UID))
            {
                strErrMsg += "用户名不能为空!<br/>";
            }
            else if (!DbHelperSQLBBS.Exists("select top 1 UserID from dbo.Dv_User where UserName='" + UID + "' "))
            {
                strErrMsg += "用户名" + UID + "不存在!<br/>";
                Pbzx.Common.ErrorLog.WriteLogMeng("用户名不存在", "OrgUID=" + OrgUID + " DecUID=" + DecUID + " UID=" + UID, true, true);
            }
            else if (string.IsNullOrEmpty(mobilecheckcode))
            {
                strErrMsg += "手机验证码不能为空!<br/>";
            }
            else if (Session["MOBILE_CHECKCODE"] == null || (!mobilecheckcode.Equals(Session["MOBILE_CHECKCODE"].ToString().Trim())))
            {
                strErrMsg += "手机验验证码错误!<br/>";
                Pbzx.Common.ErrorLog.WriteLogMeng("手机验验证码错误", "mobilecheckcode=" + mobilecheckcode + " MOBILE_CHECKCODE=" + Session["MOBILE_CHECKCODE"].ToString().Trim(), true, true);
            }

            if (strErrMsg.Length == 0)
            {
                //看密码是否正确
                DataSet ds = DbHelperSQLBBS.Query("select top 1 UserID,UserEmail,UserName,UserPassword,LockUser,UserClass,MOBILE from Dv_User where UserName='" + UID + "'");
                DataRow rowData = ds.Tables[0].Rows[0];

                //更新用户验证后的手机号
                int result = 0;
                 object objEmail = rowData["UserEmail"];

                 if (objEmail == null || (objEmail is string && string.IsNullOrEmpty(objEmail.ToString())))
                 {

                     result = DbHelperSQLBBS.ExecuteSql("update dbo.Dv_User set MOBILE='" + mobile + "' , UserEmail='" + Session["txtEmail"].ToString() + "'  where UserName='" + UID + "'");
                     result = DbHelperSQL.ExecuteSql("update dbo.PBnet_UserTable set Mobile='" + mobile + "' , Email='" + Session["txtEmail"].ToString() + "'  where UserName='" + UID + "'");
                 }
                 else
                 {
                     result = DbHelperSQLBBS.ExecuteSql("update dbo.Dv_User set MOBILE='" + mobile + "' where UserName='" + UID + "'");
                     result = DbHelperSQL.ExecuteSql("update dbo.PBnet_UserTable set Mobile='" + mobile + "' where UserName='" + UID + "'");
                 }


                Page.ClientScript.RegisterStartupScript(GetType(), Pbzx.Web.WebFunc.GetGuid(), JS.Alert("手机验证提交成功，请重新登录!", "/login.aspx"));
                //Page.ClientScript.RegisterStartupScript(this.GetType(), Pbzx.Web.WebFunc.GetGuid(), JS.myAlert1("", "手机验证提交成功，请重新登录!",500, "1", "", "", false, false));
                
                //Response.Redirect("/login.aspx");
                return; 

            }
            else {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Pbzx.Web.WebFunc.GetGuid(), JS.myAlert1("", "您提交的信息中存在以下错误:<br/><br/>" + strErrMsg + "<br/>请修改后再重新提交", 500, "1", "", "", false, false));
                return; 
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        checkPhone();
        goupdate();
    }

    private string checkEmail()
    {
        string strErrMsg = "";
        string email = "";
        try
        {
            email = Input.FilterAll(this.txtEmail.Text);
        }
        catch (Exception ex)
        {
            strErrMsg += "Email含有非法字符！<br/>";
        }
        if (string.IsNullOrEmpty(email))
        {
            strErrMsg += "电子邮件不能为空!<br/>";
        }
        else if (!Regex.IsMatch(email, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
        {
            strErrMsg += "Email格式不正确";
        }
        else if (Session["dvEmail"].ToString()=="new" & DbHelperSQLBBS.Exists("select * from Dv_User where UserEmail='" + email + "'"))
        {
            strErrMsg += "对不起,您的Email已经被占用！";
        }
        else if (Session["Email_CHECKCODE_RM"] == null)
        {
            strErrMsg += "请先获取Email验证码！";
        }
        else if (Input.FilterAll(txtEmailCode.Text) != Session["Email_CHECKCODE_RM"].ToString())
        {
            strErrMsg += "Email验证码错误！";
        }
        //Session["Email"] = email;
        return strErrMsg;
    }

    private string checkPhone()
    {
        string strErrMsg = "";

        String mobile = Input.FilterAll(this.txtQQ.Text);
        String mobilecheckcode = Input.FilterAll(this.txtPhoneCode.Text);

        if (string.IsNullOrEmpty(mobile))
        {
            strErrMsg += "手机号不能为空!<br/>";
        }
        if (string.IsNullOrEmpty(mobilecheckcode))
        {
            strErrMsg += "手机验证码不能为空!<br/>";
        }

        if (Session["MOBILE_CHECKCODE"] == null)
        {
            strErrMsg += "请先获取手机验证码！<br/>";
        }
        else if (!mobilecheckcode.Equals(Session["MOBILE_CHECKCODE"].ToString().Trim()))
        {
            strErrMsg += "手机验证码错误！<br/>";
        }

        return strErrMsg;
    }
}