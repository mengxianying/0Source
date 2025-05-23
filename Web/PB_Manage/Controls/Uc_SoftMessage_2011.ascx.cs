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
using System.Text;
using Maticsoft.DBUtility;
using Pbzx.BLL;

namespace Pbzx.Web.PB_Manage.Controls
{
    public partial class Uc_SoftMessage_2011 : System.Web.UI.UserControl
    {
        CstSoftware softwar = new CstSoftware();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               
                dropDownBind();
                this.txtCreateTime1.Text = DateTime.Now.ToShortDateString();
                this.txtCreateTime2.Text = DateTime.Now.ToShortDateString();

                Method.BindText(txtTitleSerch, "strTitleSerch", true);
                Method.BindText(txtCreateTime1, "strCreateTime1", true);
                Method.BindText(txtCreateTime2, "strCreateTime2", true);
                Method.BindDdlOrRadio(this.rblDateType, "dateType", true);

                Method.BindDdlOrRadio(this.DropList1, "DropList1", true);
                Method.BindDdlOrRadio(this.DropList2, "DropList2", true);
                Method.BindDdlOrRadio(this.DropList3, "DropList3", true);
                Method.BindDdlOrRadio(this.DropList4, "DropList4", true);
            }
        }

        private void dropDownBind()
        {
            string sqlSoft = "Select SoftwareName,SoftwareType from [CstSoftware] Group By SoftwareName,SoftwareType order by min(CstID)";
            DataTable ds = softwar.GetLisBySql(sqlSoft);
            DropList1.DataTextField = "SoftwareName";
            DropList1.DataValueField = "SoftwareName";
            DropList1.DataSource = ds;
            DropList1.DataBind();
            //注册限定
            RegType();
            //用户限定
            UserType();
            BindInstall();
        }
        /// <summary>
        /// 用户类型绑定方法
        /// </summary>
        private void UserType()
        {
            XmlDataSource userdata = new XmlDataSource();
            userdata.DataFile = "~/xml/Msg_UserClass.xml";
            DropList4.DataSource = userdata;
            DropList4.DataBind();
        }
        /// <summary>
        /// 注册类型手动绑定方法
        /// </summary>
        private void RegType()
        {
            XmlDataSource regdata = new XmlDataSource();
            regdata.DataFile = "~/xml/Msg_RegType.xml";
            DropList3.DataSource = regdata;
            DropList3.DataBind();
        }
        /// <summary>
        /// 点击查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOK_Click(object sender, EventArgs e)
        {
            StringBuilder bu1 = new StringBuilder();

            bu1.Append(Method.BindText(txtTitleSerch, "strTitleSerch", false));
            bu1.Append(Method.BindText(txtCreateTime1, "strCreateTime1", false));
            bu1.Append(Method.BindText(txtCreateTime2, "strCreateTime2", false));
            bu1.Append(Method.BindDdlOrRadio(this.rblDateType, "dateType", false));

            bu1.Append(Method.BindDdlOrRadio(this.DropList1, "DropList1", false));
            bu1.Append(Method.BindDdlOrRadio(this.DropList2, "DropList2", false));
            bu1.Append(Method.BindDdlOrRadio(this.DropList3, "DropList3", false));
            bu1.Append(Method.BindDdlOrRadio(this.DropList4, "DropList4", false));

            Response.Redirect("SoftMessage_Manage_2011.aspx?" + bu1.ToString());
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("SoftMessage_Manage_2011.aspx");
        }
        /// <summary>
        /// 改变触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            BindInstall();
        }
        /// <summary>
        /// 二级绑定
        /// </summary>
        private void BindInstall()
        {
            this.DropList2.Items.Clear();
            ListItem lt = new ListItem();
            lt.Text = "所有";
            lt.Value = "0";
            lt.Selected = true;
            DropList2.Items.Add(lt);
            string sqlInstall = "select InstallType, InstallName  from dbo.CstSoftware where SoftwareName='" + this.DropList1.SelectedItem.Text + "' order by CstID  ";
            DataTable ds = softwar.GetLisBySql(sqlInstall);
            DropList2.DataTextField = "InstallName";
            DropList2.DataValueField = "InstallName";
            DropList2.DataSource = ds;
            DropList2.DataBind();
        }
    }
}