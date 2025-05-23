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

namespace Pbzx.Web.PB_Manage.CST
{
    public partial class SoftOnline_Editor : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["ID"]))
            {
                //当有ID传来时！
                BindData(int.Parse(Request["ID"]));
            }
        }
        /// <summary>
        /// 绑定数据方法
        /// </summary>
        /// <param name="ID"></param>
        private void BindData(int ID)
        {
            Pbzx.BLL.CstLogin cstLoginBLL = new Pbzx.BLL.CstLogin();

            Pbzx.Model.CstLogin model = cstLoginBLL.GetModel(ID);

            this.lblHDSN.Text = "<a href='SoftReg_Manager.aspx?strHDSN=" + model.HDSN + "' target='_blank'>" + model.HDSN + "</a>";
            this.lblStatus.Text = Method.ShowStatus(model.Status);
            this.lblRN.Text = model.RN;
            this.lblRegType.Text = Method.ShowRegType(model.HDSN.Substring(4, 1));

            Pbzx.BLL.CstSoftware softBLL = new Pbzx.BLL.CstSoftware();

            string[] result = softBLL.Chksettype(model.SoftwareType, model.InstallType);

            this.lblSoftwareType.Text = result[0];

            this.lblInstallType.Text = result[1];

            this.lblTVersion.Text = model.Version;
            this.lblExpireDate.Text = model.ExpireDate.ToString();
            this.lblOSVersion.Text = model.OSVersion;
            this.lblFirstLoginTime.Text = model.FirstLoginTime.ToString();
            this.lblLoginTime.Text = model.LoginTime.ToString();
            this.lblIP.Text = model.IP;
            this.lblLoginCount.Text = model.LoginCount.ToString();
            this.lblTotalCount.Text = model.TotalCount.ToString();
            this.lblAginTime.Text = model.AginTime.ToString();

        }

        protected void btn_OK_Click(object sender, EventArgs e)
        {
            Response.Redirect("SoftOnline_Manage.aspx");
        }
    }
}
