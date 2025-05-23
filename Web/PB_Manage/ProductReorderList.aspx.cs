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
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Pbzx.Web.PB_Manage
{
    public partial class ProductReorderList : AdminBasic
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }

        }

        private void BindData()
        {
            StringBuilder bu = new StringBuilder();
            bu.Append(" 1=1 and pb_Deleted=0 ");
            bu.Append(this.AddParameter());
            string Searchstr = bu.ToString();
            ObjDCProduct.SelectParameters[0].DefaultValue = Searchstr;
            //Pbzx.BLL.PBnet_Product productBLL = new Pbzx.BLL.PBnet_Product();
            //this.ReorderList1.DataSource = productBLL.GetProductListSort(Searchstr);
            //this.ReorderList1.DataBind();   

        }

        /// <summary>
        /// 处理url传值查询
        /// </summary>
        /// <returns></returns>
        protected string AddParameter()
        {
            StringBuilder bu = new StringBuilder();

            //软件名称
            if (!string.IsNullOrEmpty(Request["softName"]))
            {
                bu.Append(" and pb_SoftName like '%" + Request["softName"].Trim() + "%' ");
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
                        bu.Append(" and pb_UpdateTime between '" + Request["strCreateTime1"] + "' and '" + Request["strCreateTime2"] + "'  ");
                    }
                    else if (Request["dateType"] == "2")
                    {
                        bu.Append(" and pb_LastHitTime between '" + Request["strCreateTime1"] + "' and '" + Request["strCreateTime2"] + "'  ");
                    }
                }
            }
            if (!string.IsNullOrEmpty(Request["pb_SoftVersion"]))
            {
                bu.Append(" and pb_SoftVersion like '%" + Request["pb_SoftVersion"].Trim() + "%'");
            }
            return bu.ToString();

        }


        protected void lbtnCreate_Click(object sender, EventArgs e)
        {
            //Server.Execute("/PB_Manage/Refurbish_Soft.aspx");
            WebFunc.RefPagesByPageName("首页");
        }


    }
}
