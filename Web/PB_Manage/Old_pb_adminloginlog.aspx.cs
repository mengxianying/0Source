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
using Maticsoft.DBUtility;

namespace Pbzx.Web.PB_Manage
{
    public partial class Old_pb_adminloginlog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MyGridView.PageSize = WebInit.webBaseConfig.WebPageNum;
                //if (Request["CID"] != null)
                //{
                //    labAction.Text = new Pbzx.BLL.pb_adminloginlogType().GetModel(Convert.ToInt32(Request["CID"])).VarTypeName;
                //}
                this.MyGridView.PageSize = WebInit.webBaseConfig.WebPageNum;
                BindData();
            }
        }

        private void BindData()
        {
            Pbzx.BLL.PBnet_UserLog newsBLL = new Pbzx.BLL.PBnet_UserLog();
            StringBuilder bu = new StringBuilder();
            bu.Append(" 1=1 ");
            bu.Append(this.AddParameter());
            //  bu.Append(" and IntSetting=0 ");
            ///////////////////////////////////////////////////////////////////////////////////
            string Searchstr = bu.ToString();
            string order = "log_time desc ";
            int myCount = 0;

            DataTable lsResult = newsBLL.GuestGetBySearch(Searchstr, "*", order, WebInit.webBaseConfig.WebPageNum, 3, AspNetPager1.CurrentPageIndex, out myCount);

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
            BindData();
        }


        /// <summary>
        /// 处理url传值查询
        /// </summary>
        /// <returns></returns>
        private string AddParameter()
        {
            StringBuilder bu1 = new StringBuilder();


            if (!string.IsNullOrEmpty(Request["log_username"]))
            {
                bu1.Append(" and log_username like '%" + Request["log_username"].Trim() + "%' ");
            }
            if (!string.IsNullOrEmpty(Request["log_Ip"]))
            {
                if (Request["log_Ip"].Trim().Contains("."))
                {
                    if (Request["log_Ip"].Trim().Substring(Request["log_Ip"].Trim().Length - 1) != ".")
                    {
                        bu1.Append(" and log_Ip='" + Request["log_Ip"].Trim() + "' ");
                    }
                    else
                    {
                        bu1.Append(" and log_Ip like '" + Request["log_Ip"].Trim() + "%' ");
                    }
                }
                else
                {
                    bu1.Append(" and (log_country like '%" + Request["log_Ip"].Trim() + "%' or log_city like '%" + Request["log_Ip"].Trim() + "%')");
                }

            }
            if (!string.IsNullOrEmpty(Request["log_state"]))
            {
                bu1.Append(" and log_state like '%" + Request["log_state"] + "%' ");
            }

            if (!string.IsNullOrEmpty(Request["log_stepinto"]))
            {
                bu1.Append(" and log_stepinto='" + Request["log_stepinto"] + "' ");
            }

            if (!string.IsNullOrEmpty(Request["log_password"]))
            {
                bu1.Append(" and log_password='" + Request["log_password"] + "' ");
            }

            if (!string.IsNullOrEmpty(Request["log_urlname"]))
            {
                bu1.Append(" and log_urlname='" + Request["log_urlname"] + "' ");
            }


            if (!string.IsNullOrEmpty(Request["dateType"]))
            {
                if (!string.IsNullOrEmpty(Request["strCreateTime1"]) && !string.IsNullOrEmpty(Request["strCreateTime2"]))
                {
                    if (Request["dateType"] == "0")
                    {
                        bu1.Append(" and log_time between '" + Request["strCreateTime1"] + "' and '" + Request["strCreateTime2"] + " 23:59:59'  ");
                    }

                }
            }
            return bu1.ToString();
        }




        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                string href = "<a href='Old_pb_adminLogEditor.aspx?ID=" + e.Row.Cells[0].Text + "'  target='_blank' >";
                e.Row.Cells[0].Text = href + "(" + Convert.ToString(((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id) + ")</a>";
            }
        }

        /// <summary>
        /// 格式化
        /// </summary>
        /// <param name="temp_pass"></param>
        /// <param name="log_stepinto"></param>
        /// <returns></returns>
        protected string FormartTemp_pass(object temp_pass, object log_stepinto)
        {
            string result = temp_pass.ToString();
            result = result.Replace("<", "<<");
            result = result.Replace(">", ">>");
            if (log_stepinto.ToString() == "Admin_login" || log_stepinto.ToString() == "BBS_Admin")
            {
                result = "";
            }
            return result;
        }

        protected void lbtnDel_Command(object sender, CommandEventArgs e)
        {
            int result = DbHelperSQLBBS.ExecuteSql(" update Dv_User set LockUser=1 where username='" + e.CommandArgument.ToString() + "' and LockUser=0 ");
            if (result > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "ok", JS.Alert("锁定成功！"));
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "ok", JS.Alert("该用户名不存在或者已经被锁定！"));
            }

        }

        protected void lbtnJie_Command(object sender, CommandEventArgs e)
        {
            int result = DbHelperSQLBBS.ExecuteSql(" update Dv_User set LockUser=0 where username='" + e.CommandArgument.ToString() + "' and LockUser=1 ");
            if (result > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "ok", JS.Alert("解锁成功！"));
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "ok", JS.Alert("该用户名不存在或者没有被锁定！"));
            }
        }

    }
}
