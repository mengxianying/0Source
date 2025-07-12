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
        /// ���ⳤ��
        /// </summary>
        public int TitleLength
        {
            get { return _titleLength; }
            set { _titleLength = value; }
        }

        private int _count;
        /// <summary>
        /// ��ʾ����������
        /// </summary>
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }

        private string _typeName = "";
        /// <summary>
        /// �����������
        /// </summary>
        public string TypeName
        {
            get { return _typeName.Trim(); }
            set { _typeName = value; }
        }

        private string _isHot = "";
        /// <summary>
        /// �Ƿ�����,1�����ȵ㣬0�������ȵ㣬 Ĭ��Ϊ�ȵ�����ȵ���
        /// </summary>
        public string IsHot
        {
            get { return _isHot; }
            set { _isHot = value; }
        }

        private string _state = "";
        /// <summary>
        /// ״̬��0-�������1-�ѽ����2-�ѹرա�Ĭ�ϻ��߿��ַ���-���
        /// </summary>
        public string State
        {
            get { return _state; }
            set { _state = value; }
        }


        private string _isCommend = "";
        /// <summary>
        /// �Ƿ��Ǿ����Ƽ���1���Ƽ� 0�����Ƽ���Ĭ��Ϊ��ϣ�
        /// </summary>
        public string IsCommend
        {
            get { return _isCommend; }
            set { _isCommend = value; }
        }

        private string _isHighLargessPoint = "";
        /// <summary>
        /// �Ƿ��Ǹ��������⣨1���� 0�����ǣ�Ĭ��Ϊ��ϣ�
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
        /// ������
        /// </summary>
        private void BindData()
        {
            //�Ƿ����ȵ�
            string strHot = "";
            if (IsHot == "1")
            {

                strHot = Method.CheckQuestionHot(true);
            }
            else if (IsHot == "0")
            {
                strHot = Method.CheckQuestionHot(false);
            }

            //״̬���������δ������ѹرգ�
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

            //�Ƿ��Ƽ�
            string strCommend = "";
            if (IsCommend == "0")
            {
                strCommend = "and IsCommend=0 ";
            }
            else if (IsCommend == "1")
            {
                strCommend = "and IsCommend=1 ";
            }

            //�Ƿ��Ǹ���������
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