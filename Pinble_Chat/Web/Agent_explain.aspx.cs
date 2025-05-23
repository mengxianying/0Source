using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using Pbzx.Common;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Pbzx.Web
{
    public partial class Agent_explain : System.Web.UI.Page
    {
        public string stragttype = "";
        public string strName = "";
        public string strEMail = "";
        public string strTelephone = "";
        public string strAddress = "";
        public string strMobile = "";
        public string strRemark = "";
        public string stragtmore = "";
        public string strPostmore = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.Params["id"]))
                {
                    string id = Input.FilterAll(Request.Params["id"]);
                    if (OperateText.IsNumber(id))
                    {
                        ShowNews(int.Parse(id));
                    }
                }
            }
        }
        private void ShowNews(int id)
        {
          Pbzx.BLL.AgentInfo MyBLL = new Pbzx.BLL.AgentInfo();
          Pbzx.Model.AgentInfo Model = MyBLL.GetModel(id);

          stragttype =Model.agttype;
          strName = Model.Name;
          strEMail = Model.EMail;
          strTelephone = Model.Telephone;
          strAddress = Model.Address;
          strMobile = Model.Mobile;
          strRemark = Model.Remark;
          strPostmore = Model.postmore;
        }
    }
}
