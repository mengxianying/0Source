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
    public partial class Public_Content : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MyGridView.PageSize = WebInit.webBaseConfig.WebPageNum;                
                this.MyGridView.PageSize = WebInit.webBaseConfig.WebPageNum;
                BindData();
            }
        }
        private void BindData()
        {
            Pbzx.BLL.PBnet_PulbicContent newsBLL = new Pbzx.BLL.PBnet_PulbicContent();
            StringBuilder bu = new StringBuilder();
            bu.Append(" 1=1 ");
           // bu.Append(this.AddParameter());
         
            string Searchstr = bu.ToString();
            string order = "IntID";
            int myCount = 0;

            DataTable lsResult = newsBLL.GuestGetBySearch(Searchstr, "*", order, WebInit.webBaseConfig.WebPageNum, 1, AspNetPager1.CurrentPageIndex, out myCount);

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
                e.Row.Cells[0].Text = "(" + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString() + ")";
            }
        }
        protected void MyGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (this.MyGridView.Rows.Count <= 1)
            {
                e.Cancel = true;
                JS.Alert("���뱣֤������һ����¼");
            }
            int id = int.Parse(MyGridView.DataKeys[e.RowIndex].Value.ToString());
            string nvarname = MyGridView.DataKeys[e.RowIndex].Values["NvarTitle"].ToString();
            Pbzx.BLL.PBnet_PulbicContent bll = new Pbzx.BLL.PBnet_PulbicContent();
            if (bll.Delete(id))
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("ɾ��", "ɾ������[" + nvarname + "]");
                //ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("��ɾ����" + del + "����¼.", "FriendLink_Manage.aspx"));
                JS.Alert("ɾ������[" + nvarname + "]�ɹ���");
            }
            BindData();
        }
        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            Pbzx.BLL.PBnet_PulbicContent Contentbll = new Pbzx.BLL.PBnet_PulbicContent();
            Pbzx.Model.PBnet_PulbicContent ContentModel = Contentbll.GetModel(id);

            if (Files.Create(ContentModel.HtmUrl, ContentModel.AspxUrl))
            {
                JS.Alert("����[" + ContentModel.NvarTitle.ToString() + "]�ɹ���");
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("����", "��������[" + ContentModel.NvarTitle.ToString() + "]");
            }
            BindData();
            Response.Redirect("Public_Content.aspx");
        }
        protected void lbtnShow_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            Pbzx.BLL.PBnet_PulbicContent.ChangeAudit(id, "BitState");
            BindData();
        }
    }
}
