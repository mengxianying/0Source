using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;
using Pbzx.Common;
using Maticsoft.DBUtility;
using System.Collections;

namespace Pbzx.Web
{
    public class RefurbishCpSortTime : System.Web.UI.Page
    {
        public void BindData(string cpType)
        {

            Pbzx.Common.MyXML xml = new Pbzx.Common.MyXML("\\xml\\CpSortTime.xml");
            XmlNode root = xml.GetXmlRoot();
            if (cpType == "quanbu")
            {
                Pbzx.BLL.PBnet_LotteryMenu lottBLL = new Pbzx.BLL.PBnet_LotteryMenu();
                DataTable dt = lottBLL.GetList(" BitIs_show=1 order by IntClass_OrderId,NvarOrderId ").Tables[0];
                if (dt.Rows.Count < 1)
                {
                    return;
                }
                XmlNode QGFC = root.SelectSingleNode("/CpSort/QGFC");
                QGFC.RemoveAll();
                XmlNode QGTC = root.SelectSingleNode("/CpSort/QGTC");
                QGTC.RemoveAll();
                XmlNode GSFC = root.SelectSingleNode("/CpSort/GSFC");
                GSFC.RemoveAll();
                XmlNode GSTC = root.SelectSingleNode("/CpSort/GSTC");
                GSTC.RemoveAll();
                XmlNode GPFC = root.SelectSingleNode("/CpSort/GPFC");
                GPFC.RemoveAll();
                XmlNode GPTC = root.SelectSingleNode("/CpSort/GPTC");
                GPTC.RemoveAll();
                foreach (DataRow row in dt.Rows)
                {
                    string type = row["NvarClass"].ToString();
                    string nvarName = row["NvarName"].ToString();
                    if (Input.IsInteger(nvarName.Substring(0, 1)))
                    {
                        nvarName = "_" + nvarName;
                    }
                    else if (nvarName.Contains("＋"))
                    {
                        nvarName = nvarName.Replace("＋", "X");
                    }
                    //  nvarName = nvarName.Replace("\r\n", "");
                    DataTable dtWeb = DbHelperSQL1.Query("select top 1 * from " + row["NvarApp_name"].ToString() + " order by issue desc").Tables[0];
                    if (dtWeb.Rows.Count < 1)
                    {
                        return;
                    }
                    switch (type)
                    {
                        case "全国福彩":
                            xml.AddChildNode("/CpSort/" + QGFC.Name, nvarName);
                            // XmlNode temp = QGFC.SelectSingleNode("./" +nvarName);
                            xml.AddAttribute("/CpSort/QGFC/" + nvarName, "name", row["NvarName"].ToString());
                            xml.AddAttribute("/CpSort/QGFC/" + nvarName, "issue", dtWeb.Rows[0]["issue"].ToString());
                            if ("FCSSData" == row["NvarApp_name"].ToString())
                            {
                                xml.AddAttribute("/CpSort/QGFC/" + nvarName, "code", "");
                                xml.AddAttribute("/CpSort/QGFC/" + nvarName, "redcode", dtWeb.Rows[0]["redcode"].ToString());
                                xml.AddAttribute("/CpSort/QGFC/" + nvarName, "bluecode", dtWeb.Rows[0]["bluecode"].ToString());
                                if (dtWeb.Rows[0]["bluecode2"] != null)
                                {
                                    xml.AddAttribute("/CpSort/QGFC/" + nvarName, "bluecode2", dtWeb.Rows[0]["bluecode2"].ToString());
                                }
                            }
                            else if ("FC3DData" == row["NvarApp_name"].ToString())
                            {
                                string[] result = WebFunc.CalGZM(dtWeb.Rows[0]["testcode"].ToString());
                                string cstJin = result[0];
                                string HL1 = result[1];
                                string HL2 = result[2];
                                string deTestCode = result[3];
                                xml.AddAttribute("/CpSort/QGFC/" + nvarName, "code", dtWeb.Rows[0]["code"].ToString());
                                xml.AddAttribute("/CpSort/QGFC/" + nvarName, "testcode", dtWeb.Rows[0]["testcode"].ToString());
                                xml.AddAttribute("/CpSort/QGFC/" + nvarName, "machine", dtWeb.Rows[0]["machine"].ToString());
                                xml.AddAttribute("/CpSort/QGFC/" + nvarName, "ball", dtWeb.Rows[0]["ball"].ToString());
                                xml.AddAttribute("/CpSort/QGFC/" + nvarName, "decode", deTestCode);
                                xml.AddAttribute("/CpSort/QGFC/" + nvarName, "Jin", cstJin);
                                xml.AddAttribute("/CpSort/QGFC/" + nvarName, "HL1", HL1);
                                xml.AddAttribute("/CpSort/QGFC/" + nvarName, "HL2", HL2);
                            }
                            else
                            {
                                xml.AddAttribute("/CpSort/QGFC/" + nvarName, "code", dtWeb.Rows[0]["code"].ToString());
                            }
                            if (dtWeb.Columns.Contains("tcode"))
                            {
                                if (dtWeb.Rows[0]["tcode"] != null)
                                {
                                    xml.AddAttribute("/CpSort/QGFC/" + nvarName, "tcode", dtWeb.Rows[0]["tcode"].ToString());
                                }
                                else
                                {
                                    xml.AddAttribute("/CpSort/QGFC/" + nvarName, "tcode", "");
                                }
                            }
                            else
                            {
                                xml.AddAttribute("/CpSort/QGFC/" + nvarName, "tcode", "");
                            }
                            xml.AddAttribute("/CpSort/QGFC/" + nvarName, "date", dtWeb.Rows[0]["date"].ToString());
                            xml.AddAttribute("/CpSort/QGFC/" + nvarName, "lott_date", row["NvarLott_date"].ToString());
                            xml.AddAttribute("/CpSort/QGFC/" + nvarName, "app", row["NvarApp_name"].ToString());
                            Files.Create("/pb_cst.htm", "/Template/Fc3DGZM.aspx");
                            break;
                        case "全国体彩":
                            xml.AddChildNode("/CpSort/" + QGTC.Name, nvarName);
                            // 
                            xml.AddAttribute("/CpSort/QGTC/" + nvarName, "name", row["NvarName"].ToString());
                            xml.AddAttribute("/CpSort/QGTC/" + nvarName, "issue", dtWeb.Rows[0]["issue"].ToString());

                            if ("TCPL35Data" == row["NvarApp_name"].ToString())
                            {
                                xml.AddAttribute("/CpSort/QGTC/" + nvarName, "code", "");
                                xml.AddAttribute("/CpSort/QGTC/" + nvarName, "code3", dtWeb.Rows[0]["code3"].ToString());
                                xml.AddAttribute("/CpSort/QGTC/" + nvarName, "code5", dtWeb.Rows[0]["code5"].ToString());
                            }
                            else
                            {
                                xml.AddAttribute("/CpSort/QGTC/" + nvarName, "code", dtWeb.Rows[0]["code"].ToString());
                                if (dtWeb.Columns.Contains("tcode"))
                                {
                                    if (dtWeb.Rows[0]["tcode"] != null)
                                    {
                                        xml.AddAttribute("/CpSort/QGTC/" + nvarName, "tcode", dtWeb.Rows[0]["tcode"].ToString());
                                    }
                                    else
                                    {
                                        xml.AddAttribute("/CpSort/QGTC/" + nvarName, "tcode", "");
                                    }
                                }
                                else
                                {
                                    xml.AddAttribute("/CpSort/QGTC/" + nvarName, "tcode", "");
                                }
                                ///
                                if ("TCDLTData" == row["NvarApp_name"].ToString())
                                {
                                    xml.AddAttribute("/CpSort/QGTC/" + nvarName, "code2", dtWeb.Rows[0]["code2"].ToString());
                                }
                            }

                            xml.AddAttribute("/CpSort/QGTC/" + nvarName, "date", dtWeb.Rows[0]["date"].ToString());
                            xml.AddAttribute("/CpSort/QGTC/" + nvarName, "lott_date", row["NvarLott_date"].ToString());
                            xml.AddAttribute("/CpSort/QGTC/" + nvarName, "app", row["NvarApp_name"].ToString());

                            break;
                        case "各省福彩":

                            xml.AddChildNode("/CpSort/" + GSFC.Name, nvarName);
                            xml.AddAttribute("/CpSort/GSFC/" + nvarName, "name", row["NvarName"].ToString());
                            xml.AddAttribute("/CpSort/GSFC/" + nvarName, "issue", dtWeb.Rows[0]["issue"].ToString());
                            xml.AddAttribute("/CpSort/GSFC/" + nvarName, "code", dtWeb.Rows[0]["code"].ToString());
                            if (dtWeb.Columns.Contains("tcode"))
                            {
                                if (dtWeb.Rows[0]["tcode"] != null)
                                {
                                    xml.AddAttribute("/CpSort/GSFC/" + nvarName, "tcode", dtWeb.Rows[0]["tcode"].ToString());
                                }
                                else
                                {
                                    xml.AddAttribute("/CpSort/GSFC/" + nvarName, "tcode", "");
                                }
                            }
                            else
                            {
                                xml.AddAttribute("/CpSort/GSFC/" + nvarName, "tcode", "");
                            }
                            xml.AddAttribute("/CpSort/GSFC/" + nvarName, "date", dtWeb.Rows[0]["date"].ToString());
                            xml.AddAttribute("/CpSort/GSFC/" + nvarName, "lott_date", row["NvarLott_date"].ToString());
                            xml.AddAttribute("/CpSort/GSFC/" + nvarName, "app", row["NvarApp_name"].ToString());

                            break;
                        case "各省体彩":

                            xml.AddChildNode("/CpSort/" + GSTC.Name, nvarName);
                            xml.AddAttribute("/CpSort/GSTC/" + nvarName, "name", row["NvarName"].ToString());
                            xml.AddAttribute("/CpSort/GSTC/" + nvarName, "issue", dtWeb.Rows[0]["issue"].ToString());
                            xml.AddAttribute("/CpSort/GSTC/" + nvarName, "code", dtWeb.Rows[0]["code"].ToString());
                            if (dtWeb.Columns.Contains("tcode"))
                            {
                                if (dtWeb.Rows[0]["tcode"] != null)
                                {
                                    xml.AddAttribute("/CpSort/GSTC/" + nvarName, "tcode", dtWeb.Rows[0]["tcode"].ToString());
                                }
                                else
                                {
                                    xml.AddAttribute("/CpSort/GSTC/" + nvarName, "tcode", "");
                                }
                            }
                            else
                            {
                                xml.AddAttribute("/CpSort/GSTC/" + nvarName, "tcode", "");
                            }
                            xml.AddAttribute("/CpSort/GSTC/" + nvarName, "date", dtWeb.Rows[0]["date"].ToString());
                            xml.AddAttribute("/CpSort/GSTC/" + nvarName, "lott_date", row["NvarLott_date"].ToString());
                            xml.AddAttribute("/CpSort/GSTC/" + nvarName, "app", row["NvarApp_name"].ToString());

                            break;
                        case "高频福彩":

                            xml.AddChildNode("/CpSort/" + GPFC.Name, nvarName);


                            xml.AddAttribute("/CpSort/GPFC/" + nvarName, "name", row["NvarName"].ToString());
                            xml.AddAttribute("/CpSort/GPFC/" + nvarName, "issue", dtWeb.Rows[0]["issue"].ToString());
                            xml.AddAttribute("/CpSort/GPFC/" + nvarName, "code", dtWeb.Rows[0]["code"].ToString());
                            if (dtWeb.Columns.Contains("tcode"))
                            {
                                if (dtWeb.Rows[0]["tcode"] != null)
                                {
                                    xml.AddAttribute("/CpSort/GPFC/" + nvarName, "tcode", dtWeb.Rows[0]["tcode"].ToString());
                                }
                                else
                                {
                                    xml.AddAttribute("/CpSort/GPFC/" + nvarName, "tcode", "");
                                }
                            }
                            else
                            {
                                xml.AddAttribute("/CpSort/GPFC/" + nvarName, "tcode", "");
                            }
                            xml.AddAttribute("/CpSort/GPFC/" + nvarName, "date", dtWeb.Rows[0]["date"].ToString());
                            xml.AddAttribute("/CpSort/GPFC/" + nvarName, "lott_date", row["NvarLott_date"].ToString());
                            xml.AddAttribute("/CpSort/GPFC/" + nvarName, "app", row["NvarApp_name"].ToString());
                            break;
                        case "高频体彩":
                            xml.AddChildNode("/CpSort/" + GPTC.Name, nvarName);
                            xml.AddAttribute("/CpSort/GPTC/" + nvarName, "name", row["NvarName"].ToString());
                            xml.AddAttribute("/CpSort/GPTC/" + nvarName, "issue", dtWeb.Rows[0]["issue"].ToString());
                            xml.AddAttribute("/CpSort/GPTC/" + nvarName, "code", dtWeb.Rows[0]["code"].ToString());
                            if (dtWeb.Columns.Contains("tcode"))
                            {
                                if (dtWeb.Rows[0]["tcode"] != null)
                                {
                                    xml.AddAttribute("/CpSort/GPTC/" + nvarName, "tcode", dtWeb.Rows[0]["tcode"].ToString());
                                }
                                else
                                {
                                    xml.AddAttribute("/CpSort/GPTC/" + nvarName, "tcode", "");
                                }
                            }
                            else
                            {
                                xml.AddAttribute("/CpSort/GPTC/" + nvarName, "tcode", "");
                            }
                            xml.AddAttribute("/CpSort/GPTC/" + nvarName, "date", dtWeb.Rows[0]["date"].ToString());
                            xml.AddAttribute("/CpSort/GPTC/" + nvarName, "lott_date", row["NvarLott_date"].ToString());
                            xml.AddAttribute("/CpSort/GPTC/" + nvarName, "app", row["NvarApp_name"].ToString());
                            break;
                    }

                }
            }
            else if (cpType == "quanguo")
            {
                Pbzx.BLL.PBnet_LotteryMenu lottBLL = new Pbzx.BLL.PBnet_LotteryMenu();
                DataTable dt = null;
                dt = lottBLL.GetList(" BitState=1 and  BitIs_show=1 and (NvarClass='全国福彩' or  NvarClass='全国体彩')    order by IntClass_OrderId,NvarOrderId  ").Tables[0];//and (NvarClass='全国福彩' or  NvarClass='全国体彩') 
                if (dt.Rows.Count < 1)
                {
                    return;
                }
                XmlNode QGFC = root.SelectSingleNode("/CpSort/QGFC");
                QGFC.RemoveAll();
                XmlNode QGTC = root.SelectSingleNode("/CpSort/QGTC");
                QGTC.RemoveAll();
                foreach (DataRow row in dt.Rows)
                {
                    string type = row["NvarClass"].ToString();
                    string nvarName = row["NvarName"].ToString();
                    if (Input.IsInteger(nvarName.Substring(0, 1)))
                    {
                        nvarName = "_" + nvarName;
                    }
                    else if (nvarName.Contains("＋"))
                    {
                        nvarName = nvarName.Replace("＋", "X");
                    }
                    //  nvarName = nvarName.Replace("\r\n", "");
                    DataTable dtWeb = DbHelperSQL1.Query("select top 1 * from " + row["NvarApp_name"].ToString() + " order by issue desc").Tables[0];
                    if (dtWeb.Rows.Count < 1)
                    {
                        return;
                    }
                    switch (type)
                    {
                        case "全国福彩":
                            xml.AddChildNode("/CpSort/" + QGFC.Name, nvarName);
                            // XmlNode temp = QGFC.SelectSingleNode("./" +nvarName);
                            xml.AddAttribute("/CpSort/QGFC/" + nvarName, "name", row["NvarName"].ToString());
                            xml.AddAttribute("/CpSort/QGFC/" + nvarName, "issue", dtWeb.Rows[0]["issue"].ToString());
                            if ("FCSSData" == row["NvarApp_name"].ToString())
                            {
                                xml.AddAttribute("/CpSort/QGFC/" + nvarName, "code", "");
                                xml.AddAttribute("/CpSort/QGFC/" + nvarName, "redcode", dtWeb.Rows[0]["redcode"].ToString());
                                xml.AddAttribute("/CpSort/QGFC/" + nvarName, "bluecode", dtWeb.Rows[0]["bluecode"].ToString());
                                if (dtWeb.Rows[0]["bluecode2"] != null)
                                {
                                    xml.AddAttribute("/CpSort/QGFC/" + nvarName, "bluecode2", dtWeb.Rows[0]["bluecode2"].ToString());
                                }
                            }
                            else if ("FC3DData" == row["NvarApp_name"].ToString())
                            {
                                string[] result = WebFunc.CalGZM(dtWeb.Rows[0]["testcode"].ToString());
                                string cstJin = result[0];
                                string HL1 = result[1];
                                string HL2 = result[2];
                                string deTestCode = result[3];
                                xml.AddAttribute("/CpSort/QGFC/" + nvarName, "code", dtWeb.Rows[0]["code"].ToString());
                                xml.AddAttribute("/CpSort/QGFC/" + nvarName, "testcode", dtWeb.Rows[0]["testcode"].ToString());
                                xml.AddAttribute("/CpSort/QGFC/" + nvarName, "machine", dtWeb.Rows[0]["machine"].ToString());
                                xml.AddAttribute("/CpSort/QGFC/" + nvarName, "ball", dtWeb.Rows[0]["ball"].ToString());
                                xml.AddAttribute("/CpSort/QGFC/" + nvarName, "decode", deTestCode);
                                xml.AddAttribute("/CpSort/QGFC/" + nvarName, "Jin", cstJin);
                                xml.AddAttribute("/CpSort/QGFC/" + nvarName, "HL1", HL1);
                                xml.AddAttribute("/CpSort/QGFC/" + nvarName, "HL2", HL2);
                            }
                            else
                            {
                                xml.AddAttribute("/CpSort/QGFC/" + nvarName, "code", dtWeb.Rows[0]["code"].ToString());
                            }
                            if (dtWeb.Columns.Contains("tcode"))
                            {
                                if (dtWeb.Rows[0]["tcode"] != null)
                                {
                                    xml.AddAttribute("/CpSort/QGFC/" + nvarName, "tcode", dtWeb.Rows[0]["tcode"].ToString());
                                }
                                else
                                {
                                    xml.AddAttribute("/CpSort/QGFC/" + nvarName, "tcode", "");
                                }
                            }
                            else
                            {
                                xml.AddAttribute("/CpSort/QGFC/" + nvarName, "tcode", "");
                            }
                            xml.AddAttribute("/CpSort/QGFC/" + nvarName, "date", dtWeb.Rows[0]["date"].ToString());
                            xml.AddAttribute("/CpSort/QGFC/" + nvarName, "lott_date", row["NvarLott_date"].ToString());
                            xml.AddAttribute("/CpSort/QGFC/" + nvarName, "app", row["NvarApp_name"].ToString());
                            Files.Create("/pb_cst.htm", "/Template/Fc3DGZM.aspx");
                            break;
                        case "全国体彩":
                            xml.AddChildNode("/CpSort/" + QGTC.Name, nvarName);
                            // 
                            xml.AddAttribute("/CpSort/QGTC/" + nvarName, "name", row["NvarName"].ToString());
                            xml.AddAttribute("/CpSort/QGTC/" + nvarName, "issue", dtWeb.Rows[0]["issue"].ToString());

                            if ("TCPL35Data" == row["NvarApp_name"].ToString())
                            {
                                xml.AddAttribute("/CpSort/QGTC/" + nvarName, "code", "");
                                xml.AddAttribute("/CpSort/QGTC/" + nvarName, "code3", dtWeb.Rows[0]["code3"].ToString());
                                xml.AddAttribute("/CpSort/QGTC/" + nvarName, "code5", dtWeb.Rows[0]["code5"].ToString());
                            }
                            else
                            {
                                xml.AddAttribute("/CpSort/QGTC/" + nvarName, "code", dtWeb.Rows[0]["code"].ToString());
                                if (dtWeb.Columns.Contains("tcode"))
                                {
                                    if (dtWeb.Rows[0]["tcode"] != null)
                                    {
                                        xml.AddAttribute("/CpSort/QGTC/" + nvarName, "tcode", dtWeb.Rows[0]["tcode"].ToString());
                                    }
                                    else
                                    {
                                        xml.AddAttribute("/CpSort/QGTC/" + nvarName, "tcode", "");
                                    }
                                }
                                else
                                {
                                    xml.AddAttribute("/CpSort/QGTC/" + nvarName, "tcode", "");
                                }
                                ///
                                if ("TCDLTData" == row["NvarApp_name"].ToString())
                                {
                                    xml.AddAttribute("/CpSort/QGTC/" + nvarName, "code2", dtWeb.Rows[0]["code2"].ToString());
                                }
                            }

                            xml.AddAttribute("/CpSort/QGTC/" + nvarName, "date", dtWeb.Rows[0]["date"].ToString());
                            xml.AddAttribute("/CpSort/QGTC/" + nvarName, "lott_date", row["NvarLott_date"].ToString());
                            xml.AddAttribute("/CpSort/QGTC/" + nvarName, "app", row["NvarApp_name"].ToString());

                            break;
                    }
                }
            }
            else
            {
                Pbzx.BLL.PBnet_LotteryMenu lottBLL = new Pbzx.BLL.PBnet_LotteryMenu();
                DataTable dt = DbHelperSQL.Query(" select top 1 * from PBnet_LotteryMenu where NvarApp_name='" + cpType + "'  ").Tables[0];
                if (dt.Rows.Count < 1)
                {
                    return;
                }
                DataRow row = dt.Rows[0];
                string type = row["NvarClass"].ToString();
                string nvarName = row["NvarName"].ToString();
                if (Input.IsInteger(nvarName.Substring(0, 1)))
                {
                    nvarName = "_" + nvarName;
                }
                else if (nvarName.Contains("＋"))
                {
                    nvarName = nvarName.Replace("＋", "X");
                }
                DataTable dtWeb = DbHelperSQL1.Query("select top 1 * from " + row["NvarApp_name"].ToString() + " order by issue desc").Tables[0];
                if (dtWeb.Rows.Count < 1)
                {
                    return;
                }
                switch (type)
                {
                    case "全国福彩":
                        XmlNode QGFCitem = root.SelectSingleNode("/CpSort/QGFC/" + nvarName);
                        QGFCitem.Attributes.RemoveAll();
                        xml.AddAttribute("/CpSort/QGFC/" + nvarName, "name", row["NvarName"].ToString());
                        xml.AddAttribute("/CpSort/QGFC/" + nvarName, "issue", dtWeb.Rows[0]["issue"].ToString());
                        if ("FCSSData" == row["NvarApp_name"].ToString())
                        {
                            xml.AddAttribute("/CpSort/QGFC/" + nvarName, "code", "");
                            xml.AddAttribute("/CpSort/QGFC/" + nvarName, "redcode", dtWeb.Rows[0]["redcode"].ToString());
                            xml.AddAttribute("/CpSort/QGFC/" + nvarName, "bluecode", dtWeb.Rows[0]["bluecode"].ToString());
                            if (dtWeb.Rows[0]["bluecode2"] != null)
                            {
                                xml.AddAttribute("/CpSort/QGFC/" + nvarName, "bluecode2", dtWeb.Rows[0]["bluecode2"].ToString());
                            }
                        }
                        else if ("FC3DData" == row["NvarApp_name"].ToString())
                        {
                            string[] result = WebFunc.CalGZM(dtWeb.Rows[0]["testcode"].ToString());
                            string cstJin = result[0];
                            string HL1 = result[1];
                            string HL2 = result[2];
                            string deTestCode = result[3];
                            xml.AddAttribute("/CpSort/QGFC/" + nvarName, "code", dtWeb.Rows[0]["code"].ToString());
                            xml.AddAttribute("/CpSort/QGFC/" + nvarName, "testcode", dtWeb.Rows[0]["testcode"].ToString());
                            xml.AddAttribute("/CpSort/QGFC/" + nvarName, "machine", dtWeb.Rows[0]["machine"].ToString());
                            xml.AddAttribute("/CpSort/QGFC/" + nvarName, "ball", dtWeb.Rows[0]["ball"].ToString());
                            xml.AddAttribute("/CpSort/QGFC/" + nvarName, "decode", deTestCode);
                            xml.AddAttribute("/CpSort/QGFC/" + nvarName, "Jin", cstJin);
                            xml.AddAttribute("/CpSort/QGFC/" + nvarName, "HL1", HL1);
                            xml.AddAttribute("/CpSort/QGFC/" + nvarName, "HL2", HL2);

                        }
                        else
                        {
                            xml.AddAttribute("/CpSort/QGFC/" + nvarName, "code", dtWeb.Rows[0]["code"].ToString());
                        }
                        if (dtWeb.Columns.Contains("tcode"))
                        {
                            if (dtWeb.Rows[0]["tcode"] != null)
                            {
                                xml.AddAttribute("/CpSort/QGFC/" + nvarName, "tcode", dtWeb.Rows[0]["tcode"].ToString());
                            }
                            else
                            {
                                xml.AddAttribute("/CpSort/QGFC/" + nvarName, "tcode", "");
                            }
                        }
                        else
                        {
                            xml.AddAttribute("/CpSort/QGFC/" + nvarName, "tcode", "");
                        }
                        xml.AddAttribute("/CpSort/QGFC/" + nvarName, "date", dtWeb.Rows[0]["date"].ToString());
                        xml.AddAttribute("/CpSort/QGFC/" + nvarName, "lott_date", row["NvarLott_date"].ToString());
                        xml.AddAttribute("/CpSort/QGFC/" + nvarName, "app", row["NvarApp_name"].ToString());
                        Files.Create("/pb_cst.htm", "/Template/Fc3DGZM.aspx");
                        break;
                    case "全国体彩":
                        XmlNode QGTCitem = root.SelectSingleNode("/CpSort/QGTC/" + nvarName);
                        QGTCitem.Attributes.RemoveAll();
                        xml.AddAttribute("/CpSort/QGTC/" + nvarName, "name", row["NvarName"].ToString());
                        xml.AddAttribute("/CpSort/QGTC/" + nvarName, "issue", dtWeb.Rows[0]["issue"].ToString());

                        if ("TCPL35Data" == row["NvarApp_name"].ToString())
                        {
                            xml.AddAttribute("/CpSort/QGTC/" + nvarName, "code", "");
                            xml.AddAttribute("/CpSort/QGTC/" + nvarName, "code3", dtWeb.Rows[0]["code3"].ToString());
                            xml.AddAttribute("/CpSort/QGTC/" + nvarName, "code5", dtWeb.Rows[0]["code5"].ToString());
                        }
                        else
                        {
                            xml.AddAttribute("/CpSort/QGTC/" + nvarName, "code", dtWeb.Rows[0]["code"].ToString());
                            if (dtWeb.Columns.Contains("tcode"))
                            {
                                if (dtWeb.Rows[0]["tcode"] != null)
                                {
                                    xml.AddAttribute("/CpSort/QGTC/" + nvarName, "tcode", dtWeb.Rows[0]["tcode"].ToString());
                                }
                                else
                                {
                                    xml.AddAttribute("/CpSort/QGTC/" + nvarName, "tcode", "");
                                }
                            }
                            else
                            {
                                xml.AddAttribute("/CpSort/QGTC/" + nvarName, "tcode", "");
                            }
                            ///
                            if ("TCDLTData" == row["NvarApp_name"].ToString())
                            {
                                xml.AddAttribute("/CpSort/QGTC/" + nvarName, "code2", dtWeb.Rows[0]["code2"].ToString());
                            }
                        }

                        xml.AddAttribute("/CpSort/QGTC/" + nvarName, "date", dtWeb.Rows[0]["date"].ToString());
                        xml.AddAttribute("/CpSort/QGTC/" + nvarName, "lott_date", row["NvarLott_date"].ToString());
                        xml.AddAttribute("/CpSort/QGTC/" + nvarName, "app", row["NvarApp_name"].ToString());
                        //xml.AddAttribute("/CpSort/QGTC/" + nvarName, "info", row["LottTypeInfo"].ToString());
                        break;
                    case "各省福彩":
                        XmlNode GSFCitem = root.SelectSingleNode("/CpSort/GSFC/" + nvarName);
                        GSFCitem.Attributes.RemoveAll();
                        xml.AddAttribute("/CpSort/GSFC/" + nvarName, "name", row["NvarName"].ToString());
                        xml.AddAttribute("/CpSort/GSFC/" + nvarName, "issue", dtWeb.Rows[0]["issue"].ToString());
                        xml.AddAttribute("/CpSort/GSFC/" + nvarName, "code", dtWeb.Rows[0]["code"].ToString());
                        if (dtWeb.Columns.Contains("tcode"))
                        {
                            if (dtWeb.Rows[0]["tcode"] != null)
                            {
                                xml.AddAttribute("/CpSort/GSFC/" + nvarName, "tcode", dtWeb.Rows[0]["tcode"].ToString());
                            }
                            else
                            {
                                xml.AddAttribute("/CpSort/GSFC/" + nvarName, "tcode", "");
                            }
                        }
                        else
                        {
                            xml.AddAttribute("/CpSort/GSFC/" + nvarName, "tcode", "");
                        }
                        xml.AddAttribute("/CpSort/GSFC/" + nvarName, "date", dtWeb.Rows[0]["date"].ToString());
                        xml.AddAttribute("/CpSort/GSFC/" + nvarName, "lott_date", row["NvarLott_date"].ToString());
                        xml.AddAttribute("/CpSort/GSFC/" + nvarName, "app", row["NvarApp_name"].ToString());
                        break;
                    case "各省体彩":
                        XmlNode GSTCitem = root.SelectSingleNode("/CpSort/GSTC/" + nvarName);
                        GSTCitem.Attributes.RemoveAll();
                        xml.AddAttribute("/CpSort/GSTC/" + nvarName, "name", row["NvarName"].ToString());
                        xml.AddAttribute("/CpSort/GSTC/" + nvarName, "issue", dtWeb.Rows[0]["issue"].ToString());
                        xml.AddAttribute("/CpSort/GSTC/" + nvarName, "code", dtWeb.Rows[0]["code"].ToString());
                        if (dtWeb.Columns.Contains("tcode"))
                        {
                            if (dtWeb.Rows[0]["tcode"] != null)
                            {
                                xml.AddAttribute("/CpSort/GSTC/" + nvarName, "tcode", dtWeb.Rows[0]["tcode"].ToString());
                            }
                            else
                            {
                                xml.AddAttribute("/CpSort/GSTC/" + nvarName, "tcode", "");
                            }
                        }
                        else
                        {
                            xml.AddAttribute("/CpSort/GSTC/" + nvarName, "tcode", "");
                        }
                        xml.AddAttribute("/CpSort/GSTC/" + nvarName, "date", dtWeb.Rows[0]["date"].ToString());
                        xml.AddAttribute("/CpSort/GSTC/" + nvarName, "lott_date", row["NvarLott_date"].ToString());
                        xml.AddAttribute("/CpSort/GSTC/" + nvarName, "app", row["NvarApp_name"].ToString());
                        break;
                    case "高频福彩":
                        XmlNode GPFCitem = root.SelectSingleNode("/CpSort/GPFC/" + nvarName);
                        GPFCitem.Attributes.RemoveAll();
                        xml.AddAttribute("/CpSort/GPFC/" + nvarName, "name", row["NvarName"].ToString());
                        xml.AddAttribute("/CpSort/GPFC/" + nvarName, "issue", dtWeb.Rows[0]["issue"].ToString());
                        xml.AddAttribute("/CpSort/GPFC/" + nvarName, "code", dtWeb.Rows[0]["code"].ToString());
                        if (dtWeb.Columns.Contains("tcode"))
                        {
                            if (dtWeb.Rows[0]["tcode"] != null)
                            {
                                xml.AddAttribute("/CpSort/GPFC/" + nvarName, "tcode", dtWeb.Rows[0]["tcode"].ToString());
                            }
                            else
                            {
                                xml.AddAttribute("/CpSort/GPFC/" + nvarName, "tcode", "");
                            }
                        }
                        else
                        {
                            xml.AddAttribute("/CpSort/GPFC/" + nvarName, "tcode", "");
                        }
                        xml.AddAttribute("/CpSort/GPFC/" + nvarName, "date", dtWeb.Rows[0]["date"].ToString());
                        xml.AddAttribute("/CpSort/GPFC/" + nvarName, "lott_date", row["NvarLott_date"].ToString());
                        xml.AddAttribute("/CpSort/GPFC/" + nvarName, "app", row["NvarApp_name"].ToString());
                        break;
                    case "高频体彩":
                        XmlNode GPTCitem = root.SelectSingleNode("/CpSort/GPTC/" + nvarName);
                        GPTCitem.Attributes.RemoveAll();
                        xml.AddAttribute("/CpSort/GPTC/" + nvarName, "name", row["NvarName"].ToString());
                        xml.AddAttribute("/CpSort/GPTC/" + nvarName, "issue", dtWeb.Rows[0]["issue"].ToString());
                        xml.AddAttribute("/CpSort/GPTC/" + nvarName, "code", dtWeb.Rows[0]["code"].ToString());
                        if (dtWeb.Columns.Contains("tcode"))
                        {
                            if (dtWeb.Rows[0]["tcode"] != null)
                            {
                                xml.AddAttribute("/CpSort/GPTC/" + nvarName, "tcode", dtWeb.Rows[0]["tcode"].ToString());
                            }
                            else
                            {
                                xml.AddAttribute("/CpSort/GPTC/" + nvarName, "tcode", "");
                            }
                        }
                        else
                        {
                            xml.AddAttribute("/CpSort/GPTC/" + nvarName, "tcode", "");
                        }
                        xml.AddAttribute("/CpSort/GPTC/" + nvarName, "date", dtWeb.Rows[0]["date"].ToString());
                        xml.AddAttribute("/CpSort/GPTC/" + nvarName, "lott_date", row["NvarLott_date"].ToString());
                        xml.AddAttribute("/CpSort/GPTC/" + nvarName, "app", row["NvarApp_name"].ToString());
                        break;
                }

            }
            ///添加生成时间
            // XmlNode temp = QGFC.SelectSingleNode("./" +nvarName);
            //xml.AddAttribute("/CpSort/CreateTime", "time", DateTime.Now.ToString());
            XmlNode myTime = root.SelectSingleNode("/CpSort/CreateTime");
            myTime.Attributes.RemoveAll();
            xml.AddAttribute("/CpSort/CreateTime", "time", DateTime.Now.ToString());

        }

    }
}
