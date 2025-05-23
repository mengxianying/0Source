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
    public partial class Broker_Content_Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["FCKeditor:UserFilesPath"] = "/Images/UploadFiles/Other";
                Session["DefaultSelect"] = "/Images/UploadFiles/Other";

                string str = Request.QueryString["ID"];
                Pbzx.BLL.PBnet_broker_content ContentBll = new Pbzx.BLL.PBnet_broker_content();
                Pbzx.Model.PBnet_broker_content ContentModel;
                if (OperateText.IsNumber(str))
                { 
                    ContentModel=ContentBll.GetModel(int.Parse(str.ToString()));
                    this.txtTitle.Text = ContentModel.Btitle;
                    this.ddlType.SelectedValue = ContentModel.Btype;
                    this.cbIsAuditing.Checked = ContentModel.IsAuditing;
                    this.txtIntSortID.Text = ContentModel.IntSortID.ToString();
                    this.txtContent.Value = ContentModel.Bcontent;
                }
            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_broker_content ContentBll = new Pbzx.BLL.PBnet_broker_content();
            Pbzx.Model.PBnet_broker_content ContentModel;
            int intID = Convert.ToInt32(Request["ID"]);

            if (intID > 0)
            {
                ContentModel = ContentBll.GetModel(intID);
            }
            else
            {
                ContentModel = new Pbzx.Model.PBnet_broker_content();
            }
            ContentModel.Btitle = txtTitle.Text.Trim();
            ContentModel.Btype = ddlType.SelectedValue;
            ContentModel.IsAuditing = cbIsAuditing.Checked;
            ContentModel.IntSortID = int.Parse(txtIntSortID.Text.Trim());
            ContentModel.Bcontent = txtContent.Value;

            if (intID > 0)
            {
                if (ContentBll.Update(ContentModel))
                {

                    ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("Broker_Content.aspx"));
                    Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("修改", "经纪人页面内容[" + ContentModel.ID + ":" + ContentModel.Btitle + "].");

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("经纪人页面内容修改失败."));
                }
            }
            else
            {
                if (ContentBll.Add(ContentModel))
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("Broker_Content.aspx"));
                    Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("新增", "经纪人页面内容[" + ContentModel.ID + ":" + ContentModel.Btitle + "].");

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("经纪人页面内容添加失败."));
                }

            }
       
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Broker_Content.aspx");
        }
    }
}
