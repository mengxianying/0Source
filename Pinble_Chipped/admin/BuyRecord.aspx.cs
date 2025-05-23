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
using Pbzx.BLL;
using System.Drawing;

namespace Pinble_Chipped.admin
{
    public partial class BuyRecord : System.Web.UI.Page
    {
        Pbzx.BLL.publicMethod get_pub = new Pbzx.BLL.publicMethod();
        DataTable IResult = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Method.Get_UserName.ToString() == "0")
            {
                Response.Write("<script type='text/javascript'>parent.mainFrame.location.href ='/LoginPage.aspx'</script>");
                //Response.Write("<script type='text/javascript'>window.top.location.href ='/LoginPage.aspx'</script>");
                Response.End();
                return;
            }
            if (!IsPostBack)
            {
                BindMy_GridView();
            }
        }


        //�������
        protected void myGridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex > -1)
            {
                if (AspNetPager1.PageCount > 1)
                {
                    e.Row.Cells[0].Text = Convert.ToString(e.Row.RowIndex + 1 + (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize);
                }
                else
                {
                    e.Row.Cells[0].Text = Convert.ToString(e.Row.RowIndex + 1);
                }
            }
        }
        /// <summary>
        /// ���ҵĹ��ʼ�¼
        /// </summary>
        public void BindMy_GridView()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("ChippedName=" + "'" + Method.Get_UserName.ToString() + "'");
            string Searchstr = sb.ToString();
            string order = "chippedTime desc";
            int myCount = 0;
            IResult = get_pub.v_BuyRecord(Searchstr, "*", order, 30, 3, AspNetPager1.CurrentPageIndex, out myCount);
            if (IResult != null && IResult.Rows.Count > 0)
            {
                myGridView.DataSource = IResult;
               
                myGridView.DataBind();
            }
            else
            {
                
                AspNetPager1.Visible = false;
            }
            AspNetPagerConfig(myCount);

        }
        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = 30;
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
            BindMy_GridView();
        }

        //���¼�
        protected void myGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int count = this.myGridView.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                //��������
                Label lab_lotteryName = this.myGridView.Rows[i].Cells[0].FindControl("lab_lotteryName") as Label;
                //����
                Label lab_plan = this.myGridView.Rows[i].Cells[0].FindControl("lab_plan") as Label;
                //����״̬
                Label lab_SState = this.myGridView.Rows[i].Cells[0].FindControl("lab_SState") as Label;
                //����
                Label lab_bonus = this.myGridView.Rows[i].Cells[0].FindControl("lab_bonus") as Label;

                //���� ������ʾ
                Label lan_playName = this.myGridView.Rows[i].Cells[0].FindControl("lan_playName") as Label;

                //�Ϲ��Ľ��  
                Label lab_subscriptyion = this.myGridView.Rows[i].Cells[0].FindControl("lab_subscriptyion") as Label;
                //����ʱ���ݵļ۸�
                decimal n_Single = Convert.ToDecimal(IResult.Rows[i]["AtotalMoney"]) / Convert.ToInt32(IResult.Rows[i]["Share"]);
                //�����Ϲ��Ľ��
                decimal n_buySinle = n_Single * Convert.ToInt32(IResult.Rows[i]["ChippedShare"]);

                lab_subscriptyion.Text = n_buySinle.ToString();

                //��ѯ�û��ʻ�������Ƿ���֧������
                publicMethod pubMod = new publicMethod();
                if (IResult.Rows[i]["playName"].ToString() == "9999")
                {
                    lab_lotteryName.Text = "������";
                }
                else
                {
                    DataSet ds = pubMod.Chipped_Table("PBnet_LotteryMenu", "NvarName", "IntId=" + "'" + Convert.ToInt32(IResult.Rows[i]["playName"]) + "'");
                    if (ds != null && ds.Tables[0].Rows.Count>0)
                    {
                        lab_lotteryName.Text = ds.Tables[0].Rows[0]["NvarName"].ToString();
                    }
                }
                string plan = get_pub.percent(IResult.Rows[i]["QNumber"].ToString());
                lab_plan.Text = plan + "%";

                if (Convert.ToInt32(IResult.Rows[i]["State"]) == 2)
                {
                    lab_SState.Text = "���˿�";
                }
                if (Convert.ToInt32(IResult.Rows[i]["State"]) == 1)
                {
                    lab_SState.Text = "�ѳ�Ʊ";
                }
                if (Convert.ToInt32(IResult.Rows[i]["State"]) == 0)
                {
                    lab_SState.Text = "������";
                }
                if (Convert.ToInt32(IResult.Rows[i]["State"]) == 3)
                {
                    lab_SState.Text = "δ��Ʊ";
                }
                if (Convert.ToInt32(IResult.Rows[i]["State"]) == 4)
                {
                    lab_SState.Text = "����ʧ��,�ȴ��˿�";
                }
                //��ѯ������Ϣ��
                DataSet ds_table = pubMod.Chipped_Table("Chipped_LaunchInfo", "bounsAllost,Purchasing,doubles,Winning", "QNumber=" + "'" + IResult.Rows[i]["QNumber"].ToString() + "'");
                if (Convert.ToInt32(ds_table.Tables[0].Rows[0]["Purchasing"]) == 1)
                {
                    lan_playName.Text = "����";
                }
                if (Convert.ToInt32(ds_table.Tables[0].Rows[0]["Purchasing"]) == 2)
                {
                    lan_playName.Text = "����";
                }
                //�������� lab_dub
                Label lab_dub = this.myGridView.Rows[i].Cells[0].FindControl("lab_dub") as Label;

                lab_dub.Text = ds_table.Tables[0].Rows[0]["doubles"].ToString();
                //���������ܽ��
                Label lab_Toal = this.myGridView.Rows[i].Cells[0].FindControl("lab_Toal") as Label;

                decimal TotalAmount =Convert.ToDecimal(ds_table.Tables[0].Rows[0]["bounsAllost"]);

                lab_Toal.Text = TotalAmount.ToString("��#,##0.00");


                //���񽱽�ĵ��ݵĽ��   ��õĽ���/���ֵķ���
                decimal onlyMoney = Convert.ToDecimal(ds_table.Tables[0].Rows[0]["bounsAllost"]) / Convert.ToInt32(IResult.Rows[i]["Share"]);
                //������

                decimal ObtainManey = onlyMoney * Convert.ToInt32(IResult.Rows[i]["ChippedShare"]);
                lab_bonus.Text = ObtainManey.ToString("��#,##0.00");
                
                //��ʾ �Ƿ��н�
                Label lab_Winning = this.myGridView.Rows[i].Cells[0].FindControl("lab_Winning") as Label;
                if (Convert.ToInt32(ds_table.Tables[0].Rows[0]["Winning"]) == 0)
                {
                    lab_Winning.Text = "δ����";
                }
                if (Convert.ToInt32(ds_table.Tables[0].Rows[0]["Winning"]) == 1)
                {
                    lab_Winning.Text = "<font color='red'>�н�</font>";
                }
                if (Convert.ToInt32(ds_table.Tables[0].Rows[0]["Winning"]) == 2)
                {
                    lab_Winning.Text = "<font color='blue'>δ�н�</font>";
                }

                //��Ʊ���
                int n_SerialNum = get_pub.LotContrast(Convert.ToInt32(IResult.Rows[i]["PlayName"]));
                Label lab_Serial = this.myGridView.Rows[i].Cells[0].FindControl("lab_Serial") as Label;
                //��������
                string n_LNum = get_pub.Lnum(n_SerialNum, 20120626);
                if (n_LNum != "" && n_LNum != null)
                {
                    lab_Serial.Text = n_LNum;
                }
                else
                {
                    lab_Serial.Text = "";
                }

            }

        }


    }
}
