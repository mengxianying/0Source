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

namespace Pinble_Ask
{
    public partial class Help : System.Web.UI.Page
    {
        public string WebTitle = "";
        public string wenkf = "";
        public string dakf = "";
        public string dajiadf = "";
        public string clwendf = "";

        public string regf = "";
        public string dadf = "";
        public string pldf = "";
        public string tjwendf = "";
        public string tjdadf = "";

        public string hpdadf = "";
        public string twf = "";
        public string mdf = "";
        public string plkf = "";
        public string gqkf = "";

        public string Overdue = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                WebTitle = WebInit.siteconfig.WebTitle;
                wenkf = WebInit.siteconfig.wenkf;
                dakf = WebInit.siteconfig.dakf;

                dajiadf = WebInit.siteconfig.dajiadf;
                clwendf = WebInit.siteconfig.clwendf;
               
                regf = WebInit.siteconfig.regf;
                dadf = WebInit.siteconfig.dadf;

                tjwendf = WebInit.siteconfig.tjwendf;
                tjdadf = WebInit.siteconfig.tjdadf;

                mdf = WebInit.siteconfig.mdf;
                gqkf = WebInit.siteconfig.gqkf;
                plkf = WebInit.siteconfig.plkf;
                Overdue = WebInit.siteconfig.OverTime;
               
                BindData();
            }
        }
        private void BindData()
        {
            Pbzx.BLL.PBnet_ask_GradeConfig MyBll = new Pbzx.BLL.PBnet_ask_GradeConfig();
            this.Repeater1.DataSource = MyBll.GetAllList();
            this.Repeater1.DataBind();
        }
    }
}


















//<%--                                        <tr bgcolor="#ffffff">
//                                            <td height="30" colspan="3" align="left">
//                                                <strong>���ٴ���</strong></td>
//                                        </tr>
//                                        <tr bgcolor="#ffffff">
//                                            <td height="35" align="left">
//                                                <span style="font-weight: 400">�����������</span></td>
//                                            <td height="35" align="left">
//                                                <span style="font-weight: 400">��<%=clwendf%></span></td>
//                                            <td height="35" align="left">
//                                                <span style="font-weight: 400">�����߶Թ���������д�������������Ѵ𰸺�ѡ��������𰸣������Ի��ϵͳ������<%=clwendf%>��</span></td>
//                                        </tr>--%>