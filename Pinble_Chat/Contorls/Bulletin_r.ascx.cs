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

namespace Pinble_Chat.Contorls
{
    public partial class Bulletin_r : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();             
            }
        }
       
        private int _titleLength;
        /// <summary>
        /// 标题长度
        /// </summary>
        public int TitleLength
        {
            get { return _titleLength; }
            set { _titleLength = value; }
        }

        private int _count;
        /// <summary>
        /// 显示多少条
        /// </summary>
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }

        private string _typeName = "";
        /// <summary>
        ///所属类别名称
        /// </summary>
        public string TypeName
        {
            get { return _typeName.Trim(); }
            set { _typeName = value; }
        }

        private string intDisPosition = "";
        /// <summary>
        /// 显示位置        
        /// </summary>
        public string IntDisPosition
        {
            get { return intDisPosition.Trim(); }
            set { intDisPosition = value; }
        }

        private string _classCss = "newslink";
        /// <summary>
        /// 内容行使用样式
        /// </summary>
        public string ClassCss
        {
            get { return _classCss; }
            set { _classCss = value; }
        }

        private string _intChannelID = "";

        public string IntChannelID
        {
            get { return _intChannelID; }
            set { _intChannelID = value; }
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
                    this.Repeater1.DataSource = MyBLL.GetTitleListByCount(sb.ToString() + Method.Where_News + " order by DatDateAndTime desc  ", this.Count);
                    this.Repeater1.DataBind();
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
                this.Repeater1.DataSource = MyBLL.GetTitleListByCount(sb.ToString() + Method.Where_News + "order by DatDateAndTime desc ", this.Count);
                this.Repeater1.DataBind();
            }

        }
    }
}