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

namespace Pbzx.Web.PB_Manage.Controls.cpdataconfig
{
    public partial class FC4Dconfig : AdminBasic
    {
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic();
        int intCode = 4;
        protected void Page_Load(object sender, EventArgs e)
        {
            basicDAL.IsCst = true;
            if (!Page.IsPostBack)
            {
                BindData();
                this.lblLinkAdd.Text = WebFunc.GetInfo("FC4DData_ShangH");       
            }

            Pbzx.BLL.PBnet_LotteryMenu lotBLL = new Pbzx.BLL.PBnet_LotteryMenu();
            DataSet ds = lotBLL.GetList(" NvarApp_name='FC4DData_ShangH' ");
            //string linkAdd = "";
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                this.txtIssue.MaxLength = Convert.ToInt32(row["IssueLen"]);



                string[] lotTypeSZ = row["LottTypeInfo"].ToString().Split(new char[] { '|' });
                string[] kjHaoSZ = lotTypeSZ[0].Split(new char[] { ',' });
                if (kjHaoSZ[5] == "数字型")
                {
                    intCode = Convert.ToInt32(kjHaoSZ[1]);
                }
                else
                {
                    intCode = Convert.ToInt32(kjHaoSZ[1]) * 2;
                }
                txtIssue.MaxLength = Convert.ToInt32(ds.Tables[0].Rows[0]["IssueLen"]);

                txtCode.MaxLength = intCode;
                lblCodeFW.Text = "范围：（" + kjHaoSZ[2] + " - " + kjHaoSZ[3] + "）";
            }


        }
        protected void BindData()
        {
            string sql = "select top 15 * from FC4DData_ShangH order by issue desc";
            DataTable dt = basicDAL.GetLisBySql(sql);
            this.MyGridView.DataSource = dt;
            this.MyGridView.DataBind();
            ViewState["hide"] = "0";
        }

        protected void BindDivAdd()
        {
            if (ViewState["hide"].ToString() == "0")
            {
                FC7LC_add_code_main(false, "", "");
                //this.txtissueseq.Enabled = true;
                this.txtIssue.Enabled = true;
                this.txtDate.Enabled = true;
                this.btnSave.Text = "添加";
            }
            else
            {
                DataRow row = basicDAL.GetRowBySql("select * from FC4DData_ShangH where issue='" + ViewState["hide"] + "'");
                FC7LC_add_code_main(true, row["date"], row["issue"]);
                //this.txtissueseq.Enabled = false;
                this.txtIssue.Enabled = false;
                this.txtDate.Enabled = false;
                this.btnSave.Text = "修改";
            }
        }

        protected void FC7LC_add_code_main(object bModify, object sdate, object sissue)
        {
            string code, issueseq;
            if (bool.Parse(bModify.ToString()) == false)
            {
                string sql = "select top 1 * from FC4DData_ShangH order by issue desc";
                DataTable dt = basicDAL.GetLisBySql(sql);
　　　　　  　  int tempInt = int.Parse(dt.Rows[0]["issue"].ToString()) + 1;
                sissue = tempInt.ToString();
                //int issueseq1 = int.Parse(dt.Rows[0]["issueseq"].ToString()) + 1;
                //issueseq=issueseq1.ToString();

                lblFW.Text = "格式：" + dt.Rows[0]["code"].ToString();

                sdate = DateTime.Parse(dt.Rows[0]["date"].ToString()).AddDays(1).ToShortDateString();

                //判断是否在休市时间之内start(孟2010-02-23)
                if (WebInit.webBaseConfig.YearStart != "" && WebInit.webBaseConfig.YearEnd != "")
                {
                    if (Convert.ToDateTime(sdate) >= DateTime.Parse(WebInit.webBaseConfig.YearStart) && Convert.ToDateTime(sdate) <= DateTime.Parse(WebInit.webBaseConfig.YearEnd))
                    {
                        sdate = DateTime.Parse(WebInit.webBaseConfig.YearEnd).AddDays(1).ToShortDateString();//下一期开始时间 
                    }
                }
                //判断是否在休市时间之内end(孟2010-02-23)

                if (DateTime.Parse(sdate.ToString()) > DateTime.Now)
                {
                    if (DateTime.Parse(sdate.ToString()) > DateTime.Now)
                    {
                        Response.Write("<script>alert('最新数据已经录入，请到下期开奖日再来录入新的数据！');history.go(-1);</script>");
                        Response.End();
                        //btnClear_Click(new object(), new EventArgs());
                        return;
                    }
                }
                //跨年处理 
                if (DateTime.Parse(sdate.ToString()).Year.ToString() != sissue.ToString().Substring(0, 4))
                {
                    sissue = DateTime.Now.Year + "001";
                }

                code = "";
                ViewState["hide"] = "0";
                this.btnSave.Text = "添加";
            }
            else
            {

                string sql = "select * from FC4DData_ShangH where issue='" + sissue + "'";
                DataTable dt = basicDAL.GetLisBySql(sql);
                //issueseq = dt.Rows[0]["issueseq"].ToString();
          　    sdate = dt.Rows[0]["date"];
                sissue = dt.Rows[0]["issue"];
                code = dt.Rows[0]["code"].ToString();
                ViewState["hide"] = sissue;
                this.btnSave.Text = "修改";
                lblFW.Text = "格式：" + code;
            }
            //this.txtissueseq.Text = issueseq;
            this.txtDate.Text = DateTime.Parse(sdate.ToString()).ToShortDateString();
            this.txtIssue.Text = sissue.ToString();
            this.txtCode.Text = code;

            //期号
            this.lblIssue.Text = "格式：" + sissue;
            this.txtDate.Text = Convert.ToDateTime(sdate).ToShortDateString();

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.FC4DData_ShangH MyBLL = new Pbzx.BLL.FC4DData_ShangH();
            string strErrMsg = "";
            if (this.txtCode.Text.Length < 4)
            {
                strErrMsg += "号码输入不完整.\\r\\n";
            }

            if (!OperateText.IsNumber(this.txtCode.Text))
            {
                strErrMsg += "号码格式输入不正确.\\r\\n";
            }

            DateTime now = DateTime.Now;
            if (!DateTime.TryParse(this.txtDate.Text,out now))
            {
                strErrMsg += "开奖日期格式不正确.\\r\\n";
            }
            //int zongQiHao = 4;
            //if (!int.TryParse(txtissueseq.Text,out zongQiHao))
            //{
            //    strErrMsg += "总期号格式不正确，应该为数字.\\r\\n";
            //}

            if (strErrMsg != "")
            {
                strErrMsg = "您提交的信息中存在以下错误:\\r\\n\\r\\n" + strErrMsg + "\\r\\n请修改后再重新提交.";
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                return;
            }
            else
            {
                Pbzx.Model.FC4DData_ShangH FCPL5Model;
                if (ViewState["hide"].ToString() == "0")
                {
                    FCPL5Model = new Pbzx.Model.FC4DData_ShangH();
                }
                else
                {
                    FCPL5Model = MyBLL.GetModel(ViewState["hide"].ToString());
                }
                //FCPL5Model.issueSeq = int.Parse(this.txtissueseq.Text);
                FCPL5Model.date = DateTime.Parse(this.txtDate.Text);
                FCPL5Model.issue = this.txtIssue.Text;
                FCPL5Model.code = this.txtCode.Text;
                FCPL5Model.LastModifyTime = DateTime.Now;
                FCPL5Model.OpIp = Request.UserHostAddress; ;
                FCPL5Model.OpName = WebFunc.GetCurrentAdmin();
                if (ViewState["hide"].ToString() == "0")
                {
                    if (MyBLL.Add(FCPL5Model))
                    {
                        ViewState["hide"] = "0";
                        btnList_Click(new object(), new EventArgs());
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "error", JS.Alert("添加失败!"));
                        return;
                    }

                }
                else
                {
                    if (MyBLL.Update(FCPL5Model))
                    {
                        ViewState["hide"] = "0";
                        btnList_Click(new object(), new EventArgs());
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "error", JS.Alert("更新失败!"));
                        return;
                    }
                }
            }
            ViewState["hide"] = "0";
            //Server.Execute("/PB_Manage/RefurbishCpXml.aspx?cpType=FC4DData_ShangH");
        }

        protected void FC7LC_del_code()
        {
            string sql = "";
            //判断是否搜索的数据
            if (txt_Condition.Text.Trim() != "" && txt_Condition.Text.Trim() != null)
            {
                string charSatr = txt_Condition.Text.ToString().Trim().Substring(txt_Condition.Text.Trim().Length - 1, 1);
                if (charSatr == "%")
                {
                    sql = "select top 1 * from FC4DData_ShangH where issue like " + "'" + txt_Condition.Text.ToString().Trim() + "'" + " order by issue desc";
                }
                else
                {
                    sql = "select top 1 * from FC4DData_ShangH where issue=" + "'" + txt_Condition.Text.ToString().Trim() + "'" + " order by issue desc";
                }
            }
            else
            {
                sql = "select top 1 * from FC4DData_ShangH order by issue desc";
            }
            DataRow row = basicDAL.GetRowBySql(sql);
            if (row == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "error", JS.Alert("没有可删除的开奖信息!"));
                return;
            }
            TimeSpan ts = DateTime.Now - DateTime.Parse(row["date"].ToString());          
            if (ts.TotalDays > 2)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "error1", JS.Alert("您只能删除最近二天的开奖信息"));
                return;
            }
            if (basicDAL.ExecuteSql("delete FC4DData_ShangH  where issue='" + row["issue"] + "'") > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "error2", JS.Alert("删除最近开奖信息成功！"));
            }
            ViewState["hide"] = "0";
        }

        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {
            string strIssue = e.CommandArgument.ToString();
            this.hfNewsID.Value = strIssue;
            ViewState["hide"] = strIssue;
            btnDivAdd_Click(new object(), new EventArgs());
        }

        //格式化IP地址
        protected string GetIp(object ip)
        {
            Pbzx.BLL.PBnet_ipdata ipBLL = new Pbzx.BLL.PBnet_ipdata();
            return ipBLL.S_getIPaddress(ip.ToString());
        }

        //让列表显示
        protected void btnList_Click(object sender, EventArgs e)
        {
            BindData();
            BindDivAdd();
            this.divAdd.Visible = false;
            this.divList.Visible = true;
            txt_Condition.Text = "";
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            FC7LC_del_code();
            //Server.Execute("/PB_Manage/RefurbishCpXml.aspx?cpType=FC4DData_ShangH");
        }

        //让添加显示
        protected void btnDivAdd_Click(object sender, EventArgs e)
        {
            BindDivAdd();
            this.divList.Visible = false;
            this.divAdd.Visible = true;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            BindData();
            BindDivAdd();
            this.divAdd.Visible = false;
            this.divList.Visible = true;
        }


        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Search_Click(object sender, EventArgs e)
        {
            if (txt_Condition.Text.Trim() != "" && txt_Condition.Text.Trim() != null)
            {
                ////判断长度
                //string charSatr = txt_Condition.Text.ToString().Trim().Substring(txt_Condition.Text.Trim().Length - 1, 1);
                string sql = "";
                //if (charSatr == "%")
                //{
                //    sql = "select top 120 * from FC4DData_ShangH where issue like " + "'" + txt_Condition.Text.ToString().Trim() + "'" + " order by issue desc";
                //}
                //else
                //{
                //    sql = "select top 120 * from FC4DData_ShangH where issue=" + "'" + txt_Condition.Text.ToString().Trim() + "'" + " order by issue desc";
                //}
                sql = "select top 120 * from " + ViewState["tableName"] + " where issue like " + "'" + txt_Condition.Text.ToString().Trim() + "%" + "'" + " order by issue desc";
                DataTable dt = basicDAL.GetLisBySql(sql);
                this.MyGridView.DataSource = dt;
                this.MyGridView.DataBind();
                ViewState["hide"] = "0";
            }
        }
    }
}
