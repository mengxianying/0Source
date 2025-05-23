using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Maticsoft.DBUtility;
using System.Security.Principal;
using System.Data;
using System.Web.SessionState;
using Pbzx.Common;
using System.Configuration;
using System.Data.SqlClient;

namespace Pbzx.BLL
{
    public class PinbleLogin
    {

        private void UpdateLogin(string userName)
        {
            DbHelperSQL.ExecuteSql(" update PBnet_broker set LastLogin_time='" + DateTime.Now + "' where UserName='" + userName + "' ");
            DateTime dtLastLogin = Convert.ToDateTime(DbHelperSQLBBS.GetSingle(" select top 1 LastLogin from dbo.Dv_User  where UserName='" + userName + "' "));
            if (dtLastLogin.ToShortDateString() == DateTime.Now.ToShortDateString())
            {
                DbHelperSQLBBS.ExecuteSql("UPDATE dbo.Dv_User SET LastLogin = '" + DateTime.Now + "', UserLogins = UserLogins + 1 ,UserLastIP='" + HttpContext.Current.Request.UserHostAddress + "' where UserName='" + userName + "'");
            }
            else
            {
                DbHelperSQLBBS.ExecuteSql("UPDATE dbo.Dv_User SET LastLogin = '" + DateTime.Now + "', UserLogins = UserLogins + 1 ,UserLastIP='" + HttpContext.Current.Request.UserHostAddress + "',UserToday='0|0|0|0|0' where UserName='" + userName + "'");
            }
        }
        /// <summary>
        /// ��½��֤
        /// </summary>
        /// <param name="LoginName">�û���</param>
        /// <param name="LoginPassWord">����</param>
        /// <returns>true/false</returns>
        public string CheckLogin(string LoginName, string LoginPassWord)
        {
            UserOut();
            string UID = Input.FilterAll(LoginName);
            string PWD = Input.FilterAll(LoginPassWord);
            DataSet ds = DbHelperSQLBBS.Query("select top 1 UserID,UserName,UserPassword,LockUser,UserClass from Dv_User where UserName='" + UID + "'");
            if (!(ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0))
            {
                Method.record_user_log(LoginName, LoginPassWord, "�û���������", "��¼");
                return "�û�������";
            }
            DataRow rowData = ds.Tables[0].Rows[0];
            if (rowData["LockUser"].ToString() == "1")
            {
                Method.record_user_log(LoginName, LoginPassWord, "ID����", "��¼");
                return "���û���������";
            }
            if (rowData["UserClass"].ToString() == "COPPA" || rowData["UserClass"].ToString() == "�ȴ���֤")
            {
                Method.record_user_log(LoginName, LoginPassWord, "�û���ʱ�޷�ʹ��", "��¼");
                return "���û���ʱ�޷�ʹ�ã�";
            }
            if (rowData["UserPassword"].ToString() != Input.MD5(PWD))
            {
                Method.record_user_log(LoginName, LoginPassWord, "��վ��¼ʧ��", "��¼");
                return "�������";
            }
            if (HttpContext.Current.Request.Cookies["UserClass"] != null)
            {
                HttpCookie cookie = new HttpCookie("UserClass");
                cookie.Value = Pbzx.Common.Input.Encrypt(rowData["UserClass"].ToString());
                cookie.Domain = System.Web.Security.FormsAuthentication.CookieDomain;    // ��仰�ڲ�����վ�����ã���Ϊ��ϵ��ͬһ����������Ķ��վ���Ƿ��ܹ���Cookie
                HttpContext.Current.Response.Cookies.Add(cookie);
            }


            // HttpContext.Current.Session["RealPWD"] = PWD;
            //QueryParam qp = new QueryParam();
            //qp.Where = string.Format(" Where U_StatUs=0 and  U_LoginName='{0}' and U_Password='{1}'", Common.inSQL(LoginName), Common.md5(LoginPassWord, 32));
            //int iInt = 0;
            //ArrayList lst = BusinessFacade.sys_UserList(qp, out iInt);
            //if (iInt > 0)
            //{
            //    bBool = true;
            //    sys_UserTable sUT = (sys_UserTable)lst[0];
            //    string[] U_ExtendFieldArray = (sUT.U_ExtendField + "").Split(',');
            //    if (U_ExtendFieldArray.Length == 3)
            //    {
            //        Common.MenuStyle = Convert.ToInt32(U_ExtendFieldArray[0]);
            //        Common.PageSize = Convert.ToInt32(U_ExtendFieldArray[1]);
            //        Common.TableSink = U_ExtendFieldArray[2];
            //    }
            //    checkOnline(sUT.U_LoginName.ToLower(), sUT.U_Password, Common.GetSessionID);
            //HttpContext.Current.Request.Cookies[System.Web.Security.FormsAuthentication.FormsCookieName].Expires
            UpdateLogin(UID);
            //HttpContext.Current.Session["MOBILE"] = "aaaa";
            Signin(LoginName, PWD, rowData["UserID"].ToString());
            string strClass = rowData["UserClass"].ToString();
            if (strClass == "����Ա" || strClass == "��������" || strClass == "����" || strClass == "�Ĺ�")
            {
                Method.record_user_log(LoginName, strClass, "��վ��¼�ɹ�", "��¼");
            }
            // }  
            return "";
        }

        /// <summary>
        /// ��½��֤
        /// </summary>
        /// <param name="LoginName">�û���</param>
        /// <param name="LoginPassWord">����</param>
        /// <returns>true/false</returns>
        public string CheckLogin(string LoginName, string LoginPassWord, string uTime)
        {
            UserOut();
            // DbHelperSQLBBS.GetSingle("select count(1) from Dv_User where UserName='" + LoginName + "' ");
            string UID = Input.FilterAll(LoginName);
            string PWD = Input.FilterAll(LoginPassWord);
            DataSet ds = DbHelperSQLBBS.Query("select top 1 UserID,UserName,UserPassword,LockUser,UserClass,MOBILE from Dv_User where UserName='" + UID + "'");
            if (!(ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0))
            {
                Method.record_user_log(LoginName, LoginPassWord, "�û���������", "��¼");
                return "�û�������";
            }
            DataRow rowData = ds.Tables[0].Rows[0];
            if (rowData["LockUser"].ToString() == "1")
            {
                Method.record_user_log(LoginName, LoginPassWord, "ID����", "��¼");
                return "���û���������";
            }
            if (rowData["UserClass"].ToString() == "COPPA" || rowData["UserClass"].ToString() == "�ȴ���֤")
            {
                Method.record_user_log(LoginName, LoginPassWord, "�û���ʱ�޷�ʹ��", "��¼");
                return "���û���ʱ�޷�ʹ�ã�";
            }
            if (rowData["UserPassword"].ToString() != Input.MD5(PWD))
            {
                Method.record_user_log(LoginName, LoginPassWord, "��վ��¼ʧ��", "��¼");
                return "�������";
            }
            HttpContext.Current.Session["MOBILE"] = rowData["MOBILE"].ToString();

            //��WEB���ֻ���
            string connectString2 = ConfigurationManager.AppSettings["ConnectionString"];
            SqlConnection sqlCnt = new SqlConnection(connectString2);
            sqlCnt.Open();

            String mobileinWeb = "";
            SqlCommand command = new SqlCommand("select top 1 Mobile from [PBnet_UserTable] where UserName='"+UID+"'",sqlCnt);
  
            SqlDataReader reader = command.ExecuteReader();		//ִ��SQL������һ��������
            if (reader.Read())
            {
                if (reader["Mobile"].ToString().Trim().Length > 0)
                {
                    mobileinWeb = reader["Mobile"].ToString().Trim();
                }
            }
            reader.Close();
            command.Dispose();
            sqlCnt.Close();

            HttpContext.Current.Session["MOBILE_WEB"] = mobileinWeb;


            Pbzx.Common.ErrorLog.WriteLogMeng("��¼mobile", "�ֻ���" + mobileinWeb +  "\r\n", true, true);


            if (HttpContext.Current.Request.Cookies["UserClass"] == null)
            {
                HttpCookie cookie = new HttpCookie("UserClass");
                if (uTime == "0")
                {
                }
                else if (uTime == "1")
                {
                    cookie.Expires = DateTime.Now.AddDays(1);
                }
                else if (uTime == "2")
                {
                    cookie.Expires = DateTime.Now.AddMonths(1);
                }
                else if (uTime == "3")
                {
                    cookie.Expires = DateTime.Now.AddYears(1);
                }

               

                cookie.Value = Pbzx.Common.Input.Encrypt(rowData["UserClass"].ToString());
            

                cookie.Domain = System.Web.Security.FormsAuthentication.CookieDomain;    // ��仰�ڲ�����վ�����ã���Ϊ��ϵ��ͬһ����������Ķ��վ���Ƿ��ܹ���Cookie
                HttpContext.Current.Response.Cookies.Add(cookie);

                Pbzx.Common.ErrorLog.WriteLogMeng("��¼UserClass", "UserClass��" + cookie.Value + "��Domain:"+cookie.Domain+" \r\n", true, true);

            }
            UpdateLogin(UID);
            Signin(LoginName, PWD, uTime, rowData["UserID"].ToString());
            string strClass = rowData["UserClass"].ToString();
            //if (strClass == "����Ա" || strClass == "��������" || strClass == "����" || strClass == "�Ĺ�")
            //{
                Method.record_user_log(LoginName, strClass, "��վ��¼�ɹ�", "��¼");
          //  }
            return "";
        }


        /// <summary>
        /// Chat��½��֤
        /// </summary>
        /// <param name="LoginName">�û���</param>
        /// <param name="LoginPassWord">����</param>
        /// <returns>true/false</returns>
        public string CheckLoginChat(string LoginName, string LoginPassWord, string uTime)
        {
            UserOut();
            // DbHelperSQLBBS.GetSingle("select count(1) from Dv_User where UserName='" + LoginName + "' ");
            string UID = Input.FilterAll(LoginName);
            string PWD = Input.FilterAll(LoginPassWord);
            DataSet ds = DbHelperSQLBBS.Query("select top 1 UserID,UserName,UserPassword,LockUser,UserClass from Dv_User where UserName='" + UID + "'");
            if (!(ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0))
            {
                Method.record_user_log_01(LoginName, LoginPassWord, "�û���������", "��¼");
                return "�û�������";
            }
            DataRow rowData = ds.Tables[0].Rows[0];
            if (rowData["LockUser"].ToString() == "1")
            {
                Method.record_user_log_01(LoginName, LoginPassWord, "ID����", "��¼");
                return "���û���������";
            }
            if (rowData["UserClass"].ToString() == "COPPA" || rowData["UserClass"].ToString() == "�ȴ���֤")
            {
                Method.record_user_log_01(LoginName, LoginPassWord, "�û���ʱ�޷�ʹ��", "��¼");
                return "���û���ʱ�޷�ʹ�ã�";
            }
            if (rowData["UserPassword"].ToString() != Input.MD5(PWD))
            {
                Method.record_user_log_01(LoginName, LoginPassWord, "��������վ��¼ʧ��", "��¼");
                return "�������";
            }
            if (HttpContext.Current.Request.Cookies["UserClass"] == null)
            {
                HttpCookie cookie = new HttpCookie("UserClass");
                if (uTime == "0")
                {
                }
                else if (uTime == "1")
                {
                    cookie.Expires = DateTime.Now.AddDays(1);
                }
                else if (uTime == "2")
                {
                    cookie.Expires = DateTime.Now.AddMonths(1);
                }
                else if (uTime == "3")
                {
                    cookie.Expires = DateTime.Now.AddYears(1);
                }
                cookie.Value = Pbzx.Common.Input.Encrypt(rowData["UserClass"].ToString());
                cookie.Domain = System.Web.Security.FormsAuthentication.CookieDomain;    // ��仰�ڲ�����վ�����ã���Ϊ��ϵ��ͬһ����������Ķ��վ���Ƿ��ܹ���Cookie
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
            UpdateLogin(UID);
            Signin(LoginName, PWD, uTime, rowData["UserID"].ToString());
            string strClass = rowData["UserClass"].ToString();
            //if (strClass == "����Ա" || strClass == "��������" || strClass == "����" || strClass == "�Ĺ�")
            //{
            Method.record_user_log_01(LoginName, strClass, "�����ҵ�¼�ɹ�", "��¼");
            //}
            return "";
        }


        /// <summary>
        /// ��½��֤
        /// </summary>
        /// <param name="LoginName">�û���</param>
        /// <param name="LoginPassWord">����</param>
        /// <returns>true/false</returns>
        public string CheckLogin(string LoginName, string LoginPassWord, string uTime, bool IsMd5PWD)
        {
            UserOut();
            // DbHelperSQLBBS.GetSingle("select count(1) from Dv_User where UserName='" + LoginName + "' ");
            string UID = Input.FilterAll(LoginName);
            string PWD = Input.FilterAll(LoginPassWord);
            DataSet ds = DbHelperSQLBBS.Query("select top 1 UserID,UserName,UserPassword,LockUser,UserClass from Dv_User where UserName='" + UID + "'");
            if (!(ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0))
            {
                Method.record_user_log(LoginName, LoginPassWord, "�û���������", "��¼");
                return "�û�������";
            }
            DataRow rowData = ds.Tables[0].Rows[0];
            if (rowData["LockUser"].ToString() == "1")
            {
                Method.record_user_log(LoginName, LoginPassWord, "ID����", "��¼");
                return "���û���������";
            }
            if (rowData["UserClass"].ToString() == "COPPA" || rowData["UserClass"].ToString() == "�ȴ���֤")
            {
                Method.record_user_log(LoginName, LoginPassWord, "�û���ʱ�޷�ʹ��", "��¼");
                return "���û���ʱ�޷�ʹ�ã�";
            }
            if (IsMd5PWD)
            {
                if (rowData["UserPassword"].ToString() != PWD)
                {
                    Method.record_user_log(LoginName, LoginPassWord, "��վ��¼ʧ��", "��¼");
                    return "�������";
                }
            }
            else
            {
                if (rowData["UserPassword"].ToString() != Input.MD5(PWD))
                {
                    Method.record_user_log(LoginName, LoginPassWord, "��վ��¼ʧ��", "��¼");
                    return "�������";
                }
            }

            if (HttpContext.Current.Request.Cookies["UserClass"] == null)
            {
                HttpCookie cookie = new HttpCookie("UserClass");
                if (uTime == "0")
                {
                }
                else if (uTime == "1")
                {
                    cookie.Expires = DateTime.Now.AddDays(1);
                }
                else if (uTime == "2")
                {
                    cookie.Expires = DateTime.Now.AddMonths(1);
                }
                else if (uTime == "3")
                {
                    cookie.Expires = DateTime.Now.AddYears(1);
                }
                cookie.Value = Pbzx.Common.Input.Encrypt(rowData["UserClass"].ToString());
                cookie.Domain = System.Web.Security.FormsAuthentication.CookieDomain;    // ��仰�ڲ�����վ�����ã���Ϊ��ϵ��ͬһ����������Ķ��վ���Ƿ��ܹ���Cookie
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
            UpdateLogin(UID);
            Signin(LoginName, PWD, uTime, rowData["UserID"].ToString());
            string strClass = rowData["UserClass"].ToString();
            if (strClass == "����Ա" || strClass == "��������" || strClass == "����" || strClass == "�Ĺ�")
            {
                Method.record_user_log(LoginName, strClass, "��վ��¼�ɹ�", "��¼");
            }
            return "";
        }


        /// <summary>
        /// �û����µ�¼
        /// </summary>
        /// <returns></returns>
        public void ReLogin()
        {
            Signin();
        }

        private void CheckIsOldUser(string uName)
        {
            //��̳����
            DataSet ds = DbHelperSQLBBS.Query("select top 1 UserName,UserPassword,UserEmail,JoinDate,UserQuesion,UserAnswer from Dv_User where UserName='" + uName + "' and LockUser!='1' and UserClass!='COPPA' and UserClass!='�ȴ���֤'  ");
            string uEmail = ds.Tables[0].Rows[0]["UserEmail"].ToString();
            string uJoinDate = ds.Tables[0].Rows[0]["JoinDate"].ToString();
            string uUserQuesion = ds.Tables[0].Rows[0]["UserQuesion"].ToString();
            string uUserAnswer = ds.Tables[0].Rows[0]["UserAnswer"].ToString();
            string pwd = ds.Tables[0].Rows[0]["UserPassword"].ToString();
            //��ʵ��Ϣ��
            int intRealInfo = (int)DbHelperSQL.GetSingle("select count(1) from PBnet_UserTable where UserName='" + uName + "' ");
            if (intRealInfo < 1)
            {
                //�û���ʵ��Ϣ�����¼
                Pbzx.Model.PBnet_UserTable userReal = new Pbzx.Model.PBnet_UserTable();
                userReal.UserName = uName;
                userReal.Email = uEmail;
                userReal.CreatTime = DateTime.Parse(uJoinDate);
                userReal.State = 0;
                Pbzx.BLL.PBnet_UserTable userRealBLL = new Pbzx.BLL.PBnet_UserTable();
                userRealBLL.Add(userReal);
            }

            //�Ĳ��Ҳ����¼2025.0520ע��
            //int intChat = (int)DbHelperSQLMeChat.GetSingle("select count(1) from UserInfo where UserName='" + uName + "' ");
            //if (intChat < 1)
            //{
            //    int isHas = (int)DbHelperSQLMeChat.GetSingle("select count(1) from UserInfo2 where UserName='" + uName + "' ");
            //    int chat = 0;
            //    if (isHas > 0)
            //    {
            //        chat = DbHelperSQLMeChat.ExecuteSql("Insert into UserInfo select * from UserInfo2 where UserName='" + uName + "'");
            //        DbHelperSQLMeChat.ExecuteSql("update UserInfo set Password='" + pwd + "' where UserName='" + uName + "' ");
            //    }
            //    else
            //    {

            //        StringBuilder strSql = new StringBuilder();
            //        strSql.Append("insert into UserInfo(");
            //        strSql.Append("UserName,LoginTime,Alias,Password,Email,Question,Answer,Grade,RegistTime,status,IP,LogoutTime,age,sex,Oicq,Icon,Photo,Resume)");
            //        strSql.Append(" values (");
            //        strSql.Append("@UserName,@LoginTime,@Alias,@Password,@Email,@Question,@Answer,'1','" + DateTime.Now + "','1','" + System.Web.HttpContext.Current.Request.UserHostAddress + "','" + DateTime.Now + "','20','1','','1','','���û���δ��д���˼�� ')");
            //        strSql.Append(";select @@IDENTITY");
            //        SqlParameter[] parameters = {
            //        new SqlParameter("@UserName", SqlDbType.VarChar,30),
            //        new SqlParameter("@LoginTime", SqlDbType.DateTime),
            //        new SqlParameter("@Alias", SqlDbType.VarChar,30),
            //        new SqlParameter("@Password", SqlDbType.VarChar,20),
            //        new SqlParameter("@Email", SqlDbType.VarChar,50),
            //        new SqlParameter("@Question", SqlDbType.VarChar,50),
            //        new SqlParameter("@Answer", SqlDbType.VarChar,50)	
            //        };
            //        parameters[0].Value = uName.ToLower();
            //        parameters[1].Value = DateTime.Now;
            //        parameters[2].Value = uName;
            //        parameters[3].Value = pwd;
            //        parameters[4].Value = uEmail;
            //        parameters[5].Value = uUserQuesion;
            //        parameters[6].Value = uUserAnswer;
            //        object obj = DbHelperSQLMeChat.GetSingle(strSql.ToString(), parameters);
            //        //chat = DbHelperSQLMeChat.ExecuteSql("insert into UserInfo(UserName,LoginTime,Alias,Password,Email,Question,Answer,Grade,RegistTime,status,IP,LogoutTime,age,sex,Oicq,Icon,Photo,Resume) values('" + uName.ToLower() + "','" + DateTime.Now + "','" + uName + "','" + pwd + "','" + uEmail + "','" + uUserQuesion + "','" + uUserAnswer + "','1','" + DateTime.Now + "','1','" + System.Web.HttpContext.Current.Request.UserHostAddress + "','" + DateTime.Now + "','20','1','','1','','���û���δ��д���˼�� ')");
            //    }
            //}

            ////���뱣����
            //int intPWDProtect = (int)DbHelperSQL.GetSingle("select count(1) from PBnet_UserProtectPwd where UserName='" + uName + "' ");
            //if (intPWDProtect < 1)
            //{
            //    //���뱣��������¼
            //    int mifa = DbHelperSQL.ExecuteSql("insert into PBnet_UserProtectPwd(UserName,SecurityQuestion,Answer,Email) values('" + uName + "','" + uUserQuesion + "','" + uUserAnswer + "','" + uEmail + "')");            
            //}            
            //ƴ���ɲ����¼
            int intBarUser = (int)DbHelperSQL.GetSingle("select count(1) from PBnet_ask_User where UserName='" + uName + "' ");
            if (intBarUser < 1)
            {
                Pbzx.Model.PBnet_ask_User askUserModel = new Pbzx.Model.PBnet_ask_User();
                askUserModel.UserName = uName;
                askUserModel.Point = Int32.Parse(WebInit.siteconfig.regf);
                askUserModel.Pointpenalty = 0;
                askUserModel.OtherPointpenalty = 0;

                askUserModel.AskNum = 0;
                askUserModel.ReplyNum = 0;
                askUserModel.Best_ReplyNum = 0;
                askUserModel.OpenTime = DateTime.Now;
                askUserModel.Ask_DelNum = 0;
                askUserModel.UserGroup = "";
                askUserModel.Score = Int32.Parse(WebInit.siteconfig.regf);
                askUserModel.State = 0;
                Pbzx.BLL.PBnet_ask_User askUserBLL = new Pbzx.BLL.PBnet_ask_User();
                bool ask = askUserBLL.Add(askUserModel);
            }

        }


        /// <summary>
        /// �û���½
        /// </summary>
        /// <param name="sUT">�û�ʵ����</param>
        private void Signin(string Uname, string pwd, string uTime, string userID)
        {
            CheckIsOldUser(Uname);
            StringBuilder sb = new StringBuilder();
            //��ͨ�û�
            sb.Append("manager_user");
            //�߼��û�
            int intRealInfo = (int)DbHelperSQL.GetSingle("select count(1) from PBnet_UserTable where UserName='" + Uname + "' ");
            if (intRealInfo > 0)
            {
                Pbzx.BLL.PBnet_UserTable realBll = new PBnet_UserTable();
                Pbzx.Model.PBnet_UserTable RealModel = realBll.GetModelName(Uname);
                if (RealModel != null)
                {
                    if (!string.IsNullOrEmpty(RealModel.CardID) && !string.IsNullOrEmpty(RealModel.RealName))
                    {
                        sb.Append("|user_RealInfo");
                        if (RealModel.AccountNumberState == 3)
                        {
                            sb.Append("|AccountNumber");
                        }
                        if (RealModel.EmailState == 3)
                        {
                            sb.Append("|Email");
                        }
                    }
                }
            }
            //�������û�
            int intBroker = (int)DbHelperSQL.GetSingle("select count(1) from PBnet_broker where UserName='" + Uname + "' ");
            if (intBroker > 0)
            {
                sb.Append("|user_Broker");
            }

            //ƴ�����û�
            int intAsk = (int)DbHelperSQL.GetSingle("select count(1) from PBnet_ask_User where UserName='" + Uname + "' ");
            if (intAsk > 0)
            {
                sb.Append("|ask_User");
            }

            //�����û�
            int intDelegate = (int)DbHelperSQL1.GetSingle("select count(1) from AgentInfo where UserName='" + Uname + "' " + Method.Where_AgentInfo);
            if (intDelegate > 0)
            {
                sb.Append("|delegate_User");
            }
            //�����û�
            int intDelegate1 = (int)DbHelperSQL1.GetSingle("select count(1) from AgentInfo_Apply where UserName='" + Uname + "' ");
            if (intDelegate1 > 0)
            {
                sb.Append("|AgentInfo_Apply");
            }

            System.Web.Security.FormsAuthenticationTicket tk = new FormsAuthenticationTicket(1,
                   Uname + "&" + pwd + "&" + userID + "&" + uTime,
                    DateTime.Now,
                    DateTime.Now.AddMonths(1),
                    true,
                    sb.ToString(),
                    System.Web.Security.FormsAuthentication.FormsCookiePath
                    );
            string key = System.Web.Security.FormsAuthentication.Encrypt(tk); //�õ����ܺ�������֤Ʊ�ִ� 
            HttpCookie ck = new HttpCookie(System.Web.Security.FormsAuthentication.FormsCookieName, key);
            if (uTime == "0")
            {
            }
            else if (uTime == "1")
            {
                ck.Expires = DateTime.Now.AddDays(1);
            }
            else if (uTime == "2")
            {
                ck.Expires = DateTime.Now.AddMonths(1);
            }
            else if (uTime == "3")
            {
                ck.Expires = DateTime.Now.AddYears(1);
            }
            ck.Domain = System.Web.Security.FormsAuthentication.CookieDomain;    // ��仰�ڲ�����վ�����ã���Ϊ��ϵ��ͬһ����������Ķ��վ���Ƿ��ܹ���Cookie
            HttpContext.Current.Response.Cookies.Add(ck);
            System.Web.Security.FormsIdentity frmiden = new FormsIdentity(tk);
            bool isT = frmiden.IsAuthenticated;
            HttpContext.Current.User = new GenericPrincipal(frmiden, sb.ToString().Split(new char[] { '|' }));//�浽HttpContext.User�� 

            Pbzx.Common.ErrorLog.WriteLogMeng("��¼",""+ "FormsIdentity��" + tk.Name + ";userData:" + tk.UserData + "Expiration:" + tk.Expiration + "��Identity.IsAuthenticated:" + HttpContext.Current.User.Identity.IsAuthenticated + HttpContext.Current.User.Identity.Name + " \r\n", true, true);
            //System.Web.HttpContext.Current.Server.Execute("/WebForm2.aspx");
        }

        public void AdminSignIn()
        {

        }

        /// <summary>
        /// �û���½
        /// </summary>
        /// <param name="sUT">�û�ʵ����</param>
        private void Signin(string Uname, string pwd, string UserID)
        {
            CheckIsOldUser(Uname);
            StringBuilder sb = new StringBuilder();
            //��ͨ�û�
            sb.Append("manager_user");
            //�߼��û�
            int intRealInfo = (int)DbHelperSQL.GetSingle("select count(1) from PBnet_UserTable where UserName='" + Uname + "' ");
            if (intRealInfo > 0)
            {
                Pbzx.BLL.PBnet_UserTable utBLL = new PBnet_UserTable();
                Pbzx.Model.PBnet_UserTable RealModel = utBLL.GetModelName(Uname);
                if (RealModel != null)
                {
                    if (RealModel != null && !string.IsNullOrEmpty(RealModel.CardID) && !string.IsNullOrEmpty(RealModel.RealName))
                    {
                        sb.Append("|user_RealInfo");
                        if (RealModel.AccountNumberState == 3)
                        {
                            sb.Append("|AccountNumber");
                        }
                        if (RealModel.EmailState == 3)
                        {
                            sb.Append("|Email");
                        }
                    }
                }
            }

            //�������û�
            int intBroker = (int)DbHelperSQL.GetSingle("select count(1) from PBnet_broker where UserName='" + Uname + "' ");
            if (intBroker > 0)
            {
                sb.Append("|user_Broker");
            }

            //ƴ�����û�
            int intAsk = (int)DbHelperSQL.GetSingle("select count(1) from PBnet_ask_User where UserName='" + Uname + "' ");
            if (intAsk > 0)
            {
                sb.Append("|ask_User");
            }

            //�����û�
            int intDelegate = (int)DbHelperSQL1.GetSingle("select count(1) from AgentInfo where UserName='" + Uname + "' " + Method.Where_AgentInfo);
            if (intDelegate > 0)
            {
                sb.Append("|delegate_User");
            }
            //�����û�
            int intDelegate1 = (int)DbHelperSQL1.GetSingle("select count(1) from AgentInfo_Apply where UserName='" + Uname + "' ");
            if (intDelegate1 > 0)
            {
                sb.Append("|AgentInfo_Apply");
            }



            System.Web.Security.FormsAuthenticationTicket tk = new FormsAuthenticationTicket(1,
                   Uname + "&" + pwd + "&" + UserID + "&0",
                    DateTime.Now,
                    DateTime.Now.AddMonths(1),
                    true,
                    sb.ToString(),
                    System.Web.Security.FormsAuthentication.FormsCookiePath
                    );
            string key = System.Web.Security.FormsAuthentication.Encrypt(tk); //�õ����ܺ�������֤Ʊ�ִ� 
            HttpCookie ck = new HttpCookie(System.Web.Security.FormsAuthentication.FormsCookieName, key);
            ck.Domain = System.Web.Security.FormsAuthentication.CookieDomain;  // ��仰�ڲ�����վ�����ã���Ϊ��ϵ��ͬһ����������Ķ��վ���Ƿ��ܹ���Cookie
            HttpContext.Current.Response.Cookies.Add(ck);

            System.Web.Security.FormsIdentity frmiden = new FormsIdentity(tk);
            bool isT = frmiden.IsAuthenticated;
            HttpContext.Current.User = new GenericPrincipal(frmiden, sb.ToString().Split(new char[] { '|' }));//�浽HttpContext.User��             
        }

        private void Signin()
        {
            string uTime = HttpContext.Current.User.Identity.IsAuthenticated ? HttpContext.Current.User.Identity.Name.Split(new char[] { '&' })[3] : "0";
            Signin(Method.Get_UserName, Method.Get_UserID, uTime, Method.Get_UserID);
        }



        /// <summary>
        /// �û��˳�
        /// </summary>
        public static void UserOut()
        {
            try
            {
                // DbHelperSQLBBS.ExecuteSql("UPDATE dbo.Dv_User SET LastLogin = '" + DateTime.Now + "', UserLogins = UserLogins + 1 ,UserLastIP='" + HttpContext.Current.Request.UserHostAddress + "' where UserName='" + UID + "'");  
                //FrameWorkPermission.UserOnlineList.Remove(Common.Get_UserID);
                //д�˳���־
                // EventMessage.EventWriteDB(2, "�û��˳�", Common.Get_UserID);
                //�˳�����
                // BusinessFacade.InterfaceOnlineRemove(Common.GetSessionID);
                //UserData.Move_UserPermissionCache(Common.Get_UserID);
                //UserData.MoveUserCache(Common.Get_UserID);
                //HttpContext.Current.Response.Cookies["MenuStyle"].Expires = DateTime.Now.AddDays(-30);
                //HttpContext.Current.Response.Cookies["PageSize"].Expires = DateTime.Now.AddDays(-30);
                //HttpContext.Current.Response.Cookies["TableSink"].Expires = DateTime.Now.AddDays(-30);
                if (HttpContext.Current.Request.Cookies[System.Web.Security.FormsAuthentication.FormsCookieName] != null)
                {
                    HttpContext.Current.Request.Cookies[System.Web.Security.FormsAuthentication.FormsCookieName].Expires = DateTime.Now.AddMinutes(-1);
                }

                HttpCookie cookieUClass = HttpContext.Current.Request.Cookies["UserClass"];
                if (cookieUClass != null)
                {
                    cookieUClass.Expires = DateTime.Today.AddDays(-10);
                    cookieUClass.Domain = System.Web.Security.FormsAuthentication.CookieDomain;
                    HttpContext.Current.Response.Cookies.Add(cookieUClass);
                }
                System.Web.Security.FormsAuthentication.SignOut();
                // System.Web.HttpContext.Current.Response.Redirect(System.Web.HttpContext.Current.Request.UrlReferrer.AbsoluteUri);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
