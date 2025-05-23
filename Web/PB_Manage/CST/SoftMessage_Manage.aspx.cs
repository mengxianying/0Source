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
    public partial class SoftMessage_Manage : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Load�����ݳ�ʼ��
                MyGridView.PageSize = WebInit.webBaseConfig.WebPageNum;
                if (ViewState["order"] == null)
                {
                    ViewState["order"] = "MsgTime";
                }
                if (ViewState["isDesc"] == null)
                {
                    ViewState["isDesc"] = true;
                }
                //������
                BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
            }
        }

        /// <summary>
        /// ����ҳ�ؼ� ÿҳ��ʾ������������
        /// </summary>
        /// <param name="tempCount"></param>
        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = WebInit.webBaseConfig.WebPageNum;
            AspNetPager1.RecordCount = tempCount;
            //��������ķ���
            AddCustomText();
        }
        /// <summary>
        /// �˷�����Ҫ������ʾ
        /// </summary>
        protected void AddCustomText()
        {
            AspNetPager1.CustomInfoHTML = "��<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>��&nbsp;";
            AspNetPager1.CustomInfoHTML += "��ҳ<font color=\"red\"><b>" + MyGridView.Rows.Count + "</b></font>��&nbsp;";
            AspNetPager1.CustomInfoHTML += "��ҳ:<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "ҳ</font>";
        }
        /// <summary>
        /// ����ҳ�ؼ� changed��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }


        /// <summary>
        /// ����url��ֵ��ѯ
        /// </summary>
        /// <returns></returns>
        private string AddParameter()
        {
            StringBuilder bu = new StringBuilder();


            if (!string.IsNullOrEmpty(Request["strTitleSerch"]))
            {
                bu.Append(" and MsgTitle like '%" + Request["strTitleSerch"] + "%' ");
            }

            if (!string.IsNullOrEmpty(Request["dateType"]))
            {
                if (!string.IsNullOrEmpty(Request["strCreateTime1"]) && !string.IsNullOrEmpty(Request["strCreateTime2"]))
                {
                    if (Request["dateType"] == "1")
                    {
                        bu.Append(" and MsgTime between '" + Request["strCreateTime1"] + "' and '" + Request["strCreateTime2"] + " 23:59:59'  ");
                    }
                    else if (Request["dateType"] == "2")
                    {
                        bu.Append(" and PostTime1 between '" + Request["strCreateTime1"] + "' and '" + Request["strCreateTime2"] + " 23:59:59'  ");
                    }
                    else if (Request["dateType"] == "3")
                    {
                        bu.Append(" and PostTime2 between '" + Request["strCreateTime1"] + "' and '" + Request["strCreateTime2"] + " 23:59:59'  ");
                    }
                }
            }
            return bu.ToString();

        }

        /// <summary>
        /// �������¼�����ʱ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnDel_Command(object sender, CommandEventArgs e)
        {
            //�ȵõ�Ҫɾ����ID
            int id = int.Parse(e.CommandArgument.ToString());

            Pbzx.BLL.CstMessage msgBLL = new Pbzx.BLL.CstMessage();
            //����ID�ҳ���ʵ�����
            Pbzx.Model.CstMessage msgModel = msgBLL.GetModel(id);
            //������ı���
            string nvarname = msgModel.MsgTitle.ToString();
            //ִ��ɾ��
            if (msgBLL.Delete(id))
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("ɾ��", "ɾ�������Ϣ[" + nvarname + "]");

                JS.Alert("ɾ���ɹ���");
            }
            else
            {
                JS.Alert("ɾ��ʧ�ܣ�");
            }
            //���°󶨵�ǰ����
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }


        protected string ChkSoftType(object st, object it)
        {
            Pbzx.BLL.CstSoftware softBLL = new Pbzx.BLL.CstSoftware();
            string[] result = softBLL.Chksettype(st, it);
            return result[0] + "(" + result[1] + ")";
        }
        /// <summary>
        /// �����ݳ�������ʱ��������ǰ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MyGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            ViewState["order"] = e.SortExpression.ToString(); //�õ�Ҫ������ֶ�

            if ((bool)ViewState["isDesc"])
            {
                ViewState["isDesc"] = false;
            }
            else
            {
                ViewState["isDesc"] = true;
            }
            //���°�����
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }

        /// <summary>
        /// ���ݰ�
        /// </summary>
        /// <param name="column">�����Ӧ����</param>
        /// <param name="isDesc">�Ƿ񰴽�������������ture Ϊ desc false Ϊ asc</param>
        private void BindData(string column, bool isDesc)
        {
            //new һ��Bll����
            Pbzx.BLL.CstMessage messageBLL = new Pbzx.BLL.CstMessage();

            //�ַ���ƴ��
            StringBuilder bu = new StringBuilder();
            bu.Append(" 1=1 ");
            bu.Append(this.AddParameter());
            string Searchstr = bu.ToString();
            string order = column;
            int myCount = 0;

            //�ж�����ʽ
            if (isDesc)
            {
                order += " desc ";
            }
            else
            {
                order += " asc ";
            }

            //���˲�����������Ӧ������
            DataTable lsResult = messageBLL.GuestGetBySearch(Searchstr, "ID,MsgSender,MsgLevel,MsgType,MsgCategory,MsgSend,MsgTitle,MsgTime,MsgContent,MsgST,MsgPV,MsgIT,LoginCount,TotalCount,LLTime,PostTime1,PostTime2,UserID", order, WebInit.webBaseConfig.WebPageNum, 3, AspNetPager1.CurrentPageIndex, out myCount);
            //�������������ݰ󶨵�GiveView
            this.MyGridView.DataSource = lsResult;
            this.MyGridView.DataBind();
            //��aspnetpage�ؼ����ݵ�������
            AspNetPagerConfig(myCount);
            //����ѯ����Ϊ��ʱ���������Ϣ��ʾ
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
        /// ��lbtn���������¼�ʱ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnAduting_Command(object sender, CommandEventArgs e)
        {
            //�Ȼ��ID
            int id = int.Parse(e.CommandArgument.ToString());

            Pbzx.BLL.CstMessage cstMSGBLL = new Pbzx.BLL.CstMessage();
            //����ҵ��㷽���ı䵱ǰ״̬
            cstMSGBLL.ChangeAudit(id, "MsgSend");
            //Ȼ�����°󶨵�ǰ����
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }

        /// <summary>
        /// ������޸�ʱ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("SoftMessage_Editor.aspx");
        }
        /// <summary>
        /// �����а��¼��Ժ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //���ַ�ʽ���Ǻܺã�
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                string href = "<a href='SoftMessage_Editor.aspx?ID=" + e.Row.Cells[0].Text + "'>";
                //����һ�а�����
                e.Row.Cells[0].Text = href + "(" + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString() + ")</a>";
            }

            //��õķ�ʽ�ǣ����ж��Ƿ��������У�
            //if(e.Row.RowType==DataControlRowType.DataRow){
            //Ȼ��������д����
            // }
        }
    }
}
