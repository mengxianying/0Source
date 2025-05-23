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

namespace Pbzx.Web
{
    public partial class UpdateCancelOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime dtStart = DateTime.Now;
            TimeSpan tsStart = dtStart.TimeOfDay;
            string userIP = Request.UserHostAddress;
            string serverIP = ConfigurationManager.AppSettings["ServerIP"];
            if (serverIP == "" || serverIP.Contains(userIP))
            {
                Response.Clear();
                Response.Write("<a href='refresh'>refresh</a><br>");
                Response.Write("≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡<br/>");
                int Hours = int.Parse(ConfigurationManager.AppSettings["OrderH"]);
                int Minutes = int.Parse(ConfigurationManager.AppSettings["OrderM"]);
                if (tsStart.Hours == Hours && tsStart.Minutes >= Minutes)
                {
                    if (!string.IsNullOrEmpty(Request["PinbleOrders"]) && Request["PinbleOrders"] == "CancelOrders")
                    {
                        string strDays = ConfigurationManager.AppSettings["OrderCancelDay"];
                        int day = 15;
                        int.TryParse(strDays, out day);
                        int orderCount = DbHelperSQL.ExecuteSql(" update PBnet_Orders set IsCancel=2,UpdateStaticDate = GETDATE() WHERE (DATEDIFF(dd, OrderDate, GETDATE()) > " + day + ") and (TipID = 2) and IsCancel=0 and ispay=0 ");

                        //更新充值取款
                        DataSet ds = DbHelperSQL.Query("SELECT * FROM PBnet_Charge WHERE State = 0 AND IsCancel = 0 AND ispay=0 AND (DATEDIFF(dd, OrderDate, GETDATE()) > " + day + ")");
                        int chargeOrderCount = 0;
                        //判断是否有要更新的充值和取款订单
                        if (ds.Tables[0].Rows.Count > 0)
                        {

                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                //判断充值过期了的，将订单取消，将用户的冻结金额退还类型为1表示为取款
                                if (ds.Tables[0].Rows[i]["Type"].ToString() == "1")
                                {
                                    Pbzx.BLL.PBnet_UserTable UsBll = new Pbzx.BLL.PBnet_UserTable();
                                    Pbzx.Model.PBnet_UserTable UsModel = UsBll.GetModelName(ds.Tables[0].Rows[i]["UserName"].ToString());
                                    if (UsModel != null)
                                    {
                                        if (UsModel.FrozenMoney >= Convert.ToDecimal(ds.Tables[0].Rows[i]["PayMoney"]))
                                        {
                                            UsModel.FrozenMoney -= Convert.ToDecimal(ds.Tables[0].Rows[i]["PayMoney"]);
                                        }
                                        else
                                        {
                                            throw new Exception("用户冻结余额发生异常！");
                                        }
                                        UsBll.Update(UsModel);
                                    }
                                }
                            }

                            chargeOrderCount = DbHelperSQL.ExecuteSql(" update PBnet_Charge set IsCancel=2,UpdateStaticDate = GETDATE() WHERE (DATEDIFF(dd, OrderDate, GETDATE()) > " + day + ") and State=0 and IsCancel=0 and ispay=0 ");
                        }

                        int orderDetailCount = DbHelperSQL.ExecuteSql(" update PBnet_OrderDetail set Serial='已完成',TempOpen='1'  WHERE ((LEFT(RegType,1)=7) OR (LEFT(RegType,1)=6)) and  ((TempOpen IS NULL) OR (TempOpen = 0)) AND (OrderID IN (SELECT orderid FROM PBnet_orders  WHERE (DATEDIFF(dd, UpdateStaticDate, GETDATE()) > 10) AND TipID = 6)) ");

                        Response.Write("更新过期商品品订单 " + orderCount.ToString() + " 个。<br/>");
                        Response.Write("更新订单详细表软件" + orderDetailCount.ToString() + " 个。<br/>");
                        Response.Write("更新过期充值取款订单 " + chargeOrderCount.ToString() + " 个。<br/>");
                    }
                    else if (!string.IsNullOrEmpty(Request["PinbleMessages"]) && Request["PinbleMessages"] == "CancelMessages" && DateTime.Now.Day == 1)
                    {
                        string strMonth = ConfigurationManager.AppSettings["MessageCancelMonth"];
                        int month = 0;
                        int.TryParse(strMonth, out month);
                        int messageCount = 0;
                        if (month == 0)
                        {
                            messageCount = 0;
                        }
                        else
                        {
                            messageCount = DbHelperSQLBBS.ExecuteSql(" delete from Dv_Message where (DATEDIFF(MM, sendtime, GETDATE()) >" + month + " ) ");
                        }
                        Response.Write("删除过期网站消息 " + messageCount.ToString() + " 个。<br/>");
                    }
                    else if (!string.IsNullOrEmpty(Request["PinbleUserLogs"]) && Request["PinbleUserLogs"] == "UserLogs" && DateTime.Now.Day == 1)
                    {
                        string strMonth = ConfigurationManager.AppSettings["UserLogCancelMonth"];
                        int month = 0;
                        int.TryParse(strMonth, out month);
                        int userLogCount = 0;
                        if (month == 0)
                        {
                            userLogCount = 0;
                        }
                        else
                        {
                            userLogCount = DbHelperSQL.ExecuteSql(" delete from PBnet_UserLog where (DATEDIFF(MM, log_time, GETDATE()) >" + month + " ) ");
                        }
                        Response.Write("删除过期用户日志 " + userLogCount.ToString() + " 个。<br/>");
                    }
                    else if (!string.IsNullOrEmpty(Request["PinbleAdminLogs"]) && Request["PinbleAdminLogs"] == "AdminLogs" && DateTime.Now.Day == 1)
                    {
                        string strMonth = ConfigurationManager.AppSettings["AdminLogCancelMonth"];
                        int month = 0;
                        int.TryParse(strMonth, out month);
                        int adminLogCount = 0;
                        if (month == 0)
                        {
                            adminLogCount = 0;
                        }
                        else
                        {
                            adminLogCount = DbHelperSQL.ExecuteSql(" delete from PBnet_WebLog where (DATEDIFF(MM, ActionTime, GETDATE()) >" + month + " ) ");
                        }
                        Response.Write("删除过期管理员日志 " + adminLogCount.ToString() + " 个。<br/>");
                    }
                    else if (!string.IsNullOrEmpty(Request["PinbleAdminLogs"]) && Request["PinbleAdminLogs"] == "deleteCue" && DateTime.Now.Day == 1)
                    {
                        DateTime data = DateTime.Now.AddDays(-2);
                        int deldteCueCount = 0;
                        deldteCueCount = DbHelperSQL.ExecuteSql(" delete from PBnet_retrieveinfo where RTime<"+"'"+ data +"'");
                        Response.Write("删除过期用户取回密码操作记录 " + deldteCueCount.ToString() + " 个。<br/>");
                    }
                }

                Response.Write("≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡<br/>");
                DateTime dtEnd = DateTime.Now;
                TimeSpan tsJG = dtEnd - dtStart;
                Response.Write("【" + Math.Floor(tsJG.TotalSeconds) + "秒】" + dtStart + " - " + dtEnd + " ");
            }


        }
    }
}
