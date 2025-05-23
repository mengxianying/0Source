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
using Pbzx.BLL;
using System.Text;
using System.Collections.Generic;

namespace Pinble_Market.admin.Note
{
    public partial class refresh : System.Web.UI.Page
    {


        Pbzx.BLL.Note_LotteryIssue lotteryIssbll = new Note_LotteryIssue();

        Note_LotteryType notebll = new Note_LotteryType();
        Note_Customize custbll = new Note_Customize();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //--------�ж��Ƿ��Ѿ���������Ϣ

                //--------��Ҫ��ѭ

                //--------����������ÿ�췢����Ϣ���ض�ʱ��

                //�ҳ����е���Ϣ����
                List<Pbzx.Model.Note_LotteryType> list = notebll.GetLists();

                //������Ϣ����
                foreach (Pbzx.Model.Note_LotteryType var in list)
                {
                    //�ж���Ϣ�Ƿ����޶�ʱ����
                    //�涨���ڼ�
                    string bgwek = var.IssueWeek;

                    //�涨ʱ��
                    string bgdate = var.IssueTime;

                    ///�ж������ڵĽ���
                    if (bgwek.Contains(((int)DateTime.Now.DayOfWeek).ToString()))
                    {
                        if (DateTime.Now >= Convert.ToDateTime(bgdate) && DateTime.Now < Convert.ToDateTime(bgdate).AddHours(1))
                        {

                            //��������ID�ҵ��������û��б�
                            List<Pbzx.Model.Note_Customize> userlist = custbll.GetByList("SID=" + var.SID);


                            //Ҫ������������Ϣ����
                            Pbzx.Model.Note_LotteryIssue issue = lotteryIssbll.GetMaxModel(var.SID.ToString());

                            if (issue != null)
                            {

                                if (issue.BeginTime.Year != DateTime.Now.Year)
                                {
                                    return;
                                }

                                if (issue.BeginTime.Month != DateTime.Now.Month)
                                {
                                    return;
                                }

                                //�����û��绰�����б�
                                StringBuilder but = new StringBuilder();

                                //�������û������������ִ��
                                if (userlist != null)
                                {
                                    //�ж��Ƿ��ж������û�
                                    foreach (Pbzx.Model.Note_Customize var1 in userlist)
                                    {
                                        //�ж��Ƿ��ڶ�������
                                        if (var1.EndTime >= DateTime.Now)
                                        {
                                            //������Ϣ
                                            but.Append(var1.Phone + ",");
                                        }
                                        else
                                        { 
                                            //������ڶ������ڣ��ж����Ƿ��Զ�����
                                            if (var1.ContinuationType == 1)
                                            {
                                                //�ҵ��û�����
                                                Pbzx.BLL.PBnet_UserTable UsBll = new Pbzx.BLL.PBnet_UserTable();
                                                Pbzx.Model.PBnet_UserTable UsModel = UsBll.GetModelName(var1.UserName);


                                                string[] monthprice = var.PriceContent.Split('|')[0].Split('/');
                                                string price = monthprice[0].Substring(0, monthprice[0].Length - 1);
                                                string month = monthprice[1].Substring(0, monthprice[1].Length - 1);

                                                //�ж��˻�����Ƿ��㹻
                                                //�����Զ�����
                                                if (UsModel.CurrentMoney > Convert.ToDecimal(price))
                                                {
                                                    ///////////////////////////////////////////����һ��Ҫ��¼��־(�����)
                                                    


                                                    ///////////////////////////////////////////���˻��м�ȥ�������
                                                    UsModel.CurrentMoney = UsModel.CurrentMoney - Convert.ToDecimal(price);
                                                    UsBll.Update(UsModel);
                                                   
                                                    var1.EndTime = DateTime.Now.AddMonths(Convert.ToInt32(month));
                                                    var1.Price += Convert.ToDecimal(price);

                                                    custbll.Update(var1);
                                                }
                                                else
                                                { 
                                                    var1.ContinuationType = 0;
                                                    custbll.Update(var1);
                                                }


                                                //�ٴ��ж����Ƿ��ڹ�������
                                                Pbzx.Model.Note_Customize usercust = custbll.GetModel(var1.ID);
                                                if (usercust.EndTime >= DateTime.Now)
                                                {
                                                    //������Ϣ����
                                                    but.Append(usercust.Phone + ",");
                                                }

                                            }

                                        }

                                    }
                                }

                                //�Ѿ���Ҫ�������û��ֻ������ˣ�
                                if (but.ToString().Length > 0)
                                {
                                    //������Ϣ�ӿ�
                                    SMSClass sms = new SMSClass();

                                    //�жϣ��������������ʱ�򣬷�������
                                    if (but.ToString().Split(',').Length > 60)
                                    {

                                    }

                                    //   sms.SetSMS(but.ToString().Substring(0, but.ToString().Length - 1), issue.Content, "");


                                    Response.Write(">>>>>>>>>>>>>���ŷ���ƽ̨<br/>");
                                    Response.Write("��������:" + var.SName);
                                    Response.Write("<br/>");
                                    Response.Write("���ͺ��룺" + but.ToString().Substring(0, but.ToString().Length - 1));
                                    Response.Write("<br/>");
                                    Response.Write("��������:" + issue.Content);
                                    Response.Write("<br/>");
                                    Response.Write(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                                    Response.Write("<br/>");
                                }
                                //����Ϣ��Ϊ�Ѷ�
                                issue.IsSend = 1;
                                lotteryIssbll.Update(issue);

                            }
                        }

                    }

                }
            }
        }
    }
}
