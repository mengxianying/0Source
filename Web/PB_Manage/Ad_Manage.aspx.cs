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
    public partial class Ad_Manage : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.MyGridView.PageSize = WebInit.webBaseConfig.WebPageNum;

                this.Page.SetFocus(this.UcAD1);//设置焦点
                if (ViewState["order"] == null)
                {
                    ViewState["order"] = "PlaceName";
                }
                if (ViewState["isDesc"] == null)
                {
                    ViewState["isDesc"] = false;
                }
                BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
                
            }
        }

        private void BindData(string column, bool isDesc)
        {
            Pbzx.BLL.PBnet_Adv messageBLL = new Pbzx.BLL.PBnet_Adv();
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

            DataTable lsResult = messageBLL.GuestGetBySearch(Searchstr, "*", order, WebInit.webBaseConfig.WebPageNum, 3, AspNetPager1.CurrentPageIndex, out myCount);
            
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
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }

        //protected void lbtnDel_Command(object sender, CommandEventArgs e)
        //{
        //    int id = int.Parse(e.CommandArgument.ToString());
        //    Pbzx.BLL.PBnet_Adv msgBLL = new Pbzx.BLL.PBnet_Adv();
        //    if (msgBLL.Delete(id))
        //    {
        //        JS.Alert("删除成功！");
        //    }
        //    else
        //    {
        //        JS.Alert("删除失败！");
        //    }
        //    BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        //}

        public string GetWei(object place)
        {
           int intplace = int.Parse(place.ToString());
           Pbzx.BLL.PBnet_AdvPlace PlaceBll = new Pbzx.BLL.PBnet_AdvPlace();
           Pbzx.Model.PBnet_AdvPlace placeModel = PlaceBll.GetModel(intplace);
            if(placeModel == null)
            {
                return "";
            }
           return placeModel.PlaceName;
        }

        public string GetAD(object StieName, object url, object picUrl, object Place,object width,object height)
        {   
           string intplace = Place.ToString();
            Pbzx.BLL.PBnet_AdvPlace PlaceBll = new Pbzx.BLL.PBnet_AdvPlace();
            Pbzx.Model.PBnet_AdvPlace placeModel = PlaceBll.GetModelName(intplace);
            if(placeModel == null)
            {
                return "";
            }
            int Type =int.Parse(placeModel.TypeID.ToString());
                       
            string newWidth ="";
            if (width .ToString()!= "")
            {
                if (int.Parse(width.ToString()) > 278)
                {
                    newWidth = "278";
                }
                else
                {

                    newWidth = width.ToString();
                }
            }
            string Getad = "";
            if (Type ==1)
            {
                Getad = "<a href='" + url.ToString() + "' target='_blank'>" + url.ToString() + "</a>";
            }
            else if(Type == 3)
            {
                Getad += "<object classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\" codebase=\" http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\" width='" + newWidth + "' height='" + height + "'>";
                        Getad += " <param name=\"movie\" value=" + picUrl + " /> <param name=\"quality\" value=\"high\" />";
                        Getad += "<embed src=" + picUrl + " quality=\"high\" pluginspage=\" http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\"></embed>";
                        Getad += "</object>";
            }
            else if (Type == 6)
            {
                Getad = "";
            }
            else if (Type == 0 || Type == 2 || Type == 4 || Type == 5)
            {
                if (picUrl.ToString() != "")
                {
                    Getad +="<a href='"+url+"' target='_blank'>";
                    Getad += "<img src=" + picUrl + " width='" + newWidth + "' height='" + height + "' border='0'/>";
                    Getad += "</a>";
                }
                else
                {
                    Getad = " <img src='../Images/AD/Gold.gif' width='245' height='40'>";
                }
            }
             
           return Getad;         
          
        }
        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                e.Row.Cells[1].Text = "(" + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString() + ")";
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
            BindData("" + ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }

        protected void MyGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //protected void btnSC_Click(object sender, EventArgs e)
        //{
        //    Pbzx.BLL.PBnet_Adv MyBll = new Pbzx.BLL.PBnet_Adv();
        //    string str = Request.Form["sel"];
        //    if (str== null)广告位名称
        //    {
        //        return;
        //    }
        //    int Del = MyBll.BatchDel(str);
        //    if (Del > 0)
        //    {
        //        Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("删除", "删除广告[" + str + "]");
        //        ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("共删除了" + Del + "条记录.", "Ad_Manage.aspx"));
        //    }
        //    BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        //}

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_Adv MyBll = new Pbzx.BLL.PBnet_Adv();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int Del = MyBll.BatchUpdateState(str, "pb_IsSelected",true);
            if (Del > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("设为最新", "设为最新广告[" + str + "]");
               // ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("共设为最新了" + Del + "条广告.", "Ad_Manage.aspx"));
                ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("共设为最新了" + Del + "条广告."));
            }
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }

        protected void btnNNew_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_Adv MyBll = new Pbzx.BLL.PBnet_Adv();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int Del = MyBll.BatchUpdateState(str, "pb_IsSelected", false);
            if (Del > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("设为不最新", "设为不最新广告[" + str + "]");
               // ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("共设为不最新了" + Del + "条广告.", "Ad_Manage.aspx"));
                ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("共设为不最新了" + Del + "条广告."));
            }
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }
        private string AddParameter()
        {
            StringBuilder bu1 = new StringBuilder();

            if (!string.IsNullOrEmpty(Request["strSiteName"]))
            {
                bu1.Append(" and pb_SiteName like'%" + Request["strSiteName"] + "%' ");
            }
            if (!string.IsNullOrEmpty(Request["strSiteUrl"]))
            {
                bu1.Append(" and pb_SiteUrl like'%" + Request["strSiteUrl"] + "%' ");
            }
            if (!string.IsNullOrEmpty(Request["Channel"]))
            {
                bu1.Append(" and (PlaceName in (select PlaceName from PBnet_AdvPlace where  ChannelID='" + Request["Channel"] + "')) ");
            }
            if (!string.IsNullOrEmpty(Request["ADType"]))
            {
                bu1.Append(" and (PlaceName in (select PlaceName from PBnet_AdvPlace where  TypeID='" + Request["ADType"] + "')) ");
            }
            if (!string.IsNullOrEmpty(Request["dateType"]))
            {
                if (!string.IsNullOrEmpty(Request["strCreateTime1"]) && !string.IsNullOrEmpty(Request["strCreateTime2"]))
                {
                    if (Request["dateType"] == "1")
                    {
                        bu1.Append(" and pb_ADDTime between '" + Request["strCreateTime1"] + "' and '" + Request["strCreateTime2"] + " 23:59:59'  ");
                    }
                    else if (Request["dateType"] == "2")
                    {
                        bu1.Append(" and pb_ENDTime between '" + Request["strCreateTime1"] + "' and '" + Request["strCreateTime2"] + " 23:59:59'  ");
                    }
                }
            }
            return bu1.ToString();

        }

        protected void lbtnUpDateIndex_Click(object sender, EventArgs e)
        {
            WebFunc.RefPagesByPageName("首页");
        }
    }
}
