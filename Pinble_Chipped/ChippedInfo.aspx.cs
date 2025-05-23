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

namespace Pinble_Chipped
{
    public partial class ChippedInfo : System.Web.UI.Page
    {
        Pbzx.BLL.PBnet_LotteryMenu get_lm = new Pbzx.BLL.PBnet_LotteryMenu();
        DataSet ds = new DataSet();
        //��ˮ��
        public static string number = "";
        public static int share = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rep_ProjectInfoBind();
                
            }
        }
        /// <summary>
        /// ������
        /// </summary>
        private void rep_ProjectInfoBind()
        {
            string Qnum = Request["id"].ToString();
            int shareNum =Convert.ToInt32(Request["share"]);
            Pbzx.BLL.Chipped_LaunchInfoManage get_lif = new Pbzx.BLL.Chipped_LaunchInfoManage();
            ds = get_lif.GetList("QNumber=" + "'" + Qnum + "'");
            this.rep_ProjectInfo.DataSource = ds;
            this.rep_ProjectInfo.DataBind();
            buyShare.Text = shareNum.ToString();

            //���ݵĽ��
            decimal nEachMoney = Convert.ToDecimal(ds.Tables[0].Rows[0]["AtotalMoney"]) / Convert.ToInt32(ds.Tables[0].Rows[0]["Share"]);
            //���ѽ��
            decimal nSpend=shareNum*nEachMoney;

            lab_money.Text = nSpend.ToString("0.##");
            if (Convert.ToInt32(ds.Tables[0].Rows[0]["Object"]) == 0)
            {
                //��ʾ����
                string n_num=displayNum(ds.Tables[0].Rows[0]["ChoiceNum"].ToString(), Convert.ToInt32(ds.Tables[0].Rows[0]["playName"]));
                lab_number.Text = n_num;
            }
            if(Convert.ToInt32(ds.Tables[0].Rows[0]["Object"]) == 1)
            {
                lab_number.Text = "";
            }
            if (Convert.ToInt32(ds.Tables[0].Rows[0]["Object"]) == 2)
            {
                lab_number.Text = "";
            }
            //��ֵ��ҳ������ر���
            number = Qnum;
            share =Convert.ToInt32(shareNum);
        }

        /// <summary>
        /// ���¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rep_ProjectInfo_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem RI in this.rep_ProjectInfo.Items)
            {
                //�淨��ʶ
                Label lab_lottery = RI.FindControl("lab_lottery") as Label;
                //ע��
                Label lab_num = RI.FindControl("lab_num") as Label;
                //���ݽ��
                Label lab_SingleMoney = RI.FindControl("lab_SingleMoney") as Label;
                //��������
                Label lab_secretType = RI.FindControl("lab_secretType") as Label;

                
                
                //��ѯ��������
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["playName"]) == 9999)
                {
                    //����3 ���⴦��
                    lab_lottery.Text = "����3";
                }
                else
                {
                    DataSet ds_lm = get_lm.GetList("IntId=" + Convert.ToInt32(ds.Tables[0].Rows[0]["playName"]));
                    if (ds_lm != null && ds_lm.Tables[0].Rows.Count > 0)
                    {
                        lab_lottery.Text = ds_lm.Tables[0].Rows[0]["NvarName"].ToString();
                    }
                }

                lab_num.Text= ds.Tables[0].Rows[0]["ChoiceNum"].ToString().Split(';').Length.ToString();

                //���ݽ��
                decimal SingleMoney = Convert.ToDecimal(ds.Tables[0].Rows[0]["AtotalMoney"]) / Convert.ToInt32(ds.Tables[0].Rows[0]["Share"]);

                lab_SingleMoney.Text = SingleMoney.ToString("0.##");

                if (Convert.ToInt32(ds.Tables[0].Rows[RI.ItemIndex]["Object"]) == 0)
                {
                    lab_secretType.Text = "����";
                }
                if (Convert.ToInt32(ds.Tables[0].Rows[RI.ItemIndex]["Object"]) == 1)
                {
                    lab_secretType.Text = "ֻ�Ը����˿���";
                }
                if (Convert.ToInt32(ds.Tables[0].Rows[RI.ItemIndex]["Object"]) == 2)
                {
                    lab_secretType.Text = "����";
                }
            }
        }

        /// <summary>
        /// ��ʾ�������
        /// </summary>
        /// <param name="num">���봮</param>
        /// <param name="playName">�淨��ʶ</param>
        private string displayNum(string num,int playName)
        { 
            //3D
            if (playName == 1)
            {
                string num3D="";
                for (int i = 0; i < num.Split(';').Length; i++)
                {
                    if (num.Split(';')[i].Split('|')[0].ToString() == "1")
                    {
                        num3D += "<font color='red'>[3Dֱѡ]</font> " + num.Split(';')[i].Split('|')[1].ToString()+"<br/>";
                    }
                    if (num.Split(';')[i].Split('|')[0].ToString() == "S1")
                    {
                        num3D += "<font color='red'>[ֱѡ��ֵ]</font> " + num.Split(';')[i].Split('|')[1].ToString() + "<br/>";
                    }
                    if (num.Split(';')[i].Split('|')[0].ToString() == "6")
                    {
                        num3D += "<font color='red'>[3D��ѡ]</font> " + num.Split(';')[i].Split('|')[1].ToString() + "<br/>";
                    }
                    if (num.Split(';')[i].Split('|')[0].ToString() == "S9")
                    {
                        num3D += "<font color='red'>[��ѡ��ֵ]</font> " + num.Split(';')[i].Split('|')[1].ToString() + "<br/>";
                    }
                    if (num.Split(';')[i].Split('|')[0].ToString() == "F3")
                    {
                        num3D += "<font color='red'>[��������]</font> " + num.Split(';')[i].Split('|')[1].ToString() + "<br/>";
                    }
                    if (num.Split(';')[i].Split('|')[0].ToString() == "S3")
                    {
                        num3D += "<font color='red'>[������ֵ]</font> " + num.Split(';')[i].Split('|')[1].ToString() + "<br/>";
                    }
                    if (num.Split(';')[i].Split('|')[0].ToString() == "F6")
                    {
                        num3D += "<font color='red'>[��������]</font> " + num.Split(';')[i].Split('|')[1].ToString() + "<br/>";
                    }
                    if (num.Split(';')[i].Split('|')[0].ToString() == "S6")
                    {
                        num3D += "<font color='red'>[������ֵ]</font> " + num.Split(';')[i].Split('|')[1].ToString() + "<br/>";
                    }
                    if (num.Split(';')[i].Split('|')[0].ToString() == "1D")
                    {
                        num3D += "<font color='red'>[1Dѡ��]</font> " + num.Split(';')[i].Split('|')[1].ToString() + "<br/>";
                    }
                    if (num.Split(';')[i].Split('|')[0].ToString()=="2D")
                    {
                        num3D += "<font color='red'>[2Dѡ��]</font> " + num.Split(';')[i].Split('|')[1].ToString() + "<br/>";
                    }
                    if (num.Split(';')[i].Split('|')[0].ToString() =="tx")
                    {
                        num3D += "<font color='red'>[ͨѡ]</font> " + num.Split(';')[i].Split('|')[1].ToString() + "<br/>";
                    }
                    if (num.Split(';')[i].Split('|')[0].ToString() == "hsx")
                    {
                        num3D += "<font color='red'>[����ѡ]</font> " + num.Split(';')[i].Split('|')[1].ToString() + "<br/>";
                    }
                }
                return num3D;
            }
            //˫ɫ��
            if (playName == 3)
            {
                string numssq = "";
                for (int i = 0; i < num.Split(';').Length; i++)
                {

                    numssq += "������ " + num.Split(';')[i].Split('-')[0].ToString()+"<br/>" +"������ "+ num.Split(';')[i].Split('-')[1].ToString()+"<br/>";
                }
                return numssq;
            }
            //���ֲ�
            if (playName == 2)
            {
                string numqlc= "";
                for (int i = 0; i < num.Split(';').Length; i++)
                {

                    numqlc += "�����롿 " + num.Split(';')[i].ToString() + "<br/>";
                }
                return numqlc;
            }
            //����5
            if (playName == 4)
            {
                string numpl = "";
                for (int i = 0; i < num.Split(';').Length; i++)
                {

                    numpl += "�����롿 " + num.Split(';')[i].ToString() + "<br/>";
                }
                return numpl;
            }
            //����3
            if (playName == 9999)
            {
                string numps = "";
                for (int i = 0; i < num.Split(';').Length; i++)
                {
                    if (num.Split(';')[i].Split('|')[0].ToString() == "1")
                    {
                        numps += "<font color='red'>[ֱѡ]</font> " + num.Split(';')[i].Split('|')[1].ToString() + "<br/>";
                    }
                    if (num.Split(';')[i].Split('|')[0].ToString() == "S1")
                    {
                        numps += "<font color='red'>[ֱѡ��ֵ]</font> " + num.Split(';')[i].Split('|')[1].ToString() + "<br/>";
                    }
                    if (num.Split(';')[i].Split('|')[0].ToString() =="6")
                    {
                        numps += "<font color='red'>[��ѡ]</font> " + num.Split(';')[i].Split('|')[1].ToString() + "<br/>";
                    }
                    if (num.Split(';')[i].Split('|')[0].ToString() == "S6")
                    {
                        numps += "<font color='red'>[��ѡ��ֵ]</font> " + num.Split(';')[i].Split('|')[1].ToString() + "<br/>";
                    }
                    if (num.Split(';')[i].Split('|')[0].ToString() =="F3")
                    {
                        numps += "<font color='red'>[��������]</font> " + num.Split(';')[i].Split('|')[1].ToString() + "<br/>";
                    }
                    if (num.Split(';')[i].Split('|')[0].ToString() == "S3")
                    {
                        numps += "<font color='red'>[������ֵ]</font> " + num.Split(';')[i].Split('|')[1].ToString() + "<br/>";
                    }
                    if (num.Split(';')[i].Split('|')[0].ToString() == "F6")
                    {
                        numps += "<font color='red'>[��������]</font> " + num.Split(';')[i].Split('|')[1].ToString() + "<br/>";
                    }
                    if (num.Split(';')[i].Split('|')[0].ToString() == "S6")
                    {
                        numps += "<font color='red'>[������ֵ]</font> " + num.Split(';')[i].Split('|')[1].ToString() + "<br/>";
                    }
                }
                return numps;
            }
            //���ǲ�
            if (playName == 5)
            {
                string numqxc = "";
                for (int i = 0; i < num.Split(';').Length; i++)
                {

                    numqxc += "�����롿 " + num.Split(';')[i].ToString() + "<br/>";
                }
                return numqxc;
            }
            //����͸
            if (playName == 6)
            {
                string numdlt = "";
                for (int i = 0; i < num.Split(';').Length; i++)
                {

                    numdlt += "��ǰ�����롿 " + num.Split(';')[i].Split('-')[0].ToString() + "<br/>" + "���������롿 " + num.Split(';')[i].Split('-')[1].ToString() + "<br/>";
                }
                return numdlt;
            }
            return "";
        }
    }
}
