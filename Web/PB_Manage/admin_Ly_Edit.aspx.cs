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
    public partial class admin_Ly_Edit : AdminBasic
    {
       // public int intID = ;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int intID = Convert.ToInt32(Request.QueryString["ID"]);
                Pbzx.BLL.PBnet_LyBook BookBll = new Pbzx.BLL.PBnet_LyBook();
                Pbzx.Model.PBnet_LyBook BookModel = BookBll.GetModel(intID);
                this.txtLyContent.Text = BookModel.LyContent;
                this.lblLy_Email.Text = BookModel.Ly_Email;
                this.lblLyUserName.Text = BookModel.LyUserName;
                this.lblLySort.Text = WebFunc.GetLyTypeByID(BookModel.LySort);                
                Pbzx.BLL.PBnet_LyResume ResumeBll = new Pbzx.BLL.PBnet_LyResume();
                if (ResumeBll.Exists(intID))
                {
                    Pbzx.Model.PBnet_LyResume ResumeModel = ResumeBll.GetModel(intID);
                    this.txtResume.Text = ResumeModel.ResumeContent;
                }                
            }

        }

        protected void btBack_Click(object sender, EventArgs e)
        {
            int intID = Convert.ToInt32(Request.QueryString["ID"]);
            Pbzx.BLL.PBnet_LyBook BookBll = new Pbzx.BLL.PBnet_LyBook();
            Pbzx.Model.PBnet_LyBook BookModel = BookBll.GetModel(intID);
            BookModel.LyState = 1;
            Pbzx.BLL.PBnet_LyResume ResumeBll = new Pbzx.BLL.PBnet_LyResume();
            Pbzx.Model.PBnet_LyResume ResumeModel;
            if (ResumeBll.Exists(intID))
            {
                ResumeModel = ResumeBll.GetModel(intID);
                ResumeModel = ResumeBll.GetModel(intID);
                ResumeModel.SystemNumber = intID;
                ResumeModel.ResumeTime = DateTime.Now;
                ResumeModel.ResumeContent = this.txtResume.Text;
                ResumeModel.ResumeAuthor = WebFunc.GetCurrentAdmin();
                if (ResumeBll.Update(ResumeModel) && BookBll.Update(BookModel))
                {
                    Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("¡Ù—‘ªÿ∏¥≥…π¶", "ªÿ∏¥[" + BookModel.Ly_Email + "]¡Ù—‘≥…π¶.");
                    Response.Write("<script>alert('¡Ù—‘ªÿ∏¥≥…π¶');window.opener.location.reload();window.opener.focus();window.opener=null;window.open('','_self');window.close();</script>");
                }
                else
                {
                    Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("¡Ù—‘ªÿ∏¥ ß∞‹", "ªÿ∏¥[" + BookModel.Ly_Email + "]¡Ù—‘ ß∞‹.");
                    Response.Write("<script>alert('¡Ù—‘ªÿ∏¥ ß∞‹');window.opener=null;window.open('','_self');window.close();</script>");
                }                
            }
            else
            {
             
                ResumeModel = new Pbzx.Model.PBnet_LyResume();
                ResumeModel.SystemNumber = intID;
                ResumeModel.ResumeTime = DateTime.Now;
                ResumeModel.ResumeContent = this.txtResume.Text;
                if (ResumeBll.Add(ResumeModel) && BookBll.Update(BookModel))
                {                    
                    Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("¡Ù—‘ªÿ∏¥≥…π¶", "ªÿ∏¥[" + BookModel.Ly_Email + "]¡Ù—‘≥…π¶.");
                    Response.Write("<script>alert('¡Ù—‘ªÿ∏¥≥…π¶');window.opener.location.reload();window.opener.focus();window.opener=null;window.open('','_self');window.close();</script>");
                }
                else
                {
                    Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("¡Ù—‘ªÿ∏¥ ß∞‹", "ªÿ∏¥[" + BookModel.Ly_Email + "]¡Ù—‘ ß∞‹.");
                    Response.Write("<script>alert('¡Ù—‘ªÿ∏¥ ß∞‹');window.opener=null;window.open('','_self');window.close();</script>");
                }

            }
                   
        }
    }
}
