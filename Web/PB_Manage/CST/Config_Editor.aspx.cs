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
using Pbzx.Common;

namespace Pbzx.Web.PB_Manage.CST
{
    public partial class Config_Editor : AdminBasic
    {
        /// <summary>
        /// ҳ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Pbzx.BLL.CN_Config configBLL = new Pbzx.BLL.CN_Config();
                Pbzx.Model.CN_Config MyConfig;
                string str = Request.QueryString["ID"];

                MyConfig = configBLL.GetModel(Convert.ToInt32(str));

                lblName.Text = MyConfig.ConfigName;
                txtValue.Text = MyConfig.ConfigValue;
                txtDetails.Text = MyConfig.ConfigDetails;
                lblFlag.Text = (MyConfig.ConfigFlag).ToString();
                lblStatus.Text = GetFlag(MyConfig.Status.ToString());

            }
        }
        /// <summary>
        /// ��ʽ����ʾ����
        /// </summary>
        /// <param name="objnum"></param>
        /// <returns></returns>
        protected string GetFlag(object objnum)
        {
            string Flag = "";
            int intnum = int.Parse(objnum.ToString());
            switch (intnum)
            {
                case 0:
                    Flag = "<font color='#009900'>Ͷ��ʹ��</font>";
                    break;
                case 1:
                    Flag = "<font color='#666666'>�ȴ�ʹ��</font>";
                    break;
                case 10:
                    Flag = "<font color='#660033'>�����޸�</font>";
                    break;
                default:
                    Flag = "";
                    break;
            }
            return Flag;
        }
        /// <summary>
        /// ����޸�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void bt_ok_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.CN_Config configBLL = new Pbzx.BLL.CN_Config();
            string str = Request.QueryString["ID"];
            Pbzx.Model.CN_Config MyConfig = configBLL.GetModel(Convert.ToInt32(str));

            

            //MyConfig.ConfigName = this.lblName.Text;
            MyConfig.ConfigValue = this.txtValue.Text;
            MyConfig.ConfigDetails = this.txtDetails.Text;
            //���ж�����״̬�Ƿ����ã���Ϊ�����޸ĵ�ʱ�򲻸������÷�������ȴ�����
            if (MyConfig.Status == 1 || MyConfig.Status == 0)
            {
                MyConfig.Status = 1;
            }  
            //MyConfig.ConfigFlag = int.Parse(this.lblFlag.Text);
            //MyConfig.Status = int.Parse(this.lblStatus.Text);

            if (configBLL.Update(MyConfig))
            {
                // ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("�޸ĳɹ�."));               
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("�޸�", "�޸�������Ϣ[" + MyConfig.ConfigName + "].");
                Response.Write("<script>alert('�޸ĳɹ�');window.opener.location.reload();window.opener.focus();window.opener=null;window.open('','_self');window.close();</script>");
            }
            else
            {
                Response.Write("<script>alert('�޸�ʧ��');</script>");
            }
        }
    }
}
