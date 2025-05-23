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
using System.Text;
using Pbzx.Common;

namespace Pinble_Chipped.admin
{
    public partial class ChippedName : System.Web.UI.Page
    {

        DataTable IsResult = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] != null && Request.QueryString["Id"] != "")
                {

                    //lab绑定
                    labBind(Request.QueryString["Id"]);
                    //grid绑定
                    myGridViewBind();
                }
            }
        }

        private void labBind(string Qnumber)
        {
            Pbzx.BLL.Chipped_LaunchInfoManage mybll = new Pbzx.BLL.Chipped_LaunchInfoManage();
            Pbzx.Model.chipped_LaunchInfo launchinfo = mybll.GetModel(Qnumber);
            if (launchinfo != null)
            {
                lblQNumber.Text = launchinfo.QNumber;
                lblUserName.Text = launchinfo.UserName;
                lblLaunchTime.Text = launchinfo.LaunchTime.ToString();

                //彩种
                if (Convert.ToInt32(launchinfo.playName) == 1)
                {
                    lbllottName.Text = "3D";
                }
                else if (Convert.ToInt32(launchinfo.playName) == 2)
                {
                    lbllottName.Text = "七乐彩";
                }
                else if (Convert.ToInt32(launchinfo.playName) == 3)
                {
                    lbllottName.Text = "双色球";
                }
                else if (Convert.ToInt32(launchinfo.playName) == 4)
                {
                    lbllottName.Text = "排列5";
                }
                else if (Convert.ToInt32(launchinfo.playName) == 5)
                {
                    lbllottName.Text = "七星彩";

                }
                else if (Convert.ToInt32(launchinfo.playName) == 6)
                {
                    lbllottName.Text = "大乐透";
                }
                lblExpectNum.Text = launchinfo.ExpectNum.ToString();
                lblTitle.Text = launchinfo.Title;
                lblChoiceNum.Text = launchinfo.ChoiceNum.Replace("|", "<br/>");
                lblAtotalMoney.Text = launchinfo.AtotalMoney.ToString();
                lblShare.Text = launchinfo.Share.ToString();
                lblBuyShare.Text = launchinfo.BuyShare.ToString();
                lblProtect.Text = launchinfo.Protect.ToString();

                //状态
                if (launchinfo.State == 0)
                {
                    labState.Text = "进行中...";
                }
                else if (launchinfo.State == 1)
                {
                    labState.Text = "成功";
                }
                else
                {
                    labState.Text = "失败";
                }
            }
        }

        private void myGridViewBind()
        {
            Pbzx.BLL.Chipped_InfoManage mybll = new Pbzx.BLL.Chipped_InfoManage();
            StringBuilder sb = new StringBuilder();
            if (Request.QueryString["Id"] != null && Request.QueryString["Id"] != "")
            {
                sb.Append("QNumber='" + Request.QueryString["Id"] + "'");
            }
            else
            {
                sb.Append("1=1");
            }
            string Searchstr = sb.ToString();
            //发布时间倒序排列
            string order = "ChippedTime desc";
            int mycount = 0;
            IsResult = mybll.GuestGetBySearchChipped_Info(Searchstr, "*", order, 20, 3, AspNetPager1.CurrentPageIndex, out mycount);
            this.MyGridView.DataSource = IsResult;
            this.MyGridView.DataBind();
            AspNetPagerConfig(mycount);
            if (IsResult == null)
            {
                this.litContent.Text = "<b>抱歉！<p/>暂时没有合买信息</b>";
            }
            else
            {
                this.litContent.Text = "";
            }
        }
        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = 20;
            AspNetPager1.RecordCount = tempCount;
            AddCustomText();
        }
        protected void AddCustomText()
        {
            AspNetPager1.CustomInfoHTML = "总计<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>条&nbsp;";
            AspNetPager1.CustomInfoHTML += "<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "页</font>";
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            myGridViewBind();
        }

        protected void myGridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex > -1)
            {
                if (AspNetPager1.PageCount > 1)
                {
                    e.Row.Cells[0].Text = Convert.ToString(e.Row.RowIndex + 1 + (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize);
                }
                else
                {
                    e.Row.Cells[0].Text = Convert.ToString(e.Row.RowIndex + 1);
                }
            }
        }

        protected void myGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}
