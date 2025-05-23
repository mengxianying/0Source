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
    public partial class US_free : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MyGridView.PageSize = WebInit.webBaseConfig.WebPageNum;
                if (ViewState["order"] == null)
                {
                    ViewState["order"] = "LastLoginTime";
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
                    bu1.Append(" and InstallType in (select InstallType from  CstSoftware where SoftwareName='" + Request["SoftwareName"] + "' ) ");
                }
            }
            #endregion

            if (!string.IsNullOrEmpty(Input.FilterAll(Request["strDiskCVol"])))
            {
                bu1.Append(" and DiskCVol like '%" + Input.FilterAll(Request["strDiskCVol"]) + "%' ");
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
            if (!string.IsNullOrEmpty(Request["strUseCount"]))
            {
                bu1.Append(" and UseCount='" + Request["strUseCount"] + "'");
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
            if (!string.IsNullOrEmpty(Request["strLastLoginIP"]))
            {
              //  bu1.Append(" and LastLoginIP='" + Request["strLastLoginIP"] + "' ");
                if (Request["strLastLoginIP"].Trim().Substring(Request["strLastLoginIP"].Trim().Length - 1) != ".")
                {
                    bu1.Append(" and LastLoginIP='" + Request["strLastLoginIP"].Trim() + "' ");
                }
                else
                {
                    bu1.Append(" and LastLoginIP like '" + Request["strLastLoginIP"].Trim() + "%' ");
                }
            }

            if (!string.IsNullOrEmpty(Request["strLastLoginID"]))
            {
                bu1.Append(" and LastLoginID='" + Request["strLastLoginID"] + "' ");
            }
            if (!string.IsNullOrEmpty(Request["strServiceID"]))
            {
                bu1.Append(" and ServiceID='" + Request["strServiceID"] + "' ");
            }

            if (!string.IsNullOrEmpty(Request["dateType"]))
            {
                if (!string.IsNullOrEmpty(Request["strCreateTime1"]) && !string.IsNullOrEmpty(Request["strCreateTime2"]))
                {
                    if (Request["dateType"] == "1")
                    {
                        bu1.Append(" and FirstLoginTime between '" + Request["strCreateTime1"] + "' and '" + Request["strCreateTime2"] + " 23:59:59'  ");
                    }
                    else if (Request["dateType"] == "2")
                    {
                        bu1.Append(" and LastLoginTime between '" + Request["strCreateTime1"] + "' and '" + Request["strCreateTime2"] + " 23:59:59'  ");
                    }
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
            Pbzx.BLL.CN_FreeTestUser freeBLL = new Pbzx.BLL.CN_FreeTestUser();
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

            DataTable lsResult = freeBLL.GuestGetBySearch(Searchstr, "*", order, Pbzx.Common.WebInit.webBaseConfig.WebPageNum, 3, AspNetPager1.CurrentPageIndex, out myCount);
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
            return "<a href='US_free.aspx?softwareType=" + num.ToString() + "&installType=" + st.ToString() + "'>" + result[0] + "(" + result[1] + ")" + "</a>";

           // return result[0] + "("+ result[1]+")";
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
        protected string GetStatus(object objstatus)
        {
            int status = int.Parse(objstatus.ToString());
            if(status==1)
            {
            return "<font color='#006600'>正常</font>";
            }
            else
            {
                return "<font color='#333333'>禁止</font>";
            }
       }
        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                string href = "<a href='US_free_Editor.aspx?ID=" + e.Row.Cells[0].Text + "' target='_blank'>";
                e.Row.Cells[0].Text = href + "(" + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString() + ")</a>";
            }
        }

    }
}
