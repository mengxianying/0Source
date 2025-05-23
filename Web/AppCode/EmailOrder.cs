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
        /// Email���췽��
        /// </summary>
        /// <param name="toEmail">Ҫ���͵���Email��ַ</param>
        /// <param name="orderID">������</param>
        /// <param name="type">����0�����������1����������2����ֵ����</param>
        /// <param name="stepType">����1:�¶�����2�������������</param>
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
            get { return "ƴ�������������:" + OrderID + "��ϵͳ�Զ����ͣ�����ظ���"; }
        }

        private string GetEmailOrderContent(string stepType)
        {

            //string title = "";

            StringBuilder content = new StringBuilder();
            content.Append("<table width='610' border='0' align='center' cellpadding='0' cellspacing='0'>");
            content.Append("<tr>");
            content.Append("<td width='330'><a href='" + WebInit.webBaseConfig.WebUrl + "' ><img border='0' alt='ƴ�����߲���ͨ���' src='" + WebInit.webBaseConfig.WebUrl + "images/web/EmailLogo.gif' width='215' height='50' /></a></td>");
            content.Append("<td width='280' valign='bottom'>");
            content.Append("<div style='background-color:#FB7D00; width:100%; padding-top:7px; font-size:12px; color:#FFFFFF;  text-align:center;'>");
            content.Append("<a href='" + WebInit.webBaseConfig.WebUrl + "' target='_blank' style='color:#FFFFFF; text-decoration:none;'>ƴ����ҳ</a> | ");
            content.Append("<a href='" + WebInit.webBaseConfig.WebUrl + "Soft.aspx' target='_blank' style='color:#FFFFFF; text-decoration:none;'>����̳�</a> | ");
            content.Append("<a href='" + WebInit.webBaseConfig.WebUrl + "SoftwarePrices.htm' target='_blank' style='color:#FFFFFF; text-decoration:none;'>ע�Ṻ��</a> | ");
            content.Append("<a href='http://bbs.pinble.com/' target='_blank' style='color:#FFFFFF; text-decoration:none;'>ƴ����̳</a>");
            content.Append("</div>");
            content.Append("</td>");
            content.Append("</tr>");
            content.Append("</table>");

            content.Append("<table width='610' border='0' align='center' cellpadding='0' cellspacing='7' bgcolor='#FB7D00' style='height:25px; font-size:12px; color:#000000; line-height:180%; text-align: left;'>");
            content.Append("<tr>");
            content.Append("<td align='center' valign='top' bgcolor='#FFFFFF'>");


            content.Append("<div style='background-color:#FFECD9; text-align:left; line-height:28px;'>");
            content.Append("&nbsp;[С����]<font color='#666666'> �����������ʣ��뵽<a href='" + WebInit.webBaseConfig.WebUrl + "' target='_blank'>" + WebInit.webBaseConfig.WebUrl + "</a>��ѯ����绰010-62132803��ѯ! </font>");
            content.Append("</div>");


            content.Append("<div style='width:95%; text-align:left; border-bottom:dashed #999999; border-bottom-width:1px; padding:7px;' >");
            content.Append("<strong>�װ���" + UserName + "��</strong><br/>");
            content.Append("ƴ�������ѽ����Ķ�����Ϣ���͹�����");
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
                content.Append("<strong>������Ϣ:</strong>");
                content.Append("<div style='padding-left:15px;'>");
                content.Append(string.Format("�����ţ�{0}<br/>", Order["OrderID"]));
                content.Append(string.Format("�µ�ʱ�䣺{0}<br/>", Order["OrderDate"]));
                content.Append(string.Format("����״̬��{0}({1})<br/>", WebFunc.FormartTipName(Order["TipID"], Order["IsPay"]), Order["UpdateStaticDate"]));
                content.Append("</div>");
                content.Append("</div>");

                content.Append("<div style='width:95%; text-align:left; border-bottom:dashed #999999; border-bottom-width:1px; padding:7px;'>");
                if (string.IsNullOrEmpty(Order["PortTypeName"].ToString()) || Order["PortPrice"].ToString() == "0")
                {
                }
                else
                {
                    //content.Append(string.Format("&nbsp;&nbsp;�ջ���ʽ��{0}", Order["PortTypeName"]));
                    content.Append(string.Format("�������ݷѣ�{0}<br/>", Method.FormatMoney(Order["PortPrice"])));
                }
                content.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
                content.Append(string.Format("���ʽ��{0}<br/>", Order["PayTypeName"]));
                content.Append("</div>");

                content.Append("<div style='width:95%; text-align:left; border-bottom:dashed #999999; border-bottom-width:1px; padding:7px;' >");
                content.Append("<strong>������Ϣ:</strong>");
                content.Append("<div style='padding-left:15px;'>");
                content.Append("��������" + result[1] + "���ܼ۸�:" + string.Format("{0:C2}", decimal.Parse(result[2])));
                content.Append("</div>");
                content.Append("</div>");

                content.Append("<div  style='width:95%; text-align:left; padding:7px;' >");
                content.Append(string.Format("<a href='{0}?OrderID={1}'><strong>�鿴����</strong></a>", urlShowOrder, OrderID));
                content.Append("<br/>");
                content.Append("������������������Ч���������Ĵ��뿽����������ĵ�ַ���У�");
                content.Append("<br/>");
                content.Append("<font color='#0033FF'>");
                content.Append(urlShowOrder + "?OrderID=" + OrderID);
                content.Append("</font>");
                content.Append("</div>");
            }
            else if (Type == "2")
            {
                content.Append("<div  style='width:95%; text-align:left; border-bottom:dashed #999999; border-bottom-width:1px; padding:7px;'>");
                content.Append("<strong>������Ϣ:</strong>");
                content.Append("<div style='padding-left:15px;'>");
                content.Append(string.Format("�����ţ�{0}<br/>", Order["OrderID"]));
                content.Append(string.Format("�µ�ʱ�䣺{0}<br/>", Order["OrderDate"]));
                content.Append(string.Format("����״̬��{0}({1})<br/>", WebFunc.GetPBnetChargeTipName(Order["State"]), Order["UpdateStaticDate"]));
                content.Append("</div>");
                content.Append("</div>");

                content.Append("<div style='width:95%; text-align:left; border-bottom:dashed #999999; border-bottom-width:1px; padding:7px;'>");

                content.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
                content.Append(string.Format("���ʽ��{0}<br/>", Order["PayTypeName"]));
                content.Append("</div>");

                content.Append("<div style='width:95%; text-align:left; border-bottom:dashed #999999; border-bottom-width:1px; padding:7px;' >");
                content.Append("<strong>������Ϣ:</strong>");
                content.Append("<div style='padding-left:15px;'>");
                content.Append("��ֵ���:" + string.Format("{0:C2}", Convert.ToDecimal(Order["PayMoney"]) - Convert.ToDecimal(Order["HasPayedPrice"])));
                content.Append("</div>");
                content.Append("</div>");

                content.Append("<div  style='width:95%; text-align:left; padding:7px;' >");
                content.Append(string.Format("<a href='/UserCenter/User_Center.aspx?myUrl=Money_Log.aspx'><strong>�鿴</strong></a>", urlShowOrder, OrderID));
                content.Append("<br/>");
                content.Append("������������������Ч���������Ĵ��뿽����������ĵ�ַ���У�");
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
                content.Append("<strong>�����嵥:</strong>");
                content.Append("<table width='96%' border='0' align='center'cellpadding='2' cellspacing='1' bgcolor='#CCCCCC' style='height:25px; font-size:12px; color:#000000; line-height:180%; text-align: left;' >");
                content.Append("<tr bgcolor='#EFEFEF'>");
                content.Append("<td width='34%'><strong>�������</strong></td>");
                content.Append("<td width='46%'><strong>ע�᷽ʽ</strong></td>");
                content.Append("<td width='20%' align='center'><strong>���ۼ�</strong></td>");
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
                content.Append("<strong>����嵥:</strong>");
                content.Append("<table width='96%' border='0' align='center'cellpadding='2' cellspacing='1' bgcolor='#CCCCCC' style='height:25px; font-size:12px; color:#000000; line-height:180%; text-align: left;' >");
                content.Append("<tr bgcolor='#EFEFEF'>");
                content.Append("<td width='24%'><strong>�������</strong></td>");
                content.Append("<td width='36%'><strong>ע�᷽ʽ</strong></td>");
                content.Append("<td width='20%' align='center'><strong>���ۼ�</strong></td>");
                content.Append("<td width='20%' align='center'><strong>������</strong></td>");
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
        /// ��ʼ�����ʼ�
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
                //Զ���ʼ����Ϳ���
                string jmailString = ConfigurationManager.AppSettings["LongJmail"];
                if (jmailString == null || jmailString != "true")
                {
                    //Email email = new Email(ToEmail, EmailOrderSubject, GetEmailOrderContent(StepType));
                    //email.Send("ƴ�����߲���ͨ���");
                }
                else
                {
                    //Զ�̵���
                    Web_JmailService.WebService1 wb = new Web_JmailService.WebService1();
                    wb.GetEmail(ToEmail, EmailOrderSubject, GetEmailOrderContent(StepType));
                }
                Pbzx.Common.ErrorLog.WriteLogMeng("�����ʼ�����", "�û���" + UserName + " �ʼ����ͳɹ�", false, false);
            }
            catch (Exception ex)
            {
                Pbzx.Common.ErrorLog.WriteLogMeng("�����ʼ�����", ex.ToString(), false, false);

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
