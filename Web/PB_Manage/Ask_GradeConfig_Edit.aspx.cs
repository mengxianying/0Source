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

namespace Pbzx.Web.PB_Manage
{
    public partial class Ask_GradeConfig_Edit : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string str = Request.QueryString["ID"];
                Pbzx.BLL.PBnet_ask_GradeConfig MyBll = new Pbzx.BLL.PBnet_ask_GradeConfig();
                Pbzx.Model.PBnet_ask_GradeConfig MyModel;

                if (OperateText.IsNumber(str))
                {

                    MyModel = MyBll.GetModel(Convert.ToInt32(str));
                    this.txtName.Text = MyModel.GradeName;
                    this.txtMinPoint.Text = MyModel.MinPoint.ToString();
                    this.txtMaxPoint.Text = MyModel.MaxPoint.ToString();
                    this.hfID.Value = MyModel.ID.ToString();
                }
            }
        }
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            string strErrMsg = "";
            if (this.txtName.Text.Trim() == "")
            {
                strErrMsg += "�ȼ����Ʋ���Ϊ��.\\r\\n";
            }
            if (this.txtMinPoint.Text.Trim() == ""&&!OperateText.IsNumber(this.txtMinPoint.Text))
            {
                
                    strErrMsg += "�ȼ���С���ֲ�������.\\r\\n";
               
            }

            if (this.txtMaxPoint.Text.Trim() == ""&&!OperateText.IsNumber(this.txtMaxPoint.Text))
            {
               
                    strErrMsg += "�ȼ������ֲ�������.\\r\\n";
               
            }
            if (strErrMsg != "")
            {
                strErrMsg = "���ύ�������Ϣ�д������´���:\\r\\n\\r\\n" + strErrMsg + "\\r\\n���޸ĺ��������ύ.";
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                return;
            }
            Pbzx.BLL.PBnet_ask_GradeConfig MyBll = new Pbzx.BLL.PBnet_ask_GradeConfig();
            Pbzx.Model.PBnet_ask_GradeConfig MyModel;
            int Myid=Convert.ToInt32(this.hfID.Value);
             if (Myid > 0)
             { 
                 MyModel = MyBll.GetModel(Myid);
             }
             else
             {
                 MyModel = new Pbzx.Model.PBnet_ask_GradeConfig();
             }

            MyModel.GradeName = this.txtName.Text;
            MyModel.MinPoint = int.Parse(this.txtMinPoint.Text);
            MyModel.MaxPoint = int.Parse(this.txtMaxPoint.Text);           
            if (Myid > 0)
            {
                if (MyBll.Update(MyModel))
                {
                   // ClientScript.RegisterStartupScript(this.GetType(), "ok", JS.Alert("�ȼ���Ϣ�޸ĳɹ�."));
                    ClientScript.RegisterStartupScript(this.GetType(), "redirect", JS.Replace("Ask_GradeConfig.aspx"));
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("�ȼ���Ϣ�޸�ʧ��."));
                }
            }
            else
            {
                MyModel.GradeID = Convert.ToString(Convert.ToInt32(DbHelperSQL.GetSingle("select top 1 GradeID from PBnet_ask_GradeConfig order by MaxPoint desc")) + 1);
                if (MyBll.Add(MyModel))
                {
                 //   ClientScript.RegisterStartupScript(this.GetType(), "ok", JS.Alert("�ȼ���Ϣ��ӳɹ�."));
                    ClientScript.RegisterStartupScript(this.GetType(), "redirect", JS.Replace("Ask_GradeConfig.aspx"));
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("�ȼ���Ϣ���ʧ��."));
                }
            }
        }        
    }
}
