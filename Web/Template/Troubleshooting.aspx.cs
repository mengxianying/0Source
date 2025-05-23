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

namespace Pbzx.Web
{
    public partial class Troubleshooting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
                BindQQ();
            }
        }
        private void BindData()
        {
            Pbzx.BLL.PBnet_Product ProductBll = new Pbzx.BLL.PBnet_Product();
            this.rptSoft.DataSource = ProductBll.GetList(" pb_TypeName <> '免费版'  and pb_TypeName<>'珍藏版'  and " + Method.product + " order by countid asc  ");
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
                return objPrice.ToString();               
            }
            else
            {

                return " - ";
            }
        }
    }
}
