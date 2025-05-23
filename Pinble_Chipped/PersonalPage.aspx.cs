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
using Pbzx.BLL;

namespace Pinble_Chipped
{
    public partial class PersonalPage : System.Web.UI.Page
    {
        Pbzx.BLL.publicMethod get_pub = new Pbzx.BLL.publicMethod();
        public static string pageName="";
        DataSet dsAttention = new DataSet();
        public static string name = ""; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pageName = Request["name"].ToString();
                //获取参数
                name = Request["name"].ToString();
                rep_AttentionBind();
                mainPage.Attributes.Add("src", "Personal.aspx?name="+Request["name"].ToString());
                mainPage.Attributes.Add("onload", "TuneHeight('mainPage','mainPage')");

                
            }
        }

        /// <summary>
        /// 绑定他关注的列表
        /// </summary>
        public void rep_AttentionBind()
        {
            dsAttention = get_pub.Chipped_Table("Chipped_Attention", "top 10 AName", "Attention=" + "'" + name + "'");
            this.rep_Attention.DataSource = dsAttention;
            this.rep_Attention.DataBind();
        }

        //绑定事件
        protected void rep_Attention_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem RI in rep_Attention.Items)
            {
                //声明控件
                Label lab_prix = RI.FindControl("lab_prix") as Label;
                DataSet dsWin = get_pub.Chipped_Table("PlatformPublic_UserWinning", "top 1 u_Monery", "u_name=" + "'" + dsAttention.Tables[0].Rows[0][0] + "'" + " and u_platform='Chipped' order by u_Monery desc");
                //if (dsWin != null && dsWin.Tables[0].Rows.Count > 0)
                //{
                //    if (Convert.ToDecimal(dsWin.Tables[0].Rows[0][0]) > 10000000)
                //    {
                //        lab_winName.Text = "千万大奖得主";
                //    }
                //    else if (Convert.ToDecimal(dsWin.Tables[0].Rows[0][0]) > 1000000)
                //    {
                //        lab_winName.Text = "百万大奖得主";
                //    }
                //    else if (Convert.ToDecimal(dsWin.Tables[0].Rows[0][0]) > 100000)
                //    {
                //        lab_winName.Text = "十万大奖得主";
                //    }
                //    else if (Convert.ToDecimal(dsWin.Tables[0].Rows[0][0]) > 10000)
                //    {
                //        lab_winName.Text = "万元大奖得主";
                //    }
                //    else if (Convert.ToDecimal(dsWin.Tables[0].Rows[0][0]) > 1000)
                //    {
                //        lab_winName.Text = "千元大奖得主";
                //    }
                //    else
                //    {
                //        lab_winName.Text = "暂时未或千元以上大奖";
                //    }
                //}
                //else
                //{
                //    lab_winName.Text = "暂时未千元以上大奖";
                //}
            }
        }
    }
}
