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
                //LoginID：登录ID号，（CstLogin表中的ID号，登录时获取）。
                //RegType：注册方式，比如0：免费版跟单机版方式一样（详见后面的数据设计）。
                //UserClass：用户类型，比如1、管理员等（详见后面的数据设计，网络登录才有效）。

                //DownFlag：下载标志，0：下载测试消息（由TestMsgID确定）；
                //1：下载所有最新消息（含紧急和普通）；
                //2：下载最新网页消息；                                 
                //3：下载最新资讯；(需要注意的是网页消息和最新资讯只需要提取最近一条)

                //TestMsgID：测试的消息ID号，（当DownFlag=0时有效），以下是特殊值
                //0：最近增加的一个消息（即ID号最大的）；
                //-1：最近增加的网页消息（即网页消息中ID号最大的）；
                //-2：最近增加的非网页消息（即非网页消息中ID号最大的）；

                // TextBind();
                //用户ID
                string LoginID = Pbzx.Common.Input.FilterAll(Request.QueryString["LoginID"]);
                //注册方式
                string RegType = Pbzx.Common.Input.FilterAll(Request.QueryString["RegType"]);
                //用户类型
                string UserClass = Pbzx.Common.Input.FilterAll(Request.QueryString["UserClass"]);
                //下载标志
                string DownFlag = Pbzx.Common.Input.FilterAll(Request.QueryString["DownFlag"]);
                //测试的消息ID号
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
                    //绑定最新测试消息
                    BindTextMssg(LoginID, RegType, UserClass, DownFlag, TestMsgID);
                }
                else if (DownFlag == "1")
                {
                    //下载所有最新消息（含紧急和普通）
                    BindNewsMsg(LoginID, RegType, UserClass, DownFlag, TestMsgID);
                }
                else if (DownFlag == "2")
                {
                    //下载最新网页消息； 
                    BindNewsWeb(LoginID, RegType, UserClass, DownFlag, TestMsgID);
                }
                else if (DownFlag == "3")
                {
                    //下载最新资讯；(需要注意的是网页消息和最新资讯只需要提取最近一条)
                    BindNewsZX(LoginID, RegType, UserClass, DownFlag, TestMsgID);
                }
            }

        }

        #region  下载最新资讯；(需要注意的是网页消息和最新资讯只需要提取最近一条)
        /// <summary>
        /// 下载最新资讯；(需要注意的是网页消息和最新资讯只需要提取最近一条)
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
            //当参数正确传来时
            StringBuilder but = new StringBuilder();

            //查询是否有数据
            StringBuilder txtbut = new StringBuilder();

            string agstring = "";
            string webstring = "";
            string newstring = "";

            //用户名称限定
            string usernamestring = "";
            //认证码限定
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
                    //得到上次用户获取的时间
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
                    //用户版本号
                    VersionName = ds.Tables[0].Rows[0]["Version"].ToString();
                    //软件类型
                    SoftwareType1 = ds.Tables[0].Rows[0]["SoftwareType"].ToString();
                    //
                    InstallType1 = ds.Tables[0].Rows[0]["InstallType"].ToString();
                    //普通消息和紧急消息上次获取时间
                    agstring = ds.Tables[0].Rows[0]["NormalMsgTime"].ToString();

                    //网页消息上次获取时间
                    webstring = ds.Tables[0].Rows[0]["WebMsgTime"].ToString();

                    //最新咨询上次获取时间
                    newstring = ds.Tables[0].Rows[0]["NewsMsgTime"].ToString();

                    //用户名
                    usernamestring = ds.Tables[0].Rows[0]["RN"].ToString();

                    //认证码ID
                    hdnsstring = ds.Tables[0].Rows[0]["HDSN"].ToString();

                    //消息类型
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

                //状态必须是 1的，
                but.Append(" and State=1 ");

                txtbut.Append(" and State=1 ");


                //子查询
                but.Append("and ID in(select CMID from CM_MainBySoftwareType where (SoftInfo = " + ((Convert.ToInt32(SoftwareType1) * 16) + Convert.ToInt32(InstallType1)) + " OR SoftInfo = 0)");
                but.Append("and (" + VersionName.Replace(".", "") + " >= BeginVersion or BeginVersion=0) ");
                but.Append("and (" + VersionName.Replace(".", "") + "<=EndVersion or EndVersion=0))");


                //先根据开始时间来查询
                but.Append(" and BeginTime<='" + DateTime.Now.ToString() + "'");

                txtbut.Append(" and BeginTime<='" + DateTime.Now.ToString() + "'");

                //在根据结束时间来查询
                but.Append(" and EndTime>='" + DateTime.Now.ToString() + "'");

                txtbut.Append(" and EndTime>='" + DateTime.Now.ToString() + "'");


                //根据用户来查询
                if (msgtype == "8")
                {
                    but.Append(usernamestring);
                }
                else
                {
                    but.Append(hdnsstring);
                }

                ////模糊查询，放最后
                //if (RegType != "0")
                //{
                but.Append("and (RegType like '%|" + RegType + "|%' OR RegType = '|0|')");
                //}
                //if (UserClass != "0")
                //{
                but.Append(" and (UserClass like '%|" + UserClass + "|%' OR UserClass = '|0|')");
                //   }
                //最后
                but.Append(" order by PostTime desc");

            }


            DataSet TextSet = null;

            int bs = 0;
            if (DownFlag == "3")
            {

                //判断是不是当天

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
                //当没跨天时，最新资讯不给他数据
                if (bs != 1)
                {
                    TextSet = DbHelperSQL1.Query(but.ToString());
                }
            }


            //当存在消息时
            XmlDocument doc = new XmlDocument();
            //判断是添加什么类型限定
            doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/Msg_Private.xml"));
            //得到根节点
            XmlElement root = doc.DocumentElement;
            XmlNode haha = null;

            haha = root.SelectNodes("reg")[3];

            if ((TextSet != null || DownFlag == "3"))
            {
                StringBuilder buts = new StringBuilder();
                //访问定时

                //访问ID列表
                string ids = "";
                //访问ID列表2，用来开关访问清0
                string ids2 = "";

                if (TextSet != null && TextSet.Tables.Count > 0)
                {
                    if (TextSet.Tables[0].Rows.Count > 0)
                    {
                        //更新时间
                        DbHelperSQL1.ExecuteSql("update CstLogin2010 set NewsMsgTime='" + DateTime.Now.ToString() + "' where ID='" + LoginID + "'");

                        if (haha != null)
                        {
                            buts.Append(haha.SelectSingleNode("@Msg_Minute").Value + ";");
                            buts.Append(TextSet.Tables[0].Rows.Count + ";");
                        }
                    }

                    //消息个数
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
                        //消息ID
                        buts.Append(TextSet.Tables[0].Rows[i]["Id"] + "|");
                        //发布者
                        buts.Append(TextSet.Tables[0].Rows[i]["Sender"] + "|");
                        //发送时间
                        buts.Append(TextSet.Tables[0].Rows[i]["PostTime"] + "|");
                        //类型
                        buts.Append(TextSet.Tables[0].Rows[i]["Type"] + "|");
                        //分类
                        buts.Append(TextSet.Tables[0].Rows[i]["Category"] + "|");
                        //标题
                        buts.Append(TextSet.Tables[0].Rows[i]["Title"] + "|");
                        //宽度
                        buts.Append(TextSet.Tables[0].Rows[i]["WebWidth"] + "|");
                        //高度
                        buts.Append(TextSet.Tables[0].Rows[i]["WebHeight"] + "|");
                        //内容URL
                        buts.Append(TextSet.Tables[0].Rows[i]["ContentURL"] + "?v=" + new Random().Next() + "|;");

                        ids2 = NewMethod(ids2, TextSet, i);
                        //}
                    }
                }

                if (ids == "")
                {
                    //判断是不是当天

                    if ((DateTime.Now.Year != Convert.ToDateTime(ds.Tables[0].Rows[0]["NewsMsgTime"].ToString()).Year) || (DateTime.Now.Month != Convert.ToDateTime(ds.Tables[0].Rows[0]["NewsMsgTime"].ToString()).Month) || (DateTime.Now.Day != Convert.ToDateTime(ds.Tables[0].Rows[0]["NewsMsgTime"].ToString()).Day))
                    {
                        //当查询条件为最新咨询时，特殊处理
                        if (DownFlag == "3")
                        {
                            StringBuilder but1 = new StringBuilder();


                            but1.Append("select Top 1  *from CM_Main where ");

                            //子查询
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
                                //消息个数
                                for (int i = 0; i < TextSet1.Tables[0].Rows.Count; i++)
                                {
                                    if (buts.ToString() == "")
                                    {
                                        haha = root.SelectNodes("reg")[3];
                                        buts.Append(haha.SelectSingleNode("@Msg_Minute").Value + ";");
                                        buts.Append(TextSet1.Tables[0].Rows.Count + ";");
                                    }
                                    ids += TextSet1.Tables[0].Rows[i]["Id"] + ",";
                                    //更新他获取的时间
                                    DbHelperSQL1.Query("update CstLogin2010 set NewsMsgTime='" + DateTime.Now.ToString() + "' where ID='" + LoginID + "'");
                                    //消息ID
                                    buts.Append(TextSet1.Tables[0].Rows[i]["Id"] + "|");
                                    //发布者
                                    buts.Append(TextSet1.Tables[0].Rows[i]["Sender"] + "|");
                                    //发送时间
                                    buts.Append(TextSet1.Tables[0].Rows[i]["PostTime"] + "|");
                                    //类型
                                    buts.Append(TextSet1.Tables[0].Rows[i]["Type"] + "|");
                                    //分类
                                    buts.Append(TextSet1.Tables[0].Rows[i]["Category"] + "|");
                                    //标题
                                    buts.Append(TextSet1.Tables[0].Rows[i]["Title"] + "|");
                                    //宽度
                                    buts.Append(TextSet1.Tables[0].Rows[i]["WebWidth"] + "|");
                                    //高度
                                    buts.Append(TextSet1.Tables[0].Rows[i]["WebHeight"] + "|");
                                    //内容URL
                                    buts.Append(TextSet1.Tables[0].Rows[i]["ContentURL"] + "?v=" + new Random().Next() + "|;");

                                    ids2 = NewMethod(ids2, TextSet1, i);
                                }
                            }
                        }
                    }
                }
                //判断，当此条数据跨天，则清空当天访问人数
                if (ids2 != "" && DownFlag != "0")
                {
                    ids2 = ids2.Substring(0, ids2.Length - 1);
                    DbHelperSQL1.Query("update CM_Main set TodayCount=0,LastTime='" + DateTime.Now.ToString() + "'  where Id in(" + ids2 + ")");
                }

                if (ids != "" && DownFlag != "0")
                {
                    //得到所有的ID
                    ids = ids.Substring(0, ids.Length - 1);
                    //将他的日访问量和总访问量加1

                    if (ConfigurationManager.AppSettings["Msglog"] == "true")
                    {
                        Pbzx.Common.ErrorLog.WriteLogMeng("[最新资讯]" + "LoginID:" + LoginID + "  RegType:" + RegType + "  UserClass:" + UserClass + "具体消息个数：" + TextSet.Tables[0].Rows.Count, "具体SQL语句：" + but.ToString(), true, true);
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

        #region   绑定最新网页消息
        /// <summary>
        /// 绑定最新网页消息
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
            //当参数正确传来时
            StringBuilder but = new StringBuilder();

            //查询是否有数据
            StringBuilder txtbut = new StringBuilder();

            string agstring = "";
            string webstring = "";
            string WebTime = "";
            string newstring = "";

            //用户名称限定
            string usernamestring = "";
            //认证码限定
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
                //得到上次用户获取的时间
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
                //用户版本号
                VersionName = ds.Tables[0].Rows[0]["Version"].ToString();
                //软件类型
                SoftwareType1 = ds.Tables[0].Rows[0]["SoftwareType"].ToString();
                //
                InstallType1 = ds.Tables[0].Rows[0]["InstallType"].ToString();
                //普通消息和紧急消息上次获取时间
                agstring = ds.Tables[0].Rows[0]["NormalMsgTime"].ToString();

                //网页消息上次获取时间
                webstring = ds.Tables[0].Rows[0]["WebMsgTime"].ToString();
                //最新咨询上次获取时间
                newstring = ds.Tables[0].Rows[0]["NewsMsgTime"].ToString();

                //用户名
                usernamestring = ds.Tables[0].Rows[0]["RN"].ToString();

                //认证码ID
                hdnsstring = ds.Tables[0].Rows[0]["HDSN"].ToString();

                //消息类型
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

            //状态必须是 1的，
            but.Append(" and State=1 ");
            txtbut.Append(" and State=1 ");

            //子查询
            but.Append("and ID in(select CMID from CM_MainBySoftwareType where (SoftInfo = " + ((Convert.ToInt32(SoftwareType1) * 16) + Convert.ToInt32(InstallType1)) + " OR SoftInfo = 0)");
            but.Append("and (" + VersionName.Replace(".", "") + " >= BeginVersion or BeginVersion=0) ");
            but.Append("and (" + VersionName.Replace(".", "") + "<=EndVersion or EndVersion=0))");


            //先根据开始时间来查询
            but.Append(" and BeginTime<='" + DateTime.Now.ToString() + "'");

            txtbut.Append(" and BeginTime<='" + DateTime.Now.ToString() + "'");

            //在根据结束时间来查询
            but.Append(" and EndTime>='" + DateTime.Now.ToString() + "'");

            txtbut.Append(" and EndTime>='" + DateTime.Now.ToString() + "'");


            //根据用户来查询
            if (msgtype == "8")
            {
                but.Append(usernamestring);
            }
            else
            {
                but.Append(hdnsstring);
            }




            ////模糊查询，放最后
            //if (RegType != "0")
            //{
            but.Append("and (RegType like '%|" + RegType + "|%' OR RegType = '|0|')");
            //}
            //if (UserClass != "0")
            //{
            but.Append(" and (UserClass like '%|" + UserClass + "|%' OR UserClass = '|0|')");
            //  }
            //最后
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



            //当存在消息时
            XmlDocument doc = new XmlDocument();
            //判断是添加什么类型限定
            doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/Msg_Private.xml"));
            //得到根节点
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
                //访问定时

                //访问ID列表
                string ids = "";
                //访问ID列表2，用来开关访问清0
                string ids2 = "";

                if (TextSet != null && TextSet.Tables.Count > 0)
                {
                    if (TextSet.Tables[0].Rows.Count > 0)
                    {
                        WebTime = TextSet.Tables[0].Rows[0]["PostTime"].ToString();
                        ///用户获取，当条消息发布的时间
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

                    //消息个数
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
                        //消息ID
                        buts.Append(TextSet.Tables[0].Rows[i]["Id"] + "|");
                        //发布者
                        buts.Append(TextSet.Tables[0].Rows[i]["Sender"] + "|");
                        //发送时间
                        buts.Append(TextSet.Tables[0].Rows[i]["PostTime"] + "|");
                        //类型
                        buts.Append(TextSet.Tables[0].Rows[i]["Type"] + "|");
                        //分类
                        buts.Append(TextSet.Tables[0].Rows[i]["Category"] + "|");
                        //标题
                        buts.Append(TextSet.Tables[0].Rows[i]["Title"] + "|");
                        //宽度
                        buts.Append(TextSet.Tables[0].Rows[i]["WebWidth"] + "|");
                        //高度
                        buts.Append(TextSet.Tables[0].Rows[i]["WebHeight"] + "|");
                        //内容URL
                        buts.Append(TextSet.Tables[0].Rows[i]["ContentURL"] + "?v=" + new Random().Next()+ "|;");

                        ids2 = NewMethod(ids2, TextSet, i);
                    }
                   
                }
                //判断，当此条数据跨天，则清空当天访问人数
                if (ids2 != "" && DownFlag != "0")
                {
                    ids2 = ids2.Substring(0, ids2.Length - 1);
                    DbHelperSQL1.Query("update CM_Main set TodayCount=0,LastTime='" + DateTime.Now.ToString() + "'  where Id in(" + ids2 + ")");
                }

                if (ids != "")
                {

                    //得到所有的ID
                    ids = ids.Substring(0, ids.Length - 1);
                    //将他的日访问量和总访问量加1

                    if (ConfigurationManager.AppSettings["Msglog"] == "true")
                    {
                        Pbzx.Common.ErrorLog.WriteLogMeng("[最新网页消息]" + "LoginID:" + LoginID + "  RegType:" + RegType + "  UserClass:" + UserClass + "具体消息个数：" + TextSet.Tables[0].Rows.Count, "具体SQL语句：" + but.ToString(), true, true);
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

        #region 所有最新消息（含紧急和普通）
        /// <summary>
        /// 所有最新消息（含紧急和普通）
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
            //当参数正确传来时
            StringBuilder but = new StringBuilder();

            //查询是否有数据
            StringBuilder txtbut = new StringBuilder();

            string agstring = "";
            string webstring = "";
            string newstring = "";

            //用户名称限定
            string usernamestring = "";
            //认证码限定
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
                    //得到上次用户获取的时间
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
                    //用户版本号
                    VersionName = ds.Tables[0].Rows[0]["Version"].ToString();
                    //软件类型
                    SoftwareType1 = ds.Tables[0].Rows[0]["SoftwareType"].ToString();
                    //
                    InstallType1 = ds.Tables[0].Rows[0]["InstallType"].ToString();
                    //普通消息和紧急消息上次获取时间
                    agstring = ds.Tables[0].Rows[0]["NormalMsgTime"].ToString();

                    //网页消息上次获取时间
                    webstring = ds.Tables[0].Rows[0]["WebMsgTime"].ToString();

                    //最新咨询上次获取时间
                    newstring = ds.Tables[0].Rows[0]["NewsMsgTime"].ToString();

                    //用户名
                    usernamestring = ds.Tables[0].Rows[0]["RN"].ToString();

                    //认证码ID
                    hdnsstring = ds.Tables[0].Rows[0]["HDSN"].ToString();

                    //消息类型
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



                //子查询
                but.Append("and ID in(select CMID from CM_MainBySoftwareType where (SoftInfo = " + ((Convert.ToInt32(SoftwareType1) * 16) + Convert.ToInt32(InstallType1)) + " OR SoftInfo = 0)");
                but.Append("and (" + VersionName.Replace(".", "") + " >= BeginVersion or BeginVersion=0) ");
                but.Append("and (" + VersionName.Replace(".", "") + "<=EndVersion or EndVersion=0))");



                //下载所有最新消息（含紧急和普通）

                but.Append("and Type in(1,2)");
                but.Append(agstring);

                txtbut.Append("and Type in(1,2)");
                txtbut.Append(agstring);


                //状态必须是 1的，
                but.Append(" and State=1 ");

                txtbut.Append(" and State=1 ");


                //先根据开始时间来查询
                but.Append(" and BeginTime<='" + DateTime.Now.ToString() + "'");

                txtbut.Append(" and BeginTime<='" + DateTime.Now.ToString() + "'");

                //在根据结束时间来查询
                but.Append(" and EndTime>='" + DateTime.Now.ToString() + "'");

                txtbut.Append(" and EndTime>='" + DateTime.Now.ToString() + "'");


                //根据用户来查询
                if (msgtype == "8")
                {
                    but.Append(usernamestring);
                }
                else
                {
                    but.Append(hdnsstring);
                }

                ////模糊查询，放最后
                //if (RegType != "0")
                //{
                but.Append("and (RegType like '%|" + RegType + "|%' OR RegType = '|0|')");
                //}
                //if (UserClass != "0")
                //{
                but.Append(" and (UserClass like '%|" + UserClass + "|%' OR UserClass = '|0|')");
                // }
                //最后
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

            //当存在消息时
            XmlDocument doc = new XmlDocument();
            //判断是添加什么类型限定
            doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/Msg_Private.xml"));
            //得到根节点
            XmlElement root = doc.DocumentElement;
            XmlNode haha = null;

            haha = root.SelectNodes("reg")[0];

            if (TextSet != null)
            {
                StringBuilder buts = new StringBuilder();
                //访问定时

                //访问ID列表
                string ids = "";
                //访问ID列表2，用来开关访问清0
                string ids2 = "";

                if (TextSet != null && TextSet.Tables.Count > 0)
                {
                    if (TextSet.Tables[0].Rows.Count > 0)
                    {
                        //更新用户的获取时间

                        DbHelperSQL1.ExecuteSql("update CstLogin2010 set NormalMsgTime='" + DateTime.Now.ToString() + "' where ID='" + LoginID + "'");


                        if (haha != null)
                        {
                            buts.Append(haha.SelectSingleNode("@Msg_Minute").Value + ";");
                            buts.Append(TextSet.Tables[0].Rows.Count + ";");
                        }
                    }

                    //消息个数
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
                        //消息ID
                        buts.Append(TextSet.Tables[0].Rows[i]["Id"] + "|");
                        //发布者
                        buts.Append(TextSet.Tables[0].Rows[i]["Sender"] + "|");
                        //发送时间
                        buts.Append(TextSet.Tables[0].Rows[i]["PostTime"] + "|");
                        //类型
                        buts.Append(TextSet.Tables[0].Rows[i]["Type"] + "|");
                        //分类
                        buts.Append(TextSet.Tables[0].Rows[i]["Category"] + "|");
                        //标题
                        buts.Append(TextSet.Tables[0].Rows[i]["Title"] + "|");
                        //宽度
                        buts.Append(TextSet.Tables[0].Rows[i]["WebWidth"] + "|");
                        //高度
                        buts.Append(TextSet.Tables[0].Rows[i]["WebHeight"] + "|");
                        //内容URL
                        buts.Append(TextSet.Tables[0].Rows[i]["ContentURL"] + "?v=" + new Random().Next() + "|;");

                        ids2 = NewMethod(ids2, TextSet, i);
                    }


                }

                //判断，当此条数据跨天，则清空当天访问人数
                if (ids2 != "" && DownFlag != "0")
                {
                    ids2 = ids2.Substring(0, ids2.Length - 1);
                    DbHelperSQL1.Query("update CM_Main set TodayCount=0,LastTime='" + DateTime.Now.ToString() + "'  where Id in(" + ids2 + ")");
                }

                if (ids != "" && DownFlag != "0")
                {
                    //得到所有的ID
                    ids = ids.Substring(0, ids.Length - 1);
                    //将他的日访问量和总访问量加1


                    if (ConfigurationManager.AppSettings["Msglog"] == "true")
                    {
                        Pbzx.Common.ErrorLog.WriteLogMeng("[紧急和普通]" + "LoginID:" + LoginID + "  RegType:" + RegType + "  UserClass:" + UserClass + "具体消息个数：" + TextSet.Tables[0].Rows.Count, "具体SQL语句：" + but.ToString(), true, true);
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

        #region  测试消息
        /// <summary>
        /// 得到测试消息
        /// </summary>
        private void BindTextMssg(string LoginID, string RegType, string UserClass, string DownFlag, string TestMsgID)
        {
            string VersionName = "";
            string SoftwareType1 = "";
            string InstallType1 = "";
            //当参数正确传来时
            StringBuilder but = new StringBuilder();

            //查询是否有数据
            StringBuilder txtbut = new StringBuilder();

            string agstring = "";
            string webstring = "";
            string newstring = "";

            //用户名称限定
            string usernamestring = "";
            //认证码限定
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

            //当存在消息时

            XmlNode nodetime = BindXMLTime(DownFlag);


            if (TextSet != null)
            {
                StringBuilder buts = new StringBuilder();
                //访问定时

                //访问ID列表
                string ids = "";
                //访问ID列表2，用来开关访问清0
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

                    //消息个数
                    for (int i = 0; i < TextSet.Tables[0].Rows.Count; i++)
                    {
                        //获取消息版本
                        string vis = TextSet.Tables[0].Rows[i]["SoftInfo"].ToString();
                        //判断版本
                        int bo = 0;
                        if (VersionName != "" || SoftwareType1 != "" || InstallType1 != "")
                        {
                            bo = TryVersion(vis, VersionName, ((Convert.ToInt32(SoftwareType1) * 16) + Convert.ToInt32(InstallType1)));
                        }
                        if (bo == 1 || DownFlag == "0")
                        {
                            ids += TextSet.Tables[0].Rows[i]["Id"] + ",";
                            //消息ID
                            buts.Append(TextSet.Tables[0].Rows[i]["Id"] + "|");
                            //发布者
                            buts.Append(TextSet.Tables[0].Rows[i]["Sender"] + "|");
                            //发送时间
                            buts.Append(TextSet.Tables[0].Rows[i]["PostTime"] + "|");
                            //类型
                            buts.Append(TextSet.Tables[0].Rows[i]["Type"] + "|");
                            //分类
                            buts.Append(TextSet.Tables[0].Rows[i]["Category"] + "|");
                            //标题
                            buts.Append(TextSet.Tables[0].Rows[i]["Title"] + "|");
                            //宽度
                            buts.Append(TextSet.Tables[0].Rows[i]["WebWidth"] + "|");
                            //高度
                            buts.Append(TextSet.Tables[0].Rows[i]["WebHeight"] + "|");
                            //内容URL
                            buts.Append(TextSet.Tables[0].Rows[i]["ContentURL"] + "?v=" + new Random().Next() + "|;");

                            ids2 = NewMethod(ids2, TextSet, i);
                        }
                    }
                }

                //判断，当此条数据跨天，则清空当天访问人数
                if (ids2 != "" && DownFlag != "0")
                {
                    ids2 = ids2.Substring(0, ids2.Length - 1);
                    DbHelperSQL1.Query("update CM_Main set TodayCount=0,LastTime='" + DateTime.Now.ToString() + "'  where Id in(" + ids2 + ")");
                }

                if (ids != "" && DownFlag != "0")
                {
                    //得到所有的ID
                    ids = ids.Substring(0, ids.Length - 1);

                    //将他的日访问量和总访问量加1
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


        #region 得到轮循时间
        /// <summary>
        /// 得到轮循时间
        /// </summary>
        /// <returns></returns>
        private XmlNode BindXMLTime(string DownFlag)
        {
            XmlDocument doc = new XmlDocument();
            //判断是添加什么类型限定
            doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/Msg_Private.xml"));
            //得到根节点
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

        #region 原
        /// <summary>
        /// 数据绑定
        /// // 返回信息：
        /// 消息信息格式：访问时间隔;消息个数;消息ID|发布者|发送时间|类型|分类|标题|宽度|高度|内容URL （以“|”分隔）
        /// </summary>
        private void TextBind()
        {
            //用户ID
            string LoginID = Pbzx.Common.Input.FilterAll(Request.QueryString["LoginID"]);
            //注册方式
            string RegType = Pbzx.Common.Input.FilterAll(Request.QueryString["RegType"]);
            //用户类型
            string UserClass = Pbzx.Common.Input.FilterAll(Request.QueryString["UserClass"]);
            //下载标志
            string DownFlag = Pbzx.Common.Input.FilterAll(Request.QueryString["DownFlag"]);
            //测试的消息ID号
            string TestMsgID = Pbzx.Common.Input.FilterAll(Request.QueryString["TestMsgID"]);

            //////////////////////////////////////////////////////////////////////
            //if (DownFlag == "3")
            //{
            //    Pbzx.Common.ErrorLog.WriteLogMeng("测试最新资讯：用户ID：" + LoginID + " 注册方式：" + RegType + " 用户类型：" + UserClass, "初始消息内容：", true, true);
            //}
            //////////////////////////////////////////////////////////////////////

            string VersionName = "";
            string SoftwareType1 = "";
            string InstallType1 = "";
            //当参数正确传来时
            StringBuilder but = new StringBuilder();

            //查询是否有数据
            StringBuilder txtbut = new StringBuilder();

            string agstring = "";
            string webstring = "";
            string newstring = "";

            //用户名称限定
            string usernamestring = "";
            //认证码限定
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
                    //得到上次用户获取的时间
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
                    //用户版本号
                    VersionName = ds.Tables[0].Rows[0]["Version"].ToString();
                    //软件类型
                    SoftwareType1 = ds.Tables[0].Rows[0]["SoftwareType"].ToString();
                    //
                    InstallType1 = ds.Tables[0].Rows[0]["InstallType"].ToString();
                    //普通消息和紧急消息上次获取时间
                    agstring = ds.Tables[0].Rows[0]["NormalMsgTime"].ToString();

                    //网页消息上次获取时间
                    webstring = ds.Tables[0].Rows[0]["WebMsgTime"].ToString();

                    //最新咨询上次获取时间
                    newstring = ds.Tables[0].Rows[0]["NewsMsgTime"].ToString();

                    //用户名
                    usernamestring = ds.Tables[0].Rows[0]["RN"].ToString();

                    //认证码ID
                    hdnsstring = ds.Tables[0].Rows[0]["HDSN"].ToString();

                    //消息类型
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

                //下载所有最新消息（含紧急和普通）
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

                //状态必须是 1的，
                but.Append(" and State=1 ");

                txtbut.Append(" and State=1 ");


                //先根据开始时间来查询
                but.Append(" and BeginTime<='" + DateTime.Now.ToString() + "'");

                txtbut.Append(" and BeginTime<='" + DateTime.Now.ToString() + "'");

                //在根据结束时间来查询
                but.Append(" and EndTime>='" + DateTime.Now.ToString() + "'");

                txtbut.Append(" and EndTime>='" + DateTime.Now.ToString() + "'");


                //根据用户来查询
                if (msgtype == "8")
                {
                    but.Append(usernamestring);
                }
                else
                {
                    but.Append(hdnsstring);
                }

                //模糊查询，放最后
                if (RegType != "0")
                {
                    but.Append("and (RegType like '%" + RegType + "%' OR RegType = '0|')");
                }
                if (UserClass != "0")
                {
                    but.Append(" and (UserClass like '%" + UserClass + "%' OR UserClass = '0|')");
                }
                //最后
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

                //判断是不是当天

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

                    //Pbzx.Common.ErrorLog.WriteLogMeng("测试消息个数：" + counttext.Tables[0].Rows[0]["Tcount"].ToString(), "测试SQL语句：" + txtbut.ToString(), true, true);

                    if (Convert.ToInt32(counttext.Tables[0].Rows[0]["Tcount"]) > 0)
                    {
                        TextSet = DbHelperSQL1.Query(but.ToString());
                        //Pbzx.Common.ErrorLog.WriteLogMeng("具体消息个数：" + TextSet.Tables[0].Rows.Count, "具体SQL语句：" + but.ToString(), true, true);
                    }
                }
            }
            else
            {
                //当没跨天时，最新资讯不给他数据
                if (bs != 1)
                {
                    TextSet = DbHelperSQL1.Query(but.ToString());
                }
            }


            //当存在消息时
            XmlDocument doc = new XmlDocument();
            //判断是添加什么类型限定
            doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/Msg_Private.xml"));
            //得到根节点
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
                //访问定时

                //访问ID列表
                string ids = "";
                //访问ID列表2，用来开关访问清0
                string ids2 = "";

                if (TextSet != null)
                {
                    if (TextSet.Tables[0].Rows.Count > 0)
                    {
                        //////////////////////////////////////////////////////////////////////
                        //if (DownFlag == "3")
                        //{
                        //    Pbzx.Common.ErrorLog.WriteLogMeng(">>>>>>>>>>数据继续执行 SQL语句：" + but.ToString(), "确定执行到更新这一步", true, true);
                        //}
                        //////////////////////////////////////////////////////////////////////
                        //更新用户的获取时间
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
                        //    Pbzx.Common.ErrorLog.WriteLogMeng(">>>>>>>>>>数据时间更新完成", "确定执行到更新这一步", true, true);
                        //}
                        //////////////////////////////////////////////////////////////////////

                        if (haha != null)
                        {
                            buts.Append(haha.SelectSingleNode("@Msg_Minute").Value + ";");
                            buts.Append(TextSet.Tables[0].Rows.Count + ";");
                        }
                    }

                    //消息个数
                    for (int i = 0; i < TextSet.Tables[0].Rows.Count; i++)
                    {
                        //获取消息版本
                        string vis = TextSet.Tables[0].Rows[i]["SoftInfo"].ToString();
                        //判断版本
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
                            //消息ID
                            buts.Append(TextSet.Tables[0].Rows[i]["Id"] + "|");
                            //发布者
                            buts.Append(TextSet.Tables[0].Rows[i]["Sender"] + "|");
                            //发送时间
                            buts.Append(TextSet.Tables[0].Rows[i]["PostTime"] + "|");
                            //类型
                            buts.Append(TextSet.Tables[0].Rows[i]["Type"] + "|");
                            //分类
                            buts.Append(TextSet.Tables[0].Rows[i]["Category"] + "|");
                            //标题
                            buts.Append(TextSet.Tables[0].Rows[i]["Title"] + "|");
                            //宽度
                            buts.Append(TextSet.Tables[0].Rows[i]["WebWidth"] + "|");
                            //高度
                            buts.Append(TextSet.Tables[0].Rows[i]["WebHeight"] + "|");
                            //内容URL
                            buts.Append(TextSet.Tables[0].Rows[i]["ContentURL"] + "?v=" + new Random().Next() + "|;");

                            ids2 = NewMethod(ids2, TextSet, i);
                        }
                    }
                    //////////////////////////////////////////////////////////////////////
                    //if (DownFlag == "3")
                    //{
                    //    Pbzx.Common.ErrorLog.WriteLogMeng(">>>>>>>>>>消息遍历完成", "遍历个数：" + TextSet.Tables[0].Rows.Count, true, true);
                    //}
                    //////////////////////////////////////////////////////////////////////
                }

                if (ids == "")
                {
                    //判断是不是当天

                    if (DateTime.Now.Day != Convert.ToDateTime(ds.Tables[0].Rows[0]["NewsMsgTime"].ToString()).Day)
                    {
                        //当查询条件为最新咨询时，特殊处理
                        if (DownFlag == "3")
                        {

                            DataSet TextSet1 = DbHelperSQL1.Query(" select Top 1  *from CM_Main where (RegType like '%" + RegType + "%' OR RegType = '0|') and (UserClass like '%" + UserClass + "%' OR UserClass = '0|') and BeginTime<='" + DateTime.Now.ToString() + "' and EndTime>='" + DateTime.Now.ToString() + "'and Type=4 and State=1 order by PostTime desc");

                            //////////////////////////////////////////////////////////////////////
                            //if (DownFlag == "3")
                            //{
                            //    Pbzx.Common.ErrorLog.WriteLogMeng("没有最新资讯时 SQL语句：" + but.ToString(), "确定执行到更新这一步", true, true);
                            //}
                            //////////////////////////////////////////////////////////////////////

                            if (TextSet1 != null)
                            {
                                //消息个数
                                for (int i = 0; i < TextSet1.Tables[0].Rows.Count; i++)
                                {
                                    //获取消息版本
                                    string vis = TextSet1.Tables[0].Rows[i]["SoftInfo"].ToString();
                                    //判断版本
                                    if (TryVersion(vis, VersionName, ((Convert.ToInt32(SoftwareType1) * 16) + Convert.ToInt32(InstallType1))) == 1)
                                    {
                                        if (buts.ToString() == "")
                                        {
                                            haha = root.SelectNodes("reg")[3];
                                            buts.Append(haha.SelectSingleNode("@Msg_Minute").Value + ";");
                                            buts.Append(TextSet1.Tables[0].Rows.Count + ";");
                                        }
                                        ids += TextSet1.Tables[0].Rows[i]["Id"] + ",";
                                        //更新他获取的时间
                                        DbHelperSQL1.Query("update CstLogin2010 set NewsMsgTime='" + DateTime.Now.ToString() + "' where ID='" + LoginID + "'");
                                        //消息ID
                                        buts.Append(TextSet1.Tables[0].Rows[i]["Id"] + "|");
                                        //发布者
                                        buts.Append(TextSet1.Tables[0].Rows[i]["Sender"] + "|");
                                        //发送时间
                                        buts.Append(TextSet1.Tables[0].Rows[i]["PostTime"] + "|");
                                        //类型
                                        buts.Append(TextSet1.Tables[0].Rows[i]["Type"] + "|");
                                        //分类
                                        buts.Append(TextSet1.Tables[0].Rows[i]["Category"] + "|");
                                        //标题
                                        buts.Append(TextSet1.Tables[0].Rows[i]["Title"] + "|");
                                        //宽度
                                        buts.Append(TextSet1.Tables[0].Rows[i]["WebWidth"] + "|");
                                        //高度
                                        buts.Append(TextSet1.Tables[0].Rows[i]["WebHeight"] + "|");
                                        //内容URL
                                        buts.Append(TextSet1.Tables[0].Rows[i]["ContentURL"] + "?v=" + new Random().Next() + "|;");

                                        ids2 = NewMethod(ids2, TextSet1, i);
                                    }
                                }
                            }
                        }
                    }
                }
                //判断，当此条数据跨天，则清空当天访问人数
                if (ids2 != "" && DownFlag != "0")
                {
                    ids2 = ids2.Substring(0, ids2.Length - 1);
                    DbHelperSQL1.Query("update CM_Main set TodayCount=0,LastTime='" + DateTime.Now.ToString() + "'  where Id in(" + ids2 + ")");
                }

                if (ids != "" && DownFlag != "0")
                {
                    //得到所有的ID
                    ids = ids.Substring(0, ids.Length - 1);
                    //将他的日访问量和总访问量加1

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

        #region 消息清0

        /// <summary>
        /// 消息清0
        /// </summary>
        /// <param name="ids2">id值</param>
        /// <param name="TextSet1">数据集</param>
        /// <param name="i">遍历i变量</param>
        /// <returns></returns>
        private static string NewMethod(string ids2, DataSet TextSet1, int i)
        {
            //消息访问量开关
            //首先判断，当日访问为0时，没必要更新
            if (Convert.ToUInt32(TextSet1.Tables[0].Rows[i]["TodayCount"]) > 0)
            {
                //当年份不同时，清0
                if (Convert.ToDateTime(TextSet1.Tables[0].Rows[i]["LastTime"]).Year != DateTime.Now.Year)
                {
                    //清0
                    ids2 += TextSet1.Tables[0].Rows[i]["Id"] + ",";
                }
                else
                {
                    //当年份相同时！判断月份，月份不同，清0
                    if (Convert.ToDateTime(TextSet1.Tables[0].Rows[i]["LastTime"]).Month != DateTime.Now.Month)
                    {

                        //清0
                        ids2 += TextSet1.Tables[0].Rows[i]["Id"] + ",";
                    }
                    else
                    {
                        //当月份相同时，判断他的天，如和最后访问日期不同，清0
                        if (Convert.ToDateTime(TextSet1.Tables[0].Rows[i]["LastTime"]).Day != DateTime.Now.Day)
                        {
                            //清0
                            ids2 += TextSet1.Tables[0].Rows[i]["Id"] + ",";
                        }
                    }
                }
            }
            return ids2;
        }

        #endregion


        #region 版本比较

        /// <summary>
        /// 版本比较
        /// </summary>
        /// <param name="Versionone">消息版本</param>
        /// <returns></returns>
        public int TryVersion(string Versionone, string Versiontwo, int softtype)
        {
            if (Versionone == "" || Versiontwo == "" || softtype == 0)
            {
                return 0;
            }
            //软件所有的限定
            string[] Versions = Versionone.Split('|');

            for (int i = 0; i < Versions.Length - 1; i++)
            {
                // 单个软件限定版本
                string[] version = Versions[i].Split(',');

                // 用户版本
                string[] userbeginversion = Versiontwo.Split('.');


                //软件
                string sortwar = version[0];

                if (sortwar == "0")
                {
                    return 1;//直接返回成功！
                }

                // 开始版本
                string[] beginversion = version[1].Split('.');
                // 结束版本
                string[] endversion = version[2].Split('.');

                //比较是否是该软件的消息
                if (Convert.ToInt32(sortwar) == softtype)
                {
                    //比较版本
                    //当第一个版本为0时，表示不限定
                    if (beginversion[0] == "0")
                    {
                        return 1;//直接返回成功！
                    }
                    //比较第一个版本,因为这里限定了他的版本类型，可以这样更快的比较
                    //
                    //判断和开始版本的大小和他的数对比
                    if (Convert.ToInt32(userbeginversion[0] + userbeginversion[1] + userbeginversion[2]) >= Convert.ToInt32(beginversion[0] + beginversion[1] + beginversion[2]))
                    {
                        //判断结束版本
                        if (Convert.ToInt32(userbeginversion[0] + userbeginversion[1] + userbeginversion[2]) <= Convert.ToInt32(endversion[0] + endversion[1] + endversion[2]))
                        {
                            return 1;//直接返回成功！
                        }
                    }
                }
            }
            //  判断版本
            return 0;
        }

        #endregion



    }
}
