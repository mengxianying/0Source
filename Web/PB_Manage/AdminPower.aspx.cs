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

namespace Pbzx.Web.PB_Manage
{
    public partial class AdminPower : AdminBasic
    {
        protected DataTable Dview;
        protected Hashtable tbRS;
     
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                if (ViewState["currentUser"] == null)
                {
                    ViewState["currentUser"] = Input.FilterAll(Request["curUser"]);
                }

                if (string.IsNullOrEmpty(ViewState["currentUser"].ToString()))
                {
                    Response.Redirect("Master_Manage.aspx");
                    return;
                }
                bindRights();
            }
        }

        protected void bindRights()
        {
            Pbzx.BLL.PBnet_Module ModuleBLL = new Pbzx.BLL.PBnet_Module();
            dlRoot.DataSource = ModuleBLL.GetRootList(true);
            dlRoot.DataBind();
        }

        protected string getChild(object mName, object mRoot)
        {
            int root = Convert.ToInt32(mRoot);
            Pbzx.BLL.PBnet_Module ModuleBLL = new Pbzx.BLL.PBnet_Module();
            Dview = ModuleBLL.GetList(" Depth =1 AND RootID=" + root).Tables[0];
            string name = mName.ToString();
            name = "<b>" + name + "</b>";
            return name;
        }

        protected string showRights(object name, object mUrl,object id)
        {
            string result = "";
            string url = mUrl.ToString().ToLower();


            bool isHas = DbHelperSQL.Exists("select count(1) from PBnet_tpman where Master_Name='" + ViewState["currentUser"].ToString() + "' and charindex('" + Method.AdminPowerSettingFormart(id) + "',Setting) > 0 ");
            if (!isHas)
            {
                result += name + "<input type=\"checkbox\" name=\"myPower.aspx\" value=\"" + id + "\" /> ";
            }
            else
            {
                result += name + "<input type=\"checkbox\" name=\"myPower.aspx\" value=\"" + id + "\" checked=\"checked\" /> ";
            }
            return result;
        }


        private string  EnCodePower()
        {
            StringBuilder sb = new StringBuilder();
            ArrayList arr = new ArrayList();
            foreach (string str in Request.Form)
            {
                string tmpstr = str.ToLower();
                if (tmpstr.IndexOf(".aspx") == -1) continue;
                string[] res = Request.Form.GetValues(str);                             
                foreach(string strSZ in res)
                {
                    arr.Add(Method.AdminPowerSettingFormart(strSZ));                 
                }               
            }
            arr.Sort();
            foreach(object obj in arr)
            {
                sb.Append(obj.ToString()+ ",");
            }
            if(sb.Length  > 1)
            {
                sb.Remove(sb.Length -1,1);
            }
            return sb.ToString();
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            if (DbHelperSQL.ExecuteSql("update PBnet_tpman set Setting='" + EnCodePower() + "' where Master_Name='" + ViewState["currentUser"].ToString() + "' ") > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("�޸�", "�޸�[" + ViewState["currentUser"].ToString() + "]Ȩ��");
                ClientScript.RegisterStartupScript(this.GetType(), "ok", JS.Alert("�û�Ȩ���޸ĳɹ�.\\r\\n���û�Ȩ���趨�����´ε�¼ʱ��Ч��"));
                ClientScript.RegisterStartupScript(this.GetType(), "redirect", JS.Replace("Master_Manage.aspx"));
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "redError", JS.Alert("�û�Ȩ���޸�ʧ�ܣ�"));
            }
        }
    }
}
