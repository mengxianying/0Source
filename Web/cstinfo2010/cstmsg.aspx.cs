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
using System.Text;
using Maticsoft.DBUtility;
using Pbzx.BLL;
using System.Xml;

namespace Pbzx.Web.cstinfo2010
{
    public partial class cstmsg : System.Web.UI.Page
    {
        CstLogin cstuser = new CstLogin();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ///cstinfo2010/cstmsg.aspx?LoginID=1&DownFlag=2&RegType=0&UserClass=0
                //TryVersion("32,4.8.2,3.8.9|33,0,1|32,3.8.7,3.8.9|32,3.8.1,3.8.9|", "3.8.6", 32);
                //LoginID����¼ID�ţ���CstLogin���е�ID�ţ���¼ʱ��ȡ����
                //RegType��ע�᷽ʽ������0����Ѱ�������淽ʽһ������������������ƣ���
                //UserClass���û����ͣ�����1������Ա�ȣ���������������ƣ������¼����Ч����

                //DownFlag�����ر�־��0�����ز�����Ϣ����TestMsgIDȷ������
                //1����������������Ϣ������������ͨ����
                //2������������ҳ��Ϣ��                                 
                //3������������Ѷ��(��Ҫע�������ҳ��Ϣ��������Ѷֻ��Ҫ��ȡ���һ��)

                //TestMsgID�����Ե���ϢID�ţ�����DownFlag=0ʱ��Ч��������������ֵ
                //0��������ӵ�һ����Ϣ����ID�����ģ���
                //-1��������ӵ���ҳ��Ϣ������ҳ��Ϣ��ID�����ģ���
                //-2��������ӵķ���ҳ��Ϣ��������ҳ��Ϣ��ID�����ģ���

                // TextBind();
                //�û�ID
                string LoginID = Pbzx.Common.Input.FilterAll(Request.QueryString["LoginID"]);
                //ע�᷽ʽ
                string RegType = Pbzx.Common.Input.FilterAll(Request.QueryString["RegType"]);
                //�û�����
                string UserClass = Pbzx.Common.Input.FilterAll(Request.QueryString["UserClass"]);
                //���ر�־
                string DownFlag = Pbzx.Common.Input.FilterAll(Request.QueryString["DownFlag"]);
                //���Ե���ϢID��
                string TestMsgID = Pbzx.Common.Input.FilterAll(Request.QueryString["TestMsgID"]);

                if (LoginID == null || DownFlag == null || LoginID == "" || DownFlag == "")
                {
                    return;
                }


                if (DownFlag != "0" && DownFlag != "1" && DownFlag != "2" && DownFlag != "3")
                {
                    return;
                }

                if (DownFlag == null || DownFlag == "")
                {
                    return;
                }
                else if (DownFlag == "0")
                {
                    //�����²�����Ϣ
                    BindTextMssg(LoginID, RegType, UserClass, DownFlag, TestMsgID);
                }
                else if (DownFlag == "1")
                {
                    //��������������Ϣ������������ͨ��
                    BindNewsMsg(LoginID, RegType, UserClass, DownFlag, TestMsgID);
                }
                else if (DownFlag == "2")
                {
                    //����������ҳ��Ϣ�� 
                    BindNewsWeb(LoginID, RegType, UserClass, DownFlag, TestMsgID);
                }
                else if (DownFlag == "3")
                {
                    //����������Ѷ��(��Ҫע�������ҳ��Ϣ��������Ѷֻ��Ҫ��ȡ���һ��)
                    BindNewsZX(LoginID, RegType, UserClass, DownFlag, TestMsgID);
                }
            }

        }

        #region  ����������Ѷ��(��Ҫע�������ҳ��Ϣ��������Ѷֻ��Ҫ��ȡ���һ��)
        /// <summary>
        /// ����������Ѷ��(��Ҫע�������ҳ��Ϣ��������Ѷֻ��Ҫ��ȡ���һ��)
        /// </summary>
        /// <param name="LoginID"></param>
        /// <param name="RegType"></param>
        /// <param name="UserClass"></param>
        /// <param name="DownFlag"></param>
        /// <param name="TestMsgID"></param>
        private void BindNewsZX(string LoginID, string RegType, string UserClass, string DownFlag, string TestMsgID)
        {
            string VersionName = "";
            string SoftwareType1 = "";
            string InstallType1 = "";
            //��������ȷ����ʱ
            StringBuilder but = new StringBuilder();

            //��ѯ�Ƿ�������
            StringBuilder txtbut = new StringBuilder();

            string agstring = "";
            string webstring = "";
            string newstring = "";

            //�û������޶�
            string usernamestring = "";
            //��֤���޶�
            string hdnsstring = "";

            string msgtype = "";

            DataSet ds = null;


            if (DownFlag != "0")
            {
                if (LoginID == null || LoginID == "")
                {
                    Response.Write("User is Error");
                    return;
                }

                try
                {
                    //�õ��ϴ��û���ȡ��ʱ��
                    ds = DbHelperSQL1.Query("select NormalMsgTime,WebMsgTime,NewsMsgTime,Version,SoftwareType,InstallType,HDSN,RN,HDSNType from CstLogin2010 where ID='" + Convert.ToInt32(LoginID) + "'");
                    if (ds.Tables.Count <= 0)
                    {
                        Response.Write("Error");
                        return;
                    }

                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        Response.Write("Error");
                        return;
                    }
                }
                catch
                {
                    Response.Write("Error");
                    return;
                }




                if (ds.Tables[0].Rows.Count > 0)
                {
                    //�û��汾��
                    VersionName = ds.Tables[0].Rows[0]["Version"].ToString();
                    //�������
                    SoftwareType1 = ds.Tables[0].Rows[0]["SoftwareType"].ToString();
                    //
                    InstallType1 = ds.Tables[0].Rows[0]["InstallType"].ToString();
                    //��ͨ��Ϣ�ͽ�����Ϣ�ϴλ�ȡʱ��
                    agstring = ds.Tables[0].Rows[0]["NormalMsgTime"].ToString();

                    //��ҳ��Ϣ�ϴλ�ȡʱ��
                    webstring = ds.Tables[0].Rows[0]["WebMsgTime"].ToString();

                    //������ѯ�ϴλ�ȡʱ��
                    newstring = ds.Tables[0].Rows[0]["NewsMsgTime"].ToString();

                    //�û���
                    usernamestring = ds.Tables[0].Rows[0]["RN"].ToString();

                    //��֤��ID
                    hdnsstring = ds.Tables[0].Rows[0]["HDSN"].ToString();

                    //��Ϣ����
                    msgtype = ds.Tables[0].Rows[0]["HDSNType"].ToString();

                    if (hdnsstring != "")
                    {
                        hdnsstring = " and (HDSN='' OR HDSN like '%" + hdnsstring + "%|' ) ";
                    }

                    if (usernamestring != "")
                    {
                        usernamestring = " and (UserName='' OR UserName like '%|" + usernamestring + "%|') ";
                    }

                    if (newstring != "")
                    {
                        newstring = " and PostTime >'" + newstring.ToString() + "'";
                    }

                }

                but.Append("select");

                txtbut.Append("select count(ID) as Tcount ");

                if (DownFlag == "0" || DownFlag == "2" || DownFlag == "3")
                {
                    but.Append(" Top 1 ");
                }
                but.Append(" * from CM_Main where 1=1 ");
                txtbut.Append(" from CM_Main where 1=1 ");

                if (DownFlag == "3")
                {
                    but.Append("and Type=4 ");
                    but.Append(newstring);
                    txtbut.Append("and Type=4");
                    txtbut.Append(newstring);
                }

                //״̬������ 1�ģ�
                but.Append(" and State=1 ");

                txtbut.Append(" and State=1 ");


                //�Ӳ�ѯ
                but.Append("and ID in(select CMID from CM_MainBySoftwareType where (SoftInfo = " + ((Convert.ToInt32(SoftwareType1) * 16) + Convert.ToInt32(InstallType1)) + " OR SoftInfo = 0)");
                but.Append("and (" + VersionName.Replace(".", "") + " >= BeginVersion or BeginVersion=0) ");
                but.Append("and (" + VersionName.Replace(".", "") + "<=EndVersion or EndVersion=0))");


                //�ȸ��ݿ�ʼʱ������ѯ
                but.Append(" and BeginTime<='" + DateTime.Now.ToString() + "'");

                txtbut.Append(" and BeginTime<='" + DateTime.Now.ToString() + "'");

                //�ڸ��ݽ���ʱ������ѯ
                but.Append(" and EndTime>='" + DateTime.Now.ToString() + "'");

                txtbut.Append(" and EndTime>='" + DateTime.Now.ToString() + "'");


                //�����û�����ѯ
                if (msgtype == "8")
                {
                    but.Append(usernamestring);
                }
                else
                {
                    but.Append(hdnsstring);
                }

                ////ģ����ѯ�������
                //if (RegType != "0")
                //{
                but.Append("and (RegType like '%|" + RegType + "|%' OR RegType = '|0|')");
                //}
                //if (UserClass != "0")
                //{
                but.Append(" and (UserClass like '%|" + UserClass + "|%' OR UserClass = '|0|')");
                //   }
                //���
                but.Append(" order by PostTime desc");

            }


            DataSet TextSet = null;

            int bs = 0;
            if (DownFlag == "3")
            {

                //�ж��ǲ��ǵ���

                if ((DateTime.Now.Year != Convert.ToDateTime(ds.Tables[0].Rows[0]["NewsMsgTime"].ToString()).Year) || (DateTime.Now.Month != Convert.ToDateTime(ds.Tables[0].Rows[0]["NewsMsgTime"].ToString()).Month) || (DateTime.Now.Day != Convert.ToDateTime(ds.Tables[0].Rows[0]["NewsMsgTime"].ToString()).Day))
                {
                    bs = 0;
                }
                else
                {
                    bs = 1;
                }
            }

            if (DownFlag != "0" && bs == 0)
            {
                if (txtbut.ToString().Length > 0)
                {
                    DataSet counttext = DbHelperSQL1.Query(txtbut.ToString());
                    if (counttext != null && counttext.Tables.Count > 0 && Convert.ToInt32(counttext.Tables[0].Rows[0]["Tcount"]) > 0)
                    {
                        TextSet = DbHelperSQL1.Query(but.ToString());
                    }
                }
            }
            else
            {
                //��û����ʱ��������Ѷ����������
                if (bs != 1)
                {
                    TextSet = DbHelperSQL1.Query(but.ToString());
                }
            }


            //��������Ϣʱ
            XmlDocument doc = new XmlDocument();
            //�ж������ʲô�����޶�
            doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/Msg_Private.xml"));
            //�õ����ڵ�
            XmlElement root = doc.DocumentElement;
            XmlNode haha = null;

            haha = root.SelectNodes("reg")[3];

            if ((TextSet != null || DownFlag == "3"))
            {
                StringBuilder buts = new StringBuilder();
                //���ʶ�ʱ

                //����ID�б�
                string ids = "";
                //����ID�б�2���������ط�����0
                string ids2 = "";

                if (TextSet != null && TextSet.Tables.Count > 0)
                {
                    if (TextSet.Tables[0].Rows.Count > 0)
                    {
                        //����ʱ��
                        DbHelperSQL1.ExecuteSql("update CstLogin2010 set NewsMsgTime='" + DateTime.Now.ToString() + "' where ID='" + LoginID + "'");

                        if (haha != null)
                        {
                            buts.Append(haha.SelectSingleNode("@Msg_Minute").Value + ";");
                            buts.Append(TextSet.Tables[0].Rows.Count + ";");
                        }
                    }

                    //��Ϣ����
                    for (int i = 0; i < TextSet.Tables[0].Rows.Count; i++)
                    {
                        if (haha == null)
                        {
                            if (TextSet.Tables[0].Rows[i]["Type"].ToString() == "1" || TextSet.Tables[0].Rows[i]["Type"].ToString() == "2")
                            {
                                haha = root.SelectNodes("reg")[0];
                            }
                            else if (TextSet.Tables[0].Rows[i]["Type"].ToString() == "3")
                            {
                                haha = root.SelectNodes("reg")[2];
                            }
                            else if (TextSet.Tables[0].Rows[i]["Type"].ToString() == "4")
                            {
                                haha = root.SelectNodes("reg")[3];
                            }
                            buts.Append(haha.SelectSingleNode("@Msg_Minute").Value + ";");
                            buts.Append(TextSet.Tables[0].Rows.Count + ";");
                        }

                        ids += TextSet.Tables[0].Rows[i]["Id"] + ",";
                        //��ϢID
                        buts.Append(TextSet.Tables[0].Rows[i]["Id"] + "|");
                        //������
                        buts.Append(TextSet.Tables[0].Rows[i]["Sender"] + "|");
                        //����ʱ��
                        buts.Append(TextSet.Tables[0].Rows[i]["PostTime"] + "|");
                        //����
                        buts.Append(TextSet.Tables[0].Rows[i]["Type"] + "|");
                        //����
                        buts.Append(TextSet.Tables[0].Rows[i]["Category"] + "|");
                        //����
                        buts.Append(TextSet.Tables[0].Rows[i]["Title"] + "|");
                        //���
                        buts.Append(TextSet.Tables[0].Rows[i]["WebWidth"] + "|");
                        //�߶�
                        buts.Append(TextSet.Tables[0].Rows[i]["WebHeight"] + "|");
                        //����URL
                        buts.Append(TextSet.Tables[0].Rows[i]["ContentURL"] + "?v=" + new Random().Next() + "|;");

                        ids2 = NewMethod(ids2, TextSet, i);
                        //}
                    }
                }

                if (ids == "")
                {
                    //�ж��ǲ��ǵ���

                    if ((DateTime.Now.Year != Convert.ToDateTime(ds.Tables[0].Rows[0]["NewsMsgTime"].ToString()).Year) || (DateTime.Now.Month != Convert.ToDateTime(ds.Tables[0].Rows[0]["NewsMsgTime"].ToString()).Month) || (DateTime.Now.Day != Convert.ToDateTime(ds.Tables[0].Rows[0]["NewsMsgTime"].ToString()).Day))
                    {
                        //����ѯ����Ϊ������ѯʱ�����⴦��
                        if (DownFlag == "3")
                        {
                            StringBuilder but1 = new StringBuilder();


                            but1.Append("select Top 1  *from CM_Main where ");

                            //�Ӳ�ѯ
                            but1.Append(" ID in(select CMID from CM_MainBySoftwareType where (SoftInfo = " + ((Convert.ToInt32(SoftwareType1) * 16) + Convert.ToInt32(InstallType1)) + " OR SoftInfo = 0)");
                            but1.Append(" and (" + VersionName.Replace(".", "") + " >= BeginVersion or BeginVersion=0) ");
                            but1.Append(" and (" + VersionName.Replace(".", "") + "<=EndVersion or EndVersion=0))");


                            but1.Append(" and Type=4 ");
                            but1.Append(" and State=1");
                            but1.Append(" and (RegType like '%|" + RegType + "|%' OR RegType = '|0|')");
                            but1.Append(" and (UserClass like '%|" + UserClass + "|%' OR UserClass = '|0|')");
                            but1.Append(" and BeginTime<='" + DateTime.Now.ToString() + "'");
                            but1.Append(" and EndTime>='" + DateTime.Now.ToString() + "'");
                            but1.Append(" order by PostTime desc");

                            DataSet TextSet1 = DbHelperSQL1.Query(but1.ToString());


                            if (TextSet1 != null && TextSet1.Tables.Count > 0)
                            {
                                //��Ϣ����
                                for (int i = 0; i < TextSet1.Tables[0].Rows.Count; i++)
                                {
                                    if (buts.ToString() == "")
                                    {
                                        haha = root.SelectNodes("reg")[3];
                                        buts.Append(haha.SelectSingleNode("@Msg_Minute").Value + ";");
                                        buts.Append(TextSet1.Tables[0].Rows.Count + ";");
                                    }
                                    ids += TextSet1.Tables[0].Rows[i]["Id"] + ",";
                                    //��������ȡ��ʱ��
                                    DbHelperSQL1.Query("update CstLogin2010 set NewsMsgTime='" + DateTime.Now.ToString() + "' where ID='" + LoginID + "'");
                                    //��ϢID
                                    buts.Append(TextSet1.Tables[0].Rows[i]["Id"] + "|");
                                    //������
                                    buts.Append(TextSet1.Tables[0].Rows[i]["Sender"] + "|");
                                    //����ʱ��
                                    buts.Append(TextSet1.Tables[0].Rows[i]["PostTime"] + "|");
                                    //����
                                    buts.Append(TextSet1.Tables[0].Rows[i]["Type"] + "|");
                                    //����
                                    buts.Append(TextSet1.Tables[0].Rows[i]["Category"] + "|");
                                    //����
                                    buts.Append(TextSet1.Tables[0].Rows[i]["Title"] + "|");
                                    //���
                                    buts.Append(TextSet1.Tables[0].Rows[i]["WebWidth"] + "|");
                                    //�߶�
                                    buts.Append(TextSet1.Tables[0].Rows[i]["WebHeight"] + "|");
                                    //����URL
                                    buts.Append(TextSet1.Tables[0].Rows[i]["ContentURL"] + "?v=" + new Random().Next() + "|;");

                                    ids2 = NewMethod(ids2, TextSet1, i);
                                }
                            }
                        }
                    }
                }
                //�жϣ����������ݿ��죬����յ����������
                if (ids2 != "" && DownFlag != "0")
                {
                    ids2 = ids2.Substring(0, ids2.Length - 1);
                    DbHelperSQL1.Query("update CM_Main set TodayCount=0,LastTime='" + DateTime.Now.ToString() + "'  where Id in(" + ids2 + ")");
                }

                if (ids != "" && DownFlag != "0")
                {
                    //�õ����е�ID
                    ids = ids.Substring(0, ids.Length - 1);
                    //�������շ��������ܷ�������1

                    if (ConfigurationManager.AppSettings["Msglog"] == "true")
                    {
                        Pbzx.Common.ErrorLog.WriteLogMeng("[������Ѷ]" + "LoginID:" + LoginID + "  RegType:" + RegType + "  UserClass:" + UserClass + "������Ϣ������" + TextSet.Tables[0].Rows.Count, "����SQL��䣺" + but.ToString(), true, true);
                    }


                    DbHelperSQL1.Query("update CM_Main set TodayCount=TodayCount+1,TotalCount=TotalCount+1,LastTime='" + DateTime.Now.ToString() + "'  where Id in(" + ids + ")");

                }
                else if (ids == "")
                {
                    buts.Remove(0, buts.Length);
                    haha = root.SelectNodes("reg")[3];
                    buts.Append(haha.SelectSingleNode("@Msg_Minute").Value + ";");
                    buts.Append("0;");
                }

                Response.Write(buts.ToString());
                return;
            }
            else
            {
                if (haha != null)
                {
                    Response.Write(haha.SelectSingleNode("@Msg_Minute").Value + ";0;");
                }
                else
                {
                    Response.Write("900;0;");
                }

                return;
            }
        }

        #endregion

        #region   ��������ҳ��Ϣ
        /// <summary>
        /// ��������ҳ��Ϣ
        /// </summary>
        /// <param name="LoginID"></param>
        /// <param name="RegType"></param>
        /// <param name="UserClass"></param>
        /// <param name="DownFlag"></param>
        /// <param name="TestMsgID"></param>
        private void BindNewsWeb(string LoginID, string RegType, string UserClass, string DownFlag, string TestMsgID)
        {
            string VersionName = "";
            string SoftwareType1 = "";
            string InstallType1 = "";
            //��������ȷ����ʱ
            StringBuilder but = new StringBuilder();

            //��ѯ�Ƿ�������
            StringBuilder txtbut = new StringBuilder();

            string agstring = "";
            string webstring = "";
            string WebTime = "";
            string newstring = "";

            //�û������޶�
            string usernamestring = "";
            //��֤���޶�
            string hdnsstring = "";

            string msgtype = "";

            DataSet ds = null;

            if (LoginID == null || LoginID == "")
            {
                Response.Write("User is Error");
                return;
            }

            try
            {
                //�õ��ϴ��û���ȡ��ʱ��
                ds = DbHelperSQL1.Query("select NormalMsgTime,WebMsgTime,NewsMsgTime,Version,SoftwareType,InstallType,HDSN,RN,HDSNType from CstLogin2010 where ID='" + LoginID + "'");
                if (ds == null || ds.Tables.Count <= 0)
                {
                    Response.Write("Error");
                    return;
                }
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    Response.Write("Error");
                    return;
                }
            }
            catch
            {
                Response.Write("Error");
                return;
            }




            if (ds.Tables[0].Rows.Count > 0)
            {
                //�û��汾��
                VersionName = ds.Tables[0].Rows[0]["Version"].ToString();
                //�������
                SoftwareType1 = ds.Tables[0].Rows[0]["SoftwareType"].ToString();
                //
                InstallType1 = ds.Tables[0].Rows[0]["InstallType"].ToString();
                //��ͨ��Ϣ�ͽ�����Ϣ�ϴλ�ȡʱ��
                agstring = ds.Tables[0].Rows[0]["NormalMsgTime"].ToString();

                //��ҳ��Ϣ�ϴλ�ȡʱ��
                webstring = ds.Tables[0].Rows[0]["WebMsgTime"].ToString();
                //������ѯ�ϴλ�ȡʱ��
                newstring = ds.Tables[0].Rows[0]["NewsMsgTime"].ToString();

                //�û���
                usernamestring = ds.Tables[0].Rows[0]["RN"].ToString();

                //��֤��ID
                hdnsstring = ds.Tables[0].Rows[0]["HDSN"].ToString();

                //��Ϣ����
                msgtype = ds.Tables[0].Rows[0]["HDSNType"].ToString();

                if (hdnsstring != "")
                {
                    hdnsstring = " and (HDSN='' OR HDSN like '%" + hdnsstring + "|%' ) and  UserName='' ";
                }

                if (usernamestring != "")
                {
                    usernamestring = " and (UserName='' OR UserName like '%|" + usernamestring + "|%') and HDSN='' ";
                }

                if (webstring != "")
                {
                    webstring = " and PostTime >'" + webstring.ToString() + "'";
                }

            }

            but.Append("select");

            txtbut.Append("select count(ID) as Tcount ");

            if (DownFlag == "0" || DownFlag == "2" || DownFlag == "3")
            {
                but.Append(" Top 1 ");
            }

            but.Append(" * from CM_Main where 1=1 ");
            txtbut.Append(" from CM_Main where 1=1 ");


            but.Append("and Type=3");
            but.Append(webstring);

            //״̬������ 1�ģ�
            but.Append(" and State=1 ");
            txtbut.Append(" and State=1 ");

            //�Ӳ�ѯ
            but.Append("and ID in(select CMID from CM_MainBySoftwareType where (SoftInfo = " + ((Convert.ToInt32(SoftwareType1) * 16) + Convert.ToInt32(InstallType1)) + " OR SoftInfo = 0)");
            but.Append("and (" + VersionName.Replace(".", "") + " >= BeginVersion or BeginVersion=0) ");
            but.Append("and (" + VersionName.Replace(".", "") + "<=EndVersion or EndVersion=0))");


            //�ȸ��ݿ�ʼʱ������ѯ
            but.Append(" and BeginTime<='" + DateTime.Now.ToString() + "'");

            txtbut.Append(" and BeginTime<='" + DateTime.Now.ToString() + "'");

            //�ڸ��ݽ���ʱ������ѯ
            but.Append(" and EndTime>='" + DateTime.Now.ToString() + "'");

            txtbut.Append(" and EndTime>='" + DateTime.Now.ToString() + "'");


            //�����û�����ѯ
            if (msgtype == "8")
            {
                but.Append(usernamestring);
            }
            else
            {
                but.Append(hdnsstring);
            }




            ////ģ����ѯ�������
            //if (RegType != "0")
            //{
            but.Append("and (RegType like '%|" + RegType + "|%' OR RegType = '|0|')");
            //}
            //if (UserClass != "0")
            //{
            but.Append(" and (UserClass like '%|" + UserClass + "|%' OR UserClass = '|0|')");
            //  }
            //���
            but.Append(" order by PostTime asc");



            DataSet TextSet = null;


            if (txtbut.ToString().Length > 0)
            {
                DataSet counttext = DbHelperSQL1.Query(txtbut.ToString());

                if (counttext != null && counttext.Tables.Count > 0)
                {
                    if (Convert.ToInt32(counttext.Tables[0].Rows[0]["Tcount"]) > 0)
                    {
                        TextSet = DbHelperSQL1.Query(but.ToString());
                    }
                }
            }



            //��������Ϣʱ
            XmlDocument doc = new XmlDocument();
            //�ж������ʲô�����޶�
            doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/Msg_Private.xml"));
            //�õ����ڵ�
            XmlElement root = doc.DocumentElement;
            XmlNode haha = null;
            if (DownFlag == "1")
            {
                haha = root.SelectNodes("reg")[0];
            }
            else if (DownFlag == "2")
            {
                haha = root.SelectNodes("reg")[2];
            }
            if (TextSet != null)
            {
                StringBuilder buts = new StringBuilder();
                //���ʶ�ʱ

                //����ID�б�
                string ids = "";
                //����ID�б�2���������ط�����0
                string ids2 = "";

                if (TextSet != null && TextSet.Tables.Count > 0)
                {
                    if (TextSet.Tables[0].Rows.Count > 0)
                    {
                        WebTime = TextSet.Tables[0].Rows[0]["PostTime"].ToString();
                        ///�û���ȡ��������Ϣ������ʱ��
                        //  DbHelperSQL1.ExecuteSql("update CstLogin2010 set WebMsgTime='" + DateTime.Now.ToString() + "' where ID='" + LoginID + "'");
                        DbHelperSQL1.ExecuteSql("update CstLogin2010 set WebMsgTime='" + WebTime + "' where ID='" + LoginID + "'");

                        if (haha != null)
                        {
                            buts.Append(haha.SelectSingleNode("@Msg_Minute").Value + ";");

                        }
                        else
                        {
                            buts.Append("0;");
                        }

                        buts.Append(TextSet.Tables[0].Rows.Count + ";");
                    }
                    else
                    {
                        if (haha != null)
                        {
                            buts.Append(haha.SelectSingleNode("@Msg_Minute").Value + ";0;");
                        }
                        else
                        {
                            buts.Append("0;0;");
                        }
                    }

                    //��Ϣ����
                    for (int i = 0; i < TextSet.Tables[0].Rows.Count; i++)
                    {
                        if (haha == null)
                        {
                            if (TextSet.Tables[0].Rows[i]["Type"].ToString() == "1" || TextSet.Tables[0].Rows[i]["Type"].ToString() == "2")
                            {
                                haha = root.SelectNodes("reg")[0];
                            }
                            else if (TextSet.Tables[0].Rows[i]["Type"].ToString() == "3")
                            {
                                haha = root.SelectNodes("reg")[2];
                            }
                            else if (TextSet.Tables[0].Rows[i]["Type"].ToString() == "4")
                            {
                                haha = root.SelectNodes("reg")[3];
                            }
                            buts.Append(haha.SelectSingleNode("@Msg_Minute").Value + ";");
                            buts.Append(TextSet.Tables[0].Rows.Count + ";");
                        }

                        ids += TextSet.Tables[0].Rows[i]["Id"] + ",";
                        //��ϢID
                        buts.Append(TextSet.Tables[0].Rows[i]["Id"] + "|");
                        //������
                        buts.Append(TextSet.Tables[0].Rows[i]["Sender"] + "|");
                        //����ʱ��
                        buts.Append(TextSet.Tables[0].Rows[i]["PostTime"] + "|");
                        //����
                        buts.Append(TextSet.Tables[0].Rows[i]["Type"] + "|");
                        //����
                        buts.Append(TextSet.Tables[0].Rows[i]["Category"] + "|");
                        //����
                        buts.Append(TextSet.Tables[0].Rows[i]["Title"] + "|");
                        //���
                        buts.Append(TextSet.Tables[0].Rows[i]["WebWidth"] + "|");
                        //�߶�
                        buts.Append(TextSet.Tables[0].Rows[i]["WebHeight"] + "|");
                        //����URL
                        buts.Append(TextSet.Tables[0].Rows[i]["ContentURL"] + "?v=" + new Random().Next()+ "|;");

                        ids2 = NewMethod(ids2, TextSet, i);
                    }
                   
                }
                //�жϣ����������ݿ��죬����յ����������
                if (ids2 != "" && DownFlag != "0")
                {
                    ids2 = ids2.Substring(0, ids2.Length - 1);
                    DbHelperSQL1.Query("update CM_Main set TodayCount=0,LastTime='" + DateTime.Now.ToString() + "'  where Id in(" + ids2 + ")");
                }

                if (ids != "")
                {

                    //�õ����е�ID
                    ids = ids.Substring(0, ids.Length - 1);
                    //�������շ��������ܷ�������1

                    if (ConfigurationManager.AppSettings["Msglog"] == "true")
                    {
                        Pbzx.Common.ErrorLog.WriteLogMeng("[������ҳ��Ϣ]" + "LoginID:" + LoginID + "  RegType:" + RegType + "  UserClass:" + UserClass + "������Ϣ������" + TextSet.Tables[0].Rows.Count, "����SQL��䣺" + but.ToString(), true, true);
                    }

                    DbHelperSQL1.Query("update CM_Main set TodayCount=TodayCount+1,TotalCount=TotalCount+1,LastTime='" + DateTime.Now.ToString() + "'  where Id in(" + ids + ")");
                }

                Response.Write(buts.ToString());
                return;
            }
            else
            {
                if (haha != null)
                {
                    Response.Write(haha.SelectSingleNode("@Msg_Minute").Value + ";0;");
                }
                else
                {
                    Response.Write("900;0;");
                }
                return;
            }
        }

        #endregion

        #region ����������Ϣ������������ͨ��
        /// <summary>
        /// ����������Ϣ������������ͨ��
        /// </summary>
        /// <param name="LoginID"></param>
        /// <param name="RegType"></param>
        /// <param name="UserClass"></param>
        /// <param name="DownFlag"></param>
        /// <param name="TestMsgID"></param>
        private void BindNewsMsg(string LoginID, string RegType, string UserClass, string DownFlag, string TestMsgID)
        {
            string VersionName = "";
            string SoftwareType1 = "";
            string InstallType1 = "";
            //��������ȷ����ʱ
            StringBuilder but = new StringBuilder();

            //��ѯ�Ƿ�������
            StringBuilder txtbut = new StringBuilder();

            string agstring = "";
            string webstring = "";
            string newstring = "";

            //�û������޶�
            string usernamestring = "";
            //��֤���޶�
            string hdnsstring = "";

            string msgtype = "";

            DataSet ds = null;
            if (DownFlag != "0")
            {
                if (LoginID == null || LoginID == "")
                {
                    Response.Write("User is Error");
                    return;
                }

                try
                {
                    //�õ��ϴ��û���ȡ��ʱ��
                    ds = DbHelperSQL1.Query("select NormalMsgTime,WebMsgTime,NewsMsgTime,Version,SoftwareType,InstallType,HDSN,RN,HDSNType from CstLogin2010 where ID='" + LoginID + "'");
                    if (ds == null || ds.Tables.Count <= 0)
                    {
                        Response.Write("Error");
                        return;
                    }
                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        Response.Write("Error");
                        return;
                    }
                }
                catch
                {
                    Response.Write("Error");
                    return;
                }




                if (ds.Tables[0].Rows.Count > 0)
                {
                    //�û��汾��
                    VersionName = ds.Tables[0].Rows[0]["Version"].ToString();
                    //�������
                    SoftwareType1 = ds.Tables[0].Rows[0]["SoftwareType"].ToString();
                    //
                    InstallType1 = ds.Tables[0].Rows[0]["InstallType"].ToString();
                    //��ͨ��Ϣ�ͽ�����Ϣ�ϴλ�ȡʱ��
                    agstring = ds.Tables[0].Rows[0]["NormalMsgTime"].ToString();

                    //��ҳ��Ϣ�ϴλ�ȡʱ��
                    webstring = ds.Tables[0].Rows[0]["WebMsgTime"].ToString();

                    //������ѯ�ϴλ�ȡʱ��
                    newstring = ds.Tables[0].Rows[0]["NewsMsgTime"].ToString();

                    //�û���
                    usernamestring = ds.Tables[0].Rows[0]["RN"].ToString();

                    //��֤��ID
                    hdnsstring = ds.Tables[0].Rows[0]["HDSN"].ToString();

                    //��Ϣ����
                    msgtype = ds.Tables[0].Rows[0]["HDSNType"].ToString();

                    if (hdnsstring != "")
                    {
                        hdnsstring = " and (HDSN='' OR HDSN like '%" + hdnsstring + "%|' ) ";
                    }

                    if (usernamestring != "")
                    {
                        usernamestring = " and (UserName='' OR UserName like '%|" + usernamestring + "|%') ";
                    }

                    if (agstring != "")
                    {
                        agstring = " and PostTime >'" + agstring.ToString() + "'";
                    }
                }

                but.Append("select");

                txtbut.Append("select count(ID) as Tcount ");

                if (DownFlag == "0" || DownFlag == "2" || DownFlag == "3")
                {
                    but.Append(" Top 1 ");
                }
                but.Append(" * from CM_Main where 1=1 ");
                txtbut.Append(" from CM_Main where 1=1 ");



                //�Ӳ�ѯ
                but.Append("and ID in(select CMID from CM_MainBySoftwareType where (SoftInfo = " + ((Convert.ToInt32(SoftwareType1) * 16) + Convert.ToInt32(InstallType1)) + " OR SoftInfo = 0)");
                but.Append("and (" + VersionName.Replace(".", "") + " >= BeginVersion or BeginVersion=0) ");
                but.Append("and (" + VersionName.Replace(".", "") + "<=EndVersion or EndVersion=0))");



                //��������������Ϣ������������ͨ��

                but.Append("and Type in(1,2)");
                but.Append(agstring);

                txtbut.Append("and Type in(1,2)");
                txtbut.Append(agstring);


                //״̬������ 1�ģ�
                but.Append(" and State=1 ");

                txtbut.Append(" and State=1 ");


                //�ȸ��ݿ�ʼʱ������ѯ
                but.Append(" and BeginTime<='" + DateTime.Now.ToString() + "'");

                txtbut.Append(" and BeginTime<='" + DateTime.Now.ToString() + "'");

                //�ڸ��ݽ���ʱ������ѯ
                but.Append(" and EndTime>='" + DateTime.Now.ToString() + "'");

                txtbut.Append(" and EndTime>='" + DateTime.Now.ToString() + "'");


                //�����û�����ѯ
                if (msgtype == "8")
                {
                    but.Append(usernamestring);
                }
                else
                {
                    but.Append(hdnsstring);
                }

                ////ģ����ѯ�������
                //if (RegType != "0")
                //{
                but.Append("and (RegType like '%|" + RegType + "|%' OR RegType = '|0|')");
                //}
                //if (UserClass != "0")
                //{
                but.Append(" and (UserClass like '%|" + UserClass + "|%' OR UserClass = '|0|')");
                // }
                //���
                but.Append(" order by PostTime desc");

            }

            DataSet TextSet = null;

            if (txtbut.ToString().Length > 0)
            {
                DataSet counttext = DbHelperSQL1.Query(txtbut.ToString());

                if (counttext != null && counttext.Tables.Count > 0 && Convert.ToInt32(counttext.Tables[0].Rows[0]["Tcount"]) > 0)
                {
                    TextSet = DbHelperSQL1.Query(but.ToString());
                }
            }

            //��������Ϣʱ
            XmlDocument doc = new XmlDocument();
            //�ж������ʲô�����޶�
            doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/Msg_Private.xml"));
            //�õ����ڵ�
            XmlElement root = doc.DocumentElement;
            XmlNode haha = null;

            haha = root.SelectNodes("reg")[0];

            if (TextSet != null)
            {
                StringBuilder buts = new StringBuilder();
                //���ʶ�ʱ

                //����ID�б�
                string ids = "";
                //����ID�б�2���������ط�����0
                string ids2 = "";

                if (TextSet != null && TextSet.Tables.Count > 0)
                {
                    if (TextSet.Tables[0].Rows.Count > 0)
                    {
                        //�����û��Ļ�ȡʱ��

                        DbHelperSQL1.ExecuteSql("update CstLogin2010 set NormalMsgTime='" + DateTime.Now.ToString() + "' where ID='" + LoginID + "'");


                        if (haha != null)
                        {
                            buts.Append(haha.SelectSingleNode("@Msg_Minute").Value + ";");
                            buts.Append(TextSet.Tables[0].Rows.Count + ";");
                        }
                    }

                    //��Ϣ����
                    for (int i = 0; i < TextSet.Tables[0].Rows.Count; i++)
                    {

                        if (haha == null)
                        {
                            if (TextSet.Tables[0].Rows[i]["Type"].ToString() == "1" || TextSet.Tables[0].Rows[i]["Type"].ToString() == "2")
                            {
                                haha = root.SelectNodes("reg")[0];
                            }
                            else if (TextSet.Tables[0].Rows[i]["Type"].ToString() == "3")
                            {
                                haha = root.SelectNodes("reg")[2];
                            }
                            else if (TextSet.Tables[0].Rows[i]["Type"].ToString() == "4")
                            {
                                haha = root.SelectNodes("reg")[3];
                            }
                            buts.Append(haha.SelectSingleNode("@Msg_Minute").Value + ";");
                            buts.Append(TextSet.Tables[0].Rows.Count + ";");
                        }

                        ids += TextSet.Tables[0].Rows[i]["Id"] + ",";
                        //��ϢID
                        buts.Append(TextSet.Tables[0].Rows[i]["Id"] + "|");
                        //������
                        buts.Append(TextSet.Tables[0].Rows[i]["Sender"] + "|");
                        //����ʱ��
                        buts.Append(TextSet.Tables[0].Rows[i]["PostTime"] + "|");
                        //����
                        buts.Append(TextSet.Tables[0].Rows[i]["Type"] + "|");
                        //����
                        buts.Append(TextSet.Tables[0].Rows[i]["Category"] + "|");
                        //����
                        buts.Append(TextSet.Tables[0].Rows[i]["Title"] + "|");
                        //���
                        buts.Append(TextSet.Tables[0].Rows[i]["WebWidth"] + "|");
                        //�߶�
                        buts.Append(TextSet.Tables[0].Rows[i]["WebHeight"] + "|");
                        //����URL
                        buts.Append(TextSet.Tables[0].Rows[i]["ContentURL"] + "?v=" + new Random().Next() + "|;");

                        ids2 = NewMethod(ids2, TextSet, i);
                    }


                }

                //�жϣ����������ݿ��죬����յ����������
                if (ids2 != "" && DownFlag != "0")
                {
                    ids2 = ids2.Substring(0, ids2.Length - 1);
                    DbHelperSQL1.Query("update CM_Main set TodayCount=0,LastTime='" + DateTime.Now.ToString() + "'  where Id in(" + ids2 + ")");
                }

                if (ids != "" && DownFlag != "0")
                {
                    //�õ����е�ID
                    ids = ids.Substring(0, ids.Length - 1);
                    //�������շ��������ܷ�������1


                    if (ConfigurationManager.AppSettings["Msglog"] == "true")
                    {
                        Pbzx.Common.ErrorLog.WriteLogMeng("[��������ͨ]" + "LoginID:" + LoginID + "  RegType:" + RegType + "  UserClass:" + UserClass + "������Ϣ������" + TextSet.Tables[0].Rows.Count, "����SQL��䣺" + but.ToString(), true, true);
                    }


                    DbHelperSQL1.Query("update CM_Main set TodayCount=TodayCount+1,TotalCount=TotalCount+1,LastTime='" + DateTime.Now.ToString() + "'  where Id in(" + ids + ")");

                }


                if (buts.ToString() == "")
                {
                    if (haha != null)
                    {
                        Response.Write(haha.SelectSingleNode("@Msg_Minute").Value + ";0;");
                    }
                    else
                    {
                        Response.Write("0;0;");
                    }
                }
                else
                {
                    Response.Write(buts.ToString());
                }
                return;
            }
            else
            {
                if (haha != null)
                {
                    Response.Write(haha.SelectSingleNode("@Msg_Minute").Value + ";0;");
                }
                else
                {
                    Response.Write("0;0;");
                }

                return;
            }
        }
        #endregion

        #region  ������Ϣ
        /// <summary>
        /// �õ�������Ϣ
        /// </summary>
        private void BindTextMssg(string LoginID, string RegType, string UserClass, string DownFlag, string TestMsgID)
        {
            string VersionName = "";
            string SoftwareType1 = "";
            string InstallType1 = "";
            //��������ȷ����ʱ
            StringBuilder but = new StringBuilder();

            //��ѯ�Ƿ�������
            StringBuilder txtbut = new StringBuilder();

            string agstring = "";
            string webstring = "";
            string newstring = "";

            //�û������޶�
            string usernamestring = "";
            //��֤���޶�
            string hdnsstring = "";

            string msgtype = "";

            DataSet ds = null;

            if (TestMsgID == null || TestMsgID == "")
            {
                return;
            }

            but.Append("select top 1 * from CM_Main where");

            if (TestMsgID == "0")
            {
                but.Append(" Type=1");
            }

            else if (TestMsgID == "-1")
            {
                but.Append(" Type = 2");
            }
            else if (TestMsgID == "-2")
            {
                but.Append(" Type =3");
            }
            else if (TestMsgID == "-3")
            {
                but.Append(" Type =4");
            }
            else if (TestMsgID == "-4")
            {
                but.Append(" 1=1");
            }
            else
                but.Append(" Id =" + TestMsgID);

            but.Append(" order by PostTime desc");

            DataSet TextSet = DbHelperSQL1.Query(but.ToString());

            //��������Ϣʱ

            XmlNode nodetime = BindXMLTime(DownFlag);


            if (TextSet != null)
            {
                StringBuilder buts = new StringBuilder();
                //���ʶ�ʱ

                //����ID�б�
                string ids = "";
                //����ID�б�2���������ط�����0
                string ids2 = "";

                if (TextSet != null && TextSet.Tables.Count > 0)
                {
                    if (TextSet.Tables[0].Rows.Count > 0)
                    {

                        if (nodetime != null)
                        {
                            buts.Append(nodetime.SelectSingleNode("@Msg_Minute").Value + ";");
                        }
                        else
                        {
                            buts.Append("0;");
                        }
                        buts.Append(TextSet.Tables[0].Rows.Count + ";");
                    }

                    //��Ϣ����
                    for (int i = 0; i < TextSet.Tables[0].Rows.Count; i++)
                    {
                        //��ȡ��Ϣ�汾
                        string vis = TextSet.Tables[0].Rows[i]["SoftInfo"].ToString();
                        //�жϰ汾
                        int bo = 0;
                        if (VersionName != "" || SoftwareType1 != "" || InstallType1 != "")
                        {
                            bo = TryVersion(vis, VersionName, ((Convert.ToInt32(SoftwareType1) * 16) + Convert.ToInt32(InstallType1)));
                        }
                        if (bo == 1 || DownFlag == "0")
                        {
                            ids += TextSet.Tables[0].Rows[i]["Id"] + ",";
                            //��ϢID
                            buts.Append(TextSet.Tables[0].Rows[i]["Id"] + "|");
                            //������
                            buts.Append(TextSet.Tables[0].Rows[i]["Sender"] + "|");
                            //����ʱ��
                            buts.Append(TextSet.Tables[0].Rows[i]["PostTime"] + "|");
                            //����
                            buts.Append(TextSet.Tables[0].Rows[i]["Type"] + "|");
                            //����
                            buts.Append(TextSet.Tables[0].Rows[i]["Category"] + "|");
                            //����
                            buts.Append(TextSet.Tables[0].Rows[i]["Title"] + "|");
                            //���
                            buts.Append(TextSet.Tables[0].Rows[i]["WebWidth"] + "|");
                            //�߶�
                            buts.Append(TextSet.Tables[0].Rows[i]["WebHeight"] + "|");
                            //����URL
                            buts.Append(TextSet.Tables[0].Rows[i]["ContentURL"] + "?v=" + new Random().Next() + "|;");

                            ids2 = NewMethod(ids2, TextSet, i);
                        }
                    }
                }

                //�жϣ����������ݿ��죬����յ����������
                if (ids2 != "" && DownFlag != "0")
                {
                    ids2 = ids2.Substring(0, ids2.Length - 1);
                    DbHelperSQL1.Query("update CM_Main set TodayCount=0,LastTime='" + DateTime.Now.ToString() + "'  where Id in(" + ids2 + ")");
                }

                if (ids != "" && DownFlag != "0")
                {
                    //�õ����е�ID
                    ids = ids.Substring(0, ids.Length - 1);

                    //�������շ��������ܷ�������1
                    DbHelperSQL1.Query("update CM_Main set TodayCount=TodayCount+1,TotalCount=TotalCount+1,LastTime='" + DateTime.Now.ToString() + "'  where Id in(" + ids + ")");

                }
                if (buts.ToString() == "")
                {
                    if (nodetime != null)
                    {
                        Response.Write(nodetime.SelectSingleNode("@Msg_Minute").Value + ";0;");
                    }
                    else
                    {
                        Response.Write("900;0;");
                    }
                }
                else
                {
                    Response.Write(buts.ToString());
                }
                return;
            }
            else
            {
                if (nodetime != null)
                {
                    Response.Write(nodetime.SelectSingleNode("@Msg_Minute").Value + ";0;");
                }
                else
                {
                    Response.Write("900;0;");
                }

                return;
            }
        }

        #endregion


        #region �õ���ѭʱ��
        /// <summary>
        /// �õ���ѭʱ��
        /// </summary>
        /// <returns></returns>
        private XmlNode BindXMLTime(string DownFlag)
        {
            XmlDocument doc = new XmlDocument();
            //�ж������ʲô�����޶�
            doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/Msg_Private.xml"));
            //�õ����ڵ�
            XmlElement root = doc.DocumentElement;

            if (DownFlag == "1")
            {
                return root.SelectNodes("reg")[0];
            }
            else if (DownFlag == "2")
            {
                return root.SelectNodes("reg")[2];
            }
            else if (DownFlag == "3")
            {
                return root.SelectNodes("reg")[3];
            }

            return null;
        }

        #endregion

        #region ԭ
        /// <summary>
        /// ���ݰ�
        /// // ������Ϣ��
        /// ��Ϣ��Ϣ��ʽ������ʱ���;��Ϣ����;��ϢID|������|����ʱ��|����|����|����|���|�߶�|����URL ���ԡ�|���ָ���
        /// </summary>
        private void TextBind()
        {
            //�û�ID
            string LoginID = Pbzx.Common.Input.FilterAll(Request.QueryString["LoginID"]);
            //ע�᷽ʽ
            string RegType = Pbzx.Common.Input.FilterAll(Request.QueryString["RegType"]);
            //�û�����
            string UserClass = Pbzx.Common.Input.FilterAll(Request.QueryString["UserClass"]);
            //���ر�־
            string DownFlag = Pbzx.Common.Input.FilterAll(Request.QueryString["DownFlag"]);
            //���Ե���ϢID��
            string TestMsgID = Pbzx.Common.Input.FilterAll(Request.QueryString["TestMsgID"]);

            //////////////////////////////////////////////////////////////////////
            //if (DownFlag == "3")
            //{
            //    Pbzx.Common.ErrorLog.WriteLogMeng("����������Ѷ���û�ID��" + LoginID + " ע�᷽ʽ��" + RegType + " �û����ͣ�" + UserClass, "��ʼ��Ϣ���ݣ�", true, true);
            //}
            //////////////////////////////////////////////////////////////////////

            string VersionName = "";
            string SoftwareType1 = "";
            string InstallType1 = "";
            //��������ȷ����ʱ
            StringBuilder but = new StringBuilder();

            //��ѯ�Ƿ�������
            StringBuilder txtbut = new StringBuilder();

            string agstring = "";
            string webstring = "";
            string newstring = "";

            //�û������޶�
            string usernamestring = "";
            //��֤���޶�
            string hdnsstring = "";

            string msgtype = "";

            DataSet ds = null;
            if (DownFlag != "0" && DownFlag != "1" && DownFlag != "2" && DownFlag != "3")
            {
                return;
            }
            if (DownFlag == "0")
            {
                if (TestMsgID == null || TestMsgID == "")
                {
                    return;
                }
            }
            if (DownFlag != "0")
            {
                if (LoginID == null || LoginID == "")
                {
                    Response.Write("User is Error");
                    return;
                }

                try
                {
                    //�õ��ϴ��û���ȡ��ʱ��
                    ds = DbHelperSQL1.Query("select NormalMsgTime,WebMsgTime,NewsMsgTime,Version,SoftwareType,InstallType,HDSN,RN,HDSNType from CstLogin2010 where ID='" + LoginID + "'");
                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        Response.Write("Error");
                        return;
                    }
                }
                catch
                {
                    Response.Write("Error");
                    return;
                }




                if (ds.Tables[0].Rows.Count > 0)
                {
                    //�û��汾��
                    VersionName = ds.Tables[0].Rows[0]["Version"].ToString();
                    //�������
                    SoftwareType1 = ds.Tables[0].Rows[0]["SoftwareType"].ToString();
                    //
                    InstallType1 = ds.Tables[0].Rows[0]["InstallType"].ToString();
                    //��ͨ��Ϣ�ͽ�����Ϣ�ϴλ�ȡʱ��
                    agstring = ds.Tables[0].Rows[0]["NormalMsgTime"].ToString();

                    //��ҳ��Ϣ�ϴλ�ȡʱ��
                    webstring = ds.Tables[0].Rows[0]["WebMsgTime"].ToString();

                    //������ѯ�ϴλ�ȡʱ��
                    newstring = ds.Tables[0].Rows[0]["NewsMsgTime"].ToString();

                    //�û���
                    usernamestring = ds.Tables[0].Rows[0]["RN"].ToString();

                    //��֤��ID
                    hdnsstring = ds.Tables[0].Rows[0]["HDSN"].ToString();

                    //��Ϣ����
                    msgtype = ds.Tables[0].Rows[0]["HDSNType"].ToString();

                    if (hdnsstring != "")
                    {
                        hdnsstring = " and (HDSN='' OR HDSN like '%" + hdnsstring + "%|' ) ";
                    }

                    if (usernamestring != "")
                    {
                        usernamestring = " and (UserName='' OR UserName like '%" + usernamestring + "%|') ";
                    }

                    if (agstring != "")
                    {
                        agstring = " and PostTime >'" + agstring.ToString() + "'";
                    }
                    if (webstring != "")
                    {
                        webstring = " and PostTime >'" + webstring.ToString() + "'";
                    }
                    if (newstring != "")
                    {
                        newstring = " and PostTime >'" + newstring.ToString() + "'";
                    }

                }

                but.Append("select");

                txtbut.Append("select count(ID) as Tcount ");

                if (DownFlag == "0" || DownFlag == "2" || DownFlag == "3")
                {
                    but.Append(" Top 1 ");
                }
                but.Append(" * from CM_Main where 1=1 ");
                txtbut.Append(" from CM_Main where 1=1 ");

                //��������������Ϣ������������ͨ��
                if (DownFlag == "1")
                {
                    but.Append("and Type in(1,2)");
                    but.Append(agstring);

                    txtbut.Append("and Type in(1,2)");
                    txtbut.Append(agstring);
                }
                else if (DownFlag == "2")
                {
                    but.Append("and Type=3");
                    but.Append(webstring);

                    txtbut.Append("and Type=3");
                    txtbut.Append(webstring);
                }
                else if (DownFlag == "3")
                {
                    but.Append("and Type=4 ");
                    // but.Append(newstring);

                    txtbut.Append("and Type=4");
                    //  txtbut.Append(newstring);
                }

                //״̬������ 1�ģ�
                but.Append(" and State=1 ");

                txtbut.Append(" and State=1 ");


                //�ȸ��ݿ�ʼʱ������ѯ
                but.Append(" and BeginTime<='" + DateTime.Now.ToString() + "'");

                txtbut.Append(" and BeginTime<='" + DateTime.Now.ToString() + "'");

                //�ڸ��ݽ���ʱ������ѯ
                but.Append(" and EndTime>='" + DateTime.Now.ToString() + "'");

                txtbut.Append(" and EndTime>='" + DateTime.Now.ToString() + "'");


                //�����û�����ѯ
                if (msgtype == "8")
                {
                    but.Append(usernamestring);
                }
                else
                {
                    but.Append(hdnsstring);
                }

                //ģ����ѯ�������
                if (RegType != "0")
                {
                    but.Append("and (RegType like '%" + RegType + "%' OR RegType = '0|')");
                }
                if (UserClass != "0")
                {
                    but.Append(" and (UserClass like '%" + UserClass + "%' OR UserClass = '0|')");
                }
                //���
                but.Append(" order by PostTime desc");

            }
            if (DownFlag == "0")
            {
                but.Append("select top 1 * from CM_Main where");
                if (TestMsgID == "0")
                {
                    but.Append(" Type=1");
                }

                else if (TestMsgID == "-1")
                {
                    but.Append(" Type = 2");
                }
                else if (TestMsgID == "-2")
                {
                    but.Append(" Type =3");
                }
                else if (TestMsgID == "-3")
                {
                    but.Append(" Type =4");
                }
                else if (TestMsgID == "-4")
                {
                    but.Append(" 1=1");
                }
                else
                    but.Append(" Id =" + TestMsgID);

                but.Append(" order by PostTime desc");
            }


            DataSet TextSet = null;

            int bs = 0;
            if (DownFlag == "3")
            {

                //�ж��ǲ��ǵ���

                if (DateTime.Now.Day != Convert.ToDateTime(ds.Tables[0].Rows[0]["NewsMsgTime"].ToString()).Day)
                {
                    bs = 0;
                }
                else
                {
                    bs = 1;
                }
            }

            if (DownFlag != "0" && bs == 0)
            {
                if (txtbut.ToString().Length > 0)
                {
                    DataSet counttext = DbHelperSQL1.Query(txtbut.ToString());

                    //Pbzx.Common.ErrorLog.WriteLogMeng("������Ϣ������" + counttext.Tables[0].Rows[0]["Tcount"].ToString(), "����SQL��䣺" + txtbut.ToString(), true, true);

                    if (Convert.ToInt32(counttext.Tables[0].Rows[0]["Tcount"]) > 0)
                    {
                        TextSet = DbHelperSQL1.Query(but.ToString());
                        //Pbzx.Common.ErrorLog.WriteLogMeng("������Ϣ������" + TextSet.Tables[0].Rows.Count, "����SQL��䣺" + but.ToString(), true, true);
                    }
                }
            }
            else
            {
                //��û����ʱ��������Ѷ����������
                if (bs != 1)
                {
                    TextSet = DbHelperSQL1.Query(but.ToString());
                }
            }


            //��������Ϣʱ
            XmlDocument doc = new XmlDocument();
            //�ж������ʲô�����޶�
            doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/Msg_Private.xml"));
            //�õ����ڵ�
            XmlElement root = doc.DocumentElement;
            XmlNode haha = null;
            if (DownFlag == "1")
            {
                haha = root.SelectNodes("reg")[0];
            }
            else if (DownFlag == "2")
            {
                haha = root.SelectNodes("reg")[2];
            }
            else if (DownFlag == "3")
            {
                haha = root.SelectNodes("reg")[3];
            }
            if ((TextSet != null || DownFlag == "3"))
            {
                StringBuilder buts = new StringBuilder();
                //���ʶ�ʱ

                //����ID�б�
                string ids = "";
                //����ID�б�2���������ط�����0
                string ids2 = "";

                if (TextSet != null)
                {
                    if (TextSet.Tables[0].Rows.Count > 0)
                    {
                        //////////////////////////////////////////////////////////////////////
                        //if (DownFlag == "3")
                        //{
                        //    Pbzx.Common.ErrorLog.WriteLogMeng(">>>>>>>>>>���ݼ���ִ�� SQL��䣺" + but.ToString(), "ȷ��ִ�е�������һ��", true, true);
                        //}
                        //////////////////////////////////////////////////////////////////////
                        //�����û��Ļ�ȡʱ��
                        if (DownFlag == "1")
                        {
                            DbHelperSQL1.ExecuteSql("update CstLogin2010 set NormalMsgTime='" + DateTime.Now.ToString() + "' where ID='" + LoginID + "'");
                        }
                        else if (DownFlag == "2")
                        {
                            DbHelperSQL1.ExecuteSql("update CstLogin2010 set WebMsgTime='" + DateTime.Now.ToString() + "' where ID='" + LoginID + "'");
                        }
                        else if (DownFlag == "3")
                        {

                            DbHelperSQL1.ExecuteSql("update CstLogin2010 set NewsMsgTime='" + DateTime.Now.ToString() + "' where ID='" + LoginID + "'");
                        }

                        //////////////////////////////////////////////////////////////////////
                        //if (DownFlag == "3")
                        //{
                        //    Pbzx.Common.ErrorLog.WriteLogMeng(">>>>>>>>>>����ʱ��������", "ȷ��ִ�е�������һ��", true, true);
                        //}
                        //////////////////////////////////////////////////////////////////////

                        if (haha != null)
                        {
                            buts.Append(haha.SelectSingleNode("@Msg_Minute").Value + ";");
                            buts.Append(TextSet.Tables[0].Rows.Count + ";");
                        }
                    }

                    //��Ϣ����
                    for (int i = 0; i < TextSet.Tables[0].Rows.Count; i++)
                    {
                        //��ȡ��Ϣ�汾
                        string vis = TextSet.Tables[0].Rows[i]["SoftInfo"].ToString();
                        //�жϰ汾
                        int bo = 0;
                        if (VersionName != "" || SoftwareType1 != "" || InstallType1 != "")
                        {
                            bo = TryVersion(vis, VersionName, ((Convert.ToInt32(SoftwareType1) * 16) + Convert.ToInt32(InstallType1)));
                        }
                        if (bo == 1 || DownFlag == "0")
                        {
                            if (haha == null)
                            {
                                if (TextSet.Tables[0].Rows[i]["Type"].ToString() == "1" || TextSet.Tables[0].Rows[i]["Type"].ToString() == "2")
                                {
                                    haha = root.SelectNodes("reg")[0];
                                }
                                else if (TextSet.Tables[0].Rows[i]["Type"].ToString() == "3")
                                {
                                    haha = root.SelectNodes("reg")[2];
                                }
                                else if (TextSet.Tables[0].Rows[i]["Type"].ToString() == "4")
                                {
                                    haha = root.SelectNodes("reg")[3];
                                }
                                buts.Append(haha.SelectSingleNode("@Msg_Minute").Value + ";");
                                buts.Append(TextSet.Tables[0].Rows.Count + ";");
                            }

                            ids += TextSet.Tables[0].Rows[i]["Id"] + ",";
                            //��ϢID
                            buts.Append(TextSet.Tables[0].Rows[i]["Id"] + "|");
                            //������
                            buts.Append(TextSet.Tables[0].Rows[i]["Sender"] + "|");
                            //����ʱ��
                            buts.Append(TextSet.Tables[0].Rows[i]["PostTime"] + "|");
                            //����
                            buts.Append(TextSet.Tables[0].Rows[i]["Type"] + "|");
                            //����
                            buts.Append(TextSet.Tables[0].Rows[i]["Category"] + "|");
                            //����
                            buts.Append(TextSet.Tables[0].Rows[i]["Title"] + "|");
                            //���
                            buts.Append(TextSet.Tables[0].Rows[i]["WebWidth"] + "|");
                            //�߶�
                            buts.Append(TextSet.Tables[0].Rows[i]["WebHeight"] + "|");
                            //����URL
                            buts.Append(TextSet.Tables[0].Rows[i]["ContentURL"] + "?v=" + new Random().Next() + "|;");

                            ids2 = NewMethod(ids2, TextSet, i);
                        }
                    }
                    //////////////////////////////////////////////////////////////////////
                    //if (DownFlag == "3")
                    //{
                    //    Pbzx.Common.ErrorLog.WriteLogMeng(">>>>>>>>>>��Ϣ�������", "����������" + TextSet.Tables[0].Rows.Count, true, true);
                    //}
                    //////////////////////////////////////////////////////////////////////
                }

                if (ids == "")
                {
                    //�ж��ǲ��ǵ���

                    if (DateTime.Now.Day != Convert.ToDateTime(ds.Tables[0].Rows[0]["NewsMsgTime"].ToString()).Day)
                    {
                        //����ѯ����Ϊ������ѯʱ�����⴦��
                        if (DownFlag == "3")
                        {

                            DataSet TextSet1 = DbHelperSQL1.Query(" select Top 1  *from CM_Main where (RegType like '%" + RegType + "%' OR RegType = '0|') and (UserClass like '%" + UserClass + "%' OR UserClass = '0|') and BeginTime<='" + DateTime.Now.ToString() + "' and EndTime>='" + DateTime.Now.ToString() + "'and Type=4 and State=1 order by PostTime desc");

                            //////////////////////////////////////////////////////////////////////
                            //if (DownFlag == "3")
                            //{
                            //    Pbzx.Common.ErrorLog.WriteLogMeng("û��������Ѷʱ SQL��䣺" + but.ToString(), "ȷ��ִ�е�������һ��", true, true);
                            //}
                            //////////////////////////////////////////////////////////////////////

                            if (TextSet1 != null)
                            {
                                //��Ϣ����
                                for (int i = 0; i < TextSet1.Tables[0].Rows.Count; i++)
                                {
                                    //��ȡ��Ϣ�汾
                                    string vis = TextSet1.Tables[0].Rows[i]["SoftInfo"].ToString();
                                    //�жϰ汾
                                    if (TryVersion(vis, VersionName, ((Convert.ToInt32(SoftwareType1) * 16) + Convert.ToInt32(InstallType1))) == 1)
                                    {
                                        if (buts.ToString() == "")
                                        {
                                            haha = root.SelectNodes("reg")[3];
                                            buts.Append(haha.SelectSingleNode("@Msg_Minute").Value + ";");
                                            buts.Append(TextSet1.Tables[0].Rows.Count + ";");
                                        }
                                        ids += TextSet1.Tables[0].Rows[i]["Id"] + ",";
                                        //��������ȡ��ʱ��
                                        DbHelperSQL1.Query("update CstLogin2010 set NewsMsgTime='" + DateTime.Now.ToString() + "' where ID='" + LoginID + "'");
                                        //��ϢID
                                        buts.Append(TextSet1.Tables[0].Rows[i]["Id"] + "|");
                                        //������
                                        buts.Append(TextSet1.Tables[0].Rows[i]["Sender"] + "|");
                                        //����ʱ��
                                        buts.Append(TextSet1.Tables[0].Rows[i]["PostTime"] + "|");
                                        //����
                                        buts.Append(TextSet1.Tables[0].Rows[i]["Type"] + "|");
                                        //����
                                        buts.Append(TextSet1.Tables[0].Rows[i]["Category"] + "|");
                                        //����
                                        buts.Append(TextSet1.Tables[0].Rows[i]["Title"] + "|");
                                        //���
                                        buts.Append(TextSet1.Tables[0].Rows[i]["WebWidth"] + "|");
                                        //�߶�
                                        buts.Append(TextSet1.Tables[0].Rows[i]["WebHeight"] + "|");
                                        //����URL
                                        buts.Append(TextSet1.Tables[0].Rows[i]["ContentURL"] + "?v=" + new Random().Next() + "|;");

                                        ids2 = NewMethod(ids2, TextSet1, i);
                                    }
                                }
                            }
                        }
                    }
                }
                //�жϣ����������ݿ��죬����յ����������
                if (ids2 != "" && DownFlag != "0")
                {
                    ids2 = ids2.Substring(0, ids2.Length - 1);
                    DbHelperSQL1.Query("update CM_Main set TodayCount=0,LastTime='" + DateTime.Now.ToString() + "'  where Id in(" + ids2 + ")");
                }

                if (ids != "" && DownFlag != "0")
                {
                    //�õ����е�ID
                    ids = ids.Substring(0, ids.Length - 1);
                    //�������շ��������ܷ�������1

                    DbHelperSQL1.Query("update CM_Main set TodayCount=TodayCount+1,TotalCount=TotalCount+1,LastTime='" + DateTime.Now.ToString() + "'  where Id in(" + ids + ")");

                }
                else if (ids == "")
                {
                    if (DownFlag == "3")
                    {
                        buts.Remove(0, buts.Length);
                        haha = root.SelectNodes("reg")[3];
                        buts.Append(haha.SelectSingleNode("@Msg_Minute").Value + ";");
                        buts.Append("0;");
                    }
                }

                Response.Write(buts.ToString());
                return;
            }
            else
            {
                if (haha != null)
                {
                    Response.Write(haha.SelectSingleNode("@Msg_Minute").Value + ";0;");
                }
                else
                {
                    Response.Write("900;0;");
                }

                return;
            }

        }

        #endregion

        #region ��Ϣ��0

        /// <summary>
        /// ��Ϣ��0
        /// </summary>
        /// <param name="ids2">idֵ</param>
        /// <param name="TextSet1">���ݼ�</param>
        /// <param name="i">����i����</param>
        /// <returns></returns>
        private static string NewMethod(string ids2, DataSet TextSet1, int i)
        {
            //��Ϣ����������
            //�����жϣ����շ���Ϊ0ʱ��û��Ҫ����
            if (Convert.ToUInt32(TextSet1.Tables[0].Rows[i]["TodayCount"]) > 0)
            {
                //����ݲ�ͬʱ����0
                if (Convert.ToDateTime(TextSet1.Tables[0].Rows[i]["LastTime"]).Year != DateTime.Now.Year)
                {
                    //��0
                    ids2 += TextSet1.Tables[0].Rows[i]["Id"] + ",";
                }
                else
                {
                    //�������ͬʱ���ж��·ݣ��·ݲ�ͬ����0
                    if (Convert.ToDateTime(TextSet1.Tables[0].Rows[i]["LastTime"]).Month != DateTime.Now.Month)
                    {

                        //��0
                        ids2 += TextSet1.Tables[0].Rows[i]["Id"] + ",";
                    }
                    else
                    {
                        //���·���ͬʱ���ж������죬������������ڲ�ͬ����0
                        if (Convert.ToDateTime(TextSet1.Tables[0].Rows[i]["LastTime"]).Day != DateTime.Now.Day)
                        {
                            //��0
                            ids2 += TextSet1.Tables[0].Rows[i]["Id"] + ",";
                        }
                    }
                }
            }
            return ids2;
        }

        #endregion


        #region �汾�Ƚ�

        /// <summary>
        /// �汾�Ƚ�
        /// </summary>
        /// <param name="Versionone">��Ϣ�汾</param>
        /// <returns></returns>
        public int TryVersion(string Versionone, string Versiontwo, int softtype)
        {
            if (Versionone == "" || Versiontwo == "" || softtype == 0)
            {
                return 0;
            }
            //������е��޶�
            string[] Versions = Versionone.Split('|');

            for (int i = 0; i < Versions.Length - 1; i++)
            {
                // ��������޶��汾
                string[] version = Versions[i].Split(',');

                // �û��汾
                string[] userbeginversion = Versiontwo.Split('.');


                //���
                string sortwar = version[0];

                if (sortwar == "0")
                {
                    return 1;//ֱ�ӷ��سɹ���
                }

                // ��ʼ�汾
                string[] beginversion = version[1].Split('.');
                // �����汾
                string[] endversion = version[2].Split('.');

                //�Ƚ��Ƿ��Ǹ��������Ϣ
                if (Convert.ToInt32(sortwar) == softtype)
                {
                    //�Ƚϰ汾
                    //����һ���汾Ϊ0ʱ����ʾ���޶�
                    if (beginversion[0] == "0")
                    {
                        return 1;//ֱ�ӷ��سɹ���
                    }
                    //�Ƚϵ�һ���汾,��Ϊ�����޶������İ汾���ͣ�������������ıȽ�
                    //
                    //�жϺͿ�ʼ�汾�Ĵ�С���������Ա�
                    if (Convert.ToInt32(userbeginversion[0] + userbeginversion[1] + userbeginversion[2]) >= Convert.ToInt32(beginversion[0] + beginversion[1] + beginversion[2]))
                    {
                        //�жϽ����汾
                        if (Convert.ToInt32(userbeginversion[0] + userbeginversion[1] + userbeginversion[2]) <= Convert.ToInt32(endversion[0] + endversion[1] + endversion[2]))
                        {
                            return 1;//ֱ�ӷ��سɹ���
                        }
                    }
                }
            }
            //  �жϰ汾
            return 0;
        }

        #endregion



    }
}
