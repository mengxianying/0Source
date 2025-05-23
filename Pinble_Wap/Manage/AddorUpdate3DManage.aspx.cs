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
                    //绑定数据
                    FC7LC_add_code_main(true, row["date"], row["issue"]);
                    this.txtIssue.Enabled = false;
                    this.txtDate.Enabled = false;
                    this.btnSave.Text = "修改";
                }
                else
                {
                    FC7LC_add_code_main(false, "", "");
                    this.txtIssue.Enabled = true;
                    this.txtDate.Enabled = true;
                    this.btnSave.Text = "添加";
                }
            }
        }
        /// <summary>
        /// 点击修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {

            Pbzx.BLL.FC3DData FC3DBLL = new Pbzx.BLL.FC3DData();
            string strErrMsg = "";

            //开奖期号非空判断
            if (txtIssue.Text.Trim().Length == 0 || txtIssue.Text.Trim() == "")
            {
                strErrMsg += "开奖期号不能为空!";
            }
            int er = 0;
            if (!int.TryParse(txtIssue.Text.Trim(), out er))
            {
                strErrMsg += "开奖期号存在特殊字符!";
            }
            //开奖日期非空判断
            if (txtDate.Text.Trim() == "" || txtDate.Text.Trim().Length == 0)
            {
                strErrMsg += "开奖日期不能为空!";
            }

            if (this.txtTestcode.Text.Trim().Length < 3)
            {
                strErrMsg += "试机号输入不完整!";
            }

            if (!int.TryParse(this.txtTestcode.Text.Trim(), out er))
            {
                strErrMsg += "试机号存在特殊字符!";
            }

            if (!string.IsNullOrEmpty(this.txtCode.Text))
            {
                if (this.txtCode.Text.Length != 3)
                {
                    strErrMsg += " 开奖号码位数不对!";
                }
                if (!int.TryParse(this.txtCode.Text.Trim(), out er))
                {
                    strErrMsg += " 开奖号码不对!";
                }
            }

            //得到当前时间
            DateTime now = DateTime.Now;

            if (!DateTime.TryParse(this.txtDate.Text, out now))
            {
                strErrMsg += " 开奖日期格式不正确!";
            }

            //得到开奖号码
            string code = this.txtCode.Text;
            //得到开奖期数
            string txtIssues = this.txtIssue.Text;
            //得到基球号
            string AndBall = rblMachineAndBall.SelectedValue;

            //得到试机号
            string Testcode = txtTestcode.Text;


            if (strErrMsg != "")
            {
                labMessage.Text = "(您提交的信息中存在以下错误:" + strErrMsg + " 请修改后再重新提交)";
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
                //给他添加时间赋值
                FC7LCModel.date = DateTime.Parse(this.txtDate.Text);
                //给他期数赋值
                FC7LCModel.issue = this.txtIssue.Text;

                ////得到类型 如 1-1 进行分割
                //string[] mAndB = this.rblMachineAndBall.SelectedValue.Split(new char[] { '-' });
                ////第一位数
                //FC7LCModel.machine = int.Parse(mAndB[0]);
                ////第二位数
                //FC7LCModel.ball = int.Parse(mAndB[1]);

                //开奖号码
                FC7LCModel.code = this.txtCode.Text;

                //试机号
                FC7LCModel.testcode = this.txtTestcode.Text;

                //最后修改时间
                FC7LCModel.LastModifyTime = DateTime.Now;

                //当前IP
                FC7LCModel.OpIp = Request.UserHostAddress;

                //添加的用户
                FC7LCModel.OpName = (Session["User"] as Pbzx.Model.PBnet_tpman).Master_Name;


               

                if (Request.QueryString["issue"] == null)
                {
                    //只有在添加时才使用修改
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
        /// 点击返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClear_Click(object sender, EventArgs e)
        {
            Response.Redirect("List3DManage.aspx");
        }

        #region ------需研究
        /// <summary>
        /// 直接拿来用的！具体作用，代研究中
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
            //最近得一期(可能有奖号，可能没奖号,名称：下一期)
            //DataRow row1 = dtFc3d.Rows[0];

            //倒数第二期（一定有奖号，名称：当前期）
            DataRow row2 = dtFc3d.Rows[0];

            string abc = row2["code"].ToString(); //code
            string jabc = row2["testcode"].ToString();//tcode
            string he = Method.Qhe(abc);
            string jhe = Method.Qhe(jabc);

            string _jhe = Method.Qhe(testcodeNow);
            ///下一期试机号：s(-1,jabc) = row1["testcode"]               
            int a = int.Parse(abc.Substring(0, 1));
            int b = int.Parse(abc.Substring(1, 1));
            int c = int.Parse(abc.Substring(2, 1));
            int[] gsCode = new int[7];

            //公式1：  取一个数整数部门得尾数（（按位加和到位数为1（下一期试机号）） 加+ 按位加和到位数为1（当前期数奖号） ）                                   
            gsCode[0] = Method.END(Method.BSUM(testcodeNow) + Method.BSUM(abc));  //end(bsum(s(-1,jabc),1)+bsum(abc,1))  

            //公式2：
            gsCode[1] = Method.END(10 + Method.BSUM(abc) - Method.BSUM(testcodeNow));//end(10+bsum(abc,1)-bsum(s(-1,jabc),1))

            //公式3：
            ///gsCode[2] = Method.END(10 + Method.BSUM(sjabc) - Method.BSUM(jabc));//end(10+bsum(s(-1,jabc),1)-bsum(jabc,1))

            gsCode[2] = Method.BSUM(Convert.ToString(Method.Qkd(abc) * Method.HW(he) + Method.BSUM(testcodeNow) * 3 - Method.BSUM(jabc) * 2));//BSUM(kd*hw+BSUM(S(-1,JABC),1)*3-BSUM(JABC,1)*2,1)
            //公式4：
            //gsCode[3] = Method.END(Method.BSUM(sjabc) + Method.BSUM(abc) + Method.BSUM(jabc));//end(bsum(s(-1,jabc),1)+bsum(abc,1)+bsum(jabc,1))
            gsCode[3] = Method.END(Method.BSUM(testcodeNow) + Method.BSUM(abc) * 2 + Method.BSUM(jabc) * 3);    // END(BSUM(S(-1,JABC),1)+BSUM(ABC,1)*2+BSUM(JABC,1)*3)		                                                   

            //公式5：
            /// gsCode[4] = Method.END(Method.BSUM(sjhe + Method.Qkd(sjabc)) + Method.BSUM(he + Method.Qkd(abc)) + Method.BSUM(jhe + Method.Qkd(sjabc)));//end(bsum(s(-1,jhe)+s(-1,jkd),1)+bsum(he+kd,1)+bsum(jhe+jkd,1))                               
            gsCode[4] = Method.END(Method.BSUM(Convert.ToString(Convert.ToUInt32(_jhe) + Method.Qkd(testcodeNow))) + Method.BSUM(Convert.ToString(Convert.ToUInt32(he) + Method.Qkd(abc))) + Method.BSUM(Convert.ToString(Convert.ToUInt32(jhe) + Method.Qkd(jabc))));//' end(bsum(s(-1,jhe)+s(-1,jkd),1)+bsum(he+kd,1)+bsum(jhe+jkd,1))
            //公式6:
            //gsCode[5] = Method.BSUM(he + 3 * a + 2 * b + c);//bsum(he+3*A+2*B+c,1)
            gsCode[5] = Method.BSUM(Convert.ToString(Method.Qkd(abc) + 3 * a + 2 * b + c)); // BSUM(KD+3*A+2*B+C,1)

            //公式7:
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

        #region  ---代研究
        /// <summary>
        /// 代研究
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

                //判断是否在休市时间之内start
                if (WapWebInit.web3DBaseConfig.YearStart != "" && WapWebInit.web3DBaseConfig.YearEnd != "")
                {
                    if (Convert.ToDateTime(sdate) >= DateTime.Parse(WapWebInit.web3DBaseConfig.YearStart) && Convert.ToDateTime(sdate) <= DateTime.Parse(WapWebInit.web3DBaseConfig.YearEnd))
                    {
                        sdate = DateTime.Parse(WapWebInit.web3DBaseConfig.YearEnd).AddDays(1).ToShortDateString();//下一期开始时间 
                    }
                }
                //判断是否在休市时间之内end

                if (DateTime.Parse(sdate.ToString()) > DateTime.Now)
                {
                    //Response.Write("<script>alert('最新数据已经录入，请到下期开奖日再来录入新的数据！');history.go(-1);</script>");
                    //Response.End();
                    Response.Redirect("../Regset.aspx?msg=1");
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


            this.rblMachineAndBall.SelectedValue = machine + "-" + ball;

            this.txtTestcode.Text = testcode;
            this.txtCode.Text = code;
        }
        #endregion
    }
}
