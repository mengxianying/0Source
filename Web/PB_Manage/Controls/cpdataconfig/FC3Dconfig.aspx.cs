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
using Maticsoft.DBUtility;
using System.Xml;
using System.IO;
using System.Net;

namespace Pbzx.Web.PB_Manage.Controls.cpdataconfig
{
    public partial class FC3Dconfig : AdminBasic
    {
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic();
        protected void Page_Load(object sender, EventArgs e)
        {
            basicDAL.IsCst = true;
            if (!Page.IsPostBack)
            {
                Pbzx.BLL.PBnet_LotteryMenu lotBLL = new Pbzx.BLL.PBnet_LotteryMenu();
                DataSet ds = lotBLL.GetList(" NvarApp_name='FC3DData' ");
                txtIssue.MaxLength = Convert.ToInt32(ds.Tables[0].Rows[0]["IssueLen"]);
                BindData();
                this.lblLinkAdd.Text = WebFunc.GetInfo("FC3DData");
            }
        }
        protected void BindData()
        {
            string sql = "select top 15 * from FC3DData order by issue desc";
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
                this.txtIssue.Enabled = true;
                this.txtDate.Enabled = true;
                this.btnSave.Text = "添加";
            }
            else
            {
                DataRow row = basicDAL.GetRowBySql("select * from FC3DData where issue='" + ViewState["hide"] + "'");
                FC7LC_add_code_main(true, row["date"], row["issue"]);
                this.txtIssue.Enabled = false;
                this.txtDate.Enabled = false;
                this.btnSave.Text = "修改";
            }
        }

        protected void FC7LC_add_code_main(object bModify, object sdate, object sissue)
        {
            string machine = "1", ball = "1", testcode, code;

            if (bool.Parse(bModify.ToString()) == false)
            {
                string sql = "select top 1 * from FC3DData order by issue desc";
                DataTable dt = basicDAL.GetLisBySql(sql);

                int tempInt = int.Parse(dt.Rows[0]["issue"].ToString()) + 1;
                sissue = tempInt.ToString();

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
                    Response.Write("<script>alert('最新数据已经录入，请到下期开奖日再来录入新的数据！');history.go(-1);</script>");
                    Response.End();
                    //btnClear_Click(new object(), new EventArgs());
                    return;
                }
                //跨年处理 
                if (DateTime.Parse(sdate.ToString()).Year.ToString() != sissue.ToString().Substring(0, 4))
                {
                    sissue = DateTime.Now.Year + "001";
                }
                machine = "1";
                ball = "1";
                testcode = "";
                code = "";
                ViewState["hide"] = "0";
                this.btnSave.Text = "添加";
            }
            else
            {
                string sql = "select * from FC3DData where issue='" + sissue + "'";
                DataTable dt = basicDAL.GetLisBySql(sql);
                sdate = dt.Rows[0]["date"];
                sissue = dt.Rows[0]["issue"];
                machine = dt.Rows[0]["machine"].ToString();
                ball = dt.Rows[0]["ball"].ToString();
                testcode = dt.Rows[0]["testcode"].ToString();
                code = dt.Rows[0]["code"].ToString();
                ViewState["hide"] = sissue;
                this.btnSave.Text = "修改";
            }
            this.txtDate.Text = DateTime.Parse(sdate.ToString()).ToShortDateString();
            this.txtIssue.Text = sissue.ToString();

            //this.ddlMachine.SelectedValue = machine;
            //this.ddlBall.SelectedValue = ball;

            this.rblMachineAndBall.SelectedValue = machine + "-" + ball;

            this.txtTestcode.Text = testcode;
            this.txtCode.Text = code;
        }

        /// <summary>
        /// 点击修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {

            Pbzx.BLL.FC3DData FC7LCBLL = new Pbzx.BLL.FC3DData();
            string WapUDS = System.Configuration.ConfigurationManager.AppSettings["UDS"];
            string WapPDS = System.Configuration.ConfigurationManager.AppSettings["PDS"];
            string strErrMsg = "";
            if (this.txtTestcode.Text.Length < 3)
            {
                strErrMsg += "试机号输入不完整.\\r\\n";
            }
            if (!string.IsNullOrEmpty(this.txtCode.Text))
            {
                if (this.txtCode.Text.Length != 3)
                {
                    strErrMsg += "开奖号码位数不对";
                }
            }

            DateTime now = DateTime.Now;
            if (!DateTime.TryParse(this.txtDate.Text, out now))
            {
                strErrMsg += "开奖日期格式不正确.\\r\\n";
            }

            string code = this.txtCode.Text;

            if (strErrMsg != "")
            {
                strErrMsg = "您提交的信息中存在以下错误:\\r\\n\\r\\n" + strErrMsg + "\\r\\n请修改后再重新提交.";
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                return;
            }
            else
            {
                Pbzx.Model.FC3DData FC7LCModel;
                if (ViewState["hide"].ToString() == "0")
                {
                    FC7LCModel = new Pbzx.Model.FC3DData();
                }
                else
                {
                    FC7LCModel = FC7LCBLL.GetModel(ViewState["hide"].ToString());
                }
                FC7LCModel.date = DateTime.Parse(this.txtDate.Text);
                FC7LCModel.issue = this.txtIssue.Text;
                //  string[] mAndB = this.rblMachineAndBall.SelectedValue.Split(new char[] { '-' });
                //   FC7LCModel.machine = int.Parse(mAndB[0]);
                //   FC7LCModel.ball = int.Parse(mAndB[1]);
                FC7LCModel.code = this.txtCode.Text;
                FC7LCModel.testcode = this.txtTestcode.Text;
                FC7LCModel.LastModifyTime = DateTime.Now;
                FC7LCModel.OpIp = Request.UserHostAddress; ;
                FC7LCModel.OpName = WebFunc.GetCurrentAdmin();
                if (ViewState["hide"].ToString() == "0")
                {
                    string[] tsCodeDe = WebFunc.CalGZM(this.txtTestcode.Text);
                    FC7LCModel.AttentionCode = tsCodeDe[0] + tsCodeDe[1] + tsCodeDe[2];
                    FC7LCModel.decode = tsCodeDe[3];
                    if (FC7LCBLL.Add(FC7LCModel))
                    {
                        if (string.IsNullOrEmpty(this.txtCode.Text))
                        {
                            //Pbzx.Common.MyXML xml = new Pbzx.Common.MyXML("\\xml\\QuanGuoCpDate.xml");
                            //XmlNode root = xml.GetXmlRoot();
                            //XmlNode _3DTest = root.SelectSingleNode("/CpDate/_3DTest");
                            //xml.SetAttribute("/CpDate/_3DTest", "date", FC7LCModel.date.ToShortDateString() + " 18:30");
                        }
                        else
                        {
                            try
                            {
                                Files.Create("/pb_cst.htm", "/Template/Fc3DGZM.aspx");
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                        ViewState["hide"] = "0";
                        btnClear_Click(new object(), new EventArgs());
                        Application["FC3DData"] = "false";
                        if (!string.IsNullOrEmpty(WapUDS) && !string.IsNullOrEmpty(WapUDS))
		                {
                            WebRequest.Create("http://wap.pinble.com/ApplicationInspect.aspx?UDS=" + WapUDS + "&PDS=" + WapPDS + "&cpname=FC3DData");
//                            WebResponse response = request.GetResponse();  
		                }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "error", JS.Alert("添加失败!"));
                        return;
                    }
                }
                else
                {
                    //string[] tsCodeDe = WebFunc.CalGZM(this.txtTestcode.Text);
                    //FC7LCModel.AttentionCode = tsCodeDe[0] + tsCodeDe[1] + tsCodeDe[2];
                    //FC7LCModel.decode = tsCodeDe[3];
                    if (FC7LCBLL.Update(FC7LCModel))
                    {
                        if (string.IsNullOrEmpty(this.txtCode.Text))
                        {
                            //Pbzx.Common.MyXML xml = new Pbzx.Common.MyXML("\\xml\\QuanGuoCpDate.xml");
                            //XmlNode root = xml.GetXmlRoot();
                            //XmlNode _3DTest = root.SelectSingleNode("/CpDate/_3DTest");
                            //xml.SetAttribute("/CpDate/_3DTest", "date", FC7LCModel.date.ToShortDateString() + " 18:30");
                        }
                        else
                        {
                            try
                            {
                                Files.Create("/pb_cst.htm", "/Template/Fc3DGZM.aspx");
                            }
                            catch (Exception ex)
                            { }
                        }
                        ViewState["hide"] = "0";
                        btnClear_Click(new object(), new EventArgs());
                        Application["FC3DData"] = "false";
                        if (!string.IsNullOrEmpty(WapUDS) && !string.IsNullOrEmpty(WapUDS))
                        {
                            WebRequest.Create("http://wap.pinble.com/ApplicationInspect.aspx?UDS=" + WapUDS + "&PDS=" + WapPDS + "&cpname=FC3DData");
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "error", JS.Alert("更新失败!"));
                        return;
                    }
                }
            }
            // string[] result = WebFunc.CalGZM();
            // DbHelperSQL1.ExecuteSql("update FC3DData set AttentionCode='" + result[0] + result[1] + result[2] + "' where issue='"+this.txtIssue.Text.Trim()+"' ");
            //Server.Execute("/PB_Manage/RefurbishCpXml.aspx?cpType=FC3DData");           

        }

        protected void FC7LC_del_code()
        {
            string sql = "";
            string WapUDS = System.Configuration.ConfigurationManager.AppSettings["UDS"];
            string WapPDS = System.Configuration.ConfigurationManager.AppSettings["PDS"];
            //判断是否搜索的数据
            if (txt_Condition.Text.Trim() != "" && txt_Condition.Text.Trim() != null)
            {
                string charSatr = txt_Condition.Text.ToString().Trim().Substring(txt_Condition.Text.Trim().Length - 1, 1);
                if (charSatr == "%")
                {
                    sql = "select top 1 * from FC3DData where issue like " + "'" + txt_Condition.Text.ToString().Trim() + "'" + " order by issue desc";
                }
                else
                {
                    sql = "select top 1 * from FC3DData where issue=" + "'" + txt_Condition.Text.ToString().Trim() + "'" + " order by issue desc";
                }
            }
            else
            {
                sql = "select top 1 * from FC3DData order by issue desc";
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
            if (basicDAL.ExecuteSql("delete FC3DData  where issue='" + row["issue"] + "'") > 0)
            {
                if (!string.IsNullOrEmpty(WapUDS) && !string.IsNullOrEmpty(WapUDS))
                {
                    WebRequest.Create("http://wap.pinble.com/ApplicationInspect.aspx?UDS=" + WapUDS + "&PDS=" + WapPDS + "&cpname=FC3DData");
                }
                Application["FC3DData"] = "false";
                ClientScript.RegisterStartupScript(this.GetType(), "error2", JS.Alert("删除最近开奖信息成功！"));
                Files.Create("/pb_cst.htm", "/Template/Fc3DGZM.aspx");
            }
            ViewState["hide"] = "0";
        }

        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {
            string strIssue = e.CommandArgument.ToString();
            ViewState["hide"] = strIssue;
            btnDivAdd_Click(new object(), new EventArgs());
        }



        //格式化IP地址
        protected string GetIp(object ip)
        {
            Pbzx.BLL.PBnet_ipdata ipBLL = new Pbzx.BLL.PBnet_ipdata();
            return ipBLL.S_getIPaddress(ip.ToString());
        }
        protected void btnDel_Click(object sender, EventArgs e)
        {
            FC7LC_del_code();
            //Server.Execute("/PB_Manage/RefurbishCpXml.aspx?cpType=FC3DData");
        }

        //让添加显示
        protected void btnDivAdd_Click(object sender, EventArgs e)
        {
            //string machine = "1", ball = "1", testcode = "", code = "", sissue = "", sdate="";

            //if (bool.Parse(bModify.ToString()) == false)
            //{
            //    string sql = "select top 1 * from FC3DData order by issue desc";
            //    DataTable dt = basicDAL.GetLisBySql(sql);
            //    int tempInt = int.Parse(dt.Rows[0]["issue"].ToString()) + 1;
            //    sissue = tempInt.ToString();
            //    sdate = DateTime.Parse(dt.Rows[0]["date"].ToString()).AddDays(1).ToShortDateString();

            //    if (DateTime.Parse(sdate.ToString()) > DateTime.Now)
            //    {
            //        ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("最新数据已经录入，请到下期开奖日再来录入新的数据！"));
            //        return;
            //    }
            //    //跨年处理 
            //    if (DateTime.Parse(sdate.ToString()).Year.ToString() != sissue.ToString().Substring(0, 4))
            //    {
            //        sissue = DateTime.Now.Year + "001";
            //    }
            //    machine = "1";
            //    ball = "1";
            //    testcode = "";
            //    code = "";
            //    ViewState["hide"] = "0";
            //    this.btnSave.Text = "添加";
            //}

            BindDivAdd();
            this.divList.Visible = false;
            this.divAdd.Visible = true;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            BindData();
            this.divAdd.Visible = false;
            this.divList.Visible = true;
            txt_Condition.Text = "";
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
                //    sql = "select top 120 * from FC3DData where issue like " + "'" + txt_Condition.Text.ToString().Trim() + "'" + " order by issue desc";
                //}
                //else
                //{
                //    sql = "select top 120 * from FC3DData where issue=" + "'" + txt_Condition.Text.ToString().Trim() + "'" + " order by issue desc";
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
