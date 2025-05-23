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
    public partial class Ask_Reply_Deleted : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (ViewState["order"] == null)
                {
                    ViewState["order"] = "ReplyTime";
                }
                if (ViewState["isDesc"] == null)
                {
                    ViewState["isDesc"] = true;
                }
                BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
            }
        }
        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = Pbzx.Common.WebInit.webBaseConfig.WebPageNum;
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
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }
        protected void BindData(string column, bool isDesc)
        {
            Pbzx.BLL.PBnet_ask_Reply MyBll = new Pbzx.BLL.PBnet_ask_Reply();
            StringBuilder bu = new StringBuilder();
            bu.Append("1=1");
            bu.Append(" and Deleted =1 ");    
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

            DataTable IsResult = MyBll.GuestGetBySearch(Searchstr, "*", order, Pbzx.Common.WebInit.webBaseConfig.WebPageNum, 3, AspNetPager1.CurrentPageIndex, out myCount);
            this.MyGridView.DataSource = IsResult;
            this.MyGridView.DataBind();
            AspNetPagerConfig(myCount);
            if (IsResult == null)
            {
                this.litContent.Text = "<b>��Ǹ��<p/><br/>Ӧ��û���ҵ������������ݼ�¼</b>";
            }
            else
            {
                this.litContent.Text = "";
            }
        }
      
        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                string href = "<a href='Ask_Reply_Edit.aspx?id=" + e.Row.Cells[1].Text + "'>";
                e.Row.Cells[1].Text = href + "(" + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString() + ")</a>";
            }
        }

                protected void lbtnDel_Command(object sender, CommandEventArgs e)
        {

            Pbzx.BLL.PBnet_ask_Reply produtBLL = new Pbzx.BLL.PBnet_ask_Reply();
            int id = int.Parse(e.CommandArgument.ToString());
            Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("ɾ��", "ɾ���ظ�[" + produtBLL.GetModel(id).Replyer + "].");
            ClientScript.RegisterStartupScript(this.GetType(), "ok", JS.Alert("ɾ���ɹ���."));
            produtBLL.BatchUpdate(id.ToString(), "Deleted", true);       
       
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }
        public static string GetTitle(object num)
        {
            string title = "";
            int intnum = int.Parse(num.ToString());
            Pbzx.BLL.PBnet_ask_Question TitleBll = new Pbzx.BLL.PBnet_ask_Question();
            Pbzx.Model.PBnet_ask_Question TitleModel = TitleBll.GetModel(intnum);
            if (TitleModel != null)
            {
                title = TitleModel.Title.ToString();

                return title.ToString();
            }
            else
            {
                return null;
            }

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_ask_Reply ReplyBLL = new Pbzx.BLL.PBnet_ask_Reply();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int del = ReplyBLL.BatchDel(str);
            if (del > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("ɾ��", "ɾ���ظ�[" + str + "]");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("��ɾ����" + del + "���ظ���¼.", "Ask_Reply_Deleted.aspx"));
            }
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }
        protected void lbtnPb_Elite_Command(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            Pbzx.BLL.PBnet_ask_Reply.ChangeAudit(id, "Deleted");
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }
        protected void btnManySH_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_ask_Reply produtBLL = new Pbzx.BLL.PBnet_ask_Reply();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int del = produtBLL.BatchUpdate(str, "Deleted", false);
            if (del > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("��ԭ", "��ԭ�ظ�[" + str + "]");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("����ԭ��" + del + "���ظ���¼.", "Ask_Reply_Deleted.aspx"));
            }
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }

        protected void btnGD_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_ask_Reply produtBLL = new Pbzx.BLL.PBnet_ask_Reply();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int del = produtBLL.ExecuteBySql("update  PBnet_ask_Reply set Deleted=0   WHERE Deleted=1 ");
            if (del > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("��ԭ", "��ԭ���лظ�[" + str + "]");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("����ԭ��" + del + "���ظ���¼.", "Ask_Reply_Deleted.aspx"));
            }
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);

        }
        protected void btnNotIndex_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_ask_Reply produtBLL = new Pbzx.BLL.PBnet_ask_Reply();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int del = produtBLL.ExecuteBySql("DELETE FROM PBnet_ask_Reply WHERE Deleted=1 ");
            if (del > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("����ɾ��", "����ɾ���ظ�[" + str + "]");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("������ɾ����" + del + "���ظ���¼.", "Ask_Reply_Deleted.aspx"));
            }
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
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
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }
    }
}
