using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.DBUtility;
using System.Collections;
using Pbzx.Common;
using System.Configuration;

namespace Pinble_Challenge
{
    public partial class Tlott : System.Web.UI.Page
    {
        Pbzx.BLL.Challenge_config get_cg = new Pbzx.BLL.Challenge_config();
        Pbzx.Model.Challenge_config mod_cg = new Pbzx.Model.Challenge_config();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region 验证显示执行开奖页面结果
                DateTime dtStart = DateTime.Now;
                TimeSpan tsStart = dtStart.TimeOfDay;
                string userIP = Request.UserHostAddress;
                string serverIP = ConfigurationManager.AppSettings["ServerIP"];  //获取IP
                if (serverIP == "" || serverIP.Contains(userIP))
                {
                    //当天执行页面标识 归0（未执行）
                    DataSet dspb = get_cg.GetList("attState='pblt'");
                    if (dspb != null && dspb.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToInt32(dspb.Tables[0].Rows[0]["Complete"].ToString()) == 1)
                        {
                            //验证当天是否已执行 (比对当天时间)
                            string t1 = Convert.ToDateTime(dspb.Tables[0].Rows[0]["CTime"]).ToShortDateString();
                            string t2 = DateTime.Now.ToShortDateString();
                            if (DateTime.Compare(Convert.ToDateTime(t1), Convert.ToDateTime(t2)) == 0 && DayOfWeek() == 1)
                            {
                                Response.Clear();
                                Response.Write("<a href='refresh'>refresh</a><br>");
                                Response.Write("≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡<br/>");
                                Response.Write("开奖已执行完成" + "<br/>");
                                Response.Write("≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡<br/>");
                                DateTime dtEnd1 = DateTime.Now;
                                TimeSpan tsJG1 = dtEnd1 - dtStart;
                                Response.Write("【" + Math.Floor(tsJG1.TotalSeconds) + "秒】" + dtStart + " - " + dtEnd1 + " ");
                                //停止页面加载
                                Response.End();
                            }
                            else
                            {
                                mod_cg = get_cg.GetModel(Convert.ToInt32(dspb.Tables[0].Rows[0]["id"].ToString()));
                                mod_cg.Complete = 0;
                                try
                                {
                                    get_cg.Update(mod_cg);
                                }
                                catch (Exception ex)
                                {
                                    Pbzx.Common.ErrorLog.WriteLog(ex);
                                }
                            }


                        }

                    }
                    //是否到了执行时间
                    string n_LottComp = Input.SetConfigValue("ExecutionTime", "TimeConfig.xml");
                    //每天的开奖时间
                    string time = DateTime.Now.ToShortDateString() + " " + n_LottComp;

                    string strTime1 = DateTime.Now.ToString();
                    string strTime2 = time;
                    DateTime dt1 = Convert.ToDateTime(strTime1);
                    DateTime dt2 = Convert.ToDateTime(strTime2);
                    int n = dt1.CompareTo(dt2);

                    Response.Clear();
                    Response.Write("<a href='refresh'>refresh</a><br>");
                    Response.Write("≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡<br/>");
                    if (n > 0)
                    {
                        try
                        {
                            winPoints();
                        }
                        catch (Exception ex)
                        {
                            Pbzx.Common.ErrorLog.WriteLog(ex);
                            Response.Write("开奖出现程序错误" + "<br/>");
                            Response.Write("≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡<br/>");
                            DateTime dtEnd1 = DateTime.Now;
                            TimeSpan tsJG1 = dtEnd1 - dtStart;
                            Response.Write("【" + Math.Floor(tsJG1.TotalSeconds) + "秒】" + dtStart + " - " + dtEnd1 + " ");
                            //停止页面加载
                            Response.End();
                        }
                        //检测当天是否已开奖
                        if (Convert.ToInt32(dspb.Tables[0].Rows[0]["Complete"]) == 0)
                        {
                            Response.Write("未开奖" + "<br/>");
                            Response.Write("≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡<br/>");
                            DateTime dtEnd = DateTime.Now;
                            TimeSpan tsJG = dtEnd - dtStart;
                            Response.Write("【" + Math.Floor(tsJG.TotalSeconds) + "秒】" + dtStart + " - " + dtEnd + " ");
                            //停止页面加载
                            Response.End();
                        }
                        if (Convert.ToInt32(dspb.Tables[0].Rows[0]["Complete"]) == 1)
                        {

                            Response.Write("开奖已完成" + "<br/>");
                            Response.Write("≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡<br/>");
                            DateTime dtEnd = DateTime.Now;
                            TimeSpan tsJG = dtEnd - dtStart;
                            Response.Write("【" + Math.Floor(tsJG.TotalSeconds) + "秒】" + dtStart + " - " + dtEnd + " ");
                            //停止页面加载
                            Response.End();
                        }
                    }
                    else
                    {
                        Response.Write("未到执行时间" + "<br/>");
                        Response.Write("≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡<br/>");
                        DateTime dtEnd = DateTime.Now;
                        TimeSpan tsJG = dtEnd - dtStart;
                        Response.Write("【" + Math.Floor(tsJG.TotalSeconds) + "秒】" + dtStart + " - " + dtEnd + " ");
                        //停止页面加载
                        Response.End();
                    }
                }
                #endregion

                //winPoints();
                
            }
        }


        /// <summary>
        /// 中奖获取积分
        /// </summary>
        public void winPoints()
        {
            string n_LottComp = Input.SetConfigValue("LottCompulsory", "TimeConfig.xml");
            //查询没有开奖的数据
            DataSet ds = DbHelperSQL.Query("select * from dbo.v_ReCon where C_win=0 and C_name is not null");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                //强制执行
                if (n_LottComp == "Y")
                {
                    try
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            CondCont(ds.Tables[0].Rows[i]["T_state"].ToString(), Convert.ToInt32(ds.Tables[0].Rows[i]["C_issue"]), ds.Tables[0].Rows[i]["C_num"].ToString(), ds.Tables[0].Rows[i]["C_name"].ToString(), Convert.ToInt32(ds.Tables[0].Rows[i]["C_lottID"]));
                            if (i == ds.Tables[0].Rows.Count-1)
                            {
                                DataSet ds_count = get_cg.GetList("attState='pblt'");
                                //查询 有无数据
                                if (ds_count.Tables[0].Rows.Count > 0 && ds_count != null)
                                {
                                    //删除数据
                                    if (DbHelperSQL.ExecuteSql("delete from dbo.Challenge_config where attState='pblt' ") > 0)
                                    {
                                        //添加执行完成记录
                                        mod_cg.CTime = DateTime.Now;
                                        mod_cg.Complete = 1;
                                        mod_cg.agreeRef = 0;
                                        mod_cg.lastIP = Request.UserHostAddress;
                                        mod_cg.attState = "pblt";
                                        get_cg.Add(mod_cg);
                                    }
                                }
                                else
                                {
                                    //添加执行完成记录
                                    mod_cg.CTime = DateTime.Now;
                                    mod_cg.Complete = 1;
                                    mod_cg.agreeRef = 0;
                                    mod_cg.lastIP = Request.UserHostAddress;
                                    mod_cg.attState = "pblt";
                                    get_cg.Add(mod_cg);
                                }

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //全局错误日志
                        Pbzx.Common.ErrorLog.WriteLog(ex);
                    }
                }
                else
                {
                    //正常执行数据
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        //双色球
                        if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_lottID"]) == 3 && DayOfWeek() == 0)
                        //if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_lottID"]) == 3)
                        {
                            //获取双色球执行统计的时间
                            string n_ssqTime = Input.SetConfigValue("FCSSDataTime", "TimeConfig.xml");
                            //设定允许执行时间
                            string exTime = DateTime.Now.ToShortDateString() + " " + n_ssqTime;
                            if (DateTime.Compare(DateTime.Now, Convert.ToDateTime(exTime)) > 0)
                            {
                                try
                                {
                                    CondCont(ds.Tables[0].Rows[i]["T_state"].ToString(), Convert.ToInt32(ds.Tables[0].Rows[i]["C_issue"]), ds.Tables[0].Rows[i]["C_num"].ToString(), ds.Tables[0].Rows[i]["C_name"].ToString(), Convert.ToInt32(ds.Tables[0].Rows[i]["C_lottID"]));

                                }
                                catch (Exception ex)
                                {
                                    //全局错误日志
                                    Pbzx.Common.ErrorLog.WriteLog(ex);
                                }
                            }
                        }

                        //3D
                        if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_lottID"]) == 1)
                        {
                            string n_ssqTime = Input.SetConfigValue("FC3DDataTime", "TimeConfig.xml");
                            //设定允许执行时间
                            string exTime = DateTime.Now.ToShortDateString() + " " + n_ssqTime;
                            if (DateTime.Compare(DateTime.Now, Convert.ToDateTime(exTime)) > 0)
                            {
                                try
                                {
                                    CondCont(ds.Tables[0].Rows[i]["T_state"].ToString(), Convert.ToInt32(ds.Tables[0].Rows[i]["C_issue"]), ds.Tables[0].Rows[i]["C_num"].ToString(), ds.Tables[0].Rows[i]["C_name"].ToString(), Convert.ToInt32(ds.Tables[0].Rows[i]["C_lottID"]));
                                }
                                catch (Exception ex)
                                {
                                    //全局错误日志
                                    Pbzx.Common.ErrorLog.WriteLog(ex);
                                }
                            }
                        }
                        //排列三
                        if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_lottID"]) == 9999)
                        {
                            string n_ssqTime = Input.SetConfigValue("TCPL35DataTime", "TimeConfig.xml");
                            //设定允许执行时间
                            string exTime = DateTime.Now.ToShortDateString() + " " + n_ssqTime;
                            if (DateTime.Compare(DateTime.Now, Convert.ToDateTime(exTime)) > 0)
                            {
                                try
                                {
                                    CondCont(ds.Tables[0].Rows[i]["T_state"].ToString(), Convert.ToInt32(ds.Tables[0].Rows[i]["C_issue"]), ds.Tables[0].Rows[i]["C_num"].ToString(), ds.Tables[0].Rows[i]["C_name"].ToString(), Convert.ToInt32(ds.Tables[0].Rows[i]["C_lottID"]));

                                }
                                catch (Exception ex)
                                {
                                    //全局错误日志
                                    Pbzx.Common.ErrorLog.WriteLog(ex);
                                }
                            }
                        }
                    }
                    DataSet ds_count = get_cg.GetList("attState='pblt'");
                    //查询 有无数据
                    if (ds_count.Tables[0].Rows.Count > 0 && ds_count != null)
                    {
                        //删除数据
                        if (DbHelperSQL.ExecuteSql("delete from dbo.Challenge_config where attState='pblt' ") > 0)
                        {
                            //添加执行完成记录
                            mod_cg.CTime = DateTime.Now;
                            mod_cg.Complete = 1;
                            mod_cg.agreeRef = 0;
                            mod_cg.lastIP = Request.UserHostAddress;
                            mod_cg.attState = "pblt";
                            get_cg.Add(mod_cg);
                        }
                    }
                    else
                    {
                        //添加执行完成记录
                        mod_cg.CTime = DateTime.Now;
                        mod_cg.Complete = 1;
                        mod_cg.agreeRef = 0;
                        mod_cg.lastIP = Request.UserHostAddress;
                        mod_cg.attState = "pblt";
                        get_cg.Add(mod_cg);
                    }
                }
            }
        }
        //(Convert.ToInt32(DateTime.Now.DayOfWeek) == 0 || DateTime.Now.DayOfWeek.ToString() == "Thursday" || DateTime.Now.DayOfWeek.ToString() == "Sunday")
        private int DayOfWeek()
        {
            int week=Convert.ToInt32(DateTime.Now.DayOfWeek);
            if (week == 0 || week == 2 || week == 4)
            {
                //星期二 四 日
                return 0;
            }
            return 1;
        }



        #region 不同的条件积分兑换

        /// <summary>
        /// 处理兑奖
        /// </summary>
        /// <param name="cond">条件名称</param>
        /// <param name="issue">期号</param>
        /// <param name="optionalNum">选择号码</param>
        /// <param name="name">会员名</param>
        /// <param name="lottid">彩种id</param>
        /// <returns></returns>
        public void CondCont(string cond,int issue,string optionalNum,string name,int lottid)
        {
            Pbzx.BLL.Challenge_type get_t = new Pbzx.BLL.Challenge_type();
            DataSet ds = new DataSet();
            int n_Integral=0;
            if (cond == "hq3d")
            { 
                //红球3胆
                //查询开奖号码
                string lottNum = SelectlottNum(issue);
                if (lottNum != "")
                {
                    n_Integral = Tlott_hq3d(lottNum.Split('+')[0].ToString(), optionalNum);
                    //修改会员积分
                    IntegralUser(n_Integral, name, cond,lottid,issue);
                    //获取条件ID
                    ds = get_t.GetList("T_state=" + "'" + cond + "'" + " and T_lottID=" + lottid);
                    updateCinfo(name, lottid, issue, Convert.ToInt32(ds.Tables[0].Rows[0]["T_id"]), n_Integral);
                }

            }
            if (cond == "hq6d")
            {
                //红球6胆
                //查询开奖号码
                string lottNum = SelectlottNum(issue);
                if (lottNum != "")
                {
                    n_Integral = Tlott_hq6d(lottNum.Split('+')[0].ToString(), optionalNum);
                    //修改会员积分
                    IntegralUser(n_Integral, name, cond, lottid, issue);
                    //获取条件ID
                    ds = get_t.GetList("T_state=" + "'" + cond + "'" + " and T_lottID=" + lottid);
                    updateCinfo(name, lottid, issue, Convert.ToInt32(ds.Tables[0].Rows[0]["T_id"]), n_Integral);
                }
            }
            if (cond == "s3hq")
            {
                //杀3红球
                //查询开奖号码
                string lottNum = SelectlottNum(issue);
                if (lottNum != "")
                {
                    n_Integral = Tlott_s3hq(lottNum.Split('+')[0].ToString(), optionalNum);
                    //修改会员积分
                    IntegralUser(n_Integral, name, cond, lottid, issue);
                    //获取条件ID
                    ds = get_t.GetList("T_state=" + "'" + cond + "'" + " and T_lottID=" + lottid);
                    updateCinfo(name, lottid, issue, Convert.ToInt32(ds.Tables[0].Rows[0]["T_id"]), n_Integral);
                }

            }
            if (cond == "s6hq")
            {
                //杀6红球
                //查询开奖号码
                string lottNum = SelectlottNum(issue);
                if (lottNum != "")
                {
                    n_Integral = Tlott_s6hq(lottNum.Split('+')[0].ToString(), optionalNum);
                    //修改会员积分
                    IntegralUser(n_Integral, name, cond, lottid, issue);
                    //获取条件ID
                    ds = get_t.GetList("T_state=" + "'" + cond + "'" + " and T_lottID=" + lottid);
                    updateCinfo(name, lottid, issue, Convert.ToInt32(ds.Tables[0].Rows[0]["T_id"]), n_Integral);
                }

            }
            if (cond == "lq1d")
            {
                //蓝球1胆
                //查询开奖号码
                string lottNum = SelectlottNum(issue);
                if (lottNum != "")
                {
                    n_Integral = Tlott_lq1d(lottNum.Split('+')[1].ToString(), optionalNum);
                    //修改会员积分
                    IntegralUser(n_Integral, name, cond, lottid, issue);
                    //获取条件ID
                    ds = get_t.GetList("T_state=" + "'" + cond + "'" + " and T_lottID=" + lottid);
                    updateCinfo(name, lottid, issue, Convert.ToInt32(ds.Tables[0].Rows[0]["T_id"]), n_Integral);
                }

            }
            if (cond == "lq3d")
            {
                //蓝球3胆
                //查询开奖号码
                string lottNum = SelectlottNum(issue);
                if (lottNum != "")
                {
                    n_Integral = Tlott_lq3d(lottNum.Split('+')[1].ToString(), optionalNum);
                    //修改会员积分
                    IntegralUser(n_Integral, name, cond, lottid, issue);
                    //获取条件ID
                    ds = get_t.GetList("T_state=" + "'" + cond + "'" + " and T_lottID=" + lottid);
                    updateCinfo(name, lottid, issue, Convert.ToInt32(ds.Tables[0].Rows[0]["T_id"]), n_Integral);
                }

            }
            if (cond == "s3lq")
            {
                //杀3蓝球
                //查询开奖号码
                string lottNum = SelectlottNum(issue);
                if (lottNum != "")
                {
                    n_Integral = Tlott_s3lq(lottNum.Split('+')[1].ToString(), optionalNum);
                    //修改会员积分
                    IntegralUser(n_Integral, name, cond, lottid, issue);
                    //获取条件ID
                    ds = get_t.GetList("T_state=" + "'" + cond + "'" + " and T_lottID=" + lottid);
                    updateCinfo(name, lottid, issue, Convert.ToInt32(ds.Tables[0].Rows[0]["T_id"]), n_Integral);
                }

            }
            if (cond == "s6lq")
            {
                //杀6蓝球
                //查询开奖号码
                string lottNum = SelectlottNum(issue);
                if (lottNum != "")
                {
                    n_Integral = Tlott_s6lq(lottNum.Split('+')[1].ToString(), optionalNum);
                    //修改会员积分
                    IntegralUser(n_Integral, name, cond, lottid, issue);
                    //获取条件ID
                    ds = get_t.GetList("T_state=" + "'" + cond + "'" + " and T_lottID=" + lottid);
                    updateCinfo(name, lottid, issue, Convert.ToInt32(ds.Tables[0].Rows[0]["T_id"]), n_Integral);
                }

            }
            if (cond == "h3l")
            {
                //12红+3蓝
                //查询开奖号码
                string lottNum = SelectlottNum(issue);
                if (lottNum != "")
                {
                    n_Integral = Tlott_h3l(lottNum, optionalNum);
                    //修改会员积分
                    IntegralUser(n_Integral, name, cond, lottid, issue);
                    //获取条件ID
                    ds = get_t.GetList("T_state=" + "'" + cond + "'" + " and T_lottID=" + lottid);
                    updateCinfo(name, lottid, issue, Convert.ToInt32(ds.Tables[0].Rows[0]["T_id"]), n_Integral);
                }

            }
            if (cond == "h2l")
            {
                //9红+2蓝
                //查询开奖号码
                string lottNum = SelectlottNum(issue);
                if (lottNum != "")
                {
                    n_Integral = Tlott_h2l(lottNum, optionalNum);
                    //修改会员积分
                    IntegralUser(n_Integral, name, cond, lottid, issue);
                    //获取条件ID
                    ds = get_t.GetList("T_state=" + "'" + cond + "'" + " and T_lottID=" + lottid);
                    updateCinfo(name, lottid, issue, Convert.ToInt32(ds.Tables[0].Rows[0]["T_id"]), n_Integral);
                }

            }
            /********3D 排3区********/
            if (cond == "dd" || cond=="pdd")
            {
                string lottNum = "";
                //独胆
                //查询开奖号码
                if (lottid == 1)
                {
                    lottNum = SelectlottNum_d(issue);
                }
                else
                {
                    lottNum = SelectlottNum_p(issue);
                }
                
                if (lottNum != "")
                {
                    n_Integral = Tlott_dd(lottNum.ToString(), optionalNum);
                    //修改会员积分
                    IntegralUser(n_Integral, name, cond, lottid, issue);
                    //获取条件ID
                    ds = get_t.GetList("T_state=" + "'" + cond + "'" + " and T_lottID=" + lottid);
                    updateCinfo(name, lottid, issue, Convert.ToInt32(ds.Tables[0].Rows[0]["T_id"]), n_Integral);
                }

            }
            if (cond == "sd" || cond=="psd")
            {
                string lottNum = "";
                //双胆
                //查询开奖号码
                if (lottid == 1)
                {
                    lottNum = SelectlottNum_d(issue);
                }
                else
                {
                    lottNum = SelectlottNum_p(issue);
                }

                if (lottNum != "")
                {
                    n_Integral = Tlott_sd(lottNum.ToString(), optionalNum);
                    //修改会员积分
                    IntegralUser(n_Integral, name, cond, lottid, issue);
                    //获取条件ID
                    ds = get_t.GetList("T_state=" + "'" + cond + "'" + " and T_lottID=" + lottid);
                    updateCinfo(name, lottid, issue, Convert.ToInt32(ds.Tables[0].Rows[0]["T_id"]), n_Integral);
                }

            }
            if (cond == "zx1z" || cond=="pzx1z")
            {
                string lottNum = "";
                // 组选1注
                //查询开奖号码
                if (lottid == 1)
                {
                    lottNum = SelectlottNum_d(issue);
                }
                else
                {
                    lottNum = SelectlottNum_p(issue);
                }

                if (lottNum != "")
                {
                    n_Integral = Tlott_zx1z(lottNum.ToString(), optionalNum);
                    //修改会员积分
                    IntegralUser(n_Integral, name, cond, lottid, issue);
                    //获取条件ID
                    ds = get_t.GetList("T_state=" + "'" + cond + "'" + " and T_lottID=" + lottid);
                    updateCinfo(name, lottid, issue, Convert.ToInt32(ds.Tables[0].Rows[0]["T_id"]), n_Integral);
                }

            }
            if (cond == "s1m" || cond=="ps1m")
            {
                string lottNum = "";
                //杀1码
                //查询开奖号码
                if (lottid == 1)
                {
                    lottNum = SelectlottNum_d(issue);
                }
                else
                {
                    lottNum = SelectlottNum_p(issue);
                }

                if (lottNum != "")
                {
                    n_Integral = Tlott_s1m(lottNum.ToString(), optionalNum);
                    //修改会员积分
                    IntegralUser(n_Integral, name, cond, lottid, issue);
                    //获取条件ID
                    ds = get_t.GetList("T_state=" + "'" + cond + "'" + " and T_lottID=" + lottid);
                    updateCinfo(name, lottid, issue, Convert.ToInt32(ds.Tables[0].Rows[0]["T_id"]), n_Integral);
                }

            }
            if (cond == "s2m" || cond=="ps2m")
            {
                string lottNum = "";
                //杀2码
                //查询开奖号码
                if (lottid == 1)
                {
                    lottNum = SelectlottNum_d(issue);
                }
                else
                {
                    lottNum = SelectlottNum_p(issue);
                }

                if (lottNum != "")
                {
                    n_Integral = Tlott_s2m(lottNum.ToString(), optionalNum);
                    //修改会员积分
                    IntegralUser(n_Integral, name, cond, lottid, issue);
                    //获取条件ID
                    ds = get_t.GetList("T_state=" + "'" + cond + "'" + " and T_lottID=" + lottid);
                    updateCinfo(name, lottid, issue, Convert.ToInt32(ds.Tables[0].Rows[0]["T_id"]), n_Integral);
                }

            }
            if (cond == "dk" || cond=="pdk")
            {
                string lottNum = "";
                //独跨
                //查询开奖号码
                if (lottid == 1)
                {
                    lottNum = SelectlottNum_d(issue);
                }
                else
                {
                    lottNum = SelectlottNum_p(issue);
                }

                if (lottNum != "")
                {
                    n_Integral = Tlott_dk(lottNum.ToString(), optionalNum);
                    //修改会员积分
                    IntegralUser(n_Integral, name, cond, lottid, issue);
                    //获取条件ID
                    ds = get_t.GetList("T_state=" + "'" + cond + "'" + " and T_lottID=" + lottid);
                    updateCinfo(name, lottid, issue, Convert.ToInt32(ds.Tables[0].Rows[0]["T_id"]), n_Integral);
                }

            }
            if (cond == "dh" || cond=="pdh")
            {
                string lottNum = "";
                //独合
                //查询开奖号码
                if (lottid == 1)
                {
                    lottNum = SelectlottNum_d(issue);
                }
                else
                {
                    lottNum = SelectlottNum_p(issue);
                }

                if (lottNum != "")
                {
                    n_Integral = Tlott_dh(lottNum.ToString(), optionalNum);
                    //修改会员积分
                    IntegralUser(n_Integral, name, cond, lottid, issue);
                    //获取条件ID
                    ds = get_t.GetList("T_state=" + "'" + cond + "'" + " and T_lottID=" + lottid);
                    updateCinfo(name, lottid, issue, Convert.ToInt32(ds.Tables[0].Rows[0]["T_id"]), n_Integral);
                }

            }
            if (cond == "s1h" || cond=="ps1h")
            {
                string lottNum = "";
                //杀1合
                //查询开奖号码
                if (lottid == 1)
                {
                    lottNum = SelectlottNum_d(issue);
                }
                else
                {
                    lottNum = SelectlottNum_p(issue);
                }

                if (lottNum != "")
                {
                    n_Integral = Tlott_s1h(lottNum.ToString(), optionalNum);
                    //修改会员积分
                    IntegralUser(n_Integral, name, cond, lottid, issue);
                    //获取条件ID
                    ds = get_t.GetList("T_state=" + "'" + cond + "'" + " and T_lottID=" + lottid);
                    updateCinfo(name, lottid, issue, Convert.ToInt32(ds.Tables[0].Rows[0]["T_id"]), n_Integral);
                }

            }
            if (cond == "5dw" || cond=="p5dw")
            {
                string lottNum = "";
                //5*5*5定位
                //查询开奖号码
                if (lottid == 1)
                {
                    lottNum = SelectlottNum_d(issue);
                }
                else
                {
                    lottNum = SelectlottNum_p(issue);
                }

                if (lottNum != "")
                {
                    n_Integral = Tlott_5dw(lottNum.ToString(), optionalNum);
                    //修改会员积分
                    IntegralUser(n_Integral, name, cond, lottid, issue);
                    //获取条件ID
                    ds = get_t.GetList("T_state=" + "'" + cond + "'" + " and T_lottID=" + lottid);
                    updateCinfo(name, lottid, issue, Convert.ToInt32(ds.Tables[0].Rows[0]["T_id"]), n_Integral);
                }

            }
            if (cond == "3dw" || cond=="p3dw")
            {
                string lottNum = "";
                //3*3*3 定位
                //查询开奖号码
                if (lottid == 1)
                {
                    lottNum = SelectlottNum_d(issue);
                }
                else
                {
                    lottNum = SelectlottNum_p(issue);
                }

                if (lottNum != "")
                {
                    n_Integral = Tlott_3dw(lottNum.ToString(), optionalNum);
                    //修改会员积分
                    IntegralUser(n_Integral, name, cond, lottid, issue);
                    //获取条件ID
                    ds = get_t.GetList("T_state=" + "'" + cond + "'" + " and T_lottID=" + lottid);
                    updateCinfo(name, lottid, issue, Convert.ToInt32(ds.Tables[0].Rows[0]["T_id"]), n_Integral);
                }

            }
            if (cond == "zx" || cond=="pzx")
            {
                string lottNum = "";
                //直选1注
                //查询开奖号码
                if (lottid == 1)
                {
                    lottNum = SelectlottNum_d(issue);
                }
                else
                {
                    lottNum = SelectlottNum_p(issue);
                }

                if (lottNum != "")
                {
                    n_Integral = Tlott_zx(lottNum.ToString(), optionalNum);
                    //修改会员积分
                    IntegralUser(n_Integral, name, cond, lottid, issue);
                    //获取条件ID
                    ds = get_t.GetList("T_state=" + "'" + cond + "'" + " and T_lottID=" + lottid);
                    updateCinfo(name, lottid, issue, Convert.ToInt32(ds.Tables[0].Rows[0]["T_id"]), n_Integral);
                }

            }
            if (cond == "m" || cond=="p5m")
            {
                string lottNum = "";
                //5码
                //查询开奖号码
                if (lottid == 1)
                {
                    lottNum = SelectlottNum_d(issue);
                }
                else
                {
                    lottNum = SelectlottNum_p(issue);
                }

                if (lottNum != "")
                {
                    n_Integral = Tlott_m(lottNum.ToString(), optionalNum);
                    //修改会员积分
                    IntegralUser(n_Integral, name, cond, lottid, issue);
                    //获取条件ID
                    ds = get_t.GetList("T_state=" + "'" + cond + "'" + " and T_lottID=" + lottid);
                    updateCinfo(name, lottid, issue, Convert.ToInt32(ds.Tables[0].Rows[0]["T_id"]), n_Integral);
                }

            }

        }
        #endregion

        #region   条件中奖所获得积分
        /// <summary>
        /// 红球3胆兑奖换积分
        /// </summary>
        /// <param name="lottNum">开奖红球号码</param>
        /// <param name="OptionalNum">自选红球号码</param>
        public int Tlott_hq3d(string lottNum,string OptionalNum)
        {
            int N_num = 0;
            for (int j = 0; j < OptionalNum.Split(',').Length; j++)
            {
                for (int i = 0; i < lottNum.Split(',').Length; i++)
                {
                    if (Convert.ToInt32(OptionalNum.Split(',')[j]) == Convert.ToInt32(lottNum.Split(',')[i]))
                    {
                        N_num = N_num + 1;
                    }
                }
                
            }
            if (N_num == 1)
            {
                string n_part= Input.SetConfigValue("h3HitOne", "lottIntegral.xml");
                if (n_part != "")
                {
                    return Convert.ToInt32(n_part);
                }
                
            }
            if (N_num == 2)
            {
                string n_part = Input.SetConfigValue("h3HitTwo", "lottIntegral.xml");
                if (n_part != "")
                {
                    return Convert.ToInt32(n_part);
                }

            }
            if (N_num == 3)
            {
                string n_part = Input.SetConfigValue("h3HitThree", "lottIntegral.xml");
                if (n_part != "")
                {
                    return Convert.ToInt32(n_part);
                }
            }
            return 0;
        }

        /// <summary>
        /// 红球6胆兑奖换积分
        /// </summary>
        /// <param name="lottNum">开奖红球号码</param>
        /// <param name="OptionalNum">自选号码</param>
        /// <returns></returns>
        public int Tlott_hq6d(string lottNum, string OptionalNum)
        {
            int N_num = 0;
            for (int j = 0; j < OptionalNum.Split(',').Length; j++)
            {
                for (int i = 0; i < lottNum.Split(',').Length; i++)
                {
                    if (Convert.ToInt32(OptionalNum.Split(',')[j]) == Convert.ToInt32(lottNum.Split(',')[i]))
                    {
                        N_num = N_num + 1;
                    }
                }

            }
            if (N_num == 1)
            {
                string n_part = Input.SetConfigValue("h6HitOne", "lottIntegral.xml");
                if (n_part != "")
                {
                    return Convert.ToInt32(n_part);
                }

            }
            if (N_num == 2)
            {
                string n_part = Input.SetConfigValue("h6HitTwo", "lottIntegral.xml");
                if (n_part != "")
                {
                    return Convert.ToInt32(n_part);
                }
            }
            if (N_num == 3)
            {
                string n_part = Input.SetConfigValue("h6HitThree", "lottIntegral.xml");
                if (n_part != "")
                {
                    return Convert.ToInt32(n_part);
                }
            }
            if (N_num == 4)
            {
                string n_part = Input.SetConfigValue("h6HitFour", "lottIntegral.xml");
                if (n_part != "")
                {
                    return Convert.ToInt32(n_part);
                }
            }
            if (N_num == 5)
            {
                string n_part = Input.SetConfigValue("h6HitFive", "lottIntegral.xml");
                if (n_part != "")
                {
                    return Convert.ToInt32(n_part);
                }
            }
            if (N_num == 6)
            {
                string n_part = Input.SetConfigValue("h6HitSix", "lottIntegral.xml");
                if (n_part != "")
                {
                    return Convert.ToInt32(n_part);
                }
            }
            return 0;
        }
        /// <summary>
        /// 杀3红球 兑奖换积分
        /// </summary>
        /// <param name="lottNum">开奖红球号码</param>
        /// <param name="OptionalNum">自选号码</param>
        /// <returns></returns>
        public int Tlott_s3hq(string lottNum, string OptionalNum)
        {
            int N_num = 0;
            for (int j = 0; j < OptionalNum.Split(',').Length; j++)
            {
                for (int i = 0; i < lottNum.Split(',').Length; i++)
                {
                    if (Convert.ToInt32(OptionalNum.Split(',')[j]) == Convert.ToInt32(lottNum.Split(',')[i]))
                    {
                        N_num = N_num + 1;
                    }
                }

            }
            if (N_num >0)
            {
                return 0;
            }

            string n_part = Input.SetConfigValue("s3hHit", "lottIntegral.xml");
            if (n_part == "")
            {
                return 0;
            }
            return Convert.ToInt32(n_part);
        }
        /// <summary>
        /// 杀6红球 兑奖换积分
        /// </summary>
        /// <param name="lottNum">开奖红球号码</param>
        /// <param name="OptionalNum">自选号码</param>
        /// <returns></returns>
        public int Tlott_s6hq(string lottNum, string OptionalNum)
        {
            int N_num = 0;
            for (int j = 0; j < OptionalNum.Split(',').Length; j++)
            {
                for (int i = 0; i < lottNum.Split(',').Length; i++)
                {
                    if (Convert.ToInt32(OptionalNum.Split(',')[j]) == Convert.ToInt32(lottNum.Split(',')[i]))
                    {
                        N_num = N_num + 1;
                    }
                }

            }
            if (N_num > 0)
            {
                return 0;
            }

            string n_part = Input.SetConfigValue("s6hHit", "lottIntegral.xml");
            if (n_part == "")
            {
                return 0;
            }
            return Convert.ToInt32(n_part);
        }
        /// <summary>
        /// 蓝球1胆 兑奖换积分
        /// </summary>
        /// <param name="lottNum">开奖蓝球号码</param>
        /// <param name="OptionalNum">自选号码</param>
        /// <returns></returns>
        public int Tlott_lq1d(string lottNum, string OptionalNum)
        {
            if (Convert.ToInt32(OptionalNum) == Convert.ToInt32(lottNum))
            {
                string n_part = Input.SetConfigValue("lHit", "lottIntegral.xml");
                if (n_part != "")
                {
                    return Convert.ToInt32(n_part);
                }
            }

            return 0;
        }
        /// <summary>
        /// 蓝球3胆 兑奖换积分
        /// </summary>
        /// <param name="lottNum">开奖蓝球号码</param>
        /// <param name="OptionalNum">自选号码</param>
        /// <returns></returns>
        public int Tlott_lq3d(string lottNum, string OptionalNum)
        {
            int N_num = 0;
            for (int j = 0; j < OptionalNum.Split(',').Length; j++)
            {
                if (Convert.ToInt32(OptionalNum.Split(',')[j]) == Convert.ToInt32(lottNum))
                {
                    N_num = N_num + 1;
                }

            }
            if (N_num ==1)
            {
                string n_part = Input.SetConfigValue("l3Hit", "lottIntegral.xml");
                if (n_part != "")
                {
                    return Convert.ToInt32(n_part);
                }
            }

            return 0;
        }

        /// <summary>
        /// 杀3蓝球 兑奖换积分
        /// </summary>
        /// <param name="lottNum">开奖蓝球号码</param>
        /// <param name="OptionalNum">自选号码</param>
        /// <returns></returns>
        public int Tlott_s3lq(string lottNum, string OptionalNum)
        {
            int N_num = 0;
            for (int j = 0; j < OptionalNum.Split(',').Length; j++)
            {
                if (Convert.ToInt32(OptionalNum.Split(',')[j]) == Convert.ToInt32(lottNum))
                {
                    N_num = N_num + 1;
                }

            }
            if (N_num > 0)
            {
                return 0;
            }

            string n_part = Input.SetConfigValue("s3lHit", "lottIntegral.xml");
            if (n_part == "")
            {
                return 0;
            } 
            return Convert.ToInt32(n_part);
        }
        /// <summary>
        /// 杀6蓝球 兑奖换积分
        /// </summary>
        /// <param name="lottNum">开奖蓝球号码</param>
        /// <param name="OptionalNum">自选号码</param>
        /// <returns></returns>
        public int Tlott_s6lq(string lottNum, string OptionalNum)
        {
            int N_num = 0;
            for (int j = 0; j < OptionalNum.Split(',').Length; j++)
            {
                if (Convert.ToInt32(OptionalNum.Split(',')[j]) == Convert.ToInt32(lottNum))
                {
                    N_num = N_num + 1;
                }

            }
            if (N_num > 0)
            {
                return 0;
            }

            string n_part = Input.SetConfigValue("s6lHit", "lottIntegral.xml");
            if (n_part == "")
            {
                return 0;
            }
            return Convert.ToInt32(n_part);
        }
        /// <summary>
        /// 12红+3蓝 兑奖换积分
        /// </summary>
        /// <param name="lottNum">开奖号码</param>
        /// <param name="OptionalNum">自选号码</param>
        /// <returns></returns>
        public int Tlott_h3l(string lottNum, string OptionalNum)
        {
            //红球中奖个数
            int n_numR = 0;
            //蓝球中奖个数
            int n_numB = 0;

            //开奖号码红球
            string l_red=lottNum.Split('+')[0].ToString(); 
            //开奖号码蓝球
            string l_blue = lottNum.Split('+')[1].ToString();

            //自选号码红球
            string o_red = OptionalNum.Split('+')[0].ToString();
            //自选号码蓝球
            string o_blue = OptionalNum.Split('+')[1].ToString();

            for (int i = 0; i < o_red.Split(',').Length; i++)
            {
                for (int j = 0; j < l_red.Split(',').Length; j++)
                {
                    if (Convert.ToInt32(o_red.Split(',')[i]) == Convert.ToInt32(l_red.Split(',')[j]))
                    {
                        n_numR = n_numR + 1;
                    }
                }
            }

            //所中蓝球个数
            for (int i = 0; i < o_blue.Split(',').Length; i++)
            {
                if (Convert.ToInt32(o_blue.Split(',')[i]) == Convert.ToInt32(l_blue))
                {
                    n_numB = n_numB + 1;
                }
            }
            if (n_numR == 6 && n_numB == 1)
            {
                string n_part = Input.SetConfigValue("h3l61Hit", "lottIntegral.xml");
                if (n_part != "")
                {
                    return Convert.ToInt32(n_part);
                }
            }
            if (n_numR == 6 && n_numB == 0)
            {
                string n_part = Input.SetConfigValue("h3l60Hit", "lottIntegral.xml");
                if (n_part != "")
                {
                    return Convert.ToInt32(n_part);
                }
            }
            if (n_numR == 5 && n_numB == 1)
            {
                string n_part = Input.SetConfigValue("h3l51Hit", "lottIntegral.xml");
                if (n_part != "")
                {
                    return Convert.ToInt32(n_part);
                }
            }
            if (n_numR == 5 && n_numB == 0)
            {
                string n_part = Input.SetConfigValue("h3l50Hit", "lottIntegral.xml");
                if (n_part != "")
                {
                    return Convert.ToInt32(n_part);
                }
            }
            if (n_numR == 4 && n_numB == 1)
            {
                string n_part = Input.SetConfigValue("h3l41Hit", "lottIntegral.xml");
                if (n_part != "")
                {
                    return Convert.ToInt32(n_part);
                }
            }
            if (n_numR == 4 && n_numB == 0)
            {
                string n_part = Input.SetConfigValue("h3l40Hit", "lottIntegral.xml");
                if (n_part != "")
                {
                    return Convert.ToInt32(n_part);
                }
            }
            if (n_numR == 3 && n_numB == 1)
            {
                string n_part = Input.SetConfigValue("h3l31Hit", "lottIntegral.xml");
                if (n_part != "")
                {
                    return Convert.ToInt32(n_part);
                }
            }
            if (n_numR == 3 && n_numB == 0)
            {
                string n_part = Input.SetConfigValue("h3l30Hit", "lottIntegral.xml");
                if (n_part != "")
                {
                    return Convert.ToInt32(n_part);
                }
            }
            if (n_numR == 2 && n_numB == 1)
            {
                string n_part = Input.SetConfigValue("h3l21Hit", "lottIntegral.xml");
                if (n_part != "")
                {
                    return Convert.ToInt32(n_part);
                }
            }
            if (n_numR == 2 && n_numB == 0)
            {
                string n_part = Input.SetConfigValue("h3l20Hit", "lottIntegral.xml");
                if (n_part != "")
                {
                    return Convert.ToInt32(n_part);
                }
            }
            if (n_numR == 1 && n_numB == 1)
            {
                string n_part = Input.SetConfigValue("h3l11Hit", "lottIntegral.xml");
                if (n_part != "")
                {
                    return Convert.ToInt32(n_part);
                }
            }
            if (n_numR == 0 && n_numB == 1)
            {
                string n_part = Input.SetConfigValue("h3l01Hit", "lottIntegral.xml");
                if (n_part != "")
                {
                    return Convert.ToInt32(n_part);
                }
            }
            return 0;
        }


        /// <summary>
        /// 9红+2蓝 兑奖换积分
        /// </summary>
        /// <param name="lottNum">开奖号码</param>
        /// <param name="OptionalNum">自选号码</param>
        /// <returns></returns>
        public int Tlott_h2l(string lottNum, string OptionalNum)
        {
            //红球中奖个数
            int n_numR = 0;
            //蓝球中奖个数
            int n_numB = 0;

            //开奖号码红球
            string l_red = lottNum.Split('+')[0].ToString();
            //开奖号码蓝球
            string l_blue = lottNum.Split('+')[1].ToString();

            //自选号码红球
            string o_red = OptionalNum.Split('+')[0].ToString();
            //自选号码蓝球
            string o_blue = OptionalNum.Split('+')[1].ToString();

            for (int i = 0; i < o_red.Split(',').Length; i++)
            {
                for (int j = 0; j < l_red.Split(',').Length; j++)
                {
                    if (Convert.ToInt32(o_red.Split(',')[i]) == Convert.ToInt32(l_red.Split(',')[j]))
                    {
                        n_numR = n_numR + 1;
                    }
                }
            }

            //所中蓝球个数
            for (int i = 0; i < o_blue.Split(',').Length; i++)
            {
                if (Convert.ToInt32(o_blue.Split(',')[i]) == Convert.ToInt32(l_blue))
                {
                    n_numB = n_numB + 1;
                }
            }
            if (n_numR == 6 && n_numB == 1)
            {
                string n_part = Input.SetConfigValue("h2l61Hit", "lottIntegral.xml");
                if (n_part != "")
                {
                    return Convert.ToInt32(n_part);
                }
            }
            if (n_numR == 6 && n_numB == 0)
            {
                string n_part = Input.SetConfigValue("h2l60Hit", "lottIntegral.xml");
                if (n_part != "")
                {
                    return Convert.ToInt32(n_part);
                }
            }
            if (n_numR == 5 && n_numB == 1)
            {
                string n_part = Input.SetConfigValue("h2l51Hit", "lottIntegral.xml");
                if (n_part != "")
                {
                    return Convert.ToInt32(n_part);
                }
            }
            if (n_numR == 5 && n_numB == 0)
            {
                string n_part = Input.SetConfigValue("h2l50Hit", "lottIntegral.xml");
                if (n_part != "")
                {
                    return Convert.ToInt32(n_part);
                }
            }
            if (n_numR == 4 && n_numB == 1)
            {
                string n_part = Input.SetConfigValue("h2l41Hit", "lottIntegral.xml");
                if (n_part != "")
                {
                    return Convert.ToInt32(n_part);
                }
            }
            if (n_numR == 4 && n_numB == 0)
            {
                string n_part = Input.SetConfigValue("h2l40Hit", "lottIntegral.xml");
                if (n_part != "")
                {
                    return Convert.ToInt32(n_part);
                }
            }
            if (n_numR == 3 && n_numB == 1)
            {
                string n_part = Input.SetConfigValue("h2l31Hit", "lottIntegral.xml");
                if (n_part != "")
                {
                    return Convert.ToInt32(n_part);
                }
            }
            if (n_numR == 3 && n_numB == 0)
            {
                string n_part = Input.SetConfigValue("h2l30Hit", "lottIntegral.xml");
                if (n_part != "")
                {
                    return Convert.ToInt32(n_part);
                }
            }
            if (n_numR == 2 && n_numB == 1)
            {
                string n_part = Input.SetConfigValue("h2l21Hit", "lottIntegral.xml");
                if (n_part != "")
                {
                    return Convert.ToInt32(n_part);
                }
            }
            if (n_numR == 2 && n_numB == 0)
            {
                string n_part = Input.SetConfigValue("h2l20Hit", "lottIntegral.xml");
                if (n_part != "")
                {
                    return Convert.ToInt32(n_part);
                }
            }
            if (n_numR == 1 && n_numB == 1)
            {
                string n_part = Input.SetConfigValue("h2l11Hit", "lottIntegral.xml");
                if (n_part != "")
                {
                    return Convert.ToInt32(n_part);
                }
            }
            if (n_numR == 0 && n_numB == 1)
            {
                string n_part = Input.SetConfigValue("h2l01Hit", "lottIntegral.xml");
                if (n_part != "")
                {
                    return Convert.ToInt32(n_part);
                }
            }
            return 0;
        }


        /********3D 排列3***********/
        /// <summary>
        /// 独胆 兑奖换积分
        /// </summary>
        /// <param name="lottNum">开奖号码</param>
        /// <param name="OptionalNum">自选号码</param>
        /// <returns></returns>
        public int Tlott_dd(string lottNum, string OptionalNum)
        {
            int n_num = 0;
            if (lottNum.Contains(OptionalNum))
            {
                n_num = n_num + 1;
            }
            if (n_num == 1)
            {
                string n_part = Input.SetConfigValue("ddHit", "lottIntegral.xml");
                if (n_part != "")
                {
                    return Convert.ToInt32(n_part);
                }
            }
            return 0;
        }
        /// <summary>
        /// 双胆 兑奖换积分
        /// </summary>
        /// <param name="lottNum">开奖号码</param>
        /// <param name="OptionalNum">自选号码</param>
        /// <returns></returns>
        public int Tlott_sd(string lottNum, string OptionalNum)
        {
            int n_num = 0;
            for (int i = 0; i < OptionalNum.Split(',').Length; i++)
            {
                if (lottNum.Contains(OptionalNum.Split(',')[i]))
                {
                    n_num = n_num + 1;
                    OptionalNum.Remove(OptionalNum.IndexOf(OptionalNum.Split(',')[i].ToString()), 1);
                }
            }
            if (n_num == 1)
            {
                string n_part = Input.SetConfigValue("sdHitOne", "lottIntegral.xml");
                if (n_part != "")
                {
                    return Convert.ToInt32(n_part);
                }
            }
            if (n_num == 2)
            {
                string n_part = Input.SetConfigValue("sdHitTwo", "lottIntegral.xml");
                if (n_part != "")
                {
                    return Convert.ToInt32(n_part);
                }
            }
            return 0;
        }
        /// <summary>
        /// 组选1注 兑奖换积分
        /// </summary>
        /// <param name="lottNum">开奖号码</param>
        /// <param name="OptionalNum">自选号码</param>
        /// <returns></returns>
        public int Tlott_zx1z(string lottNum, string OptionalNum)
        {
            int n_num = 0;
            for (int i = 0; i < 3; i++)
            {
                if (lottNum.Contains(OptionalNum.Split(',')[i]))
                {
                    n_num = n_num + 1;
                    OptionalNum.Remove(OptionalNum.IndexOf(OptionalNum.Split(',')[i].ToString()), 1);
                }
            }
            if (n_num == 3)
            {
                string n_part = Input.SetConfigValue("GroupHit", "lottIntegral.xml");
                if (n_part != "")
                {
                    return Convert.ToInt32(n_part);
                }
            }
            return 0;
        }
        /// <summary>
        /// 杀1码 兑奖换积分
        /// </summary>
        /// <param name="lottNum">开奖号码</param>
        /// <param name="OptionalNum">自选号码</param>
        /// <returns></returns>
        public int Tlott_s1m(string lottNum, string OptionalNum)
        {
            int n_num = 0;
            for (int i = 0; i < 3; i++)
            {
                if (Convert.ToInt32(lottNum.Split(',')[i]) == Convert.ToInt32(OptionalNum))
                {
                    n_num = n_num + 1;
                }
            }
            if (n_num > 0)
            {
                return 0;
            }
            string n_part = Input.SetConfigValue("sMHitOne", "lottIntegral.xml");
            if (n_part == "")
            {
                return 0;
            } 
            return Convert.ToInt32(n_part);
        }

        /// <summary>
        /// 杀2码 兑奖换积分
        /// </summary>
        /// <param name="lottNum">开奖号码</param>
        /// <param name="OptionalNum">自选号码</param>
        /// <returns></returns>
        public int Tlott_s2m(string lottNum, string OptionalNum)
        {
            int n_num = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < OptionalNum.Split(',').Length; j++)
                {
                    if (Convert.ToInt32(lottNum.Split(',')[i]) == Convert.ToInt32(OptionalNum.Split(',')[j]))
                    {
                        n_num = n_num + 1;
                    }
                }
            }
            if (n_num > 0)
            {
                return 0;
            }
            string n_part = Input.SetConfigValue("sMHitTwo", "lottIntegral.xml");
            if (n_part == "")
            {
                return 0;
            }
            return Convert.ToInt32(n_part);
        }
        /// <summary>
        /// 独跨 兑奖换积分
        /// </summary>
        /// <param name="lottNum">开奖号码</param>
        /// <param name="OptionalNum">自选号码</param>
        /// <returns></returns>
        public int Tlott_dk(string lottNum, string OptionalNum)
        {
            int n_num = 0;

            ArrayList arr = new ArrayList();
            for (int i = 0; i < 3; i++)
            {
                arr.Add(lottNum.Split(',')[i]);
            }
            //排序
            ArrayList arr_sort = arrlist(arr);
            int n_sort = Convert.ToInt32(arr_sort[2]) - Convert.ToInt32(arr_sort[0]);
            if (n_sort == Convert.ToInt32(OptionalNum))
            {
                n_num = 1;
            }
            if (n_num == 1)
            {
                string n_part = Input.SetConfigValue("dKHit", "lottIntegral.xml");
                if (n_part != "")
                {
                    return Convert.ToInt32(n_part);
                }
                
            }
            return 0;
        }
        /// <summary>
        /// 独合 兑奖换积分
        /// </summary>
        /// <param name="lottNum">开奖号码</param>
        /// <param name="OptionalNum">自选号码</param>
        /// <returns></returns>
        public int Tlott_dh(string lottNum, string OptionalNum)
        {

            int n_hop = Convert.ToInt32(lottNum.Split(',')[0]) + Convert.ToInt32(lottNum.Split(',')[1]) + Convert.ToInt32(lottNum.Split(',')[2]);

            int hop = -1;
            if (n_hop > 9)
            {
                hop = Convert.ToInt32(n_hop.ToString().Substring(1, 1));
            }
            else
            {
                hop = n_hop;
            }
            if (hop == Convert.ToInt32(OptionalNum))
            {
                string n_part = Input.SetConfigValue("dhHit", "lottIntegral.xml");
                if (n_part != "")
                {
                    return Convert.ToInt32(n_part);
                }
            }
            return 0;
        }

        /// <summary>
        /// 杀1合 兑奖换积分
        /// </summary>
        /// <param name="lottNum">开奖号码</param>
        /// <param name="OptionalNum">自选号码</param>
        /// <returns></returns>
        public int Tlott_s1h(string lottNum, string OptionalNum)
        {

            int n_hop = Convert.ToInt32(lottNum.Split(',')[0]) + Convert.ToInt32(lottNum.Split(',')[1]) + Convert.ToInt32(lottNum.Split(',')[2]);

            int hop = -1;
            if (n_hop > 9)
            {
                hop = Convert.ToInt32(n_hop.ToString().Substring(1, 1));
            }
            else
            {
                hop = n_hop;
            }
            if (hop == Convert.ToInt32(OptionalNum))
            {
                return 0;
            }
            string n_part = Input.SetConfigValue("shHit", "lottIntegral.xml");
            if (n_part == "")
            {
                return 0;
            }
            return Convert.ToInt32(n_part);
        }

        /// <summary>
        /// 5*5*5定位 兑奖换积分
        /// </summary>
        /// <param name="lottNum">开奖号码</param>
        /// <param name="OptionalNum">自选号码</param>
        /// <returns></returns>
        public int Tlott_5dw(string lottNum, string OptionalNum)
        {

            int n_num = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (Convert.ToInt32(lottNum.Split(',')[i]) == Convert.ToInt32(OptionalNum.Split(',')[i].Substring(j, 1)))
                    {
                        n_num = n_num + 1;
                    }
                }
            }
            if (n_num == 3)
            {
                string n_part = Input.SetConfigValue("dw5Hit", "lottIntegral.xml");
                if (n_part != "")
                {
                    return Convert.ToInt32(n_part);
                }
            }

             return 0;
        }
        /// <summary>
        /// 3*3*3定位 兑奖换积分
        /// </summary>
        /// <param name="lottNum">开奖号码</param>
        /// <param name="OptionalNum">自选号码</param>
        /// <returns></returns>
        public int Tlott_3dw(string lottNum, string OptionalNum)
        {

            int n_num = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Convert.ToInt32(lottNum.Split(',')[i]) == Convert.ToInt32(OptionalNum.Split(',')[i].Substring(j, 1)))
                    {
                        n_num = n_num + 1;
                    }
                }
            }
            if (n_num == 3)
            {
                string n_part = Input.SetConfigValue("dw3Hit", "lottIntegral.xml");
                if (n_part != "")
                {
                    return Convert.ToInt32(n_part);
                }
            }

            return 0;
        }

        /// <summary>
        /// 直选1注 兑奖换积分
        /// </summary>
        /// <param name="lottNum">开奖号码</param>
        /// <param name="OptionalNum">自选号码</param>
        /// <returns></returns>
        public int Tlott_zx(string lottNum, string OptionalNum)
        {

            int n_num = 0;

            for (int i = 0; i < 3; i++)
            {
                if (Convert.ToInt32(lottNum.Split(',')[i]) == Convert.ToInt32(OptionalNum.Split(',')[i]))
                {
                    n_num = n_num + 1;
                }
            }
            if (n_num == 3)
            {
                string n_part = Input.SetConfigValue("dirHit", "lottIntegral.xml");
                if (n_part != "")
                {
                    return Convert.ToInt32(n_part);
                }
            }

            return 0;
        }
        /// <summary>
        /// 5码 兑奖换积分
        /// </summary>
        /// <param name="lottNum">开奖号码</param>
        /// <param name="OptionalNum">自选号码</param>
        /// <returns></returns>
        public int Tlott_m(string lottNum, string OptionalNum)
        {

            int n_num = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < OptionalNum.Split(',').Length; j++)
                {
                    if (Convert.ToInt32(lottNum.Split(',')[i]) == Convert.ToInt32(OptionalNum.Split(',')[j]))
                    {
                        n_num = n_num + 1;
                    }
                }
                    
            }
            if (n_num == 3)
            {
                string n_part = Input.SetConfigValue("m5Hit", "lottIntegral.xml");
                if (n_part != "")
                {
                    return Convert.ToInt32(n_part);
                }
            }

            return 0;
        }

        #endregion



        #region  查询 双色球 3D 排列3开奖号码
        /// <summary>
        /// 查询双色球 开奖号码
        /// </summary>
        /// <param name="issue"></param>
        public string SelectlottNum(int issue)
        {
            DataSet ds = DbHelperSQL1.Query("select redcode,bluecode from FCSSData where issue=" + "'" + issue + "'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
               string num=ResNum_ssq(ds.Tables[0].Rows[0]["redcode"].ToString()+"+"+ds.Tables[0].Rows[0]["bluecode"].ToString());
               return num;
            }
            return "";
        }

        /// <summary>
        /// 查询3D开奖号码
        /// </summary>
        /// <param name="issue">期号</param>
        /// <returns></returns>
        public string SelectlottNum_d(int issue)
        {
            string wNum = Method.RlotteryNum(1, issue);
            if (wNum != "")
            {
                string num = ResNum_d(wNum);
                return num;
            }
            return "";
        }

        /// <summary>
        /// 查询排列3开奖号码
        /// </summary>
        /// <param name="issue"></param>
        /// <returns></returns>
        public string SelectlottNum_p(int issue)
        {
            string wNum = Method.RlotteryNum(9999, issue);
            if (wNum != "")
            {
                string num = ResNum_d(wNum);
                return num;
            }
            return "";
        }

        #endregion


        #region 把开奖号码用，号隔开

        /// <summary>
        /// 拆分双色球开奖号码
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string ResNum_ssq(string num)
        {
            string redball = num.Split('+')[0].ToString();
            string blueball = num.Split('+')[1].ToString();

            string NewRedball = "";
            //重新组合红球
            for (int i = 0; i < redball.Length / 2; i++)
            {
                NewRedball += redball.Substring(i * 2, 2).ToString() + ",";
            }

            string ballNum = NewRedball.Substring(0, NewRedball.Length - 1) +"+"+ blueball;

            return ballNum;
           
        }

        /// <summary>
        /// 拆分3D 排列3 开奖号码
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string ResNum_d(string num)
        {
            string newNum = "";
            for (int i = 0; i < 3; i++)
            {
                newNum += num.Substring(i, 1).ToString() + ",";  
            }
            return newNum.Substring(0, newNum.Length - 1);
        }

        #endregion


        /// <summary>
        /// 修改会员积分
        /// </summary>
        /// <param name="Integral">积分</param>
        /// <param name="userName">会员名称</param>
        /// <param name="cond">条件名称</param>
        /// <param name="issue">期号</param>
        public void IntegralUser(int Integral,string userName,string cond,int lottId,int issue)
        {
            Pbzx.BLL.Challenge_integral get_l = new Pbzx.BLL.Challenge_integral();
            Pbzx.Model.Challenge_integral mod_l = new Pbzx.Model.Challenge_integral();
            Pbzx.BLL.PlatformPublic_UserWinning get_puw = new Pbzx.BLL.PlatformPublic_UserWinning();
            Pbzx.Model.PlatformPublic_UserWinning mod_puw = new Pbzx.Model.PlatformPublic_UserWinning();
            if (Integral > 0)
            { 
                //是否已有积分
                DataSet ds = get_l.GetList("I_name=" + "'" + userName + "'" + " and I_condName=" + "'" + cond + "'" + " and I_lottid=" + lottId);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    //已有积分
                    int n_integral = Convert.ToInt32(ds.Tables[0].Rows[0]["I_Integral"]) + Integral;
                    try
                    {
                        //获取model 实体
                        mod_l = get_l.GetModel(Convert.ToInt32(ds.Tables[0].Rows[0]["I_id"]));

                        mod_l.I_integral = n_integral;
                        get_l.Update(mod_l);
                    }
                    catch (Exception ex)
                    {
                        //全局错误日志
                        Pbzx.Common.ErrorLog.WriteLog(ex);
                    }
                }
                else
                {
                    try
                    {
                        mod_l.I_name = userName;
                        mod_l.I_lottid = lottId;
                        mod_l.I_condName = cond;
                        mod_l.I_integral = Integral;
                        get_l.Add(mod_l);
                    }
                    catch (Exception ex)
                    {
                        //全局错误日志
                        Pbzx.Common.ErrorLog.WriteLog(ex);
                    }
                }
                try
                {
                    mod_puw.u_name = userName;
                    mod_puw.u_issue = issue;
                    mod_puw.u_lottId = lottId;
                    mod_puw.u_time = DateTime.Now;
                    mod_puw.u_wItem = cond;
                    mod_puw.u_wContent = "拼搏擂台中奖积分";
                    mod_puw.u_coin = Integral;
                    mod_puw.u_platform = "match";
                    mod_puw.u_Monery = 0;
                    get_puw.Add(mod_puw);
                }
                catch (Exception ex)
                {
                    //全局错误日志
                    Pbzx.Common.ErrorLog.WriteLog(ex);
                }
            }
        }
        /// <summary>
        /// 冒泡排序
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        private ArrayList arrlist(ArrayList arr)
        {
            for (int i = 0; i < arr.Count - 1; i++)
            {
                int flag = 1;
                for (int j = 0; j < arr.Count - 1 - i; j++)
                {

                    if (Convert.ToInt32(arr[j]) > Convert.ToInt32(arr[j + 1]))
                    {
                        flag = 0;
                        int temp = Convert.ToInt32(arr[j]);
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }

                }
                if (flag == 1)
                {
                    break;
                }
            }

            return arr;
        }

        /// <summary>
        /// 修改信息表的开奖标识
        /// </summary>
        /// <param name="username">会员名</param>
        /// <param name="C_lottID">彩种id</param>
        /// <param name="C_issue">期号</param>
        /// <param name="C_Tid">条件名</param>
        /// <param name="flag">中奖积分</param>
        public void updateCinfo(string username, int C_lottID, int C_issue,int C_Tid,int flag)
        {
            Pbzx.BLL.Challenge_Cinfo get_c = new Pbzx.BLL.Challenge_Cinfo();
            DataSet ds = get_c.GetList("C_name=" + "'" + username + "'" + " and C_lottID=" + C_lottID + " and C_issue=" + C_issue + " and C_Tid=" + C_Tid);
            Pbzx.Model.Challenge_Cinfo mod_c = get_c.GetModel(Convert.ToInt32(ds.Tables[0].Rows[0]["C_id"]));
            if (flag > 0)
            {
                mod_c.C_win = 1;
            }
            else
            {
                mod_c.C_win = 2;
            }
            get_c.Update(mod_c);
        }

    }
}