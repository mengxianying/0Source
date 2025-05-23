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
    public partial class Soft_Manage : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MyGridView.PageSize = WebInit.webBaseConfig.WebPageNum;
                BindData();
            }
        }

        private void BindData()
        {
            Pbzx.BLL.PBnet_Soft softBLL = new Pbzx.BLL.PBnet_Soft();
            StringBuilder bu = new StringBuilder();
            bu.Append(" 1=1  and pb_Deleted=0 ");
            bu.Append(this.AddParameter());
         //   bu.Append(" and IntSetting=1 ");
            ///////////////////////////////////////////////////////////////////////////////////
            string Searchstr = bu.ToString();
            string order = "pb_UpdateTime desc ";
            int myCount = 0;

            DataTable lsResult = softBLL.GuestGetBySearch(Searchstr, "*", order, WebInit.webBaseConfig.WebPageNum, 3, AspNetPager1.CurrentPageIndex, out myCount);

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
            Pbzx.BLL.PBnet_Soft.ChangeAudit(id, "pb_Passed");
            BindData();
        }
        protected void lbtnPb_OnTop_Command(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            Pbzx.BLL.PBnet_Soft.ChangeAudit(id, "pb_OnTop");
            BindData();
        }

        protected void lbtnDel_Command(object sender, CommandEventArgs e)
        {

            Pbzx.BLL.PBnet_Soft softBLL = new Pbzx.BLL.PBnet_Soft();
            int id = int.Parse(e.CommandArgument.ToString());
            Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("ɾ��", "ɾ����Ƶ���[" + softBLL.GetModel(id).PBnet_SoftName + "].");
            ClientScript.RegisterStartupScript(this.GetType(), "ok", JS.Alert("ɾ���ɹ���."));
            softBLL.BatchUpdate(id.ToString(), "pb_Deleted", true);
            BindData();
        }



        protected void lbtnPb_Elite_Command(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            Pbzx.BLL.PBnet_Soft.ChangeAudit(id, "pb_indexshow");
            BindData();
        }

        /// <summary>
        /// ����url��ֵ��ѯ
        /// </summary>
        /// <returns></returns>
        private string AddParameter()
        {
            StringBuilder bu = new StringBuilder();

            //if (!string.IsNullOrEmpty(Request["SoftVersion"]))
            //{
            //    bu.Append(" and pb_TypeName =" + Request["SoftVersion"] + " ");
            //}

            if (!string.IsNullOrEmpty(Request["softClass"]))
            {
                bu.Append(" and pb_ClassID =" + Request["softClass"] + " ");
            }
            if (!string.IsNullOrEmpty(Request["regedit"]))
            {
                bu.Append(" and pb_UpdateTime between dateAdd(day," + this.Request["regedit"].ToString() + ",getdate()) and getdate()  ");
            }
            if (!string.IsNullOrEmpty(Request["softName"]))
            {
                bu.Append(" and PBnet_SoftName like '%" + Input.FilterAll(Request["softName"]) + "%' ");
            }

            //ʱ���ѯ
            if (!string.IsNullOrEmpty(Request["dateType"]))
            {
                if (!string.IsNullOrEmpty(Request["strCreateTime1"]) && !string.IsNullOrEmpty(Request["strCreateTime2"]))
                {
                    if (Request["dateType"] == "1")
                    {
                        bu.Append(" and pb_UpdateTime between '" + Request["strCreateTime1"] + "' and '" + Request["strCreateTime2"] + " 23:59:59'  ");
                    }
                    else if (Request["dateType"] == "2")
                    {
                        bu.Append(" and pb_LastHitTime between '" + Request["strCreateTime1"] + "' and '" + Request["strCreateTime2"] + " 23:59:59'  ");
                    }
                }
            }

            return bu.ToString();

        }

        protected void MyGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            IsAuthority(3);
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            IsAuthority(1);
           Response.Redirect("Soft_Editor.aspx", true);
        }

        protected void btnManySH_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_Soft produtBLL = new Pbzx.BLL.PBnet_Soft();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int del = produtBLL.BatchUpdate(str, "pb_Passed", true);
            if (del > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("����", "�������[" + str + "]");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("��������" + del + "����¼.", "Soft_Manage.aspx"));
            }
            BindData();
        }

        protected void btnGD_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_Soft produtBLL = new Pbzx.BLL.PBnet_Soft();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int del = produtBLL.BatchUpdate(str, "pb_Passed", false);
            if (del > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("ȡ������", "ȡ���������[" + str + "]");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("��ȡ��������" + del + "�������¼.", "Soft_Manage.aspx"));
            }
            BindData();
        }

        protected void btnTJ_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_Soft produtBLL = new Pbzx.BLL.PBnet_Soft();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int del = produtBLL.BatchUpdate(str, "pb_indexshow", true);
            if (del > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("��ҳ��ʾ", "��ҳ��ʾ���[" + str + "]");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("��������ҳ��ʾ��" + del + "�������¼.", "Soft_Manage.aspx"));
            }
            BindData();
        }

        protected void btnOnTop_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_Soft produtBLL = new Pbzx.BLL.PBnet_Soft();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int del = produtBLL.BatchUpdate(str, "pb_OnTop", true);
            if (del > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("�̶�", "�̶�[" + str + "]");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("�����ù̶���" + del + "����¼.", "Soft_Manage.aspx"));
            }
            BindData();
        }



        protected void btnNotOnTop_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_Soft produtBLL = new Pbzx.BLL.PBnet_Soft();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int del = produtBLL.BatchUpdate(str, "pb_OnTop", false);
            if (del > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("ȡ���̶�", "ȡ���̶�[" + str + "]");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("��ȡ���̶���" + del + "����¼.", "Soft_Manage.aspx"));
            }
            BindData();
        }

        protected void btnNotIndex_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_Soft produtBLL = new Pbzx.BLL.PBnet_Soft();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int del = produtBLL.BatchUpdate(str, "pb_indexshow", false);
            if (del > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("ȡ����ҳ��ʾ", "ȡ����ҳ��ʾ���[" + str + "]");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("��ȡ����ҳ��ʾ��" + del + "�������¼.", "Soft_Manage.aspx"));
            }
            BindData();
        }

        protected void lbtnCreate_Click(object sender, EventArgs e)
        {            
            WebFunc.RefPagesByPageName("��ҳ");
            WebFunc.RefPagesByPageName("�����Ƕҳ��");
            WebFunc.RefPagesByPageName("�°������Ƕҳ��"); //�°汾
        }

        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                string href = "<a href='Soft_Editor.aspx?ID=" + e.Row.Cells[1].Text + "'>";
                e.Row.Cells[1].Text = href + "(" + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString() + ")</a>";
            }
        }
    }
}
