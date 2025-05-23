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
    public partial class AgentPass_Editor : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Pbzx.BLL.AgentInfo MyBLL = new Pbzx.BLL.AgentInfo();
                Method.BindProvince(this.ddlProvince, "");                

                txtExpireD.Text = DateTime.Now.ToShortDateString();
                Pbzx.Model.AgentInfo MyAgenInfo;
                Pbzx.BLL.AgentInfo AgentInfoBLL = new Pbzx.BLL.AgentInfo();

                string str = Request.QueryString["ID"];
                if (OperateText.IsNumber(str))
                {
                    // lblAction.Text = "修改";
                    btnCancel.Visible = true;
                    btnCancel.Attributes.Add("onclick", "history.back();return false;");
                    MyAgenInfo = AgentInfoBLL.GetModel(Convert.ToInt32(str));
                    txtID.Text = (MyAgenInfo.ID).ToString();
                    txtExpireD.Text = MyAgenInfo.ExpireDate.ToShortDateString();

                    if (MyAgenInfo.delshow)
                    {
                        this.rblshow.Items[0].Selected = true;
                        this.rblshow.Items[1].Selected = false;
                    }
                    else
                    {
                        this.rblshow.Items[0].Selected = false;
                        this.rblshow.Items[1].Selected = true;
                    }

                    this.rblState.SelectedValue = MyAgenInfo.Status.ToString();
                   // rblState.SelectedValue = MyAgenInfo.Status.ToString();
                    //rblState.Items.Selected = MyAgenInfo.Status;                   
                }
                else
                {
                    // lblAction.Text = "新增";
                    btnCancel.Visible = false;
                    MyAgenInfo = new Pbzx.Model.AgentInfo();
                    this.txtID.Text = AgentInfoBLL.GetNewID().ToString();

                }

                hfFriendLinkID.Value = MyAgenInfo.ID.ToString();
                this.txtUserName.Text = MyAgenInfo.UserName;
                txtName.Text = MyAgenInfo.Name;
                txtFax.Text = MyAgenInfo.Fax;
                txtType.Text = MyAgenInfo.agttype;
                txtMobile.Text = MyAgenInfo.Mobile;
                txtTel.Text = MyAgenInfo.Telephone;
                txtEmail.Text = MyAgenInfo.EMail;
                txtCompany.Text = MyAgenInfo.Company;
                txtPost.Text = MyAgenInfo.PostCode;
                txtAddress.Text = MyAgenInfo.Address;
                //txtProvince.Text = MyAgenInfo.Province;
                this.ddlProvince.SelectedValue = MyAgenInfo.Province;

                txtPrice.Text = MyAgenInfo.PricePercent.ToString();
                
                this.txtRemark.Text = MyAgenInfo.Remark;
                this.txtAgtmore.Text = MyAgenInfo.agtmore;
                // txtNote.Text = MyAgenInfo.Note;
                txtPostmore.Text = MyAgenInfo.postmore;

            }
        }

        private void SetData(Pbzx.Model.AgentInfo MyAgentInfo)
        {

            MyAgentInfo.UserName = this.txtUserName.Text;
            MyAgentInfo.ID = int.Parse(this.txtID.Text);
            MyAgentInfo.Name = txtName.Text.Trim();
            MyAgentInfo.Fax = txtFax.Text.Trim();
            MyAgentInfo.agttype = txtType.Text.Trim();
            MyAgentInfo.Mobile = txtMobile.Text.Trim();
            MyAgentInfo.Telephone = txtTel.Text.Trim();
            MyAgentInfo.EMail = txtEmail.Text.Trim();
            MyAgentInfo.Company = txtCompany.Text.Trim();
            MyAgentInfo.postmore = txtPostmore.Text;
            MyAgentInfo.Address = txtAddress.Text.Trim();
            MyAgentInfo.agtmore = txtAgtmore.Text;
          //  MyAgentInfo.Province = txtProvince.Text.Trim();
            MyAgentInfo.Province = this.ddlProvince.SelectedValue;

            MyAgentInfo.PricePercent = Convert.ToInt32(txtPrice.Text.Trim());
            MyAgentInfo.ExpireDate = Convert.ToDateTime(txtExpireD.Text.Trim());
            MyAgentInfo.Status = int.Parse(this.rblState.SelectedValue);
            MyAgentInfo.delshow = this.rblshow.Items[0].Selected;
            MyAgentInfo.Remark = this.txtRemark.Text;
            MyAgentInfo.agtmore = this.txtAgtmore.Text;
            //  MyAgentInfo.Note = txtNote.Text;


        }
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            string strErrMsg = "";
            if (txtName.Text.Trim() == "")
            {
                strErrMsg += "代理人姓名不能为空.\\r\\n";
            }
            if (!OperateText.IsNumber(this.txtPrice.Text))
            {
                strErrMsg += "代理价格不是数字.\\r\\n";
            }
            string strTemp = WebFunc.IsDVUser(this.txtUserName.Text.Trim()) ;
            if (strTemp != "true")
            {
                strErrMsg += strTemp;
            }
            if (strErrMsg != "")
            {
                strErrMsg = "您提交的代理信息中存在以下错误:\\r\\n\\r\\n" + strErrMsg + "\\r\\n请修改后再重新提交.";
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                return;
            }
            else
            {
                int ID = Convert.ToInt32(hfFriendLinkID.Value);
                Pbzx.BLL.AgentInfo AgentInfoBLL = new Pbzx.BLL.AgentInfo();
                Pbzx.Model.AgentInfo MyAgentInfo;
                if (ID > 0)
                {
                    MyAgentInfo = AgentInfoBLL.GetModel(ID);
                    SetData(MyAgentInfo);
                    if (AgentInfoBLL.Update(MyAgentInfo))
                    {
                        // ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("代理修改成功."));
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("AgentPass_Manage.aspx"));
                        Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("修改", "修改代理[" + MyAgentInfo.Name + "].");
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("代理修改失败."));
                    }
                }
                else
                {
                    MyAgentInfo = new Pbzx.Model.AgentInfo();
                    SetData(MyAgentInfo);
                    if (AgentInfoBLL.Add(MyAgentInfo))
                    {
                        //  ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("代理添加成功."));
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("AgentPass_Manage.aspx"));
                        Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("新增", "新增代理[" + MyAgentInfo.Name + "].");
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("代理添加失败."));
                    }
                }
            }



        }
    }
}
