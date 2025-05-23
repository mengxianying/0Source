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
    public partial class ProductDeleted : AdminBasic
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
            Pbzx.BLL.PBnet_Product productBLL = new Pbzx.BLL.PBnet_Product();
            StringBuilder bu = new StringBuilder();
            bu.Append(" 1=1 and pb_Deleted=1 ");
            bu.Append(this.AddParameter());
            string Searchstr = bu.ToString();
            string order = "countid asc";
            int myCount = 0;

            DataTable lsResult = productBLL.GuestGetBySearch(Searchstr, "*", order, WebInit.webBaseConfig.WebPageNum, 3, AspNetPager1.CurrentPageIndex, out myCount);

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


        /// <summary>
        /// �õ��������
        /// </summary>
        /// <param name="hits">���ش���</param>
        /// <returns></returns>
        protected string GetFlag(string strHits)
        {
            int hits = int.Parse(strHits);
            string flag = "";
            if (hits < WebInit.webBaseConfig.HitsOfHot / 5)
            {
                flag = "��";
            }
            else if (hits <= WebInit.webBaseConfig.HitsOfHot)
            {
                flag = "��";
            }
            else if (hits <= WebInit.webBaseConfig.HitsOfHot * 2)
            {
                flag = "��";
            }
            else
            {
                flag = "��";
            }
            return flag;
        }

        protected void lbtnAduting_Command(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            Pbzx.BLL.PBnet_Product.ChangeAudit(id, "pb_Passed");
            BindData();
        }

        protected void lbtnDel_Command(object sender, CommandEventArgs e)
        {

            Pbzx.BLL.PBnet_Product produtBLL = new Pbzx.BLL.PBnet_Product();
            int id = int.Parse(e.CommandArgument.ToString());
            
            Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("ɾ��", "ɾ����Ʒ[" + produtBLL.GetModel(id).pb_SoftName + "].");
            produtBLL.Delete(id);
            ClientScript.RegisterStartupScript(this.GetType(), "ok", JS.Alert("ɾ���ɹ���."));
           
            BindData();
        }

        protected void lbtnPb_OnTop_Command(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            Pbzx.BLL.PBnet_Product.ChangeAudit(id, "pb_OnTop");
            BindData();
        }

        protected void lbtnPb_Elite_Command(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            Pbzx.BLL.PBnet_Product.ChangeAudit(id, "pb_Deleted");
            BindData();
        }

        /// <summary>
        /// ����url��ֵ��ѯ
        /// </summary>
        /// <returns></returns>
        private string AddParameter()
        {
            StringBuilder bu = new StringBuilder();

            //�������
            if (!string.IsNullOrEmpty(Request["softName"]))
            {
                bu.Append(" and pb_SoftName like '%" + Request["softName"].Trim() + "%' ");
            }

            //������
            if (!string.IsNullOrEmpty(Request["softClass"]))
            {
                bu.Append(" and pb_ClassID='" + Request["softClass"] + "' ");
            }

            //������
            if (!string.IsNullOrEmpty(Request["SoftVersion"]))
            {
                bu.Append(" and pb_TypeName='" + Request["SoftVersion"] + "' ");
            }




            //ʱ���ѯ
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

        protected void MyGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        { }

        protected void btnManySH_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_Product produtBLL = new Pbzx.BLL.PBnet_Product();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int del = produtBLL.BatchUpdate(str, "pb_Deleted", false);
            if (del > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("��ԭ", "��ԭ��Ʒ[" + str + "]");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("����ԭ��" + del + "����Ʒ��¼.", "ProductDeleted.aspx"));
            }
            BindData();
        }

        protected void btnGD_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_Product produtBLL = new Pbzx.BLL.PBnet_Product();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int del = produtBLL.ExecuteBySql("update  PBnet_Product set pb_Deleted=0   WHERE pb_Deleted=1 ");
            if (del > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("��ԭ", "��ԭ������Ʒ[" + str + "]");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("����ԭ��" + del + "����¼.", "ProductDeleted.aspx"));
            }
            BindData();

        }

        protected void btnTJ_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_Product produtBLL = new Pbzx.BLL.PBnet_Product();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int del = produtBLL.BatchDel(str);
            if (del > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("����ɾ��", "����ɾ����Ʒ[" + str + "]");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("������ɾ����" + del + "����Ʒ��¼.", "ProductDeleted.aspx"));
            }
            BindData();
        }



        protected void btnNotIndex_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_Product produtBLL = new Pbzx.BLL.PBnet_Product();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int del = produtBLL.ExecuteBySql("DELETE FROM PBnet_Product WHERE pb_Deleted=1 ");
            if (del > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("����ɾ��", "����ɾ����Ʒ[" + str + "]");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("������ɾ����" + del + "����Ʒ��¼.", "ProductDeleted.aspx"));
            }
            BindData();
        }


        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                e.Row.Cells[1].Text = "(" + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString() + ")";
            }
        }
    }
}
