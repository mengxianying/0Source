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

namespace Pbzx.Web.PB_Manage.Controls
{
    public partial class TC7XCconfig : System.Web.UI.UserControl
    {
        private Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic();
        protected void Page_Load(object sender, EventArgs e)
        {
            basicDAL.IsCst = true;
        }
        protected void TC7XC_editcode_main()
        {
            string sql = "select top 30 * from TC7XCData order by date desc";
            DataTable dt = basicDAL.GetLisBySql(sql);
           
        }

        //protected void TC7XC_add_code_main(object bModify, object sdate, object sissue)
        //{
        //    string code, money, first, second, summoney, bigsmallmoney, oddevenmoney, subflag;

        //    if (bool.Parse(bModify.ToString()) == false)
        //    {
        //        string sql = "select top 1 * from TC7XCData order by date desc";
        //        DataTable dt = basicDAL.GetLisBySql(sql);

        //        DateTime Datsdate = DateTime.Parse(dt.Rows[0]["date"].ToString());
        //        int tempInt = int.Parse(dt.Rows[0]["issue"].ToString()) + 1;
        //        string Strsissue = tempInt.ToString();

        //        //七星彩开奖为：每周二、周五、周日
        //        switch (sdate.DayOfWeek)
        //        {
        //            case 1: //星期天
        //                sdate = sdate.AddDays(2);//下个星期二
        //                break;
        //            case 3:   //星期二 
        //                sdate = sdate.AddDays(3);//下个星期五
        //                break;
        //            case 6: // 星期五
        //                sdate = sdate.AddDays(3);// 下个星期天 
        //                break;
        //        }

        //        if (sdate > DateTime.Now)
        //        {
        //            Response.Write("<br><br><font color=blue>最新数据已经录入，请到下期开奖日再来录入新的数据！</font><br><br><br><a href='javascript:history.back(1)'>返回体彩七星彩开奖信息管理</a><br>");
        //        }
        //        //跨年处理 
        //        if (sdate.Year != sissue.Substring(0, 4))
        //        {
        //            sissue = DateTime.Now.Year + "001";
        //        }

        //        code = "";
        //        money = "";
        //        first = "5000000";
        //        second = "";
        //        summoney = 0;
        //        bigsmallmoney = 0;
        //        oddevenmoney = 0;
        //        subflag = "add";
        //    }
        //    else
        //    {
        //        sql = "select * from TC7XCData where issue='" + sissue + "'";
        //        DataTable dt = basicDAL.GetLisBySql(sql);
        //        sdate = dt.Rows[0]["date"];
        //        sissue = dt.Rows[0]["issue"];
        //        code = dt.Rows[0]["code"];
        //        summoney = dt.Rows[0]["summoney"];

        //        bigsmallmoney = dt.Rows[0]["bigsmallmoney"];
        //        oddevenmoney = dt.Rows[0]["oddevenmoney"];
        //        money = dt.Rows[0]["money"];
        //        first = dt.Rows[0]["first"];
        //        second = dt.Rows[0]["second"];
        //        subflag = "modify";
        //    }

        //}

      
      
    }
}