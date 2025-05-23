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
using System.Xml;
using Maticsoft.DBUtility;
using Pbzx.Common;
using System.IO;

namespace Pbzx.Web.PB_Manage
{
    public partial class RefurbishCpXml : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string parm1 = Input.FilterAll(Request["cpType"]);
                if (string.IsNullOrEmpty(parm1))
                {
                    CreateQuanGuo("");
                    CreateGeSheng("");
                    CreateGaoPin("");
                }
                else
                {
                    MyBindData(parm1);
                }
            }
        }

        /// <summary>
        /// ������
        /// </summary>
        /// <param name="type">��Ʊ����</param>
        private void MyBindData(string type)
        {
            switch(type)
            {
                case "quanbu":
                    CreateQuanGuo("");
                    CreateGeSheng("");
                    CreateGaoPin("");
                    break;
                case "quanguo":
                    CreateQuanGuo("");
                    break;
                case "gesheng":
                    CreateGeSheng("");
                    break;
                case "gaopin":
                    CreateGaoPin("");
                    break;
                default:
                    object objResult = DbHelperSQL.GetSingle(" select top 1 NvarClass from PBnet_LotteryMenu where BitIs_show=1 and  NvarApp_name='" + type + "'  ");
                    if (objResult != null && !string.IsNullOrEmpty(objResult.ToString()))
                    {
                        string classType = objResult.ToString();
                        if (classType == "ȫ������" || classType == "ȫ�����")
                        {
                            CreateQuanGuo(type);
                        }
                        else if (classType == "��ʡ����" || classType == "��ʡ���")
                        {
                            CreateGeSheng(type);
                        }
                        else
                        {
                            CreateGaoPin(type);
                        }
                    }
                    break;

            }
        }

        #region ��ǰ
        //public void BindData(string cpType)
        //{
        //    Pbzx.Common.MyXML xml = new Pbzx.Common.MyXML("\\xml\\CpSortTime.xml");
        //    XmlNode root = xml.GetXmlRoot();
        //    if (cpType == "quanbu")
        //    {
        //        Pbzx.BLL.PBnet_LotteryMenu lottBLL = new Pbzx.BLL.PBnet_LotteryMenu();
        //        DataTable dt = lottBLL.GetList(" BitIs_show=1 order by IntClass_OrderId,NvarOrderId ").Tables[0];
        //        if (dt.Rows.Count < 1)
        //        {
        //            return;
        //        }
        //        XmlNode QGFC = root.SelectSingleNode("/CpSort/QGFC");
        //        QGFC.RemoveAll();
        //        XmlNode QGTC = root.SelectSingleNode("/CpSort/QGTC");
        //        QGTC.RemoveAll();
        //        XmlNode GSFC = root.SelectSingleNode("/CpSort/GSFC");
        //        GSFC.RemoveAll();
        //        XmlNode GSTC = root.SelectSingleNode("/CpSort/GSTC");
        //        GSTC.RemoveAll();
        //        XmlNode GPFC = root.SelectSingleNode("/CpSort/GPFC");
        //        GPFC.RemoveAll();
        //        XmlNode GPTC = root.SelectSingleNode("/CpSort/GPTC");
        //        GPTC.RemoveAll();
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            string type = row["NvarClass"].ToString();
        //            string nvarName = row["NvarName"].ToString();
        //            if (Input.IsInteger(nvarName.Substring(0, 1)))
        //            {
        //                nvarName = "_" + nvarName;
        //            }
        //            else if (nvarName.Contains("��"))
        //            {
        //                nvarName = nvarName.Replace("��", "X");
        //            }
        //            //  nvarName = nvarName.Replace("\r\n", "");
        //            DataTable dtWeb = DbHelperSQL1.Query("select top 1 * from " + row["NvarApp_name"].ToString() + " order by issue desc").Tables[0];
        //            if (dtWeb.Rows.Count < 1 )
        //            {
        //                return;
        //            }
        //                switch (type)
        //                {
        //                    case "ȫ������":
        //                        xml.AddChildNode("/CpSort/" + QGFC.Name, nvarName);
        //                        // XmlNode temp = QGFC.SelectSingleNode("./" +nvarName);
        //                        xml.AddAttribute("/CpSort/QGFC/" + nvarName, "name", row["NvarName"].ToString());
        //                        xml.AddAttribute("/CpSort/QGFC/" + nvarName, "issue", dtWeb.Rows[0]["issue"].ToString());
        //                        if ("FCSSData" == row["NvarApp_name"].ToString())
        //                        {
        //                            xml.AddAttribute("/CpSort/QGFC/" + nvarName, "code", "");
        //                            xml.AddAttribute("/CpSort/QGFC/" + nvarName, "redcode", dtWeb.Rows[0]["redcode"].ToString());
        //                            xml.AddAttribute("/CpSort/QGFC/" + nvarName, "bluecode", dtWeb.Rows[0]["bluecode"].ToString());
        //                            if (dtWeb.Rows[0]["bluecode2"] != null)
        //                            {
        //                                xml.AddAttribute("/CpSort/QGFC/" + nvarName, "bluecode2", dtWeb.Rows[0]["bluecode2"].ToString());
        //                            }
        //                        }
        //                        else if ("FC3DData" == row["NvarApp_name"].ToString())
        //                        {
        //                            string[] result = CalGZM();
        //                            string cstJin = result[0];
        //                            string HL1 = result[1];
        //                            string HL2 = result[2];
        //                            string deTestCode = result[3];
        //                            xml.AddAttribute("/CpSort/QGFC/" + nvarName, "code", dtWeb.Rows[0]["code"].ToString());
        //                            xml.AddAttribute("/CpSort/QGFC/" + nvarName, "testcode", dtWeb.Rows[0]["testcode"].ToString());
        //                            xml.AddAttribute("/CpSort/QGFC/" + nvarName, "machine", dtWeb.Rows[0]["machine"].ToString());
        //                            xml.AddAttribute("/CpSort/QGFC/" + nvarName, "ball", dtWeb.Rows[0]["ball"].ToString());
        //                            xml.AddAttribute("/CpSort/QGFC/" + nvarName, "decode", deTestCode);
        //                            xml.AddAttribute("/CpSort/QGFC/" + nvarName, "Jin", cstJin);
        //                            xml.AddAttribute("/CpSort/QGFC/" + nvarName, "HL1", HL1);
        //                            xml.AddAttribute("/CpSort/QGFC/" + nvarName, "HL2", HL2);
        //                        }
        //                        else
        //                        {
        //                            xml.AddAttribute("/CpSort/QGFC/" + nvarName, "code", dtWeb.Rows[0]["code"].ToString());
        //                        }
        //                        if (dtWeb.Columns.Contains("tcode"))
        //                        {
        //                            if (dtWeb.Rows[0]["tcode"] != null)
        //                            {
        //                                xml.AddAttribute("/CpSort/QGFC/" + nvarName, "tcode", dtWeb.Rows[0]["tcode"].ToString());
        //                            }
        //                            else
        //                            {
        //                                xml.AddAttribute("/CpSort/QGFC/" + nvarName, "tcode", "");
        //                            }
        //                        }
        //                        else
        //                        {
        //                            xml.AddAttribute("/CpSort/QGFC/" + nvarName, "tcode", "");
        //                        }
        //                        xml.AddAttribute("/CpSort/QGFC/" + nvarName, "date",Convert.ToDateTime(dtWeb.Rows[0]["date"]).ToShortDateString()+" 20:30:00");
        //                        xml.AddAttribute("/CpSort/QGFC/" + nvarName, "lott_date", row["NvarLott_date"].ToString());
        //                        xml.AddAttribute("/CpSort/QGFC/" + nvarName, "app", row["NvarApp_name"].ToString());
        //                        Files.Create("/pb_cst.html", "/Template/Fc3DGZM.aspx");
        //                        break;
        //                    case "ȫ�����":
        //                        xml.AddChildNode("/CpSort/" + QGTC.Name, nvarName);
        //                        // 
        //                        xml.AddAttribute("/CpSort/QGTC/" + nvarName, "name", row["NvarName"].ToString());
        //                        xml.AddAttribute("/CpSort/QGTC/" + nvarName, "issue", dtWeb.Rows[0]["issue"].ToString());

        //                        if ("TCPL35Data" == row["NvarApp_name"].ToString())
        //                        {
        //                            xml.AddAttribute("/CpSort/QGTC/" + nvarName, "code", "");
        //                            xml.AddAttribute("/CpSort/QGTC/" + nvarName, "code3", dtWeb.Rows[0]["code3"].ToString());
        //                            xml.AddAttribute("/CpSort/QGTC/" + nvarName, "code5", dtWeb.Rows[0]["code5"].ToString());
        //                        }
        //                        else
        //                        {
        //                            xml.AddAttribute("/CpSort/QGTC/" + nvarName, "code", dtWeb.Rows[0]["code"].ToString());
        //                            if (dtWeb.Columns.Contains("tcode"))
        //                            {
        //                                if (dtWeb.Rows[0]["tcode"] != null)
        //                                {
        //                                    xml.AddAttribute("/CpSort/QGTC/" + nvarName, "tcode", dtWeb.Rows[0]["tcode"].ToString());
        //                                }
        //                                else
        //                                {
        //                                    xml.AddAttribute("/CpSort/QGTC/" + nvarName, "tcode", "");
        //                                }
        //                            }
        //                            else
        //                            {
        //                                xml.AddAttribute("/CpSort/QGTC/" + nvarName, "tcode", "");
        //                            }
        //                            ///
        //                            if ("TCDLTData" == row["NvarApp_name"].ToString())
        //                            {
        //                                xml.AddAttribute("/CpSort/QGTC/" + nvarName, "code2", dtWeb.Rows[0]["code2"].ToString());
        //                            }
        //                        }

        //                        xml.AddAttribute("/CpSort/QGTC/" + nvarName, "date", Convert.ToDateTime(dtWeb.Rows[0]["date"]).ToShortDateString() + " 20:30:00");
        //                        xml.AddAttribute("/CpSort/QGTC/" + nvarName, "lott_date", row["NvarLott_date"].ToString());
        //                        xml.AddAttribute("/CpSort/QGTC/" + nvarName, "app", row["NvarApp_name"].ToString());

        //                        break;
        //                    case "��ʡ����":

        //                        xml.AddChildNode("/CpSort/" + GSFC.Name, nvarName);
        //                        xml.AddAttribute("/CpSort/GSFC/" + nvarName, "name", row["NvarName"].ToString());
        //                        xml.AddAttribute("/CpSort/GSFC/" + nvarName, "issue", dtWeb.Rows[0]["issue"].ToString());
        //                        xml.AddAttribute("/CpSort/GSFC/" + nvarName, "code", dtWeb.Rows[0]["code"].ToString());
        //                        if (dtWeb.Columns.Contains("tcode"))
        //                        {
        //                            if (dtWeb.Rows[0]["tcode"] != null)
        //                            {
        //                                xml.AddAttribute("/CpSort/GSFC/" + nvarName, "tcode", dtWeb.Rows[0]["tcode"].ToString());
        //                            }
        //                            else
        //                            {
        //                                xml.AddAttribute("/CpSort/GSFC/" + nvarName, "tcode", "");
        //                            }
        //                        }
        //                        else
        //                        {
        //                            xml.AddAttribute("/CpSort/GSFC/" + nvarName, "tcode", "");
        //                        }
        //                        xml.AddAttribute("/CpSort/GSFC/" + nvarName, "date", Convert.ToDateTime(dtWeb.Rows[0]["date"]).ToShortDateString() + " 20:30:00");
        //                        xml.AddAttribute("/CpSort/GSFC/" + nvarName, "lott_date", row["NvarLott_date"].ToString());
        //                        xml.AddAttribute("/CpSort/GSFC/" + nvarName, "app", row["NvarApp_name"].ToString());

        //                        break;
        //                    case "��ʡ���":

        //                        xml.AddChildNode("/CpSort/" + GSTC.Name, nvarName);
        //                        xml.AddAttribute("/CpSort/GSTC/" + nvarName, "name", row["NvarName"].ToString());
        //                        xml.AddAttribute("/CpSort/GSTC/" + nvarName, "issue", dtWeb.Rows[0]["issue"].ToString());
        //                        xml.AddAttribute("/CpSort/GSTC/" + nvarName, "code", dtWeb.Rows[0]["code"].ToString());
        //                        if (dtWeb.Columns.Contains("tcode"))
        //                        {
        //                            if (dtWeb.Rows[0]["tcode"] != null)
        //                            {
        //                                xml.AddAttribute("/CpSort/GSTC/" + nvarName, "tcode", dtWeb.Rows[0]["tcode"].ToString());
        //                            }
        //                            else
        //                            {
        //                                xml.AddAttribute("/CpSort/GSTC/" + nvarName, "tcode", "");
        //                            }
        //                        }
        //                        else
        //                        {
        //                            xml.AddAttribute("/CpSort/GSTC/" + nvarName, "tcode", "");
        //                        }
        //                        xml.AddAttribute("/CpSort/GSTC/" + nvarName, "date", Convert.ToDateTime(dtWeb.Rows[0]["date"]).ToShortDateString() + " 20:30:00");
        //                        xml.AddAttribute("/CpSort/GSTC/" + nvarName, "lott_date", row["NvarLott_date"].ToString());
        //                        xml.AddAttribute("/CpSort/GSTC/" + nvarName, "app", row["NvarApp_name"].ToString());

        //                        break;
        //                    case "��Ƶ����":

        //                        xml.AddChildNode("/CpSort/" + GPFC.Name, nvarName);


        //                        xml.AddAttribute("/CpSort/GPFC/" + nvarName, "name", row["NvarName"].ToString());
        //                        xml.AddAttribute("/CpSort/GPFC/" + nvarName, "issue", dtWeb.Rows[0]["issue"].ToString());
        //                        xml.AddAttribute("/CpSort/GPFC/" + nvarName, "code", dtWeb.Rows[0]["code"].ToString());
        //                        if (dtWeb.Columns.Contains("tcode"))
        //                        {
        //                            if (dtWeb.Rows[0]["tcode"] != null)
        //                            {
        //                                xml.AddAttribute("/CpSort/GPFC/" + nvarName, "tcode", dtWeb.Rows[0]["tcode"].ToString());
        //                            }
        //                            else
        //                            {
        //                                xml.AddAttribute("/CpSort/GPFC/" + nvarName, "tcode", "");
        //                            }
        //                        }
        //                        else
        //                        {
        //                            xml.AddAttribute("/CpSort/GPFC/" + nvarName, "tcode", "");
        //                        }
        //                        xml.AddAttribute("/CpSort/GPFC/" + nvarName, "date", dtWeb.Rows[0]["date"].ToString());
        //                        xml.AddAttribute("/CpSort/GPFC/" + nvarName, "lott_date", row["NvarLott_date"].ToString());
        //                        xml.AddAttribute("/CpSort/GPFC/" + nvarName, "app", row["NvarApp_name"].ToString());
        //                        break;
        //                    case "��Ƶ���":
        //                        xml.AddChildNode("/CpSort/" + GPTC.Name, nvarName);
        //                        xml.AddAttribute("/CpSort/GPTC/" + nvarName, "name", row["NvarName"].ToString());
        //                        xml.AddAttribute("/CpSort/GPTC/" + nvarName, "issue", dtWeb.Rows[0]["issue"].ToString());
        //                        xml.AddAttribute("/CpSort/GPTC/" + nvarName, "code", dtWeb.Rows[0]["code"].ToString());
        //                        if (dtWeb.Columns.Contains("tcode"))
        //                        {
        //                            if (dtWeb.Rows[0]["tcode"] != null)
        //                            {
        //                                xml.AddAttribute("/CpSort/GPTC/" + nvarName, "tcode", dtWeb.Rows[0]["tcode"].ToString());
        //                            }
        //                            else
        //                            {
        //                                xml.AddAttribute("/CpSort/GPTC/" + nvarName, "tcode", "");
        //                            }
        //                        }
        //                        else
        //                        {
        //                            xml.AddAttribute("/CpSort/GPTC/" + nvarName, "tcode", "");
        //                        }
        //                        xml.AddAttribute("/CpSort/GPTC/" + nvarName, "date", dtWeb.Rows[0]["date"].ToString());
        //                        xml.AddAttribute("/CpSort/GPTC/" + nvarName, "lott_date", row["NvarLott_date"].ToString());
        //                        xml.AddAttribute("/CpSort/GPTC/" + nvarName, "app", row["NvarApp_name"].ToString());
        //                        break;
        //                }
                    
        //        }
        //    }
        //    else if(cpType =="quanguo")
        //    {
        //        Pbzx.BLL.PBnet_LotteryMenu lottBLL = new Pbzx.BLL.PBnet_LotteryMenu();   
        //        DataTable dt = null;     
        //        dt = lottBLL.GetList(" BitIs_show=1 and (NvarClass='ȫ������' or  NvarClass='ȫ�����')    order by IntClass_OrderId,NvarOrderId  ").Tables[0];//and (NvarClass='ȫ������' or  NvarClass='ȫ�����') 
        //        if (dt.Rows.Count < 1)
        //        {
        //            return;
        //        }
        //        XmlNode QGFC = root.SelectSingleNode("/CpSort/QGFC");
        //        QGFC.RemoveAll();
        //        XmlNode QGTC = root.SelectSingleNode("/CpSort/QGTC");
        //        QGTC.RemoveAll();
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            string type = row["NvarClass"].ToString();
        //            string nvarName = row["NvarName"].ToString();
        //            if (Input.IsInteger(nvarName.Substring(0, 1)))
        //            {
        //                nvarName = "_" + nvarName;
        //            }
        //            else if (nvarName.Contains("��"))
        //            {
        //                nvarName = nvarName.Replace("��", "X");
        //            }
        //            //  nvarName = nvarName.Replace("\r\n", "");
        //            DataTable dtWeb = DbHelperSQL1.Query("select top 1 * from " + row["NvarApp_name"].ToString() + " order by issue desc").Tables[0];
        //            if (dtWeb.Rows.Count < 1)
        //            {
        //                return;
        //            }
        //            switch (type)
        //            {
        //                case "ȫ������":
        //                    xml.AddChildNode("/CpSort/" + QGFC.Name, nvarName);
        //                    // XmlNode temp = QGFC.SelectSingleNode("./" +nvarName);
        //                    xml.AddAttribute("/CpSort/QGFC/" + nvarName, "name", row["NvarName"].ToString());
        //                    xml.AddAttribute("/CpSort/QGFC/" + nvarName, "issue", dtWeb.Rows[0]["issue"].ToString());
        //                    if ("FCSSData" == row["NvarApp_name"].ToString())
        //                    {
        //                        xml.AddAttribute("/CpSort/QGFC/" + nvarName, "code", "");
        //                        xml.AddAttribute("/CpSort/QGFC/" + nvarName, "redcode", dtWeb.Rows[0]["redcode"].ToString());
        //                        xml.AddAttribute("/CpSort/QGFC/" + nvarName, "bluecode", dtWeb.Rows[0]["bluecode"].ToString());
        //                        if (dtWeb.Rows[0]["bluecode2"] != null)
        //                        {
        //                            xml.AddAttribute("/CpSort/QGFC/" + nvarName, "bluecode2", dtWeb.Rows[0]["bluecode2"].ToString());
        //                        }
        //                    }
        //                    else if ("FC3DData" == row["NvarApp_name"].ToString())
        //                    {
        //                        string[] result = CalGZM();
        //                        string cstJin = result[0];
        //                        string HL1 = result[1];
        //                        string HL2 = result[2];
        //                        string deTestCode = result[3];
        //                        xml.AddAttribute("/CpSort/QGFC/" + nvarName, "code", dtWeb.Rows[0]["code"].ToString());
        //                        xml.AddAttribute("/CpSort/QGFC/" + nvarName, "testcode", dtWeb.Rows[0]["testcode"].ToString());
        //                        xml.AddAttribute("/CpSort/QGFC/" + nvarName, "machine", dtWeb.Rows[0]["machine"].ToString());
        //                        xml.AddAttribute("/CpSort/QGFC/" + nvarName, "ball", dtWeb.Rows[0]["ball"].ToString());
        //                        xml.AddAttribute("/CpSort/QGFC/" + nvarName, "decode", deTestCode);
        //                        xml.AddAttribute("/CpSort/QGFC/" + nvarName, "Jin", cstJin);
        //                        xml.AddAttribute("/CpSort/QGFC/" + nvarName, "HL1", HL1);
        //                        xml.AddAttribute("/CpSort/QGFC/" + nvarName, "HL2", HL2);
        //                    }
        //                    else
        //                    {
        //                        xml.AddAttribute("/CpSort/QGFC/" + nvarName, "code", dtWeb.Rows[0]["code"].ToString());
        //                    }
        //                    if (dtWeb.Columns.Contains("tcode"))
        //                    {
        //                        if (dtWeb.Rows[0]["tcode"] != null)
        //                        {
        //                            xml.AddAttribute("/CpSort/QGFC/" + nvarName, "tcode", dtWeb.Rows[0]["tcode"].ToString());
        //                        }
        //                        else
        //                        {
        //                            xml.AddAttribute("/CpSort/QGFC/" + nvarName, "tcode", "");
        //                        }
        //                    }
        //                    else
        //                    {
        //                        xml.AddAttribute("/CpSort/QGFC/" + nvarName, "tcode", "");
        //                    }
        //                    xml.AddAttribute("/CpSort/QGFC/" + nvarName, "date", Convert.ToDateTime(dtWeb.Rows[0]["date"]).ToShortDateString() + " 20:30:00");
        //                    xml.AddAttribute("/CpSort/QGFC/" + nvarName, "lott_date", row["NvarLott_date"].ToString());
        //                    xml.AddAttribute("/CpSort/QGFC/" + nvarName, "app", row["NvarApp_name"].ToString());
        //                    Files.Create("/pb_cst.html", "/Template/Fc3DGZM.aspx");
        //                    break;
        //                case "ȫ�����":
        //                    xml.AddChildNode("/CpSort/" + QGTC.Name, nvarName);
        //                    // 
        //                    xml.AddAttribute("/CpSort/QGTC/" + nvarName, "name", row["NvarName"].ToString());
        //                    xml.AddAttribute("/CpSort/QGTC/" + nvarName, "issue", dtWeb.Rows[0]["issue"].ToString());

        //                    if ("TCPL35Data" == row["NvarApp_name"].ToString())
        //                    {
        //                        xml.AddAttribute("/CpSort/QGTC/" + nvarName, "code", "");
        //                        xml.AddAttribute("/CpSort/QGTC/" + nvarName, "code3", dtWeb.Rows[0]["code3"].ToString());
        //                        xml.AddAttribute("/CpSort/QGTC/" + nvarName, "code5", dtWeb.Rows[0]["code5"].ToString());
        //                    }
        //                    else
        //                    {
        //                        xml.AddAttribute("/CpSort/QGTC/" + nvarName, "code", dtWeb.Rows[0]["code"].ToString());
        //                        if (dtWeb.Columns.Contains("tcode"))
        //                        {
        //                            if (dtWeb.Rows[0]["tcode"] != null)
        //                            {
        //                                xml.AddAttribute("/CpSort/QGTC/" + nvarName, "tcode", dtWeb.Rows[0]["tcode"].ToString());
        //                            }
        //                            else
        //                            {
        //                                xml.AddAttribute("/CpSort/QGTC/" + nvarName, "tcode", "");
        //                            }
        //                        }
        //                        else
        //                        {
        //                            xml.AddAttribute("/CpSort/QGTC/" + nvarName, "tcode", "");
        //                        }
        //                        ///
        //                        if ("TCDLTData" == row["NvarApp_name"].ToString())
        //                        {
        //                            xml.AddAttribute("/CpSort/QGTC/" + nvarName, "code2", dtWeb.Rows[0]["code2"].ToString());
        //                        }
        //                    }

        //                    xml.AddAttribute("/CpSort/QGTC/" + nvarName, "date", Convert.ToDateTime(dtWeb.Rows[0]["date"]).ToShortDateString() + " 20:30:00");
        //                    xml.AddAttribute("/CpSort/QGTC/" + nvarName, "lott_date", row["NvarLott_date"].ToString());
        //                    xml.AddAttribute("/CpSort/QGTC/" + nvarName, "app", row["NvarApp_name"].ToString());

        //                    break;
        //            }
        //        }               
        //    }
        //    else
        //    {
        //        Pbzx.BLL.PBnet_LotteryMenu lottBLL = new Pbzx.BLL.PBnet_LotteryMenu();
        //        DataTable dt = DbHelperSQL.Query(" select top 1 * from PBnet_LotteryMenu where NvarApp_name='"+cpType+"'  ").Tables[0];
        //        if (dt.Rows.Count < 1)
        //        {
        //            return;
        //        }
        //        DataRow row = dt.Rows[0];
        //        string type = row["NvarClass"].ToString();
        //        string nvarName = row["NvarName"].ToString();
        //        if (Input.IsInteger(nvarName.Substring(0, 1)))
        //        {
        //            nvarName = "_" + nvarName;
        //        }
        //        else if (nvarName.Contains("��"))
        //        {
        //            nvarName = nvarName.Replace("��", "X");
        //        }
        //        DataTable dtWeb = DbHelperSQL1.Query("select top 1 * from " + row["NvarApp_name"].ToString() + " order by issue desc").Tables[0];
        //        if (dtWeb.Rows.Count < 1)
        //        {
        //            return;
        //        }
        //        switch (type)
        //        {
        //            case "ȫ������":
        //                XmlNode QGFCitem = root.SelectSingleNode("/CpSort/QGFC/"+nvarName);                        
        //                QGFCitem.Attributes.RemoveAll();
        //                xml.AddAttribute("/CpSort/QGFC/" + nvarName, "name", row["NvarName"].ToString());
        //                xml.AddAttribute("/CpSort/QGFC/" + nvarName, "issue", dtWeb.Rows[0]["issue"].ToString());
        //                if ("FCSSData" == row["NvarApp_name"].ToString())
        //                {
        //                    xml.AddAttribute("/CpSort/QGFC/" + nvarName, "code", "");
        //                    xml.AddAttribute("/CpSort/QGFC/" + nvarName, "redcode", dtWeb.Rows[0]["redcode"].ToString());
        //                    xml.AddAttribute("/CpSort/QGFC/" + nvarName, "bluecode", dtWeb.Rows[0]["bluecode"].ToString());
        //                    if (dtWeb.Rows[0]["bluecode2"] != null)
        //                    {
        //                        xml.AddAttribute("/CpSort/QGFC/" + nvarName, "bluecode2", dtWeb.Rows[0]["bluecode2"].ToString());
        //                    }
        //                }
        //                else if ("FC3DData" == row["NvarApp_name"].ToString())
        //                {
        //                    string[] result = CalGZM();
        //                    string cstJin = result[0];
        //                    string HL1 = result[1];
        //                    string HL2 = result[2];
        //                    string deTestCode = result[3];
        //                    xml.AddAttribute("/CpSort/QGFC/" + nvarName, "code", dtWeb.Rows[0]["code"].ToString());
        //                    xml.AddAttribute("/CpSort/QGFC/" + nvarName, "testcode", dtWeb.Rows[0]["testcode"].ToString());
        //                    xml.AddAttribute("/CpSort/QGFC/" + nvarName, "machine", dtWeb.Rows[0]["machine"].ToString());
        //                    xml.AddAttribute("/CpSort/QGFC/" + nvarName, "ball", dtWeb.Rows[0]["ball"].ToString());
        //                    xml.AddAttribute("/CpSort/QGFC/" + nvarName, "decode", deTestCode);
        //                    xml.AddAttribute("/CpSort/QGFC/" + nvarName, "Jin", cstJin);
        //                    xml.AddAttribute("/CpSort/QGFC/" + nvarName, "HL1", HL1);
        //                    xml.AddAttribute("/CpSort/QGFC/" + nvarName, "HL2", HL2);
                          
        //                }
        //                else
        //                {
        //                    xml.AddAttribute("/CpSort/QGFC/" + nvarName, "code", dtWeb.Rows[0]["code"].ToString());
        //                }
        //                if (dtWeb.Columns.Contains("tcode"))
        //                {
        //                    if (dtWeb.Rows[0]["tcode"] != null)
        //                    {
        //                        xml.AddAttribute("/CpSort/QGFC/" + nvarName, "tcode", dtWeb.Rows[0]["tcode"].ToString());
        //                    }
        //                    else
        //                    {
        //                        xml.AddAttribute("/CpSort/QGFC/" + nvarName, "tcode", "");
        //                    }
        //                }
        //                else
        //                {
        //                    xml.AddAttribute("/CpSort/QGFC/" + nvarName, "tcode", "");
        //                }
        //                xml.AddAttribute("/CpSort/QGFC/" + nvarName, "date", Convert.ToDateTime(dtWeb.Rows[0]["date"]).ToShortDateString() + " 20:30:00");
        //                xml.AddAttribute("/CpSort/QGFC/" + nvarName, "lott_date", row["NvarLott_date"].ToString());
        //                xml.AddAttribute("/CpSort/QGFC/" + nvarName, "app", row["NvarApp_name"].ToString());
        //                Files.Create("/pb_cst.html", "/Template/Fc3DGZM.aspx");
        //                break;
        //            case "ȫ�����":
        //                XmlNode QGTCitem = root.SelectSingleNode("/CpSort/QGTC/" + nvarName);
        //                QGTCitem.Attributes.RemoveAll();
        //                xml.AddAttribute("/CpSort/QGTC/" + nvarName, "name", row["NvarName"].ToString());
        //                xml.AddAttribute("/CpSort/QGTC/" + nvarName, "issue", dtWeb.Rows[0]["issue"].ToString());

        //                if ("TCPL35Data" == row["NvarApp_name"].ToString())
        //                {
        //                    xml.AddAttribute("/CpSort/QGTC/" + nvarName, "code", "");
        //                    xml.AddAttribute("/CpSort/QGTC/" + nvarName, "code3", dtWeb.Rows[0]["code3"].ToString());
        //                    xml.AddAttribute("/CpSort/QGTC/" + nvarName, "code5", dtWeb.Rows[0]["code5"].ToString());
        //                }
        //                else
        //                {
        //                    xml.AddAttribute("/CpSort/QGTC/" + nvarName, "code", dtWeb.Rows[0]["code"].ToString());
        //                    if (dtWeb.Columns.Contains("tcode"))
        //                    {
        //                        if (dtWeb.Rows[0]["tcode"] != null)
        //                        {
        //                            xml.AddAttribute("/CpSort/QGTC/" + nvarName, "tcode", dtWeb.Rows[0]["tcode"].ToString());
        //                        }
        //                        else
        //                        {
        //                            xml.AddAttribute("/CpSort/QGTC/" + nvarName, "tcode", "");
        //                        }
        //                    }
        //                    else
        //                    {
        //                        xml.AddAttribute("/CpSort/QGTC/" + nvarName, "tcode", "");
        //                    }
        //                    ///
        //                    if ("TCDLTData" == row["NvarApp_name"].ToString())
        //                    {
        //                        xml.AddAttribute("/CpSort/QGTC/" + nvarName, "code2", dtWeb.Rows[0]["code2"].ToString());
        //                    }
        //                }

        //                xml.AddAttribute("/CpSort/QGTC/" + nvarName, "date", Convert.ToDateTime(dtWeb.Rows[0]["date"]).ToShortDateString() + " 20:30:00");
        //                xml.AddAttribute("/CpSort/QGTC/" + nvarName, "lott_date", row["NvarLott_date"].ToString());
        //                xml.AddAttribute("/CpSort/QGTC/" + nvarName, "app", row["NvarApp_name"].ToString());
        //                //xml.AddAttribute("/CpSort/QGTC/" + nvarName, "info", row["LottTypeInfo"].ToString());
        //                break;
        //            case "��ʡ����":
        //                XmlNode GSFCitem = root.SelectSingleNode("/CpSort/GSFC/" + nvarName);
        //                GSFCitem.Attributes.RemoveAll();
        //                xml.AddAttribute("/CpSort/GSFC/" + nvarName, "name", row["NvarName"].ToString());
        //                xml.AddAttribute("/CpSort/GSFC/" + nvarName, "issue", dtWeb.Rows[0]["issue"].ToString());
        //                xml.AddAttribute("/CpSort/GSFC/" + nvarName, "code", dtWeb.Rows[0]["code"].ToString());
        //                if (dtWeb.Columns.Contains("tcode"))
        //                {
        //                    if (dtWeb.Rows[0]["tcode"] != null)
        //                    {
        //                        xml.AddAttribute("/CpSort/GSFC/" + nvarName, "tcode", dtWeb.Rows[0]["tcode"].ToString());
        //                    }
        //                    else
        //                    {
        //                        xml.AddAttribute("/CpSort/GSFC/" + nvarName, "tcode", "");
        //                    }
        //                }
        //                else
        //                {
        //                    xml.AddAttribute("/CpSort/GSFC/" + nvarName, "tcode", "");
        //                }
        //                xml.AddAttribute("/CpSort/GSFC/" + nvarName, "date", Convert.ToDateTime(dtWeb.Rows[0]["date"]).ToShortDateString() + " 20:30:00");
        //                xml.AddAttribute("/CpSort/GSFC/" + nvarName, "lott_date", row["NvarLott_date"].ToString());
        //                xml.AddAttribute("/CpSort/GSFC/" + nvarName, "app", row["NvarApp_name"].ToString());
        //                break;
        //            case "��ʡ���":
        //                XmlNode GSTCitem = root.SelectSingleNode("/CpSort/GSTC/" + nvarName);
        //                GSTCitem.Attributes.RemoveAll();
        //                xml.AddAttribute("/CpSort/GSTC/" + nvarName, "name", row["NvarName"].ToString());
        //                xml.AddAttribute("/CpSort/GSTC/" + nvarName, "issue", dtWeb.Rows[0]["issue"].ToString());
        //                xml.AddAttribute("/CpSort/GSTC/" + nvarName, "code", dtWeb.Rows[0]["code"].ToString());
        //                if (dtWeb.Columns.Contains("tcode"))
        //                {
        //                    if (dtWeb.Rows[0]["tcode"] != null)
        //                    {
        //                        xml.AddAttribute("/CpSort/GSTC/" + nvarName, "tcode", dtWeb.Rows[0]["tcode"].ToString());
        //                    }
        //                    else
        //                    {
        //                        xml.AddAttribute("/CpSort/GSTC/" + nvarName, "tcode", "");
        //                    }
        //                }
        //                else
        //                {
        //                    xml.AddAttribute("/CpSort/GSTC/" + nvarName, "tcode", "");
        //                }
        //                xml.AddAttribute("/CpSort/GSTC/" + nvarName, "date", Convert.ToDateTime(dtWeb.Rows[0]["date"]).ToShortDateString() + " 20:30:00");
        //                xml.AddAttribute("/CpSort/GSTC/" + nvarName, "lott_date", row["NvarLott_date"].ToString());
        //                xml.AddAttribute("/CpSort/GSTC/" + nvarName, "app", row["NvarApp_name"].ToString());
        //                break;
        //            case "��Ƶ����":
        //                XmlNode GPFCitem = root.SelectSingleNode("/CpSort/GPFC/" + nvarName);
        //                GPFCitem.Attributes.RemoveAll();
        //                xml.AddAttribute("/CpSort/GPFC/" + nvarName, "name", row["NvarName"].ToString());
        //                xml.AddAttribute("/CpSort/GPFC/" + nvarName, "issue", dtWeb.Rows[0]["issue"].ToString());
        //                xml.AddAttribute("/CpSort/GPFC/" + nvarName, "code", dtWeb.Rows[0]["code"].ToString());
        //                if (dtWeb.Columns.Contains("tcode"))
        //                {
        //                    if (dtWeb.Rows[0]["tcode"] != null)
        //                    {
        //                        xml.AddAttribute("/CpSort/GPFC/" + nvarName, "tcode", dtWeb.Rows[0]["tcode"].ToString());
        //                    }
        //                    else
        //                    {
        //                        xml.AddAttribute("/CpSort/GPFC/" + nvarName, "tcode", "");
        //                    }
        //                }
        //                else
        //                {
        //                    xml.AddAttribute("/CpSort/GPFC/" + nvarName, "tcode", "");
        //                }
        //                xml.AddAttribute("/CpSort/GPFC/" + nvarName, "date", dtWeb.Rows[0]["date"].ToString());
        //                xml.AddAttribute("/CpSort/GPFC/" + nvarName, "lott_date", row["NvarLott_date"].ToString());
        //                xml.AddAttribute("/CpSort/GPFC/" + nvarName, "app", row["NvarApp_name"].ToString());
        //                break;
        //            case "��Ƶ���":
        //                XmlNode GPTCitem = root.SelectSingleNode("/CpSort/GPTC/" + nvarName);
        //                GPTCitem.Attributes.RemoveAll();
        //                xml.AddAttribute("/CpSort/GPTC/" + nvarName, "name", row["NvarName"].ToString());
        //                xml.AddAttribute("/CpSort/GPTC/" + nvarName, "issue", dtWeb.Rows[0]["issue"].ToString());
        //                xml.AddAttribute("/CpSort/GPTC/" + nvarName, "code", dtWeb.Rows[0]["code"].ToString());
        //                if (dtWeb.Columns.Contains("tcode"))
        //                {
        //                    if (dtWeb.Rows[0]["tcode"] != null)
        //                    {
        //                        xml.AddAttribute("/CpSort/GPTC/" + nvarName, "tcode", dtWeb.Rows[0]["tcode"].ToString());
        //                    }
        //                    else
        //                    {
        //                        xml.AddAttribute("/CpSort/GPTC/" + nvarName, "tcode", "");
        //                    }
        //                }
        //                else
        //                {
        //                    xml.AddAttribute("/CpSort/GPTC/" + nvarName, "tcode", "");
        //                }
        //                xml.AddAttribute("/CpSort/GPTC/" + nvarName, "date", dtWeb.Rows[0]["date"].ToString());
        //                xml.AddAttribute("/CpSort/GPTC/" + nvarName, "lott_date", row["NvarLott_date"].ToString());
        //                xml.AddAttribute("/CpSort/GPTC/" + nvarName, "app", row["NvarApp_name"].ToString());
        //                break;
        //        }                
        //    }
        //    ///�������ʱ��
        //    // XmlNode temp = QGFC.SelectSingleNode("./" +nvarName);
        //    //xml.AddAttribute("/CpSort/CreateTime", "time", DateTime.Now.ToString());
        //    XmlNode myTime = root.SelectSingleNode("/CpSort/CreateTime");
        //    myTime.Attributes.RemoveAll();
        //    xml.AddAttribute("/CpSort/CreateTime", "time", DateTime.Now.ToString());

        //}
        #endregion

        /// <summary>
        ///����ȫ������
        /// </summary>
        private void CreateQuanGuo(string cpType)
        {
            string xmlPath = HttpRuntime.AppDomainAppPath + "\\xml\\QuanGuoCpDate.xml";         
            if (!File.Exists(xmlPath))
            {
                DirectoryFile.CreateFile(xmlPath);
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(xmlPath, false, System.Text.Encoding.GetEncoding("utf-8")))
                {                   
                    sw.Write("<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n");
                    sw.Write("<CpDate>\r\n</CpDate>");
                    sw.Close();
                }
            }
            //����xml
            Pbzx.Common.MyXML xml = xml = new Pbzx.Common.MyXML("\\xml\\QuanGuoCpDate.xml");               
            //���ڵ�
            XmlNode root = xml.GetXmlRoot();
            //��ѯ����
            Pbzx.BLL.PBnet_LotteryMenu lottBLL = new Pbzx.BLL.PBnet_LotteryMenu();
            DataTable dt = null;
            if (string.IsNullOrEmpty(cpType))
            {
                dt = lottBLL.GetList("  BitState=1 and BitIs_show=1 and (NvarClass='ȫ������' or NvarClass='ȫ�����') order by IntClass_OrderId asc ,NvarOrderId asc ").Tables[0];
            }
            else
            {
                dt = DbHelperSQL.Query(" select top 1 * from PBnet_LotteryMenu where  BitState=1 and BitIs_show=1  and  NvarApp_name='" + cpType + "' order by NvarOrderId asc  ").Tables[0];
            }
           
            if (dt.Rows.Count < 1)
            {
                return;
            }
            //����ȫ�����ʽڵ�
            XmlNode QGFC = root.SelectSingleNode("/CpDate/QGFC");           
            if (QGFC == null) //��������ھ����
            {
                xml.AddChildNode("/CpDate", "QGFC");
                QGFC = root.SelectSingleNode("/CpDate/QGFC");
            }
            //����ȫ����ʽڵ�
            XmlNode QGTC = root.SelectSingleNode("/CpDate/QGTC");
            if (QGTC == null) //��������ھ����
            {
                xml.AddChildNode("/CpDate", "QGTC");
                QGTC = root.SelectSingleNode("/CpDate/QGTC");
            }


            //����PBnet_LotteryMenu(ȫ�����ʺ�ȫ����ʽڵ�)
            foreach (DataRow row in dt.Rows)
            {
                string type = row["NvarClass"].ToString();
                string nvarName = row["NvarName"].ToString();
                if (Input.IsInteger(nvarName.Substring(0, 1)))
                {
                    nvarName = "_" + nvarName;
                }
                else if (nvarName.Contains("��"))
                {
                    nvarName = nvarName.Replace("��", "X");
                }
                //��ѯ��Ӧ��������(cst��)
                DataTable dtWeb = DbHelperSQL1.Query("select top 1 * from " + row["NvarApp_name"].ToString() + " order by issue desc").Tables[0];
                if (dtWeb.Rows.Count < 1)
                {
                    return;
                }
                XmlNode temp = null;
                //�Ƿ�ˢ��
                string isRefresh =  Convert.ToInt32(row["IsRefresh"]) == 1 ? "true" : "false";
                string[] lottTypeInfoSZ = row["LottTypeInfo"].ToString().Split(new char[] { '|' });
                string[] strInfo1 = lottTypeInfoSZ[0].Split(new char[] { ',' });
                switch (type)
                {
                    case "ȫ������":
                        //�Ƿ��иýڵ㣬���û���򴴽�
                        temp = QGFC.SelectSingleNode("/CpDate/QGFC/" + nvarName);
                        if (temp == null)
                        {
                            xml.AddChildNode("/CpDate/QGFC", nvarName);
                            temp = QGFC.SelectSingleNode("/CpDate/QGFC/" + nvarName);
                        }
                        //���ù�������

                        SetPublicAttributes(xml, "/CpDate/QGFC/" + nvarName, row["NvarName"].ToString(), dtWeb.Rows[0]["issue"].ToString(), Convert.ToDateTime(dtWeb.Rows[0]["date"]).ToShortDateString() + " 21:20:00", row["NvarLott_date"].ToString(), row["NvarApp_name"].ToString());
                        //����3D��������
                        if ("FC3DData" == row["NvarApp_name"].ToString())
                        {

                            //��ע��
                            string[] result = WebFunc.CalGZM(dtWeb.Rows[0]["testcode"].ToString());
                            string jin = result[0];
                            string yin = result[1];
                            string tong = result[2];
                            string deTestCode = result[3];                           
                            xml.SetAttribute("/CpDate/QGFC/" + nvarName, "testcode", dtWeb.Rows[0]["testcode"].ToString());
                            object obj3DCode = DbHelperSQL1.GetSingle("select top 1 code from " + row["NvarApp_name"].ToString() + "   order by issue desc");
                            string str3DCode  = "";
                            if(obj3DCode != null && obj3DCode.ToString().Length > 0 )
                            {
                                str3DCode = obj3DCode.ToString();
                            }                          
                            xml.SetAttribute("/CpDate/QGFC/" + nvarName, "code", str3DCode);
                            xml.AddAttribute("/CpDate/QGFC/" + nvarName, "machine", dtWeb.Rows[0]["machine"].ToString());
                            xml.AddAttribute("/CpDate/QGFC/" + nvarName, "ball", dtWeb.Rows[0]["ball"].ToString());
                            xml.AddAttribute("/CpDate/QGFC/" + nvarName, "decode", deTestCode);
                            xml.AddAttribute("/CpDate/QGFC/" + nvarName, "jin", jin);
                            xml.AddAttribute("/CpDate/QGFC/" + nvarName, "yin", yin);
                            xml.AddAttribute("/CpDate/QGFC/" + nvarName, "tong", tong);
                            if (string.IsNullOrEmpty(str3DCode))
                            {
                                SetPublicAttributes(xml, "/CpDate/QGFC/" + nvarName, row["NvarName"].ToString(), dtWeb.Rows[0]["issue"].ToString(), Convert.ToDateTime(dtWeb.Rows[0]["date"]).ToShortDateString() + " 19:00:00", row["NvarLott_date"].ToString(), row["NvarApp_name"].ToString());
                            }
                            else
                            {
                                Files.Create("/pb_cst.htm", "/Template/Fc3DGZM.aspx");
                            }
                            
                        }
                        else
                        {
                            if ("FCSSData" == row["NvarApp_name"].ToString() || "FC7LC" == row["NvarApp_name"].ToString())
                            {
                                SetPublicAttributes(xml, "/CpDate/QGFC/" + nvarName, row["NvarName"].ToString(), dtWeb.Rows[0]["issue"].ToString(), Convert.ToDateTime(dtWeb.Rows[0]["date"]).ToShortDateString() + " 21:20:00", row["NvarLott_date"].ToString(), row["NvarApp_name"].ToString());
                            }

                            xml.SetAttribute("/CpDate/QGFC/" + nvarName, strInfo1[4], dtWeb.Rows[0][strInfo1[4]].ToString());
                            if(lottTypeInfoSZ.Length > 1 && !string.IsNullOrEmpty(lottTypeInfoSZ[1]))
                            {
                                string[] strInfo2 = lottTypeInfoSZ[1].Split(new char[] { ',' });
                                xml.SetAttribute("/CpDate/QGFC/" + nvarName, strInfo2[4], dtWeb.Rows[0][strInfo2[4]].ToString());
                            }
                        }
                        xml.AddAttribute("/CpDate/QGFC/" + nvarName, "refresh", isRefresh);                        
                        break;
                    case "ȫ�����":
                        //�Ƿ��иýڵ㣬���û���򴴽�
                        temp = QGFC.SelectSingleNode("/CpDate/QGTC/" + nvarName);
                        if (temp == null)
                        {
                            xml.AddChildNode("/CpDate/QGTC", nvarName);
                            temp = QGFC.SelectSingleNode("/CpDate/QGTC/" + nvarName);
                        }
                        //���ù�������
                        SetPublicAttributes(xml, "/CpDate/QGTC/" + nvarName,  row["NvarName"].ToString(), dtWeb.Rows[0]["issue"].ToString(),Convert.ToDateTime(dtWeb.Rows[0]["date"]).ToShortDateString() + " 20:30:00", row["NvarLott_date"].ToString(), row["NvarApp_name"].ToString());
                        xml.SetAttribute("/CpDate/QGTC/" + nvarName, strInfo1[4], dtWeb.Rows[0][strInfo1[4]].ToString());
                        if (lottTypeInfoSZ.Length > 1 && !string.IsNullOrEmpty(lottTypeInfoSZ[1]))
                        {
                            string[] strInfo2 = lottTypeInfoSZ[1].Split(new char[] { ',' });
                            xml.SetAttribute("/CpDate/QGTC/" + nvarName, strInfo2[4], dtWeb.Rows[0][strInfo2[4]].ToString());
                        }
                        xml.AddAttribute("/CpDate/QGTC/" + nvarName, "refresh", isRefresh);
                        break;
                }
            }

            //���PbCpMsgString�ڵ�
            AddOtherAttr(xml, "/CpDate", "PbCpMsgString", "value", "true");
            //���_3DTest�ڵ�
            AddOtherAttr(xml, "/CpDate", "_3DTest", "date", "2010-3-26 19:00:00");
            //���_3DTestVerify�ڵ�
            AddOtherAttr(xml, "/CpDate", "_3DTestVerify", "date", "2010-3-24 19:15:00");

            AddOtherAttr(xml, "/CpDate", "_3DOrder", "date", "2010-3-26 19:15:00");

            //���_3DMoney�ڵ�
             AddOtherAttr(xml, "/CpDate", "_3DMoney", "date", "2010-3-26 21:00:00");
                
            AddOtherAttr(xml, "/CpDate", "SSMoney", "date", "2010-3-24 21:00:00");
            AddOtherAttr(xml, "/CpDate", "_7LMoney", "date", "2010-3-26 21:30:00");
            AddOtherAttr(xml, "/CpDate", "PL3Money", "date", "2010-3-26 21:30:00");
            AddOtherAttr(xml, "/CpDate", "PL5Money", "date", "2010-3-26 21:30:00");
            AddOtherAttr(xml, "/CpDate", "DLTMoney", "date", "2010-3-26 21:30:00");
            AddOtherAttr(xml, "/CpDate", "_7XCMoney", "date", "2010-3-26 21:30:00");


            //���CreateTime�ڵ�
            AddOtherAttr(xml, "/CpDate", "CreateTime", "time", DateTime.Now.ToString());
            xml.SetAttribute("/CpDate/CreateTime", "time", DateTime.Now.ToString());



        }

        /// <summary>
        ///���ɸ�ʡ����
        /// </summary>
        private void CreateGeSheng(string cpType)
        {
            string xmlPath = HttpRuntime.AppDomainAppPath + "\\xml\\GeShengCpDate.xml";
            if (!File.Exists(xmlPath))
            {
                DirectoryFile.CreateFile(xmlPath);
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(xmlPath, false, System.Text.Encoding.GetEncoding("utf-8")))
                {
                    sw.Write("<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n");
                    sw.Write("<CpDate>\r\n</CpDate>");
                    sw.Close();
                }
            }

            //����xml
            Pbzx.Common.MyXML xml = new Pbzx.Common.MyXML("\\xml\\GeShengCpDate.xml");
            //���ڵ�
            XmlNode root = xml.GetXmlRoot();
            //��ѯ����
            Pbzx.BLL.PBnet_LotteryMenu lottBLL = new Pbzx.BLL.PBnet_LotteryMenu();
            DataTable dt = null;
            if (string.IsNullOrEmpty(cpType))
            {
                dt = lottBLL.GetList("  BitState=1 and BitIs_show=1  and (NvarClass='��ʡ����' or NvarClass='��ʡ���') order by IntClass_OrderId,NvarOrderId ").Tables[0]; 
            }
            else
            {
                dt = DbHelperSQL.Query(" select top 1 * from PBnet_LotteryMenu where   BitState=1 and BitIs_show=1  and NvarApp_name='" + cpType + "' order by NvarOrderId asc   ").Tables[0];
            }
            if (dt.Rows.Count < 1)
            {
                return;
            }
            //�����ʡ���ʽڵ�
            XmlNode GSFC = root.SelectSingleNode("/CpDate/GSFC");
            if (GSFC == null) //��������ھ����
            {
                xml.AddChildNode("/CpDate", "GSFC");
                GSFC = root.SelectSingleNode("/CpDate/GSFC");
            }
            //�����ʡ��ʽڵ�
            XmlNode GSTC = root.SelectSingleNode("/CpDate/GSTC");
            if (GSTC == null) //��������ھ����
            {
                xml.AddChildNode("/CpDate", "GSTC");
                GSTC = root.SelectSingleNode("/CpDate/GSTC");
            }
            //����PBnet_LotteryMenu(��ʡ���ʺ͸�ʡ��ʽڵ�)
            foreach (DataRow row in dt.Rows)
            {
                string type = row["NvarClass"].ToString();
                string nvarName = row["NvarName"].ToString();
                if (Input.IsInteger(nvarName.Substring(0, 1)))
                {
                    nvarName = "_" + nvarName;
                }
                else if (nvarName.Contains("��"))
                {
                    nvarName = nvarName.Replace("��", "X");
                }
                //��ѯ��Ӧ��������(cst��)
                DataTable dtWeb = DbHelperSQL1.Query("select top 1 * from " + row["NvarApp_name"].ToString() + " order by issue desc").Tables[0];
                if (dtWeb.Rows.Count < 1)
                {
                    return;
                }
                XmlNode temp = null;
                //�Ƿ�ˢ��
                string isRefresh = Convert.ToInt32(row["IsRefresh"]) == 1 ? "true" : "false";
                string[] lottTypeInfoSZ = row["LottTypeInfo"].ToString().Split(new char[] { '|' });
                string[] strInfo1 = lottTypeInfoSZ[0].Split(new char[] { ',' });
                switch (type)
                {
                    case "��ʡ����":
                        //�Ƿ��иýڵ㣬���û���򴴽�
                        temp = GSFC.SelectSingleNode("/CpDate/GSFC/" + nvarName);
                        if (temp == null)
                        {
                            xml.AddChildNode("/CpDate/GSFC", nvarName);
                            temp = GSFC.SelectSingleNode("/CpDate/GSFC/" + nvarName);
                        }
                        //���ù�������
                        SetPublicAttributes(xml, "/CpDate/GSFC/" + nvarName, row["NvarName"].ToString(), dtWeb.Rows[0]["issue"].ToString(), Convert.ToDateTime(dtWeb.Rows[0]["date"]).ToShortDateString() + " 20:30:00", row["NvarLott_date"].ToString(), row["NvarApp_name"].ToString());
                        xml.SetAttribute("/CpDate/GSFC/" + nvarName, strInfo1[4], dtWeb.Rows[0][strInfo1[4]].ToString());
                        if (lottTypeInfoSZ.Length > 1 && !string.IsNullOrEmpty(lottTypeInfoSZ[1]))
                        {
                            string[] strInfo2 = lottTypeInfoSZ[1].Split(new char[] { ',' });
                            xml.SetAttribute("/CpDate/GSFC/" + nvarName, strInfo2[4], dtWeb.Rows[0][strInfo2[4]].ToString());
                        }
                        xml.AddAttribute("/CpDate/GSFC/" + nvarName, "refresh", isRefresh);
                        break;
                    case "��ʡ���":
                        //�Ƿ��иýڵ㣬���û���򴴽�
                        temp = GSTC.SelectSingleNode("/CpDate/GSTC/" + nvarName);
                        if (temp == null)
                        {
                            xml.AddChildNode("/CpDate/GSTC", nvarName);
                            temp = GSTC.SelectSingleNode("/CpDate/GSTC/" + nvarName);
                        }
                        //���ù�������
                        SetPublicAttributes(xml, "/CpDate/GSTC/" + nvarName, row["NvarName"].ToString(), dtWeb.Rows[0]["issue"].ToString(), Convert.ToDateTime(dtWeb.Rows[0]["date"]).ToShortDateString() + " 20:30:00", row["NvarLott_date"].ToString(), row["NvarApp_name"].ToString());
                        xml.SetAttribute("/CpDate/GSTC/" + nvarName, strInfo1[4], dtWeb.Rows[0][strInfo1[4]].ToString());
                        if (lottTypeInfoSZ.Length > 1 && !string.IsNullOrEmpty(lottTypeInfoSZ[1]))
                        {
                            string[] strInfo2 = lottTypeInfoSZ[1].Split(new char[] { ',' });
                            xml.SetAttribute("/CpDate/GSTC/" + nvarName, strInfo2[4], dtWeb.Rows[0][strInfo2[4]].ToString());
                        }
                        xml.AddAttribute("/CpDate/GSTC/" + nvarName, "refresh", isRefresh);
                        break;
                }
            }

            //���CreateTime�ڵ�
            AddOtherAttr(xml, "/CpDate", "CreateTime", "time", DateTime.Now.ToString());
            xml.SetAttribute("/CpDate/CreateTime", "time", DateTime.Now.ToString());
        }


        /// <summary>
        ///���ɸ�Ƶ����
        /// </summary>
        private void CreateGaoPin(string cpType)
        {
            string xmlPath = HttpRuntime.AppDomainAppPath + "\\xml\\GaoPinCpDate.xml";
            if (!File.Exists(xmlPath))
            {
                DirectoryFile.CreateFile(xmlPath);
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(xmlPath, false, System.Text.Encoding.GetEncoding("utf-8")))
                {
                    sw.Write("<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n");
                    sw.Write("<CpDate>\r\n</CpDate>");
                    sw.Close();
                }
            }
            //����xml
            Pbzx.Common.MyXML xml = new Pbzx.Common.MyXML("\\xml\\GaoPinCpDate.xml");
            //���ڵ�
            XmlNode root = xml.GetXmlRoot();
            //��ѯ����
            Pbzx.BLL.PBnet_LotteryMenu lottBLL = new Pbzx.BLL.PBnet_LotteryMenu();
            DataTable dt = null;
            if (string.IsNullOrEmpty(cpType))
            {
                dt = lottBLL.GetList(" BitState=1 and BitIs_show=1 and (NvarClass='��Ƶ����' or NvarClass='��Ƶ���') order by IntClass_OrderId,NvarOrderId ").Tables[0];
            }
            else
            {
                dt = DbHelperSQL.Query(" select top 1 * from PBnet_LotteryMenu where BitState=1 and BitIs_show=1 and NvarApp_name='" + cpType + "'  ").Tables[0];
            }
            if (dt.Rows.Count < 1)
            {
                return;
            }
            //�����Ƶ���ʽڵ�
            XmlNode GPFC = root.SelectSingleNode("/CpDate/GPFC");
            if (GPFC == null) //��������ھ����
            {
                xml.AddChildNode("/CpDate", "GPFC");
                GPFC = root.SelectSingleNode("/CpDate/GPFC");
            }
            //�����Ƶ��ʽڵ�
            XmlNode GPTC = root.SelectSingleNode("/CpDate/GPTC");
            if (GPTC == null) //��������ھ����
            {
                xml.AddChildNode("/CpDate", "GPTC");
                GPTC = root.SelectSingleNode("/CpDate/GPTC");
            }
            //����PBnet_LotteryMenu(��ʡ���ʺ͸�ʡ��ʽڵ�)
            foreach (DataRow row in dt.Rows)
            {
                string type = row["NvarClass"].ToString();
                string nvarName = row["NvarName"].ToString();
                if (Input.IsInteger(nvarName.Substring(0, 1)))
                {
                    nvarName = "_" + nvarName;
                }
                else if (nvarName.Contains("��"))
                {
                    nvarName = nvarName.Replace("��", "X");
                }
                //��ѯ��Ӧ��������(cst��)
                DataTable dtWeb = DbHelperSQL1.Query("select top 1 * from " + row["NvarApp_name"].ToString() + " order by issue desc").Tables[0];
                if (dtWeb.Rows.Count < 1)
                {
                    return;
                }
                XmlNode temp = null;
                //�Ƿ�ˢ��
                string isRefresh = Convert.ToInt32(row["IsRefresh"]) == 1 ? "true" : "false";
                string[] lottTypeInfoSZ = row["LottTypeInfo"].ToString().Split(new char[] { '|' });
                string[] strInfo1 = lottTypeInfoSZ[0].Split(new char[] { ',' });
                switch (type)
                {
                    case "��Ƶ����":
                        //�Ƿ��иýڵ㣬���û���򴴽�
                        temp = GPFC.SelectSingleNode("/CpDate/GPFC/" + nvarName);
                        if (temp == null)
                        {
                            xml.AddChildNode("/CpDate/GPFC", nvarName);
                            temp = GPFC.SelectSingleNode("/CpDate/GPFC/" + nvarName);
                        }
                        //���ù�������
                        SetPublicAttributes(xml, "/CpDate/GPFC/" + nvarName,  row["NvarName"].ToString(), dtWeb.Rows[0]["issue"].ToString(), dtWeb.Rows[0]["date"].ToString(), row["NvarLott_date"].ToString(), row["NvarApp_name"].ToString());
                        xml.SetAttribute("/CpDate/GPFC/" + nvarName, strInfo1[4], dtWeb.Rows[0][strInfo1[4]].ToString());
                        if (lottTypeInfoSZ.Length > 1 && !string.IsNullOrEmpty(lottTypeInfoSZ[1]))
                        {
                            string[] strInfo2 = lottTypeInfoSZ[1].Split(new char[] { ',' });
                            xml.SetAttribute("/CpDate/GPFC/" + nvarName, strInfo2[4], dtWeb.Rows[0][strInfo2[4]].ToString());
                        }
                        xml.AddAttribute("/CpDate/GPFC/" + nvarName, "refresh", isRefresh);
                        break;
                    case "��Ƶ���":
                        //�Ƿ��иýڵ㣬���û���򴴽�
                        temp = GPTC.SelectSingleNode("/CpDate/GPTC/" + nvarName);
                        if (temp == null)
                        {
                            xml.AddChildNode("/CpDate/GPTC", nvarName);
                            temp = GPTC.SelectSingleNode("/CpDate/GPTC/" + nvarName);
                        }
                        //���ù�������
                        SetPublicAttributes(xml, "/CpDate/GPTC/" + nvarName, row["NvarName"].ToString(), dtWeb.Rows[0]["issue"].ToString(), dtWeb.Rows[0]["date"].ToString(), row["NvarLott_date"].ToString(), row["NvarApp_name"].ToString());
                        xml.SetAttribute("/CpDate/GPTC/" + nvarName, strInfo1[4], dtWeb.Rows[0][strInfo1[4]].ToString());
                        if (lottTypeInfoSZ.Length > 1 && !string.IsNullOrEmpty(lottTypeInfoSZ[1]))
                        {
                            string[] strInfo2 = lottTypeInfoSZ[1].Split(new char[] { ',' });
                            xml.SetAttribute("/CpDate/GPTC/" + nvarName, strInfo2[4], dtWeb.Rows[0][strInfo2[4]].ToString());
                        }
                        xml.AddAttribute("/CpDate/GPTC/" + nvarName, "refresh", isRefresh);
                        break;
                }
            }
            //���CreateTime�ڵ�
            AddOtherAttr(xml, "/CpDate", "CreateTime", "time", DateTime.Now.ToString());
            xml.SetAttribute("/CpDate/CreateTime", "time", DateTime.Now.ToString());
        }
      


        /// <summary>
        /// ���ù�������
        /// </summary>
        /// <param name="path"></param>
        /// <param name="name"></param>
        /// <param name="issue"></param>
        /// <param name="code"></param>
        /// <param name="date"></param>
        /// <param name="lott_date"></param>
        /// <param name="app"></param>
        private void SetPublicAttributes(Pbzx.Common.MyXML  xml,string path, string name, string issue, string date, string lott_date, string app)
        {          
            xml.SetAttribute(path,"name",name);
            xml.SetAttribute(path, "issue", issue);
            xml.SetAttribute(path, "date", date);
            xml.SetAttribute(path, "lott_date", lott_date);
            xml.SetAttribute(path, "app", app);
        }


        /// <summary>
        /// ��Ӹ��ӽڵ������ֵ
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="parentPath"></param>
        /// <param name="nodeName"></param>
        /// <param name="attrName"></param>
        /// <param name="attrValue"></param>
        private void AddOtherAttr(Pbzx.Common.MyXML xml, string parentPath, string nodeName, string attrName, string attrValue)
        {
            XmlNode root = xml.GetXmlRoot();
            XmlNode tempNode = root.SelectSingleNode(parentPath + "/" + nodeName);
            if (tempNode == null)
            {
                xml.AddChildNode(parentPath, nodeName);
                tempNode = root.SelectSingleNode(parentPath + "/" + nodeName);
            }
            if (tempNode.Attributes[attrName] == null)
            {
                xml.SetAttribute(parentPath + "/" + nodeName, attrName, attrValue);
            }
        }



    }
}














































































            //Pbzx.BLL.PBnet_LotteryMenu lottBLL = new Pbzx.BLL.PBnet_LotteryMenu();   
            //DataTable dt = null;     
            //Pbzx.Common.MyXML xml = new Pbzx.Common.MyXML("\\xml\\CpSortTime.xml");            
            //XmlNode root = xml.GetXmlRoot();
            //switch (cptype)
            //{
            //    case "quanguo":
            //        dt = lottBLL.GetList(" BitIs_show=1 and (NvarClass='ȫ������' or  NvarClass='ȫ�����')    order by IntClass_OrderId,NvarOrderId  ").Tables[0];//and (NvarClass='ȫ������' or  NvarClass='ȫ�����') 
            //        if (dt.Rows.Count < 1)
            //        {
            //            return;
            //        }
            //        XmlNode QGFC = root.SelectSingleNode("/CpSort/QGFC");
            //        QGFC.RemoveAll();
            //        XmlNode QGTC = root.SelectSingleNode("/CpSort/QGTC");
            //        QGTC.RemoveAll();
            //        foreach (DataRow row in dt.Rows)
            //        {
            //            string type = row["NvarClass"].ToString();
            //            string nvarName = row["NvarName"].ToString();
            //            if (Input.IsInteger(nvarName.Substring(0, 1)))
            //            {
            //                nvarName = "_" + nvarName;
            //            }
            //            else if (nvarName.Contains("��"))
            //            {
            //                nvarName = nvarName.Replace("��", "_");
            //            }
            //            //  nvarName = nvarName.Replace("\r\n", "");
            //            DataTable dtWeb = DbHelperSQL1.Query("select top 1 * from " + row["NvarApp_name"].ToString() + " order by issue desc").Tables[0];
            //            switch (type)
            //            {
            //                case "ȫ������":
            //                    xml.AddChildNode("/CpSort/" + QGFC.Name, nvarName);
            //                    // XmlNode temp = QGFC.SelectSingleNode("./" +nvarName);
            //                    xml.AddAttribute("/CpSort/QGFC/" + nvarName, "name", row["NvarName"].ToString());
            //                    xml.AddAttribute("/CpSort/QGFC/" + nvarName, "issue", dtWeb.Rows[0]["issue"].ToString());
            //                    if ("FCSSData" == row["NvarApp_name"].ToString())
            //                    {
            //                        xml.AddAttribute("/CpSort/QGFC/" + nvarName, "code", "");
            //                        xml.AddAttribute("/CpSort/QGFC/" + nvarName, "redcode", dtWeb.Rows[0]["redcode"].ToString());
            //                        xml.AddAttribute("/CpSort/QGFC/" + nvarName, "bluecode", dtWeb.Rows[0]["bluecode"].ToString());
            //                        if (dtWeb.Rows[0]["bluecode2"] != null)
            //                        {
            //                            xml.AddAttribute("/CpSort/QGFC/" + nvarName, "bluecode2", dtWeb.Rows[0]["bluecode2"].ToString());
            //                        }
            //                    }
            //                    else if ("FC3DData" == row["NvarApp_name"].ToString())
            //                    {
            //                        string[] result = CalGZM();
            //                        string cstJin = result[0];
            //                        string HL1 = result[1];
            //                        string HL2 = result[2];
            //                        string deTestCode = result[3];
            //                        xml.AddAttribute("/CpSort/QGFC/" + nvarName, "code", dtWeb.Rows[0]["code"].ToString());
            //                        xml.AddAttribute("/CpSort/QGFC/" + nvarName, "testcode", dtWeb.Rows[0]["testcode"].ToString());
            //                        xml.AddAttribute("/CpSort/QGFC/" + nvarName, "machine", dtWeb.Rows[0]["machine"].ToString());
            //                        xml.AddAttribute("/CpSort/QGFC/" + nvarName, "ball", dtWeb.Rows[0]["ball"].ToString());
            //                        xml.AddAttribute("/CpSort/QGFC/" + nvarName, "decode", deTestCode);
            //                        xml.AddAttribute("/CpSort/QGFC/" + nvarName, "Jin", cstJin);
            //                        xml.AddAttribute("/CpSort/QGFC/" + nvarName, "HL1", HL1);
            //                        xml.AddAttribute("/CpSort/QGFC/" + nvarName, "HL2", HL2);
            //                    }
            //                    else
            //                    {
            //                        xml.AddAttribute("/CpSort/QGFC/" + nvarName, "code", dtWeb.Rows[0]["code"].ToString());
            //                    }
            //                    if (dtWeb.Columns.Contains("tcode"))
            //                    {
            //                        if (dtWeb.Rows[0]["tcode"] != null)
            //                        {
            //                            xml.AddAttribute("/CpSort/QGFC/" + nvarName, "tcode", dtWeb.Rows[0]["tcode"].ToString());
            //                        }
            //                        else
            //                        {
            //                            xml.AddAttribute("/CpSort/QGFC/" + nvarName, "tcode", "");
            //                        }
            //                    }
            //                    else
            //                    {
            //                        xml.AddAttribute("/CpSort/QGFC/" + nvarName, "tcode", "");
            //                    }
            //                    xml.AddAttribute("/CpSort/QGFC/" + nvarName, "date", dtWeb.Rows[0]["date"].ToString());
            //                    xml.AddAttribute("/CpSort/QGFC/" + nvarName, "lott_date", row["NvarLott_date"].ToString());
            //                    xml.AddAttribute("/CpSort/QGFC/" + nvarName, "app", row["NvarApp_name"].ToString());

            //                    break;
            //                case "ȫ�����":
            //                    xml.AddChildNode("/CpSort/" + QGTC.Name, nvarName);
            //                    // 
            //                    xml.AddAttribute("/CpSort/QGTC/" + nvarName, "name", row["NvarName"].ToString());
            //                    xml.AddAttribute("/CpSort/QGTC/" + nvarName, "issue", dtWeb.Rows[0]["issue"].ToString());

            //                    if ("TCPL35Data" == row["NvarApp_name"].ToString())
            //                    {
            //                        xml.AddAttribute("/CpSort/QGTC/" + nvarName, "code", "");
            //                        xml.AddAttribute("/CpSort/QGTC/" + nvarName, "code3", dtWeb.Rows[0]["code3"].ToString());
            //                        xml.AddAttribute("/CpSort/QGTC/" + nvarName, "code5", dtWeb.Rows[0]["code5"].ToString());
            //                    }
            //                    else
            //                    {
            //                        xml.AddAttribute("/CpSort/QGTC/" + nvarName, "code", dtWeb.Rows[0]["code"].ToString());
            //                        if (dtWeb.Columns.Contains("tcode"))
            //                        {
            //                            if (dtWeb.Rows[0]["tcode"] != null)
            //                            {
            //                                xml.AddAttribute("/CpSort/QGTC/" + nvarName, "tcode", dtWeb.Rows[0]["tcode"].ToString());
            //                            }
            //                            else
            //                            {
            //                                xml.AddAttribute("/CpSort/QGTC/" + nvarName, "tcode", "");
            //                            }
            //                        }
            //                        else
            //                        {
            //                            xml.AddAttribute("/CpSort/QGTC/" + nvarName, "tcode", "");
            //                        }
            //                        ///
            //                        if ("TCDLTData" == row["NvarApp_name"].ToString())
            //                        {
            //                            xml.AddAttribute("/CpSort/QGTC/" + nvarName, "code2", dtWeb.Rows[0]["code2"].ToString());
            //                        }
            //                    }

            //                    xml.AddAttribute("/CpSort/QGTC/" + nvarName, "date", dtWeb.Rows[0]["date"].ToString());
            //                    xml.AddAttribute("/CpSort/QGTC/" + nvarName, "lott_date", row["NvarLott_date"].ToString());
            //                    xml.AddAttribute("/CpSort/QGTC/" + nvarName, "app", row["NvarApp_name"].ToString());

            //                    break;
            //            }
            //        }
            //        break;