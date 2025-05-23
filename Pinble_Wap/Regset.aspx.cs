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

namespace Pinble_Wap
{
    public partial class Regset : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["msg"] != null)
                {
                    switch (Request.QueryString["msg"])
                    {
                        case "1":
                            labtext.Text = "最新数据已经录入，请到下期开奖日再来录入新的数据！";
                            break;
                        case "2":
                            labtext.Text = "更新失败！";
                            break;
                        case "3":
                            labtext.Text = "添加失败！";
                            break;
                        case "4":
                            labtext.Text = "添加成功！";
                            break;
                        case "5":
                            labtext.Text = "更新成功！";
                            break;
                        case "6":
                            labtext.Text = "对不起！此浏览器不支持！";
                            break;
                    }

                }
            }
        }

        protected void lnkbut_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["msg"] != null)
            {
                if (Request.QueryString["msg"] != "6")
                {
                    Response.Redirect("Manage/List3DManage.aspx");
                    return;
                }

            }
            Response.Redirect("http://www.pinble.com");
        }
    }
}
