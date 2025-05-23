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
    public partial class Ask_User_Edit : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string str = Request.QueryString["ID"];
                Pbzx.BLL.PBnet_ask_User MyBll = new Pbzx.BLL.PBnet_ask_User();
                Pbzx.Model.PBnet_ask_User MyModel;
                if (OperateText.IsNumber(str))
                {
                    MyModel = MyBll.GetModel(Convert.ToInt32(str.ToString()));

                    this.lblUserName.Text = MyModel.UserName;
                    this.lblID.Text = MyModel.ID.ToString();
                    this.lblOpenTime.Text = MyModel.OpenTime.ToString();

                    this.lblPoint.Text = MyModel.Score.ToString();
                    this.lblPointpenalty.Text = MyModel.Pointpenalty.ToString();
                    this.lblOtherPointpenalty.Text = MyModel.OtherPointpenalty.ToString();
                    this.lblTitle.Text = Method.GetUserTitle(Convert.ToString(MyModel.Score - MyModel.Pointpenalty - MyModel.OtherPointpenalty));
                    this.lblUserGroup.Text = MyModel.UserGroup;
                    this.rblState.SelectedValue = MyModel.State.ToString();
                    this.lblScore.Text = Convert.ToString(MyModel.Score - MyModel.Pointpenalty - MyModel.OtherPointpenalty);
                    this.lblAskNum.Text = MyModel.AskNum.ToString();
                    this.lblReplyNum.Text = MyModel.ReplyNum.ToString();

                    this.lblBest_ReplyNum.Text = MyModel.Best_ReplyNum.ToString();
                    this.lblAsk_DelNum.Text = MyModel.Ask_DelNum.ToString();
                }
            }
        }

        protected void btn_ok_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_ask_User MyBll = new Pbzx.BLL.PBnet_ask_User();
            Pbzx.Model.PBnet_ask_User MyModel = MyBll.GetModel(int.Parse(this.lblID.Text));

            MyModel.State = int.Parse(this.rblState.SelectedValue);

            if (MyBll.Update(MyModel))
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("修改", "修改拼搏吧用户[" + this.lblUserName.Text + "]状态");
                //ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("Ask_User.aspx"));
                Response.Write("<script>alert('修改成功');window.opener.location.reload();window.opener.focus();window.opener=null;window.open('','_self');window.close();</script>");
            }
            else
            {
             ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("修改失败."));
            }
        }
    }
}
