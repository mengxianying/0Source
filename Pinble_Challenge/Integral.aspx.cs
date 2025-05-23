using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.DBUtility;
using Pbzx.Common;
using System.Text;

namespace Pinble_Challenge
{
    public partial class Integral : System.Web.UI.Page
    {
        Pbzx.BLL.PlatformPublic_UserWinning get_uw = new Pbzx.BLL.PlatformPublic_UserWinning();
        DataTable IsResult = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //
            }
            if (Request.Params["id"] != "" && Request.Params["id"] != null)
            {
                string n_lotStr = Request["id"].ToString();

                
                if (n_lotStr == "s")
                {
                    lbtn_s.CssClass = "hover";
                    lbtn_d.CssClass = "";
                    lbtn_p.CssClass = "";

                    repConBind("u_lottId=3 and u_platform='match'");
                    lab_lname.Text = "双色球";
                }
                if (n_lotStr == "d")
                {
                    lbtn_d.CssClass = "hover";
                    lbtn_s.CssClass = "";
                    lbtn_p.CssClass = "";
                    repConBind("u_lottId=1 and u_platform='match'");
                    lab_lname.Text = "3D";
                }
                if (n_lotStr == "p")
                {
                    lbtn_p.CssClass = "hover";
                    lbtn_s.CssClass = "";
                    lbtn_d.CssClass = "";
                    repConBind("u_lottId=9999 and u_platform='match'");
                    lab_lname.Text = "排列三";
                }
            }
            else
            {
                lbtn_s.CssClass = "hover";
                lbtn_d.CssClass = "";
                lbtn_p.CssClass = "";

                repConBind("u_lottId=3 and u_platform='match'");
            }
        }

        public void repConBind(string term)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(term);
            string Searchstr = sb.ToString();
            //发布时间倒序排列
            string order = "u_time desc";
            int mycount = 0;
            IsResult = get_uw.GuestGetBySearchIntegral(Searchstr, "*", order, 50, 3, AspNetPager1.CurrentPageIndex, out mycount);
            this.rep_con.DataSource = IsResult;
            this.rep_con.DataBind();
            AspNetPagerConfig(mycount);
        }
        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = 50;
            AspNetPager1.RecordCount = tempCount;
            AddCustomText();
        }
        protected void AddCustomText()
        {
            AspNetPager1.CustomInfoHTML = "总计<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>条&nbsp;";
            AspNetPager1.CustomInfoHTML += "<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "页</font>";
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            repConBind("u_platform='match'");
        }

        protected void rep_con_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem RI in this.rep_con.Items)
            {
                Label lab_lott = RI.FindControl("lab_lott") as Label;
                Label lab_lottType = RI.FindControl("lab_lottType") as Label;
                if (Convert.ToInt32(IsResult.Rows[RI.ItemIndex]["u_lottId"]) == 1)
                {
                    lab_lott.Text = "3D";
                }
                if (Convert.ToInt32(IsResult.Rows[RI.ItemIndex]["u_lottId"]) == 3)
                {
                    lab_lott.Text = "双色球";
                }
                if (Convert.ToInt32(IsResult.Rows[RI.ItemIndex]["u_lottId"]) == 9999)
                {
                    lab_lott.Text = "排列三";
                }
                Pbzx.BLL.Challenge_type get_type = new Pbzx.BLL.Challenge_type();
                DataSet ds_type = get_type.GetList("T_state=" + "'" + IsResult.Rows[RI.ItemIndex]["u_wItem"] + "'");
                lab_lottType.Text = ds_type.Tables[0].Rows[0]["T_cond"].ToString();
            }
        }



        protected void Button3_Click(object sender, EventArgs e)
        {
            string n_lotStr = string.Empty;
            int lott = 0;
            if (Request.Params["id"] != "" && Request.Params["id"] != null)
            {
                n_lotStr = Request["id"].ToString();
                if (n_lotStr == "s")
                {
                    lott = 3;
                }
                if (n_lotStr == "d")
                {
                    lott = 1;
                }
                if (n_lotStr == "p")
                {
                    lott = 9999;
                }
            }
            else
            {
                if (lott != 0)
                {
                    repConBind("u_lottId=" + "'" + lott + "'" + " and u_platform='match'" + " and u_name like " + "'%" + txt_search.Text + "%'" + " or u_issue like " + "'%" + txt_search.Text + "%'");
                }
                repConBind("u_lottId='3' and u_platform='match'" + " and u_name like " + "'%" + txt_search.Text + "%'" + " or u_issue like " + "'%" + txt_search.Text + "%'");
            }
            
        }

        private static bool IsNumeric(string str) //接收一个string类型的参数,保存到str里  
        {
            if (str == null || str.Length == 0)    //验证这个参数是否为空  
                return false;                           //是，就返回False  
            ASCIIEncoding ascii = new ASCIIEncoding();//new ASCIIEncoding 的实例  
            byte[] bytestr = ascii.GetBytes(str);         //把string类型的参数保存到数组里  

            foreach (byte c in bytestr)                   //遍历这个数组里的内容  
            {
                if (c < 48 || c > 57)                          //判断是否为数字  
                {
                    return false;                              //不是，就返回False  
                }
            }
            return true;                                        //是，就返回True  
        }  
    }
}