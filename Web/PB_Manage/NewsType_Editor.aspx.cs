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
    public partial class NewsType_Editor : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string str = Request.QueryString["ID"];
                Pbzx.Model.PBnet_NewsType MyNewType;
                Pbzx.BLL.PBnet_NewsType NewsTypeBLL = new Pbzx.BLL.PBnet_NewsType();
                NewsTypeBLL.BindNewsType(this.ddlParent, 0);
                //this.ddlParent.Items.Insert(0, new ListItem("根类别", "0"));

                if (OperateText.IsNumber(str))
                {
                    MyNewType = NewsTypeBLL.GetModel(Convert.ToInt32(str));
                    lblAction.Text = "修改";
                    this.ddlParent.SelectedValue = MyNewType.IntNewsTypeID.ToString();
                }
                else
                {
                    MyNewType = new Pbzx.Model.PBnet_NewsType();
                    lblAction.Text = "添加";
                    if (OperateText.IsNumber(Request["MYID"]))
                    {
                    this.ddlParent.SelectedValue = Request["MYID"];
                    }
                }
                hfFriendLinkID.Value = MyNewType.IntNewsTypeID.ToString();
                this.txtVarTypeName.Text = MyNewType.VarTypeName;
                this.rblIsAuditing.Items[0].Selected = MyNewType.BitIsAuditing;
                this.txtOrder.Text = MyNewType.IntOrderID.ToString();

           }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            string strErrMsg = "";
            if (this.txtVarTypeName.Text.Trim() == "")
            {
                strErrMsg += "类别名称不能为空.\\r\\n";
            }

            if (this.txtOrder.Text.Trim() == "")
            {
                strErrMsg += "类别说明不能为空.\\r\\n";
            }

            if (strErrMsg != "")
            {
                strErrMsg = "您提交的友情链接中存在以下错误:\\r\\n\\r\\n" + strErrMsg + "\\r\\n请修改后再重新提交.";
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                return;
            }

            Pbzx.Model.PBnet_NewsType MyNewsType;
            Pbzx.BLL.PBnet_NewsType newsTypeBLL = new Pbzx.BLL.PBnet_NewsType();
            int intID = Convert.ToInt32(hfFriendLinkID.Value);
            if (intID > 0)
            {
                MyNewsType = newsTypeBLL.GetModel(intID);
            }
            else
            {
                MyNewsType = new Pbzx.Model.PBnet_NewsType();
            }

            MyNewsType.VarTypeName = this.txtVarTypeName.Text;
            MyNewsType.IntTypeFID = int.Parse(this.ddlParent.SelectedValue);
            MyNewsType.BitIsAuditing =this.rblIsAuditing.Items[0].Selected;
            MyNewsType.IntOrderID =this.txtOrder.Text;

            if (MyNewsType.IntNewsTypeID > 0)
            {
                if (newsTypeBLL.Update(MyNewsType))
                {
                    Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("修改", "修改新闻类别[" + MyNewsType.IntNewsTypeID + ":" + MyNewsType.VarTypeName + "].");
                    //ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("新闻类别修改成功.", "NewsType_list.aspx"));
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("NewsType_list.aspx"));
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "err", JS.Alert("新闻类别修改失败."));
                }
            }
            else
            {
                if (newsTypeBLL.Add(MyNewsType))
                {
                    Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("新增", "添加新闻类别[" + MyNewsType.IntNewsTypeID + ":" + MyNewsType.VarTypeName + "].");
                  //  ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("新闻类别添加成功..", "NewsType_Editor.aspx"));
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("NewsType_Editor.aspx"));
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "err", JS.Alert("新闻类别添加失败."));
                }
            }
            


        }
    }
}

