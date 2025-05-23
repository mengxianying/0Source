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
using Maticsoft.DBUtility;

namespace Pbzx.Web
{
    public partial class Buy_jiage : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        Repeater DL = new Repeater();
        DataSet ds = new DataSet();
        Pbzx.BLL.PBnet_ProductPrice _pp = new BLL.PBnet_ProductPrice();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
                BindQQ();
                //BindDataList1();
                //BindrepjiageName();
            }
        }
        private void BindData()
        {
            Pbzx.BLL.PBnet_Product ProductBll = new Pbzx.BLL.PBnet_Product();
            this.rptSoft.DataSource = ProductBll.GetList(" pb_TypeName <> '免费版'  and pb_TypeName<>'珍藏版' and pb_freeshow=0 and " + Method.product + " order by countid asc  ");
            this.rptSoft.DataBind();
        }
        public static string GetsoftDog(object objSoftmoney, object pb_TypeName)
        {
            if (pb_TypeName != null && pb_TypeName.ToString() == "出票系统")
            {
                return " - ";
            }
            string[] strSZ = objSoftmoney.ToString().Split(new char[] { '元' });
            int money = 0;
            string danwei = "";
            if (strSZ.Length > 1)
            {
                if (OperateText.IsNumber(strSZ[0]))
                {
                    if (strSZ[0].ToString() == "0")
                    {
                        return " - ";
                    }
                    money = Convert.ToInt32(Convert.ToDecimal(strSZ[0])) + int.Parse(WebInit.webBaseConfig.SoftdogPrice.ToString()) + 20;
                    danwei = strSZ[1];
                }
            }
            else
            {
                return " - ";
            }
           
            return money.ToString()+"元"+danwei;
        }
      
        private void BindQQ()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" 1=1");
            sb.Append(" and BitIsAuditing=1");
            sb.Append("  and IntDisplayPosition=0  order by IntOrderID asc ");
            Pbzx.BLL.PBnet_QQ QqBll = new Pbzx.BLL.PBnet_QQ();
            this.dtQq.DataSource = QqBll.GetList(sb.ToString());
            this.dtQq.DataBind();
        }

        protected string GetPrice(object objPrice)
        {
            if (objPrice != null && objPrice.ToString() != "" )
            {
                if (objPrice.ToString() == "0" || objPrice.ToString().StartsWith("0元"))
                {
                    return " - ";
                }
                return objPrice.ToString();               
            }
            else
            {

                return " - ";
            }
        }

        ///// <summary>
        ///// 绑定软件名称
        ///// </summary>
        //private void BindrepjiageName()
        //{

        //    //dt = DbHelperSQL.Query("select distinct VarVersionType from PBnet_ProductPrice where VarVersionType<>'免费版'").Tables[0];
        //    dt = _pp.SelectAllProductPrice().Tables[0];
        //    repjiage.DataSource = dt;
        //    repjiage.DataBind();
        //}

        //private void BindDataList1()
        //{
        //    DataTable _dat = new DataTable();
        //    _dat = DbHelperSQL.Query("select  VarVersionType from PBnet_ProductPrice where VarVersionType <> '免费版'  and VarVersionType<>'珍藏版' group by VarVersionType").Tables[0];
        //    Repeater1.DataSource = _dat;
        //    Repeater1.DataBind();
        //}
    }
}
