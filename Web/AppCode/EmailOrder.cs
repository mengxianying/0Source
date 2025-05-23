using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Web;
using System.Data;
using Pbzx.Common;
using System.Configuration;

namespace Pbzx.Web
{
    public class EmailOrder
    {

        private string ToEmail;
        private string OrderID;
        private DataSet OrderDetail;
        private DataRow Order;
        private string UrlAuthority;
        private string UserName;
        private string Type = "0";
        private string StepType = "1";

        /// <summary>
        /// Email构造方法
        /// </summary>
        /// <param name="toEmail">要发送到的Email地址</param>
        /// <param name="orderID">订单号</param>
        /// <param name="type">类型0：软件订单，1：代理订单，2：充值订单</param>
        /// <param name="stepType">步骤1:下订单，2：订单处理完成</param>
        public EmailOrder(string toEmail, string orderID, string type, string stepType)
        {
            ToEmail = toEmail;
            OrderID = orderID;
            UrlAuthority = HttpContext.Current.Request.Url.Authority;
            Type = type;
            StepType = stepType;
        }

        private string EmailOrderSubject
        {
            get { return "拼搏在线软件订单:" + OrderID + "（系统自动发送，请勿回复）"; }
        }

        private string GetEmailOrderContent(string stepType)
        {

            //string title = "";

            StringBuilder content = new StringBuilder();
            content.Append("<table width='610' border='0' align='center' cellpadding='0' cellspacing='0'>");
            content.Append("<tr>");
            content.Append("<td width='330'><a href='" + WebInit.webBaseConfig.WebUrl + "' ><img border='0' alt='拼搏在线彩神通软件' src='" + WebInit.webBaseConfig.WebUrl + "images/web/EmailLogo.gif' width='215' height='50' /></a></td>");
            content.Append("<td width='280' valign='bottom'>");
            content.Append("<div style='background-color:#FB7D00; width:100%; padding-top:7px; font-size:12px; color:#FFFFFF;  text-align:center;'>");
            content.Append("<a href='" + WebInit.webBaseConfig.WebUrl + "' target='_blank' style='color:#FFFFFF; text-decoration:none;'>拼搏首页</a> | ");
            content.Append("<a href='" + WebInit.webBaseConfig.WebUrl + "Soft.aspx' target='_blank' style='color:#FFFFFF; text-decoration:none;'>软件商城</a> | ");
            content.Append("<a href='" + WebInit.webBaseConfig.WebUrl + "SoftwarePrices.htm' target='_blank' style='color:#FFFFFF; text-decoration:none;'>注册购买</a> | ");
            content.Append("<a href='http://bbs.pinble.com/' target='_blank' style='color:#FFFFFF; text-decoration:none;'>拼搏论坛</a>");
            content.Append("</div>");
            content.Append("</td>");
            content.Append("</tr>");
            content.Append("</table>");

            content.Append("<table width='610' border='0' align='center' cellpadding='0' cellspacing='7' bgcolor='#FB7D00' style='height:25px; font-size:12px; color:#000000; line-height:180%; text-align: left;'>");
            content.Append("<tr>");
            content.Append("<td align='center' valign='top' bgcolor='#FFFFFF'>");


            content.Append("<div style='background-color:#FFECD9; text-align:left; line-height:28px;'>");
            content.Append("&nbsp;[小提醒]<font color='#666666'> 如有其它疑问，请到<a href='" + WebInit.webBaseConfig.WebUrl + "' target='_blank'>" + WebInit.webBaseConfig.WebUrl + "</a>查询，或电话010-62132803咨询! </font>");
            content.Append("</div>");


            content.Append("<div style='width:95%; text-align:left; border-bottom:dashed #999999; border-bottom-width:1px; padding:7px;' >");
            content.Append("<strong>亲爱的" + UserName + "，</strong><br/>");
            content.Append("拼搏在线已将您的订单信息发送过来。");
            content.Append("</div>");

            content.Append(GetProductDetails(stepType));

            content.Append("</td>");
            content.Append("</tr>");
            content.Append("</table>");
            content.Append("");
            return content.ToString();
        }

        private string GetProductDetails(string stepType)
        {
            string urlShowOrder = WebInit.webBaseConfig.WebUrl + "UserCenter/ShowOrder.aspx";
            StringBuilder content = new StringBuilder();
            if (Type == "0" || Type == "1")
            {
                string[] result = GetContentByStep(stepType);
                content.Append(result[0]);

                content.Append("<div  style='width:95%; text-align:left; border-bottom:dashed #999999; border-bottom-width:1px; padding:7px;'>");
                content.Append("<strong>订单信息:</strong>");
                content.Append("<div style='padding-left:15px;'>");
                content.Append(string.Format("订单号：{0}<br/>", Order["OrderID"]));
                content.Append(string.Format("下单时间：{0}<br/>", Order["OrderDate"]));
                content.Append(string.Format("订单状态：{0}({1})<br/>", WebFunc.FormartTipName(Order["TipID"], Order["IsPay"]), Order["UpdateStaticDate"]));
                content.Append("</div>");
                content.Append("</div>");

                content.Append("<div style='width:95%; text-align:left; border-bottom:dashed #999999; border-bottom-width:1px; padding:7px;'>");
                if (string.IsNullOrEmpty(Order["PortTypeName"].ToString()) || Order["PortPrice"].ToString() == "0")
                {
                }
                else
                {
                    //content.Append(string.Format("&nbsp;&nbsp;收货方式：{0}", Order["PortTypeName"]));
                    content.Append(string.Format("软件狗快递费：{0}<br/>", Method.FormatMoney(Order["PortPrice"])));
                }
                content.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
                content.Append(string.Format("付款方式：{0}<br/>", Order["PayTypeName"]));
                content.Append("</div>");

                content.Append("<div style='width:95%; text-align:left; border-bottom:dashed #999999; border-bottom-width:1px; padding:7px;' >");
                content.Append("<strong>费用信息:</strong>");
                content.Append("<div style='padding-left:15px;'>");
                content.Append("总数量：" + result[1] + "；总价格:" + string.Format("{0:C2}", decimal.Parse(result[2])));
                content.Append("</div>");
                content.Append("</div>");

                content.Append("<div  style='width:95%; text-align:left; padding:7px;' >");
                content.Append(string.Format("<a href='{0}?OrderID={1}'><strong>查看订单</strong></a>", urlShowOrder, OrderID));
                content.Append("<br/>");
                content.Append("如果您点击上述链接无效，请把下面的代码拷贝到浏览器的地址栏中：");
                content.Append("<br/>");
                content.Append("<font color='#0033FF'>");
                content.Append(urlShowOrder + "?OrderID=" + OrderID);
                content.Append("</font>");
                content.Append("</div>");
            }
            else if (Type == "2")
            {
                content.Append("<div  style='width:95%; text-align:left; border-bottom:dashed #999999; border-bottom-width:1px; padding:7px;'>");
                content.Append("<strong>订单信息:</strong>");
                content.Append("<div style='padding-left:15px;'>");
                content.Append(string.Format("订单号：{0}<br/>", Order["OrderID"]));
                content.Append(string.Format("下单时间：{0}<br/>", Order["OrderDate"]));
                content.Append(string.Format("订单状态：{0}({1})<br/>", WebFunc.GetPBnetChargeTipName(Order["State"]), Order["UpdateStaticDate"]));
                content.Append("</div>");
                content.Append("</div>");

                content.Append("<div style='width:95%; text-align:left; border-bottom:dashed #999999; border-bottom-width:1px; padding:7px;'>");

                content.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
                content.Append(string.Format("付款方式：{0}<br/>", Order["PayTypeName"]));
                content.Append("</div>");

                content.Append("<div style='width:95%; text-align:left; border-bottom:dashed #999999; border-bottom-width:1px; padding:7px;' >");
                content.Append("<strong>费用信息:</strong>");
                content.Append("<div style='padding-left:15px;'>");
                content.Append("充值金额:" + string.Format("{0:C2}", Convert.ToDecimal(Order["PayMoney"]) - Convert.ToDecimal(Order["HasPayedPrice"])));
                content.Append("</div>");
                content.Append("</div>");

                content.Append("<div  style='width:95%; text-align:left; padding:7px;' >");
                content.Append(string.Format("<a href='/UserCenter/User_Center.aspx?myUrl=Money_Log.aspx'><strong>查看</strong></a>", urlShowOrder, OrderID));
                content.Append("<br/>");
                content.Append("如果您点击上述链接无效，请把下面的代码拷贝到浏览器的地址栏中：");
                content.Append("<br/>");
                content.Append("<font color='#0033FF'>");
                content.Append(WebInit.webBaseConfig.WebUrl + "/UserCenter/User_Center.aspx?myUrl=Money_Log.aspx");
                content.Append("</font>");
                content.Append("</div>");
            }
            return content.ToString();


        }

        private string[] GetContentByStep(string stepType)
        {
            string[] result = new string[3];
            //ID=<%#Pbzx.Common.Input.Encrypt(Eval("pb_SoftID").ToString()) %>
            string urlShowBookDetail = WebInit.webBaseConfig.WebUrl + "Soft_explain.aspx";
            StringBuilder content = new StringBuilder();
            int count = 0;
            decimal totalPrice = 0;
            if (stepType == "1")
            {
                content.Append("<div  style='width:95%; text-align:left; border-bottom:dashed #999999; border-bottom-width:1px; padding:7px;' >");
                content.Append("<strong>订单清单:</strong>");
                content.Append("<table width='96%' border='0' align='center'cellpadding='2' cellspacing='1' bgcolor='#CCCCCC' style='height:25px; font-size:12px; color:#000000; line-height:180%; text-align: left;' >");
                content.Append("<tr bgcolor='#EFEFEF'>");
                content.Append("<td width='34%'><strong>软件名称</strong></td>");
                content.Append("<td width='46%'><strong>注册方式</strong></td>");
                content.Append("<td width='20%' align='center'><strong>总售价</strong></td>");
                content.Append("</tr>");
                foreach (DataRow dr in OrderDetail.Tables[0].Rows)
                {
                    count++;
                    decimal tempPrice = Method.CalRowPrice(dr["Quatity"], dr["RegType"]);
                    content.Append("<tr bgcolor='#FFFFFF'>");
                    content.Append(string.Format("<td><a href='{0}?ID={1}' title='{2}'>{3}</a></td>", urlShowBookDetail, Input.Encrypt(dr["ProductID"].ToString()), dr["pb_SoftName"], dr["pb_SoftName"].ToString()));
                    content.Append(string.Format("<td>{0}</td>", WebFunc.CheckRegTye(dr["RegType"], dr["pb_TypeName"], dr["pb_DemoUrl"], dr["pb_RegUrl"])));
                    content.Append(string.Format("<td>{0}</td>", string.Format("{0:C2}", tempPrice)));
                    content.Append("</tr>");
                    totalPrice += tempPrice;
                }
                content.Append("</table>");
                content.Append("</div>");
            }
            else if (stepType == "2")
            {
                content.Append("<div  style='width:95%; text-align:left; border-bottom:dashed #999999; border-bottom-width:1px; padding:7px;' >");
                content.Append("<strong>软件清单:</strong>");
                content.Append("<table width='96%' border='0' align='center'cellpadding='2' cellspacing='1' bgcolor='#CCCCCC' style='height:25px; font-size:12px; color:#000000; line-height:180%; text-align: left;' >");
                content.Append("<tr bgcolor='#EFEFEF'>");
                content.Append("<td width='24%'><strong>软件名称</strong></td>");
                content.Append("<td width='36%'><strong>注册方式</strong></td>");
                content.Append("<td width='20%' align='center'><strong>总售价</strong></td>");
                content.Append("<td width='20%' align='center'><strong>处理结果</strong></td>");
                content.Append("</tr>");
                foreach (DataRow dr in OrderDetail.Tables[0].Rows)
                {
                    count++;
                    decimal tempPrice = Method.CalRowPrice(dr["Quatity"], dr["RegType"]);
                    content.Append("<tr bgcolor='#FFFFFF'>");
                    content.Append(string.Format("<td><a href='{0}?ID={1}' title='{2}'>{3}</a></td>", urlShowBookDetail, Input.Encrypt(dr["ProductID"].ToString()), dr["pb_SoftName"], dr["pb_SoftName"].ToString()));
                    content.Append(string.Format("<td>{0}</td>", WebFunc.CheckRegTye(dr["RegType"], dr["pb_TypeName"], dr["pb_DemoUrl"], dr["pb_RegUrl"])));
                    content.Append(string.Format("<td>{0}</td>", string.Format("{0:C2}", tempPrice)));
                    content.Append(string.Format("<td>{0}</td>", WebFunc.GetProductResultByType(Convert.ToInt32(Order["TipID"]), Convert.ToInt32(Order["IsPay"]), dr["RegType"].ToString(), dr["serial"].ToString(), Convert.ToInt32(dr["State"]))));
                    content.Append("</tr>");
                    totalPrice += tempPrice;
                }
                content.Append("</table>");
                content.Append("</div>");
            }

            result[0] = content.ToString();
            result[1] = count.ToString();
            result[2] = totalPrice.ToString();
            return result;
        }


        /// <summary>
        /// 开始发送邮件
        /// </summary>
        public void StartSendEmail()
        {
            if (Type == "0")
            {
                Order = new Pbzx.BLL.PBnet_Orders().SelectOrdersByOrderID(OrderID).Tables[0].Rows[0];
            }
            else if (Type == "1")
            {
                Order = new Pbzx.BLL.PBnet_Orders_Delegates().SelectOrdersByOrderID(OrderID).Tables[0].Rows[0];
            }
            OrderDetail = new Pbzx.BLL.PBnet_OrderDetail().SelectOrderDetailByOrderID(OrderID);
            UserName = Order["ReceiverName"].ToString();
            try
            {
                //远程邮件发送开关
                string jmailString = ConfigurationManager.AppSettings["LongJmail"];
                if (jmailString == null || jmailString != "true")
                {
                    //Email email = new Email(ToEmail, EmailOrderSubject, GetEmailOrderContent(StepType));
                    //email.Send("拼搏在线彩神通软件");
                }
                else
                {
                    //远程调用
                    Web_JmailService.WebService1 wb = new Web_JmailService.WebService1();
                    wb.GetEmail(ToEmail, EmailOrderSubject, GetEmailOrderContent(StepType));
                }
                Pbzx.Common.ErrorLog.WriteLogMeng("基本邮件发送", "用户：" + UserName + " 邮件发送成功", false, false);
            }
            catch (Exception ex)
            {
                Pbzx.Common.ErrorLog.WriteLogMeng("基本邮件发送", ex.ToString(), false, false);

            }

        }

        public void SendEmail()
        {
            //StartSendEmail();
            //ThreadStart threadStartSendEmail = new ThreadStart(StartSendEmail);
            //Thread threadSendEmail = new Thread(threadStartSendEmail);
            //threadSendEmail.Start();

        }
    }
}
