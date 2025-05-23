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
using Maticsoft.DBUtility;
using System.Text;

namespace Pinble_Ask.Contorls
{
    public partial class UcType : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();              
            }
        }
        /// <summary>
        /// 绑定问题种类大类别
        /// </summary>
        private void BindData()
        {
            Pbzx.BLL.PBnet_ask_Type typeBLL = new Pbzx.BLL.PBnet_ask_Type();
            DataSet ds = typeBLL.GetList("Depth=0 and BitIsAuditing=1 order by OrderID ");
            this.rptCpBigSort.DataSource = ds;
            this.rptCpBigSort.DataBind();
        }

        protected string FormartClass(object fType)
        {
            Pbzx.BLL.PBnet_ask_Type typeBLL = new Pbzx.BLL.PBnet_ask_Type();
            DataSet ds = typeBLL.GetList("FTypeID=" + fType.ToString() + "and BitIsAuditing=1 order by OrderID ");
            StringBuilder sb = new StringBuilder();
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count <= 2)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        sb.Append("<a href='QuestionList.aspx?type=" + Input.Encrypt(row["Id"].ToString()) + "' target='_self' class='Linl12Green'>" + row["TypeName"] + "</a>&nbsp;&nbsp;&nbsp;&nbsp;");
                    }
                }
                else
                {
                    int kk = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        kk++;
                        sb.Append("<a href='QuestionList.aspx?type=" + Input.Encrypt(row["Id"].ToString()) + "' target='_self' class='Linl12Green'>" + row["TypeName"] + "</a>&nbsp;&nbsp;&nbsp;&nbsp;");
                        if(kk %2 == 0)
                        {
                            if (kk == dt.Rows.Count)
                            {
                            }
                            else
                            {
                                sb.Append("<br/>");
                            }
                        }                        
                    }
                    //sb.Append("<a href='QuestionType.aspx?type=" + fType.ToString() + "' target='_blank'> >> </a>&nbsp;");
                }
            }
            return sb.ToString();
        }

        private string _hasAnswers = "";
        /// <summary>
        /// 已解决问题个数
        /// </summary>
        public string HasAnswers
        {
            get
            {
                int count = (int)DbHelperSQL.GetSingle(" select count(1) from PBnet_ask_Question where State=1 ");
                _hasAnswers = count.ToString();
                return _hasAnswers;
            }
        }

        private string _noAnswers = "";
        /// <summary>
        /// 待解决问题个数
        /// </summary>
        public string NoAnswers
        {
            get
            {
                int count = (int)DbHelperSQL.GetSingle(" select count(1) from PBnet_ask_Question where State=0 ");
                _noAnswers = count.ToString();
                return _noAnswers;
            }
        }

        private string _userCount = "";
        /// <summary>
        /// 拼搏吧用户总数
        /// </summary>
        public string UserCount
        {
            get
            {
                int count = (int)DbHelperSQL.GetSingle(" select count(1) from PBnet_ask_User ");
                _userCount = count.ToString();
                return _userCount;
            }
        }

    }
}