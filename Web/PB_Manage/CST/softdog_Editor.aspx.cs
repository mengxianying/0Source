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
    public partial class softdog_Editor : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if(!IsPostBack)
            {
                Pbzx.BLL.SoftDogInfo dogBLL = new Pbzx.BLL.SoftDogInfo();
                Pbzx.Model.SoftDogInfo MyDog;

                string str = Request.QueryString["ID"];
                MyDog = dogBLL.GetModel(Convert.ToInt32(str));

                this.labID.Text = MyDog.SN;
                this.labCreateTime.Text = MyDog.CreateTime.ToString();
                this.txtAgentID.Text = MyDog.AgentID.ToString();
                this.txtAgentName.Text = MyDog.AgentName;
                this.txtCreater.Text = MyDog.Creater;
                this.txtSeller.Text = MyDog.Seller;
                this.txtSellTime.Text = MyDog.SellTime.ToString();
                this.txtPayType.Text = MyDog.PayType;
                this.txtOldSN.Text = MyDog.OldSN;
                this.txtSellPrice.Text = MyDog.SellPrice.ToString();
                this.txtRemarks.Text = MyDog.Remarks;
                this.rblStatus.SelectedValue = MyDog.Status.ToString();

            }
        }

        protected void bt_ok_Click(object sender, EventArgs e)
        {
            string strErrMsg = "";

            if (!OperateText.IsNumber(this.txtAgentID.Text))
            {
                strErrMsg += "֧����������.\\r\\n";
            }
            if (!OperateText.IsNumber(this.txtSellPrice.Text))
            {
                strErrMsg += "����ID��������.\\r\\n";
            }
            DateTime dt = new DateTime();
            if (!DateTime.TryParse(this.txtSellTime.Text.Trim(), out dt))
            {
                strErrMsg += "����ʱ�����ݸ�ʽ����ȷ.\\r\\n";
            }

            if (strErrMsg != "")
            {
                strErrMsg = "���ύ�������Ϣ�д������´���:\\r\\n\\r\\n" + strErrMsg + "\\r\\n���޸ĺ��������ύ.";
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                return;
            }



            Pbzx.BLL.SoftDogInfo dogBLL = new Pbzx.BLL.SoftDogInfo();
            string str = Request.QueryString["ID"];
            Pbzx.Model.SoftDogInfo MyDog = dogBLL.GetModel(Convert.ToInt32(str));

            MyDog.AgentID = int.Parse(this.txtAgentID.Text);
            MyDog.AgentName = this.txtAgentName.Text.Trim();
            MyDog.Creater = this.txtCreater.Text.Trim();
            MyDog.Seller = this.txtSeller.Text.Trim();
            MyDog.SellTime=Convert.ToDateTime(this.txtSellTime.Text);
            MyDog.PayType = txtPayType.Text;
            MyDog.OldSN=this.txtOldSN.Text.Trim();
            MyDog.SellPrice=int.Parse(this.txtSellPrice.Text);
            MyDog.Remarks = this.txtRemarks.Text.Trim();
            MyDog.Status =int.Parse(this.rblStatus.SelectedValue);

            if (dogBLL.Update(MyDog))
            {
               // ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("�޸ĳɹ�."));                
               Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("�޸�", "�޸��������Ϣ[���кţ�" + MyDog.SN + "].");
               Response.Write("<script>window.opener.location.reload();window.opener.focus();window.opener=null;window.open('','_self');window.close();</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("�޸�ʧ��."));
            }
        }
    }
}
