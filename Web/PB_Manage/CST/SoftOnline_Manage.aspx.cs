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

namespace Pbzx.Web.PB_Manage
{
    public partial class SoftOnline_Manage : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                MyGridView.PageSize = WebInit.webBaseConfig.WebPageNum;
                Pbzx.BLL.CN_MaxOnline maxBLL = new Pbzx.BLL.CN_MaxOnline();
                if (!string.IsNullOrEmpty(Request["softwareType"]) && !string.IsNullOrEmpty(Request["installType"]))
                {                    
                    Pbzx.Model.CN_MaxOnline model = maxBLL.GetModelByType(Request["softwareType"], Request["installType"]);
                    if(model != null)
                    {
                         this.lblFZ.Text = "峰值:" + model.MaxCount + "人 " + model.RecodeTime;
                    }                    
                }
                else
                {
                    this.lblFZ.Text = "峰值:" + maxBLL.GetCountm() + " 人" + " "+maxBLL.GetName(); 
                }
                if (ViewState["order"] == null)
                {
                    ViewState["order"] = "LoginTime";
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
                    bu.Append(" and InstallType in (select InstallType from  CstSoftware where SoftwareName='" + Request["SoftwareName"] + "' ) ");
                }
            }
            #endregion



            if (!string.IsNullOrEmpty(Request["softwareType"]))
            {
                bu.Append(" and SoftwareType='" + Request["softwareType"]+"' ");
            }

            if (!string.IsNullOrEmpty(Request["installType"]))
            {
                bu.Append(" and InstallType='" + Request["installType"]+"' ");
            }

            if (!string.IsNullOrEmpty(Request["checkHDSN"]))
            {
                bu.Append(" and Status='" + Request["checkHDSN"] + "' ");
            }
            if(!string.IsNullOrEmpty(Request["strHDSN"]))
            {
                if (Request["strHDSN"].Length == 16)
                {
                    if (!string.IsNullOrEmpty(Request["yuan"]) && Request["yuan"] == "yes")
                    {
                        bu.Append(" and left(HDSN,4)='" + Request["strHDSN"].Substring(0, 4) + "' and substring(HDSN,9,5)='" + Request["strHDSN"].Substring(8, 5) + "' ");
                    }
                    else
                    {
                        bu.Append(" and HDSN='" + Request["strHDSN"] + "'");
                    }
                }
                else
                {
                    bu.Append(" and HDSN='" + Request["strHDSN"] + "'");
                }
            }

            if (!string.IsNullOrEmpty(Request["strRN"]))
            {
                bu.Append(" and RN='" + Request["strRN"]+"' ");
            }
            if (!string.IsNullOrEmpty(Request["regType"]))
            {
                bu.Append(" and substring(hdsn,5,1)='" + Request["regType"] + "'");
            }
            if (!string.IsNullOrEmpty(Request["strVersion"]))
            {
                bu.Append(" and Version='" + Request["strVersion"]+"' ");
            }


            if (!string.IsNullOrEmpty(Request["oSVersion"]))
            {
                bu.Append(" and OSVersion='" + Request["oSVersion"] + "' ");
            }
            if (!string.IsNullOrEmpty(Request["strIP"]))
            {
                bu.Append(" and IP='" + Request["strIP"] + "' ");
            }
            if (!string.IsNullOrEmpty(Request["dateType"]))
            {
                if (!string.IsNullOrEmpty(Request["strCreateTime1"]) && !string.IsNullOrEmpty(Request["strCreateTime2"]))
                {                   
                    if (Request["dateType"]=="1")
                    {
                        bu.Append(" and LoginTime between '" + Request["strCreateTime1"] + "' and '" + DateTime.Parse(Request["strCreateTime2"]).AddDays(1).ToShortDateString() + "'  ");
                    }
                    else if (Request["dateType"] == "2")
                    {
                        bu.Append(" and FirstLoginTime between '" + Request["strCreateTime1"] + "' and '" + DateTime.Parse(Request["strCreateTime2"]).AddDays(1).ToShortDateString() + "'  ");
                    }
                }                
            }
            return bu.ToString();

        }


        private void BindData(string column, bool isDesc)
        {
            Pbzx.BLL.CstLogin cstLoginBLL = new Pbzx.BLL.CstLogin();
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

            DataTable lsResult = cstLoginBLL.GuestGetBySearch(Searchstr, "*", order, WebInit.webBaseConfig.WebPageNum, 3, AspNetPager1.CurrentPageIndex, out myCount);
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

        protected string ChkHDSN(object tHDSN,object tRN,object tStatus)
        {
            string strStatus = tStatus.ToString();
            string dis = "";
            string strRN = tRN.ToString();
            string strHDSN = tHDSN.ToString();
            switch(strStatus)
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
        protected string ChkSoftType(object num,object st)
        {
            //Pbzx.BLL.CstSoftware softBLL = new Pbzx.BLL.CstSoftware();
            //string[] result = softBLL.Chksettype(num, st);
            //return "<a href='SoftOnline_Manage.aspx?softwareType=" + num.ToString() + "&installType=" + st.ToString() + "'>" + result[0] + "(" + result[1] + ")" + "</a>";

            Pbzx.BLL.CstSoftware softBLL = new Pbzx.BLL.CstSoftware();
            string[] result = softBLL.Chksettype(num, st);
            string[] results = softBLL.Chksettypeid(num, st);
            return "<a href='SoftOnline_Manage.aspx?SoftwareName=" + results[0] + "&InstallName=" + st.ToString() + "'>" + result[0] + "(" + result[1] + ")" + "</a>";
        }

        protected string GetIp(object ip)
        {
            Pbzx.BLL.PBnet_ipdata ipBLL = new Pbzx.BLL.PBnet_ipdata();
            return "<a href='?strIP="+ip.ToString()+"'>" + ipBLL.S_getIPaddress(ip.ToString()) + "</a>";
        }

        protected void MyGridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.Header) //如果是表頭
            //{
            //    foreach (TableCell MyHeader in e.Row.Cells) //對每一格      
            //    {
            //        if (MyHeader.HasControls())
            //        {
            //          //  if (((LinkButton)MyHeader.Controls[0]).CommandArgument == this.MyGridView.SortExpression)
            //                //否為為排序欄位

            //             //   if (MyGridView.SortDirection == SortDirection.Ascending) //依排序方向加入箭號
                               
            //            //if (lblSort.Text == "desc")
            //            //{
            //            //   MyHeader.Controls.Add(new LiteralControl("↑"));
            //            //}
            //            //else
            //            //{
            //            //    MyHeader.Controls.Add(new LiteralControl("↓"));
            //            //}                                                       
                                
            //        }
            //    }
            //}

        }

        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {            
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                string href = "<a href='SoftOnline_Editor.aspx?ID=" + e.Row.Cells[0].Text + "' target='_blank'>";                
                e.Row.Cells[0].Text = href +"("+(((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString()+")</a>";
            }
        }




    }
}
