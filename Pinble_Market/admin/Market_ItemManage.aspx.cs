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
using Pbzx.BLL;
using Pbzx.Model;
using Pbzx.Common;
using Pinble_Market.AppCod;
namespace Pinble_Market.admin
{
    public partial class Market_ItemManage : System.Web.UI.Page
    {
        Market_appendItemManager appenditem = new Market_appendItemManager();
        Market_TypeManager marktype = new Market_TypeManager();
        Pbzx.BLL.PBnet_UserTable usertype = new Pbzx.BLL.PBnet_UserTable();
        Pbzx.BLL.PBnet_LotteryMenu lotterymenu = new Pbzx.BLL.PBnet_LotteryMenu();
        Pbzx.BLL.Market_BuyInfo byinfomanager = new Pbzx.BLL.Market_BuyInfo();
        Pbzx.BLL.Market_NumManager numnamage = new Pbzx.BLL.Market_NumManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Method.Get_UserName.ToString() == "0")
            {
                Response.Write("<script type='text/javascript'>parent.mainFrame.location.href='/login.aspx'</script>");
                Response.End();
                return;
            }
            //�ж��û��Ƿ��¼�Ƿ��Ǹ߼��û�
            if (!WebFunc.CheckIsAdvanceUser(Method.Get_UserName))
            {
                Response.Write("<script type='text/javascript' language='javascript' > if (confirm('ֻ�и߼��û�����ʹ�ô���ܣ�����������')){top.location='/UserCenter/UserRealInfo.aspx';}else{history.go(-1);}</script>");
                Response.End();
                return;


            }

            if (!IsPostBack)
            {
                BindDiv();
            }

        }
        /// <summary>
        /// DIV���ݰ�
        /// </summary>
        private void BindDiv()
        {
            DataTable g_ds = new DataTable();
            StringBuilder sb = new StringBuilder();
            sb.Append("UserId=" + "'" + Method.Get_UserName.ToString() + "' and On_off <>3");
            string Searchstr = sb.ToString();
            string order = "appendid desc";
            int myCount = 0;
            g_ds = appenditem.GuestGetBySearch(Searchstr, "*", order, Convert.ToInt32(Input.GetManageCount()), 3, AspNetPager1.CurrentPageIndex, out myCount);
            myGridView.DataSource = g_ds;
            myGridView.DataKeyNames = new string[] { "appendId" };
            myGridView.DataBind();
            AspNetPagerConfig(myCount);
            if (g_ds == null || g_ds.Rows.Count == 0)
            {
                cb_full.Visible = false;
                btn_delete.Visible = false;
                btn_cancel.Visible = false;
                AspNetPager1.Visible = false;
                litContent.Text = "<font color='blue'>��û���趨�κ���Ŀ�� </font></b>&nbsp;&nbsp;&nbsp;<a href='/ItemEnactment.aspx' target='mainFrame' ><font color='red'>���ھ�ȥ����</font></a>";
            }
            else
            {
                litContent.Visible = false;
            }
        }

        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = Convert.ToInt32(Input.GetManageCount());
            AspNetPager1.RecordCount = tempCount;
            AddCustomText();
        }

        protected void AddCustomText()
        {
            AspNetPager1.CustomInfoHTML = "��<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>��&nbsp;";
            AspNetPager1.CustomInfoHTML += "��ҳ<font color=\"red\"><b>" + myGridView.Rows.Count + "</b></font>��&nbsp;";
            AspNetPager1.CustomInfoHTML += "��ҳ:<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "ҳ</font>";
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindDiv();
        }

        /// <summary>
        /// ��ʽ���շ�����
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string BindSF(object obj)
        {
            if (obj != null)
            {
                if (Convert.ToInt32(obj) == 0)
                {
                    return "���";
                }
                else
                {
                    return "�շ�";
                }
            }
            else
            {
                return "�����쳣";
            }
        }
        /// <summary>
        /// ��ʽ��״̬��ʾ
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string BindZT(object obj)
        {
            if (obj != null)
            {
                if (Convert.ToInt32(obj) == 0)
                {
                    return "<font color='green'>����</font>";
                }
                else if (Convert.ToInt32(obj) == 1)
                {
                    return "<font color='green'>����</font>";
                }
                else
                {
                    return "<font color='red'>�ر�<font>";
                }
            }
            else
            {
                return "�����쳣";
            }
        }
        /// <summary>
        /// �������¼�����ʱ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Gvidlist_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                Market_appendItem model = appenditem.GetModel(Convert.ToInt32(e.CommandArgument));
                if (model != null)
                {
                    //3Ϊ�û�ɾ��
                    model.On_off = 3;

                    if (appenditem.Update(model) > 0)
                    {
                        this.myGridView.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('ɾ���ɹ���');</script>");
                        BindDiv();
                        return;
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('ɾ��ʧ�ܣ�');</script>");

                    }
                }
            }
            else if (e.CommandName == "GB")
            {
                Market_appendItem mark = appenditem.GetModel(Convert.ToInt32(e.CommandArgument));
                mark.On_off = 2;
                appenditem.Update(mark);
                BindDiv();
                return;
            }
            else if (e.CommandName == "SD")
            {
                Market_appendItem mark = appenditem.GetModel(Convert.ToInt32(e.CommandArgument));
                mark.On_off = 1;
                appenditem.Update(mark);
                BindDiv();
                return;
            }
            else if (e.CommandName == "KF")
            {
                Market_appendItem mark = appenditem.GetModel(Convert.ToInt32(e.CommandArgument));
                mark.On_off = 0;
                appenditem.Update(mark);
                BindDiv();
                return;
            }
            else if (e.CommandName == "URL")
            {
                Response.Redirect("ItemEnactment.aspx?itemid=" + e.CommandArgument.ToString());
            }
        }
        /// <summary>
        /// �������а�ʱ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Gvidlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //�ж��Ƿ��շ�
                string fei = (e.Row.Cells[3].FindControl("Label3") as Label).Text;


                if (fei == "�շ�")
                {
                    //��Ϊ�շ���Ŀ����������Ϊ0�����Ƕ����˶����ڣ���������ɾ��
                    //������ĿID
                    string itemid = (e.Row.Cells[9].FindControl("linkbutDelete") as LinkButton).CommandArgument;
                    if (itemid != null && itemid != "")
                    {
                        DataSet ds = byinfomanager.GetList(" issueInfoId='" + itemid + "' and EndTime>= '" + DateTime.Now.ToString() + "' ");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            (e.Row.Cells[9].FindControl("linkbutDelete") as LinkButton).Visible = false;
                        }
                        else
                        {
                            (e.Row.Cells[9].FindControl("linkbutDelete") as LinkButton).Visible = true;
                        }
                    }
                    else
                    {
                        (e.Row.Cells[9].FindControl("linkbutDelete") as LinkButton).Visible = false;
                    }

                }
                else
                {
                    (e.Row.Cells[9].FindControl("linkbutDelete") as LinkButton).Visible = true;
                }

                string kf = (e.Row.Cells[8].FindControl("Label4") as Label).Text;
                if (kf == "<font color='green'>����</font>")
                    (e.Row.Cells[9].FindControl("linkbut1") as LinkButton).Enabled = false;
                else if (kf == "<font color='green'>����</font>")
                    (e.Row.Cells[9].FindControl("linkbut2") as LinkButton).Enabled = false;
                else if (kf == "<font color='red'>�ر�<font>")
                    (e.Row.Cells[9].FindControl("linkbut3") as LinkButton).Enabled = false;

                (e.Row.Cells[9].FindControl("linkbutDelete") as LinkButton).Attributes.Add("onclick", "javascript:return confirm('ȷ��Ҫɾ������Ŀ��');");
                (e.Row.Cells[9].FindControl("linkbut3") as LinkButton).Attributes.Add("onclick", "javascript:return confirm('ȷ����Ҫ�رմ���Ŀ�𣡹رպ�����ֹͣ�Դ���Ŀ�ķ�����');");
            }
        }
        /// <summary>
        /// ���ݸ�ʽ��
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public string TextFormat(object obj, int length)
        {

            string source = obj.ToString();
            if (length <= 0)
            {
                return source;
            }
            else
            {
                int tempLength = Method.GetStrLen(source);
                int charLength = 0;
                int hzLength = 0;

                //string tempResult = "";
                if (tempLength > length)
                {
                    Char[] cc = source.ToCharArray();
                    //int intLen = 0;
                    for (int i = 0; i < cc.Length; i++)
                    {
                        if (Convert.ToInt32(cc[i]) > 255)
                        {
                            hzLength++;

                        }
                        else
                        {
                            charLength++;
                        }

                        if ((hzLength * 2 + charLength) % 2 == 0 && hzLength * 2 + charLength >= length || (hzLength * 2 + charLength) % 2 == 1 && hzLength * 2 + charLength >= length - 1)
                        {
                            break;
                        }
                    }
                    return source.Substring(0, (hzLength + charLength) - 1) + "..";
                }
                else
                {
                    return source;
                }
            }
        }

        protected void Gvidlist_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
        /// <summary>
        /// �༭��ʽ��
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        /// <returns></returns>
        public string zu(object obj, object obj1, object obj2)
        {
            return obj + "," + obj1 + "," + obj2.ToString();
        }

        /// <summary>
        /// ID�Զ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Gvidlist_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex > -1)
            {
                e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1 + (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize);
            }
        }
        //�շ���Ŀ�б�
        protected void lbtn_speakfor_Click(object sender, EventArgs e)
        {
            DataTable g_ds = new DataTable();
            StringBuilder sb = new StringBuilder();
            sb.Append("UserId=" + "'" + Method.Get_UserName.ToString() + "' and On_off <>3" + " and Charge=1");
            string Searchstr = sb.ToString();
            string order = "appendid desc";
            int myCount = 0;
            g_ds = appenditem.GuestGetBySearch(Searchstr, "*", order, WebInit.webBaseConfig.WebPageNum2, 3, AspNetPager1.CurrentPageIndex, out myCount);
            myGridView.DataSource = g_ds;
            myGridView.DataBind();
            AspNetPagerConfig(myCount);
        }
        //�����Ŀ�б�
        protected void lbtn_free_Click(object sender, EventArgs e)
        {
            DataTable g_ds = new DataTable();
            StringBuilder sb = new StringBuilder();
            sb.Append("UserId=" + "'" + Method.Get_UserName.ToString() + "' and On_off <>3" + " and Charge=0");
            string Searchstr = sb.ToString();
            string order = "appendid desc";
            int myCount = 0;
            g_ds = appenditem.GuestGetBySearch(Searchstr, "*", order, WebInit.webBaseConfig.WebPageNum2, 3, AspNetPager1.CurrentPageIndex, out myCount);
            myGridView.DataSource = g_ds;
            myGridView.DataBind();
            AspNetPagerConfig(myCount);
        }
        /// <summary>
        /// �ж��Ƿ񷢲�������һ�ڵ�����
        /// </summary>
        /// obj ����������ͣ��ж��Ƿ񷢲������һ��
        /// obj1 ��ĿID
        /// <returns></returns>
        public string BindNR(object obj, object obj1)
        {
            WebService1 wbs = new WebService1();
            string issus = wbs.lotteryNum(obj.ToString());
            DataSet dst = numnamage.GetList("ExpectNum='" + issus + "' and ItemID='" + obj1.ToString() + "'");
            if (dst.Tables[0].Rows.Count > 0)
            {
                return "<font color='green'>" + issus + " ���ѷ���</font>";
            }
            else
            {
                return "<font color='red'>" + issus + " ��δ����</font>";
            }
        }
        //����
        protected void lbtn_resetTool_Click(object sender, EventArgs e)
        {
            BindDiv();
        }

        //����״̬
        protected void lbtn_open_Click(object sender, EventArgs e)
        {
            DataTable g_ds = new DataTable();
            StringBuilder sb = new StringBuilder();
            sb.Append("UserId=" + "'" + Method.Get_UserName.ToString() + "' and On_off <>3" + " and On_off=0");
            string Searchstr = sb.ToString();
            string order = "appendid desc";
            int myCount = 0;
            g_ds = appenditem.GuestGetBySearch(Searchstr, "*", order, WebInit.webBaseConfig.WebPageNum2, 3, AspNetPager1.CurrentPageIndex, out myCount);
            myGridView.DataSource = g_ds;
            myGridView.DataBind();
            AspNetPagerConfig(myCount);
        }

        //�ر�״̬
        protected void lbtn_close_Click(object sender, EventArgs e)
        {
            DataTable g_ds = new DataTable();
            StringBuilder sb = new StringBuilder();
            sb.Append("UserId=" + "'" + Method.Get_UserName.ToString() + "' and On_off <>3" + " and On_off=2");
            string Searchstr = sb.ToString();
            string order = "appendid desc";
            int myCount = 0;
            g_ds = appenditem.GuestGetBySearch(Searchstr, "*", order, WebInit.webBaseConfig.WebPageNum2, 3, AspNetPager1.CurrentPageIndex, out myCount);
            myGridView.DataSource = g_ds;
            myGridView.DataBind();
            AspNetPagerConfig(myCount);
        }
        //ɾ��ѡ��
        protected void btn_delete_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i <= myGridView.Rows.Count - 1; i++)
            //{
            //    CheckBox cb = (CheckBox)myGridView.Rows[i].FindControl("cb");
            //    if (cb.Checked == true)
            //    {
            //        Market_appendItem model = appenditem.GetModel(Convert.ToInt32(myGridView.DataKeys[i].Value));
            //        if (model != null)
            //        {
            //            //3Ϊ�û�ɾ��
            //            model.On_off = 3;

            //            if (appenditem.Update(model) > 0)
            //            {
            //                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('ɾ���ɹ���');</script>");
            //                BindDiv();
            //                return;
            //            }
            //            else
            //            {
            //                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('ɾ��ʧ�ܣ�');</script>");

            //            }
            //        }
            //    }
            //}

        }
        //ȡ��ɾ��
        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            cb_full.Checked = false;
            for (int i = 0; i <= myGridView.Rows.Count - 1; i++)
            {
                CheckBox cb = (CheckBox)myGridView.Rows[i].FindControl("cb");
                cb.Checked = false;
            }

        }
        //ȫѡ�¼�
        protected void cb_full_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i <= myGridView.Rows.Count - 1; i++)
            {
                CheckBox cb = (CheckBox)myGridView.Rows[i].FindControl("cb");
                if (cb_full.Checked == true)
                {
                    cb.Checked = true;
                }
                else
                {
                    cb.Checked = false;
                }
            }
        }

    }
}
