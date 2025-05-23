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
using System.Text;
using System.Data.SqlClient;

namespace Pbzx.Web
{
    public partial class Updatebroker : System.Web.UI.Page
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
                int Hours = int.Parse(ConfigurationManager.AppSettings["BrokerH"]);
                int Minutes = int.Parse(ConfigurationManager.AppSettings["BrokerM"]);
                if (tsStart.Hours == Hours && tsStart.Minutes >= Minutes)
                {
                    if (!string.IsNullOrEmpty(Request["PinbleBroker"]) && Request["PinbleBroker"] == "updateBroker")
                    {
                        //获取经纪人列表
                        DataSet ds = DbHelperSQL.Query("SELECT * FROM PBnet_broker where State=1 order by  Discount_rate, Year_tradeMoney desc");



                        if (ds.Tables[0].Rows.Count > 0)
                        {

                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                StringBuilder tiaozheng = new StringBuilder();
                                DataRow  row = ds.Tables[0].Rows[i];
                                string userName = row["UserName"].ToString();
                                DateTime passtime = DateTime.Parse(row["Pass_time"].ToString());
                                DateTime  tempPasstime = new DateTime(DateTime.Now.Year,passtime.Date.Month,passtime.Date.Day);
                                DateTime YearStart_time = DateTime.Parse(row["YearStart_time"].ToString());

                                //初始化YearStart_time
                                if (!string.IsNullOrEmpty(Request["init"]) && Request["init"] == "true")
                                {              
                                    if(DateTime.Now >= tempPasstime)
                                    {
                                        if (row["YearStart_time"].ToString() != tempPasstime.ToString())
                                        {
                                            Response.Write("<br/<br/>经纪人【" + userName + "】更新YearStart_time");
                                        }
                                        YearStart_time = tempPasstime;
                                        DbHelperSQL.ExecuteSql("update PBnet_broker set YearStart_time='" + tempPasstime + "' where UserName='" + userName + "'  ");
                                       
                                    }
                                    else
                                    {
                                        if (row["YearStart_time"].ToString() != YearStart_time.ToString())
                                        {
                                            Response.Write("<br/<br/>经纪人【" + userName + "】更新YearStart_time");
                                        }
                                        YearStart_time =  new DateTime(DateTime.Now.Year-1,passtime.Date.Month,passtime.Date.Day);
                                        DbHelperSQL.ExecuteSql("update PBnet_broker set YearStart_time='" + YearStart_time + "' where UserName='"+userName+"'  ");
                                    }                 
                                }



                                //总交易金额
                                object objtotal_tradeMoney = DbHelperSQL.GetSingle("SELECT SUM(CustomerPay) FROM [Pinble_Web].[dbo].[PBnet_broker_TradeInfo] where BrokerName='" + userName + "'  ");
                                string total_tradeMoney = objtotal_tradeMoney == null ? "0.00" : objtotal_tradeMoney.ToString();

                                //总收入金额
                                object objtotal_incomeMoney = DbHelperSQL.GetSingle("SELECT SUM(BrokerIncome) FROM [Pinble_Web].[dbo].[PBnet_broker_TradeInfo] where BrokerName='" + userName + "'  ");
                                string total_incomeMoney = objtotal_incomeMoney == null ? "0.00" : objtotal_incomeMoney.ToString();


                                //去年开始时间
                                DateTime dtLastYearStartTime = YearStart_time.AddYears(-1);

                                
                                
                                //今年交易金额
                                 object objyear_tradeMoney = DbHelperSQL.GetSingle("SELECT SUM(CustomerPay) FROM [Pinble_Web].[dbo].[PBnet_broker_TradeInfo] where BrokerName='" + userName + "' and  CreateTime >= '" + YearStart_time + "'  and CreateTime < GETDATE()   ");
                                 string year_tradeMoney = objyear_tradeMoney == null ? "0.00" : objyear_tradeMoney.ToString();

                                //今年收入金额
                                 object objyear_incomeMoney = DbHelperSQL.GetSingle("SELECT SUM(BrokerIncome) FROM [Pinble_Web].[dbo].[PBnet_broker_TradeInfo] where BrokerName='" + userName + "' and  CreateTime >= '" + YearStart_time + "'  and CreateTime < GETDATE()   ");
                                 string year_incomeMoney = objyear_incomeMoney == null ? "0.00" : objyear_incomeMoney.ToString();

                                //去年交易金额
                                 object objlastYear_tradeMoney = DbHelperSQL.GetSingle("SELECT SUM(CustomerPay) FROM [Pinble_Web].[dbo].[PBnet_broker_TradeInfo] where BrokerName='" + userName + "' and  CreateTime >= '" + dtLastYearStartTime + "'  and CreateTime < '" + YearStart_time + "'   ");
                                 string lastYear_tradeMoney = objlastYear_tradeMoney == null ? "0.00" : objlastYear_tradeMoney.ToString();

                                decimal dcYear_tradeMoney = Decimal.Parse(year_tradeMoney);
                                decimal dcLastYear_tradeMoney = Decimal.Parse(lastYear_tradeMoney);





                                //目前数据库中的等级和折扣
                                string Discount_gradeName = row["Discount_gradeName"].ToString();
                                string Discount_rate = row["Discount_rate"].ToString();
                                string oldDiscount_gradeName = Discount_gradeName;
                                int oldRate = int.Parse(Discount_rate);
                                string tiaoji = "";
                                int oldDiscount_grade = 1;

                                object Discount_grade = DbHelperSQL.GetSingle("SELECT Discount_grade FROM [Pinble_Web].[dbo].[PBnet_broker_Config] where Discount_gradeName='" + Discount_gradeName + "'  ");
                                oldDiscount_grade = int.Parse(Discount_grade.ToString());

                                DateTime dtTjEndTime = YearStart_time; 
                                int newDiscount_grade = oldDiscount_grade;
                                //更新交易金额和更新等级,处理跨年和不跨年情况
                                if (DateTime.Parse(DateTime.Now.ToShortDateString()) >= DateTime.Parse(YearStart_time.AddYears(1).ToShortDateString()))//跨年处理,如果跨年直接统计YearStart_time到YearStart_time.AddYears(1)之间的交易金额，并计算等级
                                {
                                    object objKuaNianJine = DbHelperSQL.GetSingle("SELECT SUM(CustomerPay) FROM [Pinble_Web].[dbo].[PBnet_broker_TradeInfo] where BrokerName='" + userName + "' and  CreateTime >= '" + YearStart_time + "'  and CreateTime < '" + YearStart_time.AddYears(1) + "'   ");
                                    string kuaNianJine = objKuaNianJine == null ? "0.00" : objKuaNianJine.ToString();
                                    DataRow rowBrokerConfig = GetBrokerConfig(Decimal.Parse(kuaNianJine));
                                    newDiscount_grade = int.Parse(rowBrokerConfig["Discount_grade"].ToString());
                                    //如果销售额小于原有等级，则降1级
                                    if (newDiscount_grade < oldDiscount_grade)
                                    {
                                        newDiscount_grade = oldDiscount_grade - 1;

                                        if (newDiscount_grade < 1)
                                        {
                                            newDiscount_grade = 1;
                                        }

                                        rowBrokerConfig = GetBrokerConfigByDiscount_grade(newDiscount_grade);
                                        Discount_gradeName = rowBrokerConfig["Discount_gradeName"].ToString();
                                        Discount_rate = rowBrokerConfig["Discount_rate"].ToString();

                                        tiaoji = "降级，由" + oldDiscount_grade + "级降到" + newDiscount_grade + "级";
                                    }
                                    else if (newDiscount_grade > oldDiscount_grade)
                                    {

                                        rowBrokerConfig = GetBrokerConfigByDiscount_grade(newDiscount_grade);
                                        Discount_gradeName = rowBrokerConfig["Discount_gradeName"].ToString();
                                        Discount_rate = rowBrokerConfig["Discount_rate"].ToString();

                                        tiaoji = "升级，由" + oldDiscount_grade + "级升到" + newDiscount_grade + "级";
                                    }
                                    else
                                    {
                                        tiaozheng.Append("经纪人跨年等级无变化，");
                                    }

                                    dtTjEndTime = YearStart_time.AddYears(1);
                                    DbHelperSQL.ExecuteSql("update PBnet_broker set YearStart_time='" + YearStart_time.AddYears(1) + "' where UserName='" + userName + "'  ");

                                }
                                else//不跨年处理
                                {
                                    DataRow rowBrokerConfig = GetBrokerConfig(dcYear_tradeMoney);
                                    int newRate = int.Parse(rowBrokerConfig["Discount_rate"].ToString());

                                    newDiscount_grade = int.Parse(rowBrokerConfig["Discount_grade"].ToString());
                                    //如果今年的交易金额计算出来的等级大于目前数据库中的等级则更新，否者不变。
                                    if (newRate < oldRate)
                                    {
                                        Discount_gradeName = rowBrokerConfig["Discount_gradeName"].ToString();
                                        Discount_rate = rowBrokerConfig["Discount_rate"].ToString();
                                        tiaoji = "升级，由" + oldDiscount_grade + "级升到" + newDiscount_grade + "级";
                                        dtTjEndTime = DateTime.Now;
                                    }
                                    else
                                    {
                                        tiaozheng.Append("经纪人不跨年等级无变化，");
                                    }
                                }

                                #region 调试信息
                                //Response.Write("<br/<br/>经纪人【" + userName + "】信息如下：");
                                //Response.Write("<br/>总交易金额：" + total_tradeMoney);
                                ////Response.Write("<br/>总收入金额：" + total_incomeMoney);
                                //Response.Write("<br/>今年时间段：" + YearStart_time + " - " + DateTime.Now);
                                //Response.Write("<br/>今年交易金额：" + year_tradeMoney);
                                //Response.Write("<br/>去年时间段：" + dtLastYearStartTime + " - " + YearStart_time);
                                //Response.Write("<br/>去年交易金额：" + lastYear_tradeMoney);
                                //Response.Write("<br/>经纪人等级：" + Discount_gradeName);
                                //Response.Write("<br/>经纪人利率：" + Discount_rate);
                                #endregion




                                if (!string.IsNullOrEmpty(tiaoji))
                                {                                    
                                    Response.Write("<br/>经纪人【"+userName+"】调级情况：" + tiaoji + "");
                                    //DbHelperSQL.ExecuteSql("update PBnet_broker set Discount_gradeName='" + Discount_gradeName + "',Discount_rate='" + Discount_rate + "',LastYear_tradeMoney='" + lastYear_tradeMoney + "',Year_tradeMoney='" + year_tradeMoney + "',Year_incomeMoney='" + year_incomeMoney + "',Total_tradeMoney='" + total_tradeMoney + "',Total_incomeMoney='" + total_incomeMoney + "' where UserName='" + userName + "'  ");

                                    //写日志


                                    DbHelperSQL.ExecuteSql("INSERT INTO [Pinble_Web].[dbo].[PBnet_brokerLog]([UserName],[YearStart_time],[YearEnd_time],[Year_tradeMoney],[Old_gradeName],[Now_gradeName],[Updated_time],[Remark])VALUES('" + userName + "','" + YearStart_time + "','" + dtTjEndTime + "','" + year_tradeMoney + "','" + oldDiscount_gradeName + "','" + Discount_gradeName + "','" + DateTime.Now + "','经纪人【" + userName + "】调级情况：" + tiaoji + "')  ");
                                    //Response.Write("INSERT INTO [Pinble_Web].[dbo].[PBnet_brokerLog]([UserName],[YearStart_time],[YearEnd_time],[Year_tradeMoney],[Old_gradeName],[Now_gradeName],[Updated_time],[Remark])VALUES('" + userName + "','" + YearStart_time + "','" + dtTjEndTime + "','" + year_tradeMoney + "','" + oldDiscount_gradeName + "','" + Discount_gradeName + "','" + DateTime.Now + "','经纪人【" + userName + "】调级情况：" + tiaoji + "')  ");
                                }


                                #region 调试信息
                                //if (Discount_gradeName != row["Discount_gradeName"].ToString() )
                                //{
                                //    tiaozheng.Append("级别由" + row["Discount_gradeName"].ToString() + "调整为：" + Discount_gradeName+"，");
                                //}
                                //if (decimal.Parse(lastYear_tradeMoney) != decimal.Parse(row["LastYear_tradeMoney"].ToString()))
                                //{
                                //    tiaozheng.Append("去年交易金额由" + row["LastYear_tradeMoney"].ToString() + "调整为：" + lastYear_tradeMoney + "，");
                                //}
                                //if (decimal.Parse(year_tradeMoney) != decimal.Parse(row["Year_tradeMoney"].ToString()))
                                //{
                                //    tiaozheng.Append("今年交易金额由" + row["Year_tradeMoney"].ToString() + "调整为：" + year_tradeMoney + "，");
                                //}
                                //if (decimal.Parse(year_incomeMoney) != decimal.Parse(row["Year_incomeMoney"].ToString()))
                                //{
                                //    tiaozheng.Append("今年收入金额由" + row["Year_incomeMoney"].ToString() + "调整为：" + year_incomeMoney + "，");
                                //}
                                //if (decimal.Parse(total_tradeMoney) != decimal.Parse(row["Total_tradeMoney"].ToString()))
                                //{
                                //    tiaozheng.Append("总交易金额由" + row["Total_tradeMoney"].ToString() + "调整为：" + total_tradeMoney + "，");
                                //}
                                //if (decimal.Parse(total_incomeMoney) != decimal.Parse(row["Total_incomeMoney"].ToString()))
                                //{
                                //    tiaozheng.Append("总收入金额由" + row["Total_incomeMoney"].ToString() + "调整为：" + total_incomeMoney + "，");
                                //}
                                //if (!string.IsNullOrEmpty(tiaozheng.ToString()))
                                //{
                                //    Response.Write("<br/>更新情况：" + tiaozheng.ToString() + "");
                                //}
                                #endregion

                                //Response.Write("<br/>------------------------------------");
                                DbHelperSQL.ExecuteSql("update PBnet_broker set Discount_gradeName='" + Discount_gradeName + "',Discount_rate='" + Discount_rate + "',LastYear_tradeMoney='" + lastYear_tradeMoney + "',Year_tradeMoney='" + year_tradeMoney + "',Year_incomeMoney='" + year_incomeMoney + "',Total_tradeMoney='" + total_tradeMoney + "',Total_incomeMoney='" + total_incomeMoney + "' where UserName='"+userName+"'  ");
                            }
                        }

                    }
                }

                Response.Write("<br/>≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡<br/>");
                DateTime dtEnd = DateTime.Now;
                TimeSpan tsJG = dtEnd - dtStart;
                Response.Write("【" + Math.Floor(tsJG.TotalSeconds) + "秒】" + dtStart + " - " + dtEnd + " ");
            }


        }


        private DataRow GetBrokerConfig(decimal jiaoyijiner)
        {
            //获取经纪人配置列表
            DataSet dsPBnet_broker_Config = DbHelperSQL.Query("SELECT * FROM PBnet_broker_Config order by Min_tradeMoney ");
            DataRow rowBroker_Config = null;
            int broker_ConfigIndex = 0;
            int max = 0;
            if (dsPBnet_broker_Config.Tables[0].Rows.Count > 0)
            {

                for (int k = 0; k < dsPBnet_broker_Config.Tables[0].Rows.Count; k++)
                {
                    decimal dcMin_tradeMoney = Decimal.Parse(dsPBnet_broker_Config.Tables[0].Rows[k]["Min_tradeMoney"].ToString());

                    if (jiaoyijiner >= dcMin_tradeMoney)
                    {
                        continue;
                    }
                    else
                    {
                        max = k;
                        broker_ConfigIndex = k;
                        break;
                    }
                }
            }
            max = broker_ConfigIndex == 0 ? dsPBnet_broker_Config.Tables[0].Rows.Count - 1 : broker_ConfigIndex - 1;
            rowBroker_Config = dsPBnet_broker_Config.Tables[0].Rows[max];
            return rowBroker_Config;

            string sql = "SELECT top 1 * FROM PBnet_broker_Config WHERE  Min_tradeMoney  <='" + jiaoyijiner + "'  ORDER BY Min_tradeMoney DESC";
            return DbHelperSQL.Query(sql).Tables[0].Rows[0];

        }


        private DataRow GetBrokerConfigByDiscount_grade(int Discount_grade)
        {
            //获取经纪人配置列表
            DataSet dsPBnet_broker_Config = DbHelperSQL.Query("SELECT * FROM PBnet_broker_Config where Discount_grade ='" + Discount_grade + "'");

            DataRow rowBroker_Config = null;
            if (dsPBnet_broker_Config.Tables[0].Rows.Count > 0)
            {
                rowBroker_Config = dsPBnet_broker_Config.Tables[0].Rows[0];
            }
            return rowBroker_Config;
        }
    }
}
