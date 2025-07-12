using System;
using System.Data;
using System.Configuration;
using System.Web.UI;
using Pbzx.Common;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Xml;

namespace Pinble_Ask
{
    public partial class reg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Response.CacheControl = "no-cache";
                Response.Expires = 0;
                //������������
                if (Request["strSearch"] != null)
                {
//                    ProcessingSearch(Server.UrlDecode(Request["strSearch"]));
                    ProcessingSearch(Input.FilterAll(Server.UrlDecode(Request["strSearch"])));
                }

                //����������
                if (Request["strBulletin"] != null)
                {
//                    ProcessingSearch1(Server.UrlDecode(Request["strBulletin"]));
                    ProcessingSearch1(Input.FilterAll(Server.UrlDecode(Request["strBulletin"])));
                }

                //�������ŵ�������Զ�����
                if (Request["NewsClick"] != null)
                {
                    string id = Input.FilterAll(Request["NewsClick"]);
                    if (id.Length > 0)
                    {
//                        NewsClickAdd(Request["NewsClick"]);
                        NewsClickAdd(id);
                    }
                }

                //�������������Զ�����
                if (Request["BulletinClick"] != null)
                {
                    string id = Input.FilterAll(Request["BulletinClick"]);
                    if (id.Length > 0)
                    {
                        BulletinClickAdd(id);
                    }
                }

                //����ʡ�а�
                if (Request["province"] != null)
                {
                    GetCityData(Input.FilterAll(Server.UrlDecode(Request["province"])));
                }

                //�����ж��û����Ƿ�����
                if (Request["checkUserName"] != null)
                {
                    CheckUserName(Input.FilterAll(Server.UrlDecode(Request["checkUserName"])));
                }

                //�����ж��û�Email�Ƿ�ռ��
                if (Request["checkUserEmail"] != null)
                {
                    CheckUserEmail(Input.FilterAll(Server.UrlDecode(Request["checkUserEmail"])));
                }

                //�����Ĳ���
                if (Request["name_pwd"] != null)
                {
                    Response.Clear();
                    LoginSort login = new LoginSort();
                    if (!login["manager_user"] || Method.Get_UserPwd == "0")
                    {
                        Response.Write("var NamePWD='';");
                        //Response.End();
                        Response.Redirect("/Login.aspx");
                    }
                    else
                    {
                        Response.Write("var NamePWD='" + Server.UrlEncode(Method.Get_UserName + "|" + Method.Get_UserPwd) + "';");
                    }
                    Response.End();
                }

                //bigType
                if (Request["bigType"] != null)
                {
                    string strbigType = Input.FilterAll(Server.UrlDecode(Request["bigType"]));
                    GetAskType(strbigType);
                }
                

                if (Request["IsLogin"] != null)
                {
                    IsLogin();
                }

                if (Request["uName"] != null && Request["uPwd"] != null && Request["uCode"] != null && Request["uTime"] != null)
                {
//                    MyCheckLogin(Request["uName"], Request["uPwd"], Request["uCode"], Request["uTime"]);
                    MyCheckLogin(Input.FilterAll(Server.UrlDecode(Request["uName"])), Input.FilterAll(Server.UrlDecode(Request["uPwd"])), Input.FilterAll(Server.UrlDecode(Request["uCode"])), Input.FilterAll(Server.UrlDecode(Request["uTime"])));
                }
                if (Request["loginOut"] != null)
                {
                    MyLoginOut();
                }

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
                    string UserName = Input.FilterAll(Server.UrlDecode(Request["cueName"]));
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



        private void InitLoginIP(string username)
        {
            XmlDocument doc = new XmlDocument();
            //�ж������ʲô�����޶�
            doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/AskConfig.xml"));

            //�õ����ڵ�
            XmlElement root = doc.DocumentElement;
            if (root.ChildNodes.Count > 0)
            {

                XmlNode haha = root.SelectNodes("userlogin")[0];

                string ips = haha.SelectSingleNode("@ip").Value;

                string address = haha.SelectSingleNode("@address").Value;

                //���������ܵĵ�ַ
                if (ips == "")
                {
                    ips = "000.000.000";
                }
                if (address == "")
                {
                    address = "0";
                }
                //�ж�IP
                string ip = "";
                if (Context.Request.ServerVariables["HTTP_VIA"] != null) // �������� using proxy 
                {
                    // �õ���ʵ�Ŀͻ��˵�ַ
                    ip = Context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();  // Return real client IP. 
                }
                else//���û��ʹ�ô�����������ߵò����ͻ��˵�ip  not using proxy or can't get the Client IP 
                {
                    //�õ�����˵ĵ�ַ 
                    ip = Context.Request.ServerVariables["REMOTE_ADDR"].ToString(); //While it can't get the Client IP, it will return proxy IP. 
                }
                if (NewMethod(ips, ip))
                {
                    Method.record_user_log(username, "", "�����θ�IPλ�õ�¼", "��¼���");
                    Response.Redirect("http://www.pinble.com");
                }
                //�ж�ʡ��
                string s_temp = Method.S_getIPaddress(ip);
                if (NewMethod(s_temp, address))
                {
                    Method.record_user_log(username, "", "�����θõ�ַλ�õ�¼", "��¼���");
                    Response.Redirect("http://www.pinble.com");
                }
            }
        }

        /// <summary>
        /// ѭ���ж�
        /// </summary>
        /// <param name="s_temp"></param>
        /// <param name="sfs"></param>
        /// <returns></returns>
        private bool NewMethod(string s_temp, string sfs)
        {
            sfs = sfs.Replace("|\r\n", "|");
            string[] fsfs = sfs.Split('|');

            for (int j = 0; j < fsfs.Length; j++)
            {
                if (s_temp != "")
                {
                    if (s_temp.Contains(fsfs[j]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// ��¼
        /// </summary>
        /// <param name="uName"></param>
        /// <param name="uPwd"></param>
        /// <param name="uCode"></param>
        private void MyCheckLogin(string uName, string uPwd, string uCode, string uTime)
        {

            InitLoginIP(uName);
            string strResult = "";
            
            Pbzx.BLL.PinbleLogin LoginBll = new Pbzx.BLL.PinbleLogin();
            string result = LoginBll.CheckLogin(uName, uPwd, uTime);
            if (uCode.ToUpper() != Session["ValidateCode"].ToString())
            {
                strResult = "��֤�����";
            }
            else
            {
                if (!string.IsNullOrEmpty(result))
                {
                    strResult = result;
                }
                else
                {
                    object objMsgCount = DbHelperSQLBBS.GetSingle("select count(*) from Dv_Message where flag=0 and issend = 1 and delR = 0 and incept = '" + uName + "' ");
                    strResult = "true&" + objMsgCount.ToString();
                }
            }
            Response.Clear();
            Response.Write(strResult);
            Response.End();
        }

        /// <summary>
        /// �˳�
        /// </summary>
        private void MyLoginOut()
        {
            try
            {
                Pbzx.BLL.PinbleLogin.UserOut();
                Response.Write("true");
            }
            catch (Exception ex)
            {
                Response.Write("false");
            }

        }


        private void IsLogin()
        {
            Response.Clear();
            LoginSort login = new LoginSort();
            if (login[Pbzx.Common.ELoginSort.manager_user.ToString()])
            {
                object objMsgCount = DbHelperSQLBBS.GetSingle("select count(*) from Dv_Message where flag=0 and issend = 1 and delR = 0 and incept = '" + Method.Get_UserName + "' ");
                Response.Write("true&" + Pbzx.Common.Method.Get_UserName + "&" + objMsgCount.ToString());
            }
            else
            {
                Response.Write("false");
            }
            Response.End();
        }

        private void ProcessingSearch(string str)
        {
            Response.Clear();
            string strReturn = "";
            string result = Input.Encrypt(Input.FilterAll(str));
            strReturn = "/News_list.aspx?Search=" + result;
            Response.Write(strReturn);
            Response.End();
        }
        private void ProcessingSearch1(string str)
        {
            string strReturn = "";
            string result = Input.Encrypt(Input.FilterAll(str));
            strReturn = "/Bulletin_list.aspx?Search=" + result;
            Response.Write(strReturn);
            Response.End();
        }
        private void NewsClickAdd(string click)
        {
            Response.Clear();
            int id = 0;
            if (int.TryParse(click, out id))
            {
                Pbzx.BLL.PBnet_News newsBLL = new Pbzx.BLL.PBnet_News();
                Pbzx.Model.PBnet_News model = newsBLL.GetModel(id);
                if (model == null)
                {
                    Response.Write("var clickcount='0';");
                    Response.End();
                    return;
                }
                model.IntClick += 1;
                newsBLL.Update(model);
                Response.Write("var clickcount='" + model.IntClick.ToString() + "';");
                Response.End();
            }
            else
            {
                Response.Write("var clickcount='0';");
                Response.End();
            }
        }
        private void BulletinClickAdd(string click)
        {
            Response.Clear();
            int id = 0;
            if (int.TryParse(click, out id))
            {
                Pbzx.BLL.PBnet_Bulletin bulletinBLL = new Pbzx.BLL.PBnet_Bulletin();
                Pbzx.Model.PBnet_Bulletin model = bulletinBLL.GetModel(int.Parse(click));
                if (model == null)
                {
                    Response.Write("var clickcount='0';");
                    Response.End();
                    return;
                }
                model.IntClick += 1;
                bulletinBLL.Update(model);
                Response.Write("var clickcount='" + model.IntClick.ToString() + "';");
                Response.End();
            }
            else
            {
                Response.Write("var clickcount='0';");
                Response.End();
            }
        }

        private void GetCityData(string province)
        {
            Response.Clear();
            StringBuilder strbu = new StringBuilder();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                SqlCommand com1 = new SqlCommand("select Code ,Name,ProvinceId from City where ProvinceId='" + province + "' ", con);
                SqlDataAdapter da1 = new SqlDataAdapter(com1);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "dbo.City");

                foreach (DataRow row in ds1.Tables[0].Rows)
                {
                    strbu.Append(row["Name"] + "&" + row["Code"] + ",");
                }
            }
            Response.Write(strbu.ToString().Length >= 1 ? strbu.Remove(strbu.Length - 1, 1).ToString() : "��������&");
            Response.End();
        }

        private void CheckUserName(string userName)
        {
            Response.Clear();
            StringBuilder strbu = new StringBuilder();
            if (userName == "")
            {
                Response.Write("�û�������Ϊ�գ�");
            }
            else if (DbHelperSQLBBS.Exists("select * from Dv_User where UserName='" + userName + "'"))
            {
                Response.Write("�Բ���,�����û����Ѿ���ռ��!");
            }
            Response.End();
        }

        private void CheckUserEmail(string userEmail)
        {
            Response.Clear();
            StringBuilder strbu = new StringBuilder();
            if (userEmail == "")
            {
                Response.Write("Email����Ϊ��!");
            }
            else if (DbHelperSQLBBS.Exists("select * from Dv_User where UserEmail='" + userEmail + "'"))
            {
                Response.Write("�Բ���,����Email�Ѿ���ռ��!");
            }
            Response.End();
        }

        private void GetAskType(string bigType)
        {
            Response.Clear();
            StringBuilder strbu = new StringBuilder();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                SqlCommand com1 = new SqlCommand("select Id ,TypeName,FTypeID from PBnet_ask_Type where FTypeID='" + bigType + "' ", con);
                SqlDataAdapter da1 = new SqlDataAdapter(com1);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "dbo.PBnet_ask_Type");

                foreach (DataRow row in ds1.Tables[0].Rows)
                {
                    strbu.Append(row["TypeName"] + "&" + row["Id"] + ",");
                }
            }
            Response.Write(strbu.ToString().Length >= 1 ? strbu.Remove(strbu.Length - 1, 1).ToString() : "��������&");
            Response.End();
        }

    }
}
