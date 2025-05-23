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
    public partial class Bulletin_c : System.Web.UI.UserControl
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

        private string _intChannelID = "";

        public string IntChannelID
        {
            get { return _intChannelID; }
            set { _intChannelID = value; }
        }



        protected string GetTitleByCount(object title, object shortTitle)
        {
            if (shortTitle != null && !string.IsNullOrEmpty(shortTitle.ToString()))
            {
                return StrFormat.CutStringByNum(shortTitle, this.TitleLength*2);
            }
            else
            {
                return StrFormat.CutStringByNum(title, this.TitleLength*2);
            }
        }



        private void BindData()
        {
            Pbzx.BLL.PBnet_Bulletin MyBLL = new Pbzx.BLL.PBnet_Bulletin();
            Pbzx.BLL.PBnet_BulletinType MyTypeBLL = new Pbzx.BLL.PBnet_BulletinType();
            if (!string.IsNullOrEmpty(TypeName))
            {
                Pbzx.Model.PBnet_BulletinType typemodel = MyTypeBLL.GetModelByTypeName(TypeName);
                if (typemodel == null)
                {
                    return;
                }
                else
                {
                    StringBuilder sb = new StringBuilder(" 1=1 ");
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
                    if (!string.IsNullOrEmpty(_intChannelID))
                    {
                        sb.Append(" and IntChannelID='" + _intChannelID + "' ");
                    }
                    this.DataList1.DataSource = MyBLL.GetTitleListByCount(sb.ToString() + Method.Where_News + Method.NewsPage, this.Count);
                    this.DataList1.DataBind();
                }
            }
            else
            {
                StringBuilder sb = new StringBuilder(" 1=1 ");
                if (!string.IsNullOrEmpty(IntDisPosition.ToString()))
                {
                    sb.Append(" and IntDisPosition='" + IntDisPosition.ToString().Trim() + "' ");
                }
                if (!string.IsNullOrEmpty(_intChannelID))
                {
                    sb.Append(" and IntChannelID='" + _intChannelID + "' ");
                }
                this.DataList1.DataSource = MyBLL.GetTitleListByCount(sb.ToString() + Method.Where_News + Method.NewsPage, this.Count);
                this.DataList1.DataBind();
            }

        }
    }
}