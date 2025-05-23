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

namespace Pbzx.Web.PB_Manage
{
    public partial class Soft_Editor : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string basePath = "/Images/UploadFiles/Resource/" + DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString();
                if (!DirectoryFile.IsCreateDirectory(Server.MapPath(basePath)))
                {
                    DirectoryFile.CreateDirectory(Server.MapPath(basePath));
                }
                Session["FCKeditor:UserFilesPath"] = basePath;
                Session["DefaultSelect"] = basePath;

                //Session["FCKeditor:UserFilesPath"] = "/Images/UploadFiles/Resource";
                //Session["DefaultSelect"] = "/Images/UploadFiles/Resource";

                txtUpdateTime.Text = DateTime.Now.ToString();
                BindDropdownList();
                string str = Request.QueryString["ID"];
                Pbzx.Model.PBnet_Soft myProduct;
                Pbzx.BLL.PBnet_Soft softBLL = new Pbzx.BLL.PBnet_Soft();

                if (OperateText.IsNumber(str))
                {
                    myProduct = softBLL.GetModel(Convert.ToInt32(str));
                    lblAction.Text = "�޸�";
                    //btnCancel.Visible = true;
                    //btnCancel.Attributes.Add("onclick", "history.back();return false;");
                    BindItems(myProduct);
                }
                else
                {
                    myProduct = new Pbzx.Model.PBnet_Soft();
                    lblAction.Text = "����";
                    //btnCancel.Visible = false;
                }
                hfFriendLinkID.Value = myProduct.PBnet_SoftID.ToString();
            }
        }

        private void BindItems(Pbzx.Model.PBnet_Soft model)
        {
            this.ddlSoftClass.SelectedValue = model.pb_ClassID.ToString();
            this.txtSoftName.Text = model.PBnet_SoftName;
            this.txtSoftVersion3.Text = model.PBnet_SoftVersion;
            this.ddlSoftType.SelectedValue = model.PBnet_SoftType.ToString();
            this.ddlSoftLanguage.SelectedValue = model.PBnet_SoftLanguage.ToString();
            this.ddlCopyrightType.SelectedValue = model.pb_CopyrightType.ToString();
            this.txtOperatingSystem.Text = model.pb_OperatingSystem;
            this.txtAuthor.Text = model.pb_Author;
            this.txtAuthorEmail.Text = model.pb_AuthorEmail;
            this.txtAuthorHomepage.Text = model.pb_AuthorHomepage;
            //this.txtDemoUrl.Text = model.pb_DemoUrl;
            this.txtRegUrl.Text = model.pb_RegUrl;
            //this.txtSoftdemo.Text = model.pbnet_softde;
            //this.txtilluminate.Text = model.pb_i;
            this.txtLogo.Text = model.PBnet_SoftPicUrl;
            this.weSoftIntro.Value = model.PBnet_SoftIntro;
            //this.weSoftContent.Text = model.pbnetsoftc;
            this.txtKeyword.Text = model.pb_Keyword;
            this.chkOnTop.Checked = model.pb_OnTop;
            this.chkElite.Checked = model.pb_Elite;
            this.ddlStars.SelectedValue = model.pb_Stars.ToString();

            this.txtDayHits.Text = model.pb_DayHits.ToString();
            this.txtWeekHits.Text = model.pb_WeekHits.ToString();
            this.txtMonthHits.Text = model.pb_MonthHits.ToString();
            this.txtHits.Text = model.pb_Hits.ToString();
            this.ddlSoftLevel.SelectedValue = model.PBnet_SoftLevel.ToString();
            this.txtSoftPoint.Text = model.PBnet_SoftPoint.ToString();
            this.txtDecompressPassword.Text = model.pb_DecompressPassword;
            this.txtSoftSize.Text = model.PBnet_SoftSize.ToString();
            this.txtDownloadUrl1.Text = model.pb_DownloadUrl1;
            this.txtDownloadUrl2.Text = model.pb_DownloadUrl2;
            this.txtDownloadUrl3.Text = model.pb_DownloadUrl3;
            this.txtDownloadUrl4.Text = model.pb_DownloadUrl4;
            this.txtUpdateTime.Text = model.pb_UpdateTime.ToString();

            this.ckPb_softshow.Checked = model.PBnet_Softshow;
            this.ckIndexshow.Checked = model.pb_indexshow;
            this.ckPassed.Checked = model.pb_Passed;
            this.txtvideocount.Text = model.Video;

        }

        private void BindDropdownList()
        {
            Pbzx.BLL.PBnet_SoftClass softClassBLL = new Pbzx.BLL.PBnet_SoftClass();
            softClassBLL.BindSoftClass(this.ddlSoftClass, 1);

        }




        private void BindModel(Pbzx.Model.PBnet_Soft model)
        {
            model.pb_ClassID = int.Parse(this.ddlSoftClass.SelectedValue);
            model.PBnet_SoftName = this.txtSoftName.Text;
            model.PBnet_SoftVersion = this.txtSoftVersion3.Text;
            model.PBnet_SoftType = int.Parse(this.ddlSoftType.SelectedValue);
            model.PBnet_SoftLanguage = int.Parse(this.ddlSoftLanguage.SelectedValue);

            model.pb_CopyrightType = int.Parse(this.ddlCopyrightType.SelectedValue);

            model.pb_OperatingSystem = this.txtOperatingSystem.Text;
            model.pb_Author = this.txtAuthor.Text;

            model.pb_AuthorEmail = this.txtAuthorEmail.Text;
            model.pb_AuthorHomepage = this.txtAuthorHomepage.Text;

            //model.pb_DemoUrl = this.txtDemoUrl.Text;
            model.pb_RegUrl = this.txtRegUrl.Text;
            //  model.pbnet_so = this.txtSoftdemo.Text;

            model.PBnet_SoftPicUrl = this.txtLogo.Text;
            model.PBnet_SoftIntro = this.weSoftIntro.Value;
            model.pb_Keyword = this.txtKeyword.Text;
            model.pb_OnTop = this.chkOnTop.Checked;
            model.pb_Elite = this.chkElite.Checked;
            model.pb_Stars = int.Parse(this.ddlStars.SelectedValue);

            model.pb_DayHits = this.txtDayHits.Text == "" ? 0 : int.Parse(this.txtDayHits.Text);
            model.pb_WeekHits = this.txtWeekHits.Text == "" ? 0 : int.Parse(this.txtWeekHits.Text);
            model.pb_MonthHits = this.txtMonthHits.Text == "" ? 0 : int.Parse(this.txtMonthHits.Text);
            model.pb_Hits = this.txtHits.Text == "" ? 0 : int.Parse(this.txtHits.Text);

            model.PBnet_SoftLevel = int.Parse(this.ddlSoftLevel.SelectedValue);

            model.PBnet_SoftPoint = txtSoftPoint.Text == "" ? 0 : int.Parse(this.txtSoftPoint.Text);
            model.pb_DecompressPassword = this.txtDecompressPassword.Text;
            model.PBnet_SoftSize = this.txtSoftSize.Text == "" ? 0 : int.Parse(this.txtSoftSize.Text);

            model.pb_DownloadUrl1 = this.txtDownloadUrl1.Text;
            model.pb_DownloadUrl2 = this.txtDownloadUrl2.Text;
            model.pb_DownloadUrl3 = this.txtDownloadUrl3.Text;
            model.pb_DownloadUrl4 = this.txtDownloadUrl4.Text;
            model.pb_UpdateTime = Request.Form["txtUpdateTime"] == "" ? DateTime.Now : DateTime.Parse(Request.Form["txtUpdateTime"]);
            model.PBnet_Softshow = this.ckPb_softshow.Checked;
            model.pb_indexshow = this.ckIndexshow.Checked;
            model.pb_Passed = this.ckPassed.Checked;


            model.Video = this.txtvideocount.Text.Replace("'", "\"");

        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            string strErrMsg = "";
            if (this.txtSoftName.Text.Trim() == "")
            {
                strErrMsg += "��Դ���Ʋ���Ϊ��.\\r\\n";
            }
            if (this.txtSoftVersion3.Text.Trim() == "")
            {
                strErrMsg += "��Դ�汾����Ϊ��.\\r\\n";
            }
            if (this.txtLogo.Text.Trim() == "")
            {
                strErrMsg += "��ԴͼƬ���ܿ�.\\r\\n";
            }

            if (this.weSoftIntro.Value.Trim() == "")
            {
                strErrMsg += "��ϸ˵������Ϊ��.\\r\\n";
            }

            if (this.txtDownloadUrl1.Text.Trim() == "")
            {
                strErrMsg += "���ص�ַһ����Ϊ��.\\r\\n";
            }


            //string ext = "";

            //if (FileUploadLogo.FileName != "" && FileUploadLogo.FileBytes.Length > 100)
            //{
            //    ext = System.IO.Path.GetExtension(FileUploadLogo.FileName);

            //    if (ext != ".gif" && ext != ".jpg" && ext != ".jpeg")
            //    {
            //        strErrMsg += "���ͼƬ���ļ���ʽ����ȷ,ֻ�����ϴ�[.gif/.jpg/.jpeg]��ʽ���ļ�.\\r\\n";
            //    }
            //    if (FileUploadLogo.FileBytes.Length / 1024 > 2 * 1024)
            //    {
            //        strErrMsg += "���ͼƬ�ļ���С����ϵͳ����,��������ϴ�2M(2*1024kb)���ļ�.\\r\\n";
            //    }

            //}


            DateTime dt = new DateTime();
            if (!DateTime.TryParse(this.txtUpdateTime.Text, out dt))
            {
                strErrMsg += "����ʱ�����ݸ�ʽ����ȷ.\\r\\n";
            }

            //if (this.txtDayHits.Text.Trim() != "")
            //{
            //    if (!OperateText.IsNumber(this.txtDayHits.Text))
            //    {
            //        strErrMsg += "�����ش�����������.\\r\\n";
            //    }
            //}

            //if (this.txtDayHits.Text.Trim() != "")
            //{
            //    if (!OperateText.IsNumber(this.txtDayHits.Text))
            //    {
            //        strErrMsg += "�����ش�����������.\\r\\n";
            //    }
            //}
            //if (this.txtWeekHits.Text.Trim() != "")
            //{
            //    if (!OperateText.IsNumber(this.txtWeekHits.Text))
            //    {
            //        strErrMsg += "�����ش�����������.\\r\\n";
            //    }
            //}
            //if (this.txtMonthHits.Text.Trim() != "")
            //{
            //    if (!OperateText.IsNumber(this.txtMonthHits.Text))
            //    {
            //        strErrMsg += "�����ش�����������.\\r\\n";
            //    }
            //}
            //if (this.txtHits.Text.Trim() != "")
            //{
            //    if (!OperateText.IsNumber(this.txtHits.Text))
            //    {
            //        strErrMsg += "�����ش�����������.\\r\\n";
            //    }
            //}
            //if (this.txtSoftPoint.Text.Trim() != "")
            //{
            //    if (!OperateText.IsNumber(this.txtSoftPoint.Text))
            //    {
            //        strErrMsg += "���ص�����������.\\r\\n";
            //    }
            //}
            //if (this.txtSoftSize.Text.Trim() != "")
            //{
            //    if (!OperateText.IsNumber(this.txtSoftSize.Text))
            //    {
            //        strErrMsg += "�����С��������.\\r\\n";
            //    }
            //}

            if (strErrMsg != "")
            {
                strErrMsg = "���ύ����Դ��Ϣ�д������´���:\\r\\n\\r\\n" + strErrMsg + "\\r\\n���޸ĺ��������ύ.";
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                return;
            }

            Pbzx.Model.PBnet_Soft myProduct;
            Pbzx.BLL.PBnet_Soft productBLL = new Pbzx.BLL.PBnet_Soft();

            int LinkID = Convert.ToInt32(hfFriendLinkID.Value);
            if (LinkID > 0)
            {
                myProduct = productBLL.GetModel(LinkID);
                //myProduct.pb_UpdateTime = DateTime.Now;
            }
            else
            {
                myProduct = new Pbzx.Model.PBnet_Soft();
            }

            //string filename = "Images/UploadFiles/Product/P_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ext;

            //if (FileUploadLogo.FileName != "" && FileUploadLogo.FileBytes.Length > 100)
            //{
            //    if (myProduct.PBnet_SoftPicUrl != "")
            //    {
            //        Files.deleteFile(Server.MapPath("../" + myProduct.PBnet_SoftPicUrl));
            //    }
            //    FileUploadLogo.SaveAs(Server.MapPath("../" + filename));
            //    myProduct.PBnet_SoftPicUrl = filename;
            //}
            myProduct.PBnet_SoftPicUrl = this.txtLogo.Text;

            BindModel(myProduct);

            if (myProduct.PBnet_SoftID > 0)
            {
                if (productBLL.Update(myProduct))
                {
                    Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("�޸�", "�޸���Դ��Ϣ[" + myProduct.PBnet_SoftID + ":" + myProduct.PBnet_SoftName + "].");
                    //Response.Write("<script>alert('�޸ĳɹ�');window.opener.location.reload();window.opener.focus();window.opener=null;window.open('','_self');window.close();</script>");
                    Response.Redirect("Soft_Manage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('�޸�ʧ��');</script>");
                }
            }
            else
            {
                if (productBLL.Add(myProduct))
                {
                    Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("����", "�����Դ��Ϣ[" + myProduct.PBnet_SoftID + ":" + myProduct.PBnet_SoftName + "].");
                    //Response.Write("<script>alert('��ӳɹ�');window.opener.location.reload();window.opener.focus();window.opener=null;window.open('','_self');window.close();</script>");
                    Response.Redirect("Soft_Manage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('���ʧ��');</script>");
                }
            }
            //ˢ����ҳ
            WebFunc.RefDefault();
        }

        protected void btClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("Soft_Manage.aspx");
        }


    }
}
