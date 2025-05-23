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
    public partial class Ask_Question_Edit : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Pbzx.BLL.PBnet_ask_Question MyBll = new Pbzx.BLL.PBnet_ask_Question();
                Pbzx.Model.PBnet_ask_Question MyModel;
                string str = Request.QueryString["Id"];
                if (OperateText.IsNumber(str))
                {
                    MyModel = MyBll.GetModel(Convert.ToInt32(str));
                    this.lblTitle.Text = MyModel.Title;
                    this.lblRelay.Text = MyModel.Relay;
                    this.lblId.Text = MyModel.Id.ToString();

                    //this.lblAskTime.Text = MyModel.AskTime.ToString();
                    this.txtAskTime.Text = MyModel.AskTime.ToString();
                    this.lblTypeName.Text = MyModel.TypeName;

                    //this.lblOverTime.Text = MyModel.OverTime.ToString();
                    this.txtOverTime.Text = MyModel.OverTime.ToString();

                    this.lblTypeID.Text = MyModel.TypeID.ToString();
                    //this.lblUpdateTime.Text = MyModel.UpdateTime.ToString();
                    this.txtUpdateTime.Text = MyModel.UpdateTime.ToString();

                    this.lblFTypeID.Text = MyModel.FTypeID.ToString();

                    this.lblLargessPoint.Text = MyModel.LargessPoint.ToString();
                    this.lblAsker.Text = MyModel.Asker;
                    this.lblAnswerer.Text = MyModel.Answerer;

                    this.lblAskerId.Text = MyModel.AskerId.ToString();
                    this.lblAnswererId.Text = MyModel.AnswererId.ToString();
                    this.lblAttachId.Text = MyModel.AttachId.ToString();

                    this.lblReplys.Text = MyModel.Replys.ToString();
                    this.lblViews.Text = MyModel.Views.ToString();
                    if(MyModel.IsCommend)
                    {
                        this.rblIsCommend.Items[0].Selected = true;
                    }
                    else
                    {
                        this.rblIsCommend.Items[1].Selected = true;
                    }

                    if(MyModel.IsAnonymous)
                    { 
                        //this.rblIsAnonymous.Items[0].Selected = true;
                        this.lblIsNM.Text = "匿名";
                    }
                    else
                    {
                        //this.rblIsAnonymous.Items[1].Selected = true;
                        this.lblIsNM.Text = "不匿名";
                    }
                    //if (MyModel.BitIsHot)
                    //{
                    //    this.rblBitIsHot.Items[0].Selected = true;
                    //}
                    //else
                    //{
                    //    this.rblBitIsHot.Items[1].Selected = true;
                    //}
                    //this.lblState.Text = Method.GetQuestionStateName(MyModel.State);
                    this.ddlState.SelectedValue = MyModel.State.ToString();

                    this.txtContent.Value = MyModel.Content;
                }
            }
        }

        protected void btn_ok_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_ask_Question MyBll = new Pbzx.BLL.PBnet_ask_Question();
            Pbzx.Model.PBnet_ask_Question MyModel = MyBll.GetModel(Convert.ToInt32(this.lblId.Text));


           // MyModel.BitIsHot = this.rblBitIsHot.Items[0].Selected;
        
            
            if(!MyModel.IsCommend)
            {
                if (this.rblIsCommend.Items[0].Selected)
                {
                    WebFunc.JingHuaUpdate(MyModel.Id);
                }        
            }
            MyModel.IsCommend = this.rblIsCommend.Items[0].Selected;
            MyModel.Content = txtContent.Value;

            //提问时间
            DateTime askTime = DateTime.Now;
            if(DateTime.TryParse(txtAskTime.Text,out askTime))
            {
                MyModel.AskTime = askTime;
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("提问时间格式不正确."));
                return;
            }

            //结束时间
            DateTime overTime = DateTime.Now;
            if (DateTime.TryParse(txtOverTime.Text, out overTime))
            {
                MyModel.OverTime = overTime;
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("结束时间格式不正确."));
                return;
            }


            //更新时间
            DateTime updateTime = DateTime.Now;
            if (DateTime.TryParse(txtUpdateTime.Text, out updateTime))
            {
                MyModel.UpdateTime = updateTime;
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("更新时间格式不正确."));
                return;
            }

            //问题状态
            MyModel.State = int.Parse(ddlState.SelectedValue);
            
         
            if (MyBll.Update(MyModel))
            {              
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("修改", "修改问题[" + MyModel.Title + "].");
                Response.Write("<script>alert('修改成功');window.opener.location.reload();window.opener.focus();window.opener=null;window.open('','_self');window.close();</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("修改失败."));
            }
        }
    }
}
