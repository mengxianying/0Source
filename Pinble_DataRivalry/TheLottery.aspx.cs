using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using Pbzx.Common;
using System.Configuration;
using Maticsoft.DBUtility;

namespace Pinble_DataRivalry
{
    public partial class TheLottery : System.Web.UI.Page
    {
        Pbzx.BLL.DataRivalry_downLoad get_dd = new Pbzx.BLL.DataRivalry_downLoad();
        Pbzx.BLL.DataRivalry_UpLoadFile get_u = new Pbzx.BLL.DataRivalry_UpLoadFile();
        Pbzx.BLL.DataRivalry_Rt get_r = new Pbzx.BLL.DataRivalry_Rt();
        Pbzx.BLL.Challenge_config get_cg = new Pbzx.BLL.Challenge_config();
        Pbzx.Model.Challenge_config mod_cg = new Pbzx.Model.Challenge_config();
        protected void Page_Load(object sender, EventArgs e)
        {
            SetPageNoCache();
            if (!IsPostBack)
            {
                
                #region   大底开奖计算处理
                DateTime dtStart = DateTime.Now;
                TimeSpan tsStart = dtStart.TimeOfDay;
                string userIP = Request.UserHostAddress;
                string serverIP = ConfigurationManager.AppSettings["ServerIP"];
                if (serverIP == "" || serverIP.Contains(userIP))
                {
                    #region 执行
                    //当天执行页面标识 归0（未执行）
                    DataSet ds = get_cg.GetList("attState='ddbp'");
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToInt32(ds.Tables[0].Rows[0]["Complete"].ToString()) == 1)
                        {
                            //验证当天是否已执行 (比对当天时间)
                            string t1 = Convert.ToDateTime(ds.Tables[0].Rows[0]["CTime"]).ToShortDateString();
                            string t2 = DateTime.Now.ToShortDateString();
                            if (DateTime.Compare(Convert.ToDateTime(t1), Convert.ToDateTime(t2)) == 0)
                            {
                                string t3=Input.SetConfigValue("ExecutionTime", "TimeConfig.xml");
                                Response.Clear();
                                Response.Write("<a href='refresh'>refresh</a><br>");
                                Response.Write("≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡<br/>");
                                Response.Write("上次开奖时间为： " + t1 + "<br/>");
                                Response.Write("开奖已执行完成" + "<br/>");

                                Response.Write("开奖时间为：" + t2 + " " + t3 + "<br/>");
                                Response.Write("≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡<br/>");
                                DateTime dtEnd1 = DateTime.Now;
                                TimeSpan tsJG1 = dtEnd1 - dtStart;
                                Response.Write("【" + Math.Floor(tsJG1.TotalSeconds) + "秒】" + dtStart + " - " + dtEnd1 + " ");
                                //停止页面加载
                                Response.End();
                            }
                            else
                            {
                                mod_cg = get_cg.GetModel(Convert.ToInt32(ds.Tables[0].Rows[0]["id"].ToString()));
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
                    Response.Clear();
                    Response.Write("<a href='refresh'>refresh</a><br>");
                    Response.Write("≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡<br/>");

                    #region 判断是否到执行时间
                    //是否到了执行时间
                    string n_LottComp = Input.SetConfigValue("ExecutionTime", "TimeConfig.xml");
                    //每天的开奖时间（3D 排3都是当天开奖）
                    string time = DateTime.Now.ToShortDateString() + " " + n_LottComp;

                    string strTime1 = DateTime.Now.ToString();
                    string strTime2 = time;
                    DateTime dt1 = Convert.ToDateTime(strTime1);
                    DateTime dt2 = Convert.ToDateTime(strTime2);
                    int n = dt1.CompareTo(dt2);


                    #endregion


                    string n_LottCompulsory = Input.SetConfigValue("LottCompulsory", "TimeConfig.xml");
                    if (n_LottCompulsory == "N")
                    {
                        if (n > 0)
                        {
                            try
                            {
                                TLottery();
                                
                            }
                            catch (Exception ex)
                            {
                                Pbzx.Common.ErrorLog.WriteLog(ex);
                                Response.Write(DateTime.Now.Day + "号开奖发生错误：" + "<br/>");
                                Response.Write("错误信息：" + ex + "<br/>");
                                Response.Write("≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡<br/>");
                                DateTime dtEnd = DateTime.Now;
                                TimeSpan tsJG = dtEnd - dtStart;
                                Response.Write("【" + Math.Floor(tsJG.TotalSeconds) + "秒】" + dtStart + " - " + dtEnd + " ");
                                //停止页面加载
                                Response.End();
                                return;
                            }
                            DataSet ds_count = get_cg.GetList("attState='ddbp'");
                            //查询 有无数据
                            if (ds_count.Tables[0].Rows.Count > 0 && ds_count != null)
                            {
                                //删除数据
                                if (DbHelperSQL.ExecuteSql("delete from dbo.Challenge_config where attState='ddbp' ") > 0)
                                {
                                    //添加执行完成记录
                                    mod_cg.CTime = DateTime.Now;
                                    mod_cg.Complete = 1;
                                    mod_cg.agreeRef = 0;
                                    mod_cg.lastIP = Request.UserHostAddress;
                                    mod_cg.attState = "ddbp";
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
                                mod_cg.attState = "ddbp";
                                get_cg.Add(mod_cg);
                            }
                            DataSet ds_open = get_cg.GetList("attState='ddbp'");
                            if (ds_open != null && ds_open.Tables[0].Rows.Count > 0)
                            {
                                //检测当天是否已开奖
                                if (Convert.ToInt32(ds_open.Tables[0].Rows[0]["Complete"]) == 0)
                                {
                                    Response.Write(DateTime.Now.Day + "号未开奖" + "<br/>");
                                    Response.Write("开奖时间为：" + DateTime.Now.ToShortDateString() + " " + n_LottComp + "<br/>");
                                    Response.Write("≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡<br/>");
                                    DateTime dtEnd = DateTime.Now;
                                    TimeSpan tsJG = dtEnd - dtStart;
                                    Response.Write("【" + Math.Floor(tsJG.TotalSeconds) + "秒】" + dtStart + " - " + dtEnd + " ");
                                    //停止页面加载
                                    Response.End();
                                }
                                if (Convert.ToInt32(ds_open.Tables[0].Rows[0]["Complete"]) == 1)
                                {
                                    Response.Write("开奖完成标识： " + ds_open.Tables[0].Rows[0]["Complete"].ToString() + "<br/>");
                                    Response.Write(DateTime.Now.Day + "号开奖已完成" + "<br/>");
                                    Response.Write("开奖完成时间：" + ds_open.Tables[0].Rows[0]["CTime"].ToString() + "<br/>");
                                    Response.Write("≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡<br/>");
                                    DateTime dtEnd = DateTime.Now;
                                    TimeSpan tsJG = dtEnd - dtStart;
                                    Response.Write("【" + Math.Floor(tsJG.TotalSeconds) + "秒】" + dtStart + " - " + dtEnd + " ");
                                    //停止页面加载
                                    Response.End();
                                }
                            }
                        }
                        else
                        {
                            Response.Write("开奖时间为： " + n_LottComp+" <br/>");
                            Response.Write(DateTime.Now.Day + " 号未到开奖时间" + "<br/>");
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
                        try
                        {
                            TLottery();

                        }
                        catch (Exception ex)
                        {
                            Pbzx.Common.ErrorLog.WriteLog(ex);
                            Response.Write(DateTime.Now.Day + "号开奖发生错误：" + "<br/>");
                            Response.Write("错误信息：" + ex + "<br/>");
                            Response.Write("≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡<br/>");
                            DateTime dtEnd = DateTime.Now;
                            TimeSpan tsJG = dtEnd - dtStart;
                            Response.Write("【" + Math.Floor(tsJG.TotalSeconds) + "秒】" + dtStart + " - " + dtEnd + " ");
                            //停止页面加载
                            Response.End();
                            return;
                        }
                        DataSet ds_count = get_cg.GetList("attState='ddbp'");
                        //查询 有无数据
                        if (ds_count.Tables[0].Rows.Count > 0 && ds_count != null)
                        {
                            //删除数据
                            if (DbHelperSQL.ExecuteSql("delete from dbo.Challenge_config where attState='ddbp' ") > 0)
                            {
                                //添加执行完成记录
                                mod_cg.CTime = DateTime.Now;
                                mod_cg.Complete = 1;
                                mod_cg.agreeRef = 0;
                                mod_cg.lastIP = Request.UserHostAddress;
                                mod_cg.attState = "ddbp";
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
                            mod_cg.attState = "ddbp";
                            get_cg.Add(mod_cg);
                        }
                        DataSet ds_open = get_cg.GetList("attState='ddbp'");
                        if (ds_open != null && ds_open.Tables[0].Rows.Count > 0)
                        {
                            //检测当天是否已开奖
                            if (Convert.ToInt32(ds_open.Tables[0].Rows[0]["Complete"]) == 0)
                            {
                                Response.Write("开奖标识： " + ds_open.Tables[0].Rows[0]["Complete"].ToString() + "<br/>");
                                Response.Write("未开奖" + "<br/>");
                                Response.Write("开奖时间为：" + DateTime.Now.ToShortDateString() + " " + n_LottComp + "<br/>");
                                Response.Write("≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡<br/>");
                                DateTime dtEnd = DateTime.Now;
                                TimeSpan tsJG = dtEnd - dtStart;
                                Response.Write("【" + Math.Floor(tsJG.TotalSeconds) + "秒】" + dtStart + " - " + dtEnd + " ");
                                //停止页面加载
                                Response.End();
                            }
                            if (Convert.ToInt32(ds_open.Tables[0].Rows[0]["Complete"]) == 1)
                            {
                                Response.Write("开奖标识： " + ds_open.Tables[0].Rows[0]["Complete"].ToString() + "<br/>");
                                Response.Write("开奖已完成" + "<br/>");
                                Response.Write("开奖完成时间：" + ds_open.Tables[0].Rows[0]["CTime"].ToString() + "<br/>");
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
                            Response.Write("开奖完成记录：" + ds_open.Tables[0].Rows.Count.ToString() + "<br/>");
                            Response.Write("未到开奖时间。" + "<br/>");
                            Response.Write("开奖时间为：" + DateTime.Now.ToShortDateString() + " " + n_LottComp + "<br/>");
                            Response.Write("≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡<br/>");
                            DateTime dtEnd = DateTime.Now;
                            TimeSpan tsJG = dtEnd - dtStart;
                            Response.Write("【" + Math.Floor(tsJG.TotalSeconds) + "秒】" + dtStart + " - " + dtEnd + " ");
                            //停止页面加载
                            Response.End();
                        }

                    }
                    #endregion
                }
                #endregion

                //TLottery();
             
            }
        }

        /// <summary>
        /// 开奖添加中奖信息
        /// </summary>
        public void TLottery()
        {
            //查询未开奖的所有数据
            DataSet ds = get_u.GetListView("F_state=0");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                //获取开奖期的开奖号码
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    //Pbzx.Common.Follow.WriteLog("项目ID：" + ds.Tables[0].Rows[i]["F_drID"].ToString() + " 期号：" + ds.Tables[0].Rows[i]["F_Period"].ToString() + " 用户：" + ds.Tables[0].Rows[i]["F_username"].ToString());
                    string CorrectNum = "";
                    if (Convert.ToInt32(ds.Tables[0].Rows[i]["F_lottery"]) == 1)
                    {
                        //3D 
                        CorrectNum = get_u.SelectlottNum(Convert.ToInt32(ds.Tables[0].Rows[i]["F_Period"]), 1);
                    }
                    if (Convert.ToInt32(ds.Tables[0].Rows[i]["F_lottery"]) == 2)
                    {
                        //排列三
                        CorrectNum = get_u.SelectlottNum(Convert.ToInt32(ds.Tables[0].Rows[i]["F_Period"]), 9999);
                    }
                    if (CorrectNum != "" && CorrectNum.Length == 3)
                    {
                        //获得中出情况
                        string n_num = DataContrest(CorrectNum, ds.Tables[0].Rows[i]["ct_Num"].ToString(), Convert.ToInt32(ds.Tables[0].Rows[i]["F_SingleGroup"]));

                        //添加大底中出情况
                        InsertTabRt(Convert.ToInt32(ds.Tables[0].Rows[i]["F_drID"].ToString()), Convert.ToInt32(ds.Tables[0].Rows[i]["F_Period"].ToString()), ds.Tables[0].Rows[i]["F_username"].ToString(), n_num, Convert.ToInt32(ds.Tables[0].Rows[i]["F_SingleGroup"].ToString()));

                        Distribution(ds.Tables[0].Rows[i]["F_username"].ToString(), Convert.ToInt32(ds.Tables[0].Rows[i]["ct_Num"].ToString().Split(',').Length), Convert.ToInt32(ds.Tables[0].Rows[i]["F_drID"]), Convert.ToInt32(ds.Tables[0].Rows[i]["F_SingleGroup"]), CorrectNum);
                    }
                    //Pbzx.Common.Follow.WriteLog(ds.Tables[0].Rows[i]["F_Period"].ToString()+"期开奖号码为："+CorrectNum);
                }
               
            }
        }

        #region 大底中出情况
        //数据验证
        /// <summary>
        /// 验证号码中出情况
        /// </summary>
        /// <param name="CorrectNum">奖号</param>
        /// <param name="UpLoadNum">大底号码</param>
        /// <param name="singleGroup">单选大底VS组选大底</param>
        /// <returns></returns>
        public string DataContrest(string CorrectNum, string UpLoadNum, int singleGroup)
        {
            int g_count = 0;
            int g_rd = 0;
            int g_ad = 0;
            string g_result = "";
            int g_group = 0;
            int g_zero = 0;
            if (UpLoadNum != null && UpLoadNum.Split(',').Length > 0)
            {
                if (singleGroup == 1)
                {
                    //去除重复数据
                    string[] str = new string[UpLoadNum.Split(',').Length];
                    for (int k = 0; k < UpLoadNum.Split(',').Length; k++)
                    {
                        str[k] = UpLoadNum.Split(',')[k];
                    }
                    string[] array = removeDuplicate(str);
                    //单选大底
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (CorrectNum == array[i].ToString())
                        {
                            //计算全中个数
                            g_count++;
                            continue;
                        }

                        int num1 = 0;
                        int num2 = 0;
                        for (int j = 0; j < 3; j++)
                        {
                            num1 += Convert.ToInt32(CorrectNum.Substring(j, 1));
                            if (array[i].Substring(j, 1).ToString() != "")
                            {
                                num2 += Convert.ToInt32(array[i].Substring(j, 1));
                            }
                            else
                            {
                                num2 = -1;
                            }
                        }

                        if (num1 == num2)
                        {
                            g_group++;
                        }

                        string Correct = CorrectNum.Substring(0, 1).ToString() + CorrectNum.Substring(2, 1).ToString();
                        string DataNum = array[i].Substring(0, 1).ToString() + array[i].Substring(2, 1).ToString();

                        if (CorrectNum.Substring(0, 2) == array[i].Substring(0, 2) || CorrectNum.Substring(1, 2) == array[i].Substring(1, 2) || Correct == DataNum)
                        {
                            //2D 中2个数
                            g_rd++;
                            continue;
                        }
                        //if (CorrectNum.Substring(0, 1) == array[i].Substring(0, 1) || CorrectNum.Substring(1, 1) == array[i].Substring(1, 1) || CorrectNum.Substring(2, 1) == array[i].Substring(2, 1))
                        //{
                        //    //1D 中一个数  分百位 十位  个位
                        //    g_ad++;
                        //    continue;
                        //}
                        //中1位
                        for (int n = 0; n < 3; n++)
                        {
                            if (CorrectNum.Substring(n, 1).ToString() == array[i].Substring(n, 1).ToString())
                            {
                                //1D 中一个数  分百位 十位  个位
                                g_ad++;
                                continue;
                            }
                        }

                        int Calculation = 0;
                        //中0位
                        for (int k = 0; k < 3; k++)
                        {
                            if (CorrectNum.Substring(k, 1) == array[i].ToString().Substring(k, 1))
                            {
                                Calculation = 1;
                            }
                        }
                        if (Calculation == 1)
                        {
                            continue;
                        }
                        else
                        {
                            g_zero++;
                        }
                    }
                    //g_result = "全中：" + g_count + "|2D：" + g_rd + "|1D：" + g_ad + "|中0：" + g_zero + "|中组：" + g_group;
                    g_result = g_count.ToString() + "|" + g_rd.ToString() + "|" + g_ad.ToString() + "|" + g_zero.ToString() + "|" + g_group.ToString();
                }
                if (singleGroup == 2)
                {
                    //去除重复数据
                    string[] str = new string[UpLoadNum.Split(',').Length];
                    for (int k = 0; k < UpLoadNum.Split(',').Length; k++)
                    {
                        str[k] = UpLoadNum.Split(',')[k];
                    }
                    string[] array = removeDuplicate(str);
                    //组选大底 没有中单
                    for (int i = 0; i < array.Length; i++)
                    {

                        //号码排序
                        ArrayList arr = new ArrayList();
                        if (arr.Count > 0)
                        {
                            arr.Clear();
                        }
                        arr.Add(array[i].Substring(0, 1));
                        arr.Add(array[i].Substring(1, 1));
                        arr.Add(array[i].Substring(2, 1));
                        //号码宠幸排序
                        ArrayList returnArr = Input.arrlist(arr);
                        string RecombinantNum = returnArr[0].ToString() + returnArr[1].ToString() + returnArr[2].ToString();
                        string DataNum = RecombinantNum.Substring(0, 1).ToString() + RecombinantNum.Substring(2, 1).ToString();

                        //开奖号码 排序
                        ArrayList arrN = new ArrayList();
                        arrN.Add(CorrectNum.Substring(0, 1).ToString());
                        arrN.Add(CorrectNum.Substring(1, 1).ToString());
                        arrN.Add(CorrectNum.Substring(2, 1).ToString());
                        ArrayList arrSort = Input.arrlist(arrN);
                        string CorrectN = arrSort[0].ToString() + arrSort[1].ToString() + arrSort[2].ToString();
                        //设定头尾数字
                        string Correct = CorrectN.Substring(0, 1).ToString() + CorrectN.Substring(2, 1).ToString();
                        //组选中奖个数
                        if (CorrectN.ToString() == RecombinantNum)
                        {
                            //记录组选中奖
                            g_group++;
                            continue;
                        }


                        if (getStringCount(CorrectN, RecombinantNum) == true || Correct == DataNum || getStringCount(CorrectN, DataNum) == true || getStringCount(RecombinantNum, Correct) == true)
                        {
                            //2D 中2个数
                            g_rd++;
                            continue;
                        }
                        int seq = -1;
                        //1D 中奖率

                        string[] num1 = new string[3];
                        num1[0] = RecombinantNum.Substring(0, 1);
                        num1[1] = RecombinantNum.Substring(1, 1);
                        num1[2] = RecombinantNum.Substring(2, 1);
                        string[] returnNum1 = removeDuplicate(num1);
                        for (int w = 0; w < returnNum1.Length; w++)
                        {
                            if (CorrectN.IndexOf(returnNum1[w]) >= 0)
                            {
                                g_ad++;
                                seq = i;
                                break;
                            }
                        }
                        if (seq != -1)
                        {
                            continue;
                        }

                        int zeroSeq = -1;
                        //中0位
                        for (int k = 0; k < 3; k++)
                        {
                            string[] num = new string[3];
                            num[0] = RecombinantNum.Substring(0, 1);
                            num[1] = RecombinantNum.Substring(1, 1);
                            num[2] = RecombinantNum.Substring(2, 1);
                            string[] returnNum = removeDuplicate(num);
                            for (int l = 0; l < returnNum.Length; l++)
                            {
                                if (CorrectN.Substring(k, 1) == returnNum[l])
                                {
                                    zeroSeq = i;
                                }
                            }
                        }
                        if (zeroSeq != -1)
                        {
                            continue;
                        }
                        else
                        {
                            g_zero++;
                        }
                    }

                    //g_result =全中 "|2D：" + g_rd + "|1D：" + g_ad + "|中0：" + g_zero + "|中组：" + g_group;
                    g_result = g_count.ToString() + "|" + g_rd.ToString() + "|" + g_ad.ToString() + "|" + g_zero.ToString() + "|" + g_group.ToString();

                }
            }
            return g_result;
        }
        #endregion

        #region  统计组变单，单变组的个数
        /// <summary>
        /// 计算组变单
        /// </summary>
        /// <param name="NoteNum">注数</param>
        /// <returns></returns>
        public int groupchangeSingle(int NoteNum)
        {
            return 6 * NoteNum;
        }

        /// <summary>
        /// 计算单变组
        /// </summary>
        /// <param name="number">号码</param>
        /// <returns></returns>
        public int SingleChangeGroup(string number)
        {
            if (number.Length == 3)
            {
                int sum = 0;
                //ArrayList arr = new ArrayList();
                string[] arr = new string[number.Split(',').Length];
                for (int i = 0; i < number.Split(',').Length; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        sum += Convert.ToInt32(number.Split(',')[i].Substring(j, 1));
                    }
                    arr[i] = sum.ToString();
                    sum = 0;
                }
                string[] str = removeDuplicate(arr);
                return str.Length;
            }
            return 0;
        }
        protected string[] removeDuplicate(string[] ArrInput)
        {
            ArrayList nStr = new ArrayList();
            for (int i = 0; i < ArrInput.Length; i++)
            {
                if (!nStr.Contains(ArrInput[i]))
                {
                    nStr.Add(ArrInput[i]);
                }
            }
            return (string[])nStr.ToArray(typeof(string));
        }
        #endregion


        #region  添加中奖信息
        /// <summary>
        /// 添加中奖详细信息
        /// </summary>
        /// <param name="ID">发布信息表主键ID</param>
        /// <param name="issue">发布期号</param>
        /// <param name="userName">用户名</param>
        /// <param name="pNum">中奖返回信息</param>
        /// <param name="singleGroup">大底类型： 单选--组选</param>
        public void InsertTabRt(int ID, int issue, string userName, string pNum, int singleGroup)
        {
            //Pbzx.Common.Follow.WriteLog("发布ID："+ ID+" 期号："+ issue+" 用户名："+userName+" 中奖信息："+pNum+" 类型："+singleGroup);
            Pbzx.Model.DataRivalry_Rt mod_r = new Pbzx.Model.DataRivalry_Rt();

            mod_r.Rt_Period = issue;
            mod_r.Rt_AwardNum = ID;
            mod_r.Rt_UserName = userName;
            #region 判断是否有空值
            int r_single = 0;
            int r_group = 0;
            int r_two = 0;
            int r_one = 0;
            int r_zero = 0;
            if (pNum.Split('|')[0].ToString() != "")
            {
                r_single = Convert.ToInt32(pNum.Split('|')[0]);
            }
            if (pNum.Split('|')[4].ToString() != "")
            {
                r_group = Convert.ToInt32(pNum.Split('|')[4]);
            }
            if (pNum.Split('|')[1].ToString() != "")
            { 
                r_two=Convert.ToInt32(pNum.Split('|')[1]);
            }
            if (pNum.Split('|')[2].ToString() != "")
            {
                r_one = Convert.ToInt32(pNum.Split('|')[2]);
            }
            if (pNum.Split('|')[3].ToString() != "")
            {
                r_zero = Convert.ToInt32(pNum.Split('|')[3]);
            }
            #endregion
            if (singleGroup == 1)
            {
                mod_r.Rt_Single = r_single;
                //单选变组选后 所中情况
                //mod_r.Rt_Group = groupchangeSingle(Convert.ToInt32(pNum.Split('|')[0]));
                mod_r.Rt_Group = 0;
            }
            if (singleGroup == 2)
            {
                mod_r.Rt_Single = 0;
                mod_r.Rt_Group = r_group;
            }
            mod_r.Rt_two = r_two;
            mod_r.Rt_one = r_one;
            mod_r.Rt_zero = r_zero;
            mod_r.Rt_CSRate = "0";
            //Pbzx.Common.Follow.WriteLog("添加ID为"+ ID +"数据");
            //添加数据
            if (get_r.Add(mod_r) > 0)
            {
                //Pbzx.Common.Follow.WriteLog("添加ID为" +  ID  + "数据成功");
                //修改开奖标识
                Pbzx.Model.DataRivalry_UpLoadFile mod_u = get_u.GetModel(ID);
                mod_u.F_state = 1;
                get_u.Update(mod_u);
            }

        }


        #endregion  


        #region  分配中奖所获积分 金币
        /// <summary>
        /// 分配积分 金币
        /// </summary>
        /// <param name="username">会员名</param>
        /// <param name="noteNum">大底个数</param>
        /// <param name="ID">中奖序号（信息表中的主键ID）</param>
        /// <param name="type">大底类型，1：单选大底  2：组选大底</param>
        public void Distribution(string username,int noteNum,int ID,int type,string openNum)
        {
            Pbzx.BLL.PlatformPublic_integralPrize get_ie = new Pbzx.BLL.PlatformPublic_integralPrize();
            Pbzx.Model.PlatformPublic_integralPrize mod_ie = new Pbzx.Model.PlatformPublic_integralPrize();
            if (type == 1)
            {
                //获取基数
                string tNum = Input.SetConfigValue("InTwo", "Switchxml.xml");  //2D

                string oNum = Input.SetConfigValue("InOne", "Switchxml.xml");  //1D

                string zNum = Input.SetConfigValue("InZero", "Switchxml.xml");  //0D

                //获取上下限
                int InTwoUpperlimit = 0; //2D 上限
                if (Input.SetConfigValue("InTwoUpperlimit", "Switchxml.xml") != "")
                {
                    InTwoUpperlimit = Convert.ToInt32(Input.SetConfigValue("InTwoUpperlimit", "Switchxml.xml"))/100;
                }
                int InTwoLowerlimit = 0; //2D 下限
                if (Input.SetConfigValue("InTwoLowerlimit", "Switchxml.xml") != "")
                {
                    InTwoLowerlimit = Convert.ToInt32(Input.SetConfigValue("InTwoLowerlimit", "Switchxml.xml"))/100;
                }

                int InOneUpperlimit = 0;//1D 上限
                if (Input.SetConfigValue("InOneUpperlimit", "Switchxml.xml") != "")
                {
                    InOneUpperlimit = Convert.ToInt32(Input.SetConfigValue("InOneUpperlimit", "Switchxml.xml"))/100;
                }

                int InOneLowerlimit = 0;//1D 下限
                if (Input.SetConfigValue("InOneLowerlimit", "Switchxml.xml") != "")
                {
                    InOneLowerlimit = Convert.ToInt32(Input.SetConfigValue("InOneLowerlimit", "Switchxml.xml"))/100;
                }

                int InZeroUpperlimit = 0;//0D 上限
                if (Input.SetConfigValue("InZeroUpperlimit", "Switchxml.xml") != "")
                {
                    InZeroUpperlimit = Convert.ToInt32(Input.SetConfigValue("InZeroUpperlimit", "Switchxml.xml"))/100;
                }
                int InZeroLowerlimit = 0;//0D 下限
                if (Input.SetConfigValue("InZeroLowerlimit", "Switchxml.xml") != "")
                {
                    InZeroLowerlimit = Convert.ToInt32(Input.SetConfigValue("InZeroLowerlimit", "Switchxml.xml"))/100;
                }

                int n_tNum = 0;
                int n_oNum = 0;
                int n_zNum = 0;
                if (tNum != "")
                {
                    n_tNum = Convert.ToInt32(tNum);
                }
                if (oNum != "")
                {
                    n_oNum = Convert.ToInt32(oNum);
                }
                if (zNum != "")
                {
                    n_zNum = Convert.ToInt32(zNum);
                }
                //计算当前大底 基数范围
                //按发布底计算最大数
                int n_TwoD = Convert.ToInt32(noteNum * (n_tNum * 0.001));
                int UpperlimitTwoD = n_TwoD + n_TwoD * InTwoUpperlimit; //当前大底2D 最大值
                int LowerlimitTwoD = n_TwoD - n_TwoD * InTwoLowerlimit; //当前大底2D 最小值

                int n_OneD = Convert.ToInt32(noteNum * (n_oNum * 0.001));
                int UpperlimitOneD = n_OneD + n_OneD*InOneUpperlimit; //当前大底1D 最大值
                int LowerlimitOneD = n_OneD - n_OneD*InOneLowerlimit; //当前大底1D 最小值

                int n_ZeroD = Convert.ToInt32(noteNum * (n_zNum * 0.001));
                int UpperlimitZeroD = n_ZeroD + n_ZeroD*InZeroUpperlimit; //当前大底0D 最大值
                int LowerlimitZeroD = n_ZeroD - n_ZeroD*InZeroLowerlimit; //当前大底0D 最小值

                //2D积分
                int IntegralTwo = 0;
                //1D
                int IntegralOne = 0;
                //0D 
                int IntegralZero = 0;

                int IntegralGroup = 0;

                //金币获取
                int CoinTwo = 0;

                int CoinOne = 0;

                int CoinZero = 0;

                int CoinGroup = 0;

                //查询信息表DataRivalry_Rt
                DataSet ds = get_r.GetList("Rt_AwardNum=" + ID + " and Rt_UserName=" + "'" + username + "'");
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["Rt_two"]) < UpperlimitTwoD && Convert.ToInt32(ds.Tables[0].Rows[0]["Rt_two"]) > LowerlimitTwoD)
                    {
                        if (Input.SetConfigValue("IntegralTwo", "Switchxml.xml") != "")
                        {
                            IntegralTwo = Convert.ToInt32(Input.SetConfigValue("IntegralTwo", "Switchxml.xml"));
                        }
                        if (Input.SetConfigValue("CoinTwo", "Switchxml.xml") != "")
                        {
                            CoinTwo = Convert.ToInt32(Input.SetConfigValue("CoinTwo", "Switchxml.xml"));
                        }
                    }
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["Rt_one"]) < UpperlimitOneD && Convert.ToInt32(ds.Tables[0].Rows[0]["Rt_one"]) > LowerlimitOneD)
                    {
                        if (Input.SetConfigValue("IntegralOne", "Switchxml.xml") != "")
                        {
                            IntegralOne = Convert.ToInt32(Input.SetConfigValue("IntegralOne", "Switchxml.xml"));
                        }
                        if (Input.SetConfigValue("CoinOne", "Switchxml.xml") != "")
                        {
                            CoinOne = Convert.ToInt32(Input.SetConfigValue("CoinOne", "Switchxml.xml"));
                        }
                    }
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["Rt_zero"]) < UpperlimitZeroD && Convert.ToInt32(ds.Tables[0].Rows[0]["Rt_zero"]) > LowerlimitZeroD)
                    {
                        if (Input.SetConfigValue("IntegralZero", "Switchxml.xml") != "")
                        {
                            IntegralZero = Convert.ToInt32(Input.SetConfigValue("IntegralZero", "Switchxml.xml"));
                        }
                        if (Input.SetConfigValue("CoinZero", "Switchxml.xml") != "")
                        {
                            CoinZero = Convert.ToInt32(Input.SetConfigValue("CoinZero", "Switchxml.xml"));
                        }
                    }
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["Rt_Single"]) == 1)
                    {
                        if (Input.SetConfigValue("IntegralGroup", "Switchxml.xml") != "")
                        {
                            IntegralGroup = Convert.ToInt32(Input.SetConfigValue("IntegralGroup", "Switchxml.xml"));
                        }
                        if (Input.SetConfigValue("CoinGroup", "Switchxml.xml") != "")
                        {
                            CoinGroup = Convert.ToInt32(Input.SetConfigValue("CoinGroup", "Switchxml.xml"));
                        }
                    }
                }
                //查询用户是否已有积分
                DataSet ds_inter = get_ie.GetList("Pip_user=" + "'" + username + "'" + " and Pip_belongs='DataRivalry'");
                if (ds_inter != null && ds_inter.Tables[0].Rows.Count > 0)
                {
                    //已有数据 修改数据
                    mod_ie = get_ie.GetModel(Convert.ToInt32(ds_inter.Tables[0].Rows[0]["Pip_id"]));

                    mod_ie.Pip_Interal = mod_ie.Pip_Interal + IntegralTwo + IntegralOne + IntegralZero + IntegralGroup;
                    mod_ie.Pip_money = mod_ie.Pip_money + CoinTwo + CoinOne + CoinZero + CoinGroup;
                    get_ie.Update(mod_ie);
                }
                else
                {
                    mod_ie.Pip_user = username;
                    mod_ie.Pip_Interal = IntegralTwo + IntegralOne + IntegralZero + IntegralGroup;
                    mod_ie.Pip_money = Convert.ToDecimal(CoinTwo + CoinOne + CoinZero + CoinGroup);
                    mod_ie.Pip_belongs = "DataRivalry";
                    get_ie.Add(mod_ie);
                }
            }
            if (type == 2)
            {
                string Re_num = lottType(openNum);
                //获取基数
                string tNum = "";

                string oNum = "";

                string zNum = "";
                if (Re_num == "6") //组6
                {
                    tNum = Input.SetConfigValue("InTwo", "GroupNum.xml");  //2D

                    oNum = Input.SetConfigValue("InOne", "GroupNum.xml");  //1D

                    zNum = Input.SetConfigValue("InZero", "GroupNum.xml");  //0D
                }
                if (Re_num == "3")
                {
                    tNum = Input.SetConfigValue("InTwozt", "GroupNum.xml");  //2D

                    oNum = Input.SetConfigValue("InOnezt", "GroupNum.xml");  //1D

                    zNum = Input.SetConfigValue("InZerozt", "GroupNum.xml");  //0D
                }
                if (Re_num == "bao")
                {
                    tNum = Input.SetConfigValue("InTwobz", "GroupNum.xml");  //2D

                    oNum = Input.SetConfigValue("InOnebz", "GroupNum.xml");  //1D

                    zNum = Input.SetConfigValue("InZerobz", "GroupNum.xml");  //0D
                }

                //获取上下限
                //int InTwoUpperlimit = Convert.ToInt32(Input.SetConfigValue("InTwoUpperlimit", "GroupNum.xml"));//2D 上限
                //int InTwoLowerlimit = Convert.ToInt32(Input.SetConfigValue("InTwoLowerlimit", "GroupNum.xml")); //2D 下限

                //int InOneUpperlimit = Convert.ToInt32(Input.SetConfigValue("InOneUpperlimit", "GroupNum.xml"));//1D 上限
                //int InOneLowerlimit = Convert.ToInt32(Input.SetConfigValue("InOneLowerlimit", "GroupNum.xml"));//1D 下限

                //int InZeroUpperlimit = Convert.ToInt32(Input.SetConfigValue("InZeroUpperlimit", "GroupNum.xml"));//0D 上限
                //int InZeroLowerlimit = Convert.ToInt32(Input.SetConfigValue("InZeroLowerlimit", "GroupNum.xml"));//0D 下限


                int InTwoUpperlimit = 0; //2D 上限
                if (Input.SetConfigValue("InTwoUpperlimit", "GroupNum.xml") != "")
                {
                    InTwoUpperlimit = Convert.ToInt32(Input.SetConfigValue("InTwoUpperlimit", "GroupNum.xml"))/100;
                }
                int InTwoLowerlimit = 0; //2D 下限
                if (Input.SetConfigValue("InTwoLowerlimit", "GroupNum.xml") != "")
                {
                    InTwoLowerlimit = Convert.ToInt32(Input.SetConfigValue("InTwoLowerlimit", "GroupNum.xml"))/100;
                }

                int InOneUpperlimit = 0;//1D 上限
                if (Input.SetConfigValue("InOneUpperlimit", "GroupNum.xml") != "")
                {
                    InOneUpperlimit = Convert.ToInt32(Input.SetConfigValue("InOneUpperlimit", "GroupNum.xml"))/100;
                }

                int InOneLowerlimit = 0;//1D 下限
                if (Input.SetConfigValue("InOneLowerlimit", "GroupNum.xml") != "")
                {
                    InOneLowerlimit = Convert.ToInt32(Input.SetConfigValue("InOneLowerlimit", "GroupNum.xml"))/100;
                }

                int InZeroUpperlimit = 0;//0D 上限
                if (Input.SetConfigValue("InZeroUpperlimit", "GroupNum.xml") != "")
                {
                    InZeroUpperlimit = Convert.ToInt32(Input.SetConfigValue("InZeroUpperlimit", "GroupNum.xml"))/100;
                }
                int InZeroLowerlimit = 0;//0D 下限
                if (Input.SetConfigValue("InZeroLowerlimit", "GroupNum.xml") != "")
                {
                    InZeroLowerlimit = Convert.ToInt32(Input.SetConfigValue("InZeroLowerlimit", "GroupNum.xml"))/100;
                }


                int n_tNum = 0;
                int n_oNum = 0;
                int n_zNum = 0;
                if (tNum != "")
                {
                    n_tNum = Convert.ToInt32(tNum);
                }
                if (oNum != "")
                {
                    n_oNum = Convert.ToInt32(oNum);
                }
                if (zNum != "")
                {
                    n_zNum = Convert.ToInt32(zNum);
                }

                //计算当前大底 基数范围
                int n_TwoD =Convert.ToInt32(noteNum * n_tNum * 0.22);
                int UpperlimitTwoD = n_TwoD + n_TwoD*InTwoUpperlimit; //当前大底2D 最大值
                int LowerlimitTwoD = n_TwoD - n_TwoD*InTwoLowerlimit; //当前大底2D 最小值

                int n_OneD = Convert.ToInt32(noteNum * (n_oNum * 0.22));
                int UpperlimitOneD = n_OneD + n_OneD*InOneUpperlimit; //当前大底1D 最大值
                int LowerlimitOneD = n_OneD - n_OneD*InOneLowerlimit; //当前大底1D 最小值

                int n_ZeroD = Convert.ToInt32(noteNum * (n_zNum * 0.22));
                int UpperlimitZeroD = n_ZeroD + n_ZeroD*InZeroUpperlimit; //当前大底0D 最大值
                int LowerlimitZeroD = n_ZeroD - n_ZeroD*InZeroLowerlimit; //当前大底0D 最小值

                //2D积分
                int IntegralTwo = 0;
                //1D
                int IntegralOne = 0;
                //0D 
                int IntegralZero = 0;

                int IntegralGroup = 0;

                //金币获取
                int CoinTwo = 0;

                int CoinOne = 0;

                int CoinZero = 0;

                int CoinGroup = 0;

                //查询信息表DataRivalry_Rt
                DataSet ds = get_r.GetList("Rt_AwardNum=" + ID + " and Rt_UserName=" + "'" + username + "'");
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["Rt_two"]) < UpperlimitTwoD && Convert.ToInt32(ds.Tables[0].Rows[0]["Rt_two"]) > LowerlimitTwoD)
                    {
                        if (Input.SetConfigValue("IntegralTwo", "GroupNum.xml") != "")
                        {
                            IntegralTwo = Convert.ToInt32(Input.SetConfigValue("IntegralTwo", "GroupNum.xml"));
                        }
                        if (Input.SetConfigValue("CoinTwo", "GroupNum.xml") != "")
                        {
                            CoinTwo = Convert.ToInt32(Input.SetConfigValue("CoinTwo", "GroupNum.xml"));
                        }
                    }
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["Rt_one"]) < UpperlimitOneD && Convert.ToInt32(ds.Tables[0].Rows[0]["Rt_one"]) > LowerlimitOneD)
                    {
                        if (Input.SetConfigValue("IntegralOne", "GroupNum.xml") != "")
                        {
                            IntegralOne = Convert.ToInt32(Input.SetConfigValue("IntegralOne", "GroupNum.xml"));
                        }
                        if (Input.SetConfigValue("CoinOne", "GroupNum.xml") != "")
                        {
                            CoinOne = Convert.ToInt32(Input.SetConfigValue("CoinOne", "GroupNum.xml"));
                        }
                    }
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["Rt_zero"]) < UpperlimitZeroD && Convert.ToInt32(ds.Tables[0].Rows[0]["Rt_zero"]) > LowerlimitZeroD)
                    {
                        if (Input.SetConfigValue("IntegralZero", "GroupNum.xml") != "")
                        {
                            IntegralZero = Convert.ToInt32(Input.SetConfigValue("IntegralZero", "GroupNum.xml"));
                        }
                        if (Input.SetConfigValue("CoinZero", "GroupNum.xml") != "")
                        {
                            CoinZero = Convert.ToInt32(Input.SetConfigValue("CoinZero", "GroupNum.xml"));
                        }
                    }
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["Rt_Single"]) == 1)
                    {
                        if (Input.SetConfigValue("IntegralGroup", "GroupNum.xml") != "")
                        {
                            IntegralGroup = Convert.ToInt32(Input.SetConfigValue("IntegralGroup", "GroupNum.xml"));
                        }
                        if (Input.SetConfigValue("CoinGroup", "GroupNum.xml") != "")
                        {
                            CoinGroup = Convert.ToInt32(Input.SetConfigValue("CoinGroup", "GroupNum.xml"));
                        }
                    }
                }
                //查询用户是否已有积分
                DataSet ds_inter = get_ie.GetList("Pip_user=" + "'" + username + "'" + " and Pip_belongs='DataRivalry'");
                if (ds_inter != null && ds_inter.Tables[0].Rows.Count > 0)
                {
                    //已有数据 修改数据
                    mod_ie = get_ie.GetModel(Convert.ToInt32(ds_inter.Tables[0].Rows[0]["Pip_id"]));

                    mod_ie.Pip_Interal = mod_ie.Pip_Interal + IntegralTwo + IntegralOne + IntegralZero + IntegralGroup;
                    mod_ie.Pip_money = mod_ie.Pip_money + CoinTwo + CoinOne + CoinZero + CoinGroup;
                    get_ie.Update(mod_ie);
                }
                else
                {
                    mod_ie.Pip_user = username;
                    mod_ie.Pip_Interal = IntegralTwo + IntegralOne + IntegralZero + IntegralGroup;
                    mod_ie.Pip_money =Convert.ToDecimal(CoinTwo + CoinOne + CoinZero + CoinGroup);
                    mod_ie.Pip_belongs = "DataRivalry";
                    get_ie.Add(mod_ie);
                }
            }

        }

        #endregion

        #region 判断相邻数字相同
        private static bool getStringCount(string str1, string str2)
        {
            int startIndex = 0;
            int count = 0;
            while (startIndex + 2 <= str1.Length)
            {
                string tmp = str1.Substring(startIndex, 2);
                if (str2.IndexOf(tmp) >= 0)
                {
                    count++;
                }
                startIndex += 1;
            }
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        private void SetPageNoCache()
        {

            Response.Buffer = true;

            Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);

            Response.Expires = 0;

            Response.CacheControl = "no-cache";

            Response.AddHeader("Pragma", "No-Cache");

        }

        /// <summary>
        /// 判断开奖号码是属于什么 （组选大底）
        /// </summary>
        /// <param name="num">号码</param>
        /// <returns></returns>
        private string lottType(string num)
        {
            string[] strNum = new string[num.Length];
            for (int i = 0; i < num.Length; i++)
            {
                strNum[i] = num.Substring(i,1);
            }

            if (strNum[0].ToString() == strNum[1].ToString() && strNum[0].ToString() == strNum[2].ToString())
            {
                return "bao";
            }
            if (strNum[0].ToString() == strNum[1].ToString() || strNum[0].ToString() == strNum[2].ToString() || strNum[1].ToString() == strNum[2].ToString())
            {
                return "3";
            }
            return "6";
        }
    }
}