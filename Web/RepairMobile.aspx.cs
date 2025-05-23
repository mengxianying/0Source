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

                //�������Ƿ���ȷ
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

    // ��һ����ťͨ�ô���
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
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), Pbzx.Web.WebFunc.GetGuid(), JS.myAlert1("", "���ύ����Ϣ�д������´���:<br/><br/>" + strErrMsg + "<br/>���޸ĺ��������ύ.", 500, "1", "", "", false, false));
                return;
            }
        }
    }

    // ��һ����ť����
    protected void btnPrev_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex--;
    }

    // ���沽������
    private string SaveStepData(int step)
    {
        var data = (Dictionary<string, string>)ViewState["RegistrationData"];
        string strErrMsg = "";
        switch (step)
        {
            case 1:
                //���������Ϣ
                strErrMsg = checkEmail();
                Session["txtEmail"] = Input.FilterAll(this.txtEmail.Text.Trim());
               
                if (strErrMsg != "")
                {
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), Pbzx.Web.WebFunc.GetGuid(), JS.myAlert1("", "���ύ��ע����Ϣ�д������´���:<br/><br/>" + strErrMsg + "<br/>���޸ĺ��������ύ.", 500, "1", "", "", false, false));
                    break;
                }
                else
                {
                    //data["Email"] = Input.FilterAll(txtEmail.Text);
                    //Session["Email"] = Input.FilterAll(txtEmail.Text);
                    break;
                }
            case 2:
                //����ֻ���Ϣ
                strErrMsg = checkPhone();
                if (strErrMsg != "")
                {
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), Pbzx.Web.WebFunc.GetGuid(), JS.myAlert1("", "���ύ��ע����Ϣ�д������´���:<br/><br/>" + strErrMsg + "<br/>���޸ĺ��������ύ.", 500, "1", "", "", false, false));
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

            //�ֻ�
            String mobile = Input.FilterAll(txtQQ.Text);

            //�ֻ���֤��
            String mobilecheckcode = Input.FilterAll(txtPhoneCode.Text);



            //object objMobile = DbHelperSQLBBS.GetSingle("select top 1 Mobile from dbo.Dv_User where UserName='" + UID + "' ");
            strErrMsg = "";
            if (string.IsNullOrEmpty(mobile))
            {
                strErrMsg = "�ֻ����벻��Ϊ��!";
            }
            else if (!Regex.IsMatch(mobile, @"^1[3-9]\d{9}$"))
            {
                strErrMsg += "�ֻ�����" + mobile + "����ȷ!<br/>";
                Pbzx.Common.ErrorLog.WriteLogMeng("�ֻ����벻��ȷ", "mobile = " + mobile, true, true);
            }
            //            else if (objMobile != null && !string.IsNullOrEmpty(objMobile.ToString()))
            //            {
            //                Pbzx.Common.ErrorLog.WriteLogMeng("�ֻ���", objMobile.ToString() + "=" + objMobile.ToString().Length, true, true);
            //                if (objMobile.ToString().Length == 11)
            //                {
            //                    strErrMsg = "�ֻ������Ѿ���֤ͨ��������Ҫ�ٴ���֤!";
            //                }
            //            }
            else if (string.IsNullOrEmpty(UID))
            {
                strErrMsg += "�û�������Ϊ��!<br/>";
            }
            else if (!DbHelperSQLBBS.Exists("select top 1 UserID from dbo.Dv_User where UserName='" + UID + "' "))
            {
                strErrMsg += "�û���" + UID + "������!<br/>";
                Pbzx.Common.ErrorLog.WriteLogMeng("�û���������", "OrgUID=" + OrgUID + " DecUID=" + DecUID + " UID=" + UID, true, true);
            }
            else if (string.IsNullOrEmpty(mobilecheckcode))
            {
                strErrMsg += "�ֻ���֤�벻��Ϊ��!<br/>";
            }
            else if (Session["MOBILE_CHECKCODE"] == null || (!mobilecheckcode.Equals(Session["MOBILE_CHECKCODE"].ToString().Trim())))
            {
                strErrMsg += "�ֻ�����֤�����!<br/>";
                Pbzx.Common.ErrorLog.WriteLogMeng("�ֻ�����֤�����", "mobilecheckcode=" + mobilecheckcode + " MOBILE_CHECKCODE=" + Session["MOBILE_CHECKCODE"].ToString().Trim(), true, true);
            }

            if (strErrMsg.Length == 0)
            {
                //�������Ƿ���ȷ
                DataSet ds = DbHelperSQLBBS.Query("select top 1 UserID,UserEmail,UserName,UserPassword,LockUser,UserClass,MOBILE from Dv_User where UserName='" + UID + "'");
                DataRow rowData = ds.Tables[0].Rows[0];

                //�����û���֤����ֻ���
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


                Page.ClientScript.RegisterStartupScript(GetType(), Pbzx.Web.WebFunc.GetGuid(), JS.Alert("�ֻ���֤�ύ�ɹ��������µ�¼!", "/login.aspx"));
                //Page.ClientScript.RegisterStartupScript(this.GetType(), Pbzx.Web.WebFunc.GetGuid(), JS.myAlert1("", "�ֻ���֤�ύ�ɹ��������µ�¼!",500, "1", "", "", false, false));
                
                //Response.Redirect("/login.aspx");
                return; 

            }
            else {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Pbzx.Web.WebFunc.GetGuid(), JS.myAlert1("", "���ύ����Ϣ�д������´���:<br/><br/>" + strErrMsg + "<br/>���޸ĺ��������ύ", 500, "1", "", "", false, false));
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
            strErrMsg += "Email���зǷ��ַ���<br/>";
        }
        if (string.IsNullOrEmpty(email))
        {
            strErrMsg += "�����ʼ�����Ϊ��!<br/>";
        }
        else if (!Regex.IsMatch(email, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
        {
            strErrMsg += "Email��ʽ����ȷ";
        }
        else if (Session["dvEmail"].ToString()=="new" & DbHelperSQLBBS.Exists("select * from Dv_User where UserEmail='" + email + "'"))
        {
            strErrMsg += "�Բ���,����Email�Ѿ���ռ�ã�";
        }
        else if (Session["Email_CHECKCODE_RM"] == null)
        {
            strErrMsg += "���Ȼ�ȡEmail��֤�룡";
        }
        else if (Input.FilterAll(txtEmailCode.Text) != Session["Email_CHECKCODE_RM"].ToString())
        {
            strErrMsg += "Email��֤�����";
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
            strErrMsg += "�ֻ��Ų���Ϊ��!<br/>";
        }
        if (string.IsNullOrEmpty(mobilecheckcode))
        {
            strErrMsg += "�ֻ���֤�벻��Ϊ��!<br/>";
        }

        if (Session["MOBILE_CHECKCODE"] == null)
        {
            strErrMsg += "���Ȼ�ȡ�ֻ���֤�룡<br/>";
        }
        else if (!mobilecheckcode.Equals(Session["MOBILE_CHECKCODE"].ToString().Trim()))
        {
            strErrMsg += "�ֻ���֤�����<br/>";
        }

        return strErrMsg;
    }
}