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

namespace Pbzx.Web.PB_Manage.CST
{
    public partial class AgentAgree : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }
        private void BindData()
        {
            Pbzx.BLL.AgentAgree AgentBll = new Pbzx.BLL.AgentAgree();
            MyGridView.DataSource = AgentBll.GetAllList();
            MyGridView.DataBind();
        }
        
        protected void MyGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (this.MyGridView.Rows.Count <= 1)
            {
                e.Cancel = true;
                JS.Alert("���뱣֤������һ����¼");
            }
            int id = int.Parse(MyGridView.DataKeys[e.RowIndex].Value.ToString());
            string nvarname = MyGridView.DataKeys[e.RowIndex].Values["Title"].ToString();
            Pbzx.BLL.AgentAgree bll = new Pbzx.BLL.AgentAgree();
            if (bll.Delete(id))
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("ɾ��", "ɾ������Э��[" + nvarname + "]");
                //ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("��ɾ����" + del + "����¼.", "FriendLink_Manage.aspx"));
                JS.Alert("ɾ������[" + nvarname + "]�ɹ���");
            }
            BindData();
        }

        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = "("+id.ToString()+")";
            }
        }
        //�û�����
        public static string GetState(object num)
        {
            string state = "";
            int Intnum = int.Parse(num.ToString());
            switch (Intnum)
            {
                case 0:
                    state = "<font color='#003399'>�����</font>";
                    break;
                case 1:
                    state = "<font color=red>δ���</font>";
                    break;
                default:
                    state = "<font color='#888888'>δ֪</font>";
                    break;
            }
            return state;
        }
    }
}
