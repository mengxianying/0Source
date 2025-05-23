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

namespace Pinble_Market
{
    public partial class Market_Itemissuance : System.Web.UI.Page
    {
        Market_NumManager markmanager = new Market_NumManager();
        Pbzx.BLL.PBnet_UserTable usertype = new Pbzx.BLL.PBnet_UserTable();
        
        Pbzx.BLL.Market_Page markepage = new Market_Page();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Method.Get_UserName.ToString() == "0")
            {
                Response.Write("<script type='text/javascript'>parent.mainFrame.location.href='/login.aspx'</script>");
                Response.End();
                return;
            }
            // �ж��û��Ƿ��¼�Ƿ��Ǹ߼��û�
            if (!WebFunc.CheckIsAdvanceUser(Method.Get_UserName))
            {
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alertScript", "if (confirm('ֻ�и߼��û�����ʹ�ô���ܣ�����������')){top.location='../UserCenter/UserRealInfo.aspx';}else{history.go(-1);}", true);

                Response.Write("<script type='text/javascript' language='javascript' > if (confirm('ֻ�и߼��û�����ʹ�ô���ܣ�����������')){top.location='../UserCenter/UserRealInfo.aspx';}else{history.go(-1);}</script>");

                Response.End();
                return;

            }
            if (!IsPostBack)
            {
                //�󶨲���
                ddlLotteryBind();
                //������
                QSBind();
                

                ////��ʱ��
                //BindDate();
            }
        }

        /// <summary>
        /// ������ʱ��
        /// </summary>
        private void BindDate()
        {
            //ddlDateH.Items.Clear();
            //ddlDateY.Items.Clear();
            //ddlDateR.Items.Clear();
            //ddlDateS.Items.Clear();
            //ddlDateF.Items.Clear();
            //�����
            //for (int i = 0; i < 5; i++)
            //{
            //    ListItem list = new ListItem();
            //    list.Text = (DateTime.Now.Year + i).ToString();
            //    list.Value = (DateTime.Now.Year + i).ToString();
            //    ddlDateH.Items.Add(list);
            //}
            ////���·�
            //for (int i = 1; i < 13; i++)
            //{
            //    ListItem list = new ListItem();
            //    list.Text = i.ToString();
            //    list.Value = i.ToString();
            //    ddlDateY.Items.Add(list);
            //}
            ////����
            //Bindrq();

            ////��ʱ
            //for (int i = 0; i < 24; i++)
            //{
            //    ListItem list = new ListItem();
            //    list.Text = i.ToString();
            //    list.Value = i.ToString();
            //    ddlDateS.Items.Add(list);
            //}

            ////�󶨷�
            //for (int i = 0; i < 60; i++)
            //{
            //    ListItem list = new ListItem();
            //    list.Text = i.ToString();
            //    list.Value = i.ToString();
            //    ddlDateF.Items.Add(list);
            //}
        }
        /// <summary>
        /// �󶨲���
        /// </summary>
        private void ddlLotteryBind()
        {
            //Pbzx.BLL.PBnet_LotteryMenu lm = new Pbzx.BLL.PBnet_LotteryMenu();
            //DataSet ds = lm.GetList("NvarClass='ȫ������' or NvarClass='ȫ�����'");

            //ddlLottery.DataSource = ds;
            //ddlLottery.DataTextField = "NvarName";
            //ddlLottery.DataValueField = "Intid";
            //ddlLottery.DataBind();
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
                ddlLottery.DataSource = DbHelperSQL.Query("SELECT IntId, NvarName FROM PBnet_LotteryMenu WHERE (IntId IN (" + ids + ")) ");

                ddlLottery.DataTextField = "NvarName";
                ddlLottery.DataValueField = "IntId";
                ddlLottery.DataBind();

            }
            ListItem it = new ListItem("--��ѡ�����--", "0");
            ddlLottery.Items.Insert(0, it); 

        }
        private void XMBind()
        {
            ddlitemName.Items.Clear();
            ddlitemName.Items.Add(new ListItem("--��ѡ������--", "0"));
            ////�޸�ǰ
            //DataSet dds = markepage.Market_GetItme("NvarName, TypeName,appendId", "Userid=" + Method.Get_UserID);
            //�޸ĺ�
            DataSet dds = markepage.Market_GetItme("distinct NvarName, TypeName,appendId ", "Userid=" + "'" + Method.Get_UserName.ToString() + "'" + " and On_off <>3 and LotteryID=" + Convert.ToInt32(ddlLottery.SelectedValue) + " and On_Off<>3");
            for (int i = 0; i < dds.Tables[0].Rows.Count; i++)
            {

                if (dds.Tables[0].Rows.Count > 0)
                {
                    ListItem list = new ListItem();
                    list.Text = dds.Tables[0].Rows[i]["TypeName"].ToString();
                    //�޸��˰󶨵�Valueֵ��  ͬһ���û�ֻ����1�� ��Ʊ���͡�   ������� typeID  �� �û�ID  �õ� ��ĿID  
                    //id �ǲ�Ʊ���ͱ����id  �� ��Ŀ�����typeID ��Ӧ��
                    list.Value = dds.Tables[0].Rows[i]["appendId"].ToString();
                    ddlitemName.Items.Add(list);
                }

                //  �󶨵�ddl�����б���

            }
            if (ddlitemName.Items.Count <= 0)
            {
                ListItem lite = new ListItem();
                lite.Text = "��������Ŀ";
                lite.Value = "��������Ŀ";
                ddlitemName.Items.Clear();
                ddlitemName.Items.Add(lite);
            }
        }
        /// <summary>
        /// �����󶨷���
        /// </summary>
        private void QSBind()
        {
            ////�����ڼ�,����ֻ��ģ��
            //Random ra = new Random();
            //txtYCqs.Text = ra.Next(10000, 99999).ToString();
        }

        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void Button1_Click(object sender, EventArgs e)
        //{
            //if (ddlitemName.SelectedValue == "��������Ŀ" || ddlitemName.SelectedValue == "")
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('��ʱû�����µ���Ŀ����������ʱ�������ǵ�pinble��̳��');", true);
            //    return;
            //}

            //Market_Num mark = new Market_Num();

            //mark.ItemID = Convert.ToInt32(ddlitemName.SelectedValue);
            //mark.ExpectNum = txtYCqs.Text;

            ////����ʱ��
            //if (rdbtfabu.SelectedValue == "0")
            //    mark.IssueTime = "0";
            //else
            //    mark.IssueTime = ddlDateH.SelectedValue + "-" + ddlDateY.SelectedValue + "-" + ddlDateR.SelectedValue + " " + ddlDateS.SelectedValue + ":" + ddlDateF.SelectedValue;


            //mark.Commend = Convert.ToInt32(rdbttuijian.SelectedValue);

            //mark.Content = txtContent.Text;
            //if (markmanager.Add(mark) > 0)
            //{
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('��ӳɹ���');</script>");
            //    Response.Write("<script language=javascript>window.close();</script>");

            //}
            //else
            //{
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('���ʧ�ܣ�');</script>");
            //}

        //}

        /// <summary>
        /// ���÷���ʱ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rdbtfabu_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (rdbtfabu.SelectedValue == "0")
            //{
            //    txtDate.Visible = false;
            //}
            //else
            //{
            //    ddlDateY.SelectedValue = DateTime.Now.Month.ToString();
            //    ddlDateR.SelectedValue = (DateTime.Now.Day + 1).ToString();
            //    txtDate.Visible = true;
            //}
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
            //ddlDateR.Items.Clear();
            ////������
            //if (Convert.ToInt32(ddlDateY.SelectedValue) % 2 != 0)
            //{
            //    for (int i = 1; i < 31; i++)
            //    {
            //        ListItem list = new ListItem();
            //        list.Text = i.ToString();
            //        list.Value = i.ToString();
            //        ddlDateR.Items.Add(list);
            //    }
            //}
            //else
            //{

            //    if (ddlDateY.SelectedValue == "2")
            //    {
            //        for (int i = 1; i < 29; i++)
            //        {
            //            ListItem list = new ListItem();
            //            list.Text = i.ToString();
            //            list.Value = i.ToString();
            //            ddlDateR.Items.Add(list);
            //        }
            //    }
            //    else
            //    {
            //        for (int i = 1; i < 32; i++)
            //        {
            //            ListItem list = new ListItem();
            //            list.Text = i.ToString();
            //            list.Value = i.ToString();
            //            ddlDateR.Items.Add(list);
            //        }
            //    }
            //}
        }

        protected void ddlLottery_SelectedIndexChanged(object sender, EventArgs e)
        {
            //��Ŀ�б��
            XMBind();
            
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ItemEnactment.aspx");
        }


    }
}
