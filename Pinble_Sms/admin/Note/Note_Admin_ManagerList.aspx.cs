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
            but.Append(" <div align='center'><strong><font color='#023A70'>���</font></strong></div>");
            but.Append("</td>");

            but.Append("  <td>");
            but.Append("<div align='center'>  <strong><font color='#023A70'>��������</font></strong></div>");
            but.Append(" </td>");


            but.Append("<td>");
            but.Append(" <div align='left'> <strong><font color='#023A70'>�û���</font></strong></div>");
            but.Append("</td>");


            but.Append("<td>");
            but.Append(" <div align='left'> <strong><font color='#023A70'>�ֻ�����</font></strong></div>");
            but.Append("</td>");

            but.Append(" <td>");
            but.Append("<div align='center'>  <strong><font color='#023A70'>����ʱ��</font></strong></div>");
            but.Append(" </td>");
            but.Append("  <td>");
            but.Append("<div align='center'>  <strong><font color='#023A70'>����ʱ��</font></strong></div>");
            but.Append(" </td>");
            but.Append("  <td>");
            but.Append("<div align='center'>  <strong><font color='#023A70'>״̬</font></strong></div>");
            but.Append(" </td>");
            but.Append("  <td>");
            but.Append("<div align='center'>  <strong><font color='#023A70'>���ѷ�ʽ</font></strong></div>");
            but.Append(" </td>");
            but.Append("<td>");
            but.Append(" <div align='center'><strong><font color='#023A70'>�༭</font></strong></div>");
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
                        sName = "�����Ϳ����Ѿ������ڣ�";
                    }

                    but.Append(" <td>" + sName + "</td>");


                    but.Append(" <td>" + customize.UserName + "</td>");


                    but.Append(" <td > <div align='left'> " + customize.Phone + "</div>");
                    but.Append("</td>");
                    //����ʱ��
                    DateTime dt = customize.BeginTime;
                    string begintime = dt.Year + "��" + dt.Month + "��" + dt.Day + "��";
                    but.Append(" <td>" + begintime + "</td>");

                    //����ʱ��
                    DateTime dtg = customize.EndTime;
                    string endtime = dtg.Year + "��" + dtg.Month + "��" + dtg.Day + "��";

                    but.Append(" <td>" + endtime + "</td>");
                    string status = "";
                    if (customize.EndTime >= DateTime.Now)
                    {
                        if (customize.Status == 1)
                        {
                            status = "���ն���Ϣ";
                        }
                        else if (customize.Status == 0)
                        {
                            status = "�����ն���";
                        }
                    }
                    else
                    {
                        status = "�����ѹ���";
                    }

                    but.Append(" <td>" + status + "</td>");

                    //���ѷ�ʽ
                    string continuation = "";
                    if (customize.ContinuationType == 0)
                    {
                        continuation = "�ֶ�";
                    }
                    else if (customize.ContinuationType == 1)
                    {
                        continuation = "�Զ�";
                    }
                    else
                    {
                        continuation = "����";
                    }
                    but.Append(" <td>" + continuation + "</td>");

                    but.Append("<td>");
                    if (customize.EndTime < DateTime.Now)
                    {
                        but.Append("<div align='center'>");
                        but.Append("<a href='../../Note/Note_Details.aspx?id=" + customize.SID + "'>�����ѹ���</a>");
                        but.Append("  </div>");
                    }
                    else
                    {
                        but.Append("<div align='center'>");
                        but.Append("<a href='../../Note/Note_Manager_Edit.aspx?id=" + customize.ID + "&sName=" + sName + "&returnUrl=" + Request.RawUrl.ToString() + "'>�༭</a>");
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
        /// �����ѯ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void btnok_Click1(object sender, EventArgs e)
        {
            BindList(0, txtUserName.Text);
        }
    }


}
