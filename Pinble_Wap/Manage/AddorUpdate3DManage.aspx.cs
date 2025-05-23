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

namespace Pinble_Wap.Manage
{
    public partial class AddorUpdate3DManage : System.Web.UI.Page
    {
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic();

        protected void Page_Load(object sender, EventArgs e)
        {
            basicDAL.IsCst = true;

            if (Session["User"] == null)
            {
                Response.Redirect("../UserLogin.aspx");
                return;
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["issue"] != null)
                {
                    DataRow row = basicDAL.GetRowBySql("select * from FC3DData where issue='" + Request.QueryString["issue"] + "'");
                    //������
                    FC7LC_add_code_main(true, row["date"], row["issue"]);
                    this.txtIssue.Enabled = false;
                    this.txtDate.Enabled = false;
                    this.btnSave.Text = "�޸�";
                }
                else
                {
                    FC7LC_add_code_main(false, "", "");
                    this.txtIssue.Enabled = true;
                    this.txtDate.Enabled = true;
                    this.btnSave.Text = "���";
                }
            }
        }
        /// <summary>
        /// ����޸�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {

            Pbzx.BLL.FC3DData FC3DBLL = new Pbzx.BLL.FC3DData();
            string strErrMsg = "";

            //�����ںŷǿ��ж�
            if (txtIssue.Text.Trim().Length == 0 || txtIssue.Text.Trim() == "")
            {
                strErrMsg += "�����ںŲ���Ϊ��!";
            }
            int er = 0;
            if (!int.TryParse(txtIssue.Text.Trim(), out er))
            {
                strErrMsg += "�����ںŴ��������ַ�!";
            }
            //�������ڷǿ��ж�
            if (txtDate.Text.Trim() == "" || txtDate.Text.Trim().Length == 0)
            {
                strErrMsg += "�������ڲ���Ϊ��!";
            }

            if (this.txtTestcode.Text.Trim().Length < 3)
            {
                strErrMsg += "�Ի������벻����!";
            }

            if (!int.TryParse(this.txtTestcode.Text.Trim(), out er))
            {
                strErrMsg += "�Ի��Ŵ��������ַ�!";
            }

            if (!string.IsNullOrEmpty(this.txtCode.Text))
            {
                if (this.txtCode.Text.Length != 3)
                {
                    strErrMsg += " ��������λ������!";
                }
                if (!int.TryParse(this.txtCode.Text.Trim(), out er))
                {
                    strErrMsg += " �������벻��!";
                }
            }

            //�õ���ǰʱ��
            DateTime now = DateTime.Now;

            if (!DateTime.TryParse(this.txtDate.Text, out now))
            {
                strErrMsg += " �������ڸ�ʽ����ȷ!";
            }

            //�õ���������
            string code = this.txtCode.Text;
            //�õ���������
            string txtIssues = this.txtIssue.Text;
            //�õ������
            string AndBall = rblMachineAndBall.SelectedValue;

            //�õ��Ի���
            string Testcode = txtTestcode.Text;


            if (strErrMsg != "")
            {
                labMessage.Text = "(���ύ����Ϣ�д������´���:" + strErrMsg + " ���޸ĺ��������ύ)";
                return;
            }
            else
            {

                Pbzx.Model.FC3DData FC7LCModel = null;
                if (Request.QueryString["issue"] == null)
                {
                    FC7LCModel = new Pbzx.Model.FC3DData();
                }
                else
                {
                    FC7LCModel = FC3DBLL.GetModel(Request.QueryString["issue"]);
                }
                //�������ʱ�丳ֵ
                FC7LCModel.date = DateTime.Parse(this.txtDate.Text);
                //����������ֵ
                FC7LCModel.issue = this.txtIssue.Text;

                ////�õ����� �� 1-1 ���зָ�
                //string[] mAndB = this.rblMachineAndBall.SelectedValue.Split(new char[] { '-' });
                ////��һλ��
                //FC7LCModel.machine = int.Parse(mAndB[0]);
                ////�ڶ�λ��
                //FC7LCModel.ball = int.Parse(mAndB[1]);

                //��������
                FC7LCModel.code = this.txtCode.Text;

                //�Ի���
                FC7LCModel.testcode = this.txtTestcode.Text;

                //����޸�ʱ��
                FC7LCModel.LastModifyTime = DateTime.Now;

                //��ǰIP
                FC7LCModel.OpIp = Request.UserHostAddress;

                //��ӵ��û�
                FC7LCModel.OpName = (Session["User"] as Pbzx.Model.PBnet_tpman).Master_Name;


               

                if (Request.QueryString["issue"] == null)
                {
                    //ֻ�������ʱ��ʹ���޸�
                    string[] tsCodeDe = CalGZM(this.txtTestcode.Text);
                    FC7LCModel.AttentionCode = tsCodeDe[0] + tsCodeDe[1] + tsCodeDe[2];
                    FC7LCModel.decode = tsCodeDe[3];

                    if (FC3DBLL.Add(FC7LCModel))
                    {
                        Response.Redirect("../Regset.aspx?msg=4");
                    }
                    else
                    {
                        Response.Redirect("../Regset.aspx?msg=3");
                        return;
                    }
                }
                else
                {

                    if (FC3DBLL.Update(FC7LCModel))
                    {
                        Response.Redirect("../Regset.aspx?msg=5");
                    }
                    else
                    {
                        Response.Redirect("../Regset.aspx?msg=2");
                        return;
                    }
                }
            }
            Response.Redirect("List3DManage.aspx");
        }
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClear_Click(object sender, EventArgs e)
        {
            Response.Redirect("List3DManage.aspx");
        }

        #region ------���о�
        /// <summary>
        /// ֱ�������õģ��������ã����о���
        /// </summary>
        /// <param name="testcodeNow"></param>
        /// <returns></returns>
        public static string[] CalGZM(string testcodeNow)
        {
            string cstJin = "";
            string HL1 = "";
            string HL2 = "";
            string deTestCode = "";
            DataTable dtFc3d = DbHelperSQL1.Query("select top 1 issue,code,testcode  from FC3DData where code is not null and code!=''  order by issue desc").Tables[0];
            //�����һ��(�����н��ţ�����û����,���ƣ���һ��)
            //DataRow row1 = dtFc3d.Rows[0];

            //�����ڶ��ڣ�һ���н��ţ����ƣ���ǰ�ڣ�
            DataRow row2 = dtFc3d.Rows[0];

            string abc = row2["code"].ToString(); //code
            string jabc = row2["testcode"].ToString();//tcode
            string he = Method.Qhe(abc);
            string jhe = Method.Qhe(jabc);

            string _jhe = Method.Qhe(testcodeNow);
            ///��һ���Ի��ţ�s(-1,jabc) = row1["testcode"]               
            int a = int.Parse(abc.Substring(0, 1));
            int b = int.Parse(abc.Substring(1, 1));
            int c = int.Parse(abc.Substring(2, 1));
            int[] gsCode = new int[7];

            //��ʽ1��  ȡһ�����������ŵ�β��������λ�Ӻ͵�λ��Ϊ1����һ���Ի��ţ��� ��+ ��λ�Ӻ͵�λ��Ϊ1����ǰ�������ţ� ��                                   
            gsCode[0] = Method.END(Method.BSUM(testcodeNow) + Method.BSUM(abc));  //end(bsum(s(-1,jabc),1)+bsum(abc,1))  

            //��ʽ2��
            gsCode[1] = Method.END(10 + Method.BSUM(abc) - Method.BSUM(testcodeNow));//end(10+bsum(abc,1)-bsum(s(-1,jabc),1))

            //��ʽ3��
            ///gsCode[2] = Method.END(10 + Method.BSUM(sjabc) - Method.BSUM(jabc));//end(10+bsum(s(-1,jabc),1)-bsum(jabc,1))

            gsCode[2] = Method.BSUM(Convert.ToString(Method.Qkd(abc) * Method.HW(he) + Method.BSUM(testcodeNow) * 3 - Method.BSUM(jabc) * 2));//BSUM(kd*hw+BSUM(S(-1,JABC),1)*3-BSUM(JABC,1)*2,1)
            //��ʽ4��
            //gsCode[3] = Method.END(Method.BSUM(sjabc) + Method.BSUM(abc) + Method.BSUM(jabc));//end(bsum(s(-1,jabc),1)+bsum(abc,1)+bsum(jabc,1))
            gsCode[3] = Method.END(Method.BSUM(testcodeNow) + Method.BSUM(abc) * 2 + Method.BSUM(jabc) * 3);    // END(BSUM(S(-1,JABC),1)+BSUM(ABC,1)*2+BSUM(JABC,1)*3)		                                                   

            //��ʽ5��
            /// gsCode[4] = Method.END(Method.BSUM(sjhe + Method.Qkd(sjabc)) + Method.BSUM(he + Method.Qkd(abc)) + Method.BSUM(jhe + Method.Qkd(sjabc)));//end(bsum(s(-1,jhe)+s(-1,jkd),1)+bsum(he+kd,1)+bsum(jhe+jkd,1))                               
            gsCode[4] = Method.END(Method.BSUM(Convert.ToString(Convert.ToUInt32(_jhe) + Method.Qkd(testcodeNow))) + Method.BSUM(Convert.ToString(Convert.ToUInt32(he) + Method.Qkd(abc))) + Method.BSUM(Convert.ToString(Convert.ToUInt32(jhe) + Method.Qkd(jabc))));//' end(bsum(s(-1,jhe)+s(-1,jkd),1)+bsum(he+kd,1)+bsum(jhe+jkd,1))
            //��ʽ6:
            //gsCode[5] = Method.BSUM(he + 3 * a + 2 * b + c);//bsum(he+3*A+2*B+c,1)
            gsCode[5] = Method.BSUM(Convert.ToString(Method.Qkd(abc) + 3 * a + 2 * b + c)); // BSUM(KD+3*A+2*B+C,1)

            //��ʽ7:
            //gsCode[6] = Method.BSUM(he + a + 2 * b + 3 * c);//bsum(he+A+2*B+3*c,1)
            gsCode[6] = Method.BSUM(Convert.ToString(Convert.ToUInt32(he) + 2 * Method.Qkd(abc) + 3 * Method.HW(he)));              //BSUM(HE+2*KD+3*HW,1)

            int[] codeCount = new int[7];
            for (int i = 0; i < codeCount.Length; i++)
            {
                codeCount[i] = 0;
            }
            string[] Result = new string[7];
            SortedList sortCode = new SortedList();
            ArrayList arrCount = new ArrayList();
            for (int i = 0; i < gsCode.Length; i++)
            {
                for (int j = 0; j < gsCode.Length; j++)
                {
                    if (gsCode[i] == gsCode[j])
                    {
                        codeCount[i]++;
                    }
                }
                if (!sortCode.ContainsKey(codeCount[i] + "" + gsCode[i]))
                {
                    sortCode.Add(codeCount[i] + "" + gsCode[i], gsCode[i]);
                    arrCount.Add(codeCount[i] + "" + (7 - i) + "" + gsCode[i]);
                }
            }
            arrCount.Sort();
            cstJin = arrCount[arrCount.Count - 1].ToString().Substring(2, 1);
            HL1 = arrCount[arrCount.Count - 2].ToString().Substring(2, 1);
            HL2 = arrCount[arrCount.Count - 3].ToString().Substring(2, 1);
            char[] charSZ = testcodeNow.ToCharArray();
            Array.Sort(charSZ);
            string row1Code = new string(charSZ);
            object objDe = DbHelperSQL1.GetSingle("select top 1 decode from FC3DTest_Code where code='" + row1Code + "' ");
            if (objDe != null)
            {
                deTestCode = objDe.ToString();
            }
            string[] strRetrun = new string[4];
            strRetrun[0] = cstJin;
            strRetrun[1] = HL1;
            strRetrun[2] = HL2;
            strRetrun[3] = deTestCode;
            return strRetrun;
        }
        #endregion

        #region  ---���о�
        /// <summary>
        /// ���о�
        /// </summary>
        /// <param name="bModify"></param>
        /// <param name="sdate"></param>
        /// <param name="sissue"></param>
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

                //�ж��Ƿ�������ʱ��֮��start
                if (WapWebInit.web3DBaseConfig.YearStart != "" && WapWebInit.web3DBaseConfig.YearEnd != "")
                {
                    if (Convert.ToDateTime(sdate) >= DateTime.Parse(WapWebInit.web3DBaseConfig.YearStart) && Convert.ToDateTime(sdate) <= DateTime.Parse(WapWebInit.web3DBaseConfig.YearEnd))
                    {
                        sdate = DateTime.Parse(WapWebInit.web3DBaseConfig.YearEnd).AddDays(1).ToShortDateString();//��һ�ڿ�ʼʱ�� 
                    }
                }
                //�ж��Ƿ�������ʱ��֮��end

                if (DateTime.Parse(sdate.ToString()) > DateTime.Now)
                {
                    //Response.Write("<script>alert('���������Ѿ�¼�룬�뵽���ڿ���������¼���µ����ݣ�');history.go(-1);</script>");
                    //Response.End();
                    Response.Redirect("../Regset.aspx?msg=1");
                    return;
                }
                //���괦�� 
                if (DateTime.Parse(sdate.ToString()).Year.ToString() != sissue.ToString().Substring(0, 4))
                {
                    sissue = DateTime.Now.Year + "001";
                }
                machine = "1";
                ball = "1";
                testcode = "";
                code = "";
                ViewState["hide"] = "0";
                this.btnSave.Text = "���";
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
                this.btnSave.Text = "�޸�";
            }
            this.txtDate.Text = DateTime.Parse(sdate.ToString()).ToShortDateString();
            this.txtIssue.Text = sissue.ToString();


            this.rblMachineAndBall.SelectedValue = machine + "-" + ball;

            this.txtTestcode.Text = testcode;
            this.txtCode.Text = code;
        }
        #endregion
    }
}
