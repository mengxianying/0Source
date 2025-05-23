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
using System.Data.SqlClient;
using System.Text;

namespace Pbzx.Web.PB_Manage
{
    public partial class MsgDetail : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Buffer = true;
            Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);
            Response.Expires = 0;
            Response.CacheControl = "no-cache";
            if (!Page.IsPostBack)
            {
                WebFunc.BindFriends(this.ddlFriends);
                try
                {
                    string GroupSetting = DbHelperSQLBBS.GetSingle("select top 1 GroupSetting from Dv_UserGroups where usertitle in(select top 1 UserClass from dv_user where username='拼搏在线')").ToString();
                    string[] GroupSettingSZ = GroupSetting.Split(new char[] { ',' });
                    int senduserCount = 1;
                    senduserCount = Convert.ToInt32(GroupSettingSZ[33]);
                    this.lblSenduserCount.Text = senduserCount.ToString();

                    //今日可发信息数目
                    int todayCount = WebFunc.GetUserTodayMSG("拼搏在线");
//                    this.lblTodayCount.Text = Convert.ToString(Convert.ToInt32(GroupSettingSZ[63]) - todayCount);
                    if (Convert.ToInt32(GroupSettingSZ[63]) != 0)
                    {
                        this.lblTodayCount.Text = Convert.ToString(Convert.ToInt32(GroupSettingSZ[63]) - todayCount);
                    }
                    else
                    {
                        this.lblTodayCount.Text = "9999";
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('此用户信息异常，请与管理员联系');top.location='/Default.htm';</script>");
                    return;
                }
                if (!string.IsNullOrEmpty(Request["action"]))
                {
                    string action = Request["action"];
                    string msgId = "";
                    if (action == "new")//撰写短消息
                    {
                        this.tbSend.Visible = true;
                        this.tbRead.Visible = false;
                        this.tbAlert.Visible = false;
                        this.ibtnDel.Visible = false;
                        imgClose.Visible = false;
                    }
                    else
                    {

                        msgId = Input.FilterAll(Request["id"]);
                        this.ibtnDel.Visible = true;
                        DataSet ds = DbHelperSQLBBS.Query("select id,sender,incept,title,content,flag,sendtime,delR,delS,isSend from Dv_Message where id=" + msgId + " ");
                        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow row = ds.Tables[0].Rows[0];
                            if (action == "read")//收信箱
                            {
                                if (row["incept"].ToString().ToLower() != "拼搏在线")
                                {
                                    this.tbAlert.Visible = true;
                                    this.tbSend.Visible = false;
                                    this.tbRead.Visible = false;
                                    this.lblAlertTitle.Text = "您在\"<font color='red'>阅读短信</font>\"的时候发生错误,下面是错误的详细信息";
                                    this.lblAlertContent.Text = "你是不是跑到别人的信箱啦、或者该信息已经被收件人删除。 <p>请确保您有相应的操作权限。 ";
                                }
                                else
                                {
                                    DbHelperSQLBBS.Query("update Dv_Message set flag=1  where id=" + msgId + " ");
                                    this.tbRead.Visible = true;
                                    this.tbSend.Visible = false;
                                    this.tbAlert.Visible = false;
                                    lblTime.Text = "在" + row["sendtime"] + "，" + row["sender"] + " 给您发送的消息！ ";
                                    lblTitle.Text = row["title"].ToString();
                                    lblContent.Text = Input.ToTxt(row["content"].ToString());
                                }
                            }
                            else if (action == "myRead")
                            {
                                if (row["sender"].ToString().ToLower() != "拼搏在线")
                                {
                                    this.tbAlert.Visible = true;
                                    this.tbSend.Visible = false;
                                    this.tbRead.Visible = false;
                                    this.lblAlertTitle.Text = "您在\"<font color='red'>阅读短信</font>\"的时候发生错误,下面是错误的详细信息";
                                    this.lblAlertContent.Text = "你是不是跑到别人的信箱啦、或者该信息已经被收件人删除。 <p>请确保您有相应的操作权限。 ";
                                }
                                else
                                {
                                    this.tbRead.Visible = true;
                                    this.tbSend.Visible = false;
                                    this.tbAlert.Visible = false;
                                    lblTime.Text = "在" + row["sendtime"] + "，您给" + row["incept"] + " 发送的消息！ ";
                                    lblTitle.Text = row["title"].ToString();
                                    lblContent.Text = Input.ToTxt(row["content"].ToString());
                                }
                            }
                            else if (action == "outread")//草稿箱
                            {
                                if (row["sender"].ToString() != "拼搏在线")
                                {
                                    this.tbAlert.Visible = true;
                                    this.tbSend.Visible = false;
                                    this.tbRead.Visible = false;
                                    this.lblAlertTitle.Text = "您在\"<font color='red'>阅读短信</font>\"的时候发生错误,下面是错误的详细信息";
                                    this.lblAlertContent.Text = "你是不是跑到别人的信箱啦、或者该信息已经被收件人删除。 <p>请确保您有相应的操作权限。 ";
                                }
                                else
                                {
                                    this.tbRead.Visible = true;
                                    this.tbSend.Visible = false;
                                    this.tbAlert.Visible = false;
                                    lblTime.Text = "在" + row["sendtime"] + "，您给" + row["incept"] + " 发送的消息！ ";
                                    lblTitle.Text = row["title"].ToString();
                                    lblContent.Text = Input.ToTxt(row["content"].ToString()).ToString();
                                }
                            }
                            else if (action == "edit")//草稿箱
                            {
                                if (row["sender"].ToString() != "拼搏在线")
                                {
                                    this.tbAlert.Visible = true;
                                    this.tbSend.Visible = false;
                                    this.tbRead.Visible = false;
                                    this.lblAlertTitle.Text = "您在\"<font color='red'>阅读短信</font>\"的时候发生错误,下面是错误的详细信息";
                                    this.lblAlertContent.Text = "你是不是跑到别人的信箱啦、或者该信息已经被收件人删除。 <p>请确保您有相应的操作权限。 ";
                                }
                                else
                                {
                                    this.tbSend.Visible = true;
                                    this.tbRead.Visible = false;
                                    this.tbAlert.Visible = false;
                                    txtToUser.Text = row["incept"].ToString();
                                    txtTitle.Text = row["title"].ToString();
                                    txtContent.Value = row["content"].ToString();
                                }
                            }
                            else
                            {
                                tbBig.Visible = false;
                            }
                        }
                        else
                        {
                            tbBig.Visible = false;
                        }
                    }
                }
            }
        }

        protected void ibtnDel_Click(object sender, ImageClickEventArgs e)
        {
            string msgId = Input.FilterAll(Request["id"]);
            string action = Request["action"];
            if (action == "read")
            {
                DbHelperSQLBBS.ExecuteSql("update Dv_Message set delR=1  where id=" + msgId + " and incept='拼搏在线' ");
            }
            else if (action == "outread")
            {
                DbHelperSQLBBS.ExecuteSql("update Dv_Message set delS=1 where id=" + msgId + " and sender='拼搏在线' ");
            }
            else if (action == "edite")
            {
                DbHelperSQLBBS.ExecuteSql("update Dv_Message set delS=1 where id=" + msgId + " and sender='拼搏在线' ");
            }
            this.lblAlertTitle.Text = "操作成功信息 ";
            this.lblContent.Text = "操作成功：删除短消息成功。删除的消息将置于您的废信箱内。";
            this.tbAlert.Visible = true;
            this.tbRead.Visible = false;
            this.tbSend.Visible = false;
        }

        protected void ibtnWrite_Click(object sender, ImageClickEventArgs e)
        {
            this.tbSend.Visible = true;
            this.tbAlert.Visible = false;
            this.tbRead.Visible = false;

        }

        protected void ibtnReplypm_Click(object sender, ImageClickEventArgs e)
        {
            string msgId = Input.FilterAll(Request["id"]);
            string action = Request["action"];
            DataSet ds = null;
            if (action == "read")
            {
                ds = DbHelperSQLBBS.Query("select * from  Dv_Message  where id=" + msgId + " and incept='拼搏在线' ");
                DataRow row = ds.Tables[0].Rows[0];
                this.txtToUser.Text = row["sender"].ToString();
                this.txtTitle.Text = "RW：" + row["title"].ToString();

                this.txtContent.Value = "======在 2010-5-14 13:37:00 " + row["sender"] + " 来信中写道：======<br/>" + row["content"].ToString() + "<br/>=====================================";
                this.tbSend.Visible = true;
                this.tbAlert.Visible = false;
                this.tbRead.Visible = false;

            }
            else if (action == "outread" || action == "edite")
            {
                this.tbAlert.Visible = true;
                this.tbSend.Visible = false;
                this.tbRead.Visible = false;
                this.lblAlertTitle.Text = "您在\"<font color='red'>转发消息</font>\"的时候发生错误,下面是错误的详细信息";
                this.lblAlertContent.Text = "自己不能给自己发消息 ";

            }
            else if (action == "new")
            {
                this.tbSend.Visible = true;
                this.tbAlert.Visible = false;
                this.tbRead.Visible = false;
            }
        }

        protected void ibtnFw_Click(object sender, ImageClickEventArgs e)
        {
            string msgId = Input.FilterAll(Request["id"]);
            string action = Request["action"];
            DataSet ds = null;
            if (action == "read")
            {
                ds = DbHelperSQLBBS.Query("select * from  Dv_Message  where id=" + msgId + " and incept='拼搏在线' ");
                DataRow row = ds.Tables[0].Rows[0];
                this.txtToUser.Text = row["sender"].ToString();
                this.txtTitle.Text = "FW：" + row["title"].ToString();
                this.txtContent.Value = "============== 下面是转发信息 ============== <br/>原发件人：" + row["sender"] + " <br/>原发件内容：<br/>" + Input.ToTxt(row["content"].ToString()) + "<br/>======================================";
                this.tbSend.Visible = true;
                this.tbAlert.Visible = false;
                this.tbRead.Visible = false;

            }
            else if (action == "outread" || action == "edite")
            {
                ds = DbHelperSQLBBS.Query("select * from  Dv_Message  where id=" + msgId + " and sender='拼搏在线' ");
                DataRow row = ds.Tables[0].Rows[0];
                this.txtTitle.Text = "FW：" + row["title"].ToString();
                this.txtContent.Value = "============== 下面是转发信息 ============== <br/>原发件人：" + row["sender"] + " <br/>原发件内容：<br/>" + row["content"].ToString() + "<br/>======================================";
                this.tbSend.Visible = true;
                this.tbAlert.Visible = false;
                this.tbRead.Visible = false;
            }
            else if (action == "new")
            {
                this.tbSend.Visible = true;
                this.tbAlert.Visible = false;
                this.tbRead.Visible = false;
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            string action = Request["action"];
            string msgId = Input.FilterAll(Request["id"]);
            string strSender = "拼搏在线";
            string toUsers = txtToUser.Text.Trim();
            string[] toUsersSZ = toUsers.Split(new char[] { ',' });

            try
            {
                Input.FilterAll(toUsersSZ[0]);
            }
            catch (Exception ex)
            {
                this.lblAlertTitle.Text = "您在\"<font color='red'>发送消息</font>\"的时候发生错误,下面是错误的详细信息";
                this.lblAlertContent.Text = "收件人名中含有非法字符 ！";
                this.tbAlert.Visible = true;
                this.tbSend.Visible = false;
                this.tbRead.Visible = false;
                return;
            }
            string title = Input.FilterHTML(txtTitle.Text);
            string content = Request.Form["txtContent"];
            string incept = toUsersSZ[0];
            string checkResult = WebFunc.IsDVUser(incept);
            //if (int.Parse(this.lblTodayCount.Text) < 1)
            //{
            //    this.lblAlertTitle.Text = "您在\"<font color='red'>发送消息</font>\"的时候发生错误,下面是错误的详细信息";
            //    this.lblAlertContent.Text = "您今天还可以发送的消息条数为：0！请改天再发！";
            //    this.tbAlert.Visible = true;
            //    this.tbSend.Visible = false;
            //    this.tbRead.Visible = false;
            //    return;
            //}
            if (action == "new")
            {
                bool checkResultAll = true;
                //bool checkInsert = true;
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionStringBBS"]))
                {
                    conn.Open();
                    const string transName = "InsertDv_Message";
                    SqlTransaction trans = conn.BeginTransaction(transName);
                    try
                    {
                        int k = 0;
                        for (int i = 0; i < toUsersSZ.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(toUsersSZ[i]))
                            {
                                if (WebFunc.IsDVUser(toUsersSZ[i]) != "true")
                                {
                                    checkResultAll = false;
                                    break;
                                }
                                else
                                {
                                    k++;
                                    using (SqlCommand cmd = new SqlCommand())
                                    {
                                        cmd.Connection = conn;
                                        cmd.Transaction = trans;
                                        cmd.CommandType = CommandType.Text;
                                        cmd.CommandText = "insert into Dv_Message(sender,incept,title,content,flag,sendtime,delR,delS,isSend)  values (@sender,@incept,@title,@content,@flag,@sendtime,@delR,@delS,@isSend);select @@IDENTITY";
                                        cmd.Parameters.Add(new SqlParameter("@sender", strSender));
                                        cmd.Parameters.Add(new SqlParameter("@incept", toUsersSZ[i]));
                                        cmd.Parameters.Add(new SqlParameter("@title", title));
                                        cmd.Parameters.Add(new SqlParameter("@content", content));
                                        cmd.Parameters.Add(new SqlParameter("@flag", "0"));
                                        cmd.Parameters.Add(new SqlParameter("@sendtime", DateTime.Now));
                                        cmd.Parameters.Add(new SqlParameter("@delR", "0"));
                                        cmd.Parameters.Add(new SqlParameter("@delS", "0"));
                                        cmd.Parameters.Add(new SqlParameter("@isSend", "1"));
                                        cmd.ExecuteScalar();
                                        cmd.Parameters.Clear();
                                    }
                                    if (k >= int.Parse(this.lblTodayCount.Text))
                                    {
                                        //break;
                                    }
                                }
                            }
                            else
                            {
                                checkResultAll = false;
                                break;
                            }
                        }
                        if (checkResultAll)
                        {
                            trans.Commit();
                            this.lblAlertTitle.Text = "发送成功信息";
                            this.lblAlertContent.Text = "操作成功：恭喜您，发送短消息成功。发送的消息同时保存在您的已发送消息中。 ";
                        }
                        else
                        {
                            trans.Rollback(transName);
                            this.lblAlertTitle.Text = "您在\"<font color='red'>发送消息</font>\"的时候发生错误,下面是错误的详细信息";
                            this.lblAlertContent.Text = "您忘记填写会员ID了吧，或该用户ID不存在了！  ";
                        }
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback(transName);
                        conn.Close();
                        conn.Dispose();
                        this.lblAlertTitle.Text = "您在\"<font color='red'>发送消息</font>\"的时候发生错误,下面是错误的详细信息";
                        this.lblAlertContent.Text = "发送失败！ ";
                    }
                    finally
                    {
                        conn.Close();
                        conn.Dispose();
                    }
                }
            }
            else if (action == "edit")
            {
                if (checkResult != "true")
                {
                    this.lblAlertTitle.Text = "您在\"<font color='red'>发送消息</font>\"的时候发生错误,下面是错误的详细信息";
                    this.lblAlertContent.Text = "您忘记填写会员ID了吧，或该用户ID不存在了！  ";
                }
                else
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("update Dv_Message set ");
                    strSql.Append("sender=@sender,");
                    strSql.Append("incept=@incept,");
                    strSql.Append("title=@title,");
                    strSql.Append("content=@content,");
                    strSql.Append("flag=@flag,");
                    strSql.Append("sendtime=@sendtime,");
                    strSql.Append("delR=@delR");
                    strSql.Append("delS=@delS");
                    strSql.Append("isSend=@isSend");
                    strSql.Append(" where Id=@Id ");
                    SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@sender", SqlDbType.VarChar,50),
					new SqlParameter("@incept", SqlDbType.VarChar,50),
					new SqlParameter("@title", SqlDbType.VarChar,100),
					new SqlParameter("@content", SqlDbType.NText),
					new SqlParameter("@flag", SqlDbType.Int,4),
					new SqlParameter("@sendtime", SqlDbType.DateTime,8),
					new SqlParameter("@delR", SqlDbType.Int,4),
					new SqlParameter("@delS", SqlDbType.Int,4),
					new SqlParameter("@isSend", SqlDbType.Int,4)
                  };
                    parameters[0].Value = msgId;
                    parameters[1].Value = strSender;
                    parameters[2].Value = incept;
                    parameters[3].Value = title;
                    parameters[4].Value = content;
                    parameters[5].Value = 0;
                    parameters[6].Value = DateTime.Now;
                    parameters[7].Value = 0;
                    parameters[8].Value = 0;
                    parameters[9].Value = 1;
                    int obj = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
                    if (obj > 0)
                    {
                        this.lblAlertTitle.Text = "您在\"<font color='red'>发送消息</font>\"的时候发生错误,下面是错误的详细信息";
                        this.lblAlertContent.Text = "发送失败！ ";
                    }
                    else
                    {
                        this.lblAlertTitle.Text = "发送成功信息";
                        this.lblAlertContent.Text = "操作成功：恭喜您，发送短消息成功。发送的消息同时保存在您的已发送消息中。 ";
                    }
                }
            }
            else if (action == "read")
            {
                bool checkResultAll = true;
                //bool checkInsert = true;
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionStringBBS"]))
                {
                    conn.Open();
                    const string transName = "InsertDv_Message";
                    SqlTransaction trans = conn.BeginTransaction(transName);
                    try
                    {
                        int k = 0;
                        for (int i = 0; i < toUsersSZ.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(toUsersSZ[i]))
                            {
                                if (WebFunc.IsDVUser(toUsersSZ[i]) != "true")
                                {
                                    checkResultAll = false;
                                    break;
                                }
                                else
                                {
                                    k++;
                                    using (SqlCommand cmd = new SqlCommand())
                                    {
                                        cmd.Connection = conn;
                                        cmd.Transaction = trans;
                                        cmd.CommandType = CommandType.Text;
                                        cmd.CommandText = "insert into Dv_Message(sender,incept,title,content,flag,sendtime,delR,delS,isSend)  values (@sender,@incept,@title,@content,@flag,@sendtime,@delR,@delS,@isSend);select @@IDENTITY";
                                        cmd.Parameters.Add(new SqlParameter("@sender", strSender));
                                        cmd.Parameters.Add(new SqlParameter("@incept", toUsersSZ[i]));
                                        cmd.Parameters.Add(new SqlParameter("@title", title));
                                        cmd.Parameters.Add(new SqlParameter("@content", content));
                                        cmd.Parameters.Add(new SqlParameter("@flag", "0"));
                                        cmd.Parameters.Add(new SqlParameter("@sendtime", DateTime.Now));
                                        cmd.Parameters.Add(new SqlParameter("@delR", "0"));
                                        cmd.Parameters.Add(new SqlParameter("@delS", "0"));
                                        cmd.Parameters.Add(new SqlParameter("@isSend", "1"));
                                        cmd.ExecuteScalar();
                                        cmd.Parameters.Clear();
                                    }
                                    if (k >= int.Parse(this.lblTodayCount.Text))
                                    {
                                        //break;
                                    }
                                }
                            }
                            else
                            {
                                checkResultAll = false;
                                break;
                            }
                        }
                        if (checkResultAll)
                        {
                            trans.Commit();
                            this.lblAlertTitle.Text = "发送成功信息";
                            this.lblAlertContent.Text = "操作成功：恭喜您，发送短消息成功。发送的消息同时保存在您的已发送消息中。 ";
                        }
                        else
                        {
                            trans.Rollback(transName);
                            this.lblAlertTitle.Text = "您在\"<font color='red'>发送消息</font>\"的时候发生错误,下面是错误的详细信息";
                            this.lblAlertContent.Text = "您忘记填写会员ID了吧，或该用户ID不存在了！  ";
                        }
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback(transName);
                        conn.Close();
                        conn.Dispose();
                        this.lblAlertTitle.Text = "您在\"<font color='red'>发送消息</font>\"的时候发生错误,下面是错误的详细信息";
                        this.lblAlertContent.Text = "发送失败！ ";
                    }
                    finally
                    {
                        conn.Close();
                        conn.Dispose();
                    }
                }
            }
            this.tbAlert.Visible = true;
            this.tbSend.Visible = false;
            this.tbRead.Visible = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string action = Request["action"];
            string msgId = Input.FilterAll(Request["id"]);
            string strSender = "拼搏在线";
            string incept = Input.FilterAll(txtToUser.Text);
            string title = Input.FilterHTML(txtTitle.Text);
            string content = Request.Form["txtContent"];
            string checkResult = WebFunc.IsDVUser(incept);
            if (action == "new")
            {
                if (checkResult != "true")
                {
                    this.lblAlertTitle.Text = "您在\"<font color='red'>保存消息</font>\"的时候发生错误,下面是错误的详细信息";
                    this.lblAlertContent.Text = "您忘记填写会员ID了吧，或该用户ID不存在了！  ";
                }
                else
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("insert into Dv_Message(");
                    strSql.Append("sender,incept,title,content,flag,sendtime,delR,delS,isSend)");
                    strSql.Append(" values (");
                    strSql.Append("@sender,@incept,@title,@content,@flag,@sendtime,@delR,@delS,@isSend)");
                    strSql.Append(";select @@IDENTITY");
                    SqlParameter[] parameters = {
					new SqlParameter("@sender", SqlDbType.VarChar,50),
					new SqlParameter("@incept", SqlDbType.VarChar,50),
					new SqlParameter("@title", SqlDbType.VarChar,100),
					new SqlParameter("@content", SqlDbType.NText),
					new SqlParameter("@flag", SqlDbType.Int,4),
					new SqlParameter("@sendtime", SqlDbType.DateTime,8),
					new SqlParameter("@delR", SqlDbType.Int,4),
					new SqlParameter("@delS", SqlDbType.Int,4),
					new SqlParameter("@isSend", SqlDbType.Int,4)
                };
                    parameters[0].Value = strSender;
                    parameters[1].Value = incept;
                    parameters[2].Value = title;
                    parameters[3].Value = content;
                    parameters[4].Value = 0;
                    parameters[5].Value = DateTime.Now;
                    parameters[6].Value = 0;
                    parameters[7].Value = 0;
                    parameters[8].Value = 0;
                    object obj = DbHelperSQLBBS.GetSingle(strSql.ToString(), parameters);
                    if (obj == null)
                    {
                        this.lblAlertTitle.Text = "您在\"<font color='red'>保存消息</font>\"的时候发生错误,下面是错误的详细信息";
                        this.lblAlertContent.Text = "保存失败！ ";
                    }
                    else
                    {
                        this.lblAlertTitle.Text = "保存成功信息";
                        this.lblAlertContent.Text = "操作成功：恭喜您，信息保存成功。消息保存在您的已发送消息中。 ";
                    }
                }
            }
            else if (action == "edit")
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update Dv_Message set ");
                strSql.Append("sender=@sender,");
                strSql.Append("incept=@incept,");
                strSql.Append("title=@title,");
                strSql.Append("content=@content,");
                strSql.Append("flag=@flag,");
                strSql.Append("sendtime=@sendtime,");
                strSql.Append("delR=@delR");
                strSql.Append("delS=@delS");
                strSql.Append("isSend=@isSend");
                strSql.Append(" where Id=@Id ");
                SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@sender", SqlDbType.VarChar,50),
					new SqlParameter("@incept", SqlDbType.VarChar,50),
					new SqlParameter("@title", SqlDbType.VarChar,100),
					new SqlParameter("@content", SqlDbType.NText),
					new SqlParameter("@flag", SqlDbType.Int,4),
					new SqlParameter("@sendtime", SqlDbType.DateTime,8),
					new SqlParameter("@delR", SqlDbType.Int,4),
					new SqlParameter("@delS", SqlDbType.Int,4),
					new SqlParameter("@isSend", SqlDbType.Int,4)
                  };
                parameters[0].Value = msgId;
                parameters[1].Value = strSender;
                parameters[2].Value = incept;
                parameters[3].Value = title;
                parameters[4].Value = content;
                parameters[5].Value = 0;
                parameters[6].Value = DateTime.Now;
                parameters[7].Value = 0;
                parameters[8].Value = 0;
                parameters[9].Value = 0;
                int obj = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
                if (obj > 0)
                {
                    this.lblAlertTitle.Text = "您在\"<font color='red'>保存信息</font>\"的时候发生错误,下面是错误的详细信息";
                    this.lblAlertContent.Text = "保存失败！ ";
                }
                else
                {
                    this.lblAlertTitle.Text = "保存成功信息";
                    this.lblAlertContent.Text = "操作成功：恭喜您，信息保存成功。消息保存在您的草稿箱中。 ";
                }
            }
            this.tbAlert.Visible = true;
            this.tbSend.Visible = false;
            this.tbRead.Visible = false;
        }

        protected void ddlFriends_SelectedIndexChanged(object sender, EventArgs e)
        {
            string myText = this.txtToUser.Text.Trim();
            if (string.IsNullOrEmpty(myText))
            {
                if (!string.IsNullOrEmpty(this.ddlFriends.SelectedValue))
                {
                    myText += this.ddlFriends.SelectedValue;
                }
            }
            else
            {
                string[] tempSZ = myText.Split(new char[] { ',' });
                if (!string.IsNullOrEmpty(this.ddlFriends.SelectedValue))
                {
                    bool find = false;
                    foreach (string tempF in tempSZ)
                    {
                        if (tempF == this.ddlFriends.SelectedValue)
                        {
                            find = true;
                            break;
                        }
                    }
                    if (!find)
                    {
                        myText += "," + this.ddlFriends.SelectedValue;
                    }
                }
            }
            this.txtToUser.Text = myText;
        }
    }
}
