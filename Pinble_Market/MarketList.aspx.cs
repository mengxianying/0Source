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
using Pinble_Market.AppCod;

namespace Pinble_Market
{
    public partial class MarketList : System.Web.UI.Page
    {
        Pbzx.BLL.Market_CollASAtten collasAtten = new Pbzx.BLL.Market_CollASAtten();
        Pbzx.Model.Market_CollASAtten ModCollasAtten = new Pbzx.Model.Market_CollASAtten();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LotteryListBind();
            }
        }

        /// <summary>
        /// �����ݴ���ҳ
        /// ������: zhouwei
        /// ����ʱ��: �޸��� 2010-10-27
        /// </summary>
        public void LotteryListBind()
        {
            int typeId = Convert.ToInt32(Input.Decrypt(Request["id"]));

            Pbzx.BLL.Market_appendItemManager MyBLL = new Pbzx.BLL.Market_appendItemManager();
            StringBuilder str = new StringBuilder();
            str.Append("id="+typeId);

            string Searchstr = str.ToString();
            string order = "appendid asc";
            int mycount = 0;
            DataTable IsResult = MyBLL.GuestGetBySearch(Searchstr, "*", order, Convert.ToInt32(Input.GetCount()), 3, AspNetPager1.CurrentPageIndex, out mycount);
            this.LotteryList.DataSource = IsResult;
            this.LotteryList.DataBind();
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
            LotteryListBind();
        }

        protected void Btn_Collection_Commend(object sender, CommandEventArgs e)
        {
            //if (Method.Get_UserName == "0")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "up", "alert('����û�е�¼�����ȵ�½��')", true);
            //}
            //else
            //{
            //    if (!collasAtten.Exists(Method.Get_UserName.ToString(), e.CommandArgument.ToString()))
            //    {
            //        try
            //        {

            //            ModCollasAtten.ItemID = Convert.ToInt32(e.CommandArgument);
            //            ModCollasAtten.collection = 1;
            //            ModCollasAtten.accUser = Method.Get_UserName.ToString();
            //            ModCollasAtten.collTime = DateTime.Today.Date;
            //            if (collasAtten.Add(ModCollasAtten) > 0)
            //            {
            //                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "alert('�ղسɹ����뵽��̨�鿴')", true);
            //            }
            //        }
            //        catch (Exception exception)
            //        {
            //            return;
            //        }
            //    }
            //    else
            //    {
            //        if (ModCollasAtten.collection == 1)
            //        {
            //            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "up", "alert(�����ظ��ղأ�')", true);
            //        }
            //        else
            //        {
            //            try
            //            {

            //                ModCollasAtten.ItemID = Convert.ToInt32(e.CommandArgument);
            //                ModCollasAtten.collection = 1;
            //                ModCollasAtten.accUser = Method.Get_UserName.ToString();
            //                ModCollasAtten.collTime = DateTime.Today.Date;
            //                if (collasAtten.Update(ModCollasAtten) > 0)
            //                {
            //                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "alert('�ղسɹ����뵽��̨�鿴')", true);
            //                }
            //            }
            //            catch (Exception exception)
            //            {
            //                return;
            //            }
            //        }
            //    }

            //}
        }

        protected void Btn_buy_Command(object sender, CommandEventArgs e)
        {
        //    //�ж��Ƿ�߼��û�
        //    if (!WebFunc.CheckIsAdvanceUser(Method.Get_UserName))
        //    {
        //        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "<script type='text/javascript' language='javascript' > if (confirm('ֻ�и߼��û�����ʹ�ô���ܣ�����������')){top.location='" + WebInit.webBaseConfig.WebUrl + "UserCenter/UserRealInfo.aspx ';}</script>", false);
        //    }
        //    else
        //    {
        //        Pbzx.BLL.Market_BuyInfo buy = new Pbzx.BLL.Market_BuyInfo();
        //        //�ж��Ƿ������Ŀ
        //        if (buy.Exists(Method.Get_UserName.ToString(), Convert.ToInt32(e.CommandArgument)) == true)
        //        {
        //            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "alert('���ѹ��������Ŀ��')", true);
        //        }
        //        else
        //        {
        //            Pbzx.BLL.Market_appendItemManager app = new Pbzx.BLL.Market_appendItemManager();
        //            Pbzx.Model.Market_appendItem Modapp = new Pbzx.Model.Market_appendItem();
        //            Modapp = app.GetModel(Convert.ToInt32(e.CommandArgument));
        //            //Response.Redirect(urlconvertor("Market_buy.aspx?id=" + "" + Input.Encrypt(Modapp.TypeID.ToString()) + "" + "&price=" + "" + Input.Encrypt(Modapp.Price.ToString()) + "" + "&appendId=" + "" + Input.Encrypt(e.CommandArgument.ToString()) + ""));
        //            Page.RegisterStartupScript("upscript", "<script>window.open('Market_buy.aspx?id='+ '" + Input.Encrypt(Modapp.TypeID.ToString()) + "'+ '&price='+ '" + Input.Encrypt(Modapp.Price.ToString()) + "'+ '&appendId='+'" + Input.Encrypt(e.CommandArgument.ToString()) + "')</script>");

        //        }

        //    }
        //}

        //protected void Btn_Attention_Command(object sender, CommandEventArgs e)
        //{
        //    if (Method.Get_UserName == "0")
        //    {
        //        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "up", "alert('����û�е�¼�����ȵ�½��')", true);
        //    }
        //    else
        //    {
        //        if (!collasAtten.Exists(Method.Get_UserName.ToString(), e.CommandArgument.ToString()))
        //        {
        //            try
        //            {
        //                ModCollasAtten.accUser = Method.Get_UserName.ToString();
        //                ModCollasAtten.attention = 1;
        //                ModCollasAtten.ItemID = Convert.ToInt32(e.CommandArgument);
        //                ModCollasAtten.attTime = DateTime.Today.Date;
        //                if (Convert.ToInt32(collasAtten.Add(ModCollasAtten)) > 0)
        //                {
        //                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "alert('��ӳɹ����뵽��̨�鿴')", true);
        //                }
        //                else
        //                {
        //                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "alert('���ʧ��')", true);
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                return;
        //            }
        //        }
        //        else
        //        {
        //            if (ModCollasAtten.attention == 1)
        //            {
        //                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "up", "alert(�����ظ��ղأ�')", true);
        //            }
        //            else
        //            {
        //                try
        //                {
        //                    ModCollasAtten.accUser = Method.Get_UserName.ToString();
        //                    ModCollasAtten.attention = 1;
        //                    ModCollasAtten.ItemID = Convert.ToInt32(e.CommandArgument);
        //                    ModCollasAtten.attTime = DateTime.Today.Date;
        //                    if (Convert.ToInt32(collasAtten.Update(ModCollasAtten)) > 0)
        //                    {
        //                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "alert('��ӳɹ����뵽��̨�鿴')", true);
        //                    }
        //                    else
        //                    {
        //                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "alert('���ʧ��')", true);
        //                    }
        //                }
        //                catch (Exception ex)
        //                {
        //                    return;
        //                }
        //            }
        //        }

        //    }
        }
    }
}
