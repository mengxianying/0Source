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
using Pbzx.Help;


namespace Pinble_Help.pinbleHelp
{
    public partial class HelpList : System.Web.UI.Page
    {
        Pbzx.BLL.Help_HelpName get_name = new Pbzx.BLL.Help_HelpName();
        Pbzx.Model.Help_HelpName mod_name = new Pbzx.Model.Help_HelpName();
        DataSet ds = new DataSet();
        Pbzx.BLL.Help_Contrast get_cont = new Pbzx.BLL.Help_Contrast();
        public static string url = "";
        public string n = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //
                BindmyGridView();
                //Pbzx.BLL.PBnet_tpman get_tn = new Pbzx.BLL.PBnet_tpman();
                //string name = Request.QueryString["name"];
                //if (string.IsNullOrEmpty(name) == true)
                //{
                //    Pbzx.BLL.PBnet_tpman.IsLoginSoftware();
                //}
                //else
                //{
                //    n = name;
                //    DataSet ds_user = get_tn.GetList("Master_Name=" + "'" + Request["name"].ToString() + "'");
                //    if (ds_user == null || ds_user.Tables[0].Rows.Count <= 0)
                //    {
                //        Pbzx.BLL.PBnet_tpman.IsLoginSoftware();
                //    }
                //}
                //Pbzx.BLL.PBnet_tpman.IsLoginSoftware();
              

            }
        }

        /// <summary>
        /// 绑定数据列表
        /// </summary>
        private void BindmyGridView()
        {
            ds = get_name.GetList("Hn_Open=1");
            myGridView.DataSource = ds;
            myGridView.DataKeyNames = new string[] { "Hn_ID" };
            myGridView.DataBind();
        }

        /// <summary>
        /// 生成序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void myGridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex > -1)
            {
                e.Row.Cells[0].Text = Convert.ToString(e.Row.RowIndex + 1);
            }
        }

        /// <summary>
        /// 绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void myGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int count = this.myGridView.Rows.Count;
            string software = "";
            //行是正常状态或是交替行
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                for (int i = 0; i < count; i++)
                {
                    Label lab_software = this.myGridView.Rows[i].Cells[0].FindControl("lab_software") as Label;
                    DataSet ds_software = get_cont.GetList("Ct_TreeNum=" + ds.Tables[0].Rows[i]["Hn_ID"].ToString());
                    if (ds_software != null && ds_software.Tables[0].Rows.Count > 0)
                    {
                        for (int j = 0; j < ds_software.Tables[0].Rows.Count; j++)
                        {
                            Pbzx.BLL.CstSoftware get_sft = new Pbzx.BLL.CstSoftware();
                            DataTable dt = get_sft.GetLisBySql("select CstID,CstName from CstSoftware where CstID=" + Convert.ToInt32(ds_software.Tables[0].Rows[j]["Ct_software"]));
                            if (j >= 3 && j % 3 == 0)
                            {
                                software += dt.Rows[0]["CstName"].ToString() + "<br/>";
                            }
                            else
                            {
                                software += dt.Rows[0]["CstName"].ToString() + "，";
                            }
                        }
                        lab_software.Text = software;
                        software = "";
                    }
                    else
                    {
                        lab_software.Text = "";
                    }
                }
            }
            //如果是绑定数据行
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                {
                    ((LinkButton)e.Row.Cells[11].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('删除数据：关联软件和添加的软件帮助都会被删除?')");
                }
            }

        }
        protected void linkb_help_Click(object sender, EventArgs e)
        {
            string aspxHtml = "/Help.aspx";
            if (aspxHtml.IndexOf(".aspx") < 0)
            {
                System.Web.HttpContext.Current.Server.Execute(aspxHtml);
                System.Web.HttpContext.Current.Response.Write("<script>alert('生成导航成功！');</script>");
            }
            else if (aspxHtml.IndexOf("RefurbishCpXml.aspx") > 0)
            {
                System.Web.HttpContext.Current.Server.Execute(aspxHtml);
            }
            else
            {
                if (Files.Create("/Help.htm", "/Help.aspx"))
                {
                    System.Web.HttpContext.Current.Response.Write("<script>alert('生成成功！');</script>");
                }
                else
                {
                    System.Web.HttpContext.Current.Response.Write("<script>alert('生成失败！');</script>");
                }
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void myGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //删除帮助
            if (get_name.Delete(Convert.ToInt32(myGridView.DataKeys[e.RowIndex].Value)) > 0)
            {
                Response.Write("<script>alert('删除成功')</script>");
                BindmyGridView();
            }
            else
            {
                Response.Write("<script>alert('删除失败')</script>");
            }

        }

        /// <summary>
        /// 取消编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void myGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            myGridView.EditIndex = -1;
            BindmyGridView();
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void myGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            myGridView.EditIndex = e.NewEditIndex;
            BindmyGridView();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void myGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            mod_name = get_name.GetModel(Convert.ToInt32(myGridView.DataKeys[e.RowIndex].Value.ToString()));
            //获取要修改的列的Text 控件 
            TextBox txt_name = (TextBox)(myGridView.Rows[e.RowIndex].Cells[2].Controls[0]);
            if (txt_name.Text != "")
            {
                mod_name.Hn_name = txt_name.Text;
                if (get_name.Update(mod_name) > 0)
                {

                    Response.Write("<script>alert('修改成功')</script>");
                    myGridView.EditIndex = -1;
                    BindmyGridView();

                }
                else
                {
                    Response.Write("<script>alert('修改失败')</script>");
                }
            }
        }
        /// <summary>
        /// 验证登录
        /// </summary>
        public void login()
        {
            //string url = Request["urlAddress"].ToString();
            url = "FAFAF471359A4A0B";
            if (url != "")
            {
                WebFunc.validation(url);
            }
            else
            {
                //检查是否已登录.
                Pbzx.BLL.PBnet_tpman.IsLoginSoftware(); // 
            }
        }

    }
}
