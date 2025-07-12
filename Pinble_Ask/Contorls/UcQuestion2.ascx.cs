using System;
using System.Web.UI;
using System.Text;
using Pbzx.Common;

namespace Pinble_Ask.Contorls
{
    public partial class UcQuestion2 : System.Web.UI.UserControl
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
        /// 显示多少条数据
        /// </summary>
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }

        private string _typeName = "";
        /// <summary>
        /// 所属类别名称
        /// </summary>
        public string TypeName
        {
            get { return _typeName.Trim(); }
            set { _typeName = value; }
        }

        private string _isHot = "";
        /// <summary>
        /// 是否热门,1代表热点，0代表不是热点， 默认为热点与非热点混合
        /// </summary>
        public string IsHot
        {
            get { return _isHot; }
            set { _isHot = value; }
        }

        private string _state = "";
        /// <summary>
        /// 状态：0-待解决；1-已解决；2-已关闭。默认或者空字符串-混合
        /// </summary>
        public string State
        {
            get { return _state; }
            set { _state = value; }
        }


        private string _isCommend = "";
        /// <summary>
        /// 是否是精彩推荐（1：推荐 0：不推荐，默认为混合）
        /// </summary>
        public string IsCommend
        {
            get { return _isCommend; }
            set { _isCommend = value; }
        }

        private string _isHighLargessPoint = "";
        /// <summary>
        /// 是否是高悬赏问题（1：是 0：不是，默认为混合）
        /// </summary>
        public string IsHighLargessPoint
        {
            get { return _isHighLargessPoint; }
            set { _isHighLargessPoint = value; }
        }

        protected string FormartReplys(object objId)
        {
            Pbzx.BLL.PBnet_ask_Reply replyBLL = new Pbzx.BLL.PBnet_ask_Reply();
            return replyBLL.GetSingleData("select count(1) from PBnet_ask_Reply where  Deleted=0 and QuestionId='" + objId.ToString() + "' ").ToString();
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            //是否是热点
            string strHot = "";
            if (IsHot == "1")
            {

                strHot = Method.CheckQuestionHot(true);
            }
            else if (IsHot == "0")
            {
                strHot = Method.CheckQuestionHot(false);
            }

            //状态（待解决，未解决，已关闭）
            string strState = "";
            if (State == "0")
            {
                strState = " and State=0 ";
            }
            else if (State == "1")
            {
                strState = " and State=1 ";
            }
            else if (State == "2")
            {
                strState = " and State=2 ";
            }

            //是否推荐
            string strCommend = "";
            if (IsCommend == "0")
            {
                strCommend = "and IsCommend=0 ";
            }
            else if (IsCommend == "1")
            {
                strCommend = "and IsCommend=1 ";
            }

            //是否是高悬赏问题
           // string strHighLargessPoint = "";
            if (IsHighLargessPoint == "0")
            {
                strCommend = "and LargessPoint < " + WebInit.ask.AskHighLargessPoint + " ";
            }
            else if (IsHighLargessPoint == "1")
            {
                strCommend = "and LargessPoint >= " + WebInit.ask.AskHighLargessPoint + " ";
            }





            Pbzx.BLL.PBnet_ask_Question questionBLL = new Pbzx.BLL.PBnet_ask_Question();

            Pbzx.BLL.PBnet_ask_Type askTypeBLL = new Pbzx.BLL.PBnet_ask_Type();
            StringBuilder sb = new StringBuilder(" 1=1 ");
            sb.Append(strState);
            sb.Append(strHot);
            sb.Append(strCommend);

            if (!string.IsNullOrEmpty(TypeName))
            {
                Pbzx.Model.PBnet_ask_Type typemodel = askTypeBLL.GetModelByTypeName(TypeName);
                if (typemodel == null)
                {
                    return;
                }
                else
                {
                    sb.Append(" and TypeName='" + typemodel.TypeName + "' ");
                    this.Repeater1.DataSource = questionBLL.GetTitleListByCount(sb.ToString(), this.Count);
                    this.Repeater1.DataBind();
                }
            }
            else
            {
                this.Repeater1.DataSource = questionBLL.GetTitleListByCount(sb.ToString(), this.Count);
                this.Repeater1.DataBind();
            }

        }
    }
}