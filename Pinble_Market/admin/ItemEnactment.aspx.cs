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
using Maticsoft.DBUtility;
using Pbzx.BLL;
using Pbzx.Model;
using Pbzx.Common;
using Pinble_Market.AppCod;
using System.Drawing;

namespace Pinble_Market.admin
{
    /// <summary>
    /// �������Ŀ
    /// 2010-10-19
    /// </summary>
    public partial class ItemEnactment : System.Web.UI.Page
    {
        Market_TypeManager lotterymanager = new Market_TypeManager();
        Pbzx.BLL.PBnet_UserTable usertypemanager = new Pbzx.BLL.PBnet_UserTable();
        Market_appendItemManager lotteryitemmanager = new Market_appendItemManager();
        Market_NumManager nummanager = new Market_NumManager();
        Pbzx.BLL.Market_BuyInfo buyinfomanager = new Pbzx.BLL.Market_BuyInfo();

        /// <summary>
        /// ҳ������¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Method.Get_UserName.ToString() == "0")
            {
                Response.Write("<script type='text/javascript'>parent.mainFrame.location.href='../login.aspx'</script>");
                Response.End();
                return;
            }
            //�ж��û��Ƿ��¼�Ƿ��Ǹ߼��û�
            if (!WebFunc.CheckIsAdvanceUser(Method.Get_UserName))
            {
                Response.Write("<script type='text/javascript' language='javascript' > if (confirm('ֻ�и߼��û�����ʹ�ô���ܣ�����������')){location='http://www.pinble.com/UserCenter/UserRealInfo.aspx';}else{history.go(-1);}</script>");
                //ClientScript.RegisterStartupScript(this.GetType(), "upscript", "if (confirm('ֻ�и߼��û�����ʹ�ô���ܣ�����������')){top.location='../UserCenter/UserRealInfo.aspx';}else{history.go(-1);}",true);
                Response.End();
                return;
            }
            if (!IsPostBack)
            {
                //ҳ�����ݰ�
                DataBInds();
                //��ʱ��
                BindDate();
                //�շ�ģʽ
                BindSF(Request.QueryString["itemid"]);

                //�жϵ�����������ʱ�����޸ģ������ݰ󶨵��ؼ���
                if (Request.QueryString["itemid"] != null)
                {

                    btnresult.Visible = true;
                    string[] sj = Request.QueryString["itemid"].Split(',');
                    Market_appendItem item = lotteryitemmanager.GetModel(Convert.ToInt32(sj[0]));

                    if (item != null)
                    {
                        ddlSofts.SelectedValue = sj[1];
                        ddlxianmoBind();
                        ddlxianmo.SelectedValue = sj[2];
                        ddlSofts.Enabled = false;
                        ddlxianmo.Enabled = false;
                        txtzk.Text = Convert.ToInt32(item.Agio).ToString();
                        txtprice.Text = Convert.ToInt32(item.Price).ToString();
                        ddlsf.SelectedValue = item.Charge.ToString();
                        radbut.SelectedValue = item.On_off.ToString();
                        txtsay.Text = item.Say;
                    }
                }
            }
        }
        /// <summary>
        /// �жϵ��û���������û��10�ڣ������շ���Ŀ
        /// </summary>
        private void BindSF(string sfms)
        {
            sfmsgs.Text = "";
            this.sfms.Visible = false;
            money.Visible = false;

            ddlsf.Items.Clear();
            if (sfms != null)
            {
                string[] sj = Request.QueryString["itemid"].Split(',');
                if (nummanager.GetList("ItemID='" + sj[0] + "'").Tables[0].Rows.Count >= 10)
                {
                    this.sfms.Visible = true;
                    money.Visible = true;
                    ddlsf.Items.Add(new ListItem("���", "0"));
                    ddlsf.Items.Add(new ListItem("�����շ�", "1"));
                }
                else
                {
                    ddlsf.Items.Add(new ListItem("���", "0"));
                }

                Market_appendItem item = lotteryitemmanager.GetModel(Convert.ToInt32(sj[0]));

                if (item != null)
                {
                    if (item.Charge == 1)
                    {
                        if (buyinfomanager.GetList("issueInfoId='" + sj[0] + "'  and EndTime>= '" + DateTime.Now.ToString() + "'").Tables[0].Rows.Count > 0)
                        {
                            sfmsgs.Text = "(�����޸��շ�ģʽ��������������Ŀ����";
                            ddlsf.Enabled = false;
                        }
                    }
                }
            }
            else
            {
                ddlsf.Items.Add(new ListItem("���", "0"));
            }
        }

        /// <summary>
        /// ������ʱ��
        /// </summary>
        private void BindDate()
        {
            ddlDateH.Items.Clear();
            ddlDateY.Items.Clear();
            ddlDateR.Items.Clear();
            ddlDateS.Items.Clear();
            ddlDateF.Items.Clear();
            //�����
            for (int i = 0; i < 5; i++)
            {
                ListItem list = new ListItem();
                list.Text = (DateTime.Now.Year + i).ToString();
                list.Value = (DateTime.Now.Year + i).ToString();
                ddlDateH.Items.Add(list);
            }
            //���·�
            for (int i = 1; i < 13; i++)
            {
                ListItem list = new ListItem();
                list.Text = i.ToString();
                list.Value = i.ToString();
                ddlDateY.Items.Add(list);
            }
            //����
            Bindrq();

            //��ʱ
            for (int i = 0; i < 24; i++)
            {
                ListItem list = new ListItem();
                if (i < 10)
                {
                    list.Text = "0" + i.ToString();
                    list.Value = "0" + i.ToString();
                }
                else
                {
                    list.Text = i.ToString();
                    list.Value = i.ToString();
                }
                ddlDateS.Items.Add(list);
            }

            //�󶨷�
            for (int i = 0; i < 60; i++)
            {
                ListItem list = new ListItem();
                if (i < 10)
                {
                    list.Text = "0" + i.ToString();
                    list.Value = "0" + i.ToString();
                }
                else
                {
                    list.Text = i.ToString();
                    list.Value = i.ToString();
                }
                ddlDateF.Items.Add(list);
            }

        }
        /// <summary>
        /// ���ݰ󶨷���
        /// </summary>
        private void DataBInds()
        {
            ddlSoftsBind();

        }
        /// <summary>
        /// ���������б�󶨷���
        /// </summary>
        private void ddlSoftsBind()
        {
            DataSet daset = DbHelperSQL.Query("SELECT LotteryID FROM Market_Type GROUP BY LotteryID");
            //�����ݴ���0ʱ
            string ids = "";
            for (int i = 0; i < daset.Tables[0].Rows.Count; i++)
            {
                if (daset.Tables[0].Rows[i]["LotteryID"].ToString() != "")
                {
                    ids = ids + daset.Tables[0].Rows[i]["LotteryID"].ToString() + ",";
                }
            }
            if (ids != "")
            {

                ids = ids.Substring(0, ids.Length - 1);
                ddlSofts.DataSource = DbHelperSQL.Query("SELECT IntId, NvarName FROM PBnet_LotteryMenu WHERE (IntId IN (" + ids + ")) ");

                ddlSofts.DataTextField = "NvarName";
                ddlSofts.DataValueField = "IntId";
                ddlSofts.DataBind();
            }
        }
        /// <summary>
        /// ���������󼤷�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlSofts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSofts.SelectedValue != "=��ѡ�����=")
            {
                ddlxianmoBind();
            }
            else
            {
                ddlxianmo.Items.Clear();
                ddlxianmo.Items.Add(new ListItem("=��ѡ������=", "=��ѡ��="));

            }
        }
        /// <summary>
        /// ddl������
        /// </summary>
        private void ddlxianmoBind()
        {
            labmsgtype.Text = "";
            Pbzx.Model.PBnet_UserTable user = usertypemanager.GetModelName(Method.Get_UserName);
            if (user != null)
            {
                ddlxianmo.Items.Clear();
                ddlxianmo.Items.Add(new ListItem("=��ѡ������=", "=��ѡ��="));
                DataSet dast = lotterymanager.GetList("LotteryID='" + ddlSofts.SelectedValue + "'");
                if (dast.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dast.Tables[0].Rows.Count; i++)
                    {
                        if (Request.QueryString["itemid"] != null)
                        {

                            ListItem lm = new ListItem();
                            //lm.Text = ddlSofts.SelectedItem.Text + dast.Tables[0].Rows[i]["TypeName"];
                            lm.Text = dast.Tables[0].Rows[i]["TypeName"].ToString();
                            lm.Value = dast.Tables[0].Rows[i]["Id"].ToString();
                            ddlxianmo.Items.Add(lm);
                        }
                        else
                        {
                            //�ж��Ƿ��Ѿ����
                            if (lotteryitemmanager.GetList("TypeID=" + dast.Tables[0].Rows[i]["Id"] + " and UserId='" + Method.Get_UserName + "' and On_off <>3").Tables[0].Rows.Count == 0)
                            {
                                ListItem lm = new ListItem();
                                //lm.Text = ddlSofts.SelectedItem.Text + dast.Tables[0].Rows[i]["TypeName"];
                                lm.Text = dast.Tables[0].Rows[i]["TypeName"].ToString();
                                lm.Value = dast.Tables[0].Rows[i]["Id"].ToString();
                                ddlxianmo.Items.Add(lm);
                            }
                        }
                    }
                }
            }

            if (ddlxianmo.Items.Count <= 1)
            {
                labmsgtype.Text = "(�˲����µ��������Ѿ�ȫ���趨����ѡ���������֣�)";
            }
        }
        /// <summary>
        /// ���ؼ������ı�ʱ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlsf_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlsf.SelectedItem.Text == "���")
            {
                txtprice.Enabled = false;
                txtzk.Enabled = false;
                txtzk.Text = "0";
                txtprice.Text = "���";
            }
            else
            {
                txtprice.Enabled = true;
                txtzk.Enabled = true;
                txtprice.Text = "1";
            }

        }

        /// <summary>
        /// ȷ���ύ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (ddlSofts.SelectedValue == "=��ѡ��=")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('��ѡ��һ�����֣�');", true);
                return;
            }
            if (ddlxianmo.SelectedValue == "=��ѡ��=")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('��ѡ��һ����Ŀ��');", true);
                return;
            }
            if (txtsay.Text == "" || txtsay.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('����д��Ŀ˵����');", true);
                return;
            }

            if (ddlxianmo.SelectedValue == "��������Ŀ" || ddlxianmo.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('��" + ddlSofts.SelectedItem.Text + "����ʱû�����µ���Ŀ����������ʱ�������ǵ�pinble��̳��');", true);
                return;
            }
            if (txtsay.Text.Length > 100)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('�����������ֻ����д100���ַ�����');", true);
                return;
            }

            if (Input.Htmls(txtsay.Text) == string.Empty)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('�������к���������Ż򹥻��ԵĽű�����');", true);
                return;
            }

           
            if (ddlsf.SelectedValue != "0")
            {
                //�жϼ۸������Ƿ���ȷ
                int price1 = 0;
                if (!int.TryParse(txtprice.Text, out price1))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('�۸���д����ȷ��');", true);
                    return;
                }

                //�ж��ۿ������Ƿ���ȷ
                int zk = 0;
                if (!int.TryParse(txtzk.Text, out zk))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('�ۿ���д����ȷ��');", true);
                    return;
                }
                if (price1 <= 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('�۸���С�ڻ���ڣ�0��');", true);
                    return;
                }
                if (price1 < 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('�۸���С�ڻ���ڣ�0��');", true);
                    return;
                }
                if (zk < 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('�ۿ���д����ȷ��');", true);
                    return;
                }
            }
            Pbzx.Model.PBnet_UserTable user = usertypemanager.GetModelName(Method.Get_UserName);
            if (user != null)
            {

                Market_appendItem lotteryitem = new Market_appendItem();

                //��Ŀ����ID

                lotteryitem.TypeID = Convert.ToInt32(ddlxianmo.SelectedValue);
                //��ǰ�û���
                //lotteryitem.UserId = user.Id;
                lotteryitem.UserId = Method.Get_UserName.ToString();
                //�շ�ģʽ
                lotteryitem.Charge = Convert.ToInt32(ddlsf.SelectedValue);
                if (lotteryitem.Charge != 0)
                {
                    //�۸�
                    lotteryitem.Price = Convert.ToDecimal(txtprice.Text);
                    //�ۿ�
                    lotteryitem.Agio = Convert.ToDecimal(txtzk.Text);
                }
                else
                {
                    //�۸�
                    lotteryitem.Price = 0;
                    //�ۿ�
                    lotteryitem.Agio = 0;
                }
                //off-on �����Ƿ񿪷�
                lotteryitem.On_off = Convert.ToInt32(radbut.SelectedValue);
                //����
                lotteryitem.Say = txtsay.Text;

                //��ǰʱ��
                lotteryitem.Time = DateTime.Now;

                //����ʱ��
                if (rdbtfabu.SelectedValue == "0")
                    lotteryitem.IssueTime = DateTime.Now.ToString();
                else
                    lotteryitem.IssueTime = ddlDateH.SelectedValue + "-" + ddlDateY.SelectedValue + "-" + ddlDateR.SelectedValue + " " + ddlDateS.SelectedValue + ":" + ddlDateF.SelectedValue + ":00";

                //�Ƽ�����
                lotteryitem.Commend = Convert.ToInt32(rdbttuijian.SelectedValue);

                //Ĭ��Ϊ������Ŀ
                lotteryitem.State = 0;


                //�Ƿ����Ʋ鿴����
                if (rdbtnlenght.SelectedValue == "0")
                    lotteryitem.Confine = 0;
                else
                    lotteryitem.Confine = Convert.ToInt32(txtxz.Text);
                //ִ���޸Ĳ���
                if (Request.QueryString["itemid"] != null)
                {
                    string[] sj = Request.QueryString["itemid"].Split(',');
                    lotteryitem.appendID = Convert.ToInt32(sj[0]);
                    if (lotteryitemmanager.Update(lotteryitem) > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('�޸ĳɹ���');location='Market_ItemManage.aspx';", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('�޸�ʧ�ܣ�');", true);
                    }
                }
                else
                {
                    if (lotteryitemmanager.Add(lotteryitem) > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('��ӳɹ���');location='Market_ItemManage.aspx';", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('���ʧ�ܣ�');", true);
                    }
                }
            }
        }

        /// <summary>
        /// ���÷���ʱ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rdbtfabu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdbtfabu.SelectedValue == "0")
            {
                txtDate.Visible = false;
            }
            else
            {
                ddlDateY.SelectedValue = DateTime.Now.Month.ToString();
                ddlDateR.SelectedValue = (DateTime.Now.Day + 1).ToString();
                txtDate.Visible = true;
            }
        }
        /// <summary>
        /// ����ѡ����·����ж�ÿ���µ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlDateY_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bindrq();
        }
        /// <summary>
        /// �����ڵķ���
        /// </summary>
        private void Bindrq()
        {
            ddlDateR.Items.Clear();
            //������
            if (Convert.ToInt32(ddlDateY.SelectedValue) % 2 != 0)
            {
                for (int i = 1; i < 31; i++)
                {
                    ListItem list = new ListItem();
                    list.Text = i.ToString();
                    list.Value = i.ToString();
                    ddlDateR.Items.Add(list);
                }
            }
            else
            {

                if (ddlDateY.SelectedValue == "2")
                {
                    for (int i = 1; i < 29; i++)
                    {
                        ListItem list = new ListItem();
                        list.Text = i.ToString();
                        list.Value = i.ToString();
                        ddlDateR.Items.Add(list);
                    }
                }
                else
                {
                    for (int i = 1; i < 32; i++)
                    {
                        ListItem list = new ListItem();
                        list.Text = i.ToString();
                        list.Value = i.ToString();
                        ddlDateR.Items.Add(list);
                    }
                }
            }
        }
        /// <summary>
        /// �ж��Ƿ��������ķ�������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rdbtnlenght_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdbtnlenght.SelectedValue == "0")
            {
                Div2.Visible = false;
            }
            else
            {
                Div2.Visible = true;
            }
        }
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnresult_Click(object sender, EventArgs e)
        {
            Response.Redirect("Market_ItemManage.aspx");
        }
        /// <summary>
        /// ������������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void radbut_SelectedIndexChanged(object sender, EventArgs e)
        {
            string radnumber = radbut.SelectedValue;
            if (radnumber == "0")
            {
                labstatusmsg.Text = "(�����ڣ������������û����Զ�������Ŀ��)";
                labstatusmsg.ForeColor = Color.Green;
            }
            else if (radnumber == "1")
            {
                labstatusmsg.Text = "(��ʾ�������������û����޷������˵���Ŀ��)";
                labstatusmsg.ForeColor = Color.Red;
            }
            else
            {
                labstatusmsg.Text = "(��ʾ���رպ󣬽���ֹ�������Ŀ�ķ���)";
                labstatusmsg.ForeColor = Color.Red;
            }

        }

    }
}
