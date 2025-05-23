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

namespace Pbzx.Web
{
    public partial class Synchronous : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                LoginSort login = new LoginSort();
                this.txtBbsName.Text = Method.Get_UserName;
                this.txtBbsPWD.Text = Method.Get_UserPwd;
                this.txtLcsName.Text = Method.Get_UserName;
                this.txtLcsPWD.Text = Method.Get_UserPwd;
            }
        }

        protected void btnTB_Click(object sender, EventArgs e)
        {
            //��̨������֤
            string strErrMsg = "";
            if (this.txtBbsName.Text.Trim() == "" || this.txtBbsName.Text.Length>12)
            {
                strErrMsg += "��̳�û�������Ϊ�ջ򳬹�12���ַ���\\r\\n";
            }
            else if (this.txtBbsPWD.Text.Trim() == "" || this.txtBbsPWD.Text.Length > 16)
            {
                strErrMsg += "��̳�����벻��Ϊ�ջ򳬹�16���ַ���\\r\\n";
            }
            else if (this.txtLcsName.Text.Trim() == "" || this.txtLcsName.Text.Length > 12)
            {
                strErrMsg += "�Ĳ����û�������Ϊ�ջ򳬹�12���ַ���\\r\\n";
            }
            else if (this.txtLcsPWD.Text.Trim() == "" || this.txtLcsPWD.Text.Length > 16)
            {
                strErrMsg += "�Ĳ������벻��Ϊ�ջ򳬹�16���ַ���\\r\\n";
            }
            if (strErrMsg != "")
            {
                strErrMsg = "���ύ���Ĳ���ͬ����Ϣ�д������´���:\\r\\n\\r\\n" + strErrMsg + "\\r\\n���޸ĺ��������ύ.";
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
               
                return;
            }
            else
            {
                #region �ж���̳�û����������Ƿ���ȷ
                //�����ı��� ��ֹע�빥��
                string  bbsName = Input.FilterAll(this.txtBbsName.Text);
                string bbsPWD = Input.FilterAll(this.txtBbsPWD.Text);
                DataSet ds = DbHelperSQLBBS.Query("select top 1 * from Dv_User where UserName='" + bbsName + "'");
                if (!(ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "login", JS.Alert("��̳�û��������벻��ȷ!�޷�ͬ����"));
                   
                    return;
                }
                DataRow rowData = ds.Tables[0].Rows[0];
                if (rowData["UserPassword"].ToString() != Input.MD5(bbsPWD))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "login", JS.Alert("��̳�û��������벻��ȷ!�޷�ͬ����"));
                   
                    return;
                }
                #endregion

                #region �ж��Ĳ��� �û����������Ƿ���ȷ
                string chatName = Input.FilterAll(this.txtLcsName.Text);
                string chatPWD = Input.FilterAll(this.txtLcsPWD.Text);
                DataSet dsChat = DbHelperSQLMeChat.Query("select top 1 * from UserInfo2 where UserName='" + chatName + "'");
                if (!(dsChat.Tables.Count > 0 && dsChat.Tables[0].Rows.Count > 0))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "login", JS.Alert("�Ĳ����û��������벻��ȷ!�޷�ͬ����"));
                   
                    return;
                }
                DataRow rowDataChat = dsChat.Tables[0].Rows[0];
                string tempChatPWD = rowDataChat["Password"].ToString();
                if (tempChatPWD.Length == 16 && !Method.IsContainsNum(tempChatPWD))
                {
                    if (tempChatPWD != Input.MD5(chatPWD))
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "login", JS.Alert("�Ĳ����û��������벻��ȷ!�޷�ͬ����"));
                       
                        return;
                    }
                }
                else
                {
                    if (tempChatPWD != chatPWD)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "login", JS.Alert("�Ĳ����û��������벻��ȷ!�޷�ͬ����"));
                       
                        return;
                    }
                }
                #endregion


                ///�����û�ԭ�Ĳ��Ҽ�¼��¼�����±�
                int copy = DbHelperSQLMeChat.ExecuteSql("insert  into dbo.userInfo select * from userInfo2 where userInfo2.UserName='" + chatName + "'");
                ///�����û��Ĳ����û�������Ϊ��̳�û���ʵ��ͬ��
                int update = DbHelperSQLMeChat.ExecuteSql("update userInfo set userName='" + bbsName + "'");                
                if (copy > 0 && update > 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "login", "<script type='text/javascript'>$(document).ready(function(){ReturnDivValue('success');});</script> ");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "login", "<script type='text/javascript'>$(document).ready(function(){ReturnDivValue('fail');});</script> ");
                }
                //�رմ˴��ڲ�ˢ�¸�����            
            }            
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "login", "<script type='text/javascript'>$(document).ready(function(){ReturnDivValue('newUser');});</script> ");
        }


        
    }
}
