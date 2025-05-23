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
using Pinble_Market.AppCod;

namespace Pinble_Market
{
    public partial class Market_UserList : System.Web.UI.Page
    {
        Pbzx.BLL.Market_Page get_page = new Pbzx.BLL.Market_Page();
        Pbzx.BLL.Market_CollASAtten collasAtten = new Pbzx.BLL.Market_CollASAtten();
        Pbzx.Model.Market_CollASAtten ModCollasAtten = new Pbzx.Model.Market_CollASAtten();
        DataTable IsResult = new DataTable();
        private string str = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LotteryListBind();

            }
        }

        /// <summary>
        /// �����ݴ���ҳ
        /// ������: zhouwei
        /// ����ʱ��: �޸��� 2010-10-28
        /// </summary>
        public void LotteryListBind()
        {
            //ȡ�����Ļ�ԱID
            string name = Input.Decrypt(Request["id"]);

            Pbzx.BLL.Market_appendItemManager MyBLL = new Pbzx.BLL.Market_appendItemManager();
            StringBuilder str = new StringBuilder();
            str.Append("userid=" + "'" + name + "'");
            //�����Ŀ���ǿ���״̬�Ͳ���ʾ
            str.Append(" and On_off=0");
            string Searchstr = str.ToString();
            string order = "Charge desc";
            int mycount = 0;
            IsResult = MyBLL.GuestGetBySearch(Searchstr, "*", order, Convert.ToInt32(Input.GetCount()), 3, AspNetPager1.CurrentPageIndex, out mycount);
            this.LotteryList.DataSource = IsResult;
            this.LotteryList.DataBind();
            AspNetPagerConfig(mycount);
            if (IsResult == null)
            {
                this.litContent.Text = "<b>��Ǹ��<p/><br/>Ӧ��û���ҵ������������ݼ�¼</b>";
            }
            else
            {
                this.litContent.Text = "";
            }

            //����ID��ȡ�̻�������
            Lab_Name.Text = name.ToString();
            Lab_Num.Text = IsResult.Rows.Count.ToString();

            StringBuilder sb = new StringBuilder();
            sb.Append("appName=" + "'" + name.ToString() + "'");
            sb.Append(" and Mark=1");
            sb.Append(" and Statc=1");

            DataSet ds = collasAtten.Num(sb.ToString());
            if (ds != null)
            {
                //�����ж������ղ�
                Lab_CollNum.Text = ds.Tables[0].Rows.Count > 0 ? ds.Tables[0].Rows.Count.ToString() : "0";
            }
            //����ж����˹�����̻�����Ŀ
            Pbzx.BLL.Market_BuyInfo buyNum = new Pbzx.BLL.Market_BuyInfo();
            DataSet dsbuy = buyNum.GetList("ShopUserID=" + "'"+ name +"'");
            if (dsbuy != null)
            {
                Lab_peopNum.Text = dsbuy.Tables[0].Rows.Count.ToString();
            }

            //�ж����˹�ע��ǰ�̻�
            StringBuilder sba = new StringBuilder();
            sba.Append("appName="+"'"+ name.ToString() +"'");
            sba.Append(" and Mark=2");
            sba.Append(" and Statc=2");
            DataSet dsa = collasAtten.Num(sba.ToString());
            if (dsa != null)
            {
                lab_attNum.Text = dsa.Tables[0].Rows.Count > 0 ? dsa.Tables[0].Rows.Count.ToString() : "0";
            }

        }

        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = Convert.ToInt32(Input.GetCount());
            AspNetPager1.RecordCount = tempCount;
            AddCustomText();
        }
        protected void AddCustomText()
        {
            AspNetPager1.CustomInfoHTML = "�ܼ�<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>��&nbsp;";
            AspNetPager1.CustomInfoHTML += "<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "ҳ</font>";
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            LotteryListBind();
        }

        //�ղ��̻�
        protected void Img_Btn_coll_Click(object sender, ImageClickEventArgs e)
        {
            if (!collasAtten.Exists(Method.Get_UserName, Lab_Name.Text, 2, 1))
            {
                //�ղ��̻�
                ModCollasAtten.appName = Lab_Name.Text;
                ModCollasAtten.Uname = Method.Get_UserName.ToString();
                //mark=1 ��ʶΪ�ղ�
                ModCollasAtten.mark = 1;
                //statc=2 ��ʶΪ�ղػ�Ա
                ModCollasAtten.statc = 2;
                ModCollasAtten.appTime = DateTime.Now.Date;
                if (collasAtten.Add(ModCollasAtten) > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "upScript", "alert('�ղسɹ�')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "upScript", "alert('�ղ�ʧ�ܣ��������ղ�')", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "upScript", "alert('���Ѿ��ղع����̻��������ظ��ղ�')", true);
            }
        }
        /// <summary>
        /// ��ע�̻�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Img_Btn_attention_Click(object sender, ImageClickEventArgs e)
        {
            if (!collasAtten.Exists(Method.Get_UserName, Lab_Name.Text, 2, 2))
            {
                //�ղ��̻�
                ModCollasAtten.appName = Lab_Name.Text;
                ModCollasAtten.Uname = Method.Get_UserName.ToString();
                //mark=1 ��ʶΪ�ղ�
                ModCollasAtten.mark = 2;
                //statc=2 ��ʶΪ�ղػ�Ա
                ModCollasAtten.statc = 2;
                ModCollasAtten.appTime = DateTime.Now.Date;
                if (collasAtten.Add(ModCollasAtten) > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "upScript", "alert('��ע�ɹ�')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "upScript", "alert('��עʧ�ܣ������¹�ע���̻�')", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "upScript", "alert('���Ѿ���ע�����̻��������ظ���ע')", true);
            }

        }


        /// <summary>
        /// �ղ���Ŀ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_Collection_Commend(object sender, CommandEventArgs e)
        {
            loginInfo();
            str = get_page.CollectionItem(Method.Get_UserName.ToString(), e.CommandArgument.ToString());
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "alert('" + str + "')", true);
        }
        /// <summary>
        /// ������Ŀ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_buy_Command(object sender, CommandEventArgs e)
        {
            loginInfo();
            str = get_page.BuyItem(Method.Get_UserName.ToString(), e.CommandArgument.ToString());
            if (str == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "alert('���ѹ��������Ŀ��')", true);
            }
            else
            {
                Page.RegisterStartupScript("upscript", "<script>window.open('" + str + "')</script>");
            }
        }
        /// <summary>
        /// ��ע��Ŀ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_Attention_Command(object sender, CommandEventArgs e)
        {
            loginInfo();
            str = get_page.AttentionItem(Method.Get_UserName.ToString(), e.CommandArgument.ToString());
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "alert('" + str + "')", true);
        }
        protected void LotteryList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Pbzx.BLL.Market_appendItemManager app = new Pbzx.BLL.Market_appendItemManager();
            Pbzx.Model.Market_appendItem appMod = new Pbzx.Model.Market_appendItem();
            Pbzx.BLL.Market_Page get_page = new Pbzx.BLL.Market_Page();
            //ȡ�����Ļ�ԱID
            string userName = Input.Decrypt(Request["id"]);
            //��ȡ�û��������е���Ŀ
            foreach (RepeaterItem RI in this.LotteryList.Items)
            {
                if (RI.ItemType != ListItemType.Header && RI.ItemType != ListItemType.Footer)
                {
                    ////��ѯ��������Ŀ
                    appMod = app.GetModel(Convert.ToInt32(IsResult.Rows[RI.ItemIndex]["appendId"]));
                    LinkButton Btn_buy = RI.FindControl("Btn_buy") as LinkButton;
                    Label lab_price = RI.FindControl("lab_price") as Label;
                    if (appMod.Charge == 0)
                    {
                        lab_price.Text = "<font color='red'>�����Ŀ</font>";
                        Btn_buy.Visible = false;
                    }
                    Label lab_new = RI.FindControl("lab_new") as Label;
                    Label lab_newGut = RI.FindControl("lab_newGut") as Label;
                    DataSet get_ds = get_page.Market_GetNum("top 1 ExpectNum,Content,itemidentity,itemnumber", "appendID=" + Convert.ToInt32(IsResult.Rows[RI.ItemIndex]["appendId"]) + " order by ExpectNum desc");
                    if (get_ds.Tables[0].Rows.Count > 0 && get_ds.Tables[0].Rows[0][0].ToString()!="")
                    {
                        if (Convert.ToInt32(get_ds.Tables[0].Rows[0]["itemidentity"]) == 0)
                        {
                            lab_new.Text = get_ds.Tables[0].Rows[0][0].ToString();
                            lab_newGut.Text = "���ţ�<font color='red'> " + get_ds.Tables[0].Rows[0]["Content"].ToString() + "</font>";
                        }
                        else
                        {
                            lab_new.Text = get_ds.Tables[0].Rows[0][0].ToString();
                            lab_newGut.Text = "ɱ�ţ�<font color='red'> " + get_ds.Tables[0].Rows[0]["Content"].ToString() + "</font>";
                        }
                    }
                    else
                    {
                        lab_new.Text = "";
                        lab_newGut.Text = "";
                    }
                }
            }

        }
        private void loginInfo()
        {
            //�ж��û��Ƿ��¼
            if (Method.Get_UserName.ToString() == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "<script type='text/javascript' language='javascript' > if (confirm('���ȵ�¼��վ��')){ parent.mainFrame.location.href='../login.aspx';}else{ history.go(-1);}</script>", false);
            }
        }

    }
}
