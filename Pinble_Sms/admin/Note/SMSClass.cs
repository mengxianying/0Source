using System;
using System.Data;
using System.Configuration;
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
    public class SMSClass
    {

        private string g_uid = ConfigurationManager.AppSettings["g_uid"];//��½�˻�
        private string g_eid = ConfigurationManager.AppSettings["g_eid"];//��ҵID����
        private string g_pwd = ConfigurationManager.AppSettings["g_pwd"]; //��½����.����
        private string g_gate_id = ConfigurationManager.AppSettings["g_gate_id"];//ʹ��ͨ��



        /// <summary>
        /// ���ŷ���
        /// </summary>
        /// <param name="strNumbers"></param>
        /// <param name="strcontent"></param>
        /// <param name="begTime"></param>
        /// <returns></returns>
        public string SetSMS(string strNumbers, string strcontent, string begTime)
        {
            WebSMS wsm = new WebSMS();

            if (wsm == null)
            {
                //Response.Write("<script>alert('�������س�ʼ��ʧ��!');window.location='Default.aspx';</script>");
                //return;
            }
            string strIdentity = wsm.GetIdentityMark(Int32.Parse(g_eid), g_uid, g_pwd, Int32.Parse(g_gate_id));
            if (strIdentity == null || strIdentity == "")
            {
                //Response.Write("<script>alert('��ȡ��ʶ��ʧ��!');window.location='Default.aspx';</script>");
                //return;
            }
            //���ٷ���.ֱ���ύ����Ӫ������
            SendResult status = wsm.FastSend(strIdentity, strNumbers, strcontent, begTime, "");
            //���ͳɹ�
            string js = "����ʧ��";
            if (status.RetCode > 0)
            {
                js = "���ͳɹ�";
                //js = "���ͳɹ�,������:" + status.RetCode.ToString() + "��";
                //this.Label1.Text = "��ǰ���:" + wsm.GetMoney(strIdentity).ToString("0.00");
            }
            else //����ʧ��
            {
                //  js = "����ʧ��,�������:" + status.RetCode.ToString() + ",ԭ��:" + status.ErrorDesc;
            }
            //js = js.Replace("\"", "\\\"");
            // js = js.Replace("\'", "\\\'");

            return js;
        }

        /// <summary>
        /// ��ѯ��ǰ���
        /// </summary>
        /// <returns></returns>
        public string GetMoney()
        {
            WebSMS wsm = new WebSMS();
            string strIdentity = wsm.GetIdentityMark(Int32.Parse(g_eid), g_uid, g_pwd, Int32.Parse(g_gate_id));
            return wsm.GetMoney(strIdentity).ToString("0.00");
        }

        /// <summary>
        /// ���ն���
        /// </summary>
        /// <returns></returns>
        public DataSet GetSMS()
        {
            WebSMS wsm = new WebSMS();
            if (wsm == null)
            {
                //   Response.Write("<script>alert('���س�ʼ��ʧ��!');window.location='Default.aspx';</script>");
                return null;
            }

            string strIdentity = wsm.GetIdentityMark(Int32.Parse(g_eid), g_uid, g_pwd, Int32.Parse(g_gate_id));
            if (strIdentity == null || strIdentity == "")
            {
                //   Response.Write("<script>alert('��ȡ��ʶ��ʧ��!');window.location='Default.aspx';</script>");
                return null;
            }

            try
            {
                string readxml = wsm.ReadXml(strIdentity);
                //��������ִ�����ʧ��
                int code = 0;
                if (Int32.TryParse(readxml, out code))
                {
                    //   this.div_sms.InnerText = "����ʧ��,�������:" + code.ToString().Trim() + ",ԭ��:" + wsm.GetErrorHint(code);
                    return null;
                }
                if (readxml == null || readxml.ToString().Trim() == "")
                {
                    //     this.div_sms.InnerText = "û���յ����Żظ�!";
                    //     this.GridView1.DataSource = null;
                    //   this.GridView1.DataBind();
                    return null;
                }
                //  this.div_sms.Visible = false;
                DataSet ds = ConvertXMLToDataSet(readxml);
                //    this.GridView1.DataSource = ds.Tables[0];
                //  this.GridView1.DataBind();
                return ds;
            }
            catch (Exception ex)
            {
                // this.div_sms.InnerText = "�����쳣:ԭ��" + ex.Message.ToString();
                return null;
            }
        }
        /// <summary>
        /// �յ���XMLת��dataset��
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
    }
}
