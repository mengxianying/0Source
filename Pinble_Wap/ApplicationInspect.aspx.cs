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
using Maticsoft.DBUtility;
using Pbzx.BLL;
using Pbzx.Model;
using Pbzx.Common;

namespace Pinble_Wap
{
    public partial class ApplicationInspect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write("QueryStringPDS=" + Request.QueryString["PDS"] + "<br>");
            //Response.Write("PDS=" + ConfigurationManager.AppSettings["PDS"] + "<br>");
            //Response.Write("QueryStringUDS=" + Request.QueryString["UDS"] + "<br>");
            //Response.Write("UDS=" + ConfigurationManager.AppSettings["UDS"] + "<br>");
            //Response.Write("UserHostAddress=" + ConfigurationManager.AppSettings["IP"] + "<br>");
            //Response.Write("IP=" + Request.UserHostAddress + "<br>");

//            System.Threading.Thread.Sleep(1000); // 延时1秒
//            string Msg = "";

            DateTime dtStart = DateTime.Now;
            TimeSpan tsStart = dtStart.TimeOfDay;
            string cpname = Request.QueryString["cpname"];
            if (!(!string.IsNullOrEmpty(cpname) && Request.QueryString["PDS"] == ConfigurationManager.AppSettings["PDS"] && Request.QueryString["UDS"] == ConfigurationManager.AppSettings["UDS"]))
            {
                Response.Redirect("Default.aspx");
                return;
            }

//            string IPaddress = "";
            string userIP = Request.UserHostAddress;

//            Pbzx.Common.ErrorLog.WriteLogMeng("更新奖号", "cpname:" + cpname + " userIP:" + userIP, true, true);

            //if (!(cpname == "WeiXin_MoNiTestCode"))
            //{
            //    DataSet dsAppData = DbHelperSQL1.Query(" select top 1 * from " + cpname + " order by issue desc ");
            //    IPaddress = dsAppData.Tables[0].Rows[0]["OpIp"].ToString();
            //}
//            Pbzx.Common.ErrorLog.WriteLogMeng("更新奖号", "cpname:" + cpname + " IPaddress:" + IPaddress, true, true);
            if (!(Request.UserHostAddress == ConfigurationManager.AppSettings["IP"] || Request.UserHostAddress == "192.168.0.100" || Request.UserHostAddress == "192.168.0.1"))
            {
                Response.Redirect("Default.aspx");
                return;
            }

//            Pbzx.Common.ErrorLog.WriteLogMeng("更新奖号", "cpname:" + cpname + " IPaddress111:" + IPaddress, true, true);
            if (!string.IsNullOrEmpty(cpname))
            {
                Application.Lock();
                if (cpname == "TCPL35Data")
                {
                    Application["WeiXin_MoNiTestCode"] = "false";
                }
                Application[cpname] = "false";
                Application.UnLock();

                //                string strtmp = Application[cpname].ToString();
                Response.Write("执行IP：" + userIP + "   " + cpname + "更新成功！");
            }
            else
            {
                Response.Write("执行IP：" + Request.UserHostAddress + "   缺少cpname参数未更新！");
            }
            return;

            
            ////当前时间
            //int Hour = DateTime.Now.Hour;

            ////当前星期
            //int xq = Convert.ToInt32(DateTime.Now.DayOfWeek);

            ////得到当前的分钟数
            //int min = DateTime.Now.Minute;

            //string cpname = Request.QueryString["cpname"];
            //#region //------------------------------------------------------------3D福彩
            //Hashtable hat3D = (Hashtable)Application["FC3DDataValue"];
            //if (hat3D == null)
            //{
            //    UpdateBind("FC3DData");
            //}
            //else if (string.IsNullOrEmpty(cpname) || cpname == "FC3DData")
            //{
            //    //更新3D数据
            //    string issue = hat3D["issue"].ToString();
            //    string date = hat3D["date"].ToString();
            //    string code = hat3D["code"].ToString();
            //    string testcode = hat3D["testcode"].ToString();
            //    string decode = hat3D["decode"].ToString();
            //    string attentioncode = hat3D["AttentionCode"].ToString();
            //    string lasttime = hat3D["lasttime"].ToString();
            //    DataRow dar = Binddate("FC3DData");
            //    if (dar != null && (dar["LastModifyTime"].ToString() != lasttime || dar["issue"].ToString() != issue || dar["date"].ToString() != date || dar["code"].ToString() != code || dar["decode"].ToString() != decode || dar["AttentionCode"].ToString() != attentioncode || dar["testcode"].ToString() != testcode))
            //    {
            //        Application.Lock();
            //        hat3D["testcode"] = dar["testcode"].ToString();
            //        hat3D["decode"] = dar["decode"].ToString();
            //        hat3D["lasttime"] = dar["LastModifyTime"].ToString();
            //        hat3D["date"] = dar["date"].ToString();
            //        hat3D["code"] = dar["code"].ToString();
            //        hat3D["issue"] = dar["issue"].ToString();
            //        hat3D["AttentionCode"] = dar["AttentionCode"].ToString();

            //        Application["FC3DDataValue"] = hat3D;
            //        Application.UnLock();
            //        Msg += "3D数据已更新！<br />";
            //    }

            //}
            //#endregion

            //#region//-----------------------------------------------------------------体彩排列三
            //Hashtable hatPl3 = (Hashtable)Application["WeiXin_MoNiTestCodeValue"];

            //if (hatPl3 == null)
            //{
            //    UpdateBind("WeiXin_MoNiTestCode");
            //}
            //else if (string.IsNullOrEmpty(cpname) || cpname == "WeiXin_MoNiTestCode")
            //{
            //    //体彩排列三每天开奖
            //    //得到Application中的最后修改时间
            //    string issue = hatPl3["issue"].ToString();
            //    string date = hatPl3["date"].ToString();
            //    string code = hatPl3["code"].ToString();
            //    string testcode = hatPl3["testcode"].ToString();
            //    string decode = hatPl3["decode"].ToString();
            //    string attentioncode = hatPl3["AttentionCode"].ToString();
            //    string lasttime2 = hatPl3["lasttime"].ToString();

            //    DataRow darpl3 = Binddate("WeiXin_MoNiTestCode");
            //    if (darpl3 != null && (darpl3["LastModifyTime"].ToString() != lasttime2 || darpl3["issue3"].ToString() != issue || darpl3["date"].ToString() != date || darpl3["code3"].ToString() != code || darpl3["decode3"].ToString() != decode || darpl3["AttentionCode3"].ToString() != attentioncode || darpl3["testcode3"].ToString() != testcode))
            //    {
            //        Application.Lock();
            //        hatPl3["lasttime"] = darpl3["LastModifyTime"].ToString();
            //        hatPl3["date"] = darpl3["date"].ToString();
            //        hatPl3["issue"] = darpl3["issue3"].ToString();
            //        hatPl3["testcode"] = darpl3["testcode3"].ToString();
            //        hatPl3["code"] = darpl3["code3"].ToString();
            //        hatPl3["decode"] = darpl3["decode3"].ToString();
            //        hatPl3["AttentionCode"] = darpl3["AttentionCode3"].ToString();
            //        Application["WeiXin_MoNiTestCodeValue"] = hatPl3;
            //        Application.UnLock();
            //        Msg += "体彩排列三数据已更新！<br />";
            //    }
            //}
            //#endregion

            //#region//-----------------------------------------------------------------体彩排列五
            //Hashtable hatPl5 = (Hashtable)Application["TCPL35DataValue"];

            //if (hatPl5 == null)
            //{
            //    UpdateBind("TCPL35Data");
            //}
            //else if (string.IsNullOrEmpty(cpname) || cpname == "TCPL35Data")
            //{
            //    //体彩排列五每天开奖
            //    //得到Application中的最后修改时间
            //    string lasttime2 = hatPl5["lasttime"].ToString();
            //    string date = hatPl5["date"].ToString();
            //    string issue = hatPl5["issue"].ToString();
            //    string code5 = hatPl5["code5"].ToString();
            //    DataRow darpl5 = Binddate("TCPL35Data");
            //    if (darpl5 != null && (darpl5["LastModifyTime"].ToString() != lasttime2 || darpl5["issue"].ToString() != issue || darpl5["date"].ToString() != date || darpl5["code5"].ToString() != code5))
            //    {
            //        Application.Lock();
            //        hatPl5["lasttime"] = darpl5["LastModifyTime"].ToString();
            //        hatPl5["date"] = darpl5["date"].ToString();
            //        hatPl5["issue"] = darpl5["issue"].ToString();
            //        hatPl5["code5"] = darpl5["code5"].ToString();
            //        Application["TCPL35DataValue"] = darpl5;
            //        Application.UnLock();
            //        Msg += "体彩排列五数据已更新！<br />";
            //    }
            //}
            //#endregion

            //#region //----------------------------------------------------------------体彩七星彩
            //Hashtable hatTc7XC = (Hashtable)Application["TC7XCData_NewValue"];

            //if (hatTc7XC == null)
            //{
            //    UpdateBind("TC7XCData_New");
            //}
            //else if (string.IsNullOrEmpty(cpname) || cpname == "TC7XCData_New")
            //{
            //    if (xq == 1 || xq == 5 || xq == 7)
            //    {
            //        //得到Application中的最后修改时间
            //        string date = hatTc7XC["date"].ToString();
            //        string issue = hatTc7XC["issue"].ToString();
            //        string lasttime3 = hatTc7XC["lasttime"].ToString();
            //        string code = hatTc7XC["code"].ToString();
            //        DataRow dar3 = Binddate("TC7XCData_New");
            //        if (dar3 != null && (dar3["LastModifyTime"].ToString() != lasttime3 || dar3["date"].ToString() != date || dar3["issue"].ToString() != issue || dar3["code"].ToString() != code))
            //        {
            //            Application.Lock();
            //            hatTc7XC["lasttime"] = dar3["LastModifyTime"].ToString();
            //            hatTc7XC["date"] = dar3["date"].ToString();
            //            hatTc7XC["issue"] = dar3["issue"].ToString();
            //            hatTc7XC["code"] = dar3["code"].ToString();
            //            hatTc7XC["tcode"] = dar3["tcode"].ToString();
            //            Application["TC7XCData_NewValue"] = hatTc7XC;
            //            Application.UnLock();
            //            Msg += "体彩七星彩数据已更新！<br />";
            //        }
            //    }
            //}
            //#endregion

            //#region //--------------------------------------------------------------福彩七乐彩
            //Hashtable hatFc7lc = (Hashtable)Application["FC7LCValue"];

            //if (hatFc7lc == null)
            //{
            //    UpdateBind("FC7LC");
            //}
            //else if (string.IsNullOrEmpty(cpname) || cpname == "FC7LC")
            //{
            //    //开奖时间 一 三 五
            //    if ((xq == 1 || xq == 3 || xq == 5))
            //    {
            //        string date = hatFc7lc["date"].ToString();
            //        string issue = hatFc7lc["issue"].ToString();
            //        string lasttime4 = hatFc7lc["lasttime"].ToString();
            //        string code = hatFc7lc["code"].ToString();
            //        string tcode = hatFc7lc["tcode"].ToString();
            //        DataRow dar4 = Binddate("FC7LC");
            //        if (dar4 != null && (dar4["LastModifyTime"].ToString() != lasttime4 || dar4["date"].ToString() != date || dar4["issue"].ToString() != issue || dar4["code"].ToString() != code || dar4["tcode"].ToString() != tcode))
            //        {
            //            Application.Lock();
            //            hatFc7lc["lasttime"] = dar4["LastModifyTime"].ToString();
            //            hatFc7lc["date"] = dar4["date"].ToString();
            //            hatFc7lc["issue"] = dar4["issue"].ToString();
            //            hatFc7lc["code"] = dar4["code"].ToString();
            //            hatFc7lc["tcode"] = dar4["tcode"].ToString();
            //            Application["FC7LCValue"] = hatFc7lc;
            //            Application.UnLock();
            //            Msg += "福彩七乐彩数据已更新！<br />";
            //        }
            //    }
            //}

            //#endregion

            //#region //-------------------------------------------------------------福彩双色球
            //Hashtable hatSsq = (Hashtable)Application["FCSSDataValue"];


            //if (hatSsq == null)
            //{
            //    UpdateBind("FCSSData");
            //}
            //else if (string.IsNullOrEmpty(cpname) || cpname == "FCSSData")
            //{
            //    //开奖时间 二 四 日
            //    if ((xq == 2 || xq == 4 || xq == 7))
            //    {
            //        //得到Application中的最后修改时间
            //        string date = hatSsq["date"].ToString();
            //        string issue = hatSsq["issue"].ToString();
            //        string lasttime5 = hatSsq["lasttime"].ToString();
            //        string redcode = hatSsq["redcode"].ToString();
            //        string bluecode = hatSsq["bluecode"].ToString();
            //        DataRow dar5 = Binddate("FCSSData");
            //        if (dar5 != null && (dar5["LastModifyTime"].ToString() != lasttime5 || dar5["date"].ToString() != date || dar5["issue"].ToString() != issue || dar5["redcode"].ToString() != redcode || dar5["bluecode"].ToString() != bluecode))
            //        {
            //            Application.Lock();
            //            hatSsq["lasttime"] = dar5["LastModifyTime"].ToString();
            //            hatSsq["date"] = dar5["date"].ToString();
            //            hatSsq["issue"] = dar5["issue"].ToString();
            //            hatSsq["redcode"] = dar5["redcode"].ToString();
            //            hatSsq["bluecode"] = dar5["bluecode"].ToString();
            //            Application["FCSSDataValue"] = hatSsq;
            //            Application.UnLock();
            //            Msg += "福彩双色球数据已更新！<br />";
            //        }
            //    }
            //}

            //#endregion

            //#region //---------------------------------------------------------------体彩大乐透
            //Hashtable hatDlt = (Hashtable)Application["TCDLTDataValue"];
            //if (hatDlt == null)
            //{
            //    UpdateBind("TCDLTData");
            //}
            //else if (string.IsNullOrEmpty(cpname) || cpname == "TCDLTData")
            //{
            //    //开奖时间一 三 六
            //    if ((xq == 1 || xq == 3 || xq == 6))
            //    {
            //        //得到Application中的最后修改时间
            //        string date = hatDlt["date"].ToString();
            //        string issue = hatDlt["issue"].ToString();
            //        string lasttime6 = hatDlt["lasttime"].ToString();
            //        string code = hatDlt["code"].ToString();
            //        string code2 = hatDlt["code2"].ToString();
            //        DataRow dar6 = Binddate("TCDLTData");
            //        if (dar6 != null && (dar6["LastModifyTime"].ToString() != lasttime6 || dar6["date"].ToString() != date || dar6["issue"].ToString() != issue || dar6["code"].ToString() != code || dar6["code2"].ToString() != code2))
            //        {
            //            Application.Lock();
            //            hatDlt["lasttime"] = dar6["LastModifyTime"].ToString();
            //            hatDlt["date"] = dar6["date"].ToString();
            //            hatDlt["issue"] = dar6["issue"].ToString();
            //            hatDlt["code"] = dar6["code"].ToString();
            //            hatDlt["code2"] = dar6["code2"].ToString();
            //            Application["TCDLTDataValue"] = hatDlt;
            //            Application.UnLock();
            //            Msg += "体彩大乐透数据已更新！<br />";
            //        }
            //    }
            //}
            //#endregion

            //#region //---------------------------------------------------------------福彩快乐8
            //Hashtable hatKl8 = (Hashtable)Application["FCKL8DataValue"];
            //if (hatKl8 == null)
            //{
            //    UpdateBind("FCKL8Data");
            //}
            //else if (string.IsNullOrEmpty(cpname) || cpname == "FCKL8Data")
            //{
            //    //得到Application中的最后修改时间
            //    string date = hatKl8["date"].ToString();
            //    string issue = hatKl8["issue"].ToString();
            //    string lasttime20 = hatKl8["lasttime"].ToString();
            //    string code = hatKl8["code"].ToString();
            //    DataRow dar20 = Binddate("FCKL8Data");
            //    if (dar20 != null && (dar20["LastModifyTime"].ToString() != lasttime20 || dar20["date"].ToString() != date || dar20["issue"].ToString() != issue || dar20["code"].ToString() != code))
            //    {
            //        Application.Lock();
            //        hatKl8["lasttime"] = dar20["LastModifyTime"].ToString();
            //        hatKl8["date"] = dar20["date"].ToString();
            //        hatKl8["issue"] = dar20["issue"].ToString();
            //        hatKl8["code"] = dar20["code"].ToString();
            //        Application["FCKL8DataValue"] = hatKl8;
            //        Application.UnLock();
            //        Msg += "福彩快乐8数据已更新！<br />";
            //    }
            //}
            //#endregion

            //if (Msg == "")
            //{
            //    Msg = "无任何数据更新！<br/>";
            //}
            //Response.Write("<a href='http://www.pinble.com/refresh'>refresh</a><br/>");
            //Response.Write("≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡<br/>");
            //Response.Write(Msg.ToString());
            //Response.Write("≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡<br/>");
            //DateTime dtEnd = DateTime.Now;
            //TimeSpan tsJG = dtEnd - dtStart;
            //Response.Write("【" + Math.Floor(tsJG.TotalSeconds) + "秒】" + dtStart + " - " + dtEnd + " ");

        }


        #region 单条数据获取
        private DataRow Binddate(string cpName)
        {
            string strissue = " issue ";
            string strwhere = "";
            if (cpName == "WeiXin_MoNiTestCode")
            {
                strissue = " issue3 ";
                strwhere = " where status = 1 ";
            }

            DataSet dsAppData = DbHelperSQL1.Query(" select top 1 * from " + cpName + strwhere + " order by " + strissue + " desc ");
            DataRow row = dsAppData.Tables[0].Rows[0];
            return row;
        }
        #endregion

        #region 数据获取公用方法
        private void UpdateBind(string cpName)
        {
            string tempValue = cpName + "Value";
            string strissue = " issue ";
            string strwhere = "";
            if (cpName == "WeiXin_MoNiTestCode")
            {
                strissue = " issue3 ";
                strwhere = " where status = 1 ";
            }
            if (Application[tempValue] == null || Application[cpName] == null || !(Application[cpName] != null && Application[cpName].ToString() == "true"))
            {
                Application.Lock();
                Hashtable hatData = new Hashtable();

                DataSet dsAppData = DbHelperSQL1.Query(" select top 1 * from " + cpName + strwhere + " order by " + strissue + " desc ");
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
                Application[tempValue] = hatData;
                Application[cpName] = "true";
                Application.UnLock();
            }
        }
        #endregion
    }
}
