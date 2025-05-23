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
    public partial class OtherX7config : AdminBasic
    {
        #region
        private int _maxNum = 1;
        int otherIssue = 7;

        public int MaxNum
        {
            get { return _maxNum; }
            set { _maxNum = value; }
        } 
        // bool IsLianXu = true;
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
                else
                {
                    JS.Alert("�������ݴ���");
                    return;
                }                
            }
            SetLinkAdd();
        }

        private void SetYZValue(string min, string max)
        {
            this.lblFW.Text = "��ʽ��01 02 03 04 05 06 07����Χ��" + min + "--" + max + "��";
            this.rvd1.MinimumValue = min;
            this.rvd1.MaximumValue = max;
            this.rvd1.ErrorMessage = "�������󣬷�Χ��" + min + "--" + max + "��";

            this.rvd2.MinimumValue = min;
            this.rvd2.MaximumValue = max;
            this.rvd2.ErrorMessage = "�������󣬷�Χ��" + min + "--" + max + "��";

            this.rvd3.MinimumValue = min;
            this.rvd3.MaximumValue = max;
            this.rvd3.ErrorMessage = "�������󣬷�Χ��" + min + "--" + max + "��";

            this.rvd4.MinimumValue = min;
            this.rvd4.MaximumValue = max;
            this.rvd4.ErrorMessage = "�������󣬷�Χ��" + min + "--" + max + "��";

            this.rvd5.MinimumValue = min;
            this.rvd5.MaximumValue = max;
            this.rvd5.ErrorMessage = "�������󣬷�Χ��" + min + "--" + max + "��";

            this.rvd6.MinimumValue = min;
            this.rvd6.MaximumValue = max;
            this.rvd6.ErrorMessage = "�������󣬷�Χ��" + min + "--" + max + "��";

            this.rvd7.MinimumValue = min;
            this.rvd7.MaximumValue = max;
            this.rvd7.ErrorMessage = "�������󣬷�Χ��" + min + "--" + max + "��";
        }

        private void SetYZTCodeValue(string min, string max)
        {
            this.lblTCode.Text = "��ʽ��01����Χ��" + min + "--" + max + "��";
            this.rvdTCode.MinimumValue = min;
            this.rvdTCode.MaximumValue = max;
            this.rvdTCode.ErrorMessage = "�ر�������󣬷�Χ��" + min + "--" + max + "��";
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

                this.Title = row["NvarName"] + "������Ϣ����";
                linkAdd += "<font color=333333><b>" + row["NvarName"] + "������Ϣ����</b></font>&nbsp;&nbsp;&nbsp;"; 
                string[] kjInfo = row["LottTypeInfo"].ToString().Split(new char[] { '|' });            
                //string min = "01";
                //string max = "50";
                //string tmin = "1";
                //string tmax = "50";
                string codes = kjInfo[0];
                string tcodes = null;              
               
                //������֤
                string[] codeArray = codes.Split(new char[] {','});
                if(codeArray.Length > 4)
                {
                    if(codeArray[2] =="1")
                    {
                        codeArray[2]="01";
                    }
                    SetYZValue(codeArray[2], codeArray[3]);
                }
                //�ر������֤
                if(kjInfo.Length > 1 && !string.IsNullOrEmpty(kjInfo[1]))
                {
                    tcodes = kjInfo[1];
                    string[] tcodeArray = tcodes.Split(new char[] {','});
                    if (tcodeArray.Length > 4)
                    {
                        if (tcodeArray[5] != "������")
                        {
                            tcodeArray[2] = "01";
                            txtBluecode.MaxLength = 2;
                        }
                        else
                        {
                            txtBluecode.MaxLength = 1;
                        }
                        SetYZTCodeValue(tcodeArray[2], tcodeArray[3]);
                    }
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
                    string[] tmSZ = objTime.ToString().Split(new char[] { '|' });
                    result[1] += tmSZ[0] + " �� " + tmSZ[tmSZ.Length - 1] + "&nbsp;&nbsp;ÿ��" + row["DayLottCount"] + "��&nbsp;";

                    TimeSpan tsStart = new TimeSpan();
                    TimeSpan tsEnd = new TimeSpan();
                    if (!TimeSpan.TryParse(tmSZ[0], out tsStart) || !TimeSpan.TryParse(tmSZ[1], out tsEnd))
                    {
                        Response.Write("<script>alert('ʱ����������!')</script>");
                    }
                    else
                    {
                        int jg = 0;
                        tsEnd.Subtract(tsStart);
                        while (tsStart < tsEnd)
                        {
                            tsStart = tsStart.Add(TimeSpan.FromMinutes(1));
                            jg++;
                        }
                        result[1] += jg.ToString() + "����һ��";
                    }
                }
                else
                {
                    object objDate = row["NvarLott_date"];
                    result[1] = Method.GetLottDate(objDate.ToString());
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
            this.MyGridView.DataSource = dt;
            this.MyGridView.DataBind();
            ViewState["hide"] = "0";
        }


        //#region
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
                FC7LC_add_code_main(true, row["date"].ToString(), row["issue"].ToString());
                this.txtIssue.Enabled = false;
                this.txtDate.Enabled = false;
                this.btnSave.Text = "�޸�";
            }
        }

        protected void FC7LC_add_code_main(object bModify, string sdate, string sissue)
        {
            string code, s_number = "";
            string code1, code2, code3, code4, code5, code6, code7="", bluecode="";

            if (bool.Parse(bModify.ToString()) == false)
            {
                string sql = "select top 1 * from " + ViewState["tableName"] + " order by issue desc";
                DataTable dt = basicDAL.GetLisBySql(sql);
                sissue = dt.Rows[0]["issue"].ToString();
                sdate = dt.Rows[0]["date"].ToString();
                int intTemp = int.Parse(sissue.ToString()) + 1;
                sissue = intTemp.ToString();

                if (Request["lottDate"] == "0" || Request["lottDate"] == "")
                {
                    sdate = DateTime.Parse(sdate).AddDays(1).ToShortDateString();
                    //�ж��Ƿ�������ʱ��֮��start(��2010-02-23)
                    if (WebInit.webBaseConfig.YearStart != "" && WebInit.webBaseConfig.YearEnd != "")
                    {
                        if (Convert.ToDateTime(sdate) >= DateTime.Parse(WebInit.webBaseConfig.YearStart) && Convert.ToDateTime(sdate) <= DateTime.Parse(WebInit.webBaseConfig.YearEnd))
                        {
                            sdate = DateTime.Parse(WebInit.webBaseConfig.YearEnd).AddDays(1).ToShortDateString();//��һ�ڿ�ʼʱ�� 
                        }
                    }
                    //�ж��Ƿ�������ʱ��֮��end(��2010-02-23)

                }
                else if (Request["lottDate"].Length > 1)
                {
                    int intWeek = (((int)DateTime.Parse(sdate).DayOfWeek) + 1);
                    s_number =  Request["lottDate"].IndexOf("" + intWeek.ToString() + "").ToString();
                    if (int.Parse(s_number) == Request["lottDate"].Length - 1)
                    {
                        sdate = DateTime.Parse(sdate).AddDays((int.Parse(Request["lottDate"].Substring(0, 1))) + 7 - int.Parse(Request["lottDate"].Substring(Request["lottDate"].Length - 1, 1))).ToShortDateString();
                    }
                    else
                    {
                        sdate = DateTime.Parse(sdate).AddDays((int.Parse(Request["lottDate"].Substring(int.Parse(s_number) + 1, 1))) - int.Parse(Request["lottDate"].Substring(int.Parse(s_number), 1))).ToShortDateString();
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
                        string[] checkResult = WebFunc.GetYearEndDate(Convert.ToDateTime(sdate), Request["lottDate"]);
                        if (checkResult[0] == "true")
                        {
                            int intWeek1 = (((int)DateTime.Parse(sdate).DayOfWeek) + 1);
                            s_number = Request["lottDate"].IndexOf("" + intWeek1.ToString() + "").ToString();
                            if (int.Parse(s_number) == Request["lottDate"].Length - 1)
                            {
                                sdate = DateTime.Parse(sdate).AddDays((int.Parse(Request["lottDate"].Substring(0, 1))) + 7 - int.Parse(Request["lottDate"].Substring(Request["lottDate"].Length - 1, 1))).ToShortDateString();
                            }
                            else
                            {
                                sdate = DateTime.Parse(sdate).AddDays((int.Parse(Request["lottDate"].Substring(int.Parse(s_number) + 1, 1))) - int.Parse(Request["lottDate"].Substring(int.Parse(s_number), 1))).ToShortDateString();
                            }
                        }
                        else
                        {
                            sdate = checkResult[1];
                        }
                    }
                    //�ж��Ƿ�������ʱ��֮��end(��2010-02-23)

                }

                if (DateTime.Parse(sdate.ToString()) > DateTime.Now)
                {
                    Response.Write("<script>alert('���������Ѿ�¼�룬�뵽���ڿ���������¼���µ����ݣ�');history.go(-1);</script>");
                    Response.End();
                    //btnClear_Click(new object(), new EventArgs());
                    return;
                }
                if (DateTime.Parse(sdate).Year.ToString() != sissue.Substring(0, 4))
                {
                    sissue = DateTime.Now.Year.ToString() + "001";
                }
                code1 = "";
                code2 = "";
                code3 = "";
                code4 = "";
                code5 = "";
                code6 = "";
                code7 = "";
                bluecode = "";
                ViewState["hide"] = "0";
                this.btnSave.Text = "���";
            }
            else
            {
                string sql = "select * from " + ViewState["tableName"] + " where issue='" + sissue + "'";
                DataTable dt = basicDAL.GetLisBySql(sql);
                sdate = dt.Rows[0]["date"].ToString();
                sissue = dt.Rows[0]["issue"].ToString();
                code = dt.Rows[0]["code"].ToString();
                code1 = code.Substring(0, 2);
                code2 = code.Substring(2, 2);
                code3 = code.Substring(4, 2);
                code4 = code.Substring(6, 2);
                code5 = code.Substring(8, 2);
                code6 = code.Substring(10, 2);
                bluecode = dt.Rows[0]["tcode"].ToString();

                if (Request["city"] != "TC36X7Data_FZ3J")
                {
                    code7 = code.Substring(12, 2);
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
            this.txtCode6.Text = code6;
            this.txtCode7.Text = code7;
            this.txtBluecode.Text = bluecode;

            //�ں�
            this.lblIssue.Text = "��ʽ��" + sissue;
            this.txtDate.Text = Convert.ToDateTime(sdate).ToShortDateString();

        }



        protected void btnSave_Click(object sender, EventArgs e)
        {
            string strErrMsg = "";
            if (this.txtIssue.Text.Length != otherIssue)
            {
                strErrMsg += "�ںŴ���λ������.\\r\\n";
            }
            if (this.txtBluecode.Text.Length !=  txtBluecode.MaxLength)
            {
                strErrMsg += "�ر�������λ������.\\r\\n";
            }

            DateTime now = DateTime.Now;
            if (!DateTime.TryParse(this.txtDate.Text, out now))
            {
                strErrMsg += "�������ڸ�ʽ����ȷ.\\r\\n";
            }

            if (this.txtCode1.Text.Length != 2 || this.txtCode2.Text.Length != 2 || this.txtCode3.Text.Length != 2 || this.txtCode4.Text.Length != 2 || this.txtCode5.Text.Length != 2 || this.txtCode6.Text.Length != 2)
            {
                strErrMsg += "�����������벻�������밴�տ��������ұ���ʾ��ʽ���룡\\r\\n";
            }
            if (strErrMsg != "")
            {
                strErrMsg = "���ύ����Ϣ�д������´���:\\r\\n\\r\\n" + strErrMsg + "\\r\\n���޸ĺ��������ύ.";
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                return;
            }  

            string code = this.txtCode1.Text + this.txtCode2.Text + this.txtCode3.Text + this.txtCode4.Text + this.txtCode5.Text + this.txtCode6.Text;
            string code7 = code + this.txtCode7.Text;
            string tempCode = code + this.txtBluecode.Text;
            string tempCode7 = code7 + this.txtBluecode.Text; 
            string isCF ="";
            string resultCode = code;
            Pbzx.BLL.PBnet_LotteryMenu lotBLL = new Pbzx.BLL.PBnet_LotteryMenu();
            //PBnet_LotteryMenu��ǰ������Ϣ
            DataSet ds = lotBLL.GetList(" NvarApp_name='" + ViewState["tableName"] + "' ");
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                string[] strInfoSZ = row["LottTypeInfo"].ToString().Split(new char[] { '|' });
                string[] codeInfoSZ = strInfoSZ[0].Split(new char[] { ',' });
                
                if (codeInfoSZ[5] == "��͸��")
                {
                    if (Request["city"] == "TC36X7Data_FZ3J")
                    {
                        resultCode = Method.OrderCode(Method.FormartCode(code, ""), "");
                        isCF = Method.showCheckStr(Method.FormartCode(code, " "), int.Parse(codeInfoSZ[3]));
                    }
                    else
                    {
                        resultCode = Method.OrderCode(Method.FormartCode(code7, ""), "");
                        isCF = Method.showCheckStr(Method.FormartCode(code7, " "), int.Parse(codeInfoSZ[3]));
                    }
                }
            }

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
            string sql = "select top 1 * from " + ViewState["tableName"] + " order by issue desc";
            DataTable dt = basicDAL.GetLisBySql(sql);
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
                if (basicDAL.ExecuteSql(" insert into " + ViewState["tableName"] + "(issue,[date],Code,tcode,LastModifytime,OpIp,OpName) values('" + this.txtIssue.Text + "','" + this.txtDate.Text + "','" + resultCode + "','" + this.txtBluecode.Text + "','" + DateTime.Now + "','" + Request.UserHostAddress + "','"+WebFunc.GetCurrentAdmin()+"')") > 0)
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
                if (basicDAL.ExecuteSql("update " + ViewState["tableName"] + " set issue='" + this.txtIssue.Text + "',[date]='" + this.txtDate.Text + "',Code='" + resultCode + "',tcode='" + txtBluecode.Text + "',LastModifytime='" + DateTime.Now + "',OpIp='" + Request.UserHostAddress + "',OpName='"+WebFunc.GetCurrentAdmin()+"' where issue='" + ViewState["hide"] + "' ") > 0)
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
            //Server.Execute("/PB_Manage/RefurbishCpXml.aspx?cpType=" + ViewState["tableName"]);
        }

        protected void FC7LC_del_code()
        {
            string sql = "";
            //�ж��Ƿ�����������
            if (txt_Condition.Text.Trim() != "" && txt_Condition.Text.Trim() != null)
            {
                string charSatr = txt_Condition.Text.Trim().ToString().Substring(txt_Condition.Text.Trim().Length - 1, 1);
                if (charSatr == "%")
                {
                    sql = "select top 1 * from " + ViewState["tableName"] + " where issue like " + "'" + txt_Condition.Text.Trim().ToString() + "'" + " order by issue desc";
                }
                else
                {
                    sql = "select top 1 * from " + ViewState["tableName"] + " where issue=" + "'" + txt_Condition.Text.Trim().ToString() + "'" + " order by issue desc";
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
        //#endregion
        //��ʽ��IP��ַ
        protected string GetIp(object ip)
        {
            Pbzx.BLL.PBnet_ipdata ipBLL = new Pbzx.BLL.PBnet_ipdata();
            return ipBLL.S_getIPaddress(ip.ToString());
        }
        //#region
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
            //this.divBatchAdd.Visible = false;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            BindData();
            this.divAdd.Visible = false;
            this.divList.Visible = true;           
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
                //string charSatr = txt_Condition.Text.Trim().ToString().Substring(txt_Condition.Text.Trim().Length - 1, 1);
                string sql = "";
                //if (charSatr == "%")
                //{
                //    sql = "select top 120 * from " + ViewState["tableName"] + " where issue like " + "'" + txt_Condition.Text.Trim().ToString() + "'" + " order by issue desc";
                //}
                //else
                //{
                //    sql = "select top 120 * from " + ViewState["tableName"] + " where issue=" + "'" + txt_Condition.Text.Trim().ToString() + "'" + " order by issue desc";
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
