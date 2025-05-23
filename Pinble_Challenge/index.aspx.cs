using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.DBUtility;
using Pbzx.Common;

namespace Pinble_Challenge
{
    public partial class index : System.Web.UI.Page
    {
        Pbzx.BLL.Challenge_Cinfo get_c = new Pbzx.BLL.Challenge_Cinfo();
        DataSet ds_s = new DataSet();
        DataSet ds_d = new DataSet();
        DataSet ds_p = new DataSet();
        public static string lottName;
        public static string issueN;
        public static string issNum;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["id"] != "" && Request.Params["id"] != null)
            {
                string n_lotStr = Request["id"].ToString();
                
                if (!IsPostBack)
                {
                    
                }
                if (n_lotStr == "s")
                {
                    ddl_issue.Items.Clear();
                    ddl_issueBind(n_lotStr);
                    lottName = "";
                    lbtn_s.CssClass = "hover";
                    lbtn_d.CssClass = "";
                    lbtn_p.CssClass = "";
                    //默认绑定双色球 表
                    BindRepssq();
                    ssq_content.Visible = true;
                    
                    D_content.Visible = false;
                    P_content.Visible = false;
                    lab_lname.Text = "双色球";
                    lab_win.Text = "双色球";
                    //lab_wTime.Text = "";
                    labtime.Text = "每周二 四 日";
                    lottName = "ssq";

                    // 绑定条件
                    ddl_cond.Items.Clear();
                    Bindddl_cond(3);
                    lab_lott.Text = "双色球";
                    ClientScript.RegisterStartupScript(this.GetType(), "TheCall", "<script>TheCallData()</script>");
                }
                if (n_lotStr == "d")
                {
                    ddl_issue.Items.Clear();
                    ddl_issueBind(n_lotStr);
                    lottName = "";
                    lbtn_d.CssClass = "hover";
                    lbtn_s.CssClass = "";
                    lbtn_p.CssClass = "";
                    BindRep3D();
                    D_content.Visible = true;
                    ssq_content.Visible = false;
                    P_content.Visible = false;
                    lab_lname.Text = "福彩3D";
                    lab_win.Text = "福彩3D";
                    //lab_wTime.Text = Pbzx.BLL.publicMethod.lotteryNameData("FC3DData").ToString();
                    labtime.Text = "每日";
                    lottName = "sd";
                    ddl_cond.Items.Clear();
                    Bindddl_cond(1);
                    lab_lott.Text = "福彩3D";
                    ClientScript.RegisterStartupScript(this.GetType(), "TheCall", "<script>TheCallData()</script>");
                    
                }
                if (n_lotStr == "p")
                {
                    ddl_issue.Items.Clear();
                    ddl_issueBind(n_lotStr);
                    lottName = "";
                    lbtn_p.CssClass = "hover";
                    lbtn_s.CssClass = "";
                    lbtn_d.CssClass = "";
                    BindRepP();
                    P_content.Visible = true;
                    ssq_content.Visible = false;
                    D_content.Visible = false;
                    lab_lname.Text = "排列三";
                    lab_win.Text = "排列三";
                    labtime.Text = "每日";
                    lottName = "pl";

                    ddl_cond.Items.Clear();
                    Bindddl_cond(9999);
                    lab_lott.Text = "排列三";
                    ClientScript.RegisterStartupScript(this.GetType(), "TheCall", "<script>TheCallData()</script>");
                }
            }
            else
            {
                lottName = "";
                lbtn_s.CssClass = "hover";
                lbtn_d.CssClass = "";
                lbtn_p.CssClass = "";
                
                ssq_content.Visible = true;
                D_content.Visible = false;
                if (!IsPostBack)
                {
                    //默认绑定双色球 表
                    BindRepssq();
                    ddl_issueBind("s");
                }
                lottName = "ssq";

                ddl_cond.Items.Clear();
                Bindddl_cond(3);



                ClientScript.RegisterStartupScript(this.GetType(), "TheCall", "<script>TheCallData()</script>");
            }

        }

        /// <summary>
        /// 绑定双色球数据表
        /// </summary>
        public void BindRepssq()
        {
            string issue = Pbzx.BLL.publicMethod.Period(3);
            //查询当前开奖号码
            string openNum = lottOpenNum(3, Convert.ToInt32(issue));
            if (openNum == "")
            {
                int issN = Convert.ToInt32(issue) - 1;
                issueN = issN.ToString();
                lab_num.Text = lottOpenNum(3, Convert.ToInt32(issue) - 1);
            }
            else
            {
                issueN = issue;
                lab_num.Text = lottOpenNum(3, Convert.ToInt32(issue));
            }
            issNum = issue;
            ds_s = get_c.GetBankTransfer("C_issue=" + "'" + issue + "'");
            this.rep_conD.DataSource = ds_s;
            this.DataBind();
        }

        /// <summary>
        /// 绑定福彩3D数据表
        /// </summary>
        public void BindRep3D()
        {
            string issue = Pbzx.BLL.publicMethod.Period(1);
            //查询当前开奖号码
            string openNum = lottOpenNum(1,Convert.ToInt32(issue));
            if (openNum == "")
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
            issNum = issue;
            ds_d = get_c.GetBankTransferD("C_issue=" + "'" + issue + "'");
            this.rep_dd.DataSource = ds_d;
            this.rep_dd.DataBind();
        }
        /// <summary>
        /// 绑定排列3数据表
        /// </summary>
        public void BindRepP()
        {
            string issue = Pbzx.BLL.publicMethod.Period(4);
            //查询当前开奖号码
            string openNum = lottOpenNum(9999, Convert.ToInt32(issue));
            if (openNum == "")
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
            issNum = issue;
            ds_p = get_c.GetBankTransferP("C_issue=" + "'" + issue + "'");
            this.rep_pls.DataSource = ds_p;
            this.rep_pls.DataBind();
        }
        /// <summary>
        /// 绑定条件下拉表
        /// </summary>
        /// <param name="playName"></param>
        public void Bindddl_cond(int playName)
        { 
            Pbzx.BLL.Challenge_type get_te=new Pbzx.BLL.Challenge_type();
            this.ddl_cond.Items.Add(new ListItem("--请选择--", "0"));
            DataSet ds_cond = get_te.GetList("T_lottID="+playName);
            this.ddl_cond.DataSource = ds_cond;
            this.ddl_cond.DataTextField = "T_cond";
            this.ddl_cond.DataValueField = "T_cond";
            this.ddl_cond.DataBind();

            ListItem[] listItem = new ListItem[ddl_cond.Items.Count];
            ddl_cond.Items.CopyTo(listItem, 0);
            foreach (ListItem i in listItem)
            {
                if (i.Value == "直选1注" || i.Value == "组选1注" || i.Value == "5*5*5定位" || i.Value == "3*3*3定位" || i.Value =="5码")
                {
                    ddl_cond.Items.Remove(i);
                }

            }

        }

        //双色球绑定
        protected void rep_conD_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem RI in this.rep_conD.Items)
            {
                Label lab_h3l = RI.FindControl("lab_h3l") as Label;
                Label lab_h2l = RI.FindControl("lab_h2l") as Label;
                Label lab_hq6d = RI.FindControl("lab_hq6d") as Label;
                Label lab_s6hq = RI.FindControl("lab_s6hq") as Label;
                Label lab_s6lq = RI.FindControl("lab_s6lq") as Label;

                if (ds_s.Tables[0].Rows[RI.ItemIndex]["h3l"].ToString() != "")
                {
                    string num = "";
                    for (int i = 0; i < ds_s.Tables[0].Rows[RI.ItemIndex]["h3l"].ToString().Split(',').Length; i++)
                    {
                        if (i % 7 == 0 && i > 0)
                        {
                            num += ds_s.Tables[0].Rows[RI.ItemIndex]["h3l"].ToString().Split(',')[i] + "</br>";
                        }
                        else
                        {
                            num += ds_s.Tables[0].Rows[RI.ItemIndex]["h3l"].ToString().Split(',')[i] + ",";
                        }
                    }
                    lab_h3l.Text = num.Substring(0, num.Length - 1);
                }
                else
                {
                    lab_h3l.Text = "--";
                }
                if (ds_s.Tables[0].Rows[RI.ItemIndex]["h2l"].ToString() != "")
                {
                    string num = "";
                    for (int i = 0; i < ds_s.Tables[0].Rows[RI.ItemIndex]["h2l"].ToString().Split(',').Length; i++)
                    {
                        if (i % 5 == 0 && i > 0)
                        {
                            num += ds_s.Tables[0].Rows[RI.ItemIndex]["h2l"].ToString().Split(',')[i] + "</br>";
                        }
                        else
                        {
                            num += ds_s.Tables[0].Rows[RI.ItemIndex]["h2l"].ToString().Split(',')[i] + ",";
                        }
                    }
                    lab_h2l.Text = num.Substring(0, num.Length - 1);
                }
                else
                {
                    lab_h2l.Text = "--";
                }
                if (ds_s.Tables[0].Rows[RI.ItemIndex]["hq6d"].ToString() != "")
                {
                    string num = "";
                    for (int i = 1; i < ds_s.Tables[0].Rows[RI.ItemIndex]["hq6d"].ToString().Split(',').Length+1; i++)
                    {
                        if (i % 3 == 0)
                        {
                            num += ds_s.Tables[0].Rows[RI.ItemIndex]["hq6d"].ToString().Split(',')[i-1] + "</br>";
                        }
                        else
                        {
                            num += ds_s.Tables[0].Rows[RI.ItemIndex]["hq6d"].ToString().Split(',')[i-1] + ",";
                        }
                    }
                    lab_hq6d.Text = num.Substring(0, num.Length - 1);
                }
                else
                {
                    lab_hq6d.Text = "--";
                }
                if (ds_s.Tables[0].Rows[RI.ItemIndex]["s6hq"].ToString() != "")
                {
                    string num = "";
                    for (int i = 1; i < ds_s.Tables[0].Rows[RI.ItemIndex]["s6hq"].ToString().Split(',').Length + 1; i++)
                    {
                        if (i % 3 == 0)
                        {
                            num += ds_s.Tables[0].Rows[RI.ItemIndex]["s6hq"].ToString().Split(',')[i - 1] + "</br>";
                        }
                        else
                        {
                            num += ds_s.Tables[0].Rows[RI.ItemIndex]["s6hq"].ToString().Split(',')[i - 1] + ",";
                        }
                    }
                    lab_s6hq.Text = num.Substring(0, num.Length - 1);
                }
                else
                {
                    lab_s6hq.Text = "--";
                }
                if (ds_s.Tables[0].Rows[RI.ItemIndex]["s6lq"].ToString() != "")
                {
                    string num = "";
                    for (int i = 1; i < ds_s.Tables[0].Rows[RI.ItemIndex]["s6lq"].ToString().Split(',').Length + 1; i++)
                    {
                        if (i % 3 == 0)
                        {
                            num += ds_s.Tables[0].Rows[RI.ItemIndex]["s6lq"].ToString().Split(',')[i - 1] + "</br>";
                        }
                        else
                        {
                            num += ds_s.Tables[0].Rows[RI.ItemIndex]["s6lq"].ToString().Split(',')[i - 1] + ",";
                        }
                    }
                    lab_s6lq.Text = num.Substring(0, num.Length - 1);
                }
                else
                {
                    lab_s6lq.Text = "--";
                }
            }
        }

        //绑定期号下拉框
        public void ddl_issueBind(string lotID)
        {
            DataSet ds = new DataSet();
            if (lotID == "s")
            {
                string g_issue = Pbzx.BLL.publicMethod.Period(3);
                ddl_issue.Items.Add(new ListItem(g_issue, g_issue));
                ds = Maticsoft.DBUtility.DbHelperSQL1.Query("select top 30 issue from FCSSData order by issue desc");
                ddl_issue.DataSource = ds;
                ddl_issue.DataTextField = "issue";
                ddl_issue.DataValueField = "issue";
                ddl_issue.DataBind();
            }
            if (lotID == "d")
            {
                string g_issue = Pbzx.BLL.publicMethod.Period(1);
                ddl_issue.Items.Add(new ListItem(g_issue, g_issue));
                ds = Maticsoft.DBUtility.DbHelperSQL1.Query("select top 30 issue from FC3DData order by issue desc");
                ddl_issue.DataSource = ds;
                ddl_issue.DataTextField = "issue";
                ddl_issue.DataValueField = "issue";
                ddl_issue.DataBind();
            }
            if (lotID == "p")
            {
                string g_issue = Pbzx.BLL.publicMethod.Period(4);
                ddl_issue.Items.Add(new ListItem(g_issue, g_issue));
                ds = Maticsoft.DBUtility.DbHelperSQL1.Query("select top 30 issue from TCPL35Data order by issue desc");
                ddl_issue.DataSource = ds;
                ddl_issue.DataTextField = "issue";
                ddl_issue.DataValueField = "issue";
                ddl_issue.DataBind();
            }
        }

        //3D
        protected void rep_dd_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem RI in this.rep_dd.Items)
            {

            }
        }
        public string lottOpenNum(int lottID, int issue)
        {
            string num = "";
            if (lottID == 9999)
            {
                //排列3 9999
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
            return num;
        }

    }
}