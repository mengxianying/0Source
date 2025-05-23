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
using System.Collections.Generic;
using Maticsoft.DBUtility;

namespace Pbzx.Web
{
    public partial class ProductDownload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
//                string strReferrer = Request.UrlReferrer.Host;
//                if (string.IsNullOrEmpty(strReferrer))
//                {
//                    strReferrer = "";
//                }
//                if (string.IsNullOrEmpty(strReferrer) || !strReferrer.ToLower().Contains("pinble.") || string.IsNullOrEmpty(Request["reUrl"]) || string.IsNullOrEmpty(Request["id"]))
                if (string.IsNullOrEmpty(Request["reUrl"]) || string.IsNullOrEmpty(Request["id"]))
                {
                    Response.Redirect("error.htm");
                    return;
                }
                else
                {
                    string errMsg = "";
                    //����
                    string par = Request["reUrl"];
                    if (par.Length >= 5)
                    {
                        par = par.Substring(0, 5);
                    }
                    par = Input.Filter(par);
                    string id = Request["id"];
                    if (id.Length >= 5)
                    {
                        id = id.Substring(0, 5);
                    }
                    id = Input.Filter(id);
                    Pbzx.BLL.PBnet_Product productBLL = new Pbzx.BLL.PBnet_Product();
                    int intId = 0;
                    if (!OperateText.IsNumber(par) || !OperateText.IsNumber(id) || !int.TryParse(id, out intId))
                    {
                        Response.Redirect("error.htm");
                        return;
                    }
                    if (!(par == "1" || par == "2" || par == "3" || par == "4"))
                    {
                        Response.Redirect("error.htm");
                        return;
                    }

                    string[] down1SZ = WebFunc.GetDownInfo("1", "1");
                    string[] down2SZ = WebFunc.GetDownInfo("1", "2");
                    string[] down3SZ = WebFunc.GetDownInfo("1", "3");
                    string[] down4SZ = WebFunc.GetDownInfo("1", "4");

                    string loginMsg = "";
                    if (par == "1" && down1SZ[4] == "1")
                    {
                        loginMsg = "����ҳ�����Ͻǵĵ�¼����¼��վ�������أ�";
                    }
                    if (par == "2" && down2SZ[4] == "1")
                    {
                        loginMsg = "����ҳ�����Ͻǵĵ�¼����¼��վ�������أ�";
                    }
                    if (par == "3" && down3SZ[4] == "1")
                    {
                        loginMsg = "����ҳ�����Ͻǵĵ�¼����¼��վ�������أ�";
                    }
                    if (par == "4" && down4SZ[4] == "1")
                    {
                        loginMsg = "����ҳ�����Ͻǵĵ�¼����¼��վ�������أ�";
                    }



                    //������Ҫ��¼ʱ���ж��Ƿ��¼
                    if (!string.IsNullOrEmpty(loginMsg))
                    {
                        LoginSort login = new LoginSort();
                        ///�ж��û��Ƿ��½״̬                
                        if (!login["manager_user"])
                        {
                            Response.Write("<script>alert('����ҳ�����Ͻǵĵ�¼����¼��վ�������أ�');history.go(-1);</script>");
                            //Page.RegisterStartupScript(WebFunc.GetGuid(), JS.myAlert1("��ʾ��", "����ҳ�����Ͻǵĵ�¼����¼��վ�������أ�", 350, "1", "history.go(-1);", "", false, false));
                            return;
                        }
                    }





                    Pbzx.Model.PBnet_Product productModel = productBLL.GetModel(intId);
                    if (productModel == null)
                    {
                        Response.Redirect("error.htm");
                        return;
                    }


                    //�����������
                    DateTime dtLastHitTime = productModel.pb_LastHitTime;

                    //����
                    if (dtLastHitTime.Year == DateTime.Now.Year)
                    {
                        //����
                        if (dtLastHitTime.Month == DateTime.Now.Month)
                        {
                            //����
                            if (dtLastHitTime.Day != DateTime.Now.Day)
                            {
                                int dayse = (int)DateTime.Now.DayOfWeek;
                                DateTime s1 = DateTime.Today.AddDays(-(dayse) + 1);
                                //dtLastHitTime < s1
                                if (dayse == 1)
                                {
                                    //   DbHelperSQL.ExecuteSql("update PBnet_Product set pb_DayHits=0,pb_WeekHits=0,pb_LastHitTime='" + DateTime.Now.ToString() + "' where pb_SoftID<>" + intId);
                                    DbHelperSQL.ExecuteSql("update PBnet_Product set pb_DayHits=0,pb_WeekHits=0,pb_LastHitTime='" + DateTime.Now.ToString() + "'");
                                }
                                else
                                {
                                    // DbHelperSQL.ExecuteSql("update PBnet_Product set pb_DayHits=0,pb_LastHitTime='" + DateTime.Now.ToString() + "' where pb_SoftID<>" + intId);
                                    DbHelperSQL.ExecuteSql("update PBnet_Product set pb_DayHits=0,pb_LastHitTime='" + DateTime.Now.ToString() + "'");
                                }

                            }
                        }
                        else
                        {
                            int dayse = (int)DateTime.Now.DayOfWeek;
                            if (dayse == 1)
                            {
                                //    DbHelperSQL.ExecuteSql("update PBnet_Product set pb_DayHits=0,pb_WeekHits=0,pb_MonthHits=0 ,pb_LastHitTime='" + DateTime.Now.ToString() + "' where pb_SoftID<>" + intId);
                                DbHelperSQL.ExecuteSql("update PBnet_Product set pb_DayHits=0,pb_WeekHits=0,pb_MonthHits=0 ,pb_LastHitTime='" + DateTime.Now.ToString() + "'");
                            }
                            else
                            {
                                //      DbHelperSQL.ExecuteSql("update PBnet_Product set pb_DayHits=0,pb_WeekHits=0,pb_MonthHits=0 ,pb_LastHitTime='" + DateTime.Now.ToString() + "' where pb_SoftID<>" + intId);
                                DbHelperSQL.ExecuteSql("update PBnet_Product set pb_DayHits=0,pb_WeekHits=0,pb_MonthHits=0 ,pb_LastHitTime='" + DateTime.Now.ToString() + "'");
                            }
                        }

                    }
                    else
                    {
                        //    DbHelperSQL.ExecuteSql("update PBnet_Product set pb_DayHits=0,pb_WeekHits=0,pb_MonthHits=0 ,pb_LastHitTime='" + DateTime.Now.ToString() + "' where pb_SoftID<>" + intId);
                        DbHelperSQL.ExecuteSql("update PBnet_Product set pb_DayHits=0,pb_WeekHits=0,pb_MonthHits=0 ,pb_LastHitTime='" + DateTime.Now.ToString() + "'");
                    }

                    //��������
                    int dayHits = productModel.pb_DayHits;
                    int weekHits = productModel.pb_WeekHits;
                    int monthHits = productModel.pb_MonthHits;
                    //if (dtLastHitTime.Year == DateTime.Now.Year)
                    //{
                    //    if (dtLastHitTime.Month == DateTime.Now.Month)
                    //    {
                    //        monthHits += 1;
                    //        int days = (int)DateTime.Now.DayOfWeek;
                    //        DateTime s1 = DateTime.Today.AddDays(-(days) + 1);
                    //        bool numbers = false;
                    //        if (productModel.pb_LastHitTime.Day == DateTime.Now.Day)
                    //        {
                    //            numbers = true;
                    //        }
                    //        if (days == 1 && numbers == false)
                    //        {
                    //            weekHits = 1;
                    //            dayHits = 1;
                    //        }
                    //        else
                    //        {
                    //            weekHits += 1;
                    //            if (dtLastHitTime.Date == DateTime.Now.Date)
                    //            {
                    //                dayHits += 1;
                    //            }
                    //            else
                    //            {
                    //                dayHits = 1;
                    //            }
                    //        }
                    //    }
                    //    else
                    //    {
                    //        dayHits = 1;
                    //        weekHits = 1;
                    //        monthHits = 1;
                    //    }
                    //}
                    //else
                    //{
                    //    dayHits = 1;
                    //    weekHits = 1;
                    //    monthHits = 1;
                    //}
                    //    productModel.pb_LastHitTime = DateTime.Now;
                    Pbzx.Model.PBnet_Product productModel1 = productBLL.GetModel(intId);
                    productModel1.pb_DayHits += 1;
                    productModel1.pb_MonthHits += 1;
                    productModel1.pb_WeekHits += 1;
                    productModel1.pb_Hits += 1;
                    productBLL.Update(productModel1);




                    if (down1SZ[2] == "0" && down2SZ[2] == "0" && down3SZ[2] == "0" && down4SZ[2] == "0")
                    {
                        errMsg = "�����ص�ַ�ѹرգ��޷����أ�";
                        //Page.RegisterStartupScript(WebFunc.GetGuid(), JS.myAlert1("��ʾ��", "�����ص�ַ�ѹرգ��޷�����", 350, "1", "history.go(-1);", "", false, false));
                        //return;
                    }
                    if (par == "1")
                    {
                        //�еĻ�����down1--start
                        if (down1SZ[2] == "0" || string.IsNullOrEmpty(productModel.pb_DownloadUrl1))
                        {
                            errMsg = "�����ص�ַ�ѹرգ��޷����أ�";
                        }
                        else
                        {
                            Response.Redirect(down1SZ[1] + productModel.pb_DownloadUrl1);
                        }
                        //�еĻ�����down1---end  
                    }

                    if (par == "2")
                    {
                        //�еĻ�����down2--start
                        if (down2SZ[2] == "0" || string.IsNullOrEmpty(productModel.pb_DownloadUrl2))
                        {
                            errMsg = "�����ص�ַ�ѹرգ��޷����أ�";
                        }
                        else
                        {
                            Response.Redirect(down2SZ[1] + productModel.pb_DownloadUrl2);
                        }
                        //�еĻ�����down2--end

                    }

                    if (par == "3")
                    {
                        //�еĻ�����down3--start
                        if (down3SZ[2] == "0" || string.IsNullOrEmpty(productModel.pb_DownloadUrl3))
                        {
                            errMsg = "�����ص�ַ�ѹرգ��޷����أ�";
                        }
                        else
                        {
                            Response.Redirect(down3SZ[1] + productModel.pb_DownloadUrl3);
                        }
                        //�еĻ�����down3--end
                    }

                    if (par == "4")
                    {
                        //�еĻ�����down4--start
                        if (down4SZ[2] == "0" || string.IsNullOrEmpty(productModel.pb_DownloadUrl4))
                        {
                            errMsg = "�����ص�ַ�ѹرգ��޷����أ�";
                        }
                        else
                        {
                            Response.Redirect(down4SZ[1] + productModel.pb_DownloadUrl4);
                        }
                        //�еĻ�����down4--end
                    }

                    if (!string.IsNullOrEmpty(errMsg))
                    {
                        Page.RegisterStartupScript(WebFunc.GetGuid(), JS.myAlert1("��ʾ��", errMsg, 350, "1", "history.go(-1);", "", false, false));
                        return;
                    }
                }
            }
        }
    }
}
