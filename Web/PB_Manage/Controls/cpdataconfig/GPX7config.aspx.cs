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
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Collections.Generic;

namespace Pbzx.Web.PB_Manage.Controls.cpdataconfig
{
    public partial class GPX7config : AdminBasic
    {
        #region
        bool IsInsert = true;
        bool IsLianXu = true;
        int guangdongIssue = 10;


        int intCode = 14;//号码长度
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (int.Parse(DateTime.Now.Year.ToString().Substring(2, 2)) >= 10)
            {
                //otherIssue = 8;
            }
            basicDAL.IsCst = true;
            if (!Page.IsPostBack)
            {
                if (Request["city"] != null)
                {
                    if (ViewState["tableName"] == null)
                    {
                        ViewState["tableName"] = Input.FilterAll(Request["city"]);
                    }
                    BindData();
                }
            }
            SetLinkAdd();

        }

        private void SetYZValue(string min, string max)
        {
            this.rvd1.MinimumValue = min;
            this.rvd1.MaximumValue = max;
            this.rvd1.ErrorMessage = "码有误，范围（" + min + "--" + max + "）";

            this.rvd2.MinimumValue = min;
            this.rvd2.MaximumValue = max;
            this.rvd2.ErrorMessage = "号码有误，范围（" + min + "--" + max + "）";

            this.rvd3.MinimumValue = min;
            this.rvd3.MaximumValue = max;
            this.rvd3.ErrorMessage = "号码有误，范围（" + min + "--" + max + "）";

            this.rvd4.MinimumValue = min;
            this.rvd4.MaximumValue = max;
            this.rvd4.ErrorMessage = "号码有误，范围（" + min + "--" + max + "）";

            this.rvd5.MinimumValue = min;
            this.rvd5.MaximumValue = max;
            this.rvd5.ErrorMessage = "号码有误，范围（" + min + "--" + max + "）";

            this.rvd6.MinimumValue = min;
            this.rvd6.MaximumValue = max;
            this.rvd6.ErrorMessage = "号码有误，范围（" + min + "--" + max + "）";

            this.rvd7.MinimumValue = min;
            this.rvd7.MaximumValue = max;
            this.rvd7.ErrorMessage = "号码有误，范围（" + min + "--" + max + "）";

            //this.rvd8.MinimumValue = min;
            //this.rvd8.MaximumValue = max;
            //this.rvd8.ErrorMessage = "号码有误，范围（" + min + "--" + max + "）";

        }

        private void SetLinkAdd()
        {
            string linkAdd = "";
            linkAdd = GetInfo(ViewState["tableName"].ToString());
            this.lblLinkAdd.Text = linkAdd;
        }

        //得到开奖网址，每天开奖时间起始+期数+间隔
        private string GetInfo(string type)
        {
            string[] result = new string[] { "", "" };
            Pbzx.BLL.PBnet_LotteryMenu lotBLL = new Pbzx.BLL.PBnet_LotteryMenu();
            DataSet ds = lotBLL.GetList(" NvarApp_name='" + type + "' ");
            string linkAdd = "";
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
                    kjHaoSZ[2] = "01";

                }
                lblFW.Text = "范围：" + kjHaoSZ[2] + " - " + kjHaoSZ[3];

                guangdongIssue = Convert.ToInt32(row["IssueLen"]);
                this.Title = row["NvarName"] + "开奖信息管理";
                linkAdd += "<font color=333333><b>" + row["NvarName"] + "开奖信息管理</b></font>&nbsp;&nbsp;&nbsp;";
                string[] kjInfo = row["LottTypeInfo"].ToString().Split(new char[] { '|' });
                //string min = "01";
                //string max = "50";
                //string tmin = "1";
                //string tmax = "50";
                string codes = kjInfo[0];
                //string tcodes = null;
                //号码验证
                string[] codeArray = codes.Split(new char[] { ',' });
                if (codeArray.Length > 4)
                {
                    if (codeArray[2] == "1")
                    {
                        codeArray[2] = "01";
                    }
                    SetYZValue(codeArray[2], codeArray[3]);
                }

                string[] wzSZ = row["LottWebsites"].ToString().Split(new char[] { '|' });
                //网址
                foreach (string str in wzSZ)
                {
                    if (!string.IsNullOrEmpty(str))
                    {
                        string[] wzName = str.Split(new char[] { ',' });
                        if (!string.IsNullOrEmpty(wzName[0]) && !string.IsNullOrEmpty(wzName[1]))
                        {
                            result[0] += "<a href='" + wzName[1] + "' target='_blank'>" + wzName[0] + "</a>&nbsp;&nbsp;&nbsp;";
                        }
                    }
                }
                //时间
                object objTime = row["TimeList"];
                if (objTime != null && !string.IsNullOrEmpty(objTime.ToString()))
                {
                    result[1] += WebFunc.GetTimeListSZ(objTime)[0][0] + "&nbsp;&nbsp;每天" + row["DayLottCount"] + "期&nbsp;";
                }
                if (row["Mark"] != null && !string.IsNullOrEmpty(row["Mark"].ToString()))
                {
                    result[1] += "&nbsp;" + row["Mark"].ToString();
                }
            }
            return linkAdd + result[0] + result[1];
        }

        protected void BindData()
        {
            string sql = "select top 15 * from " + ViewState["tableName"] + " order by issue desc";
            DataTable dt = basicDAL.GetLisBySql(sql);
            if (dt.Rows.Count > 0)
            {
                this.lblIssue.Text = dt.Rows[0]["Issue"].ToString();
                this.lblIssue1.Text = dt.Rows[0]["Issue"].ToString();
                this.lblCode.Text = dt.Rows[0]["Code"].ToString();
                this.MyGridView.DataSource = dt;
                this.MyGridView.DataBind();
            }
            ViewState["hide"] = "0";
        }

        protected void BindDivAdd()
        {
            if (ViewState["hide"].ToString() == "0")
            {
                FC7LC_add_code_main(false, "", "");
                this.txtIssue.Enabled = true;
                this.txtDate.Enabled = true;
                this.btnSave.Text = "添加";
            }
            else
            {
                DataRow row = basicDAL.GetRowBySql("select * from " + ViewState["tableName"] + " where issue='" + ViewState["hide"] + "'");
                FC7LC_add_code_main(true, row["date"], row["issue"]);
                this.txtIssue.Enabled = false;
                this.txtDate.Enabled = false;
                this.btnSave.Text = "修改";
            }
        }
        protected void BindDivBatch()
        {
            this.txtBatch.Text = "";
            ViewState["hide"] = "0";
        }

        protected void FC7LC_add_code_main(object bModify, object sdate, object sissue)
        {
            //string code = "", code1 = "", code2 = "", code3 = "", code4 = "", code5 = "", code6 = "", code7 = "", code8 = "";
            string code = "", code1 = "", code2 = "", code3 = "", code4 = "", code5 = "", code6 = "", code7 = "";

            if (bool.Parse(bModify.ToString()) == false)
            {
                string sql = "select top 1 * from " + ViewState["tableName"] + " order by issue desc";
                DataTable dt = basicDAL.GetLisBySql(sql);
                if (dt.Rows.Count > 0)
                {
                    sissue = dt.Rows[0]["issue"].ToString();
                    sdate = DateTime.Parse(dt.Rows[0]["date"].ToString());
                    string[] result = CalcNextDate(sissue.ToString(), sdate.ToString());
                    sissue = result[0];
                    sdate = result[1];
                }
                code = "";
                code1 = "";
                code2 = "";
                code3 = "";
                code4 = "";
                code5 = "";
                code6 = "";
                code7 = "";
                //code8 = "";
                ViewState["hide"] = "0";
                this.btnSave.Text = "添加";
            }
            else
            {
                string sql = "select * from " + ViewState["tableName"] + " where issue='" + sissue + "'";
                DataTable dt = basicDAL.GetLisBySql(sql);
                if (dt.Rows.Count > 0)
                {
                    sdate = dt.Rows[0]["date"];
                    sissue = dt.Rows[0]["issue"];
                    code = dt.Rows[0]["code"].ToString();
                    code1 = code.Substring(0, 2);
                    code2 = code.Substring(2, 2);
                    code3 = code.Substring(4, 2);
                    code4 = code.Substring(6, 2);
                    code5 = code.Substring(8, 2);
                    code6 = code.Substring(10, 2);
                    code7 = code.Substring(12, 2);
                    //code8 = code.Substring(14, 2);
                }

                ViewState["hide"] = sissue;
                this.btnSave.Text = "修改";
            }
            this.txtDate.Text = sdate.ToString();
            this.txtIssue.Text = sissue.ToString();
            this.txtCode1.Text = code1;
            this.txtCode2.Text = code2;
            this.txtCode3.Text = code3;
            this.txtCode4.Text = code4;
            this.txtCode5.Text = code5;
            this.txtCode6.Text = code6;
            this.txtCode7.Text = code7;
            //this.txtCode8.Text = code8;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string sql = "select top 1 * from " + ViewState["tableName"] + " order by issue desc";
            DataTable dt = basicDAL.GetLisBySql(sql);

            string strErrMsg = "";
            //if (this.txtCode1.Text.Length != 2 || this.txtCode2.Text.Length != 2 || this.txtCode3.Text.Length != 2 || this.txtCode4.Text.Length != 2 || this.txtCode5.Text.Length != 2 || this.txtCode6.Text.Length != 2 || this.txtCode7.Text.Length != 2 || this.txtCode8.Text.Length != 2)
            //{
            //    strErrMsg += "号码输入不完整.\\r\\n";
            //}
            if (this.txtCode1.Text.Length != 2 || this.txtCode2.Text.Length != 2 || this.txtCode3.Text.Length != 2 || this.txtCode4.Text.Length != 2 || this.txtCode5.Text.Length != 2 || this.txtCode6.Text.Length != 2 || this.txtCode7.Text.Length != 2)
            {
                strErrMsg += "号码输入不完整.\\r\\n";
            }
            DateTime now = DateTime.Now;
            if (!DateTime.TryParse(this.txtDate.Text, out now))
            {
                strErrMsg += "开奖日期格式不正确.\\r\\n";
            }

            if (strErrMsg != "")
            {
                strErrMsg = "您提交的信息中存在以下错误:\\r\\n\\r\\n" + strErrMsg + "\\r\\n请修改后再重新提交.";
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                return;
            }

            //string code = this.txtCode1.Text + this.txtCode2.Text + this.txtCode3.Text + this.txtCode4.Text + this.txtCode5.Text + this.txtCode6.Text + this.txtCode7.Text + this.txtCode8.Text;
            string code = this.txtCode1.Text + this.txtCode2.Text + this.txtCode3.Text + this.txtCode4.Text + this.txtCode5.Text + this.txtCode6.Text + this.txtCode7.Text;
            string resultCode = code;
            string isCF = "";
            string[] result = CheckFormart(-1, this.txtIssue.Text, code);
            string errorMsg = result[0];
            isCF = result[1];
            resultCode = result[2];

            //期号错误
            if (errorMsg.Length > 0)
            {
                strErrMsg += errorMsg + ".\\r\\n";
            }
            //奖号错误
            if (isCF.Length > 0)
            {
                strErrMsg += isCF + ".\\r\\n";
            }
            if (strErrMsg != "")
            {
                strErrMsg = "您提交的信息中存在以下错误:\\r\\n\\r\\n" + strErrMsg + "\\r\\n请修改后再重新提交.";
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                return;
            }
            else
            {
                if (ViewState["hide"].ToString() == "0")
                {
                    if (dt.Rows.Count > 0 && dt.Rows[0]["issue"].ToString() == this.txtIssue.Text)
                    {
                        strErrMsg += "该开奖日期的开奖信息已经存在.\\r\\n";
                    }
                    if (strErrMsg != "")
                    {
                        strErrMsg = "您提交的信息中存在以下错误:\\r\\n\\r\\n" + strErrMsg + "\\r\\n请修改后再重新提交.";
                        ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                        return;
                    }
                    if (basicDAL.ExecuteSql(" insert into " + ViewState["tableName"] + "(issue,[date],Code,LastModifytime,OpIp,OpName) values('" + this.txtIssue.Text + "','" + this.txtDate.Text + "','" + resultCode + "','" + DateTime.Now + "','" + Request.UserHostAddress + "','" + WebFunc.GetCurrentAdmin() + "')") > 0)
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
                    if (basicDAL.ExecuteSql("update " + ViewState["tableName"] + " set issue='" + this.txtIssue.Text + "',[date]='" + this.txtDate.Text + "',Code='" + resultCode + "',LastModifytime='" + DateTime.Now + "',OpIp='" + Request.UserHostAddress + "',OpName='" + WebFunc.GetCurrentAdmin() + "' where issue='" + ViewState["hide"] + "' ") > 0)
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
            //Server.Execute("/PB_Manage/RefurbishCpXml.aspx?cpType=" + ViewState["tableName"]);
        }

        protected void FC7LC_del_code()
        {
            string sql = "";
            //判断是否搜索的数据
            if (txt_Condition.Text != "" && txt_Condition.Text != null)
            {
                string charSatr = txt_Condition.Text.ToString().Substring(txt_Condition.Text.Length - 1, 1);
                if (charSatr == "%")
                {
                    sql = "select top 1 * from " + ViewState["tableName"] + " where issue like " + "'" + txt_Condition.Text.ToString() + "'" + " order by issue desc";
                }
                else
                {
                    sql = "select top 1 * from " + ViewState["tableName"] + " where issue=" + "'" + txt_Condition.Text.ToString() + "'" + " order by issue desc";
                }
            }
            else
            {
                sql = "select top 1 * from " + ViewState["tableName"] + " order by issue desc";
            }
            DataRow row = basicDAL.GetRowBySql(sql);
            if (row == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "error", JS.Alert("没有可删除的开奖信息!"));
                return;
            }
            if (basicDAL.ExecuteSql("delete " + ViewState["tableName"] + "  where issue='" + row["issue"] + "'") > 0)
            {
                btnList_Click(new object(), new EventArgs());
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
            this.divAdd.Visible = false;
            this.divList.Visible = true;
            this.divBatchAdd.Visible = false;
            txt_Condition.Text = "";
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            FC7LC_del_code();
            //Server.Execute("/PB_Manage/RefurbishCpXml.aspx?cpType=" + ViewState["tableName"]);
        }

        //让添加显示
        protected void btnDivAdd_Click(object sender, EventArgs e)
        {
            BindDivAdd();
            this.divList.Visible = false;
            this.divAdd.Visible = true;
            this.divBatchAdd.Visible = false;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            BindData();
            this.divAdd.Visible = false;
            this.divList.Visible = true;
            this.divBatchAdd.Visible = false;
        }

        protected void btnBatchAdd_Click(object sender, EventArgs e)
        {
            BindDivBatch();
            this.divAdd.Visible = false;
            this.divList.Visible = false;
            this.divBatchAdd.Visible = true;
        }

        protected void batchOK_Click(object sender, EventArgs e)
        {
            FCSSL_batchSave_code(this.txtBatch.Text);
            //Server.Execute("/PB_Manage/RefurbishCpXml.aspx?cpType=" + ViewState["tableName"]);
        }


        /// <summary>
        /// 计算下一期期号和date
        /// </summary>
        /// <param name="issue"></param>
        /// <returns></returns>
        private string[] CalcNextDate(string issue, string strdate)
        {

            DateTime oldDate = DateTime.Parse(strdate);

            int tempINT = int.Parse(issue) + 1;

            string qishu = "";
            string date = "";
            string mynewIssue = "";


            Pbzx.BLL.PBnet_LotteryMenu lotBLL = new Pbzx.BLL.PBnet_LotteryMenu();
            //PBnet_LotteryMenu表当前彩种信息
            DataSet ds = lotBLL.GetList(" NvarApp_name='" + ViewState["tableName"] + "' ");
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

                object objTime = row["TimeList"];
                List<string> tmSZ = WebFunc.GetTimeListSZ(objTime)[1];
                //每天开奖期数
                qishu = row["DayLottCount"].ToString();

                mynewIssue = tempINT.ToString();

                for (int i = 0; i < tmSZ.Count; i++)
                {
                    if (TimeSpan.Parse(tmSZ[i]) == oldDate.TimeOfDay)//找到该时间所在时间序列位置
                    {
                        if (oldDate.TimeOfDay == TimeSpan.Parse(tmSZ[tmSZ.Count - 1]))//如果是一天中的最后一期(如果最后时间是0:00则不需要跨天，否则需要)
                        {
                            if (oldDate.TimeOfDay == TimeSpan.Parse("0:00"))
                            {
                                date = oldDate.ToShortDateString() + " " + tmSZ[0];
                            }
                            else
                            {
                                date = oldDate.AddDays(1).ToShortDateString() + " " + tmSZ[0];
                                //判断是否在休市时间之内start(孟2010-02-23)
                                if (WebInit.webBaseConfig.YearStart != "" && WebInit.webBaseConfig.YearEnd != "")
                                {
                                    if (Convert.ToDateTime(date) >= DateTime.Parse(WebInit.webBaseConfig.YearStart) && Convert.ToDateTime(date) <= DateTime.Parse(WebInit.webBaseConfig.YearEnd))
                                    {
                                        date = DateTime.Parse(WebInit.webBaseConfig.YearEnd).AddDays(1).ToShortDateString() + " " + tmSZ[0];//下一期开始时间 
                                    }
                                }
                                //判断是否在休市时间之内end(孟2010-02-23)
                            }
                            DateTime dtMyNewIssue = Convert.ToDateTime(date);
                            string tempYue = dtMyNewIssue.Month.ToString().Length < 2 ? "0" + dtMyNewIssue.Month.ToString() : dtMyNewIssue.Month.ToString();
                            string tempDay = dtMyNewIssue.Day.ToString().Length < 2 ? "0" + dtMyNewIssue.Day.ToString() : dtMyNewIssue.Day.ToString();


                            ///////////更新期号(孟3-11)
                            string[] qihaoClear = row["IssueInfo"].ToString().Split(new char[] { '&' });
                            string[] issueSzBig = qihaoClear[0].Split(new char[] { '|' });
                            string tempResult = "";
                            if (!string.IsNullOrEmpty(issueSzBig[0]))
                            {
                                string[] issueDate = issueSzBig[0].Split(new char[] { ',' });
                                if (!string.IsNullOrEmpty(issueDate[0]))
                                {
                                    if (issueDate[0] == "yyyy")
                                    {
                                        tempResult += dtMyNewIssue.Year.ToString();
                                    }
                                    else if (issueDate[0] == "yy")
                                    {
                                        tempResult += dtMyNewIssue.Year.ToString().Substring(2);
                                    }
                                }
                                if (issueSzBig[0].Contains("MM"))
                                {
                                    tempResult += tempYue;
                                }
                                if (issueSzBig[0].Contains("dd"))
                                {
                                    tempResult += tempDay;
                                }
                            }
                            string liuShui1 = "";
                            string liuShui2 = "";
                            //如果是按天更新
                            if (qihaoClear[1].Contains("日"))
                            {
                                //第二个流水号
                                if (issueSzBig.Length > 2)
                                {
                                    liuShui1 = Convert.ToString(int.Parse(issue.Substring(tempResult.Length, int.Parse(issueSzBig[1]))) + 1);
                                    for (int j = 0; j <= int.Parse(issueSzBig[1]) - liuShui1.Length; j++)
                                    {
                                        liuShui1 = "0" + liuShui1;
                                    }

                                    string tempLiushui = "";
                                    int length = int.Parse(issueSzBig[2]);
                                    for (int j = 0; j < length - 1; j++)
                                    {
                                        tempLiushui += "0";
                                    }
                                    tempLiushui += "1";
                                    liuShui2 += tempLiushui;
                                }
                                else
                                {
                                    //第一个流水号
                                    if (!string.IsNullOrEmpty(issueSzBig[1]))
                                    {
                                        string tempLiushui = "";
                                        int length = int.Parse(issueSzBig[1]);
                                        for (int j = 0; j < length - 1; j++)
                                        {
                                            tempLiushui += "0";
                                        }
                                        tempLiushui += "1";
                                        liuShui1 += tempLiushui;
                                    }
                                }
                            }
                            //如果是按年更新
                            if (qihaoClear[1].Contains("年") && !qihaoClear[1].Contains("日"))
                            {
                                if (dtMyNewIssue.Year != oldDate.Year)
                                {

                                    //第一个流水号
                                    if (!string.IsNullOrEmpty(issueSzBig[1]))
                                    {
                                        string tempLiushui = "";
                                        int length = int.Parse(issueSzBig[1]);
                                        for (int j = 0; j < length - 1; j++)
                                        {
                                            tempLiushui += "0";
                                        }
                                        tempLiushui += "1";
                                        liuShui1 += tempLiushui;
                                    }
                                    //第二个流水号
                                    if (!string.IsNullOrEmpty(issueSzBig[2]))
                                    {
                                        string tempLiushui = "";
                                        int length = int.Parse(issueSzBig[2]);
                                        for (int j = 0; j < length - 1; j++)
                                        {
                                            tempLiushui += "0";
                                        }
                                        tempLiushui += "1";
                                        liuShui2 += tempLiushui;
                                    }
                                }
                                else
                                {
                                    liuShui1 = Convert.ToString(int.Parse(issue.Substring(tempResult.Length, int.Parse(issueSzBig[1]))) + 1);
                                    for (int j = 0; j <= int.Parse(issueSzBig[1]) - liuShui1.Length; j++)
                                    {
                                        liuShui1 = "0" + liuShui1;
                                    }
                                }

                            }
                            mynewIssue = tempResult + liuShui1 + liuShui2;
                            ///////////更新期号(孟3-11)

                        }
                        else
                        {
                            if (TimeSpan.Parse(tmSZ[i + 1]) == TimeSpan.Parse("0:00"))
                            {
                                date = oldDate.AddDays(1).ToShortDateString() + " " + tmSZ[i + 1];
                            }
                            else
                            {
                                date = oldDate.ToShortDateString() + " " + tmSZ[i + 1];
                            }
                        }
                        break;
                    }
                }



            }
            return new string[] { mynewIssue, date };
        }



        //检查期号和奖号数据合法性
        private string[] CheckFormart(int currentRow, string issue, string code)
        {
            string[] result = new string[3];
            Pbzx.BLL.PBnet_LotteryMenu lotBLL = new Pbzx.BLL.PBnet_LotteryMenu();
            //PBnet_LotteryMenu表当前彩种信息
            DataSet ds = lotBLL.GetList(" NvarApp_name='" + ViewState["tableName"] + "' ");
            string errorMsg = "";//错误提示信息（例如期号长度不够）
            string isCF = "";//错误提示信息（例如期号是否重复）
            string resultCode = code;//格式化后的号码
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                string[] strInfoSZ = row["LottTypeInfo"].ToString().Split(new char[] { '|' });
                string[] codeInfoSZ = strInfoSZ[0].Split(new char[] { ',' });
                if (ViewState["tableName"].ToString() == "FC20X8Data_GuangD")// 广东快乐十分 
                {
                    if (issue.Length != guangdongIssue)//广东快乐十分期号长度
                    {
                        errorMsg += "期号错误：位数不符";
                    }
                    isCF = Method.showCheckStr(Method.FormartCode(code, " "), int.Parse(codeInfoSZ[3]));

                }
                if (ViewState["tableName"].ToString() == "FC27X7Data_XinJ")// 新疆喜乐彩 
                {
                    if (issue.Length != guangdongIssue)
                    {
                        errorMsg += "期号错误：位数不符";
                    }
                    //排序号码
                    resultCode = Method.OrderCode(Method.FormartCode(code, ""), "");
                }
                if (currentRow != -1)
                {
                    if (!string.IsNullOrEmpty(errorMsg))
                    {
                        errorMsg += "在第" + currentRow + "行，期号：" + issue + " 号码：" + code + "处.\\r\\n";
                    }
                    if (!string.IsNullOrEmpty(isCF))
                    {
                        isCF += "在第" + currentRow + "行，期号：" + issue + " 号码：" + code + "处.\\r\\n";
                    }
                }
                result[0] = errorMsg;
                result[1] = isCF;
                result[2] = resultCode;
            }
            return result;
        }

        protected void FCSSL_batchSave_code(string text)
        {
            bool isError = false;
            string strErrMsg = "";

            //过滤格式字符串start
            text = text.Replace(" ", "").Replace("\r\n", "+");
            string[] textTempSZ = text.Split(new char[] { '+' });
            string temp = "";
            for (int i = 0; i < textTempSZ.Length; i++)
            {
                if (!string.IsNullOrEmpty(textTempSZ[i]))
                {
                    temp += textTempSZ[i];
                    if (i < textTempSZ.Length - 1)
                    {
                        temp += "+";
                    }
                }
            }
            if (temp.Length > 0 && temp.Substring(temp.Length - 1) == "+")
            {
                temp = temp.Substring(0, temp.Length - 1);
            }
            string[] textSZ = temp.Split(new char[] { '+' });
            string issueCodeError = "";
            for (int i = 0; i < textSZ.Length; i++)
            {
                string qihao = "";
                string haoma = "";
                textSZ[i] = textSZ[i].Trim();
                if (ViewState["tableName"].ToString() == "FC27X7Data_XinJ")// 新疆喜乐彩 
                {
                    if (textSZ[i].Length < guangdongIssue)
                    {
                        issueCodeError += "期号错误：位数不符！在第" + (i + 1) + "行处.\\r\\n";
                        break;
                    }
                    qihao = textSZ[i].Substring(0, guangdongIssue);
                    //haoma = textSZ[i].Substring(guangdongIssue);
                    haoma = Method.OrderCode(Method.FormartCode(textSZ[i].Substring(guangdongIssue), ""), "");
                }
                //else if (ViewState["tableName"].ToString() == "FC21X5Data_GuangX")
                //{
                //    qihao = textSZ[i].Substring(0, guangxiIssue);
                //    haoma = textSZ[i].Substring(guangxiIssue);
                //}
                //else
                //{
                //    qihao = textSZ[i].Substring(0, otherIssue);
                //    haoma = textSZ[i].Substring(otherIssue);
                //}
                if (qihao.Substring(0, 1) == "0")
                {
                    qihao = qihao.Substring(1);
                }
                textSZ[i] = qihao + "&" + haoma;
            }

            if (!string.IsNullOrEmpty(issueCodeError))
            {
                issueCodeError = "您提交的信息中存在以下错误:\\r\\n\\r\\n" + issueCodeError + "\\r\\n请修改后再重新提交.";
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(issueCodeError));
                return;
            }

            //过滤格式字符串end


            SortedList sortCode = new SortedList();

            //查询最新Issue
            string sql = "select top 1 date,Issue from " + ViewState["tableName"] + " order by issue desc";
            DataRow row = basicDAL.GetRowBySql(sql);
            if (row == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert("数据访问出错！"));
                return;
            }
            string oldIssue = row["Issue"].ToString();
            string oldDate = row["date"].ToString();
            string[] newJHSJ = CalcNextDate(oldIssue, oldDate);
            string mynewIssue = newJHSJ[0];
            string mynewDate = newJHSJ[1];

            for (int i = 0; i < textSZ.Length; i++)
            {
                string[] codeSZ = textSZ[i].Trim().Split(new char[] { '&' });
                string code = codeSZ[1];
                string resultCode = code;
                if (codeSZ[1].Length != intCode)
                {
                    isError = true;
                    strErrMsg += "奖号错误：位数不符！在第" + (i + 1) + "行，期号：" + codeSZ[0] + " 号码：" + codeSZ[1] + "处.\\r\\n";
                    break;
                }
                else
                {
                    string[] result = CheckFormart(i + 1, codeSZ[0], codeSZ[1]);
                    if (result[0].Length > 0)
                    {
                        isError = true;
                        strErrMsg += result[0] + ".\\r\\n";
                        break;
                    }
                    if (result[1].Length > 0)
                    {
                        isError = true;
                        strErrMsg += result[1] + ".\\r\\n";
                        break;
                    }
                    else if (int.Parse(codeSZ[0]) <= int.Parse(oldIssue))
                    {
                        isError = true;
                        strErrMsg += "该期奖号已经存在！在第" + (i + 1) + "行，期号：" + codeSZ[0] + " 号码：" + codeSZ[1] + "处，应该录入期号为：" + mynewIssue + ".\\r\\n";
                        break;
                    }
                    try
                    {
                        resultCode = result[2];
                        sortCode.Add(codeSZ[0], resultCode);
                    }
                    catch (IndexOutOfRangeException ex1)
                    {
                        isError = true;
                        strErrMsg += "插入数据有误，数组索引越界.\\r\\n";
                        break;
                    }
                    catch (Exception ex)
                    {
                        isError = true;
                        strErrMsg += "插入了重复期号数据！在第" + (i + 1) + "行，期号：" + codeSZ[0] + " 号码：" + codeSZ[1] + "处.\\r\\n";
                        break;
                    }
                }
            }
            SortedList sortCode2 = sortCode.Clone() as SortedList;

            if (isError)
            {
                strErrMsg = "您提交的信息中存在以下错误:\\r\\n\\r\\n" + strErrMsg + "\\r\\n请修改后再重新提交.";
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                return;
            }

            ///如果期号不连续则停止
            IsContains(sortCode2, mynewIssue, mynewDate);
            if (!IsLianXu || !IsInsert)
            {
                return;
            }

            if (!string.IsNullOrEmpty(strErrMsg))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                return;
            }
            ///数据完整，执行事务
            using (SqlConnection conn = new SqlConnection(DbHelperSQL1.connectionString))
            {
                conn.Open();
                const string transName = "InsertFCSSL";
                SqlTransaction trans = conn.BeginTransaction(transName);
                try
                {
                    #region
                    foreach (DictionaryEntry entry in sortCode)
                    {

                        SqlParameter[] parmInsertOrderDetail =
                      {
                           new SqlParameter("@issue",entry.Key),
                           new SqlParameter("@date",mynewDate),
                           new SqlParameter("@Code",entry.Value),
                           new SqlParameter("@LastModifytime", DateTime.Now),
                           new SqlParameter("@OpIp",Request.UserHostAddress),
                           new SqlParameter("@OpName",WebFunc.GetCurrentAdmin())       
                       };
                        //" + ViewState["tableName"] + "
                        SQLHelper.ExecuteNonQuery(trans, CommandType.Text, " insert into " + ViewState["tableName"] + " (issue,[date],Code,LastModifytime,OpIp,OpName) values(@issue,@date,@Code,@LastModifytime,@OpIp,@OpName)", parmInsertOrderDetail);
                        ///插入一条数据后先计算出下一期得期号和时间
                        string[] tempQHSJ = CalcNextDate(mynewIssue, mynewDate);
                        mynewIssue = tempQHSJ[0];
                        mynewDate = tempQHSJ[1];
                    }
                    #endregion
                    //提交事务
                    trans.Commit();
                }
                catch
                {
                    //事务执行失败，回滚
                    trans.Rollback(transName);
                    conn.Close();
                    conn.Dispose();
                    ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert("数据插入失败，请与管理员联系！"));
                    return;
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }

            btnList_Click(new object(), new EventArgs());
        }


        protected void IsContains(SortedList sortCode, string myIssue, string myDate)
        {
            if (sortCode.ContainsKey(myIssue))
            {
                sortCode.Remove(myIssue);
                string[] tempJHSJ = CalcNextDate(myIssue, myDate);
                myIssue = tempJHSJ[0];
                myDate = tempJHSJ[1];
                IsContains(sortCode, myIssue, myDate);
                //if (DateTime.Parse(myDate) > DateTime.Now)
                //{
                //    string strErrMsg = "您提交的信息中存在以下错误:\\r\\n\\r\\n最新数据已经录入，请到下期开奖日再来录入新的数据！\\r\\n请修改后再重新提交.";
                //    ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                //    IsInsert = false;
                //}
            }
            else
            {
                if (sortCode.Count > 0)
                {
                    string strErrMsg = " 期号不连续！，缺少的期号为：" + myIssue + "，请添加此期号后继续！\\r\\n";
                    ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                    IsLianXu = false;
                }
                else
                {
                    IsLianXu = true;
                }
            }
        }
        #endregion


        /// <summary>
        /// 搜索录入 数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Search_Click(object sender, EventArgs e)
        {
            
            //判断是否搜索的数据
            if (txt_Condition.Text.Trim() != "" && txt_Condition.Text.Trim() != null)
            {
                ////判断长度
                //string charSatr = txt_Condition.Text.ToString().Trim().Substring(txt_Condition.Text.Trim().Length - 1, 1);
                string sql = "";
                //if (charSatr == "%")
                //{
                //    sql = "select top 120 * from " + ViewState["tableName"] + " where issue like " + "'" + txt_Condition.Text.ToString().Trim() + "'" + " order by issue desc";
                //}
                //else
                //{
                //    sql = "select top 120 * from " + ViewState["tableName"] + " where issue=" + "'" + txt_Condition.Text.ToString().Trim() +"'" + " order by issue desc";
                //}
                sql = "select top 120 * from " + ViewState["tableName"] + " where issue like " + "'" + txt_Condition.Text.ToString().Trim() + "%" + "'" + " order by issue desc";

                DataTable dt = basicDAL.GetLisBySql(sql);
                if (dt.Rows.Count > 0)
                {
                    this.lblIssue.Text = dt.Rows[0]["Issue"].ToString();
                    this.lblIssue1.Text = dt.Rows[0]["Issue"].ToString();
                    this.lblCode.Text = dt.Rows[0]["Code"].ToString();
                    this.MyGridView.DataSource = dt;
                    this.MyGridView.DataBind();
                }
                else
                {
                    this.MyGridView.DataSource = dt;
                    this.MyGridView.DataBind();
                }
                ViewState["hide"] = "0";
            }
           
        }
    }
}