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
                    string GroupSetting = DbHelperSQLBBS.GetSingle("select top 1 GroupSetting from Dv_UserGroups where usertitle in(select top 1 UserClass from dv_user where username='ƴ������')").ToString();
                    string[] GroupSettingSZ = GroupSetting.Split(new char[] { ',' });
                    int senduserCount = 1;
                    senduserCount = Convert.ToInt32(GroupSettingSZ[33]);
                    this.lblSenduserCount.Text = senduserCount.ToString();

                    //���տɷ���Ϣ��Ŀ
                    int todayCount = WebFunc.GetUserTodayMSG("ƴ������");
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
                    Response.Write("<script>alert('���û���Ϣ�쳣���������Ա��ϵ');top.location='/Default.htm';</script>");
                    return;
                }
                if (!string.IsNullOrEmpty(Request["action"]))
                {
                    string action = Request["action"];
                    string msgId = "";
                    if (action == "new")//׫д����Ϣ
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
                            if (action == "read")//������
                            {
                                if (row["incept"].ToString().ToLower() != "ƴ������")
                                {
                                    this.tbAlert.Visible = true;
                                    this.tbSend.Visible = false;
                                    this.tbRead.Visible = false;
                                    this.lblAlertTitle.Text = "����\"<font color='red'>�Ķ�����</font>\"��ʱ��������,�����Ǵ������ϸ��Ϣ";
                                    this.lblAlertContent.Text = "���ǲ����ܵ����˵������������߸���Ϣ�Ѿ����ռ���ɾ���� <p>��ȷ��������Ӧ�Ĳ���Ȩ�ޡ� ";
                                }
                                else
                                {
                                    DbHelperSQLBBS.Query("update Dv_Message set flag=1  where id=" + msgId + " ");
                                    this.tbRead.Visible = true;
                                    this.tbSend.Visible = false;
                                    this.tbAlert.Visible = false;
                                    lblTime.Text = "��" + row["sendtime"] + "��" + row["sender"] + " �������͵���Ϣ�� ";
                                    lblTitle.Text = row["title"].ToString();
                                    lblContent.Text = Input.ToTxt(row["content"].ToString());
                                }
                            }
                            else if (action == "myRead")
                            {
                                if (row["sender"].ToString().ToLower() != "ƴ������")
                                {
                                    this.tbAlert.Visible = true;
                                    this.tbSend.Visible = false;
                                    this.tbRead.Visible = false;
                                    this.lblAlertTitle.Text = "����\"<font color='red'>�Ķ�����</font>\"��ʱ��������,�����Ǵ������ϸ��Ϣ";
                                    this.lblAlertContent.Text = "���ǲ����ܵ����˵������������߸���Ϣ�Ѿ����ռ���ɾ���� <p>��ȷ��������Ӧ�Ĳ���Ȩ�ޡ� ";
                                }
                                else
                                {
                                    this.tbRead.Visible = true;
                                    this.tbSend.Visible = false;
                                    this.tbAlert.Visible = false;
                                    lblTime.Text = "��" + row["sendtime"] + "������" + row["incept"] + " ���͵���Ϣ�� ";
                                    lblTitle.Text = row["title"].ToString();
                                    lblContent.Text = Input.ToTxt(row["content"].ToString());
                                }
                            }
                            else if (action == "outread")//�ݸ���
                            {
                                if (row["sender"].ToString() != "ƴ������")
                                {
                                    this.tbAlert.Visible = true;
                                    this.tbSend.Visible = false;
                                    this.tbRead.Visible = false;
                                    this.lblAlertTitle.Text = "����\"<font color='red'>�Ķ�����</font>\"��ʱ��������,�����Ǵ������ϸ��Ϣ";
                                    this.lblAlertContent.Text = "���ǲ����ܵ����˵������������߸���Ϣ�Ѿ����ռ���ɾ���� <p>��ȷ��������Ӧ�Ĳ���Ȩ�ޡ� ";
                                }
                                else
                                {
                                    this.tbRead.Visible = true;
                                    this.tbSend.Visible = false;
                                    this.tbAlert.Visible = false;
                                    lblTime.Text = "��" + row["sendtime"] + "������" + row["incept"] + " ���͵���Ϣ�� ";
                                    lblTitle.Text = row["title"].ToString();
                                    lblContent.Text = Input.ToTxt(row["content"].ToString()).ToString();
                                }
                            }
                            else if (action == "edit")//�ݸ���
                            {
                                if (row["sender"].ToString() != "ƴ������")
                                {
                                    this.tbAlert.Visible = true;
                                    this.tbSend.Visible = false;
                                    this.tbRead.Visible = false;
                                    this.lblAlertTitle.Text = "����\"<font color='red'>�Ķ�����</font>\"��ʱ��������,�����Ǵ������ϸ��Ϣ";
                                    this.lblAlertContent.Text = "���ǲ����ܵ����˵������������߸���Ϣ�Ѿ����ռ���ɾ���� <p>��ȷ��������Ӧ�Ĳ���Ȩ�ޡ� ";
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
                DbHelperSQLBBS.ExecuteSql("update Dv_Message set delR=1  where id=" + msgId + " and incept='ƴ������' ");
            }
            else if (action == "outread")
            {
                DbHelperSQLBBS.ExecuteSql("update Dv_Message set delS=1 where id=" + msgId + " and sender='ƴ������' ");
            }
            else if (action == "edite")
            {
                DbHelperSQLBBS.ExecuteSql("update Dv_Message set delS=1 where id=" + msgId + " and sender='ƴ������' ");
            }
            this.lblAlertTitle.Text = "�����ɹ���Ϣ ";
            this.lblContent.Text = "�����ɹ���ɾ������Ϣ�ɹ���ɾ������Ϣ���������ķ������ڡ�";
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
                ds = DbHelperSQLBBS.Query("select * from  Dv_Message  where id=" + msgId + " and incept='ƴ������' ");
                DataRow row = ds.Tables[0].Rows[0];
                this.txtToUser.Text = row["sender"].ToString();
                this.txtTitle.Text = "RW��" + row["title"].ToString();

                this.txtContent.Value = "======�� 2010-5-14 13:37:00 " + row["sender"] + " ������д����======<br/>" + row["content"].ToString() + "<br/>=====================================";
                this.tbSend.Visible = true;
                this.tbAlert.Visible = false;
                this.tbRead.Visible = false;

            }
            else if (action == "outread" || action == "edite")
            {
                this.tbAlert.Visible = true;
                this.tbSend.Visible = false;
                this.tbRead.Visible = false;
                this.lblAlertTitle.Text = "����\"<font color='red'>ת����Ϣ</font>\"��ʱ��������,�����Ǵ������ϸ��Ϣ";
                this.lblAlertContent.Text = "�Լ����ܸ��Լ�����Ϣ ";

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
                ds = DbHelperSQLBBS.Query("select * from  Dv_Message  where id=" + msgId + " and incept='ƴ������' ");
                DataRow row = ds.Tables[0].Rows[0];
                this.txtToUser.Text = row["sender"].ToString();
                this.txtTitle.Text = "FW��" + row["title"].ToString();
                this.txtContent.Value = "============== ������ת����Ϣ ============== <br/>ԭ�����ˣ�" + row["sender"] + " <br/>ԭ�������ݣ�<br/>" + Input.ToTxt(row["content"].ToString()) + "<br/>======================================";
                this.tbSend.Visible = true;
                this.tbAlert.Visible = false;
                this.tbRead.Visible = false;

            }
            else if (action == "outread" || action == "edite")
            {
                ds = DbHelperSQLBBS.Query("select * from  Dv_Message  where id=" + msgId + " and sender='ƴ������' ");
                DataRow row = ds.Tables[0].Rows[0];
                this.txtTitle.Text = "FW��" + row["title"].ToString();
                this.txtContent.Value = "============== ������ת����Ϣ ============== <br/>ԭ�����ˣ�" + row["sender"] + " <br/>ԭ�������ݣ�<br/>" + row["content"].ToString() + "<br/>======================================";
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
            string strSender = "ƴ������";
            string toUsers = txtToUser.Text.Trim();
            string[] toUsersSZ = toUsers.Split(new char[] { ',' });

            try
            {
                Input.FilterAll(toUsersSZ[0]);
            }
            catch (Exception ex)
            {
                this.lblAlertTitle.Text = "����\"<font color='red'>������Ϣ</font>\"��ʱ��������,�����Ǵ������ϸ��Ϣ";
                this.lblAlertContent.Text = "�ռ������к��зǷ��ַ� ��";
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
            //    this.lblAlertTitle.Text = "����\"<font color='red'>������Ϣ</font>\"��ʱ��������,�����Ǵ������ϸ��Ϣ";
            //    this.lblAlertContent.Text = "�����컹���Է��͵���Ϣ����Ϊ��0��������ٷ���";
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
                            this.lblAlertTitle.Text = "���ͳɹ���Ϣ";
                            this.lblAlertContent.Text = "�����ɹ�����ϲ�������Ͷ���Ϣ�ɹ������͵���Ϣͬʱ�����������ѷ�����Ϣ�С� ";
                        }
                        else
                        {
                            trans.Rollback(transName);
                            this.lblAlertTitle.Text = "����\"<font color='red'>������Ϣ</font>\"��ʱ��������,�����Ǵ������ϸ��Ϣ";
                            this.lblAlertContent.Text = "��������д��ԱID�˰ɣ�����û�ID�������ˣ�  ";
                        }
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback(transName);
                        conn.Close();
                        conn.Dispose();
                        this.lblAlertTitle.Text = "����\"<font color='red'>������Ϣ</font>\"��ʱ��������,�����Ǵ������ϸ��Ϣ";
                        this.lblAlertContent.Text = "����ʧ�ܣ� ";
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
                    this.lblAlertTitle.Text = "����\"<font color='red'>������Ϣ</font>\"��ʱ��������,�����Ǵ������ϸ��Ϣ";
                    this.lblAlertContent.Text = "��������д��ԱID�˰ɣ�����û�ID�������ˣ�  ";
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
                        this.lblAlertTitle.Text = "����\"<font color='red'>������Ϣ</font>\"��ʱ��������,�����Ǵ������ϸ��Ϣ";
                        this.lblAlertContent.Text = "����ʧ�ܣ� ";
                    }
                    else
                    {
                        this.lblAlertTitle.Text = "���ͳɹ���Ϣ";
                        this.lblAlertContent.Text = "�����ɹ�����ϲ�������Ͷ���Ϣ�ɹ������͵���Ϣͬʱ�����������ѷ�����Ϣ�С� ";
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
                            this.lblAlertTitle.Text = "���ͳɹ���Ϣ";
                            this.lblAlertContent.Text = "�����ɹ�����ϲ�������Ͷ���Ϣ�ɹ������͵���Ϣͬʱ�����������ѷ�����Ϣ�С� ";
                        }
                        else
                        {
                            trans.Rollback(transName);
                            this.lblAlertTitle.Text = "����\"<font color='red'>������Ϣ</font>\"��ʱ��������,�����Ǵ������ϸ��Ϣ";
                            this.lblAlertContent.Text = "��������д��ԱID�˰ɣ�����û�ID�������ˣ�  ";
                        }
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback(transName);
                        conn.Close();
                        conn.Dispose();
                        this.lblAlertTitle.Text = "����\"<font color='red'>������Ϣ</font>\"��ʱ��������,�����Ǵ������ϸ��Ϣ";
                        this.lblAlertContent.Text = "����ʧ�ܣ� ";
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
            string strSender = "ƴ������";
            string incept = Input.FilterAll(txtToUser.Text);
            string title = Input.FilterHTML(txtTitle.Text);
            string content = Request.Form["txtContent"];
            string checkResult = WebFunc.IsDVUser(incept);
            if (action == "new")
            {
                if (checkResult != "true")
                {
                    this.lblAlertTitle.Text = "����\"<font color='red'>������Ϣ</font>\"��ʱ��������,�����Ǵ������ϸ��Ϣ";
                    this.lblAlertContent.Text = "��������д��ԱID�˰ɣ�����û�ID�������ˣ�  ";
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
                        this.lblAlertTitle.Text = "����\"<font color='red'>������Ϣ</font>\"��ʱ��������,�����Ǵ������ϸ��Ϣ";
                        this.lblAlertContent.Text = "����ʧ�ܣ� ";
                    }
                    else
                    {
                        this.lblAlertTitle.Text = "����ɹ���Ϣ";
                        this.lblAlertContent.Text = "�����ɹ�����ϲ������Ϣ����ɹ�����Ϣ�����������ѷ�����Ϣ�С� ";
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
                    this.lblAlertTitle.Text = "����\"<font color='red'>������Ϣ</font>\"��ʱ��������,�����Ǵ������ϸ��Ϣ";
                    this.lblAlertContent.Text = "����ʧ�ܣ� ";
                }
                else
                {
                    this.lblAlertTitle.Text = "����ɹ���Ϣ";
                    this.lblAlertContent.Text = "�����ɹ�����ϲ������Ϣ����ɹ�����Ϣ���������Ĳݸ����С� ";
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
