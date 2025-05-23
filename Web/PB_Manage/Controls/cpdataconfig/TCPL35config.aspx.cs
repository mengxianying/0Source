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
using System.IO;
using System.Net;

namespace Pbzx.Web.PB_Manage.Controls.cpdataconfig
{
    public partial class TCPL35config : AdminBasic
    {
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic();
        protected void Page_Load(object sender, EventArgs e)
        {
            basicDAL.IsCst = true;
            if (!Page.IsPostBack)
            {

                BindData();
            }
            Pbzx.BLL.PBnet_LotteryMenu lotBLL = new Pbzx.BLL.PBnet_LotteryMenu();
            DataSet ds = lotBLL.GetList(" NvarApp_name='TCPL35Data' ");
            txtIssue.MaxLength = Convert.ToInt32(ds.Tables[0].Rows[0]["IssueLen"]);
            this.lblLinkAdd.Text = WebFunc.GetInfo("TCPL35Data");   
        }
        protected void BindData()
        {
            string sql = "select top 15 * from TCPL35Data order by issue desc";
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
                this.btnSave.Text = "���";
            }
            else
            {
                DataRow row = basicDAL.GetRowBySql("select * from TCPL35Data where issue='" + ViewState["hide"] + "'");
                FC7LC_add_code_main(true, row["date"], row["issue"]);
                this.txtIssue.Enabled = false;
                this.txtDate.Enabled = false;
                this.btnSave.Text = "�޸�";
            }
        }

        protected void FC7LC_add_code_main(object bModify, object sdate, object sissue)
        {
            string machine, ball, testcode, code3, code5;
            if (bool.Parse(bModify.ToString()) == false)
            {
                string sql = "select top 1 * from TCPL35Data order by issue desc";
                DataTable dt = basicDAL.GetLisBySql(sql);
                int tempInt = int.Parse(dt.Rows[0]["issue"].ToString()) + 1;
                sissue = tempInt.ToString();
                sdate = DateTime.Parse(dt.Rows[0]["date"].ToString()).AddDays(1).ToShortDateString();

                //�ж��Ƿ�������ʱ��֮��start(��2010-02-23)
                if (WebInit.webBaseConfig.YearStart != "" && WebInit.webBaseConfig.YearEnd != "")
                {
                    if (Convert.ToDateTime(sdate) >= DateTime.Parse(WebInit.webBaseConfig.YearStart) && Convert.ToDateTime(sdate) <= DateTime.Parse(WebInit.webBaseConfig.YearEnd))
                    {
                        sdate = DateTime.Parse(WebInit.webBaseConfig.YearEnd).AddDays(1).ToShortDateString();//��һ�ڿ�ʼʱ�� 
                    }
                }
                //�ж��Ƿ�������ʱ��֮��end(��2010-02-23)





                if (DateTime.Parse(sdate.ToString()) > DateTime.Now)
                {
                    Response.Write("<script>alert('���������Ѿ�¼�룬�뵽���ڿ���������¼���µ����ݣ�');history.go(-1);</script>");
                    Response.End();
                    //btnClear_Click(new object(), new EventArgs());
                    return;
                }
                //���괦�� 
                if (DateTime.Parse(sdate.ToString()).Year.ToString() != sissue.ToString().Substring(0, 4))
                {
                    sissue = DateTime.Now.Year + "001";
                }
                machine = "0";
		        ball = "0";
		        testcode = "";
		        code3 = "";
                code5 = "";
                ViewState["hide"] = "0";
                this.btnSave.Text = "���";
            }
            else
            {
                
                string sql = "select * from TCPL35Data where issue='" + sissue + "'";
                DataTable dt = basicDAL.GetLisBySql(sql);
                sdate = dt.Rows[0]["date"];
                sissue = dt.Rows[0]["issue"];
                machine = dt.Rows[0]["machine"].ToString();
                ball = dt.Rows[0]["ball"].ToString();
                testcode = dt.Rows[0]["testcode"].ToString();
		        code3 = dt.Rows[0]["code3"].ToString();
		        code5 = dt.Rows[0]["code5"].ToString();
                ViewState["hide"] = sissue;
                this.btnSave.Text = "�޸�";
            }

            this.txtIssue.Text = sissue.ToString();
            this.txtCode1.Text = code5;

            //�ں�
            this.lblIssue.Text = "��ʽ��" + sissue;
            this.txtDate.Text = Convert.ToDateTime(sdate).ToShortDateString();

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.TCPL35Data FC7LCBLL = new Pbzx.BLL.TCPL35Data();
            string WapUDS = System.Configuration.ConfigurationManager.AppSettings["UDS"];
            string WapPDS = System.Configuration.ConfigurationManager.AppSettings["PDS"];
            string strErrMsg = "";
            if (this.txtCode1.Text.Length < 5)
            {
                strErrMsg += "�������벻����.\\r\\n";
            }

            DateTime now = DateTime.Now;
            if (!DateTime.TryParse(this.txtDate.Text, out now))
            {
                strErrMsg += "�������ڸ�ʽ����ȷ.\\r\\n";
            }


            if (!OperateText.IsNumber(this.txtCode1.Text))
            {
                strErrMsg += "�����ʽ���벻��ȷ.\\r\\n";
            }

            if (strErrMsg != "")
            {
                strErrMsg = "���ύ����Ϣ�д������´���:\\r\\n\\r\\n" + strErrMsg + "\\r\\n���޸ĺ��������ύ.";
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                return;
            }
            else
            {
                Pbzx.Model.TCPL35Data FC7LCModel;
                if (ViewState["hide"].ToString() == "0")
                {
                    FC7LCModel = new Pbzx.Model.TCPL35Data();
                }
                else
                {
                    FC7LCModel = FC7LCBLL.GetModel(ViewState["hide"].ToString());
                }
                FC7LCModel.date = DateTime.Parse(this.txtDate.Text);
                FC7LCModel.issue = this.txtIssue.Text;
                FC7LCModel.code5 = this.txtCode1.Text;
                FC7LCModel.code3 = this.txtCode1.Text.Substring(0, 3);
                FC7LCModel.machine = 0;
                FC7LCModel.ball = 0;
                FC7LCModel.testcode = "0";
                FC7LCModel.LastModifyTime = DateTime.Now;
                FC7LCModel.OpIp = Request.UserHostAddress; ;
                FC7LCModel.OpName = WebFunc.GetCurrentAdmin();
                if (ViewState["hide"].ToString() == "0")
                {
                    FC7LCBLL.Add(FC7LCModel);                   
                }
                else
                {
                    FC7LCBLL.Update(FC7LCModel);                    
                }
                Application["TCPL35Data"] = "false";
                if (!string.IsNullOrEmpty(WapUDS) && !string.IsNullOrEmpty(WapUDS))
                {
                    WebRequest.Create("http://wap.pinble.com/ApplicationInspect.aspx?UDS=" + WapUDS + "&PDS=" + WapPDS + "&cpname=WeiXin_MoNiTestCode");
                    WebRequest.Create("http://wap.pinble.com/ApplicationInspect.aspx?UDS=" + WapUDS + "&PDS=" + WapPDS + "&cpname=TCPL35Data");
                }
            }
            ViewState["hide"] = "0";
            btnList_Click(new object(), new EventArgs());
            //Server.Execute("/PB_Manage/RefurbishCpXml.aspx?cpType=TCPL35Data");
        }

        protected void FC7LC_del_code()
        {
            string WapUDS = System.Configuration.ConfigurationManager.AppSettings["UDS"];
            string WapPDS = System.Configuration.ConfigurationManager.AppSettings["PDS"];
            string sql = "";
            //�ж��Ƿ�����������
            if (txt_Condition.Text.Trim() != "" && txt_Condition.Text.Trim() != null)
            {
                string charSatr = txt_Condition.Text.Trim().ToString().Substring(txt_Condition.Text.Trim().Length - 1, 1);
                if (charSatr == "%")
                {
                    sql = "select top 1 * from TCPL35Data where issue like " + "'" + txt_Condition.Text.Trim().ToString() + "'" + " order by issue desc";
                }
                else
                {
                    sql = "select top 1 * from TCPL35Data where issue=" + "'" + txt_Condition.Text.Trim().ToString() + "'" + " order by issue desc";
                }
            }
            else
            {
                sql = "select top 1 * from TCPL35Data order by issue desc";
            }
            DataRow row = basicDAL.GetRowBySql(sql);
            if (row == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "error", JS.Alert("û�п�ɾ���Ŀ�����Ϣ!"));
                return;
            }
            TimeSpan ts = DateTime.Now - DateTime.Parse(row["date"].ToString());
            if (ts.Days > 2)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "error1", JS.Alert("��ֻ��ɾ���������Ŀ�����Ϣ"));
                return;
            }
            if (basicDAL.ExecuteSql("delete TCPL35Data  where issue='" + row["issue"] + "'") > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "error2", JS.Alert("ɾ�����������Ϣ�ɹ���"));
                Application["TCPL35Data"] = "false";
                if (!string.IsNullOrEmpty(WapUDS) && !string.IsNullOrEmpty(WapUDS))
                {
                    WebRequest.Create("http://wap.pinble.com/ApplicationInspect.aspx?UDS=" + WapUDS + "&PDS=" + WapPDS + "&cpname=WeiXin_MoNiTestCode");
                    WebRequest.Create("http://wap.pinble.com/ApplicationInspect.aspx?UDS=" + WapUDS + "&PDS=" + WapPDS + "&cpname=TCPL35Data");
                }
            }
            ViewState["hide"] = "0";
            //Server.Execute("/PB_Manage/RefurbishCpXml.aspx?cpType=TCPL35Data");
        }

        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {
            string strIssue = e.CommandArgument.ToString();
            this.hfNewsID.Value = strIssue;
            ViewState["hide"] = strIssue;
            btnDivAdd_Click(new object(), new EventArgs());
        }

        //��ʽ��IP��ַ
        protected string GetIp(object ip)
        {
            Pbzx.BLL.PBnet_ipdata ipBLL = new Pbzx.BLL.PBnet_ipdata();
            return ipBLL.S_getIPaddress(ip.ToString());
        }

        //���б���ʾ
        protected void btnList_Click(object sender, EventArgs e)
        {
            BindData();
            this.divAdd.Visible = false;
            this.divList.Visible = true;
            txt_Condition.Text = "";
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            FC7LC_del_code();                     
        }

        //�������ʾ
        protected void btnDivAdd_Click(object sender, EventArgs e)
        {
            BindDivAdd();
            this.divList.Visible = false;
            this.divAdd.Visible = true;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            BindData();
            this.divAdd.Visible = false;
            this.divList.Visible = true;
        }


        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Search_Click(object sender, EventArgs e)
        {
            if (txt_Condition.Text.Trim() != "" && txt_Condition.Text.Trim() != null)
            {
                ////�жϳ���
                //string charSatr = txt_Condition.Text.Trim().ToString().Substring(txt_Condition.Text.Trim().Length - 1, 1);
                string sql = "";
                //if (charSatr == "%")
                //{
                //    sql = "select top 120 * from TCPL35Data where issue like " + "'" + txt_Condition.Text.Trim().ToString() + "'" + " order by issue desc";
                //}
                //else
                //{
                //    sql = "select top 120 * from TCPL35Data where issue=" + "'" + txt_Condition.Text.Trim().ToString() + "'" + " order by issue desc";
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
