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

namespace Pbzx.Web.PB_Manage.CST
{
    public partial class SoftConfig_Editor : AdminBasic
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtSoftwareType.Attributes.Add("readonly", "true");
                Pbzx.Model.CstSoftware MySoftware;
                Pbzx.BLL.CstSoftware softwareBLL = new Pbzx.BLL.CstSoftware();

                string str = Request.QueryString["ID"];
                softwareBLL.BindSoftwareType(this.ddlSoftType);
                this.ddlSoftType.Items.RemoveAt(0);
                this.ddlSoftType.Items.Insert(0, new ListItem("", ""));

                softwareBLL.BindProductVersionType(this.ddlVersionTypeName);
                this.ddlVersionTypeName.Items.RemoveAt(0);
                this.ddlVersionTypeName.Items.Insert(0, new ListItem("", ""));


                if (str != null && OperateText.IsNumber(str))
                {

                    lblAction.Text = "�޸�";
                    //btnCancel.Visible = true;
                    //btnCancel.Attributes.Add("onclick","history.back();return false;");
                    MySoftware = softwareBLL.GetModel(Convert.ToInt32(str));

                    this.ddlSoftType.SelectedValue = MySoftware.SoftwareName;
                    rblFlage.SelectedValue = MySoftware.Flag.ToString();
                    txtVersionTypeName.Text = MySoftware.VersionTypeName;
                    txtVersionType.Text = MySoftware.VersionType.ToString();
                    ddlVersionTypeName.SelectedValue = MySoftware.VersionType.ToString();


                    ddlVersionTypeName.SelectedValue = MySoftware.VersionType.ToString();
                    ddlSoftType.Enabled = false;
                    ddlVersionTypeName.Enabled = false;

                    ddlInstallType.Enabled = false;
                    txtSoftwareType.Enabled = false;

                    this.lblID.Text = ((MySoftware.SoftwareType * 16) + MySoftware.InstallType).ToString();
                }
                else
                {
                    ddlSoftType.Enabled = true;
                    softwareBLL.BindSoftwareType(this.ddlSoftType);

                    lblAction.Text = "����";
                    //btnCancel.Visible = false;
                    MySoftware = new Pbzx.Model.CstSoftware();
                }


                hfNewsID.Value = MySoftware.CstID.ToString();
                ViewState["CstID"] = hfNewsID.Value;
                txtSoftwareType.Text = MySoftware.SoftwareType.ToString();
                txtSoftwareName.Text = MySoftware.SoftwareName;
                txtSoftwareNameColor.Text = MySoftware.SoftwareNameColor;
                ddlInstallType.SelectedValue = MySoftware.InstallType.ToString();
                txtInstallName.Text = MySoftware.InstallName;
                txtInstallNameColor.Text = MySoftware.InstallNameColor;
                txtCstName.Text = MySoftware.CstName;
                txtYearMoney.Text = MySoftware.YearMoney.ToString();
                txtLifeMoney.Text = MySoftware.LifeMoney.ToString();

            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.CstSoftware softwareBLL = new Pbzx.BLL.CstSoftware();
            string strErrMsg = "";
            if (!OperateText.IsNumber(this.txtSoftwareType.Text.Trim()))
            {
                strErrMsg += "�������δ��������ݸ�ʽ����ȷ.\\r\\n";
            }
            if (txtSoftwareName.Text.Trim() == "")
            {
                strErrMsg += "�������������Ϊ��.\\r\\n";
            }
            if (this.txtSoftwareNameColor.Text.Trim() == "")
            {
                strErrMsg += "�������������ɫ����Ϊ��.\\r\\n";
            }
            if (!OperateText.IsNumber(this.ddlInstallType.SelectedValue))
            {
                strErrMsg += "��װ����δ��������ݸ�ʽ����ȷ.\\r\\n";
            }
            if (this.txtInstallName.Text.Trim() == "")
            {
                strErrMsg += "��װ����������Ϊ��.\\r\\n";
            }
            if (this.txtInstallNameColor.Text.Trim() == "")
            {
                strErrMsg += "��װ��������ɫ����Ϊ��.\\r\\n";
            }
            if (!OperateText.IsNumber(this.txtYearMoney.Text.Trim()))
            {
                strErrMsg += "��������ݸ�ʽ����ȷ.\\r\\n";
            }
            if (!OperateText.IsNumber(this.txtLifeMoney.Text.Trim()))
            {
                strErrMsg += "����������ݸ�ʽ����ȷ.\\r\\n";
            }

            if (this.txtVersionTypeName.Text.Trim() == "")
            {
                strErrMsg += "�汾����������Ϊ��.\\r\\n";
            }

            if (this.txtVersionTypeName.Text.Trim() == "")
            {
                strErrMsg += "�汾����ֵ����Ϊ��.\\r\\n";
            }



            if (strErrMsg != "")
            {
                strErrMsg = "���ύ�����������Ϣ�д������´���:\\r\\n\\r\\n" + strErrMsg + "\\r\\n���޸ĺ��������ύ.";
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                return;
            }
            else
            {
                int NewsID = Convert.ToInt32(hfNewsID.Value);

                Pbzx.Model.CstSoftware MySoftware;
                if (NewsID > 0)
                {
                    MySoftware = softwareBLL.GetModel(NewsID);
                }
                else
                {
                    if (softwareBLL.IsExists(this.txtSoftwareName.Text, txtInstallName.Text))
                    {

                        strErrMsg += "������������Ѿ�����.\\r\\n";
                    }
                    if (strErrMsg != "")
                    {
                        strErrMsg = "���ύ�����������Ϣ�д������´���:\\r\\n\\r\\n" + strErrMsg + "\\r\\n���޸ĺ��������ύ.";
                        ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                        return;
                    }
                    MySoftware = new Pbzx.Model.CstSoftware();
                }
                MySoftware.SoftwareType = int.Parse(txtSoftwareType.Text);
                MySoftware.SoftwareName = txtSoftwareName.Text;
                MySoftware.SoftwareNameColor = txtSoftwareNameColor.Text;
                MySoftware.InstallType = int.Parse(ddlInstallType.SelectedValue);
                MySoftware.InstallName = txtInstallName.Text;
                MySoftware.InstallNameColor = txtInstallNameColor.Text;
                MySoftware.CstName = txtCstName.Text;
                MySoftware.YearMoney = int.Parse(txtYearMoney.Text);
                MySoftware.LifeMoney = int.Parse(txtLifeMoney.Text);
                MySoftware.VersionTypeName = txtVersionTypeName.Text;
                MySoftware.VersionType = int.Parse(txtVersionType.Text);

                if (rblFlage.Items[0].Selected)
                {
                    MySoftware.Flag = 1;
                }
                else
                {
                    MySoftware.Flag = 0;
                }

                if (MySoftware.CstID > 0)
                {
                    if (softwareBLL.Update(MySoftware))
                    {
                        //  ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("���������Ϣ�޸ĳɹ�."));
                        Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("�޸�", "�޸��������[" + MySoftware.CstID + ":" + MySoftware.CstName + "].");
                        //Response.Write("<script>alert('�޸ĳɹ�');window.opener.location.reload();window.opener.focus();window.opener=null;window.open('','_self');window.close();</script>");
                        Response.Redirect("SoftConfig_Manage.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('�޸�ʧ��');</script>");
                    }
                }
                else
                {
                    MySoftware.CstID = Int16.Parse(ViewState["CstID"].ToString());
                    if (softwareBLL.Add(MySoftware))
                    {
                        //   ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("���������Ϣ��ӳɹ�."));
                        Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("����", "�����������[" + MySoftware.CstName + "].");
                        //Response.Write("<script>alert('��ӳɹ�');window.opener.location.reload();window.opener.focus();window.opener=null;window.open('','_self');window.close();</script>");
                        Response.Redirect("SoftConfig_Manage.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('�޸�ʧ��');</script>");
                    }
                }
            }
        }

        protected void ddlSoftType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddlSoftType.SelectedValue != "")
            {
                DataRow row = DbHelperSQL1.Query("select  top 1 CstID,SoftwareType from CstSoftware where SoftwareName='" + this.ddlSoftType.SelectedValue + "' order by CstID asc ").Tables[0].Rows[0];
                int cstID = Convert.ToInt32(row["CstID"]) - 1;
                ViewState["CstID"] = cstID;
                //lblID.Text = (cstID / 16).ToString();
                txtSoftwareType.Text = (cstID / 16).ToString();
                txtSoftwareName.Text = this.ddlSoftType.SelectedValue;
                txtCstName.Text = this.ddlSoftType.SelectedValue;
                lblID.Text = ((Convert.ToInt32(txtSoftwareType.Text) * 16) + Convert.ToInt32(ddlInstallType.SelectedValue)).ToString();

            }
            else
            {
                ViewState["CstID"] = hfNewsID.Value;
            }
        }

        protected void ddlVersionTypeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddlVersionTypeName.SelectedValue != "")
            {
                this.txtVersionTypeName.Text = this.ddlVersionTypeName.SelectedItem.Text;
                this.txtVersionType.Text = this.ddlVersionTypeName.SelectedValue;
            }
        }

        protected void btClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("SoftConfig_Manage.aspx");
        }

        protected void ddlInstallType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblID.Text = ((Convert.ToInt32(txtSoftwareType.Text) * 16) + Convert.ToInt32(ddlInstallType.SelectedValue)).ToString();
        }

        protected void txtSoftwareType_TextChanged(object sender, EventArgs e)
        {
            if (txtSoftwareType.Text.Trim() == "")
            {
                txtSoftwareType.Text = "0";
            }
            int result = 0;
            if (int.TryParse(txtSoftwareType.Text, out result))
            {
                lblID.Text = ((Convert.ToInt32(txtSoftwareType.Text) * 16) + Convert.ToInt32(ddlInstallType.SelectedValue)).ToString();
            }
            else
            {
                txtSoftwareType.Text = "0";
                lblID.Text = ((Convert.ToInt32(txtSoftwareType.Text) * 16) + Convert.ToInt32(ddlInstallType.SelectedValue)).ToString();
            }



        }
    }
}
