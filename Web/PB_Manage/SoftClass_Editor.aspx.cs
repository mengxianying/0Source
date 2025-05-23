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
using System.Text;
using Pbzx.Common;

namespace Pbzx.Web.PB_Manage
{
    public partial class SoftClass_Editor : AdminBasic
    {
        public string strClass = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                if (Request["strTyp"] == "1")
                {
                    this.yuanID.Visible = true;
                    this.chanID.Visible = false;
                }
                else if (Request["strTyp"] == "0")
                {
                    this.chanID.Visible = true;
                    this.yuanID.Visible = false;
                }


                strClass = Request.QueryString["strTyp"];          
                string str = Request.QueryString["ID"];
               // Pbzx.Model.PBnet_SoftClass MyClass;
                
                Pbzx.Model.PBnet_SoftClass MySoftClass;
                Pbzx.BLL.PBnet_SoftClass softClassBLL = new Pbzx.BLL.PBnet_SoftClass();
                if (strClass == "0")
                {
                    softClassBLL.BindSoftClass(this.ddlParent, 0);
                    this.ddlParent.Items.Insert(0, new ListItem("根类别", "0"));
                }
                else if (strClass == "1")
                {

                    softClassBLL.BindSoftClass(this.ddlParent, 1);
                    this.ddlParent.Items.Insert(0, new ListItem("根类别", "0"));
                }

                if (OperateText.IsNumber(str))
                {
                   
                    MySoftClass = softClassBLL.GetModel(Convert.ToInt32(str));
                    lblAction.Text = "修改";
                    //btnCancel.Visible = true;
                    //btnCancel.Attributes.Add("onclick", "history.back();return false;");
                    this.ddlParent.SelectedValue = MySoftClass.IntParentID.ToString();
                }
                else
                {
                    MySoftClass = new Pbzx.Model.PBnet_SoftClass();
                    lblAction.Text = "新增";
                    if (OperateText.IsNumber(Request["MyID"]))
                    {
                        this.ddlParent.SelectedValue = Request["MyID"];
                    }
                    //btnCancel.Visible = false;
                }

                hfFriendLinkID.Value = MySoftClass.IntClassID.ToString();
               

                this.txtNvarClassName.Text = MySoftClass.NvarClassName;
                this.txtNvarReadme.Text = MySoftClass.NvarReadme;
                if (MySoftClass.BitIsElite)
                {
                    this.rblBitIsElite.Items[0].Selected = true;
                }
                else
                {
                    this.rblBitIsElite.Items[1].Selected = true;
                }

                if (MySoftClass.pb_ShowOnTop)
                {
                    this.rblIsShowInTop.Items[0].Selected = true;
                }
                else
                {
                    this.rblIsShowInTop.Items[1].Selected = true;
                }
                //this.txtNvarClassPicUrl.Text = MySoftClass.NvarClassPicUrl;
                this.txtNvarLinkUrl.Text = MySoftClass.NvarLinkUrl;
                this.ddlIntBrowsePurview.SelectedValue = MySoftClass.IntBrowsePurview.ToString();
                this.ddlIntAddPurview.SelectedValue = MySoftClass.IntAddPurview.ToString();

            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            string strErrMsg = "";
            if (this.txtNvarClassName.Text.Trim() == "")
            {
                strErrMsg += "类别名称不能为空.\\r\\n";
            }

            if (this.txtNvarReadme.Text.Trim() == "")
            {
                strErrMsg += "类别说明不能为空.\\r\\n";
            }

            if (strErrMsg != "")
            {
                strErrMsg = "您提交的类别信息中存在以下错误:\\r\\n\\r\\n" + strErrMsg + "\\r\\n请修改后再重新提交.";
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                return;
            }

            Pbzx.Model.PBnet_SoftClass MySoftClass;
            Pbzx.BLL.PBnet_SoftClass softClassBLL = new Pbzx.BLL.PBnet_SoftClass();

            int intID = Convert.ToInt32(hfFriendLinkID.Value);
            if (intID > 0)
            {
                MySoftClass = softClassBLL.GetModel(intID);
            }
            else
            {
                MySoftClass = new Pbzx.Model.PBnet_SoftClass();
            }

            string temp = "";

            if (Request["strTyp"] == "1")
            {
                MySoftClass.IntSetting = 1;
                temp = "yuan";
            }
            else if (Request["strTyp"] == "0")
            {
                MySoftClass.IntSetting = 0;
                temp = "chan";
            }

           // MySoftClass.IntSetting = this.rblIntSetting.SelectedIndex;

            MySoftClass.IntParentID = int.Parse(this.ddlParent.SelectedValue);
            MySoftClass.NvarClassName = this.txtNvarClassName.Text;
            MySoftClass.NvarReadme = this.txtNvarReadme.Text;
            MySoftClass.BitIsElite = this.rblBitIsElite.Items[0].Selected;
            MySoftClass.pb_ShowOnTop = this.rblIsShowInTop.Items[0].Selected;
            //MySoftClass.NvarClassPicUrl = this.txtNvarClassPicUrl.Text;
            MySoftClass.NvarLinkUrl = this.txtNvarLinkUrl.Text;
            MySoftClass.IntBrowsePurview =int.Parse(this.ddlIntBrowsePurview.SelectedValue);
            MySoftClass.IntAddPurview =int.Parse(this.ddlIntAddPurview.SelectedValue);


            //MyLink.Operator = RM.BLL.Admin.GetNowUser().AdminName;

            if (MySoftClass.IntClassID > 0)
            {
                if (softClassBLL.Update(MySoftClass))
                {
                    Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("修改", "修改" + temp + "类别[" + MySoftClass.IntClassID + ":" + MySoftClass.NvarClassName + "].");
                 //   ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("软件类别修改成功.", "SoftClass_Manage.aspx"));
                
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("SoftClass_Manage.aspx?classType="+temp));
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "err", JS.Alert("" + temp + "类别修改失败."));
                }
            }
            else
            {
                if (softClassBLL.Add(MySoftClass))
                {
                    Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("新增", "添加" + temp + "类别[" + MySoftClass.IntClassID + ":" + MySoftClass.NvarClassName + "].");
                   // ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("软件类别添加成功..", "SoftClass_Manage.aspx"));
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("SoftClass_Manage.aspx?classType=" + temp));
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "err", JS.Alert("" + temp + "类别添加失败."));
                }
            }

        }
    }
}
