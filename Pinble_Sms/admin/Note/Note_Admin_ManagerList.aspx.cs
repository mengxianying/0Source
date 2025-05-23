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
using Pbzx.BLL;
using Pbzx.Common;
using System.Collections.Generic;

namespace Pinble_Market.admin.Note
{
    public partial class Note_Admin_ManagerList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int sid = 0;
                string username = null;
                if (Request.QueryString["Sid"] != null && Request.QueryString["Sid"] != "")
                {
                    sid = Convert.ToInt32(Request.QueryString["Sid"]);
                }
                BindList(sid, username);
            }
        }


        private void BindList(int sid, string username)
        {
            StringBuilder but = new StringBuilder();
            but.Append("<table width='94%' border='0' align='center' cellpadding='3' cellspacing='0'>");
            but.Append(" <tr><td style='border-bottom-color: #999999; border-bottom-style: solid; border-bottom-width: 1px;'colspan='9'> <br /></td> </tr>");

            but.Append("<tr bgcolor='#DFDFDF'> ");

            but.Append("<td>");
            but.Append(" <div align='center'><strong><font color='#023A70'>编号</font></strong></div>");
            but.Append("</td>");

            but.Append("  <td>");
            but.Append("<div align='center'>  <strong><font color='#023A70'>服务名称</font></strong></div>");
            but.Append(" </td>");


            but.Append("<td>");
            but.Append(" <div align='left'> <strong><font color='#023A70'>用户名</font></strong></div>");
            but.Append("</td>");


            but.Append("<td>");
            but.Append(" <div align='left'> <strong><font color='#023A70'>手机号码</font></strong></div>");
            but.Append("</td>");

            but.Append(" <td>");
            but.Append("<div align='center'>  <strong><font color='#023A70'>订购时间</font></strong></div>");
            but.Append(" </td>");
            but.Append("  <td>");
            but.Append("<div align='center'>  <strong><font color='#023A70'>到期时间</font></strong></div>");
            but.Append(" </td>");
            but.Append("  <td>");
            but.Append("<div align='center'>  <strong><font color='#023A70'>状态</font></strong></div>");
            but.Append(" </td>");
            but.Append("  <td>");
            but.Append("<div align='center'>  <strong><font color='#023A70'>续费方式</font></strong></div>");
            but.Append(" </td>");
            but.Append("<td>");
            but.Append(" <div align='center'><strong><font color='#023A70'>编辑</font></strong></div>");
            but.Append("</td>");

            but.Append("</tr>");

            Note_Customize ce = new Note_Customize();
            List<Pbzx.Model.Note_Customize> modelList = null;

            if (sid != 0 && username == null)
            {
                modelList = ce.GetModelBySid(sid);
            }
            else if (sid != 0 && username != null)
            {
                modelList = ce.GetByList(" SID=" + sid + " and UserName='" + username + "' ");
            }
            else if (sid == 0 && username != null)
            {
                modelList = ce.GetByList(" UserName like '%" + username + "%' ");
            }
            else
            {
                modelList = ce.GetByList("");
            }




            int i = 0;
            if (modelList != null)
            {
                foreach (Pbzx.Model.Note_Customize customize in modelList)
                {
                    if (i % 2 == 0)
                    {
                        but.Append(" <tr bgcolor='#FFFFFF'>");
                    }
                    else
                    {
                        but.Append(" <tr bgcolor='#DFFFDF'>");
                    }
                    but.Append(" <td>" + ++i + "</td>");

                    string sName = "";
                    Pbzx.BLL.Note_LotteryType lotebll = new Pbzx.BLL.Note_LotteryType();
                    Pbzx.Model.Note_LotteryType note = lotebll.GetModel(customize.SID);
                    if (note != null)
                    {
                        sName = note.SName;
                    }
                    else
                    {
                        sName = "该类型可能已经不存在！";
                    }

                    but.Append(" <td>" + sName + "</td>");


                    but.Append(" <td>" + customize.UserName + "</td>");


                    but.Append(" <td > <div align='left'> " + customize.Phone + "</div>");
                    but.Append("</td>");
                    //订购时间
                    DateTime dt = customize.BeginTime;
                    string begintime = dt.Year + "年" + dt.Month + "月" + dt.Day + "日";
                    but.Append(" <td>" + begintime + "</td>");

                    //过期时间
                    DateTime dtg = customize.EndTime;
                    string endtime = dtg.Year + "年" + dtg.Month + "月" + dtg.Day + "日";

                    but.Append(" <td>" + endtime + "</td>");
                    string status = "";
                    if (customize.EndTime >= DateTime.Now)
                    {
                        if (customize.Status == 1)
                        {
                            status = "接收短消息";
                        }
                        else if (customize.Status == 0)
                        {
                            status = "不接收短信";
                        }
                    }
                    else
                    {
                        status = "服务已过期";
                    }

                    but.Append(" <td>" + status + "</td>");

                    //续费方式
                    string continuation = "";
                    if (customize.ContinuationType == 0)
                    {
                        continuation = "手动";
                    }
                    else if (customize.ContinuationType == 1)
                    {
                        continuation = "自动";
                    }
                    else
                    {
                        continuation = "错误";
                    }
                    but.Append(" <td>" + continuation + "</td>");

                    but.Append("<td>");
                    if (customize.EndTime < DateTime.Now)
                    {
                        but.Append("<div align='center'>");
                        but.Append("<a href='../../Note/Note_Details.aspx?id=" + customize.SID + "'>服务已过期</a>");
                        but.Append("  </div>");
                    }
                    else
                    {
                        but.Append("<div align='center'>");
                        but.Append("<a href='../../Note/Note_Manager_Edit.aspx?id=" + customize.ID + "&sName=" + sName + "&returnUrl=" + Request.RawUrl.ToString() + "'>编辑</a>");
                        but.Append("  </div>");
                    }
                    but.Append("</td>");




                    but.Append("</tr> ");

                }
            }
            but.Append("</table>");

            mainLay.InnerHtml = but.ToString();

        }

        /// <summary>
        /// 点击查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void btnok_Click1(object sender, EventArgs e)
        {
            BindList(0, txtUserName.Text);
        }
    }


}
