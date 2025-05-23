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

namespace Pbzx.Web
{
    public partial class About : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string strId = Input.FilterAll(Request["id"]);
                if (!OperateText.IsNumber(strId))
                {
                    strId = "1";
                }
                Pbzx.BLL.PBnet_About MyBll = new Pbzx.BLL.PBnet_About();
                Pbzx.Model.PBnet_About MyModel;

                if (strId != null && strId != "")
                {                  
                    MyModel= MyBll.GetModel(int.Parse(strId.ToString()));

                    lblWeiTitle.Text = MyModel.UsTitle;
                    lblTitle.Text = MyModel.UsTitle;
                    lblContent.Text = MyModel.UsContent;
                }
                else
                {
                    MyModel = MyBll.GetModelName();

                    lblWeiTitle.Text = MyModel.UsTitle;
                    lblTitle.Text = MyModel.UsTitle;
                    lblContent.Text = MyModel.UsContent;
                }
                this.Title = this.lblWeiTitle.Text + " - 拼搏在线彩神通软件";
            }

        }
    }
}
