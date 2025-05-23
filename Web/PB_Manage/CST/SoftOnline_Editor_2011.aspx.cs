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
using Pbzx.Model;
using Pbzx.Common;

namespace Pbzx.Web.PB_Manage.CST
{
    public partial class SoftOnline_Editor_2011 : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["ID"]))
                {
                    //当有ID传来时！
                    BindData(int.Parse(Request["ID"]));
                }
            }
        }
        /// <summary>
        /// 绑定数据方法
        /// </summary>
        /// <param name="ID"></param>
        private void BindData(int ID)
        {
            Pbzx.BLL.CstLogin2010Manager cstLoginBLL = new Pbzx.BLL.CstLogin2010Manager();

            Pbzx.Model.CstLogin2010 model = cstLoginBLL.GetModel(ID);

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
            this.lblOSVersion.Text = model.OSName;
            this.lblFirstLoginTime.Text = model.FirstLoginTime.ToString();
            this.lblLoginTime.Text = model.LastLoginTime.ToString();
            this.lblIP.Text = model.LastLoginIP;
            this.lblLoginCount.Text = model.TodayCount.ToString();
            this.lblTotalCount.Text = model.TotalCount.ToString();
            this.lblAginTime.Text = "普通（紧急）消息时间：" + model.NormalMsgTime.ToString() + "<br/>网页消息时间：" + model.WebMsgTime.ToString() + "<br/>最新资讯时间：" + model.NewsMsgTime.ToString();

        }

        protected void btn_OK_Click(object sender, EventArgs e)
        {
            Response.Redirect("SoftOnline_Manage.aspx");
        }
    }
}
