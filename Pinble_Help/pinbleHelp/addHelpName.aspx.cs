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
using System.IO;

namespace Pinble_Help.pinbleHelp
{
    public partial class addHelpName : System.Web.UI.Page
    {
        Pbzx.BLL.Help_HelpName get_name = new Pbzx.BLL.Help_HelpName();
        Pbzx.Model.Help_HelpName mod_name = new Pbzx.Model.Help_HelpName();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Pbzx.BLL.PBnet_tpman get_tn = new Pbzx.BLL.PBnet_tpman();
                string name = Request.QueryString["n"];
                if (string.IsNullOrEmpty(name) == true)
                {
                    Pbzx.BLL.PBnet_tpman.IsLoginSoftware();
                }
                else
                {
                    DataSet ds_user = get_tn.GetList("Master_Name=" + "'" + name + "'");
                    if (ds_user == null || ds_user.Tables[0].Rows.Count <= 0)
                    {
                        Pbzx.BLL.PBnet_tpman.IsLoginSoftware();
                    }
                }
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_add_Click(object sender, EventArgs e)
        {
            if (txt_HelpName.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('请填写帮助名称！')</script>");
                return;
            }
            if (RadioButtonList1.SelectedValue == "" || RadioButtonList1.SelectedValue == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('请选择状态！')</script>");
                return;
            }
            else
            {
                if (get_name.Exists(txt_HelpName.Text))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('已有相同名称的帮助文件！')</script>");
                    return;
                }
                else
                {
                    mod_name.Hn_name = txt_HelpName.Text;
                    mod_name.Hn_Open = Convert.ToInt32(RadioButtonList1.SelectedValue);
                    mod_name.Hn_path = "/leftHtml/" + txt_HelpName.Text + ".htm";
                    if (get_name.Add(mod_name) > 0)
                    {
                        DataSet ds = get_name.GetList("Hn_name=" + "'" + txt_HelpName.Text.ToString() + "'");
                        string path = Server.MapPath("~/html/" + Convert.ToInt32(ds.Tables[0].Rows[0]["Hn_ID"]));
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        //ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('添加成功！');window.open('HelpList.aspx');window.opener=null;window.open('','_self');window.close();</script>");
                        Response.Write("<script>alert('修改成功');window.opener.location.reload();window.opener.focus();window.opener=null;window.open('','_self');window.close();</script>");

                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('添加失败！')</script>");
                    }
                }
            }
        }
    }
}
