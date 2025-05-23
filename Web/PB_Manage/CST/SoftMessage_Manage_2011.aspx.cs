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
using System.Xml;
using System.Text;
using Pbzx.BLL;
using Maticsoft.DBUtility;
using System.IO;

namespace Pbzx.Web.PB_Manage
{
    public partial class SoftMessage_Manage_2011 : AdminBasic
    {
        //�½�һ��BLL����
        BLL.CM_MainManager ll = new BLL.CM_MainManager();
        public static BLL.CstSoftware softwmanager = new BLL.CstSoftware();

        public static CM_MainBySoftwareTypeManager cmmanager = new CM_MainBySoftwareTypeManager();

        /// <summary>
        /// ҳ������¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

            //�ж��ǲ��ǵ�һ�μ���
            if (!IsPostBack)
            {
                //�õ����������б�
                DataSet ds = ll.GetAllList();
                //�õ�������������
                int number = ds.Tables[0].Columns.Count;
                //�������ļ��ж�ȡÿҳ��ʾ����
                MyGridView.PageSize = WebInit.webBaseConfig.WebPageNum;
                //���������Ը���ֵ
                //Ĭ�� PostTime 
                if (ViewState["order"] == null)
                {
                    ViewState["order"] = "EndTime";
                }
                if (ViewState["isDesc"] == null)
                {
                    ViewState["isDesc"] = true;
                }



                //���շ�����0�����������������ڲ��ǽ��죡�����Ľ��շ�����0��

                //�õ����е������Ϣ
                if (ds.Tables[0].Rows.Count > 0)
                {

                    string ids = "";

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        //�����жϣ����շ���Ϊ0ʱ��û��Ҫ����
                        if (Convert.ToInt32(ds.Tables[0].Rows[i]["TodayCount"].ToString()) > 0)
                        {
                            //����ݲ�ͬʱ����0
                            if (DateTime.Parse(ds.Tables[0].Rows[i]["LastTime"].ToString()).Year != DateTime.Now.Year)
                            {
                                //����Ҫ��0��ID
                                ids += ds.Tables[0].Rows[i]["ID"].ToString() + ",";
                            }
                            else
                            {
                                //�������ͬʱ���ж��·ݣ��·ݲ�ͬ����0
                                if (DateTime.Parse(ds.Tables[0].Rows[i]["LastTime"].ToString()).Month != DateTime.Now.Month)
                                {

                                    //����Ҫ��0��ID
                                    ids += ds.Tables[0].Rows[i]["ID"].ToString() + ",";
                                }
                                else
                                {
                                    //���·���ͬʱ���ж������죬������������ڲ�ͬ����0
                                    if (DateTime.Parse(ds.Tables[0].Rows[i]["LastTime"].ToString()).Day != DateTime.Now.Day)
                                    {
                                        //����Ҫ��0��ID
                                        ids += ds.Tables[0].Rows[i]["ID"].ToString() + ",";
                                    }

                                }

                            }
                        }
                    }
                    //��ids��Ϊ��ʱ���������ָ��ID�ĵ��շ���
                    if (ids != "")
                    {
                        ids = ids.Substring(0, ids.Length - 1);
                        //��0
                        DbHelperSQL1.ExecuteSql("UPDATE CM_Main SET TodayCount=0 where id in(" + ids + ")");
                    }
                }
                //------------------------------------------------------------------------------------------

                BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
            }
        }

        /// <summary>
        /// �󶨷�ҳ�ؼ�
        /// </summary>
        /// <param name="tempCount"></param>
        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = WebInit.webBaseConfig.WebPageNum;
            AspNetPager1.RecordCount = tempCount;
            AddCustomText();
        }
        /// <summary>
        /// ��ҳ�ؼ���������ʾ
        /// </summary>
        protected void AddCustomText()
        {
            AspNetPager1.CustomInfoHTML = "��<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>��&nbsp;";
            AspNetPager1.CustomInfoHTML += "��ҳ<font color=\"red\"><b>" + MyGridView.Rows.Count + "</b></font>��&nbsp;";
            AspNetPager1.CustomInfoHTML += "��ҳ:<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "ҳ</font>";
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }


        /// <summary>
        /// ����url��ֵ��ѯ
        /// </summary>
        /// <returns></returns>
        private string AddParameter()
        {
            StringBuilder bu = new StringBuilder();

            //�����ⲻΪ��ʱ
            if (!string.IsNullOrEmpty(Request["strTitleSerch"]))
            {
                bu.Append(" and Title like '%" + Request["strTitleSerch"] + "%' ");
            }
            //�������ѯ������������ʱ
            if (!string.IsNullOrEmpty(Request["DropList1"]))
            {
                if (Request["DropList1"] != "0")
                {
                    //����ѯ����汾��Ϊ����ʱ
                    if (Request["DropList1"] != "0")
                    {
                        //�õ�����16���Ƶ�ID
                        //int id16 = ((Convert.ToInt32(Request["DropList1"]) * 16) + Convert.ToInt32(Request["DropList2"]));
                        //bu.Append(" and SoftInfo like '%" + id16 + ",%'");

                        //if (Request["DropList2"] != "0")
                        //{
                        //    bu.Append(" and SoftInfo like '%" + Request["DropList1"] + "," + Request["DropList2"] + "|%'");
                        //}
                        //else
                        //{
                        //    bu.Append(" and SoftInfo like '%" + Request["DropList1"] + ",%'");
                        //}

                        if (Request["DropList2"] != "0")
                        {
                            bu.Append(" and  Id in( select CMID from CM_MainBySoftwareType where (SoftwareName = '" + Request["DropList1"] + "') AND (InstallName = '" + Request["DropList2"] + "'))");
                        }
                        else
                        {
                            bu.Append(" and  Id in( select CMID from CM_MainBySoftwareType where (SoftwareName = '" + Request["DropList1"] + "'))");
                        }


                    }
                }
            }
            //��ע���޶���������ʱ
            if (!string.IsNullOrEmpty(Request["DropList3"]))
            {
                if (Request["DropList3"] != "00")
                {
                    bu.Append(" and RegType like '%" + Request["DropList3"] + "|%'");

                }
            }
            //���û��޶���������ʱ
            if (!string.IsNullOrEmpty(Request["DropList4"]))
            {
                if (Request["DropList4"] != "00")
                {
                    bu.Append(" and UserClass  like '%" + Request["DropList4"] + "|%'");
                }
                else if (Request["DropList4"] == "0")
                {
                    bu.Append(" and UserClass = '" + Request["DropList4"] + "|'");
                }
            }
            if (!string.IsNullOrEmpty(Request["dateType"]))
            {
                if (!string.IsNullOrEmpty(Request["strCreateTime1"]) && !string.IsNullOrEmpty(Request["strCreateTime2"]))
                {
                    if (Request["dateType"] == "1")
                    {
                        bu.Append(" and PostTime between '" + Request["strCreateTime1"] + "' and '" + Request["strCreateTime2"] + " 23:59:59'  ");
                    }
                    else if (Request["dateType"] == "2")
                    {
                        bu.Append(" and BeginTime between '" + Request["strCreateTime1"] + "' and '" + Request["strCreateTime2"] + " 23:59:59'  ");
                    }
                    else if (Request["dateType"] == "3")
                    {
                        bu.Append(" and EndTime between '" + Request["strCreateTime1"] + "' and '" + Request["strCreateTime2"] + " 23:59:59'  ");
                    }
                }
            }
            return bu.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnDel_Command(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            Pbzx.BLL.CM_MainManager cmmain = new Pbzx.BLL.CM_MainManager();
            Pbzx.Model.CM_Main msgModel = cmmain.GetMain(id);
            string nvarname = msgModel.Title.ToString();
            //�ж϶�Ӧ����HTMLҳ���Ƿ���ڣ�����ڣ�����ɾ��
            try
            {
                //����վ�Ķ�ʱ������Ҳ��Ķ�����Ȼ�޷�ʹ��ɾ��
                if (DirectoryFile.IsCreateFile(Server.MapPath("~" + msgModel.ContentURL.Substring(22))))
                {
                    DirectoryFile.FileDel(Server.MapPath("~" + msgModel.ContentURL.Substring(22)));
                }
            }
            catch
            {

            }


            if (cmmain.Delete(id))
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("ɾ��", "ɾ�������Ϣ[" + nvarname + "]");
                JS.Alert("ɾ���ɹ���");
            }
            else
            {
                JS.Alert("ɾ��ʧ�ܣ�");
            }

            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="st"></param>
        /// <param name="it"></param>
        /// <returns></returns>
        protected string ChkSoftType(object st, object it)
        {
            Pbzx.BLL.CstSoftware softBLL = new Pbzx.BLL.CstSoftware();
            string[] result = softBLL.Chksettype(st, it);
            return result[0] + "(" + result[1] + ")";
        }



        /// <summary>
        /// ���ݰ󶨷���
        /// </summary>
        /// <param name="column"></param>
        /// <param name="isDesc"></param>
        private void BindData(string column, bool isDesc)
        {
            //�½�һ��BLL����
            BLL.CM_MainManager ll = new BLL.CM_MainManager();
            //����һ����������
            StringBuilder bu = new StringBuilder();
            bu.Append(" 1=1 "); //����
            //URL������ֵ

            //�ж������xx��ֻ��Ҫ���������ѯ����
            if (Request["xx"] != null)
            {
                bu.Append(" and [Type]=" + Request["xx"]);
            }
            else
            {
                bu.Append(this.AddParameter());
            }
            string Searchstr = bu.ToString();
            //��������
            string order = column;
            int myCount = 0;
            //�ж����������л��ǽ���
            if (isDesc)
            {
                order += " desc ";
            }
            else
            {
                order += " asc ";
            }
            //����BLL�����õ� ���ݱ�
            DataTable lsResult = ll.GuestGetBySearch(Searchstr, "ID,SoftInfo,RegType,UserClass,Sender,Type,Category,State,PostTime,BeginTime,EndTime,Title,ContentURL,LastTime,TodayCount,TotalCount,Content", order, WebInit.webBaseConfig.WebPageNum, 3, AspNetPager1.CurrentPageIndex, out myCount);
            //�󶨵�GriView��
            this.MyGridView.DataSource = lsResult;
            this.MyGridView.DataBind();

            AspNetPagerConfig(myCount);
            if (lsResult == null)
            {
                this.litContent.Text = "<b>��Ǹ��<p/><br/>Ӧ��û���ҵ������������ݼ�¼</b>";
            }
            else
            {
                this.litContent.Text = "";
            }


        }


        protected void lbtnAduting_Command(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            Pbzx.BLL.CstMessage cstMSGBLL = new Pbzx.BLL.CstMessage();
            cstMSGBLL.ChangeAudit(id, "MsgSend");
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }
        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("SoftMessage_Editor_2011.aspx");
        }
        /// <summary>
        /// �а��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                string href = "<a href='SoftMessage_Editor_2011.aspx?ID=" + e.Row.Cells[0].Text + "'>";
                e.Row.Cells[0].Text = href + "(" + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString() + ")</a>";
            }
        }

        //״̬��ʽ��
        public static string StatusGSF(object obj)
        {
            if (Convert.ToInt32(obj) == 0)
            {
                return "δ����";
            }
            else
            {
                return "<font color='green'>�ѷ���</font>";
            }

        }
        //��Ϣ��ʽ��
        public static string MsgGSH(object obj)
        {
            string s = "";
            string zong = "";
            XmlDocument dom = new XmlDocument();
            dom.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/Msg_Private.xml"));//װ��XML�ĵ� 
            XmlElement root = dom.DocumentElement;
            for (int i = 0; i < root.ChildNodes.Count; i++)
            {

                XmlNode haha = root.SelectNodes("reg")[i];
                //�õ�����ID
                string ss = haha.SelectSingleNode("@number").Value;

                if (ss == obj.ToString())
                {
                    zong = haha.SelectSingleNode("@name").Value;
                }
            }
            switch (Convert.ToInt32(obj))
            {
                case 1:
                    s = "<a style='color:#000000' href='SoftMessage_Manage_2011.aspx?xx=1'>" + zong + "</a>";
                    break;
                case 2:
                    s = "<a style='color:#FF0000' href='SoftMessage_Manage_2011.aspx?xx=2'>" + zong + "</a>";
                    break;
                case 3:
                    s = "<a style='color:#0000FF' href='SoftMessage_Manage_2011.aspx?xx=3'>" + zong + "</a>";
                    break;
                case 4:
                    s = "<a style='color:#008000' href='SoftMessage_Manage_2011.aspx?xx=4'>" + zong + "</a>";
                    break;
            }
            return s;
        }
        //���շ��ʸ�ʽ��
        public static string JrfwGSH(object obj)
        {
            if (Convert.ToInt32(obj) > 0)
            {
                return "<font color='#000000'>" + obj + "</font>";
            }
            else
            {
                return "<font color='#808080'>" + obj + "</font>";
            }

        }
        /// <summary>
        /// ���
        /// </summary>
        /// <returns></returns>
        public static string LeibieGSH(object obj)
        {
            if (obj.ToString() == "")
            {
                return "URL";
            }
            else
            {

                return "HTML";
            }

        }
        /// <summary>
        /// ����޶�
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string RJGSH(object obj)
        {

            if (obj.ToString() == "0,0,0|")
            {
                return "<font color='#0000FF' title='û���κ�����޶�'>����</font>";
            }
            else
            {
                //�õ����е������
                string[] rj = obj.ToString().Split('|');
                //���м���
                string buts = "";
                for (int i = 0; i < rj.Length - 1; i++)
                {
                    string rjstring = "";
                    //������Ϣ�ٷָ������
                    string[] rjmx = rj[i].Split(',');

                    //�õ�16���Ƶ����ID
                    //int rjid = Convert.ToInt32(rjmx[0]);

                    //��16���Ƶ����ID ת������ȷ�� ID��Ϣ
                    ////�õ����id
                    //int zqid1 = rjid / 16;
                    ////�õ����ID�������ID
                    //int zqid2 = rjid % 16;
                    //�õ��汾�ŵļ����Ϣ
                    string vis = rjmx[1] + "," + rjmx[2];
                    ////һ����
                    //string sqlSoft = "SELECT SoftwareType,MAX(SoftwareName) AS SoftwareName FROM CstSoftware where SoftwareType=" + zqid1.ToString() + " GROUP BY SoftwareType";
                    //DataTable ds1 = softwmanager.GetLisBySql(sqlSoft);

                    //if (ds1.Rows.Count > 0)
                    //{
                    //rjstring = ds1.Rows[0]["SoftwareName"].ToString();
                    //if (zqid2 != 0)
                    //{
                    //������
                    //string sqlInstall = "select  MAX(InstallType) as InstallType,  InstallName  from dbo.CstSoftware where InstallType='" + zqid2.ToString() + "' GROUP BY InstallName ";
                    //DataTable ds2 = softwmanager.GetLisBySql(sqlInstall);

                    //if (ds2.Rows.Count > 0)
                    //{
                    //    rjstring += ":" + ds2.Rows[0]["InstallName"].ToString();
                    //}


                    //}
                    //else
                    //{
                    //    rjstring += ":����";
                    //}

                    //}

                    if (rjmx.Length > 3)
                    {
                        rjstring += rjmx[3] + ":" + rjmx[4] + ":" + vis + "&#13;";

                    }
                    else
                    {
                        rjstring += "����";
                    }

                    buts += rjstring;

                }

                if (buts.Length >= 7)
                {
                    return "<font title='" + buts + "'>" + buts.Substring(0, 6) + "...</font>";
                }
                else
                {
                    return "<font title='" + buts + "'>" + buts + "</font>";
                }
            }
        }

        /// <summary>
        /// ����޶��޸İ汾
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string RJGSH_01(object obj)
        {
            if (obj != null)
            {
                DataSet ds = cmmanager.GetList("CMID='" + obj.ToString() + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string buts = "";
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        if (ds.Tables[0].Rows[i][5].ToString() == "0")
                        {
                            return "<font title='����'>����</font>";
                        }
                        buts += ds.Tables[0].Rows[i][5] + ":" + ds.Tables[0].Rows[i][6] + ":" + ds.Tables[0].Rows[i][3] + "," + ds.Tables[0].Rows[i][4] + "&#13;";

                    }

                    if (buts.Length >= 7)
                    {
                        return "<font title='" + buts + "'>" + buts.Substring(0, 6) + "...</font>";
                    }
                    else
                    {
                        return "<font title='" + buts + "'>" + buts + "</font>";
                    }
                }


            }
            return "";

            //if (obj.ToString() == "0,0,0|")
            //{
            //    return "<font color='#0000FF' title='û���κ�����޶�'>����</font>";
            //}
            //else
            //{
            //    //�õ����е������
            //    string[] rj = obj.ToString().Split('|');
            //    //���м���
            //    string buts = "";
            //    for (int i = 0; i < rj.Length - 1; i++)
            //    {
            //        string rjstring = "";
            //        //������Ϣ�ٷָ������
            //        string[] rjmx = rj[i].Split(',');
            //        string vis = rjmx[1] + "," + rjmx[2];


            //        if (rjmx.Length > 3)
            //        {
            //            rjstring += rjmx[3] + ":" + rjmx[4] + ":" + vis + "&#13;";

            //        }
            //        else
            //        {
            //            rjstring += "����";
            //        }

            //        buts += rjstring;

            //    }

            //    if (buts.Length >= 7)
            //    {
            //        return "<font title='" + buts + "'>" + buts.Substring(0, 6) + "...</font>";
            //    }
            //    else
            //    {
            //        return "<font title='" + buts + "'>" + buts + "</font>";
            //    }
            //}
        }


        /// <summary>
        /// ע���޶���Ϣ
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ZCGSH(object obj)
        {
            string zong = "";
            string[] zc = obj.ToString().Split('|');
            XmlDocument dom = new XmlDocument();
            dom.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/Msg_RegType.xml"));//װ��XML�ĵ� 
            XmlElement root = dom.DocumentElement;
            for (int i = 0; i < root.ChildNodes.Count; i++)
            {

                XmlNode haha = root.SelectNodes("reg")[i];
                //�õ�����ID
                string ss = haha.SelectSingleNode("@number").Value;
                for (int j = 0; j < zc.Length - 1; j++)
                {
                    if (ss == zc[j])
                    {
                        zong += haha.SelectSingleNode("@name").Value + "|";
                    }
                }



            }

            if (zong.Length >= 7)
            {
                return "<font title='" + zong + "'>" + zong.Substring(0, 6) + "...</font>";
            }
            else if (zong.Length > 0)
            {
                return "<font title='" + zong + "'>" + zong.Substring(0, zong.Length - 1) + "</font>";
            }
            return "";

        }
        /// <summary>
        /// �û��޶���Ϣ
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string YHGSH(object obj)
        {

            string zong = "";
            string[] zc = obj.ToString().Split('|');
            XmlDocument dom = new XmlDocument();
            dom.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/Msg_UserClass.xml"));//װ��XML�ĵ� 
            XmlElement root = dom.DocumentElement;
            for (int i = 0; i < root.ChildNodes.Count; i++)
            {

                XmlNode haha = root.SelectNodes("reg")[i];
                //�õ�����ID
                string ss = haha.SelectSingleNode("@number").Value;
                for (int j = 0; j < zc.Length - 1; j++)
                {
                    if (ss == zc[j])
                    {
                        zong += haha.SelectSingleNode("@name").Value + "|";
                    }
                }



            }

            if (zong.Length >= 7)
            {
                return "<font title='" + zong + "'>" + zong.Substring(0, 6) + "...</font>";
            }
            else if (zong.Length > 0)
            {
                return "<font title='" + zong + "'>" + zong.Substring(0, zong.Length - 1) + "</font>";
            }
            return "";
        }

        /// <summary>
        /// ������ʾ��ɫ���÷���
        /// </summary>
        /// <param name="objtile">����</param>
        /// <param name="objbegintime">��ʼʱ��</param>
        /// <param name="objendtime">����ʱ��</param>
        /// <param name="isfb">�Ƿ񷢲���</param>
        /// <returns>����</returns>
        public static string TitleFmt(object objtile, object objbegintime, object objendtime, object isfb)
        {
            //Ϊ0δ����
            if (Convert.ToInt32(isfb) != 0)
            {
                //�ѷ����ѿ�ʼ ��ɫ
                if (Convert.ToDateTime(objbegintime) <= DateTime.Now && Convert.ToDateTime(objendtime) >= DateTime.Now)
                {
                    return "<font style='color:blue;'>" + objtile + "</font>";
                }
                //�ѷ���δ��ʼ ��ɫ
                if (Convert.ToDateTime(objbegintime) > DateTime.Now)
                {
                    return "<font style='color:green;'>" + objtile + "</font>";
                }
                //�ѷ����ѹ��� ��ɫ
                if (Convert.ToDateTime(objendtime) < DateTime.Now)
                {
                    return "<font style='color:gray;'>" + objtile + "</font>";
                }

            }
            //δ�����ѹ��� ��ɫ
            if (Convert.ToDateTime(objendtime) < DateTime.Now)
            {
                return "<font style='color:gray;'>" + objtile + "</font>";
            }
            //δ������ɫ black
            return "<font style='color:black;'>" + objtile + "</font>";
        }
        /// <summary>
        /// �������¼�����ʱ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MyGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //��Ϊ�޸�ʱ
            if (e.CommandName == "Upda")
            {
                Pbzx.Model.CM_Main cmian = ll.GetMain(Convert.ToInt32(e.CommandArgument));
                //ִ���޸�
                if (cmian.BeginTime < DateTime.Now)
                    cmian.BeginTime = DateTime.Now;

                if (cmian.State == 0)
                {
                    //����������
                    DbHelperSQL1.ExecuteSql("UPDATE CM_Main SET State = 1,BeginTime='" + cmian.BeginTime + "' WHERE (ID = " + e.CommandArgument + ") ");
                }
                else
                {
                    DbHelperSQL1.ExecuteSql("UPDATE CM_Main SET State = 0,BeginTime='" + cmian.BeginTime + "' WHERE (ID = " + e.CommandArgument + ") ");
                }

                Response.Redirect("SoftMessage_Manage_2011.aspx");
            }

        }

        protected void MyGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            ViewState["order"] = e.SortExpression.ToString();
            if ((bool)ViewState["isDesc"])
            {
                ViewState["isDesc"] = false;
            }
            else
            {
                ViewState["isDesc"] = true;
            }
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }
    }
}
