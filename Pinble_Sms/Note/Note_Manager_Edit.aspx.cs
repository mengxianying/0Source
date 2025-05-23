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

                    //����ʱ��
                    DateTime dt = custmd.BeginTime;
                    string begintime = dt.Year + "��" + dt.Month + "��" + dt.Day + "��";
                    labbegintime.Text = begintime;


                    //����ʱ��
                    DateTime dtg = custmd.EndTime;
                    string endtime = dtg.Year + "��" + dtg.Month + "��" + dtg.Day + "��";
                    labendtime.Text = endtime;


                    txtPhone.Text = custmd.Phone;
                    rdbutjF.SelectedValue = custmd.ContinuationType.ToString();
                    rdbutstatus.SelectedValue = custmd.Status.ToString();
                    
                 
                }

            }
        }
        /// <summary>
        /// ���ع����б�
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
        /// ����޸�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (txtPhone.Text.Trim() == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "alert('����д�ֻ����룡');", true);
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
                        ClientScript.RegisterStartupScript(this.GetType(), "", "alert('�޸ĳɹ���');location='" + url + "';", true);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "", "alert('�޸�ʧ�ܣ�');", true);
                    }
                }

            }


        }

    }
}
