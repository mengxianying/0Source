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
using Pinble_Sms.cnwoxp;
using System.IO;
using System.Xml;

namespace Pinble_Market.admin.Note
{
    public partial class SMSStart : System.Web.UI.Page
    {
        private string g_uid = ConfigurationManager.AppSettings["g_uid"];//登陆账户
        private string g_eid = ConfigurationManager.AppSettings["g_eid"];//企业ID代码
        private string g_pwd = ConfigurationManager.AppSettings["g_pwd"]; //登陆密码.明文
        private string g_gate_id = ConfigurationManager.AppSettings["g_gate_id"];//使用通道
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Label1.Text = "当前余额:0.00";
            if (g_uid == "" || g_eid == "" || g_pwd == "" || g_gate_id == "")
            {
                Response.Write("参数不全!");
                return;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            WebSMS wsm = new WebSMS();
            if (wsm == null)
            {
                Response.Write("<script>alert('网关初始化失败!');window.location='Default.aspx';</script>");
                return;
            }
            string strIdentity = wsm.GetIdentityMark(Int32.Parse(g_eid), g_uid, g_pwd, Int32.Parse(g_gate_id));
            if (strIdentity == null || strIdentity == "")
            {
                Response.Write("<script>alert('获取标识串失败!');window.location='Default.aspx';</script>");
                return;
            }
            if (this.t_sendNo.Text.ToString().Trim() == "" || this.t_sendMemo.Text.ToString().Trim() == "")
            {
                Response.Write("<script>alert('接收号码或者短信内容没有输入!');window.location='Default.aspx';</script>");
                return;
            }
            if (this.t_sendTime.Text.ToString().Trim() != "")
            {
                DateTime dt;
                if (!DateTime.TryParse(this.t_sendTime.Text.ToString().Trim(), out dt))
                {
                    Response.Write("<script>alert('定时格式错误!');window.location='Default.aspx';</script>");
                    return;
                }
                if (dt <= DateTime.Now)
                {

                    Response.Write("<script>alert('定时时间必须大于当前时间!');window.location='Default.aspx';</script>");
                    return;

                }
            }
            //快速发送.直接提交到运营商网关
            SendResult status = wsm.FastSend(strIdentity, this.t_sendNo.Text.ToString().Trim(), this.t_sendMemo.Text.ToString().Trim(), this.t_sendTime.Text.ToString().Trim(), "");
            //发送成功
            string js = "";
            if (status.RetCode > 0)
            {
                js = "发送成功,共发送:" + status.RetCode.ToString() + "条";
                this.Label1.Text = "当前余额:" + wsm.GetMoney(strIdentity).ToString("0.00");
            }
            else //发送失败
            {
                js = "发送失败,错误代码:" + status.RetCode.ToString() + ",原因:" + status.ErrorDesc;
            }
            js = js.Replace("\"", "\\\"");
            js = js.Replace("\'", "\\\'");
            Response.Write("<script>alert('" + js + "');window.location='SMSStart.aspx';</script>");
        }
        /// <summary>
        /// 收到的XML转成dataset型
        /// </summary>
        /// <param name="xmlData"></param>
        /// <returns></returns>
        public DataSet ConvertXMLToDataSet(string xmlData)
        {
            StringReader stream = null;
            XmlTextReader reader = null;
            try
            {
                DataSet xmlDS = new DataSet();
                stream = new StringReader(xmlData);
                reader = new XmlTextReader(stream);
                xmlDS.ReadXml(reader);
                return xmlDS;
            }
            catch (Exception ex)
            {
                string strTest = ex.Message;
                return null;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
        //从服务上取短信.功能被放弃。接收短信修改PUSH下发给客户。
        private void ReadSMS()
        {
            WebSMS wsm = new WebSMS();
            if (wsm == null)
            {
                Response.Write("<script>alert('网关初始化失败!');window.location='Default.aspx';</script>");
                return;
            }

            string strIdentity = wsm.GetIdentityMark(Int32.Parse(g_eid), g_uid, g_pwd, Int32.Parse(g_gate_id));
            if (strIdentity == null || strIdentity == "")
            {
                Response.Write("<script>alert('获取标识串失败!');window.location='Default.aspx';</script>");
                return;
            }
            try
            {
                string readxml = wsm.ReadXml(strIdentity);
                //如果是数字代表返回失败
                int code = 0;
                if (Int32.TryParse(readxml, out code))
                {
                    this.div_sms.InnerText = "接收失败,错误代码:" + code.ToString().Trim() + ",原因:" + wsm.GetErrorHint(code);
                    return;
                }
                if (readxml == null || readxml.ToString().Trim() == "")
                {
                    this.div_sms.InnerText = "没有收到短信回复!";
                    this.GridView1.DataSource = null;
                    this.GridView1.DataBind();
                    return;
                }
                this.div_sms.Visible = false;
                DataSet ds = ConvertXMLToDataSet(readxml);
                this.GridView1.DataSource = ds.Tables[0];
                this.GridView1.DataBind();
            }
            catch (Exception ex)
            {
                this.div_sms.InnerText = "接收异常:原因" + ex.Message.ToString();
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            ReadSMS();
        }
    }
}
