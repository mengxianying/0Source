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
using System.Text;

namespace Pbzx.Web.PB_Manage
{
    public partial class ProductPrice_Editor : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_SoftClass softClassBLL = new Pbzx.BLL.PBnet_SoftClass();
            //��������
            softClassBLL.BindSoftClass(this.ddlParent, 0);
            //������汾���
            Pbzx.Common.Method.BindProductVersionByEnum(ref this.ddlSoftVersion);
            //������۸񸳳�ʼֵ
            this.txtSoftdog.Text = WebInit.webBaseConfig.SoftdogPrice.ToString();
            this.txtSoftdog.Enabled = false;
            //����ʱ�丳��ʼֵ
            txtDatUpdateTime.Text = DateTime.Now.ToString();
            //��
            BindData();
        }
        private void BindData()
        {

            Pbzx.Model.PBnet_ProductPrice MyPrice;
            Pbzx.BLL.PBnet_ProductPrice PriceBLL = new Pbzx.BLL.PBnet_ProductPrice();
            Pbzx.BLL.PBnet_Product productBLL = new Pbzx.BLL.PBnet_Product();
            string str = Request.QueryString["ID"];
            if (str != null && OperateText.IsNumber(str))
            {
                this.IsAuthority(2);
                lblAction.Text = "�޸�";
                btnCancel.Visible = true;
                btnCancel.Attributes.Add("onclick", "history.back();return false;");
                MyPrice = PriceBLL.GetModel(Convert.ToInt32(str));
                ddlSoftVersion.SelectedValue = MyPrice.VarVersionType;
            }
            else
            {
                this.IsAuthority(1);
                lblAction.Text = "����";
                btnCancel.Visible = false;
                MyPrice = new Pbzx.Model.PBnet_ProductPrice();
                if (!string.IsNullOrEmpty(Request["productID"]) && OperateText.IsNumber(Request["productID"]))
                {
                    //����Ʒ����
                   BindProduct(productBLL.GetModelByCache(int.Parse(Request["productID"])));
                }
                else
                {
                    Alert();
                }
            }

            hfPriceID.Value = MyPrice.IntPriceID.ToString();
            


        }

        private void BindProduct(Pbzx.Model.PBnet_Product model)
        {
            //����������
            this.ddlParent.SelectedValue = model.pb_ClassID.ToString();
            this.ddlParent.Enabled = false;
            //����������
            this.txtPb_SoftName.Text = model.pb_SoftName;
            this.txtPb_SoftName.Enabled = false;
        }

        /// <summary>
        /// �������淽��
        /// </summary>
        private void Alert()
        {
            JS.Alert("û�д���Ʒ��ؼ۸�", "ProductPrice_Manage.aspx");
            return; 
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            if (this.btnReset.Text == "����")
            {
                this.txtSoftdog.Enabled = true;
                this.btnReset.Text = "����˼۸�";
            }
            else
            {
                Decimal price = 0;
                if (!Decimal.TryParse(this.txtSoftdog.Text, out price))
                {
                    JS.Alert("���趨�ļ۸��ʽ����ȷ��");
                    return;
                }
                WebBaseConfig wb = WebInit.webBaseConfig;
                wb.SoftdogPrice = decimal.Parse(this.txtSoftdog.Text);
                WebInit.webBaseConfig = wb;
                this.txtSoftdog.Enabled = false;
                this.btnReset.Text = "����";
            }
            
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            //Pbzx.BLL.PBnet_ProductPrice priceBLL = new Pbzx.BLL.PBnet_ProductPrice();
            //StringBuilder strErrMsg = new StringBuilder();
            //if (this.btn_Save.Text == "����˼۸�")
            //{
            //    ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert("����û�б���������۸����ȱ��棡"));
            //    return;
            //}
            //if (string.IsNullOrEmpty(txtVarNetPrice.Text))
            //{
            //    strErrMsg.Append("����ע�᷽ʽ �۸���Ϊ��.\\r\\n");
            //}
            //if(this.ddlSoftVersion.SelectedValue != "רҵ��" && this.ddlVarUseTime1.SelectedValue == "һ��" )
            //{
            //    strErrMsg.Append("����ע�᷽ʽ Ŀǰֻ��רҵ�����һ�����޵ļ۸�.\\r\\n");
            //}
            //if(string.IsNullOrEmpty(this.txtVarNetPrice1.Text))
            //{
            //    strErrMsg.Append("����ע�᷽ʽ �۸���Ϊ��.\\r\\n");
            //}
            //if (!Common.OperateText.IsNumber(this.txtOrderID))
            //{
            //    strErrMsg.Append("������������Ÿ�ʽ����ȷ������������.\\r\\n");
            //}

            //if (strErrMsg != "")
            //{
            //   string  strErrMsg1 = "���ύ��������Ϣ�д������´���:\\r\\n\\r\\n" + strErrMsg.ToString() + "\\r\\n���޸ĺ��������ύ.";
            //    ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg1));
            //    return;
            //}
            //else
            //{ 
               
               
            //}
        }
    }
}
