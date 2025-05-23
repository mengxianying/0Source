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
using Pbzx.BLL;

namespace Pinble_Sms.Note
{
    public partial class Note_Manager_Edit : System.Web.UI.Page
    {

        Note_Customize cebll = new Note_Customize();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                BindDetails();
            }
        }

        private void BindDetails()
        {
            if (Request.QueryString["id"] != "" && Request.QueryString["sName"] != "")
            {
                lblottoryType.Text = Request.QueryString["sName"];

                Pbzx.Model.Note_Customize custmd = cebll.GetModel(Convert.ToInt32(Request.QueryString["id"]));
                if (custmd != null)
                {

                    //订购时间
                    DateTime dt = custmd.BeginTime;
                    string begintime = dt.Year + "年" + dt.Month + "月" + dt.Day + "日";
                    labbegintime.Text = begintime;


                    //过期时间
                    DateTime dtg = custmd.EndTime;
                    string endtime = dtg.Year + "年" + dtg.Month + "月" + dtg.Day + "日";
                    labendtime.Text = endtime;


                    txtPhone.Text = custmd.Phone;
                    rdbutjF.SelectedValue = custmd.ContinuationType.ToString();
                    rdbutstatus.SelectedValue = custmd.Status.ToString();
                    
                 
                }

            }
        }
        /// <summary>
        /// 返回管理列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnregist_Click(object sender, EventArgs e)
        {
            string url = "Note_Manager.aspx";
            if (Request.QueryString["returnUrl"] != null)
            {
                url = Request.QueryString["returnUrl"];
            }

            Response.Redirect(url);
        }

        /// <summary>
        /// 点击修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (txtPhone.Text.Trim() == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请填写手机号码！');", true);
                return;
            }

            if (Request.QueryString["id"] != "" && Request.QueryString["sName"] != "")
            {
                Pbzx.Model.Note_Customize custmd = cebll.GetModel(Convert.ToInt32(Request.QueryString["id"]));
                if (custmd != null)
                {
                    custmd.Phone = txtPhone.Text;
                    custmd.ContinuationType = Convert.ToInt32(rdbutjF.SelectedValue);
                    custmd.Status = Convert.ToInt32(rdbutstatus.SelectedValue);

                    int result = cebll.Update(custmd);

                    string url = "Note_Manager.aspx";
                    if (Request.QueryString["returnUrl"] != null)
                    {
                        url = Request.QueryString["returnUrl"];
                    }
                    if (result != 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "", "alert('修改成功！');location='" + url + "';", true);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "", "alert('修改失败！');", true);
                    }
                }

            }


        }

    }
}
