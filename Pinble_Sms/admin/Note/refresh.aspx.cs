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

                //--------判断是否已经发布了消息

                //--------需要轮循

                //--------》可以设置每天发送消息的特定时间

                //找出所有的消息类型
                List<Pbzx.Model.Note_LotteryType> list = notebll.GetLists();

                //遍历消息类型
                foreach (Pbzx.Model.Note_LotteryType var in list)
                {
                    //判断消息是否在限定时间内
                    //规定星期几
                    string bgwek = var.IssueWeek;

                    //规定时间
                    string bgdate = var.IssueTime;

                    ///判断是星期的今天
                    if (bgwek.Contains(((int)DateTime.Now.DayOfWeek).ToString()))
                    {
                        if (DateTime.Now >= Convert.ToDateTime(bgdate) && DateTime.Now < Convert.ToDateTime(bgdate).AddHours(1))
                        {

                            //根据类型ID找到订购的用户列表
                            List<Pbzx.Model.Note_Customize> userlist = custbll.GetByList("SID=" + var.SID);


                            //要发布的最新信息对象
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

                                //接收用户电话号码列表
                                StringBuilder but = new StringBuilder();

                                //当存在用户订购的情况才执行
                                if (userlist != null)
                                {
                                    //判断是否有订购的用户
                                    foreach (Pbzx.Model.Note_Customize var1 in userlist)
                                    {
                                        //判断是否在订购期内
                                        if (var1.EndTime >= DateTime.Now)
                                        {
                                            //发送消息
                                            but.Append(var1.Phone + ",");
                                        }
                                        else
                                        { 
                                            //如果不在订购期内，判断他是否自动续费
                                            if (var1.ContinuationType == 1)
                                            {
                                                //找到用户对象
                                                Pbzx.BLL.PBnet_UserTable UsBll = new Pbzx.BLL.PBnet_UserTable();
                                                Pbzx.Model.PBnet_UserTable UsModel = UsBll.GetModelName(var1.UserName);


                                                string[] monthprice = var.PriceContent.Split('|')[0].Split('/');
                                                string price = monthprice[0].Substring(0, monthprice[0].Length - 1);
                                                string month = monthprice[1].Substring(0, monthprice[1].Length - 1);

                                                //判断账户余额是否足够
                                                //给他自动续费
                                                if (UsModel.CurrentMoney > Convert.ToDecimal(price))
                                                {
                                                    ///////////////////////////////////////////这里一定要记录日志(代添加)
                                                    


                                                    ///////////////////////////////////////////从账户中减去消费余额
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


                                                //再次判断他是否在购买期内
                                                Pbzx.Model.Note_Customize usercust = custbll.GetModel(var1.ID);
                                                if (usercust.EndTime >= DateTime.Now)
                                                {
                                                    //发送消息号码
                                                    but.Append(usercust.Phone + ",");
                                                }

                                            }

                                        }

                                    }
                                }

                                //已经有要订购的用户手机号码了！
                                if (but.ToString().Length > 0)
                                {
                                    //调用消息接口
                                    SMSClass sms = new SMSClass();

                                    //判断，当号码数量多的时候，分批发送
                                    if (but.ToString().Split(',').Length > 60)
                                    {

                                    }

                                    //   sms.SetSMS(but.ToString().Substring(0, but.ToString().Length - 1), issue.Content, "");


                                    Response.Write(">>>>>>>>>>>>>短信发送平台<br/>");
                                    Response.Write("发送类型:" + var.SName);
                                    Response.Write("<br/>");
                                    Response.Write("发送号码：" + but.ToString().Substring(0, but.ToString().Length - 1));
                                    Response.Write("<br/>");
                                    Response.Write("发送内容:" + issue.Content);
                                    Response.Write("<br/>");
                                    Response.Write(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                                    Response.Write("<br/>");
                                }
                                //将消息设为已读
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
