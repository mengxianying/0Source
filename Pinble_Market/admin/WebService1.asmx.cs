using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using Pbzx.BLL;
using Pbzx.Model;
using System.Text;
using System.Web.UI;
using Maticsoft.DBUtility;

namespace Pinble_Market.admin
{
    /// <summary>
    /// WebService1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        /// <summary>
        /// 带参数
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="value3"></param>
        /// <param name="value4"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetWish(string value1)
        {
            //根据项目的ID来查询 彩种名称和彩种类型
            Pbzx.BLL.Market_Page page = new Pbzx.BLL.Market_Page();
            DataSet ds = page.Market_GetItme("NvarName,TypeName", "appendID=" + Convert.ToInt32(value1));
            //查询项目是否能发布收费项目
            DataSet get_ds = page.Market_GetNum("Charge", "appendID=" + Convert.ToInt32(value1));
            //charge==1 收费项目
            if (Convert.ToInt32(get_ds.Tables[0].Rows[0]["Charge"]) == 1)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0][0].ToString() + "&" + ds.Tables[0].Rows[0][1].ToString() + "|" + "NoCue";
                }
                else
                {
                    return null;
                }
            }
            else
            {
                DataSet dt = page.Market_GetNum("top 10 ExpectNum", "appendID=" + Convert.ToInt32(value1) + " order by ExpectNum desc");
                string str = "No";
                if (dt.Tables[0].Rows.Count >= 10)
                {
                    if (Convert.ToInt32(dt.Tables[0].Rows[0]["ExpectNum"]) - Convert.ToInt32(dt.Tables[0].Rows[9]["ExpectNum"]) == 9)
                    {
                        str = "Cue";
                    }
                    else
                    {
                        if (Convert.ToInt32(dt.Tables[0].Rows[0]["ExpectNum"]) - Convert.ToInt32(dt.Tables[0].Rows[9]["ExpectNum"]) > 9)
                        {
                            str = "CueNoSeries";
                        }
                        else
                        {
                            str = "NoCue";
                        }
                    }
                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0][0].ToString() + "&" + ds.Tables[0].Rows[0][1].ToString() + "|" + str;
                }
                else
                {
                    return null;
                }
            }


        }

        /// <summary>
        /// 添加发布期数
        /// </summary>
        /// <param name="itemid">项目ID</param>
        /// <param name="expectnum">期号</param>
        /// <param name="issueTime">发布时间</param>
        /// <param name="Commend">是否推荐</param>
        /// <param name="content">内容</param>
        /// <param name="itemidentity">标识</param>
        /// <param name="itemradio">第一个单选框</param>
        /// <param name="itemcheck">第二个复选框</param>
        /// <param name="itemnumber">第三个</param>
        /// <returns></returns>
        [WebMethod]
        public int AddItem(int itemid, string expectnum, string issueTime, int Commend, string content, int itemidentity, string itemradio, string itemcheck, string itemnumber)
        {

            Market_NumManager markbll = new Market_NumManager();
            if (!markbll.Exists(itemid, expectnum, itemradio))
            {
                Market_Num mark = new Market_Num();

                mark.ItemID = itemid;
                mark.ExpectNum = expectnum;
                //发布时间
                mark.IssueTime = issueTime;
                mark.Commend = Commend;
                mark.Content = content;
                mark.itemidentity = itemidentity;
                mark.itemradio = itemradio;
                mark.itemcheck = itemcheck;
                mark.itemnumber = itemnumber;
                return markbll.Add(mark);
            }
            return 0;
        }
        /// <summary>
        /// 根据选择的彩种生成期号
        /// </summary>
        /// <param name="name">彩种名称</param>
        /// <returns></returns>
        [WebMethod]
        public string selectIssue(string name)
        {

            //3D
            if (name == "1")
            {
                UpdateApplication("FC3DData");
                Hashtable hat3D = (Hashtable)Application["FC3DDataValue"];
                string awardNum = Formart5(hat3D["code"].ToString(), "zhong1");
                return hat3D["issue"].ToString() + "|" + awardNum;

            }
            //七乐彩
            if (name == "2")
            {
                UpdateApplication("FC7LC");
                Hashtable hatFc7lc = (Hashtable)Application["FC7LCValue"];
                string awardNum = Formart2(hatFc7lc["code"].ToString(), "zhong1") + "+" + hatFc7lc["tcode"].ToString();
                return hatFc7lc["issue"].ToString() + "|" + awardNum;
            }
            //双色球
            if (name == "3")
            {
                UpdateApplication("FCSSData");
                Hashtable hatSsq = (Hashtable)Application["FCSSDataValue"];
                string awardNum = Formart2(hatSsq["redcode"].ToString(), "zhong1") + "+" + hatSsq["bluecode"].ToString();
                return hatSsq["issue"].ToString() + "|" + awardNum;
            }
            //排列5
            if (name == "4")
            {
                UpdateApplication("TCPL35Data");
                Hashtable hatPl5 = (Hashtable)Application["TCPL35DataValue"];
                string awardNum = Formart5(hatPl5["code5"].ToString(), "zhong1");
                return hatPl5["issue"].ToString() + "|" + awardNum;
            }
            //七星彩
            if (name == "5")
            {
                UpdateApplication("TC7XCData_New");
                Hashtable hatTc7XC = (Hashtable)Application["TC7XCData_NewValue"];
                string awardNum = Formart5(hatTc7XC["code"].ToString(), "zhong1") + "+" + hatTc7XC["tcode"].ToString();
                return hatTc7XC["issue"].ToString() + "|" + awardNum;
            }
            //大乐透
            if (name == "6")
            {
                UpdateApplication("TCDLTData");
                Hashtable hatDlt = (Hashtable)Application["TCDLTDataValue"];
                string awardNum = Formart2(hatDlt["code"].ToString(), "zhong1") + "+" + hatDlt["code2"].ToString();
                return hatDlt["issue"].ToString() + "|" + awardNum;
            }
            //22选5
            if (name == "7")
            {
                UpdateApplication("TC22X5Data");
                Hashtable hatTc22X5 = (Hashtable)Application["TC22X5DataValue"];
                string awardNum = Formart2(hatTc22X5["code"].ToString(), "zhong1");
                return hatTc22X5["issue"].ToString() + "|" + awardNum;
            }
            return null;
        }
        private void UpdateApplication(string cpName)
        {
            string tempValue = cpName + "Value";
            if (Application[tempValue] == null || Application[cpName] == null || !(Application[cpName] != null && Application[cpName].ToString() == "true"))
            {
                DataSet dsAppData = Maticsoft.DBUtility.DbHelperSQL1.Query(" select top 1 * from  " + cpName + " order by issue desc ");
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
                    case "TC22X5Data":
                        hatData.Add("code", row["code"]);
                        break;
                    case "TC31X7Data":
                        hatData.Add("code", row["code"]);
                        hatData.Add("tcode", row["tcode"]);
                        break;
                }

                Application.Lock();
                Pbzx.Common.ErrorLog.WriteLogMeng("Application更新", "Application['" + cpName + "']发生改变", true, true);
                Application[tempValue] = hatData;
                Application[cpName] = "true";
                Application.UnLock();
            }
        }
        //处理双色球
        private string Formart2(string code, string type)
        {
            StringBuilder sbResult = new StringBuilder();
            for (int i = 0; i < code.Length; i += 2)
            {
                if (i < code.Length - 2)
                {
                    sbResult.Append(code.Substring(i, 2) + " ");
                }
                else
                {
                    sbResult.Append(code.Substring(i, 2) + " ");
                }
            }
            return sbResult.ToString();
        }
        //处理3D
        private string Formart5(string code, string type)
        {
            StringBuilder sbResult = new StringBuilder();
            for (int i = 0; i < code.Length; i++)
            {
                if (i == code.Length)
                {
                    sbResult.Append(code.Substring(i, 1) + " ");
                }
                else
                {
                    sbResult.Append(code.Substring(i, 1) + " "); // .Substring(i, 1);
                }
            }
            return sbResult.ToString();
        }
        /// <summary>
        /// 查询彩票最新的一期的号码
        /// </summary>
        /// <param name="NvarName">彩票名称</param>
        /// <returns></returns>
        /// 
        [WebMethod]
        public string lotteryNum(string NvarName)
        {
            if (NvarName == "3D")
            {
                return selectIssue("1").Split('|')[0];
            }
            if (NvarName == "七乐彩")
            {
                return selectIssue("2").Split('|')[0];
            }
            if (NvarName == "双色球")
            {
                return selectIssue("3").Split('|')[0];
            }
            if (NvarName == "排列五")
            {
                return selectIssue("4").Split('|')[0];
            }
            if (NvarName == "七星彩")
            {
                return selectIssue("5").Split('|')[0];
            }
            if (NvarName == "大乐透")
            {
                return selectIssue("6").Split('|')[0];
            }
            if (NvarName == "22选5")
            {
                return selectIssue("7").Split('|')[0];
            }
            return "";
        }
        /// <summary>
        /// 判断用户帐户有没有余额缴纳保证金
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns></returns>
        [WebMethod]
        public string deductMoney(string username)
        {
            DataSet ds = DbHelperSQLBBS.Query("select UserMoney from Dv_User where UserName=" + "'" + username + "'");
            if (Convert.ToInt32(ds.Tables[0].Rows[0]["UserMoney"]) > Convert.ToInt32(Pbzx.Common.Input.GetPrice().ToString()))
            {
                return "1";
            }
            return "0";
        }

        /// <summary>
        /// 扣除保证金
        /// </summary>
        /// <param name="money"></param>
        /// <returns></returns>
        [WebMethod]
        public string deduct(string price,string username, int itemid)
        {
            //判断有没有设置收费金额
            //如果是收费改变 修改数据库的值
            if (price != "" || price!=null || Convert.ToInt32(price)>0)
            {
                Pbzx.BLL.Market_appendItemManager app = new Market_appendItemManager();
                Pbzx.Model.Market_appendItem modapp=app.GetModel(itemid);

                //扣除商户保证金
                DataSet ds = DbHelperSQLBBS.Query("select UserMoney from Dv_User where UserName=" + "'" + username + "'");
                int money = Convert.ToInt32(ds.Tables[0].Rows[0]["UserMoney"]) - Convert.ToInt32(Pbzx.Common.Input.GetPrice().ToString());
                int dsmoney = DbHelperSQLBBS.ExecuteSql("update Dv_User set UserMoney=" + money + " where UserName=" + "'" + username + "'");
                if (dsmoney > 0)
                {
                    //修改收费免费标识
                    modapp.Charge = 1;
                    modapp.Price = Convert.ToDecimal(price);
                    //修改的条件ID
                    modapp.appendID = itemid;
                    if (app.Update(modapp) > 0)
                    {
                        return "1";
                    }
                    else
                    {
                        return "0";
                    }
                }
            }
            return "0";
        }
    }
}
