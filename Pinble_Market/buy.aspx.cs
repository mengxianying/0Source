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
using Pinble_Market.AppCod;
using System.Text;

namespace Pinble_Market
{
    public partial class buy : System.Web.UI.Page
    {
        public string NvarName = "";
        public string TypeName = "";
        public string userId = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // �ж��û��Ƿ��¼�Ƿ��Ǹ߼��û�
                if (!WebFunc.CheckIsAdvanceUser(Method.Get_UserName))
                {
                    lab_name.Text = "��  " + Method.Get_UserName.ToString() + "�����Ǹ߼��û�";
                }
                else
                {
                    lab_name.Text ="<font color='red'>"+"��ӭ����" + Method.Get_UserName.ToString()+"</font>     ��ѡ��Ҫ���������";
                    lbtn_login.Visible = false;
                }
                main();
                BindTab_BuyInfo();
            }
        }

        private void main()
        {
            
            string appendID = Input.Decrypt(Request["appendId"]);

            buyItem(appendID);

            Pbzx.BLL.Market_Page MyPage = new Pbzx.BLL.Market_Page();
            //�󶨱��������
            DataSet ds = MyPage.Market_GetItme("UserId,Time,say,NvarName,TypeName,Price","appendID="+Convert.ToInt32(appendID));
            //�����Ľ�������
            lab_say.Text = ds.Tables[0].Rows[0]["say"].ToString();
            lab_user.Text = ds.Tables[0].Rows[0]["UserId"].ToString();
            lan_NvarName.Text = ds.Tables[0].Rows[0]["NvarName"].ToString() + ds.Tables[0].Rows[0]["TypeName"].ToString();
            NvarName = Pbzx.Common.Input.Encrypt(ds.Tables[0].Rows[0]["NvarName"].ToString());
            TypeName =Pbzx.Common.Input.Encrypt(ds.Tables[0].Rows[0]["TypeName"].ToString());
            userId = Pbzx.Common.Input.Encrypt(ds.Tables[0].Rows[0]["UserId"].ToString());
            //�۸�
            lab_price.Text = ds.Tables[0].Rows[0]["Price"].ToString();
            //��������ʱ��
            lab_time.Text = string.Format("{0:u}", Convert.ToDateTime(ds.Tables[0].Rows[0]["Time"])).Substring(0,10);

            //�󶨾����ںŵ�����
            DataSet dsNum = MyPage.Market_GetNum("top 2 ExpectNum,Content", "appendID=" +Convert.ToInt32(appendID) + " order by ExpectNum desc");
            //��ѯ�����Ŀ�����˶�����
            DataSet num = MyPage.Market_GetNum("ExpectNum", "appendID=" + Convert.ToInt32(appendID));
            lab_num.Text = num.Tables[0].Rows.Count.ToString();
            //���ֻ����һ��
            if (dsNum != null && dsNum.Tables[0].Rows.Count < 2)
            { 
                lab_upNum.Text="<font color='red'>û�����·���</font>";
                lab_NumGut.Text="��������";
            }
            else
            {
                lab_upNum.Text = dsNum.Tables[0].Rows[1]["ExpectNum"].ToString();
                lab_NumGut.Text = dsNum.Tables[0].Rows[1]["Content"].ToString();
            }
            //��ѯ�����µ��ں�
            //localhost.WebService1 web=new Pinble_Market.localhost.WebService1();
            Pinble_Market.admin.WebService1 web = new Pinble_Market.admin.WebService1();
            lab_NewNum.Text = web.lotteryNum(ds.Tables[0].Rows[0]["NvarName"].ToString());
        }
        /// <summary>
        /// ��֤�û��Ƿ��������Ŀ
        /// </summary>
        private void buyItem(string appendID)
        { 
            //�ж��Ƿ��������Ŀ
            Pbzx.BLL.Market_BuyInfo Mybuy = new Pbzx.BLL.Market_BuyInfo();

            if (!Mybuy.Exists(Method.Get_UserName.ToString(), Convert.ToInt32(appendID)))
            {
                lab_beginTime.Text = DateTime.Today.Date.ToString("yyyy-MM-dd");
            }
            else
            {
                
                DataSet ds = Mybuy.GetList("issueInfoId=" + Convert.ToInt32(appendID) + " and buyuserid=" + "'" + Method.Get_UserName.ToString() + "'");
                lab_buyHistory.Text = "<font color='red'>���ѹ��������������ʱ���ǣ�" + ds.Tables[0].Rows[0]["EndTime"].ToString()+" ���������ӳ�ʱ��</font>";
                lab_beginTime.Text =Convert.ToDateTime(ds.Tables[0].Rows[0]["EndTime"]).ToString("yyyy-MM-dd");
            }
        }

        protected void Cob_time_SelectedIndexChanged(object sender, EventArgs e)
        {
            lab_endTime.Text = Convert.ToDateTime(lab_beginTime.Text).AddMonths(Convert.ToInt32(Cob_time.SelectedValue)).ToString("yyyy-MM-dd"); 
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (agreement.Checked == false)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updateScript", "alert('���Ȳ鿴���û�����Э�顷���ݲ�ѡ��ͬ��')", true);
                return;
            }
            string appendID = Input.Decrypt(Request["appendId"]);
            if (Cob_time.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updateScript", "alert('����ѡ�������ޣ�')", true);
                return;
            }

            Pbzx.BLL.Market_BuyInfo Mybuy = new Pbzx.BLL.Market_BuyInfo();
            Pbzx.Model.Market_BuyInfo Mymod = new Pbzx.Model.Market_BuyInfo();

            Pbzx.BLL.Market_Page Mypage=new Pbzx.BLL.Market_Page();

            Pbzx.BLL.PBnet_UserTable g_user = new Pbzx.BLL.PBnet_UserTable();
            Pbzx.Model.PBnet_UserTable g_Moduser = new Pbzx.Model.PBnet_UserTable();
            DataSet ds = Mypage.Market_GetItme("TypeName,Price,UserId", "appendID=" + Convert.ToInt32(appendID));
            //��ѯ�����û����ʻ����
            g_Moduser = g_user.GetModelName(Method.Get_UserName);
            decimal Money = Convert.ToDecimal(g_Moduser.CurrentMoney);
            decimal price = Convert.ToDecimal(ds.Tables[0].Rows[0]["Price"]);
            if (!Mybuy.Exists(Method.Get_UserName.ToString(), Convert.ToInt32(appendID)))
            {
                //û�й������Ŀ    
                Mymod.buyuserid = Method.Get_UserName.ToString();
                Mymod.issueInfoId = Convert.ToInt32(appendID);
                Mymod.LotteryType = ds.Tables[0].Rows[0]["TypeName"].ToString();
                Mymod.ShopUserID=ds.Tables[0].Rows[0]["UserId"].ToString();
                Mymod.Price =Convert.ToDecimal(ds.Tables[0].Rows[0]["Price"].ToString());
                Mymod.Term =Convert.ToInt32(Cob_time.SelectedValue);
                Mymod.BeginTime = Convert.ToDateTime(lab_beginTime.Text);
                Mymod.EndTime = Convert.ToDateTime(lab_endTime.Text);
                Mymod.buyContinue = Convert.ToInt32(Request.Form["radiobutton"]);
                
                if (Money > price)
                {
                    if (Mybuy.Add(Mymod) > 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "UpdatePanel1", "<script>alert('����ɹ��������̨�鿴');window.close();</script>", false);
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updateScript", "if(confirm('�������㣬���ֵ��')){ window.open('" + WebInit.webBaseConfig.WebUrl + "UserCenter/User_Center.aspx');window.close();}else{window.close();}", true);
                }
            }
            else
            { 
                //�������Ŀ
                Mymod.EndTime = Convert.ToDateTime(lab_endTime.Text);
                if (Money > price)
                {
                    if (Mybuy.Update(Mymod) > 0)
                    {
                        //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "UpdatePanel1", "<script>alert('����ɹ��������̨�鿴');window.close();</script>", false);
                        ClientScript.RegisterStartupScript(this.GetType(), "Myscript", "<script>alert('����ɹ��������̨�鿴');window.close();</script>");
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updateScript", "if(confirm('�������㣬���ֵ��')){ window.open('" + WebInit.webBaseConfig.WebUrl + "UserCenter/User_Center.aspx');window.close();}else{window.close();}", true);
                }
                
            }
        }

        //�󶨹�����Ŀ�鿴�б�
        /// <summary>
        /// ������: zhouwei
        /// ����ʱ��: 2010-12-22
        /// </summary>
        public void BindTab_BuyInfo()
        {
            int ID = Convert.ToInt32(Input.Decrypt(Request["appendId"]));

            Pbzx.BLL.Market_BuyInfo MyBLL = new Pbzx.BLL.Market_BuyInfo();
            StringBuilder str = new StringBuilder();
            str.Append("issueInfoId=" + ID);

            string Searchstr = str.ToString();
            string order = "buyid asc";
            int mycount = 0;
            DataTable IsResult = MyBLL.GuestGetBySearchBuyInfo(Searchstr, "*", order, 10, 3, AspNetPager1.CurrentPageIndex, out mycount);
            this.Tab_BuyInfo.DataSource = IsResult;
            this.Tab_BuyInfo.DataBind();
            AspNetPagerConfig(mycount);
            if (IsResult == null)
            {
                this.litContent.Text = "<b>��Ǹ��<p/><br/>Ӧ��û���ҵ������������ݼ�¼</b>";
            }
            else
            {
                this.litContent.Text = "";
            }


        }

        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = 10;
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
            BindTab_BuyInfo();
        }
        //��ע��Ŀ
        protected void lbtn_attention_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.Market_Page pa = new Pbzx.BLL.Market_Page();
            string appendID = Input.Decrypt(Request["appendId"]);

            //��ѯ����
            DataSet ds = pa.Market_GetItme("NvarName", "appendID=" + Convert.ToInt32(appendID));
            Pbzx.BLL.Market_CollASAtten ca = new Pbzx.BLL.Market_CollASAtten();
            Pbzx.Model.Market_CollASAtten modca = new Pbzx.Model.Market_CollASAtten();
            if (!ca.Exists(Method.Get_UserName, appendID, 1, 2))
            {
                modca.appName = appendID;
                modca.appTime = DateTime.Now.Date;
                modca.mark = 2;
                modca.statc = 1;
                modca.Uname = Method.Get_UserName.ToString();
                if (ca.Add(modca) > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "upScript", "alert('���ɹ���ע�˴���Ŀ')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "upScript", "alert('��ע��Ŀ���ɹ���')", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "upScript", "alert('���Ѿ���ע������Ŀ')", true);
            }
        }

    }
}
