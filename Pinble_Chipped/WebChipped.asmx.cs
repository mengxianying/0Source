using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using Pbzx.BLL;
using Pbzx.Model;
using System.Text;
using System.Web.UI;
using Maticsoft.DBUtility;
using System.IO;
using Pbzx.Common;

namespace Pinble_Chipped
{
    /// <summary>
    /// WebChipped 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]

    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]
    public class WebChipped : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        /// <summary>
        /// 合买代购发起 添加数据
        /// </summary>
        /// <param name="QNumber">流水订单号</param>
        /// <param name="Title">标题</param>
        /// <param name="say">介绍说明</param>
        /// <param name="LaunchTime">发布时间</param>
        /// <param name="playname">彩种的玩法ID</param>
        /// <param name="ExpectNum">期号</param>
        /// <param name="ChoiceNum">购买的号码</param>
        /// <param name="UserName">发起的会员</param>
        /// <param name="doubles">倍数</param>
        /// <param name="share">份数</param>
        /// <param name="obj">开放设置</param>
        /// <param name="BuyShare">自己选购的份数</param>
        /// <param name="Protect">保底</param>
        /// <param name="Commission">提成比例</param>
        /// <param name="Purchasing">合买，代购</param>
        /// <param name="Money">方案总体的金额</param>
        /// <param name="Statc"> 成功标识： 代购显示成功， 合买开奖的时候修改标识</param>
        /// <returns></returns>
        [WebMethod]
        public int addChipped(string num, string title, string say, string launchtime, int playname, int expectnum, string choicenum, string username, int doubles, int share, int obj, int buyshare, int protect, int commisstion, int purchasing, decimal AtotalMoney, int Statc)
        {
            Chipped_LaunchInfoManage get_cl = new Chipped_LaunchInfoManage();
            chipped_LaunchInfo clMod = new chipped_LaunchInfo();
            //查询用户帐户的余额是否能支付购买
            publicMethod pubMod = new publicMethod();
            DataSet ds = pubMod.Chipped_Table("PBnet_UserTable", "Id,CurrentMoney,FrozenMoney", "UserName=" + "'" + username + "'");
            Pbzx.BLL.PBnet_UserTable get_userTab = new Pbzx.BLL.PBnet_UserTable();
            Pbzx.Model.PBnet_UserTable modUserTab = get_userTab.GetModel(Convert.ToInt32(ds.Tables[0].Rows[0]["Id"]));

            //代理商彩种编号
            int nLotNum = pubMod.LotContrast(playname);

            //判断数据是否已经存在
            if (!get_cl.Exists(num))
            {

                //判断用户余额是否够支付此次购买的份数的金额
                decimal buyMoney = AtotalMoney / share * buyshare;
                //支付金额  小于  用户的可用资金（可用资金=余额-冻结资金）
                if (buyMoney < Convert.ToDecimal(ds.Tables[0].Rows[0]["CurrentMoney"]) - Convert.ToDecimal(ds.Tables[0].Rows[0]["FrozenMoney"]))
                {
                    //余额充足
                    clMod.QNumber = num;
                    clMod.Title = title;
                    clMod.Say = say;
                    clMod.LaunchTime =Convert.ToDateTime(launchtime);
                    clMod.playName = playname;
                    clMod.ExpectNum = expectnum;
                    clMod.ChoiceNum = choicenum;
                    clMod.UserName = username;
                    clMod.doubles = doubles;
                    clMod.Share = share;
                    clMod.Object = obj.ToString();
                    clMod.BuyShare = buyshare;
                    clMod.Protect = protect;
                    clMod.Commission = commisstion;
                    clMod.Purchasing = purchasing;
                    clMod.AtotalMoney = AtotalMoney;
                    clMod.State = Statc;
                    clMod.Winning = 0;
                    clMod.opens = 0;
                    clMod.bounsAllost = "0";

                    try
                    {
                        //添加成功后 把所花金额
                        if (get_cl.Add(clMod) > 0)
                        {
                            //代购  （直接扣除用户的金额）
                            if (purchasing == 1)
                            {

                                //投注业务参数
                                string prar = pubMod.PostBetting(num, nLotNum, 20120626, Convert.ToInt32(AtotalMoney), choicenum, doubles, "wwwwwwwww", 2);

                                //返回的字符串
                                string xmlStr = pubMod.bett(prar);
                                int code = 9;

                                for (int i = 0; i < xmlStr.Split(',').Length; i++)
                                {
                                    if (xmlStr.Split(',')[i].Split('|')[0] == "xCode")
                                    {
                                        code = Convert.ToInt32(xmlStr.Split(',')[i].Split('|')[1]);
                                        break;
                                    }
                                }
                                if (code == 0)
                                {
                                    //投注成功 (投注成功，冻结资金， 可能有出票失败)
                                    modUserTab.FrozenMoney = modUserTab.FrozenMoney + Convert.ToDecimal(buyMoney);
                                    //修改账户金额
                                    if (get_userTab.Update(modUserTab))
                                    {
                                        //个人收支账户记录
                                        Pbzx.BLL.PlatformPublic_payments get_pmen = new Pbzx.BLL.PlatformPublic_payments();
                                        get_pmen.payments(username, num, 3, expectnum, playname, "代购发起成功冻结资金", Convert.ToDecimal(buyMoney), "Chipped");
                                        return 1;
                                    }
                                }
                                else
                                {
                                    //get_cl.Delete(num);
                                    //投注失败  更改标识  4: 方案失败未退款的。
                                    Pbzx.BLL.Chipped_LaunchInfoManage get_lif = new Chipped_LaunchInfoManage();
                                    Pbzx.Model.chipped_LaunchInfo mod_lif = get_lif.GetModel(num);
                                    mod_lif.State = 4;
                                    mod_lif.opens = code;
                                    try
                                    {
                                        if (get_lif.Update(mod_lif) > 0)
                                        {
                                            //个人收支账户记录
                                            Pbzx.BLL.PlatformPublic_payments get_pmen = new Pbzx.BLL.PlatformPublic_payments();
                                            get_pmen.payments(username, num, 3, expectnum, playname, "代购订单" + num + "发起失败，等待退款处理", Convert.ToDecimal(buyMoney), "Chipped");
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        //全局错误日志
                                        Pbzx.Common.ErrorLog.WriteLog(ex);
                                    }
                                }
                            }
                            if (purchasing == 2)
                            {
                                //添加成功把用户所花金额先冻结(本次金额+原有的冻结金额)
                                modUserTab.FrozenMoney = Convert.ToDecimal(buyMoney) + Convert.ToDecimal(ds.Tables[0].Rows[0]["FrozenMoney"]);
                                //修改成功
                                if (get_userTab.Update(modUserTab))
                                {
                                    //个人收支账户记录
                                    Pbzx.BLL.PlatformPublic_payments get_pmen = new Pbzx.BLL.PlatformPublic_payments();
                                    get_pmen.payments(username, num, 3, expectnum, playname, "合买发起成功冻结资金", Convert.ToDecimal(buyMoney), "Chipped");
                                    if (colpete(num))
                                    {
                                        //投注业务参数
                                        string prar = pubMod.PostBetting(num, nLotNum, 20120626, Convert.ToInt32(AtotalMoney), choicenum, doubles, "wwwwwwwww", 2);


                                        //返回的字符串
                                        string xmlStr = pubMod.bett(prar);

                                        int code = -1;

                                        for (int i = 0; i < xmlStr.Split(',').Length; i++)
                                        {
                                            if (xmlStr.Split(',')[i].Split('|')[0] == "xCode")
                                            {
                                                code = Convert.ToInt32(xmlStr.Split(',')[i].Split('|')[1]);
                                                break;
                                            }
                                        }
                                        //投注成功（返回  投注成功 订单100%销售完成，返回标识3： 投注成功 未出票）
                                        if (code == 0)
                                        {
                                            return 3;
                                        }
                                        else
                                        {
                                            //销售商返回失败数据 
                                            Pbzx.BLL.Chipped_LaunchInfoManage get_lif = new Chipped_LaunchInfoManage();
                                            Pbzx.Model.chipped_LaunchInfo mod_lif = get_lif.GetModel(num);
                                            mod_lif.opens = code;
                                            mod_lif.State = 4;
                                            try
                                            {
                                                if (get_lif.Update(mod_lif) > 0)
                                                {
                                                    //个人收支账户记录 
                                                    get_pmen.payments(username, num, 3, expectnum, playname, "合买订单" + num + "投注失败，等待退款处理", Convert.ToDecimal(buyMoney), "Chipped");
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                //全局错误日志
                                                Pbzx.Common.ErrorLog.WriteLog(ex);
                                            }

                                        }
                                    }
                                    else
                                    { 
                                        //处理跟单
                                        int n_returnNum=CustomTrack(username, playname, num);
                                        if (n_returnNum == 0)
                                        {
                                            return 1;
                                        }
                                        if (n_returnNum == 1)
                                        {
                                            return 3;
                                        }
                                    }
                                   return 1;

                                }
                                else
                                {
                                    if (get_cl.Delete(num) > 0)
                                    {

                                    }
                                    else
                                    {
                                        return 0;
                                    }
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
                    //余额不足
                    return -1;
                }
            }
            return 0;
        }

        /// <summary>
        /// 判断购买的份数 是否合法
        /// </summary>
        /// <param name="num">购买的份数</param>
        /// <param name="Qnum">流水账号</param>
        /// <returns></returns>
        [WebMethod]
        public int shareNum(int num, string Qnum)
        {
            publicMethod get_pub = new publicMethod();
            //获取购买的份数
            DataSet dsNum = get_pub.Statistics("QNumber=" + "'" + Qnum + "'");
            //发布人分配的总份数
            DataSet dsNumAll = get_pub.Chipped_Table("Chipped_LaunchInfo", "Share", "QNumber=" + "'" + Qnum + "'");
            //剩余的份数
            int shareNum = Convert.ToInt32(dsNumAll.Tables[0].Rows[0][0]) - Convert.ToInt32(dsNum.Tables[0].Rows[0][0]);
            if (shareNum <= 0)
            {
                //方案出售完毕
                return 1;
            }
            else
            {
                //购买的份数 大于剩余份数
                if (num > shareNum)
                {
                    //2: 购买份数大于 剩余份数  不成功
                    return 2;
                }
            }
            //购买合法
            return 3;
        }


        /// <summary>
        /// 合买添加
        /// </summary>
        /// <param name="Qnum">流水号</param>
        /// <param name="share">购买的份数</param>
        /// <returns></returns>
        [WebMethod]
        public int ChippedAdd(string Qnum, int share)
        {
            Chipped_InfoManage get_info = new Chipped_InfoManage();
            Chipped_Info ModInfo = new Chipped_Info();
            ModInfo.QNumber = Qnum;
            ModInfo.ChippedName = Method.Get_UserName.ToString();
            ModInfo.ChippedShare = share;
            ModInfo.ChippedTime = DateTime.Now.ToLocalTime();
            if (get_info.Add(ModInfo) > 0)
            {
                publicMethod get_p = new publicMethod();
                //用户账户金额是否够支付
                DataSet ds_money = get_p.Chipped_Table("PBnet_UserTable", "Id", "UserName=" + "'" + Method.Get_UserName.ToString() + "'");
                Pbzx.BLL.PBnet_UserTable get_userTab = new Pbzx.BLL.PBnet_UserTable();
                Pbzx.Model.PBnet_UserTable modUserTab = get_userTab.GetModel(Convert.ToInt32(ds_money.Tables[0].Rows[0]["Id"]));


                //根据与流水号查询合买订单的信息
                DataSet ds = get_p.Chipped_Table("Chipped_LaunchInfo", "ExpectNum,AtotalMoney,Share,playName,doubles,ChoiceNum", "QNumber=" + "'" + Qnum + "'");

                //代理商彩种编号
                int nLotNum = get_p.LotContrast(Convert.ToInt32(ds.Tables[0].Rows[0]["playName"]));

                //计算每份的价格
                decimal nEachMoney = Math.Round(Convert.ToDecimal(ds.Tables[0].Rows[0]["AtotalMoney"]) / Convert.ToInt32(ds.Tables[0].Rows[0]["Share"]), 2);
                //会员花费的金额
                decimal nBuyMoney = nEachMoney * share;

                if (modUserTab.CurrentMoney - modUserTab.FrozenMoney < nBuyMoney)
                {
                    //会员账户余额不足
                    return 2;
                }
                else
                {
                    //冻结会员购买金额
                    modUserTab.FrozenMoney = Convert.ToDecimal(nBuyMoney) + Convert.ToDecimal(modUserTab.FrozenMoney);
                    try
                    {
                        //修改会员金额
                        if (get_userTab.Update(modUserTab))
                        {
                            //个人收支账户记录
                            Pbzx.BLL.PlatformPublic_payments get_pmen = new Pbzx.BLL.PlatformPublic_payments();
                            get_pmen.payments(Method.Get_UserName.ToString(), Qnum, 3, Convert.ToInt32(ds.Tables[0].Rows[0]["ExpectNum"]), Convert.ToInt32(ds.Tables[0].Rows[0]["playName"]), "参与合买成功冻结资金", Convert.ToDecimal(nBuyMoney.ToString("0.##")), "Chipped");

                            if (colpete(Qnum))
                            {
                                //投注业务参数
                                string prar = get_p.PostBetting(Qnum, nLotNum, 20120626, Convert.ToInt32(ds.Tables[0].Rows[0]["AtotalMoney"]), ds.Tables[0].Rows[0]["ChoiceNum"].ToString(), Convert.ToInt32(ds.Tables[0].Rows[0]["doubles"]), "wwwwwwwww", 2);


                                //返回的字符串
                                string xmlStr = get_p.bett(prar);

                                int code = -1;

                                for (int i = 0; i < xmlStr.Split(',').Length; i++)
                                {
                                    if (xmlStr.Split(',')[i].Split('|')[0] == "xCode")
                                    {
                                        code = Convert.ToInt32(xmlStr.Split(',')[i].Split('|')[1]);
                                        break;
                                    }
                                }
                                if (code == 0)
                                {
                                    return 3;
                                }
                                else
                                {
                                    //销售商返回失败数据
                                    Pbzx.BLL.Chipped_LaunchInfoManage get_lif = new Chipped_LaunchInfoManage();
                                    Pbzx.Model.chipped_LaunchInfo mod_lif = get_lif.GetModel(Qnum);
                                    mod_lif.State = code;
                                    return 1;
                                }
                            }
                            else
                            {
                                return 1;
                            }
                        }
                        else
                        {
                            if (get_info.Delete(Qnum, Method.Get_UserName.ToString()) > 0)
                            {
                                return 0;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //全局错误日志
                        Pbzx.Common.ErrorLog.WriteLog(ex);

                    }
                }
            }
            return 0;
        }
        /// <summary>
        /// 合买购买达成100% 修改发起单标识
        /// </summary>
        /// <param name="Qnum">订单号</param>
        public bool colpete(string Qnum)
        {
            //计算是否全部销售完毕
            publicMethod get_p = new publicMethod();
            string pert = get_p.percent(Qnum);
            if (pert == "100")
            {
                Chipped_LaunchInfoManage get_lim = new Chipped_LaunchInfoManage();
                Pbzx.Model.chipped_LaunchInfo get_modL = new Pbzx.Model.chipped_LaunchInfo();
                try
                {
                    get_modL = get_lim.GetModel(Qnum);
                    //标识为3 方案发起成功  但是没有出票
                    get_modL.State = 3;
                    get_lim.Update(get_modL);
                    return true;
                }
                catch (Exception ex)
                {
                    //全局错误日志
                    Pbzx.Common.ErrorLog.WriteLog(ex);

                }
            }
            return false;

        }



        /// <summary>
        /// 判断用户是否登录
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string username()
        {
            if (Pbzx.Common.Method.Get_UserName.ToString() == "0")
            {
                return "0";
            }
            else
            {
                //判断是否高级用户
                if (Pinble_Chipped.AppCod.WebFunc.CheckIsAdvanceUser(Method.Get_UserName))
                {
                    return Method.Get_UserName.ToString();
                }
                //不是高级用户  返回1
                return "1";
            }
        }

        /// <summary>
        /// 绑定我发布的方案
        /// </summary>
        ///<param name="playName">方法名称</param>
        /// <returns></returns>
        [WebMethod]
        public string BindList(int playName)
        {
            //********我发布的方案********//
            Chipped_LaunchInfoManage get_lim = new Chipped_LaunchInfoManage();
            DataSet ds = get_lim.GetList(10, "UserName=" + "'" + Method.Get_UserName.ToString() + "'" + " and playName=" + "'" + playName + "'", "LaunchTime desc");
            //string state="";
            StringBuilder sbStr = new StringBuilder();
            sbStr.Append("<table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" class=\"rec_table\">");
            sbStr.Append("<colgroup>");
            sbStr.Append("<col width=\"6%\" />");
            sbStr.Append("<col width=\"15%\" />");
            sbStr.Append("<col width=\"15%\" />");
            sbStr.Append("<col width=\"15%\" />");
            sbStr.Append("<col width=\"15%\" />");
            sbStr.Append("<col width=\"15%\" />");
            sbStr.Append("<col width=\"15%\" />");
            sbStr.Append("</colgroup>");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<th>排序</th>");
            sbStr.Append("<th>发起人</th>");
            sbStr.Append("<th>发布时间</th>");
            sbStr.Append("<th>战绩</th>");
            sbStr.Append("<th>方案金额</th>");
            sbStr.Append("<th>方案内容</th>");
            sbStr.Append("<th>操作</th>");
            sbStr.Append("</tr>");
            int RowCount = 1;
            string display = "";
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td>" + RowCount + "</td>");
                sbStr.Append("<td>" + dr[7].ToString() + "</td>");
                sbStr.Append("<td>" + Convert.ToDateTime(dr[3]).ToString("yyyy-MM-dd HH:mm:ss") + "</td>");
                sbStr.Append("<td>*****</td>");
                sbStr.Append("<td>" + dr[18].ToString() + "</td>");
                sbStr.Append("<td><a href=\"javascript:void(0)\" onclick=\"view('" + dr[6].ToString() + "')\">查看</a></td>");
                //在发布后2小时内可以取消

                if (Convert.ToDateTime(dr[3]).Year.ToString() == DateTime.Now.Year.ToString() && Convert.ToDateTime(dr[3]).Month.ToString() == DateTime.Now.Month.ToString() && Convert.ToDateTime(dr[3]).Date.ToString() == DateTime.Now.Date.ToString())
                {
                    if (Convert.ToInt32(DateTime.Now.Hour) - Convert.ToInt32(Convert.ToDateTime(dr[3]).Hour) < 2)
                    {
                        display = "<a href='#'>取消</a>";
                    }
                    else
                    {
                        display = "进行中";
                    }
                }
                sbStr.Append("<td>" + display + "</td>");
                sbStr.Append("</tr>");
                RowCount++;
            }
            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //********我发布的方案********//

            return HttpContext.Current.Server.HtmlEncode(sbStr.ToString());
        }

        /// <summary>
        /// 绑定我参与的方案
        /// <param name="playName">玩法标识</param>
        /// </summary>
        [WebMethod]
        public string BindList_pp(int playName)
        {
            //********我参与的方案********//
            publicMethod get_pub = new publicMethod();
            DataSet ds_pp = get_pub.Chipped_Table("v_participation", "distinct QNumber,UserName,Title,AtotalMoney,Share,ChoiceNum", "ChippedName=" + "'" + Method.Get_UserName.ToString() + "'" + " and playName=" + playName + " group by  QNumber,UserName,Title,AtotalMoney,Share,ChoiceNum");
            StringBuilder str_pp = new StringBuilder();
            str_pp.Append("<table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" class=\"rec_table\">");
            str_pp.Append("<tbody>");
            str_pp.Append("<tr>");
            str_pp.Append("<th>排序</th>");
            str_pp.Append("<th>发起人</th>");
            str_pp.Append("<th>标题</th>");
            str_pp.Append("<th>战绩</th>");
            str_pp.Append("<th>方案金额</th>");
            str_pp.Append("<th>每份金额</th>");
            str_pp.Append("<th>方案内容</th>");
            str_pp.Append("<th>进度</th>");
            str_pp.Append("</tr>");
            int RowCount = 1;
            foreach (DataRow dr in ds_pp.Tables[0].Rows)
            {
                publicMethod pub = new publicMethod();
                string panert = pub.percent(dr[0].ToString());
                str_pp.Append("<tr>");
                str_pp.Append("<td>" + RowCount + "</td>");
                str_pp.Append("<td>" + dr[1].ToString() + "</td>");
                str_pp.Append("<td>" + dr[2].ToString() + "</td>");
                str_pp.Append("<td>*****</td>");
                str_pp.Append("<td>" + dr[3].ToString() + "</td>");
                //计算每份多少钱
                int money = Convert.ToInt32(dr[3]) / Convert.ToInt32(dr[4]);
                str_pp.Append("<td>" + money + "元</td>");
                str_pp.Append("<td><a href=\"javascript:void(0)\" onclick=\"view('" + dr[5].ToString() + "')\" >查看</a></td>");
                str_pp.Append("<td>" + panert + "%</td>");
                str_pp.Append("</tr>");
                RowCount++;
            }
            str_pp.Append("</tbody>");
            str_pp.Append("</table>");
            //********我参与的方案********//
            return HttpContext.Current.Server.HtmlEncode(str_pp.ToString());
        }

        /// <summary>
        /// 我关注的合买方案列表
        /// </summary>
        /// <param name="playName"></param>
        /// <returns></returns>
        [WebMethod]
        public string BindList_Attention(int playName)
        {
            //********我关注的方案********//
            publicMethod get_pub = new publicMethod();
            Pbzx.BLL.Chipped_Attention get_att = new Pbzx.BLL.Chipped_Attention();
            DataSet ds = get_att.GetList("Attention=" + "'" + Method.Get_UserName.ToString() + "'");
            StringBuilder strAtt = new StringBuilder();
            strAtt.Append("<table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" class=\"rec_table\">");
            strAtt.Append("<colgroup>");
            strAtt.Append("<col width=\"6%\" />");
            strAtt.Append("<col width=\"14%\" />");
            strAtt.Append("<col width=\"12%\" />");
            strAtt.Append("<col width=\"12%\" />");
            strAtt.Append("<col width=\"10%\" />");
            strAtt.Append("<col width=\"10%\" />");
            strAtt.Append("<col width=\"8%\" />");
            strAtt.Append("<col width=\"10%\" />");
            strAtt.Append("</colgroup>");
            strAtt.Append("<tbody>");
            strAtt.Append("<tr>");
            strAtt.Append("<th>排序</th>");

            strAtt.Append("<th>发起人</th>");
            strAtt.Append("<th>战绩</th>");
            strAtt.Append("<th>方案金额</th>");
            strAtt.Append("<th> 每份金额</th>");
            //strAtt.Append("<th>方案内容</th>");
            strAtt.Append("<th>进度</th>");
            strAtt.Append("<th>剩余份数</th>");
            strAtt.Append("</tr>");
            int RowCount = 1;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                strAtt.Append("<tr>");
                strAtt.Append("<th>" + RowCount + "</th>");

                strAtt.Append("<th>" + dr[1] + "</th>");
                strAtt.Append("<th>****</th>");
                //查询方案信息
                DataSet get_ds = get_pub.Chipped_Table("Chipped_LaunchInfo", "top 1 *", "UserName=" + "'" + dr[1].ToString() + "'" + " order by LaunchTime desc");
                strAtt.Append("<th>" + Convert.ToDecimal(get_ds.Tables[0].Rows[0]["AtotalMoney"]) + "</th>");
                strAtt.Append("<th>" + Convert.ToDecimal(get_ds.Tables[0].Rows[0]["AtotalMoney"]) / Convert.ToInt32(get_ds.Tables[0].Rows[0]["Share"]) + "</th>");
                //strAtt.Append("<th><a href=\"javascript:void(0)\" onClick=view('" + get_ds.Tables[0].Rows[0]["ChoiceNum"].ToString() + "')>查看</a></th>");
                string panert = get_pub.percent(get_ds.Tables[0].Rows[0]["QNumber"].ToString());
                strAtt.Append("<th>" + panert + "</th>");
                //总共出售的份数
                DataSet dsSta = get_pub.Statistics("QNumber=" + "'" + get_ds.Tables[0].Rows[0]["QNumber"].ToString() + "'");
                int surplus = Convert.ToInt32(get_ds.Tables[0].Rows[0]["Share"]) - Convert.ToInt32(dsSta.Tables[0].Rows[0][0]);
                strAtt.Append("<th>" + surplus.ToString() + "</th>");
                strAtt.Append("</tr>");
                RowCount++;
            }
            strAtt.Append("</tbody>");
            strAtt.Append("</table>");
            //********我关注的方案********//
            return HttpContext.Current.Server.HtmlEncode(strAtt.ToString());
        }

        /// <summary>
        /// 订制跟单
        /// </summary>
        /// <param name="playName">彩种标识</param>
        [WebMethod]
        public string TrackingOrders(int playName)
        {
            publicMethod get_pub = new publicMethod();
            //根据彩种查询订单信息（用于跟单）
            //DataSet ds = get_pub.Chipped_Table("v_Sort", "*","playName=" + playName+" group by AName,playName order by count(*) desc");
            DataSet ds = get_pub.Chipped_Table("Chipped_LaunchInfo", "UserName", "playName=" + playName + " and Purchasing=2 and State=0 group by UserName");
            StringBuilder sb = new StringBuilder();
            sb.Append("<table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" class=\"rec_table\">");
            sb.Append("<colgroup>");
            sb.Append("<col width=\"6%\" />");
            sb.Append("<col width=\"10%\" />");
            sb.Append("<col width=\"12%\" />");
            sb.Append("<col width=\"12%\" />");
            sb.Append("<col width=\"10%\" />");
            sb.Append("<col width=\"10%\" />");
            sb.Append("<col width=\"10%\" />");
            sb.Append("</colgroup>");
            sb.Append("<tbody>");
            sb.Append("<tr>");
            sb.Append("<th>排序</th>");
            sb.Append("<th>用户名</th>");
            sb.Append("<th>战绩</th>");
            sb.Append("<th>累计中奖</th>");
            sb.Append("<th>被关注人次</th>");
            sb.Append("<th>已订制人数</th>");
            sb.Append("<th>订制跟单</th>");
            sb.Append("</tr>");
            int RowCount = 1;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                sb.Append("<tr>");
                sb.Append("<th>" + RowCount + "</th>");
                sb.Append("<th><a href='PersonalPage.aspx?name=" + dr[0].ToString() + "'>" + dr[0].ToString() + "</a></th>");
                sb.Append("<th>******</th>");
                sb.Append("<th>累计中奖</th>");
                DataSet dsnumber = get_pub.Chipped_Table("Chipped_Attention", "count(*)", "AName=" + "'" + dr[0].ToString() + "'");
                sb.Append("<th>" + Convert.ToInt32(dsnumber.Tables[0].Rows[0][0]) + "</th>");
                sb.Append("<th>已订制人数</th>");
                //sb.Append("<th><a href=\"/Tracking.aspx?name=" + Method.Get_UserName.ToString() + "\" onclick=\"login()\">订制</a></th>");
                sb.Append("<th><a href='Tracking.aspx?name=" + dr[0].ToString() + "&playName=" + playName + "'>订制</a></th>");
                sb.Append("</tr>");
                RowCount++;
            }
            sb.Append("</tbody>");
            sb.Append("</table>");
            return HttpContext.Current.Server.HtmlEncode(sb.ToString());
        }

        /// <summary>
        /// 上传号码
        /// </summary>
        /// <param name="path">文件的路径</param>
        private string PicPath(string path)
        {
            string text = "";
            string fileName = path;
            string fname = fileName;
            string extraName = fileName.Substring(fileName.LastIndexOf(".") + 1);

            //上传txt文件
            if (extraName.ToLower() == "txt")
            {

                StreamReader rd = new StreamReader(fileName, Encoding.Default);
                System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("\\d+(?:,\\d+)+");
                System.Text.RegularExpressions.Regex reg1 = new System.Text.RegularExpressions.Regex("\\d+(?: \\d+)+");
                //读取到流的末尾
                while (!rd.EndOfStream)
                {
                    string lineText = rd.ReadLine().ToString();

                    if (lineText == "" || lineText == null)
                    {
                        //Response.Write("<script>alert('文本的数据错误，请检查')</script>");
                        return "error";
                        //停止程序
                    }
                    else
                    {
                        //if (lineText.Split('|').Length != 2)
                        //{
                        //    //Response.Write("<script>alert('文件格式错误，请检查')</script>");
                        //    return "error";
                        //    //停止程序
                        //}
                        //else
                        //{
                        //    if (!reg.IsMatch(lineText.Split('|')[0].ToString()) && !reg.IsMatch(lineText.Split('|')[1].ToString()))
                        //    {
                        //        //Response.Write("<script>alert('文件中的数据错误，请检查')</script>");
                        //        return "error";
                        //    }
                        //    //判断红球号码
                        //    for (int i = 0; i < lineText.Split('|')[0].Split(',').Length; i++)
                        //    {
                        //        //验证传入的数据是否正确
                        //        if (Convert.ToInt32(lineText.Split('|')[0].Split(',')[i]) <= 0 || Convert.ToInt32(lineText.Split('|')[0].Split(',')[i]) > 33 && lineText.Split('|')[0].Split(',')[i].Length != 2)
                        //        {
                        //            //Response.Write("<script>alert('文件中的号码有错误，请检查')</script>");
                        //            return "error";
                        //        }
                        //    }
                        //    //判断蓝球号码
                        //    for (int j = 0; j < lineText.Split('|')[1].Split(',').Length; j++)
                        //    {
                        //        if (Convert.ToInt32(lineText.Split('|')[1].Split(',')[j]) <= 0 || Convert.ToInt32(lineText.Split('|')[1].Split(',')[j]) > 16)
                        //        {
                        //            //Response.Write("<script>alert('文件中的号码有错误，请检查')</script>");
                        //            return "error";
                        //        }
                        //    }
                        //}
                        //判断红篮球 已"|"隔开
                        if (lineText.Split('|').Length == 2)
                        {
                            if (reg.IsMatch(lineText.Split('|')[0].ToString()) && reg.IsMatch(lineText.Split('|')[1].ToString()))
                            {
                                //判断红球号码
                                for (int i = 0; i < lineText.Split('|')[0].Split(',').Length; i++)
                                {
                                    //验证传入的数据是否正确
                                    if (Convert.ToInt32(lineText.Split('|')[0].Split(',')[i]) <= 0 || Convert.ToInt32(lineText.Split('|')[0].Split(',')[i]) > 33 && lineText.Split('|')[0].Split(',')[i].Length != 2)
                                    {
                                        return "error";
                                    }
                                }
                                //判断蓝球号码
                                for (int j = 0; j < lineText.Split('|')[1].Split(',').Length; j++)
                                {
                                    if (Convert.ToInt32(lineText.Split('|')[1].Split(',')[j]) <= 0 || Convert.ToInt32(lineText.Split('|')[1].Split(',')[j]) > 16)
                                    {
                                        return "error";
                                    }
                                }
                            }
                            else if (reg1.IsMatch(lineText.Split('|')[0].ToString()) && reg1.IsMatch(lineText.Split('|')[1].ToString()))
                            {
                                //判断红球号码
                                for (int i = 0; i < lineText.Split('|')[0].Split(' ').Length; i++)
                                {
                                    //验证传入的数据是否正确
                                    if (Convert.ToInt32(lineText.Split('|')[0].Split(' ')[i]) <= 0 || Convert.ToInt32(lineText.Split('|')[0].Split(' ')[i]) > 33 && lineText.Split('|')[0].Split(' ')[i].Length != 2)
                                    {
                                        return "error";
                                    }
                                }
                                //判断蓝球号码
                                for (int j = 0; j < lineText.Split('|')[1].Split(' ').Length; j++)
                                {
                                    if (Convert.ToInt32(lineText.Split('|')[1].Split(' ')[j]) <= 0 || Convert.ToInt32(lineText.Split('|')[1].Split(' ')[j]) > 16)
                                    {
                                        return "error";
                                    }
                                }
                            }
                            else
                            {
                                return "error";
                            }

                        }//红蓝球以"+"隔开
                        else if (lineText.Split('+').Length == 2)
                        {

                        }
                        else
                        {
                            return "error";
                        }

                        text += lineText + "<br/>";
                    }
                }
                return text.ToString();
            }
            else
            {
                return "";
                //Response.Write("<script>alert('只支持.txt');</script>");
                //Response.Write("<script>history.go(-2);</script>");

            }
        }

        /// <summary>
        /// 获取一个合买代购的流水号
        /// </summary>
        /// <param name="ExpectNum">期号</param>
        /// <param name="playName">彩种标识</param>
        /// <returns></returns>
        [WebMethod]
        public string isomux(int ExpectNum, int playName)
        {
            //3D
            if (playName == 1)
            {
                return Method.CreateQNumber("fcsd",true);
            }
            //七乐彩
            if (playName == 2)
            {
                return Method.CreateQNumber("fcqlc", true);
            }
            //双色球
            if (playName == 3)
            {
                return Method.CreateQNumber("fcssq", true);
            }
            //大乐透
            if (playName == 6)
            {
                return Method.CreateQNumber("tcdlt", true);
            }
            //排列3
            if (playName == 9999)
            {
                return Method.CreateQNumber("tcpls", true);
            }
            //排列5
            if (playName == 4)
            {
                return Method.CreateQNumber("tcplw", true);
            }
            //七星彩
            if (playName == 5)
            {
                return Method.CreateQNumber("tcqxc", true);
            }
            return "0";

        }

        /// <summary>
        /// 添加关注
        /// </summary>
        /// <param name="AName">被关注的人</param>
        /// <returns></returns>
        [WebMethod]
        public int Attention(string AName)
        {
            Pbzx.BLL.publicMethod get_pbmod = new publicMethod();
            int count = get_pbmod.Attention(AName, Method.Get_UserName.ToString());
            if (count == 1)
            {
                return 1;
            }
            return 0;
        }

        /// <summary>
        /// 订制跟单的期号生成
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="num">跟单期号</param>
        /// <param name="playName">玩法标识</param>
        /// <returns></returns>
        [WebMethod]
        public string TrackingExc(string name, int num, int playName)
        {
            Pbzx.BLL.publicMethod get_pbmod = new publicMethod();
            //根据用户名查询他发布的最新的
            DataSet ds = get_pbmod.Chipped_Table("Chipped_LaunchInfo", "top 1 ExpectNum", "playName=" + playName + " and UserName=" + "'" + name + "'" + " order by LaunchTime desc");
            StringBuilder Tstr = new StringBuilder();
            // 循环生成期号
            Tstr.Append("<table width=\"90%\" border=\"0\">");
            Tstr.Append("<tr>");
            //循环有几行
            for (int i = 1; i < num + 1; i++)
            {

                if (i == 1)
                {
                    Tstr.Append("<td style=\"color: #FF0000\">");
                    Tstr.Append("1、<input type=\"checkbox\" name=\"ENum\" value='" + Convert.ToInt32(ds.Tables[0].Rows[0][0]) + "' checked=\"CHECKED\"  />" + Convert.ToInt32(ds.Tables[0].Rows[0][0]) + " 期 " + "</td>");
                }
                else
                {
                    Tstr.Append("<td>");
                    int ExpectNum = Convert.ToInt32(ds.Tables[0].Rows[0][0]) + i - 1;
                    Tstr.Append(i);
                    Tstr.Append("、<input type=\"checkbox\" name=\"ENum\" value='" + ExpectNum + "' checked=\"CHECKED\"  />" + ExpectNum + " 期 " + "</td>");
                    if (i % 3 == 0)
                    {
                        Tstr.Append("</tr><tr>");
                    }
                }


            }
            Tstr.Append("</tr>");
            Tstr.Append("</table>");

            return HttpContext.Current.Server.HtmlEncode(Tstr.ToString());
        }
        /// <summary>
        /// 添加跟单信息
        /// </summary>
        /// <param name="UserName">发单人的用户名</param>
        /// <param name="playName">彩种标识</param>
        /// <param name="num">定制次数</param>
        /// <param name="money">认购金额</param>
        /// <returns></returns>
        [WebMethod]
        public int AddTracking(string UserName, int playName, int num, string money)
        {
            //判断是否已经对此用户添加跟单信息
            Pbzx.BLL.Chipped_TrackingOrders get_TO = new Pbzx.BLL.Chipped_TrackingOrders();
            Pbzx.Model.Chipped_TrackingOrders Mod_TO = new Pbzx.Model.Chipped_TrackingOrders();
            //最多可跟1000单
            Pbzx.BLL.publicMethod get_pd = new publicMethod();
            DataSet ds_num = get_pd.Chipped_Table("Chipped_TrackingOrders", "count(*)", "UserN=" + "'" + UserName + "'" + " and TrackingLNum=" + playName);
            if (Convert.ToInt32(ds_num.Tables[0].Rows[0][0]) > 1000)
            {
                return 2;
            }
            else
            {
                DataSet ds = get_TO.GetList("UserN=" + "'" + UserName + "'" + " and TrackingLNum=" + playName + " and TrackingName=" + "'" + Method.Get_UserName.ToString() + "'");
                //已经有跟单信息
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    //(已经有跟单信息)  进行中： 不允许跟单      已完成：修改跟单信息
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["TrackingState"]) == 0)
                    {
                        //有跟单信息 不允许跟单
                        return 0;
                    }
                    else
                    {
                        Mod_TO.UserN = UserName;
                        Mod_TO.TrackingLNum = playName;
                        Mod_TO.TrackingName = Method.Get_UserName.ToString();
                        Mod_TO.SubscribeNum = num;
                        Mod_TO.BuyMoney = Convert.ToDecimal(money);
                        Mod_TO.TrackingState = 0;
                        Mod_TO.TrackingTime = DateTime.Now;
                        Mod_TO.TrackingN = 0;
                        if (get_TO.Update(Mod_TO))
                        {
                            return 1;
                        }
                    }
                }
                else
                {
                    Mod_TO.UserN = UserName;
                    Mod_TO.TrackingLNum = playName;
                    Mod_TO.TrackingName = Method.Get_UserName.ToString();
                    Mod_TO.SubscribeNum = num;
                    Mod_TO.BuyMoney = Convert.ToDecimal(money);
                    Mod_TO.TrackingState = 0;
                    Mod_TO.TrackingTime = DateTime.Now;
                    if (get_TO.Add(Mod_TO) > 0)
                    {
                        return 1;
                    }
                }
            }
            return 0;
        }

        /// <summary>
        /// 订制跟单的期号生成
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="num">跟单期号</param>
        /// <param name="playName">玩法标识</param>
        /// <returns></returns>
        [WebMethod]
        public string teackNum(string name, int num, int playName)
        {
            Pbzx.BLL.publicMethod get_pbmod = new publicMethod();
            //根据用户名查询他发布的最新的
            DataSet ds = get_pbmod.Chipped_Table("Chipped_LaunchInfo", "top 1 ExpectNum", "playName=" + playName + " and UserName=" + "'" + name + "'" + " order by LaunchTime desc");
            StringBuilder Tstr = new StringBuilder();
            // 循环生成期号
            Tstr.Append("<table width=\"90%\" border=\"0\">");
            Tstr.Append("<tr>");
            //循环有几行
            for (int i = 1; i < num + 1; i++)
            {

                if (i == 1)
                {
                    Tstr.Append("<td style=\"color: #FF0000\">");
                    Tstr.Append("1、<input type=\"checkbox\" name=\"ENum\" value='" + Convert.ToInt32(ds.Tables[0].Rows[0][0]) + "' checked=\"CHECKED\"  />" + Convert.ToInt32(ds.Tables[0].Rows[0][0]) + " 期 " + "</td>");
                }
                else
                {
                    Tstr.Append("<td>");
                    int ExpectNum = Convert.ToInt32(ds.Tables[0].Rows[0][0]) + i - 1;
                    Tstr.Append(i);
                    Tstr.Append("、<input type=\"checkbox\" name=\"ENum\" value='" + ExpectNum + "' checked=\"CHECKED\"  />" + ExpectNum + " 期 " + "</td>");
                    if (i % 3 == 0)
                    {
                        Tstr.Append("</tr><tr>");
                    }
                }


            }
            Tstr.Append("</tr>");
            Tstr.Append("</table>");

            return HttpContext.Current.Server.HtmlEncode(Tstr.ToString());
        }






        /// <summary>
        /// 检查是已经截止发布
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public int Allow(string playName)
        {
            string dt = "";
            //3D
            if (playName == "1")
            {
                dt = Pbzx.Common.Method.GetFCDateTime.ToString();
            }
            //七乐彩
            if (playName == "2")
            {
                dt = Pbzx.Common.Method.GetFC7LCDateTime.ToString();
            }
            //双色球
            if (playName == "3")
            {
                dt = Pbzx.Common.Method.GetSSQDateTime.ToString();
            }
            //排列三五
            if (playName == "4" || playName == "9999")
            {
                dt = Pbzx.Common.Method.GetTCPL35DateTime.ToString();
            }
            //七星彩
            if (playName == "5")
            {
                dt = Pbzx.Common.Method.GetTC7XCDateTime.ToString();
            }
            //大乐透
            if (playName == "6")
            {
                dt = Pbzx.Common.Method.GetTCDLTDateTime.ToString();
            }
            //22选5
            if (playName == "7")
            {
                dt = Pbzx.Common.Method.GetTC22X5DateTime.ToString();
            }
            //31选7
            if (playName == "8")
            {
                dt = Pbzx.Common.Method.GetTC31X7DateTime.ToString();
            }

            if (dt == "")
            {
                return 0;
            }
            //当前时间已经超出发布时间
            if (DateTime.Compare(DateTime.Now, Convert.ToDateTime(dt)) > 0)
            {
                return 1;
            }
            return 0;
        }

        /// <summary>
        /// 绑定主页排行
        /// </summary>
        /// <param name="LName">彩种名称</param>
        /// <returns></returns>
        [WebMethod]
        public string HRanking(string LName)
        {
            Pbzx.BLL.PlatformPublic_UserWinning get_uw = new Pbzx.BLL.PlatformPublic_UserWinning();
            DataSet ds = get_uw.GetList("select top 10  from PlatformPublic_UserWinning order by u_Monery desc ");
            StringBuilder sbstr = new StringBuilder();
            sbstr.Append("<table width='100%' border='0' class='tabled'>");
            sbstr.Append("<colgroup>");
            sbstr.Append("<col width='60%' />");
            sbstr.Append("<col width='40%' />");
            sbstr.Append("</colgroup>");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                sbstr.Append("<tr>");
                sbstr.Append("<td>" + dr[1].ToString());
                sbstr.Append("</td>");
                sbstr.Append("<td>" + dr[4].ToString());
                sbstr.Append("</td>");
                sbstr.Append("</tr>");
            }
            sbstr.Append("<table>");

            return HttpContext.Current.Server.HtmlEncode(sbstr.ToString());
        }
        /// <summary>
        /// 添加多期机选信息
        /// </summary>
        /// <param name="note">注数</param>
        /// <param name="multiple">倍数</param>
        /// <param name="tmtion">中止条件（1-100000000）</param>
        /// <param name="mess">是否发出短信</param>
        /// <param name="playState">彩种标识</param>
        /// <returns></returns>
        [WebMethod]
        public int RandomNum(int note, int multiple, int tmtion, int mess, int playState)
        {
            Pbzx.Model.Chipped_RandomNum get_mod = new Pbzx.Model.Chipped_RandomNum();
            Pbzx.BLL.Chipped_RandomNum get_rn = new Pbzx.BLL.Chipped_RandomNum();
            //用户定制是否完成
            DataSet ds = get_rn.GetList("Rn_name=" + "'" + Method.Get_UserName + "'");
            if (ds == null || ds.Tables[0].Rows.Count == 0 || Convert.ToInt32(ds.Tables[0].Rows[0]["Rn_state"]) == 1)
            {
                //无数据 或是已经截止完成 //允许发布
                get_mod.Rn_name = Method.Get_UserName.ToString();
                get_mod.Rn_note = note;
                get_mod.Rn_multiple = multiple;
                get_mod.Rn_tmtion = Convert.ToDecimal(tmtion);
                get_mod.Rn_mess = mess;
                get_mod.Rn_play = playState;
                get_mod.Rn_state = 0;
                get_mod.Rn_time = DateTime.Now;
                get_mod.Rn_num = Method.CreateQNumber("dqjx", true);
                if (get_rn.Add(get_mod) > 0)
                {
                    //添加成功( 返回id)
                    DataSet dsID = get_rn.GetList("Rn_name=" + "'" + Method.Get_UserName + "' order by Rn_id desc");
                    //返回新生成ID
                    return Convert.ToInt32(dsID.Tables[0].Rows[0]["Rn_id"]);
                }
            }
            return 0;
        }

        /// <summary>
        /// 添加多期机选期号
        /// </summary>
        /// <param name="RdID">多期机选表ID</param>
        /// <param name="issue">期号</param>
        /// <param name="multiple">倍数</param>
        /// <param name="money">金额</param>
        /// <returns></returns>
        [WebMethod]
        public string issueNum(int RdID, string issue, string multiple, string money)
        {

            Pbzx.Model.Chipped_issueN get_modIN = new Pbzx.Model.Chipped_issueN();
            Pbzx.BLL.Chipped_issueN get_In = new Pbzx.BLL.Chipped_issueN();
            string nInid = "";
            for (int i = 0; i < issue.Split('|').Length; i++)
            {
                string nOrderNum = Pbzx.Common.Method.CreateQNumber("dq", true);
                if (get_In.Exists(nOrderNum))
                {
                    nOrderNum = Pbzx.Common.Method.CreateQNumber("dq", true);

                }
                get_modIN.In_RnId = RdID;
                get_modIN.In_num = nOrderNum;
                get_modIN.In_mark = 0;
                get_modIN.In_issue = issue.Split('|')[i];
                get_modIN.In_multiple = Convert.ToInt32(multiple.Split('|')[i]);
                get_modIN.In_money = Convert.ToDecimal(money.Split('|')[i]);

                try
                {
                    if (get_In.Add(get_modIN) > 0)
                    {
                        DataSet ds_in = get_In.GetList("In_RnId=" + RdID + " and In_issue=" + issue.Split('|')[i]);
                        nInid += Convert.ToInt32(ds_in.Tables[0].Rows[0]["In_id"]) + "|";
                    }
                    else
                    {
                        if (get_In.Delete(RdID))
                        {
                            return "0";
                        }
                    }
                }
                catch { }

            }
            return nInid.Substring(0, nInid.Length - 1);
        }

        /// <summary>
        /// 多期机选出投注
        /// </summary>
        /// <param name="issue">当前期号</param>
        /// <param name="playName">彩种标识</param>
        /// <returns></returns>
        [WebMethod]
        public int issueDrawer(string issue,int playName)
        {
            Pbzx.BLL.publicMethod pubMod = new publicMethod();
            Pbzx.BLL.Chipped_issueN get_n = new Pbzx.BLL.Chipped_issueN();
            Pbzx.BLL.Chipped_Num get_num=new Pbzx.BLL.Chipped_Num();
            //代理商彩种编号
            int nLotNum = pubMod.LotContrast(playName);
            DataSet dsTab = pubMod.Chipped_Table("PBnet_UserTable", "Id,CurrentMoney,FrozenMoney", "UserName=" + "'" + Method.Get_UserName.ToString() + "'");
            Pbzx.BLL.PBnet_UserTable get_userTab = new Pbzx.BLL.PBnet_UserTable();
            Pbzx.Model.PBnet_UserTable modUserTab = get_userTab.GetModel(Convert.ToInt32(dsTab.Tables[0].Rows[0]["Id"]));


            //查询当前期正常的没有出票是的数据
            DataSet ds = get_n.GetListView("Rn_play=" + playName + " and In_issue=" + "'" + issue + "'" + " and Rn_state=0 and In_mark=0 and Rn_name="+"'"+ Method.Get_UserName.ToString() +"'");
            decimal buyMoney = Convert.ToDecimal(ds.Tables[0].Rows[0]["In_money"]) * Convert.ToInt32(ds.Tables[0].Rows[0]["In_multiple"]);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                //查询投注号码
                DataSet dsNum = get_num.GetList("N_InId=" + Convert.ToInt32(ds.Tables[0].Rows[0]["In_id"]));

                //投注业务参数
                string prar = pubMod.PostBetting(ds.Tables[0].Rows[0]["In_num"].ToString(), nLotNum, 20120626, Convert.ToInt32(ds.Tables[0].Rows[0]["In_money"]), dsNum.Tables[0].Rows[0]["N_num"].ToString(),Convert.ToInt32(ds.Tables[0].Rows[0]["In_multiple"]), "wwwwwwwww", 2);

                //返回的字符串
                string xmlStr = pubMod.bett(prar);
                int code = -1;

                for (int i = 0; i < xmlStr.Split(',').Length; i++)
                {
                    if (xmlStr.Split(',')[i].Split('|')[0] == "xCode")
                    {
                        code = Convert.ToInt32(xmlStr.Split(',')[i].Split('|')[1]);
                        break;
                    }
                }
                if (code == 0)
                {
                    //投注成功 (投注成功，冻结资金， 可能有出票失败)
                    modUserTab.FrozenMoney = modUserTab.FrozenMoney + Convert.ToDecimal(buyMoney);
                    //修改账户金额
                    if (get_userTab.Update(modUserTab))
                    {
                        //个人收支账户记录
                        Pbzx.BLL.PlatformPublic_payments get_pmen = new Pbzx.BLL.PlatformPublic_payments();
                        get_pmen.payments(Method.Get_UserName.ToString(), ds.Tables[0].Rows[0]["In_num"].ToString(), 3, Convert.ToInt32(ds.Tables[0].Rows[0]["In_issue"]), Convert.ToInt32(ds.Tables[0].Rows[0]["Rn_play"]), "多期机选订单" + ds.Tables[0].Rows[0]["In_num"].ToString() + "扣除投注资金", Convert.ToDecimal(buyMoney), "Chipped");
                        return 1;
                    }
                }
            }
            else
            {
                //没有数据 不做处理
                return 0;
            }
            return 0;
        }

        /// <summary>
        /// 处理期号对应随机号码添加
        /// </summary>
        /// <param name="issueId">返回的期号对应的id</param>
        /// <param name="playName">彩种标识</param>
        /// <param name="num">每期要生成的注数</param>
        /// <param name="money">当前期金额</param>
        /// <param name="expectnum">当前期号</param>
        /// <returns></returns>
        [WebMethod]
        public int HandleIssue(string issueId, int playName, int num, decimal money, int expectnum, int RdID)
        {
            Pbzx.BLL.publicMethod get_pm=new publicMethod();
            int state = 0;
            if (issueId != null && issueId != "")
            {
                if (issueId.Substring(issueId.Length - 1) == "|")
                {
                    issueId = issueId.Substring(0, issueId.Length - 1);
                }
                for (int i = 0; i < issueId.Split('|').Length; i++)
                {
                    string radoNum = string.Empty;
                    radoNum = Random(playName, num, true);
                    try
                    {
                        Pbzx.BLL.Chipped_issueN cp = new Pbzx.BLL.Chipped_issueN();
                        string Isnumber = cp.GetModel(Convert.ToInt32(issueId.Split('|')[i])).In_issue;
                        if (addNum(Convert.ToInt32(issueId.Split('|')[i]), radoNum, RdID) > 0 && Convert.ToInt32(Isnumber) == expectnum)
                        {
                            //FrozenMoney(money, expectnum, playName, RdID);

                            int n_Drawer = issueDrawer(expectnum.ToString(), playName);
                            if (n_Drawer == 1)
                            {
                                state = 3;
                            }
                        }
                        else
                        {

                            int n_s = addNum(Convert.ToInt32(issueId.Split('|')[i]), radoNum, RdID);
                            if (n_s == 0)
                            {
                                state = 0;
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        //全局错误日志
                        Pbzx.Common.ErrorLog.WriteLog(ex);
                    }

                }
            }
            return state;

        }
        /// <summary>
        /// 删除多期信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [WebMethod]
        public void deleteData(int id)
        {
            //添加失败后 删除多期数据
            Pbzx.BLL.Chipped_Num get_num = new Pbzx.BLL.Chipped_Num();
            Pbzx.BLL.Chipped_RandomNum get_rn = new Pbzx.BLL.Chipped_RandomNum();
            Pbzx.BLL.Chipped_issueN get_is = new Pbzx.BLL.Chipped_issueN();
            if (get_num.DeleteRn(id))
            {
                if (get_is.DeleteRn(id))
                {
                    if (get_rn.Delete(id))
                    {
                        //删除成功
                    }
                }
            }
        }

        /// <summary>
        /// 冻结当前期购买金额 （修改用户账户金额）
        /// </summary>
        /// <param name="money">金额</param>
        [WebMethod]
        public int FrozenMoney(decimal money, int expectnum, int playName, int RdID)
        {
            //查询用户帐户的余额是否能支付购买
            publicMethod pubMod = new publicMethod();
            DataSet ds = pubMod.Chipped_Table("PBnet_UserTable", "Id,CurrentMoney,FrozenMoney", "UserName=" + "'" + Method.Get_UserName + "'");
            Pbzx.BLL.PBnet_UserTable get_user = new Pbzx.BLL.PBnet_UserTable();
            Pbzx.Model.PBnet_UserTable get_moduser = get_user.GetModelName(Method.Get_UserName);
            get_moduser.FrozenMoney = Convert.ToDecimal(ds.Tables[0].Rows[0]["FrozenMoney"]) + money;
            if (get_user.Update(get_moduser))
            {
                //个人收支账户记录
                Pbzx.BLL.PlatformPublic_payments get_pmen = new Pbzx.BLL.PlatformPublic_payments();

                if (RdID > 0)
                {
                    Pbzx.BLL.Chipped_RandomNum get_rn = new Pbzx.BLL.Chipped_RandomNum();
                    Pbzx.Model.Chipped_RandomNum model = get_rn.GetModel(RdID);
                    if (model != null)
                    {
                        get_pmen.payments(Method.Get_UserName, model.Rn_num, 3, expectnum, playName, "多期机选支付冻结资金", money, "Chipped");
                    }
                }
                return 1;
            }
            return 0;
        }

        #region   生成随机号码
        /// <summary>
        /// 生成随机号码
        /// </summary>
        /// <param name="playName">彩种标识</param>
        /// <param name="note">生成几注</param>
        /// <returns></returns>
        [WebMethod]
        public string Random(int playName, int note, bool Sleep)
        {
            if (Sleep)
                System.Threading.Thread.Sleep(1);
            Random rad = new Random(DateTime.Now.Millisecond);
            //声明数组
            ArrayList listArr = new ArrayList();
            //号码串数组
            string ball = string.Empty;
            if (playName == 3)
            {
                for (int i = 0; i < note; i++)
                {
                    listArr.Clear();

                    while (true)
                    {
                        if (listArr.Count >= 6)
                        {
                            break;
                        }
                        int temp = rad.Next(1, 33);
                        if (!listArr.Contains(temp))
                        {
                            listArr.Add(temp);
                        }
                    }
                    listArr.Sort();

                    //对红球进行冒泡排序
                    string redBall = string.Empty;
                    //组合号码
                    for (int j = 0; j < listArr.Count; j++)
                    {

                        redBall += int.Parse(listArr[j].ToString()).ToString("00") + ",";
                    }
                    //组合后的一注号码
                    ball += redBall.TrimEnd(',') + "-" + rad.Next(1, 16).ToString("00") + "|";

                }
                return ball.TrimEnd('|');

            }
            if (playName == 6)
            {
                //大乐透
                for (int i = 0; i < note; i++)
                {
                    listArr.Clear();

                    while (true)
                    {
                        if (listArr.Count >= 5)
                        {
                            break;
                        }
                        int temp = rad.Next(1, 35);
                        if (!listArr.Contains(temp))
                        {
                            listArr.Add(temp);
                        }
                    }
                    listArr.Sort();

                    //对前区进行冒泡排序
                    string redBall = string.Empty;
                    //组合号码
                    for (int j = 0; j < listArr.Count; j++)
                    {

                        redBall += int.Parse(listArr[j].ToString()).ToString("00") + ",";
                    }
                    string buleBall = string.Empty;
                    int temp1 = 0;
                    int temp2 = 0;
                    while (true)
                    {
                        temp1 = rad.Next(1, 12);
                        temp2 = rad.Next(1, 12);
                        if (temp1 != temp2)
                        {
                            break;
                        }

                    }
                    if (temp1 < temp2)
                    {
                        buleBall = number(temp1) + "," + number(temp2);
                    }
                    else
                    {
                        buleBall = number(temp2) + "," + number(temp1);
                    }
                    //组合后的一注号码
                    ball += redBall.TrimEnd(',') + "-" + buleBall + "|";

                }
                return ball.TrimEnd('|');
            }
            if (playName == 2)
            {
                //七乐彩
                for (int i = 0; i < note; i++)
                {
                    listArr.Clear();

                    while (true)
                    {
                        if (listArr.Count >= 7)
                        {
                            break;
                        }
                        int temp = rad.Next(1, 30);
                        if (!listArr.Contains(temp))
                        {
                            listArr.Add(temp);
                        }
                    }
                    listArr.Sort();

                    //对红球进行冒泡排序
                    string redBall = string.Empty;
                    //组合号码
                    for (int j = 0; j < listArr.Count; j++)
                    {

                        redBall += int.Parse(listArr[j].ToString()).ToString("00") + ",";
                    }
                    //组合后的一注号码
                    ball += redBall.TrimEnd(',') + "|";

                }
                return ball.TrimEnd('|');
            }
            return "";
        }

        #endregion

        /// <summary>
        /// 添加所生成的机选号码
        /// </summary>
        /// <param name="issNID">期号对应的iD</param>
        /// <param name="num">号码串</param>
        /// <returns></returns>
        private int addNum(int issNID, string num,int Rnid)
        {
            Pbzx.Model.Chipped_Num get_modnum = new Pbzx.Model.Chipped_Num();
            Pbzx.BLL.Chipped_Num get_num = new Pbzx.BLL.Chipped_Num();
            get_modnum.N_InId = issNID;
            get_modnum.N_num = num;
            get_modnum.N_RnId = Rnid;
            if (get_num.Add(get_modnum) > 0)
            {
                return 1;
            }

            return 0;
        }

        /// <summary>
        /// 组合号码
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private string number(int num)
        {
            if (num < 10)
            {
                return "0" + num.ToString();
            }
            return num.ToString();
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
        /// 生成连续期号
        /// </summary>
        /// <param name="preid">当前期</param>
        /// <param name="num">生成几期</param>
        /// <param name="mod">模块</param>
        /// <returns></returns>
        [WebMethod]
        public string GeneratingSeries(int preid, int num, string Lottory, string mod, string endtime)
        {

            string hms = "20:00";
            if (Lottory == "TCDLTData")
            {
                hms = "20:10";
            }
            else if (Lottory == "")
            {

            }
            StringBuilder Tstr = new StringBuilder();
            // 循环生成期号
            Tstr.Append("<table width=\"100%\" border=\"0\">");
            Tstr.Append("<tr>");
            //循环有几行
            string dttime = null;
            for (int i = 1; i < num + 1; i++)
            {
                int issue = preid + 1;
                //得到下一期开奖时间
                string dttimes = Pbzx.Common.Method.GetLotoryTime(dttime, Lottory);

                //判断跨年
                if (dttime != null)
                {
                    if (Convert.ToDateTime(dttime).Year < Convert.ToDateTime(dttimes).Year)
                    {
                        issue = Convert.ToInt32(Convert.ToDateTime(dttime).Year + 1 + "001");
                    }
                }

                if (i == 1)
                {

                    Tstr.Append("<td style=\"color: #FF0000\">");

                    if (Convert.ToDateTime(endtime) > DateTime.Now)
                    {
                        Tstr.Append("01、<input type=\"checkbox\" id=\"check_" + mod + "_" + i + "\" name=\"ENum\" value='" + preid + "' checked=\"CHECKED\"  /><span id=\"exp_" + mod + "_" + i + "\">" + preid + " </span>期 " + "<input type=\"text\" id=\"txt_" + mod + "_1\" style=\"width:30px\" maxlength=\"3\" value=\"1\" onkeyup=\"this.value=this.value.replace(/[^\\d]/g,'');dataChage(this.id," + i + ")\" />倍&nbsp￥<span id=\"money_" + mod + "_" + i + "\">0</span>元" + "</td>");
                        Tstr.Append("<td style=\"color: #FF0000\">[当前期]</td>");
                    }
                    else
                    {
                        Tstr.Append("01、<input type=\"checkbox\" id=\"check_" + mod + "_" + i + "\" name=\"ENum\" value='" + preid + "' disabled=\"disabled\" /><span id=\"exp_" + mod + "_" + i + "\">" + preid + " </span>期 " + "<input type=\"text\" id=\"txt_" + mod + "_1\"  disabled=\"disabled\" style=\"width:30px\" maxlength=\"3\" value=\"0\" onkeyup=\"this.value=this.value.replace(/[^\\d]/g,'');dataChage(this.id," + i + ")\" />倍&nbsp￥<span id=\"money_" + mod + "_" + i + "\">0</span>元" + "</td>");
                        Tstr.Append("<td style=\"color: #FF0000\">[已截止]</td>");  
                    }
                  
                }
                else
                {
                    preid = issue;
                    Tstr.Append("<td>");

                    if (i < 10)
                    {

                        Tstr.Append("0" + i);
                    }
                    else
                    {
                        Tstr.Append(i);
                    }
                    Tstr.Append("、<input type=\"checkbox\" id=\"check_" + mod + "_" + i + "\" name=\"ENum\" value='" + issue + "' checked=\"CHECKED\"  /><span id=\"exp_" + mod + "_" + i + "\">" + issue + " </span>期 " + "<input type=\"text\" id=\"txt_" + mod + "_" + i + "\" style=\"width:30px\" maxlength=\"3\" value=\"1\" onkeyup=\"this.value=this.value.replace(/[^\\d]/g,'');dataChage(this.id," + i + ")\" />倍&nbsp￥<span id=\"money_" + mod + "_" + i + "\">0</span>元" + "</td>");


                    Tstr.Append("<td>" + dttimes + " " + hms + "</td>");
                    dttime = dttimes;
                    if (i % 2 == 0)
                    {
                        Tstr.Append("</tr><tr>");
                    }
                }

            }
            Tstr.Append("</tr>");
            Tstr.Append("</table>");
            return HttpContext.Current.Server.HtmlEncode(Tstr.ToString());
        }

        /// <summary>
        /// 查看用户账户余额是否充足
        /// </summary>
        /// <param name="money">金额</param>
        /// <returns></returns>
        [WebMethod]
        public int userMoneyInsufficient(decimal money)
        {
            Pbzx.BLL.PBnet_UserTable get_ut = new Pbzx.BLL.PBnet_UserTable();
            DataSet ds_ut = get_ut.GetList("UserName=" + "'" + Method.Get_UserName + "'");
            if (ds_ut != null && ds_ut.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToDecimal(ds_ut.Tables[0].Rows[0]["CurrentMoney"]) > money)
                {
                    return 1;
                }
            }
            return 0;
        }
        /// <summary>
        /// 添加追号信息
        /// </summary>
        /// <param name="SerialNum">订单流水号</param>
        /// <param name="username">用户名 </param>
        /// <param name="playName">彩种编号，对应彩种表</param>
        /// <param name="stopCondition">停止追号的条件</param>
        /// <param name="issue">期号串</param>
        /// <param name="num">选择的号码</param>
        /// <param name="multiple">投注倍数</param>
        /// <param name="money">所花金额</param>
        /// <param name="message">是否要短信提醒</param>
        /// <param name="time">添加时间</param>
        /// <param name="CurrentIssue">当前期号</param>
        /// <returns></returns>
        [WebMethod]
        public int trackNum(string SerialNum, string username, int playName, string stopCondition, string issue, string num, string multiple, string money, int message, string CurrentIssue)
        {
            Pbzx.BLL.publicMethod get_pub = new publicMethod();
            Pbzx.BLL.Chipped_TrackNum get_tn = new Pbzx.BLL.Chipped_TrackNum();
            Pbzx.Model.Chipped_TrackNum mod_tn = new Pbzx.Model.Chipped_TrackNum();

            DataSet ds_user = get_pub.Chipped_Table("PBnet_UserTable", "Id,CurrentMoney,FrozenMoney", "UserName=" + "'" + username + "'");
            Pbzx.BLL.PBnet_UserTable get_userTab = new Pbzx.BLL.PBnet_UserTable();
            Pbzx.Model.PBnet_UserTable modUserTab = get_userTab.GetModel(Convert.ToInt32(ds_user.Tables[0].Rows[0]["Id"]));

            //代理商彩种编号
            int nLotNum = get_pub.LotContrast(playName);

            //发起时间
            DateTime date = Convert.ToDateTime(DateTime.Now.ToLongTimeString());

            for (int i = 0; i < issue.Split('|').Length; i++)
            {
                //生成订单号
                string nOrderNum = Pbzx.Common.Method.CreateQNumber("zh",true);
                mod_tn.tn_orderNum = nOrderNum;
                mod_tn.tn_username = username;
                mod_tn.tn_playname = playName;
                mod_tn.tn_stopCondition = stopCondition;
                mod_tn.tn_issue = issue.Split('|')[i].ToString();
                mod_tn.tn_num = num;
                mod_tn.tn_multiple = Convert.ToInt32(multiple.Split('|')[i]);
                mod_tn.tn_money = Convert.ToDecimal(money.Split('|')[i]);
                mod_tn.tn_message = message;
                mod_tn.tn_complete = 0;
                mod_tn.tn_time = date;
                mod_tn.tn_order = SerialNum;
                mod_tn.tn_open = 0;
                mod_tn.tn_dtbt = 0;
                try
                {
                    if (get_tn.Add(mod_tn) > 0)
                    {
                        //查询当前期号

                        if (issue.Split('|')[i].ToString() == CurrentIssue)
                        {
                            //购买了当前期  出票
                            //投注业务参数
                            string prar = get_pub.PostBetting(nOrderNum, nLotNum, 20120626, Convert.ToInt32(money.Split('|')[i]), num, Convert.ToInt32(multiple.Split('|')[i]), "wwwwwwwww", 2);

                            //返回的字符串
                            string xmlStr = get_pub.bett(prar);
                            int code = -1;

                            for (int j = 0; j < xmlStr.Split(',').Length; j++)
                            {
                                if (xmlStr.Split(',')[j].Split('|')[0] == "xCode")
                                {
                                    code = Convert.ToInt32(xmlStr.Split(',')[j].Split('|')[1]);
                                    break;
                                }
                            }
                            if (code == 0)
                            {
                                //投注成功 (投注成功，冻结资金， 可能有出票失败)
                                modUserTab.FrozenMoney = modUserTab.FrozenMoney + Convert.ToDecimal(money.Split('|')[i]);
                                //修改账户金额
                                if (get_userTab.Update(modUserTab))
                                {
                                    //个人收支账户记录
                                    Pbzx.BLL.PlatformPublic_payments get_pmen = new Pbzx.BLL.PlatformPublic_payments();
                                    get_pmen.payments(username, SerialNum, 3, Convert.ToInt32(issue.Split('|')[i]), playName, "追号成功冻结资金", Convert.ToDecimal(money.Split('|')[i]), "Chipped");

                                }
                            }
                        }
                    }
                    else
                    {
                        return 0;
                    }

                }
                catch (Exception ex)
                {
                    //全局错误日志
                    Pbzx.Common.ErrorLog.WriteLog(ex);
                }
            }
            return 1;
        }


        /// <summary>
        /// 查询是否出票 1-出票成功 2002： 投注中  合买代购出票
        /// </summary>
        /// <param name="Qnum">订单流水号</param>
        [WebMethod]
        public void selectDrawer(string Qnum)
        {
            Pbzx.BLL.publicMethod get_p = new publicMethod();
            Pbzx.BLL.Chipped_LaunchInfoManage get_lif = new Chipped_LaunchInfoManage();
            Pbzx.Model.chipped_LaunchInfo get_li = get_lif.GetModel(Qnum);
            //请求参数
            string getStr = get_p.PostStr(3821, 102, "zzzzzzz", "OrderID=" + Qnum);

            string str = get_p.PostUrl(getStr);

            //接收返回字符串
            string xmlStr = get_p.Receive(str);

            int code = -1;

            for (int i = 0; i < xmlStr.Split(',').Length; i++)
            {
                if (xmlStr.Split(',')[i].Split('|')[0] == "xCode")
                {
                    code = Convert.ToInt32(xmlStr.Split(',')[i].Split('|')[1]);
                    break;
                }
            }
            if (code == 1)
            {

                try
                {
                    get_li.State = 1;
                    if (get_lif.Update(get_li) > 0)
                    {
                        //扣除用户购买金额
                        get_p.DeductionMonery(Qnum);
                    }
                }
                catch (Exception ex)
                {
                    //全局错误日志
                    Pbzx.Common.ErrorLog.WriteLog(ex);
                }
            }
            //2002 数据处理中
            if (code == 2002)
            {
                get_li.State = 3;
                get_lif.Update(get_li);
            }

        }

        /// <summary>
        /// 查询是否出票 1-出票成功 2002： 投注中    追号出票
        /// </summary>
        /// <param name="issue">当前期号</param>
        [WebMethod]
        public void DrawerSuc(string Qnum,string issue)
        {
            Pbzx.BLL.publicMethod get_p = new publicMethod();
            Pbzx.BLL.Chipped_TrackNum get_tk = new Pbzx.BLL.Chipped_TrackNum();
            DataSet ds_tk = get_p.Chipped_Table("Chipped_TrackNum", "tn_id,tn_orderNum", "tn_issue=" + "'" + issue + "'" + " and tn_complete=0 and tn_order=" + "'" + Qnum + "'");
            Pbzx.Model.Chipped_TrackNum mod_tk = get_tk.GetModel(Convert.ToInt32(ds_tk.Tables[0].Rows[0]["tn_id"]));
            //请求参数
            string getStr = get_p.PostStr(3821, 102, "zzzzzzz", "OrderID=" + ds_tk.Tables[0].Rows[0]["tn_orderNum"].ToString());

            string str = get_p.PostUrl(getStr);

            //接收返回字符串
            string xmlStr = get_p.Receive(str);

            int code = -1;

            for (int i = 0; i < xmlStr.Split(',').Length; i++)
            {
                if (xmlStr.Split(',')[i].Split('|')[0] == "xCode")
                {
                    code = Convert.ToInt32(xmlStr.Split(',')[i].Split('|')[1]);
                    break;
                }
            }
            if (code == 1)
            {

                try
                {
                    mod_tk.tn_complete = 1;
                    if (get_tk.Update(mod_tk))
                    {
                        //扣除用户购买金额
                        get_p.DedMoneyTackNum(ds_tk.Tables[0].Rows[0]["tn_orderNum"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    //全局错误日志
                    Pbzx.Common.ErrorLog.WriteLog(ex);
                }
            }

        }
        /// <summary>
        /// 查询是否出票 1-出票成功 2002： 投注中    多期机选出票状态
        /// </summary>
        /// <param name="Rn_id">多期机选信息表ID</param>
        /// <param name="issue">当前期号</param>
        [WebMethod]
        public void sDrawerDQ(int Rn_id,string issue)
        {
            Pbzx.BLL.publicMethod get_p = new publicMethod();
            Pbzx.BLL.Chipped_issueN get_is = new Pbzx.BLL.Chipped_issueN();
            DataSet ds = get_is.GetList("In_RnId=" + Rn_id + " and In_issue="+"'"+ issue +"'");
            Pbzx.Model.Chipped_issueN mod_is = get_is.GetModel(Convert.ToInt32(ds.Tables[0].Rows[0]["In_id"]));
            //请求参数
            string getStr = get_p.PostStr(3821, 102, "zzzzzzz", "OrderID=" + ds.Tables[0].Rows[0]["In_num"].ToString());

            string str = get_p.PostUrl(getStr);

            //接收返回字符串
            string xmlStr = get_p.Receive(str);

            int code = -1;

            for (int i = 0; i < xmlStr.Split(',').Length; i++)
            {
                if (xmlStr.Split(',')[i].Split('|')[0] == "xCode")
                {
                    code = Convert.ToInt32(xmlStr.Split(',')[i].Split('|')[1]);
                    break;
                }
            }
            if (code == 1)
            {

                try
                {
                    mod_is.In_mark = 1;
                    if (get_is.Update(mod_is))
                    {
                        //扣除用户购买金额
                        get_p.DeductionDqM(ds.Tables[0].Rows[0]["In_num"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    //全局错误日志
                    Pbzx.Common.ErrorLog.WriteLog(ex);
                }
            }

        }

        /// <summary>
        /// 处理定制跟单
        /// </summary>
        /// <param name="UserName">发单人用户名</param>
        /// <param name="playName">彩种编号</param>
        /// <param name="OrderNum">订单编号</param>
        public int CustomTrack(string UserName,int playName,string OrderNum)
        { 
            Pbzx.BLL.Chipped_TrackingOrders get_ts=new Pbzx.BLL.Chipped_TrackingOrders();
            Pbzx.BLL.Chipped_LaunchInfoManage get_lo = new Chipped_LaunchInfoManage();
            Pbzx.BLL.Chipped_InfoManage get_loe = new Chipped_InfoManage();
            Pbzx.Model.Chipped_Info mod_loe = new Chipped_Info();
            Pbzx.BLL.publicMethod get_pd = new publicMethod();
            //代理商彩种编号
            int nLotNum = get_pd.LotContrast(playName);
            //查询订单状态
            DataSet ds_order = get_lo.GetList("QNumber=" + "'" + OrderNum + "'");
            //计算单份的价格
            decimal n_Each = Convert.ToDecimal(ds_order.Tables[0].Rows[0]["AtotalMoney"]) / Convert.ToInt32(ds_order.Tables[0].Rows[0]["Share"]);

            //查询跟单的用户
            DataSet ds = get_ts.GetList("UserN=" + "'" + UserName + "'" + " and TrackingLNum=" + playName + " and BuyMoney>=" + n_Each + " order by TrackingTime desc");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[i]["SubscribeNum"])-Convert.ToInt32(ds.Tables[0].Rows[i]["TrackingN"]) < 0)
                    {
                        break;
                    }
                    //是否销售完成
                    if (colpete(OrderNum))
                    {
                        //已经销售完成
                        //投注业务参数
                        string prar = get_pd.PostBetting(OrderNum, nLotNum, 20120626, Convert.ToInt32(ds_order.Tables[0].Rows[0]["AtotalMoney"]), ds_order.Tables[0].Rows[0]["ChoiceNum"].ToString(), Convert.ToInt32(ds_order.Tables[0].Rows[0]["doubles"]), "wwwwwwwww", 2);


                        //返回的字符串
                        string xmlStr = get_pd.bett(prar);

                        int code = -1;

                        for (int j = 0; j < xmlStr.Split(',').Length; j++)
                        {
                            if (xmlStr.Split(',')[j].Split('|')[0] == "xCode")
                            {
                                code = Convert.ToInt32(xmlStr.Split(',')[j].Split('|')[1]);
                                break;
                            }
                        }
                        if (code == 0)
                        {
                            return 1;
                        }
                        else
                        {
                            //出票不成功  
                            Pbzx.Model.chipped_LaunchInfo mod_lif = get_lo.GetModel(OrderNum);
                            mod_lif.State = 3;
                            get_lo.Update(mod_lif);
                        }


                    }
                    else
                    {
                        //进行销售
                        //允许购买的份数  认购金额/每份金额=认购的份数
                        int n_EachNum = Convert.ToInt32(ds.Tables[0].Rows[i]["BuyMoney"]) / Convert.ToInt32(n_Each);
                        //花费金额
                        decimal n_Money = n_EachNum * n_Each;

                        //查询用户账户金额是否够支付
                        DataSet ds_user = get_pd.Chipped_Table("PBnet_UserTable", "Id,CurrentMoney,FrozenMoney", "UserName=" + "'" + ds.Tables[0].Rows[i]["TrackingName"].ToString() + "'");
                        if (Convert.ToDecimal(ds_user.Tables[0].Rows[0]["CurrentMoney"]) > n_Money)
                        {
                            mod_loe.QNumber = OrderNum;
                            mod_loe.ChippedName = ds.Tables[0].Rows[i]["TrackingName"].ToString();
                            mod_loe.ChippedShare = n_EachNum;
                            mod_loe.ChippedTime = DateTime.Now;
                            try
                            {
                                //添加数据
                                if (get_loe.Add(mod_loe) > 0)
                                { 
                                    //修改完成次数
                                    Pbzx.Model.Chipped_TrackingOrders mod_ts = get_ts.GetModel(Convert.ToInt32(ds.Tables[0].Rows[i]["TrackingID"]));
                                    mod_ts.TrackingN = Convert.ToInt32(ds.Tables[0].Rows[i]["TrackingN"]) + 1;
                                    get_ts.Update(mod_ts);
                                    //个人收支账户记录
                                    Pbzx.BLL.PlatformPublic_payments get_pmen = new Pbzx.BLL.PlatformPublic_payments();
                                    get_pmen.payments(ds.Tables[0].Rows[i]["TrackingName"].ToString(), OrderNum, 3, Convert.ToInt32(ds_order.Tables[0].Rows[0]["ExpectNum"]), Convert.ToInt32(ds_order.Tables[0].Rows[0]["playName"]), "定制跟单成功冻结资金", Convert.ToDecimal(n_Money), "Chipped");
                                    if (colpete(OrderNum))
                                    {
                                        //已经销售完成
                                        //投注业务参数
                                        string prar = get_pd.PostBetting(OrderNum, nLotNum, 20120626, Convert.ToInt32(ds_order.Tables[0].Rows[0]["AtotalMoney"]), ds_order.Tables[0].Rows[0]["ChoiceNum"].ToString(), Convert.ToInt32(ds_order.Tables[0].Rows[0]["doubles"]), "wwwwwwwww", 2);


                                        //返回的字符串
                                        string xmlStr = get_pd.bett(prar);

                                        int code = -1;

                                        for (int j = 0; j < xmlStr.Split(',').Length; j++)
                                        {
                                            if (xmlStr.Split(',')[j].Split('|')[0] == "xCode")
                                            {
                                                code = Convert.ToInt32(xmlStr.Split(',')[j].Split('|')[1]);
                                                break;
                                            }
                                        }
                                        if (code == 0)
                                        {
                                            return 1;
                                        }
                                        else
                                        {
                                            //出票不成功  
                                            Pbzx.Model.chipped_LaunchInfo mod_lif = get_lo.GetModel(OrderNum);
                                            mod_lif.State = 3;
                                            get_lo.Update(mod_lif);
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

                    }
                }
                
            }
            return 0;

        }



    }
}
