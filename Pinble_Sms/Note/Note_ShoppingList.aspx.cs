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
using System.Text;
using System.Collections.Generic;

namespace Pinble_Sms.Note
{
    public partial class Note_ShoppingList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindList();

            }
        }

        private void BindList()
        {
            StringBuilder but = new StringBuilder();
            but.Append("<table width='94%' border='0' align='center' cellpadding='3' cellspacing='0'>");
            but.Append(" <tr><td style='border-bottom-color: #999999; border-bottom-style: solid; border-bottom-width: 1px;'colspan='6'> <br /></td> </tr>");

            but.Append("<tr bgcolor='#DFDFDF'> ");

            but.Append("<td>");
            but.Append(" <div align='center'><strong><font color='#023A70'>编号</font></strong></div>");
            but.Append("</td>");

            but.Append("  <td>");
            but.Append("<div align='center'>  <strong><font color='#023A70'>服务名称</font></strong></div>");
            but.Append(" </td>");

            but.Append("<td width='230'>");
            but.Append(" <div align='left'> <strong><font color='#023A70'>服务说明</font></strong></div>");
            but.Append("</td>");

            but.Append("<td>");
            but.Append(" <div align='center'><strong><font color='#023A70'>订制</font></strong></div>");
            but.Append("</td>");

            but.Append("</tr>");

            Note_LotteryType tp = new Note_LotteryType();


            List<Pbzx.Model.Note_LotteryType> modelList = tp.GetLists(" Ispublic=1 ");
            if (modelList != null)
            {
                int i = 0;
                foreach (Pbzx.Model.Note_LotteryType lotterytype in modelList)
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

                    but.Append(" <td>" + lotterytype.SName + "</td>");
                    but.Append(" <td  width='230px'> <div align='left'> " + lotterytype.Explain + "</div>");
                    but.Append("</td>");
                    but.Append("<td>");
                    but.Append("<div align='center'>");
                    but.Append("<a href='Note_Details.aspx?id=" + lotterytype.SID + "'><img style='border:0px;' src='/image/dz.gif'  alt='点击订购'/></a>");
                    but.Append("  </div>");
                    but.Append("</td>");

                    but.Append("</tr> ");

                }
            }

            but.Append("</table>");

            mainLayM.InnerHtml = but.ToString();
        }

    }
}
