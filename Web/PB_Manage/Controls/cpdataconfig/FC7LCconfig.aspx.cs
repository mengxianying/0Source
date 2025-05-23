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
    public partial class FC7LCconfig : AdminBasic
    {
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic();
        protected void Page_Load(object sender, EventArgs e)
        {
            basicDAL.IsCst = true;
            if (!Page.IsPostBack)
            {
                Pbzx.BLL.PBnet_LotteryMenu lotBLL = new Pbzx.BLL.PBnet_LotteryMenu();
                DataSet ds = lotBLL.GetList(" NvarApp_name='FC7LC' ");
                txtIssue.MaxLength = Convert.ToInt32(ds.Tables[0].Rows[0]["IssueLen"]);
                BindData();
                this.lblLinkAdd.Text = WebFunc.GetInfo("FC7LC");    
            }
        }
        protected void BindData()
        {
            string sql = "select top 15 * from FC7LC order by issue desc";
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
                DataRow row = basicDAL.GetRowBySql("select * from FC7LC where issue='" + ViewState["hide"] + "'");
                FC7LC_add_code_main(true, row["date"], row["issue"]);
                this.txtIssue.Enabled = false;
                this.txtDate.Enabled = false;
                this.btnSave.Text = "�޸�";
            }
        }

        protected void FC7LC_add_code_main(object bModify, object sdate, object sissue)
        {
            string code1, code2, code3, code4, code5, code6, code7, Tcode;
            if (bool.Parse(bModify.ToString()) == false)
            {
                string sql = "select top 1 * from FC7LC order by issue desc";
                DataTable dt = basicDAL.GetLisBySql(sql);
                int tempInt = int.Parse(dt.Rows[0]["issue"].ToString()) + 1;
                sissue = tempInt.ToString();
                sdate = DateTime.Parse(dt.Rows[0]["date"].ToString()).ToShortDateString();

                //���ֲʿ���Ϊ��ÿ��һ������������
                switch (((int)DateTime.Parse(sdate.ToString()).DayOfWeek) + 1)
                {
                    //����һ����
                    case 2:
                        sdate = DateTime.Parse(sdate.ToString()).AddDays(2).ToShortDateString();
                        break;
                    //������
                    case 4:
                        sdate = DateTime.Parse(sdate.ToString()).AddDays(2).ToShortDateString();
                        break;
                    //������
                    case 6:
                        sdate = DateTime.Parse(sdate.ToString()).AddDays(3).ToShortDateString();
                        break;
                    //����һ����
                    case 7:
                        sdate = DateTime.Parse(sdate.ToString()).AddDays(3).ToShortDateString();//�¸�����һ
                        break;
                }

                //�ж��Ƿ�������ʱ��֮��start(��2010-02-23)
                bool isInXS = false;               
                if (WebInit.webBaseConfig.YearStart != "" && WebInit.webBaseConfig.YearEnd != "")
                {
                    if (Convert.ToDateTime(sdate) >= DateTime.Parse(WebInit.webBaseConfig.YearStart) && Convert.ToDateTime(sdate) <= DateTime.Parse(WebInit.webBaseConfig.YearEnd))
                    {
                        sdate = DateTime.Parse(WebInit.webBaseConfig.YearEnd).ToShortDateString();//��һ�ڿ�ʼʱ�� 
                        isInXS = true;
                    }
                }               
                if (isInXS)
                {
                    string[] checkResult = WebFunc.GetYearEndDate(Convert.ToDateTime(sdate), "246");
                    if (checkResult[0] == "true")
                    {
                        //���ֲʿ���Ϊ��ÿ��һ������������
                        switch (((int)DateTime.Parse(sdate.ToString()).DayOfWeek) + 1)
                        {
                            //����һ����
                            case 2:
                                sdate = DateTime.Parse(sdate.ToString()).AddDays(2).ToShortDateString();
                                break;
                            //������
                            case 4:
                                sdate = DateTime.Parse(sdate.ToString()).AddDays(2).ToShortDateString();
                                break;
                            //������
                            case 6:
                                sdate = DateTime.Parse(sdate.ToString()).AddDays(3).ToShortDateString();
                                break;
                        }
                    }
                    else
                    {
                        sdate = checkResult[1];
                    }
                } 
                //�ж��Ƿ�������ʱ��֮��end(��2010-02-23)

                if (DateTime.Parse(sdate.ToString()) > DateTime.Now)
                {

                    if (DateTime.Parse(sdate.ToString()) > DateTime.Now)
                    {
                        Response.Write("<script>alert('���������Ѿ�¼�룬�뵽���ڿ���������¼���µ����ݣ�');history.go(-1);</script>");
                        Response.End();
                        //btnClear_Click(new object(), new EventArgs());
                        return;
                    }
                }
                //���괦�� 
                if (DateTime.Parse(sdate.ToString()).Year.ToString() != sissue.ToString().Substring(0, 4))
                {
                    sissue = DateTime.Now.Year + "001";
                }
		        code1 = "";
		        code2 = "";
		        code3 = "";
		        code4 = "";
		        code5 = "";
		        code6 = "";
		        code7 = "";
                Tcode = "";
                ViewState["hide"] = "0";
                this.btnSave.Text = "���";
            }
            else
            {
                string code = "";
                string sql = "select * from FC7LC where issue='" + sissue + "'";
                DataTable dt = basicDAL.GetLisBySql(sql);
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
                Tcode = dt.Rows[0]["Tcode"].ToString();

                ViewState["hide"] = sissue;
                this.btnSave.Text = "�޸�";
            }
            this.txtDate.Text = DateTime.Parse(sdate.ToString()).ToShortDateString();
            this.txtIssue.Text = sissue.ToString();
            this.txtCode1.Text = code1;
            this.txtCode2.Text = code2;
            this.txtCode3.Text = code3;
            this.txtCode4.Text = code4;
            this.txtCode5.Text = code5;
            this.txtCode6.Text = code6;
            this.txtCode7.Text = code7;
            this.txtTcode.Text = Tcode;           
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.FC7LC FC7LCBLL = new Pbzx.BLL.FC7LC();
            string WapUDS = System.Configuration.ConfigurationManager.AppSettings["UDS"];
            string WapPDS = System.Configuration.ConfigurationManager.AppSettings["PDS"];
            string strErrMsg = "";
            if (this.txtCode1.Text.Length != 2 || this.txtCode2.Text.Length != 2 || this.txtCode3.Text.Length != 2 || this.txtCode4.Text.Length != 2 || this.txtCode5.Text.Length != 2 || this.txtCode6.Text.Length != 2 || this.txtCode7.Text.Length != 2)
            {
                strErrMsg += "�����������벻�������밴���ұ߸�ʽ����.\\r\\n";
                return;
            }
            if(this.txtTcode.Text.Length != 2)
            {
                strErrMsg += "�ر�������벻�������밴���ұ߸�ʽ����.\\r\\n";
            }

            DateTime now = DateTime.Now;
            if (!DateTime.TryParse(this.txtDate.Text, out now))
            {
                strErrMsg += "�������ڸ�ʽ����ȷ.\\r\\n";
            }

            if (strErrMsg != "")
            {
                strErrMsg = "���ύ����Ϣ�д������´���:\\r\\n\\r\\n" + strErrMsg + "\\r\\n���޸ĺ��������ύ.";
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                return;
            }

            string code = this.txtCode1.Text + this.txtCode2.Text + this.txtCode3.Text + this.txtCode4.Text + this.txtCode5.Text + this.txtCode6.Text + this.txtCode7.Text;
            string tempCode = code + this.txtTcode.Text;
            string isCF = Method.showCheckStr(Method.FormartCode(tempCode,""),30);
            if(isCF.Length > 0)
            {
                strErrMsg += isCF + ".\\r\\n";
            }
            if (strErrMsg != "")
            {
                strErrMsg = "���ύ����Ϣ�д������´���:\\r\\n\\r\\n" + strErrMsg + "\\r\\n���޸ĺ��������ύ.";
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                return;
            }
            else
            {
                Pbzx.Model.FC7LC FC7LCModel;
                if (ViewState["hide"].ToString() == "0")
                {
                    FC7LCModel = new Pbzx.Model.FC7LC();                    
                }
                else
                {
                    FC7LCModel = FC7LCBLL.GetModel(ViewState["hide"].ToString());
                }
                FC7LCModel.code = Method.OrderCode(Method.FormartCode(code,""),"");
                FC7LCModel.tcode = this.txtTcode.Text;
                FC7LCModel.date = DateTime.Parse(this.txtDate.Text);
                FC7LCModel.issue = this.txtIssue.Text;
                FC7LCModel.LastModifytime = DateTime.Now;
                FC7LCModel.OpIp = Request.UserHostAddress; ;
                FC7LCModel.OpName = WebFunc.GetCurrentAdmin();
                if (ViewState["hide"].ToString() == "0")
                {
                    if (FC7LCBLL.Add(FC7LCModel))
                    {
                        ViewState["hide"] = "0";
                        btnList_Click(new object(), new EventArgs());
                        Application["FC7LC"] = "false";
                        if (!string.IsNullOrEmpty(WapUDS) && !string.IsNullOrEmpty(WapUDS))
                        {
                            WebRequest.Create("http://wap.pinble.com/ApplicationInspect.aspx?UDS=" + WapUDS + "&PDS=" + WapPDS + "&cpname=FC7LC");
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "error", JS.Alert("���ʧ��!"));
                        return;
                    }
                }
                else
                {
                    if (FC7LCBLL.Update(FC7LCModel))
                    {
                        ViewState["hide"] = "0";
                        btnList_Click(new object(), new EventArgs());
                        Application["FC7LC"] = "false";
                        if (!string.IsNullOrEmpty(WapUDS) && !string.IsNullOrEmpty(WapUDS))
                        {
                            WebRequest.Create("http://wap.pinble.com/ApplicationInspect.aspx?UDS=" + WapUDS + "&PDS=" + WapPDS + "&cpname=FC7LC");
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "error", JS.Alert("����ʧ��!"));
                        return;
                    }
                }            
            }
            //Server.Execute("/PB_Manage/RefurbishCpXml.aspx?cpType=FC7LC");
        }

        protected void FC7LC_del_code()
        {
            string WapUDS = System.Configuration.ConfigurationManager.AppSettings["UDS"];
            string WapPDS = System.Configuration.ConfigurationManager.AppSettings["PDS"];
            string sql = "";
            //�ж��Ƿ�����������
            if (txt_Condition.Text.Trim() != "" && txt_Condition.Text.Trim() != null)
            {
                string charSatr = txt_Condition.Text.ToString().Trim().Substring(txt_Condition.Text.Trim().Length - 1, 1);
                if (charSatr == "%")
                {
                    sql = "select top 1 * from FC7LC where issue like " + "'" + txt_Condition.Text.ToString().Trim() + "'" + " order by issue desc";
                }
                else
                {
                    sql = "select top 1 * from FC7LC where issue=" + "'" + txt_Condition.Text.ToString().Trim() + "'" + " order by issue desc";
                }
            }
            else
            {
                sql = "select top 1 * from FC7LC order by issue desc";
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
            if (basicDAL.ExecuteSql("delete FC7LC  where issue='" + row["issue"] + "'") > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "error2", JS.Alert("ɾ�����������Ϣ�ɹ���"));
                Application["FC7LC"] = "false";
                if (!string.IsNullOrEmpty(WapUDS) && !string.IsNullOrEmpty(WapUDS))
                {
                    WebRequest.Create("http://wap.pinble.com/ApplicationInspect.aspx?UDS=" + WapUDS + "&PDS=" + WapPDS + "&cpname=FC7LC");
                }
            }
            ViewState["hide"] = "0";
            //Server.Execute("/PB_Manage/RefurbishCpXml.aspx?cpType=FC7LC");
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
                //string charSatr = txt_Condition.Text.ToString().Trim().Substring(txt_Condition.Text.Trim().Length - 1, 1);
                string sql = "";
                //if (charSatr == "%")
                //{
                //    sql = "select top 120 * from FC7LC where issue like " + "'" + txt_Condition.Text.ToString().Trim() + "'" + " order by issue desc";
                //}
                //else
                //{
                //    sql = "select top 120 * from FC7LC where issue=" + "'" + txt_Condition.Text.ToString().Trim() + "'" + " order by issue desc";
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
