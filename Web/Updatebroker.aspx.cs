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
                Response.Write("�ԡԡԡԡԡԡԡԡԡԡԡԡԡԡԡԡԡԡԡԡԡԡԡԡԡԡ�<br/>");
                int Hours = int.Parse(ConfigurationManager.AppSettings["BrokerH"]);
                int Minutes = int.Parse(ConfigurationManager.AppSettings["BrokerM"]);
                if (tsStart.Hours == Hours && tsStart.Minutes >= Minutes)
                {
                    if (!string.IsNullOrEmpty(Request["PinbleBroker"]) && Request["PinbleBroker"] == "updateBroker")
                    {
                        //��ȡ�������б�
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

                                //��ʼ��YearStart_time
                                if (!string.IsNullOrEmpty(Request["init"]) && Request["init"] == "true")
                                {              
                                    if(DateTime.Now >= tempPasstime)
                                    {
                                        if (row["YearStart_time"].ToString() != tempPasstime.ToString())
                                        {
                                            Response.Write("<br/<br/>�����ˡ�" + userName + "������YearStart_time");
                                        }
                                        YearStart_time = tempPasstime;
                                        DbHelperSQL.ExecuteSql("update PBnet_broker set YearStart_time='" + tempPasstime + "' where UserName='" + userName + "'  ");
                                       
                                    }
                                    else
                                    {
                                        if (row["YearStart_time"].ToString() != YearStart_time.ToString())
                                        {
                                            Response.Write("<br/<br/>�����ˡ�" + userName + "������YearStart_time");
                                        }
                                        YearStart_time =  new DateTime(DateTime.Now.Year-1,passtime.Date.Month,passtime.Date.Day);
                                        DbHelperSQL.ExecuteSql("update PBnet_broker set YearStart_time='" + YearStart_time + "' where UserName='"+userName+"'  ");
                                    }                 
                                }



                                //�ܽ��׽��
                                object objtotal_tradeMoney = DbHelperSQL.GetSingle("SELECT SUM(CustomerPay) FROM [Pinble_Web].[dbo].[PBnet_broker_TradeInfo] where BrokerName='" + userName + "'  ");
                                string total_tradeMoney = objtotal_tradeMoney == null ? "0.00" : objtotal_tradeMoney.ToString();

                                //��������
                                object objtotal_incomeMoney = DbHelperSQL.GetSingle("SELECT SUM(BrokerIncome) FROM [Pinble_Web].[dbo].[PBnet_broker_TradeInfo] where BrokerName='" + userName + "'  ");
                                string total_incomeMoney = objtotal_incomeMoney == null ? "0.00" : objtotal_incomeMoney.ToString();


                                //ȥ�꿪ʼʱ��
                                DateTime dtLastYearStartTime = YearStart_time.AddYears(-1);

                                
                                
                                //���꽻�׽��
                                 object objyear_tradeMoney = DbHelperSQL.GetSingle("SELECT SUM(CustomerPay) FROM [Pinble_Web].[dbo].[PBnet_broker_TradeInfo] where BrokerName='" + userName + "' and  CreateTime >= '" + YearStart_time + "'  and CreateTime < GETDATE()   ");
                                 string year_tradeMoney = objyear_tradeMoney == null ? "0.00" : objyear_tradeMoney.ToString();

                                //����������
                                 object objyear_incomeMoney = DbHelperSQL.GetSingle("SELECT SUM(BrokerIncome) FROM [Pinble_Web].[dbo].[PBnet_broker_TradeInfo] where BrokerName='" + userName + "' and  CreateTime >= '" + YearStart_time + "'  and CreateTime < GETDATE()   ");
                                 string year_incomeMoney = objyear_incomeMoney == null ? "0.00" : objyear_incomeMoney.ToString();

                                //ȥ�꽻�׽��
                                 object objlastYear_tradeMoney = DbHelperSQL.GetSingle("SELECT SUM(CustomerPay) FROM [Pinble_Web].[dbo].[PBnet_broker_TradeInfo] where BrokerName='" + userName + "' and  CreateTime >= '" + dtLastYearStartTime + "'  and CreateTime < '" + YearStart_time + "'   ");
                                 string lastYear_tradeMoney = objlastYear_tradeMoney == null ? "0.00" : objlastYear_tradeMoney.ToString();

                                decimal dcYear_tradeMoney = Decimal.Parse(year_tradeMoney);
                                decimal dcLastYear_tradeMoney = Decimal.Parse(lastYear_tradeMoney);





                                //Ŀǰ���ݿ��еĵȼ����ۿ�
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
                                //���½��׽��͸��µȼ�,�������Ͳ��������
                                if (DateTime.Parse(DateTime.Now.ToShortDateString()) >= DateTime.Parse(YearStart_time.AddYears(1).ToShortDateString()))//���괦��,�������ֱ��ͳ��YearStart_time��YearStart_time.AddYears(1)֮��Ľ��׽�������ȼ�
                                {
                                    object objKuaNianJine = DbHelperSQL.GetSingle("SELECT SUM(CustomerPay) FROM [Pinble_Web].[dbo].[PBnet_broker_TradeInfo] where BrokerName='" + userName + "' and  CreateTime >= '" + YearStart_time + "'  and CreateTime < '" + YearStart_time.AddYears(1) + "'   ");
                                    string kuaNianJine = objKuaNianJine == null ? "0.00" : objKuaNianJine.ToString();
                                    DataRow rowBrokerConfig = GetBrokerConfig(Decimal.Parse(kuaNianJine));
                                    newDiscount_grade = int.Parse(rowBrokerConfig["Discount_grade"].ToString());
                                    //������۶�С��ԭ�еȼ�����1��
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

                                        tiaoji = "��������" + oldDiscount_grade + "������" + newDiscount_grade + "��";
                                    }
                                    else if (newDiscount_grade > oldDiscount_grade)
                                    {

                                        rowBrokerConfig = GetBrokerConfigByDiscount_grade(newDiscount_grade);
                                        Discount_gradeName = rowBrokerConfig["Discount_gradeName"].ToString();
                                        Discount_rate = rowBrokerConfig["Discount_rate"].ToString();

                                        tiaoji = "��������" + oldDiscount_grade + "������" + newDiscount_grade + "��";
                                    }
                                    else
                                    {
                                        tiaozheng.Append("�����˿���ȼ��ޱ仯��");
                                    }

                                    dtTjEndTime = YearStart_time.AddYears(1);
                                    DbHelperSQL.ExecuteSql("update PBnet_broker set YearStart_time='" + YearStart_time.AddYears(1) + "' where UserName='" + userName + "'  ");

                                }
                                else//�����괦��
                                {
                                    DataRow rowBrokerConfig = GetBrokerConfig(dcYear_tradeMoney);
                                    int newRate = int.Parse(rowBrokerConfig["Discount_rate"].ToString());

                                    newDiscount_grade = int.Parse(rowBrokerConfig["Discount_grade"].ToString());
                                    //�������Ľ��׽���������ĵȼ�����Ŀǰ���ݿ��еĵȼ�����£����߲��䡣
                                    if (newRate < oldRate)
                                    {
                                        Discount_gradeName = rowBrokerConfig["Discount_gradeName"].ToString();
                                        Discount_rate = rowBrokerConfig["Discount_rate"].ToString();
                                        tiaoji = "��������" + oldDiscount_grade + "������" + newDiscount_grade + "��";
                                        dtTjEndTime = DateTime.Now;
                                    }
                                    else
                                    {
                                        tiaozheng.Append("�����˲�����ȼ��ޱ仯��");
                                    }
                                }

                                #region ������Ϣ
                                //Response.Write("<br/<br/>�����ˡ�" + userName + "����Ϣ���£�");
                                //Response.Write("<br/>�ܽ��׽�" + total_tradeMoney);
                                ////Response.Write("<br/>�������" + total_incomeMoney);
                                //Response.Write("<br/>����ʱ��Σ�" + YearStart_time + " - " + DateTime.Now);
                                //Response.Write("<br/>���꽻�׽�" + year_tradeMoney);
                                //Response.Write("<br/>ȥ��ʱ��Σ�" + dtLastYearStartTime + " - " + YearStart_time);
                                //Response.Write("<br/>ȥ�꽻�׽�" + lastYear_tradeMoney);
                                //Response.Write("<br/>�����˵ȼ���" + Discount_gradeName);
                                //Response.Write("<br/>���������ʣ�" + Discount_rate);
                                #endregion




                                if (!string.IsNullOrEmpty(tiaoji))
                                {                                    
                                    Response.Write("<br/>�����ˡ�"+userName+"�����������" + tiaoji + "");
                                    //DbHelperSQL.ExecuteSql("update PBnet_broker set Discount_gradeName='" + Discount_gradeName + "',Discount_rate='" + Discount_rate + "',LastYear_tradeMoney='" + lastYear_tradeMoney + "',Year_tradeMoney='" + year_tradeMoney + "',Year_incomeMoney='" + year_incomeMoney + "',Total_tradeMoney='" + total_tradeMoney + "',Total_incomeMoney='" + total_incomeMoney + "' where UserName='" + userName + "'  ");

                                    //д��־


                                    DbHelperSQL.ExecuteSql("INSERT INTO [Pinble_Web].[dbo].[PBnet_brokerLog]([UserName],[YearStart_time],[YearEnd_time],[Year_tradeMoney],[Old_gradeName],[Now_gradeName],[Updated_time],[Remark])VALUES('" + userName + "','" + YearStart_time + "','" + dtTjEndTime + "','" + year_tradeMoney + "','" + oldDiscount_gradeName + "','" + Discount_gradeName + "','" + DateTime.Now + "','�����ˡ�" + userName + "�����������" + tiaoji + "')  ");
                                    //Response.Write("INSERT INTO [Pinble_Web].[dbo].[PBnet_brokerLog]([UserName],[YearStart_time],[YearEnd_time],[Year_tradeMoney],[Old_gradeName],[Now_gradeName],[Updated_time],[Remark])VALUES('" + userName + "','" + YearStart_time + "','" + dtTjEndTime + "','" + year_tradeMoney + "','" + oldDiscount_gradeName + "','" + Discount_gradeName + "','" + DateTime.Now + "','�����ˡ�" + userName + "�����������" + tiaoji + "')  ");
                                }


                                #region ������Ϣ
                                //if (Discount_gradeName != row["Discount_gradeName"].ToString() )
                                //{
                                //    tiaozheng.Append("������" + row["Discount_gradeName"].ToString() + "����Ϊ��" + Discount_gradeName+"��");
                                //}
                                //if (decimal.Parse(lastYear_tradeMoney) != decimal.Parse(row["LastYear_tradeMoney"].ToString()))
                                //{
                                //    tiaozheng.Append("ȥ�꽻�׽����" + row["LastYear_tradeMoney"].ToString() + "����Ϊ��" + lastYear_tradeMoney + "��");
                                //}
                                //if (decimal.Parse(year_tradeMoney) != decimal.Parse(row["Year_tradeMoney"].ToString()))
                                //{
                                //    tiaozheng.Append("���꽻�׽����" + row["Year_tradeMoney"].ToString() + "����Ϊ��" + year_tradeMoney + "��");
                                //}
                                //if (decimal.Parse(year_incomeMoney) != decimal.Parse(row["Year_incomeMoney"].ToString()))
                                //{
                                //    tiaozheng.Append("������������" + row["Year_incomeMoney"].ToString() + "����Ϊ��" + year_incomeMoney + "��");
                                //}
                                //if (decimal.Parse(total_tradeMoney) != decimal.Parse(row["Total_tradeMoney"].ToString()))
                                //{
                                //    tiaozheng.Append("�ܽ��׽����" + row["Total_tradeMoney"].ToString() + "����Ϊ��" + total_tradeMoney + "��");
                                //}
                                //if (decimal.Parse(total_incomeMoney) != decimal.Parse(row["Total_incomeMoney"].ToString()))
                                //{
                                //    tiaozheng.Append("����������" + row["Total_incomeMoney"].ToString() + "����Ϊ��" + total_incomeMoney + "��");
                                //}
                                //if (!string.IsNullOrEmpty(tiaozheng.ToString()))
                                //{
                                //    Response.Write("<br/>���������" + tiaozheng.ToString() + "");
                                //}
                                #endregion

                                //Response.Write("<br/>------------------------------------");
                                DbHelperSQL.ExecuteSql("update PBnet_broker set Discount_gradeName='" + Discount_gradeName + "',Discount_rate='" + Discount_rate + "',LastYear_tradeMoney='" + lastYear_tradeMoney + "',Year_tradeMoney='" + year_tradeMoney + "',Year_incomeMoney='" + year_incomeMoney + "',Total_tradeMoney='" + total_tradeMoney + "',Total_incomeMoney='" + total_incomeMoney + "' where UserName='"+userName+"'  ");
                            }
                        }

                    }
                }

                Response.Write("<br/>�ԡԡԡԡԡԡԡԡԡԡԡԡԡԡԡԡԡԡԡԡԡԡԡԡԡԡ�<br/>");
                DateTime dtEnd = DateTime.Now;
                TimeSpan tsJG = dtEnd - dtStart;
                Response.Write("��" + Math.Floor(tsJG.TotalSeconds) + "�롿" + dtStart + " - " + dtEnd + " ");
            }


        }


        private DataRow GetBrokerConfig(decimal jiaoyijiner)
        {
            //��ȡ�����������б�
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
            //��ȡ�����������б�
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
