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

namespace Pinble_Ask
{
    public partial class Bulletin_Ask_Show : System.Web.UI.Page
    {
        public string title = "";
        public string content = "";  
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string strId = Input.FilterAll(Input.Decrypt(Request["id"]));
                if (strId != null && strId != "")
                {
                    Pbzx.BLL.PBnet_Bulletin MyBll = new Pbzx.BLL.PBnet_Bulletin();
                    Pbzx.Model.PBnet_Bulletin MyModel = MyBll.GetModel(int.Parse(strId.ToString()));

                    title = MyModel.NvarTitle;
                    content = MyModel.NteContent;
                    this.lblAndTime.Text = MyModel.DatDateAndTime.ToString();
                    this.lblSource.Text = MyModel.Source;

                    this.Title = title + " - 拼搏吧 - 拼搏在线彩神通软件";
                  
                }
            }
        }
    }
}
