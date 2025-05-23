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
    public partial class Public_Content_Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["FCKeditor:UserFilesPath"] = "/Images/UploadFiles/Other";
                Session["DefaultSelect"] = "/Images/UploadFiles/Other";

                Pbzx.BLL.PBnet_PulbicContent ContentBLL = new Pbzx.BLL.PBnet_PulbicContent();
                 Pbzx.Model.PBnet_PulbicContent MyContent;
                string str = Request.QueryString["IntID"];

                if (str != null && OperateText.IsNumber(str))
                {
                    MyContent = ContentBLL.GetModel(Convert.ToInt32(str));

                    txtTitle.Text = MyContent.NvarTitle;
                    ddlClass.SelectedValue = MyContent.NvarClass;
                    txtContent.Value = MyContent.NteContent;
                    chbState.Checked = MyContent.BitState;
                    txtHtmUrl.Text = MyContent.HtmUrl;

                    hfContentID.Value = MyContent.IntID.ToString();

                }

            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            string strErrMsg = "";
            if (txtTitle.Text.Trim() == "")
            {
                strErrMsg += "标题不能为空.\\r\\n";
            }
            if (txtHtmUrl.Text.Trim() == "")
            {
                strErrMsg += "静态页面地址不能为空.\\r\\n";
            }
            if (strErrMsg != "")
            {
                strErrMsg = "您提交的信息中存在以下错误:\\r\\n\\r\\n" + strErrMsg + "\\r\\n请修改后再重新提交.";
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                return;
            }
            else
            {
                Pbzx.BLL.PBnet_PulbicContent ContentBLL = new Pbzx.BLL.PBnet_PulbicContent();
                Pbzx.Model.PBnet_PulbicContent MyContent;

                int MyID=Convert.ToInt32(hfContentID.Value);
                if (MyID > 0)
                {
                    MyContent = ContentBLL.GetModel(MyID);
                }
                else
                {
                    MyContent = new Pbzx.Model.PBnet_PulbicContent();
                }

                MyContent.NvarTitle=txtTitle.Text;
                MyContent.NvarClass=ddlClass.SelectedValue;                
                MyContent.BitState =chbState.Checked;
                MyContent.NteContent =txtContent.Value;
                MyContent.HtmUrl =txtHtmUrl.Text;
                if (ddlClass.SelectedValue == "网站版权")
                {
                    MyContent.AspxUrl = "/Footer.aspx?ID="+MyContent.IntID.ToString();
                }

                if (MyID > 0)
                {
                    if (ContentBLL.Update(MyContent))
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("Public_Content.aspx"));
                        Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("修改", "修改内容[" + MyContent.IntID + ":" + MyContent.NvarTitle + "].");
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("修改失败."));
                    }

                }
                else
                {
                    if (ContentBLL.Add(MyContent))
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("Public_Content.aspx"));
                        Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("添加", "添加内容[" + MyContent.IntID + ":" + MyContent.NvarTitle + "].");
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("添加失败."));
                    }
                
                }

            }
        }
    }
}
