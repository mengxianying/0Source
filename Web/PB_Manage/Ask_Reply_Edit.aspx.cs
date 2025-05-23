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
    public partial class Ask_Reply_Edit : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string str = Request.QueryString["ID"];
                Pbzx.BLL.PBnet_ask_Reply MyBll = new Pbzx.BLL.PBnet_ask_Reply();
                Pbzx.Model.PBnet_ask_Reply MyModel;
                if (OperateText.IsNumber(str))
                {
                    MyModel = MyBll.GetModel(Convert.ToInt32(str.ToString()));
                    this.lblQuestionId.Text = GetTitle(MyModel.QuestionId.ToString());
                    this.lblReplyer.Text = MyModel.Replyer;
                    this.lblReplyTime.Text = MyModel.ReplyTime.ToString();

                    this.lblReplyerId.Text = MyModel.ReplyerId.ToString();
                    this.lblIsBest.Text= Convert.ToBoolean(MyModel.IsBest) ? "<font color='red'>ÊÇ</font>":"<font color='blue'>·ñ</font>";
                    this.lblAttachId.Text = MyModel.AttachId.ToString();

                    this.txtGoodComment.Text = MyModel.GoodComment.ToString();
                    this.txtBadComment.Text = MyModel.BadComment.ToString();
                    this.txtReferenceBook.Text = MyModel.ReferenceBook;

                    this.txtComment.Text = MyModel.Comment;
                    this.txtContent.Text = MyModel.Content;

                }
            
            }
        }
        protected string GetTitle(object num)
        {
            string title = "";
            int intnum = int.Parse(num.ToString());
            Pbzx.BLL.PBnet_ask_Question TitleBll = new Pbzx.BLL.PBnet_ask_Question();
            Pbzx.Model.PBnet_ask_Question TitleModel = TitleBll.GetModel(intnum);
            title = TitleModel.Title;
            return title;
        }
    }
}
