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
using System.Collections.Generic;
using Pbzx.Common;
using System.Text;
using Maticsoft.DBUtility;


namespace Pbzx.Web.PB_Manage
{
    public partial class KJInfo_Manage : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();

            }
        }
        private void BindData()
        {
            Pbzx.BLL.PBnet_LotteryMenu LotteryMenuBLL = new Pbzx.BLL.PBnet_LotteryMenu();
            // List<Pbzx.Model.PBnet_LotteryMenu> ls = LotteryMenuBLL.GetLisBySql("select IntId,NvarName,NvarClass 1=1  group by NvarClass order by min(IntId)");
            DataTable dt = LotteryMenuBLL.GetLisBySql("select NvarClass from PBnet_LotteryMenu where  BitState=1 group by NvarClass order by min(IntClass_OrderId)");
            this.rptCpBigSort.DataSource = dt;
            this.rptCpBigSort.DataBind();
        }

        protected string FormartClass(object varclass)
        {
            Pbzx.BLL.PBnet_LotteryMenu lotteryBLL = new Pbzx.BLL.PBnet_LotteryMenu();
            Pbzx.BLL.PBnet_Module moduleBLL = new Pbzx.BLL.PBnet_Module();
            //����Ȩ��
            string tempIDS = DbHelperSQL.GetSingle("select top 1  Setting  from PBnet_tpman where Master_Name ='" + WebFunc.GetCurrentAdmin() + "'  ").ToString();
            string[] idsSZ = tempIDS.Split(new char[] { ',' });
            StringBuilder sbQX = new StringBuilder();
            foreach (string str in idsSZ)
            {
                if (!string.IsNullOrEmpty(str))
                {
                    Pbzx.Model.PBnet_Module module = moduleBLL.GetModel(int.Parse(str));
                    sbQX.Append("'" + module.Name + "',");
                }
            }
            if (sbQX.Length > 1)
            {
                sbQX.Remove(sbQX.Length - 1, 1);
            }
            //
            if (sbQX.ToString() == "")
            {
                sbQX.Append("0");
            }
            DataSet ds = lotteryBLL.GetList("NvarClass='" + varclass.ToString() + "' and  BitState=1  and NvarName in(" + sbQX.ToString() + ")  order by NvarOrderId ");
            CpSort mycpsort = null;
            StringBuilder sb = new StringBuilder("");
           


            if (ds.Tables.Count > 0)
            {
                List<Pbzx.Model.PBnet_LotteryMenu> lsLottery = lotteryBLL.DataTableToList(ds.Tables[0]);
                foreach (Pbzx.Model.PBnet_LotteryMenu model in lsLottery)
                {
                   
                    if (model.NvarClass == "ȫ������" || model.NvarClass == "ȫ�����")
                    {
                        mycpsort = new CpSort("\\xml\\QuanGuoCpDate.xml");
                    }
                    else if (model.NvarClass == "��ʡ����" || model.NvarClass == "��ʡ���")
                    {
                        mycpsort = new CpSort("\\xml\\GeShengCpDate.xml");
                    }
                    else
                    {
                        mycpsort = new CpSort("\\xml\\GaoPinCpDate.xml");
                    }
                    string s_font1 = "";
                    string s_font2 = "";
                    string s_lottdate = "";


                    string app_name = model.NvarApp_name;
                    //��������
                    string nvarName = model.NvarName;
                    if (nvarName == "������������")
                    {
                        nvarName = nvarName;
                    }
                    if (Input.IsInteger(nvarName.Substring(0, 1)))
                    {
                        nvarName = "_" + nvarName;
                    }
                    else if (nvarName.Contains("��"))
                    {
                        nvarName = nvarName.Replace("��", "X");
                    }
                    if (string.IsNullOrEmpty(nvarName))
                    {
                        nvarName = "";
                    }
                    string lott_date = model.NvarLott_date;

                    if (string.IsNullOrEmpty(lott_date))
                    {
                        lott_date = "";
                    }

                    //xml������ֿ���ʱ��
                    string xmlDate = mycpsort[nvarName].Lott_date;
                    if (app_name.Length != 0 && string.IsNullOrEmpty(xmlDate))
                    {
                        s_font1 = "<font color='#009900'>";
                        s_font2 = "</font>";
                    }
                    else if (app_name == "3D")//����3D
                    {
                        DateTime dtNow = DateTime.Now;
                        DateTime dt3DTest = DateTime.Parse(mycpsort["_3DTest"].Lott_date);
                        DateTime dt3D = DateTime.Parse(xmlDate);
                        DateTime dt3DTestVerify = DateTime.Parse(mycpsort["_3DTestVerify"].Lott_date);
                        DateTime dt3DMoney = DateTime.Parse(mycpsort["_3DMoney"].Lott_date);

                        //3D�Ի��ź͵�ǰʱ���
                        TimeSpan ts3DTest = dtNow - dt3DTest;
                        //3D�����ź͵�ǰʱ���
                        TimeSpan ts3D = dtNow - dt3D;
                        //3d�Ի�����֤�͵�ǰʱ���
                        TimeSpan ts3DTestVerify = dtNow - dt3DTestVerify;
                        //3d Money�͵�ǰʱ��� 
                        TimeSpan ts3DMoney = dtNow - dt3DMoney;


                        if ((ts3DTest.Hours > 22 && (dtNow.Hour == 18 && dtNow.Minute >= 24)) || (ts3D.Hours >= 2 && (dtNow.Hour == 20 && dtNow.Minute >= 26)))
                        {
                            s_font1 = "<font color='#ff0000'>";
                            s_font2 = "</font>";
                        }
                        else if ((ts3DTestVerify.Hours > 22 && (dtNow.Hour == 18 && dtNow.Minute >= 24)) || (ts3DMoney.Hours > 23 && (dtNow.Hour >= 21 && dtNow.Minute >= 25)))
                        {
                            s_font1 = "<font color='#9900ff'>";
                            s_font2 = "</font>";
                        }
                        else if ((ts3DTestVerify.Hours <= 1 && (dtNow.Hour == 18 && dtNow.Minute >= 24)) || (ts3D.Hours <= 1 && (dtNow.Hour == 20 && dtNow.Minute >= 32)))
                        {
                            s_font1 = "<font color='#0000ff'>";
                            s_font2 = "</font>";
                        }
                    }
                    else if (app_name.Length != 0 && app_name != "" && xmlDate != "")
                    {
                        //���������NvarLott_date�ֶΣ����һλ
                        string s_date = lott_date.Substring(lott_date.Length - 1);
                        //���������NvarLott_date�ֶΣ�����
                        int s_len = lott_date.Length;
                        //���������NvarLott_date�ֶΣ�
                        lott_date = lott_date.Substring(0, lott_date.Length - 1);

                        DateTime dtNow = DateTime.Now;
                        DateTime dtApp = DateTime.Parse(xmlDate);
                        //CpSort JiangXSscCpsort = new CpSort("\\xml\\GaoPinCpDate.xml");
                        //DateTime dtSSC_JiangX = DateTime.Parse(JiangXSscCpsort["����ʱʱ��"].Lott_date);
                        TimeSpan tsApp = dtNow - dtApp;
                        //TimeSpan tsSSC_JiangX = dtNow - dtSSC_JiangX;

                        if (s_date == "D" && lott_date == "0")
                        {
                            //��ɫ����δ¼��
                            if (tsApp.TotalHours > 23)
                            {
                                s_font1 = "<font color='#ff0000'>";
                                s_font2 = "</font>";
                            }//��ɫ����ո�¼��
                            else if (tsApp.TotalHours <= 1)
                            {
                                s_font1 = "<font color='#0000ff'>";
                                s_font2 = "</font>";
                            }//�����Ǻ�ɫ
                            else
                            {
                                s_font1 = "<font color='#000000'>";
                                s_font2 = "</font>";
                            }
                        }
                        else if (s_date == "D" && s_len > 1)
                        {
                            //����ʱ����(Сʱ)
                            int s_hour = 0;
                            int s_number = lott_date.IndexOf(Convert.ToString((int)dtApp.DayOfWeek + 1)) + 1;
                            if (s_number != -1)
                            {
                                if (s_number == lott_date.Length)
                                {
                                    s_hour = ((int.Parse(lott_date.Substring(0, 1))) + 7 - int.Parse((lott_date.Substring(lott_date.Length - 1)))) * 24 - 1;
                                }
                                else
                                {
                                    try
                                    {
                                        s_hour = ((int.Parse(lott_date.Substring(s_number, 1))) - (int.Parse(lott_date.Substring(s_number - 1, 1)))) * 24 - 1;
                                    }
                                    catch (Exception ex)
                                    {
                                        Response.Write("��ǰ������֣�" + model.NvarName + "���������Lott_date��" + model.NvarLott_date + "�����" + lott_date + "��s_number=" + s_number);
                                        Response.End();
                                    }
                                }
                                ///��ɫδ¼��
                                if (tsApp.TotalHours > s_hour)
                                {
                                    s_font1 = "<font color='#ff0000'>";
                                    s_font2 = "</font>";
                                }//��ɫ��¼��
                                else if (tsApp.TotalHours <= 1)
                                {
                                    s_font1 = "<font color='#0000ff'>";
                                    s_font2 = "</font>";
                                }
                                else
                                {
                                    s_font1 = "<font color='#000000'>";
                                    s_font2 = "</font>";
                                }
                            }
                            else
                            {
                                s_font1 = "<font color='#000000'>";
                                s_font2 = "</font>";
                            }
                            s_lottdate = "&lottdate=" + lott_date;
                        }
                        else if (s_date == "M" && s_len > 0)
                        {

                            string strList = model.TimeList;
                            string[] listCount = strList.Split(new char[] { '&' });
                            for (int i = 0; i < listCount.Length; i++)
                            {
                                if (!string.IsNullOrEmpty(listCount[i]) && listCount[i].Length > 1)
                                {
                                    string[] tmSZ = listCount[i].Split(new char[] { '|' });
                                    TimeSpan tsStart = new TimeSpan();
                                    TimeSpan tsEnd = new TimeSpan();
                                    TimeSpan tsJS = new TimeSpan();
                                    if (!TimeSpan.TryParse(tmSZ[0], out tsStart) || !TimeSpan.TryParse(tmSZ[1], out tsEnd) || !TimeSpan.TryParse(tmSZ[tmSZ.Length - 1], out tsJS))
                                    {
                                        //Response.Write("<script>alert('ʱ����������!')</script>");
                                    }
                                    else
                                    {
                                        int jg = 0;
                                        tsEnd.Subtract(tsStart);
                                        while (tsStart < tsEnd)
                                        {
                                            tsStart = tsStart.Add(TimeSpan.FromMinutes(1));
                                            jg++;
                                        }
                                        //�����������δ���
                                        if (tsStart < tsJS)
                                        {
                                            if (dtNow.TimeOfDay >= TimeSpan.Parse(tmSZ[0]) && dtNow.TimeOfDay <= TimeSpan.Parse(tmSZ[tmSZ.Length - 1]))
                                            {
                                                if (model.NvarName == "����481")
                                                {
                                                    if (tsApp.TotalMinutes > int.Parse(lott_date) * 1.4)
                                                    {
                                                        s_font1 = "<font color='#ff0000'>";
                                                        s_font2 = "</font>";
                                                    }
                                                    else if (tsApp.TotalMinutes < int.Parse(lott_date) * 0.5)
                                                    {
                                                        s_font1 = "<font color='#0000ff'>";
                                                        s_font2 = "</font>";
                                                    }
                                                    else
                                                    {
                                                        s_font1 = "<font color='#000000'>";
                                                        s_font2 = "</font>";
                                                    }
                                                    break;
                                                }
                                                if (tsApp.TotalMinutes > int.Parse(lott_date) * 1.4)
                                                {
                                                    s_font1 = "<font color='#ff0000'>";
                                                    s_font2 = "</font>";
                                                }
                                                else if (tsApp.TotalMinutes < int.Parse(lott_date) * 0.5)
                                                {
                                                    s_font1 = "<font color='#0000ff'>";
                                                    s_font2 = "</font>";
                                                }
                                                else
                                                {
                                                    s_font1 = "<font color='#000000'>";
                                                    s_font2 = "</font>";
                                                }
                                                break;
                                            }
                                            else
                                            {
                                                s_font1 = "<font color='#000000'>";
                                                s_font2 = "</font>";
                                            }
                                        }
                                        else
                                        {
                                            if ((dtNow.TimeOfDay >= TimeSpan.Parse(tmSZ[0]) && dtNow.TimeOfDay <= TimeSpan.Parse("23:59:59")) || (dtNow.TimeOfDay >= TimeSpan.Parse("00:00:01") && dtNow.TimeOfDay <= TimeSpan.Parse(tmSZ[tmSZ.Length - 1])))
                                            {
                                                if (tsApp.TotalMinutes > int.Parse(lott_date) * 1.4)
                                                {
                                                    s_font1 = "<font color='#ff0000'>";
                                                    s_font2 = "</font>";
                                                }
                                                else if (tsApp.TotalMinutes < int.Parse(lott_date) * 0.5)
                                                {
                                                    s_font1 = "<font color='#0000ff'>";
                                                    s_font2 = "</font>";
                                                }
                                                else
                                                {
                                                    s_font1 = "<font color='#000000'>";
                                                    s_font2 = "</font>";
                                                }
                                                break;
                                            }
                                            else
                                            {
                                                s_font1 = "<font color='#000000'>";
                                                s_font2 = "</font>";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else if (s_date == "H" && s_len > 1)
                        {
                            if (tsApp.TotalHours >= int.Parse(lott_date))
                            {
                                s_font1 = "<font color='#ff0000'>";
                                s_font2 = "</font>";
                            }
                            else if (tsApp.TotalHours <= 1)
                            {
                                s_font1 = "<font color='#0000ff'>";
                                s_font2 = "</font>";
                            }
                            else
                            {
                                s_font1 = "<font color='#000000'>";
                                s_font2 = "</font>";
                            }
                        }
                    }

                    if (!model.IsRefresh)
                    {
                        s_font1 = "<font color='#9370db'>";
                        s_font2 = "</font>";
                    }

                    Object objLottDate = model.NvarLott_date;
                    string strLottDate = "";
                    if (objLottDate != null)
                    {
                        strLottDate = objLottDate.ToString();
                        if (strLottDate.Length > 1)
                        {
                            strLottDate = strLottDate.Substring(0, strLottDate.Length - 1);
                        }
                    }
                    string strTemp = "<a href='" + model.Url + "?city=" + model.NvarApp_name + "&lottdate=" + strLottDate + "'  target='ShowPage1' >";
                    strTemp += s_font1;
                    strTemp += model.NvarName;
                    strTemp += s_font2;
                    strTemp += "</a>&nbsp;|&nbsp;";
                    sb.Append(strTemp);
                }
            }
            return sb.ToString();
        }



        protected void lbtnUpdateIndex_Click(object sender, EventArgs e)
        {
            Application.Lock();
            Application["FC3DData"] = "false";
            Application["TCPL35Data"] = "false";
            Application["WeiXin_MoNiTestCode"] = "false";
            Application["TC7XCData_New"] = "false";
            Application["FC7LC"] = "false";
            Application["FCSSData"] = "false";
            Application["TCDLTData"] = "false";
            Application["FCKL8Data"] = "false";
//            Application["TC22X5Data"] = "false";
//            Application["TC31X7Data"] = "false";
            Application.UnLock();
            //������ҳ��������
            Server.Execute("/PB_Manage/RefurbishCpXml.aspx");
        }

        protected void lbtnQG_Click(object sender, EventArgs e)
        {
            Application.Lock();
            Application["FC3DData"] = "false";
            Application["TCPL35Data"] = "false";
            Application["WeiXin_MoNiTestCode"] = "false";
            Application["TC7XCData_New"] = "false";
            Application["FC7LC"] = "false";
            Application["FCSSData"] = "false";
            Application["TCDLTData"] = "false";
            Application["FCKL8Data"] = "false";
//            Application["TC22X5Data"] = "false";
//            Application["TC31X7Data"] = "false";
            Application.UnLock();
            //����xml��������
            Server.Execute("/PB_Manage/RefurbishCpXml.aspx?cpType=quanguo");
        }

        protected void lbtnGS_Click(object sender, EventArgs e)
        {
            Server.Execute("/PB_Manage/RefurbishCpXml.aspx?cpType=gesheng");
        }

        protected void lbtnGP_Click(object sender, EventArgs e)
        {
            Server.Execute("/PB_Manage/RefurbishCpXml.aspx?cpType=gaopin");
        }

    }
}






