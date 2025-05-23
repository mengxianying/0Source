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
        /// ������
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
                this.litContent.Text = "<b>��Ǹ��<p/><br/>Ӧ��û���ҵ������������ݼ�¼</b>";
            }
            else
            {
                this.litContent.Text = "";
            }
        }


        /// <summary>
        /// ��ҳ�ؼ�����
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
            AspNetPager1.CustomInfoHTML = "��<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>��&nbsp;";
            AspNetPager1.CustomInfoHTML += "��ҳ<font color=\"red\"><b>" + MyGridView.Rows.Count + "</b></font>��&nbsp;";
            AspNetPager1.CustomInfoHTML += "��ҳ:<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "ҳ</font>";
        }

        /// <summary>
        /// ҳ��ı����°�����
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
          //      JS.Alert("���뱣֤������һ����¼");
          //  }
          //  int id = int.Parse(MyGridView.DataKeys[e.RowIndex].Value.ToString());
          ////  string nvarname = MyGridView.Rows[e.RowIndex].Cells[2].Text;
          //  Pbzx.BLL.PBnet_WebLog bllWg = new Pbzx.BLL.PBnet_WebLog();
          //  if (bllWg.Delete(id))
          //  {
          //      //ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("��ɾ����" + del + "����¼.", "FriendLink_Manage.aspx"));//[" + nvarname + "]
          //      JS.Alert("ɾ����־�ɹ���");
          //  }
          //  BindData();
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        private string AddParameter()
        {
            StringBuilder bu = new StringBuilder();
            if (!string.IsNullOrEmpty(Request["ActionType"]) && Request["ActionType"] != "����")
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
               //Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("ɾ��", "ɾ������[" + str + "]");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("��ɾ����" + del + "����¼.", "WebLog_Manage.aspx"));
            }
            BindData();
        }

        protected string GetIpName(object obj)
        {
            Pbzx.BLL.PBnet_ipdata ipBLL = new Pbzx.BLL.PBnet_ipdata();
            return ipBLL.S_getIPaddress(obj.ToString());
        }

        /// <summary>
        /// ��������
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

        //��ѯ
        protected void btn_Query_Click(object sender, EventArgs e)
        {
            BindData();
        }
    }
}
