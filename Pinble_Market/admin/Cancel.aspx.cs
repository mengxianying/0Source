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

namespace Pinble_Market.admin
{
    public partial class Cancel : System.Web.UI.Page
    {
        Pbzx.BLL.Market_CancelIndent get_cl = new Pbzx.BLL.Market_CancelIndent();
        Pbzx.Model.Market_CancelIndent get_modcl = new Pbzx.Model.Market_CancelIndent();
        Pbzx.BLL.Market_BuyInfo g_buy = new Pbzx.BLL.Market_BuyInfo();
        public string str = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int item = Convert.ToInt32(Input.Decrypt(Request["item"]));
                DataSet dstime = g_buy.GetList("issueInfoId=" + item + " and buyuserid=" + "'" + Method.Get_UserName + "'");
                if (Convert.ToInt32(DateTime.Now.Day) - Convert.ToInt32(Convert.ToDateTime(dstime.Tables[0].Rows[0]["BeginTime"]).Day) < 5)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "upScript", "alert('订制未超过5天不能退订')", true);
                    Response.Write("<Script language=JavaScript>window.open('Cancel.aspx');</Script>");
                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            int item =Convert.ToInt32(Input.Decrypt(Request["item"]));
            //判断有项目已经提交过申请
            if (!get_cl.Exists(Method.Get_UserName.ToString(),item))
            {
                //申请退款标志1：申请退款  2：取消申请
                get_modcl.CancelIndent = 1;
                //退订的条件ID
                get_modcl.CancelItem = item;
                //申请退款的会员
                get_modcl.CancelName = Method.Get_UserName.ToString();
                //退款的理由
                get_modcl.CancelSake = txt_gut.Text;

                //选择的理由
                if (cb1.Checked == true)
                {
                    str += cb1.Text.ToString() + "<br/>";
                }
                if (cb2.Checked == true)
                {
                    str += cb2.Text.ToString() + "<br/>";
                }
                if (cb3.Checked == true)
                {
                    str += cb3.Text.ToString() + "<br/>";
                }
                get_modcl.Other = str;
                get_modcl.CTime = DateTime.Now.Date;
                get_modcl.CApprove = 3;
                if (get_cl.Add(get_modcl) > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('申请成功！5个工作日内处理');window.close();</script>");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('申请失败。')</script>");
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "upScript", "alert('已经提交过退款申请')", true);
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            cb1.Checked = false;
            cb2.Checked = false;
            cb3.Checked = false;
            txt_gut.Text = "";
        }
    }
}
