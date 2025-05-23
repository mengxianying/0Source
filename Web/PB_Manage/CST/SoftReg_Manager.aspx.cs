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
using Pbzx.Common;
using System.Text;

namespace Pbzx.Web.PB_Manage.CST
{
    public partial class SoftReg_Manager : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MyGridView.PageSize = WebInit.webBaseConfig.WebPageNum;
                if (ViewState["order"] == null)
                {
                    ViewState["order"] = "RegisterDate";
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
            Pbzx.BLL.CstSoftware sfBll = new Pbzx.BLL.CstSoftware();

            #region
            if (!string.IsNullOrEmpty(Request["SoftwareName"]))
            {
                string SoftwareType = sfBll.GetIdByName("SoftwareName", Request["SoftwareName"], "SoftwareType");
                bu.Append(" and SoftwareType='" + SoftwareType + "' ");
            }
            if (!string.IsNullOrEmpty(Request["InstallName"]))
            {
                //string installType = sfBll.GetIdByName("InstallName", Request["InstallName"], "InstallType");
                bu.Append(" and InstallType='" + Request["InstallName"] + "' ");
            }
            else
            {
                if (!string.IsNullOrEmpty(Request["SoftwareName"]))
                {
                    string sname = Request["SoftwareName"];
                    if (sname == "数字6 1")
                    {
                        sname = "数字6+1";
                    }
                    bu.Append(" and InstallType in (select InstallType from  CstSoftware where SoftwareName='" + sname + "' ) ");
                }
            }
            #endregion

            if (!string.IsNullOrEmpty(Request["RegisterMode"]))
            {
                bu.Append(" and RegisterMode='" + Request["RegisterMode"] + "' ");
            }
            if (!string.IsNullOrEmpty(Request["softwareType"]))
            {
                bu.Append(" and SoftwareType='" + Request["softwareType"] + "' ");
            }
            if (!string.IsNullOrEmpty(Request["installType"]))
            {
                bu.Append(" and InstallType='" + Request["installType"] + "' ");
            }

            if (!string.IsNullOrEmpty(Request["strHDSN"]))
            {
                if (Request["strHDSN"].Length == 16)
                {
                    if (!string.IsNullOrEmpty(Request["yuan"]) && Request["yuan"] == "yes")
                    {
                        bu.Append(" and left(HDSN,4)='" + Request["strHDSN"].Substring(0, 4) + "' and substring(HDSN,9,5)='" + Request["strHDSN"].Substring(8, 5) + "' ");
                    }
                    else
                    {
                        bu.Append(" and HDSN='" + Request["strHDSN"].Trim() + "'");
                    }
                }
                else
                {
                    bu.Append(" and HDSN='" + Request["strHDSN"].Trim() + "'");
                }
            }

            if (!string.IsNullOrEmpty(Request["strPayDetails"]))
            {
                bu.Append(" and PayDetails like '%" + Request["strPayDetails"].Trim() + "%' ");
            }
            if (!string.IsNullOrEmpty(Request["strRemarks"]))
            {
                bu.Append(" and Remarks like '%" + Request["strRemarks"].Trim() + "%' ");
            }
            if (!string.IsNullOrEmpty(Request["strUserAddress"]))
            {
                bu.Append(" and UserAddress like '%" + Request["strUserAddress"].Trim() + "%' ");
            }

            if (!string.IsNullOrEmpty(Request["strRN"]))
            {
                bu.Append(" and RN='" + Request["strRN"].Trim() + "' ");
            }

            if (!string.IsNullOrEmpty(Request["strOldSN"]))
            {
                bu.Append(" and OldSN='" + Request["strOldSN"].Trim() + "'");
            }
            if (!string.IsNullOrEmpty(Request["strOrgSN"]))
            {
                bu.Append(" and OrgSN like'%" + Request["strOrgSN"].Trim() + "%' ");
            }


            if (!string.IsNullOrEmpty(Request["strUserName"]))
            {
                bu.Append(" and Username like '%" + Request["strUserName"].Trim() + "%' ");
            }

            if (!string.IsNullOrEmpty(Request["strBBsID"]))
            {
                bu.Append(" and BBsID='" + Request["strBBsID"].Trim() + "' ");
            }

            if (!string.IsNullOrEmpty(Request["timeType"]))
            {
                bu.Append(" and TimeType='" + Request["timeType"].Trim() + "' ");
            }

            if (!string.IsNullOrEmpty(Request["registerType"]))
            {
                switch (Request["registerType"])
                {
                    case "公司注册":
                        bu.Append("  and (AgentName is null or AgentName='' or agentname='公司注册' )  ");
                        break;
                    case "代理注册":
                        bu.Append(" and AgentName is not null and  AgentName<>'' and AgentName<>'公司注册' ");
                        break;
                    case "充值卡注册":
                        bu.Append(" and CardNo is not null and  CardNo<>'' ");
                        break;
                    default:
                        bu.Append(" and AgentName='" + Request["registerType"].Trim() + "' ");
                        break;
                }
            }

            if (!string.IsNullOrEmpty(Request["useType"]))
            {
                bu.Append(" and UseType like '%" + Request["useType"].Trim() + "%' ");
            }

            if (!string.IsNullOrEmpty(Request["PayType"]))
            {
                bu.Append(" and PayType like '%" + Request["PayType"].Trim() + "%' ");
            }

            if (!string.IsNullOrEmpty(Request["regType"]))
            {
                bu.Append(" and substring(hdsn,5,1)='" + Request["regType"].Trim() + "'");
            }



            if (!string.IsNullOrEmpty(Request["tStatus"]))
            {
                bu.Append(" and Status='" + Request["tStatus"].Trim() + "' ");
            }
            if (!string.IsNullOrEmpty(Request["dateType"]))
            {
                if (!string.IsNullOrEmpty(Request["strCreateTime1"]) && !string.IsNullOrEmpty(Request["strCreateTime2"]))
                {
                    if (Request["dateType"] == "1")
                    {
                        bu.Append(" and RegisterDate between '" + Request["strCreateTime1"].Trim() + "' and '" + DateTime.Parse(Request["strCreateTime2"]).AddDays(1).ToShortDateString() + "'  ");
                    }
                    else if (Request["dateType"] == "2")
                    {
                        bu.Append(" and ExpireDate between '" + Request["strCreateTime1"].Trim() + "' and '" + DateTime.Parse(Request["strCreateTime2"]).AddDays(1).ToShortDateString() + "'  ");
                    }
                }
            }
            return bu.ToString();

        }


        private void BindData(string column, bool isDesc)
        {
            Pbzx.BLL.RegisterInfo2 regInfoBLL = new Pbzx.BLL.RegisterInfo2();
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

            DataTable lsResult = regInfoBLL.GuestGetBySearch(Searchstr, "*", order, WebInit.webBaseConfig.WebPageNum, 3, AspNetPager1.CurrentPageIndex, out myCount);

            this.MyGridView.DataSource = lsResult;
            this.MyGridView.DataBind();
            AspNetPagerConfig(myCount);
            if (lsResult == null)
            {
                this.litContent.Text = "<b>抱歉！<p/><br/>应该没有找到您搜索的数据记录</b>";
            }
            else
            {
                string strTotalTemp = regInfoBLL.GetTotalMoney(bu.ToString());
                this.lblTotal.Text = "总金额：" + Math.Round(Convert.ToDecimal(strTotalTemp.Split(new char[] { '&' })[1]), 2) + "元&nbsp;";
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



        protected string ChkSoftType(object num, object st)
        {
            Pbzx.BLL.CstSoftware softBLL = new Pbzx.BLL.CstSoftware();
            string[] result = softBLL.Chksettype(num, st);
            return "<a href='SoftReg_Manager.aspx?softwareType=" + num.ToString() + "&installType=" + st.ToString() + "'>" + result[0] + "(" + result[1] + ")" + "</a>";
        }

        protected string ChkHDSN(object tHDSN, object tRN, object tStatus)
        {
            string strStatus = tStatus.ToString();
            string dis = "";
            string strRN = tRN.ToString();
            string strHDSN = tHDSN.ToString();
            switch (strStatus)
            {
                case null:
                    dis = "<a href='SoftReg_Manager.aspx?strRN=" + strRN + "&act_searchmod=0' target='_blank'>" + strHDSN + "</a>";
                    break;
                case "":
                    dis = "<a href='SoftReg_Manager.aspx?strRN=" + strRN + "&act_searchmod=0' target='_blank'>" + strHDSN + "</a>";
                    break;
                case "1":
                    dis = "<a href='SoftReg_Manager.aspx?strRN=" + strRN + "&act_searchmod=0' target='_blank'>" + strHDSN + "</a>";
                    break;
                case "2":
                    dis = "<a href='SoftReg_Manager.aspx?strRN=" + strRN + "&act_searchmod=0' target='_blank' style='color:#ff0000;' >" + strHDSN + "</a>";
                    break;
                case "3":
                    dis = "<a href='SoftReg_Manager.aspx?strRN=" + strRN + "&act_searchmod=0' target='_blank' style='color:#009900;'>" + strHDSN + "</a>";
                    break;
                case "4":
                    dis = "<a href='SoftReg_Manager.aspx?strRN=" + strRN + "&act_searchmod=0' target='_blank' style='color:#999999;'>" + strHDSN + "</a>";
                    break;
                default:
                    dis = "<a href='SoftReg_Manager.aspx?strRN=" + strRN + "&act_searchmod=0' target='_blank'>" + strHDSN + "</a>";
                    break;
            }
            return dis;
        }

        protected string BindHdsn_A(object objOld, object objIsReg)
        {

            string tempObj = objOld.ToString();
            string tempReg = objIsReg.ToString();
            string result = "";
            if (string.IsNullOrEmpty(tempObj))
            {
                result = "color:#0033FF;";
            }
            else if (tempReg == "1")
            {
                result = "color:#FF0000;";
            }
            return result;
        }

        protected string BindGetUseType(object obj)
        {
            return Pbzx.Common.Method.GetUseType(obj);
        }
        protected string BindGetTimeType(object obj)
        {
            return Pbzx.Common.Method.GetTimeType(obj);
        }

        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                string href = "<a href='SoftReg_Editor.aspx?ID=" + e.Row.Cells[0].Text + "'  target='_blank' >";
                e.Row.Cells[0].Text = href + "(" + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString() + ")</a>";
            }
        }

    }
}
