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
using Maticsoft.DBUtility;

namespace Pbzx.Web.PB_Manage.Cst
{
    public partial class Agent_Editor : AdminBasic
    //: AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                txtExpireD.Text = DateTime.Now.ToShortDateString();
                string str = Request.QueryString["ID"];
                Pbzx.BLL.AgentInfo_Apply AgentInfoBLL = new Pbzx.BLL.AgentInfo_Apply();
                Pbzx.Model.AgentInfo_Apply MyAgenInfo = AgentInfoBLL.GetModel(int.Parse(str));

                //if (OperateText.IsNumber(str))
                //{
                //    // lblAction.Text = "�޸�";
                //    btnCancel.Visible = true;
                //    btnCancel.Attributes.Add("onclick", "history.back();return false;");
                //    MyAgenInfo = AgentInfoBLL.GetModel(Convert.ToInt32(str));
                //   
                //}

                lblName.Text = MyAgenInfo.Name;
                txtExpireD.Text = MyAgenInfo.ExpireDate.ToShortDateString();
                this.lblCompany.Text = MyAgenInfo.Company;
                this.txtRemark.Text = MyAgenInfo.Remark;
                this.txtAgtmore.Text = MyAgenInfo.agtmore;
                this.txtPrice.Text = MyAgenInfo.PricePercent.ToString();

                hfFriendLinkID.Value = MyAgenInfo.ID.ToString();
                lblMobile.Text = MyAgenInfo.Mobile;
                lblTelphone.Text = MyAgenInfo.Telephone;              
                lblfax.Text = MyAgenInfo.Fax;
                //lblUserName.Text = MyAgenInfo.UserName;
                txtUserName.Text = MyAgenInfo.UserName;                
                 lblPostCode.Text = MyAgenInfo.PostCode;                
                 lblProvince.Text = MyAgenInfo.Province;
                 lblEmail.Text = MyAgenInfo.EMail;
                 lblAddress.Text = MyAgenInfo.Address;
                 txtagttype.Text = MyAgenInfo.agttype;
                 txtPostmore.Text = MyAgenInfo.postmore;

                this.lblState.Text = MyAgenInfo.Status == 0 ? "��δ��Ϊ��ʽ����" : "�Ѿ���Ϊ��ʽ����";
                if (DbHelperSQL1.Exists("select count(Name) from AgentInfo where UserName='" + MyAgenInfo.UserName + "'"))
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("������Ϣ�Ѿ���ӵ���ʵ������Ϣ���ˣ��뵽����ʽ��������б༭!"));
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("AgentPass_Manage.aspx"));
                    return;
                }
              
            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            string strErrMsg = "";
            if (!OperateText.IsNumber(this.txtPrice.Text))
            {
                strErrMsg += "����۸�������.\\r\\n";
            }
            DateTime tempTime = DateTime.Now;
            if (!DateTime.TryParse(txtExpireD.Text, out tempTime))
            {
                strErrMsg += "����ʱ���ʽ����ȷ.\\r\\n";
            }
            string strTemp = WebFunc.IsDVUser(this.txtUserName.Text.Trim());
            if (strTemp != "true")
            {
                strErrMsg += strTemp;
            }
            if (strErrMsg != "")
            {
                strErrMsg = "���ύ�Ĵ�����Ϣ�д������´���:\\r\\n\\r\\n" + strErrMsg + "\\r\\n���޸ĺ��������ύ.";
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                return;
            }
            else
            {
                int intID = int.Parse(Request.QueryString["ID"]);

                Pbzx.BLL.AgentInfo_Apply AgentInfoBLL = new Pbzx.BLL.AgentInfo_Apply();
                Pbzx.Model.AgentInfo_Apply MyAgentInfo = AgentInfoBLL.GetModel(intID);
                Pbzx.BLL.AgentInfo ReallyAgentBLL = new Pbzx.BLL.AgentInfo();
                Pbzx.Model.AgentInfo ReallyAgentInfo = new Pbzx.Model.AgentInfo();
                MyAgentInfo.UserName = txtUserName.Text;
                MyAgentInfo.agttype = txtagttype.Text.Trim();
                MyAgentInfo.PricePercent = Convert.ToInt32(txtPrice.Text.Trim());
                MyAgentInfo.ExpireDate = Convert.ToDateTime(txtExpireD.Text.Trim());
                MyAgentInfo.Remark = this.txtRemark.Text;
                MyAgentInfo.agtmore = this.txtAgtmore.Text;
                MyAgentInfo.postmore = txtPostmore.Text;
                if (AgentInfoBLL.Update(MyAgentInfo))
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("������Ϣ����ɹ���"));
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("Agent_Manage.aspx"));
                    Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("����", "�������[" + MyAgentInfo.Name + "].");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("������ʧ��."));
                }
                
            }
        }

        protected void btnUP_Click(object sender, EventArgs e)
        {
            string strErrMsg = "";

            if (!OperateText.IsNumber(this.txtPrice.Text))
            {
                strErrMsg += "����۸�������.\\r\\n";
            }
            DateTime tempTime = DateTime.Now;
            if(!DateTime.TryParse(txtExpireD.Text,out tempTime))
            {
                strErrMsg += "����ʱ���ʽ����ȷ.\\r\\n";
            }
            if (strErrMsg != "")
            {
                strErrMsg = "���ύ�Ĵ�����Ϣ�д������´���:\\r\\n\\r\\n" + strErrMsg + "\\r\\n���޸ĺ��������ύ.";
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                return;
            }
            else
            {
                int intID = int.Parse(Request.QueryString["ID"]);

                Pbzx.BLL.AgentInfo_Apply AgentInfoBLL = new Pbzx.BLL.AgentInfo_Apply();
                Pbzx.Model.AgentInfo_Apply MyAgentInfo = AgentInfoBLL.GetModel(intID);

                Pbzx.BLL.AgentInfo ReallyAgentBLL = new Pbzx.BLL.AgentInfo();
                Pbzx.Model.AgentInfo ReallyAgentInfo = new Pbzx.Model.AgentInfo();

                if(MyAgentInfo.Status == 1)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert("���û��Ѿ�����Ϊ��ʽ����"));
                    return;
                }
                MyAgentInfo.Status = 1;
                MyAgentInfo.PricePercent = Convert.ToInt32(txtPrice.Text.Trim());
                MyAgentInfo.ExpireDate = Convert.ToDateTime(txtExpireD.Text.Trim());
                MyAgentInfo.agtmore =this.txtAgtmore.Text;
                MyAgentInfo.postmore = txtPostmore.Text;
               

                ReallyAgentInfo.ID = ReallyAgentBLL.GetNewID();
                ReallyAgentInfo.Status = 1;
                ReallyAgentInfo.Name = lblName.Text;
                ReallyAgentInfo.Fax = lblfax.Text;
                ReallyAgentInfo.UserName = txtUserName.Text;
                ReallyAgentInfo.PostCode = lblPostCode.Text;
                ReallyAgentInfo.Remark = this.txtRemark.Text;

                ReallyAgentInfo.agttype = txtagttype.Text;
                ReallyAgentInfo.Mobile = lblMobile.Text;
                ReallyAgentInfo.Telephone = lblTelphone.Text;
                ReallyAgentInfo.EMail = lblEmail.Text;
                ReallyAgentInfo.Company = lblCompany.Text;
                ReallyAgentInfo.agtmore = this.txtAgtmore.Text;
                ReallyAgentInfo.postmore = txtPostmore.Text;

                ReallyAgentInfo.Address = lblAddress.Text;
                ReallyAgentInfo.Province = lblProvince.Text;
                ReallyAgentInfo.PricePercent = Convert.ToInt32(txtPrice.Text.Trim());
                ReallyAgentInfo.ExpireDate = Convert.ToDateTime(txtExpireD.Text.Trim());
                ReallyAgentInfo.agtmore = txtAgtmore.Text;
               
                if (AgentInfoBLL.Update(MyAgentInfo) && ReallyAgentBLL.Add(ReallyAgentInfo))
                {
                    Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("���", "��Ӵ���[" + lblName.Text + "]����ʵ������Ϣ��");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("������Ϣ��ӵ�����ʵ������Ϣ��"));
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("AgentPass_Manage.aspx"));
                    Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("����", "�������[" + MyAgentInfo.Name + "].");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("������ʧ��."));
                }
            }
        }

    }
}
