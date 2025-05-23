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

namespace Pbzx.Web.Contorls
{
    public partial class UcSchoolHot : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        private int _titleLength;

        public int TitleLength
        {
            get { return _titleLength; }
            set { _titleLength = value; }
        }

        private int _count;

        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }

        private string _typeName = "";

        public string TypeName
        {
            get { return _typeName.Trim(); }
            set { _typeName = value; }
        }
        private string intDisPosition = "";

        public string IntDisPosition
        {
            get { return intDisPosition.Trim(); }
            set { intDisPosition = value; }
        }
        private int _isHot;

        public int IsHot
        {
            get { return _isHot; }
            set { _isHot = value; }
        }

        private void BindData()
        {
            string strHot = "";
            if (IsHot > 0)
            {
                strHot = Method.CheckNewsHot(true);
            }
            else if (IsHot == 0)
            {
                strHot = "";
            }
            else
            {
                strHot = Method.CheckNewsHot(false);
            }

            Pbzx.BLL.PBnet_School MyBLL = new Pbzx.BLL.PBnet_School();
            Pbzx.BLL.PBnet_SchoolType MyTypeBLL = new Pbzx.BLL.PBnet_SchoolType();

            if (!string.IsNullOrEmpty(TypeName))
            {
                Pbzx.Model.PBnet_SchoolType typemodel = MyTypeBLL.GetModelByTypeName(TypeName);
                if (typemodel == null)
                {
                    return;
                }
                else
                {
                    StringBuilder sb = new StringBuilder(" 1=1 ");
                    sb.Append(strHot);
                    sb.Append(" and IntShowType=" + typemodel.IntNewsTypeID + " ");
                    if (!string.IsNullOrEmpty(IntDisPosition.ToString()))
                    {
                        if (!OperateText.IsNumber(IntDisPosition))
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "no", "需要设置数字！");
                            return;
                        }
                        sb.Append(" and IntDisPosition='" + IntDisPosition + "' ");
                    }//NewsFilter
                    this.Repeater1.DataSource = MyBLL.GetTitleListByCount(sb.ToString() + Method.Where_News + " order by DatDateAndTime desc  ", this.Count);
                    this.Repeater1.DataBind();
                }
            }
            else
            {
                StringBuilder sb = new StringBuilder(" 1=1 ");
                sb.Append(strHot);
                if (!string.IsNullOrEmpty(IntDisPosition.ToString()))
                {
                    sb.Append(" and IntDisPosition='" + IntDisPosition.ToString().Trim() + "' ");
                }
                this.Repeater1.DataSource = MyBLL.GetTitleListByCount(sb.ToString() + Method.Where_News + "order by DatDateAndTime desc ", this.Count);
                this.Repeater1.DataBind();
            }

        }
    }
}