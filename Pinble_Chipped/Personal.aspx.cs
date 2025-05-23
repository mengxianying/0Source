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
using Pbzx.BLL;

namespace Pinble_Chipped
{
    public partial class Personal : System.Web.UI.Page
    {
        Pbzx.BLL.publicMethod get_pub = new Pbzx.BLL.publicMethod();
        DataSet ds = new DataSet();
        DataSet ds_pp = new DataSet();
        DataSet dsDataList = new DataSet();
        public string name = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                name = Request["name"].ToString();
                personInfo();
                rep_dynamicBind();
                
                rep_ppBind();
                dl_historyBind();
                
            }
        }

        //������Ϣ
        public void personInfo()
        {
            //���ý����� 
            //DataSet dsWin = get_pub.Chipped_Table("v_Winning", "top 1 bonus", "UserName=" + "'" + name + "'" + " and Purchasing=2 and State=1 order by bonus desc");
            DataSet dsWin = get_pub.Chipped_Table("PlatformPublic_UserWinning", "top 1 u_Monery", "u_name=" + "'" + name + "'" + " and u_platform='Chipped' order by u_Monery desc");
            if (dsWin != null && dsWin.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToDecimal(dsWin.Tables[0].Rows[0][0]) > 10000000)
                {
                    lab_winName.Text = "ǧ��󽱵���";
                }
                else if (Convert.ToDecimal(dsWin.Tables[0].Rows[0][0]) > 1000000)
                {
                    lab_winName.Text = "����󽱵���";
                }
                else if (Convert.ToDecimal(dsWin.Tables[0].Rows[0][0]) > 100000)
                {
                    lab_winName.Text = "ʮ��󽱵���";
                }
                else if (Convert.ToDecimal(dsWin.Tables[0].Rows[0][0]) > 10000)
                {
                    lab_winName.Text = "��Ԫ�󽱵���";
                }
                else if (Convert.ToDecimal(dsWin.Tables[0].Rows[0][0]) > 1000)
                {
                    lab_winName.Text = "ǧԪ�󽱵���";
                }
                else
                {
                    lab_winName.Text = "��ʱδ��ǧԪ���ϴ�";
                }
            }
            else
            {
                lab_winName.Text = "��ʱδǧԪ���ϴ�";
            }
            
            //���˵��û���
            lab_UserName.Text = name;
            
            //��������
            DataSet dsNum = get_pub.Chipped_Table("Chipped_LaunchInfo", "count(*)", "UserName=" + "'" + name + "'");
            lab_num.Text = dsNum.Tables[0].Rows[0][0].ToString();

            //�����ɹ���
            DataSet dsSuccess = get_pub.Chipped_Table("Chipped_LaunchInfo", "count(*)", "UserName=" + "'" + name + "'" + " and State=1");
            lab_success.Text = Convert.ToString(Convert.ToInt32(Convert.ToInt32(dsSuccess.Tables[0].Rows[0][0])/Convert.ToInt32(dsNum.Tables[0].Rows[0][0])*100)) +"%";

            //����н�


        }


        /// <summary>
        /// �����¶�̬ ����
        /// </summary>
        public void rep_dynamicBind()
        {
            ds = get_pub.Chipped_Table("Chipped_LaunchInfo", "top 3 *", "UserName=" + "'" + name + "'" + " order by LaunchTime desc");
            this.rep_dynamic.DataSource = ds;
            this.rep_dynamic.DataBind();
        }
        /// <summary>
        /// ���¶�̬�İ��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rep_dynamic_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
           
            foreach (RepeaterItem RI in this.rep_dynamic.Items)
            {
                Label lab_Lname = RI.FindControl("lab_Lname") as Label;
                //��ѯ��Ӧ�Ĳ���
                if (Convert.ToInt32(ds.Tables[0].Rows[RI.ItemIndex]["playName"]) == 1)
                { 
                    //3D
                    lab_Lname.Text = "����3D";
                }
                if (Convert.ToInt32(ds.Tables[0].Rows[RI.ItemIndex]["playName"]) == 3)
                {
                    lab_Lname.Text = "˫ɫ��";
                }
                if (Convert.ToInt32(ds.Tables[0].Rows[RI.ItemIndex]["playName"]) == 2)
                {
                    lab_Lname.Text = "���ֲ�";
                }
                if (Convert.ToInt32(ds.Tables[0].Rows[RI.ItemIndex]["playName"]) == 4)
                {
                    lab_Lname.Text = "������";
                }
                if (Convert.ToInt32(ds.Tables[0].Rows[RI.ItemIndex]["playName"]) == 5)
                {
                    lab_Lname.Text = "���ǲ�";
                }
                if (Convert.ToInt32(ds.Tables[0].Rows[RI.ItemIndex]["playName"]) == 6)
                {
                    lab_Lname.Text = "����͸";
                }
                if (Convert.ToInt32(ds.Tables[0].Rows[RI.ItemIndex]["playName"]) == 7)
                {
                    lab_Lname.Text = "22ѡ5";
                }
            }
        }

        /// <summary>
        /// �󶨲��뷽��
        /// </summary>
        public void rep_ppBind()
        {
            
            ds_pp = get_pub.Chipped_Table("v_Merger", "top 5 *", "ChippedName=" + "'" + name + "'");
            this.rep_pp.DataSource = ds_pp;
            this.rep_pp.DataBind();
        }
        protected void rep_pp_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Pbzx.BLL.Chipped_LaunchInfoManage get_lm = new Pbzx.BLL.Chipped_LaunchInfoManage();
            
            foreach (RepeaterItem RI in this.rep_pp.Items)
            {
                Label lab_Lname_pp = RI.FindControl("lab_Lname_pp") as Label;
                Label lab_ExpectNum_pp = RI.FindControl("lab_ExpectNum_pp") as Label;
                Label lab_AtotalMoney_pp = RI.FindControl("lab_AtotalMoney_pp") as Label;
                DataSet ds_ppBund=get_lm.GetList("QNumber="+"'"+ ds_pp.Tables[0].Rows[RI.ItemIndex]["QNumber"].ToString() +"'");
                if (Convert.ToInt32(ds_ppBund.Tables[0].Rows[0]["playName"]) == 1)
                {
                    lab_Lname_pp.Text = "����3D";   
                }
                if (Convert.ToInt32(ds_ppBund.Tables[0].Rows[0]["playName"]) == 2)
                {
                    lab_Lname_pp.Text = "���ֲ�";
                }
                if (Convert.ToInt32(ds_ppBund.Tables[0].Rows[0]["playName"]) == 3)
                {
                    lab_Lname_pp.Text = "˫ɫ��";
                }
                if (Convert.ToInt32(ds_ppBund.Tables[0].Rows[0]["playName"]) == 4)
                {
                    lab_Lname_pp.Text = "������";
                }
                if (Convert.ToInt32(ds_ppBund.Tables[0].Rows[0]["playName"]) == 5)
                {
                    lab_Lname_pp.Text = "���ǲ�";
                }
                if (Convert.ToInt32(ds_ppBund.Tables[0].Rows[0]["playName"]) == 6)
                {
                    lab_Lname_pp.Text = "����͸";
                }
                if (Convert.ToInt32(ds_ppBund.Tables[0].Rows[0]["playName"]) == 7)
                {
                    lab_Lname_pp.Text = "22ѡ5";
                }
                lab_ExpectNum_pp.Text = ds_ppBund.Tables[0].Rows[0]["ExpectNum"].ToString();
                lab_AtotalMoney_pp.Text = ds_ppBund.Tables[0].Rows[0]["AtotalMoney"].ToString();

            }
        }

        /// <summary>
        /// ����ʷս��
        /// </summary>
        public void dl_historyBind()
        {
            dsDataList = get_pub.Chipped_Table("v_participation", "distinct playName", "UserName=" + "'" + name + "'" + " or ChippedName=" + "'" + name + "'" + " and Purchasing=2 and State=1 " + " group by playName");
            this.dl_history.DataSource = dsDataList;
            this.dl_history.DataBind();


        }
        //DataList ���¼�
        protected void dl_history_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            Pbzx.BLL.PlatformPublic_UserWinning get_win = new Pbzx.BLL.PlatformPublic_UserWinning();
            int lotteryInt = 0;
            decimal WinMoneysd = 0;
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) //�����ż����
            {
                //��������
                Label lab_lotteryName = e.Item.FindControl("lab_lotteryName") as Label;
                //�Ͳ������Ӧ��ͼƬ
                Image image_lottery = e.Item.FindControl("image_lottery") as Image;

                //�н�����
                Label lab_num = e.Item.FindControl("lab_num") as Label;
                //�н��ܽ��
                Label lab_totalMoney = e.Item.FindControl("lab_totalMoney") as Label;
                //��ѯ���б���Ա�����3D����Ŀ lotteryInt
                DataSet dsLott = get_pub.Chipped_Table("v_Merger", "distinct QNumber", "ChippedName=" + "'" + name + "'" + " group by QNumber");
                for (int i = 0; i < dsLott.Tables[0].Rows.Count; i++)
                {
                    //��ѯ�н�����
                    if (get_win.Exists(dsLott.Tables[0].Rows[i]["QNumber"].ToString(), "Chipped"))
                    {
                        lotteryInt++;
                    }
                    //�����н����
                    DataSet dsWin = get_win.GetList("u_wItem=" + "'" + dsLott.Tables[0].Rows[i]["QNumber"].ToString() + "'" + " and u_platform='Chipped'");
                    if (dsWin != null && dsWin.Tables[0].Rows.Count > 0)
                    {
                        WinMoneysd += Convert.ToDecimal(dsWin.Tables[0].Rows[0]["u_Monery"]);
                    }
                }

                if (Convert.ToInt32(dsDataList.Tables[0].Rows[e.Item.ItemIndex]["playName"]) == 1)
                {
                    lab_lotteryName.Text = "����3D";
                    image_lottery.ImageUrl = "~/images/sd.png";
                }
                if (Convert.ToInt32(dsDataList.Tables[0].Rows[e.Item.ItemIndex]["playName"]) == 3)
                {
                    lab_lotteryName.Text = "˫ɫ��";
                    image_lottery.ImageUrl = "~/images/ssq.png";
                }
                if (Convert.ToInt32(dsDataList.Tables[0].Rows[e.Item.ItemIndex]["playName"]) == 2)
                {
                    lab_lotteryName.Text = "���ֲ�";
                    image_lottery.ImageUrl = "~/images/ssq.png";
                }
                if (Convert.ToInt32(dsDataList.Tables[0].Rows[e.Item.ItemIndex]["playName"]) == 6)
                {
                    lab_lotteryName.Text = "����͸";
                    image_lottery.ImageUrl = "~/images/dlt.png";
                }
                if (Convert.ToInt32(dsDataList.Tables[0].Rows[e.Item.ItemIndex]["playName"]) == 4)
                {
                    lab_lotteryName.Text = "������";
                    image_lottery.ImageUrl = "~/images/plw.png";
                }
                if (Convert.ToInt32(dsDataList.Tables[0].Rows[e.Item.ItemIndex]["playName"]) == 5)
                {
                    lab_lotteryName.Text = "���ǲ�";
                    image_lottery.ImageUrl = "~/images/plw.png";
                }
                lab_num.Text = lotteryInt.ToString();
                lab_totalMoney.Text = WinMoneysd.ToString();
            }
        }
    }
}
