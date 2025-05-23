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

namespace Pinble_Chipped
{
    public partial class Attention : System.Web.UI.Page
    {
        Pbzx.BLL.Chipped_Attention get_bll = new Pbzx.BLL.Chipped_Attention();
        DataTable My_IsResult = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rep_AttentionBind();
            }
        }
        /// <summary>
        /// ������ע���б�
        /// </summary>
        public void rep_AttentionBind()
        {
            string name = Request["name"].ToString();

            StringBuilder strB = new StringBuilder();
            strB.Append("AName=" + "'" + name + "'");
            string Searchstr = strB.ToString();
            string order = "id desc";
            int mycount = 0;
            My_IsResult = get_bll.GuestGetBySearchChipped(Searchstr, "*", order, 20, 3, AspNetPager1.CurrentPageIndex, out mycount);
           
            if (My_IsResult != null && My_IsResult.Rows.Count>0)
            {
                this.Repeater_My.DataSource = My_IsResult;
                this.Repeater_My.DataBind();
                litContent.Text = "";
            }
            else
            {
                litContent.Text = "����ʱû�з������������Ϣ";
            }
            AspNetPagerConfig1(mycount);
        }
        //��ҳ
        protected void AspNetPagerConfig1(int tempCount)
        {
            AspNetPager1.PageSize = 20;
            AspNetPager1.RecordCount = tempCount;
            AddCustomText1();
        }
        protected void AddCustomText1()
        {
            AspNetPager1.CustomInfoHTML = "�ܼ�<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>��&nbsp;";
            AspNetPager1.CustomInfoHTML += "<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "ҳ</font>";
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            rep_AttentionBind();
        }

        //���¼�
        protected void Repeater_My_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Pbzx.BLL.Chipped_LaunchInfoManage get_lm = new Pbzx.BLL.Chipped_LaunchInfoManage();
            foreach (RepeaterItem RI in this.Repeater_My.Items)
            {
                Label lab_lottery = RI.FindControl("lab_lottery") as Label;

                Label lab_ExpectNum = RI.FindControl("lab_ExpectNum") as Label;

                Label lab_money = RI.FindControl("lab_money") as Label;

                //��ȡ��ע��Ա���·�������Ϣ
                DataSet ds = get_lm.GetList(1, "UserName=" + "'" + My_IsResult.Rows[RI.ItemIndex]["Attention"].ToString() + "'", "LaunchTime desc");

                if (Convert.ToInt32(ds.Tables[0].Rows[0]["playName"]) == 1)
                { 
                    //3D
                    lab_lottery.Text = "����3D";
                }
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["playName"]) == 3)
                {
                    //˫ɫ��
                    lab_lottery.Text = "˫ɫ��";
                }
                lab_ExpectNum.Text = ds.Tables[0].Rows[0]["ExpectNum"].ToString();
                lab_money.Text = ds.Tables[0].Rows[0]["AtotalMoney"].ToString();

            }
        }
        //����ע������
        public void BAttention()
        {
            //string name = Request["name"].ToString();
            string name = "userzhou";
            DataSet ds = get_bll.GetList("Attention="+"'"+ name +"'");
            lab_UserNum.Text = ds.Tables[0].Rows.Count.ToString();
        }
    }
}
