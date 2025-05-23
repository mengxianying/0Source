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
    public partial class FCSSLconfig : AdminBasic
    {
        bool IsLianXu = true;
        bool IsInsert = true;
        int intIssue = 10;//�ںų���
        int intCode = 3;//���볤��
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic();
        protected void Page_Load(object sender, EventArgs e)
        {
            basicDAL.IsCst = true;
            if (!Page.IsPostBack)
            {
                BindData();
            }
            Pbzx.BLL.PBnet_LotteryMenu lotBLL = new Pbzx.BLL.PBnet_LotteryMenu();
            DataSet ds = lotBLL.GetList(" NvarApp_name='FCSSLData_SH' ");
            txtIssue.MaxLength = Convert.ToInt32(ds.Tables[0].Rows[0]["IssueLen"]);
            intIssue = Convert.ToInt32(ds.Tables[0].Rows[0]["IssueLen"]);
            ViewState["tableName"] = "FCSSLData_SH";
            this.lblLinkAdd.Text = WebFunc.GetInfo("FCSSLData_SH");    
        }
        protected void BindData()
        {
            string sql = "select top 15 * from FCSSLData_SH order by issue desc";
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
                DataRow row = basicDAL.GetRowBySql("select * from FCSSLData_SH where issue='" + ViewState["hide"] + "'");
                FC7LC_add_code_main(true, row["date"], row["issue"]);
                this.txtIssue.Enabled = false;
                this.txtDate.Enabled = false;
                this.btnSave.Text = "�޸�";
            }
        }
        protected void BindDivBatch()
        {
            this.txtBatch.Text = "";
            ViewState["hide"] = "0";
        }

        protected void FC7LC_add_code_main(object bModify, object sdate, object sissue)
        {
            string code;

            if (bool.Parse(bModify.ToString()) == false)
            {
                string sql = "select top 1 * from FCSSLData_SH order by issue desc";
                DataTable dt = basicDAL.GetLisBySql(sql);
                sissue = dt.Rows[0]["issue"].ToString();
                sdate = DateTime.Parse(dt.Rows[0]["date"].ToString());

                if (!string.IsNullOrEmpty(sdate.ToString()))
                {
                    string[] tempSZ = CalcNexIssue(sissue.ToString(), sdate.ToString());
                    sissue = tempSZ[0];
                    sdate = tempSZ[1];
                }
                else
                {
                    sdate = "";
                }
                code = "";
                ViewState["hide"] = "0";
                this.btnSave.Text = "���";
            }
            else
            {
                string sql = "select * from FCSSLData_SH where issue='" + sissue + "'";
                DataTable dt = basicDAL.GetLisBySql(sql);
                sdate = dt.Rows[0]["date"];
                sissue = dt.Rows[0]["issue"];
                code = dt.Rows[0]["code"].ToString();
                ViewState["hide"] = sissue;
                this.btnSave.Text = "�޸�";
            }
            this.txtDate.Text = sdate.ToString();
            this.txtIssue.Text = sissue.ToString();
            this.txtcode.Text = code;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.FCSSLData_SH FC7LCBLL = new Pbzx.BLL.FCSSLData_SH();
            string strErrMsg = "";
            if (this.txtIssue.Text.Length < 8)
            {
                strErrMsg += "�������벻����.\\r\\n";
            }
            if (this.txtcode.Text.Length < 3)
            {
                strErrMsg += "�������벻����.\\r\\n";
            }

            DateTime now = DateTime.Now;
            if (!DateTime.TryParse(this.txtDate.Text, out now))
            {
                strErrMsg += "�������ڸ�ʽ����ȷ.\\r\\n";
            }


            string sql = "select top 1 * from FCSSLData_SH order by issue desc";
            DataTable dt = basicDAL.GetLisBySql(sql);
            if (strErrMsg != "")
            {
                strErrMsg = "���ύ����Ϣ�д������´���:\\r\\n\\r\\n" + strErrMsg + "\\r\\n���޸ĺ��������ύ.";
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                return;
            }
            else
            {
                Pbzx.Model.FCSSLData_SH FC7LCModel;
                if (ViewState["hide"].ToString() == "0")
                {
                    if (dt.Rows[0]["issue"].ToString() == this.txtIssue.Text)
                    {
                        strErrMsg += "�ÿ������ڵĿ�����Ϣ�Ѿ�����.\\r\\n";
                    }
                    if (strErrMsg != "")
                    {
                        strErrMsg = "���ύ����Ϣ�д������´���:\\r\\n\\r\\n" + strErrMsg + "\\r\\n���޸ĺ��������ύ.";
                        ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                        return;
                    }
                    FC7LCModel = new Pbzx.Model.FCSSLData_SH();
                }
                else
                {
                    FC7LCModel = FC7LCBLL.GetModel(int.Parse(ViewState["hide"].ToString()));
                }
                FC7LCModel.date = DateTime.Parse(this.txtDate.Text);
                FC7LCModel.Issue = int.Parse(this.txtIssue.Text);
                FC7LCModel.Code = this.txtcode.Text;
                FC7LCModel.LastModifytime = DateTime.Now;
                FC7LCModel.OpIp = Request.UserHostAddress; ;
                FC7LCModel.OpName = WebFunc.GetCurrentAdmin();
                if (ViewState["hide"].ToString() == "0")
                {
                    if (FC7LCBLL.Add(FC7LCModel))
                    {
                        ViewState["hide"] = "0";
                        btnList_Click(new object(), new EventArgs());
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
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "error", JS.Alert("����ʧ��!"));
                        return;
                    }
                }
            }
            //Server.Execute("/PB_Manage/RefurbishCpXml.aspx?cpType=FCSSLData_SH");
        }

        protected void FC7LC_del_code()
        {
            string sql = "";
            //�ж��Ƿ�����������
            if (txt_Condition.Text.Trim() != "" && txt_Condition.Text.Trim() != null)
            {
                string charSatr = txt_Condition.Text.ToString().Trim().Substring(txt_Condition.Text.Trim().Length - 1, 1);
                if (charSatr == "%")
                {
                    sql = "select top 1 * from FCSSLData_SH where issue like " + "'" + txt_Condition.Text.ToString().Trim() + "'" + " order by issue desc";
                }
                else
                {
                    sql = "select top 1 * from FCSSLData_SH where issue=" + "'" + txt_Condition.Text.ToString().Trim() + "'" + " order by issue desc";
                }
            }
            else
            {
                sql = "select top 1 * from FCSSLData_SH order by issue desc";
            }
            DataRow row = basicDAL.GetRowBySql(sql);
            if (row == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "error", JS.Alert("û�п�ɾ���Ŀ�����Ϣ!"));
                return;
            }
            if (basicDAL.ExecuteSql("delete FCSSLData_SH  where issue='" + row["issue"] + "'") > 0)
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
            this.divBatchAdd.Visible = false;
            this.divList.Visible = true;
            txt_Condition.Text = "";
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            FC7LC_del_code();
            //Server.Execute("/PB_Manage/RefurbishCpXml.aspx?cpType=FCSSLData_SH");
        }

        //�������ʾ
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
            //Server.Execute("/PB_Manage/RefurbishCpXml.aspx?cpType=FCSSLData_SH");
        }

        protected void SSL_rtrimVBcrlf(string str)
        {
            //string pos, isBlankChar;
            int pos = str.Length;
          
           

        }

        /// <summary>
        /// ������һ��Issue
        /// </summary>
        /// <param name="issue"></param>
        /// <returns></returns>
        private string[] CalcNexIssue()
        {
            string  statDate="",countDate="", statIssue = "", sdateStr="";
            string sql = "select top 1 * from FCSSLData_SH order by issue desc";
            DataTable dt = basicDAL.GetLisBySql(sql);
            string  sissue = dt.Rows[0]["issue"].ToString();
            string sdate = dt.Rows[0]["date"].ToString();
            if (!string.IsNullOrEmpty(sdate.ToString()))
            {
                countDate = sissue.ToString().Substring(sissue.ToString().Length - 2, 2);
                if (countDate == "23")
                {
                    DateTime startTime = DateTime.Parse(sdate.ToString()).AddDays(1);

                    //ƴ����
                    statIssue += startTime.Year.ToString();
                    //ƴ����
                    sdateStr = startTime.Month.ToString();
                    if (sdateStr.Length < 2)
                    {
                        sdateStr = "0" + sdateStr;
                    }
                    statIssue += sdateStr;
                    //ƴ����
                    sdateStr = DateTime.Parse(sdate.ToString()).AddDays(1).Day.ToString();
                    if (sdateStr.Length < 2)
                    {
                        sdateStr = "0" + sdateStr;
                    }
                    statIssue += sdateStr;
                    //�ӳ�ʼֵ
                    statIssue += "01";
                    sissue = statIssue;

                    //����
                    statDate = startTime.Date.ToShortDateString();
                    statDate += " 10:30:00";
                    sdate = statDate;
                }
                else
                {
                    sdate = DateTime.Parse(sdate.ToString()).AddMinutes(30).ToString();
                    int tempInt = int.Parse(dt.Rows[0]["issue"].ToString()) + 1;
                    sissue = tempInt.ToString();
                }
            }
            return new string[] { sissue,sdate};
        }


        /// <summary>
        /// ������һ��Issue
        /// </summary>
        /// <param name="issue"></param>
        /// <returns></returns>
        private string[] CalcNexIssue(string issue, string sdate)
        {
            DateTime oldDate = DateTime.Parse(sdate);

            string date = "";
            string mynewIssue = "";

            Pbzx.BLL.PBnet_LotteryMenu lotBLL = new Pbzx.BLL.PBnet_LotteryMenu();
            //PBnet_LotteryMenu��ǰ������Ϣ
            DataSet ds = lotBLL.GetList(" NvarApp_name='" + ViewState["tableName"] + "' ");
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

                object objTime = row["TimeList"];
                List<string> tmSZ = WebFunc.GetTimeListSZ(objTime)[1];

                mynewIssue = Convert.ToString(int.Parse(issue) + 1);
                for (int i = 0; i < tmSZ.Count; i++)
                {
                    if (TimeSpan.Parse(tmSZ[i]) == oldDate.TimeOfDay)//�ҵ���ʱ������ʱ������λ��
                    {
                        if (oldDate.TimeOfDay == TimeSpan.Parse(tmSZ[tmSZ.Count - 1]))//�����һ���е����һ��(������ʱ����0:00����Ҫ���죬������Ҫ)
                        {
                            if (oldDate.TimeOfDay == TimeSpan.Parse("0:00"))
                            {
                                date = oldDate.ToShortDateString() + " " + tmSZ[0];
                            }
                            else
                            {
                                date = oldDate.AddDays(1).ToShortDateString() + " " + tmSZ[0];
                                //�ж��Ƿ�������ʱ��֮��start(��2010-02-23)
                                if (WebInit.webBaseConfig.YearStart != "" && WebInit.webBaseConfig.YearEnd != "")
                                {
                                    if (Convert.ToDateTime(date) >= DateTime.Parse(WebInit.webBaseConfig.YearStart) && Convert.ToDateTime(date) <= DateTime.Parse(WebInit.webBaseConfig.YearEnd))
                                    {
                                        date = DateTime.Parse(WebInit.webBaseConfig.YearEnd).AddDays(1).ToShortDateString() + " " + tmSZ[0];//��һ�ڿ�ʼʱ�� 
                                    }
                                }
                                //�ж��Ƿ�������ʱ��֮��end(��2010-02-23)
                            }
                            DateTime dtMyNewIssue = Convert.ToDateTime(date);
                            string tempYue = dtMyNewIssue.Month.ToString().Length < 2 ? "0" + dtMyNewIssue.Month.ToString() : dtMyNewIssue.Month.ToString();
                            string tempDay = dtMyNewIssue.Day.ToString().Length < 2 ? "0" + dtMyNewIssue.Day.ToString() : dtMyNewIssue.Day.ToString();

                            ///////////�����ں�(��3-11)
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
                            //����ǰ������
                            if (qihaoClear[1].Contains("��"))
                            {
                                //�ڶ�����ˮ��
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
                                    //��һ����ˮ��
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
                            //����ǰ������
                            if (qihaoClear[1].Contains("��") && !qihaoClear[1].Contains("��"))
                            {
                                if (dtMyNewIssue.Year != oldDate.Year)
                                {

                                    //��һ����ˮ��
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
                                    //�ڶ�����ˮ��
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
                            ///////////�����ں�(��3-11)


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





        protected void  FCSSL_batchSave_code(string text)
        {   
          
            bool isError = false;
            string strErrMsg = "";
          
            Pbzx.BLL.FCSSLData_SH FCSSLData_SHBLL = new Pbzx.BLL.FCSSLData_SH();

            //���˸�ʽ�ַ���start
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

            string  issueCodeError = ""; 
            for (int i = 0; i < textSZ.Length; i++)
            {
                string qihao = "";
                string haoma = "";
                textSZ[i] = textSZ[i].Trim();
                if (textSZ[i].Length < intIssue)
                {
                    issueCodeError += "�ںŴ���λ���������ڵ�" + (i + 1) + "�д�.\\r\\n";
                    break;
                }
                qihao = textSZ[i].Substring(0, intIssue);
                haoma = textSZ[i].Substring(intIssue);
                textSZ[i] = qihao + "&" + haoma;
            }
            if (!string.IsNullOrEmpty(issueCodeError))
            {
                issueCodeError = "���ύ����Ϣ�д������´���:\\r\\n\\r\\n" + issueCodeError + "\\r\\n���޸ĺ��������ύ.";
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(issueCodeError));
                return;
            }
            //���˸�ʽ�ַ���end

                     
            SortedList sortCode = new SortedList();           
            
            //��ѯ����Issue
            string sql = "select top 1 date,Issue from FCSSLData_SH order by issue desc";
            DataRow row = basicDAL.GetRowBySql(sql);
            if(row == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert("���ݷ��ʳ���"));
                return;
            }
            //�������Ӧ�ò�����ںź�ʱ��.
            string oldIssue = row["Issue"].ToString();
            string oldDate = row["date"].ToString();

            string[] topQHSJ = CalcNexIssue(oldIssue,oldDate);

            string mynewIssue = topQHSJ[0];
            string mynewDate = topQHSJ[1];

            for (int i = 0; i < textSZ.Length; i++)
            {
                string[] codeSZ = textSZ[i].Trim().Split(new char[] { '&' });
                if(codeSZ[0].Length !=intIssue)
                {
                    isError = true;
                    strErrMsg += "�ںŴ���λ���������ڵ�"+(i+1)+"�У��ںţ�"+codeSZ[0]+" ���룺"+codeSZ[1]+"��.\\r\\n";
                    break;
                }
                else if(codeSZ[1].Length !=intCode)
                {
                    isError = true;
                    strErrMsg += "���Ŵ���λ���������ڵ�" + (i+1) + "�У��ںţ�" + codeSZ[0] + " ���룺" + codeSZ[1] + "��.\\r\\n";
                    break;
                }
                else if(int.Parse(codeSZ[0]) <= int.Parse(oldIssue))
                {
                    isError = true;
                    strErrMsg += "���ڽ����Ѿ����ڣ��ڵ�" + (i+1) + "�У��ںţ�" + codeSZ[0] + " ���룺" + codeSZ[1] + "����Ӧ��¼���ں�Ϊ��"+mynewIssue+".\\r\\n";
                    break;
                }
                try
                {
                    //�����ݷ��� SortedList
                    sortCode.Add(codeSZ[0], codeSZ[1]);
                }
                catch (IndexOutOfRangeException ex1)
                {
                    isError = true;
                    strErrMsg += "��������������������Խ��.\\r\\n";
                    break;
                }
                catch (Exception ex)
                {
                    isError = true;
                    strErrMsg += "�������ظ��ں����ݣ��ڵ�" + (i + 1) + "�У��ںţ�" + codeSZ[0] + " ���룺" + codeSZ[1] + "��.\\r\\n";
                    break;
                }
            }
            //��¡һ��SortedList �����������������
            SortedList sortCode2 = sortCode.Clone() as SortedList;                                  
            if(isError)
            {
                strErrMsg = "���ύ����Ϣ�д������´���:\\r\\n\\r\\n" + strErrMsg + "\\r\\n���޸ĺ��������ύ.";
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                return;
            }
            //�������������
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


            ///����������ִ������
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
                        SQLHelper.ExecuteNonQuery(trans, CommandType.Text, " insert into FCSSLData_SH (issue,[date],Code,LastModifytime,OpIp,OpName) values(@issue,@date,@Code,@LastModifytime,@OpIp,@OpName)", parmInsertOrderDetail);
                        ///����һ�����ݺ��ȼ������һ�ڵ��ںź�ʱ��
                        string[] tempQHSJ  = CalcNexIssue(mynewIssue, mynewDate);
                        mynewIssue = tempQHSJ[0];
                        mynewDate = tempQHSJ[1];
                    }
                    #endregion                   
                    //�ύ����
                    trans.Commit();
                }
                catch
                {
                    //����ִ��ʧ�ܣ��ع�
                    trans.Rollback(transName);
                    conn.Close();
                    conn.Dispose();
                    ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert("���ݲ���ʧ�ܣ��������Ա��ϵ��"));
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


        protected void IsContains(SortedList sortCode, string myIssue,string myDate)
        {
            if (sortCode.ContainsKey(myIssue))
            {
                sortCode.Remove(myIssue);
                string[] tempJHSJ = CalcNexIssue(myIssue, myDate);
                myIssue = tempJHSJ[0];
                myDate = tempJHSJ[1];
                IsContains(sortCode, myIssue, myDate);
            }
            else
            {
                if (sortCode.Count > 0)
                {
                    string strErrMsg = " �ںŲ���������ȱ�ٵ��ں�Ϊ��" + myIssue + "������Ӵ��ںź������\\r\\n";
                    ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                    IsLianXu = false;
                }
                else
                {
                    IsLianXu = true;
                }
            }       
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
                //    sql = "select top 15 * from FCSSLData_SH where issue like " + "'" + txt_Condition.Text.ToString().Trim() + "'" + " order by issue desc";
                //}
                //else
                //{
                //    sql = "select top 15 * from FCSSLData_SH where issue=" + "'" + txt_Condition.Text.ToString().Trim() + "'" + " order by issue desc";
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
