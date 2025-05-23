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
    public partial class SoftMessage_Manage : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Load是数据初始化
                MyGridView.PageSize = WebInit.webBaseConfig.WebPageNum;
                if (ViewState["order"] == null)
                {
                    ViewState["order"] = "MsgTime";
                }
                if (ViewState["isDesc"] == null)
                {
                    ViewState["isDesc"] = true;
                }
                //绑定数据
                BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
            }
        }

        /// <summary>
        /// 给分页控件 每页显示条数和总条数
        /// </summary>
        /// <param name="tempCount"></param>
        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = WebInit.webBaseConfig.WebPageNum;
            AspNetPager1.RecordCount = tempCount;
            //调用下面的方法
            AddCustomText();
        }
        /// <summary>
        /// 此方法主要用来显示
        /// </summary>
        protected void AddCustomText()
        {
            AspNetPager1.CustomInfoHTML = "总<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>条&nbsp;";
            AspNetPager1.CustomInfoHTML += "本页<font color=\"red\"><b>" + MyGridView.Rows.Count + "</b></font>条&nbsp;";
            AspNetPager1.CustomInfoHTML += "分页:<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "页</font>";
        }
        /// <summary>
        /// 当分页控件 changed是
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


            if (!string.IsNullOrEmpty(Request["strTitleSerch"]))
            {
                bu.Append(" and MsgTitle like '%" + Request["strTitleSerch"] + "%' ");
            }

            if (!string.IsNullOrEmpty(Request["dateType"]))
            {
                if (!string.IsNullOrEmpty(Request["strCreateTime1"]) && !string.IsNullOrEmpty(Request["strCreateTime2"]))
                {
                    if (Request["dateType"] == "1")
                    {
                        bu.Append(" and MsgTime between '" + Request["strCreateTime1"] + "' and '" + Request["strCreateTime2"] + " 23:59:59'  ");
                    }
                    else if (Request["dateType"] == "2")
                    {
                        bu.Append(" and PostTime1 between '" + Request["strCreateTime1"] + "' and '" + Request["strCreateTime2"] + " 23:59:59'  ");
                    }
                    else if (Request["dateType"] == "3")
                    {
                        bu.Append(" and PostTime2 between '" + Request["strCreateTime1"] + "' and '" + Request["strCreateTime2"] + " 23:59:59'  ");
                    }
                }
            }
            return bu.ToString();

        }

        /// <summary>
        /// 当出现事件激发时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnDel_Command(object sender, CommandEventArgs e)
        {
            //先得到要删除的ID
            int id = int.Parse(e.CommandArgument.ToString());

            Pbzx.BLL.CstMessage msgBLL = new Pbzx.BLL.CstMessage();
            //根据ID找出此实体对象
            Pbzx.Model.CstMessage msgModel = msgBLL.GetModel(id);
            //获得他的标题
            string nvarname = msgModel.MsgTitle.ToString();
            //执行删除
            if (msgBLL.Delete(id))
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("删除", "删除软件消息[" + nvarname + "]");

                JS.Alert("删除成功！");
            }
            else
            {
                JS.Alert("删除失败！");
            }
            //重新绑定当前数据
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }


        protected string ChkSoftType(object st, object it)
        {
            Pbzx.BLL.CstSoftware softBLL = new Pbzx.BLL.CstSoftware();
            string[] result = softBLL.Chksettype(st, it);
            return result[0] + "(" + result[1] + ")";
        }
        /// <summary>
        /// 在数据出现排序时，在排序前激发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MyGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            ViewState["order"] = e.SortExpression.ToString(); //得到要排序的字段

            if ((bool)ViewState["isDesc"])
            {
                ViewState["isDesc"] = false;
            }
            else
            {
                ViewState["isDesc"] = true;
            }
            //重新绑定数据
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        /// <param name="column">排序对应那列</param>
        /// <param name="isDesc">是否按降序还是升序排序，ture 为 desc false 为 asc</param>
        private void BindData(string column, bool isDesc)
        {
            //new 一个Bll对象
            Pbzx.BLL.CstMessage messageBLL = new Pbzx.BLL.CstMessage();

            //字符串拼接
            StringBuilder bu = new StringBuilder();
            bu.Append(" 1=1 ");
            bu.Append(this.AddParameter());
            string Searchstr = bu.ToString();
            string order = column;
            int myCount = 0;

            //判断排序方式
            if (isDesc)
            {
                order += " desc ";
            }
            else
            {
                order += " asc ";
            }

            //传人参数，返回相应的数据
            DataTable lsResult = messageBLL.GuestGetBySearch(Searchstr, "ID,MsgSender,MsgLevel,MsgType,MsgCategory,MsgSend,MsgTitle,MsgTime,MsgContent,MsgST,MsgPV,MsgIT,LoginCount,TotalCount,LLTime,PostTime1,PostTime2,UserID", order, WebInit.webBaseConfig.WebPageNum, 3, AspNetPager1.CurrentPageIndex, out myCount);
            //将返回来的数据绑定到GiveView
            this.MyGridView.DataSource = lsResult;
            this.MyGridView.DataBind();
            //给aspnetpage控件数据的总条数
            AspNetPagerConfig(myCount);
            //当查询数据为空时！则给予消息提示
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
        /// 当lbtn出现命令事件时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnAduting_Command(object sender, CommandEventArgs e)
        {
            //先获得ID
            int id = int.Parse(e.CommandArgument.ToString());

            Pbzx.BLL.CstMessage cstMSGBLL = new Pbzx.BLL.CstMessage();
            //调用业务层方法改变当前状态
            cstMSGBLL.ChangeAudit(id, "MsgSend");
            //然后重新绑定当前数据
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }

        /// <summary>
        /// 当点击修改时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("SoftMessage_Editor.aspx");
        }
        /// <summary>
        /// 出现行绑定事件以后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //这种方式不是很好！
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                string href = "<a href='SoftMessage_Editor.aspx?ID=" + e.Row.Cells[0].Text + "'>";
                //给第一行绑定数据
                e.Row.Cells[0].Text = href + "(" + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString() + ")</a>";
            }

            //最好的方式是（先判断是否是数据行）
            //if(e.Row.RowType==DataControlRowType.DataRow){
            //然后到这里面写东西
            // }
        }
    }
}
