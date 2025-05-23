using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using Pbzx.Common;

namespace Pinble_DataRivalry
{
    public partial class index : System.Web.UI.Page
    {
        Pbzx.BLL.DataRivalry_UpLoadFile get_uplod = new Pbzx.BLL.DataRivalry_UpLoadFile();
        Pbzx.BLL.DataRivalry_Contrast get_con = new Pbzx.BLL.DataRivalry_Contrast();
        Pbzx.BLL.DataRivalry_Rt get_rt = new Pbzx.BLL.DataRivalry_Rt();
        DataTable IsResult = new DataTable();
        private int rowCount = 0;
        Pbzx.BLL.DataRivalry_downLoad get_down = new Pbzx.BLL.DataRivalry_downLoad();
        DataSet ds_upload = new DataSet();
        Pbzx.Model.DataRivalry_downLoad mod_down = new Pbzx.Model.DataRivalry_downLoad();
        Pbzx.BLL.PlatformPublic_integralPrize get_ilp = new Pbzx.BLL.PlatformPublic_integralPrize();
        Pbzx.BLL.DataRivalry_Level get_l = new Pbzx.BLL.DataRivalry_Level();
        public static string lotteryName = "";
        public static string issueN;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
            Bind("1=1");
            
        }

        /// <summary>
        /// 绑定数据源
        /// </summary>
        /// <param name="search">搜索条件</param>
        public void Bind(string search)
        {
            Group.Visible = false;
            StringBuilder strSql = new StringBuilder();
            if (!string.IsNullOrEmpty(Request["id"]))
            {
                lotteryName = Request["id"].ToString();

            }
            else
            {
                lotteryName = "dx";
                //ddl_issue.Items.Clear();
                //ddl_issueBind(1);
            }
            if (lotteryName == "dx")
            {
                lbtn_dx.CssClass = "hover";
                lbtn_zx.CssClass = "";
                lbtn_p.CssClass = "";
                lbtn_pz.CssClass = "";
                strSql.Append("F_SingleGroup=1");
                strSql.Append(" and F_lottery=1");
                strSql.Append(" and "+search);
                //ddl_issue.Items.Clear();
                //ddl_issueBind(1);
                string issue = Pbzx.BLL.publicMethod.Period(1);
                //查询当前开奖号码
                string openNum = lottOpenNum(1, Convert.ToInt32(issue));
                if (openNum == "暂无开奖号码")
                {
                    int issN = Convert.ToInt32(issue) - 1;
                    issueN = issN.ToString();
                    lab_num.Text = lottOpenNum(1, Convert.ToInt32(issue) - 1);
                }
                else
                {
                    issueN = issue;
                    lab_num.Text = lottOpenNum(1, Convert.ToInt32(issue));
                }
                ////根据选择的期号 返回开奖号码
                ////string n_openNum = lottOpenNum(1, Convert.ToInt32(ddl_issue.SelectedValue));
                //openN.Visible = false;
                //openNT.Visible = true;
                ////openNT.InnerHtml = ddl_issue.SelectedValue + "期 福彩3D 开奖号码：<font color='red'>" + n_openNum + "</font>";
                Radio.Visible = true;
                Group.Visible = false;
            }
            if (lotteryName == "zx")
            {
                lbtn_dx.CssClass = "";
                lbtn_zx.CssClass = "hover";
                lbtn_p.CssClass = "";
                lbtn_pz.CssClass = "";

                strSql.Append("F_SingleGroup=2");
                strSql.Append(" and F_lottery=1");
                strSql.Append(" and " + search);
                //ddl_issue.Items.Clear();
                //ddl_issueBind(1);
                string issue = Pbzx.BLL.publicMethod.Period(1);
                //查询当前开奖号码
                string openNum = lottOpenNum(1, Convert.ToInt32(issue));
                if (openNum == "暂无开奖号码")
                {
                    int issN = Convert.ToInt32(issue) - 1;
                    issueN = issN.ToString();
                    lab_num.Text = lottOpenNum(1, Convert.ToInt32(issue) - 1);
                }
                else
                {
                    issueN = issue;
                    lab_num.Text = lottOpenNum(1, Convert.ToInt32(issue));
                }

                //根据选择的期号 返回开奖号码
                //string n_openNum = lottOpenNum(1, Convert.ToInt32(ddl_issue.SelectedValue));
                //openN.Visible = false;
                //openNT.Visible = true;
                //openNT.InnerHtml = ddl_issue.SelectedValue + "期 福彩3D 开奖号码：<font color='red'>" + n_openNum + "</font>";
                Radio.Visible = false;
                Group.Visible = true;
            }
            if (lotteryName == "p")
            {
                lbtn_dx.CssClass = "";
                lbtn_zx.CssClass = "";
                lbtn_p.CssClass = "hover";
                lbtn_pz.CssClass = "";
                strSql.Append("F_SingleGroup=1");
                strSql.Append(" and F_lottery=2");
                strSql.Append(" and " + search);
                //ddl_issue.Items.Clear();
                //ddl_issueBind(4);
                string issue = Pbzx.BLL.publicMethod.Period(4);
                //查询当前开奖号码
                string openNum = lottOpenNum(9999, Convert.ToInt32(issue));
                if (openNum == "暂无开奖号码")
                {
                    int issN = Convert.ToInt32(issue) - 1;
                    issueN = issN.ToString();
                    lab_num.Text = lottOpenNum(9999, Convert.ToInt32(issue) - 1);
                }
                else
                {
                    issueN = issue;
                    lab_num.Text = lottOpenNum(9999, Convert.ToInt32(issue));
                }

                //根据选择的期号 返回开奖号码
                //string n_openNum = lottOpenNum(9999, Convert.ToInt32(ddl_issue.SelectedValue));
                //openN.Visible = false;
                //openNT.Visible = true;
                //openNT.InnerHtml = ddl_issue.SelectedValue + "期 排列三 开奖号码：<font color='red'>" + n_openNum + "</font>";
                Radio.Visible = true;
                Group.Visible = false;
            }
            if (lotteryName == "pz")
            {
                lbtn_dx.CssClass = "";
                lbtn_zx.CssClass = "";
                lbtn_p.CssClass = "";
                lbtn_pz.CssClass = "hover";
                strSql.Append("F_SingleGroup=2");
                strSql.Append(" and F_lottery=2");
                strSql.Append(" and " + search);
                //ddl_issue.Items.Clear();
                //ddl_issueBind(4);
                string issue = Pbzx.BLL.publicMethod.Period(4);
                //查询当前开奖号码
                string openNum = lottOpenNum(9999, Convert.ToInt32(issue));
                if (openNum == "暂无开奖号码")
                {
                    int issN = Convert.ToInt32(issue) - 1;
                    issueN = issN.ToString();
                    lab_num.Text = lottOpenNum(9999, Convert.ToInt32(issue) - 1);
                }
                else
                {
                    issueN = issue;
                    lab_num.Text = lottOpenNum(9999, Convert.ToInt32(issue));
                }

                //根据选择的期号 返回开奖号码
                //string n_openNum = lottOpenNum(9999, Convert.ToInt32(ddl_issue.SelectedValue));
                //openN.Visible = false;
                //openNT.Visible = true;
                //openNT.InnerHtml = ddl_issue.SelectedValue + "期 排列三 开奖号码：<font color='red'>" + n_openNum + "</font>";
                Radio.Visible = false;
                Group.Visible = true;
            }
            string Searchstr = strSql.ToString();
            string order = "F_addTime desc";
            int mycount = 0;
            IsResult = get_uplod.GuestGetBySearchUp(Searchstr, "*", order, 40, 3, AspNetPager1.CurrentPageIndex, out mycount);

            rep_listTable.DataSource = IsResult;
            rep_listTable.DataBind();
            rowCount = IsResult.Rows.Count;
            AspNetPagerConfig(mycount);
        }

        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = 40;
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
            Bind("1=1");
        }

        protected void rep_listTable_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem RI in this.rep_listTable.Items)
            {
                //中单
                Label lab_Single = RI.FindControl("lab_Single") as Label;
                //中组
                Label lab_group = RI.FindControl("lab_group") as Label;
                //2D
                Label lab_2D = RI.FindControl("lab_2D") as Label;
                //1D
                Label lab_1D = RI.FindControl("lab_1D") as Label;
                //0D
                Label lab_0D = RI.FindControl("lab_0D") as Label;

                DataSet ds = get_rt.GetList("Rt_AwardNum=" + Convert.ToInt32(IsResult.Rows[RI.ItemIndex]["F_drID"]) + " and Rt_UserName=" + "'" + IsResult.Rows[RI.ItemIndex]["F_username"].ToString() + "'");

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToInt32(IsResult.Rows[RI.ItemIndex]["F_SingleGroup"]) == 1)
                    {
                        lab_Single.Text = ds.Tables[0].Rows[0]["Rt_Single"].ToString();
                    }
                    if (Convert.ToInt32(IsResult.Rows[RI.ItemIndex]["F_SingleGroup"]) == 2)
                    {
                        lab_group.Text = ds.Tables[0].Rows[0]["Rt_Group"].ToString();
                    }
                    lab_2D.Text = ds.Tables[0].Rows[0]["Rt_two"].ToString();
                    lab_1D.Text = ds.Tables[0].Rows[0]["Rt_one"].ToString();
                    lab_0D.Text = ds.Tables[0].Rows[0]["Rt_zero"].ToString();
                }
                else
                {
                    lab_group.Text = "未开奖";
                    lab_2D.Text = "未开奖";
                    lab_1D.Text = "未开奖";
                    lab_0D.Text = "未开奖";
                }

            }
        }

        
        /// <summary>
        /// //绑定查询期号 （近30期）
        /// </summary>
        /// <param name="lottID">彩种编号</param>
        //public void ddl_issueBind(int lottID)
        //{
            
        //    DataSet ds = new DataSet();
        //    string g_issue = "";
        //    if(lottID==1)
        //    {
                
        //        ds = Maticsoft.DBUtility.DbHelperSQL1.Query("select top 30 issue from FC3DData");
        //        g_issue = Pbzx.BLL.publicMethod.Period(1);
                

        //    }
        //    if (lottID == 4)
        //    {
               
        //        ds = Maticsoft.DBUtility.DbHelperSQL1.Query("select top 30 issue from TCPL35Data");
        //        g_issue = Pbzx.BLL.publicMethod.Period(4);
               
        //    }
            
        //    ddl_issue.Items.Add(new ListItem(g_issue, g_issue));
        //    ddl_issue.DataSource = ds;

        //    ddl_issue.DataTextField = "issue";
        //    ddl_issue.DataValueField = "issue";
        //    ddl_issue.DataBind();
            
        //}

        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Search_Click(object sender, EventArgs e)
        {
            if (IsNumeric(txt_issue.Value.ToString()))
            {
                if (IsNumeric(txt_Least.Text.ToString()) && IsNumeric(txt_max.Text.ToString()))
                {
                    Bind("F_FileNum>=" + "'" + txt_Least.Text + "'" + " and F_FileNum<=" + "'" + txt_max.Text.ToString() + "'" + " and F_Period=" + "'" + txt_issue.Value.ToString() + "'");

                }
                else
                {
                    Bind("F_Period=" + "'" + txt_issue.Value.ToString() + "'");
                }
                if (!string.IsNullOrEmpty(Request["id"]))
                {
                    lotteryName = Request["id"].ToString();

                }
                if (lotteryName == "dx")
                {
                    //根据选择的期号 返回开奖号码
                    string n_openNum = lottOpenNum(1, Convert.ToInt32(txt_issue.Value.ToString()));
                    openN.Visible = false;
                    openNT.Visible = true;
                    openNT.InnerHtml = txt_issue.Value.ToString() + "期 福彩3D 开奖号码：<font color='red'>" + n_openNum + "</font>";
                    
                }
                if (lotteryName == "zx")
                {
                    //根据选择的期号 返回开奖号码
                    string n_openNum = lottOpenNum(1, Convert.ToInt32(txt_issue.Value));
                    openN.Visible = false;
                    openNT.Visible = true;
                    openNT.InnerHtml = txt_issue.Value.ToString() + "期 福彩3D 开奖号码：<font color='red'>" + n_openNum + "</font>";

                }
                if (lotteryName == "p")
                {
                    //根据选择的期号 返回开奖号码
                    string n_openNum = lottOpenNum(9999, Convert.ToInt32(txt_issue.Value));
                    openN.Visible = false;
                    openNT.Visible = true;
                    openNT.InnerHtml = txt_issue.Value.ToString() + "期 排列三 开奖号码：<font color='red'>" + n_openNum + "</font>";

                }
                if (lotteryName == "pz")
                {
                    //根据选择的期号 返回开奖号码
                    string n_openNum = lottOpenNum(9999, Convert.ToInt32(txt_issue.Value));
                    openN.Visible = false;
                    openNT.Visible = true;
                    openNT.InnerHtml = txt_issue.Value.ToString() + "期 排列三 开奖号码：<font color='red'>" + n_openNum + "</font>";

                }
            }
            else
            {
                if (IsNumeric(txt_Least.Text.ToString()) && IsNumeric(txt_max.Text.ToString()))
                {
                    if (txt_issue.Value.ToString() == "")
                    {
                        Bind("F_FileNum>=" + "'" + txt_Least.Text + "'" + " and F_FileNum<=" + "'" + txt_max.Text.ToString() + "'");
                    }
                    else
                    {
                        Bind("F_FileNum>=" + "'" + txt_Least.Text + "'" + " and F_FileNum<=" + "'" + txt_max.Text.ToString() + "'" + " and F_username=" + "'" + txt_issue.Value.ToString() + "'");
                    }

                }
                else
                {
                    if (!string.IsNullOrEmpty(txt_issue.Value.ToString()))
                    {
                        Bind("F_username=" + "'" + txt_issue.Value.ToString() + "'");
                    }
                    else
                    {
                        Bind("1=1");
                    }
                }
               
            }

        }

        //protected void ddl_issue_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Bind("F_Period=" + "'" + ddl_issue.SelectedValue + "'");
        //    //openN.Visible = false;
        //    txt_issue.Value = "";
        //}

        /// <summary>
        /// 获取彩种的开奖号码
        /// </summary>
        /// <param name="lottID">彩种ID</param>
        /// <param name="issue">期号</param>
        /// <returns></returns>
        public string lottOpenNum(int lottID, int issue)
        {
            string num = "";
            if (lottID == 9999)
            {
                num = Method.RlotteryNum(4, issue);
                if (num != "")
                {
                    num = num.Substring(0, 3);
                }

            }
            else
            {
                num = Method.RlotteryNum(lottID, issue);
            }
            if (num == "")
            {
                return "暂无开奖号码";
            }

            return num;
        }


        /// <summary>
        /// 验证字符串是否为 纯数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static bool IsNumeric(string str)
        {
            System.Text.RegularExpressions.Regex reg1 = new System.Text.RegularExpressions.Regex(@"^[-]?\d+[.]?\d*$");
            return reg1.IsMatch(str);
        }

        /// <summary>
        /// 3D 直选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_dx_Click(object sender, EventArgs e)
        {
            openN.Visible = true;
            openNT.Visible = false;
            txt_issue.Value = "";
            lab_lott.Text = "福彩3D";
        }

        /// <summary>
        /// 排3 直选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_p_Click(object sender, EventArgs e)
        {
            openN.Visible = true;
            openNT.Visible = false;
            txt_issue.Value = "";
            lab_lott.Text = "排列三";
        }

        /// <summary>
        /// 3D 组选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_zx_Click(object sender, EventArgs e)
        {
            openN.Visible = true;
            openNT.Visible = false;
            txt_issue.Value = "";
            lab_lott.Text = "福彩3D";
        }
        /// <summary>
        /// 排三组选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_pz_Click(object sender, EventArgs e)
        {
            openN.Visible = true;
            openNT.Visible = false;
            txt_issue.Value = "";
            lab_lott.Text = "排列三";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //850-899注
            Bind("F_FileNum>=850 and F_FileNum<=899");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //600-800注
            Bind("F_FileNum>=600 and F_FileNum<=800");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //200-600
            Bind("F_FileNum>=200 and F_FileNum<=600");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //90-110注
            Bind("F_FileNum>=90 and F_FileNum<=110");
        }

        /// <summary>
        /// 最新期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_new_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["id"]))
            {
                lotteryName = Request["id"].ToString();

            }
            else
            {
                lotteryName = "dx";
            }
            if (lotteryName == "dx" || lotteryName == "zx")
            {
                string issue = Pbzx.BLL.publicMethod.Period(1);
                Bind("F_Period="+"'"+ issue +"'");
            }
            if (lotteryName == "p" || lotteryName == "pz")
            {
                string issue = Pbzx.BLL.publicMethod.Period(4);
                Bind("F_Period=" + "'" + issue + "'");
            }
        }
    }
}