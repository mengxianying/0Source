using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Globalization;
using net.pay.cncard.Security;
using System.Configuration;
using Pbzx.Common;
namespace Pbzx.Web.PortSampleForDotNet
{
    /// <summary>
    /// Summary description for SendOrder.
    /// </summary>
    public partial class SendOrder : System.Web.UI.Page
    {

        protected string c_mid;			//�̻���ţ��������̻��ɹ��󼴿ɻ�ã������������̻��ɹ����ʼ��л�ȡ�ñ��
        protected string c_order;		//�̻���վ���ɵĶ����ţ������ظ�
        protected string c_name;		//�̻������е��ջ�������
        protected string c_address;		//�̻������е��ջ��˵�ַ
        protected string c_tel;			//�̻������е��ջ��˵绰
        protected string c_post;		//�̻������е��ջ����ʱ�
        protected string c_email;		//�̻������е��ջ���Email
        protected string c_orderamount;	//�̻������ܽ��
        protected string c_ymd;			//�̻������Ĳ������ڣ���ʽΪ"yyyymmdd"����20050102
        protected string c_moneytype;	//֧�����֣�0Ϊ�����
        protected string c_retflag;		//�̻�����֧���ɹ����Ƿ���Ҫ�����̻�ָ�����ļ���0�����÷��� 1����Ҫ����
        protected string c_paygate;		//������̻���վѡ�����������ø�ֵ������ֵ�ɲμ�������֧��@�������ӿ��ֲᡷ��¼һ�����������֧��@��ѡ�����д���Ϊ��ֵ��
        protected string c_returl;		//���c_retflagΪ1ʱ����ֵ����֧���ɹ��󷵻ص��ļ���·��
        protected string c_memo1;		//�̻���Ҫ��֧�����֪ͨ��ת�����̻�����һ
        protected string c_memo2;		//�̻���Ҫ��֧�����֪ͨ��ת�����̻�������
        protected string c_signstr;		//�̻��Զ�����Ϣ����MD5ǩ������ַ���
        protected string c_pass;		//֧����Կ�����¼�̻������̨�����ʻ���Ϣ->������Ϣ->��ȫ��Ϣ�е�֧����Կ��
        protected string notifytype;	//0��֪ͨͨ��ʽ/1������֪ͨ��ʽ����ֵΪ��֪ͨͨ��ʽ
        protected string c_language;	//�������˹��ʿ�֧��ʱ����ʹ�ø�ֵ����������������֧��ʱ��ҳ�����֣�ֵΪ��0����ҳ����ʾΪ����/1����ҳ����ʾΪӢ��


        protected void Page_Load(object sender, System.EventArgs e)
        {
            ViewState["Type"] = "0";
            if (!string.IsNullOrEmpty(Request["type"]))
            {
                if (Request["type"] == "1")
                {
                    ViewState["Type"] = "1";
                }
            }
            LoginSort login = new LoginSort();
            if (!login["manager_user"])
            {
                Response.Redirect("/login.aspx");
                return;
            }

            if (Request["OrderID"] == "")
            {
                Response.Write("<script>alert('�Բ��𣡶�����Ŵ���');history.go(-1);</script>");
                return;
            }

            //���ն�����
            if (string.IsNullOrEmpty(Request["OrderID"]))
            {
                if (string.IsNullOrEmpty(Request["ChargeID"]))
                {
                    Response.Write("<script>alert('�Բ��𣡶�����Ŵ���');history.go(-1);</script>");
                    return;
                }
                else
                {
                    if (!WebFunc.CheckOrderIsValidate(Request["ChargeID"]))
                    {
                        Response.Write("<script>alert('�Բ��𣡸ö�����ȡ��������ʧЧ��');history.go(-1);</script>");
                        return;
                    }
                    DataSet ds = new Pbzx.BLL.PBnet_Charge().GetList(" OrderID='" + Input.FilterAll(Request["ChargeID"]) + "' ");
                    DataRow row = null;
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        row = ds.Tables[0].Rows[0];
                        c_orderamount = Convert.ToDecimal(ds.Tables[0].Rows[0]["PayMoney"]).ToString("0.00");
                    }
                    else
                    {
                        Response.Write("<script>alert('�Բ��𣡶�������');history.go(-1);</script>");
                        return;
                    }
                    Pbzx.BLL.PBnet_PayType payTypeBLL = new Pbzx.BLL.PBnet_PayType();
                    Pbzx.Model.PBnet_PayType payModel = payTypeBLL.GetModel(Convert.ToInt32(row["PayTypeID"]));
                    // Put user code to initialize the page here
                    DateTime dt = DateTime.Now;
                    string timeStr = dt.ToString("HHmmss", DateTimeFormatInfo.InvariantInfo);
                    c_mid = ConfigurationManager.AppSettings["c_mid"].ToString();
                    c_pass = ConfigurationManager.AppSettings["c_pass"].ToString();
                    Pbzx.Model.PBnet_UserTable realUser = Pbzx.BLL.PBnet_UserTable.GetCurrentRealInfoUser();
                    c_name = realUser.RealName;
                    c_address = realUser.Address;
                    c_tel = realUser.Telphone;
                    c_post = realUser.PostCode;
                    c_email = realUser.Email;
                    c_ymd = string.Format("{0:yyyyMMdd}", DateTime.Parse(row["OrderDate"].ToString().Trim()));
                    c_order = row["OrderID"].ToString();
                    //c_orderamount = "0.01";
                    c_moneytype = "0";
                    c_retflag = "1";
                    string pay = "";
                    //if (payModel != null)
                    //{
                    //    pay = payModel.PayValue.ToString();
                    //}
                    c_paygate = pay;
                    c_returl = WebInit.webBaseConfig.WebUrl + "YunWangCncard/GetPayNotify.aspx";	//�õ�ַΪ�̻���������֧�����֪ͨ��ҳ�棬���ύ�����ļ���(��Ӧ�����ļ���GetPayNotify.aspx)
                    c_memo1 = row["PayTypeID"].ToString(); //Server.UrlEncode(row["PayTypeName"] + "|" + row["PortTypeName"]);
                    c_language = "0";
                    notifytype = "1";
                    // + c_name + c_address + c_tel + c_post + c_email
                    string srcStr = c_mid + c_order + c_orderamount + c_ymd + c_moneytype + c_retflag + c_returl + c_paygate + c_memo1 + c_memo2 + notifytype + c_language + c_pass;
                    c_signstr = cnSecurity.EncryptMD5(srcStr);
                    Pbzx.Common.ErrorLog.WriteLogMeng("���߽���", "����֧����ʼ�������ţ�" + c_order, true, true);
                }
            }
            else
            {
                if (!WebFunc.CheckOrderIsValidate(Request["OrderID"]))
                {
                    Response.Write("<script>alert('�Բ��𣡸ö�����ȡ��������ʧЧ��');history.go(-1);</script>");
                    return;
                }
                DataTable dtOrders = WebFunc.GetDsOrder(Request["OrderID"]);
                if (dtOrders == null)
                {
                    Page.RegisterStartupScript(Pbzx.Web.WebFunc.GetGuid(), Pbzx.Common.JS.myAlert1("", "�Բ��𣡶�������", 400, "1", "history.go(-1);", "", false, false));
                    return;
                }
                DataRow row = dtOrders.Rows[0];
                decimal payJE = 0;
                if (dtOrders.TableName == "PBnet_Orders" || dtOrders.TableName == "PBnet_Orders_Delegates")
                {
                    payJE = Convert.ToDecimal(dtOrders.Rows[0]["HasNotPayedPrice"]);
                }
                else if (dtOrders.TableName == "PBnet_Charge")
                {
                    payJE = Convert.ToDecimal(dtOrders.Rows[0]["PayMoney"]) - Convert.ToDecimal(dtOrders.Rows[0]["HasPayedPrice"]);
                }

                c_orderamount = string.Format("{0:f}", payJE);
                //_TipID = Convert.ToInt32(ds.Tables[0].Rows[0]["TipID"]);
                Pbzx.BLL.PBnet_PayType payTypeBLL = new Pbzx.BLL.PBnet_PayType();
                Pbzx.Model.PBnet_PayType payModel = payTypeBLL.GetModel(Convert.ToInt32(row["PayTypeID"]));
                // Put user code to initialize the page here
                DateTime dt = DateTime.Now;
                string timeStr = dt.ToString("HHmmss", DateTimeFormatInfo.InvariantInfo);
                c_mid = ConfigurationManager.AppSettings["c_mid"].ToString();
                c_pass = ConfigurationManager.AppSettings["c_pass"].ToString();
                c_name = "";// row["ReceiverName"].ToString();
                c_address = "";// row["ReceiverAddress"].ToString();
                c_tel = "";// row["ReceiverPhone"].ToString();
                c_post = "";// row["ReceiverPostalCode"].ToString();
                c_email = "";// row["ReceiverEmail"].ToString();
                c_ymd = string.Format("{0:yyyyMMdd}", DateTime.Parse(row["OrderDate"].ToString().Trim()));
                c_order = row["OrderID"].ToString();
                //c_orderamount = "0.01";
                c_moneytype = "0";
                c_retflag = "1";
                string pay = "";
                if (payModel != null)
                {
                    pay = payModel.PayValue.ToString();
                }
                c_paygate = pay;
                c_returl = WebInit.webBaseConfig.WebUrl + "YunWangCncard/GetPayNotify.aspx";	//�õ�ַΪ�̻���������֧�����֪ͨ��ҳ�棬���ύ�����ļ���(��Ӧ�����ļ���GetPayNotify.aspx)
                c_memo1 = "PayTypeName"; //Server.UrlEncode(row["PayTypeName"] + "|" + row["PortTypeName"]);             
                c_language = "0";
                notifytype = "1";
                // + c_name + c_address + c_tel + c_post  + c_email  
                string srcStr = c_mid + c_order + c_orderamount + c_ymd + c_moneytype + c_retflag + c_returl + c_paygate + c_memo1 + c_memo2 + notifytype + c_language + c_pass;
                c_signstr = cnSecurity.EncryptMD5(srcStr);
                Pbzx.Common.ErrorLog.WriteLogMeng("���߽���", "����֧����ʼ�������ţ�" + c_order, true, true);
            }
        }

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

        }
        #endregion
    }
}















































































//<td align="left">
//                              <input type="hidden" name="c_name" value="<%=c_name%>"></td>
//                          <td align="left">
//                              <input type="hidden" name="c_address" value="<%=c_address%>"></td>
//                          <td align="left">
//                              <input type="hidden" name="c_tel" value="<%=c_tel%>"></td>
//                          <td align="left">
//                              <input type="hidden" name="c_post" value="<%=c_post%>"></td>
//                          <td align="left">
//                              <input type="hidden" name="c_email" value="<%=c_email%>"></td>