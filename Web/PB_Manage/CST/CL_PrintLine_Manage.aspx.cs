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
    public partial class CL_PrintLine_Manage : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MyGridView.PageSize = WebInit.webBaseConfig.WebPageNum;
                if (ViewState["order"] == null)
                {
                    ViewState["order"] = "SellTime";
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
            AspNetPager1.PageSize = WebInit.webBaseConfig.WebPageNum;
            AspNetPager1.RecordCount = tempCount;
            AddCustomText();
        }

        protected void AddCustomText()
        {
            AspNetPager1.CustomInfoHTML = "总<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>条&nbsp;";
            AspNetPager1.CustomInfoHTML += "本页<font color=\"red\"><b>" + MyGridView.Rows.Count + "</b></font>条&nbsp;";
            AspNetPager1.CustomInfoHTML += "分页:<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "页</font>";
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);  
        }

        /// <summary>
        /// 处理url传值查询
        /// </summary>
        /// <returns></returns>
        private string AddParameter()
        {
            StringBuilder bu = new StringBuilder();
            //序列号
            if (!string.IsNullOrEmpty(Request["strSN"]))
            {
                bu.Append(" and SN= '" + Request["strSN"].Trim() + "' ");
            }

            //付费方式
            if (!string.IsNullOrEmpty(Request["useType"]))
            {
                if (!string.IsNullOrEmpty(Request["strUsername"]))
                {
                    string userName = Request["strUsername"].Trim();
                    switch (Request["useType"])
                    {
                        case "1":
                            bu.Append(" and Creator='" + userName + "' ");
                            break;
                        case "2":
                            bu.Append(" and Accepter = '" + userName + "' ");
                            break;
                        case "3":
                            bu.Append(" and Seller = '" + userName + "' ");
                            break;
                    }
                }
            }

            //状态
            if (!string.IsNullOrEmpty(Request["payStatus"]))
            {
                bu.Append(" and Status='" + Request["payStatus"] + "' ");
            }

            if (!string.IsNullOrEmpty(Request["dateType"]))
            {
                if (!string.IsNullOrEmpty(Request["strCreateTime1"]) && !string.IsNullOrEmpty(Request["strCreateTime2"]))
                {
                    if (Request["dateType"] == "1")
                    {
                        bu.Append(" and CreateTime between '" + Request["strCreateTime1"] + "' and '" + Request["strCreateTime2"] + " 23:59:59'  ");
                    }
                    else if (Request["dateType"] == "2")
                    {
                        bu.Append(" and SellTime between '" + Request["strCreateTime1"] + "' and '" + Request["strCreateTime2"] + " 23:59:59'  ");
                    }
                    else if (Request["dateType"] == "3")
                    {
                        bu.Append(" and AcceptTime between '" + Request["strCreateTime1"] + "' and '" + Request["strCreateTime2"] + " 23:59:59'  ");
                    }

                    
                }
            }

            //类型
            if (!string.IsNullOrEmpty(Request["type"]))
            {
                bu.Append(" and [type]='" + Request["type"] + "' ");
            }

            return bu.ToString();

        }


        private void BindData(string column, bool isDesc)
        {
            Pbzx.BLL.CL_PrintLine printLineBLL = new Pbzx.BLL.CL_PrintLine();
            StringBuilder bu = new StringBuilder();
            bu.Append(" 1=1 ");
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

            DataTable lsResult = printLineBLL.GuestGetBySearch(Searchstr, "*", order, WebInit.webBaseConfig.WebPageNum, 3, AspNetPager1.CurrentPageIndex, out myCount);
            this.MyGridView.DataSource = lsResult;
            this.MyGridView.DataBind();
            AspNetPagerConfig(myCount);
            if (lsResult == null)
            {
             //   this.lblTotal.Text = "";
                this.litContent.Text = "<b>抱歉！<p/><br/>应该没有找到您搜索的数据记录</b>";
            }
            else
            {
                this.litContent.Text = "";
            }

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

        protected string GetStatus(object objStatus)
        {
            string strStatus = objStatus.ToString();
            string result = "";
            string strA1 = "<a href='CL_PrintLine_Manage.aspx?payStatus=" + strStatus + "'>";
            switch (strStatus)
            {
                case "0":
                    result = "<font color='#cccccc'>新创建</font>";
                    break;
                case "1":
                    result = "<font color='#009900'>已入库</font>";
                    break;
                case "2":
                    result = "<font color='#0066cc'>已销售</font>";
                    break;
                case "3":
                    result = "<font color='#ff0000'>已丢失</font>";
                    break;
                case "4":
                    result = "<font color='#339900'>已损坏</font>";
                    break;
                default:
                    result = "其它";
                    break;
            }
            return strA1 + result + "</a>";
        }

        protected string GetType(object objType)
        {
            string strType= objType.ToString();
            string result = "";
            string strA1 = "<a href='CL_PrintLine_Manage.aspx?type=" + strType + "'>";
            switch (strType)
            {
                case "0":
                    result = "<font color='#999999'>未定</font>";
                    break;
                case "1":
                    result = "<font color='#0000ff'>USB</font>";
                    break;
                case "2":
                    result = "COM";
                    break;
                default:
                    result = "其它";
                    break;
            }
            return strA1 + result + "</a>";
        }

        //protected string FormartSn(object objSNs)
        //{
        //    Pbzx.BLL.CL_PrintLine printLineBLL = new Pbzx.BLL.CL_PrintLine();
        //    string strSNs = objSNs.ToString();
        //    string[] snSZ = strSNs.Split(new char[] { '|' });
        //    StringBuilder sb = new StringBuilder();

        //    foreach (string strTemp in snSZ)
        //    {
        //        Pbzx.Model.CL_PrintLine model = printLineBLL.GetModelBySN(strTemp);
        //        if (model != null)
        //        {
        //            string result = "";
        //            switch (model.Type)
        //            {
        //                case 0:
        //                    result = "<a href='CL_PrintLine.aspx?action=ShowInfo&snsID=" + model.SN + "' style=\"color:#999999;\" target=\"_blank\">" + model.SN + " </a>";
        //                    break;
        //                case 1:
        //                    result = "<a href='CL_PrintLine.aspx?action=ShowInfo&snsID=" + model.SN + "' style=\"color:#0000ff;\" target=\"_blank\">" + model.SN + " </a>";
        //                    break;
        //                case 2:
        //                    result = "<a href='CL_PrintLine.aspx?action=ShowInfo&snsID=" + model.SN + "'  target=\"_blank\">" + model.SN + " </a>";
        //                    break;
        //                default:
        //                    result = "<a href='CL_PrintLine.aspx?action=ShowInfo&snsID=" + model.SN + "' target=\"_blank\">" + model.SN + " </a>";
        //                    break;
        //            }
        //            sb.Append(result);
        //        }
        //    }
        //    return sb.ToString();
        //}
        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                string href = "<a href='CL_PrintLine_Editor.aspx?ID=" + e.Row.Cells[0].Text + "' target='_blank'>";
                e.Row.Cells[0].Text = href + "(" + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString() + ")</a>";
            }
        }
    }
}
