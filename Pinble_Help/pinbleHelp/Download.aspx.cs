using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Pinble_Help.pinbleHelp
{
    public partial class Download : System.Web.UI.Page
    {
        Pbzx.BLL.CstSoftware get_sft = new Pbzx.BLL.CstSoftware();
        DataTable dt = new DataTable();
        Pbzx.Model.Help_Download mod_d = new Pbzx.Model.Help_Download();
        Pbzx.BLL.Help_Download get_d = new Pbzx.BLL.Help_Download();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                BindCstName();
                Pbzx.BLL.PBnet_tpman get_tn = new Pbzx.BLL.PBnet_tpman();
                string name = Request.QueryString["name"];
                if (string.IsNullOrEmpty(name) == true)
                {
                    Pbzx.BLL.PBnet_tpman.IsLoginSoftware();
                }
                else
                {
                    DataSet ds_user = get_tn.GetList("Master_Name=" + "'" + Request["name"].ToString() + "'");
                    if (ds_user == null || ds_user.Tables[0].Rows.Count <= 0)
                    {
                        Pbzx.BLL.PBnet_tpman.IsLoginSoftware();
                    }
                }
            }
        }
        /// <summary>
        /// 绑定软件名称
        /// </summary>
        private void BindCstName()
        {
            dt = get_sft.GetLisBySql("select CstName,CstID from CstSoftware where Flag!=0 and VersionType<=100");
            myGridView.DataSource = dt;
            myGridView.DataKeyNames = new string[] { "CstID" };
            myGridView.DataBind();
        }

        //编辑数据
        protected void myGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            myGridView.EditIndex = e.NewEditIndex;
            BindCstName();
        }

        //序号
        protected void myGridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex > -1)
            {
                e.Row.Cells[0].Text = Convert.ToString(e.Row.RowIndex + 1);
            }
        }

        //取消更行
        protected void myGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            myGridView.EditIndex = -1;
            BindCstName();
        }

        //更新数据
        protected void myGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox txt_down = (TextBox)(myGridView.Rows[e.RowIndex].Cells[2].FindControl("txt_down"));
            
            if (get_d.Exists1(Convert.ToInt32(myGridView.DataKeys[e.RowIndex].Value)))
            {
                DataSet ds = get_d.GetList("d_type=" + Convert.ToInt32(myGridView.DataKeys[e.RowIndex].Value));
                mod_d = get_d.GetModel(Convert.ToInt32(ds.Tables[0].Rows[0]["d_id"]));
                mod_d.d_type = Convert.ToInt32(myGridView.DataKeys[e.RowIndex].Value);
                mod_d.d_download = txt_down.Text.ToString();
                if (get_d.Update(mod_d))
                {
                    Response.Write("<script>alert('修改成功')</script>");
                    myGridView.EditIndex = -1;
                    BindCstName();
                }
                else
                {
                    Response.Write("<script>alert('修改失败')</script>");
                }
            }
            else
            {
                mod_d.d_type = Convert.ToInt32(myGridView.DataKeys[e.RowIndex].Value);
                mod_d.d_download = txt_down.Text.ToString();
                if (get_d.Add(mod_d) > 0)
                {
                    Response.Write("<script>alert('添加成功')</script>");
                    myGridView.EditIndex = -1;
                    BindCstName();
                }
                else {
                    Response.Write("<script>alert('添加失败')</script>");
                }
            }
        }


        //绑定数据时触发
        protected void myGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int n_count = this.myGridView.Rows.Count;
                //行的状态是：正常状态 或者 交替行           
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                for (int i = 0; i < n_count; i++)
                {
                    Label lab_dowload = (Label)this.myGridView.Rows[i].FindControl("lab_dowload");
                    DataSet ds = get_d.GetList("d_type=" + Convert.ToInt32(dt.Rows[i]["CstID"]));
                    if (lab_dowload != null)
                    {
                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                        {
                            lab_dowload.Text = ds.Tables[0].Rows[0]["d_download"].ToString();
                        }
                        else
                        {
                            lab_dowload.Text = "暂时没有下载地址";
                        }
                    }
                }
            }


            //如果行的类型是数据绑定行       
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //行的状态是： 编辑状态 或者 （交替行且是编辑状态）             
                if (e.Row.RowState == DataControlRowState.Edit || e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Edit))
                {
                    TextBox txt_down = (TextBox)e.Row.FindControl("txt_down");
                    DataSet ds = get_d.GetList("d_type=" + Convert.ToInt32(myGridView.DataKeys[e.Row.RowIndex].Value));
                    if(txt_down!=null)
                    {
                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                        {
                            txt_down.Text = ds.Tables[0].Rows[0]["d_download"].ToString();
                        }
                    }
                }
            }
        }


    }
}