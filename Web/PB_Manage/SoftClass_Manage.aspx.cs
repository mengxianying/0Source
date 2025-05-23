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

namespace Pbzx.Web.PB_Manage
{
    public partial class SoftClass_Manage : AdminBasic
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                MyGridView.PageSize = WebInit.webBaseConfig.WebPageNum;
                BindData();               
            }
        }
        /// <summary>
        /// ������
        /// </summary>
        private void BindData()
        {
            Pbzx.BLL.PBnet_SoftClass softclassBLL = new Pbzx.BLL.PBnet_SoftClass();
            //if (!string.IsNullOrEmpty(Request["IntSetting"]))
            //{
            //    int index = int.Parse(Request["IntSetting"]) + 1;
            //    this.rblIntSetting.SelectedIndex = index;
            //}
         
            StringBuilder bu = new StringBuilder();
            bu.Append(" 1=1 ");
            if (Request["classType"] == "yuan")
            {
                this.yuanID.Visible = true;
                bu.Append(" and IntSetting=1");
            }
            else if (Request["classType"] == "chan")
            {
                this.chanID.Visible = true;
                bu.Append(" and IntSetting=0");
            }
            bu.Append(this.AddParameter());
            ///////////////////////////////////////////////////////////////////////////////////
            string Searchstr = bu.ToString();
            string order = "IntOrderID asc ";
            int myCount = 0;

            DataTable lsResult = softclassBLL.GuestGetBySearch(Searchstr, "*", order, WebInit.webBaseConfig.WebPageNum, 3, AspNetPager1.CurrentPageIndex, out myCount);

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
            if (this.MyGridView.Rows.Count <= 1)
            {
                e.Cancel = true;
                JS.Alert("���뱣֤������һ����¼");
            }
            int id = int.Parse(MyGridView.DataKeys[e.RowIndex].Value.ToString());
            string nvarname = MyGridView.DataKeys[e.RowIndex].Values["NvarClassName"].ToString();
            Pbzx.BLL.PBnet_SoftClass bll = new Pbzx.BLL.PBnet_SoftClass();
            DbHelperSQL.ExecuteSql("delete from PBnet_Product where pb_ClassID='"+id+"' ");
            DbHelperSQL.ExecuteSql("delete from PBnet_Soft where pb_ClassID='" + id + "' ");
            if (bll.Delete(id))
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("ɾ��", "ɾ����Ʒ��Դ���[" + nvarname + "]");
                //ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("��ɾ����" + del + "����¼.", "FriendLink_Manage.aspx"));
                JS.Alert("ɾ��������[" + nvarname + "]�ɹ���");
            }
            BindData();
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        private string  AddParameter()
        {
            StringBuilder bu = new StringBuilder();
            if (!string.IsNullOrEmpty(Request["IntSetting"]) && Request["IntSetting"] != "-1")
            {
                bu.Append(" and IntSetting=" + Request["IntSetting"]);
            }
            return bu.ToString();
        }

        //protected void rblIntSetting_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Response.Redirect("SoftClass_Manage.aspx?IntSetting="+this.rblIntSetting.SelectedValue, true);
        //}

        /// <summary>
        /// �õ����Ȩ��
        /// </summary>
        /// <param name="browsePurview"></param>
        /// <returns></returns>
        protected string GetBrowsePurview(object browsePurview)
        {
            switch (browsePurview.ToString())
            {
                case "9999":
                    return "�ο�";
                case "999":
                    return "ע���û�";
                case "99":
                    return "�շ��û�";
                case "9":
                    return "VIP�û�";
                case "5":
                    return "����Ա";
                default:
                    return "δ����";
            }//AddPurview
        }


        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = "(" + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString()+")";
            }
        }

        protected void lbtnIsAuditing_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            Pbzx.BLL.PBnet_SoftClass.ChangeAudit(id, "BitIsElite");
            BindData();
        }

        protected void lbtnBitComment_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            Pbzx.BLL.PBnet_SoftClass.ChangeAudit(id, "pb_ShowOnTop");
            BindData();
        }

    }
}
