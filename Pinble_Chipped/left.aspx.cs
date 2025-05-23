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
using Pbzx.Common;

namespace Pinble_Chipped
{
    public partial class left : System.Web.UI.Page
    {
        public string lblText = "修改";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                object objMBWT = DbHelperSQLBBS.GetSingle(" select UserQuesion from Dv_User where UserName='" + Method.Get_UserName + "' ");

                if (objMBWT != null && objMBWT.ToString() != "")
                {
                    lblText = "修改";
                }
                else
                {
                    lblText = "设置";
                }
                BindFcSeq();
                BindFc3D();
                BindFcQlc();
                BindPl3();
                BindPl5();
                BindQxc();
                Bind22x5();
            }
        }
        /// <summary>
        /// 绑定双色球的条件
        /// </summary>
        private void BindFcSeq()
        {
            Pbzx.BLL.Market_Page get_page = new Pbzx.BLL.Market_Page();
            DataSet ds = get_page.Market_GetNum("distinct TypeName", "NvarName='双色球' and TypeName is not null");
            this.rep_FcSeq.DataSource = ds;
            this.rep_FcSeq.DataBind();
        }
        /// <summary>
        /// 绑定福彩3D
        /// </summary>
        private void BindFc3D()
        {
            Pbzx.BLL.Market_Page get_page = new Pbzx.BLL.Market_Page();
            DataSet ds = get_page.Market_GetNum("distinct TypeName", "NvarName='3D' and TypeName is not null");
            this.rep_Fc3D.DataSource=ds;
            this.rep_Fc3D.DataBind();
        }
        /// <summary>
        /// 绑定福彩七乐彩的条件
        /// </summary>
        private void BindFcQlc()
        {
            Pbzx.BLL.Market_Page get_page = new Pbzx.BLL.Market_Page();
            DataSet ds = get_page.Market_GetNum("distinct TypeName", "NvarName='七乐彩' and TypeName is not null");
            this.rep_FcQlc.DataSource = ds;
            this.rep_FcQlc.DataBind();
        }
        /// <summary>
        /// 绑定排列3的条件
        /// </summary>
        private void BindPl3()
        {
            Pbzx.BLL.Market_Page get_page = new Pbzx.BLL.Market_Page();
            DataSet ds = get_page.Market_GetNum("distinct TypeName", "NvarName='排列三' and TypeName is not null");
            this.rep_pl3.DataSource = ds;
            this.rep_pl3.DataBind();
        }
        /// <summary>
        /// 绑定排列5的条件
        /// </summary>
        private void BindPl5()
        {
            Pbzx.BLL.Market_Page get_page = new Pbzx.BLL.Market_Page();
            DataSet ds = get_page.Market_GetNum("distinct TypeName", "NvarName='排列五' and TypeName is not null");
            this.rep_pl5.DataSource = ds;
            this.rep_pl5.DataBind();
        }
        /// <summary>
        /// 绑定七星彩
        /// </summary>
        private void BindQxc()
        {
            Pbzx.BLL.Market_Page get_page = new Pbzx.BLL.Market_Page();
            DataSet ds = get_page.Market_GetNum("distinct TypeName", "NvarName='七星彩' and TypeName is not null");
            this.rep_Qxc.DataSource = ds;
            this.rep_Qxc.DataBind();
        }
        /// <summary>
        /// 绑定22选5彩种
        /// </summary>
        private void Bind22x5()
        { 
            Pbzx.BLL.Market_Page get_page = new Pbzx.BLL.Market_Page();
            DataSet ds = get_page.Market_GetNum("distinct TypeName", "NvarName='22选5' and TypeName is not null");
            this.rep_22x5.DataSource = ds;
            this.rep_22x5.DataBind();
        }
    }
}

