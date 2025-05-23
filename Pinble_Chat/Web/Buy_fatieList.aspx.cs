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
using System.Globalization;

namespace Pbzx.Web
{
    public partial class Buy_fatieList : System.Web.UI.Page
    {
        public string Name = "";
        public string Pwd = "";
        public string strClass = "";
        protected string soft ="";
        protected string insta = "";
        protected string ismd5 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string nowAdmin = "";
            string str_bbs = "";
            string uClass = "";
            if (!IsPostBack)
            {                
                BindClass();                
                if (!string.IsNullOrEmpty(Request["UID"]) && !string.IsNullOrEmpty(Request["PWD"]))
                {
                    ViewState["UserName"]  = Request["UID"];
                    Pbzx.BLL.PinbleLogin LoginBll = new Pbzx.BLL.PinbleLogin();
                    string result = LoginBll.CheckLogin(Request["UID"], Request["PWD"], "0");
                    if (!string.IsNullOrEmpty(result))
                    {
                        Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("����", "" + result + "��", 400, "1", "location.href='/login.aspx'", "", false, false) + "");
                        return;
                    }
                }
                else
                { 
                    if(!string.IsNullOrEmpty(Request["UID"]))
                    {
                        ViewState["UserName"] = Request["UID"];
                    }
                    LoginSort login = new LoginSort();
                    if (!login["manager_user"])
                    {
                        Response.Write("<script>alert('����û�е�¼�����¼�����ԣ�');location.href='Login.aspx?ReturnUrl=Buy_fatieList.aspx'</script>");
                        return;
                    }
                    else
                    {
                        if (ViewState["UserName"] == null)
                        {                           
                            ViewState["UserName"] = Method.Get_UserName;
                        }                        
                    }
                }
                if (!string.IsNullOrEmpty(Request["ST"]) && !string.IsNullOrEmpty(Request["IT"]))
                {
                    this.ddlSoft.SelectedValue = Request["ST"] + "-" + Request["IT"];
                    ViewState["ST"] = Request["ST"];
                    ViewState["IT"] = Request["IT"];
                }
                else
                {
                    if (ViewState["ST"] == null || ViewState["IT"] == null)
                    {
                        this.ddlSoft.SelectedValue = "1-3";
                        ViewState["ST"] = "1";
                        ViewState["IT"] = "3";
                    }
                    else
                    {
                        string[] SI = this.ddlSoft.SelectedValue.Split(new char[] { '-' });
                        ViewState["ST"] = SI[0];
                        ViewState["IT"] = SI[1];
                    }
                }

                DataSet dsUser = null;    
                DataRow rowAdmin = WebFunc.GetQQLookUser();
                HttpCookie aCookie = HttpContext.Current.Request.Cookies["UserClass"];
                
                if (rowAdmin != null)
                {                   
                    this.txtName.Visible = true;
                    this.lblName.Visible = false; 
                    nowAdmin = uClass;
                    dsUser = DbHelperSQLBBS.Query(" select UserName,UserPassword ,UserClass from [DV_user] where userName='" + ViewState["UserName"].ToString() + "'  ");
                    this.txtName.Text = ViewState["UserName"].ToString();                   
                }
                else
                {                   
                    this.lblName.Text = Method.Get_UserName;
                    this.txtName.Visible = false;
                    this.lblName.Visible = true;
                    dsUser = DbHelperSQLBBS.Query(" select UserName,UserPassword ,UserClass from [DV_user] where userName='" + Method.Get_UserName + "'  ");
                    ViewState["UserName"] = Method.Get_UserName;
                }
                uClass = dsUser.Tables[0].Rows[0]["UserClass"].ToString();       
                     
                ///����û�Ȩ��
                string sql_uType = "select ConfigName,Configvalue from CN_Config where ConfigName='AllPostUserType'";
                string userType = "";
                string postUserType = "";
                DataSet dsUType = DbHelperSQL1.Query(sql_uType);
                if (dsUType.Tables.Count > 0 && dsUType.Tables[0].Rows.Count > 0)
                {
                    userType = dsUType.Tables[0].Rows[0]["Configvalue"].ToString();
                }
                string[] utArray = userType.Split(new char[] { '|' });

                int typeNum = 0;
                bool flag = false;
                for (int i = 0; i < utArray.Length - 2; i++)
                {
                    if (uClass == utArray[i])
                    {
                        flag = true;
                        postUserType = uClass;
                        break;
                    }
                    typeNum++;
                }
                if (flag == false)
                {
                    postUserType = utArray[utArray.Length - 2];
                }



                ///��ȡ����ʱ�����һ��ʱ��
                int days = (int)DateTime.Now.DayOfWeek;
                DateTime s1 = DateTime.Today.AddDays(-(days)+1);
                DateTime s2 = DateTime.Now;

                DateTime Ups1 = DateTime.Today.AddDays(-(days + 6));
                DateTime Ups2 = DateTime.Today.AddDays(-days+1).AddMinutes(-1);

                //	'---------------��ȡ����	
                string sql_tb = "select Configvalue from CN_Config where ConfigName='CurBbsStatTable' ";
                string tableName = "";
                object objTableName = DbHelperSQL1.GetSingle(sql_tb);
                if (objTableName != null)
                {
                    tableName = objTableName.ToString();
                }


                //'-----------------------------------���ܱ�����Ϣ
               // int tbNumber = 0;
                int ParentID = 0, BoardID = 0, isbest = 0, locktopic = 0, FtDay = 0;
                string current_sql = "select TableName from Dv_TableList";
                DataSet dsTables = DbHelperSQLBBS.Query(current_sql);
                string current_str = "";
                if (dsTables.Tables.Count > 0 && dsTables.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in dsTables.Tables[0].Rows)
                    {
                        if (row["TableName"].ToString() == "dv_bbs1")
                        {
                            current_str += "" + row["TableName"] + ",";
                        }
                        else
                        {
                            current_str += "" + row["TableName"] + ",";
                        }
                    }
                }
                flag = false;
                string[] currentWeekArray = current_str.Split(new char[] { ',' });                
                int[] FtDayArray = new int[7];
                int[] GtDayArray = new int[7];


                /// '����������������������������׼/��ȡ����
                string sql_Bzhui = "select * from [CN_Software] where SoftwareType='" + ViewState["ST"] + "' and InstallType='" + ViewState["IT"] + "'";
                DataSet dsBzhui = DbHelperSQL1.Query(sql_Bzhui);
                if (dsBzhui.Tables.Count > 0 && dsBzhui.Tables[0].Rows.Count > 0)
                {
                    #region ���ܷ���
                    string strID = Input.FilterAll(Request["id"]); 
                    if (strID == "")
                    {
                        strID = "1";
                    }

                    if (strID == "1")
                    {
                        #region ѭ���淨(���ܷ���)
                        foreach (DataRow row in dsBzhui.Tables[0].Rows)
                        {
                            int nPostDayCount = 0;

                            int TotalZt = 0;
                            int TotalGt = 0;
                            int TotalBest = 0;
                            int BestPic = 0;
                            int Ztie = 0;
                            int Gtie = 0;

                            string[] ArrayFt = row["MinTopics"].ToString().Split(new char[] { '|' });
                            string fatie = ArrayFt[typeNum];

                            string[] ArrayHt = row["MinAnncounts"].ToString().Split(new char[] { '|' });
                            string huitie = ArrayHt[typeNum];

                            string[] MinDays = row["MinDays"].ToString().Split(new char[] { '|' });
                            string S_MinDays = MinDays[typeNum];

                            string[] MinBests = row["MinBests"].ToString().Split(new char[] { '|' });
                            string S_MinBests = MinBests[typeNum];


                            string[] ArrayBm = row["Boards"].ToString().Split(new char[] { '|' });
                            ///��ͷ�û���Ϣ��
                            HtmlTableRow rowHead = new HtmlTableRow();

                            HtmlTableCell cellHead = new HtmlTableCell();
                            cellHead.ColSpan = 6;
                            cellHead.Align = "center";
                            string txtTou = ViewState["UserName"] + "[" + postUserType + "]&nbsp;����(" + Ups1.ToString("yyyy��MM��dd��", DateTimeFormatInfo.InvariantInfo) + "��" + Ups2.ToString("MM��dd��", DateTimeFormatInfo.InvariantInfo) + ")";
                            txtTou += row["Lottery"] == null ? "" : "<font color=#0000ff>" + row["Lottery"] + "</font>" + "�ķ�����Ϣ";
                            cellHead.InnerHtml = txtTou;
                            rowHead.Cells.Add(cellHead);
                            tb1.Rows.Add(rowHead);

                            #region ������ͷ(���ܷ���)
                            ///��ͷ
                            HtmlTableRow rowHead1 = new HtmlTableRow();
                            rowHead1.BgColor = "#DDE6E6";
                            HtmlTableCell cellBoardHeadMeng = new HtmlTableCell();
                            cellBoardHeadMeng.Height = "22px";
                            cellBoardHeadMeng.Align = "center";
                            cellBoardHeadMeng.InnerHtml = "<b>��̳����</b>";
                            rowHead1.Cells.Add(cellBoardHeadMeng);

                            HtmlTableCell cellZtHead = new HtmlTableCell();
                            cellZtHead.Height = "22px";
                            cellZtHead.Align = "center";
                            cellZtHead.InnerHtml = "<b>��������</b>";
                            rowHead1.Cells.Add(cellZtHead);

                            HtmlTableCell cellGtHead = new HtmlTableCell();
                            cellGtHead.Height = "22px";
                            cellGtHead.Align = "center";
                            cellGtHead.InnerHtml = "<b>��������</b>";
                            rowHead1.Cells.Add(cellGtHead);

                            HtmlTableCell cellJhHead = new HtmlTableCell();
                            cellJhHead.Height = "22px";
                            cellJhHead.Align = "center";
                            cellJhHead.InnerHtml = "<b>��������</b>";
                            rowHead1.Cells.Add(cellJhHead);

                            HtmlTableCell cellGtDayHead = new HtmlTableCell();
                            cellGtDayHead.Height = "22px";
                            cellGtDayHead.Align = "center";
                            cellGtDayHead.InnerHtml = "<b>������������</b>";
                            rowHead1.Cells.Add(cellGtDayHead);

                            HtmlTableCell cellOtherHead = new HtmlTableCell();
                            cellOtherHead.Height = "22px";
                            cellOtherHead.Align = "center";
                            cellOtherHead.InnerHtml = "<b>����</b>";
                            rowHead1.Cells.Add(cellOtherHead);
                            //int TotalBest=0;
                            //int TotalDay=0;
                            //int counted=0;		 
                            //string szPostDateFlag= "0000000";
                            //int  nPostDayCount = 0;
                            tb1.Rows.Add(rowHead1);
                            #endregion

                            #region ѭ������ (���ܷ���)
                            for (int mi = 0; mi < ArrayBm.Length - 1; mi++)
                            {
                                string str = ArrayBm[mi];
                                string str_user = "select username,BoardID,TotalTopicCount,BestTopicCount,BestAnnounceCount,TotalAnnounceCount,PostDateFlag from " + tableName + " where UserName='" + ViewState["UserName"].ToString() + "' and BoardID=" + str + "";
                                DataSet myDataSet = DbHelperSQL1.Query(str_user);
                                if (!(myDataSet.Tables.Count > 0 && myDataSet.Tables[0].Rows.Count > 0))
                                {
                                    #region ��������ʱ��
                                    ///��������ʱ��
                                    HtmlTableRow rowContent1 = new HtmlTableRow();
                                    rowContent1.BgColor = "#FFFFFF";
                                    // rowContent1.Attributes.Add("class", "RowJ");                                    
                                    HtmlTableCell cellBoard = new HtmlTableCell();
                                    cellBoard.Height = "22px";
                                    cellBoard.Align = "center";
                                    cellBoard.InnerHtml = DbHelperSQLBBS.GetBbsBoardName(str);
                                    rowContent1.Cells.Add(cellBoard);

                                    HtmlTableCell cellZt = new HtmlTableCell();
                                    cellZt.Height = "22px";
                                    cellZt.Align = "center";
                                    cellZt.InnerHtml = "0";
                                    rowContent1.Cells.Add(cellZt);

                                    HtmlTableCell cellGt = new HtmlTableCell();
                                    cellGt.Height = "22px";
                                    cellGt.Align = "center";
                                    cellGt.InnerHtml = "0";
                                    rowContent1.Cells.Add(cellGt);

                                    HtmlTableCell cellJh = new HtmlTableCell();
                                    cellJh.Height = "22px";
                                    cellJh.Align = "center";
                                    cellJh.InnerHtml = "0";
                                    rowContent1.Cells.Add(cellJh);

                                    HtmlTableCell cellGtDay = new HtmlTableCell();
                                    cellGtDay.Height = "22px";
                                    cellGtDay.Align = "center";
                                    cellGtDay.InnerHtml = "0";
                                    rowContent1.Cells.Add(cellGtDay);

                                    HtmlTableCell cellOther = new HtmlTableCell();
                                    cellOther.Height = "22px";
                                    cellOther.Align = "center";
                                    cellOther.InnerHtml = "<font style='color:#999999'>�鿴����>></font>";
                                    rowContent1.Cells.Add(cellOther);

                                    tb1.Rows.Add(rowContent1);
                                    #endregion
                                }
                                else
                                {

                                    #region ѭ����������(���ܷ���)
                                    foreach (DataRow row1 in myDataSet.Tables[0].Rows)
                                    {
                                        string m_PostDateFlag = row1["PostDateFlag"].ToString();

                                        int Icount = 0;
                                        for (int i = 0; i < m_PostDateFlag.Length; i++)
                                        {
                                            if (m_PostDateFlag.Substring(i, 1) == "1")
                                            {
                                                Icount += 1;
                                            }
                                        }
                                        ///����
                                        HtmlTableRow rowContent1 = new HtmlTableRow();
                                        rowContent1.BgColor = "#FCFCFC";
                                        //  rowContent1.Attributes.Add("class", "RowJ");

                                        HtmlTableCell cellBoard = new HtmlTableCell();
                                        cellBoard.Height = "22px";
                                        cellBoard.Align = "center";
                                        cellBoard.InnerHtml = DbHelperSQLBBS.GetBbsBoardName(str);
                                        rowContent1.Cells.Add(cellBoard);

                                        HtmlTableCell cellZt = new HtmlTableCell();
                                        cellZt.Height = "22px";
                                        cellZt.Align = "center";
                                        cellZt.InnerHtml = row1["TotalTopicCount"].ToString();
                                        rowContent1.Cells.Add(cellZt);

                                        HtmlTableCell cellGt = new HtmlTableCell();
                                        cellGt.Height = "22px";
                                        cellGt.Align = "center";
                                        cellGt.InnerHtml = row1["TotalAnnounceCount"].ToString();
                                        rowContent1.Cells.Add(cellGt);

                                        HtmlTableCell cellJh = new HtmlTableCell();
                                        cellJh.Height = "22px";
                                        cellJh.Align = "center";
                                        BestPic = ((int)row1["BestTopicCount"]) + ((int)row1["BestAnnounceCount"]);
                                        cellJh.InnerHtml = BestPic.ToString();
                                        rowContent1.Cells.Add(cellJh);

                                        HtmlTableCell cellGtDay = new HtmlTableCell();
                                        cellGtDay.Height = "22px";
                                        cellGtDay.Align = "center";
                                        cellGtDay.InnerHtml = Icount.ToString();
                                        rowContent1.Cells.Add(cellGtDay);



                                        HtmlTableCell cellOther = new HtmlTableCell();
                                        cellOther.Height = "22px";
                                        cellOther.Align = "center";
                                        cellOther.InnerHtml = "<a href='Buy_fatieListShow.aspx?BoardID=" + str + "&uname=" +Server.UrlEncode(ViewState["UserName"].ToString()) + "&userType=" + Server.UrlEncode(postUserType) + "&action=1'><font color=#0000ff>�鿴����>></font></a>";
                                        TotalZt += Ztie;
                                        TotalGt += Gtie;
                                        TotalBest += BestPic;
                                        for (int i = 0; i < m_PostDateFlag.Length; i++)
                                        {
                                            if (m_PostDateFlag.Substring(i, 1) == "1")
                                            {
                                                nPostDayCount += 1;
                                            }
                                        }
                                        rowContent1.Cells.Add(cellOther);
                                        tb1.Rows.Add(rowContent1);

                                    }
                                    #endregion
                                }
                                #region ���ܼ���(���ܷ���)
                                ///�ܼ�
                                HtmlTableRow rowZJ = new HtmlTableRow();
                                rowZJ.BgColor = "#F0F0F0";

                                rowZJ.Attributes.Add("class", "RowZJ");

                                HtmlTableCell cellBoardZJ = new HtmlTableCell();
                                cellBoardZJ.Height = "22px";
                                cellBoardZJ.Align = "center";
                                cellBoardZJ.InnerHtml = "�ܼ�";
                                rowZJ.Cells.Add(cellBoardZJ);


                                HtmlTableCell cellZtZJ = new HtmlTableCell();
                                cellZtZJ.Height = "22px";
                                cellZtZJ.Align = "center";
                                cellZtZJ.InnerHtml = TotalZt >= int.Parse(fatie) ? "<font color='#0000ff'><b>" + TotalZt + "</b></font>" : "<font color=red><b>" + TotalZt + "</b></font>";
                                rowZJ.Cells.Add(cellZtZJ);

                                //TotalGt > int.Parse(huitie) ? "<font color='#0000ff'><b>" + TotalGt + "</b></font>" : "<font color=red><b>" + TotalGt + "</b></font>";

                                HtmlTableCell cellGtZJ = new HtmlTableCell();
                                cellGtZJ.Height = "22px";
                                cellGtZJ.Align = "center";
                                cellGtZJ.InnerHtml = TotalGt > int.Parse(huitie) ? "<font color='#0000ff'><b>" + TotalGt + "</b></font>" : "<font color=red><b>" + TotalGt + "</b></font>";
                                rowZJ.Cells.Add(cellGtZJ);

                                // TotalBest >= int.Parse(S_MinBests) ? "<font color='#0000ff'><b>" + TotalBest + "</b></font>" : "<font color=red><b>" + TotalBest + "</b></font>";
                                HtmlTableCell cellJhZJ = new HtmlTableCell();
                                cellJhZJ.Height = "22px";
                                cellJhZJ.Align = "center";
                                // BestPic = ((int)row["BestTopicCount"]) + ((int)row["BestAnnounceCount"]);
                                cellJhZJ.InnerHtml = TotalBest >= int.Parse(S_MinBests) ? "<font color='#0000ff'><b>" + TotalBest + "</b></font>" : "<font color=red><b>" + TotalBest + "</b></font>";
                                rowZJ.Cells.Add(cellJhZJ);



                                HtmlTableCell cellGtDayZJ = new HtmlTableCell();
                                cellGtDayZJ.Height = "22px";
                                cellGtDayZJ.Align = "center";
                                cellGtDayZJ.InnerHtml = nPostDayCount >= int.Parse(S_MinDays) ? "<font color='#0000ff'><b>" + nPostDayCount + "</b></font>" : "<font color=red><b>" + nPostDayCount + "</b><font>";
                                string useRetult = "";
                                if (TotalGt >= int.Parse(huitie) && TotalZt >= int.Parse(fatie) && TotalBest >= int.Parse(S_MinBests) && nPostDayCount >= int.Parse(S_MinDays))
                                {
                                    useRetult = "<img src='/images/web/dui.gif' width='24' height='20' border='0' title='����ʹ�������'>";
                                }
                                else
                                {
                                    useRetult = "<img src='/images/web/ca.gif' width='24' height='20' border='0' title='����ʹ�������'>";
                                }
                                rowZJ.Cells.Add(cellGtDayZJ);

                                HtmlTableCell cellOtherZJ = new HtmlTableCell();
                                cellOtherZJ.Height = "22px";
                                cellOtherZJ.Align = "center";
                                cellOtherZJ.InnerHtml = useRetult;
                                rowZJ.Cells.Add(cellOtherZJ);

                                this.tb1.Rows.Add(rowZJ);
                                #endregion

                                #region ������׼��(���ܷ���)
                                ///������׼
                                HtmlTableRow rowBZ = new HtmlTableRow();
                                rowBZ.BgColor = "#F0F0F0";
                                rowBZ.Attributes.Add("class", "rowBZ");
                                HtmlTableCell cellBoardBZ = new HtmlTableCell();
                                cellBoardBZ.Height = "22px";
                                cellBoardBZ.Align = "center";
                                cellBoardBZ.InnerHtml = "<b>������׼</b>";
                                rowBZ.Cells.Add(cellBoardBZ);

                                HtmlTableCell cellZtBZ = new HtmlTableCell();
                                cellZtBZ.Height = "22px";
                                cellZtBZ.Align = "center";
                                cellZtBZ.InnerHtml = fatie;
                                rowBZ.Cells.Add(cellZtBZ);

                                HtmlTableCell cellGtBZ = new HtmlTableCell();
                                cellGtBZ.Height = "22px";
                                cellGtBZ.Align = "center";
                                cellGtBZ.InnerHtml = huitie;
                                rowBZ.Cells.Add(cellGtBZ);

                                HtmlTableCell cellJhBZ = new HtmlTableCell();
                                cellJhBZ.Height = "22px";
                                cellJhBZ.Align = "center";
                                cellJhBZ.InnerHtml = S_MinBests;
                                rowBZ.Cells.Add(cellJhBZ);

                                HtmlTableCell cellGtDayBZ = new HtmlTableCell();
                                cellGtDayBZ.Height = "22px";
                                cellGtDayBZ.Align = "center";
                                cellGtDayBZ.InnerHtml = S_MinDays;
                                rowBZ.Cells.Add(cellGtDayBZ);

                                HtmlTableCell cellOtherBZ = new HtmlTableCell();
                                cellOtherBZ.Height = "22px";
                                cellOtherBZ.Align = "center";
                                cellOtherBZ.InnerHtml = "<a href='/Buy_mianfei.htm'><font color=#0000ff>�鿴����>></font></a>";
                                rowBZ.Cells.Add(cellOtherBZ);
                                tb1.Rows.Add(rowBZ);
                                #endregion
                            }
                            #endregion

                        }
                        #endregion
                    }
                    #endregion
                    #region ���ܷ���
                    else
                    {
                        string BestValue = "";
                        string DelValue = "";
                        int int2 = 0;
                        string Del = "";
                        string del2 = "";
                        int int3 = 0;
                        string Best = "";
                        string Best2 = "";

                        #region ѭ���淨(���ܷ���)
                        foreach (DataRow row in dsBzhui.Tables[0].Rows)
                        {
                            int nPostDayCount = 0;

                            int TotalZt = 0;
                            int TotalGt = 0;
                            int TotalBest = 0;
                            int BestPic = 0;
                            int Ztie = 0;
                            int Gtie = 0;
                            string Config_sql = "select ConfigName ,ConfigValue from CN_Config where ConfigName='DelPostValue' or ConfigName='BestPostValue'";
                            DataSet ds = DbHelperSQL1.Query(Config_sql);
                            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                            {
                                BestValue = ds.Tables[0].Rows[0]["ConfigValue"].ToString();
                                DelValue = ds.Tables[0].Rows[1]["ConfigValue"].ToString();

                                int2 = DelValue.IndexOf("|");
                                Del = DelValue.Substring(0, int2);
                                del2 = DelValue.Substring(int2 + 1, 1);

                                int3 = BestValue.IndexOf("|");
                                Best = DelValue.Substring(0, int3);
                                Best2 = DelValue.Substring(int2 + 1, 1);
                            }

                            string[] ArrayFt = row["MinTopics"].ToString().Split(new char[] { '|' });

                            string fatie = ArrayFt[typeNum];
                            string[] Arrayht = row["MinAnncounts"].ToString().Split(new char[] { '|' });
                            string huitie = Arrayht[typeNum];

                            string[] MinDays = row["MinDays"].ToString().Split(new char[] { '|' });
                            string S_MinDays = MinDays[typeNum];

                            string[] MinBests = row["MinBests"].ToString().Split(new char[] { '|' });
                            string S_MinBests = MinBests[typeNum];


                            string[] ArrayBm = row["Boards"].ToString().Split(new char[] { '|' });
                            ///��ͷ�û���Ϣ��
                            HtmlTableRow rowHead = new HtmlTableRow();
                            HtmlTableCell cellHead = new HtmlTableCell();
                            cellHead.ColSpan = 7;
                            cellHead.Align = "center";
                            string txtTou = ViewState["UserName"] + "[" + postUserType + "]&nbsp;����(" + s1.ToString("yyyy��MM��dd��", DateTimeFormatInfo.InvariantInfo) + "��" + s2.ToString("MM��dd��", DateTimeFormatInfo.InvariantInfo) + ")";
                            txtTou += row["Lottery"] == null ? "" : "<font color=#0000ff>" + row["Lottery"] + "�淨</font>" + "�ķ�����Ϣ";

                            cellHead.InnerHtml = txtTou;
                            rowHead.Cells.Add(cellHead);
                            tb1.Rows.Add(rowHead);

                            #region ������ͷ(���ܷ���)
                            ///��ͷ
                            HtmlTableRow rowHead1 = new HtmlTableRow();
                            rowHead1.BgColor = "#DDE6E6";
                            HtmlTableCell cellBoardHead = new HtmlTableCell();
                            cellBoardHead.Height = "22px";
                            cellBoardHead.Align = "center";
                            cellBoardHead.InnerHtml = "<b>��̳����</b>";
                            rowHead1.Cells.Add(cellBoardHead);

                            HtmlTableCell cellZtHead = new HtmlTableCell();
                            cellZtHead.Height = "22px";
                            cellZtHead.Align = "center";
                            cellZtHead.InnerHtml = "<b>��������</b>";
                            rowHead1.Cells.Add(cellZtHead);


                            HtmlTableCell cellGtHead = new HtmlTableCell();
                            cellGtHead.Height = "22px";
                            cellGtHead.Align = "center";
                            cellGtHead.InnerHtml = "<b>��������</b>";
                            rowHead1.Cells.Add(cellGtHead);


                            HtmlTableCell cellJhHead = new HtmlTableCell();
                            cellJhHead.Height = "22px";
                            cellJhHead.Align = "center";
                            cellJhHead.InnerHtml = "<b>��������</b>";
                            rowHead1.Cells.Add(cellJhHead);

                            HtmlTableCell cellFtDayHead = new HtmlTableCell();
                            cellFtDayHead.Height = "22px";
                            cellFtDayHead.Align = "center";
                            cellFtDayHead.InnerHtml = "<b>��������</b>";
                            rowHead1.Cells.Add(cellFtDayHead);

                            HtmlTableCell cellGtDayHead = new HtmlTableCell();
                            cellGtDayHead.Height = "22px";
                            cellGtDayHead.Align = "center";
                            cellGtDayHead.InnerHtml = "<b>��������</b>";
                            rowHead1.Cells.Add(cellGtDayHead);

                            HtmlTableCell cellOtherHead = new HtmlTableCell();
                            cellOtherHead.Height = "22px";
                            cellOtherHead.Align = "center";
                            cellOtherHead.InnerHtml = "<b>����</b>";
                            rowHead1.Cells.Add(cellOtherHead);
                            tb1.Rows.Add(rowHead1);
                            //int TotalBest=0;
                            //int TotalDay=0;
                            //int counted=0;		 
                            //string szPostDateFlag= "0000000";
                            //int  nPostDayCount = 0;
                            #endregion

                            FtDayArray[0] = 0;
                            FtDayArray[1] = 0;
                            FtDayArray[2] = 0;
                            FtDayArray[3] = 0;
                            FtDayArray[4] = 0;
                            FtDayArray[5] = 0;
                            FtDayArray[6] = 0;

                            GtDayArray[0] = 0;
                            GtDayArray[1] = 0;
                            GtDayArray[2] = 0;
                            GtDayArray[3] = 0;
                            GtDayArray[4] = 0;
                            GtDayArray[5] = 0;
                            GtDayArray[6] = 0;

                            int HostT = 0;// '������
                            int HellT = 0;// '������
                            int BestT = 0;        //  '��������
                            int DelHostT = 0;     //'��ɾ������
                            int DelHellT = 0;     //'��ɾ������
                            int BestHostT = 0;    //'����������
                            int CommonHostT = 0;  //'��ͨ������
                            int BestCommonT = 0;  //'����������
                            int CommonHellT = 0;  //'��ͨ������
                            int WeekDays = 0;     //'����ͳ������
                            int WeekDays_gt = 0;  //'����ͳ������

                            #region ѭ������ (���ܷ���)
                            for (int tempi = 0; tempi < ArrayBm.Length - 1; tempi++)
                            {
                                string str = ArrayBm[tempi];
                                //for (int i=0 ;i<currentWeekArray.Length-1;i++)
                                //{
                                string cWeek_sql = "";
                                if (string.IsNullOrEmpty(currentWeekArray[currentWeekArray.Length - 2]))
                                {                                   
                                }
                                else
                                {
                                    cWeek_sql = "select  Parentid,Boardid,Username,isbest,locktopic,AnnounceID,DateAndTime from " + currentWeekArray[currentWeekArray.Length - 2] + " where UserName='" + ViewState["UserName"].ToString() + "' and (Boardid=" + str + " or locktopic=" + str + ") and DateAndTime>='" + s1 + "' and DateAndTime<='" + s2 + "'";
                                }
                                DataSet dsCweek = DbHelperSQLBBS.Query(cWeek_sql);
                                if (dsCweek.Tables.Count > 0 && dsCweek.Tables[0].Rows.Count > 0)
                                {
                                    flag = true;
                                    foreach (DataRow rowCweek in dsCweek.Tables[0].Rows)
                                    {
                                        ParentID = (int)rowCweek["Parentid"];
                                        BoardID = (int)rowCweek["Boardid"];
                                        isbest = Convert.ToInt32(rowCweek["isbest"]);
                                        locktopic = (int)rowCweek["locktopic"];
                                        FtDay = (int)((DateTime)rowCweek["DateAndTime"]).DayOfWeek;
                                        if (BoardID == 444)
                                        {
                                            //ɾ������

                                            if (ParentID == 0 || locktopic == 34)
                                            {//' ���⣬�󷽰����ĸ���Ҳ������
                                                DelHostT = DelHostT + 1;    //'��ɾ��������1
                                            }
                                            else
                                            {
                                                DelHellT = DelHellT + 1;    // ' ��ɾ��������1
                                            }
                                        }
                                        else
                                        {  //' ���������
                                            if (ParentID == 0 || BoardID == 34)
                                            {  //' ���⣬�󷽰����ĸ���Ҳ������
                                                if (isbest != 0)
                                                {
                                                    BestHostT = BestHostT + 1;   //'������������1
                                                }
                                                else
                                                {
                                                    CommonHostT = CommonHostT + 1;        //  ' ��ͨ��������1
                                                }

                                                FtDayArray[FtDay] = 1;
                                            }
                                            else
                                            {
                                                if (isbest != 0)
                                                {
                                                    BestCommonT = BestCommonT + 1;   //' ������������1
                                                }
                                                else
                                                {
                                                    CommonHellT = CommonHellT + 1;      //' ��ͨ��������1
                                                }

                                                GtDayArray[FtDay] = 1;
                                            }
                                        }
                                    }
                                }
                                for (int w = 0; w <= 6; w++)
                                {
                                    if (FtDayArray[w] == 1)
                                    {
                                        WeekDays = WeekDays + 1;
                                    }
                                    if (GtDayArray[w] == 1)
                                    {
                                        WeekDays_gt = WeekDays_gt + 1;
                                    }
                                }
                                HostT = BestHostT * int.Parse(Best) + CommonHostT - DelHostT * (int.Parse(Del) - 1); //������Ŀ
                                HellT = BestCommonT * int.Parse(Best2) + CommonHellT - DelHellT * (int.Parse(del2) - 1);
                                BestT = BestCommonT + BestHostT;
                                TotalZt = TotalZt + HostT;
                                TotalGt = TotalGt + HellT;
                                TotalBest = TotalBest + BestHostT;

                                if (!flag)
                                {
                                    #region ��������ʱ��
                                    ///��������ʱ��
                                    HtmlTableRow rowContent1 = new HtmlTableRow();
                                    rowContent1.BgColor = "#FFFFFF";
                                    rowContent1.Attributes.Add("class", "RowJ");

                                    HtmlTableCell cellBoard = new HtmlTableCell();
                                    cellBoard.Height = "22px";
                                    cellBoard.Align = "center";
                                    cellBoard.InnerHtml = DbHelperSQLBBS.GetBbsBoardName(str);
                                    rowContent1.Cells.Add(cellBoard);

                                    HtmlTableCell cellZt = new HtmlTableCell();
                                    cellZt.Height = "22px";
                                    cellZt.Align = "center";
                                    cellZt.InnerHtml = "0";
                                    rowContent1.Cells.Add(cellZt);


                                    HtmlTableCell cellGt = new HtmlTableCell();
                                    cellGt.Height = "22px";
                                    cellGt.Align = "center";
                                    cellGt.InnerHtml = "0";
                                    rowContent1.Cells.Add(cellGt);

                                    HtmlTableCell cellJh = new HtmlTableCell();
                                    cellJh.Height = "22px";
                                    cellJh.Align = "center";
                                    cellJh.InnerHtml = "0";
                                    rowContent1.Cells.Add(cellJh);

                                    HtmlTableCell cellFtDay = new HtmlTableCell();
                                    cellFtDay.Height = "22px";
                                    cellFtDay.Align = "center";
                                    cellFtDay.InnerHtml = "0";
                                    rowContent1.Cells.Add(cellFtDay);

                                    HtmlTableCell cellGtDay = new HtmlTableCell();
                                    cellGtDay.Height = "22px";
                                    cellGtDay.Align = "center";
                                    cellGtDay.InnerHtml = "0";
                                    rowContent1.Cells.Add(cellGtDay);

                                    HtmlTableCell cellOther = new HtmlTableCell();
                                    cellOther.Height = "22px";
                                    cellOther.Align = "center";
                                    cellOther.InnerHtml = "<font style='color:#999999'>�鿴����>></font>";
                                    rowContent1.Cells.Add(cellOther);
                                    tb1.Rows.Add(rowContent1);
                                    #endregion
                                }
                                else
                                {
                                    #region ѭ����������(���ܷ���)
                                    ///����
                                    HtmlTableRow rowContent1 = new HtmlTableRow();
                                    rowContent1.BgColor = "#FCFCFC";
                                    rowContent1.Attributes.Add("class", "RowJ");

                                    HtmlTableCell cellBoard = new HtmlTableCell();
                                    cellBoard.Height = "22px";
                                    cellBoard.Align = "center";
                                    cellBoard.InnerHtml = DbHelperSQLBBS.GetBbsBoardName(str);
                                    rowContent1.Cells.Add(cellBoard);

                                    HtmlTableCell cellZt = new HtmlTableCell();
                                    cellZt.Height = "22px";
                                    cellZt.Align = "center";
                                    cellZt.InnerHtml = HostT.ToString();
                                    rowContent1.Cells.Add(cellZt);

                                    HtmlTableCell cellGt = new HtmlTableCell();
                                    cellGt.Height = "22px";
                                    cellGt.Align = "center";
                                    cellGt.InnerHtml = HellT.ToString();
                                    rowContent1.Cells.Add(cellGt);

                                    HtmlTableCell cellJh = new HtmlTableCell();
                                    cellJh.Height = "22px";
                                    cellJh.Align = "center";
                                    //int BestPic = ((int)row1["BestTopicCount"]) + ((int)row1["BestAnnounceCount"]);
                                    cellJh.InnerHtml = BestT.ToString();
                                    rowContent1.Cells.Add(cellJh);

                                    HtmlTableCell cellFtDay = new HtmlTableCell();
                                    cellFtDay.Height = "22px";
                                    cellFtDay.Align = "center";
                                    cellFtDay.InnerHtml = WeekDays.ToString();
                                    rowContent1.Cells.Add(cellFtDay);


                                    HtmlTableCell cellGtDay = new HtmlTableCell();
                                    cellGtDay.Height = "22px";
                                    cellGtDay.Align = "center";
                                    cellGtDay.InnerHtml = WeekDays_gt.ToString();
                                    rowContent1.Cells.Add(cellGtDay);

                                    HtmlTableCell cellOther = new HtmlTableCell();
                                    cellOther.Height = "22px";
                                    cellOther.Align = "center";
                                    cellOther.InnerHtml = "<a href='Buy_fatieListShow.aspx?BoardID=" + str + "&uname=" +Server.UrlEncode(ViewState["UserName"].ToString()) + "&userType=" + Server.UrlEncode(postUserType) + "&action=2'><font color=#0000ff>�鿴����>></font></a>";
                                    TotalZt += Ztie;
                                    TotalGt += Gtie;
                                    TotalBest += BestPic;
                                    rowContent1.Cells.Add(cellOther);
                                    tb1.Rows.Add(rowContent1);
                                    #endregion
                                }
                                #region ���ܼ���(���ܷ���)
                                ///�ܼ�
                                HtmlTableRow rowZJ = new HtmlTableRow();
                                rowZJ.BgColor = "#F0F0F0";
                                rowZJ.Attributes.Add("class", "RowZJ");

                                HtmlTableCell cellBoardZJ = new HtmlTableCell();
                                cellBoardZJ.Height = "22px";
                                cellBoardZJ.Align = "center";
                                cellBoardZJ.InnerHtml = "�ܼ�";
                                rowZJ.Cells.Add(cellBoardZJ);


                                HtmlTableCell cellZtZJ = new HtmlTableCell();
                                cellZtZJ.Height = "22px";
                                cellZtZJ.Align = "center";
                                cellZtZJ.InnerHtml = TotalZt >= int.Parse(fatie) ? "<font color='#0000ff'><b>" + TotalZt + "</b></font>" : "<font color=red><b>" + TotalZt + "</b></font>";
                                rowZJ.Cells.Add(cellZtZJ);

                                //TotalGt > int.Parse(huitie) ? "<font color='#0000ff'><b>" + TotalGt + "</b></font>" : "<font color=red><b>" + TotalGt + "</b></font>";

                                HtmlTableCell cellGtZJ = new HtmlTableCell();
                                cellGtZJ.Height = "22px";
                                cellGtZJ.Align = "center";
                                cellGtZJ.InnerHtml = TotalGt > int.Parse(huitie) ? "<font color='#0000ff'><b>" + TotalGt + "</b></font>" : "<font color=red><b>" + TotalGt + "</b></font>";
                                rowZJ.Cells.Add(cellGtZJ);

                                //TotalBest >= int.Parse(S_MinBests) ? "<font color='#0000ff'><b>" + TotalBest + "</b></font>" : "<font color=red><b>" + TotalBest + "</b></font>";
                                HtmlTableCell cellJhZJ = new HtmlTableCell();
                                cellJhZJ.Height = "22px";
                                cellJhZJ.Align = "center";
                                // BestPic = ((int)row["BestTopicCount"]) + ((int)row["BestAnnounceCount"]);
                                cellJhZJ.InnerHtml = TotalBest >= int.Parse(S_MinBests) ? "<font color='#0000ff'><b>" + TotalBest + "</b></font>" : "<font color=red><b>" + TotalBest + "</b></font>";
                                rowZJ.Cells.Add(cellJhZJ);


                                HtmlTableCell cellFtDayZJ = new HtmlTableCell();
                                cellFtDayZJ.Height = "22px";
                                cellFtDayZJ.Align = "center";
                                cellFtDayZJ.InnerHtml = WeekDays_gt >= int.Parse(S_MinDays) ? "<font color='#0000ff'><b>" + WeekDays_gt + "</b></font>" : "<font color=red><b>" + WeekDays_gt + "</b><font>";
                                rowZJ.Cells.Add(cellFtDayZJ);


                                HtmlTableCell cellGtDayZJ = new HtmlTableCell();
                                cellGtDayZJ.Height = "22px";
                                cellGtDayZJ.Align = "center";
                                cellGtDayZJ.InnerHtml = WeekDays >= int.Parse(S_MinDays) ? "<font color='#0000ff'><b>" + WeekDays + "</b></font>" : "<font color=red><b>" + WeekDays + "</b><font>";
                                rowZJ.Cells.Add(cellGtDayZJ);

                                string useRetult = "";
                                if (TotalGt >= int.Parse(huitie) && TotalZt >= int.Parse(fatie) && TotalBest >= int.Parse(S_MinBests) && nPostDayCount >= int.Parse(S_MinDays))
                                {
                                    useRetult = "<img src='/images/web/dui.gif' width='24' height='20' border='0' title='����ʹ�������'>";
                                }
                                else
                                {
                                    useRetult = "<img src='/images/web/ca.gif' width='24' height='20' border='0' title='����ʹ�������'>";
                                }

                                HtmlTableCell cellOtherZJ = new HtmlTableCell();
                                cellOtherZJ.Height = "22px";
                                cellOtherZJ.Align = "center";
                                cellOtherZJ.InnerHtml = useRetult;
                                rowZJ.Cells.Add(cellOtherZJ);

                                this.tb1.Rows.Add(rowZJ);
                                #endregion

                                #region ������׼��(���ܷ���)
                                ///������׼
                                HtmlTableRow rowBZ = new HtmlTableRow();
                                rowBZ.BgColor = "#F0F0F0";
                                rowBZ.Attributes.Add("class", "rowBZ");
                                HtmlTableCell cellBoardBZ = new HtmlTableCell();
                                cellBoardBZ.Height = "22px";
                                cellBoardBZ.Align = "center";
                                cellBoardBZ.InnerHtml = "<b>������׼</b>";

                                rowBZ.Cells.Add(cellBoardBZ);

                                HtmlTableCell cellZtBZ = new HtmlTableCell();
                                cellZtBZ.Height = "22px";
                                cellZtBZ.Align = "center";
                                cellZtBZ.InnerHtml = fatie;

                                rowBZ.Cells.Add(cellZtBZ);

                                HtmlTableCell cellGtBZ = new HtmlTableCell();
                                cellGtBZ.Height = "22px";
                                cellGtBZ.Align = "center";
                                cellGtBZ.InnerHtml = huitie;
                                rowBZ.Cells.Add(cellGtBZ);

                                HtmlTableCell cellJhBZ = new HtmlTableCell();
                                cellJhBZ.Height = "22px";
                                cellJhBZ.Align = "center";
                                cellJhBZ.InnerHtml = S_MinBests;
                                rowBZ.Cells.Add(cellJhBZ);


                                HtmlTableCell cellFtDayBZ = new HtmlTableCell();
                                cellFtDayBZ.Height = "22px";
                                cellFtDayBZ.Align = "center";
                                cellFtDayBZ.InnerHtml = S_MinDays;

                                rowBZ.Cells.Add(cellFtDayBZ);

                                HtmlTableCell cellGtDayBZ = new HtmlTableCell();
                                cellGtDayBZ.Height = "22px";
                                cellGtDayBZ.Align = "center";
                                cellGtDayBZ.InnerHtml = S_MinDays;
                                rowBZ.Cells.Add(cellGtDayBZ);

                                HtmlTableCell cellOtherBZ = new HtmlTableCell();
                                cellOtherBZ.Height = "22px";
                                cellOtherBZ.Align = "center";
                                cellOtherBZ.InnerHtml = "<a href='/Buy_mianfei.htm'><font color=#0000ff>�鿴����>></font></a>";
                                rowBZ.Cells.Add(cellOtherBZ);
                                this.tb1.Rows.Add(rowBZ);


                                #endregion
                                //}
                            #endregion

                            }
                        #endregion
                        }
                    }
                    #endregion

                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "noData", "alert('���ݴ���');history.go(-1);");
                }            
               
            }
        }
        private void BindClass()
        {
            Pbzx.BLL.CstSoftware MyBLL = new Pbzx.BLL.CstSoftware();
            MyBLL.BindClass(ddlSoft);
        }

        protected void btnUp_Click(object sender, EventArgs e)
        {
            string  Class = this.ddlSoft.SelectedValue;
            string[] SI = Class.Split(new char[] {'-'});
            Server.Transfer("Buy_fatieList.aspx?UID="+this.txtName.Text+"&id=1&ST=" + SI[0] + "&IT=" + SI[1]);
        }

        protected void btnThis_Click(object sender, EventArgs e)
        {
            string Class = this.ddlSoft.SelectedValue;
            string[] SI = Class.Split(new char[] { '-' });
            Server.Transfer("Buy_fatieList.aspx?UID=" + this.txtName.Text + "&id=2&ST=" + SI[0] + "&IT=" + SI[1]);
        }
    }
  }
