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

namespace Pbzx.Web.PB_Manage
{
    public partial class UpdateOrders : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {

                DateTime dtStart = DateTime.Now;
                TimeSpan tsStart = dtStart.TimeOfDay;

                Response.Clear();
                Response.Write("<a href='refresh'>refresh</a><br>");
                Response.Write("≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡<br/>");

                if (!string.IsNullOrEmpty(Request["PinbleOrders"]) && Request["PinbleOrders"] == "CancelOrders")
                {
                    string strDays = ConfigurationManager.AppSettings["OrderCancelDay"];
                    int day = 15;
                    int.TryParse(strDays, out day);
                    int orderCount = DbHelperSQL.ExecuteSql(" update PBnet_Orders set IsCancel=2,UpdateStaticDate = GETDATE() WHERE (DATEDIFF(dd, OrderDate, GETDATE()) > " + day + ") and (TipID = 2) and IsCancel=0 ");
                    int chargeOrderCount = DbHelperSQL.ExecuteSql(" update PBnet_Charge set IsCancel=2,UpdateStaticDate = GETDATE() WHERE (DATEDIFF(dd, OrderDate, GETDATE()) > " + day + ") and State=0 and IsCancel=0 ");
                    int orderDetailCount = DbHelperSQL.ExecuteSql(" update PBnet_OrderDetail set Serial='已完成',TempOpen='1'  WHERE ((LEFT(RegType,1)=7) OR (LEFT(RegType,1)=6)) and  ((TempOpen IS NULL) OR (TempOpen = 0)) AND (OrderID IN (SELECT orderid FROM PBnet_orders  WHERE (DATEDIFF(dd, UpdateStaticDate, GETDATE()) > 10) AND TipID = 6)) ");
                    Response.Write("更新过期商品品订单 " + orderCount.ToString() + " 个。<br/>");
                    Response.Write("更新订单详细表软件" + orderDetailCount.ToString() + " 个。<br/>");
                    Response.Write("更新过期充值取款订单 " + chargeOrderCount.ToString() + " 个。<br/>");
                }
                else if (!string.IsNullOrEmpty(Request["PinbleMessages"]) && Request["PinbleMessages"] == "CancelMessages")
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
                else if (!string.IsNullOrEmpty(Request["PinbleUserLogs"]) && Request["PinbleUserLogs"] == "UserLogs")
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
                else if (!string.IsNullOrEmpty(Request["PinbleAdminLogs"]) && Request["PinbleAdminLogs"] == "AdminLogs")
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
                else
                {
                    string strDays = ConfigurationManager.AppSettings["OrderCancelDay"];
                    int day = 15;
                    int.TryParse(strDays, out day);
                    int orderCount = DbHelperSQL.ExecuteSql(" update PBnet_Orders set IsCancel=2,UpdateStaticDate = GETDATE() WHERE (DATEDIFF(dd, OrderDate, GETDATE()) > " + day + ") and (TipID = 2) and IsCancel=0 ");
                    int chargeOrderCount = DbHelperSQL.ExecuteSql(" update PBnet_Charge set IsCancel=2,UpdateStaticDate = GETDATE() WHERE (DATEDIFF(dd, OrderDate, GETDATE()) > " + day + ") and State=0 and IsCancel=0 ");
                    int orderDetailCount = DbHelperSQL.ExecuteSql(" update PBnet_OrderDetail set Serial='已完成',TempOpen='1'  WHERE ((LEFT(RegType,1)=7) OR (LEFT(RegType,1)=6)) and  ((TempOpen IS NULL) OR (TempOpen = 0)) AND (OrderID IN (SELECT orderid FROM PBnet_orders  WHERE (DATEDIFF(dd, UpdateStaticDate, GETDATE()) > 10) AND TipID = 6)) ");
                    Response.Write("更新过期商品品订单 " + orderCount.ToString() + " 个。<br/>");
                    Response.Write("更新订单详细表软件" + orderDetailCount.ToString() + " 个。<br/>");
                    Response.Write("更新过期充值取款订单 " + chargeOrderCount.ToString() + " 个。<br/>");                
                }                
                Response.Write("≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡<br/>");
                DateTime dtEnd = DateTime.Now;
                TimeSpan tsJG = dtEnd - dtStart;
                Response.Write("【" + Math.Floor(tsJG.TotalSeconds) + "秒】" + dtStart + " - " + dtEnd + " ");

                //string strDays = ConfigurationManager.AppSettings["OrderCancelDay"];
                //int day = 15;
                //int.TryParse(strDays, out day);
                //int orderCount = DbHelperSQL.ExecuteSql(" update PBnet_Orders set IsCancel=2,UpdateStaticDate = GETDATE() WHERE (DATEDIFF(dd, OrderDate, GETDATE()) > " + day + ") and (TipID = 2) and IsCancel=0 ");
                //int chargeOrderCount = DbHelperSQL.ExecuteSql(" update PBnet_Charge set IsCancel=2,UpdateStaticDate = GETDATE() WHERE (DATEDIFF(dd, OrderDate, GETDATE()) > " + day + ") and State=0 and IsCancel=0 ");
                //int orderDetailCount = DbHelperSQL.ExecuteSql(" update PBnet_OrderDetail set Serial='已完成',TempOpen='1'  WHERE ((LEFT(RegType,1)=7) OR (LEFT(RegType,1)=6)) and  ((TempOpen IS NULL) OR (TempOpen = 0)) AND (OrderID IN (SELECT orderid FROM PBnet_orders  WHERE (DATEDIFF(dd, UpdateStaticDate, GETDATE()) > 10) AND TipID = 6)) ");
                //Response.Clear();
                //Response.Write("<a href='refresh'>refresh</a><br>");
                //Response.Write("≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡<br/>");
                //Response.Write("更新过期商品品订单 " + orderCount.ToString() + " 个。<br/>");
                //Response.Write("更新订单详细表软件" + orderDetailCount.ToString() + " 个。<br/>");
                //Response.Write("更新过期充值取款订单 " + chargeOrderCount.ToString() + " 个。<br/>");
                //Response.Write("≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡<br/>");
                //Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("修改", "更新过期商品品订单" + orderCount.ToString() + "个。");
                //Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("修改", "更新过期充值取款订单" + chargeOrderCount.ToString() + "个。");
                //DateTime dtEnd = DateTime.Now;
                //TimeSpan tsJG = dtEnd - dtStart;
                //Response.Write("【" + tsJG.TotalSeconds + "秒】" + dtStart + " - " + dtEnd + " ");                
            }
        }
    }
}
