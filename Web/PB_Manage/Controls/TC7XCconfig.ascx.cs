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

        //        //���ǲʿ���Ϊ��ÿ�ܶ������塢����
        //        switch (sdate.DayOfWeek)
        //        {
        //            case 1: //������
        //                sdate = sdate.AddDays(2);//�¸����ڶ�
        //                break;
        //            case 3:   //���ڶ� 
        //                sdate = sdate.AddDays(3);//�¸�������
        //                break;
        //            case 6: // ������
        //                sdate = sdate.AddDays(3);// �¸������� 
        //                break;
        //        }

        //        if (sdate > DateTime.Now)
        //        {
        //            Response.Write("<br><br><font color=blue>���������Ѿ�¼�룬�뵽���ڿ���������¼���µ����ݣ�</font><br><br><br><a href='javascript:history.back(1)'>����������ǲʿ�����Ϣ����</a><br>");
        //        }
        //        //���괦�� 
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