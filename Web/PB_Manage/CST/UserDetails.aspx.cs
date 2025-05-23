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

namespace Pbzx.Web.PB_Manage.CST
{
    public partial class UserDetails : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                Pbzx.BLL.CN_UserDetails detailsBLL = new Pbzx.BLL.CN_UserDetails();
                Pbzx.Model.CN_UserDetails Mydetails;
                string str = Request.QueryString["ID"];
                if (str != null && OperateText.IsNumber(str))
                {
                    Mydetails = detailsBLL.GetModel(Convert.ToInt32(str));

                }
                else 
                {
                    Mydetails = new Pbzx.Model.CN_UserDetails();
                }
                this.txtBss.Text = Mydetails.BbsName;
                this.txtName.Text = Mydetails.UserName;
                this.txtTel.Text = Mydetails.UserTel;

                this.txtEmail.Text = Mydetails.UserEmail;
                this.txtAddress.Text = Mydetails.UserAddress;
                this.rblStatus.SelectedValue = Mydetails.Status.ToString();
                this.txtRemarks.Text = Mydetails.Remarks;
                hfFriendLinkID.Value = Mydetails.ID.ToString();
            }
        }

       protected void btn_Save_Click(object sender, EventArgs e)
       {
           if (txtBss.Text.Trim() == "")
           {
               ClientScript.RegisterStartupScript(this.GetType(), "namenull", Pbzx.Common.JS.Alert("��̳���Ʋ���Ϊ��."));
               return;
           }

           if (txtName.Text.Trim() == "")
           {
               ClientScript.RegisterStartupScript(this.GetType(), "tagnull", JS.Alert("��������Ϊ��"));
               return;
           }
                   
           Pbzx.BLL.CN_UserDetails MyBLL = new Pbzx.BLL.CN_UserDetails();
           Pbzx.Model.CN_UserDetails MyUd;

           int LinkID = Convert.ToInt32(hfFriendLinkID.Value);

           if (LinkID > 0)
           {
               MyUd = MyBLL.GetModel(LinkID);

           }
           else
           {
               MyUd = new Pbzx.Model.CN_UserDetails();
           }

           MyUd.BbsName = this.txtBss.Text.Trim();
           MyUd.UserName = this.txtName.Text.Trim();
           MyUd.UserTel = this.txtTel.Text.Trim();
           MyUd.UserEmail = this.txtEmail.Text.Trim();
           MyUd.UserAddress = this.txtAddress.Text.Trim();
           MyUd.Status = int.Parse(this.rblStatus.SelectedValue);
           MyUd.Remarks = this.txtRemarks.Text.Trim();


           if (MyUd.ID > 0)
           {
               if (MyBLL.Update(MyUd))
               {
                   //ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("�û��޸ĳɹ�."));
                   //ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("UserDetails_Manage.aspx"));
                   Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("�޸�", "�޸��û�����[" + MyUd.UserName + "].");
                   Response.Write("<script>alert('�޸ĳɹ�');window.opener.location.reload();window.opener.focus();window.opener=null;window.open('','_self');window.close();</script>");

               }
               else
               {
                   Response.Write("<script>alert('�޸�ʧ��');</script>");
               }
           }
           else
           {

               if (MyBLL.Add(MyUd))
               {
                   //ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("�û���ӳɹ�."));
                   //ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("UserDetails_Manage.aspx"));
                   Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("����", "�����û�[" + MyUd.UserName + "].");
                   Response.Write("<script>alert('��ӳɹ�');window.opener.location.reload();window.opener.focus();window.opener=null;window.open('','_self');window.close();</script>");
               }
               else
               {
                   Response.Write("<script>alert('���ʧ��');</script>");
               }
           }

      }

    }
}

