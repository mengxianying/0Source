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

namespace Pinble_Help.pinbleHelp
{
    public partial class software : System.Web.UI.Page
    {
        Pbzx.BLL.Help_Contrast get_con = new Pbzx.BLL.Help_Contrast();
        Pbzx.Model.Help_Contrast mod_con = new Pbzx.Model.Help_Contrast();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Pbzx.Help.WebFunc.validation(Request["adress"].ToString());
                Bindcb_listSoftware();
            }
        }

        /// <summary>
        /// 绑定复选框
        /// </summary>
        private void Bindcb_listSoftware()
        {
            string name = Request["name"].ToString();
            lab_helpName.Text = name;

            Pbzx.BLL.CstSoftware get_sft = new Pbzx.BLL.CstSoftware();
            DataTable dt = get_sft.GetLisBySql("select CstID,CstName from CstSoftware");
            cb_listSoftware.DataSource = dt;
            cb_listSoftware.DataValueField = "CstID";
            cb_listSoftware.DataTextField = "CstName";
            cb_listSoftware.DataBind();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_add_Click(object sender, EventArgs e)
        {
            string id = Request["id"].ToString();
            //添加。 删除原来id 下的所有数据
            DataSet dsDelete = get_con.GetList("Ct_TreeNum=" + Convert.ToInt32(id));
            if (dsDelete != null && dsDelete.Tables[0].Rows.Count > 0)
            {
                if (get_con.DeleteID(Convert.ToInt32(id)) > 0)
                {
                    for (int i = 0; i < cb_listSoftware.Items.Count; i++)
                    {
                        if (this.cb_listSoftware.Items[i].Selected)
                        {
                            //check+=this.cb_listSoftware.Items[i].Value.ToString() + " | ";
                            mod_con.Ct_TreeNum = id;
                            mod_con.Ct_software = this.cb_listSoftware.Items[i].Value.ToString();
                            if (get_con.Add(mod_con) > 0)
                            {
                                //ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('添加成功！');window.opener=null;window.open('','_self');window.close();</script>");
                                Response.Write("<script>alert('添加成功');window.opener.location.reload();window.opener.focus();window.opener=null;window.open('','_self');window.close();</script>");
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('" + this.cb_listSoftware.Items[i].Text + ":添加失败！');</script>");
                                break;
                            }
                        }
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('数据已存在')</script>");
                }
            }
            else
            {
                for (int i = 0; i < cb_listSoftware.Items.Count; i++)
                {
                    if (this.cb_listSoftware.Items[i].Selected)
                    {

                        mod_con.Ct_TreeNum = id;
                        mod_con.Ct_software = this.cb_listSoftware.Items[i].Value.ToString();
                        if (get_con.Add(mod_con) > 0)
                        {
                            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('添加成功！');window.open('HelpList.aspx');window.opener=null;window.open('','_self');window.close();</script>");
                            Response.Write("<script>alert('添加成功');window.opener.location.reload();window.opener.focus();window.opener=null;window.open('','_self');window.close();</script>");
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('" + this.cb_listSoftware.Items[i].Text + ":添加失败！');</script>");
                            break;
                        }
                    }
                }
            }

        }

        protected void cb_listSoftware_DataBound(object sender, EventArgs e)
        {
            //查看是否添加  如果添加 则显示选中
            Pbzx.BLL.Help_Contrast get_help = new Pbzx.BLL.Help_Contrast();
            string id = Request["id"].ToString();

            int n = cb_listSoftware.Items.Count;
            for (int i = 0; i < n; i++)
            {
                DataSet ds = get_help.GetList("Ct_TreeNum=" + "'" + id + "'" + " and Ct_software=" + "'" + cb_listSoftware.Items[i].Value + "'");
                if (ds.Tables[0].Rows.Count > 0 && ds != null)
                {
                    cb_listSoftware.Items[i].Selected = true;
                }

            }
        }

    }
}
