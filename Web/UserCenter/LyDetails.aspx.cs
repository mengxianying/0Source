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

namespace Pbzx.Web.UserCenter
{
    public partial class LyDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["ID"] != null)
                {
                    
                    int num = Convert.ToInt32(Request.QueryString["ID"].ToString());
                    Pbzx.BLL.PBnet_LyBook BookBll = new Pbzx.BLL.PBnet_LyBook();
                    Pbzx.Model.PBnet_LyBook BookModel = BookBll.GetModel(num);
                    this.txtLyContent.Text = BookModel.LyContent;
                    this.lblLy_Email.Text = BookModel.Ly_Email;
                    this.lblLySort.Text = WebFunc.GetLyTypeByID(BookModel.LySort);





                    Pbzx.BLL.PBnet_LyResume ResumeBll = new Pbzx.BLL.PBnet_LyResume();
                   if(ResumeBll.Exists(num))                     
                    {  
                       Pbzx.Model.PBnet_LyResume ResumeMode = ResumeBll.GetModel(num);
                        this.txtResume.Text = ResumeMode.ResumeContent;
                    }
                    else
                    {
                        this.txtResume.Text = "系统提示:此留言暂无回复!";
                    }

                }
            }
        }

        protected void bton_Click(object sender, ImageClickEventArgs e)
        {
            
        }

    
    }
}
