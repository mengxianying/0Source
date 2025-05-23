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
using Pbzx.Web.PB_Manage;
using System.Text;
using System.IO;
using Maticsoft.DBUtility;

namespace Pbzx.Web
{
    public partial class QGKJ : System.Web.UI.Page
    {

        private void UpdateApplication(string cpName)
        {
            string tempValue = cpName + "Value";
            if (Application[tempValue] == null || Application[cpName] == null || !(Application[cpName] != null && Application[cpName].ToString() == "true"))
            {
                DataSet dsAppData = DbHelperSQL1.Query(" select top 1 * from  " + cpName + " order by issue desc ");
                DataRow row = dsAppData.Tables[0].Rows[0];
                Hashtable hatData = new Hashtable();
                hatData.Add("date", row["date"]);
                hatData.Add("issue", row["issue"]);
                switch (cpName)
                {
                    case "FC3DData":
                        hatData.Add("testcode", row["testcode"]);
                        hatData.Add("code", row["code"]);
                        hatData.Add("machine", row["machine"]);
                        hatData.Add("ball", row["ball"]);
                        hatData.Add("decode", row["decode"]);
                        hatData.Add("AttentionCode", row["AttentionCode"]);
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
                    //case "TC22X5Data":
                    //    hatData.Add("code", row["code"]);
                    //    break;
                    //case "TC31X7Data":
                    //    hatData.Add("code", row["code"]);
                    //    hatData.Add("tcode", row["tcode"]);
                    //    break;
                }

                Application.Lock();
                Pbzx.Common.ErrorLog.WriteLogMeng("Application更新", "Application['" + cpName + "']发生改变", true, true);
                Application[tempValue] = hatData;
                Application[cpName] = "true";
                Application.UnLock();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
//            if (Request.UrlReferrer == null || !(Request.UrlReferrer.Host == "pinble.com" || Request.UrlReferrer.Host == ConfigurationManager.AppSettings["HostName"]))
            if ((Request.UrlReferrer == null && !Page.IsPostBack) || (Request.UrlReferrer != null && (!Request.UrlReferrer.Host.ToLower().Contains("pinble.com") || !ConfigurationManager.AppSettings["HostName"].Contains(Request.UrlReferrer.Host.ToLower()))))
            {
                Response.Write("<script>top.location ='/';</script>");
                Response.End();
                return;
            }
            if (!Page.IsPostBack)
            {
                BindData();
            }

        }
        protected string GetPar(string type)
        {
            return Input.Encrypt(type);
        }

        private string Formart5(string code, string type)
        {
            StringBuilder sbResult = new StringBuilder();
            for (int i = 0; i < code.Length; i++)
            {
                if (i == code.Length)
                {
                    sbResult.Append("<span class='" + type + "'>" + code.Substring(i, 1) + "</span>");
                }
                else
                {
                    sbResult.Append("<span class='" + type + "'>" + code.Substring(i, 1) + "</span>"); // .Substring(i, 1);
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
                    sbResult.Append("<span class='" + type + "'>" + code.Substring(i, 1) + "</span>");
                }
                else
                {
                    sbResult.Append("<span class='" + type + "'>" + code.Substring(i, 1) + "&nbsp;</span>"); // .Substring(i, 1);
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
                    sbResult.Append("<span class='" + type + "'>" + code.Substring(i, 1) + "</span>");
                }
                else
                {
                    sbResult.Append("<span class='" + type + "'>" + code.Substring(i, 1) + "&nbsp;</span>"); // .Substring(i, 1);
                }
            }
            return sbResult.ToString();
        }
        //private string Formart2(string code, string type, bool isTest)
        //{
        //    StringBuilder sbResult = new StringBuilder();
        //    for (int i = 0; i < code.Length; i += 2)
        //    {
        //        if (i == code.Length - 2)
        //        {
        //            sbResult.Append("<span class='" + type + "'>" + code.Substring(i, 2) + "</span>"); // .Substring(i, 1);
        //        }
        //        else
        //        {
        //            sbResult.Append("<span class='" + type + "'>" + code.Substring(i, 2) + "&nbsp;</span>");
        //        }
        //    }
        //    return sbResult.ToString();
        //}
        private string Formart2(string code, string type)
        {
            StringBuilder sbResult = new StringBuilder();
            for (int i = 0; i < code.Length; i += 2)
            {
                if (i < code.Length - 2)
                {
                    sbResult.Append("<span class='" + type + "'>" + code.Substring(i, 2) + "&nbsp;</span>");
                }
                else
                {
                    sbResult.Append("<span class='" + type + "'>" + code.Substring(i, 2) + "</span>");
                }
            }
            return sbResult.ToString();
        }
        private void BindData()
        {

            ///福彩3d/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            UpdateApplication("FC3DData");
            Hashtable hat3D = (Hashtable)Application["FC3DDataValue"];
            this.lbl3DIssue.Text = hat3D["issue"].ToString();
            this.lblMachine.Text = hat3D["machine"].ToString();
            this.lblBall.Text = hat3D["ball"].ToString();
            string strfc3D = Formart5(hat3D["testcode"].ToString(), "zhong3");
            this.lblTestCode.Text = strfc3D;
            string code = hat3D["code"].ToString();
            if (string.IsNullOrEmpty(code))
            {
                this.lblCode.Visible = false;
                this.lblTestCodeDY.Visible = true;
                string strfcDY = Formart5(hat3D["decode"].ToString(), "zhong2");
                this.lblTestCodeDY.Text = "&nbsp;&nbsp;&nbsp;试机号对应码：[" + strfcDY + "]<br />";
            }
            else
            {
                this.lblCode.Visible = true;
                this.lblTestCodeDY.Visible = false;
                this.lblCode.Text = "&nbsp;&nbsp;&nbsp;开奖号：[" + Formart5(hat3D["code"].ToString(), "zhong1") + "]<br />";
            }
            string AttentionCode = hat3D["AttentionCode"].ToString();
            this.lblCstHL1_2.Text = "" + Formart(AttentionCode.Substring(1, 1), "zhong3", true) + "<span class='zhong3'>,</span>" + Formart(AttentionCode.Substring(2, 1), "zhong3", true) + "";
            this.lblJin.Text = "" + Formart(AttentionCode.Substring(0, 1), "zhong1") + "";
            this.lbl3dTime.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Parse(hat3D["date"].ToString()));
            ///福彩3d///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            ///体彩排列五///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            UpdateApplication("TCPL35Data");
            Hashtable hatPl5 = (Hashtable)Application["TCPL35DataValue"];
            this.lblTcpl5Issue.Text = hatPl5["issue"].ToString();
            this.lblTcpl5Code.Text = Formart5(hatPl5["code5"].ToString(), "zhong1") + "";
            this.lblPl5Time.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Parse(hatPl5["date"].ToString()));
            ///体彩排列五///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///体彩排列三
            this.lblTcpl3Issue.Text = hatPl5["issue"].ToString();
            this.lblTcpl3Code.Text = Formart5(hatPl5["code5"].ToString().Substring(0,3), "zhong1") + "";
            this.lblPl3Time.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Parse(hatPl5["date"].ToString()));
            ///end
           


            ///体彩七星彩///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            UpdateApplication("TC7XCData_New");
            Hashtable hatTc7XC = (Hashtable)Application["TC7XCData_NewValue"];
            this.lbl7xcIssue.Text = hatTc7XC["issue"].ToString();
            this.lbl7xcCode.Text = Formart5(hatTc7XC["code"].ToString(), "zhong1") + "&nbsp;<span class='zhongred'>+</span>&nbsp;<span class='zhong2'>" + hatTc7XC["tcode"].ToString() + "</span>" + "";
            this.lbl7xTime.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Parse(hatTc7XC["date"].ToString()));
            ///体彩七星彩///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            //福彩七乐彩///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            UpdateApplication("FC7LC");
            Hashtable hatFc7lc = (Hashtable)Application["FC7LCValue"];
            this.lbl7lcIssue.Text = hatFc7lc["issue"].ToString();
            this.lbl7lcCode.Text = Formart2(hatFc7lc["code"].ToString(), "zhong1") + "&nbsp;<span class='zhongred'>+</span>&nbsp;<span class='zhong2'>" + hatFc7lc["tcode"].ToString() + "</span>" + "";
            this.lbl7lTime.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Parse(hatFc7lc["date"].ToString()));
            //福彩七乐彩///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            //福彩双色球///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////           
            UpdateApplication("FCSSData");
            Hashtable hatSsq = (Hashtable)Application["FCSSDataValue"];
            this.lblSsqIssue.Text = hatSsq["issue"].ToString();
            this.lblSsqCode.Text = Formart2(hatSsq["redcode"].ToString(), "zhong1") + "&nbsp;<span class='zhongred'>+</span>&nbsp;<span class='zhong2'>" + hatSsq["bluecode"].ToString() + "</span>" + "";
            this.lblSsqTime.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Parse(hatSsq["date"].ToString()));
            //福彩双色球///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //体彩大乐透///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////           
            UpdateApplication("TCDLTData");
            Hashtable hatDlt = (Hashtable)Application["TCDLTDataValue"];
            this.lblDltIssue.Text = hatDlt["issue"].ToString();
            this.lblDltCode.Text = Formart2(hatDlt["code"].ToString(), "zhong1") + "&nbsp;<span class='zhongred'>+</span>&nbsp;" + Formart2(hatDlt["code2"].ToString(), "zhong2") + "";
            this.lblDltTime.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Parse(hatDlt["date"].ToString()));
            //体彩大乐透///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////           

            //体彩22选5///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////           
            UpdateApplication("TC22X5Data");
            Hashtable hatTc22X5 = (Hashtable)Application["TC22X5DataValue"];
            this.lbl22x5Issue.Text = hatTc22X5["issue"].ToString();
            this.lbl22x5Code.Text = Formart2(hatTc22X5["code"].ToString(), "zhong1");
            this.lbl22x5Time.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Parse(hatTc22X5["date"].ToString()));
            //体彩22选5///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////           

            //体彩31选7///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////           
            //UpdateApplication("TC31X7Data");
            //Hashtable hatTc31x7 = (Hashtable)Application["TC31X7DataValue"];
            //this.lbl31x7Issue.Text = hatTc31x7["issue"].ToString();
            //this.lbl31x7Code.Text = Formart2(hatTc31x7["code"].ToString(), "zhong1") + "&nbsp;<span class='zhongred'>+</span>&nbsp;<span class='zhong2'>" + hatTc31x7["tcode"].ToString() + "</span>" + "";
            //this.lbl31x7Time.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Parse(hatTc31x7["date"].ToString()));
            //体彩31选7///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////           
        }


        protected void imgSX_Click(object sender, ImageClickEventArgs e)
        {

            if (Request.Cookies["userIP"] == null)
            {
                Response.Cookies.Add(new HttpCookie("userIP", Request.UserHostAddress + "&" + DateTime.Now.ToString() + "&0"));
            }
            else
            {
                string[] parms = Request.Cookies["userIP"].Value.Split(new char[] { '&' });
                if (DateTime.Parse(parms[1]).AddMinutes(0.5) > DateTime.Now)
                {
                    ClientScript.RegisterStartupScript(GetType(), "shuaxin", "alert('您得刷新过于频繁，禁止操作！');history.back();", true);
                    return;
                }
                else
                {
                    int tempInt = int.Parse(parms[2]);
                    tempInt++;
                    Request.Cookies["userIP"].Expires = DateTime.Now.AddMinutes(-1);
                    Response.Cookies.Add(new HttpCookie("userIP", Request.UserHostAddress + "&" + DateTime.Now.ToString() + "&" + Convert.ToString(tempInt)));
                }
            }
            Server.Transfer("QGKJ.aspx");
        }
    }
}
