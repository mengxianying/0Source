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
using System.Data.SqlClient;

namespace Pbzx.Web
{
    public partial class ChatChangeInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                if(!Page.IsPostBack)
                {
                     BindData();
                }               
        }
        private void BindData()
        {
            this.lblUName.Text = Method.Get_UserName;
            DataSet dsMeChat = DbHelperSQLMeChat.Query("select Top 1 UserName,Alias,Age,Sex,Oicq,Icon,Photo,Resume,Question,Answer from UserInfo where UserName='"+Method.Get_UserName+"' ");            
            if(dsMeChat.Tables.Count > 0 && dsMeChat.Tables[0].Rows.Count > 0)
            {
                DataTable dtMeChat = dsMeChat.Tables[0];
                this.txtAge.Text = dtMeChat.Rows[0]["Age"].ToString();
                this.rblSex.SelectedIndex = Convert.ToInt32(dtMeChat.Rows[0]["Sex"]);
                if (dtMeChat.Rows[0]["Sex"].ToString() == "1")
                {
                    this.rblSex.Items[0].Selected = true;
                    this.rblSex.Items[1].Selected = false;
                }
                else
                {
                    this.rblSex.Items[0].Selected = false;
                    this.rblSex.Items[1].Selected = true;
                }
                this.txtQicq.Text = dtMeChat.Rows[0]["Oicq"].ToString();
                string url = "";
                if(string.IsNullOrEmpty(dtMeChat.Rows[0]["Icon"].ToString()))
                {
                    if (rblSex.Items[0].Selected)
                    {
                        url = "icon/1.gif";
                    }
                    else
                    {
                        url = "icon/0.gif";
                    }                     
                }
                else
                {
                     url="icon/"+dtMeChat.Rows[0]["Icon"].ToString()+".gif";   
                }
                this.imgPhoto.ImageUrl = url;
                hfImg.Value = url;
                this.txtResume.Text = dtMeChat.Rows[0]["Resume"].ToString();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string Age = Input.FilterAll(this.txtAge.Text);
            string sex =  Input.FilterAll(this.rblSex.SelectedValue);
            string Oicq =  Input.FilterHTML(this.txtQicq.Text);
            string[] icon = hfImg.Value.Split(new char[] { '/' });
            string icon1 = icon[1].Substring(0,icon[1].Length -4);
            string resume =  Input.FilterHTML(this.txtResume.Text);
            string uName = Method.Get_UserName;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UserInfo set ");
            strSql.Append("Age=@Age,");
            strSql.Append("sex=@sex,");
            strSql.Append("Oicq=@Oicq,");
            strSql.Append("Icon=@Icon,");
            strSql.Append("Resume=@Resume");
            strSql.Append(" where UserName=@UserName ");
            SqlParameter[] parameters = {
					new SqlParameter("@Age", SqlDbType.Int,4),					
					new SqlParameter("@sex", SqlDbType.Bit,1),
                    new SqlParameter("@Oicq", SqlDbType.VarChar,20),
                    new SqlParameter("@Icon", SqlDbType.VarChar,20),
                    new SqlParameter("@Resume", SqlDbType.VarChar,200),
					new SqlParameter("@UserName", SqlDbType.VarChar,30)};
            parameters[0].Value = Convert.ToInt32(Age);
            parameters[1].Value = Convert.ToInt32(sex);
            parameters[2].Value = Oicq;
            parameters[3].Value = icon1;
            parameters[4].Value = resume;
            parameters[5].Value = uName;
            DbHelperSQLMeChat.ExecuteSql(strSql.ToString(), parameters);            
            DbHelperSQL.ExecuteSql("update PBnet_UserTable set sex='" + sex + "' where UserName='" + uName + "' ");
            DbHelperSQLBBS.ExecuteSql("update Dv_User set UserSex='" + sex + "' where UserName='" + uName + "' ");

            Response.Write("<script>alert('ÐÞ¸Ä³É¹¦£¡');window.returnValue='aaa';self.close();</script>");
        }
    }
}
