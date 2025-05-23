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
using Maticsoft.DBUtility;
using Pinble_Chipped.AppCod;

namespace Pinble_Chipped
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoginSort login = new LoginSort();
                ///�ж��û��Ƿ��½״̬                
                if (!login["manager_user"])
                {
                    this.hasLogin.Visible = false;
                    this.Login1.Visible = true;
                }
                else
                {
                    this.Login1.Visible = false;
                    this.lblUName.Text = Method.Get_UserName;
                    this.hasLogin.Visible = true;
                    //Response.Write("<script>parent.location.reload();</script>");
                    
                }
            }
        }
        private string _inUrl = "";
        /// <summary>
        /// ��תĿ��Url
        /// </summary>
        public string InUrl
        {
            get { return _inUrl; }
            set { _inUrl = value; }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            #region ���������Ϣ��¼
            string UID = this.txtName.Text.Trim();
            string PWD = this.txtPWD.Text.Trim();
            string vCode = this.txtCode.Text.Trim();
            if (UID == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), WebFunc.GetGuid(), JS.myAlert1("", "�û�������Ϊ�գ�", 350, "1", "", "", false, false));
                return;
            }
            if (PWD == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), WebFunc.GetGuid(), JS.myAlert1("", "�û����벻��Ϊ�գ�", 350, "1", "", "", false, false));
                return;
            }
            if (vCode == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), WebFunc.GetGuid(), JS.myAlert1("", "��֤�벻��Ϊ�գ�", 350, "1", "", "", false, false));
                return;
            }
            if (Session["ValidateCode"] == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), WebFunc.GetGuid(), JS.myAlert1("", "��֤���Ѿ�ʧЧ��", 350, "1", "", "", false, false));
                return;
            }

            if (vCode.ToUpper() != Session["ValidateCode"].ToString())
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), WebFunc.GetGuid(), JS.myAlert1("", "��֤���������", 350, "1", "", "", false, false));
                return;
            }
            Session["ValidateCode"] = null;
            Pbzx.BLL.PinbleLogin login = new Pbzx.BLL.PinbleLogin();
            string isChecked = "0";
            if (this.cbState.Checked)
            {
                isChecked = "3";
            }
            string loginResult = login.CheckLogin(UID, PWD, isChecked);
            if (string.IsNullOrEmpty(loginResult))
            {

                if (Request["ReturnUrl"] != null)
                {
                    //Response.Write("<script>window.top.location.href='" + Server.UrlDecode(Request["ReturnUrl"]) + "';</script>");
                    Response.Write("<script>history.go(-1);</script>");
                    Response.End();
                    return;
                }
                //������ת
                if (string.IsNullOrEmpty(InUrl))
                {
                   
                    if (Request["refUrl"]==null)
                    {
                        //��̨��½ 
                        Response.Write("<script>parent.location.reload();</script>");
                    }
                    else
                    {
                        string refUrl = Request["refUrl"].ToString();
                        //Response.Redirect(Request.CurrentExecutionFilePath);
                        //��ת����ʼҳ
                        //Response.Write("<script>parent.location.reload();</script>");
                        Response.Write("<script>parent.mainFrame.location.href='" + refUrl + "';</script>");
                    }
                }
                else
                {
                    Response.Write("<script>window.top.location.href='" + this.InUrl + "';</script>");
                    Response.End();
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "loginResult", JS.Alert("" + loginResult + ""));
                return;
            }
            #endregion
        }

        //protected void btnChangePWD_Click(object sender, EventArgs e)
        //{
        //    //�޸�����
        //    Response.Write("<script>window.top.location.href='/UserCenter/User_Center.aspx?myUrl=ChangePWD.aspx';</script>");
        //    Response.End();
        //}

        //protected void btnExit_Click(object sender, EventArgs e)
        //{
        //    //�˳�
        //    Pbzx.BLL.PinbleLogin.UserOut();
        //    Response.Redirect(Request.Url.PathAndQuery);
        //}

        protected void btnIn_Click(object sender, EventArgs e)
        {
            //�����Ա����
            Response.Write("<script>window.top.location.href='/UserCenter/User_Center.aspx';</script>");
            Response.End();
        }

        protected void btnreset_Click(object sender, EventArgs e)
        {
            this.txtName.Text = "";
            this.txtPWD.Text = "";
            this.txtCode.Text = "";
        }
    }
}
