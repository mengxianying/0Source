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
    public partial class FriendLink_Editor : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Session["DefaultSelect"] = "Images/UploadFiles/FriendLink";
                //  FileUploadLogo.Attributes.Add("onchange", "Upload_OnChange(this,'txtLogo','LogoImageState');");

                string str = Request.QueryString["ID"];
                Pbzx.Model.PBnet_Links MyLink;
                Pbzx.BLL.PBnet_Links LinkBLL = new Pbzx.BLL.PBnet_Links();

                if (OperateText.IsNumber(str))
                {
                    MyLink = LinkBLL.GetModel(Convert.ToInt32(str));
                    lblAction.Text = "修改";
                    //btnCancel.Visible = true;
                    //btnCancel.Attributes.Add("onclick", "history.back();return false;");
                    this.ddlType.SelectedValue = MyLink.IntLinkType.ToString();
                }
                else
                {
                    MyLink = new Pbzx.Model.PBnet_Links();
                    lblAction.Text = "新增";
                    //btnCancel.Visible = false;
                    this.ddlType.SelectedValue = "1";
                }

                hfFriendLinkID.Value = MyLink.IntID.ToString();
                txtTitle.Text = MyLink.IntSiteName;
                txtLinkUrl.Text = MyLink.NteSiteUrl;

                //txtLogoUrl.Text = MyLink.NteLogoUrl;
                txtThumb.Text = MyLink.NteLogoUrl;
                txtContent.Text = MyLink.NteSiteIntro;
                txtSortOrder.Text = MyLink.SortOrder.ToString();
          //      txtModifyTime.Text = ((DateTime)MyLink.ModifyTime).ToShortDateString();
                if (MyLink.BitIsOK == 1)
                    rbtState.Items[0].Selected = true;
                else if (MyLink.BitIsOK == 0)
                    rbtState.Items[1].Selected = true;
                else
                    rbtState.Items[2].Selected = true;



                txtAdmin.Text = MyLink.NvarSiteAdmin;
                txtTel.Text = MyLink.Tel;
                txtQQ.Text = MyLink.QQ;

                this.rbtIsGood.Items[0].Selected = MyLink.BitIsGood;

                if (MyLink.BitIsGood)
                {
                    rbtIsGood.Items[0].Selected = true;
                }
                else
                {
                    rbtIsGood.Items[1].Selected = true;
                }
                txtEmail.Text = MyLink.NvarEmail;
                txtRemark.Text = MyLink.Remark;
            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            string strErrMsg = "";
            if (txtTitle.Text.Trim() == "")
            {
                strErrMsg += "网站名称不能为空.\\r\\n";
            }
            if (txtLinkUrl.Text.Trim() == "")
            {
                strErrMsg += "链接地址不能为空.\\r\\n";
            }
            //DateTime dtModify = DateTime.Now;
            //if (!DateTime.TryParse(this.txtModifyTime.Text, out dtModify))
            //{
            //    strErrMsg += "更新时间格式不正确.\\r\\n";
            //}

            if (!OperateText.IsNumber(txtSortOrder.Text.Trim()))
            {
                strErrMsg += "链接排序未输入或数据格式不正确.\\r\\n";
            }

            if (strErrMsg != "")
            {
                strErrMsg = "您提交的友情链接中存在以下错误:\\r\\n\\r\\n" + strErrMsg + "\\r\\n请修改后再重新提交.";
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                return;
            }

            Pbzx.Model.PBnet_Links MyLink;
            Pbzx.BLL.PBnet_Links LinkBLL = new Pbzx.BLL.PBnet_Links();

            int LinkID = Convert.ToInt32(hfFriendLinkID.Value);
            if (LinkID > 0)
            {
                MyLink = LinkBLL.GetModel(LinkID);
                MyLink.ModifyTime = DateTime.Now;
            }
            else
            {
                MyLink = new Pbzx.Model.PBnet_Links();
            }

            //MyLink.NteLogoUrl = txtLogoUrl.Text.Trim();
            MyLink.NteLogoUrl = txtThumb.Text;

            MyLink.IntLinkType = int.Parse(this.ddlType.SelectedValue);
            MyLink.IntSiteName = txtTitle.Text.Trim();
            MyLink.NteSiteUrl = txtLinkUrl.Text.Trim();
            MyLink.NteSiteIntro = txtContent.Text.Trim();
            MyLink.SortOrder = Convert.ToInt32(txtSortOrder.Text.Trim());
            MyLink.BitIsOK = Convert.ToInt32(rbtState.SelectedValue);


            MyLink.NvarSiteAdmin = txtAdmin.Text;
            MyLink.Tel = txtTel.Text;
            MyLink.QQ = txtQQ.Text;
            MyLink.BitIsGood = this.rbtIsGood.Items[0].Selected;
            MyLink.NvarEmail = txtEmail.Text;
            //  MyLink.ModifyTime = Convert.ToDateTime(this.txtModifyTime.Text);
            MyLink.Remark = txtRemark.Text;
            if (MyLink.IntID > 0)
            {
                if (LinkBLL.Update(MyLink))
                {
                    Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("修改", "修改友情链接[" + MyLink.IntID + ":" + MyLink.IntSiteName + "].");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("友情链接修改成功.", "FriendLink_Manage.aspx"));
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "err", JS.Alert("友情链接修改失败."));
                }
            }
            else
            {
                if (LinkBLL.Add(MyLink))
                {
                    Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("新增", "添加友情链接[" + MyLink.IntID + ":" + MyLink.IntSiteName + "].");

                    ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("友情链接添加成功.", "FriendLink_Manage.aspx"));
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "err", JS.Alert("友情链接添加失败."));
                }
            }
        }

        //protected void btnUp_Click(object sender, EventArgs e)
        //{
        //    string strErrMsg = "";
        //    string ext = "";

        //    if (FileUploadLogo.FileName != "" && FileUploadLogo.FileBytes.Length > 100)
        //    {
        //        ext = System.IO.Path.GetExtension(FileUploadLogo.FileName);
        //        if (ext != ".gif" && ext != ".jpg" && ext != ".jpeg")
        //        {
        //            strErrMsg += "网站Logo的文件格式不正确,只允许上传[.gif/.jpg/.jpeg]格式的文件.\\r\\n";
        //        }
        //        if (FileUploadLogo.FileBytes.Length / 1024 > 1024)
        //        {
        //            strErrMsg += "网站Logo文件大小超过系统限制,最大允许上传1M(1024kb)的文件.\\r\\n";
        //        }

        //    }
        //    if (strErrMsg != "")
        //    {
        //        strErrMsg = "您提交的友情链接中存在以下错误:\\r\\n\\r\\n" + strErrMsg + "\\r\\n请修改后再重新提交.";
        //        ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
        //        return;
        //    }
        //    string filename = "Images/UploadFiles/FriendLink/L_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ext;

        //    if (FileUploadLogo.FileName != "" && FileUploadLogo.FileBytes.Length > 100)
        //    {

        //     //  Files.deleteFile(Server.MapPath("../" + MyLink.NteLogoUrl));

        //        FileUploadLogo.SaveAs(Server.MapPath("../" + filename));

        //        txtLogoUrl.Text = "" + WebInit.webBaseConfig.WebUrl + "" + filename + "";
        //    }
        //}
    }
}
