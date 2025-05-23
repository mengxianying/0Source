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

namespace Pbzx.Web.PB_Manage.CST
{
    public partial class US_msg : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MyGridView.PageSize = WebInit.webBaseConfig.WebPageNum;
                if (ViewState["order"] == null)
                {
                    ViewState["order"] = "LastPayTime";
                }
                if (ViewState["isDesc"] == null)
                {
                    ViewState["isDesc"] = true;
                }
                BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
            }
        }


        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = Pbzx.Common.WebInit.webBaseConfig.WebPageNum;
            AspNetPager1.RecordCount = tempCount;
            AddCustomText();
        }
        protected void AddCustomText()
        {
            AspNetPager1.CustomInfoHTML = "总<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>条&nbsp;";
            AspNetPager1.CustomInfoHTML += "本页<font color=\"red\"><b>" + MyGridView.Rows.Count + "</b></font>条&nbsp;";
            AspNetPager1.CustomInfoHTML += "分页:<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "页</font>";
        }

        private string AddParameter()
        {
            StringBuilder bu1 = new StringBuilder();

            Pbzx.BLL.CstSoftware sfBll = new Pbzx.BLL.CstSoftware();

            #region 
            if (!string.IsNullOrEmpty(Request["SoftwareName"]))
            {
                string SoftwareType = sfBll.GetIdByName("SoftwareName", Request["SoftwareName"], "SoftwareType");
                bu1.Append(" and SoftwareType='" + SoftwareType + "' ");
            }
            if (!string.IsNullOrEmpty(Request["InstallName"]))
            {
                //string installType = sfBll.GetIdByName("InstallName", Request["InstallName"], "InstallType");
                bu1.Append(" and InstallType='" + Request["InstallName"] + "' ");
            }
            else
            {
                if (!string.IsNullOrEmpty(Request["SoftwareName"]))
                {
                    bu1.Append(" and InstallType in (select InstallType from  CstSoftware where SoftwareName='" + Request["SoftwareName"] + "' ) ");
                }
            }
            #endregion


            if (!string.IsNullOrEmpty(Request["strName"]))
            {
                bu1.Append(" and Username='" + Request["strName"] + "' ");
            }
            if (!string.IsNullOrEmpty(Request["softwareType"]))
            {
                bu1.Append(" and SoftwareType='" + Request["softwareType"] + "' ");
            }
            if (!string.IsNullOrEmpty(Request["installType"]))
            {
                bu1.Append(" and InstallType='" + Request["installType"] + "'");
            }
            if (!string.IsNullOrEmpty(Request["UserType"]))
            {
                bu1.Append(" and UserType='" + Request["UserType"] + "'");
            }

            if (!string.IsNullOrEmpty(Request["strValidDays"]))
            {
                bu1.Append(" and ValidDays='" + Request["strValidDays"] + "' ");
            }
            if (!string.IsNullOrEmpty(Request["strUseCount"]))
            {
                bu1.Append(" and UseCount='" + Request["strUseCount"] + "' ");
            }
            if (!string.IsNullOrEmpty(Request["strUserRemarks"]))
            {
                bu1.Append(" and UserRemarks like '%" + Request["strUserRemarks"] + "%' ");
            }
            if (!string.IsNullOrEmpty(Request["strRemarks"]))
            {
                bu1.Append(" and Remarks like '%" + Request["strRemarks"] + "%' ");
            }

            if (!string.IsNullOrEmpty(Request["dateType"]))
            {
                if (!string.IsNullOrEmpty(Request["strCreateTime1"]) && !string.IsNullOrEmpty(Request["strCreateTime2"]))
                {
                    if (Request["dateType"] == "1")
                    {
                        bu1.Append(" and CreateTime between '" + Request["strCreateTime1"] + "' and '" + Request["strCreateTime2"] + " 23:59:59'  ");
                    }
                    else if (Request["dateType"] == "2")
                    {
                        bu1.Append(" and ExpireDate between '" + Request["strCreateTime1"] + "' and '" + Request["strCreateTime2"] + " 23:59:59'  ");
                    }
                }
            }
            //处理快速搜索
            if (!string.IsNullOrEmpty(Request["strKuais"]))
            {
                int intKuai = int.Parse(Request["strKuais"].ToString());
                switch (intKuai)
                {

                    case 1:
                        bu1.Append(" and DATEDIFF(d,CreateTime,getDate())<=1 ");
                        break;
                    case 2:
                        bu1.Append("  and DATEDIFF(hh,CreateTime,getDate())<=24 ");
                        break;
                    case 3:
                        bu1.Append(" and DATEDIFF(d,CreateTime,getDate())<=2 ");
                        break;
                    case 4:
                        bu1.Append(" and DATEDIFF(d,CreateTime,getDate())<=3 ");
                        break;
                    default:
                        bu1.Append(" ");
                        break;
                }
            }
            return bu1.ToString();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }
        protected void BindData(string column, bool isDesc)
        {
            Pbzx.BLL.CN_User msgBLL = new Pbzx.BLL.CN_User();
            StringBuilder bu = new StringBuilder();
            bu.Append("1=1");
            bu.Append(this.AddParameter());

            string Searchstr = bu.ToString();
            string order = column;
            int myCount = 0;

            if (isDesc)
            {
                order += " desc ";
            }
            else
            {
                order += " asc ";
            }

            DataTable lsResult = msgBLL.GuestGetBySearch(Searchstr, "*", order, Pbzx.Common.WebInit.webBaseConfig.WebPageNum, 3, AspNetPager1.CurrentPageIndex, out myCount);

            this.MyGridView.DataSource = lsResult;
            this.MyGridView.DataBind();
            AspNetPagerConfig(myCount);

            if (lsResult == null)
            {
                this.litContent.Text = "<b>抱歉！<p/><br/>应该没有找到您搜索的数据记录</b>";
            }
            else
            {
                this.litContent.Text = "";
            }

        }
        protected string GetIpName(object obj)
        {
            Pbzx.BLL.PBnet_ipdata ipBLL = new Pbzx.BLL.PBnet_ipdata();
            return ipBLL.S_getIPaddress(obj.ToString());
        }
        protected string ChkSoftType(object num, object st)
        {
            Pbzx.BLL.CstSoftware softBLL = new Pbzx.BLL.CstSoftware();
            string[] result = softBLL.Chksettype(num, st);
            return "<a href='US_msg.aspx?softwareType=" + num.ToString() + "&installType=" + st.ToString() + "'>" + result[0] + "(" + result[1] + ")" + "</a>";

        }
        protected void MyGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            ViewState["order"] = e.SortExpression.ToString();
            if ((bool)ViewState["isDesc"])
            {
                ViewState["isDesc"] = false;
            }
            else
            {
                ViewState["isDesc"] = true;
            }
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }

        public static string GetDay(object Dnum)
        {
            int intnum = int.Parse(Dnum.ToString());
            if (intnum < 0)
            {
                return "-";
            }
            else
            {
                return intnum.ToString();
            }
        }

        public static string GetUtype(object nType)
        {
            string type = "";
            int intType = int.Parse(nType.ToString());
            switch (intType)
            {
                case 0:
                    type = "初始值";
                    break;
                case 2:
                    type = "无限免费";
                    break;
                case 3:
                    type = "临时使用";
                    break;
                case 10:
                    type = "收费记天";
                    break;
                case 11:
                    type = "免费记天";
                    break;
                case 20:
                    type = "收费包月";
                    break;
                case 21:
                    type = "免费包月";
                    break;
                case 200:
                    type = "禁止使用";
                    break;
                default:
                    type = "错误";
                    break;
            }
            return type;
        }
        protected string GetData(object objUserType, object objExpireDate, object objStatResult)
        {
            return Pbzx.Common.Method.GetExpDate(objUserType, objExpireDate, objStatResult);
        }
        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                string href = "<a href='US_msg_Editor.aspx?ID=" + e.Row.Cells[0].Text + "' target='_blank'>";
                e.Row.Cells[0].Text = href + "(" + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString() + ")</a>";
            }
        }
        public static string xx(object obj)
        {
            return "sdf";

        }
    }
}
