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
using System.Xml;
using Pbzx.Common;
using System.Text;
using System.IO;
using Maticsoft.DBUtility;

namespace Pinble_Wap
{
    public partial class _Default : System.Web.UI.Page
    {
        private void UpdateBind(string cpName)
        {
            string tempValue = cpName + "Value";
            string strtmp = "";
            if (Application[cpName] != null)
            {
                strtmp = Application[cpName].ToString();
            }

//            if (Application[tempValue] == null || Application[cpName] == null || (Application[cpName] != null && Application[cpName].ToString() != "true"))
            if (Application[tempValue] == null || string.IsNullOrEmpty(strtmp) || strtmp != "true")
            {
                Hashtable hatData = new Hashtable();
                string strissue = " issue ";
                string strwhere = "";
                if (cpName == "WeiXin_MoNiTestCode")
                {
                    strissue = " issue3 ";
                    strwhere = " where status = 1 ";
                }
                string strsql = " select top 1 * from " + cpName + strwhere + " order by " + strissue + " desc ";
                DataSet dsAppData = DbHelperSQL1.Query(strsql);
                DataRow row = dsAppData.Tables[0].Rows[0];

                hatData.Add("date", row["date"]);
                if (cpName == "WeiXin_MoNiTestCode")
                {
                    hatData.Add("issue", row["issue3"]);
                }
                else
                {
                    hatData.Add("issue", row["issue"]);
                }
                hatData.Add("lasttime", row["LastModifyTime"]);
                switch (cpName)
                {
                    case "FC3DData":
                        hatData.Add("testcode", row["testcode"]);
                        hatData.Add("code", row["code"]);
                        hatData.Add("decode", row["decode"]);
                        hatData.Add("AttentionCode", row["AttentionCode"]);
                        break;
                    case "WeiXin_MoNiTestCode":
                        hatData.Add("testcode", row["testcode3"]);
                        hatData.Add("code", row["code3"]);
                        hatData.Add("decode", row["decode3"]);
                        hatData.Add("AttentionCode", row["AttentionCode3"]);
                        break;
                    case "TCPL35Data":
                        hatData.Add("code5", row["code5"]);
                        break;
                    case "TC7XCData_New":
                        hatData.Add("code", row["code"]);
                        hatData.Add("tcode", row["tcode"]);
                        break;
                    case "FC7LC":
                        hatData.Add("code", row["code"]);
                        hatData.Add("tcode", row["tcode"]);
                        break;
                    case "FCSSData":
                        hatData.Add("redcode", row["redcode"]);
                        hatData.Add("bluecode", row["bluecode"]);
                        break;
                    case "TCDLTData":
                        hatData.Add("code", row["code"]);
                        hatData.Add("code2", row["code2"]);
                        break;
                    case "FCKL8Data":
                        hatData.Add("code", row["code"]);
                        break;
                }
                Application.Lock();
                Application[tempValue] = hatData;
                Application[cpName] = "true";
                Application.UnLock();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //只能用手机访问
            if (ConfigurationManager.AppSettings["PC-OFF"] == "true")
            {
                int place = Request.ServerVariables["HTTP_ACCEPT"].IndexOf("text/vnd.wap.wml");
                if (place < 0)
                {
                    //Error.aspx提示用户用手机访问   
                    Response.Redirect("Regset.aspx?msg=6", true);
                    return;
                }
            }

            if (Session["User"] != null)
            {
                UserDiv.Visible = true;
                labusername.Text = (Session["User"] as Pbzx.Model.PBnet_tpman).Master_Name;
            }
            else
            {
                UserDiv.Visible = false;
            }

            string strtmp;
            if (!Page.IsPostBack)
            {
                if (Application["WeiXin_MoNiTestCode"] != null)
                {
                    strtmp = Application["WeiXin_MoNiTestCode"].ToString();
                }
                BindData();
            }

        }

        private string Formart5(string code, string type)
        {
            StringBuilder sbResult = new StringBuilder();
            for (int i = 0; i < code.Length; i++)
            {
                if (i == code.Length)
                {
                    sbResult.Append("<span style='" + type + "'>" + code.Substring(i, 1) + "</span>");
                }
                else
                {
                    sbResult.Append("<span style='" + type + "'>" + code.Substring(i, 1) + "</span>");
                }
            }
            return sbResult.ToString();
        }

        private string Formart(string code, string type)
        {
            StringBuilder sbResult = new StringBuilder();
            for (int i = 0; i < code.Length; i++)
            {
                if (i == code.Length)
                {
                    sbResult.Append("<span style='" + type + "'>" + code.Substring(i, 1) + "</span>");
                }
                else
                {
                    sbResult.Append("<span style='" + type + "'>" + code.Substring(i, 1) + "&nbsp;</span>"); // .Substring(i, 1);
                }
            }
            return sbResult.ToString();
        }

        private string Formart(string code, string type, bool isTest)
        {
            StringBuilder sbResult = new StringBuilder();
            for (int i = 0; i < code.Length; i++)
            {
                if (i == code.Length - 1)
                {
                    sbResult.Append("<span style='" + type + "'>" + code.Substring(i, 1) + "</span>");
                }
                else
                {
                    sbResult.Append("<span style='" + type + "'>" + code.Substring(i, 1) + "&nbsp;</span>"); // .Substring(i, 1);
                }
            }

            return sbResult.ToString();
        }

        private string Formart2(string code, string type)
        {
            StringBuilder sbResult = new StringBuilder();
            for (int i = 0; i < code.Length; i += 2)
            {
                if (i < code.Length - 2)
                {
                    sbResult.Append("<span style='" + type + "'>" + code.Substring(i, 2) + "&nbsp;</span>");
                }
                else
                {
                    sbResult.Append("<span style='" + type + "'>" + code.Substring(i, 2) + "</span>");
                }
            }
            return sbResult.ToString();
        }

        private void BindData()
        {

            ///福彩3d/////////////////////f////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            DateTime now = DateTime.Now; // 获取当前时间
            int currentHour = now.Hour; // 获取当前小时
            int currentMinute = now.Minute; // 获取当前分钟

            UpdateBind("FC3DData");
            Hashtable hat3D = (Hashtable)Application["FC3DDataValue"];
            this.lbl3DIssue.Text = hat3D["issue"].ToString();
            string code = hat3D["code"].ToString();
            string strfc3D = hat3D["testcode"].ToString();
            string strfcDY = hat3D["decode"].ToString();
            if (string.IsNullOrEmpty(code) && ConfigurationManager.AppSettings["FirstPageTcodeDisp"] == "0")
            {
                strfc3D = "停发";
                strfcDY = "暂无";
            }
            strfc3D = Formart5(strfc3D, "color:#ff00ff");
            strfcDY = Formart5(strfcDY, "color:Green");
            this.lblTestCode.Text = strfc3D;
            if (string.IsNullOrEmpty(code))
            {
                code = "未开奖";
//                this.lblCode.Visible = false;
                this.lblCode.Visible = true;
                this.lblTestCodeDY.Visible = true;
                this.lblTestCodeDY.Text = "&nbsp;&nbsp;&nbsp;试机号对应码：[<b>" + strfcDY + "</b>]<br />";
                this.lblCode.Text = "<br/>&nbsp;&nbsp;&nbsp;开奖号：[<b>" + Formart5(code, "color:red;") + "</b>]<br />";
            }
            else
            {
                this.lblCode.Visible = true;
                this.lblTestCodeDY.Visible = false;
                this.lblCode.Text = "<br/>&nbsp;&nbsp;&nbsp;开奖号：[<b>" + Formart5(hat3D["code"].ToString(), "color:red;") + "</b>]<br />";
            }
            string AttentionCode = hat3D["AttentionCode"].ToString();
            this.lblCst3dgzm.Text = "" + Formart(AttentionCode.Substring(1, 1), "color:#ff00ff", true) + "<span class='color:#ff00ff'>,</span>" + Formart(AttentionCode.Substring(2, 1), "color:#ff00ff", true) + "";
            this.lblJin.Text = "" + Formart(AttentionCode.Substring(0, 1), "color:Red") + "";
            this.lbl3dTime.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Parse(hat3D["date"].ToString()));
            ///福彩3d///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            ///体彩排列三///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            UpdateBind("WeiXin_MoNiTestCode");
            Hashtable hatpl3 = (Hashtable)Application["WeiXin_MoNiTestCodeValue"];
            this.lblTcpl3Issue.Text = hatpl3["issue"].ToString();
            string code3 = hatpl3["code"].ToString();
            string strtestcode3 = hatpl3["testcode"].ToString();
            string strdecode3 = hatpl3["decode"].ToString();
            if (string.IsNullOrEmpty(code3) && ConfigurationManager.AppSettings["FirstPageTcodeDisp"] == "0")
            {
                strtestcode3 = "停发";
                strdecode3 = "暂无";
            }
            strtestcode3 = Formart5(strtestcode3, "color:#ff00ff");
            strdecode3 = Formart5(strdecode3, "color:Green");
            this.lblTestCode3.Text = strtestcode3;
            if (string.IsNullOrEmpty(code3))
            {
                code3 = "未开奖";
                //                this.lblCode.Visible = false;
                this.lblCode3.Visible = true;
                this.lblTestCodeDY3.Visible = true;
                this.lblTestCodeDY3.Text = "&nbsp;&nbsp;&nbsp;试机号对应码：[<b>" + strdecode3 + "</b>]<br />";
                this.lblCode3.Text = "<br/>&nbsp;&nbsp;&nbsp;开奖号：[<b>" + Formart5(code3, "color:red;") + "</b>]<br />";
            }
            else
            {
                this.lblCode3.Visible = true;
                this.lblTestCodeDY3.Visible = false;
                this.lblCode3.Text = "<br/>&nbsp;&nbsp;&nbsp;开奖号：[<b>" + Formart5(code3, "color:red;") + "</b>]<br />";
            }
            string AttentionCode3 = hatpl3["AttentionCode"].ToString();
            this.lblCstp3gzm.Text = "" + Formart(AttentionCode3.Substring(1, 1), "color:#ff00ff", true) + "<span class='color:#ff00ff'>,</span>" + Formart(AttentionCode3.Substring(2, 1), "color:#ff00ff", true) + "";
            this.lblJin3.Text = "" + Formart(AttentionCode3.Substring(0, 1), "color:Red") + "";
            this.lblPl3Time.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Parse(hatpl3["date"].ToString()));
                      
//            this.lblTcpl3Issue.Text = hatPl5["issue"].ToString();
//            this.lblTcpl3Code.Text = Formart5(hatPl5["code5"].ToString().Substring(0, 3), "color:Red") + "";
//            this.lblPl3Time.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Parse(hatPl5["date"].ToString()));
            ///体彩排列三///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            ///体彩排列五///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            UpdateBind("TCPL35Data");
            Hashtable hatPl5 = (Hashtable)Application["TCPL35DataValue"];
            this.lblTcpl5Issue.Text = hatPl5["issue"].ToString();
            this.lblTcpl5Code.Text = Formart5(hatPl5["code5"].ToString(), "color:Red") + "";
            this.lblPl5Time.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Parse(hatPl5["date"].ToString()));
            ///体彩排列五///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            ///体彩七星彩///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            UpdateBind("TC7XCData_New");
            Hashtable hatTc7XC = (Hashtable)Application["TC7XCData_NewValue"];
            this.lbl7xcIssue.Text = hatTc7XC["issue"].ToString();
            this.lbl7xcCode.Text = Formart5(hatTc7XC["code"].ToString(), "color:Red") + "&nbsp;<span class='zhongred'>+</span>&nbsp;<span style='color:Green'>" + hatTc7XC["tcode"].ToString() + "</span>" + "";
            this.lbl7xTime.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Parse(hatTc7XC["date"].ToString()));
            ///体彩七星彩///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            //福彩七乐彩///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            UpdateBind("FC7LC");
            Hashtable hatFc7lc = (Hashtable)Application["FC7LCValue"];
            this.lbl7lcIssue.Text = hatFc7lc["issue"].ToString();
            this.lbl7lcCode.Text = Formart2(hatFc7lc["code"].ToString(), "color:Red") + "&nbsp;<span class='zhongred'>+</span>&nbsp;<span style='color:Green'>" + hatFc7lc["tcode"].ToString() + "</span>" + "";
            this.lbl7lTime.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Parse(hatFc7lc["date"].ToString()));
            //福彩七乐彩///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            //福彩双色球///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////           

            UpdateBind("FCSSData");
            Hashtable hatSsq = (Hashtable)Application["FCSSDataValue"];
            this.lblSsqIssue.Text = hatSsq["issue"].ToString();
            this.lblSsqCode.Text = Formart2(hatSsq["redcode"].ToString(), "color:Red") + "&nbsp;<span class='zhongred'>+</span>&nbsp;<span style='color:Green'>" + hatSsq["bluecode"].ToString() + "</span>" + "";
            this.lblSsqTime.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Parse(hatSsq["date"].ToString()));
            //福彩双色球///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //体彩大乐透///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////           

            UpdateBind("TCDLTData");
            Hashtable hatDlt = (Hashtable)Application["TCDLTDataValue"];
            this.lblDltIssue.Text = hatDlt["issue"].ToString();
            this.lblDltCode.Text = Formart2(hatDlt["code"].ToString(), "color:Red") + "&nbsp;<span class='zhongred'>+</span>&nbsp;" + Formart2(hatDlt["code2"].ToString(), "color:Green") + "";
            this.lblDltTime.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Parse(hatDlt["date"].ToString()));
            //体彩大乐透///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////           

            //福彩快乐8///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////           
            UpdateBind("FCKL8Data");
            Hashtable hatFCKL8 = (Hashtable)Application["FCKL8DataValue"];
            this.lblKL8Issue.Text = hatFCKL8["issue"].ToString();
            this.lblKL8Code.Text = Formart2(hatFCKL8["code"].ToString(), "color:Red");
            this.lblKL8Time.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Parse(hatFCKL8["date"].ToString()));
            //福彩快乐8///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////           

        }
        /// <summary>
        /// 返回后台页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Manage/List3DManage.aspx");
        }
        /// <summary>
        /// 点击退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkBtnreselt_Click(object sender, EventArgs e)
        {
            Session["User"] = null;
            Session.Clear();
            Response.Redirect("Default.aspx");
        }
    }
}
