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

                    lblAction.Text = "修改";
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

                    lblAction.Text = "新增";
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
                strErrMsg += "软件类型未输入或数据格式不正确.\\r\\n";
            }
            if (txtSoftwareName.Text.Trim() == "")
            {
                strErrMsg += "软件类型名不能为空.\\r\\n";
            }
            if (this.txtSoftwareNameColor.Text.Trim() == "")
            {
                strErrMsg += "软件类型名的颜色不能为空.\\r\\n";
            }
            if (!OperateText.IsNumber(this.ddlInstallType.SelectedValue))
            {
                strErrMsg += "安装类型未输入或数据格式不正确.\\r\\n";
            }
            if (this.txtInstallName.Text.Trim() == "")
            {
                strErrMsg += "安装类型名不能为空.\\r\\n";
            }
            if (this.txtInstallNameColor.Text.Trim() == "")
            {
                strErrMsg += "安装类型名颜色不能为空.\\r\\n";
            }
            if (!OperateText.IsNumber(this.txtYearMoney.Text.Trim()))
            {
                strErrMsg += "年费用数据格式不正确.\\r\\n";
            }
            if (!OperateText.IsNumber(this.txtLifeMoney.Text.Trim()))
            {
                strErrMsg += "终身费用数据格式不正确.\\r\\n";
            }

            if (this.txtVersionTypeName.Text.Trim() == "")
            {
                strErrMsg += "版本类型名不能为空.\\r\\n";
            }

            if (this.txtVersionTypeName.Text.Trim() == "")
            {
                strErrMsg += "版本类型值不能为空.\\r\\n";
            }



            if (strErrMsg != "")
            {
                strErrMsg = "您提交的软件配置信息中存在以下错误:\\r\\n\\r\\n" + strErrMsg + "\\r\\n请修改后再重新提交.";
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

                        strErrMsg += "该软件的配置已经存在.\\r\\n";
                    }
                    if (strErrMsg != "")
                    {
                        strErrMsg = "您提交的软件配置信息中存在以下错误:\\r\\n\\r\\n" + strErrMsg + "\\r\\n请修改后再重新提交.";
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
                        //  ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("软件配置信息修改成功."));
                        Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("修改", "修改软件配置[" + MySoftware.CstID + ":" + MySoftware.CstName + "].");
                        //Response.Write("<script>alert('修改成功');window.opener.location.reload();window.opener.focus();window.opener=null;window.open('','_self');window.close();</script>");
                        Response.Redirect("SoftConfig_Manage.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('修改失败');</script>");
                    }
                }
                else
                {
                    MySoftware.CstID = Int16.Parse(ViewState["CstID"].ToString());
                    if (softwareBLL.Add(MySoftware))
                    {
                        //   ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("软件配置信息添加成功."));
                        Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("新增", "新增软件配置[" + MySoftware.CstName + "].");
                        //Response.Write("<script>alert('添加成功');window.opener.location.reload();window.opener.focus();window.opener=null;window.open('','_self');window.close();</script>");
                        Response.Redirect("SoftConfig_Manage.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('修改失败');</script>");
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
