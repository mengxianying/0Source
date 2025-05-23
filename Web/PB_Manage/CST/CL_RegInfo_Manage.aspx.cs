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
    public partial class CL_RegInfo_Manage : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MyGridView.PageSize = WebInit.webBaseConfig.WebPageNum;
                if (ViewState["order"] == null)
                {
                    ViewState["order"] = "CreateTime";
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


            if (!string.IsNullOrEmpty(Request["softwareType"]))
            {
                bu.Append(" and InstallType='" + Request["softwareType"] + "' ");
            }

            //根据用户名和客户名参数拼接条件
            if (!string.IsNullOrEmpty(Request["strUsername"]))
            {
                bu.Append(" and UserName like '%" + Request["strUsername"] + "%' ");
            }

            //付费状态
            if (!string.IsNullOrEmpty(Request["payStatus"]))
            {
                bu.Append(" and payStatus='" + Request["payStatus"].Trim() + "' ");
            }
            //付费方式
            if (!string.IsNullOrEmpty(Request["PayType"]))
            {
                bu.Append(" and PayType like '%" + Request["PayType"].Trim() + "%' ");
            }
            //注册类型
            if (!string.IsNullOrEmpty(Request["registerType"]))
            {
                if (Request["registerType"] == "公司注册")
                {
                    bu.Append(" and RegisterType = 1 ");
                }

                else if (Request["registerType"] == "充值卡注册")
                {
                    bu.Append(" and RegisterType = 3 ");
                }
                else
                {
                    bu.Append(" and AgentName  like '%" + Request["registerType"].Trim() + "%'");
                }

            }




            if (!string.IsNullOrEmpty(Request["dateType"]))
            {
                if (!string.IsNullOrEmpty(Request["strCreateTime1"]) && !string.IsNullOrEmpty(Request["strCreateTime2"]))
                {
                    if (Request["dateType"] == "1")
                    {
                        bu.Append(" and PayTime between '" + Request["strCreateTime1"] + "' and '" + DateTime.Parse(Request["strCreateTime2"]).AddDays(1).ToShortDateString() + "'  ");
                    }
                    else if (Request["dateType"] == "2")
                    {
                        bu.Append(" and CreateTime between '" + Request["strCreateTime1"] + "' and '" + DateTime.Parse(Request["strCreateTime2"]).AddDays(1).ToShortDateString() + "'  ");
                    }
                }
            }


            //本页面列搜索
            if (!string.IsNullOrEmpty(Request["bbsName"]))
            {
                bu.Append(" and BbsName like '%" + Request["bbsName"] + "%' ");
            }
            return bu.ToString();

        }


        private void BindData(string column, bool isDesc)
        {
            Pbzx.BLL.CL_RegisterInfo regInfoBLL = new Pbzx.BLL.CL_RegisterInfo();
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
                this.lblTotal.Text = "";
                this.litContent.Text = "<b>抱歉！<p/><br/>应该没有找到您搜索的数据记录</b>";
            }
            else
            {
                string strTotalTemp = regInfoBLL.GetTotalMoney(bu.ToString());
                this.lblTotal.Text = "总计金额：" + strTotalTemp.Split(new char[] { '&' })[1] + "元&nbsp;总计:" + strTotalTemp.Split(new char[] { '&' })[0] + "条记录";
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

          //  return "<a href='CL_RegInfo_Manage.aspx?softwareType=" + num.ToString() + "&installType=" + st.ToString() + "'>" + result[0] + "(" + result[1] + ")" + "</a>";

            return "<a href='CL_RegInfo_Manage.aspx?softwareType=" + st.ToString() + "'>" + result[0]+"("+result[1]+")" + "</a>";
        }


        protected string GetPayStatus(object objPayStatus)
        {
            string strPayStatus = objPayStatus.ToString();
            string result = "";
            string strA1 = "<a href='CL_RegInfo_Manage.aspx?payStatus=" + strPayStatus + "'>";
            switch (strPayStatus)
            {
                case "1":
                    result = "<font color='#ff0000'>未付费</font>";
                    break;
                case "2":
                    result = "已付费";
                    break;
                case "3":
                    result = "<font color='#339900'>免费</font>";
                    break;
                default:
                    result = "其它";
                    break;
            }
            return strA1 + result + "</a>";
        }

        protected string GetRegisterType(object objRegisterType, object objAgentName, object objCardInfo)
        {
            string strRegisterType = objRegisterType.ToString();
            string result = "";
            //  string strA1 = "<a href='SoftRegisterLog_Manager.aspx?registerType=" + strRegisterType + "'>";
            switch (strRegisterType)
            {
                case "1":
                    result = "公司注册";
                    break;
                case "2":
                    result = objAgentName.ToString();
                    break;
                case "3":
                    result = objCardInfo.ToString();
                    break;
                default:
                    result = "其它";
                    break;
            }
            return result;
        }

        protected string FormartSn(object objSNs)
        {
            Pbzx.BLL.CL_PrintLine printLineBLL = new Pbzx.BLL.CL_PrintLine();
            string strSNs = objSNs.ToString();
            string[] snSZ = strSNs.Split(new char[]{'|'});
            StringBuilder sb = new StringBuilder();
           
            foreach(string strTemp in snSZ)
            {
                Pbzx.Model.CL_PrintLine model = printLineBLL.GetModelBySN(strTemp);
                if(model != null)
                { 
                    string result = "";
                    switch(model.Type)
                    {
                        case 0:
                            result = "<a href='CL_PrintLine_Hao.aspx?ID=" + model.ID + "' style=\"color:#999999;\" target=\"_self\">" + model.SN + " </a>";
                            break;
                        case 1:
                            result = "<a href='CL_PrintLine_Hao.aspx?ID=" + model.ID + "'style=\"color:#0000ff;\" target=\"_self\">" + model.SN + " </a>";
                            break;
                        case 2:
                            result = "<a href='CL_PrintLine_Hao.aspx?ID=" + model.ID + "'  target=\"_self\">" + model.SN + " </a>";
                            break;
                        default:
                            result = "<a href='CL_PrintLine_Hao.aspx?ID=" + model.ID + "' target=\"_self\">" + model.SN + " </a>";
                            break;
                    }
                    sb.Append(result);
                }                
            }
            return sb.ToString();			
        }

        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                string href = "<a href='CL_RegInfo_Editor.aspx?ID=" + e.Row.Cells[0].Text + "' target='_blank'>";
                e.Row.Cells[0].Text = href + "(" + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString() + ")</a>";
            }
        }
    }
}
