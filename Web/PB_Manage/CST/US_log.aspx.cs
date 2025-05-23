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
    public partial class US_log : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MyGridView.PageSize = WebInit.webBaseConfig.WebPageNum;
                if (ViewState["order"] == null)
                {
                    ViewState["order"] = "StartTime";
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

            #region 孟新加(2010-01-05)
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
                    //2013-2-20 zhouwei
                    string whereStr = "";
                    if (Request["SoftwareName"] == "数字6 1")
                    {
                        whereStr = "数字6+1";
                    }
                    else
                    {
                        whereStr = Request["SoftwareName"];
                    }
                    //bu1.Append(" and InstallType in (select InstallType from  CstSoftware where SoftwareName='" + Request["SoftwareName"] + "' ) ");
                    bu1.Append(" and InstallType in (select InstallType from  CstSoftware where SoftwareName='" + whereStr + "' ) ");
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
            if (!string.IsNullOrEmpty(Request["Status"]))
            {
                bu1.Append(" and Status='" + Request["Status"] + "'");
            }



            if (!string.IsNullOrEmpty(Request["strHDSN"]))
            {
                if (Request["strHDSN"].Length == 16)
                {
                    if (!string.IsNullOrEmpty(Request["yuan"]) && Request["yuan"] == "yes")
                    {
                        bu1.Append(" and left(HDSN,4)='" + Request["strHDSN"].Substring(0, 4) + "' and substring(HDSN,9,5)='" + Request["strHDSN"].Substring(8, 5) + "' ");
                    }
                    else
                    {
                        bu1.Append(" and HDSN='" + Request["strHDSN"] + "'");
                    }
                }
            }

            if (!string.IsNullOrEmpty(Request["strVersion"]))
            {
                bu1.Append(" and ProgramVer='" + Request["strVersion"] + "' ");
            }

            if (!string.IsNullOrEmpty(Request["strIP"]))
            {
                //    bu1.Append(" and IP='" + Request["strIP"] + "' ");
                if (Request["strIP"].Trim().Substring(Request["strIP"].Trim().Length - 1) != ".")
                {
                    bu1.Append(" and IP='" + Request["strIP"].Trim() + "' ");
                }
                else
                {
                    bu1.Append(" and IP like '" + Request["strIP"].Trim() + "%' ");
                }
            }
            if (!string.IsNullOrEmpty(Request["strSID"]))
            {
                bu1.Append(" and ServiceID='" + Request["strSID"] + "' ");
            }

            if (!string.IsNullOrEmpty(Request["dateType"]))
            {
                if (!string.IsNullOrEmpty(Request["strCreateTime1"]) && !string.IsNullOrEmpty(Request["strCreateTime2"]))
                {
                    bu1.Append(" and StartTime between '" + Request["strCreateTime1"] + "' and '" + Request["strCreateTime2"] + " 23:59:59'  ");
                }
            }
            //处理快速搜索
            if (!string.IsNullOrEmpty(Request["strKuais"]))
            {
                int intKuai = int.Parse(Request["strKuais"].ToString());
                switch (intKuai)
                {

                    case 1:
                        bu1.Append(" and DATEDIFF(hh,StartTime,EndTime)>=1 ");
                        break;
                    case 2:
                        bu1.Append("  and DATEDIFF(hh,StartTime,EndTime)>=3 ");
                        break;
                    case 3:
                        bu1.Append(" and DATEDIFF(hh,StartTime,EndTime)>=6 ");
                        break;
                    case 4:
                        bu1.Append(" and DATEDIFF(hh,StartTime,EndTime)>=12 ");
                        break;
                    case 5:
                        bu1.Append(" and DATEDIFF(hh,StartTime,EndTime)>=24 ");
                        break;
                    case 6:
                        bu1.Append(" and DATEDIFF(d,StartTime,EndTime)>=2 ");
                        break;

                    case 7:
                        bu1.Append(" and DATEDIFF(d,StartTime,EndTime)>=3 ");
                        break;
                    case 8:
                        bu1.Append("  and UseType in (10,20) ");
                        break;
                    case 9:
                        bu1.Append(" and UseType in (106,107) ");
                        break;
                    case 10:
                        bu1.Append(" and UseType=104 ");
                        break;
                    case 11:
                        bu1.Append(" and UseType in (3,11,21) ");
                        break;
                    case 12:
                        bu1.Append(" and UseType in (100,101,102,103) ");
                        break;
                    case 13:
                        bu1.Append(" and UseType =190 ");
                        break;
                    case 14:
                        bu1.Append(" and SUBSTRING ( Username , 1 , 1 )='#'");
                        break;
                    case 15:
                        bu1.Append(" and  SUBSTRING ( Username , 1 , 1 )='@'");
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
            Pbzx.BLL.CN_Log logBLL = new Pbzx.BLL.CN_Log();
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

            DataTable lsResult = logBLL.GuestGetBySearch(Searchstr, "*", order, Pbzx.Common.WebInit.webBaseConfig.WebPageNum, 3, AspNetPager1.CurrentPageIndex, out myCount);

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

            return result[0] + "(" + result[1] + ")";
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

        public string GetUtype(object nType)
        {
            return Pbzx.Common.Method.ShowUserType(nType);
        }
        public static string GetStatus(object nType)
        {
            string type = "";
            int intType = int.Parse(nType.ToString());
            switch (intType)
            {
                case 0:
                    type = "未登录";
                    break;
                case 1:
                    type = "登录";
                    break;
                case 2:
                    type = "退出";
                    break;
                case 3:
                    type = "超时";
                    break;
                case 4:
                    type = "超时2";
                    break;
                case 10:
                    type = "强退";
                    break;
                case 20:
                    type = "错误";
                    break;
                case 21:
                    type = "密码错";
                    break;
                case 22:
                    type = "ID锁定";
                    break;
                case 23:
                    type = "ID禁用";
                    break;
                case 24:
                    type = "数超额";
                    break;
                case 30:
                    type = "贴不够";
                    break;
                case 31:
                    type = "停试用";
                    break;
                case 32:
                    type = "超试次";
                    break;
                case 33:
                    type = "超试期";
                    break;
                case 34:
                    type = "超PC数";
                    break;
                case 35:
                    type = "超用期";
                    break;
                default:
                    type = "错误";
                    break;
            }
            return type;
        }

        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                string href = "<a href='US_log_Editor.aspx?ID=" + e.Row.Cells[0].Text + "' target='_blank'>";
                e.Row.Cells[0].Text = href + "(" + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString() + ")</a>";
            }
        }


        public string CKHDNS(object obj)
        {
            if (obj == null)
            {
                return "";
            }
            if (obj.ToString() == "")
            {
                return "";
            }
            return "<a href='US_log.aspx?strHDSN=" + obj.ToString() + "' class='wuxia'>" + obj.ToString() + "</a>[<a href='US_log.aspx?yuan=yes&strHDSN=" + obj.ToString() + "' class='wuxia'><font"
                    + "color='" + Pbzx.Common.Method.CheckRegType(obj.ToString()) + "'>原</font></a>]";

        }

    }
}
