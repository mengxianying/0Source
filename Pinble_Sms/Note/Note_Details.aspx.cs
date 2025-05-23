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
using Pbzx.Common;

namespace Pinble_Sms.Note
{
    public partial class Note_Details : System.Web.UI.Page
    {

        Note_Customize nt = new Note_Customize();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //�ж��Ƿ�ע��
                if (Method.Get_UserName == "0")
                {
                    mainLayM.Visible = false;
                    Response.Write("<script>alert('���ȵ�¼��');location='Note_ShoppingList.aspx'</script>");
                    return;
                }


                string id = Request.QueryString["id"];
                int ids = 0;
                if (id != null && id != "" && int.TryParse(id, out ids))
                {
                    Note_LotteryType tp = new Note_LotteryType();
                    Pbzx.Model.Note_LotteryType lotterytype = tp.GetModel(Convert.ToInt32(id));
                    if (lotterytype != null)
                    {
                        if (lotterytype.Ispublic == false)
                        {
                            Response.Redirect("Note_ShoppingList.aspx");
                        }
                        lblottoryType.Text = lotterytype.SName;

                        //�󶨼۸�
                        string[] priceText = lotterytype.PriceContent.Split('|');
                        for (int i = 0; i < priceText.Length; i++)
                        {
                            ListItem item = new ListItem();
                            item.Value = priceText[i];
                            item.Text = priceText[i];
                            droppricelist.Items.Add(item);
                        }

                        Pbzx.Model.Note_Customize model = nt.GetModel(Convert.ToInt32(id), Method.Get_UserName);
                        if (model != null)
                        {
                            rdbutjF.SelectedValue = model.ContinuationType.ToString();

                            txtPhone.Text = model.Phone;
                            txtPhone.Enabled = false;
                            if (model.EndTime < DateTime.Now)
                            {
                                labmsg1.Text = "(��ʾ:���Ѿ������˴˷���,����״̬�Ѿ����ڣ��������ѣ�)";
                            }
                            else
                            {
                                labmsg1.Text = "(��ʾ:���Ѿ������˴˷���,����״̬����,�������ӷ���ʱ�䣡�������ѣ�)";
                            }
                        }


                    }
                    else
                    {
                        Response.Redirect("Note_ShoppingList.aspx");
                    }
                }
                else
                {
                    Response.Redirect("Note_ShoppingList.aspx");
                }
            }
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOK_Click(object sender, EventArgs e)
        {

            if (txtPhone.Text.Trim() == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "alert('����д�ֻ����룡');", true);
                return;
            }

            string id = Request.QueryString["id"];
            //���Ѽ۸�
            string pricecontent = droppricelist.SelectedValue;

            string[] monthprice = pricecontent.Split('/');
            string price = monthprice[0].Substring(0, monthprice[0].Length - 1);
            string month = monthprice[1].Substring(0, monthprice[1].Length - 1);

            Pbzx.Model.Note_Customize model = nt.GetModel(Convert.ToInt32(id), Method.Get_UserName);

            //�жϼ۸�
            Pbzx.BLL.PBnet_UserTable UsBll = new Pbzx.BLL.PBnet_UserTable();
            Pbzx.Model.PBnet_UserTable UsModel = UsBll.GetModelName(Method.Get_UserName);

            if (UsModel == null)
            {
                return;
            }
            if (UsModel.CurrentMoney < Convert.ToDecimal(price))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "alert('�Բ������˻����㣡���ȳ�ֵ��');location='Note_ShoppingList.aspx';", true);
                return;
            }
            else
            {

                ///////////////////////////////////////////���˻��м�ȥ�������
                UsModel.CurrentMoney = UsModel.CurrentMoney - Convert.ToDecimal(price);
                UsBll.Update(UsModel);
                //////////////////////////////////////////////////////////��¼����
                Note_Log log = new Note_Log();
                Pbzx.Model.Note_Log molog = new Pbzx.Model.Note_Log();
                molog.BeginTime = DateTime.Now;
                molog.Phone = txtPhone.Text;
                molog.Countent = "�������ͣ�" + lblottoryType.Text + "   ���ѷ�ʽ��" + droppricelist.SelectedItem.Text + "    ���ѽ�" + price + "��";

                log.Add(molog);
                ///////////////////////////////////////////


            }

            ///���----------------------------
            if (model != null)
            {
                if (model.EndTime < DateTime.Now)
                {
                    model.EndTime = DateTime.Now.AddMonths(Convert.ToInt32(month));
                }
                else
                {
                    model.EndTime = model.EndTime.AddMonths(Convert.ToInt32(month));
                }
                model.Price += Convert.ToDecimal(price);
                model.ContinuationType = Convert.ToInt32(rdbutjF.SelectedValue);

                if (nt.Update(model) > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "", "alert('���Ƴɹ���');location='Note_Manager.aspx';", true);
                }
            }
            else
            {
                model = new Pbzx.Model.Note_Customize();
                model.SID = Convert.ToInt32(id);
                model.Phone = txtPhone.Text;
                model.UserName = Method.Get_UserName;
                model.BeginTime = DateTime.Now;
                model.EndTime = DateTime.Now.AddMonths(Convert.ToInt32(month));
                model.Price = Convert.ToDecimal(price);
                model.Status = 1;
                model.ContinuationType = Convert.ToInt32(rdbutjF.SelectedValue);
                if (nt.Add(model) > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "", "alert('���Ƴɹ���');location='Note_Manager.aspx';", true);
                }
            }
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnregist_Click(object sender, EventArgs e)
        {
            Response.Redirect("Note_ShoppingList.aspx");
        }

        protected void rdbutjF_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdbutjF.SelectedValue == "1")
            {
                labmsg.Text = "��ѡ���Զ����ѷ��񣬵�����������ϵͳ���Զ��������˻��п۳�һ���µķ���ѣ�";
            }
            else
            {
                labmsg.Text = "��ѡ���ֶ����ѣ�������������ϵͳ���Զ�ֹͣ�����Ķ��ŷ���";
            }
        }
    }
}
