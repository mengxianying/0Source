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
    public partial class WebLog_Manage  : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //this.txtCreateTime1.Text = DateTime.Now.ToShortDateString();
                //this.txtCreateTime2.Text = DateTime.Now.ToShortDateString();
                this.MyGridView.PageSize = WebInit.webBaseConfig.WebPageNum;
                BindData();
             
            }
        }
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            Pbzx.BLL.PBnet_WebLog webLogBLL = new Pbzx.BLL.PBnet_WebLog();
            if (!string.IsNullOrEmpty(Request["ActionType"]))
            {
                this.ddlActionType.SelectedValue = Request["ActionType"];
            }
            StringBuilder bu = new StringBuilder();
            bu.Append(" 1=1 ");
            bu.Append(this.AddParameter());
            bu.Append(SearchCriteria());
            ///////////////////////////////////////////////////////////////////////////////////
            string Searchstr = bu.ToString();
            string order = "ActionTime desc ";
            int myCount = 0;

            DataTable lsResult = webLogBLL.GuestGetBySearch(Searchstr, "*", order, WebInit.webBaseConfig.WebPageNum, 3, AspNetPager1.CurrentPageIndex, out myCount);

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


        /// <summary>
        /// 分页控件配置
        /// </summary>
        /// <param name="tempCount"></param>
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

        /// <summary>
        /// 页面改变重新绑定数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void MyGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
          //  if (this.MyGridView.Rows.Count <= 1)
          //  {
          //      e.Cancel = true;
          //      JS.Alert("必须保证至少有一条记录");
          //  }
          //  int id = int.Parse(MyGridView.DataKeys[e.RowIndex].Value.ToString());
          ////  string nvarname = MyGridView.Rows[e.RowIndex].Cells[2].Text;
          //  Pbzx.BLL.PBnet_WebLog bllWg = new Pbzx.BLL.PBnet_WebLog();
          //  if (bllWg.Delete(id))
          //  {
          //      //ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("共删除了" + del + "条记录.", "FriendLink_Manage.aspx"));//[" + nvarname + "]
          //      JS.Alert("删除日志成功！");
          //  }
          //  BindData();
        }

        /// <summary>
        /// 处理
        /// </summary>
        /// <returns></returns>
        private string AddParameter()
        {
            StringBuilder bu = new StringBuilder();
            if (!string.IsNullOrEmpty(Request["ActionType"]) && Request["ActionType"] != "所有")
            {
                bu.Append(" and ActionType='" + Request["ActionType"] + "' ");
            }
            if (!string.IsNullOrEmpty(Request["Operator"]))
            {
                bu.Append(" and Operator='" + Request["Operator"] + "' ");
            }
            if (!string.IsNullOrEmpty(Request["UserIP"]))
            {
                bu.Append(" and UserIP='" + Request["UserIP"] + "'");
            }
            return bu.ToString();
        }

        protected void ddlActionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("WebLog_Manage.aspx?ActionType="+this.ddlActionType.SelectedValue);
        }
        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                e.Row.Cells[1].Text = "(" + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString() + ")";
            }
        }
        protected void btnSC_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_WebLog newstBLL = new Pbzx.BLL.PBnet_WebLog();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int del = newstBLL.BatchDel(str);
            if (del > 0)
            {
               //Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("删除", "删除新闻[" + str + "]");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("共删除了" + del + "条记录.", "WebLog_Manage.aspx"));
            }
            BindData();
        }

        protected string GetIpName(object obj)
        {
            Pbzx.BLL.PBnet_ipdata ipBLL = new Pbzx.BLL.PBnet_ipdata();
            return ipBLL.S_getIPaddress(obj.ToString());
        }

        /// <summary>
        /// 搜索条件
        /// </summary>
        /// <returns></returns>
        private string SearchCriteria()
        { 
            StringBuilder str=new StringBuilder();
            if (!string.IsNullOrEmpty(tb_Operator.Text))
            {
                str.Append(" and Operator like '%"+ tb_Operator.Text.Trim() +"%'");
            }
            if (!string.IsNullOrEmpty(tb_IP.Text))
            {
                str.Append(" and UserIP like '%"+ tb_IP.Text.Trim() +"%'");
            }
            if (!string.IsNullOrEmpty(txtCreateTime1.Text) && !string.IsNullOrEmpty(txtCreateTime2.Text))
            {
                str.Append(" and ActionTime between '" + txtCreateTime1.Text + "' and '" + txtCreateTime2.Text + " 23:59:59'  ");
            }
            if (!string.IsNullOrEmpty(tb_jt.Text))
            {
                str.Append(" and Detail like '%"+ tb_jt.Text +"%'");
            }
            return str.ToString();
        }

        //查询
        protected void btn_Query_Click(object sender, EventArgs e)
        {
            BindData();
        }
    }
}
