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

namespace Pinble_Chat
{
    public partial class Chat_Bulletin_Show : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                 Pbzx.BLL.PBnet_Bulletin BuletinBll = new Pbzx.BLL.PBnet_Bulletin();
                  Pbzx.Model.PBnet_Bulletin BulletionMedel;
                string str = Input.FilterAll(Input.Decrypt(Request.QueryString["Id"]));
                if (OperateText.IsNumber(str))
                {

                    BulletionMedel = BuletinBll.GetModel(Convert.ToInt32(str));
                    this.lblTitle.Text = BulletionMedel.NvarTitle;
                    this.lblAndTime.Text = BulletionMedel.DatDateAndTime.ToString();
                    this.lblSource.Text = BulletionMedel.Source;
                    //if (BulletionMedel.VarPicUrl != null)
                    //{
                    //    this.lblmyImg.Text = "<img src='BulletionMedel.VarPicUrl' Border='0'>";

                    //}
                    //else
                    //{
                    //    this.lblmyImg.Visible = false;
                    //}
                    this.lblContent.Text = BulletionMedel.NteContent;
                    this.Title = BulletionMedel.NvarTitle + " - 语音视频聊彩室 - 拼搏在线彩神通软件";

                }
               
            }
        }
    }
}
