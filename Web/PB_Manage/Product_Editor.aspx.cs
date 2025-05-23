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
using System.Text;
using Maticsoft.DBUtility;

namespace Pbzx.Web.PB_Manage
{
    public partial class Product_Editor : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Session["FCKeditor:UserFilesPath"] = "/Images/UploadFiles/Product";
                Session["DefaultSelect"] = "Images/UploadFiles/Product";

                //绑定关联cst库软件名称start
                DataSet dsCstID = DbHelperSQL1.Query(" select CstID,CstName from CstSoftware ");
                this.ddlCstID.DataTextField = "CstName";
                this.ddlCstID.DataValueField = "CstID";
                this.ddlCstID.DataSource = dsCstID;
                this.ddlCstID.DataBind();
                //绑定关联cst库软件名称end

                //绑定软件版本类别
                DataTable dtProVersion = WebFunc.GetProductVersion();
                this.ddlSoftVersion.DataSource = dtProVersion;
                this.ddlSoftVersion.DataTextField = "VersionTypeName";
                this.ddlSoftVersion.DataValueField = "VersionTypeName";
                this.ddlSoftVersion.DataBind();


                ddlSoftVersion.Attributes.Add("onchange", "ParentChange(this);");
                BindDropdownList();
                string str = Request.QueryString["ID"];
                Pbzx.Model.PBnet_Product myProduct;
                Pbzx.BLL.PBnet_Product productBLL = new Pbzx.BLL.PBnet_Product();

                if (OperateText.IsNumber(str))
                {
                    myProduct = productBLL.GetModel(Convert.ToInt32(str));
                    lblAction.Text = "修改";
                    //btnCancel.Visible = true;
                    //btnCancel.Attributes.Add("onclick", "history.back();return false;");
                    BindItems(myProduct);
                }
                else
                {
                    myProduct = new Pbzx.Model.PBnet_Product();
                    lblAction.Text = "新增";
                    this.txtUpdateTime.Text = DateTime.Now.ToString();
                    //btnCancel.Visible = false;
                }
                hfFriendLinkID.Value = myProduct.pb_SoftID.ToString();
                //绑定价格
                BindNetPrice();
            }
        }

        private void BindItems(Pbzx.Model.PBnet_Product model)
        {
            this.ddlSoftClass.SelectedValue = model.pb_ClassID.ToString();
            this.txtSoftName.Text = model.pb_SoftName;
            this.ddlCstID.SelectedValue = model.CstID.ToString();
            this.txtSoftVersion3.Text = model.pb_SoftVersion;
            this.ddlSoftType.SelectedValue = model.pb_SoftType.ToString();
            this.ddlSoftLanguage.SelectedValue = model.pb_SoftLanguage.ToString();
            this.ddlCopyrightType.SelectedValue = model.pb_CopyrightType.ToString();
            this.ddlSoftVersion.SelectedValue = model.pb_TypeName;
            this.txtAuthor.Text = model.pb_Author;
            // this.txtAuthorEmail.Text = model.pb_AuthorEmail;
            // this.txtAuthorHomepage.Text = model.pb_AuthorHomepage;
            if (!string.IsNullOrEmpty(model.pb_DemoUrl))
            {
                this.txtDemoUrl.Text = model.pb_DemoUrl;
            }
            if (!string.IsNullOrEmpty(model.pb_RegUrl))
            {
                this.txtRegUrl.Text = model.pb_RegUrl;
            }
            this.txtSoftdemo.Text = model.pb_Softdemo;
            this.txtilluminate.Text = model.pb_illuminate;
            this.txtLogo.Text = model.pb_SoftPicUrl;
            this.weSoftIntro.Value = model.pb_SoftIntro;
            this.weSoftContent.Value = model.pb_softContent;
            this.txtKeyword.Text = model.pb_Keyword;
            this.chkOnTop.Checked = model.pb_OnTop;
            this.chkElite.Checked = model.pb_Elite;

            this.ddlStars.SelectedValue = model.pb_Stars.ToString();

            this.txtDayHits.Text = model.pb_DayHits.ToString();
            this.txtWeekHits.Text = model.pb_WeekHits.ToString();
            this.txtMonthHits.Text = model.pb_MonthHits.ToString();
            this.txtHits.Text = model.pb_Hits.ToString();
            this.ddlSoftLevel.SelectedValue = model.pb_SoftLevel.ToString();
            this.txtSoftPoint.Text = model.pb_SoftPoint.ToString();
            this.txtDecompressPassword.Text = model.pb_DecompressPassword;
            this.txtSoftSize.Text = model.pb_SoftSize.ToString();
            this.txtDownloadUrl1.Text = model.pb_DownloadUrl1;
            this.txtDownloadUrl2.Text = model.pb_DownloadUrl2;
            this.txtDownloadUrl3.Text = model.pb_DownloadUrl3;
            this.txtDownloadUrl4.Text = model.pb_DownloadUrl4;
            this.txtUpdateTime.Text = model.pb_UpdateTime.ToString();
            this.ckfreeshow.Checked = model.pb_freeshow;

            this.ckPb_softshow.Checked = model.PBnet_Softshow;
            this.ckIndexshow.Checked = model.pb_indexshow;
            this.ckPassed.Checked = model.pb_Passed;
            this.txtSystem.Text = model.pb_OperatingSystem.ToString();
            this.txtvideocount.Text = model.Video;
        }

        private void BindDropdownList()
        {
            Pbzx.BLL.PBnet_SoftClass softClassBLL = new Pbzx.BLL.PBnet_SoftClass();
            softClassBLL.BindSoftClass(this.ddlSoftClass, 0);

        }




        private void BindModel(Pbzx.Model.PBnet_Product model)
        {
            model.pb_ClassID = int.Parse(this.ddlSoftClass.SelectedValue);
            model.pb_SoftName = this.txtSoftName.Text;
            model.CstID = int.Parse(this.ddlCstID.SelectedValue);
            model.pb_SoftVersion = this.txtSoftVersion3.Text;
            model.pb_SoftType = int.Parse(this.ddlSoftType.SelectedValue);
            model.pb_SoftLanguage = int.Parse(this.ddlSoftLanguage.SelectedValue);

            model.pb_CopyrightType = int.Parse(this.ddlCopyrightType.SelectedValue);
            model.pb_TypeName = this.ddlSoftVersion.SelectedValue;

            model.pb_OperatingSystem = this.txtSystem.Text;
            model.pb_Author = this.txtAuthor.Text;

            model.pb_AuthorEmail = "";
            model.pb_AuthorHomepage = "";

            model.pb_DemoUrl = this.txtDemoUrl.Text;
            model.pb_RegUrl = this.txtRegUrl.Text;
            model.pb_Softdemo = this.txtSoftdemo.Text;
            model.pb_illuminate = this.txtilluminate.Text;

            model.pb_SoftPicUrl = this.txtLogo.Text;
            model.pb_SoftIntro = this.weSoftIntro.Value;
            model.pb_softContent = this.weSoftContent.Value;
            model.pb_Keyword = this.txtKeyword.Text;
            model.pb_OnTop = this.chkOnTop.Checked;
            model.pb_Elite = this.chkElite.Checked;
            model.pb_Stars = int.Parse(this.ddlStars.SelectedValue);

            model.pb_DayHits = this.txtDayHits.Text == "" ? 0 : int.Parse(this.txtDayHits.Text);
            model.pb_WeekHits = this.txtWeekHits.Text == "" ? 0 : int.Parse(this.txtWeekHits.Text);
            model.pb_MonthHits = this.txtMonthHits.Text == "" ? 0 : int.Parse(this.txtMonthHits.Text);
            model.pb_Hits = this.txtHits.Text == "" ? 0 : int.Parse(this.txtHits.Text);

            model.pb_SoftLevel = int.Parse(this.ddlSoftLevel.SelectedValue);

            model.pb_SoftPoint = this.txtSoftPoint.Text == "" ? 0 : int.Parse(this.txtSoftPoint.Text);
            model.pb_DecompressPassword = this.txtDecompressPassword.Text;
            model.pb_SoftSize = this.txtSoftSize.Text == "" ? 0 : int.Parse(this.txtSoftSize.Text);

            model.pb_DownloadUrl1 = this.txtDownloadUrl1.Text;
            model.pb_DownloadUrl2 = this.txtDownloadUrl2.Text;
            model.pb_DownloadUrl3 = this.txtDownloadUrl3.Text;
            model.pb_DownloadUrl4 = this.txtDownloadUrl4.Text;
            model.pb_UpdateTime = Request.Form["txtUpdateTime"] == "" ? DateTime.Now : DateTime.Parse(Request.Form["txtUpdateTime"]);
            model.pb_freeshow = this.ckfreeshow.Checked;

            model.PBnet_Softshow = this.ckPb_softshow.Checked;
            model.pb_indexshow = this.ckIndexshow.Checked;
            model.pb_Passed = this.ckPassed.Checked;
            model.pb_OperatingSystem = this.txtSystem.Text;
            model.Video = this.txtvideocount.Text.Replace("'", "\"");

        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            string strErrMsg = "";
            if (this.txtSoftName.Text.Trim() == "")
            {
                strErrMsg += "商品名称不能为空.\\r\\n";
            }
            if (this.txtSoftVersion3.Text.Trim() == "")
            {
                strErrMsg += "版本不能为空.\\r\\n";
            }
            if (this.ddlCstID.SelectedIndex < 0)
            {
                strErrMsg += "关联cst库软件名称不能为空.\\r\\n";
            }

            //if (this.txtAuthor.Text.Trim() == "")
            //{
            //    strErrMsg += "备注说明不能为空.\\r\\n";
            //}
            if (this.weSoftIntro.Value.Trim() == "")
            {
                strErrMsg += "简要说明不能为空.\\r\\n";
            }
            if (this.weSoftIntro.Value.Trim() == "")
            {
                strErrMsg += "软件详细说明不能为空.\\r\\n";
            }
            //if (this.txtKeyword.Text.Trim() == "")
            //{
            //    strErrMsg += "关键字不能为空.\\r\\n";
            //}
            if (this.txtDownloadUrl1.Text.Trim() == "")
            {
                strErrMsg += "下载地址一不能为空.\\r\\n";
            }

            if (this.txtvideocount.Text.Trim() != "")
            {
                if (!this.txtvideocount.Text.Trim().Contains("|"))
                {
                    strErrMsg += "录音视频输入错误！.\\r\\n";
                }
            }

            // string ext = "";

            //if (FileUploadLogo.FileName != "" && FileUploadLogo.FileBytes.Length > 100)
            //{
            //    ext = System.IO.Path.GetExtension(FileUploadLogo.FileName);

            //    if (ext != ".gif" && ext != ".jpg" && ext != ".jpeg")
            //    {
            //        strErrMsg += "软件图片的文件格式不正确,只允许上传[.gif/.jpg/.jpeg]格式的文件.\\r\\n";
            //    }
            //    if (FileUploadLogo.FileBytes.Length / 1024 > 2*1024)
            //    {
            //        strErrMsg += "软件图片文件大小超过系统限制,最大允许上传2M(2*1024kb)的文件.\\r\\n";
            //    }

            //}

            DateTime dt = new DateTime();
            if (!DateTime.TryParse(this.txtUpdateTime.Text.Trim(), out dt))
            {
                strErrMsg += "更新时间数据格式不正确.\\r\\n";
            }

            if (this.txtDayHits.Text.Trim() != "")
            {
                if (!OperateText.IsNumber(this.txtDayHits.Text))
                {
                    strErrMsg += "日下载次数不是数字.\\r\\n";
                }
            }

            if (this.txtDayHits.Text.Trim() != "")
            {
                if (!OperateText.IsNumber(this.txtDayHits.Text))
                {
                    strErrMsg += "日下载次数不是数字.\\r\\n";
                }
            }
            if (this.txtWeekHits.Text.Trim() != "")
            {
                if (!OperateText.IsNumber(this.txtWeekHits.Text))
                {
                    strErrMsg += "周下载次数不是数字.\\r\\n";
                }
            }
            if (this.txtMonthHits.Text.Trim() != "")
            {
                if (!OperateText.IsNumber(this.txtMonthHits.Text))
                {
                    strErrMsg += "月下载次数不是数字.\\r\\n";
                }
            }
            if (this.txtHits.Text.Trim() != "")
            {
                if (!OperateText.IsNumber(this.txtHits.Text))
                {
                    strErrMsg += "总下载次数不是数字.\\r\\n";
                }
            }
            if (this.txtSoftPoint.Text.Trim() != "")
            {
                if (!OperateText.IsNumber(this.txtSoftPoint.Text))
                {
                    strErrMsg += "下载点数不是数字.\\r\\n";
                }
            }
            if (this.txtSoftSize.Text.Trim() != "")
            {
                if (!OperateText.IsNumber(this.txtSoftSize.Text))
                {
                    strErrMsg += "软件大小不是数字.\\r\\n";
                }
            }

            if (this.txtDownloadUrl1.Text.Trim() == "")
            {
                strErrMsg += "下载地址一不能为空.\\r\\n";
            }

            if (strErrMsg != "")
            {
                strErrMsg = "您提交的商品信息中存在以下错误:\\r\\n\\r\\n" + strErrMsg + "\\r\\n请修改后再重新提交.";
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                return;
            }

            Pbzx.Model.PBnet_Product myProduct;
            Pbzx.BLL.PBnet_Product productBLL = new Pbzx.BLL.PBnet_Product();

            int LinkID = Convert.ToInt32(hfFriendLinkID.Value);
            if (LinkID > 0)
            {
                myProduct = productBLL.GetModel(LinkID);
                //myProduct.pb_UpdateTime = DateTime.Now;
            }
            else
            {
                myProduct = new Pbzx.Model.PBnet_Product();
            }

            myProduct.pb_SoftPicUrl = this.txtLogo.Text;

            BindModel(myProduct);

            if (myProduct.pb_SoftID > 0)
            {
                if (productBLL.Update(myProduct))
                {
                    // ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("软件信息修改成功."));                    
                    Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("修改", "修改商品信息[" + myProduct.pb_SoftID + ":" + myProduct.pb_SoftName + "].");
                    //Response.Write("<script>alert('修改成功');window.opener.location.reload();window.opener.focus();window.opener=null;window.open('','_self');window.close();</script>");
                    Response.Redirect("Product_Manage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('修改失败');</script>");
                }
            }
            else
            {
                myProduct.countid = WebFunc.GetMaxCountid() + 1;
                if (productBLL.Add(myProduct))
                {
                    //   ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("软件信息添加成功."));
                    Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("新增", "添加商品信息[" + myProduct.pb_SoftName + "].");
                    //Response.Write("<script>alert('添加成功');window.opener.location.reload();window.opener.focus();window.opener=null;window.open('','_self');window.close();</script>");
                    Response.Redirect("Product_Manage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('添加失败');</script>");
                }
            }
            //刷新首页
            WebFunc.RefDefault();
        }

        private void BindNetPrice()
        {
            //this.txtPrice.Enabled = true;
            //this.lsbUseTime.ClearSelection();
            //this.lsbUseTime.Items[0].Selected = true;
            Pbzx.BLL.PBnet_ProductPrice priceBLL = new Pbzx.BLL.PBnet_ProductPrice();
            if (string.IsNullOrEmpty(this.ddlSoftVersion.SelectedValue))
            {
                this.ddlSoftVersion.Items[0].Selected = true;
            }

            if (this.ddlSoftVersion.SelectedValue == "免费版")
            {
                txtUseTime.Text = "";
            }
            else
            {
                string[] prices = priceBLL.GetModelTime(this.ddlSoftVersion.SelectedValue);
                if (prices == null)
                {
                    txtUseTime.Text = "";
                }
                else
                {
                    txtUseTime.Text = prices[0] + " " + prices[1] + " " + prices[2] + " " + prices[3].Substring(0, prices[3].Length - 3) + " ";

                }
            }

        }

        private void BindSingle()
        {
            if (this.ddlSoftVersion.SelectedValue == "专业版" || this.ddlSoftVersion.SelectedValue == "免费版")
            {
                this.txtDemoUrl.Enabled = true;
                if (this.ddlSoftVersion.SelectedValue == "免费版")
                {
                    txtDemoUrl.Text = "免费";
                    txtRegUrl.Text = "免费";
                }
            }
            else
            {
                this.txtDemoUrl.Enabled = false;
            }
        }


        protected void ddlSoftVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindNetPrice();
            BindSingle();
        }

        protected void btClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("Product_Manage.aspx");
        }
    }
}
