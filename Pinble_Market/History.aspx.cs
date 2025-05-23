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

namespace Pinble_Market
{
    public partial class History : System.Web.UI.Page
    {
        Pbzx.BLL.Market_Page get_page = new Pbzx.BLL.Market_Page();
        private int rowCount = 0;
        private string str = "";
        DataTable IsResult = new DataTable();
        private string num = "";
        public string NvarName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMyGridView();
            }
        }
        /// <summary>
        /// ������
        /// </summary>
        public void BindMyGridView()
        {

            string lottery = Input.Decrypt(Request["lottery"]);
            string name = Input.Decrypt(Request["name"]);
            string user = Input.Decrypt(Request["user"]);
            //����
            lab_NvarName.Text = lottery;
            NvarName =Pbzx.Common.Input.Encrypt(lottery);
            //����
            lab_TypeName.Text = name;
            lab_username.Text = user;
            //��ȡ����һ��
            // localhost.WebService1 get_web = new Pinble_Market.WebService1();
            Pinble_Market.admin.WebService1 get_web = new Pinble_Market.admin.WebService1();
            num = get_web.lotteryNum(lottery);

            StringBuilder strBud = new StringBuilder();
            strBud.Append("NvarName=" + "'" + lottery + "'");
            strBud.Append(" and TypeName=" + "'" + name + "'");
            strBud.Append(" and UserId=" + "'" + user + "'");
            strBud.Append(" and ExpectNum is not null");
            string Searchstr = strBud.ToString();
            string order = "ExpectNum desc";
            int mycount = 0;
            IsResult = get_page.GuestGetBySearch(Searchstr, "NvarName,TypeName,itemradio,ExpectNum,Content,UserId,itemidentity,Charge,appendId,Price,itemnumber", order, Convert.ToInt32(Input.GetCount()), 3, AspNetPager1.CurrentPageIndex, out mycount);
            myGridView.DataSource = IsResult;
            myGridView.DataBind();

            AspNetPagerConfig(mycount);
            if (IsResult == null || IsResult.Rows.Count == 0)
            {
                AspNetPager1.Visible = false;
                Btn_buy.Visible = false;
                this.litContent.Text = "<b>��Ǹ��Ӧ��û���ҵ������������ݼ�¼</b>";
            }
            else
            {
                this.litContent.Text = "";
                //�ж��Ƿ������
                if (Convert.ToInt32(IsResult.Rows[0]["Charge"]) == 0)
                {
                    //��ѵľ�û�й���ť
                    Btn_buy.Visible = false;
                    Btn_Attention.CommandArgument = IsResult.Rows[0]["appendId"].ToString();
                    Btn_Collection.CommandArgument = IsResult.Rows[0]["appendId"].ToString();
                    lab_price.Text = "<font color='red'>���</fond>";
                }
                else
                {
                    Btn_buy.CommandArgument = IsResult.Rows[0]["appendId"].ToString();
                    Btn_Attention.CommandArgument = IsResult.Rows[0]["appendId"].ToString();
                    Btn_Collection.CommandArgument = IsResult.Rows[0]["appendId"].ToString();
                    lab_price.Text = IsResult.Rows[0]["Price"].ToString().Split('.')[0] + "���/��";
                }
            }
            rowCount = IsResult.Rows.Count;
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
            BindMyGridView();
        }

        protected void myGridView_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem RI in this.myGridView.Items)
            {
                if (RI.ItemType != ListItemType.Header && RI.ItemType != ListItemType.Footer)
                {
                    Label lab_viscera = RI.FindControl("lab_viscera") as Label;
                    if (Convert.ToInt32(IsResult.Rows[0]["Charge"]) == 0)
                    {
                        //��ѵ���ʾȫ����Ϣ
                        if (Convert.ToInt32(IsResult.Rows[RI.ItemIndex]["itemidentity"]) == 0)
                        {
                            lab_viscera.Text = "����<font color='red'> " + IsResult.Rows[RI.ItemIndex]["Content"].ToString() + "</font>";
                        }
                        else
                        {
                            lab_viscera.Text = "ɱ��<font color='red'>" + IsResult.Rows[RI.ItemIndex]["Content"].ToString() + "</font>";
                        }
                        if (IsResult.Rows[RI.ItemIndex]["Content"].ToString() == "" || IsResult.Rows[RI.ItemIndex]["Content"] == null)
                        {
                            lab_viscera.Text = "δ����";
                        }
                    }
                    else
                    {
                        DateTime date = new DateTime();
                        DataSet ds = get_page.Market_GetNum("ExpectNum", "appendId=" + Convert.ToInt32(IsResult.Rows[0]["appendId"]) + " order by ExpectNum desc");
                        if (ds != null && ds.Tables[0].Rows[RI.ItemIndex]["ExpectNum"].ToString() == num.ToString())
                        {
                            //����������һ�� ��ô�շ���Ŀ���ܣ� 
                            if (RI.ItemIndex == 0 && date.Minute < 30 && date.Hour < 21)
                            {
                                lab_viscera.Text = "����";
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(IsResult.Rows[RI.ItemIndex]["itemidentity"]) == 0)
                            {
                                lab_viscera.Text = "����<font color='red'> " + IsResult.Rows[RI.ItemIndex]["Content"].ToString() + "</font>";
                            }
                            else
                            {
                                lab_viscera.Text = "ɱ��<font color='red'>" + IsResult.Rows[RI.ItemIndex]["Content"].ToString() + "</font>";
                            }
                            if (IsResult.Rows[RI.ItemIndex]["Content"].ToString() == "" || IsResult.Rows[RI.ItemIndex]["Content"] == null)
                            {
                                lab_viscera.Text = "δ����";
                            }
                        }
                    }
                }

            }
        }

        //������Ŀ
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
        //��ע
        protected void Btn_Attention_Command(object sender, CommandEventArgs e)
        {
            loginInfo();
            str = get_page.AttentionItem(Method.Get_UserName.ToString(), e.CommandArgument.ToString());
            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "alert('" + str + "')", true);
            ClientScript.RegisterStartupScript(this.GetType(), "up", "<script>alert('" + str + "')</script>");
        }
        /// <summary>
        /// �ղ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_Collection_Commend(object sender, CommandEventArgs e)
        {
            loginInfo();
            str = get_page.CollectionItem(Method.Get_UserName.ToString(), e.CommandArgument.ToString());
            ClientScript.RegisterStartupScript(this.GetType(), "up", "<script>alert('" + str + "')</script>");
        }
        /// <summary>
        /// �ж��û��Ƿ��¼
        /// </summary>
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
