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
namespace Pbzx.Web.PB_Manage
{
    public partial class Product_Manage : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MyGridView.PageSize = WebInit.webBaseConfig.WebPageNum;
                BindData();
            }
        }

        private void BindData()
        {
            Pbzx.BLL.PBnet_Product productBLL = new Pbzx.BLL.PBnet_Product();
            StringBuilder bu = new StringBuilder();
            bu.Append(" 1=1 and pb_Deleted=0 ");
            bu.Append(this.AddParameter());
            string Searchstr = bu.ToString();
            string order = "countid asc ";
            int myCount = 0;

            DataTable lsResult = productBLL.GuestGetBySearch(Searchstr, "*", order, WebInit.webBaseConfig.WebPageNum, 3, AspNetPager1.CurrentPageIndex, out myCount);

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
        /// 得到软件属性
        /// </summary>
        /// <param name="hits">下载次数</param>
        /// <returns></returns>
        protected string GetFlag(string strHits)
        {
            int hits = int.Parse(strHits);
            string flag = "";
            if (hits < WebInit.webBaseConfig.HitsOfHot / 5)
            {
                flag = "冷";
            }
            else if (hits <= WebInit.webBaseConfig.HitsOfHot)
            {
                flag = "凉";
            }
            else if (hits <= WebInit.webBaseConfig.HitsOfHot * 2)
            {
                flag = "温";
            }
            else
            {
                flag = "热";
            }
            return flag;
        }

        protected void lbtnAduting_Command(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            Pbzx.BLL.PBnet_Product.ChangeAudit(id, "pb_Passed");
            BindData();
        }

        protected void lbtnDel_Command(object sender, CommandEventArgs e)
        {

            Pbzx.BLL.PBnet_Product produtBLL = new Pbzx.BLL.PBnet_Product();
            int id = int.Parse(e.CommandArgument.ToString());
            Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("删除", "删除商品[" + produtBLL.GetModel(id).pb_SoftName + "].");
            ClientScript.RegisterStartupScript(this.GetType(), "ok", JS.Alert("删除成功！."));
            produtBLL.BatchUpdate(id.ToString(), "pb_Deleted", true);
            BindData();
        }

        protected void lbtnPb_OnTop_Command(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            Pbzx.BLL.PBnet_Product.ChangeAudit(id, "pb_OnTop");
            BindData();
        }

        protected void lbtnPb_Elite_Command(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            Pbzx.BLL.PBnet_Product.ChangeAudit(id, "pb_indexshow");
            BindData();
        }

        protected void lbtnSoftshow_Command(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            Pbzx.BLL.PBnet_Product.ChangeAudit(id, "PBnet_Softshow");
            BindData();
        }

        protected void lbtnfreeshow_Command(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            Pbzx.BLL.PBnet_Product.ChangeAudit(id, "pb_Elite");
            BindData();
        }

        /// <summary>
        /// 处理url传值查询
        /// </summary>
        /// <returns></returns>
        private string AddParameter()
        {
            StringBuilder bu = new StringBuilder();

            //软件名称
            if (!string.IsNullOrEmpty(Request["softName"]))
            {
                bu.Append(" and pb_SoftName like '%" + Input.FilterAll(Request["softName"].Trim()) + "%' ");
            }

            //软件类别
            if (!string.IsNullOrEmpty(Request["softClass"]))
            {
                bu.Append(" and pb_ClassID='" + Request["softClass"] + "' ");
            }

            //软件版本类别
            if (!string.IsNullOrEmpty(Request["SoftVersion"]))
            {
                bu.Append(" and pb_TypeName='" + Request["SoftVersion"] + "' ");
            }




            //时间查询
            if (!string.IsNullOrEmpty(Request["dateType"]))
            {
                if (!string.IsNullOrEmpty(Request["strCreateTime1"]) && !string.IsNullOrEmpty(Request["strCreateTime2"]))
                {
                    if (Request["dateType"] == "1")
                    {
                        bu.Append(" and pb_UpdateTime between '" + Request["strCreateTime1"] + "' and '" + Request["strCreateTime2"] + " 23:59:59'  ");
                    }
                    else if (Request["dateType"] == "2")
                    {
                        bu.Append(" and pb_LastHitTime between '" + Request["strCreateTime1"] + "' and '" + Request["strCreateTime2"] + " 23:59:59'  ");
                    }
                }
            }
            if (!string.IsNullOrEmpty(Request["pb_SoftVersion"]))
            {
                bu.Append(" and pb_SoftVersion like '%" + Request["pb_SoftVersion"].Trim() + "%'");
            }
            return bu.ToString();

        }

        protected void MyGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        { }

        protected void btnManySH_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_Product produtBLL = new Pbzx.BLL.PBnet_Product();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int del = produtBLL.BatchUpdate(str, "pb_Passed", true);
            if (del > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("发布", "发布商品[" + str + "]");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("共发布了" + del + "条记录.", "Product_Manage.aspx"));
            }
            BindData();
        }

        protected void btnGD_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_Product produtBLL = new Pbzx.BLL.PBnet_Product();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int del = produtBLL.BatchUpdate(str, "pb_Passed", false);
            if (del > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("取消发布", "取消发布商品[" + str + "]");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("共取消发布了" + del + "条记录.", "Product_Manage.aspx"));
            }
            BindData();
        }

        protected void btnTJ_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_Product produtBLL = new Pbzx.BLL.PBnet_Product();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int del = produtBLL.BatchUpdate(str, "pb_indexshow", true);
            if (del > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("首页显示", "首页显示商品[" + str + "]");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("共设置首页显示了" + del + "条记录.", "Product_Manage.aspx"));
            }
            BindData();
        }



        protected void btnNotIndex_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_Product produtBLL = new Pbzx.BLL.PBnet_Product();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int del = produtBLL.BatchUpdate(str, "pb_indexshow", false);
            if (del > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("取消首页显示", "取消首页显示商品[" + str + "]");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("共取消首页显示了" + del + "条记录.", "Product_Manage.aspx"));
            }
            BindData();
        }

        protected void btnOnTop_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_Product produtBLL = new Pbzx.BLL.PBnet_Product();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int del = produtBLL.BatchUpdate(str, "pb_OnTop", true);
            if (del > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("固定", "固定[" + str + "]");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("共设置固定了" + del + "条记录.", "Product_Manage.aspx"));
            }
            BindData();
        }



        protected void btnNotOnTop_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_Product produtBLL = new Pbzx.BLL.PBnet_Product();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int del = produtBLL.BatchUpdate(str, "pb_OnTop", false);
            if (del > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("取消固定", "取消固定[" + str + "]");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("共取消固定了" + del + "条记录.", "Product_Manage.aspx"));
            }
            BindData();
        }


        protected void btnFree_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_Product produtBLL = new Pbzx.BLL.PBnet_Product();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int del = produtBLL.BatchUpdate(str, "pb_freeshow", true);
            if (del > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("设置免费", "设置免费[" + str + "]");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("共设置免费了" + del + "条记录.", "Product_Manage.aspx"));
            }
            BindData();
        }



        protected void btnNotbtnFree_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_Product produtBLL = new Pbzx.BLL.PBnet_Product();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int del = produtBLL.BatchUpdate(str, "pb_freeshow", false);
            if (del > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("取消免费", "取消免费[" + str + "]");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("共取消免费了" + del + "条记录.", "Product_Manage.aspx"));
            }
            BindData();
        }

        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                string href = "<a href='Product_Editor.aspx?ID=" + e.Row.Cells[1].Text + "'>";
                e.Row.Cells[1].Text = href +"(" + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString() + ")</a>";
            }
        }

        protected void lbtnCreate_Click(object sender, EventArgs e)
        {
            //Server.Execute("/PB_Manage/Refurbish_Soft.aspx");
            WebFunc.RefPagesByPageName("首页");
            WebFunc.RefPagesByPageName("软件内嵌页面");
            WebFunc.RefPagesByPageName("新版软件内嵌页面"); //新版本
        }
    }
}
