using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Pbzx.Model;
using Pbzx.DALFactory;
using Pbzx.IDAL;
using System.Text;
using Pbzx.Common;
using System.Web.Security;
using System.Xml;
using System.IO;
using System.Net;

namespace Pbzx.BLL
{

    public class publicMethod
    {
        private static readonly IChipped_LaunchInfo dal = DataAccess.CreateIChipped_LaunchInfo();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("v_Merger", "ChippedShare");
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="TableName">查询数据库表的名称</param>
        /// <param name="CheckCondition">查询的列名 全部为*</param>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        public DataSet Chipped_Table(string TableName, string CheckCondition, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + CheckCondition);
            strSql.Append(" From " + TableName);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);

            }

            return dal.QuerySet(strSql.ToString());
        }

        /// <summary>
        /// 合并查询 会员名 购买份数 购买时间
        /// 创建人: zhouwei
        /// 创建时间: 2011-03-02
        /// </summary>
        /// <param name="SearchStr">查询字符串 </param>
        /// <param name="getFileds">获取列</param>
        /// <param name="OrderStr">排序字段</param>
        /// <param name="PageNum">获取的数据数</param>
        /// <param name="desc">升序还是降序</param>
        /// <param name="CurrentPage">当前的页数</param>
        /// <param name="Counts">返回记录集总数</param>
        /// <returns></returns>         

        public DataTable GuestGetBySearch(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "v_Merger", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }

        /// <summary>
        /// 合买发布链接合买的的视图
        /// </summary>
        /// <param name="SearchStr">查询字符串 </param>
        /// <param name="getFileds">获取列</param>
        /// <param name="OrderStr">排序字段</param>
        /// <param name="PageNum">获取的数据数</param>
        /// <param name="desc">升序还是降序</param>
        /// <param name="CurrentPage">当前的页数</param>
        /// <param name="Counts">返回记录集总数</param>
        /// <returns></returns>
        public DataTable v_participation(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "v_participation", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }


        /// <summary>
        /// 我的购买记录
        /// </summary>
        /// <param name="SearchStr">查询字符串 </param>
        /// <param name="getFileds">获取列</param>
        /// <param name="OrderStr">排序字段</param>
        /// <param name="PageNum">获取的数据数</param>
        /// <param name="desc">升序还是降序</param>
        /// <param name="CurrentPage">当前的页数</param>
        /// <param name="Counts">返回记录集总数</param>
        /// <returns></returns>
        public DataTable v_BuyRecord(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "v_BuyRecord", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }

        /// <summary>
        /// 统计总共出售的份数
        /// </summary>
        /// <param name="QNumber">流水号</param>
        /// <param name="strwhere">条件，流水号</param>
        /// <returns></returns>
        public DataSet Statistics(string strwhere)
        {
            StringBuilder strb = new StringBuilder();
            strb.Append("select sum(ChippedShare)");
            strb.Append(" from v_Merger");
            if (strwhere.Trim() != "")
            {
                strb.Append(" where " + strwhere);
            }
            return dal.QuerySet(strb.ToString());
        }

        /// <summary>
        /// 计算百分比进度
        /// </summary>
        /// <returns></returns>
        public string percent(string Qnum)
        {
            //划分的总的份数
            DataSet ds = Chipped_Table("Chipped_LaunchInfo", "Share", "QNumber=" + "'" + Qnum + "'");
            //出售的份数
            DataSet dsNum = Statistics("QNumber=" + "'" + Qnum + "'");
            decimal percent = Convert.ToDecimal(dsNum.Tables[0].Rows[0][0]) / Convert.ToDecimal(ds.Tables[0].Rows[0][0]) * 100;
            return percent.ToString("0.##");
        }

        /// <summary>
        /// 添加关注的方法
        /// </summary>
        /// <param name="AName">被关注人</param>
        /// <param name="AttentionName">关注人</param>
        public int Attention(string AName, string AttentionName)
        {
            Chipped_Attention get_att = new Chipped_Attention();
            Pbzx.Model.Chipped_Attention ModAtt = new Pbzx.Model.Chipped_Attention();
            if (get_att.Exists(AName, AttentionName))
            {
                //数据已存在（防止重复关注）
                return 0;
            }
            else
            {
                ModAtt.AName = AName;
                ModAtt.Attention = AttentionName;
                ModAtt.ATime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                if (get_att.Add(ModAtt) > 0)
                {
                    return 1;
                }
            }
            return 0;
        }


        public static string GetMoney()
        {
            if (Method.Get_UserName != "0")
            {
                Pbzx.BLL.PBnet_UserTable get_userTab = new Pbzx.BLL.PBnet_UserTable();
                //查询购买用户
                Pbzx.Model.PBnet_UserTable get_Moduser = get_userTab.GetModelName(Method.Get_UserName);
                return Convert.ToDouble(get_Moduser.CurrentMoney - get_Moduser.FrozenMoney).ToString();
            }
            return "0";
        }
        /// <summary>
        /// 方案成功 扣除花费的金额
        /// </summary>
        /// <param name="QNumber">方案的编号</param>
        /// <param name="sponsors">发起人</param>
        /// <param name="UserMoney">用户花费金额</param>
        /// <param name="each">每份的金额</param>
        public string deductMoney(string QNumber, string sponsors, decimal UserMoney, decimal each)
        {
            Pbzx.BLL.PBnet_UserTable get_userTab = new Pbzx.BLL.PBnet_UserTable();
            //扣除用户购买所花的金额
            DataSet dsRefund = Chipped_Table("v_Merger", "*", "QNumber=" + "'" + QNumber + "'");
            try
            {
                for (int l = 0; l < dsRefund.Tables[0].Rows.Count; l++)
                {
                    //查询购买用户
                    Pbzx.Model.PBnet_UserTable get_Moduser = get_userTab.GetModelName(dsRefund.Tables[0].Rows[l]["ChippedName"].ToString());

                    //用户是发起人
                    if (get_Moduser.UserName.ToString() == sponsors)
                    {
                        //扣除用户购买金额（原有的冻结金额-本次所花的金额）
                        get_Moduser.FrozenMoney = get_Moduser.FrozenMoney - UserMoney;
                        get_Moduser.CurrentMoney = get_Moduser.CurrentMoney - UserMoney;
                        //修改
                        if (get_userTab.Update(get_Moduser))
                        {
                            return "true";
                        }
                    }
                    else
                    {
                        //合买用户

                        //花费的金额  购买的份数*每份的金额
                        decimal ChippedMoney = Convert.ToDecimal(dsRefund.Tables[0].Rows[l]["ChippedShare"]) * each;

                        get_Moduser.CurrentMoney = get_Moduser.CurrentMoney - ChippedMoney;
                        get_Moduser.FrozenMoney = get_Moduser.FrozenMoney - ChippedMoney;

                        //修改
                        if (get_userTab.Update(get_Moduser))
                        {
                            return "true";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
            }
            return "false";
        }

        /// <summary>
        /// 方案失败， 退还用户金额
        /// </summary>
        /// <param name="QNumber">方案的编号</param>
        /// <param name="sponsors">发起人</param>
        /// <param name="UserMoney">用户花费金额</param>
        /// <param name="buyUser">购买的用户</param>
        /// <param name="each">没分的金额</param>
        public string ReturnDeductMoney(string QNumber, string sponsors, decimal UserMoney, decimal each)
        {
            Pbzx.BLL.PBnet_UserTable get_userTab = new Pbzx.BLL.PBnet_UserTable();
            //扣除用户购买所花的金额
            DataSet dsRefund = Chipped_Table("v_Merger", "*", "QNumber=" + "'" + QNumber + "'");
            try
            {
                for (int l = 0; l < dsRefund.Tables[0].Rows.Count; l++)
                {
                    //查询购买用户
                    Pbzx.Model.PBnet_UserTable get_Moduser = get_userTab.GetModelName(dsRefund.Tables[0].Rows[l]["ChippedName"].ToString());
                    //用户是发起人
                    if (get_Moduser.UserName.ToString() == sponsors)
                    {
                        //扣除用户购买金额（原有的冻结金额-本次所花的金额）
                        get_Moduser.FrozenMoney = get_Moduser.FrozenMoney - UserMoney;
                        //修改
                        if (get_userTab.Update(get_Moduser))
                        {
                            return "true";
                        }
                    }
                    else
                    {
                        //合买用户

                        //花费的金额  购买的份数*每份的金额
                        decimal ChippedMoney = Convert.ToDecimal(dsRefund.Tables[0].Rows[l]["ChippedShare"]) * each;
                        get_Moduser.FrozenMoney = get_Moduser.FrozenMoney - ChippedMoney;


                        //修改
                        if (get_userTab.Update(get_Moduser))
                        {
                            return "true";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
            }
            return "false";
        }





        #region 统计中奖 返回中奖金额
        /// <summary>
        /// 统计中奖 返回中奖金额
        /// </summary>
        /// <param name="Num">投递的奖号</param>
        /// <param name="RatherNum">开奖号</param>
        /// <param name="playName">玩法</param>
        /// <returns></returns>
        public decimal StatsWinning(string Num, string RatherNum, int playName)
        {
            //3D
            if (playName == 1)
            {
                //百位号码(奖号)
                string SingleNumB = RatherNum.Substring(0, 1);
                //十位号码(奖号)
                string SingleNumS = RatherNum.Substring(1, 1);
                //各位号码（奖号）
                string SingleNumG = RatherNum.Substring(2, 1);
                int flagB = 0;
                int flagS = 0;
                int flagG = 0;
                int flagNum = 0;
                int z_flagNum = 0;
                int z_flagB = 0;
                int z_flagS = 0;
                int z_flagG = 0;
                //购买多少注
                int NoteNum = Num.Split(';').Length;
                for (int i = 0; i < NoteNum; i++)
                {
                    //单式直选 （每注980）
                    if (Convert.ToInt32(Num.Split(';')[i].Split('|')[0]) == 1)
                    {
                        //百位
                        for (int k = 0; k < Num.Split(';')[i].Split('|')[1].Split(',')[0].Length; k++)
                        {
                            if (SingleNumB == Num.Split(';')[i].Split('|')[1].Split(',')[0].Substring(k, 1).ToString())
                            {
                                flagB = 1;
                            }
                        }
                        //十位
                        for (int f = 0; f < Num.Split(';')[i].Split('|')[1].Split(',')[1].Length; f++)
                        {
                            if (SingleNumS == Num.Split(';')[i].Split('|')[1].Split(',')[1].Substring(f, 1).ToString())
                            {
                                flagS = 1;
                            }
                        }
                        //个位
                        for (int g = 0; g < Num.Split(';')[i].Split('|')[1].Split(',')[2].Length; g++)
                        {
                            if (SingleNumG == Num.Split(';')[i].Split('|')[1].Split(',')[2].Substring(g, 1).ToString())
                            {
                                flagG = 1;
                            }
                        }
                        //中奖
                        if (flagB == 1 && flagS == 1 && flagG == 1)
                        {
                            //记录有几注中奖。
                            flagNum++;
                        }

                    }
                    //组选单式
                    if (Convert.ToInt32(Num.Split(';')[i].Split('|')[0]) == 6)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (SingleNumB == Num.Split(';')[i].Split('|')[1].Split(',')[j].ToString())
                            {
                                z_flagB = 1;
                            }
                            if (SingleNumS == Num.Split(';')[i].Split('|')[1].Split(',')[j].ToString())
                            {
                                z_flagS = 1;
                            }
                            if (SingleNumG == Num.Split(';')[i].Split('|')[1].Split(',')[j].ToString())
                            {
                                z_flagG = 1;
                            }

                        }
                        if (z_flagB == 1 && z_flagS == 1 && z_flagG == 1)
                        {
                            //记录中了几注
                            z_flagNum++;
                        }
                    }
                }
                if (flagNum > 0)
                {
                    //返回金额
                    return Convert.ToDecimal(980 * flagNum);
                }

            }
            //双色球
            if (playName == 3)
            {
                int Red = 0;
                int blue = 0;
                //定义计算复式中奖
                int RedF = 0;
                int blueF = 0;

                int note = 0;
                //红球号码
                string RedNum = RatherNum.Split('+')[0].ToString();
                //蓝球号码
                string blueNum = RatherNum.Split('+')[1].ToString();
                int NoteNum = Num.Split(';').Length;
                for (int i = 0; i < NoteNum; i++)
                {
                    //判断是否复式
                    if (Num.Split(';')[i].Split('+')[0].Split(',').Length > 6)
                    {
                        //复式
                        for (int j = 0; j < RedNum.Split(',').Length; j++)
                        {
                            for (int k = 0; k < Num.Split(';')[i].Split('+')[0].Split(',').Length; k++)
                            {
                                if (RedNum.Split(',')[j].ToString() == Num.Split(';')[i].Split('+')[0].Split(',')[k].ToString())
                                {
                                    RedF++;
                                }
                            }
                        }
                        //比对蓝球
                        for (int b = 0; b < blueNum.Split(',').Length; b++)
                        {
                            for (int k = 0; k < Num.Split(';')[i].Split('+')[1].Split(',').Length; k++)
                            {
                                if (blueNum.Split(',')[b].ToString() == Num.Split(';')[i].Split('+')[1].Split(',')[k].ToString())
                                {
                                    blueF++;
                                }
                            }
                        }
                        //复式奖金规则

                        //

                    }
                    else
                    {
                        //单式 （正常的计算）
                        for (int j = 0; j < RedNum.Split(',').Length; j++)
                        {
                            for (int k = 0; k < Num.Split(';')[i].Split('+')[0].Split(',').Length; k++)
                            {
                                if (RedNum.Split(',')[j].ToString() == Num.Split(';')[i].Split('+')[0].Split(',')[k].ToString())
                                {
                                    Red++;
                                }
                            }
                        }
                        //蓝球
                        if (Num.Split(';')[i].Split('+')[1].ToString() == blueNum)
                        {
                            blue = 1;
                        }
                        //6等奖
                        if (Red < 3 && blue == 1)
                        {
                            //中奖5块
                            return Convert.ToDecimal(5);
                        }
                        //5等奖
                        if (Red == 4 || (Red == 3 && blue == 1))
                        {
                            //5等奖  10块
                            return Convert.ToDecimal(10);
                        }
                        //4等奖
                        if (Red == 5 || (Red == 4 && blue == 1))
                        {
                            return Convert.ToDecimal(200);
                        }
                        //3等奖
                        if (Red == 5 && blue == 1)
                        {
                            return Convert.ToDecimal(3000);
                        }
                        //2等奖
                        if (Red == 6)
                        {
                            return Convert.ToDecimal(0);
                        }
                    }
                }

            }
            return Convert.ToDecimal(0);
        }
        #endregion


        #region  分配中奖金额
        /// <summary>
        /// 添加个人中奖信息
        /// </summary>
        /// <param name="money">中奖金额</param>
        /// <param name="name">中奖人</param>
        /// <param name="Qnum">单号</param>
        /// <param name="playName">彩种标识</param>
        /// <returns></returns>
        public int AllotMoney(decimal money, string name, string Qnum, int playName)
        {
            Pbzx.BLL.Chipped_bounsAllost get_ba = new Pbzx.BLL.Chipped_bounsAllost();
            Pbzx.Model.Chipped_bounsAllost mod_ba = new Pbzx.Model.Chipped_bounsAllost();
            try
            {
                //验证数据是否存在
                if (!get_ba.Exists(Qnum, name, playName))
                {
                    //不存在，  添加数据
                    mod_ba.AwardNum = Qnum;
                    mod_ba.AwardName = name;
                    mod_ba.bounsAllost = money;
                    mod_ba.lotteryState = playName;
                    mod_ba.AssignState = 1;
                    mod_ba.ATime = DateTime.Now;

                    if (get_ba.Add(mod_ba) > 0)
                    {
                        //添加成功
                    }
                    else
                    {
                        //添加失败
                    }

                }
                else
                {
                    //存在 跳过
                }
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
            }
            return 0;
        }
        #endregion

        #region  用户消费记录
        /// <summary>
        /// 用户消费记录
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="acctType">类型 支出  收取</param>
        /// <param name="PayItem">项目名称</param>
        /// <param name="specificItem">具体操作</param>
        /// <returns></returns>
        public void record(string UserName, int acctType, string PayItem, string specificItem)
        {
            Pbzx.BLL.Chipped_AcctPayCharge get_apc = new Pbzx.BLL.Chipped_AcctPayCharge();
            Pbzx.Model.Chipped_AcctPayCharge mod_apc = new Pbzx.Model.Chipped_AcctPayCharge();
            mod_apc.apcName = UserName;
            mod_apc.acctType = acctType;
            mod_apc.Payltem = PayItem;
            mod_apc.specificItem = specificItem;
            mod_apc.apcTime = DateTime.Now;

            get_apc.Add(mod_apc);
        }
        #endregion

        public static string lotteryNameData(string NvarApp_name)
        {
            publicMethod pb = new publicMethod();
            DataSet dsData = pb.Chipped_Table("PBnet_LotteryMenu", "NvarLott_date", "NvarApp_name='" + NvarApp_name + "'");
            return Method.GetLottDate1(dsData.Tables[0].Rows[0]["NvarLott_date"].ToString());
        }


        /// <summary>
        /// 获取彩种的下一期 期号
        /// </summary>
        /// <param name="lotteryName">彩种ID</param>
        /// <returns></returns>
        public static string Period(string NvarApp_name)
        {
            publicMethod pb = new publicMethod();
            //根据彩种的id 查询到彩种所使用的数据库
            DataSet dsData = pb.Chipped_Table("PBnet_LotteryMenu", "NvarApp_name", "NvarApp_name='" + NvarApp_name + "'");

            //查询彩种的期号(期号在开完奖后更新)

            DataSet dsperiod = null;
            int period = 0;
            if (NvarApp_name == "FC3DData")
            {
                dsperiod = Maticsoft.DBUtility.DbHelperSQL1.Query("select issue,code from " + dsData.Tables[0].Rows[0]["NvarApp_name"].ToString() + " order by issue desc");
                //最新的期号（下一期的期号 开奖期号+1=下一期的期号）
                period = Convert.ToInt32(dsperiod.Tables[0].Rows[0]["issue"]);

                if (dsperiod.Tables[0].Rows[0]["code"] == null || dsperiod.Tables[0].Rows[0]["code"].ToString() == "")
                {
                }
                else
                {
                    period = period + 1;
                }
            }
            else
            {
                dsperiod = Maticsoft.DBUtility.DbHelperSQL1.Query("select issue from " + dsData.Tables[0].Rows[0]["NvarApp_name"].ToString() + " order by issue desc");
                //最新的期号（下一期的期号 开奖期号+1=下一期的期号）
                period = Convert.ToInt32(dsperiod.Tables[0].Rows[0]["issue"]) + 1;
            }



            XmlDocument doc = new XmlDocument();
            //判断是添加什么类型限定
            doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/DownIssue.xml"));

            //得到根节点
            XmlElement root = doc.DocumentElement;
            if (root.ChildNodes.Count > 0)
            {
                string name = dsData.Tables[0].Rows[0]["NvarApp_name"].ToString();

                XmlNode ISContent = root.SelectNodes(name)[0];
                if (ISContent != null)
                {
                    //得到他的ID
                    string issue = ISContent.SelectSingleNode("@Issue").Value;
                    if (Convert.ToInt32(issue) > period)
                    {
                        return issue;
                    }
                }
            }

            return period.ToString();
        }
        /// <summary>
        /// 获取彩种的下一期 期号
        /// </summary>
        /// <param name="lotteryName">彩种ID</param>
        /// <returns></returns>
        public static string Period(int IntID)
        {
            publicMethod pb = new publicMethod();
            //根据彩种的id 查询到彩种所使用的数据库
            DataSet dsData = pb.Chipped_Table("PBnet_LotteryMenu", "NvarApp_name", "IntID='" + IntID + "'");
            DataSet dsperiod = new DataSet();
            int period = 0;
            if (dsData.Tables[0].Rows[0]["NvarApp_name"].ToString() == "FC3DData")
            {
                dsperiod = Maticsoft.DBUtility.DbHelperSQL1.Query("select issue,code from " + dsData.Tables[0].Rows[0]["NvarApp_name"].ToString() + " order by issue desc");
                //最新的期号（下一期的期号 开奖期号+1=下一期的期号）
                period = Convert.ToInt32(dsperiod.Tables[0].Rows[0]["issue"]);

                if (dsperiod.Tables[0].Rows[0]["code"] == null || dsperiod.Tables[0].Rows[0]["code"].ToString() == "")
                {
                }
                else
                {
                    period = period + 1;
                }
            }
            else
            {
                //查询彩种的期号(期号在开完奖后更新)
                dsperiod = Maticsoft.DBUtility.DbHelperSQL1.Query("select issue from " + dsData.Tables[0].Rows[0]["NvarApp_name"].ToString() + " order by issue desc");

                //最新的期号（下一期的期号 开奖期号+1=下一期的期号）
                period = Convert.ToInt32(dsperiod.Tables[0].Rows[0]["issue"]) + 1;
            }
            XmlDocument doc = new XmlDocument();
            //判断是添加什么类型限定
            doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/DownIssue.xml"));

            //得到根节点
            XmlElement root = doc.DocumentElement;
            if (root.ChildNodes.Count > 0)
            {
                string name = dsData.Tables[0].Rows[0]["NvarApp_name"].ToString();

                XmlNode ISContent = root.SelectNodes(name)[0];
                if (ISContent != null)
                {
                    //得到他的ID
                    string issue = ISContent.SelectSingleNode("@Issue").Value;
                    if (Convert.ToInt32(issue) > period)
                    {
                        return issue;
                    }
                }
            }

            return period.ToString();
        }
        /// <summary>
        /// 返回开奖号码
        /// </summary>
        /// <param name="dataName">对应的彩种数据库表</param>
        /// <param name="playName">彩种Id</param>
        /// <param name="issue">期号</param>
        /// <returns></returns>
        public string RlotteryNum(string dataName, int playName, int issue)
        {
            DataSet ds = new DataSet();
            if (playName == 1)
            {
                //3D
                ds = Maticsoft.DBUtility.DbHelperSQL1.Query("select code from " + dataName + " where issue=" + issue);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0][0].ToString();
                }
            }
            if (playName == 2)
            {
                //七乐彩
                ds = Maticsoft.DBUtility.DbHelperSQL1.Query("select code,tcode from " + dataName + " where issue=" + issue);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    //处理号码球
                    string Rball = "";
                    for (int i = 0; i < ds.Tables[0].Rows[0]["code"].ToString().Length; i++)
                    {
                        Rball += ds.Tables[0].Rows[0]["code"].ToString().Substring(i, 2) + ",";
                        i++;
                    }
                    return Rball.Substring(0, Rball.Length - 1) + "+" + ds.Tables[0].Rows[0]["tcode"].ToString();
                }
            }
            if (playName == 3)
            {
                //双色球
                ds = Maticsoft.DBUtility.DbHelperSQL1.Query("select redcode,bluecode from " + dataName + " where issue=" + issue);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    //处理号码球
                    string Rball = "";
                    for (int i = 0; i < ds.Tables[0].Rows[0]["redcode"].ToString().Length; i++)
                    {
                        Rball += ds.Tables[0].Rows[0]["redcode"].ToString().Substring(i, 2) + ",";
                        i++;
                    }
                    return Rball.Substring(0, Rball.Length - 1) + "+" + ds.Tables[0].Rows[0]["bluecode"].ToString();
                }
            }
            if (playName == 4)
            {
                //排列5
                ds = Maticsoft.DBUtility.DbHelperSQL1.Query("select code5 from " + dataName + " where issue=" + issue);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0][0].ToString();
                }
            }
            if (playName == 9999)
            {
                //排列3
                ds = Maticsoft.DBUtility.DbHelperSQL1.Query("select code3 from " + dataName + " where issue=" + issue);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0][0].ToString();
                }
            }
            if (playName == 5)
            {
                //七星彩
                ds = Maticsoft.DBUtility.DbHelperSQL1.Query("select code from " + dataName + " where issue=" + issue);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0][0].ToString();
                }
            }
            if (playName == 6)
            {
                //大乐透
                ds = Maticsoft.DBUtility.DbHelperSQL1.Query("select code,code2 from " + dataName + " where issue=" + issue);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    //处理号码球
                    string Rball = "";
                    for (int i = 0; i < ds.Tables[0].Rows[0]["code"].ToString().Length; i++)
                    {
                        Rball += ds.Tables[0].Rows[0]["code"].ToString().Substring(i, 2) + ",";
                        i++;
                    }
                    return Rball.Substring(0, Rball.Length - 1) + "+" + ds.Tables[0].Rows[0]["code2"].ToString().Substring(0, 2) + "," + ds.Tables[0].Rows[0]["code2"].ToString().Substring(2, 2);

                }
            }
            return "";
        }

        //和彩票销售商交互处理数据

        /// <summary>
        /// 处理xml
        /// </summary>
        public string Receive(string xml)
        {

            //声明一个XMLDoc文档对象，LOAD（）xml字符串
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            XmlNode node = doc.SelectSingleNode("./ActionResult");
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (XmlNode item in node.ChildNodes)
                sb.Append(item.Name + "|" + item.InnerText + ",");

            return sb.ToString();


        }

        /// <summary>
        /// 业务参数
        /// </summary>
        /// <param name="wAgent">代理商编号</param>
        /// <param name="wAction">交易申请码</param>
        /// <param name="wMsgID">交易消息序号</param>
        /// <param name="wParam">业务参数</param>
        /// <param name="wSign">客户端签名（MD5加密） 注意：务必使用GB2312编码的字符串进行密钥计算。号码串组成</param>
        /// <returns></returns>
        public string PostStr(int wAgent, int wAction, string wMsgID, string wParam)
        {

            //需要加密的 字符串
            string EncMD5 = wAgent.ToString() + wAction + wMsgID + wParam + "a8b8c8d8e8f8g8h8";

            //签名 
            string nwSign = Input.MD5(EncMD5, false);

            string postStr = "wAgent=" + wAgent + "&wAction=" + wAction + "&wMsgID=" + wMsgID + "&wSign=" + nwSign + "&wParam=" + wParam;

            return postStr;
        }

        /// <summary>
        /// 发送交易请求 并接收返回值
        /// </summary>
        /// <param name="prar">业务请求参数</param>
        public string PostUrl(string getStr)
        {
            string url = "http://t.zc310.net:8089/bin/LotSaleHttp.dll";

            string str = GetPage(url, getStr);

            return str;

        }
        /// <summary>
        /// 以post 编码gb2312的方式 发送http 请求
        /// </summary>
        /// <param name="posturl">提交的路径</param>
        /// <param name="postData">提交的参数</param>
        /// <returns></returns>
        public string GetPage(string posturl, string postData)
        {
            Stream outstream = null;
            Stream instream = null;
            StreamReader sr = null;
            HttpWebResponse response = null;
            HttpWebRequest request = null;
            Encoding encoding = System.Text.Encoding.GetEncoding("gb2312");
            byte[] data = encoding.GetBytes(postData);
            // 准备请求...
            try
            {
                // 设置参数
                request = WebRequest.Create(posturl) as HttpWebRequest;
                CookieContainer cookieContainer = new CookieContainer();
                request.CookieContainer = cookieContainer;
                request.AllowAutoRedirect = true;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                outstream = request.GetRequestStream();
                outstream.Write(data, 0, data.Length);
                outstream.Close();
                //发送请求并获取相应回应数据
                response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求
                instream = response.GetResponseStream();
                sr = new StreamReader(instream, encoding);
                //返回结果网页（html）代码
                string content = sr.ReadToEnd();

                string err = string.Empty;
                return content;


            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return string.Empty;
            }
        }


        /// <summary>
        /// 处理投注 返回请求参数字符串  请求参数
        /// </summary>
        /// <param name="OrderID">投注订单号（商家自己生成）注：只能使用数字和英文字母</param>
        /// <param name="LotID">代理商投注的彩票编号</param>
        /// <param name="LotIssue">投注的期号</param>
        /// <param name="LotMoney">投注总金额（包含多倍多期的总金额）</param>
        /// <param name="LotCode">投注号码</param>
        /// <param name="LotMulti">投注倍数，倍数范围限制为1～99</param>
        /// <param name="Attach">附加信息 不能使用中文</param>
        /// <param name="OneMoney">单注投注金额  乐透追加投注为3元</param>
        /// <returns></returns>
        public string PostBetting(string OrderID, int LotID, int LotIssue, int LotMoney, string LotCode, int LotMulti, string Attach, int OneMoney)
        {
            //业务参数

            string prar = "OrderID=" + OrderID + "_LotID=" + LotID + "_LotIssue=" + LotIssue + "_LotMoney=" + LotMoney + "_LotMulti=" + LotMulti + "_OneMoney=" + OneMoney + "_LotCode=" + LotCode + "_Attach=" + Attach;
            return prar;
        }

        /// <summary>
        /// 投注
        /// </summary>
        /// <param name="prar">业务参数</param>
        /// <returns></returns>
        public string bett(string prar)
        {
            
            //请求参数
            string getStr = PostStr(3821, 101, "zzzzzzz", prar);

            string str = PostUrl(getStr);

            //接收返回字符串
            string xmlStr = Receive(str);

            return xmlStr;
        }

        /// <summary>
        /// 业务操作
        /// </summary>
        /// <param name="prar">业务参数</param>
        /// <param name="code">业务代码</param>
        /// <returns></returns>
        public string bett(string prar,int code)
        {

            //请求参数
            string getStr = PostStr(3821, code, "zzzzzzz", prar);

            string str = PostUrl(getStr);

            //接收返回字符串
            string xmlStr = Receive(str);

            return xmlStr;
        }

        //和彩票销售商交互处理数据


        /// <summary>
        /// 扣除用户购买花费金额 合买代购订单
        /// </summary>
        /// <param name="orderNum">订单号</param>
        public void DeductionMonery(string orderNum)
        {
            Pbzx.BLL.Chipped_LaunchInfoManage get_lif = new Chipped_LaunchInfoManage();
            Pbzx.BLL.PBnet_UserTable get_utab = new Pbzx.BLL.PBnet_UserTable();
            Pbzx.Model.PBnet_UserTable mod_utab = new Pbzx.Model.PBnet_UserTable();

            //查询订单
            DataSet ds = get_lif.GetList("QNumber=" + "'" + orderNum + "'");

            //合买代购
            if (Convert.ToInt32(ds.Tables[0].Rows[0]["Purchasing"]) == 1)
            {
                //代购
                DataSet ds_user = Chipped_Table("PBnet_UserTable", "Id", "UserName=" + "'" + ds.Tables[0].Rows[0]["UserName"] + "'");
                mod_utab = get_utab.GetModel(Convert.ToInt32(ds_user.Tables[0].Rows[0]["Id"]));
                mod_utab.CurrentMoney = mod_utab.CurrentMoney - Convert.ToDecimal(ds.Tables[0].Rows[0]["AtotalMoney"]);
                mod_utab.FrozenMoney = mod_utab.FrozenMoney - Convert.ToDecimal(ds.Tables[0].Rows[0]["AtotalMoney"]);
                try
                {
                    if (get_utab.Update(mod_utab))
                    {
                        //记录本次交易
                        //个人收支账户记录
                        Pbzx.BLL.PlatformPublic_payments get_pmen = new Pbzx.BLL.PlatformPublic_payments();
                        get_pmen.payments(ds.Tables[0].Rows[0]["UserName"].ToString(),orderNum, 1, Convert.ToInt32(ds.Tables[0].Rows[0]["ExpectNum"]), Convert.ToInt32(ds.Tables[0].Rows[0]["playName"]),ds.Tables[0].Rows[0]["ExpectNum"].ToString()+"期"+"订单出票成功扣除资金", Convert.ToInt32(ds.Tables[0].Rows[0]["AtotalMoney"]), "Chipped");
                    }
                }
                catch (Exception ex)
                {
                    //全局错误日志
                    Pbzx.Common.ErrorLog.WriteLog(ex);
                }
            }
            if (Convert.ToInt32(ds.Tables[0].Rows[0]["Purchasing"]) == 2)
            {
                //查询所有合买用户
                DataSet ds_buy = Chipped_Table("v_Merger", "*", "QNumber=" + "'" + orderNum + "'");

                //方案单份的价格
                decimal nEachMoney = Convert.ToDecimal(ds.Tables[0].Rows[0]["AtotalMoney"]) / Convert.ToInt32(ds.Tables[0].Rows[0]["Share"]);

                //合买 查询没个合买用户所花费的金额
                for (int i = 0; i < ds_buy.Tables[0].Rows.Count; i++)
                {
                    //所花费的金额
                    decimal nConsumption = nEachMoney * Convert.ToInt32(ds_buy.Tables[0].Rows[i]["ChippedShare"]);

                    DataSet ds_user = Chipped_Table("PBnet_UserTable", "Id", "UserName=" + "'" + ds_buy.Tables[0].Rows[i]["ChippedName"] + "'");
                    mod_utab = get_utab.GetModel(Convert.ToInt32(ds_user.Tables[0].Rows[0]["Id"]));
                    mod_utab.CurrentMoney = mod_utab.CurrentMoney - nConsumption;
                    mod_utab.FrozenMoney = mod_utab.FrozenMoney - nConsumption;
                    try
                    {
                        if (get_utab.Update(mod_utab))
                        {
                            //记录本次交易
                            //个人收支账户记录
                            Pbzx.BLL.PlatformPublic_payments get_pmen = new Pbzx.BLL.PlatformPublic_payments();
                            get_pmen.payments(ds_buy.Tables[0].Rows[i]["ChippedName"].ToString(),orderNum, 1, Convert.ToInt32(ds.Tables[0].Rows[0]["ExpectNum"]), Convert.ToInt32(ds.Tables[0].Rows[0]["playName"]), ds.Tables[0].Rows[0]["ExpectNum"].ToString() + "期" + "订单出票成功扣除资金", nConsumption, "Chipped");
                        }
                    }
                    catch (Exception ex)
                    {
                        //全局错误日志
                        Pbzx.Common.ErrorLog.WriteLog(ex);
                    }
                }
            }

        }

        /// <summary>
        /// 扣除用户追号所用金额  处理追号订单
        /// </summary>
        /// <param name="OrderNum"></param>
        public void DedMoneyTackNum(string OrderNum)
        {
            Pbzx.BLL.Chipped_TrackNum get_tk = new Chipped_TrackNum();
            Pbzx.BLL.PBnet_UserTable get_ut = new PBnet_UserTable();
            Pbzx.Model.PBnet_UserTable mod_ut = new Model.PBnet_UserTable();
            //查询数据
            DataSet ds = get_tk.GetList("tn_orderNum=" + "'" + OrderNum + "'");
            DataSet ds_user = Chipped_Table("PBnet_UserTable", "IntId", "UserName=" + "'" + ds.Tables[0].Rows[0]["tn_username"].ToString() + "'");
            mod_ut = get_ut.GetModel(Convert.ToInt32(ds_user.Tables[0].Rows[0]["IntId"]));

            //用户此单花费金额
            decimal nEachMoney = Convert.ToDecimal(ds.Tables[0].Rows[0]["tn_money"]);

            mod_ut.CurrentMoney = mod_ut.CurrentMoney - nEachMoney;
            mod_ut.FrozenMoney = mod_ut.FrozenMoney - nEachMoney;
            try
            {
                if (get_ut.Update(mod_ut))
                {
                    //记录本次交易
                    //个人收支账户记录
                    Pbzx.BLL.PlatformPublic_payments get_pmen = new Pbzx.BLL.PlatformPublic_payments();
                    get_pmen.payments(ds.Tables[0].Rows[0]["tn_username"].ToString(),OrderNum, 1, Convert.ToInt32(ds.Tables[0].Rows[0]["tn_issue"]), Convert.ToInt32(ds.Tables[0].Rows[0]["tn_playname"]), "追号订单出票成功扣除资金", nEachMoney, "Chipped");
                }
            }
            catch (Exception ex)
            {
                //全局错误日志
                Pbzx.Common.ErrorLog.WriteLog(ex);
            }
        }
        /// <summary>
        /// 扣除多期机选金额 （当前期的购买金额）
        /// </summary>
        /// <param name="Qnum"></param>
        public void DeductionDqM(string Qnum)
        {
            Pbzx.BLL.PBnet_UserTable get_ut = new PBnet_UserTable();
            Pbzx.Model.PBnet_UserTable mod_ut = new Model.PBnet_UserTable();
            //查询数据
            DataSet ds = Chipped_Table("v_RandomNumIssue", "Rn_name,In_money,In_issue,Rn_play", "In_num=" + "'" + Qnum + "'");
            DataSet ds_user = Chipped_Table("PBnet_UserTable", "IntId", "UserName=" + "'" + ds.Tables[0].Rows[0]["Rn_name"].ToString() + "'");
            mod_ut = get_ut.GetModel(Convert.ToInt32(ds_user.Tables[0].Rows[0]["IntId"]));

            //用户此单花费金额
            decimal nEachMoney = Convert.ToDecimal(ds.Tables[0].Rows[0]["In_money"]);

            mod_ut.CurrentMoney = mod_ut.CurrentMoney - nEachMoney;
            mod_ut.FrozenMoney = mod_ut.FrozenMoney - nEachMoney;
            try
            {
                if (get_ut.Update(mod_ut))
                {
                    //记录本次交易
                    //个人收支账户记录
                    Pbzx.BLL.PlatformPublic_payments get_pmen = new Pbzx.BLL.PlatformPublic_payments();
                    get_pmen.payments(ds.Tables[0].Rows[0]["Rn_name"].ToString(), Qnum, 1, Convert.ToInt32(ds.Tables[0].Rows[0]["In_issue"]), Convert.ToInt32(ds.Tables[0].Rows[0]["Rn_play"]), "多期机选出票成功扣除资金", nEachMoney, "Chipped");
                }
            }
            catch (Exception ex)
            {
                //全局错误日志
                Pbzx.Common.ErrorLog.WriteLog(ex);
            }
        }



        /// <summary>
        /// 彩种对比编号
        /// </summary>
        /// <param name="playName">彩种编号</param>
        /// <returns></returns>
        public int LotContrast(int playName)
        {
            if (playName == 1)
            {
                //3D 
                return 52;
            }
            if (playName == 2)
            {
                //七乐彩
                return 23528;
            }
            if (playName == 3)
            {
                //双色球
                return 51;
            }
            if (playName == 9999)
            {
                //排列3
                return 33;
            }
            if (playName == 4)
            {
                //排列5
                return 35;
            }
            if (playName == 5)
            {
                //七星彩
                return 10022;
            }
            if (playName == 6)
            {
                //大乐透
                return 23529;
            }
            return 0;
        }
        /// <summary>
        /// 查询开奖号码
        /// </summary>
        /// <param name="LotID">彩票编号</param>
        /// <param name="LotIssue">期号</param>
        /// <returns></returns>
        public string Lnum(int LotID, int LotIssue)
        {
            string prar = "LotID=" + LotID + "_LotIssue=" + LotIssue;
            string xmlStr = bett(prar, 110);
            int code = -1;

            for (int i = 0; i < xmlStr.Split(',').Length; i++)
            {
                if (xmlStr.Split(',')[i].Split('|')[0] == "xCode")
                {
                    code = Convert.ToInt32(xmlStr.Split(',')[i].Split('|')[1]);
                    break;
                }
            }
            string num = "";
            for (int i = 0; i < xmlStr.Split(',').Length; i++)
            {
                if (xmlStr.Split(',')[i].Split('|')[0] == "xValue")
                {
                    num = xmlStr.Split(',')[i].Split('|')[1].Split('_')[1].ToString();
                    break;
                }
            }
            return num;
        }


    }

}
