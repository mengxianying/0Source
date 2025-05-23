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
    public partial class GPX5config : AdminBasic
    {
        #region
        bool IsInsert = true;
        bool IsLianXu = true;

        int otherIssue = 7;
        int intCode = 5;//���볤��
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic();
        protected void Page_Load(object sender, EventArgs e)
        {
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
            this.rvd1.ErrorMessage = "�����󣬷�Χ��" + min + " - " + max + "��";

            this.rvd2.MinimumValue = min;
            this.rvd2.MaximumValue = max;
            this.rvd2.ErrorMessage = "�������󣬷�Χ��" + min + " - " + max + "��";

            this.rvd3.MinimumValue = min;
            this.rvd3.MaximumValue = max;
            this.rvd3.ErrorMessage = "�������󣬷�Χ��" + min + " - " + max + "��";

            this.rvd4.MinimumValue = min;
            this.rvd4.MaximumValue = max;
            this.rvd4.ErrorMessage = "�������󣬷�Χ��" + min + " - " + max + "��";

            this.rvd5.MinimumValue = min;
            this.rvd5.MaximumValue = max;
            this.rvd5.ErrorMessage = "�������󣬷�Χ��" + min + " - " + max + "��";
        }

        private void SetLinkAdd()
        {
            string linkAdd = "";
            linkAdd = GetInfo(ViewState["tableName"].ToString());
            this.lblLinkAdd.Text = linkAdd;
        }

        //�õ�������ַ��ÿ�쿪��ʱ����ʼ+����+���
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
                otherIssue = Convert.ToInt32(row["IssueLen"]);


                string[] lotTypeSZ = row["LottTypeInfo"].ToString().Split(new char[] { '|' });
                string[] kjHaoSZ = lotTypeSZ[0].Split(new char[] { ',' });
                if (kjHaoSZ[5] == "������")
                {
                    intCode = Convert.ToInt32(kjHaoSZ[1]);
                }
                else
                {
                    intCode = Convert.ToInt32(kjHaoSZ[1]) * 2;
                    kjHaoSZ[2] = "01";
                }
                lblFW.Text = "��Χ��" + kjHaoSZ[2] + " - " + kjHaoSZ[3];

                this.Title = row["NvarName"] + "������Ϣ����";
                linkAdd += "<font color=333333><b>" + row["NvarName"] + "������Ϣ����</b></font>&nbsp;&nbsp;&nbsp;";
                string[] kjInfo = row["LottTypeInfo"].ToString().Split(new char[] { '|' });
                //string min = "01";
                //string max = "50";
                //string tmin = "1";
                //string tmax = "50";
                string codes = kjInfo[0];
                //string tcodes = null;
                //������֤
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
                //��ַ
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
                //ʱ��
                object objTime = row["TimeList"];
                if (objTime != null && !string.IsNullOrEmpty(objTime.ToString()))
                {
                    result[1] += WebFunc.GetTimeListSZ(objTime)[0][0] + "&nbsp;&nbsp;ÿ��" + row["DayLottCount"] + "��&nbsp;";
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
            string sql = "select top 15 * from " + ViewState["tableName"] + " order by issue  desc";
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
                this.btnSave.Text = "���";
            }
            else
            {
                DataRow row = basicDAL.GetRowBySql("select * from " + ViewState["tableName"] + " where issue='" + ViewState["hide"] + "'");
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
            string code = "", code1 = "", code2 = "", code3 = "", code4 = "", code5 = "";

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
                ViewState["hide"] = "0";
                this.btnSave.Text = "���";
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
                }

                ViewState["hide"] = sissue;
                this.btnSave.Text = "�޸�";
            }
            this.txtDate.Text = sdate.ToString();
            this.txtIssue.Text = sissue.ToString();
            this.txtCode1.Text = code1;
            this.txtCode2.Text = code2;
            this.txtCode3.Text = code3;
            this.txtCode4.Text = code4;
            this.txtCode5.Text = code5;

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string sql = "select top 1 * from " + ViewState["tableName"] + " order by issue desc";
            DataTable dt = basicDAL.GetLisBySql(sql);

            string strErrMsg = "";

            if (this.txtIssue.Text.Length != otherIssue)
            {
                strErrMsg += "�ں����벻����.\\r\\n";
            }


            if (this.txtCode1.Text.Length != 2 || this.txtCode2.Text.Length != 2 || this.txtCode3.Text.Length != 2 || this.txtCode4.Text.Length != 2 || this.txtCode5.Text.Length != 2)
            {
                strErrMsg += "�������벻����.\\r\\n";
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


            string code = this.txtCode1.Text + this.txtCode2.Text + this.txtCode3.Text + this.txtCode4.Text + this.txtCode5.Text;
            string resultCode = code;
            string isCF = "";
            string[] result = CheckFormart(-1, this.txtIssue.Text, code);
            string errorMsg = result[0];
            isCF = result[1];
            resultCode = result[2];

            //�ںŴ���
            if (errorMsg.Length > 0)
            {
                strErrMsg += errorMsg + ".\\r\\n";
            }
            //���Ŵ���
            if (isCF.Length > 0)
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
                if (ViewState["hide"].ToString() == "0")
                {
                    if (dt.Rows.Count > 0 && dt.Rows[0]["issue"].ToString() == this.txtIssue.Text)
                    {
                        strErrMsg += "�ÿ������ڵĿ�����Ϣ�Ѿ�����.\\r\\n";
                    }
                    if (strErrMsg != "")
                    {
                        strErrMsg = "���ύ����Ϣ�д������´���:\\r\\n\\r\\n" + strErrMsg + "\\r\\n���޸ĺ��������ύ.";
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
                        ClientScript.RegisterStartupScript(this.GetType(), "error", JS.Alert("���ʧ��!"));
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
                        ClientScript.RegisterStartupScript(this.GetType(), "error", JS.Alert("����ʧ��!"));
                        return;
                    }
                }
            }
            //Server.Execute("/PB_Manage/RefurbishCpXml.aspx?cpType=" + ViewState["tableName"]);
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
                    sql = "select top 1 * from " + ViewState["tableName"] + " where issue like " + "'" + txt_Condition.Text.ToString().Trim() + "'" + " order by issue desc";
                }
                else
                {
                    sql = "select top 1 * from " + ViewState["tableName"] + " where issue=" + "'" + txt_Condition.Text.ToString().Trim() + "'" + " order by issue desc";
                }
            }
            else
            {
                sql = "select top 1 * from " + ViewState["tableName"] + " order by issue desc";
            }
            DataRow row = basicDAL.GetRowBySql(sql);
            if (row == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "error", JS.Alert("û�п�ɾ���Ŀ�����Ϣ!"));
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
            this.divBatchAdd.Visible = false;
            txt_Condition.Text = "";
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            FC7LC_del_code();
            //Server.Execute("/PB_Manage/RefurbishCpXml.aspx?cpType=" + ViewState["tableName"]);
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
            //Server.Execute("/PB_Manage/RefurbishCpXml.aspx?cpType=" + ViewState["tableName"]);
        }


        /// <summary>
        /// ������һ���ںź�date
        /// </summary>
        /// <param name="issue"></param>
        /// <returns></returns>
        private string[] CalcNextDate(string issue, string strdate)
        {

            string date = "";
            string mynewIssue = "";

            DateTime oldDate = DateTime.Parse(strdate);


            int tempINT = int.Parse(issue) + 1;
            string newsissue = tempINT.ToString();

            Pbzx.BLL.PBnet_LotteryMenu lotBLL = new Pbzx.BLL.PBnet_LotteryMenu();
            //PBnet_LotteryMenu��ǰ������Ϣ
            DataSet ds = lotBLL.GetList(" NvarApp_name='" + ViewState["tableName"] + "' ");
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                object objTime = row["TimeList"];
                List<string> tmSZ = WebFunc.GetTimeListSZ(objTime)[1];
                ////ÿ�쿪������
                //qishu = row["DayLottCount"].ToString();

                mynewIssue = Convert.ToString(Convert.ToInt64(issue) + 1);
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
                                    //Ϊ�˷�ֹ�������ж����Ƿ����������λ
                                    if (issueSzBig.Length > 2)
                                    {
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
                                }
                                else
                                {
                                    try
                                    {
                                        try
                                        {
                                            liuShui1 = Convert.ToString(int.Parse(issue.Substring(tempResult.Length, int.Parse(issueSzBig[1]))) + 1);
                                        }
                                        catch
                                        {

                                            liuShui1 = "1";
                                        }
                                        int number = liuShui1.Length;

                                        //��ǰ�����
                                        //for (int j = 0; j <= int.Parse(issueSzBig[1]) - liuShui1.Length; j++)
                                        //{
                                        //    liuShui1 = "0" + liuShui1;
                                        //}
                                        //�޸ĺ��city=TC22X5Data_LiaoN
                                        //if (Request.QueryString["city"] == "TC22X5Data_LiaoN")
                                        //{
                                        //    for (int j = 0; j <= int.Parse(issueSzBig[1]) - number; j++)
                                        //    {
                                        //        liuShui1 = "0" + liuShui1;
                                        //    }
                                        //}
                                        //else
                                        //{
                                        //    for (int j = 0; j <= int.Parse(issueSzBig[1]) - liuShui1.Length; j++)
                                        //    {
                                        //        liuShui1 = "0" + liuShui1;
                                        //    }
                                        //}
                                        for (int j = 0; j < int.Parse(issueSzBig[1]) - number; j++)
                                        {
                                            liuShui1 = "0" + liuShui1;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Response.Write("<script>alert('�ں���Ϣ���ò���ȷ');histroy.go(-1);</script>");
                                        Response.End();
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










                //if (ViewState["tableName"].ToString() == "TC11X5Data_ShanD" || ViewState["tableName"].ToString() == "TC11X5Data_AnH")// ɽ��ʮһ�˶�� ,����11ѡ5
                //{                    
                //    if (oldDate.TimeOfDay.ToString().Substring(0,5) == lastTime)//����ǵ���һ������һ��
                //    {
                //        result = DateTime.Parse(oldDate.AddDays(1).ToShortDateString() + " " + startTime);//��һ�ڿ�ʼʱ��

                //        //�ж��Ƿ�������ʱ��֮��start(��2010-02-23)
                //        if (WebInit.webBaseConfig.YearStart != "" && WebInit.webBaseConfig.YearEnd != "")
                //        {
                //            if (result >= DateTime.Parse(WebInit.webBaseConfig.YearStart) && result <= DateTime.Parse(WebInit.webBaseConfig.YearEnd))
                //            {
                //                result = DateTime.Parse(DateTime.Parse(WebInit.webBaseConfig.YearEnd).AddDays(1).ToShortDateString() + " " + startTime);//��һ�ڿ�ʼʱ�� 
                //            }
                //        }
                //        //�ж��Ƿ�������ʱ��֮��end(��2010-02-23)

                //        newsissue = Method.FormartDateToStr(result);//ƴ����һ���ں�
                //        newsissue += "01";//��һ���ں�
                //        if (otherIssue == 7)
                //        {
                //            newsissue = newsissue.Substring(3);
                //        }
                //        else
                //        {
                //            newsissue = newsissue.Substring(2);
                //        }
                //    }
                //    else
                //    {
                //        result = oldDate.AddMinutes(openTime);//��һ�ڿ�ʼʱ��
                //    }
                //}
                //else if (ViewState["tableName"].ToString() == "FC21X5Data_GuangX")//��������ʮ��
                //{
                //    string srest = "";
                //    if (oldDate.TimeOfDay.ToString().Substring(0, 5) == lastTime)///����ǵ���һ������һ��
                //    {
                //        result = oldDate.AddDays(1);

                //        //�ж��Ƿ�������ʱ��֮��start(��2010-02-23)
                //        if (WebInit.webBaseConfig.YearStart != "" && WebInit.webBaseConfig.YearEnd != "")
                //        {
                //            if (result >= DateTime.Parse(WebInit.webBaseConfig.YearStart) && result <= DateTime.Parse(WebInit.webBaseConfig.YearEnd))
                //            {
                //                result = DateTime.Parse(DateTime.Parse(WebInit.webBaseConfig.YearEnd).AddDays(1).ToShortDateString() + " " + startTime);//��һ�ڿ�ʼʱ�� 
                //            }
                //        }
                //        //�ж��Ƿ�������ʱ��֮��end(��2010-02-23)


                //        if (result.Year != oldDate.Year)//����һ����ٽ��,�õ���һ���ںŵ�5��7λ
                //        {
                //            srest = "001";//�ںŵ�5��7λ
                //        }
                //        else
                //        {
                //            int intTemp = int.Parse(issue.Substring(4, 3)) + 1;
                //            srest = intTemp.ToString();
                //            if (srest.Length == 1)
                //            {
                //                srest = "00" + srest;//�ںŵ�5��7λ
                //            }
                //            else if (srest.Length == 2)
                //            {
                //                srest = "0" + srest;//�ںŵ�5��7λ
                //            }
                //        }

                //        newsissue = result.Year + srest + "01";//�õ���һ���ں�
                //        result = DateTime.Parse(result.ToShortDateString() + " " + startTime);//��һ�ڵ�ʱ��
                //    }
                //    else
                //    {
                //        result = oldDate.AddMinutes(openTime);//��һ�ڵ�ʱ��
                //    }
                //}
                //else if (ViewState["tableName"].ToString() == "FC23X5Data_GP_ShanD")//ɽ��ȺӢ��һ���п���ʱ������Σ�
                //{
                //    string[] timeSZS = objTime.ToString().Split(new char[] { '&' });//�������ݿ���һ��������ʱ���б�
                //    string[] timeSZ1 = timeSZS[0].Split(new char[] { '|' });//��һ��ʱ���б�
                //    string[] timeSZ2 = timeSZS[1].Split(new char[] { '|' });////�ڶ���ʱ���б�
                //    startTime = timeSZ1[0];
                //    lastTime = timeSZ1[timeSZ1.Length - 1];
                //    startTime1 = timeSZ2[0];
                //    lastTime1 = timeSZ2[timeSZ2.Length - 1];

                //    if (oldDate.TimeOfDay.ToString().Substring(0, 5) == lastTime1)//һ���е����һ�ڻ����ٽ��
                //    {
                //        result = DateTime.Parse(oldDate.AddDays(1).ToShortDateString() + " " + startTime);//��һ�ڵ�ʱ��

                //        //�ж��Ƿ�������ʱ��֮��start(��2010-02-23)
                //        if (WebInit.webBaseConfig.YearStart != "" && WebInit.webBaseConfig.YearEnd != "")
                //        {
                //            if (result >= DateTime.Parse(WebInit.webBaseConfig.YearStart) && result <= DateTime.Parse(WebInit.webBaseConfig.YearEnd))
                //            {
                //                result = DateTime.Parse(DateTime.Parse(WebInit.webBaseConfig.YearEnd).AddDays(1).ToShortDateString() + " " + startTime);//��һ�ڿ�ʼʱ�� 
                //            }
                //        }
                //        //�ж��Ƿ�������ʱ��֮��end(��2010-02-23)

                //        newsissue = Method.FormartDateToStr(result) + "01";////��һ�ڵ��ں�
                //    }
                //    else if (oldDate.TimeOfDay.ToString().Substring(0, 5) == lastTime)//һ���е�һ��ʱ������һ��
                //    {
                //        result = oldDate.AddMinutes(195);//��һ�ڵ�ʱ��
                //    }
                //    else
                //    {
                //        result = oldDate.AddMinutes(openTime);//��һ�ڵ�ʱ��
                //    }
                //}
                //else
                //{
                //    if (oldDate.TimeOfDay.ToString().Substring(0, 5) == lastTime)
                //    {
                //        result = oldDate.AddDays(1);

                //        //�ж��Ƿ�������ʱ��֮��start(��2010-02-23)
                //        if (WebInit.webBaseConfig.YearStart != "" && WebInit.webBaseConfig.YearEnd != "")
                //        {
                //            if (result >= DateTime.Parse(WebInit.webBaseConfig.YearStart) && result <= DateTime.Parse(WebInit.webBaseConfig.YearEnd))
                //            {
                //                result = DateTime.Parse(DateTime.Parse(WebInit.webBaseConfig.YearEnd).AddDays(1).ToShortDateString() + " " + startTime);//��һ�ڿ�ʼʱ�� 
                //            }
                //        }
                //        //�ж��Ƿ�������ʱ��֮��end(��2010-02-23)


                //        if (result.Year != oldDate.Year)///����һ����ٽ��
                //        {
                //            string strYear = result.Year.ToString();
                //            newsissue = strYear.Substring(strYear.Length - 1, 1) + "000001";
                //        }
                //        result = DateTime.Parse(result.ToShortDateString() + " " + startTime);
                //    }
                //    else
                //    {
                //        result = oldDate.AddMinutes(openTime);
                //    }
                //}



            }
            return new string[] { mynewIssue, date };//newsissue,result.ToString()
        }



        //����ںźͽ������ݺϷ���
        private string[] CheckFormart(int currentRow, string issue, string code)
        {
            string[] result = new string[3];
            Pbzx.BLL.PBnet_LotteryMenu lotBLL = new Pbzx.BLL.PBnet_LotteryMenu();
            //PBnet_LotteryMenu��ǰ������Ϣ
            DataSet ds = lotBLL.GetList(" NvarApp_name='" + ViewState["tableName"] + "' ");
            string errorMsg = "";//������ʾ��Ϣ�������ںų��Ȳ�����
            string isCF = "";//������ʾ��Ϣ�������ں��Ƿ��ظ���
            string resultCode = code;//��ʽ����ĺ���
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                string[] strInfoSZ = row["LottTypeInfo"].ToString().Split(new char[] { '|' });
                string[] codeInfoSZ = strInfoSZ[0].Split(new char[] { ',' });

                if (ViewState["tableName"].ToString() == "FC21X5Data_GuangX")//��������ʮ��
                {
                    if (issue.Length != otherIssue)//��������ʮ���ںų���
                    {
                        errorMsg += "�ںŴ���λ��������";
                    }
                    isCF = Method.showCheckStr(Method.FormartCode(code, " "), int.Parse(codeInfoSZ[3]));
                }
                else if (ViewState["tableName"].ToString() == "FC23X5Data_GP_ShanD")//ɽ��ȺӢ��һ���п���ʱ������Σ�
                {
                    if (issue.Length != otherIssue)//ɽ��ȺӢ���ںų���
                    {
                        errorMsg += "�ںŴ���λ��������";
                    }
                    isCF = Method.showCheckStr(Method.FormartCode(code, " "), int.Parse(codeInfoSZ[3]));
                }
                else
                {
                    //if (issue.Length != otherIssue)
                    //{
                    //    errorMsg += "�ںŴ���λ��������";
                    //}
                    isCF = Method.showCheckStr(Method.FormartCode(code, " "), int.Parse(codeInfoSZ[3]));
                    if (codeInfoSZ[5] == "��͸��")
                    {
                        resultCode = Method.OrderCode(Method.FormartCode(code, ""), "");
                    }
                }
                if (currentRow != -1)
                {
                    if (!string.IsNullOrEmpty(errorMsg))
                    {
                        errorMsg += "�ڵ�" + currentRow + "�У��ںţ�" + issue + " ���룺" + code + "��.\\r\\n";
                    }
                    if (!string.IsNullOrEmpty(isCF))
                    {
                        isCF += "�ڵ�" + currentRow + "�У��ںţ�" + issue + " ���룺" + code + "��.\\r\\n";
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
            string issueCodeError = "";
            for (int i = 0; i < textSZ.Length; i++)
            {
                string qihao = "";
                string haoma = "";
                textSZ[i] = textSZ[i].Trim();
                if (textSZ[i].Length < otherIssue)
                {
                    issueCodeError += "�ںŴ���λ���������ڵ�" + (i + 1) + "�д�.\\r\\n";
                    break;
                }

                if (ViewState["tableName"].ToString() == "FC20X5Data_GuangD" || ViewState["tableName"].ToString() == "FC23X5Data_GP_ShanD")// �㶫����ʮ�� 
                {
                    qihao = textSZ[i].Substring(0, otherIssue);
                    haoma = textSZ[i].Substring(otherIssue);
                }
                else if (ViewState["tableName"].ToString() == "FC21X5Data_GuangX")
                {
                    qihao = textSZ[i].Substring(0, otherIssue);
                    haoma = textSZ[i].Substring(otherIssue);
                }
                else
                {
                    qihao = textSZ[i].Substring(0, otherIssue);
                    haoma = textSZ[i].Substring(otherIssue);
                }
                if (qihao.Substring(0, 1) == "0")
                {
                    qihao = qihao.Substring(1);
                }
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
            string sql = "select top 1 date,Issue from " + ViewState["tableName"] + " order by issue desc";
            DataRow row = basicDAL.GetRowBySql(sql);
            if (row == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert("���ݷ��ʳ���"));
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
                if (codeSZ[0].Length != otherIssue)
                {
                    isError = true;
                    strErrMsg += "�ںŴ���λ���������ڵ�" + (i + 1) + "�У��ںţ�" + codeSZ[0] + "  ���룺" + codeSZ[1] + "��.\\r\\n";
                    break;
                }
                else if (codeSZ[1].Length != intCode)
                {
                    isError = true;
                    strErrMsg += "���Ŵ���λ���������ڵ�" + (i + 1) + "�У��ںţ�" + codeSZ[0] + " ���룺" + codeSZ[1] + "��.\\r\\n";
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
                        strErrMsg += "���ڽ����Ѿ����ڣ��ڵ�" + (i + 1) + "�У��ںţ�" + codeSZ[0] + " ���룺" + codeSZ[1] + "����Ӧ��¼���ں�Ϊ��" + mynewIssue + ".\\r\\n";
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
            }
            SortedList sortCode2 = sortCode.Clone() as SortedList;

            if (isError)
            {
                strErrMsg = "���ύ����Ϣ�д������´���:\\r\\n\\r\\n" + strErrMsg + "\\r\\n���޸ĺ��������ύ.";
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                return;
            }

            ///����ںŲ�������ֹͣ
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
                        //" + ViewState["tableName"] + "
                        SQLHelper.ExecuteNonQuery(trans, CommandType.Text, " insert into " + ViewState["tableName"] + " (issue,[date],Code,LastModifytime,OpIp,OpName) values(@issue,@date,@Code,@LastModifytime,@OpIp,@OpName)", parmInsertOrderDetail);
                        ///����һ�����ݺ��ȼ������һ�ڵ��ںź�ʱ��
                        string[] tempQHSJ = CalcNextDate(mynewIssue, mynewDate);
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
                //    string strErrMsg = "���ύ����Ϣ�д������´���:\\r\\n\\r\\n���������Ѿ�¼�룬�뵽���ڿ���������¼���µ����ݣ�\\r\\n���޸ĺ��������ύ.";
                //    ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                //    IsInsert = false;
                //}
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
        #endregion

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
                //    sql = "select top 120 * from " + ViewState["tableName"] + " where issue like " + "'" + txt_Condition.Text.ToString().Trim() + "'" + " order by issue desc";
                //}
                //else
                //{
                //    sql = "select top 120 * from " + ViewState["tableName"] + " where issue=" + "'" + txt_Condition.Text.ToString().Trim() + "'" + " order by issue desc";
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
