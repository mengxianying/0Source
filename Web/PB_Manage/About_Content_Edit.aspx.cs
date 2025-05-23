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
    public partial class About_Content__Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["FCKeditor:UserFilesPath"] = "/Images/UploadFiles/Other";
                Session["DefaultSelect"] = "/Images/UploadFiles/Other";

                string str = Request.QueryString["ID"];
                Pbzx.BLL.PBnet_About ContentBll = new Pbzx.BLL.PBnet_About();
                Pbzx.Model.PBnet_About ContentModel;
                if (OperateText.IsNumber(str))
                {
                    ContentModel = ContentBll.GetModel(int.Parse(str.ToString()));
                    this.txtTitle.Text = ContentModel.UsTitle;
                    this.txtUsUrl.Text = ContentModel.UsUrl;

                    this.cbBtommShow.Checked = ContentModel.UsIsBtommShow;
                    this.cbIsAuditing.Checked = ContentModel.UsState;
                    this.txtIntSortID.Text = ContentModel.UsOrder.ToString();
                    this.txtContent.Value = ContentModel.UsContent;
                    this.txtHtmlUrl.Text = ContentModel.HtmlUrl;
                    this.HFHtmlUrl.Value = ContentModel.ID.ToString();
                   
                }
            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_About ContentBll = new Pbzx.BLL.PBnet_About();
            Pbzx.Model.PBnet_About ContentModel;

            Pbzx.BLL.PBnet_UrlMaping UrlBll = new Pbzx.BLL.PBnet_UrlMaping();
            Pbzx.Model.PBnet_UrlMaping UrlMedel;          

            int intID = Convert.ToInt32(Request["ID"]);

            if (intID > 0)
            {
                ContentModel = ContentBll.GetModel(intID);
                UrlMedel = UrlBll.GetModelName(txtTitle.Text.Trim());

            }
            else
            {
                ContentModel = new Pbzx.Model.PBnet_About();
                UrlMedel = new Pbzx.Model.PBnet_UrlMaping();
            }
            if (int.Parse(this.HFHtmlUrl.Value) > 0)
            {
            }
            else
            {
                Pbzx.Model.PBnet_About ContentModelIntId = ContentBll.GetIntId();
                string newId = (ContentModelIntId.ID + 1).ToString();
                ContentModel.AspxUrl = "/About.aspx?id=" + newId;
                ContentModel.ID = int.Parse(newId);
                UrlMedel.Aspx = "/About.aspx?id=" + newId;
            }
            ContentModel.UsTitle = txtTitle.Text.Trim();
            ContentModel.UsState = cbIsAuditing.Checked;

            ContentModel.UsUrl = this.txtUsUrl.Text;

            ContentModel.UsIsBtommShow = this.cbBtommShow.Checked;
            ContentModel.UsOrder = int.Parse(txtIntSortID.Text.Trim());
            ContentModel.UsContent = txtContent.Value;
            ContentModel.HtmlUrl = this.txtHtmlUrl.Text;

            ContentModel.UsAddTime = DateTime.Now;

            UrlMedel.Html = this.txtHtmlUrl.Text;

            UrlMedel.Depth = 0;

            UrlMedel.PageName = txtTitle.Text.Trim();
            if (intID > 0)
            {

                if (ContentBll.Update(ContentModel))
                {
                    if (txtHtmlUrl.Text.Trim() != "")
                    {
                        UrlBll.Update(UrlMedel);
                    }
                   
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("About_Content.aspx"));
                    Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("修改", "公司内容[" + ContentModel.ID + ":" + ContentModel.UsTitle + "].");

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("公司内容修改失败."));
                }
            }
            else
            {
                if (ContentBll.Add(ContentModel))
                {
                    if (txtHtmlUrl.Text.Trim() != "")
                    {
                        UrlBll.Add(UrlMedel);
                    }
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("About_Content.aspx"));
                    Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("新增", "公司内容[" + ContentModel.ID + ":" + ContentModel.UsTitle + "].");

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("公司内容添加失败."));
                }

            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("About_Content.aspx");
        }
    }
}
