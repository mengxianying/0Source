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
using Maticsoft.DBUtility;
using Pbzx.Common;
using System.Text;

namespace Pbzx.Web.PB_Manage
{
    public partial class SoftOnline_Iterance_2011 : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MyGridView.PageSize = WebInit.webBaseConfig.WebPageNum;
                Pbzx.BLL.CN_MaxOnline maxBLL = new Pbzx.BLL.CN_MaxOnline();
                Pbzx.BLL.CstLogin2010Manager maxcstlogin = new Pbzx.BLL.CstLogin2010Manager();


                BindData();
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
            StringBuilder bu = new StringBuilder();

            Pbzx.BLL.CstSoftware sfBll = new Pbzx.BLL.CstSoftware();

            return bu.ToString();

        }


        private void BindData()
        {
            //当前页数
            int pageindex = AspNetPager1.CurrentPageIndex - 1;

            //每页显示条数 WebInit.webBaseConfig.WebPageNum
            int pagecount = WebInit.webBaseConfig.WebPageNum;

            //要显示的
            int pagege = pageindex * pagecount;

            //判断是否存在重复的
            DataTable lsResults = DbHelperSQL1.Query("SELECT  GlobalID, COUNT(GlobalID) AS GlobalIDCount, SoftwareType, InstallType FROM CstLogin2010 GROUP BY GlobalID, SoftwareType, InstallType HAVING (COUNT(GlobalID) > 1) ORDER BY GlobalIDCount DESC").Tables[0];
            if (lsResults.Rows.Count > 0)
            {
                //得到重复的数据
                DataTable lsResult = DbHelperSQL1.Query("SELECT top " + pagecount + " GlobalID, COUNT(GlobalID) AS GlobalIDCount, SoftwareType, InstallType FROM CstLogin2010 " +
                    "WHERE (GlobalID NOT IN (SELECT TOP " + pagege + " GlobalID FROM CstLogin2010 GROUP BY GlobalID,SoftwareType, InstallType HAVING (COUNT(GlobalID) > 1) order by COUNT(GlobalID) desc))" + "GROUP BY GlobalID, SoftwareType, InstallType HAVING (COUNT(GlobalID) > 1) ORDER BY GlobalIDCount DESC").Tables[0];

                this.MyGridView.DataSource = lsResult;
                this.MyGridView.DataBind();
                AspNetPagerConfig(lsResults.Rows.Count);

                this.litContent.Text = "";
            }
            else
            {
                this.litContent.Text = "<b>抱歉！<p/><br/>应该没有找到您搜索的数据记录</b>";
            }

        }

        protected void MyGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
        }

        #region
        protected string ChkHDSN(object tHDSN, object tRN, object tStatus, object hdsnType)
        {
            string strStatus = tStatus.ToString();
            string dis = "";
            string strRN = tRN.ToString();
            string strHDSN = tHDSN.ToString();
            switch (strStatus)
            {
                case null:
                    if (Convert.ToInt32(hdsnType) == 8)
                    {
                        if (tRN.ToString().Substring(0, 1) == "*")
                            return "<a title='" + tRN + "' href='US_free.aspx?&Status=1&strDiskCVol=" + tRN.ToString() + "' target='_blank'>" + strHDSN + "</a>";
                        else
                            return "<a title='" + tRN + "' href='US_msg.aspx?&strName=" + Server.UrlEncode(tRN.ToString()) + "' target='_blank'>" + strHDSN + "</a>";

                    }
                    else
                        dis = "<a title='" + tRN + "' href='SoftReg_Manager.aspx?strRN=" + strRN + "&act_searchmod=0' target='_blank'>" + strHDSN + "</a>";
                    break;
                case "":
                    if (Convert.ToInt32(hdsnType) == 8)
                    {
                        if (tRN.ToString().Substring(0, 1) == "*")
                            return "<a title='" + tRN + "' href='US_free.aspx?&Status=1&strDiskCVol=" + tRN.ToString() + "' target='_blank'>" + strHDSN + "</a>";
                        else
                            return "<a title='" + tRN + "' href='US_msg.aspx?&strName=" + Server.UrlEncode(tRN.ToString()) + "' target='_blank'>" + strHDSN + "</a>";

                    }
                    else
                        dis = "<a title='" + tRN + "' href='SoftReg_Manager.aspx?strRN=" + strRN + "&act_searchmod=0' target='_blank'>" + strHDSN + "</a>";
                    break;
                case "1":
                    if (Convert.ToInt32(hdsnType) == 8)
                    {
                        if (tRN.ToString().Substring(0, 1) == "*")
                            return "<a title='" + tRN + "' href='US_free.aspx?&Status=1&strDiskCVol=" + tRN.ToString() + "' target='_blank'>" + strHDSN + "</a>";
                        else
                            return "<a title='" + tRN + "' href='US_msg.aspx?&strName=" + Server.UrlEncode(tRN.ToString()) + "' target='_blank'>" + strHDSN + "</a>";

                    }
                    else
                        dis = "<a title='" + tRN + "' href='SoftReg_Manager.aspx?strRN=" + strRN + "&act_searchmod=0' target='_blank'>" + strHDSN + "</a>";
                    break;
                case "2":
                    if (Convert.ToInt32(hdsnType) == 8)
                    {
                        if (tRN.ToString().Substring(0, 1) == "*")
                            return "<a title='" + tRN + "' href='US_free.aspx?&Status=1&strDiskCVol=" + tRN.ToString() + "' target='_blank'>" + strHDSN + "</a>";
                        else
                            return "<a title='" + tRN + "' href='US_msg.aspx?&strName=" + Server.UrlEncode(tRN.ToString()) + "' target='_blank'>" + strHDSN + "</a>";

                    }
                    else
                        dis = "<a title='" + tRN + "' href='SoftReg_Manager.aspx?strRN=" + strRN + "&act_searchmod=0' target='_blank' style='color:#ff0000;' >" + strHDSN + "</a>";
                    break;
                case "3":
                    if (Convert.ToInt32(hdsnType) == 8)
                    {
                        if (tRN.ToString().Substring(0, 1) == "*")
                            return "<a title='" + tRN + "' href='US_free.aspx?&Status=1&strDiskCVol=" + tRN.ToString() + "' target='_blank'>" + strHDSN + "</a>";
                        else
                            return "<a title='" + tRN + "' href='US_msg.aspx?&strName=" + Server.UrlEncode(tRN.ToString()) + "' target='_blank'>" + strHDSN + "</a>";

                    }
                    else
                        dis = "<a title='" + tRN + "' href='SoftReg_Manager.aspx?strRN=" + strRN + "&act_searchmod=0' target='_blank' style='color:#009900;'>" + strHDSN + "</a>";
                    break;
                case "4":
                    if (Convert.ToInt32(hdsnType) == 8)
                    {
                        if (tRN.ToString().Substring(0, 1) == "*")
                            return "<a title='" + tRN + "' href='US_free.aspx?&Status=1&strDiskCVol=" + tRN.ToString() + "' target='_blank'>" + strHDSN + "</a>";
                        else
                            return "<a title='" + tRN + "' href='US_msg.aspx?&strName=" + Server.UrlEncode(tRN.ToString()) + "' target='_blank'>" + strHDSN + "</a>";

                    }
                    else
                        dis = "<a title='" + tRN + "' href='SoftReg_Manager.aspx?strRN=" + strRN + "&act_searchmod=0' target='_blank' style='color:#999999;'>" + strHDSN + "</a>";
                    break;
                default:
                    if (Convert.ToInt32(hdsnType) == 8)
                    {
                        if (tRN.ToString().Substring(0, 1) == "*")
                            return "<a title='" + tRN + "' href='US_free.aspx?&Status=1&strDiskCVol=" + tRN.ToString() + "' target='_blank'>" + strHDSN + "</a>";
                        else
                            return "<a title='" + tRN + "' href='US_msg.aspx?&strName=" + Server.UrlEncode(tRN.ToString()) + "' target='_blank'>" + strHDSN + "</a>";

                    }
                    else
                        dis = "<a title='" + tRN + "' href='SoftReg_Manager.aspx?strRN=" + strRN + "&act_searchmod=0' target='_blank'>" + strHDSN + "</a>";
                    break;
            }
            return dis;
        }

        #endregion


        protected string ChkSoftType(object num, object st)
        {
            Pbzx.BLL.CstSoftware softBLL = new Pbzx.BLL.CstSoftware();
            string[] result = softBLL.Chksettype(num, st);
            string[] results = softBLL.Chksettypeid(num, st);
            return "<a href='SoftOnline_Manage_2011.aspx?SoftwareName=" + results[0] + "&InstallName=" + st.ToString() + "'>" + result[0] + "(" + result[1] + ")" + "</a>";
        }


        public string GbCount(object obj)
        {
            if (obj.ToString() != "")
            {
                DataSet ds = DbHelperSQL1.Query("select count(GlobalID)from CstLogin2010 where GlobalID='" + obj.ToString() + "'");
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return ds.Tables[0].Rows[0][0].ToString();
                    }
                }

            }
            return "0";
        }

        protected string ChkHDSType(object RN, object HDSNType)
        {
            if (Convert.ToInt32(HDSNType) == 8)
            {
                return "<a href='SoftOnline_Manage_2011.aspx?&strRN=" + RN + "'>" + RN.ToString() + "</a>";
            }
            return "";
        }

        protected void MyGridView_RowCreated(object sender, GridViewRowEventArgs e)
        {


        }

        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString();
            }
        }


        public string ISGloBal(object obj)
        {

            if (obj != null && obj.ToString() != "")
            {
                string c = obj.ToString().Substring(0, 1);
                if (c == "s")
                {
                    return "<font color='#0000FF'>" + obj.ToString() + "</font>";
                }
                else if (c == "c")
                {
                    return "<font color='#9900ff'>" + obj.ToString() + "</font>";
                }
                else if (c == "n")
                {
                    return "<font color='red'>" + obj.ToString() + "</font>";
                }
                else
                {
                    return obj.ToString();
                }
            }
            return obj.ToString();
        }

    }
}
