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
using System.Collections.Generic;

namespace Pinble_Market.admin.Note
{
    public partial class Note_LotteryIssueList : System.Web.UI.Page
    {
        Pbzx.BLL.Note_LotteryIssue isstebll = new Pbzx.BLL.Note_LotteryIssue();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Request.QueryString["SID"] != null && Request.QueryString["SID"] != "")
                {
                    if (Request.QueryString["ID"] != null && Request.QueryString["ID"] != "")
                    {
                        btnok.Text = "修改";
                        Pbzx.Model.Note_LotteryIssue issue = isstebll.GetModel(Convert.ToInt32(Request.QueryString["ID"]));
                        txtQNumber.Text = issue.QNumber;
                        txtContent.Text = issue.Content;
                    }

                    BindList(Convert.ToInt32(Request.QueryString["SID"]));
                }
            }

        }
        /// <summary>
        /// 点击发布
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnok_Click(object sender, EventArgs e)
        {


            if (txtQNumber.Text.Trim() == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "alert('期号不能为空！');", true);
                return;
            }
            if (txtContent.Text.Trim() == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "alert('内容不能为空！');", true);
                return;
            }
            Pbzx.Model.Note_LotteryIssue mode = null;
            if (Request.QueryString["ID"] != null && Request.QueryString["ID"] != "")
            {
                mode = isstebll.GetModel(Convert.ToInt32(Request.QueryString["ID"]));
            }
            else
            {
                mode = new Pbzx.Model.Note_LotteryIssue();
            }
            if (Request.QueryString["SID"] != null && Request.QueryString["SID"] != "")
            {


                mode.QNumber = txtQNumber.Text;
                mode.Content = txtContent.Text;

                mode.SID = Convert.ToInt32(Request.QueryString["SID"]);

                if (Request.QueryString["ID"] != null && Request.QueryString["ID"] != "")
                {
                    isstebll.Update(mode);

                }
                else
                {
                    //判断是否已经发布当前期
                    DateTime dt = Convert.ToDateTime(ViewState["time"]);
                    if (dt.Year == DateTime.Now.Year && dt.Month == DateTime.Now.Month && DateTime.Now.Day == dt.Day)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "", "alert('今天数据已经发布！');", true);
                        return;
                    }
                    else
                    {
                        mode.BeginTime = DateTime.Now;
                        isstebll.Add(mode);
                    }
                }


                txtQNumber.Text = "";
                txtContent.Text = "";
            }

            BindList(Convert.ToInt32(Request.QueryString["SID"]));
            Response.Redirect("Note_LotteryIssueList.aspx?SID=" + Request.QueryString["SID"]);
        }


        private void BindList(int sid)
        {
            StringBuilder but = new StringBuilder();
            but.Append("<table width='90%' border='0' align='center' cellpadding='3' cellspacing='0'>");
            but.Append(" <tr><td style='border-bottom-color: #999999; border-bottom-style: solid; border-bottom-width: 1px;'colspan='9'> <br /></td> </tr>");


            but.Append("<tr bgcolor='#DFDFDF'> ");

            but.Append("<td>");
            but.Append(" <div align='center'><strong><font color='#023A70'>编号</font></strong></div>");
            but.Append("</td>");

            but.Append("  <td>");
            but.Append("<div align='center'>  <strong><font color='#023A70'>期号</font></strong></div>");
            but.Append(" </td>");


            but.Append("<td>");
            but.Append(" <div align='left'> <strong><font color='#023A70'>发布时间</font></strong></div>");
            but.Append("</td>");

            but.Append(" <td>");
            but.Append("<div align='center'>  <strong><font color='#023A70'>发布内容</font></strong></div>");
            but.Append(" </td>");

            but.Append(" <td>");
            but.Append("<div align='center'>  <strong><font color='#023A70'>编辑</font></strong></div>");
            but.Append(" </td>");
            but.Append("</tr>");

            List<Pbzx.Model.Note_LotteryIssue> modelList = isstebll.GetLists("SID=" + sid); ;





            int i = 0;
            if (modelList != null)
            {
                foreach (Pbzx.Model.Note_LotteryIssue issue in modelList)
                {
                    if (i % 2 == 0)
                    {
                        but.Append(" <tr bgcolor='#FFFFFF'>");
                    }
                    else
                    {
                        but.Append(" <tr bgcolor='#DFFFDF'>");
                    }
                    //将最新的一期时间存放到viewstate里面
                    if (i == 0)
                    {
                        ViewState["time"] = issue.BeginTime;
                    }
                    but.Append(" <td>" + ++i + "</td>");

                    but.Append(" <td>" + issue.QNumber + "</td>");
                    //订购时间
                    DateTime dt = issue.BeginTime;


                    string begintime = dt.Year + "年" + dt.Month + "月" + dt.Day + "日";
                    but.Append(" <td>" + begintime + "</td>");


                    if (issue.Content.Length > 50)
                    {
                        but.Append(" <td title='" + issue.Content + "'>" + issue.Content.Substring(0, 50) + "</td>");
                    }
                    else
                    {
                        but.Append(" <td>" + issue.Content + "</td>");
                    }



                    but.Append("<td> <a href='Note_LotteryIssueList.aspx?SID=" + Request.QueryString["SID"] + "&ID=" + issue.ID + "'>编辑</a></td>");

                    but.Append("</td>");
                    but.Append("</tr> ");

                }
            }
            but.Append("</table>");

            mainLay.InnerHtml = but.ToString();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Note_LotteryTypeList.aspx");
        }
    }
}
