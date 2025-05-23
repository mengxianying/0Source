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

namespace Pinble_Chat
{
    public partial class Reg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Response.CacheControl = "no-cache";
                Response.Expires = 0;

                //��֤����ڣ������̰��µ�ʱ����֤�Ƿ���ȷ
                if (!string.IsNullOrEmpty(Request["keyUpCheckVerifyCode"]) && !string.IsNullOrEmpty(Request["type"]))
                {
                    if (Request["type"] == "1")
                    {
                        keyUpCheckVerifyCode(Request["keyUpCheckVerifyCode"], 1);
                    }
                    else
                    {
                        keyUpCheckVerifyCode(Request["keyUpCheckVerifyCode"], 2);
                    }
                }
                //��֤�û���ʾ�����ǹ�����
                if (Request["cueName"] != null)
                {
                    Response.Clear();
                    string UserName = Server.UrlDecode(Input.FilterAll(Request["cueName"]));
                    string record = "false";
                    DataSet ds_cue = DbHelperSQLBBS.Query("select UserQuesion,UserAnswer,UserPassword from Dv_user where UserName=" + "'" + UserName + "'");
                    if (ds_cue != null && ds_cue.Tables[0].Rows.Count > 0)
                    {
                        if (ds_cue.Tables[0].Rows[0]["UserQuesion"].ToString() == "" || ds_cue.Tables[0].Rows[0]["UserAnswer"].ToString() == "")
                        {
                            record = "true";
                            Method.record_user_log(UserName, "", "��������Ϊ��", "�������");
                        }
                    }

                    Response.Write(record);
                    Response.End();
                }
            }
        }

        /// <summary>
        /// �����֤���Ƿ���ȷ
        /// </summary>
        /// <param name="text"></param>
        /// <param name="type"></param>
        private void keyUpCheckVerifyCode(string text, int type)
        {
            Response.Clear();
            object objSession = null;
            if (type == 1)
            {
                objSession = Session["ValidateCode"];
            }
            else if (type == 2)
            {
                objSession = Session["Code"];
            }
            if (objSession != null)
            {
                if (objSession.ToString().ToUpper() == text.ToUpper())
                {
                    Response.Write("true");
                }
                else
                {
                    Response.Write("false");
                }
            }
            else
            {
                Response.Write("��֤���Ѿ�ʧЧ��������֤��ͼƬ���»�ȡ��֤��");
            }
            Response.End();
        }
    }
}
