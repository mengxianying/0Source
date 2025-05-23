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

namespace Pbzx.Web.PB_Manage
{
    public partial class AdvPlace_Edit : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Method.BindAdChanl(this.Channel);
                Method.BindAdClass(this.rbtTypeID);

                string str = Request["ID"];
                if (str != null && OperateText.IsNumber(str))
                {
                    Pbzx.BLL.PBnet_AdvPlace MyBll = new Pbzx.BLL.PBnet_AdvPlace();
                    Pbzx.Model.PBnet_AdvPlace MyModel;
                    MyModel = MyBll.GetModel(Convert.ToInt32(str.ToString()));

                    this.rbtTypeID.SelectedValue = MyModel.TypeID.ToString();
                    this.Channel.SelectedValue = MyModel.ChannelID.ToString();
                    this.txtPlaceName.Text = MyModel.PlaceName;
                }             
            }
        }

        protected void btAdd_Click(object sender, EventArgs e)
        {
            string strErrMsg = "";
            if (txtPlaceName.Text.Trim() == "")
            {
                strErrMsg += "网站名称不能为空.\\r\\n";
            }
            if (strErrMsg != "")
            {
                strErrMsg = "您提交的新闻信息中存在以下错误:\\r\\n\\r\\n" + strErrMsg + "\\r\\n请修改后再重新提交.";
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                return;
            }
            else
            {
                Pbzx.BLL.PBnet_AdvPlace MyBll = new Pbzx.BLL.PBnet_AdvPlace();
                Pbzx.Model.PBnet_AdvPlace MyModel;
                int intid = Convert.ToInt32(Request["ID"]);
                if (intid > 0)
                {
                    MyModel = MyBll.GetModel(intid);
                }
                else
                {
                    MyModel = new Pbzx.Model.PBnet_AdvPlace();
                }
                MyModel.TypeID = int.Parse(this.rbtTypeID.SelectedValue);
                MyModel.ChannelID = int.Parse(this.Channel.SelectedItem.Value.ToString());
                MyModel.PlaceName = this.txtPlaceName.Text;

                if (intid > 0)
                {
                    if (MyBll.Update(MyModel))
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("AdvPlace_Manage.aspx"));
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("修改失败."));
                    }

                }
                else
                {
                    if (MyBll.Add(MyModel))
                    {

                        ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("AdvPlace_Manage.aspx"));
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("添加失败."));
                    }
                }
            }
        }
    }
}
