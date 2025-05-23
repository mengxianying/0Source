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
    public partial class SoftDownLoad : System.Web.UI.Page
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

                    //参数
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
                    Pbzx.BLL.PBnet_Soft softBLL = new Pbzx.BLL.PBnet_Soft();
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


                    string[] down1SZ = WebFunc.GetDownInfo("2", "1");
                    string[] down2SZ = WebFunc.GetDownInfo("2", "2");
                    string[] down3SZ = WebFunc.GetDownInfo("2", "3");
                    string[] down4SZ = WebFunc.GetDownInfo("2", "4");

                    string loginMsg = "";
                    if (par == "1" && down1SZ[4] == "1")
                    {
                        loginMsg = "请点击页面右上角的登录，登录网站后再下载！";
                    }
                    if (par == "2" && down2SZ[4] == "1")
                    {
                        loginMsg = "请点击页面右上角的登录，登录网站后再下载！";
                    }
                    if (par == "3" && down3SZ[4] == "1")
                    {
                        loginMsg = "请点击页面右上角的登录，登录网站后再下载！";
                    }
                    if (par == "4" && down4SZ[4] == "1")
                    {
                        loginMsg = "请点击页面右上角的登录，登录网站后再下载！";
                    }



                    //下载需要登录时，判断是否登录
                    if (!string.IsNullOrEmpty(loginMsg))
                    {
                        LoginSort login = new LoginSort();
                        ///判断用户是否登陆状态                
                        if (!login["manager_user"])
                        {
                            Response.Write("<script>alert('请点击页面右上角的登录，登录网站后再下载！');history.go(-1);</script>");
                            //Page.RegisterStartupScript(WebFunc.GetGuid(), JS.myAlert1("提示！", "请点击页面右上角的登录，登录网站后再下载！", 350, "1", "history.go(-1);", "", false, false));
                            return;
                        }
                    }

                        Pbzx.Model.PBnet_Soft softModel = softBLL.GetModel(intId);
                        if (softModel == null)
                        {
                            Response.Redirect("error.htm");
                            return;
                        }
                        else
                        {
                            //最后下载日期
                            DateTime dtLastHitTime = (DateTime)softModel.pb_LastHitTime;

                            //跨年
                            if (dtLastHitTime.Year == DateTime.Now.Year)
                            {
                                //跨月
                                if (dtLastHitTime.Month == DateTime.Now.Month)
                                {
                                    //跨天
                                    if (dtLastHitTime.Day != DateTime.Now.Day)
                                    {
                                        int dayse = (int)DateTime.Now.DayOfWeek;
                                        DateTime s1 = DateTime.Today.AddDays(-(dayse) + 1);
                                        //dtLastHitTime < s1
                                        if (dayse == 1)
                                        {
                                            //    DbHelperSQL.ExecuteSql("update PBnet_Soft set pb_DayHits=0,pb_WeekHits=0,pb_LastHitTime='" + DateTime.Now.ToString() + "' where PBnet_SoftID<>" + intId);
                                            DbHelperSQL.ExecuteSql("update PBnet_Soft set pb_DayHits=0,pb_WeekHits=0,pb_LastHitTime='" + DateTime.Now.ToString() + "'");
                                        }
                                        else
                                        {
                                            // DbHelperSQL.ExecuteSql("update PBnet_Soft set pb_DayHits=0,pb_LastHitTime='" + DateTime.Now.ToString() + "' where PBnet_SoftID<>" + intId);
                                            DbHelperSQL.ExecuteSql("update PBnet_Soft set pb_DayHits=0,pb_LastHitTime='" + DateTime.Now.ToString() + "'");
                                        }

                                    }
                                }
                                else
                                {
                                    int dayse = (int)DateTime.Now.DayOfWeek;
                                    if (dayse == 1)
                                    {
                                        // DbHelperSQL.ExecuteSql("update PBnet_Soft set pb_DayHits=0,pb_WeekHits=0,pb_MonthHits=0 ,pb_LastHitTime='" + DateTime.Now.ToString() + "' where PBnet_SoftID<>" + intId);
                                        DbHelperSQL.ExecuteSql("update PBnet_Soft set pb_DayHits=0,pb_WeekHits=0,pb_MonthHits=0 ,pb_LastHitTime='" + DateTime.Now.ToString() + "'");
                                    }
                                    else
                                    {
                                        //   DbHelperSQL.ExecuteSql("update PBnet_Soft set pb_DayHits=0,pb_WeekHits=0,pb_MonthHits=0 ,pb_LastHitTime='" + DateTime.Now.ToString() + "' where PBnet_SoftID<>" + intId);
                                        DbHelperSQL.ExecuteSql("update PBnet_Soft set pb_DayHits=0,pb_WeekHits=0,pb_MonthHits=0 ,pb_LastHitTime='" + DateTime.Now.ToString() + "'");
                                    }
                                }

                            }
                            else
                            {
                                //  DbHelperSQL.ExecuteSql("update PBnet_Soft set pb_DayHits=0,pb_WeekHits=0,pb_MonthHits=0 ,pb_LastHitTime='" + DateTime.Now.ToString() + "' where PBnet_SoftID<>" + intId);
                                DbHelperSQL.ExecuteSql("update PBnet_Soft set pb_DayHits=0,pb_WeekHits=0,pb_MonthHits=0 ,pb_LastHitTime='" + DateTime.Now.ToString() + "'");
                            }



                            //日下载量
                            //int dayHits = (int)softModel.pb_DayHits;
                            //int weekHits = (int)softModel.pb_WeekHits;
                            //int monthHits = (int)softModel.pb_MonthHits;
                            //if (dtLastHitTime.Year == DateTime.Now.Year)
                            //{
                            //    if (dtLastHitTime.Month == DateTime.Now.Month)
                            //    {
                            //        monthHits += 1;
                            //        int days = (int)DateTime.Now.DayOfWeek;
                            //        DateTime s1 = DateTime.Today.AddDays(-(days) + 1);
                            //        bool numbers = false;
                            //        if (softModel.pb_LastHitTime.Day == DateTime.Now.Day)
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
                            //    softModel.pb_LastHitTime = DateTime.Now;

                            Pbzx.Model.PBnet_Soft softModel1 = softBLL.GetModel(intId);
                            softModel1.pb_DayHits += 1;
                            softModel1.pb_MonthHits += 1;
                            softModel1.pb_WeekHits += 1;
                            softModel1.pb_Hits += 1;
                            softBLL.Update(softModel1);


                            string errMsg = "";
                            if (down1SZ[2] == "0" && down2SZ[2] == "0" && down3SZ[2] == "0" && down4SZ[2] == "0")
                            {
                                errMsg = "此下载地址已关闭！无法下载！";
                                //Page.RegisterStartupScript(WebFunc.GetGuid(), JS.myAlert1("提示！", "此下载地址已关闭！无法下载", 350, "1", "history.go(-1);", "", false, false));
                                //return;
                            }
                            else
                            {
                                if (par == "1")
                                {
                                    //有的话出现down1--start
                                    if (down1SZ[2] == "0" || string.IsNullOrEmpty(softModel.pb_DownloadUrl1))
                                    {
                                        errMsg = "此下载地址已关闭！无法下载！";
                                    }
                                    else
                                    {
                                        Response.Redirect(down1SZ[1] + softModel.pb_DownloadUrl1);
                                    }
                                    //有的话出现down1---end  
                                }

                                if (par == "2")
                                {
                                    //有的话出现down2--start
                                    if (down2SZ[2] == "0" || string.IsNullOrEmpty(softModel.pb_DownloadUrl2))
                                    {
                                        errMsg = "此下载地址已关闭！无法下载！";
                                    }
                                    else
                                    {
                                        Response.Redirect(down2SZ[1] + softModel.pb_DownloadUrl2);
                                    }
                                    //有的话出现down2--end

                                }

                                if (par == "3")
                                {
                                    //有的话出现down3--start
                                    if (down3SZ[2] == "0" || string.IsNullOrEmpty(softModel.pb_DownloadUrl3))
                                    {
                                        errMsg = "此下载地址已关闭！无法下载！";
                                    }
                                    else
                                    {
                                        Response.Redirect(down3SZ[1] + softModel.pb_DownloadUrl3);
                                    }
                                    //有的话出现down3--end
                                }

                                if (par == "4")
                                {
                                    //有的话出现down4--start
                                    if (down4SZ[2] == "0" || string.IsNullOrEmpty(softModel.pb_DownloadUrl4))
                                    {
                                        errMsg = "此下载地址已关闭！无法下载！";
                                    }
                                    else
                                    {
                                        Response.Redirect(down4SZ[1] + softModel.pb_DownloadUrl4);
                                    }
                                    //有的话出现down4--end
                                }

                                if (!string.IsNullOrEmpty(errMsg))
                                {
                                    Page.RegisterStartupScript(WebFunc.GetGuid(), JS.myAlert1("提示！", errMsg, 350, "1", "history.go(-1);", "", false, false));
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }
    
}
