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
using Maticsoft.DBUtility;

namespace Pbzx.Web.PB_Manage.CST
{
    public partial class US_config : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            MyGridView.Attributes.Add("style", "word-break:break-all;word-wrap:break-word");

            if (!IsPostBack)
            {
                //配置信息管理列表绑定
                MyGridView.PageSize = WebInit.webBaseConfig.WebPageNum;
                BindData();
                //软件配置信息列表
                SoftWareDataBinds();

            }
        }
        /// <summary>
        /// 软件配置信息绑定方法
        /// </summary>
        private void SoftWareDataBinds()
        {
            Pbzx.BLL.CstSoftware software = new Pbzx.BLL.CstSoftware();
            string softwhere = "VersionType <= 100";
            DataSet dsProduct = software.GetList(softwhere);
            StringBuilder str = new StringBuilder();
            str.Append(" <table width='98%' border='0' cellpadding='1' cellspacing='1' bgcolor='#CED7F7' align='center'>");
            for (int i = 0; i < dsProduct.Tables[0].Rows.Count; i++)
            {
                DataRow tempRow = dsProduct.Tables[0].Rows[i];
                str.Append("<tr valign='middle' bgcolor='#FFFFFF' align='center' height='22'>");
                str.Append("<td align='left'' style='width: 167px; height: 22px'>");
                str.Append("<font color='#FF0000'>" + tempRow["CstID"] + "</font> ：<font color='#0033FF'>" + tempRow["CstName"] + "</font>");
                str.Append("</td>");

                if (i + 1 < dsProduct.Tables[0].Rows.Count)
                {
                    DataRow tempRow1 = dsProduct.Tables[0].Rows[i + 1];
                    str.Append("<td align='left'' style='width: 167px; height: 22px'>");
                    str.Append("<font color='#FF0000'>" + tempRow1["CstID"] + "</font> ：<font color='#0033FF'>" + tempRow1["CstName"] + "</font>");
                    str.Append("</td>");
                }
                if (i + 2 < dsProduct.Tables[0].Rows.Count)
                {
                    DataRow tempRow2 = dsProduct.Tables[0].Rows[i + 2];
                    str.Append("<td align='left'' style='width: 167px; height: 22px'>");
                    str.Append("<font color='#FF0000'>" + tempRow2["CstID"] + "</font> ：<font color='#0033FF'>" + tempRow2["CstName"] + "</font>");
                    str.Append("</td>");
                }
                if (i + 3 < dsProduct.Tables[0].Rows.Count)
                {
                    DataRow tempRow3 = dsProduct.Tables[0].Rows[i + 3];
                    str.Append("<td align='left'' style='width: 167px; height: 22px'>");
                    str.Append("<font color='#FF0000'>" + tempRow3["CstID"] + "</font> ：<font color='#0033FF'>" + tempRow3["CstName"] + "</font>");
                    str.Append("</td>");
                }
                i = i + 3;
                str.Append(" </tr>");
            }
            this.SoftWareID.InnerHtml = str.ToString();
        }


        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = Pbzx.Common.WebInit.webBaseConfig.WebPageNum;
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
        private void BindData()
        {
            Pbzx.BLL.CN_Config configBLL = new Pbzx.BLL.CN_Config();
            StringBuilder bu = new StringBuilder();
            bu.Append("1=1");
            //   bu.Append(this.AddParameter());

            string Searchstr = bu.ToString();
            string order = "ID";
            int myCount = 0;

            DataTable lsResult = configBLL.GuestGetBySearch(Searchstr, "*", order, Pbzx.Common.WebInit.webBaseConfig.WebPageNum, 1, AspNetPager1.CurrentPageIndex, out myCount);
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
        protected string GetFlag(object objnum)
        {
            string Flag = "";
            int intnum = int.Parse(objnum.ToString());
            switch (intnum)
            {
                case 0:
                    Flag = "<font color='#009900'>投入使用</font>";
                    break;
                case 1:
                    Flag = "<font color='#666666'>等待使用</font>";
                    break;
                case 10:
                    Flag = "<font color='#660033'>不许修改</font>";
                    break;
                default:
                    Flag = "";
                    break;
            }
            return Flag;
        }

        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                string href = "<a href='Config_Editor.aspx?ID=" + e.Row.Cells[0].Text + "' target='_blank'>";
                e.Row.Cells[0].Text = href + "(" + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString() + ")</a>";
            }
        }
    }
}
