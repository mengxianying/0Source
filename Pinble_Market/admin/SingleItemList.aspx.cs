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
using Pinble_Market.AppCod;
using Pbzx.Common;
using System.Text;

namespace Pinble_Market.admin
{
    public partial class SingleItemList : System.Web.UI.Page
    {
        Pbzx.BLL.Market_NumManager g_Num = new Pbzx.BLL.Market_NumManager();
        Pbzx.Model.Market_Num g_ModNum = new Pbzx.Model.Market_Num();
        DataSet g_ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            ////判断用户是否登录是否是高级用户
            if (!WebFunc.CheckIsAdvanceUser(Method.Get_UserName))
            {
                Response.Write("<script type='text/javascript' language='javascript' > if (confirm('只有高级用户才能使用此项功能，现在申请吗？')){top.location='../UserCenter/UserRealInfo.aspx';}</script>");
                Response.End();
                return;
                
            }
            if (!IsPostBack)
            {
                Bind();
            }
        }

        /// <summary>
        /// 绑定GridView数据
        /// 创建人: zhouwei
        /// 创建时间: 2010-11-3
        /// </summary>
        public void Bind()
        {
            int id = Convert.ToInt32(Input.Decrypt(Request["id"]));
            g_ds = g_Num.GetList("ItemID=" + id);
            gv_ItemListNum.DataSource = g_ds;
            gv_ItemListNum.DataBind();
            
            
           
        }

        protected void gv_ItemListNum_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //查询条件
            int id = Convert.ToInt32(Input.Decrypt(Request["id"]));
            Pbzx.BLL.Market_Page pg = new Pbzx.BLL.Market_Page();
            DataSet ds = new DataSet();
            ds = pg.Market_GetItme("NvarName,TypeName,Intid", "appendID=" + id);
            //localhost.WebService1 web = new Pinble_Market.localhost.WebService1();
            Pinble_Market.admin.WebService1 web = new Pinble_Market.admin.WebService1();
            string ssq = web.selectIssue(ds.Tables[0].Rows[0]["Intid"].ToString());
            int num = this.gv_ItemListNum.Rows.Count;
            for (int i = 0; i < num; i++)
            {
                Label lab_lottery = (Label)this.gv_ItemListNum.Rows[i].Cells[0].FindControl("lab_lottery") as Label;
                Label lab_condition = (Label)this.gv_ItemListNum.Rows[i].Cells[0].FindControl("lab_condition") as Label;
                //Label lab_awardNum = (Label)this.gv_ItemListNum.Rows[i].Cells[0].FindControl("lab_awardNum") as Label;
                lab_condition.Text = ds.Tables[0].Rows[0]["TypeName"].ToString();
                lab_lottery.Text = ds.Tables[0].Rows[0]["NvarName"].ToString();
                //lab_awardNum.Text = ssq.Split('|')[1].ToString();
                string content=g_ds.Tables[0].Rows[i]["content"].ToString();
               
                //判断是否中奖
                Label lab_yn = (Label)this.gv_ItemListNum.Rows[i].Cells[0].FindControl("lab_yn") as Label;
                Label lab_Num = (Label)this.gv_ItemListNum.Rows[i].Cells[0].FindControl("lab_Num") as Label;
                if (lab_condition.Text == "红球胆码" && lab_lottery.Text == "双色球")
                {
                    string[] awar=new string[ssq.Split('|')[1].Split('+')[0].Split(' ').Length-1];
                    StringBuilder sb = new StringBuilder();
                    string[] arr = new string[content.Split(',').Length];
                    for (int j = 0; j < content.Split(',').Length; j++)
                    {
                        arr[j] = content.Split(',')[j];
                        for (int k = 0; k < ssq.Split('|')[1].Split('+')[0].Split(' ').Length - 1; k++)
                        {
                            awar[k] = ssq.Split('|')[1].Split('+')[0].Split(' ')[k];
                            if (arr[j] == awar[k])
                            {
                                sb.Append(arr[j]+" ");
                            }
                        }
                    }
                    if (sb.ToString() != "")
                    {
                        lab_Num.Text = "中奖号码是：<font color='red'>" + sb.ToString() + "</font>";
                    }
                    else
                    {
                        lab_Num.Text = "本期没有中奖号码";
                    }
                }
                //判断3D是否中奖
                if (lab_lottery.Text == "3D")
                {
                    if (lab_condition.Text == "胆码")
                    { 
                        //单选
                        //if()
                        //组选两码
                        //单选两码
                        //string[] awar=new string[]
                    }
                }
            }
        }

    }
}
