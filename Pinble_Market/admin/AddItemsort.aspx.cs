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
using Pbzx.Model;
using Pbzx.Common;
using Pinble_Market.AppCod;
using System.Xml;

namespace Pinble_Market.admin
{
    public partial class AddItemsort : System.Web.UI.Page
    {
        Pbzx.BLL.PBnet_LotteryMenu mey = new Pbzx.BLL.PBnet_LotteryMenu();
        Market_Type lotterytype = new Market_Type();
        Market_TypeConfigure lotterytypeconfigure = new Market_TypeConfigure();
        Market_TypeManager serverType = new Market_TypeManager();


        protected void Page_Load(object sender, EventArgs e)
        {
            ////�ж��û��Ƿ��¼�Ƿ��Ǹ߼��û�
            //if (!WebFunc.CheckIsAdvanceUser(Method.Get_UserName))
            //{
            //    Response.Write("<script type='text/javascript' language='javascript' > if (confirm('ֻ�и߼��û�����ʹ�ô���ܣ�����������')){top.location='../UserCenter/UserRealInfo.aspx';}</script>");
            //    Response.End();
            //    return;

            //}
            if (!IsPostBack)
            {
                BindLoad();
            }
        }
        /// <summary>
        /// ������Ĭ�ϰ�
        /// </summary>
        private void BindLoad()
        {
            DdtList.Items.Add(new ListItem("--��ѡ��--", "--��ѡ��--"));

            DdtList.DataSource = mey.GetList("NvarClass='ȫ������' or NvarClass='ȫ�����'");
            DdtList.DataTextField = "NvarName";
            DdtList.DataValueField = "IntId";
            DdtList.DataBind();
        }

        /// <summary>
        /// ���������󼤷�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Rbtlist1.SelectedValue == "0")
            {
                BtnOk.Text = "�� ��";
            }
            else
            {
                BtnOk.Text = "��һ��>>";
            }
        }

        /// <summary>
        /// �����ɻ�����һ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnOk_Click(object sender, EventArgs e)
        {


            if (DdtList.SelectedValue == "--��ѡ��--")
            {
                //JS.Alert("��ѡ�����");
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('��ѡ����֣�')", true);
                return;
            }


            if (Ddtservice.SelectedItem.Text == "--��ѡ��--")
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('����д���')", true);
                return;
            }
            else
            {
                //�ж��Ƿ���ڸ���Ŀ����
                if (serverType.GetList("LotteryID=" + DdtList.SelectedValue.ToString() + " and TypeName='" + Ddtservice.SelectedItem.Text + "'").Tables[0].Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('����Ŀ�����Ѵ��ڣ������ظ�������')", true);
                    return;
                }



                if (BtnOk.Text == "��һ��>>")
                {
                    labmc.Text = txtxiangm.Text;
                    MutViwe.ActiveViewIndex++;

                }
                else
                {

                    lotterytype.LotteryID = Convert.ToInt32(DdtList.SelectedValue.ToString());
                    lotterytype.TypeName = Ddtservice.SelectedItem.Text;
                    lotterytype.Intercalate = Convert.ToInt32(Rbtlist1.SelectedValue);
                    //Ĭ�����ã�Ĭ������������XML��
                    lotterytype.State = 0;
                    lotterytype.UserID = Convert.ToInt32(Method.Get_UserID);
                    int typeid = serverType.Add(lotterytype);
                    if (typeid > 0)
                    {

                        lotterytypeconfigure.TypeId = typeid;
                        lotterytypeconfigure.On_off = Convert.ToInt32(Input.GetValue("On_Off"));

                        lotterytypeconfigure.Sign = Convert.ToInt32(Input.GetValue("Sign"));

                        lotterytypeconfigure.BeginTime = DateTime.Now;

                        lotterytypeconfigure.Endtime = DateTime.Now;

                        lotterytypeconfigure.Upload = Convert.ToInt32(Input.GetValue("Upload")); ;

                        lotterytypeconfigure.SmallMoney = Convert.ToDecimal(Input.GetValue("SmallMoney"));

                        lotterytypeconfigure.BigMoney = Convert.ToDecimal(Input.GetValue("BigMoney"));

                        lotterytypeconfigure.Ticheng = Input.GetValue("Ticheng");

                        lotterytypeconfigure.ManyIssue = Convert.ToInt32(Input.GetValue("ManyIssue"));

                        lotterytypeconfigure.Recommend = Convert.ToInt32(Input.GetValue("Recommend"));

                        //ִ�� �������Ӳ���
                        Market_TypeConfigureManager config = new Market_TypeConfigureManager();
                        if (config.Add(lotterytypeconfigure) > 0)
                        {
                            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('��ӳɹ���')", true);

                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('���ʧ�ܣ�')", true);
                            return;
                        }


                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('���ʧ�ܣ�');", true);
                        return;
                    }
                }

            }

        }

        /// <summary>
        /// ��һ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void butResult_Click(object sender, EventArgs e)
        {
            MutViwe.ActiveViewIndex--;
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {

            //�ж��Ƿ���ڸ���Ŀ����
            if (serverType.GetList("LotteryID=" + DdtList.SelectedValue.ToString() + " and TypeName='" + Ddtservice.SelectedItem.Text + "'").Tables[0].Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('����Ŀ�����Ѵ��ڣ������ظ�������')", true);
                return;
            }

            //����ID
            int typeid = 0;
            //�������
            string leibie = Ddtservice.SelectedItem.Text;

            //�Ƿ�Ĭ��
            int mrid = Convert.ToInt32(Rbtlist1.SelectedValue);

            //����
            int kaiguan = 0;
            //�Ƿ��ö�

            int zd = 0;
            //��С���
            decimal minmoney = 0;
            //�����
            decimal maxmoney = 0;
            //��ɲ���
            double ticheng = 0;
            //�Ƿ��������

            int douqi = 0;
            if (mrid != 0)
            {

                //����
                kaiguan = Convert.ToInt32(RBtkaiguan.SelectedValue);

                //�Ƿ��ö�
                zd = Convert.ToInt32(Rbtzhiding.SelectedValue);

                //�ж���С����Ƿ�������ȷ
                if (!Decimal.TryParse(txtbeginMoney.Text, out minmoney))
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('��С�����д����ȷ��')", true);
                    return;
                }

                //�ж�������Ƿ�������ȷ
                if (!Decimal.TryParse(txtendMoney.Text, out maxmoney))
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('�������д����ȷ��')", true);
                    return;
                }
                //�ж���С���ܴ��������
                if (minmoney > maxmoney)
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('��С���ܴ�������')", true);
                    return;
                }
                //��ɷǿ��ж�
                if (txtticheng.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('��ɲ�������Ϊ�գ�');", true);
                    return;
                }
                //�ж��������
                if (!Double.TryParse(txtticheng.Text, out ticheng))
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('��ɲ������벻�ԣ�');", true);
                    return;
                }


                //�Ƿ��������

                douqi = Convert.ToInt32(Rbtduoqi.SelectedValue);

            }



            lotterytype.LotteryID = Convert.ToInt32(DdtList.SelectedValue.ToString());
            lotterytype.TypeName = Ddtservice.SelectedItem.Text;
            lotterytype.Intercalate = Convert.ToInt32(Rbtlist1.SelectedValue);
            //Ĭ������,Ĭ�����
            lotterytype.State = 0;
            lotterytype.UserID = Convert.ToInt32(Method.Get_UserName);
            typeid = serverType.Add(lotterytype);
            if (typeid > 0)
            {


                // lotterytype.Userid = null;
                //end-------------����

                //ִ���������Ӳ��� ����ִ�к��ID


                //������ϸ��Ϣ���

                // lotterytypeconfigure.Typeid = 1;

                lotterytypeconfigure.TypeId = typeid;
                lotterytypeconfigure.On_off = kaiguan;

                lotterytypeconfigure.Sign = zd;

                lotterytypeconfigure.BeginTime = DateTime.Now;

                lotterytypeconfigure.Endtime = DateTime.Now;

                lotterytypeconfigure.Upload = 0;

                lotterytypeconfigure.SmallMoney = minmoney;

                lotterytypeconfigure.BigMoney = maxmoney;

                lotterytypeconfigure.Ticheng = ticheng.ToString();

                lotterytypeconfigure.ManyIssue = douqi;

                lotterytypeconfigure.Recommend = 0;

                //ִ�� �������Ӳ���
                Market_TypeConfigureManager config = new Market_TypeConfigureManager();
                if (config.Add(lotterytypeconfigure) > 0)
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('��ӳɹ���')", true);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('���ʧ�ܣ�')", true);
                    return;
                }


            }
            else
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('���ʧ�ܣ�');", true);
                return;
            }
        }

        /// <summary>
        /// �ڸ����ı����Լ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void txtleibie_TextChanged(object sender, EventArgs e)
        {
            if (Ddtservice.SelectedItem.Text != "--��ѡ��--")
                txtxiangm.Text = DdtList.SelectedItem.Text + Ddtservice.SelectedItem.Text;
            else
                txtxiangm.Text = "";
        }


        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DdtList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ddtservice.Items.Clear();
            Ddtservice.Items.Add(new ListItem("--��ѡ��--", "--��ѡ��--"));
            if (DdtList.SelectedItem.Text == "--��ѡ��--")
            {
                return;
            }

            try
            {
                XmlDocument dom = new XmlDocument();
                dom.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/LottoryCondition.xml"));//װ��XML�ĵ� 
                XmlElement root = dom.DocumentElement;
                XmlNode xmlchiroot = root.SelectNodes("CP" + DdtList.SelectedItem.Text)[0];
                if (xmlchiroot != null)
                {
                    for (int i = 0; i < xmlchiroot.ChildNodes.Count; i++)
                    {
                        if (xmlchiroot.ChildNodes[i] != null)
                        {
                            ListItem item = new ListItem();
                            item.Text = xmlchiroot.ChildNodes[i].SelectSingleNode("@name").Value;
                            item.Value = xmlchiroot.ChildNodes[i].SelectSingleNode("@name").Value;
                            Ddtservice.Items.Add(item);
                        }
                    }
                    Ddtservice.DataBind();
                }

            }
            catch
            {

            }
            if (Ddtservice.SelectedItem.Text != "--��ѡ��--")
                txtxiangm.Text = DdtList.SelectedItem.Text + Ddtservice.SelectedItem.Text;
            else
                txtxiangm.Text = "";
        }
        /// <summary>
        /// ��Ŀ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Ddtservice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Ddtservice.SelectedItem.Text != "--��ѡ��--")
                txtxiangm.Text = DdtList.SelectedItem.Text + Ddtservice.SelectedItem.Text;
            else
                txtxiangm.Text = "";
        }

    }
}
