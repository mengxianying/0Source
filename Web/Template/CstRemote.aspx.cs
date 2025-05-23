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
using Maticsoft.DBUtility;

namespace Pbzx.Web.Template
{
    public partial class CstRemote : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindNewSoft();
                BindNewNews();              
            }
        }
        private void BindNewSoft()
        {
            //DataTable dtData = null;
            Pbzx.BLL.PBnet_Product ProductBll = new Pbzx.BLL.PBnet_Product();

            string tempSql = "select * from(select * from(SELECT TOP 5 pb_SoftID, pb_SoftName, pb_SoftVersion, pb_DownloadUrl1, pb_updatetime, 1 AS myType FROM PBnet_Product where " + Method.product + "  ORDER BY 5 DESC) t1 ";
            tempSql += " union ";
            tempSql += "select * from(SELECT TOP 5 PBnet_SoftID,  pbnet_SoftName, pbnet_SoftVersion, pb_DownloadUrl1, pb_updatetime, 2 AS myType FROM PBnet_soft where " + Method.soft + "  ORDER BY 5 DESC) t2) t order by t.pb_updatetime desc";


            //string tempSql = "SELECT TOP 5 pb_SoftID, pb_SoftName, pb_SoftVersion, pb_DownloadUrl1, pb_updatetime, 1 AS myType FROM PBnet_Product UNION SELECT TOP 5 PBnet_SoftID,  pbnet_SoftName, pbnet_SoftVersion, pb_DownloadUrl1, pb_updatetime, 2 FROM PBnet_soft ORDER BY 5 DESC";
            DataSet dsProduct = DbHelperSQL.Query(tempSql);
            StringBuilder sb = new StringBuilder();
            sb.Append("<table width=\"100%\" border=\"0\" cellpadding=\"1\" cellspacing=\"1\" bgcolor=\"#0062C4\">");
            sb.Append("<tr height=\"18px\" ><td width=\"73%\" align=\"center\" bgcolor=\"#ECFFFF\">");
            sb.Append("<span class=\"style7\">软件名称</span>");
            sb.Append("</td>");
            sb.Append("<td width=\"27%\" align=\"center\" bgcolor=\"#ECFFFF\"><span class=\"style7\">版本</span></td>");
            sb.Append("</tr>");


            for (int i = 0; i < dsProduct.Tables[0].Rows.Count; i++)
            {
                DataRow tempRow = dsProduct.Tables[0].Rows[i];
                sb.Append("<tr><td align='left'valign=\"middle\"   bgcolor='#FFFFFF'>");
                if (tempRow["myType"].ToString() == "1")
                {
                    sb.Append("<a  class='style2'  href='" + WebInit.webBaseConfig.WebUrl + "Soft_explain.aspx?ID=" + Input.Encrypt(tempRow["pb_SoftID"].ToString()) + "' target='_blank' title='" + tempRow["pb_SoftName"].ToString() + "'  >" + StrFormat.CutStringByNum(tempRow["pb_SoftName"], 11 * 2) + "</a>");
                }
                else
                {
                    sb.Append("<a  class='style2' href='" + WebInit.webBaseConfig.WebUrl + "Source_explain.aspx?ID=" + Input.Encrypt(tempRow["pb_SoftID"].ToString()) + "' target='_blank' title='" + tempRow["pb_SoftName"].ToString() + "' >" + StrFormat.CutStringByNum(tempRow["pb_SoftName"], 11 * 2) + "</a>");
                }
                sb.Append("</td><td align=\"center\" valign=\"middle\" bgcolor=\"#FFFFFF\">");
                sb.Append("<span class='style5'>");
                sb.Append("" + tempRow["pb_SoftVersion"].ToString() + "");
                sb.Append("</span></td></tr>");
            }
            sb.Append("<tr align=\"right\"> <td colspan=\"2\" bgcolor=\"#FFFFFF\">");
            sb.Append("<a href='" + WebInit.webBaseConfig.WebUrl + "Soft.aspx' target=\"_blank\"><font color=\"#FF0000\"><strong>更多>>></strong></font></a>&nbsp;&nbsp;");
            sb.Append("</td></tr></table>");
            this.NewSoft.InnerHtml = sb.ToString();

        }

        private void BindNewNews()
        {
            //DataTable dtData = null;
            Pbzx.BLL.PBnet_Bulletin ProductBll = new Pbzx.BLL.PBnet_Bulletin();
            string tempSql = "SELECT TOP 11 NvarTitle, NvarShortTitle, SavePath,DatDateAndTime FROM PBnet_Bulletin where BitIsPass = 1 and ShowInSoft=1 order by 4 desc";
            DataSet dsProduct = DbHelperSQL.Query(tempSql);
            StringBuilder sb = new StringBuilder();
            sb.Append("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\"  height='33' >");
            for (int i = 0; i < dsProduct.Tables[0].Rows.Count; i++)
            {
                    DataRow tempRow = dsProduct.Tables[0].Rows[i];
                    sb.Append("<tr><td width=\"95%\" height=\"17px\" align='left'>");
                    if (tempRow["NvarShortTitle"].ToString() != null && tempRow["NvarShortTitle"].ToString() != "")
                    {
                        sb.Append("&nbsp;&nbsp;<span class='style2' style=\"color: #666666\">·</span>");
                        sb.Append("<a class='style2' href='" + tempRow["SavePath"].ToString() + "'target='_blank' title='" + tempRow["NvarShortTitle"].ToString() + "' >" + StrFormat.CutStringByNum(tempRow["NvarShortTitle"], 19 * 2) + "</a>");
                    }
                    else
                    {
                        sb.Append("&nbsp;&nbsp;<span class='style2' style=\"color: #666666\">·</span>");
                        sb.Append("<a class='style2' href='" + tempRow["SavePath"].ToString() + "'target='_blank' title='" + tempRow["NvarTitle"].ToString() + "' >" + StrFormat.CutStringByNum(tempRow["NvarTitle"], 19 * 2) + "</a>");

                    }
                    sb.Append("</td></tr>");                
            }
            sb.Append("<tr><td width=\"100%\" height=\"14px\" valign=\"bottom\" align=\"right\">");
            sb.Append("<a  href='" + WebInit.webBaseConfig.WebUrl + "Bulletin.htm' target=\"_blank\"><font color=\"#FF0000\"><strong>更多>>></strong></font></a>&nbsp;&nbsp;");
            sb.Append("</td></tr></table>");
            this.NewNews.InnerHtml = sb.ToString();
        }
    }
}
