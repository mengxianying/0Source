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
using Maticsoft.DBUtility;
using Pbzx.Common;
using System.Globalization;

namespace Pbzx.Web
{
    public partial class Buy_fatieListShow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               
                string BoardId = Input.FilterAll(Request["BoardId"]);
                string uname = Input.FilterAll(Server.UrlDecode(Request["uname"]));
                string userType = Input.FilterAll(Server.UrlDecode(Request["userType"]));
                string action = Request["action"];
                if (string.IsNullOrEmpty(BoardId) || string.IsNullOrEmpty(uname) || string.IsNullOrEmpty(userType) || string.IsNullOrEmpty(action))
                {
                    Response.Write("Error.htm");
                    return;
                }
                string sql = "";
                string isbest = "";
                string locktopic = "";
                DataSet tmpA = null;
                ///��ȡ����ʱ�����һ��ʱ��
                int days = (int)DateTime.Now.DayOfWeek;
                DateTime s1 = DateTime.Today.AddDays(-(days) + 1);
                DateTime s2 = DateTime.Now;

                DateTime Ups1 = DateTime.Today.AddDays(-(days + 6));
                DateTime Ups2 = DateTime.Today.AddDays(-days + 1).AddMinutes(-1);
                ///��ȡ����bbs��
                string current_sql = "select TableName from Dv_TableList", current_str = "";
                int tbNumber = 0;
                DataSet dsTableList = DbHelperSQLBBS.Query(current_sql);
                if(dsTableList.Tables.Count > 0 && dsTableList.Tables[0].Rows.Count > 0 )
                {
                    for (int i = 0; i < dsTableList.Tables[0].Rows.Count; i++ )
                    {
                        DataRow row = dsTableList.Tables[0].Rows[i];
                        if (i == 0)
                        {
                            current_str += row["TableName"].ToString()+",";
                        }
                        else
                        {
                            current_str += row["TableName"] + ",";
                        }
                    }
                }

                string sql_count="", countStr="", int2, c1="", c2="", d1="", d2="", tmpT, delStr="", int3;
                sql_count = "select configName,configValue from cn_config where ConfigName='BestPostValue' or configName='DelPostValue'";
                DataSet ds_count = DbHelperSQL1.Query(sql_count);
                if (ds_count.Tables.Count > 0 && ds_count.Tables[0].Rows.Count > 0)
                {
                    countStr = ds_count.Tables[0].Rows[0]["ConfigValue"].ToString();
                    delStr = ds_count.Tables[0].Rows[1]["ConfigValue"].ToString();

                    string[] countStrSZ = countStr.Split(new char[] { '|' });
                    c1 = countStrSZ[0];
                    c2 = countStrSZ[1];

                    string[] delSZ = delStr.Split(new char[] { '|' });
                    d1 = delSZ[0];
                    d2 = delSZ[1];
                }

                string[] currentWeekArray = current_str.Split(new char[] {','});
                ViewState["currentWeekArray"] = currentWeekArray;
                if (action == "1")
                {
                    this.lblTime.Text = "����(" + Ups1.ToString("yyyy��MM��dd��", DateTimeFormatInfo.InvariantInfo) + "��" + Ups2.ToString("MM��dd��", DateTimeFormatInfo.InvariantInfo) + ")";

                    string sql_tb = "select ConfigName,Configvalue from CN_Config where ConfigName='CurBbsStatTable'";
                    string tableName = "";
                    DataSet dsSql_tb = DbHelperSQL1.Query(sql_tb);
                    if(dsSql_tb.Tables.Count > 0 && dsSql_tb.Tables[0].Rows.Count > 0)
                    {
                        tableName = dsSql_tb.Tables[0].Rows[0]["Configvalue"].ToString();
                    }
                    sql = "select * from " + tableName + " where username='" + uname + "'and BoardId='" + BoardId + "'";
                    tmpA = DbHelperSQL1.Query(sql);
                    if (tmpA.Tables.Count > 0 && tmpA.Tables[0].Rows.Count > 0)
                    {
                        DataRow rowTmpA = tmpA.Tables[0].Rows[0];
                        lblCommonHostT.Text = rowTmpA[2].ToString();
                        lblBestHostT.Text = rowTmpA[3].ToString();
                        lblCommonHellT.Text = rowTmpA[4].ToString();
                        lblBestCommonT.Text = rowTmpA[5].ToString();
                        lblDelHostT.Text = rowTmpA[6].ToString();
                        lblDelHellT.Text = rowTmpA[7].ToString();
                        lblTopicZS.Text = "<b>" + rowTmpA[8].ToString()+"</b>&nbsp;������&nbsp;(���㹫ʽ = ������������"+c1+"+ ��ͨ������ - ��ɾ��������"+ Convert.ToString(Convert.ToInt32(d1)-1)+")";
                        lblHellZS.Text = "<b>" + rowTmpA[9].ToString() + "</b>&nbsp;������&nbsp;(���㹫ʽ = ������������" + c2 + "+ ��ͨ������ - ��ɾ��������" + Convert.ToString(Convert.ToInt32(d2) - 1) + ")";
                    }
                    else
                    {
                        Response.Write("<script>alert('����ϸ��Ϣ��');history.go(-1);</script>");
                        Response.End();
                        return;
                    }
                   
                                   
                }
                else if (action == "2")
                {
                    this.lblTime.Text = "����(" + s1.ToString("yyyy��MM��dd��", DateTimeFormatInfo.InvariantInfo) + "��" + s2.ToString("MM��dd��", DateTimeFormatInfo.InvariantInfo) + ")";

                    string Config_sql = "select ConfigName ,ConfigValue from CN_Config where ConfigName='DelPostValue' or ConfigName='BestPostValue'";
                    DataSet ConfigArray = DbHelperSQL1.Query(Config_sql);

                    string BestValue = ConfigArray.Tables[0].Rows[0]["ConfigValue"].ToString();
                    string DelValue = ConfigArray.Tables[0].Rows[1]["ConfigValue"].ToString();

                    string[] DelSZ = DelValue.Split(new char[] { '|' });
                    string Del = DelSZ[0];
                    string del2 = DelSZ[1];

                    string[] BestSZ = BestValue.Split(new char[] { '|' });
                    string Best = BestSZ[0];
                    string Best2 = BestSZ[1];

                    string  cWeek_rs="",cWeek_sql="",thisWeek_sql="",thisWeek_rs="";
                    int
                          HostT = 0,       //������
                          HellT = 0,        //������
                          BestT = 0,        //��������
                          DelHostT = 0,     //��ɾ������
                          DelHellT = 0,     //��ɾ������
                          BestHostT = 0,    //����������
                          CommonHostT = 0,  //��ͨ������
                          BestCommonT = 0,  //����������
                          CommonHellT = 0;  //��ͨ������	
                    for (int i = 0; i < currentWeekArray.Length - 1;i++ )
                    {
                        if (!string.IsNullOrEmpty(currentWeekArray[i]))
                        {
                            cWeek_sql = "select  Parentid,Boardid,Username,isbest,locktopic,AnnounceID,DateAndTime from " + currentWeekArray[i] + " where UserName='" + uname + "' and (Boardid=" + BoardId + " or locktopic=" + BoardId + ") and DateAndTime>='" + s1 + "' and DateAndTime<='" + s2.ToShortDateString() + " 23:59:59'";
                        }                        
                        DataSet dsCWeek_sql = DbHelperSQLBBS.Query(cWeek_sql);
                        if(!(dsCWeek_sql.Tables.Count >0 && dsCWeek_sql.Tables[0].Rows.Count > 0) )
                        {
                            continue;
                        }

                        /////////////////////////////////////����04-19//////////////////////////////////////////////////
                        DataRow rowCWeek = dsCWeek_sql.Tables[0].Rows[i];
                        string ParentID = rowCWeek["Parentid"].ToString();
                        string tmBoardID = rowCWeek["Boardid"].ToString();
                        string tmisbest = rowCWeek["isbest"].ToString();
                        string tmlocktopic = rowCWeek["locktopic"].ToString();
                        if(tmBoardID =="444")
                        {
                           if(ParentID =="0" ||  locktopic =="34"){// ���⣬�󷽰����ĸ���Ҳ������
                               DelHostT=DelHostT+1; //'��ɾ��������1
                           }
                           else
                           {
                               DelHellT = DelHellT + 1; //��ɾ��������1
                           }
                        }
                        else //���������
                        {
                            if (ParentID == "0" || tmBoardID == "34")
                            {	//' ���⣬�󷽰����ĸ���Ҳ������
                                if (tmisbest != "0")
                                {
                                    BestHostT = BestHostT + 1;  // '������������1
                                }
                                else
                                { CommonHostT = CommonHostT + 1; } // ��ͨ��������1

                            }
                            else
                            {
                                if (tmisbest != "0")
                                {
                                    BestCommonT = BestCommonT + 1; //������������1
                                }
                                else
                                {
                                    CommonHellT = CommonHellT + 1; //��ͨ��������1
                                } 
                            }
				       
                        }

                    }
                    HostT = BestHostT * Convert.ToInt32(Best) + CommonHostT - DelHostT * (Convert.ToInt32(Del) - 1);
                    HellT = BestCommonT * Convert.ToInt32(Best2) + CommonHellT - DelHellT * (Convert.ToInt32(del2) - 1);

                    lblCommonHostT.Text = CommonHostT.ToString();
                    lblBestHostT.Text = BestHostT.ToString();
                    lblCommonHellT.Text = CommonHellT.ToString();
                    lblBestCommonT.Text = BestCommonT.ToString();
                    lblDelHostT.Text = DelHostT.ToString();
                    lblDelHellT.Text = DelHellT.ToString();

                    lblTopicZS.Text = "<b>" + HostT + "</b>&nbsp;������&nbsp;(���㹫ʽ = ������������" + c1 + "+ ��ͨ������ - ��ɾ��������" + Convert.ToString(Convert.ToInt32(d1) - 1) + ")";
                    lblHellZS.Text = "<b>" + HellT + "</b>&nbsp;������&nbsp;(���㹫ʽ = ������������" + c2 + "+ ��ͨ������ - ��ɾ��������" + Convert.ToString(Convert.ToInt32(d2) - 1) + ")";


                }
                this.lblUserBM.Text = uname + "[" + userType + "]��" + DbHelperSQLBBS.GetBbsBoardName(BoardId);


            string sql_temp = "";

            string StrArray = "ABCDEFGHIJKLM";

             for (int j = 0; j < currentWeekArray.Length;j++ )
             {
                sql_temp +="Select  * from (select top 300 Parentid,Boardid,Username,isbest,locktopic,Body,AnnounceID,DateAndTime,Topic from  "+currentWeekArray[j]+" where UserName='"+uname+"' and (Boardid="+BoardId+" or locktopic="+BoardId+") and DateAndTime>='"+Ups1+"' and DateAndTime<='"+Ups2.ToShortDateString()+" 23:59:59' Order By DateAndTime Desc)  "+StrArray[j]+"";
                 if(j <currentWeekArray.Length)
                 {
                    sql_temp += " union all ";
                 }
             }
             DataSet dsRs_temp = DbHelperSQLBBS.Query(sql_temp);
             if (dsRs_temp.Tables.Count > 0 && dsRs_temp.Tables[0].Rows.Count > 0)
             {
                 this.MyGridView.DataSource = dsRs_temp;
                 this.MyGridView.DataBind();
             }
             else
             {
                 //response.write("<br><br><center>��û���κη�����ϸ��Ϣ��</center>");
             }             

            }
        }



        //protected void AspNetPagerConfig(int tempCount)
        //{
        //    AspNetPager1.PageSize = 20;
        //    AspNetPager1.RecordCount = tempCount;
        //    AddCustomText();
        //}

        //protected void AddCustomText()
        //{
        //    AspNetPager1.CustomInfoHTML = "��<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>��&nbsp;";
        //    AspNetPager1.CustomInfoHTML += "��ҳ��<font color=\"red\"><b>" + MyGridView.Rows.Count + "</b></font>��&nbsp;&nbsp;";
        //    AspNetPager1.CustomInfoHTML += "��ҳ:<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "ҳ</font>";
        //}

        //protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        //{
        //    BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        //}


        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                // string href = "<a href='/SoftRegisterLog_Editor.aspx?ID=" + e.Row.Cells[0].Text + "'>";
                // e.Row.Cells[0].Text = href + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString();//+ "</a>";
                e.Row.Cells[0].Text = "(" + Convert.ToString(( MyGridView.PageIndex * MyGridView.PageSize) + id) + ")";
            }
            
        }

        
    }
}
