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
using Pbzx.SQLServerDAL;
using Pbzx.Common;
using Maticsoft.DBUtility;

namespace Pbzx.Web.PB_Manage
{
    public partial class WebUser : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MyGridView.PageSize = WebInit.webBaseConfig.WebPageNum;
                BindData();
            }
        }
        private void BindData()
        {
            StringBuilder bu = new StringBuilder();
            bu.Append(" 1=1 ");
            bu.Append(this.AddParameter());
            string Searchstr = bu.ToString();
            string order = "LastLogin desc,UserID asc";
            int myCount = 0;

            DataTable lsResult = Basic.BbsGetRecordFromPagesDs("Dv_User", "UserID,UserName,UserEmail,Mobile,JoinDate,LastLogin,UserClass,UserLastIP", order, "UserID", WebInit.webBaseConfig.WebPageNum, AspNetPager1.CurrentPageIndex, true, 3, Searchstr, out myCount);


            this.MyGridView.DataSource = lsResult;
            this.MyGridView.DataBind();
            AspNetPagerConfig(myCount);
            if (lsResult == null)
            {
                this.litContent.Text = "<b>��Ǹ��<p/><br/>Ӧ��û���ҵ������������ݼ�¼</b>";
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
            AspNetPager1.CustomInfoHTML = "��<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>��&nbsp;";
            AspNetPager1.CustomInfoHTML += "��ҳ<font color=\"red\"><b>" + MyGridView.Rows.Count + "</b></font>��&nbsp;";
            AspNetPager1.CustomInfoHTML += "��ҳ:<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "ҳ</font>";
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                string href = "<a href='WebUser_Editor.aspx?ID=" + GetUserIDByUserName(e.Row.Cells[1].Text) + "'  target='_blank' >";
                e.Row.Cells[0].Text = href + "(" + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString() + ")</a>";
            }
        }
        /// <summary>
        /// ����url��ֵ��ѯ
        /// </summary>
        /// <returns></returns>
        private string AddParameter()
        {
            StringBuilder bu = new StringBuilder();

            //if (!string.IsNullOrEmpty(Request["UserClass"]))
            //{
            //    bu.Append(" and UserClass='" + Input.FilterAll(Request["UserClass"]) + "' ");
            //}
            if (!string.IsNullOrEmpty(Request["islike"]))
            {
                if (Request["islike"] == "1")
                {
                    if (!string.IsNullOrEmpty(Request["strUserName"]))
                    {
                        bu.Append(" and UserName like '%" + Input.FilterAll(Request["strUserName"]) + "%' ");
                    }
                    if (!string.IsNullOrEmpty(Request["strUserEmail"]))
                    {
                        bu.Append(" and UserEmail like '%" + Input.FilterAll(Request["strUserEmail"]) + "%' ");
                    }
                    if (!string.IsNullOrEmpty(Request["strUserMobile"]))
                    {
                        bu.Append(" and Mobile like '%" + Input.FilterAll(Request["strUserMobile"]) + "%' ");
                    }
                }
                else
                {

                    if (!string.IsNullOrEmpty(Request["strUserName"]))
                    {
                        bu.Append(" and UserName='" + Input.FilterAll(Request["strUserName"])+"'");
                    }
                    if (!string.IsNullOrEmpty(Request["strUserEmail"]))
                    {
                        bu.Append(" and UserEmail='" + Input.FilterAll(Request["strUserEmail"]) + "'");
                    }
                    if (!string.IsNullOrEmpty(Request["strUserMobile"]))
                    {
                        bu.Append(" and Mobile='" + Input.FilterAll(Request["strUserMobile"]) + "'");
                    }
                }

            }

            //ʱ���ѯ
            if (!string.IsNullOrEmpty(Request["dateType"]))
            {
                if (!string.IsNullOrEmpty(Request["strCreateTime1"]) && !string.IsNullOrEmpty(Request["strCreateTime2"]))
                {
                    if (Request["dateType"] == "1")
                    {
                        bu.Append(" and JoinDate between '" + Request["strCreateTime1"] + "' and '" + Request["strCreateTime2"] + " 23:59:59'  ");
                    }
                    else if (Request["dateType"] == "2")
                    {
                        bu.Append(" and LastLogin between '" + Request["strCreateTime1"] + "' and '" + Request["strCreateTime2"] + " 23:59:59'  ");
                    }
                }
            }
            return bu.ToString();
        }

        /// <summary>
        /// �����û����õ��û�ID
        /// </summary>
        /// <param name="uName"></param>
        /// <returns></returns>
        protected string GetUserIDByUserName(object uName)
        {
            if (uName == null)
            {
                return "";
            }
            else
            {
                object objResult = DbHelperSQLBBS.GetSingle("select top 1 UserID from Dv_User where UserName='" + uName.ToString() + "'  ");
                if (objResult == null)
                {
                    return "";
                }
                else
                {
                    return objResult.ToString();
                }
            }
        }
    }
}
