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

namespace Pinble_Help
{
    public partial class ViewHelp : System.Web.UI.Page
    {
        Pbzx.BLL.publicMethod get_public = new Pbzx.BLL.publicMethod();
        Pbzx.BLL.CstSoftware get_sft = new Pbzx.BLL.CstSoftware();
        Pbzx.BLL.Help_Contrast get_con = new Pbzx.BLL.Help_Contrast();
        DataSet ds = new DataSet();
        Repeater DL = new Repeater();
        DataTable dt = new DataTable();
        public string n_download;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCstName();
                
            }
            DownLoadMian();
        }

        /// <summary>
        /// 绑定软件名称
        /// </summary>
        private void BindCstName()
        {
            dt = get_sft.GetLisBySql("select distinct SoftwareType from CstSoftware where Flag!=0 and VersionType<=100 group by SoftwareType");
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DL = (Repeater)e.Item.FindControl("Repeater2");
                //找到分类Repeater关联的数据项 
                DataRowView rowv = (DataRowView)e.Item.DataItem;
                ds = get_sft.GetList("SoftwareType=" + Convert.ToInt32(rowv["SoftwareType"]) + " and Flag!=0 and VersionType<=100");
                DL.DataSource = ds;
                DL.DataBind();

            }
            foreach (RepeaterItem Rep in this.Repeater1.Items)
            {
                Label lab_name = Rep.FindControl("lab_name") as Label;
                DataTable dt_name = get_sft.GetLisBySql("select top 1 SoftwareName,InstallType from CstSoftware where SoftwareType=" + Convert.ToInt32(dt.Rows[Rep.ItemIndex]["SoftwareType"]) + " order by InstallType asc");
                if (dt_name != null && dt_name.Rows.Count > 0)
                {
                    lab_name.Text = dt_name.Rows[0]["SoftwareName"].ToString();
                }
                else
                {
                    lab_name.Text = "";
                }

            }


        }
        protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            foreach (RepeaterItem RI in this.DL.Items)
            {
                LinkButton lb_Path = RI.FindControl("lb_Path") as LinkButton;
                DataSet dsCon = get_con.GetList("Ct_software=" + "'" + ds.Tables[0].Rows[RI.ItemIndex]["CstID"].ToString() + "'");
                if (dsCon != null && dsCon.Tables[0].Rows.Count > 0)
                {
                    DataSet dsHn = get_public.Chipped_Table("Help_HelpName", "Hn_ID,Hn_name", "Hn_ID=" + Convert.ToInt32(dsCon.Tables[0].Rows[0]["Ct_TreeNum"]));
                    if (dsHn != null && dsHn.Tables[0].Rows.Count > 0)
                    {
                        //id= 创建帮助ID +“|”+ 帮助文件的名称+ 软件的ID
                        lb_Path.PostBackUrl = "ViewHelp.aspx?id=" + Convert.ToInt32(dsHn.Tables[0].Rows[0]["Hn_ID"]) + "&name=" + ds.Tables[0].Rows[RI.ItemIndex]["CstName"].ToString() + "&helpName=" + dsHn.Tables[0].Rows[0]["Hn_name"].ToString() + "&cid=" + ds.Tables[0].Rows[RI.ItemIndex]["CstID"].ToString();
                    }
                }
                else
                {
                    lb_Path.PostBackUrl = "ViewHelp.aspx?id=" + "&name=" + ds.Tables[0].Rows[RI.ItemIndex]["CstName"].ToString() + "&helpName=0" + "&cid=" + ds.Tables[0].Rows[RI.ItemIndex]["CstID"].ToString();
                }
            }
        }

        //下载地址
        public void DownLoadMian()
        {
            Pbzx.BLL.Help_Download get_d=new Pbzx.BLL.Help_Download();
            int n_id = Convert.ToInt32(Request["cid"]);
            DataSet ds = get_d.GetList("d_type="+n_id);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                n_download = ds.Tables[0].Rows[0]["d_download"].ToString();
            }
        }
    }
}
