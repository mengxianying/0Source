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

namespace Pbzx.Web.PB_Manage
{
    public partial class Group_Manage : System.Web.UI.Page
    {
        protected DataTable Dview;
        protected Hashtable tbRS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               WebFunc.GetModules();             
            }
        }

        protected void bindRights()
        {
            Pbzx.BLL.PBnet_Module ModuleBLL = new Pbzx.BLL.PBnet_Module();            
            dlRoot.DataSource = ModuleBLL.GetRootList();
            dlRoot.DataBind();
        }

        protected string getChild(object mName, object mRoot)
        {
            int root = Convert.ToInt32(mRoot);
            Pbzx.BLL.PBnet_Module ModuleBLL = new Pbzx.BLL.PBnet_Module();            
            Dview = ModuleBLL.GetList("Depth =1 AND RootID=" + root).Tables[0];
            string name = mName.ToString();
            name = "<b>" + name + "</b>";
            return name;
        }

        protected string showRights(object mUrl)
        {
            string url = mUrl.ToString().ToLower();
            int[] RS ={ 0, 0, 0, 0 };
            if (tbRS.Count > 0)
            {
                RS = (int[])tbRS[url];
            }

            string result = "";
            string[] txt = { "查看", "新增", "修改", "删除" };
            for (int i = 0; i < 4; i++)
            {
                if (RS == null || RS[i] == 0)
                {
                    result += txt[i] + "<input type=\"checkbox\" name=\"" + url + "\" value=\"" + i + "\" /> ";
                }
                else
                {
                    result += txt[i] + "<input type=\"checkbox\" name=\"" + url + "\" value=\"" + i + "\" checked=\"checked\" /> ";
                }
            }
            return result;
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {           
            hfID.Value = "0";
            divOperator.Visible = false;
            divList.Visible = true;
        }

        protected void MyGridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
        }

        protected void MyGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }

        protected void DelGroup(string e)
        {
        }

        protected void ShowEditor(string e)
        {
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
        }
    }
}
