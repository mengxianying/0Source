using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using Pbzx.Common;
using System.Data;
using System.Text;
using Maticsoft.DBUtility;
using System.Collections;

namespace Pinble_Challenge
{
    /// <summary>
    /// ChallSer 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]

    public class ChallSer : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        /// <summary>
        /// 添加擂台条件
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="lott">彩种id</param>
        /// <param name="issue">期号</param>
        /// <param name="num">号码</param>
        /// <returns></returns>
        [WebMethod]
        public int addChall(string name,int lott,int issue,string num)
        {
            Pbzx.BLL.Challenge_type get_t = new Pbzx.BLL.Challenge_type();
            Pbzx.BLL.Challenge_Cinfo get_c = new Pbzx.BLL.Challenge_Cinfo();
            Pbzx.Model.Challenge_Cinfo mod_c = new Pbzx.Model.Challenge_Cinfo();
            int n_num = num.Split(';').Length;
            int n = 0;

            ////查询是否已经发布过
            if (get_c.Exists(name, issue, lott))
            {
                return 2;
            }
            DateTime time = DateTime.Now;
            for (int i = 0; i < n_num; i++)
            {
                mod_c.C_name = name;
                mod_c.C_lottID = lott;
                mod_c.C_issue = issue;

                
                //在类型表中查询条件
                DataSet ds = get_t.GetList("T_state="+"'"+ num.Split(';')[i].Split('|')[0].ToString() +"'");
                mod_c.C_Tid = Convert.ToInt32(ds.Tables[0].Rows[0]["T_id"]);
                mod_c.C_num = num.Split(';')[i].Split('|')[1].ToString();
                mod_c.C_time = time;
                mod_c.C_win = 0;
                try
                {
                    if (get_c.Add(mod_c) > 0)
                    {
                        n = n + 1;
                    }
                }
                catch (Exception ex)
                {
                    Pbzx.Common.ErrorLog.WriteLog(ex);
                }
                
            }
            if (n == n_num)
            {
                return 1;
            }

           return 0;
        }

        /// <summary>
        /// 验证用户登录
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public int logionUser()
        {
            Pbzx.BLL.PBnet_UserTable get_user = new Pbzx.BLL.PBnet_UserTable();

            DataSet ds = get_user.GetList("UserName=" + "'" + Method.Get_UserName.ToString() + "'" + " and TradePwd="+"'"+ Method.Get_UserPwd.ToString() +"'");
            if (get_user.Exists(Convert.ToInt32(ds.Tables[0].Rows[0]["Id"])))
            {
                //已经登录
                return 1;
            }
            //未登录返回0
            return 0;
        }

        /// <summary>
        /// 判断用户是否登录
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string ulogin()
        {
            if (Pbzx.Common.Method.Get_UserName.ToString() == "0")
            {
                return "0";
            }
            else
            {
                return Method.Get_UserName.ToString();
            }
        }


        #region 个人彩种中奖排列表

        /// <summary>
        /// 查询ssq彩种统计列表
        /// </summary>
        /// <param name="num">要查询的期数</param>
        /// <param name="username">会员名称</param>
        /// <param name="issue">当前期号</param>
        /// <returns></returns>
        [WebMethod]
        public string perTableS(int num, string username, int issue)
        {
            Pbzx.BLL.Challenge_Cinfo get_c = new Pbzx.BLL.Challenge_Cinfo();
            Pbzx.BLL.Challenge_integral get_i = new Pbzx.BLL.Challenge_integral();

            StringBuilder sbStr = new StringBuilder();
            sbStr.Append("<table width=\"710\"><tbody>");
            sbStr.Append("<tr class=\"expert-chart-main-top td_white\">");
            sbStr.Append("<td width=\"6%\"></td>");
            sbStr.Append("<td>红球3胆</td>");
            sbStr.Append("<td>红球6胆</td>");
            sbStr.Append("<td>杀3红球</td>");
            sbStr.Append("<td>杀6红球</td>");
            sbStr.Append("<td>蓝球1胆</td>");
            sbStr.Append("<td>蓝球3胆</td>");
            sbStr.Append("<td>杀3蓝球</td>");
            sbStr.Append("<td>杀6蓝球</td>");
            sbStr.Append("<td>12红+3蓝</td>");
            sbStr.Append("<td>9红+2蓝</td>");
            sbStr.Append("</tr>");
            sbStr.Append("</tbody>");

            //查询个人 N期之间的发布数据

            DataSet ds = get_c.GetStatiUser(num, "C_name=" + "'" + username + "'" + " and C_win=1");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                sbStr.Append("<tbody><tr class=\"td_blue\">");
                sbStr.Append("<td width=\"6%\">成绩</td>");
                sbStr.Append("<td>" + num + "中<font color='red'>" + (ds.Tables[0].Rows[0]["hq3d"].ToString() == "" ? "0" : ds.Tables[0].Rows[0]["hq3d"].ToString()) + "</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>" + (ds.Tables[0].Rows[0]["hq6d"].ToString() == "" ? "0" : ds.Tables[0].Rows[0]["hq6d"].ToString()) + "</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>" + (ds.Tables[0].Rows[0]["s3hq"].ToString() == "" ? "0" : ds.Tables[0].Rows[0]["s3hq"].ToString()) + "</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>" + (ds.Tables[0].Rows[0]["s6hq"].ToString() == "" ? "0" : ds.Tables[0].Rows[0]["s6hq"].ToString()) + "</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>" + (ds.Tables[0].Rows[0]["lq1d"].ToString() == "" ? "0" : ds.Tables[0].Rows[0]["lq1d"].ToString()) + "</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>" + (ds.Tables[0].Rows[0]["lq3d"].ToString() == "" ? "0" : ds.Tables[0].Rows[0]["lq3d"].ToString()) + "</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>" + (ds.Tables[0].Rows[0]["s3lq"].ToString() == "" ? "0" : ds.Tables[0].Rows[0]["s3lq"].ToString()) + "</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>" + (ds.Tables[0].Rows[0]["s6lq"].ToString() == "" ? "0" : ds.Tables[0].Rows[0]["s6lq"].ToString()) + "</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>" + (ds.Tables[0].Rows[0]["h3l"].ToString() == "" ? "0" : ds.Tables[0].Rows[0]["h3l"].ToString()) + "</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>" + (ds.Tables[0].Rows[0]["h2l"].ToString() == "" ? "0" : ds.Tables[0].Rows[0]["h2l"].ToString()) + "</font></td>");
                sbStr.Append("</tr>");
            }
            else
            {
                sbStr.Append("<tbody><tr class=\"td_blue\">");
                sbStr.Append("<td width=\"6%\">成绩</td>");
                sbStr.Append("<td>" + num + "中<font color='red'>0</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>0</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>0</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>0</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>0</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>0</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>0</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>0</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>0</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>0</font></td>");
                sbStr.Append("</tr>");
            }

            //计算排名-根据传来的期数 计算排名
            //sbStr.Append("<tr class=\"td_blue\">");
            //sbStr.Append("<td width=\"6%\">排名</td>");
            //sbStr.Append("<td></td>");
            //sbStr.Append("<td></td>");
            //sbStr.Append("<td></td>");
            //sbStr.Append("<td></td>");
            //sbStr.Append("<td></td>");
            //sbStr.Append("<td></td>");
            //sbStr.Append("<td></td>");
            //sbStr.Append("<td></td>");
            //sbStr.Append("<td></td>");
            //sbStr.Append("<td></td>");
            //sbStr.Append("</tr>");
            //积分情况
            sbStr.Append("<tr>");
            sbStr.Append("<td width=\"6%\">积分</td>");

            DataSet ds_rank = get_i.selectRankS("I_name=" + "'" + username + "'");
            if (ds_rank != null && ds_rank.Tables[0].Rows.Count > 0)
            {
                sbStr.Append("<td>" + ds_rank.Tables[0].Rows[0]["hq3d"].ToString() + "</td>");
                sbStr.Append("<td>" + ds_rank.Tables[0].Rows[0]["hq6d"].ToString() + "</td>");
                sbStr.Append("<td>" + ds_rank.Tables[0].Rows[0]["s3hq"].ToString() + "</td>");
                sbStr.Append("<td>" + ds_rank.Tables[0].Rows[0]["s6hq"].ToString() + "</td>");
                sbStr.Append("<td>" + ds_rank.Tables[0].Rows[0]["lq1d"].ToString() + "</td>");
                sbStr.Append("<td>" + ds_rank.Tables[0].Rows[0]["lq3d"].ToString() + "</td>");
                sbStr.Append("<td>" + ds_rank.Tables[0].Rows[0]["s3lq"].ToString() + "</td>");
                sbStr.Append("<td>" + ds_rank.Tables[0].Rows[0]["s6lq"].ToString() + "</td>");
                sbStr.Append("<td>" + ds_rank.Tables[0].Rows[0]["h3l"].ToString() + "</td>");
                sbStr.Append("<td>" + ds_rank.Tables[0].Rows[0]["h2l"].ToString() + "</td>");
            }
            else
            {
                sbStr.Append("<td>0</td>");
                sbStr.Append("<td>0</td>");
                sbStr.Append("<td>0</td>");
                sbStr.Append("<td>0</td>");
                sbStr.Append("<td>0</td>");
                sbStr.Append("<td>0</td>");
                sbStr.Append("<td>0</td>");
                sbStr.Append("<td>0</td>");
                sbStr.Append("<td>0</td>");
                sbStr.Append("<td>0</td>");
            }
            sbStr.Append("</tr>");
            //积分排名
            sbStr.Append("<tr class=\"td_blue\">");
            sbStr.Append("<td width=\"6%\">排名</td>");
            DataSet ds_hq3d = get_i.RankSSq("v_hq3d", "I_name=" + "'" + username + "'");
            if (ds_hq3d != null && ds_hq3d.Tables[0].Rows.Count > 0)
            {
                sbStr.Append("<td>" + ds_hq3d.Tables[0].Rows[0]["pm"].ToString() + "</td>");
            }
            else
            {
                sbStr.Append("<td>无</td>");
            }

            DataSet ds_hq6d = get_i.RankSSq("v_hq6d", "I_name=" + "'" + username + "'");
            if (ds_hq6d != null && ds_hq6d.Tables[0].Rows.Count > 0)
            {
                sbStr.Append("<td>" + ds_hq6d.Tables[0].Rows[0]["pm"].ToString() + "</td>");
            }
            else
            {
                sbStr.Append("<td>无</td>");
            }

            DataSet ds_s3hq = get_i.RankSSq("v_s3hq", "I_name=" + "'" + username + "'");
            if (ds_s3hq != null && ds_s3hq.Tables[0].Rows.Count > 0)
            {
                sbStr.Append("<td>" + ds_s3hq.Tables[0].Rows[0]["pm"].ToString() + "</td>");
            }
            else
            {
                sbStr.Append("<td>无</td>");
            }

            DataSet ds_s6hq = get_i.RankSSq("v_s6hq", "I_name=" + "'" + username + "'");
            if (ds_s6hq != null && ds_s6hq.Tables[0].Rows.Count > 0)
            {
                sbStr.Append("<td>" + ds_s6hq.Tables[0].Rows[0]["pm"].ToString() + "</td>");
            }
            else
            {
                sbStr.Append("<td>无</td>");
            }

            DataSet ds_lq1d = get_i.RankSSq("v_lq1d", "I_name=" + "'" + username + "'");
            if (ds_lq1d != null && ds_lq1d.Tables[0].Rows.Count > 0)
            {
                sbStr.Append("<td>" + ds_lq1d.Tables[0].Rows[0]["pm"].ToString() + "</td>");
            }
            else
            {
                sbStr.Append("<td>无</td>");
            }

            DataSet ds_lq3d = get_i.RankSSq("v_lq3d", "I_name=" + "'" + username + "'");
            if (ds_lq3d != null && ds_lq3d.Tables[0].Rows.Count > 0)
            {
                sbStr.Append("<td>" + ds_lq3d.Tables[0].Rows[0]["pm"].ToString() + "</td>");
            }
            else
            {
                sbStr.Append("<td>无</td>");
            }

            DataSet ds_s3lq = get_i.RankSSq("v_s3lq", "I_name=" + "'" + username + "'");
            if (ds_s3lq != null && ds_s3lq.Tables[0].Rows.Count > 0)
            {
                sbStr.Append("<td>" + ds_s3lq.Tables[0].Rows[0]["pm"].ToString() + "</td>");
            }
            else
            {
                sbStr.Append("<td>无</td>");
            }

            DataSet ds_s6lq = get_i.RankSSq("v_s6lq", "I_name=" + "'" + username + "'");
            if (ds_s6lq != null && ds_s6lq.Tables[0].Rows.Count > 0)
            {
                sbStr.Append("<td>" + ds_s6lq.Tables[0].Rows[0]["pm"].ToString() + "</td>");
            }
            else
            {
                sbStr.Append("<td>无</td>");
            }

            DataSet ds_h3l = get_i.RankSSq("v_h3l", "I_name=" + "'" + username + "'");
            if (ds_h3l != null && ds_h3l.Tables[0].Rows.Count > 0)
            {
                sbStr.Append("<td>" + ds_h3l.Tables[0].Rows[0]["pm"].ToString() + "</td>");
            }
            else
            {
                sbStr.Append("<td>无</td>");
            }

            DataSet ds_h2l = get_i.RankSSq("v_h2l", "I_name=" + "'" + username + "'");
            if (ds_h2l != null && ds_h2l.Tables[0].Rows.Count > 0)
            {
                sbStr.Append("<td>" + ds_h2l.Tables[0].Rows[0]["pm"].ToString() + "</td>");
            }
            else
            {
                sbStr.Append("<td>无</td>");
            }

            sbStr.Append("</tr>");
            sbStr.Append("</tbody>");

            sbStr.Append("</table>");
            //返回编码字符串
            return HttpContext.Current.Server.HtmlEncode(sbStr.ToString());
        }

        /// <summary>
        /// 查询3D、排列3个人显示表
        /// </summary>
        /// <param name="num">要查询的期数</param>
        /// <param name="username">会员名称</param>
        /// <param name="issue">当前期号</param>
        /// <returns></returns>
        [WebMethod]
        public string perTableD(int num, string username, int issue)
        {
            Pbzx.BLL.Challenge_Cinfo get_c = new Pbzx.BLL.Challenge_Cinfo();
            Pbzx.BLL.Challenge_integral get_i = new Pbzx.BLL.Challenge_integral();

            StringBuilder sbStr = new StringBuilder();
            sbStr.Append("<table width=\"710\"><tbody>");
            sbStr.Append("<tr class=\"expert-chart-main-top td_white\">");
            sbStr.Append("<td width=\"6%\"></td>");
            sbStr.Append("<td>独胆</td>");
            sbStr.Append("<td>双胆</td>");
            sbStr.Append("<td>组选1注</td>");
            sbStr.Append("<td>杀1码</td>");
            sbStr.Append("<td>杀2码</td>");
            sbStr.Append("<td>独跨</td>");
            sbStr.Append("<td>独合</td>");
            sbStr.Append("<td>杀1合</td>");
            sbStr.Append("<td>5*5*5定位</td>");
            sbStr.Append("<td>3*3*3定位</td>");
            sbStr.Append("<td>直选1注</td>");
            sbStr.Append("<td>5码</td>");
            sbStr.Append("</tr>");
            sbStr.Append("</tbody>");

            //查询个人 N期之间的发布数据

            DataSet ds = get_c.GetStatiUserD(num, "C_name=" + "'" + username + "'" + " and C_win=1");
            
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                sbStr.Append("<tbody><tr class=\"td_blue\">");
                sbStr.Append("<td width=\"6%\">成绩</td>");
                sbStr.Append("<td>" + num + "中<font color='red'>" + (ds.Tables[0].Rows[0]["dd"].ToString() == "" ? "0" : ds.Tables[0].Rows[0]["dd"].ToString()) + "</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>" + (ds.Tables[0].Rows[0]["sd"].ToString() == "" ? "0" : ds.Tables[0].Rows[0]["sd"].ToString()) + "</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>" + (ds.Tables[0].Rows[0]["zx1z"].ToString() == "" ? "0" : ds.Tables[0].Rows[0]["zx1z"].ToString()) + "</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>" + (ds.Tables[0].Rows[0]["s1m"].ToString() == "" ? "0" : ds.Tables[0].Rows[0]["s1m"].ToString()) + "</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>" + (ds.Tables[0].Rows[0]["s2m"].ToString() == "" ? "0" : ds.Tables[0].Rows[0]["s2m"].ToString()) + "</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>" + (ds.Tables[0].Rows[0]["dk"].ToString() == "" ? "0" : ds.Tables[0].Rows[0]["dk"].ToString()) + "</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>" + (ds.Tables[0].Rows[0]["dh"].ToString() == "" ? "0" : ds.Tables[0].Rows[0]["dh"].ToString()) + "</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>" + (ds.Tables[0].Rows[0]["s1h"].ToString() == "" ? "0" : ds.Tables[0].Rows[0]["s1h"].ToString()) + "</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>" + (ds.Tables[0].Rows[0][8].ToString() == "" ? "0" : ds.Tables[0].Rows[0][8].ToString()) + "</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>" + (ds.Tables[0].Rows[0][9].ToString() == "" ? "0" : ds.Tables[0].Rows[0][9].ToString()) + "</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>" + (ds.Tables[0].Rows[0]["zx"].ToString() == "" ? "0" : ds.Tables[0].Rows[0]["zx"].ToString()) + "</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>" + (ds.Tables[0].Rows[0]["m"].ToString() == "" ? "0" : ds.Tables[0].Rows[0]["m"].ToString()) + "</font></td>");
                sbStr.Append("</tr>");
            }
            else
            {
                sbStr.Append("<tbody><tr class=\"td_blue\">");
                sbStr.Append("<td width=\"6%\">成绩</td>");
                sbStr.Append("<td>" + num + "中<font color='red'>0</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>0</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>0</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>0</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>0</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>0</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>0</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>0</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>0</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>0</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>0</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>0</font></td>");
                sbStr.Append("</tr>");
            }

            //计算排名-根据传来的期数 计算排名
            //sbStr.Append("<tr class=\"td_blue\">");
            //sbStr.Append("<td width=\"6%\">排名</td>");
            //sbStr.Append("<td></td>");
            //sbStr.Append("<td></td>");
            //sbStr.Append("<td></td>");
            //sbStr.Append("<td></td>");
            //sbStr.Append("<td></td>");
            //sbStr.Append("<td></td>");
            //sbStr.Append("<td></td>");
            //sbStr.Append("<td></td>");
            //sbStr.Append("<td></td>");
            //sbStr.Append("<td></td>");
            //sbStr.Append("<td></td>");
            //sbStr.Append("<td></td>");
            //sbStr.Append("</tr>");
            //积分情况
            sbStr.Append("<tr>");
            sbStr.Append("<td width=\"6%\">积分</td>");

            DataSet ds_rank = get_i.selectRankS("I_name=" + "'" + username + "'");
            if (ds_rank != null && ds_rank.Tables[0].Rows.Count > 0)
            {

                sbStr.Append("<td>" + ds_rank.Tables[0].Rows[0]["dd"].ToString() + "</td>");
                sbStr.Append("<td>" + ds_rank.Tables[0].Rows[0]["sd"].ToString() + "</td>");
                sbStr.Append("<td>" + ds_rank.Tables[0].Rows[0]["zx1z"].ToString() + "</td>");
                sbStr.Append("<td>" + ds_rank.Tables[0].Rows[0]["s1m"].ToString() + "</td>");
                sbStr.Append("<td>" + ds_rank.Tables[0].Rows[0]["s2m"].ToString() + "</td>");
                sbStr.Append("<td>" + ds_rank.Tables[0].Rows[0]["dk"].ToString() + "</td>");
                sbStr.Append("<td>" + ds_rank.Tables[0].Rows[0]["dh"].ToString() + "</td>");
                sbStr.Append("<td>" + ds_rank.Tables[0].Rows[0]["s1h"].ToString() + "</td>");
                sbStr.Append("<td>" + ds_rank.Tables[0].Rows[0]["5dw"].ToString() + "</td>");
                sbStr.Append("<td>" + ds_rank.Tables[0].Rows[0]["3dw"].ToString() + "</td>");
                sbStr.Append("<td>" + ds_rank.Tables[0].Rows[0]["zx"].ToString() + "</td>");
                sbStr.Append("<td>" + ds_rank.Tables[0].Rows[0]["m"].ToString() + "</td>");
                sbStr.Append("</tr>");
            }
            else
            {
                sbStr.Append("<td>0</td>");
                sbStr.Append("<td>0</td>");
                sbStr.Append("<td>0</td>");
                sbStr.Append("<td>0</td>");
                sbStr.Append("<td>0</td>");
                sbStr.Append("<td>0</td>");
                sbStr.Append("<td>0</td>");
                sbStr.Append("<td>0</td>");
                sbStr.Append("<td>0</td>");
                sbStr.Append("<td>0</td>");
                sbStr.Append("<td>0</td>");
                sbStr.Append("<td>0</td>");
                sbStr.Append("</tr>");
            }

            //积分排名
            sbStr.Append("<tr class=\"td_blue\">");
            sbStr.Append("<td width=\"6%\">排名</td>");
            DataSet ds_dd = get_i.RankSSq("v_dd", "I_name=" + "'" + username + "'");
            if (ds_dd != null && ds_dd.Tables[0].Rows.Count > 0)
            {
                sbStr.Append("<td>" + ds_dd.Tables[0].Rows[0]["pm"].ToString() + "</td>");
            }
            else
            {
                sbStr.Append("<td>无</td>");
            }

            DataSet ds_sd = get_i.RankSSq("v_sd", "I_name=" + "'" + username + "'");
            if (ds_sd != null && ds_sd.Tables[0].Rows.Count > 0)
            {
                sbStr.Append("<td>" + ds_sd.Tables[0].Rows[0]["pm"].ToString() + "</td>");
            }
            else
            {
                sbStr.Append("<td>无</td>");
            }

            DataSet ds_zx1z = get_i.RankSSq("v_zx1z", "I_name=" + "'" + username + "'");
            if (ds_zx1z != null && ds_zx1z.Tables[0].Rows.Count > 0)
            {
                sbStr.Append("<td>" + ds_zx1z.Tables[0].Rows[0]["pm"].ToString() + "</td>");
            }
            else
            {
                sbStr.Append("<td>无</td>");
            }

            DataSet ds_s1m = get_i.RankSSq("v_s1m", "I_name=" + "'" + username + "'");
            if (ds_s1m != null && ds_s1m.Tables[0].Rows.Count > 0)
            {
                sbStr.Append("<td>" + ds_s1m.Tables[0].Rows[0]["pm"].ToString() + "</td>");
            }
            else
            {
                sbStr.Append("<td>无</td>");
            }

            DataSet ds_s2m = get_i.RankSSq("v_s2m", "I_name=" + "'" + username + "'");
            if (ds_s2m != null && ds_s2m.Tables[0].Rows.Count > 0)
            {
                sbStr.Append("<td>" + ds_s2m.Tables[0].Rows[0]["pm"].ToString() + "</td>");
            }
            else
            {
                sbStr.Append("<td>无</td>");
            }

            DataSet ds_dk= get_i.RankSSq("v_dk", "I_name=" + "'" + username + "'");
            if (ds_dk!= null && ds_dk.Tables[0].Rows.Count > 0)
            {
                sbStr.Append("<td>" + ds_dk.Tables[0].Rows[0]["pm"].ToString() + "</td>");
            }
            else
            {
                sbStr.Append("<td>无</td>");
            }

            DataSet ds_dh = get_i.RankSSq("v_dh", "I_name=" + "'" + username + "'");
            if (ds_dh != null && ds_dh.Tables[0].Rows.Count > 0)
            {
                sbStr.Append("<td>" + ds_dh.Tables[0].Rows[0]["pm"].ToString() + "</td>");
            }
            else
            {
                sbStr.Append("<td>无</td>");
            }

            DataSet ds_s1h = get_i.RankSSq("v_s1h", "I_name=" + "'" + username + "'");
            if (ds_s1h != null && ds_s1h.Tables[0].Rows.Count > 0)
            {
                sbStr.Append("<td>" + ds_s1h.Tables[0].Rows[0]["pm"].ToString() + "</td>");
            }
            else
            {
                sbStr.Append("<td>无</td>");
            }

            DataSet ds_5dw = get_i.RankSSq("v_5dw", "I_name=" + "'" + username + "'");
            if (ds_5dw != null && ds_5dw.Tables[0].Rows.Count > 0)
            {
                sbStr.Append("<td>" + ds_5dw.Tables[0].Rows[0]["pm"].ToString() + "</td>");
            }
            else
            {
                sbStr.Append("<td>无</td>");
            }

            DataSet ds_3dw = get_i.RankSSq("v_3dw", "I_name=" + "'" + username + "'");
            if (ds_3dw != null && ds_3dw.Tables[0].Rows.Count > 0)
            {
                sbStr.Append("<td>" + ds_3dw.Tables[0].Rows[0]["pm"].ToString() + "</td>");
            }
            else
            {
                sbStr.Append("<td>无</td>");
            }

            DataSet ds_zx = get_i.RankSSq("v_zx", "I_name=" + "'" + username + "'");
            if (ds_zx != null && ds_zx.Tables[0].Rows.Count > 0)
            {
                sbStr.Append("<td>" + ds_zx.Tables[0].Rows[0]["pm"].ToString() + "</td>");
            }
            else
            {
                sbStr.Append("<td>无</td>");
            }

            DataSet ds_m= get_i.RankSSq("v_m", "I_name=" + "'" + username + "'");
            if (ds_m != null && ds_m.Tables[0].Rows.Count > 0)
            {
                sbStr.Append("<td>" + ds_m.Tables[0].Rows[0]["pm"].ToString() + "</td>");
            }
            else
            {
                sbStr.Append("<td>无</td>");
            }

            sbStr.Append("</tr>");
            sbStr.Append("</tbody>");

            sbStr.Append("</table>");
            //返回编码字符串
            return HttpContext.Current.Server.HtmlEncode(sbStr.ToString());
        }


        /// <summary>
        /// 查询3D、排列3个人显示表
        /// </summary>
        /// <param name="num">要查询的期数</param>
        /// <param name="username">会员名称</param>
        /// <param name="issue">当前期号</param>
        /// <returns></returns>
        [WebMethod]
        public string perTableP(int num, string username, int issue)
        {
            Pbzx.BLL.Challenge_Cinfo get_c = new Pbzx.BLL.Challenge_Cinfo();
            Pbzx.BLL.Challenge_integral get_i = new Pbzx.BLL.Challenge_integral();

            StringBuilder sbStr = new StringBuilder();
            sbStr.Append("<table width=\"710\"><tbody>");
            sbStr.Append("<tr class=\"expert-chart-main-top td_white\">");
            sbStr.Append("<td width=\"6%\"></td>");
            sbStr.Append("<td>独胆</td>");
            sbStr.Append("<td>双胆</td>");
            sbStr.Append("<td>组选1注</td>");
            sbStr.Append("<td>杀1码</td>");
            sbStr.Append("<td>杀2码</td>");
            sbStr.Append("<td>独跨</td>");
            sbStr.Append("<td>独合</td>");
            sbStr.Append("<td>杀1合</td>");
            sbStr.Append("<td>5*5*5定位</td>");
            sbStr.Append("<td>3*3*3定位</td>");
            sbStr.Append("<td>直选1注</td>");
            sbStr.Append("<td>5码</td>");
            sbStr.Append("</tr>");
            sbStr.Append("</tbody>");

            //查询个人 N期之间的发布数据

            DataSet ds = get_c.GetStatiUserP(num, "C_name=" + "'" + username + "'" + " and C_win=1");

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                sbStr.Append("<tbody><tr class=\"td_blue\">");
                sbStr.Append("<td width=\"6%\">成绩</td>");
                sbStr.Append("<td>" + num + "中<font color='red'>" + (ds.Tables[0].Rows[0]["pdd"].ToString() == "" ? "0" : ds.Tables[0].Rows[0]["pdd"].ToString()) + "</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>" + (ds.Tables[0].Rows[0]["psd"].ToString() == "" ? "0" : ds.Tables[0].Rows[0]["psd"].ToString()) + "</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>" + (ds.Tables[0].Rows[0]["pzx1z"].ToString() == "" ? "0" : ds.Tables[0].Rows[0]["pzx1z"].ToString()) + "</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>" + (ds.Tables[0].Rows[0]["ps1m"].ToString() == "" ? "0" : ds.Tables[0].Rows[0]["ps1m"].ToString()) + "</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>" + (ds.Tables[0].Rows[0]["ps2m"].ToString() == "" ? "0" : ds.Tables[0].Rows[0]["ps2m"].ToString()) + "</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>" + (ds.Tables[0].Rows[0]["pdk"].ToString() == "" ? "0" : ds.Tables[0].Rows[0]["pdk"].ToString()) + "</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>" + (ds.Tables[0].Rows[0]["pdh"].ToString() == "" ? "0" : ds.Tables[0].Rows[0]["pdh"].ToString()) + "</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>" + (ds.Tables[0].Rows[0]["ps1h"].ToString() == "" ? "0" : ds.Tables[0].Rows[0]["ps1h"].ToString()) + "</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>" + (ds.Tables[0].Rows[0]["p5dw"].ToString() == "" ? "0" : ds.Tables[0].Rows[0]["p5dw"].ToString()) + "</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>" + (ds.Tables[0].Rows[0]["p3dw"].ToString() == "" ? "0" : ds.Tables[0].Rows[0]["p3dw"].ToString()) + "</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>" + (ds.Tables[0].Rows[0]["pzx"].ToString() == "" ? "0" : ds.Tables[0].Rows[0]["pzx"].ToString()) + "</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>" + (ds.Tables[0].Rows[0]["p5m"].ToString() == "" ? "0" : ds.Tables[0].Rows[0]["p5m"].ToString()) + "</font></td>");
                sbStr.Append("</tr>");
            }
            else
            {
                sbStr.Append("<tbody><tr class=\"td_blue\">");
                sbStr.Append("<td width=\"6%\">成绩</td>");
                sbStr.Append("<td>" + num + "中<font color='red'>0</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>0</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>0</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>0</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>0</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>0</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>0</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>0</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>0</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>0</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>0</font></td>");
                sbStr.Append("<td>" + num + "中<font color='red'>0</font></td>");
                sbStr.Append("</tr>");
            }

            //计算排名-根据传来的期数 计算排名
            sbStr.Append("<tr class=\"td_blue\">");
            sbStr.Append("<td width=\"6%\">排名</td>");
            sbStr.Append("<td></td>");
            sbStr.Append("<td></td>");
            sbStr.Append("<td></td>");
            sbStr.Append("<td></td>");
            sbStr.Append("<td></td>");
            sbStr.Append("<td></td>");
            sbStr.Append("<td></td>");
            sbStr.Append("<td></td>");
            sbStr.Append("<td></td>");
            sbStr.Append("<td></td>");
            sbStr.Append("<td></td>");
            sbStr.Append("<td></td>");
            sbStr.Append("</tr>");
            //积分情况
            sbStr.Append("<tr>");
            sbStr.Append("<td width=\"6%\">积分</td>");

            DataSet ds_rank = get_i.selectRankS("I_name=" + "'" + username + "'");
            if (ds_rank != null && ds_rank.Tables[0].Rows.Count > 0)
            {

                sbStr.Append("<td>" + ds_rank.Tables[0].Rows[0]["pdd"].ToString() + "</td>");
                sbStr.Append("<td>" + ds_rank.Tables[0].Rows[0]["psd"].ToString() + "</td>");
                sbStr.Append("<td>" + ds_rank.Tables[0].Rows[0]["pzx1z"].ToString() + "</td>");
                sbStr.Append("<td>" + ds_rank.Tables[0].Rows[0]["ps1m"].ToString() + "</td>");
                sbStr.Append("<td>" + ds_rank.Tables[0].Rows[0]["ps2m"].ToString() + "</td>");
                sbStr.Append("<td>" + ds_rank.Tables[0].Rows[0]["pdk"].ToString() + "</td>");
                sbStr.Append("<td>" + ds_rank.Tables[0].Rows[0]["pdh"].ToString() + "</td>");
                sbStr.Append("<td>" + ds_rank.Tables[0].Rows[0]["ps1h"].ToString() + "</td>");
                sbStr.Append("<td>" + ds_rank.Tables[0].Rows[0]["p5dw"].ToString() + "</td>");
                sbStr.Append("<td>" + ds_rank.Tables[0].Rows[0]["p3dw"].ToString() + "</td>");
                sbStr.Append("<td>" + ds_rank.Tables[0].Rows[0]["pzx"].ToString() + "</td>");
                sbStr.Append("<td>" + ds_rank.Tables[0].Rows[0]["p5m"].ToString() + "</td>");
                sbStr.Append("</tr>");
            }
            else
            {
                sbStr.Append("<td>0</td>");
                sbStr.Append("<td>0</td>");
                sbStr.Append("<td>0</td>");
                sbStr.Append("<td>0</td>");
                sbStr.Append("<td>0</td>");
                sbStr.Append("<td>0</td>");
                sbStr.Append("<td>0</td>");
                sbStr.Append("<td>0</td>");
                sbStr.Append("<td>0</td>");
                sbStr.Append("<td>0</td>");
                sbStr.Append("<td>0</td>");
                sbStr.Append("<td>0</td>");
                sbStr.Append("</tr>");
            }

            //积分排名
            sbStr.Append("<tr class=\"td_blue\">");
            sbStr.Append("<td width=\"6%\">排名</td>");
            DataSet ds_dd = get_i.RankSSq("v_pdd", "I_name=" + "'" + username + "'");
            if (ds_dd != null && ds_dd.Tables[0].Rows.Count > 0)
            {
                sbStr.Append("<td>" + ds_dd.Tables[0].Rows[0]["pm"].ToString() + "</td>");
            }
            else
            {
                sbStr.Append("<td>无</td>");
            }

            DataSet ds_sd = get_i.RankSSq("v_psd", "I_name=" + "'" + username + "'");
            if (ds_sd != null && ds_sd.Tables[0].Rows.Count > 0)
            {
                sbStr.Append("<td>" + ds_sd.Tables[0].Rows[0]["pm"].ToString() + "</td>");
            }
            else
            {
                sbStr.Append("<td>无</td>");
            }

            DataSet ds_zx1z = get_i.RankSSq("v_pzx1z", "I_name=" + "'" + username + "'");
            if (ds_zx1z != null && ds_zx1z.Tables[0].Rows.Count > 0)
            {
                sbStr.Append("<td>" + ds_zx1z.Tables[0].Rows[0]["pm"].ToString() + "</td>");
            }
            else
            {
                sbStr.Append("<td>无</td>");
            }

            DataSet ds_s1m = get_i.RankSSq("v_ps1m", "I_name=" + "'" + username + "'");
            if (ds_s1m != null && ds_s1m.Tables[0].Rows.Count > 0)
            {
                sbStr.Append("<td>" + ds_s1m.Tables[0].Rows[0]["pm"].ToString() + "</td>");
            }
            else
            {
                sbStr.Append("<td>无</td>");
            }

            DataSet ds_s2m = get_i.RankSSq("v_ps2m", "I_name=" + "'" + username + "'");
            if (ds_s2m != null && ds_s2m.Tables[0].Rows.Count > 0)
            {
                sbStr.Append("<td>" + ds_s2m.Tables[0].Rows[0]["pm"].ToString() + "</td>");
            }
            else
            {
                sbStr.Append("<td>无</td>");
            }

            DataSet ds_dk = get_i.RankSSq("v_pdk", "I_name=" + "'" + username + "'");
            if (ds_dk != null && ds_dk.Tables[0].Rows.Count > 0)
            {
                sbStr.Append("<td>" + ds_dk.Tables[0].Rows[0]["pm"].ToString() + "</td>");
            }
            else
            {
                sbStr.Append("<td>无</td>");
            }

            DataSet ds_dh = get_i.RankSSq("v_pdh", "I_name=" + "'" + username + "'");
            if (ds_dh != null && ds_dh.Tables[0].Rows.Count > 0)
            {
                sbStr.Append("<td>" + ds_dh.Tables[0].Rows[0]["pm"].ToString() + "</td>");
            }
            else
            {
                sbStr.Append("<td>无</td>");
            }

            DataSet ds_s1h = get_i.RankSSq("v_ps1h", "I_name=" + "'" + username + "'");
            if (ds_s1h != null && ds_s1h.Tables[0].Rows.Count > 0)
            {
                sbStr.Append("<td>" + ds_s1h.Tables[0].Rows[0]["pm"].ToString() + "</td>");
            }
            else
            {
                sbStr.Append("<td>无</td>");
            }

            DataSet ds_5dw = get_i.RankSSq("v_p5dw", "I_name=" + "'" + username + "'");
            if (ds_5dw != null && ds_5dw.Tables[0].Rows.Count > 0)
            {
                sbStr.Append("<td>" + ds_5dw.Tables[0].Rows[0]["pm"].ToString() + "</td>");
            }
            else
            {
                sbStr.Append("<td>无</td>");
            }

            DataSet ds_3dw = get_i.RankSSq("v_p3dw", "I_name=" + "'" + username + "'");
            if (ds_3dw != null && ds_3dw.Tables[0].Rows.Count > 0)
            {
                sbStr.Append("<td>" + ds_3dw.Tables[0].Rows[0]["pm"].ToString() + "</td>");
            }
            else
            {
                sbStr.Append("<td>无</td>");
            }

            DataSet ds_zx = get_i.RankSSq("v_pzx", "I_name=" + "'" + username + "'");
            if (ds_zx != null && ds_zx.Tables[0].Rows.Count > 0)
            {
                sbStr.Append("<td>" + ds_zx.Tables[0].Rows[0]["pm"].ToString() + "</td>");
            }
            else
            {
                sbStr.Append("<td>无</td>");
            }

            DataSet ds_m = get_i.RankSSq("v_p5m", "I_name=" + "'" + username + "'");
            if (ds_m != null && ds_m.Tables[0].Rows.Count > 0)
            {
                sbStr.Append("<td>" + ds_m.Tables[0].Rows[0]["pm"].ToString() + "</td>");
            }
            else
            {
                sbStr.Append("<td>无</td>");
            }

            sbStr.Append("</tr>");
            sbStr.Append("</tbody>");

            sbStr.Append("</table>");
            //返回编码字符串
            return HttpContext.Current.Server.HtmlEncode(sbStr.ToString());
        }

        #endregion 

        #region  会员中奖情况表

        /// <summary>
        /// 统计所有会员 中奖情况-----（双色球）
        /// </summary>
        /// <param name="issNum">发布了多少期</param>
        /// <returns></returns>
        [WebMethod]
        public string TabCompOFS(int issNum)
        {
            Pbzx.BLL.Challenge_Cinfo get_c = new Pbzx.BLL.Challenge_Cinfo();
            StringBuilder sbStr = new StringBuilder();
            sbStr.Append("<table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr class=\"cyc_fen cyc_hong\">");
            sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td><a href=\"contrast.aspx?Ind=hq3d&n=s\" target=\"_blank\">红球3胆</a></td>");
            sbStr.Append("<td><a href=\"contrast.aspx?Ind=hq3d&n=s\" target=\"_blank\">红球6胆</a></td>");
            sbStr.Append("<td><a href=\"contrast.aspx?Ind=hq3d&n=s\" target=\"_blank\">杀3红球</a></td>");
            sbStr.Append("<td><a href=\"contrast.aspx?Ind=hq3d&n=s\" target=\"_blank\">杀6红球</a></td>");
            sbStr.Append("<td><a href=\"contrast.aspx?Ind=hq3d&n=s\" target=\"_blank\">蓝球1胆</a></td>");
            sbStr.Append("<td><a href=\"contrast.aspx?Ind=hq3d&n=s\" target=\"_blank\">蓝球3胆</a></td>");
            sbStr.Append("<td><a href=\"contrast.aspx?Ind=hq3d&n=s\" target=\"_blank\">杀3蓝球</a></td>");
            sbStr.Append("<td><a href=\"contrast.aspx?Ind=hq3d&n=s\" target=\"_blank\">杀6蓝球</a></td>");
            sbStr.Append("<td><a href=\"contrast.aspx?Ind=hq3d&n=s\" target=\"_blank\">12红+3蓝</a></td>");
            sbStr.Append("<td><a href=\"contrast.aspx?Ind=hq3d&n=s\" target=\"_blank\">9红+2蓝</a></td>");
            sbStr.Append("</tr>");
            sbStr.Append("</tbody>");
            DataSet ds = new DataSet();
            int n_rank = 1;
            try
            {
                ds = get_c.GetCompOFs(issNum, "C_lottID=3 and C_win=1");
            }
            catch (Exception ex)
            {
                Pbzx.Common.ErrorLog.WriteLog(ex);
            }
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                sbStr.Append("<tbody>");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //根据发布期数

                    sbStr.Append("<tr>");
                    sbStr.Append("<td class=\"result\">" + n_rank + "</td>");
                    sbStr.Append("<td class=\"result\"><a href='Person.aspx?name=" + Server.UrlEncode(dr[0].ToString()) + "'>" + dr[0].ToString() + "</a></td>");

                    sbStr.Append("<td class=\"result\">" + issNum + "中<font color='red'>" + dr[1].ToString() + "</font></td>");
                    sbStr.Append("<td class=\"result\">" + issNum + "中<font color='red'>" + dr[2].ToString() + "</font></td>");
                    sbStr.Append("<td class=\"result\">" + issNum + "中<font color='red'>" + dr[3].ToString() + "</font></td>");
                    sbStr.Append("<td class=\"result\">" + issNum + "中<font color='red'>" + dr[4].ToString() + "</font></td>");
                    sbStr.Append("<td class=\"result\">" + issNum + "中<font color='red'>" + dr[5].ToString() + "</font></td>");
                    sbStr.Append("<td class=\"result\">" + issNum + "中<font color='red'>" + dr[6].ToString() + "</font></td>");
                    sbStr.Append("<td class=\"result\">" + issNum + "中<font color='red'>" + dr[7].ToString() + "</font></td>");
                    sbStr.Append("<td class=\"result\">" + issNum + "中<font color='red'>" + dr[8].ToString() + "</font></td>");
                    sbStr.Append("<td class=\"result\">" + issNum + "中<font color='red'>" + dr[9].ToString() + "</font></td>");
                    sbStr.Append("<td class=\"result\">" + issNum + "中<font color='red'>" + dr[10].ToString() + "</font></td>");
                    sbStr.Append("</tr>");
                    n_rank++;
                }
                sbStr.Append("</tbody>");
            }

            sbStr.Append("</table>");

            return HttpContext.Current.Server.HtmlEncode(sbStr.ToString());
        }
        /// <summary>
        /// 统计所有会员 中奖情况-----（3D）
        /// </summary>
        /// <param name="issNum">发布了多少期</param>
        /// <returns></returns>
        [WebMethod]
        public string TabCompOFS_D(int issNum)
        {
           #region
            Pbzx.BLL.Challenge_Cinfo get_c = new Pbzx.BLL.Challenge_Cinfo();
            StringBuilder sbStr = new StringBuilder();
            sbStr.Append("<table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr class=\"cyc_fen cyc_hong\">");
            sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td><a href=\"contrast.aspx?Ind=dd&n=d\" target=\"_blank\">独胆</a></td>");
            sbStr.Append("<td><a href=\"contrast.aspx?Ind=dd&n=d\" target=\"_blank\">双胆</a></td>");
            sbStr.Append("<td><a href=\"contrast.aspx?Ind=dd&n=d\" target=\"_blank\">组选1注</a></td>");
            sbStr.Append("<td><a href=\"contrast.aspx?Ind=dd&n=d\" target=\"_blank\">杀1码</a></td>");
            sbStr.Append("<td><a href=\"contrast.aspx?Ind=dd&n=d\" target=\"_blank\">杀2码</a></td>");
            sbStr.Append("<td><a href=\"contrast.aspx?Ind=dd&n=d\" target=\"_blank\">独跨</a></td>");
            sbStr.Append("<td><a href=\"contrast.aspx?Ind=dd&n=d\" target=\"_blank\">独合</a></td>");
            sbStr.Append("<td><a href=\"contrast.aspx?Ind=dd&n=d\" target=\"_blank\">杀1合</a></td>");
            sbStr.Append("<td><a href=\"contrast.aspx?Ind=dd&n=d\" target=\"_blank\">5*5*5定位</a></td>");
            //sbStr.Append("<td><a href=\"contrast.aspx?Ind=dd&n=d\" target=\"_blank\">3*3*3定位</a></td>");
            //sbStr.Append("<td><a href=\"contrast.aspx?Ind=dd&n=d\" target=\"_blank\">直选1注</a></td>");
            //sbStr.Append("<td><a href=\"contrast.aspx?Ind=dd&n=d\" target=\"_blank\">5码</a></td>");
            sbStr.Append("</tr>");
            sbStr.Append("</tbody>");
            DataSet ds = new DataSet();
            int n_rank = 1;
            try
            {
                ds = get_c.GetCompOFs(issNum, "C_lottID=1 and C_win=1");
            }
            catch (Exception ex)
            {
                Pbzx.Common.ErrorLog.WriteLog(ex);
            }
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                sbStr.Append("<tbody>");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //根据发布期数

                    sbStr.Append("<tr>");
                    sbStr.Append("<td class=\"result\">" + n_rank + "</td>");
                    sbStr.Append("<td class=\"result\"><a href=' Person.aspx?name=" + Pbzx.Common.Input.URLEncode(dr[0].ToString()) + "'>" + dr[0].ToString() + "</a></td>");

                    sbStr.Append("<td class=\"result\">" + issNum + "中<font color='red'>" + dr[11].ToString() + "</font></td>");
                    sbStr.Append("<td class=\"result\">" + issNum + "中<font color='red'>" + dr[12].ToString() + "</font></td>");
                    sbStr.Append("<td class=\"result\">" + issNum + "中<font color='red'>" + dr[13].ToString() + "</font></td>");
                    sbStr.Append("<td class=\"result\">" + issNum + "中<font color='red'>" + dr[14].ToString() + "</font></td>");
                    sbStr.Append("<td class=\"result\">" + issNum + "中<font color='red'>" + dr[15].ToString() + "</font></td>");
                    sbStr.Append("<td class=\"result\">" + issNum + "中<font color='red'>" + dr[16].ToString() + "</font></td>");
                    sbStr.Append("<td class=\"result\">" + issNum + "中<font color='red'>" + dr[17].ToString() + "</font></td>");
                    sbStr.Append("<td class=\"result\">" + issNum + "中<font color='red'>" + dr[18].ToString() + "</font></td>");
                    sbStr.Append("<td class=\"result\">" + issNum + "中<font color='red'>" + dr[19].ToString() + "</font></td>");

                    //sbStr.Append("<td class=\"result\">50中<font color='red'>0</font></td>");

                    //sbStr.Append("<td class=\"result\">" + issNum + "中<font color='red'>" + dr[21].ToString() + "</font></td>");
                    //sbStr.Append("<td class=\"result\">" + issNum + "中<font color='red'>" + dr[22].ToString() + "</font></td>");
                    sbStr.Append("</tr>");
                    n_rank++;
                }
                sbStr.Append("</tbody>");
            }

            sbStr.Append("</table>");
            #endregion

            return HttpContext.Current.Server.HtmlEncode(sbStr.ToString());
        }

        /// <summary>
        /// 统计所有会员 中奖情况-----（排列3）
        /// </summary>
        /// <param name="issNum">发布了多少期</param>
        /// <returns></returns>
        [WebMethod]
        public string TabCompOFS_P(int issNum)
        {
            Pbzx.BLL.Challenge_Cinfo get_c = new Pbzx.BLL.Challenge_Cinfo();
            StringBuilder sbStr = new StringBuilder();
            sbStr.Append("<table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr class=\"cyc_fen cyc_hong\">");
            sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td><a href=\"contrast.aspx?Ind=pdd&n=p\" target=\"_blank\" class=\"color-blue\">独胆</a></td>");
            sbStr.Append("<td><a href=\"contrast.aspx?Ind=pdd&n=p\" target=\"_blank\" class=\"color-blue\">双胆</a></td>");
            sbStr.Append("<td><a href=\"contrast.aspx?Ind=pdd&n=p\" target=\"_blank\" class=\"color-blue\">组选1注</a></td>");
            sbStr.Append("<td><a href=\"contrast.aspx?Ind=pdd&n=p\" target=\"_blank\" class=\"color-blue\">杀1码</a></td>");
            sbStr.Append("<td><a href=\"contrast.aspx?Ind=pdd&n=p\" target=\"_blank\" class=\"color-blue\">杀2码</a></td>");
            sbStr.Append("<td><a href=\"contrast.aspx?Ind=pdd&n=p\" target=\"_blank\" class=\"color-blue\">独跨</a></td>");
            sbStr.Append("<td><a href=\"contrast.aspx?Ind=pdd&n=p\" target=\"_blank\" class=\"color-blue\">独合</a></td>");
            sbStr.Append("<td><a href=\"contrast.aspx?Ind=pdd&n=p\" target=\"_blank\" class=\"color-blue\">杀1合</a></td>");
            sbStr.Append("<td><a href=\"contrast.aspx?Ind=pdd&n=p\" target=\"_blank\" class=\"color-blue\">5*5*5定位</a></td>");
            sbStr.Append("<td><a href=\"contrast.aspx?Ind=pdd&n=p\" target=\"_blank\" class=\"color-blue\">3*3*3定位</a></td>");
            sbStr.Append("<td><a href=\"contrast.aspx?Ind=pdd&n=p\" target=\"_blank\" class=\"color-blue\">直选1注</a></td>");
            sbStr.Append("<td><a href=\"contrast.aspx?Ind=pdd&n=p\" target=\"_blank\" class=\"color-blue\">5码</a></td>");
            sbStr.Append("</tr>");
            sbStr.Append("</tbody>");
            DataSet ds = new DataSet();
            int n_rank = 1;
            try
            {

                ds = get_c.GetCompOFs_P(issNum, "C_lottID=9999 and C_win=1");
            }
            catch (Exception ex)
            {
                Pbzx.Common.ErrorLog.WriteLog(ex);
            }
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                sbStr.Append("<tbody>");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //根据发布期数

                    sbStr.Append("<tr>");
                    sbStr.Append("<td class=\"result\">" + n_rank + "</td>");
                    sbStr.Append("<td class=\"result\"><a href=' Person.aspx?name=" + Pbzx.Common.Input.URLEncode(dr[0].ToString()) + "'>" + dr[0].ToString() + "</a></td>");

                    sbStr.Append("<td class=\"result\">" + issNum + "中<font color='red'>" + dr[1].ToString() + "</font></td>");
                    sbStr.Append("<td class=\"result\">" + issNum + "中<font color='red'>" + dr[2].ToString() + "</font></td>");
                    sbStr.Append("<td class=\"result\">" + issNum + "中<font color='red'>" + dr[3].ToString() + "</font></td>");
                    sbStr.Append("<td class=\"result\">" + issNum + "中<font color='red'>" + dr[4].ToString() + "</font></td>");
                    sbStr.Append("<td class=\"result\">" + issNum + "中<font color='red'>" + dr[5].ToString() + "</font></td>");
                    sbStr.Append("<td class=\"result\">" + issNum + "中<font color='red'>" + dr[6].ToString() + "</font></td>");
                    sbStr.Append("<td class=\"result\">" + issNum + "中<font color='red'>" + dr[7].ToString() + "</font></td>");
                    sbStr.Append("<td class=\"result\">" + issNum + "中<font color='red'>" + dr[8].ToString() + "</font></td>");
                    sbStr.Append("<td class=\"result\">" + issNum + "中<font color='red'>" + dr[9].ToString() + "</font></td>");
                    sbStr.Append("<td class=\"result\">" + issNum + "中<font color='red'>" + dr[10].ToString() + "</font></td>");
                    sbStr.Append("<td class=\"result\">" + issNum + "中<font color='red'>" + dr[11].ToString() + "</font></td>");
                    sbStr.Append("<td class=\"result\">" + issNum + "中<font color='red'>" + dr[12].ToString() + "</font></td>");
                    sbStr.Append("</tr>");
                    n_rank++;
                }
                sbStr.Append("</tbody>");
            }

            sbStr.Append("</table>");

            return HttpContext.Current.Server.HtmlEncode(sbStr.ToString());
        }

        #endregion



        #region 双色球 3D 排列3 成绩榜
        /// <summary>
        /// 成绩榜 绑定数据 -------双色球条件成绩榜
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string perRankData()
        {
            Pbzx.BLL.Challenge_integral get_i=new Pbzx.BLL.Challenge_integral();
            Pbzx.BLL.Challenge_Cinfo get_c = new Pbzx.BLL.Challenge_Cinfo();

            StringBuilder sbStr=new StringBuilder();
            //sbStr.Append("<div class=\"exper-content\">");
            //sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            //sbStr.Append("<p class=\"exper-title\">人气榜</p>");
            //sbStr.Append("<p class=\"txt-blue\"></p>");
            //sbStr.Append("<p class=\"exper-more\"> 更多</p>");
            //sbStr.Append("</div>");
            //sbStr.Append("<table class=\"exper-table\">");
            //sbStr.Append("<tbody><tr>");
            //sbStr.Append("<td>名次</td>");
            //sbStr.Append("<td>会员</td>");
            //sbStr.Append("<td>人气</td>");
            //sbStr.Append("<td> 详情</td>");
            //sbStr.Append("</tr>");

            ////查询会员
            //sbStr.Append("<tr>");
            //sbStr.Append("<td><var>1</var></td>");
            //sbStr.Append("<td><a href=\"#\">湛蓝</a></td>");
            //sbStr.Append("<td><font color=\"#b21\">463↓</font></td>");
            //sbStr.Append("<td><a href=\"#\" class=\"enter\" target=\"_blank\"><img src=\"images/cv.png\"></a></td>");
            //sbStr.Append("</tr></tbody>");

            //sbStr.Append("</table>");
            ////sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            ////sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a> <a href=\"#\"> <img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            ////sbStr.Append("</div>");
            //sbStr.Append("</div>");

            //红球3胆成绩排行
            DataSet ds = get_c.GetCompOFs("T_state='hq3d' and C_lottID=3 and C_win='1'");
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">红球3胆</p>");
            sbStr.Append("<p class=\"txt-blue\">"+ DateTime.Now.ToShortDateString() +"</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>成绩</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>积分</td>");
            sbStr.Append("</tr>");
            //名次 http://match.pinble.com/HisAchi.aspx?name=
            int n_win = 1;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>"+ n_win +"</var></td>");
                sbStr.Append("<td><a href='Person.aspx?name=" + Server.UrlEncode(dr[0].ToString()) + "'>" + dr[0].ToString() + "</a></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='"+ dr[0].ToString() +"' and T_state='hq3d' order by C_issue desc");

                sbStr.Append("<td> <a href='HisAchi.aspx?name=" + dr[0].ToString() + "'>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + dr[1].ToString() + "</font></a></td>");
                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询积分
                DataSet ds_i = get_i.GetList("I_name=" + "'" + dr[0].ToString() + "'" + " and I_condName='hq3d'");
                //没有积分
                if (ds_i != null && ds_i.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td class=\"results\"><a href=\"#\" target='_blank'>" + ds_i.Tables[0].Rows[0]["I_Integral"].ToString() + "</a></td>");
                }
                else
                {
                    sbStr.Append("<td class=\"results\">0</td>");
                }
               sbStr.Append("</tr>");
                n_win++;
                if (n_win > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");


            //红球6胆成绩排行
            DataSet ds_hq6d = get_c.GetCompOFs("T_state='hq6d' and C_lottID=3 and C_win='1'");
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">红球6胆</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>成绩</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>积分</td>");
            sbStr.Append("</tr>");
            //名次
            int n_hq6d = 1;
            foreach (DataRow dr in ds_hq6d.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_hq6d + "</var></td>");
                sbStr.Append("<td><a href='Person.aspx?name=" + Server.UrlEncode(dr[0].ToString()) + "'>" + dr[0].ToString() + "</a></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[0].ToString() + "' and T_state='hq6d' order by C_issue desc");

                sbStr.Append("<td><a href='HisAchi.aspx?name=" + dr[0].ToString() + "'>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + dr[2].ToString() + "</font></a></td>");
                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询积分
                DataSet ds_i = get_i.GetList("I_name=" + "'" + dr[0].ToString() + "'" + " and I_condName='hq6d'");
                //没有积分
                if (ds_i != null && ds_i.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td class=\"results\"><a href=\"#\" target='_blank'>" + ds_i.Tables[0].Rows[0]["I_Integral"].ToString() + "</a></td>");
                }
                else
                {
                    sbStr.Append("<td class=\"results\">0</td>");
                }
                sbStr.Append("</tr>");
                n_hq6d++;
                if (n_hq6d > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");

            //杀3红球成绩排行
            DataSet ds_s3hq = get_c.GetCompOFs("T_state='s3hq' and C_lottID=3 and C_win='1'");
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">杀3红球</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>成绩</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>积分</td>");
            sbStr.Append("</tr>");
            //名次
            int n_s3hq = 1;
            foreach (DataRow dr in ds_s3hq.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_s3hq + "</var></td>");
                sbStr.Append("<td><a href='Person.aspx?name=" + Server.UrlEncode(dr[0].ToString()) + "'>" + dr[0].ToString() + "</a></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[0].ToString() + "' and T_state='s3hq' order by C_issue desc");

                sbStr.Append("<td><a href='HisAchi.aspx?name=" + dr[0].ToString() + "'>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + dr[3].ToString() + "</font></a></td>");
                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询积分
                DataSet ds_i = get_i.GetList("I_name=" + "'" + dr[0].ToString() + "'" + " and I_condName='s3hq'");
                //没有积分
                if (ds_i != null && ds_i.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td class=\"results\"><a href=\"#\" target='_blank'>" + ds_i.Tables[0].Rows[0]["I_Integral"].ToString() + "</a></td>");
                }
                else
                {
                    sbStr.Append("<td class=\"results\">0</td>");
                }
                sbStr.Append("</tr>");
                n_s3hq++;
                if (n_s3hq > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");

            //杀6红球成绩排行
            DataSet ds_s6hq = get_c.GetCompOFs("T_state='s6hq' and C_lottID=3 and C_win='1'");
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">杀6红球</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>成绩</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>积分</td>");
            sbStr.Append("</tr>");
            //名次
            int n_s6hq = 1;
            foreach (DataRow dr in ds_s6hq.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_s6hq + "</var></td>");
                sbStr.Append("<td><a href='Person.aspx?name=" + Server.UrlEncode(dr[0].ToString()) + "'>" + dr[0].ToString() + "</a></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[0].ToString() + "' and T_state='s6hq' order by C_issue desc");

                sbStr.Append("<td><a href='HisAchi.aspx?name=" + dr[0].ToString() + "'>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + dr[4].ToString() + "</font></a></td>");
                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询积分
                DataSet ds_i = get_i.GetList("I_name=" + "'" + dr[0].ToString() + "'" + " and I_condName='s6hq'");
                //没有积分
                if (ds_i != null && ds_i.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td class=\"results\"><a href=\"#\" target='_blank'>" + ds_i.Tables[0].Rows[0]["I_Integral"].ToString() + "</a></td>");
                }
                else
                {
                    sbStr.Append("<td class=\"results\">0</td>");
                }
                sbStr.Append("</tr>");
                n_s6hq++;
                if (n_s6hq > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");

            //蓝球1胆成绩排行
            DataSet ds_lq1d = get_c.GetCompOFs("T_state='lq1d' and C_lottID=3 and C_win='1'");
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">蓝球1胆</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>成绩</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>积分</td>");
            sbStr.Append("</tr>");
            //名次
            int n_lq1d = 1;
            foreach (DataRow dr in ds_lq1d.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_lq1d + "</var></td>");
                sbStr.Append("<td><a href='Person.aspx?name=" + Server.UrlEncode(dr[0].ToString()) + "'>" + dr[0].ToString() + "</a></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[0].ToString() + "' and T_state='lq1d' order by C_issue desc");

                sbStr.Append("<td><a href='HisAchi.aspx?name=" + dr[0].ToString() + "'>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + dr[5].ToString() + "</font></a></td>");
                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询积分
                DataSet ds_i = get_i.GetList("I_name=" + "'" + dr[0].ToString() + "'" + " and I_condName='lq1d'");
                //没有积分
                if (ds_i != null && ds_i.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td class=\"results\"><a href=\"#\" target='_blank'>" + ds_i.Tables[0].Rows[0]["I_Integral"].ToString() + "</a></td>");
                }
                else
                {
                    sbStr.Append("<td class=\"results\">0</td>");
                }
                sbStr.Append("</tr>");
                n_lq1d++;

                if (n_lq1d > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");

            //蓝球3胆成绩排行
            DataSet ds_lq3d = get_c.GetCompOFs("T_state='lq3d' and C_lottID=3 and C_win='1'");
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">蓝球3胆</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>成绩</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>积分</td>");
            sbStr.Append("</tr>");
            //名次
            int n_lq3d = 1;
            foreach (DataRow dr in ds_lq3d.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_lq3d+ "</var></td>");
                sbStr.Append("<td><a href='Person.aspx?name=" + Server.UrlEncode(dr[0].ToString()) + "'>" + dr[0].ToString() + "</a></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[0].ToString() + "' and T_state='lq3d' order by C_issue desc");

                sbStr.Append("<td><a href='HisAchi.aspx?name=" + dr[0].ToString() + "'>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + dr[6].ToString() + "</font></a></td>");
                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询积分
                DataSet ds_i = get_i.GetList("I_name=" + "'" + dr[0].ToString() + "'" + " and I_condName='lq3d'");
                //没有积分
                if (ds_i != null && ds_i.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td class=\"results\"><a href=\"#\" target='_blank'>" + ds_i.Tables[0].Rows[0]["I_Integral"].ToString() + "</a></td>");
                }
                else
                {
                    sbStr.Append("<td class=\"results\">0</td>");
                }
                sbStr.Append("</tr>");
                n_lq3d++;
                if (n_lq3d > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");

            //杀3蓝球 成绩排行
            DataSet ds_s3lq = get_c.GetCompOFs("T_state='s3lq' and C_lottID=3 and C_win='1'");
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">杀3蓝球</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>成绩</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>积分</td>");
            sbStr.Append("</tr>");
            //名次
            int n_s3lq= 1;
            foreach (DataRow dr in ds_s3lq.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_s3lq + "</var></td>");
                sbStr.Append("<td><a href='Person.aspx?name=" + Server.UrlEncode(dr[0].ToString()) + "'>" + dr[0].ToString() + "</a></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[0].ToString() + "' and T_state='s3lq' order by C_issue desc");

                sbStr.Append("<td><a href='HisAchi.aspx?name=" + dr[0].ToString() + "'>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + dr[7].ToString() + "</font></a></td>");
                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询积分
                DataSet ds_i = get_i.GetList("I_name=" + "'" + dr[0].ToString() + "'" + " and I_condName='s3lq'");
                //没有积分
                if (ds_i != null && ds_i.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td class=\"results\"><a href=\"#\" target='_blank'>" + ds_i.Tables[0].Rows[0]["I_Integral"].ToString() + "</a></td>");
                }
                else
                {
                    sbStr.Append("<td class=\"results\">0</td>");
                }
                sbStr.Append("</tr>");
                n_s3lq++;
                if (n_s3lq > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");

            //杀6蓝球成绩排行
            DataSet ds_s6lq = get_c.GetCompOFs("T_state='s6lq' and C_lottID=3 and C_win='1'");
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">杀6蓝球</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>成绩</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>积分</td>");
            sbStr.Append("</tr>");
            //名次
            int n_s6lq = 1;
            foreach (DataRow dr in ds_s6lq.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_s6lq + "</var></td>");
                sbStr.Append("<td><a href='Person.aspx?name=" + Server.UrlEncode(dr[0].ToString()) + "'>" + dr[0].ToString() + "</a></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[0].ToString() + "' and T_state='s6lq' order by C_issue desc");

                sbStr.Append("<td><a href='HisAchi.aspx?name=" + dr[0].ToString() + "'>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + dr[8].ToString() + "</font></a></td>");
                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询积分
                DataSet ds_i = get_i.GetList("I_name=" + "'" + dr[0].ToString() + "'" + " and I_condName='s6lq'");
                //没有积分
                if (ds_i != null && ds_i.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td class=\"results\"><a href=\"#\" target='_blank'>" + ds_i.Tables[0].Rows[0]["I_Integral"].ToString() + "</a></td>");
                }
                else
                {
                    sbStr.Append("<td class=\"results\">0</td>");
                }
                sbStr.Append("</tr>");
                n_s6lq++;
                if (n_s6lq > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");

            //12红+3蓝 成绩排行
            DataSet ds_h3l = get_c.GetCompOFs("T_state='h3l' and C_lottID=3 and C_win='1'");
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">12红+3蓝</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>成绩</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>积分</td>");
            sbStr.Append("</tr>");
            //名次
            int n_h3l = 1;
            foreach (DataRow dr in ds_h3l.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_h3l + "</var></td>");
                sbStr.Append("<td><a href='Person.aspx?name=" + Server.UrlEncode(dr[0].ToString()) + "'>" + dr[0].ToString() + "</a></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[0].ToString() + "' and T_state='h3l' order by C_issue desc");

                sbStr.Append("<td><a href='HisAchi.aspx?name=" + dr[0].ToString() + "'>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + dr[9].ToString() + "</font></a></td>");
                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询积分
                DataSet ds_i = get_i.GetList("I_name=" + "'" + dr[0].ToString() + "'" + " and I_condName='h3l'");
                //没有积分
                if (ds_i != null && ds_i.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td class=\"results\"><a href=\"#\" target='_blank'>" + ds_i.Tables[0].Rows[0]["I_Integral"].ToString() + "</a></td>");
                }
                else
                {
                    sbStr.Append("<td class=\"results\">0</td>");
                }
                sbStr.Append("</tr>");
                n_h3l++;

                if (n_h3l > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");

            //9红+2蓝 成绩排行
            DataSet ds_h2l = get_c.GetCompOFs("T_state='h2l' and C_lottID=3 and C_win='1'");
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">9红+2蓝</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>成绩</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>积分</td>");
            sbStr.Append("</tr>");
            //名次
            int n_h2l = 1;
            foreach (DataRow dr in ds_h2l.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_h2l + "</var></td>");
                sbStr.Append("<td><a href='Person.aspx?name=" + Server.UrlEncode(dr[0].ToString()) + "'>" + dr[0].ToString() + "</a></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[0].ToString() + "' and T_state='h2l' order by C_issue desc");

                sbStr.Append("<td><a href='HisAchi.aspx?name=" + dr[0].ToString() + "'>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + dr[10].ToString() + "</font></a></td>");
                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询积分
                DataSet ds_i = get_i.GetList("I_name=" + "'" + dr[0].ToString() + "'" + " and I_condName='h2l'");
                //没有积分
                if (ds_i != null && ds_i.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td class=\"results\"><a href=\"#\" target='_blank'>" + ds_i.Tables[0].Rows[0]["I_Integral"].ToString() + "</a></td>");
                }
                else
                {
                    sbStr.Append("<td class=\"results\">0</td>");
                }
                sbStr.Append("</tr>");
                n_h2l++;
                if (n_h2l > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");

            return  HttpContext.Current.Server.HtmlEncode(sbStr.ToString());
        }

        /// <summary>
        /// 成绩榜 绑定数据 -------3D 条件成绩榜
        /// </summary>
        /// <param name="lottID">彩种标识</param>
        /// <returns></returns>
        [WebMethod]
        public string perRankData_D()
        {
            Pbzx.BLL.Challenge_integral get_i = new Pbzx.BLL.Challenge_integral();
            Pbzx.BLL.Challenge_Cinfo get_c = new Pbzx.BLL.Challenge_Cinfo();

            StringBuilder sbStr = new StringBuilder();
            //sbStr.Append("<div class=\"exper-content\">");
            //sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            //sbStr.Append("<p class=\"exper-title\">人气榜</p>");
            //sbStr.Append("<p class=\"txt-blue\"></p>");
            //sbStr.Append("<p class=\"exper-more\"> 更多</p>");
            //sbStr.Append("</div>");
            //sbStr.Append("<table class=\"exper-table\">");
            //sbStr.Append("<tbody><tr>");
            //sbStr.Append("<td>名次</td>");
            //sbStr.Append("<td>会员</td>");
            //sbStr.Append("<td>人气</td>");
            //sbStr.Append("<td> 详情</td>");
            //sbStr.Append("</tr>");

            ////查询会员
            //sbStr.Append("<tr>");
            //sbStr.Append("<td><var>1</var></td>");
            //sbStr.Append("<td><a href=\"#\">湛蓝</a></td>");
            //sbStr.Append("<td><font color=\"#b21\">463↓</font></td>");
            //sbStr.Append("<td><a href=\"#\" class=\"enter\" target=\"_blank\"><img src=\"images/cv.png\"></a></td>");
            //sbStr.Append("</tr></tbody>");

            //sbStr.Append("</table>");
            ////sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            ////sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a> <a href=\"#\"> <img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            ////sbStr.Append("</div>");
            //sbStr.Append("</div>");

            //独胆成绩排行
            DataSet ds_dd = get_c.GetCompOFs("T_state='dd' and C_win='1'");
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">独胆</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>成绩</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>积分</td>");
            sbStr.Append("</tr>");
            //名次
            int n_dd = 1;
            foreach (DataRow dr in ds_dd.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_dd + "</var></td>");
                sbStr.Append("<td><a href='Person.aspx?name=" + Server.UrlEncode(dr[0].ToString()) + "'>" + dr[0].ToString() + "</a></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[0].ToString() + "' and T_state='dd' order by C_issue desc");

                sbStr.Append("<td><a href='HisAchi.aspx?name=" + dr[0].ToString() + "'>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + dr[11].ToString() + "</font></a></td>");
                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询积分
                DataSet ds_i = get_i.GetList("I_name=" + "'" + dr[0].ToString() + "'" + " and I_condName='dd'");
                //没有积分
                if (ds_i != null && ds_i.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td class=\"results\"><a href=\"#\" target='_blank'>" + ds_i.Tables[0].Rows[0]["I_Integral"].ToString() + "</a></td>");
                }
                else
                {
                    sbStr.Append("<td class=\"results\">0</td>");
                }
                sbStr.Append("</tr>");
                n_dd++;
                if (n_dd > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");


            //双胆成绩排行
            DataSet ds_sd = get_c.GetCompOFs( "T_state='sd' and C_win='1'");
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">双胆</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>成绩</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>积分</td>");
            sbStr.Append("</tr>");
            //名次
            int n_sd = 1;
            foreach (DataRow dr in ds_sd.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_sd + "</var></td>");
                sbStr.Append("<td><a href='Person.aspx?name=" + Server.UrlEncode(dr[0].ToString()) + "'>" + dr[0].ToString() + "</a></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[0].ToString() + "' and T_state='sd' order by C_issue desc");

                sbStr.Append("<td><a href='HisAchi.aspx?name=" + dr[0].ToString() + "'>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + dr[12].ToString() + "</font></a></td>");
                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询积分
                DataSet ds_i = get_i.GetList("I_name=" + "'" + dr[0].ToString() + "'" + " and I_condName='sd'");
                //没有积分
                if (ds_i != null && ds_i.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td class=\"results\"><a href=\"#\" target='_blank'>" + ds_i.Tables[0].Rows[0]["I_Integral"].ToString() + "</a></td>");
                }
                else
                {
                    sbStr.Append("<td class=\"results\">0</td>");
                }
                sbStr.Append("</tr>");
                n_sd++;
                if (n_sd > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");

            //组选1注成绩排行
            DataSet ds_zx1z = get_c.GetCompOFs("T_state='zx1z' and C_win='1'");
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">组选1注</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>成绩</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>积分</td>");
            sbStr.Append("</tr>");
            //名次
            int n_zx1z= 1;
            foreach (DataRow dr in ds_zx1z.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_zx1z + "</var></td>");
                sbStr.Append("<td><a href='Person.aspx?name=" + Server.UrlEncode(dr[0].ToString()) + "'>" + dr[0].ToString() + "</a></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[0].ToString() + "' and T_state='zx1z' order by C_issue desc");

                sbStr.Append("<td><a href='HisAchi.aspx?name=" + dr[0].ToString() + "'>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + dr[13].ToString() + "</font></a></td>");
                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询积分
                DataSet ds_i = get_i.GetList("I_name=" + "'" + dr[0].ToString() + "'" + " and I_condName='zx1z'");
                //没有积分
                if (ds_i != null && ds_i.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td class=\"results\"><a href=\"#\" target='_blank'>" + ds_i.Tables[0].Rows[0]["I_Integral"].ToString() + "</a></td>");
                }
                else
                {
                    sbStr.Append("<td class=\"results\">0</td>");
                }
                sbStr.Append("</tr>");
                n_zx1z++;
                if (n_zx1z > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");

            //杀1码 成绩排行
            DataSet ds_s1m = get_c.GetCompOFs("T_state='s1m' and C_win='1'");
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">杀1码</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>成绩</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>积分</td>");
            sbStr.Append("</tr>");
            //名次
            int n_s1m = 1;
            foreach (DataRow dr in ds_s1m.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_s1m + "</var></td>");
                sbStr.Append("<td><a href='Person.aspx?name=" + Server.UrlEncode(dr[0].ToString()) + "'>" + dr[0].ToString() + "</a></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[0].ToString() + "' and T_state='s1m' order by C_issue desc");

                sbStr.Append("<td><a href='HisAchi.aspx?name=" + dr[0].ToString() + "'>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + dr[14].ToString() + "</font></a></td>");
                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询积分
                DataSet ds_i = get_i.GetList("I_name=" + "'" + dr[0].ToString() + "'" + " and I_condName='s1m'");
                //没有积分
                if (ds_i != null && ds_i.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td class=\"results\"><a href=\"#\" target='_blank'>" + ds_i.Tables[0].Rows[0]["I_Integral"].ToString() + "</a></td>");
                }
                else
                {
                    sbStr.Append("<td class=\"results\">0</td>");
                }
                sbStr.Append("</tr>");
                n_s1m++;
                if (n_s1m > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");

            //杀2码 成绩排行
            DataSet ds_s2m = get_c.GetCompOFs("T_state='s2m' and C_win='1'");
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">杀2码</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>成绩</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>积分</td>");
            sbStr.Append("</tr>");
            //名次
            int n_s2m = 1;
            foreach (DataRow dr in ds_s2m.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_s2m + "</var></td>");
                sbStr.Append("<td><a href='Person.aspx?name=" + Server.UrlEncode(dr[0].ToString()) + "'>" + dr[0].ToString() + "</a></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[0].ToString() + "' and T_state='s2m' order by C_issue desc");

                sbStr.Append("<td><a href='HisAchi.aspx?name=" + dr[0].ToString() + "'>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + dr[15].ToString() + "</font></a></td>");
                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询积分
                DataSet ds_i = get_i.GetList("I_name=" + "'" + dr[0].ToString() + "'" + " and I_condName='s2m'");
                //没有积分
                if (ds_i != null && ds_i.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td class=\"results\"><a href=\"#\" target='_blank'>" + ds_i.Tables[0].Rows[0]["I_Integral"].ToString() + "</a></td>");
                }
                else
                {
                    sbStr.Append("<td class=\"results\">0</td>");
                }
                sbStr.Append("</tr>");
                n_s2m++;
                if (n_s2m > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");

            //独跨 成绩排行
            DataSet ds_dk = get_c.GetCompOFs("T_state='dk' and C_win='1'");
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">独跨</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>成绩</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>积分</td>");
            sbStr.Append("</tr>");
            //名次
            int n_dk = 1;
            foreach (DataRow dr in ds_dk.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_dk + "</var></td>");
                sbStr.Append("<td><a href='Person.aspx?name=" + Server.UrlEncode(dr[0].ToString()) + "'>" + dr[0].ToString() + "</a></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[0].ToString() + "' and T_state='dk' order by C_issue desc");

                sbStr.Append("<td><a href='HisAchi.aspx?name=" + dr[0].ToString() + "'>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + dr[16].ToString() + "</font></a></td>");
                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询积分
                DataSet ds_i = get_i.GetList("I_name=" + "'" + dr[0].ToString() + "'" + " and I_condName='dk'");
                //没有积分
                if (ds_i != null && ds_i.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td class=\"results\"><a href=\"#\" target='_blank'>" + ds_i.Tables[0].Rows[0]["I_Integral"].ToString() + "</a></td>");
                }
                else
                {
                    sbStr.Append("<td class=\"results\">0</td>");
                }
                sbStr.Append("</tr>");
                n_dk++;
                if (n_dk > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");

            //独合 成绩排行
            DataSet ds_dh = get_c.GetCompOFs("T_state='dh' and C_win='1'");
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">独合</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>成绩</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>积分</td>");
            sbStr.Append("</tr>");
            //名次
            int n_dh = 1;
            foreach (DataRow dr in ds_dh.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_dh + "</var></td>");
                sbStr.Append("<td><a href='Person.aspx?name=" + Server.UrlEncode(dr[0].ToString()) + "'>" + dr[0].ToString() + "</a></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[0].ToString() + "' and T_state='dh' order by C_issue desc");

                sbStr.Append("<td><a href='HisAchi.aspx?name=" + dr[0].ToString() + "'>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + dr[17].ToString() + "</font></a></td>");
                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询积分
                DataSet ds_i = get_i.GetList("I_name=" + "'" + dr[0].ToString() + "'" + " and I_condName='dh'");
                //没有积分
                if (ds_i != null && ds_i.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td class=\"results\"><a href=\"#\" target='_blank'>" + ds_i.Tables[0].Rows[0]["I_Integral"].ToString() + "</a></td>");
                }
                else
                {
                    sbStr.Append("<td class=\"results\">0</td>");
                }
                sbStr.Append("</tr>");
                n_dh++;
                if (n_dh > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");

            //杀1合 成绩排行
            DataSet ds_s1h = get_c.GetCompOFs("T_state='s1h' and C_win='1'");
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">杀1合</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>成绩</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>积分</td>");
            sbStr.Append("</tr>");
            //名次
            int n_s1h= 1;
            foreach (DataRow dr in ds_s1h.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_s1h + "</var></td>");
                sbStr.Append("<td><a href='Person.aspx?name=" + Server.UrlEncode(dr[0].ToString()) + "'>" + dr[0].ToString() + "</a></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[0].ToString() + "' and T_state='s1h' order by C_issue desc");

                sbStr.Append("<td><a href='HisAchi.aspx?name=" + dr[0].ToString() + "'>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + dr[18].ToString() + "</font></a></td>");
                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询积分
                DataSet ds_i = get_i.GetList("I_name=" + "'" + dr[0].ToString() + "'" + " and I_condName='s1h'");
                //没有积分
                if (ds_i != null && ds_i.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td class=\"results\"><a href=\"#\" target='_blank'>" + ds_i.Tables[0].Rows[0]["I_Integral"].ToString() + "</a></td>");
                }
                else
                {
                    sbStr.Append("<td class=\"results\">0</td>");
                }
                sbStr.Append("</tr>");
                n_s1h++;
                if (n_s1h > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");

            //5*5*5定位 成绩排行
            DataSet ds_5dw = get_c.GetCompOFs( "T_state='5dw' and C_win='1'");
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">5*5*5定位</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>成绩</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>积分</td>");
            sbStr.Append("</tr>");
            //名次
            int n_5dw = 1;
            foreach (DataRow dr in ds_5dw.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_5dw + "</var></td>");
                sbStr.Append("<td><a href='Person.aspx?name=" + Server.UrlEncode(dr[0].ToString()) + "'>" + dr[0].ToString() + "</a></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[0].ToString() + "' and T_state='5dw' order by C_issue desc");

                sbStr.Append("<td><a href='HisAchi.aspx?name=" + dr[0].ToString() + "'>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + dr[19].ToString() + "</font></a></td>");
                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询积分
                DataSet ds_i = get_i.GetList("I_name=" + "'" + dr[0].ToString() + "'" + " and I_condName='5dw'");
                //没有积分
                if (ds_i != null && ds_i.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td class=\"results\"><a href=\"#\" target='_blank'>" + ds_i.Tables[0].Rows[0]["I_Integral"].ToString() + "</a></td>");
                }
                else
                {
                    sbStr.Append("<td class=\"results\">0</td>");
                }
                sbStr.Append("</tr>");
                n_5dw++;
                if (n_5dw > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");

            //3*3*3定位 成绩排行
            DataSet ds_3dw = get_c.GetCompOFs("T_state='3dw' and C_win='1'");
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">3*3*3定位</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>成绩</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>积分</td>");
            sbStr.Append("</tr>");
            //名次
            int n_3dw = 1;
            foreach (DataRow dr in ds_3dw.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_3dw + "</var></td>");
                sbStr.Append("<td><a href='Person.aspx?name=" + Server.UrlEncode(dr[0].ToString()) + "'>" + dr[0].ToString() + "</a></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[0].ToString() + "' and T_state='3dw' order by C_issue desc");

                sbStr.Append("<td><a href='HisAchi.aspx?name=" + dr[0].ToString() + "'>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + dr[20].ToString() + "</font></a></td>");
                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询积分
                DataSet ds_i = get_i.GetList("I_name=" + "'" + dr[0].ToString() + "'" + " and I_condName='3dw'");
                //没有积分
                if (ds_i != null && ds_i.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td class=\"results\"><a href=\"#\" target='_blank'>" + ds_i.Tables[0].Rows[0]["I_Integral"].ToString() + "</a></td>");
                }
                else
                {
                    sbStr.Append("<td class=\"results\">0</td>");
                }
                sbStr.Append("</tr>");
                n_3dw++;
                if (n_3dw > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");


            //直选1注 成绩排行
            DataSet ds_zx = get_c.GetCompOFs("T_state='zx' and C_win='1'");
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">直选1注</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>成绩</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>积分</td>");
            sbStr.Append("</tr>");
            //名次
            int n_zx = 1;
            foreach (DataRow dr in ds_zx.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_zx + "</var></td>");
                sbStr.Append("<td><a href='Person.aspx?name=" + Server.UrlEncode(dr[0].ToString()) + "'>" + dr[0].ToString() + "</a></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[0].ToString() + "' and T_state='zx' order by C_issue desc");

                sbStr.Append("<td><a href='HisAchi.aspx?name=" + dr[0].ToString() + "'>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + dr[21].ToString() + "</font></a></td>");
                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询积分
                DataSet ds_i = get_i.GetList("I_name=" + "'" + dr[0].ToString() + "'" + " and I_condName='zx'");
                //没有积分
                if (ds_i != null && ds_i.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td class=\"results\"><a href=\"#\" target='_blank'>" + ds_i.Tables[0].Rows[0]["I_Integral"].ToString() + "</a></td>");
                }
                else
                {
                    sbStr.Append("<td class=\"results\">0</td>");
                }
                sbStr.Append("</tr>");
                n_zx++;
                if (n_zx > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");

            //5码 成绩排行
            DataSet ds_m = get_c.GetCompOFs("T_state='m' and C_win='1'");
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">5码</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>成绩</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>积分</td>");
            sbStr.Append("</tr>");
            //名次
            int n_m = 1;
            foreach (DataRow dr in ds_m.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_m + "</var></td>");
                sbStr.Append("<td><a href='Person.aspx?name=" + Server.UrlEncode(dr[0].ToString()) + "'>" + dr[0].ToString() + "</a></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[0].ToString() + "' and T_state='m' order by C_issue desc");

                sbStr.Append("<td><a href='HisAchi.aspx?name=" + dr[0].ToString() + "'>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + dr[22].ToString() + "</font></a></td>");
                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询积分
                DataSet ds_i = get_i.GetList("I_name=" + "'" + dr[0].ToString() + "'" + " and I_condName='m'");
                //没有积分
                if (ds_i != null && ds_i.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td class=\"results\"><a href=\"#\" target='_blank'>" + ds_i.Tables[0].Rows[0]["I_Integral"].ToString() + "</a></td>");
                }
                else
                {
                    sbStr.Append("<td class=\"results\">0</td>");
                }
                sbStr.Append("</tr>");
                n_m++;
                if (n_m > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");

            return HttpContext.Current.Server.HtmlEncode(sbStr.ToString());
        }

        /// <summary>
        /// 成绩榜 绑定数据 -------排3条件成绩榜
        /// </summary>
        /// <param name="lottID">彩种标识</param>
        /// <returns></returns>
        [WebMethod]
        public string perRankData_P()
        {
            Pbzx.BLL.Challenge_integral get_i = new Pbzx.BLL.Challenge_integral();
            Pbzx.BLL.Challenge_Cinfo get_c = new Pbzx.BLL.Challenge_Cinfo();

            StringBuilder sbStr = new StringBuilder();
            //sbStr.Append("<div class=\"exper-content\">");
            //sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            //sbStr.Append("<p class=\"exper-title\">人气榜</p>");
            //sbStr.Append("<p class=\"txt-blue\"></p>");
            //sbStr.Append("<p class=\"exper-more\"> 更多</p>");
            //sbStr.Append("</div>");
            //sbStr.Append("<table class=\"exper-table\">");
            //sbStr.Append("<tbody><tr>");
            //sbStr.Append("<td>名次</td>");
            //sbStr.Append("<td>会员</td>");
            //sbStr.Append("<td>人气</td>");
            //sbStr.Append("<td> 详情</td>");
            //sbStr.Append("</tr>");

            ////查询会员
            //sbStr.Append("<tr>");
            //sbStr.Append("<td><var>1</var></td>");
            //sbStr.Append("<td><a href=\"#\">湛蓝</a></td>");
            //sbStr.Append("<td><font color=\"#b21\">463↓</font></td>");
            //sbStr.Append("<td><a href=\"#\" class=\"enter\" target=\"_blank\"><img src=\"images/cv.png\"></a></td>");
            //sbStr.Append("</tr></tbody>");

            //sbStr.Append("</table>");
            ////sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            ////sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a> <a href=\"#\"> <img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            ////sbStr.Append("</div>");
            //sbStr.Append("</div>");
            try
            {
                #region  排列3 Table
                //独胆成绩排行
                DataSet ds_pdd = get_c.GetCompOFs_P(99999, "T_state='pdd' and C_win='1'");
                sbStr.Append("<div class=\"exper-content\">");
                sbStr.Append("<div class=\"exper-table-f6f6f6\">");
                sbStr.Append("<p class=\"exper-title\">独胆</p>");
                sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
                sbStr.Append("<p class=\"exper-more\">更多</p>");
                sbStr.Append("</div>");

                sbStr.Append("<table class=\"exper-table\">");
                sbStr.Append("<tbody>");
                sbStr.Append("<tr>");
                sbStr.Append("<td>名次</td>");
                sbStr.Append("<td>会员</td>");
                sbStr.Append("<td>成绩</td>");
                //sbStr.Append("<td>排名</td>");
                sbStr.Append("<td>积分</td>");
                sbStr.Append("</tr>");
                //名次
                int n_pdd = 1;
                foreach (DataRow dr in ds_pdd.Tables[0].Rows)
                {
                    sbStr.Append("<tr>");
                    sbStr.Append("<td><var>" + n_pdd + "</var></td>");
                    sbStr.Append("<td><a href='/Person.aspx?name=" + Server.UrlEncode(dr[0].ToString()) + "'>" + dr[0].ToString() + "</a></td>");
                    //查询发布了多少次
                    DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[0].ToString() + "' and T_state='pdd' order by C_issue desc");

                    sbStr.Append("<td><a href='HisAchi.aspx?name=" + dr[0].ToString() + "'>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + dr[1].ToString() + "</font></a></td>");
                    //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                    //查询积分
                    DataSet ds_i = get_i.GetList("I_name=" + "'" + dr[0].ToString() + "'" + " and I_condName='pdd'");
                    //没有积分
                    if (ds_i != null && ds_i.Tables[0].Rows.Count > 0)
                    {
                        sbStr.Append("<td class=\"results\"><a href=\"#\" target='_blank'>" + ds_i.Tables[0].Rows[0]["I_Integral"].ToString() + "</a></td>");
                    }
                    else
                    {
                        sbStr.Append("<td class=\"results\">0</td>");
                    }
                    sbStr.Append("</tr>");
                    n_pdd++;
                    if (n_pdd > 13)
                    {
                        break;
                    }
                }

                sbStr.Append("</tbody>");
                sbStr.Append("</table>");
                //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
                //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
                //sbStr.Append("</div>");
                sbStr.Append("</div>");


                //双胆成绩排行
                DataSet ds_psd = get_c.GetCompOFs_P(99999, "T_state='psd' and C_win='1'");
                sbStr.Append("<div class=\"exper-content\">");
                sbStr.Append("<div class=\"exper-table-f6f6f6\">");
                sbStr.Append("<p class=\"exper-title\">双胆</p>");
                sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
                sbStr.Append("<p class=\"exper-more\">更多</p>");
                sbStr.Append("</div>");

                sbStr.Append("<table class=\"exper-table\">");
                sbStr.Append("<tbody>");
                sbStr.Append("<tr>");
                sbStr.Append("<td>名次</td>");
                sbStr.Append("<td>会员</td>");
                sbStr.Append("<td>成绩</td>");
                //sbStr.Append("<td>排名</td>");
                sbStr.Append("<td>积分</td>");
                sbStr.Append("</tr>");
                //名次
                int n_psd = 1;
                foreach (DataRow dr in ds_psd.Tables[0].Rows)
                {
                    sbStr.Append("<tr>");
                    sbStr.Append("<td><var>" + n_psd + "</var></td>");
                    sbStr.Append("<td><a href='/Person.aspx?name=" + Server.UrlEncode(dr[0].ToString()) + "'>" + dr[0].ToString() + "</a></td>");
                    //查询发布了多少次
                    DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[0].ToString() + "' and T_state='psd' order by C_issue desc");

                    sbStr.Append("<td><a href='HisAchi.aspx?name=" + dr[0].ToString() + "'>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + dr[2].ToString() + "</font></a></td>");
                    //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                    //查询积分
                    DataSet ds_i = get_i.GetList("I_name=" + "'" + dr[0].ToString() + "'" + " and I_condName='psd'");
                    //没有积分
                    if (ds_i != null && ds_i.Tables[0].Rows.Count > 0)
                    {
                        sbStr.Append("<td class=\"results\"><a href=\"#\" target='_blank'>" + ds_i.Tables[0].Rows[0]["I_Integral"].ToString() + "</a></td>");
                    }
                    else
                    {
                        sbStr.Append("<td class=\"results\">0</td>");
                    }
                    sbStr.Append("</tr>");
                    n_psd++;
                    if (n_psd > 13)
                    {
                        break;
                    }
                }

                sbStr.Append("</tbody>");
                sbStr.Append("</table>");
                //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
                //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
                //sbStr.Append("</div>");
                sbStr.Append("</div>");

                //组选1注成绩排行
                DataSet ds_pzx1z = get_c.GetCompOFs_P(99999, "T_state='pzx1z' and C_win='1'");
                sbStr.Append("<div class=\"exper-content\">");
                sbStr.Append("<div class=\"exper-table-f6f6f6\">");
                sbStr.Append("<p class=\"exper-title\">组选1注</p>");
                sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
                sbStr.Append("<p class=\"exper-more\">更多</p>");
                sbStr.Append("</div>");

                sbStr.Append("<table class=\"exper-table\">");
                sbStr.Append("<tbody>");
                sbStr.Append("<tr>");
                sbStr.Append("<td>名次</td>");
                sbStr.Append("<td>会员</td>");
                sbStr.Append("<td>成绩</td>");
                //sbStr.Append("<td>排名</td>");
                sbStr.Append("<td>积分</td>");
                sbStr.Append("</tr>");
                //名次
                int n_pzx1z = 1;
                foreach (DataRow dr in ds_pzx1z.Tables[0].Rows)
                {
                    sbStr.Append("<tr>");
                    sbStr.Append("<td><var>" + n_pzx1z + "</var></td>");
                    sbStr.Append("<td><a href='/Person.aspx?name=" + Server.UrlEncode(dr[0].ToString()) + "'>" + dr[0].ToString() + "</a></td>");
                    //查询发布了多少次
                    DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[0].ToString() + "' and T_state='pzx1z' order by C_issue desc");

                    sbStr.Append("<td><a href='HisAchi.aspx?name=" + dr[0].ToString() + "'>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + dr[3].ToString() + "</font></a></td>");
                    //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                    //查询积分
                    DataSet ds_i = get_i.GetList("I_name=" + "'" + dr[0].ToString() + "'" + " and I_condName='pzx1z'");
                    //没有积分
                    if (ds_i != null && ds_i.Tables[0].Rows.Count > 0)
                    {
                        sbStr.Append("<td class=\"results\"><a href=\"#\" target='_blank'>" + ds_i.Tables[0].Rows[0]["I_Integral"].ToString() + "</a></td>");
                    }
                    else
                    {
                        sbStr.Append("<td class=\"results\">0</td>");
                    }
                    sbStr.Append("</tr>");
                    n_pzx1z++;
                    if (n_pzx1z > 13)
                    {
                        break;
                    }
                }

                sbStr.Append("</tbody>");
                sbStr.Append("</table>");
                //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
                //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
                //sbStr.Append("</div>");
                sbStr.Append("</div>");

                //杀1码 成绩排行
                DataSet ds_ps1m = get_c.GetCompOFs_P(99999, "T_state='ps1m' and C_win='1' ");
                sbStr.Append("<div class=\"exper-content\">");
                sbStr.Append("<div class=\"exper-table-f6f6f6\">");
                sbStr.Append("<p class=\"exper-title\">杀1码</p>");
                sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
                sbStr.Append("<p class=\"exper-more\">更多</p>");
                sbStr.Append("</div>");

                sbStr.Append("<table class=\"exper-table\">");
                sbStr.Append("<tbody>");
                sbStr.Append("<tr>");
                sbStr.Append("<td>名次</td>");
                sbStr.Append("<td>会员</td>");
                sbStr.Append("<td>成绩</td>");
                //sbStr.Append("<td>排名</td>");
                sbStr.Append("<td>积分</td>");
                sbStr.Append("</tr>");
                //名次
                int n_ps1m = 1;
                foreach (DataRow dr in ds_ps1m.Tables[0].Rows)
                {
                    sbStr.Append("<tr>");
                    sbStr.Append("<td><var>" + n_ps1m + "</var></td>");
                    sbStr.Append("<td><a href='/Person.aspx?name=" + Server.UrlEncode(dr[0].ToString()) + "'>" + dr[0].ToString() + "</a></td>");
                    //查询发布了多少次
                    DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[0].ToString() + "' and T_state='ps1m' order by C_issue desc");

                    sbStr.Append("<td><a href='HisAchi.aspx?name=" + dr[0].ToString() + "'>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + dr[4].ToString() + "</font></a></td>");
                    //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                    //查询积分
                    DataSet ds_i = get_i.GetList("I_name=" + "'" + dr[0].ToString() + "'" + " and I_condName='ps1m'");
                    //没有积分
                    if (ds_i != null && ds_i.Tables[0].Rows.Count > 0)
                    {
                        sbStr.Append("<td class=\"results\"><a href=\"#\" target='_blank'>" + ds_i.Tables[0].Rows[0]["I_Integral"].ToString() + "</a></td>");
                    }
                    else
                    {
                        sbStr.Append("<td class=\"results\">0</td>");
                    }
                    sbStr.Append("</tr>");
                    n_ps1m++;
                    if (n_ps1m > 13)
                    {
                        break;
                    }
                }

                sbStr.Append("</tbody>");
                sbStr.Append("</table>");
                //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
                //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
                //sbStr.Append("</div>");
                sbStr.Append("</div>");

                //杀2码 成绩排行
                DataSet ds_ps2m = get_c.GetCompOFs_P(99999, "T_state='ps2m' and C_win='1'");
                sbStr.Append("<div class=\"exper-content\">");
                sbStr.Append("<div class=\"exper-table-f6f6f6\">");
                sbStr.Append("<p class=\"exper-title\">杀2码</p>");
                sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
                sbStr.Append("<p class=\"exper-more\">更多</p>");
                sbStr.Append("</div>");

                sbStr.Append("<table class=\"exper-table\">");
                sbStr.Append("<tbody>");
                sbStr.Append("<tr>");
                sbStr.Append("<td>名次</td>");
                sbStr.Append("<td>会员</td>");
                sbStr.Append("<td>成绩</td>");
                //sbStr.Append("<td>排名</td>");
                sbStr.Append("<td>积分</td>");
                sbStr.Append("</tr>");
                //名次
                int n_ps2m = 1;
                foreach (DataRow dr in ds_ps2m.Tables[0].Rows)
                {
                    sbStr.Append("<tr>");
                    sbStr.Append("<td><var>" + n_ps2m + "</var></td>");
                    sbStr.Append("<td><a href='/Person.aspx?name=" + Server.UrlEncode(dr[0].ToString()) + "'>" + dr[0].ToString() + "</a></td>");
                    //查询发布了多少次
                    DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[0].ToString() + "' and T_state='ps2m' order by C_issue desc");

                    sbStr.Append("<td><a href='HisAchi.aspx?name=" + dr[0].ToString() + "'>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + dr[5].ToString() + "</font></a></td>");
                    //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                    //查询积分
                    DataSet ds_i = get_i.GetList("I_name=" + "'" + dr[0].ToString() + "'" + " and I_condName='ps2m'");
                    //没有积分
                    if (ds_i != null && ds_i.Tables[0].Rows.Count > 0)
                    {
                        sbStr.Append("<td class=\"results\"><a href=\"#\" target='_blank'>" + ds_i.Tables[0].Rows[0]["I_Integral"].ToString() + "</a></td>");
                    }
                    else
                    {
                        sbStr.Append("<td class=\"results\">0</td>");
                    }
                    sbStr.Append("</tr>");
                    n_ps2m++;
                    if (n_ps2m > 13)
                    {
                        break;
                    }
                }

                sbStr.Append("</tbody>");
                sbStr.Append("</table>");
                //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
                //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
                //sbStr.Append("</div>");
                sbStr.Append("</div>");

                //独跨 成绩排行
                DataSet ds_pdk = get_c.GetCompOFs_P(99999, "T_state='pdk' and C_win='1'");
                sbStr.Append("<div class=\"exper-content\">");
                sbStr.Append("<div class=\"exper-table-f6f6f6\">");
                sbStr.Append("<p class=\"exper-title\">独跨</p>");
                sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
                sbStr.Append("<p class=\"exper-more\">更多</p>");
                sbStr.Append("</div>");

                sbStr.Append("<table class=\"exper-table\">");
                sbStr.Append("<tbody>");
                sbStr.Append("<tr>");
                sbStr.Append("<td>名次</td>");
                sbStr.Append("<td>会员</td>");
                sbStr.Append("<td>成绩</td>");
                //sbStr.Append("<td>排名</td>");
                sbStr.Append("<td>积分</td>");
                sbStr.Append("</tr>");
                //名次
                int n_pdk = 1;
                foreach (DataRow dr in ds_pdk.Tables[0].Rows)
                {
                    sbStr.Append("<tr>");
                    sbStr.Append("<td><var>" + n_pdk + "</var></td>");
                    sbStr.Append("<td><a href='/Person.aspx?name=" + Server.UrlEncode(dr[0].ToString()) + "'>" + dr[0].ToString() + "</a></td>");
                    //查询发布了多少次
                    DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[0].ToString() + "' and T_state='pdk' order by C_issue desc");

                    sbStr.Append("<td><a href='HisAchi.aspx?name=" + dr[0].ToString() + "'>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + dr[6].ToString() + "</font></a></td>");
                    //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                    //查询积分
                    DataSet ds_i = get_i.GetList("I_name=" + "'" + dr[0].ToString() + "'" + " and I_condName='pdk'");
                    //没有积分
                    if (ds_i != null && ds_i.Tables[0].Rows.Count > 0)
                    {
                        sbStr.Append("<td class=\"results\"><a href=\"#\" target='_blank'>" + ds_i.Tables[0].Rows[0]["I_Integral"].ToString() + "</a></td>");
                    }
                    else
                    {
                        sbStr.Append("<td class=\"results\">0</td>");
                    }
                    sbStr.Append("</tr>");
                    n_pdk++;
                    if (n_pdk > 13)
                    {
                        break;
                    }
                }

                sbStr.Append("</tbody>");
                sbStr.Append("</table>");
                //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
                //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
                //sbStr.Append("</div>");
                sbStr.Append("</div>");

                //独合 成绩排行
                DataSet ds_pdh = get_c.GetCompOFs_P(99999, "T_state='pdh' and C_win='1'");
                sbStr.Append("<div class=\"exper-content\">");
                sbStr.Append("<div class=\"exper-table-f6f6f6\">");
                sbStr.Append("<p class=\"exper-title\">独合</p>");
                sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
                sbStr.Append("<p class=\"exper-more\">更多</p>");
                sbStr.Append("</div>");

                sbStr.Append("<table class=\"exper-table\">");
                sbStr.Append("<tbody>");
                sbStr.Append("<tr>");
                sbStr.Append("<td>名次</td>");
                sbStr.Append("<td>会员</td>");
                sbStr.Append("<td>成绩</td>");
                //sbStr.Append("<td>排名</td>");
                sbStr.Append("<td>积分</td>");
                sbStr.Append("</tr>");
                //名次
                int n_pdh = 1;
                foreach (DataRow dr in ds_pdh.Tables[0].Rows)
                {
                    sbStr.Append("<tr>");
                    sbStr.Append("<td><var>" + n_pdh + "</var></td>");
                    sbStr.Append("<td><a href='/Person.aspx?name=" + Server.UrlEncode(dr[0].ToString()) + "'>" + dr[0].ToString() + "</a></td>");
                    //查询发布了多少次
                    DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[0].ToString() + "' and T_state='pdh' order by C_issue desc");

                    sbStr.Append("<td><a href='HisAchi.aspx?name=" + dr[0].ToString() + "'>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + dr[7].ToString() + "</font></a></td>");
                    //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                    //查询积分
                    DataSet ds_i = get_i.GetList("I_name=" + "'" + dr[0].ToString() + "'" + " and I_condName='pdh'");
                    //没有积分
                    if (ds_i != null && ds_i.Tables[0].Rows.Count > 0)
                    {
                        sbStr.Append("<td class=\"results\"><a href=\"#\" target='_blank'>" + ds_i.Tables[0].Rows[0]["I_Integral"].ToString() + "</a></td>");
                    }
                    else
                    {
                        sbStr.Append("<td class=\"results\">0</td>");
                    }
                    sbStr.Append("</tr>");
                    n_pdh++;
                    if (n_pdh > 13)
                    {
                        break;
                    }
                }

                sbStr.Append("</tbody>");
                sbStr.Append("</table>");
                //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
                //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
                //sbStr.Append("</div>");
                sbStr.Append("</div>");

                //杀1合 成绩排行
                DataSet ds_ps1h = get_c.GetCompOFs_P(99999, "T_state='ps1h' and C_win='1'");
                sbStr.Append("<div class=\"exper-content\">");
                sbStr.Append("<div class=\"exper-table-f6f6f6\">");
                sbStr.Append("<p class=\"exper-title\">杀1合</p>");
                sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
                sbStr.Append("<p class=\"exper-more\">更多</p>");
                sbStr.Append("</div>");

                sbStr.Append("<table class=\"exper-table\">");
                sbStr.Append("<tbody>");
                sbStr.Append("<tr>");
                sbStr.Append("<td>名次</td>");
                sbStr.Append("<td>会员</td>");
                sbStr.Append("<td>成绩</td>");
                //sbStr.Append("<td>排名</td>");
                sbStr.Append("<td>积分</td>");
                sbStr.Append("</tr>");
                //名次
                int n_ps1h = 1;
                foreach (DataRow dr in ds_ps1h.Tables[0].Rows)
                {
                    sbStr.Append("<tr>");
                    sbStr.Append("<td><var>" + n_ps1h + "</var></td>");
                    sbStr.Append("<td><a href='/Person.aspx?name=" + Server.UrlEncode(dr[0].ToString()) + "'>" + dr[0].ToString() + "</a></td>");
                    //查询发布了多少次
                    DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[0].ToString() + "' and T_state='ps1h' order by C_issue desc");

                    sbStr.Append("<td><a href='HisAchi.aspx?name=" + dr[0].ToString() + "'>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + dr[8].ToString() + "</font></a></td>");
                    //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                    //查询积分
                    DataSet ds_i = get_i.GetList("I_name=" + "'" + dr[0].ToString() + "'" + " and I_condName='ps1h'");
                    //没有积分
                    if (ds_i != null && ds_i.Tables[0].Rows.Count > 0)
                    {
                        sbStr.Append("<td class=\"results\"><a href=\"#\" target='_blank'>" + ds_i.Tables[0].Rows[0]["I_Integral"].ToString() + "</a></td>");
                    }
                    else
                    {
                        sbStr.Append("<td class=\"results\">0</td>");
                    }
                    sbStr.Append("</tr>");
                    n_ps1h++;
                    if (n_ps1h > 13)
                    {
                        break;
                    }
                }

                sbStr.Append("</tbody>");
                sbStr.Append("</table>");
                //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
                //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
                //sbStr.Append("</div>");
                sbStr.Append("</div>");

                //5*5*5定位 成绩排行
                DataSet ds_p5dw = get_c.GetCompOFs_P(99999, "T_state='p5dw' and C_win='1'");
                sbStr.Append("<div class=\"exper-content\">");
                sbStr.Append("<div class=\"exper-table-f6f6f6\">");
                sbStr.Append("<p class=\"exper-title\">5*5*5定位</p>");
                sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
                sbStr.Append("<p class=\"exper-more\">更多</p>");
                sbStr.Append("</div>");

                sbStr.Append("<table class=\"exper-table\">");
                sbStr.Append("<tbody>");
                sbStr.Append("<tr>");
                sbStr.Append("<td>名次</td>");
                sbStr.Append("<td>会员</td>");
                sbStr.Append("<td>成绩</td>");
                //sbStr.Append("<td>排名</td>");
                sbStr.Append("<td>积分</td>");
                sbStr.Append("</tr>");
                //名次
                int n_p5dw = 1;
                foreach (DataRow dr in ds_p5dw.Tables[0].Rows)
                {
                    sbStr.Append("<tr>");
                    sbStr.Append("<td><var>" + n_p5dw + "</var></td>");
                    sbStr.Append("<td><a href='/Person.aspx?name=" + Server.UrlEncode(dr[0].ToString()) + "'>" + dr[0].ToString() + "</a></td>");
                    //查询发布了多少次
                    DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[0].ToString() + "' and T_state='p5dw' order by C_issue desc");

                    sbStr.Append("<td><a href='HisAchi.aspx?name=" + dr[0].ToString() + "'>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + dr[9].ToString() + "</font></a></td>");
                    //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                    //查询积分
                    DataSet ds_i = get_i.GetList("I_name=" + "'" + dr[0].ToString() + "'" + " and I_condName='p5dw'");
                    //没有积分
                    if (ds_i != null && ds_i.Tables[0].Rows.Count > 0)
                    {
                        sbStr.Append("<td class=\"results\"><a href=\"#\" target='_blank'>" + ds_i.Tables[0].Rows[0]["I_Integral"].ToString() + "</a></td>");
                    }
                    else
                    {
                        sbStr.Append("<td class=\"results\">0</td>");
                    }
                    sbStr.Append("</tr>");
                    n_p5dw++;
                    if (n_p5dw > 13)
                    {
                        break;
                    }
                }

                sbStr.Append("</tbody>");
                sbStr.Append("</table>");
                //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
                //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
                //sbStr.Append("</div>");
                sbStr.Append("</div>");

                //3*3*3定位 成绩排行
                DataSet ds_p3dw = get_c.GetCompOFs_P(99999, "T_state='p3dw' and C_win='1'");
                sbStr.Append("<div class=\"exper-content\">");
                sbStr.Append("<div class=\"exper-table-f6f6f6\">");
                sbStr.Append("<p class=\"exper-title\">3*3*3定位</p>");
                sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
                sbStr.Append("<p class=\"exper-more\">更多</p>");
                sbStr.Append("</div>");

                sbStr.Append("<table class=\"exper-table\">");
                sbStr.Append("<tbody>");
                sbStr.Append("<tr>");
                sbStr.Append("<td>名次</td>");
                sbStr.Append("<td>会员</td>");
                sbStr.Append("<td>成绩</td>");
                //sbStr.Append("<td>排名</td>");
                sbStr.Append("<td>积分</td>");
                sbStr.Append("</tr>");
                //名次
                int n_p3dw = 1;
                foreach (DataRow dr in ds_p3dw.Tables[0].Rows)
                {
                    sbStr.Append("<tr>");
                    sbStr.Append("<td><var>" + n_p3dw + "</var></td>");
                    sbStr.Append("<td><a href='/Person.aspx?name=" + Server.UrlEncode(dr[0].ToString()) + "'>" + dr[0].ToString() + "</a></td>");
                    //查询发布了多少次
                    DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[0].ToString() + "' and T_state='p3dw' order by C_issue desc");

                    sbStr.Append("<td><a href='HisAchi.aspx?name=" + dr[0].ToString() + "'>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + dr[10].ToString() + "</font></a></td>");
                    //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                    //查询积分
                    DataSet ds_i = get_i.GetList("I_name=" + "'" + dr[0].ToString() + "'" + " and I_condName='p3dw'");
                    //没有积分
                    if (ds_i != null && ds_i.Tables[0].Rows.Count > 0)
                    {
                        sbStr.Append("<td class=\"results\"><a href=\"#\" target='_blank'>" + ds_i.Tables[0].Rows[0]["I_Integral"].ToString() + "</a></td>");
                    }
                    else
                    {
                        sbStr.Append("<td class=\"results\">0</td>");
                    }
                    sbStr.Append("</tr>");
                    n_p3dw++;
                    if (n_p3dw > 13)
                    {
                        break;
                    }
                }

                sbStr.Append("</tbody>");
                sbStr.Append("</table>");
                //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
                //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
                //sbStr.Append("</div>");
                sbStr.Append("</div>");


                //直选1注 成绩排行
                DataSet ds_pzx = get_c.GetCompOFs_P(99999, "T_state='pzx' and C_win='1'");
                sbStr.Append("<div class=\"exper-content\">");
                sbStr.Append("<div class=\"exper-table-f6f6f6\">");
                sbStr.Append("<p class=\"exper-title\">直选1注</p>");
                sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
                sbStr.Append("<p class=\"exper-more\">更多</p>");
                sbStr.Append("</div>");

                sbStr.Append("<table class=\"exper-table\">");
                sbStr.Append("<tbody>");
                sbStr.Append("<tr>");
                sbStr.Append("<td>名次</td>");
                sbStr.Append("<td>会员</td>");
                sbStr.Append("<td>成绩</td>");
                //sbStr.Append("<td>排名</td>");
                sbStr.Append("<td>积分</td>");
                sbStr.Append("</tr>");
                //名次
                int n_pzx = 1;
                foreach (DataRow dr in ds_pzx.Tables[0].Rows)
                {
                    sbStr.Append("<tr>");
                    sbStr.Append("<td><var>" + n_pzx + "</var></td>");
                    sbStr.Append("<td><a href='/Person.aspx?name=" + Server.UrlEncode(dr[0].ToString()) + "'>" + dr[0].ToString() + "</a></td>");
                    //查询发布了多少次
                    DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[0].ToString() + "' and T_state='pzx' order by C_issue desc");

                    sbStr.Append("<td><a href='HisAchi.aspx?name=" + dr[0].ToString() + "'>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + dr[11].ToString() + "</font></a></td>");
                    //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                    //查询积分
                    DataSet ds_i = get_i.GetList("I_name=" + "'" + dr[0].ToString() + "'" + " and I_condName='pzx'");
                    //没有积分
                    if (ds_i != null && ds_i.Tables[0].Rows.Count > 0)
                    {
                        sbStr.Append("<td class=\"results\"><a href=\"#\" target='_blank'>" + ds_i.Tables[0].Rows[0]["I_Integral"].ToString() + "</a></td>");
                    }
                    else
                    {
                        sbStr.Append("<td class=\"results\">0</td>");
                    }
                    sbStr.Append("</tr>");
                    n_pzx++;
                    if (n_pzx > 13)
                    {
                        break;
                    }
                }

                sbStr.Append("</tbody>");
                sbStr.Append("</table>");
                //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
                //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
                //sbStr.Append("</div>");
                sbStr.Append("</div>");

                //5码 成绩排行
                DataSet ds_p5m = get_c.GetCompOFs_P(99999, "T_state='p5m' and C_win='1'");
                sbStr.Append("<div class=\"exper-content\">");
                sbStr.Append("<div class=\"exper-table-f6f6f6\">");
                sbStr.Append("<p class=\"exper-title\">5码</p>");
                sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
                sbStr.Append("<p class=\"exper-more\">更多</p>");
                sbStr.Append("</div>");

                sbStr.Append("<table class=\"exper-table\">");
                sbStr.Append("<tbody>");
                sbStr.Append("<tr>");
                sbStr.Append("<td>名次</td>");
                sbStr.Append("<td>会员</td>");
                sbStr.Append("<td>成绩</td>");
                //sbStr.Append("<td>排名</td>");
                sbStr.Append("<td>积分</td>");
                sbStr.Append("</tr>");
                //名次
                int n_p5m = 1;
                foreach (DataRow dr in ds_p5m.Tables[0].Rows)
                {
                    sbStr.Append("<tr>");
                    sbStr.Append("<td><var>" + n_p5m + "</var></td>");
                    sbStr.Append("<td><a href='/Person.aspx?name=" + Server.UrlEncode(dr[0].ToString()) + "'>" + dr[0].ToString() + "</a></td>");
                    //查询发布了多少次
                    DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[0].ToString() + "' and T_state='p5m' order by C_issue desc");

                    sbStr.Append("<td><a href='HisAchi.aspx?name=" + dr[0].ToString() + "'>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + dr[22].ToString() + "</font></a></td>");
                    //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                    //查询积分
                    DataSet ds_i = get_i.GetList("I_name=" + "'" + dr[0].ToString() + "'" + " and I_condName='p5m'");
                    //没有积分
                    if (ds_i != null && ds_i.Tables[0].Rows.Count > 0)
                    {
                        sbStr.Append("<td class=\"results\"><a href=\"#\" target='_blank'>" + ds_i.Tables[0].Rows[0]["I_Integral"].ToString() + "</a></td>");
                    }
                    else
                    {
                        sbStr.Append("<td class=\"results\">0</td>");
                    }
                    sbStr.Append("</tr>");
                    n_p5m++;
                    if (n_p5m > 13)
                    {
                        break;
                    }

                }

                sbStr.Append("</tbody>");
                sbStr.Append("</table>");
                //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
                //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
                //sbStr.Append("</div>");
                sbStr.Append("</div>");
                #endregion
            }
            catch (Exception ex)
            {
                Pbzx.Common.ErrorLog.WriteLog(ex);
            }
            return HttpContext.Current.Server.HtmlEncode(sbStr.ToString());
        }
        #endregion


        #region 双色球 3D 排列3 积分榜
        /// <summary>
        /// 积分榜 绑定数据 -------双色球条件积分榜
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string IntegralTable()
        {
            Pbzx.BLL.Challenge_integral get_i = new Pbzx.BLL.Challenge_integral();
            Pbzx.BLL.Challenge_Cinfo get_c = new Pbzx.BLL.Challenge_Cinfo();

            StringBuilder sbStr = new StringBuilder();
            //sbStr.Append("<div class=\"exper-content\">");
            //sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            //sbStr.Append("<p class=\"exper-title\">人气榜</p>");
            //sbStr.Append("<p class=\"txt-blue\"></p>");
            //sbStr.Append("<p class=\"exper-more\"> 更多</p>");
            //sbStr.Append("</div>");
            //sbStr.Append("<table class=\"exper-table\">");
            //sbStr.Append("<tbody><tr>");
            //sbStr.Append("<td>名次</td>");
            //sbStr.Append("<td>会员</td>");
            //sbStr.Append("<td>人气</td>");
            //sbStr.Append("<td> 详情</td>");
            //sbStr.Append("</tr>");

            ////查询会员
            //sbStr.Append("<tr>");
            //sbStr.Append("<td><var>1</var></td>");
            //sbStr.Append("<td><a href=\"#\">湛蓝</a></td>");
            //sbStr.Append("<td><font color=\"#b21\">463↓</font></td>");
            //sbStr.Append("<td><a href=\"#\" class=\"enter\" target=\"_blank\"><img src=\"images/cv.png\"></a></td>");
            //sbStr.Append("</tr></tbody>");

            //sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a> <a href=\"#\"> <img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            //sbStr.Append("</div>");

            //红球3胆成绩排行
            DataSet ds_hq3d = get_i.RankSSq("v_hq3d", "1=1"); 
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">红球3胆</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>积分</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>成绩</td>");
            sbStr.Append("</tr>");
            //名次
            int n_win = 1;
            foreach (DataRow dr in ds_hq3d.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_win + "</var></td>");
                sbStr.Append("<td><a href='/Person.aspx?name=" + Server.UrlEncode(dr[1].ToString()) + "'>" + dr[1].ToString() + "</a></td>");
                sbStr.Append("<td class=\"results\">" + dr[4].ToString() + "</td>");

                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[1].ToString() + "' and T_state='hq3d' order by C_issue desc");

                //中奖次数
                DataSet ds_win = get_c.GetCompOFs("T_state='hq3d' and C_lottID='3' and C_name=" + "'" + dr[1].ToString() + "'"+" and C_win=1");
                if (ds_win != null && ds_win.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + ds_win.Tables[0].Rows[0]["hq3d"].ToString() + "</font></td>");
                }
                else
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">0</font></td>");
                }
                sbStr.Append("</tr>");
                n_win++;
                if (n_win > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");


            //红球6胆成绩排行
            DataSet ds_hq6d = get_i.RankSSq("v_hq6d", "1=1"); 
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">红球6胆</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>积分</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>成绩</td>");
            sbStr.Append("</tr>");
            //名次
            int n_hq6d = 1;
            foreach (DataRow dr in ds_hq6d.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_hq6d + "</var></td>");
                sbStr.Append("<td><a href='/Person.aspx?name=" + Server.UrlEncode(dr[1].ToString()) + "'>" + dr[1].ToString() + "</a></td>");
                sbStr.Append("<td class=\"results\">" + dr[4].ToString() + "</td>");

                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[1].ToString() + "' and T_state='hq6d' order by C_issue desc");

                //中奖次数
                DataSet ds_win = get_c.GetCompOFs("T_state='hq6d' and C_lottID='3' and C_name=" + "'" + dr[1].ToString() + "'"+" and C_win=1");

                if (ds_win != null && ds_win.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + ds_win.Tables[0].Rows[0]["hq6d"].ToString() + "</font></td>");
                }
                else
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">0</font></td>");
                }

                sbStr.Append("</tr>");
                n_hq6d++;
                if (n_hq6d > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");

            //杀3红球成绩排行
            DataSet ds_s3hq = get_i.RankSSq("v_s3hq", "1=1"); 
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">杀3红球</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>积分</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>成绩</td>");
            sbStr.Append("</tr>");
            //名次
            int n_s3hq = 1;
            foreach (DataRow dr in ds_s3hq.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_s3hq + "</var></td>");
                sbStr.Append("<td><a href='/Person.aspx?name=" + Server.UrlEncode(dr[1].ToString()) + "'>" + dr[1].ToString() + "</a></td>");
                sbStr.Append("<td class=\"results\">" + dr[4].ToString() + "</td>");

                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[1].ToString() + "' and T_state='s3hq' order by C_issue desc");

                //中奖次数
                DataSet ds_win = get_c.GetCompOFs("T_state='s3hq' and C_lottID='3' and C_name=" + "'" + dr[1].ToString() + "'"+" and C_win=1 ");
                if (ds_win != null && ds_win.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + ds_win.Tables[0].Rows[0]["s3hq"].ToString() + "</font></td>");
                }
                else
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">0</font></td>");
                }

                sbStr.Append("</tr>");
                n_s3hq++;
                if (n_s3hq > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");

            //杀6红球成绩排行
            DataSet ds_s6hq = get_i.RankSSq( "v_s6hq", "1=1"); 
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">杀6红球</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>积分</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>成绩</td>");
            sbStr.Append("</tr>");
            //名次
            int n_s6hq = 1;
            foreach (DataRow dr in ds_s6hq.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_s6hq + "</var></td>");
                sbStr.Append("<td><a href='/Person.aspx?name=" + Server.UrlEncode(dr[1].ToString()) + "'>" + dr[1].ToString() + "</a></td>");
                sbStr.Append("<td class=\"results\">" + dr[4].ToString() + "</td>");

                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[1].ToString() + "' and T_state='s6hq' order by C_issue desc");

                //中奖次数
                DataSet ds_win = get_c.GetCompOFs("T_state='s6hq' and C_lottID='3' and C_name=" + "'" + dr[1].ToString() + "'" + " and C_win=1 ");
                if (ds_win != null && ds_win.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + ds_win.Tables[0].Rows[0]["s6hq"].ToString() + "</font></td>");
                }
                else
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">0</font></td>");
                }

                sbStr.Append("</tr>");
                n_s6hq++;
                if (n_s6hq > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");

            //蓝球1胆成绩排行
            DataSet ds_lq1d = get_i.RankSSq("v_lq1d", "1=1"); 
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">蓝球1胆</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>积分</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>成绩</td>");
            sbStr.Append("</tr>");
            //名次
            int n_lq1d = 1;
            foreach (DataRow dr in ds_lq1d.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_lq1d + "</var></td>");
                sbStr.Append("<td><a href='/Person.aspx?name=" + Server.UrlEncode(dr[1].ToString()) + "'>" + dr[1].ToString() + "</a></td>");
                sbStr.Append("<td class=\"results\">" + dr[4].ToString() + "</td>");

                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[1].ToString() + "' and T_state='lq1d' order by C_issue desc");

                //中奖次数
                DataSet ds_win = get_c.GetCompOFs("T_state='lq1d' and C_lottID='3' and C_name=" + "'" + dr[1].ToString() + "'" + " and C_win=1 ");
                if (ds_win != null && ds_win.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + ds_win.Tables[0].Rows[0]["lq1d"].ToString() + "</font></td>");
                }
                else
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">0</font></td>");
                }

                sbStr.Append("</tr>");
                n_lq1d++;
                if (n_lq1d > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");

            //蓝球3胆成绩排行
            DataSet ds_lq3d = get_i.RankSSq("v_lq3d", "1=1"); 
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">蓝球3胆</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>积分</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>成绩</td>");
            sbStr.Append("</tr>");
            //名次
            int n_lq3d = 1;
            foreach (DataRow dr in ds_lq3d.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_lq3d + "</var></td>");
                sbStr.Append("<td><a href='/Person.aspx?name=" + Server.UrlEncode(dr[1].ToString()) + "'>" + dr[1].ToString() + "</a></td>");
                sbStr.Append("<td class=\"results\">" + dr[4].ToString() + "</td>");

                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询发布了多少次 
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[1].ToString() + "' and T_state='lq3d' order by C_issue desc");

                //中奖次数
                DataSet ds_win = get_c.GetCompOFs("T_state='lq3d' and C_lottID='3' and C_name=" + "'" + dr[1].ToString() + "'" + " and C_win=1 ");
                if (ds_win != null && ds_win.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + ds_win.Tables[0].Rows[0]["lq3d"].ToString() + "</font></td>");
                }
                else
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">0</font></td>");
                }

                sbStr.Append("</tr>");
                n_lq3d++;
                if (n_lq3d > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");

            //杀3蓝球 成绩排行
            DataSet ds_s3lq = get_i.RankSSq("v_s3lq", "1=1"); 
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">杀3蓝球</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>积分</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>成绩</td>");
            sbStr.Append("</tr>");
            //名次
            int n_s3lq = 1;
            foreach (DataRow dr in ds_s6hq.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_s3lq + "</var></td>");
                sbStr.Append("<td><a href='/Person.aspx?name=" + Server.UrlEncode(dr[1].ToString()) + "'>" + dr[1].ToString() + "</a></td>");
                sbStr.Append("<td class=\"results\">" + dr[4].ToString() + "</td>");

                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[1].ToString() + "' and T_state='s3lq' order by C_issue desc");

                //中奖次数
                DataSet ds_win = get_c.GetCompOFs("T_state='s3lq' and C_lottID='3' and C_name=" + "'" + dr[1].ToString() + "'" + " and C_win=1 ");
                if (ds_win != null && ds_win.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + ds_win.Tables[0].Rows[0]["s3lq"].ToString() + "</font></td>");
                }
                else
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">0</font></td>");
                }

                sbStr.Append("</tr>");
                n_s3lq++;
                if (n_s3lq > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");

            //杀6蓝球成绩排行
            DataSet ds_s6lq = get_i.RankSSq("v_s6lq", "1=1"); 
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">杀6蓝球</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>积分</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>成绩</td>");
            sbStr.Append("</tr>");
            //名次
            int n_s6lq = 1;
            foreach (DataRow dr in ds_s6lq.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_s6lq + "</var></td>");
                sbStr.Append("<td><a href='/Person.aspx?name=" + Server.UrlEncode(dr[1].ToString()) + "'>" + dr[1].ToString() + "</a></td>");
                sbStr.Append("<td class=\"results\">" + dr[4].ToString() + "</td>");

                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[1].ToString() + "' and T_state='s6lq' order by C_issue desc");

                //中奖次数
                DataSet ds_win = get_c.GetCompOFs("T_state='s6lq' and C_lottID='3' and C_name=" + "'" + dr[1].ToString() + "'" + " and C_win=1 ");
                if (ds_win != null && ds_win.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + ds_win.Tables[0].Rows[0]["s6lq"].ToString() + "</font></td>");
                }
                else
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">0</font></td>");
                }

                sbStr.Append("</tr>");
                n_s6lq++;
                if (n_s6lq > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");

            //12红+3蓝 成绩排行
            DataSet ds_h3l = get_i.RankSSq("v_h3l", "1=1"); 
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">12红+3蓝</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>积分</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>成绩</td>");
            sbStr.Append("</tr>");
            //名次
            int n_h3l = 1;
            foreach (DataRow dr in ds_h3l.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_h3l + "</var></td>");
                sbStr.Append("<td><a href='/Person.aspx?name=" + Server.UrlEncode(dr[1].ToString()) + "'>" + dr[1].ToString() + "</a></td>");
                sbStr.Append("<td class=\"results\">" + dr[4].ToString() + "</td>");

                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[1].ToString() + "' and T_state='h3l' order by C_issue desc");

                //中奖次数
                DataSet ds_win = get_c.GetCompOFs("T_state='h3l' and C_lottID='3' and C_name=" + "'" + dr[1].ToString() + "'" + " and C_win=1 ");
                if (ds_win != null && ds_win.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + ds_win.Tables[0].Rows[0]["h3l"].ToString() + "</font></td>");
                }
                else
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">0</font></td>");
                }

                sbStr.Append("</tr>");
                n_h3l++;
                if (n_h3l > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");

            //9红+2蓝 成绩排行
            DataSet ds_h2l = get_i.RankSSq("v_h2l", "1=1"); 
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">9红+2蓝</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>积分</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>成绩</td>");
            sbStr.Append("</tr>");
            //名次
            int n_h2l = 1;
            foreach (DataRow dr in ds_h2l.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_h2l + "</var></td>");
                sbStr.Append("<td><a href='/Person.aspx?name=" + Server.UrlEncode(dr[1].ToString()) + "'>" + dr[1].ToString() + "</a></td>");
                sbStr.Append("<td class=\"results\">" + dr[4].ToString() + "</td>");

                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[1].ToString() + "' and T_state='h2l' order by C_issue desc");

                //中奖次数
                DataSet ds_win = get_c.GetCompOFs("T_state='h2l' and C_lottID='3' and C_name=" + "'" + dr[1].ToString() + "'" + " and C_win=1 ");
                if (ds_win != null && ds_win.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + ds_win.Tables[0].Rows[0]["h2l"].ToString() + "</font></td>");
                }
                else
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">0</font></td>");
                }

                sbStr.Append("</tr>");
                n_h2l++;
                if (n_h2l > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");

            return HttpContext.Current.Server.HtmlEncode(sbStr.ToString());
        }


        /// <summary>
        /// 积分榜 绑定数据 -------3D 条件积分榜
        /// </summary>
        /// <param name="lottid">彩种Id</param>
        /// <returns></returns>
        [WebMethod]
        public string IntegralTable_d()
        {
            Pbzx.BLL.Challenge_integral get_i = new Pbzx.BLL.Challenge_integral();
            Pbzx.BLL.Challenge_Cinfo get_c = new Pbzx.BLL.Challenge_Cinfo();

            StringBuilder sbStr = new StringBuilder();
            //sbStr.Append("<div class=\"exper-content\">");
            //sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            //sbStr.Append("<p class=\"exper-title\">人气榜</p>");
            //sbStr.Append("<p class=\"txt-blue\"></p>");
            //sbStr.Append("<p class=\"exper-more\"> 更多</p>");
            //sbStr.Append("</div>");
            //sbStr.Append("<table class=\"exper-table\">");
            //sbStr.Append("<tbody><tr>");
            //sbStr.Append("<td>名次</td>");
            //sbStr.Append("<td>会员</td>");
            //sbStr.Append("<td>人气</td>");
            //sbStr.Append("<td> 详情</td>");
            //sbStr.Append("</tr>");

            ////查询会员
            //sbStr.Append("<tr>");
            //sbStr.Append("<td><var>1</var></td>");
            //sbStr.Append("<td><a href=\"#\">湛蓝</a></td>");
            //sbStr.Append("<td><font color=\"#b21\">463↓</font></td>");
            //sbStr.Append("<td><a href=\"#\" class=\"enter\" target=\"_blank\"><img src=\"images/cv.png\"></a></td>");
            //sbStr.Append("</tr></tbody>");

            //sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a> <a href=\"#\"> <img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            //sbStr.Append("</div>");

            //独胆 积分排行
            DataSet ds_dd = get_i.RankSSq("v_dd", "1=1");
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">独胆</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>积分</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>成绩</td>");
            sbStr.Append("</tr>");
            //名次
            int n_win = 1;
            foreach (DataRow dr in ds_dd.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_win + "</var></td>");
                sbStr.Append("<td><a href='/Person.aspx?name=" + Server.UrlEncode(dr[1].ToString()) + "'>" + dr[1].ToString() + "</a></td>");
                sbStr.Append("<td class=\"results\">" + dr[4].ToString() + "</td>");

                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[1].ToString() + "' and T_state='dd' order by C_issue desc");

                //中奖次数
                DataSet ds_win = get_c.GetCompOFs("T_state='dd' and C_lottID='1' and C_name=" + "'" + dr[1].ToString() + "'" + " and C_win=1");
                if (ds_win != null && ds_win.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + ds_win.Tables[0].Rows[0]["dd"].ToString() + "</font></td>");
                }
                else
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">0</font></td>");
                }
                sbStr.Append("</tr>");
                n_win++;
                if (n_win > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");


            //双胆  积分排行
            DataSet ds_sd = get_i.RankSSq("v_sd", "1=1");
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">双胆</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>积分</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>成绩</td>");
            sbStr.Append("</tr>");
            //名次
            int n_sd = 1;
            foreach (DataRow dr in ds_sd.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_sd + "</var></td>");
                sbStr.Append("<td><a href='/Person.aspx?name=" + Server.UrlEncode(dr[1].ToString()) + "'>" + dr[1].ToString() + "</a></td>");
                sbStr.Append("<td class=\"results\">" + dr[4].ToString() + "</td>");

                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[1].ToString() + "' and T_state='sd' order by C_issue desc");

                //中奖次数
                DataSet ds_win = get_c.GetCompOFs("T_state='sd' and C_lottID='1' and C_name=" + "'" + dr[1].ToString() + "'" + " and C_win=1");

                if (ds_win != null && ds_win.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + ds_win.Tables[0].Rows[0]["sd"].ToString() + "</font></td>");
                }
                else
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">0</font></td>");
                }

                sbStr.Append("</tr>");
                n_sd++;
                if (n_sd > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");

            //组选1注 积分排行
            DataSet ds_zx1z = get_i.RankSSq("v_zx1z", "1=1");
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">组选1注</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>积分</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>成绩</td>");
            sbStr.Append("</tr>");
            //名次
            int n_zx1z = 1;
            foreach (DataRow dr in ds_zx1z.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_zx1z + "</var></td>");
                sbStr.Append("<td><a href='/Person.aspx?name=" + Server.UrlEncode(dr[1].ToString()) + "'>" + dr[1].ToString() + "</a></td>");
                sbStr.Append("<td class=\"results\">" + dr[4].ToString() + "</td>");

                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[1].ToString() + "' and T_state='zx1z' order by C_issue desc");

                //中奖次数
                DataSet ds_win = get_c.GetCompOFs("T_state='zx1z' and C_lottID='1' and C_name=" + "'" + dr[1].ToString() + "'" + " and C_win=1");
                if (ds_win != null && ds_win.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + ds_win.Tables[0].Rows[0]["zx1z"].ToString() + "</font></td>");
                }
                else
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">0</font></td>");
                }

                sbStr.Append("</tr>");
                n_zx1z++;
                if (n_zx1z > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");

            //杀1码 积分排行
            DataSet ds_s1m = get_i.RankSSq("v_s1m", "1=1");
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">杀1码</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>积分</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>成绩</td>");
            sbStr.Append("</tr>");
            //名次
            int n_s1m = 1;
            foreach (DataRow dr in ds_s1m.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_s1m + "</var></td>");
                sbStr.Append("<td><a href='/Person.aspx?name=" + Server.UrlEncode(dr[1].ToString()) + "'>" + dr[1].ToString() + "</a></td>");
                sbStr.Append("<td class=\"results\">" + dr[4].ToString() + "</td>");

                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[1].ToString() + "' and T_state='s1m' order by C_issue desc");

                //中奖次数
                DataSet ds_win = get_c.GetCompOFs("T_state='s1m' and C_lottID='1' and C_name=" + "'" + dr[1].ToString() + "'" + " and C_win=1");
                if (ds_win != null && ds_win.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + ds_win.Tables[0].Rows[0]["s1m"].ToString() + "</font></td>");
                }
                else
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">0</font></td>");
                }

                sbStr.Append("</tr>");
                n_s1m++;
                if (n_s1m > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");

            //杀2码 积分排行
            DataSet ds_s2m = get_i.RankSSq("v_s2m", "1=1");
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">杀2码</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>积分</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>成绩</td>");
            sbStr.Append("</tr>");
            //名次
            int n_s2m = 1;
            foreach (DataRow dr in ds_s2m.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_s2m + "</var></td>");
                sbStr.Append("<td><a href='/Person.aspx?name=" + Server.UrlEncode(dr[1].ToString()) + "'>" + dr[1].ToString() + "</a></td>");
                sbStr.Append("<td class=\"results\">" + dr[4].ToString() + "</td>");

                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[1].ToString() + "' and T_state='s2m' order by C_issue desc");

                //中奖次数
                DataSet ds_win = get_c.GetCompOFs("T_state='s2m' and C_lottID='1' and C_name=" + "'" + dr[1].ToString() + "'" + " and C_win=1");
                if (ds_win != null && ds_win.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + ds_win.Tables[0].Rows[0]["s2m"].ToString() + "</font></td>");
                }
                else
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">0</font></td>");
                }

                sbStr.Append("</tr>");
                n_s2m++;
                if (n_s2m > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");

            //独跨 成绩排行
            DataSet ds_dk = get_i.RankSSq("v_dk", "1=1");
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">独跨</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>积分</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>成绩</td>");
            sbStr.Append("</tr>");
            //名次
            int n_dk = 1;
            foreach (DataRow dr in ds_dk.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_dk + "</var></td>");
                sbStr.Append("<td><a href='/Person.aspx?name=" + Server.UrlEncode(dr[1].ToString()) + "'>" + dr[1].ToString() + "</a></td>");
                sbStr.Append("<td class=\"results\">" + dr[4].ToString() + "</td>");

                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[1].ToString() + "' and T_state='dk' order by C_issue desc");

                //中奖次数
                DataSet ds_win = get_c.GetCompOFs("T_state='dk' and C_lottID='1' and C_name=" + "'" + dr[1].ToString() + "'" + " and C_win=1");
                if (ds_win != null && ds_win.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + ds_win.Tables[0].Rows[0]["dk"].ToString() + "</font></td>");
                }
                else
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">0</font></td>");
                }

                sbStr.Append("</tr>");
                n_dk++;
                if (n_dk > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");

            //独合 成绩排行
            DataSet ds_dh = get_i.RankSSq("v_dh", "1=1");
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">独合</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>积分</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>成绩</td>");
            sbStr.Append("</tr>");
            //名次
            int n_dh = 1;
            foreach (DataRow dr in ds_dh.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_dh + "</var></td>");
                sbStr.Append("<td><a href='/Person.aspx?name=" + Server.UrlEncode(dr[1].ToString()) + "'>" + dr[1].ToString() + "</a></td>");
                sbStr.Append("<td class=\"results\">" + dr[4].ToString() + "</td>");

                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[1].ToString() + "' and T_state='dh' order by C_issue desc");

                //中奖次数
                DataSet ds_win = get_c.GetCompOFs("T_state='dh' and C_lottID='1' and C_name=" + "'" + dr[1].ToString() + "'" + " and C_win=1");
                if (ds_win != null && ds_win.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + ds_win.Tables[0].Rows[0]["dh"].ToString() + "</font></td>");
                }
                else
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">0</font></td>");
                }

                sbStr.Append("</tr>");
                n_dh++;
                if (n_dh > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");

            //杀1合 积分排行
            DataSet ds_s1h = get_i.RankSSq("v_s1h", "1=1");
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">杀6蓝球</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>积分</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>成绩</td>");
            sbStr.Append("</tr>");
            //名次
            int n_s1h = 1;
            foreach (DataRow dr in ds_s1h.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_s1h + "</var></td>");
                sbStr.Append("<td><a href='/Person.aspx?name=" + Server.UrlEncode(dr[1].ToString()) + "'>" + dr[1].ToString() + "</a></td>");
                sbStr.Append("<td class=\"results\">" + dr[4].ToString() + "</td>");

                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[1].ToString() + "' and T_state='s1h' order by C_issue desc");

                //中奖次数
                DataSet ds_win = get_c.GetCompOFs("T_state='s1h' and C_lottID='1' and C_name=" + "'" + dr[1].ToString() + "'" + " and C_win=1");
                if (ds_win != null && ds_win.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + ds_win.Tables[0].Rows[0]["s1h"].ToString() + "</font></td>");
                }
                else
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">0</font></td>");
                }

                sbStr.Append("</tr>");
                n_s1h++;
                if (n_s1h > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");

            //5*5*5定位 积分排行
            DataSet ds_5dw = get_i.RankSSq("v_5dw", "1=1");
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">5*5*5定位</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>积分</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>成绩</td>");
            sbStr.Append("</tr>");
            //名次
            int n_5dw = 1;
            foreach (DataRow dr in ds_5dw.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_5dw + "</var></td>");
                sbStr.Append("<td><a href='/Person.aspx?name=" + Server.UrlEncode(dr[1].ToString()) + "'>" + dr[1].ToString() + "</a></td>");
                sbStr.Append("<td class=\"results\">" + dr[4].ToString() + "</td>");

                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[1].ToString() + "' and T_state='5dw' order by C_issue desc");

                //中奖次数
                DataSet ds_win = get_c.GetCompOFs("T_state='5dw' and C_lottID='1' and C_name=" + "'" + dr[1].ToString() + "'" + " and C_win=1");
                if (ds_win != null && ds_win.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + ds_win.Tables[0].Rows[0]["5dw"].ToString() + "</font></td>");
                }
                else
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">0</font></td>");
                }

                sbStr.Append("</tr>");
                n_5dw++;
                if (n_5dw > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");

            //3*3*3定位 积分排行
            DataSet ds_3dw = get_i.RankSSq("v_3dw", "1=1");
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">3*3*3定位</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>积分</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>成绩</td>");
            sbStr.Append("</tr>");
            //名次
            int n_3dw = 1;
            foreach (DataRow dr in ds_3dw.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_3dw + "</var></td>");
                sbStr.Append("<td><a href='/Person.aspx?name=" + Server.UrlEncode(dr[1].ToString()) + "'>" + dr[1].ToString() + "</a></td>");
                sbStr.Append("<td class=\"results\">" + dr[4].ToString() + "</td>");

                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[1].ToString() + "' and T_state='3dw' order by C_issue desc");

                //中奖次数
                DataSet ds_win = get_c.GetCompOFs("T_state='3dw' and C_lottID='1' and C_name=" + "'" + dr[1].ToString() + "'" + " and C_win=1");
                if (ds_win != null && ds_win.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + ds_win.Tables[0].Rows[0]["3dw"].ToString() + "</font></td>");
                }
                else
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">0</font></td>");
                }

                sbStr.Append("</tr>");
                n_3dw++;
                if (n_3dw > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");

            //直选1注 积分排行
            DataSet ds_zx = get_i.RankSSq("v_zx", "1=1");
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">直选1注</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>积分</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>成绩</td>");
            sbStr.Append("</tr>");
            //名次
            int n_zx = 1;
            foreach (DataRow dr in ds_zx.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_zx + "</var></td>");
                sbStr.Append("<td><a href='/Person.aspx?name=" + Server.UrlEncode(dr[1].ToString()) + "'>" + dr[1].ToString() + "</a></td>");
                sbStr.Append("<td class=\"results\">" + dr[4].ToString() + "</td>");

                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[1].ToString() + "' and T_state='zx' order by C_issue desc");

                //中奖次数
                DataSet ds_win = get_c.GetCompOFs("T_state='zx' and C_lottID='1' and C_name=" + "'" + dr[1].ToString() + "'" + " and C_win=1");
                if (ds_win != null && ds_win.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + ds_win.Tables[0].Rows[0]["zx"].ToString() + "</font></td>");
                }
                else
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">0</font></td>");
                }

                sbStr.Append("</tr>");
                n_zx++;
                if (n_zx > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");

            //5码 积分排行
            DataSet ds_m = get_i.RankSSq("v_m", "1=1");
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">5码</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>积分</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>成绩</td>");
            sbStr.Append("</tr>");
            //名次
            int n_m = 1;
            foreach (DataRow dr in ds_m.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_m + "</var></td>");
                sbStr.Append("<td><a href='/Person.aspx?name=" + Server.UrlEncode(dr[1].ToString()) + "'>" + dr[1].ToString() + "</a></td>");
                sbStr.Append("<td class=\"results\">" + dr[4].ToString() + "</td>");

                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[1].ToString() + "' and T_state='m' order by C_issue desc");

                //中奖次数
                DataSet ds_win = get_c.GetCompOFs("T_state='m' and C_lottID='1' and C_name=" + "'" + dr[1].ToString() + "'" + " and C_win=1");
                if (ds_win != null && ds_win.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + ds_win.Tables[0].Rows[0]["m"].ToString() + "</font></td>");
                }
                else
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">0</font></td>");
                }

                sbStr.Append("</tr>");
                n_m++;
                if (n_m > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");


            return HttpContext.Current.Server.HtmlEncode(sbStr.ToString());
        }

        /// <summary>
        /// 积分榜 绑定数据 -------排列三 条件积分榜
        /// </summary>
        /// <param name="lottid">彩种Id</param>
        /// <returns></returns>
        [WebMethod]
        public string IntegralTable_p()
        {
            Pbzx.BLL.Challenge_integral get_i = new Pbzx.BLL.Challenge_integral();
            Pbzx.BLL.Challenge_Cinfo get_c = new Pbzx.BLL.Challenge_Cinfo();

            StringBuilder sbStr = new StringBuilder();
            //sbStr.Append("<div class=\"exper-content\">");
            //sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            //sbStr.Append("<p class=\"exper-title\">人气榜</p>");
            //sbStr.Append("<p class=\"txt-blue\"></p>");
            //sbStr.Append("<p class=\"exper-more\"> 更多</p>");
            //sbStr.Append("</div>");
            //sbStr.Append("<table class=\"exper-table\">");
            //sbStr.Append("<tbody><tr>");
            //sbStr.Append("<td>名次</td>");
            //sbStr.Append("<td>会员</td>");
            //sbStr.Append("<td>人气</td>");
            //sbStr.Append("<td> 详情</td>");
            //sbStr.Append("</tr>");

            ////查询会员
            //sbStr.Append("<tr>");
            //sbStr.Append("<td><var>1</var></td>");
            //sbStr.Append("<td><a href=\"#\">湛蓝</a></td>");
            //sbStr.Append("<td><font color=\"#b21\">463↓</font></td>");
            //sbStr.Append("<td><a href=\"#\" class=\"enter\" target=\"_blank\"><img src=\"images/cv.png\"></a></td>");
            //sbStr.Append("</tr></tbody>");

            //sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a> <a href=\"#\"> <img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            //sbStr.Append("</div>");

            //独胆 积分排行
            DataSet ds_dd = get_i.RankSSq("v_pdd", "1=1");
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">独胆</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>积分</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>成绩</td>");
            sbStr.Append("</tr>");
            //名次
            int n_win = 1;
            foreach (DataRow dr in ds_dd.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_win + "</var></td>");
                sbStr.Append("<td><a href='/Person.aspx?name=" + Server.UrlEncode(dr[1].ToString()) + "'>" + dr[1].ToString() + "</a></td>");
                sbStr.Append("<td class=\"results\">" + dr[4].ToString() + "</td>");

                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[1].ToString() + "' and T_state='pdd' order by C_issue desc");

                //中奖次数
                DataSet ds_win = get_c.GetCompOFs_P(99999,"T_state='pdd' and C_lottID='9999' and C_name=" + "'" + dr[1].ToString() + "'"+" and C_win=1");
                if (ds_win != null && ds_win.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + ds_win.Tables[0].Rows[0]["pdd"].ToString() + "</font></td>");
                }
                else
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">0</font></td>");
                }
                sbStr.Append("</tr>");
                n_win++;
                if (n_win > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");


            //双胆  积分排行
            DataSet ds_sd = get_i.RankSSq("v_psd", "1=1");
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">双胆</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>积分</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>成绩</td>");
            sbStr.Append("</tr>");
            //名次
            int n_sd = 1;
            foreach (DataRow dr in ds_sd.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_sd + "</var></td>");
                sbStr.Append("<td><a href='/Person.aspx?name=" + Server.UrlEncode(dr[1].ToString()) + "'>" + dr[1].ToString() + "</a></td>");
                sbStr.Append("<td class=\"results\">" + dr[4].ToString() + "</td>");

                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[1].ToString() + "' and T_state='psd' order by C_issue desc");

                //中奖次数
                DataSet ds_win = get_c.GetCompOFs_P(99999, "T_state='psd' and C_lottID='9999' and C_name=" + "'" + dr[1].ToString() + "'" + " and C_win=1");

                if (ds_win != null && ds_win.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + ds_win.Tables[0].Rows[0]["psd"].ToString() + "</font></td>");
                }
                else
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">0</font></td>");
                }

                sbStr.Append("</tr>");
                n_sd++;
                if (n_sd > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");

            //组选1注 积分排行
            DataSet ds_zx1z = get_i.RankSSq("v_pzx1z", "1=1");
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">组选1注</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>积分</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>成绩</td>");
            sbStr.Append("</tr>");
            //名次
            int n_zx1z = 1;
            foreach (DataRow dr in ds_zx1z.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_zx1z + "</var></td>");
                sbStr.Append("<td><a href='/Person.aspx?name=" + Server.UrlEncode(dr[1].ToString()) + "'>" + dr[1].ToString() + "</a></td>");
                sbStr.Append("<td class=\"results\">" + dr[4].ToString() + "</td>");

                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[1].ToString() + "' and T_state='pzx1z' order by C_issue desc");

                //中奖次数
                DataSet ds_win = get_c.GetCompOFs_P(99999, "T_state='pzx1z' and C_lottID='9999' and C_name=" + "'" + dr[1].ToString() + "'" + " and C_win=1");
                if (ds_win != null && ds_win.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + ds_win.Tables[0].Rows[0]["pzx1z"].ToString() + "</font></td>");
                }
                else
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">0</font></td>");
                }

                sbStr.Append("</tr>");
                n_zx1z++;
                if (n_zx1z > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");

            //杀1码 积分排行
            DataSet ds_s1m = get_i.RankSSq("v_ps1m", "1=1");
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">杀1码</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>积分</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>成绩</td>");
            sbStr.Append("</tr>");
            //名次
            int n_s1m = 1;
            foreach (DataRow dr in ds_s1m.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_s1m + "</var></td>");
                sbStr.Append("<td><a href='/Person.aspx?name=" + Server.UrlEncode(dr[1].ToString()) + "'>" + dr[1].ToString() + "</a></td>");
                sbStr.Append("<td class=\"results\">" + dr[4].ToString() + "</td>");

                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[1].ToString() + "' and T_state='ps1m' order by C_issue desc");

                //中奖次数
                DataSet ds_win = get_c.GetCompOFs_P(99999, "T_state='ps1m' and C_lottID='9999' and C_name=" + "'" + dr[1].ToString() + "'" + " and C_win=1");
                if (ds_win != null && ds_win.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + ds_win.Tables[0].Rows[0]["ps1m"].ToString() + "</font></td>");
                }
                else
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">0</font></td>");
                }

                sbStr.Append("</tr>");
                n_s1m++;
                if (n_s1m > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");

            //杀2码 积分排行
            DataSet ds_s2m = get_i.RankSSq("v_ps2m", "1=1");
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">杀2码</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>积分</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>成绩</td>");
            sbStr.Append("</tr>");
            //名次
            int n_s2m = 1;
            foreach (DataRow dr in ds_s2m.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_s2m + "</var></td>");
                sbStr.Append("<td><a href='/Person.aspx?name=" + Server.UrlEncode(dr[1].ToString()) + "'>" + dr[1].ToString() + "</a></td>");
                sbStr.Append("<td class=\"results\">" + dr[4].ToString() + "</td>");

                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[1].ToString() + "' and T_state='ps2m' order by C_issue desc");

                //中奖次数
                DataSet ds_win = get_c.GetCompOFs_P(99999, "T_state='ps2m' and C_lottID='9999' and C_name=" + "'" + dr[1].ToString() + "'" + " and C_win=1");
                if (ds_win != null && ds_win.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + ds_win.Tables[0].Rows[0]["ps2m"].ToString() + "</font></td>");
                }
                else
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">0</font></td>");
                }

                sbStr.Append("</tr>");
                n_s2m++;
                if (n_s2m > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");

            //独跨 成绩排行
            DataSet ds_dk = get_i.RankSSq("v_pdk", "1=1");
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">独跨</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>积分</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>成绩</td>");
            sbStr.Append("</tr>");
            //名次
            int n_dk = 1;
            foreach (DataRow dr in ds_dk.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_dk + "</var></td>");
                sbStr.Append("<td><a href='/Person.aspx?name=" + Server.UrlEncode(dr[1].ToString()) + "'>" + dr[1].ToString() + "</a></td>");
                sbStr.Append("<td class=\"results\">" + dr[4].ToString() + "</td>");

                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[1].ToString() + "' and T_state='pdk' order by C_issue desc");

                //中奖次数
                DataSet ds_win = get_c.GetCompOFs_P(99999, "T_state='pdk' and C_lottID='9999' and C_name=" + "'" + dr[1].ToString() + "'" + " and C_win=1");
                if (ds_win != null && ds_win.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + ds_win.Tables[0].Rows[0]["pdk"].ToString() + "</font></td>");
                }
                else
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">0</font></td>");
                }

                sbStr.Append("</tr>");
                n_dk++;
                if (n_dk > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");

            //独合 成绩排行
            DataSet ds_dh = get_i.RankSSq("v_pdh", "1=1");
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">独合</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>积分</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>成绩</td>");
            sbStr.Append("</tr>");
            //名次
            int n_dh = 1;
            foreach (DataRow dr in ds_dh.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_dh + "</var></td>");
                sbStr.Append("<td><a href='/Person.aspx?name=" + Server.UrlEncode(dr[1].ToString()) + "'>" + dr[1].ToString() + "</a></td>");
                sbStr.Append("<td class=\"results\">" + dr[4].ToString() + "</td>");

                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[1].ToString() + "' and T_state='pdh' order by C_issue desc");

                //中奖次数
                DataSet ds_win = get_c.GetCompOFs_P(99999, "T_state='pdh' and C_lottID='9999' and C_name=" + "'" + dr[1].ToString() + "'" + " and C_win=1");
                if (ds_win != null && ds_win.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + ds_win.Tables[0].Rows[0]["pdh"].ToString() + "</font></td>");
                }
                else
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">0</font></td>");
                }

                sbStr.Append("</tr>");
                n_dh++;
                if (n_dh > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");

            //杀1合 积分排行
            DataSet ds_s1h = get_i.RankSSq("v_ps1h", "1=1");
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">杀6蓝球</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>积分</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>成绩</td>");
            sbStr.Append("</tr>");
            //名次
            int n_s1h = 1;
            foreach (DataRow dr in ds_s1h.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_s1h + "</var></td>");
                sbStr.Append("<td><a href='/Person.aspx?name=" + Server.UrlEncode(dr[1].ToString()) + "'>" + dr[1].ToString() + "</a></td>");
                sbStr.Append("<td class=\"results\">" + dr[4].ToString() + "</td>");

                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[1].ToString() + "' and T_state='ps1h' order by C_issue desc");

                //中奖次数
                DataSet ds_win = get_c.GetCompOFs_P(99999, "T_state='ps1h' and C_lottID='9999' and C_name=" + "'" + dr[1].ToString() + "'" + " and C_win=1");
                if (ds_win != null && ds_win.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + ds_win.Tables[0].Rows[0]["ps1h"].ToString() + "</font></td>");
                }
                else
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">0</font></td>");
                }

                sbStr.Append("</tr>");
                n_s1h++;
                if (n_s1h > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");

            //5*5*5定位 积分排行
            DataSet ds_5dw = get_i.RankSSq("v_p5dw", "1=1");
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">5*5*5定位</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>积分</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>成绩</td>");
            sbStr.Append("</tr>");
            //名次
            int n_5dw = 1;
            foreach (DataRow dr in ds_5dw.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_5dw + "</var></td>");
                sbStr.Append("<td><a href='/Person.aspx?name=" + Server.UrlEncode(dr[1].ToString()) + "'" + dr[1].ToString() + "</a></td>");
                sbStr.Append("<td class=\"results\">" + dr[4].ToString() + "</td>");

                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[1].ToString() + "' and T_state='p5dw' order by C_issue desc");

                //中奖次数
                DataSet ds_win = get_c.GetCompOFs_P(99999, "T_state='p5dw' and C_lottID='9999' and C_name=" + "'" + dr[1].ToString() + "'" + " and C_win=1");
                if (ds_win != null && ds_win.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + ds_win.Tables[0].Rows[0]["p5dw"].ToString() + "</font></td>");
                }
                else
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">0</font></td>");
                }

                sbStr.Append("</tr>");
                n_5dw++;
                if (n_5dw > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");

            //3*3*3定位 积分排行
            DataSet ds_3dw = get_i.RankSSq("v_p3dw", "1=1");
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">3*3*3定位</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>积分</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>成绩</td>");
            sbStr.Append("</tr>");
            //名次
            int n_3dw = 1;
            foreach (DataRow dr in ds_3dw.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_3dw + "</var></td>");
                sbStr.Append("<td><a href='/Person.aspx?name=" + Server.UrlEncode(dr[1].ToString()) + "'>" + dr[1].ToString() + "</a></td>");
                sbStr.Append("<td class=\"results\">" + dr[4].ToString() + "</td>");

                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[1].ToString() + "' and T_state='p3dw' order by C_issue desc");

                //中奖次数
                DataSet ds_win = get_c.GetCompOFs_P(99999, "T_state='p3dw' and C_lottID='9999' and C_name=" + "'" + dr[1].ToString() + "'" + " and C_win=1");
                if (ds_win != null && ds_win.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + ds_win.Tables[0].Rows[0]["p3dw"].ToString() + "</font></td>");
                }
                else
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">0</font></td>");
                }

                sbStr.Append("</tr>");
                n_3dw++;
                if (n_3dw > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");

            //直选1注 积分排行
            DataSet ds_zx = get_i.RankSSq("v_pzx", "1=1");
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">直选1注</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>积分</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>成绩</td>");
            sbStr.Append("</tr>");
            //名次
            int n_zx = 1;
            foreach (DataRow dr in ds_zx.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_zx + "</var></td>");
                sbStr.Append("<td><a href='/Person.aspx?name=" + Server.UrlEncode(dr[1].ToString()) + "'>" + dr[1].ToString() + "</a></td>");
                sbStr.Append("<td class=\"results\">" + dr[4].ToString() + "</td>");

                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[1].ToString() + "' and T_state='pzx' order by C_issue desc");

                //中奖次数
                DataSet ds_win = get_c.GetCompOFs_P(99999, "T_state='pzx' and C_lottID='9999' and C_name=" + "'" + dr[1].ToString() + "'" + " and C_win=1");
                if (ds_win != null && ds_win.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + ds_win.Tables[0].Rows[0]["pzx"].ToString() + "</font></td>");
                }
                else
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">0</font></td>");
                }

                sbStr.Append("</tr>");
                n_zx++;
                if (n_zx > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");

            //5码 积分排行
            DataSet ds_m = get_i.RankSSq("v_p5m", "1=1");
            sbStr.Append("<div class=\"exper-content\">");
            sbStr.Append("<div class=\"exper-table-f6f6f6\">");
            sbStr.Append("<p class=\"exper-title\">5码</p>");
            sbStr.Append("<p class=\"txt-blue\">" + DateTime.Now.ToShortDateString() + "</p>");
            sbStr.Append("<p class=\"exper-more\">更多</p>");
            sbStr.Append("</div>");

            sbStr.Append("<table class=\"exper-table\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>名次</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>积分</td>");
            //sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>成绩</td>");
            sbStr.Append("</tr>");
            //名次
            int n_m = 1;
            foreach (DataRow dr in ds_m.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td><var>" + n_m + "</var></td>");
                sbStr.Append("<td><a href='/Person.aspx?name=" + Server.UrlEncode(dr[1].ToString()) + "'>" + dr[1].ToString() + "</a></td>");
                sbStr.Append("<td class=\"results\">" + dr[4].ToString() + "</td>");

                //sbStr.Append("<td><font color=\"#b21\">→</font></td>");
                //查询发布了多少次
                DataSet ds_num = DbHelperSQL.Query("select T_state from v_ReCon where c_name='" + dr[1].ToString() + "' and T_state='p5m' order by C_issue desc");

                //中奖次数
                DataSet ds_win = get_c.GetCompOFs_P(99999, "T_state='p5m' and C_lottID='9999' and C_name=" + "'" + dr[1].ToString() + "'" + " and C_win=1");
                if (ds_win != null && ds_win.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">" + ds_win.Tables[0].Rows[0]["p5m"].ToString() + "</font></td>");
                }
                else
                {
                    sbStr.Append("<td>" + ds_num.Tables[0].Rows.Count.ToString() + "中<font color=\"ff0000\">0</font></td>");
                }

                sbStr.Append("</tr>");
                n_m++;
                if (n_m > 13)
                {
                    break;
                }
            }

            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            //sbStr.Append("<div class=\"exper-table-f6f6f7\">");
            //sbStr.Append("<a href=\"#\"><img src=\"images/zjqb.gif\" /></a><a href=\"#\"><img src=\"images/zjdb.gif\" /></a> <a href=\"#\"><img src=\"images/zj.gif\" /></a>");
            //sbStr.Append("</div>");
            sbStr.Append("</div>");


            return HttpContext.Current.Server.HtmlEncode(sbStr.ToString());
        }
        #endregion


        #region  个人成绩列表

        /// <summary>
        /// 个人成绩中出 ----双色球
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="issueNum">查询多少期的数据</param>
        /// <returns></returns>
        [WebMethod]
        public string UserAchienement(string userName,int issueNum)
        {
            Pbzx.BLL.Challenge_Cinfo get_c = new Pbzx.BLL.Challenge_Cinfo();
            Pbzx.BLL.publicMethod get_p = new Pbzx.BLL.publicMethod();
            StringBuilder sbStr = new StringBuilder();
            sbStr.Append("<table width=\"960\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr class=\"cyc_fen cyc_hong\">");
            sbStr.Append("<td width=\"90\">期号</td>");
            sbStr.Append("<td width=\"145\">双色球开奖结果</td>");
            sbStr.Append("<td>红球3胆</td>");
            sbStr.Append("<td>红球6胆</td>");
            sbStr.Append("<td>杀3红球</td>");
            sbStr.Append("<td>杀6红球</td>");
            sbStr.Append("<td>蓝球1胆</td>");
            sbStr.Append("<td>蓝球3胆</td>");
            sbStr.Append("<td>杀3蓝球</td>");
            sbStr.Append("<td>杀6蓝球</td>");
            sbStr.Append("<td>12红+3蓝</td>");
            sbStr.Append("<td>9红+2蓝</td>");
            sbStr.Append("</tr>");

            //查询所有用户发布的数据
            DataSet ds = DbHelperSQL.Query("select top " + issueNum + " C_name,C_issue from Challenge_Cinfo where C_name=" + "'" + userName + "'" + " and C_lottID='3' and C_win<>0 group by C_name,C_issue order by C_issue desc");
            sbStr.Append("<tr class=\"tr-hui\">");
            sbStr.Append("<td>当前"+ Pbzx.BLL.publicMethod.Period(3) +"期</td>");
            
            sbStr.Append("<td></td>");
            sbStr.Append("<td colspan=\"10\"><a href='index.aspx' target=\"_blank\"><span style=\"color: red;\">点击查看【" + userName + "】最新预测</span></a></td>");
            sbStr.Append("</tr>");
            sbStr.Append("</tbody>");

            sbStr.Append("<tbody>");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    //根据 会员名  期号 查询会员条件中奖情况
                    DataSet ds_win = get_c.GetCompOFs(issueNum, "C_name=" + "'" + userName + "'" + " and c_issue=" + Convert.ToInt32(ds.Tables[0].Rows[i]["C_issue"]) + " and C_lottID='3'");


                    sbStr.Append("<tr class=\"tr-red\">");

                    sbStr.Append("<td>" + ds.Tables[0].Rows[i]["C_issue"].ToString() + "期</td>");
                    //查询开奖号码
                    string ds_Num = get_p.RlotteryNum("FCSSData", 3, Convert.ToInt32(ds.Tables[0].Rows[i]["C_issue"]));
                    //开奖号码不为空
                    if (ds_Num != null && ds_Num != "")
                    {
                        sbStr.Append("<td><font color=\"red\">" + ds_Num.Split('+')[0].ToString() + "</font> + <font color=\"blue\">" + ds_Num.Split('+')[1].ToString() + "</font></td>");

                        sbStr.Append("<td class=\"result\">" + (ds_win.Tables[0].Rows[0]["hq3d"].ToString() == "1" ? "<font color=\"red\" style=\"font-size: 16px; font-weight: bold;\">√</font>" : "<b>×</b>") + "</td>");
                        sbStr.Append("<td class=\"result\">" + (ds_win.Tables[0].Rows[0]["hq6d"].ToString() == "1" ? "<font color=\"red\" style=\"font-size: 16px; font-weight: bold;\">√</font>" : "<b>×</b>") + "</td>");
                        sbStr.Append("<td class=\"result\">" + (ds_win.Tables[0].Rows[0]["s3hq"].ToString() == "1" ? "<font color=\"red\" style=\"font-size: 16px; font-weight: bold;\">√</font>" : "<b>×</b>") + "</td>");
                        sbStr.Append("<td class=\"result\">" + (ds_win.Tables[0].Rows[0]["s6hq"].ToString() == "1" ? "<font color=\"red\" style=\"font-size: 16px; font-weight: bold;\">√</font>" : "<b>×</b>") + "</td>");
                        sbStr.Append("<td class=\"result\">" + (ds_win.Tables[0].Rows[0]["lq1d"].ToString() == "1" ? "<font color=\"red\" style=\"font-size: 16px; font-weight: bold;\">√</font>" : "<b>×</b>") + "</td>");
                        sbStr.Append("<td class=\"result\">" + (ds_win.Tables[0].Rows[0]["lq3d"].ToString() == "1" ? "<font color=\"red\" style=\"font-size: 16px; font-weight: bold;\">√</font>" : "<b>×</b>") + "</td>");
                        sbStr.Append("<td class=\"result\">" + (ds_win.Tables[0].Rows[0]["s3lq"].ToString() == "1" ? "<font color=\"red\" style=\"font-size: 16px; font-weight: bold;\">√</font>" : "<b>×</b>") + "</td>");
                        sbStr.Append("<td class=\"result\">" + (ds_win.Tables[0].Rows[0]["s6lq"].ToString() == "1" ? "<font color=\"red\" style=\"font-size: 16px; font-weight: bold;\">√</font>" : "<b>×</b>") + "</td>");
                        if (ds_win.Tables[0].Rows[0]["h3l"].ToString() == "1")
                        {
                            //查询 选择的号码
                            DataSet dsN = get_p.Chipped_Table("v_ReCon", "C_Num", "C_name=" + "'" + userName + "'" + " and C_lottID='3' and C_issue=" + Convert.ToInt32(ds.Tables[0].Rows[i]["C_issue"]) + " and T_state='h3l'");
                            string WinNum = SelectNum(ds_Num.ToString(), dsN.Tables[0].Rows[0]["C_Num"].ToString());
                            sbStr.Append("<td class=\"result\"><font color=\"red\" style=\"font-size: 16px; font-weight: bold;\">" + WinNum + "</font></td>");
                        }
                        else
                        {
                            sbStr.Append("<td class=\"result\"><b>×</b></td>");
                        }

                        if (ds_win.Tables[0].Rows[0]["h2l"].ToString() == "1")
                        {
                            //查询 选择的号码
                            DataSet dsN = get_p.Chipped_Table("v_ReCon", "C_Num", "C_name=" + "'" + userName + "'" + " and C_lottID='3' and C_issue=" + Convert.ToInt32(ds.Tables[0].Rows[i]["C_issue"]) + " and T_state='h2l'");
                            string WinNum = SelectNum(ds_Num.ToString(), dsN.Tables[0].Rows[0]["C_Num"].ToString());
                            sbStr.Append("<td class=\"result\"><font color=\"red\" style=\"font-size: 16px; font-weight: bold;\">" + WinNum + "</font></td>");
                        }
                        else
                        {
                            sbStr.Append("<td class=\"result\"><b>×</b></td>");
                        }
                    }
                    sbStr.Append("</tr>");

                }
            }
            sbStr.Append("</tbody>");

            //查询中奖数
            DataSet ds_WinNum = get_c.GetCompOFs(issueNum, "C_name=" + "'" + userName + "'" + " and C_lottID='3'" + " and C_win=1");
            if (ds_WinNum != null && ds_WinNum.Tables[0].Rows.Count > 0)
            {
                sbStr.Append("<tbody>");
                sbStr.Append("<tr class=\"tr-red\">");
                sbStr.Append("<td colspan=\"2\">当前正确次数</td><td>");
                sbStr.Append(ds_WinNum.Tables[0].Rows[0]["hq3d"].ToString() == "" ? "0" : ds_WinNum.Tables[0].Rows[0]["hq3d"].ToString() + "</td><td>");
                sbStr.Append(ds_WinNum.Tables[0].Rows[0]["hq6d"].ToString() == "" ? "0" : ds_WinNum.Tables[0].Rows[0]["hq6d"].ToString() + "</td><td>");
                sbStr.Append(ds_WinNum.Tables[0].Rows[0]["s3hq"].ToString() == "" ? "0" : ds_WinNum.Tables[0].Rows[0]["s3hq"].ToString() + "</td><td>");
                sbStr.Append(ds_WinNum.Tables[0].Rows[0]["s6hq"].ToString() == "" ? "0" : ds_WinNum.Tables[0].Rows[0]["s6hq"].ToString() + "</td><td>");
                sbStr.Append(ds_WinNum.Tables[0].Rows[0]["lq1d"].ToString() == "" ? "0" : ds_WinNum.Tables[0].Rows[0]["lq1d"].ToString() + "</td><td>");
                sbStr.Append(ds_WinNum.Tables[0].Rows[0]["lq3d"].ToString() == "" ? "0" : ds_WinNum.Tables[0].Rows[0]["lq3d"].ToString() + "</td><td>");
                sbStr.Append(ds_WinNum.Tables[0].Rows[0]["s3lq"].ToString() == "" ? "0" : ds_WinNum.Tables[0].Rows[0]["s3lq"].ToString() + "</td><td>");
                sbStr.Append(ds_WinNum.Tables[0].Rows[0]["s6lq"].ToString() == "" ? "0" : ds_WinNum.Tables[0].Rows[0]["s6lq"].ToString() + "</td><td>");
                sbStr.Append(ds_WinNum.Tables[0].Rows[0]["h3l"].ToString() == "" ? "0" : ds_WinNum.Tables[0].Rows[0]["h3l"].ToString() + "</td><td>");
                sbStr.Append(ds_WinNum.Tables[0].Rows[0]["h2l"].ToString() == "" ? "0" : ds_WinNum.Tables[0].Rows[0]["h2l"].ToString() + "</td>");
                sbStr.Append("</tr>");
            }
            ////查询未中奖次数
            DataSet ds_Nw = get_c.GetCompOFs(issueNum, "C_name=" + "'" + userName + "'" + " and C_lottID='3'" + " and C_win=2");
            //说明：未中奖 为标识为2   未中奖的次数 数据相加/2 为次数
            if (ds_Nw != null && ds_Nw.Tables[0].Rows.Count > 0)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td colspan=\"2\">当前错误次数</td><td>");
                sbStr.Append(ds_Nw.Tables[0].Rows[0]["hq3d"].ToString() == "" ? "0" : Convert.ToInt32(ds_Nw.Tables[0].Rows[0]["hq3d"].ToString()) / 2 + "</td><td>");
                sbStr.Append(ds_Nw.Tables[0].Rows[0]["hq6d"].ToString() == "" ? "0" : Convert.ToInt32(ds_Nw.Tables[0].Rows[0]["hq6d"].ToString()) / 2 + "</td><td>");
                sbStr.Append(ds_Nw.Tables[0].Rows[0]["s3hq"].ToString() == "" ? "0" : Convert.ToInt32(ds_Nw.Tables[0].Rows[0]["s3hq"].ToString()) / 2 + "</td><td>");
                sbStr.Append(ds_Nw.Tables[0].Rows[0]["s6hq"].ToString() == "" ? "0" : Convert.ToInt32(ds_Nw.Tables[0].Rows[0]["s6hq"].ToString()) / 2 + "</td><td>");
                sbStr.Append(ds_Nw.Tables[0].Rows[0]["lq1d"].ToString() == "" ? "0" : Convert.ToInt32(ds_Nw.Tables[0].Rows[0]["lq1d"].ToString()) / 2 + "</td><td>");
                sbStr.Append(ds_Nw.Tables[0].Rows[0]["lq3d"].ToString() == "" ? "0" : Convert.ToInt32(ds_Nw.Tables[0].Rows[0]["lq3d"].ToString()) / 2 + "</td><td>");
                sbStr.Append(ds_Nw.Tables[0].Rows[0]["s3lq"].ToString() == "" ? "0" : Convert.ToInt32(ds_Nw.Tables[0].Rows[0]["s3lq"].ToString()) / 2 + "</td><td>");
                sbStr.Append(ds_Nw.Tables[0].Rows[0]["s6lq"].ToString() == "" ? "0" : Convert.ToInt32(ds_Nw.Tables[0].Rows[0]["s6lq"].ToString()) / 2 + "</td><td>");
                sbStr.Append(ds_Nw.Tables[0].Rows[0]["h3l"].ToString() == "" ? "0" : Convert.ToInt32(ds_Nw.Tables[0].Rows[0]["h3l"].ToString()) / 2 + "</td><td>");
                sbStr.Append(ds_Nw.Tables[0].Rows[0]["h2l"].ToString() == "" ? "0" : Convert.ToInt32(ds_Nw.Tables[0].Rows[0]["h2l"].ToString()) / 2 + "</td>");
                sbStr.Append("</tr>");
            }
            sbStr.Append("<tr class=\"tr-red\">");
            sbStr.Append("<td colspan=\"2\">最大连错次数</td>");
            int n_err = 0;
            int n_errNum = 0;
            DataSet ds_errors = get_p.Chipped_Table("v_ReCon", "*", "T_state='hq3d' order by C_issue desc");
            for (int i = 0; i < ds_errors.Tables[0].Rows.Count; i++)
            {
                if (i > 0)
                {
                    if (Convert.ToInt32(ds_errors.Tables[0].Rows[i]["C_win"]) == 2)
                    {
                        //如果是当前年得第一期 
                        if (Convert.ToInt32(ds_errors.Tables[0].Rows[i]["C_issue"]) == Convert.ToInt32(DateTime.Now.Year.ToString() + "001"))
                        {
                            //查询发布的最后一期
                            DataSet ds_f = DbHelperSQL1.Query("select top 1 issue from FCSSData order by issue desc");
                            if (Convert.ToInt32(ds_errors.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_f.Tables[0].Rows[0]["issue"]) && Convert.ToInt32(ds_errors.Tables[0].Rows[i]["C_win"])==2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(ds_errors.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_errors.Tables[0].Rows[i - 1]["C_issue"]) && Convert.ToInt32(ds_errors.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                    }
                }
            }
            sbStr.Append("<td>" + n_errNum + "</td>");

            DataSet ds_errhq6d = get_p.Chipped_Table("v_ReCon", "*", "T_state='hq6d' order by C_issue desc");
            for (int i = 0; i < ds_errhq6d.Tables[0].Rows.Count; i++)
            {
                if (i > 0)
                {
                    if (Convert.ToInt32(ds_errhq6d.Tables[0].Rows[i]["C_win"]) == 2)
                    {
                        //如果是当前年得第一期 
                        if (Convert.ToInt32(ds_errhq6d.Tables[0].Rows[i]["C_issue"]) == Convert.ToInt32(DateTime.Now.Year.ToString() + "001"))
                        {
                            //查询发布的最后一期
                            DataSet ds_f = DbHelperSQL1.Query("select top 1 issue from FCSSData order by issue desc");
                            if (Convert.ToInt32(ds_errhq6d.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_f.Tables[0].Rows[0]["issue"]) && Convert.ToInt32(ds_errhq6d.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(ds_errhq6d.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_errhq6d.Tables[0].Rows[i - 1]["C_issue"]) && Convert.ToInt32(ds_errhq6d.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                    }
                }
            }
            sbStr.Append("<td>" + n_errNum + "</td>");

            DataSet ds_errs3hq = get_p.Chipped_Table("v_ReCon", "*", "T_state='s3hq' order by C_issue desc");
            for (int i = 0; i < ds_errs3hq.Tables[0].Rows.Count; i++)
            {
                if (i > 0)
                {
                    if (Convert.ToInt32(ds_errs3hq.Tables[0].Rows[i]["C_win"]) == 2)
                    {
                        //如果是当前年得第一期 
                        if (Convert.ToInt32(ds_errs3hq.Tables[0].Rows[i]["C_issue"]) == Convert.ToInt32(DateTime.Now.Year.ToString() + "001"))
                        {
                            //查询发布的最后一期
                            DataSet ds_f = DbHelperSQL1.Query("select top 1 issue from FCSSData order by issue desc");
                            if (Convert.ToInt32(ds_errs3hq.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_f.Tables[0].Rows[0]["issue"]) && Convert.ToInt32(ds_errs3hq.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(ds_errs3hq.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_errs3hq.Tables[0].Rows[i - 1]["C_issue"]) && Convert.ToInt32(ds_errs3hq.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                    }
                }
            }
            sbStr.Append("<td>" + n_errNum + "</td>");

            DataSet ds_errs6hq = get_p.Chipped_Table("v_ReCon", "*", "T_state='s6hq' order by C_issue desc");
            for (int i = 0; i < ds_errs6hq.Tables[0].Rows.Count; i++)
            {
                if (i > 0)
                {
                    if (Convert.ToInt32(ds_errs6hq.Tables[0].Rows[i]["C_win"]) == 2)
                    {
                        //如果是当前年得第一期 
                        if (Convert.ToInt32(ds_errs6hq.Tables[0].Rows[i]["C_issue"]) == Convert.ToInt32(DateTime.Now.Year.ToString() + "001"))
                        {
                            //查询发布的最后一期
                            DataSet ds_f = DbHelperSQL1.Query("select top 1 issue from FCSSData order by issue desc");
                            if (Convert.ToInt32(ds_errs6hq.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_f.Tables[0].Rows[0]["issue"]) && Convert.ToInt32(ds_errs6hq.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(ds_errs6hq.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_errs6hq.Tables[0].Rows[i - 1]["C_issue"]) && Convert.ToInt32(ds_errs6hq.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                    }
                }
            }
            sbStr.Append("<td>" + n_errNum + "</td>");

            DataSet ds_errlq1d = get_p.Chipped_Table("v_ReCon", "*", "T_state='lq1d' order by C_issue desc");
            for (int i = 0; i < ds_errlq1d.Tables[0].Rows.Count; i++)
            {
                if (i > 0)
                {
                    if (Convert.ToInt32(ds_errlq1d.Tables[0].Rows[i]["C_win"]) == 2)
                    {
                        //如果是当前年得第一期 
                        if (Convert.ToInt32(ds_errlq1d.Tables[0].Rows[i]["C_issue"]) == Convert.ToInt32(DateTime.Now.Year.ToString() + "001"))
                        {
                            //查询发布的最后一期
                            DataSet ds_f = DbHelperSQL1.Query("select top 1 issue from FCSSData order by issue desc");
                            if (Convert.ToInt32(ds_errlq1d.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_f.Tables[0].Rows[0]["issue"]) && Convert.ToInt32(ds_errlq1d.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(ds_errlq1d.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_errlq1d.Tables[0].Rows[i - 1]["C_issue"]) && Convert.ToInt32(ds_errlq1d.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                    }
                }
            }
            sbStr.Append("<td>" + n_errNum + "</td>");

            DataSet ds_errlq3d = get_p.Chipped_Table("v_ReCon", "*", "T_state='lq3d' order by C_issue desc");
            for (int i = 0; i < ds_errlq3d.Tables[0].Rows.Count; i++)
            {
                if (i > 0)
                {
                    if (Convert.ToInt32(ds_errlq3d.Tables[0].Rows[i]["C_win"]) == 2)
                    {
                        //如果是当前年得第一期 
                        if (Convert.ToInt32(ds_errlq3d.Tables[0].Rows[i]["C_issue"]) == Convert.ToInt32(DateTime.Now.Year.ToString() + "001"))
                        {
                            //查询发布的最后一期
                            DataSet ds_f = DbHelperSQL1.Query("select top 1 issue from FCSSData order by issue desc");
                            if (Convert.ToInt32(ds_errlq3d.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_f.Tables[0].Rows[0]["issue"]) && Convert.ToInt32(ds_errlq3d.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(ds_errlq3d.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_errlq3d.Tables[0].Rows[i - 1]["C_issue"]) && Convert.ToInt32(ds_errlq3d.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                    }
                }
            }
            sbStr.Append("<td>" + n_errNum + "</td>");

            DataSet ds_errs3lq = get_p.Chipped_Table("v_ReCon", "*", "T_state='s3lq' order by C_issue desc");
            for (int i = 0; i < ds_errs3lq.Tables[0].Rows.Count; i++)
            {
                if (i > 0)
                {
                    if (Convert.ToInt32(ds_errs3lq.Tables[0].Rows[i]["C_win"]) == 2)
                    {
                        //如果是当前年得第一期 
                        if (Convert.ToInt32(ds_errs3lq.Tables[0].Rows[i]["C_issue"]) == Convert.ToInt32(DateTime.Now.Year.ToString() + "001"))
                        {
                            //查询发布的最后一期
                            DataSet ds_f = DbHelperSQL1.Query("select top 1 issue from FCSSData order by issue desc");
                            if (Convert.ToInt32(ds_errs3lq.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_f.Tables[0].Rows[0]["issue"]) && Convert.ToInt32(ds_errs3lq.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(ds_errs3lq.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_errs3lq.Tables[0].Rows[i - 1]["C_issue"]) && Convert.ToInt32(ds_errs3lq.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                    }
                }
            }
            sbStr.Append("<td>" + n_errNum + "</td>");

            DataSet ds_errs6lq = get_p.Chipped_Table("v_ReCon", "*", "T_state='s6lq' order by C_issue desc");
            for (int i = 0; i < ds_errs6lq.Tables[0].Rows.Count; i++)
            {
                if (i > 0)
                {
                    if (Convert.ToInt32(ds_errs6lq.Tables[0].Rows[i]["C_win"]) == 2)
                    {
                        //如果是当前年得第一期 
                        if (Convert.ToInt32(ds_errs6lq.Tables[0].Rows[i]["C_issue"]) == Convert.ToInt32(DateTime.Now.Year.ToString() + "001"))
                        {
                            //查询发布的最后一期
                            DataSet ds_f = DbHelperSQL1.Query("select top 1 issue from FCSSData order by issue desc");
                            if (Convert.ToInt32(ds_errs6lq.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_f.Tables[0].Rows[0]["issue"]) && Convert.ToInt32(ds_errs6lq.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(ds_errs6lq.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_errs6lq.Tables[0].Rows[i - 1]["C_issue"]) && Convert.ToInt32(ds_errs6lq.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                    }
                }
            }
            sbStr.Append("<td>" + n_errNum + "</td>");

            DataSet ds_errh3l = get_p.Chipped_Table("v_ReCon", "*", "T_state='h3l' order by C_issue desc");
            for (int i = 0; i < ds_errh3l.Tables[0].Rows.Count; i++)
            {
                if (i > 0)
                {
                    if (Convert.ToInt32(ds_errh3l.Tables[0].Rows[i]["C_win"]) == 2)
                    {
                        //如果是当前年得第一期 
                        if (Convert.ToInt32(ds_errh3l.Tables[0].Rows[i]["C_issue"]) == Convert.ToInt32(DateTime.Now.Year.ToString() + "001"))
                        {
                            //查询发布的最后一期
                            DataSet ds_f = DbHelperSQL1.Query("select top 1 issue from FCSSData order by issue desc");
                            if (Convert.ToInt32(ds_errh3l.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_f.Tables[0].Rows[0]["issue"]) && Convert.ToInt32(ds_errh3l.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(ds_errh3l.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_errh3l.Tables[0].Rows[i - 1]["C_issue"]) && Convert.ToInt32(ds_errh3l.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                    }
                }
            }
            sbStr.Append("<td>" + n_errNum + "</td>");

            DataSet ds_errh2l = get_p.Chipped_Table("v_ReCon", "*", "T_state='h2l' order by C_issue desc");
            for (int i = 0; i < ds_errh2l.Tables[0].Rows.Count; i++)
            {
                if (i > 0)
                {
                    if (Convert.ToInt32(ds_errh2l.Tables[0].Rows[i]["C_win"]) == 2)
                    {
                        //如果是当前年得第一期 
                        if (Convert.ToInt32(ds_errh2l.Tables[0].Rows[i]["C_issue"]) == Convert.ToInt32(DateTime.Now.Year.ToString() + "001"))
                        {
                            //查询发布的最后一期
                            DataSet ds_f = DbHelperSQL1.Query("select top 1 issue from FCSSData order by issue desc");
                            if (Convert.ToInt32(ds_errh2l.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_f.Tables[0].Rows[0]["issue"]) && Convert.ToInt32(ds_errh2l.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(ds_errh2l.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_errh2l.Tables[0].Rows[i - 1]["C_issue"]) && Convert.ToInt32(ds_errh2l.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                    }
                }
            }
            sbStr.Append("<td>" + n_errNum + "</td>");

            sbStr.Append("</tr>");
            //                <tr>
            //                    <td colspan="2">最大连对次数</td>
            //                    <td>3</td>
            //                    <td>6</td>
            //                    <td>1</td>
            //                    <td>2</td>
            //                    <td>7</td>
            //                    <td>4</td>
            //                    <td>1</td>
            //                    <td>9</td>
            //                    <td>9</td>
            //                    <td>3</td>
            //                    <td>1</td>
            //                </tr>

            


            sbStr.Append("<tr class=\"tr-red\">");
            sbStr.Append("<td colspan=\"2\">准确率</td>");
            //红球3胆
            DataSet n_hq3d = DbHelperSQL.Query("select top " + issueNum + " count(*) from v_ReCon where T_state='hq3d' and C_name=" + "'" + userName + "'" + " and C_win=1");
            if (n_hq3d != null && n_hq3d.Tables[0].Rows.Count > 0 && Convert.ToInt32(n_hq3d.Tables[0].Rows[0][0]) != 0)
            {
               
                //计算准确率
                //会员发布次数
                DataSet dsWinN = DbHelperSQL.Query("select top "+ issueNum +" count(*) from v_ReCon where T_state='hq3d' and C_name="+"'"+ userName +"'");
                if (dsWinN != null && dsWinN.Tables[0].Rows.Count > 0)
                {
                    decimal n_twhq3d = Convert.ToDecimal(n_hq3d.Tables[0].Rows[0][0]) / Convert.ToDecimal(dsWinN.Tables[0].Rows[0][0]) * 100;
                    sbStr.Append("<td>" + n_twhq3d.ToString("0.##") + "%</td>");
                }
            }
            else
            {
                sbStr.Append("<td>0.00%</td>");
            }
            DataSet n_hq6d = DbHelperSQL.Query("select count(*) from v_ReCon where T_state='hq6d' and C_name=" + "'" + userName + "'" + " and C_win=1");
            if (n_hq6d != null && n_hq6d.Tables[0].Rows.Count > 0 && Convert.ToInt32(n_hq6d.Tables[0].Rows[0][0]) != 0)
            {
                //计算准确率
                 //会员发布次数
                DataSet dsWinN = DbHelperSQL.Query("select top " + issueNum + " count(*) from v_ReCon where T_state='hq6d' and C_name=" + "'" + userName + "'");
                if (dsWinN != null && dsWinN.Tables[0].Rows.Count > 0)
                {
                    decimal n_twhq6d = Convert.ToDecimal(n_hq6d.Tables[0].Rows[0][0]) / Convert.ToDecimal(dsWinN.Tables[0].Rows[0][0]) * 100;
                    sbStr.Append("<td>" + n_twhq6d.ToString("0.##") + "%</td>");
                }
            }
            else
            {
                sbStr.Append("<td>0.00%</td>");
            }

            DataSet n_s3hq = DbHelperSQL.Query("select count(*) from v_ReCon where T_state='s3hq' and C_name=" + "'" + userName + "'" + " and C_win=1");
            if (n_s3hq != null && n_s3hq.Tables[0].Rows.Count > 0 && Convert.ToInt32(n_s3hq.Tables[0].Rows[0][0]) != 0)
            {
                //计算准确率
                 //会员发布次数
                DataSet dsWinN = DbHelperSQL.Query("select top " + issueNum + " count(*) from v_ReCon where T_state='s3hq' and C_name=" + "'" + userName + "'");
                if (dsWinN != null && dsWinN.Tables[0].Rows.Count > 0)
                {
                    decimal n_tws3hq = Convert.ToDecimal(n_s3hq.Tables[0].Rows[0][0]) / Convert.ToDecimal(dsWinN.Tables[0].Rows[0][0]) * 100;
                    sbStr.Append("<td>" + n_tws3hq.ToString("0.##") + "%</td>");
                }
            }
            else
            {
                sbStr.Append("<td>0.00%</td>");
            }

            DataSet n_s6hq = DbHelperSQL.Query("select count(*) from v_ReCon where T_state='s6hq' and C_name=" + "'" + userName + "'" + " and C_win=1");
            if (n_s6hq != null && n_s6hq.Tables[0].Rows.Count > 0 && Convert.ToInt32(n_s6hq.Tables[0].Rows[0][0])!=0)
            {
                //计算准确率
                 //会员发布次数
                DataSet dsWinN = DbHelperSQL.Query("select top " + issueNum + " count(*) from v_ReCon where T_state='s6hq' and C_name=" + "'" + userName + "'");
                if (dsWinN != null && dsWinN.Tables[0].Rows.Count > 0)
                {
                    decimal n_tws6hq = Convert.ToDecimal(n_s6hq.Tables[0].Rows[0][0]) / Convert.ToDecimal(dsWinN.Tables[0].Rows[0][0]) * 100;
                    sbStr.Append("<td>" + n_tws6hq.ToString("0.##") + "%</td>");
                }
            }
            else
            {
                sbStr.Append("<td>0.00%</td>");
            }

            DataSet n_lq1d = DbHelperSQL.Query("select count(*) from v_ReCon where T_state='lq1d' and C_name=" + "'" + userName + "'" + " and C_win=1");
            if (n_lq1d != null && n_lq1d.Tables[0].Rows.Count > 0 && Convert.ToInt32(n_lq1d.Tables[0].Rows[0][0]) != 0)
            {
                //计算准确率
                 //会员发布次数
                DataSet dsWinN = DbHelperSQL.Query("select top " + issueNum + " count(*) from v_ReCon where T_state='lq1d' and C_name=" + "'" + userName + "'");
                if (dsWinN != null && dsWinN.Tables[0].Rows.Count > 0)
                {
                    decimal n_twlq1d = Convert.ToDecimal(n_lq1d.Tables[0].Rows[0][0]) / Convert.ToDecimal(dsWinN.Tables[0].Rows[0][0]) * 100;
                    sbStr.Append("<td>" + n_twlq1d.ToString("0.##") + "%</td>");
                }
            }
            else
            {
                sbStr.Append("<td>0.00%</td>");
            }

            DataSet n_lq3d = DbHelperSQL.Query("select count(*) from v_ReCon where T_state='lq3d' and C_name=" + "'" + userName + "'" + " and C_win=1");
            if (n_lq3d != null && n_lq3d.Tables[0].Rows.Count > 0 && Convert.ToInt32(n_lq3d.Tables[0].Rows[0][0]) != 0)
            {
                //计算准确率
                 //会员发布次数
                DataSet dsWinN = DbHelperSQL.Query("select top " + issueNum + " count(*) from v_ReCon where T_state='lq3d' and C_name=" + "'" + userName + "'");
                if (dsWinN != null && dsWinN.Tables[0].Rows.Count > 0)
                {
                    decimal n_twlq3d = Convert.ToDecimal(n_lq3d.Tables[0].Rows[0][0]) / Convert.ToDecimal(dsWinN.Tables[0].Rows[0][0]) * 100;
                    sbStr.Append("<td>" + n_twlq3d.ToString("0.##") + "%</td>");
                }
            }
            else
            {
                sbStr.Append("<td>0.00%</td>");
            }

            DataSet n_s3lq = DbHelperSQL.Query("select count(*) from v_ReCon where T_state='s3lq' and C_name=" + "'" + userName + "'" + " and C_win=1");
            if (n_s3lq != null && n_s3lq.Tables[0].Rows.Count > 0 && Convert.ToInt32(n_s3lq.Tables[0].Rows[0][0]) != 0)
            {
                //计算准确率
                //会员发布次数
                DataSet dsWinN = DbHelperSQL.Query("select top " + issueNum + " count(*) from v_ReCon where T_state='s3lq' and C_name=" + "'" + userName + "'");
                if (dsWinN != null && dsWinN.Tables[0].Rows.Count > 0)
                {
                    decimal n_tws3lq = Convert.ToDecimal(n_s3lq.Tables[0].Rows[0][0]) / Convert.ToDecimal(dsWinN.Tables[0].Rows[0][0]) * 100;
                    sbStr.Append("<td>" + n_tws3lq.ToString("0.##") + "%</td>");
                }
            }
            else
            {
                sbStr.Append("<td>0.00%</td>");
            }

            DataSet n_s6lq = DbHelperSQL.Query("select count(*) from v_ReCon where T_state='s6lq' and C_name=" + "'" + userName + "'" + " and C_win=1");
            if (n_s6lq != null && n_s6lq.Tables[0].Rows.Count > 0 && Convert.ToInt32(n_s6lq.Tables[0].Rows[0][0]) != 0)
            {
                //计算准确率
                //会员发布次数
                DataSet dsWinN = DbHelperSQL.Query("select top " + issueNum + " count(*) from v_ReCon where T_state='s6lq' and C_name=" + "'" + userName + "'");
                if (dsWinN != null && dsWinN.Tables[0].Rows.Count > 0)
                {
                    decimal n_tws6lq = Convert.ToDecimal(n_s6lq.Tables[0].Rows[0][0]) / Convert.ToDecimal(dsWinN.Tables[0].Rows[0][0]) * 100;
                    sbStr.Append("<td>" + n_tws6lq.ToString("0.##") + "%</td>");
                }
            }
            else
            {
                sbStr.Append("<td>0.00%</td>");
            }

            DataSet n_h3l = DbHelperSQL.Query("select count(*) from v_ReCon where T_state='h3l' and C_name=" + "'" + userName + "'" + " and C_win=1");
            if (n_h3l != null && n_h3l.Tables[0].Rows.Count > 0 && Convert.ToInt32(n_h3l.Tables[0].Rows[0][0]) != 0)
            {
                //计算准确率
                //会员发布次数
                DataSet dsWinN = DbHelperSQL.Query("select top " + issueNum + " count(*) from v_ReCon where T_state='h3l' and C_name=" + "'" + userName + "'");
                if (dsWinN != null && dsWinN.Tables[0].Rows.Count > 0)
                {
                    decimal n_twh3l = Convert.ToDecimal(n_h3l.Tables[0].Rows[0][0]) / Convert.ToDecimal(dsWinN.Tables[0].Rows[0][0]) * 100;
                    sbStr.Append("<td>" + n_twh3l.ToString("0.##") + "%</td>");
                }
            }
            else
            {
                sbStr.Append("<td>0.00%</td>");
            }

            DataSet n_h2l = DbHelperSQL.Query("select count(*) from v_ReCon where T_state='h2l' and C_name=" + "'" + userName + "'" + " and C_win=1");
            if (n_h2l != null && n_h2l.Tables[0].Rows.Count > 0 && Convert.ToInt32(n_h2l.Tables[0].Rows[0][0]) != 0)
            {
                //计算准确率
                //会员发布次数
                DataSet dsWinN = DbHelperSQL.Query("select top " + issueNum + " count(*) from v_ReCon where T_state='h2l' and C_name=" + "'" + userName + "'");
                if (dsWinN != null && dsWinN.Tables[0].Rows.Count > 0)
                {
                    decimal n_twh2l = Convert.ToDecimal(n_h2l.Tables[0].Rows[0][0]) / Convert.ToDecimal(dsWinN.Tables[0].Rows[0][0]) * 100;
                    sbStr.Append("<td>" + n_twh2l.ToString("0.##") + "%</td>");
                }
            }
            else
            {
                sbStr.Append("<td>0.00%</td>");
            }

            sbStr.Append("</tr>");
            sbStr.Append("<tr>");
            sbStr.Append("<td colspan=\"2\">参数说明：</td>");
            sbStr.Append("<td colspan=\"10\" style=\"text-align: left; padding-left: 10px;\">");
            sbStr.Append("当前正确次数：会员预测正确次数的总和<br />");
            sbStr.Append("最大连对次数：连续出现正确次数的最大值<br />");
            sbStr.Append("当前连错次数：连续出现错误次数的最大值<br />");
            sbStr.Append("平均间隔期数：当前页面的总期数除以正确的次数<br />");
            sbStr.Append("成功率：正确的次数除以当前页面的总期数<br />");
            sbStr.Append("</td>");
            sbStr.Append("</tr>");
            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            return HttpContext.Current.Server.HtmlEncode(sbStr.ToString());
        }


        /// <summary>
        /// 个人成绩中出-----3D
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [WebMethod]
        public string UserAchienement_d(string userName, int issueNum)
        {
            Pbzx.BLL.Challenge_Cinfo get_c = new Pbzx.BLL.Challenge_Cinfo();
            Pbzx.BLL.publicMethod get_p = new Pbzx.BLL.publicMethod();
            StringBuilder sbStr = new StringBuilder();
            sbStr.Append("<table width=\"960\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr class=\"cyc_fen cyc_hong\">");
            sbStr.Append("<td width=\"90\">期号</td>");
            sbStr.Append("<td width=\"145\">福彩3D开奖结果</td>");
            sbStr.Append("<td>独胆</td>");
            sbStr.Append("<td>双胆</td>");
            sbStr.Append("<td>组选1注</td>");
            sbStr.Append("<td>杀1码</td>");
            sbStr.Append("<td>杀2码</td>");
            sbStr.Append("<td>独跨</td>");
            sbStr.Append("<td>独合</td>");
            sbStr.Append("<td>杀1合</td>");
            sbStr.Append("<td>5*5*5定位</td>");
            sbStr.Append("<td>3*3*3定位</td>");
            sbStr.Append("<td>直选1注</td>");
            sbStr.Append("<td>5码</td>");
            sbStr.Append("</tr>");

            //查询所有用户发布的数据
            DataSet ds = DbHelperSQL.Query("select top "+ issueNum +" C_name,C_issue from Challenge_Cinfo where C_name=" + "'" + userName + "'" + " and C_lottID='1' and C_win<>0 group by C_name,C_issue order by C_issue desc");
            sbStr.Append("<tr class=\"tr-hui\">");
            sbStr.Append("<td>当前" + Pbzx.BLL.publicMethod.Period(1) + "期</td>");
            sbStr.Append("<td></td>");
            sbStr.Append("<td colspan=\"12\"><span style=\"color: red;\">点击查看【" + userName + "】最新预测</span></td>");
            sbStr.Append("</tr>");
            sbStr.Append("</tbody>");

            sbStr.Append("<tbody>");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    //根据 会员名  期号 查询会员条件中奖情况
                    DataSet ds_win = get_c.GetCompOFs(issueNum, "C_name=" + "'" + userName + "'" + " and c_issue=" + Convert.ToInt32(ds.Tables[0].Rows[i]["C_issue"]) + " and C_lottID='1'");


                    sbStr.Append("<tr class=\"tr-red\">");

                    sbStr.Append("<td>" + ds.Tables[0].Rows[i]["C_issue"].ToString() + "期</td>");
                    //查询开奖号码
                    string ds_Num = get_p.RlotteryNum("FC3DData", 1, Convert.ToInt32(ds.Tables[0].Rows[i]["C_issue"]));
                    sbStr.Append("<td><font color=\"red\">" + ds_Num.ToString() +  "</font></td>");

                    sbStr.Append("<td class=\"result\">" + (ds_win.Tables[0].Rows[0]["dd"].ToString() == "1" ? "<font color=\"red\" style=\"font-size: 16px; font-weight: bold;\">√</font>" : "<b>×</b>") + "</td>");
                    sbStr.Append("<td class=\"result\">" + (ds_win.Tables[0].Rows[0]["sd"].ToString() == "1" ? "<font color=\"red\" style=\"font-size: 16px; font-weight: bold;\">√</font>" : "<b>×</b>") + "</td>");
                    sbStr.Append("<td class=\"result\">" + (ds_win.Tables[0].Rows[0]["zx1z"].ToString() == "1" ? "<font color=\"red\" style=\"font-size: 16px; font-weight: bold;\">√</font>" : "<b>×</b>") + "</td>");
                    sbStr.Append("<td class=\"result\">" + (ds_win.Tables[0].Rows[0]["s1m"].ToString() == "1" ? "<font color=\"red\" style=\"font-size: 16px; font-weight: bold;\">√</font>" : "<b>×</b>") + "</td>");
                    sbStr.Append("<td class=\"result\">" + (ds_win.Tables[0].Rows[0]["s2m"].ToString() == "1" ? "<font color=\"red\" style=\"font-size: 16px; font-weight: bold;\">√</font>" : "<b>×</b>") + "</td>");
                    sbStr.Append("<td class=\"result\">" + (ds_win.Tables[0].Rows[0]["dk"].ToString() == "1" ? "<font color=\"red\" style=\"font-size: 16px; font-weight: bold;\">√</font>" : "<b>×</b>") + "</td>");
                    sbStr.Append("<td class=\"result\">" + (ds_win.Tables[0].Rows[0]["dh"].ToString() == "1" ? "<font color=\"red\" style=\"font-size: 16px; font-weight: bold;\">√</font>" : "<b>×</b>") + "</td>");
                    sbStr.Append("<td class=\"result\">" + (ds_win.Tables[0].Rows[0]["s1h"].ToString() == "1" ? "<font color=\"red\" style=\"font-size: 16px; font-weight: bold;\">√</font>" : "<b>×</b>") + "</td>");
                    sbStr.Append("<td class=\"result\">" + (ds_win.Tables[0].Rows[0]["5dw"].ToString() == "1" ? "<font color=\"red\" style=\"font-size: 16px; font-weight: bold;\">√</font>" : "<b>×</b>") + "</td>");
                    sbStr.Append("<td class=\"result\">" + (ds_win.Tables[0].Rows[0]["3dw"].ToString() == "1" ? "<font color=\"red\" style=\"font-size: 16px; font-weight: bold;\">√</font>" : "<b>×</b>") + "</td>");
                    sbStr.Append("<td class=\"result\">" + (ds_win.Tables[0].Rows[0]["zx"].ToString() == "1" ? "<font color=\"red\" style=\"font-size: 16px; font-weight: bold;\">√</font>" : "<b>×</b>") + "</td>");
                    sbStr.Append("<td class=\"result\">" + (ds_win.Tables[0].Rows[0]["m"].ToString() == "1" ? "<font color=\"red\" style=\"font-size: 16px; font-weight: bold;\">√</font>" : "<b>×</b>") + "</td>");
                    sbStr.Append("</tr>");

                }
            }
            sbStr.Append("</tbody>");

            //查询中奖数
            DataSet ds_WinNum = get_c.GetCompOFs(100000, "C_name=" + "'" + userName + "'" + " and C_lottID='1'" + " and C_win=1");
            if (ds_WinNum != null && ds_WinNum.Tables[0].Rows.Count > 0)
            {
                sbStr.Append("<tbody>");
                sbStr.Append("<tr class=\"tr-red\">");
                sbStr.Append("<td colspan=\"2\">当前正确次数</td><td>");
                sbStr.Append(ds_WinNum.Tables[0].Rows[0]["dd"].ToString() == "" ? "0" : ds_WinNum.Tables[0].Rows[0]["dd"].ToString() + "</td><td>");
                sbStr.Append(ds_WinNum.Tables[0].Rows[0]["sd"].ToString() == "" ? "0" : ds_WinNum.Tables[0].Rows[0]["sd"].ToString() + "</td><td>");
                sbStr.Append(ds_WinNum.Tables[0].Rows[0]["zx1z"].ToString() == "" ? "0" : ds_WinNum.Tables[0].Rows[0]["zx1z"].ToString() + "</td><td>");
                sbStr.Append(ds_WinNum.Tables[0].Rows[0]["s1m"].ToString() == "" ? "0" : ds_WinNum.Tables[0].Rows[0]["s1m"].ToString() + "</td><td>");
                sbStr.Append(ds_WinNum.Tables[0].Rows[0]["s2m"].ToString() == "" ? "0" : ds_WinNum.Tables[0].Rows[0]["s2m"].ToString() + "</td><td>");
                sbStr.Append(ds_WinNum.Tables[0].Rows[0]["dk"].ToString() == "" ? "0" : ds_WinNum.Tables[0].Rows[0]["dk"].ToString() + "</td><td>");
                sbStr.Append(ds_WinNum.Tables[0].Rows[0]["dh"].ToString() == "" ? "0" : ds_WinNum.Tables[0].Rows[0]["dh"].ToString() + "</td><td>");
                sbStr.Append(ds_WinNum.Tables[0].Rows[0]["s1h"].ToString() == "" ? "0" : ds_WinNum.Tables[0].Rows[0]["s1h"].ToString() + "</td><td>");
                sbStr.Append(ds_WinNum.Tables[0].Rows[0]["5dw"].ToString() == "" ? "0" : ds_WinNum.Tables[0].Rows[0]["5dw"].ToString() + "</td><td>");
                sbStr.Append(ds_WinNum.Tables[0].Rows[0]["3dw"].ToString() == "" ? "0" : ds_WinNum.Tables[0].Rows[0]["3dw"].ToString() + "</td><td>");
                sbStr.Append(ds_WinNum.Tables[0].Rows[0]["zx"].ToString() == "" ? "0" : ds_WinNum.Tables[0].Rows[0]["zx"].ToString() + "</td><td>");
                sbStr.Append(ds_WinNum.Tables[0].Rows[0]["m"].ToString() == "" ? "0" : ds_WinNum.Tables[0].Rows[0]["m"].ToString() + "</td>");
                sbStr.Append("</tr>");
            }
            ////查询未中奖次数
            DataSet ds_Nw = get_c.GetCompOFs(100000, "C_name=" + "'" + userName + "'" + " and C_lottID='1'" + " and C_win=2");
            //说明：未中奖 为标识为2   未中奖的次数 数据相加/2 为次数
            if (ds_Nw != null && ds_Nw.Tables[0].Rows.Count > 0)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td colspan=\"2\">当前错误次数</td><td>");
                sbStr.Append(ds_Nw.Tables[0].Rows[0]["dd"].ToString() == "" ? "0" : Convert.ToInt32(ds_Nw.Tables[0].Rows[0]["dd"].ToString()) / 2 + "</td><td>");
                sbStr.Append(ds_Nw.Tables[0].Rows[0]["sd"].ToString() == "" ? "0" : Convert.ToInt32(ds_Nw.Tables[0].Rows[0]["sd"].ToString()) / 2 + "</td><td>");
                sbStr.Append(ds_Nw.Tables[0].Rows[0]["zx1z"].ToString() == "" ? "0" : Convert.ToInt32(ds_Nw.Tables[0].Rows[0]["zx1z"].ToString()) / 2 + "</td><td>");
                sbStr.Append(ds_Nw.Tables[0].Rows[0]["s1m"].ToString() == "" ? "0" : Convert.ToInt32(ds_Nw.Tables[0].Rows[0]["s1m"].ToString()) / 2 + "</td><td>");
                sbStr.Append(ds_Nw.Tables[0].Rows[0]["s2m"].ToString() == "" ? "0" : Convert.ToInt32(ds_Nw.Tables[0].Rows[0]["s2m"].ToString()) / 2 + "</td><td>");
                sbStr.Append(ds_Nw.Tables[0].Rows[0]["dk"].ToString() == "" ? "0" : Convert.ToInt32(ds_Nw.Tables[0].Rows[0]["dk"].ToString()) / 2 + "</td><td>");
                sbStr.Append(ds_Nw.Tables[0].Rows[0]["dh"].ToString() == "" ? "0" : Convert.ToInt32(ds_Nw.Tables[0].Rows[0]["dh"].ToString()) / 2 + "</td><td>");
                sbStr.Append(ds_Nw.Tables[0].Rows[0]["s1h"].ToString() == "" ? "0" : Convert.ToInt32(ds_Nw.Tables[0].Rows[0]["s1h"].ToString()) / 2 + "</td><td>");
                sbStr.Append(ds_Nw.Tables[0].Rows[0]["5dw"].ToString() == "" ? "0" : Convert.ToInt32(ds_Nw.Tables[0].Rows[0]["5dw"].ToString()) / 2 + "</td><td>");
                sbStr.Append(ds_Nw.Tables[0].Rows[0]["3dw"].ToString() == "" ? "0" : Convert.ToInt32(ds_Nw.Tables[0].Rows[0]["3dw"].ToString()) / 2 + "</td><td>");
                sbStr.Append(ds_Nw.Tables[0].Rows[0]["zx"].ToString() == "" ? "0" : Convert.ToInt32(ds_Nw.Tables[0].Rows[0]["zx"].ToString()) / 2 + "</td><td>");
                sbStr.Append(ds_Nw.Tables[0].Rows[0]["m"].ToString() == "" ? "0" : Convert.ToInt32(ds_Nw.Tables[0].Rows[0]["m"].ToString()) / 2 + "</td>");
                sbStr.Append("</tr>");
            }
            sbStr.Append("<tr class=\"tr-red\">");
            sbStr.Append("<td colspan=\"2\">最大连错次数</td>");
            int n_err = 0;
            int n_errNum = 0;
            DataSet ds_errdd = get_p.Chipped_Table("v_ReCon", "*", "T_state='dd' order by C_issue desc");
            for (int i = 0; i < ds_errdd.Tables[0].Rows.Count; i++)
            {
                if (i > 0)
                {
                    if (Convert.ToInt32(ds_errdd.Tables[0].Rows[i]["C_win"]) == 2)
                    {
                        //如果是当前年得第一期 
                        if (Convert.ToInt32(ds_errdd.Tables[0].Rows[i]["C_issue"]) == Convert.ToInt32(DateTime.Now.Year.ToString() + "001"))
                        {
                            //查询发布的最后一期
                            DataSet ds_f = DbHelperSQL1.Query("select top 1 issue from FC3DData order by issue desc");
                            if (Convert.ToInt32(ds_errdd.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_f.Tables[0].Rows[0]["issue"]) && Convert.ToInt32(ds_errdd.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(ds_errdd.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_errdd.Tables[0].Rows[i - 1]["C_issue"]) && Convert.ToInt32(ds_errdd.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                    }
                }
            }
            sbStr.Append("<td>" + n_errNum + "</td>");

            DataSet ds_errsd = get_p.Chipped_Table("v_ReCon", "*", "T_state='sd' order by C_issue desc");
            for (int i = 0; i < ds_errsd.Tables[0].Rows.Count; i++)
            {
                if (i > 0)
                {
                    if (Convert.ToInt32(ds_errsd.Tables[0].Rows[i]["C_win"]) == 2)
                    {
                        //如果是当前年得第一期 
                        if (Convert.ToInt32(ds_errsd.Tables[0].Rows[i]["C_issue"]) == Convert.ToInt32(DateTime.Now.Year.ToString() + "001"))
                        {
                            //查询发布的最后一期
                            DataSet ds_f = DbHelperSQL1.Query("select top 1 issue from FC3DData order by issue desc");
                            if (Convert.ToInt32(ds_errsd.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_f.Tables[0].Rows[0]["issue"]) && Convert.ToInt32(ds_errsd.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(ds_errsd.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_errsd.Tables[0].Rows[i - 1]["C_issue"]) && Convert.ToInt32(ds_errsd.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                    }
                }
            }
            sbStr.Append("<td>" + n_errNum + "</td>");

            DataSet ds_errzx1z = get_p.Chipped_Table("v_ReCon", "*", "T_state='zx1z' order by C_issue desc");
            for (int i = 0; i < ds_errzx1z.Tables[0].Rows.Count; i++)
            {
                if (i > 0)
                {
                    if (Convert.ToInt32(ds_errzx1z.Tables[0].Rows[i]["C_win"]) == 2)
                    {
                        //如果是当前年得第一期 
                        if (Convert.ToInt32(ds_errzx1z.Tables[0].Rows[i]["C_issue"]) == Convert.ToInt32(DateTime.Now.Year.ToString() + "001"))
                        {
                            //查询发布的最后一期
                            DataSet ds_f = DbHelperSQL1.Query("select top 1 issue from FC3DData order by issue desc");
                            if (Convert.ToInt32(ds_errzx1z.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_f.Tables[0].Rows[0]["issue"]) && Convert.ToInt32(ds_errzx1z.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(ds_errzx1z.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_errzx1z.Tables[0].Rows[i - 1]["C_issue"]) && Convert.ToInt32(ds_errzx1z.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                    }
                }
            }
            sbStr.Append("<td>" + n_errNum + "</td>");

            DataSet ds_errs1m = get_p.Chipped_Table("v_ReCon", "*", "T_state='s1m' order by C_issue desc");
            for (int i = 0; i < ds_errs1m.Tables[0].Rows.Count; i++)
            {
                if (i > 0)
                {
                    if (Convert.ToInt32(ds_errs1m.Tables[0].Rows[i]["C_win"]) == 2)
                    {
                        //如果是当前年得第一期 
                        if (Convert.ToInt32(ds_errs1m.Tables[0].Rows[i]["C_issue"]) == Convert.ToInt32(DateTime.Now.Year.ToString() + "001"))
                        {
                            //查询发布的最后一期
                            DataSet ds_f = DbHelperSQL1.Query("select top 1 issue from FC3DData order by issue desc");
                            if (Convert.ToInt32(ds_errs1m.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_f.Tables[0].Rows[0]["issue"]) && Convert.ToInt32(ds_errs1m.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(ds_errs1m.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_errs1m.Tables[0].Rows[i - 1]["C_issue"]) && Convert.ToInt32(ds_errs1m.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                    }
                }
            }
            sbStr.Append("<td>" + n_errNum + "</td>");

            DataSet ds_errs2m = get_p.Chipped_Table("v_ReCon", "*", "T_state='s2m' order by C_issue desc");
            for (int i = 0; i < ds_errs2m.Tables[0].Rows.Count; i++)
            {
                if (i > 0)
                {
                    if (Convert.ToInt32(ds_errs2m.Tables[0].Rows[i]["C_win"]) == 2)
                    {
                        //如果是当前年得第一期 
                        if (Convert.ToInt32(ds_errs2m.Tables[0].Rows[i]["C_issue"]) == Convert.ToInt32(DateTime.Now.Year.ToString() + "001"))
                        {
                            //查询发布的最后一期
                            DataSet ds_f = DbHelperSQL1.Query("select top 1 issue from FC3DData order by issue desc");
                            if (Convert.ToInt32(ds_errs2m.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_f.Tables[0].Rows[0]["issue"]) && Convert.ToInt32(ds_errs2m.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(ds_errs2m.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_errs2m.Tables[0].Rows[i - 1]["C_issue"]) && Convert.ToInt32(ds_errs2m.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                    }
                }
            }
            sbStr.Append("<td>" + n_errNum + "</td>");

            DataSet ds_errdk= get_p.Chipped_Table("v_ReCon", "*", "T_state='dk' order by C_issue desc");
            for (int i = 0; i < ds_errdk.Tables[0].Rows.Count; i++)
            {
                if (i > 0)
                {
                    if (Convert.ToInt32(ds_errdk.Tables[0].Rows[i]["C_win"]) == 2)
                    {
                        //如果是当前年得第一期 
                        if (Convert.ToInt32(ds_errdk.Tables[0].Rows[i]["C_issue"]) == Convert.ToInt32(DateTime.Now.Year.ToString() + "001"))
                        {
                            //查询发布的最后一期
                            DataSet ds_f = DbHelperSQL1.Query("select top 1 issue from FC3DData order by issue desc");
                            if (Convert.ToInt32(ds_errdk.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_f.Tables[0].Rows[0]["issue"]) && Convert.ToInt32(ds_errdk.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(ds_errdk.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_errdk.Tables[0].Rows[i - 1]["C_issue"]) && Convert.ToInt32(ds_errdk.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                    }
                }
            }
            sbStr.Append("<td>" + n_errNum + "</td>");

            DataSet ds_errdh = get_p.Chipped_Table("v_ReCon", "*", "T_state='dh' order by C_issue desc");
            for (int i = 0; i < ds_errdh.Tables[0].Rows.Count; i++)
            {
                if (i > 0)
                {
                    if (Convert.ToInt32(ds_errdh.Tables[0].Rows[i]["C_win"]) == 2)
                    {
                        //如果是当前年得第一期 
                        if (Convert.ToInt32(ds_errdh.Tables[0].Rows[i]["C_issue"]) == Convert.ToInt32(DateTime.Now.Year.ToString() + "001"))
                        {
                            //查询发布的最后一期
                            DataSet ds_f = DbHelperSQL1.Query("select top 1 issue from FC3DData order by issue desc");
                            if (Convert.ToInt32(ds_errdh.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_f.Tables[0].Rows[0]["issue"]) && Convert.ToInt32(ds_errdh.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(ds_errdh.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_errdh.Tables[0].Rows[i - 1]["C_issue"]) && Convert.ToInt32(ds_errdh.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                    }
                }
            }
            sbStr.Append("<td>" + n_errNum + "</td>");

            DataSet ds_errs1h = get_p.Chipped_Table("v_ReCon", "*", "T_state='s1h' order by C_issue desc");
            for (int i = 0; i < ds_errs1h.Tables[0].Rows.Count; i++)
            {
                if (i > 0)
                {
                    if (Convert.ToInt32(ds_errs1h.Tables[0].Rows[i]["C_win"]) == 2)
                    {
                        //如果是当前年得第一期 
                        if (Convert.ToInt32(ds_errs1h.Tables[0].Rows[i]["C_issue"]) == Convert.ToInt32(DateTime.Now.Year.ToString() + "001"))
                        {
                            //查询发布的最后一期
                            DataSet ds_f = DbHelperSQL1.Query("select top 1 issue from FC3DData order by issue desc");
                            if (Convert.ToInt32(ds_errs1h.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_f.Tables[0].Rows[0]["issue"]) && Convert.ToInt32(ds_errs1h.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(ds_errs1h.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_errs1h.Tables[0].Rows[i - 1]["C_issue"]) && Convert.ToInt32(ds_errs1h.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                    }
                }
            }
            sbStr.Append("<td>" + n_errNum + "</td>");

            DataSet ds_err5dw = get_p.Chipped_Table("v_ReCon", "*", "T_state='5dw' order by C_issue desc");
            for (int i = 0; i < ds_err5dw.Tables[0].Rows.Count; i++)
            {
                if (i > 0)
                {
                    if (Convert.ToInt32(ds_err5dw.Tables[0].Rows[i]["C_win"]) == 2)
                    {
                        //如果是当前年得第一期 
                        if (Convert.ToInt32(ds_err5dw.Tables[0].Rows[i]["C_issue"]) == Convert.ToInt32(DateTime.Now.Year.ToString() + "001"))
                        {
                            //查询发布的最后一期
                            DataSet ds_f = DbHelperSQL1.Query("select top 1 issue from FC3DData order by issue desc");
                            if (Convert.ToInt32(ds_err5dw.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_f.Tables[0].Rows[0]["issue"]) && Convert.ToInt32(ds_err5dw.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(ds_err5dw.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_err5dw.Tables[0].Rows[i - 1]["C_issue"]) && Convert.ToInt32(ds_err5dw.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                    }
                }
            }
            sbStr.Append("<td>" + n_errNum + "</td>");

            DataSet ds_err3dw = get_p.Chipped_Table("v_ReCon", "*", "T_state='3dw' order by C_issue desc");
            for (int i = 0; i < ds_err3dw.Tables[0].Rows.Count; i++)
            {
                if (i > 0)
                {
                    if (Convert.ToInt32(ds_err3dw.Tables[0].Rows[i]["C_win"]) == 2)
                    {
                        //如果是当前年得第一期 
                        if (Convert.ToInt32(ds_err3dw.Tables[0].Rows[i]["C_issue"]) == Convert.ToInt32(DateTime.Now.Year.ToString() + "001"))
                        {
                            //查询发布的最后一期
                            DataSet ds_f = DbHelperSQL1.Query("select top 1 issue from FC3DData order by issue desc");
                            if (Convert.ToInt32(ds_err3dw.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_f.Tables[0].Rows[0]["issue"]) && Convert.ToInt32(ds_err3dw.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(ds_err3dw.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_err3dw.Tables[0].Rows[i - 1]["C_issue"]) && Convert.ToInt32(ds_err3dw.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                    }
                }
            }
            sbStr.Append("<td>" + n_errNum + "</td>");

            DataSet ds_errzx= get_p.Chipped_Table("v_ReCon", "*", "T_state='zx' order by C_issue desc");
            for (int i = 0; i < ds_errzx.Tables[0].Rows.Count; i++)
            {
                if (i > 0)
                {
                    if (Convert.ToInt32(ds_errzx.Tables[0].Rows[i]["C_win"]) == 2)
                    {
                        //如果是当前年得第一期 
                        if (Convert.ToInt32(ds_errzx.Tables[0].Rows[i]["C_issue"]) == Convert.ToInt32(DateTime.Now.Year.ToString() + "001"))
                        {
                            //查询发布的最后一期
                            DataSet ds_f = DbHelperSQL1.Query("select top 1 issue from FC3DData order by issue desc");
                            if (Convert.ToInt32(ds_errzx.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_f.Tables[0].Rows[0]["issue"]) && Convert.ToInt32(ds_errzx.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(ds_errzx.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_errzx.Tables[0].Rows[i - 1]["C_issue"]) && Convert.ToInt32(ds_errzx.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                    }
                }
            }
            sbStr.Append("<td>" + n_errNum + "</td>");

            DataSet ds_errm = get_p.Chipped_Table("v_ReCon", "*", "T_state='m' order by C_issue desc");
            for (int i = 0; i < ds_errm.Tables[0].Rows.Count; i++)
            {
                if (i > 0)
                {
                    if (Convert.ToInt32(ds_errm.Tables[0].Rows[i]["C_win"]) == 2)
                    {
                        //如果是当前年得第一期 
                        if (Convert.ToInt32(ds_errm.Tables[0].Rows[i]["C_issue"]) == Convert.ToInt32(DateTime.Now.Year.ToString() + "001"))
                        {
                            //查询发布的最后一期
                            DataSet ds_f = DbHelperSQL1.Query("select top 1 issue from FC3DData order by issue desc");
                            if (Convert.ToInt32(ds_errm.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_f.Tables[0].Rows[0]["issue"]) && Convert.ToInt32(ds_errm.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(ds_errm.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_errm.Tables[0].Rows[i - 1]["C_issue"]) && Convert.ToInt32(ds_errm.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                    }
                }
            }
            sbStr.Append("<td>" + n_errNum + "</td>");
            sbStr.Append("</tr>");
            //                <tr>
            //                    <td colspan="2">最大连对次数</td>
            //                    <td>3</td>
            //                    <td>6</td>
            //                    <td>1</td>
            //                    <td>2</td>
            //                    <td>7</td>
            //                    <td>4</td>
            //                    <td>1</td>
            //                    <td>9</td>
            //                    <td>9</td>
            //                    <td>3</td>
            //                    <td>1</td>
            //                </tr>




            sbStr.Append("<tr class=\"tr-red\">");
            sbStr.Append("<td colspan=\"2\">准确率</td>");
            //独胆
            DataSet n_dd = DbHelperSQL.Query("select count(*) from v_ReCon where T_state='dd' and C_name=" + "'" + userName + "'" + " and C_win=1");
            if (n_dd != null && n_dd.Tables[0].Rows.Count > 0 && Convert.ToInt32(n_dd.Tables[0].Rows[0][0]) != 0)
            {
                //计算准确率
                //会员发布次数
                DataSet dsWinN = DbHelperSQL.Query("select top " + issueNum + " count(*) from v_ReCon where T_state='dd' and C_name=" + "'" + userName + "'");
                if (dsWinN != null && dsWinN.Tables[0].Rows.Count > 0)
                {
                    decimal n_twdd = Convert.ToDecimal(n_dd.Tables[0].Rows[0][0]) / Convert.ToDecimal(dsWinN.Tables[0].Rows[0][0]) * 100;
                    sbStr.Append("<td>" + n_twdd.ToString("0.##") + "%</td>");
                }
            }
            else
            {
                sbStr.Append("<td>0.00%</td>");
            }
            DataSet n_sd = DbHelperSQL.Query("select count(*) from v_ReCon where T_state='sd' and C_name=" + "'" + userName + "'" + " and C_win=1");
            if (n_sd != null && n_sd.Tables[0].Rows.Count > 0 && Convert.ToInt32(n_sd.Tables[0].Rows[0][0]) != 0)
            {
                //计算准确率
                //会员发布次数
                DataSet dsWinN = DbHelperSQL.Query("select top " + issueNum + " count(*) from v_ReCon where T_state='sd' and C_name=" + "'" + userName + "'");
                if (dsWinN != null && dsWinN.Tables[0].Rows.Count > 0)
                {
                    decimal n_twsd = Convert.ToDecimal(n_sd.Tables[0].Rows[0][0]) / Convert.ToDecimal(dsWinN.Tables[0].Rows[0][0]) * 100;
                    sbStr.Append("<td>" + n_twsd.ToString("0.##") + "%</td>");
                }
            }
            else
            {
                sbStr.Append("<td>0.00%</td>");
            }

            DataSet n_zx1z = DbHelperSQL.Query("select count(*) from v_ReCon where T_state='zx1z' and C_name=" + "'" + userName + "'" + " and C_win=1");
            if (n_zx1z != null && n_zx1z.Tables[0].Rows.Count > 0 && Convert.ToInt32(n_zx1z.Tables[0].Rows[0][0]) != 0)
            {
                //计算准确率
                //会员发布次数
                DataSet dsWinN = DbHelperSQL.Query("select top " + issueNum + " count(*) from v_ReCon where T_state='zx1z' and C_name=" + "'" + userName + "'");
                if (dsWinN != null && dsWinN.Tables[0].Rows.Count > 0)
                {
                    decimal n_twzx1z = Convert.ToDecimal(n_zx1z.Tables[0].Rows[0][0]) / Convert.ToDecimal(dsWinN.Tables[0].Rows[0][0]) * 100;
                    sbStr.Append("<td>" + n_twzx1z.ToString("0.##") + "%</td>");
                }
            }
            else
            {
                sbStr.Append("<td>0.00%</td>");
            }

            DataSet n_s1m = DbHelperSQL.Query("select count(*) from v_ReCon where T_state='s1m' and C_name=" + "'" + userName + "'" + " and C_win=1");
            if (n_s1m != null && n_s1m.Tables[0].Rows.Count > 0 && Convert.ToInt32(n_s1m.Tables[0].Rows[0][0]) != 0)
            {
                //计算准确率

                //会员发布次数
                DataSet dsWinN = DbHelperSQL.Query("select top " + issueNum + " count(*) from v_ReCon where T_state='s1m' and C_name=" + "'" + userName + "'");
                if (dsWinN != null && dsWinN.Tables[0].Rows.Count > 0)
                {
                    decimal n_tws1m = Convert.ToDecimal(n_s1m.Tables[0].Rows[0][0]) / Convert.ToDecimal(dsWinN.Tables[0].Rows[0][0]) * 100;
                    sbStr.Append("<td>" + n_tws1m.ToString("0.##") + "%</td>");
                }
            }
            else
            {
                sbStr.Append("<td>0.00%</td>");
            }

            DataSet n_s2m = DbHelperSQL.Query("select count(*) from v_ReCon where T_state='s2m' and C_name=" + "'" + userName + "'" + " and C_win=1");
            if (n_s2m != null && n_s2m.Tables[0].Rows.Count > 0 && Convert.ToInt32(n_s2m.Tables[0].Rows[0][0]) != 0)
            {
                //计算准确率

                 //会员发布次数
                DataSet dsWinN = DbHelperSQL.Query("select top " + issueNum + " count(*) from v_ReCon where T_state='s2m' and C_name=" + "'" + userName + "'");
                if (dsWinN != null && dsWinN.Tables[0].Rows.Count > 0)
                {
                    decimal n_tws2m = Convert.ToDecimal(n_s2m.Tables[0].Rows[0][0]) / Convert.ToDecimal(dsWinN.Tables[0].Rows[0][0]) * 100;
                    sbStr.Append("<td>" + n_tws2m.ToString("0.##") + "%</td>");
                }
            }
            else
            {
                sbStr.Append("<td>0.00%</td>");
            }

            DataSet n_dk = DbHelperSQL.Query("select count(*) from v_ReCon where T_state='dk' and C_name=" + "'" + userName + "'" + " and C_win=1");
            if (n_dk!= null && n_dk.Tables[0].Rows.Count > 0 && Convert.ToInt32(n_dk.Tables[0].Rows[0][0]) != 0)
            {
                //计算准确率
                 //会员发布次数
                DataSet dsWinN = DbHelperSQL.Query("select top " + issueNum + " count(*) from v_ReCon where T_state='dk' and C_name=" + "'" + userName + "'");
                if (dsWinN != null && dsWinN.Tables[0].Rows.Count > 0)
                {
                    decimal n_twdk = Convert.ToDecimal(n_dk.Tables[0].Rows[0][0]) / Convert.ToDecimal(dsWinN.Tables[0].Rows[0][0]) * 100;
                    sbStr.Append("<td>" + n_twdk.ToString("0.##") + "%</td>");
                }
            }
            else
            {
                sbStr.Append("<td>0.00%</td>");
            }

            DataSet n_dh = DbHelperSQL.Query("select count(*) from v_ReCon where T_state='dh' and C_name=" + "'" + userName + "'" + " and C_win=1");
            if (n_dh != null && n_dh.Tables[0].Rows.Count > 0 && Convert.ToInt32(n_dh.Tables[0].Rows[0][0]) != 0)
            {
                //计算准确率
                //会员发布次数
                DataSet dsWinN = DbHelperSQL.Query("select top " + issueNum + " count(*) from v_ReCon where T_state='dh' and C_name=" + "'" + userName + "'");
                if (dsWinN != null && dsWinN.Tables[0].Rows.Count > 0)
                {
                    decimal n_twdh = Convert.ToDecimal(n_dh.Tables[0].Rows[0][0]) / Convert.ToDecimal(dsWinN.Tables[0].Rows[0][0]) * 100;
                    sbStr.Append("<td>" + n_twdh.ToString("0.##") + "%</td>");
                }
            }
            else
            {
                sbStr.Append("<td>0.00%</td>");
            }

            DataSet n_s1h = DbHelperSQL.Query("select count(*) from v_ReCon where T_state='s1h' and C_name=" + "'" + userName + "'" + " and C_win=1");
            if (n_s1h != null && n_s1h.Tables[0].Rows.Count > 0 && Convert.ToInt32(n_s1h.Tables[0].Rows[0][0]) != 0)
            {
                //计算准确率

                //会员发布次数
                DataSet dsWinN = DbHelperSQL.Query("select top " + issueNum + " count(*) from v_ReCon where T_state='s1h' and C_name=" + "'" + userName + "'");
                if (dsWinN != null && dsWinN.Tables[0].Rows.Count > 0)
                {
                    decimal n_tws1h = Convert.ToDecimal(n_s1h.Tables[0].Rows[0][0]) / Convert.ToDecimal(dsWinN.Tables[0].Rows[0][0]) * 100;
                    sbStr.Append("<td>" + n_tws1h.ToString("0.##") + "%</td>");
                }
            }
            else
            {
                sbStr.Append("<td>0.00%</td>");
            }

            DataSet n_5dw = DbHelperSQL.Query("select count(*) from v_ReCon where T_state='5dw' and C_name=" + "'" + userName + "'" + " and C_win=1");
            if (n_5dw != null && n_5dw.Tables[0].Rows.Count > 0 && Convert.ToInt32(n_5dw.Tables[0].Rows[0][0]) != 0)
            {
                //计算准确率
                //会员发布次数
                DataSet dsWinN = DbHelperSQL.Query("select top " + issueNum + " count(*) from v_ReCon where T_state='5dw' and C_name=" + "'" + userName + "'");
                if (dsWinN != null && dsWinN.Tables[0].Rows.Count > 0)
                {
                    decimal n_tw5dw = Convert.ToDecimal(n_5dw.Tables[0].Rows[0][0]) / Convert.ToDecimal(dsWinN.Tables[0].Rows[0][0]) * 100;
                    sbStr.Append("<td>" + n_tw5dw.ToString("0.##") + "%</td>");
                }
            }
            else
            {
                sbStr.Append("<td>0.00%</td>");
            }

            DataSet n_3dw = DbHelperSQL.Query("select count(*) from v_ReCon where T_state='3dw' and C_name=" + "'" + userName + "'" + " and C_win=1");
            if (n_3dw != null && n_3dw.Tables[0].Rows.Count > 0 && Convert.ToInt32(n_3dw.Tables[0].Rows[0][0]) != 0)
            {
                //计算准确率
                //会员发布次数
                DataSet dsWinN = DbHelperSQL.Query("select top " + issueNum + " count(*) from v_ReCon where T_state='3dw' and C_name=" + "'" + userName + "'");
                if (dsWinN != null && dsWinN.Tables[0].Rows.Count > 0)
                {
                    decimal n_tw3dw = Convert.ToDecimal(n_3dw.Tables[0].Rows[0][0]) / Convert.ToDecimal(dsWinN.Tables[0].Rows[0][0]) * 100;
                    sbStr.Append("<td>" + n_tw3dw.ToString("0.##") + "%</td>");
                }
            }
            else
            {
                sbStr.Append("<td>0.00%</td>");
            }

            DataSet n_zx = DbHelperSQL.Query("select count(*) from v_ReCon where T_state='zx' and C_name=" + "'" + userName + "'" + " and C_win=1");
            if (n_zx != null && n_zx.Tables[0].Rows.Count > 0 && Convert.ToInt32(n_zx.Tables[0].Rows[0][0]) != 0)
            {
                //计算准确率
                //会员发布次数
                DataSet dsWinN = DbHelperSQL.Query("select top " + issueNum + " count(*) from v_ReCon where T_state='zx' and C_name=" + "'" + userName + "'");
                if (dsWinN != null && dsWinN.Tables[0].Rows.Count > 0)
                {
                    decimal n_twzx = Convert.ToDecimal(n_zx.Tables[0].Rows[0][0]) / Convert.ToDecimal(dsWinN.Tables[0].Rows[0][0]) * 100;
                    sbStr.Append("<td>" + n_twzx.ToString("0.##") + "%</td>");
                }
            }
            else
            {
                sbStr.Append("<td>0.00%</td>");
            }

            DataSet n_m = DbHelperSQL.Query("select count(*) from v_ReCon where T_state='m' and C_name=" + "'" + userName + "'" + " and C_win=1");
            if (n_m != null && n_m.Tables[0].Rows.Count > 0 && Convert.ToInt32(n_m.Tables[0].Rows[0][0]) != 0)
            {
                //计算准确率

                //会员发布次数
                DataSet dsWinN = DbHelperSQL.Query("select top " + issueNum + " count(*) from v_ReCon where T_state='m' and C_name=" + "'" + userName + "'");
                if (dsWinN != null && dsWinN.Tables[0].Rows.Count > 0)
                {
                    decimal n_twm = Convert.ToDecimal(n_m.Tables[0].Rows[0][0]) / Convert.ToDecimal(dsWinN.Tables[0].Rows[0][0]) * 100;
                    sbStr.Append("<td>" + n_twm.ToString("0.##") + "%</td>");
                }
            }
            else
            {
                sbStr.Append("<td>0.00%</td>");
            }

            sbStr.Append("</tr>");
            sbStr.Append("<tr>");
            sbStr.Append("<td colspan=\"2\">参数说明：</td>");
            sbStr.Append("<td colspan=\"12\" style=\"text-align: left; padding-left: 10px;\">");
            sbStr.Append("当前正确次数：会员预测正确次数的总和<br />");
            sbStr.Append("最大连对次数：连续出现正确次数的最大值<br />");
            sbStr.Append("当前连错次数：连续出现错误次数的最大值<br />");
            sbStr.Append("平均间隔期数：当前页面的总期数除以正确的次数<br />");
            sbStr.Append("成功率：正确的次数除以当前页面的总期数<br />");
            sbStr.Append("</td>");
            sbStr.Append("</tr>");
            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            return HttpContext.Current.Server.HtmlEncode(sbStr.ToString());
        }

        /// <summary>
        /// 个人成绩中出-----排列3
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [WebMethod]
        public string UserAchienement_p(string userName, int issueNum)
        {
            Pbzx.BLL.Challenge_Cinfo get_c = new Pbzx.BLL.Challenge_Cinfo();
            Pbzx.BLL.publicMethod get_p = new Pbzx.BLL.publicMethod();
            StringBuilder sbStr = new StringBuilder();
            sbStr.Append("<table width=\"960\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr class=\"cyc_fen cyc_hong\">");
            sbStr.Append("<td width=\"90\">期号</td>");
            sbStr.Append("<td width=\"145\">福彩3D开奖结果</td>");
            sbStr.Append("<td>独胆</td>");
            sbStr.Append("<td>双胆</td>");
            sbStr.Append("<td>组选1注</td>");
            sbStr.Append("<td>杀1码</td>");
            sbStr.Append("<td>杀2码</td>");
            sbStr.Append("<td>独跨</td>");
            sbStr.Append("<td>独合</td>");
            sbStr.Append("<td>杀1合</td>");
            sbStr.Append("<td>5*5*5定位</td>");
            sbStr.Append("<td>3*3*3定位</td>");
            sbStr.Append("<td>直选1注</td>");
            sbStr.Append("<td>5码</td>");
            sbStr.Append("</tr>");

            //查询所有用户发布的数据
            DataSet ds = DbHelperSQL.Query("select top "+ issueNum +" C_name,C_issue from Challenge_Cinfo where C_name=" + "'" + userName + "'" + " and C_lottID='9999' and C_win<>0 group by C_name,C_issue order by C_issue desc");
            sbStr.Append("<tr class=\"tr-hui\">");
            sbStr.Append("<td>当前" + Pbzx.BLL.publicMethod.Period(1) + "期</td>");
            sbStr.Append("<td></td>");
            sbStr.Append("<td colspan=\"12\"><span style=\"color: red;\">点击查看【" + userName + "】最新预测</span></td>");
            sbStr.Append("</tr>");
            sbStr.Append("</tbody>");

            sbStr.Append("<tbody>");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    //根据 会员名  期号 查询会员条件中奖情况
                    DataSet ds_win = get_c.GetCompOFs(issueNum, "C_name=" + "'" + userName + "'" + " and c_issue=" + Convert.ToInt32(ds.Tables[0].Rows[i]["C_issue"]) + " and C_lottID='9999'");


                    sbStr.Append("<tr class=\"tr-red\">");

                    sbStr.Append("<td>" + ds.Tables[0].Rows[i]["C_issue"].ToString() + "期</td>");
                    //查询开奖号码
                    string ds_Num = get_p.RlotteryNum("TCPL35Data", 9999, Convert.ToInt32(ds.Tables[0].Rows[i]["C_issue"]));
                    sbStr.Append("<td><font color=\"red\">" + ds_Num.ToString() + "</font></td>");

                    sbStr.Append("<td class=\"result\">" + (ds_win.Tables[0].Rows[0]["pdd"].ToString() == "1" ? "<font color=\"red\" style=\"font-size: 16px; font-weight: bold;\">√</font>" : "<b>×</b>") + "</td>");
                    sbStr.Append("<td class=\"result\">" + (ds_win.Tables[0].Rows[0]["psd"].ToString() == "1" ? "<font color=\"red\" style=\"font-size: 16px; font-weight: bold;\">√</font>" : "<b>×</b>") + "</td>");
                    sbStr.Append("<td class=\"result\">" + (ds_win.Tables[0].Rows[0]["pzx1z"].ToString() == "1" ? "<font color=\"red\" style=\"font-size: 16px; font-weight: bold;\">√</font>" : "<b>×</b>") + "</td>");
                    sbStr.Append("<td class=\"result\">" + (ds_win.Tables[0].Rows[0]["ps1m"].ToString() == "1" ? "<font color=\"red\" style=\"font-size: 16px; font-weight: bold;\">√</font>" : "<b>×</b>") + "</td>");
                    sbStr.Append("<td class=\"result\">" + (ds_win.Tables[0].Rows[0]["ps2m"].ToString() == "1" ? "<font color=\"red\" style=\"font-size: 16px; font-weight: bold;\">√</font>" : "<b>×</b>") + "</td>");
                    sbStr.Append("<td class=\"result\">" + (ds_win.Tables[0].Rows[0]["pdk"].ToString() == "1" ? "<font color=\"red\" style=\"font-size: 16px; font-weight: bold;\">√</font>" : "<b>×</b>") + "</td>");
                    sbStr.Append("<td class=\"result\">" + (ds_win.Tables[0].Rows[0]["pdh"].ToString() == "1" ? "<font color=\"red\" style=\"font-size: 16px; font-weight: bold;\">√</font>" : "<b>×</b>") + "</td>");
                    sbStr.Append("<td class=\"result\">" + (ds_win.Tables[0].Rows[0]["ps1h"].ToString() == "1" ? "<font color=\"red\" style=\"font-size: 16px; font-weight: bold;\">√</font>" : "<b>×</b>") + "</td>");
                    sbStr.Append("<td class=\"result\">" + (ds_win.Tables[0].Rows[0]["p5dw"].ToString() == "1" ? "<font color=\"red\" style=\"font-size: 16px; font-weight: bold;\">√</font>" : "<b>×</b>") + "</td>");
                    sbStr.Append("<td class=\"result\">" + (ds_win.Tables[0].Rows[0]["p3dw"].ToString() == "1" ? "<font color=\"red\" style=\"font-size: 16px; font-weight: bold;\">√</font>" : "<b>×</b>") + "</td>");
                    sbStr.Append("<td class=\"result\">" + (ds_win.Tables[0].Rows[0]["pzx"].ToString() == "1" ? "<font color=\"red\" style=\"font-size: 16px; font-weight: bold;\">√</font>" : "<b>×</b>") + "</td>");
                    sbStr.Append("<td class=\"result\">" + (ds_win.Tables[0].Rows[0]["p5m"].ToString() == "1" ? "<font color=\"red\" style=\"font-size: 16px; font-weight: bold;\">√</font>" : "<b>×</b>") + "</td>");
                    sbStr.Append("</tr>");

                }
            }
            sbStr.Append("</tbody>");

            //查询中奖数
            DataSet ds_WinNum = get_c.GetCompOFs(issueNum, "C_name=" + "'" + userName + "'" + " and C_lottID='9999'" + " and C_win=1");
            if (ds_WinNum != null && ds_WinNum.Tables[0].Rows.Count > 0)
            {
                sbStr.Append("<tbody>");
                sbStr.Append("<tr class=\"tr-red\">");
                sbStr.Append("<td colspan=\"2\">当前正确次数</td><td>");
                sbStr.Append(ds_WinNum.Tables[0].Rows[0]["pdd"].ToString() == "" ? "0" : ds_WinNum.Tables[0].Rows[0]["pdd"].ToString() + "</td><td>");
                sbStr.Append(ds_WinNum.Tables[0].Rows[0]["psd"].ToString() == "" ? "0" : ds_WinNum.Tables[0].Rows[0]["psd"].ToString() + "</td><td>");
                sbStr.Append(ds_WinNum.Tables[0].Rows[0]["pzx1z"].ToString() == "" ? "0" : ds_WinNum.Tables[0].Rows[0]["pzx1z"].ToString() + "</td><td>");
                sbStr.Append(ds_WinNum.Tables[0].Rows[0]["ps1m"].ToString() == "" ? "0" : ds_WinNum.Tables[0].Rows[0]["ps1m"].ToString() + "</td><td>");
                sbStr.Append(ds_WinNum.Tables[0].Rows[0]["ps2m"].ToString() == "" ? "0" : ds_WinNum.Tables[0].Rows[0]["ps2m"].ToString() + "</td><td>");
                sbStr.Append(ds_WinNum.Tables[0].Rows[0]["pdk"].ToString() == "" ? "0" : ds_WinNum.Tables[0].Rows[0]["pdk"].ToString() + "</td><td>");
                sbStr.Append(ds_WinNum.Tables[0].Rows[0]["pdh"].ToString() == "" ? "0" : ds_WinNum.Tables[0].Rows[0]["pdh"].ToString() + "</td><td>");
                sbStr.Append(ds_WinNum.Tables[0].Rows[0]["ps1h"].ToString() == "" ? "0" : ds_WinNum.Tables[0].Rows[0]["ps1h"].ToString() + "</td><td>");
                sbStr.Append(ds_WinNum.Tables[0].Rows[0]["p5dw"].ToString() == "" ? "0" : ds_WinNum.Tables[0].Rows[0]["p5dw"].ToString() + "</td><td>");
                sbStr.Append(ds_WinNum.Tables[0].Rows[0]["p3dw"].ToString() == "" ? "0" : ds_WinNum.Tables[0].Rows[0]["p3dw"].ToString() + "</td><td>");
                sbStr.Append(ds_WinNum.Tables[0].Rows[0]["pzx"].ToString() == "" ? "0" : ds_WinNum.Tables[0].Rows[0]["pzx"].ToString() + "</td><td>");
                sbStr.Append(ds_WinNum.Tables[0].Rows[0]["p5m"].ToString() == "" ? "0" : ds_WinNum.Tables[0].Rows[0]["p5m"].ToString() + "</td>");
                sbStr.Append("</tr>");
            }
            ////查询未中奖次数
            DataSet ds_Nw = get_c.GetCompOFs(issueNum, "C_name=" + "'" + userName + "'" + " and C_lottID='9999'" + " and C_win=2");
            //说明：未中奖 为标识为2   未中奖的次数 数据相加/2 为次数
            if (ds_Nw != null && ds_Nw.Tables[0].Rows.Count > 0)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td colspan=\"2\">当前错误次数</td><td>");
                sbStr.Append(ds_Nw.Tables[0].Rows[0]["pdd"].ToString() == "" ? "0" : Convert.ToInt32(ds_Nw.Tables[0].Rows[0]["pdd"].ToString()) / 2 + "</td><td>");
                sbStr.Append(ds_Nw.Tables[0].Rows[0]["psd"].ToString() == "" ? "0" : Convert.ToInt32(ds_Nw.Tables[0].Rows[0]["psd"].ToString()) / 2 + "</td><td>");
                sbStr.Append(ds_Nw.Tables[0].Rows[0]["pzx1z"].ToString() == "" ? "0" : Convert.ToInt32(ds_Nw.Tables[0].Rows[0]["pzx1z"].ToString()) / 2 + "</td><td>");
                sbStr.Append(ds_Nw.Tables[0].Rows[0]["ps1m"].ToString() == "" ? "0" : Convert.ToInt32(ds_Nw.Tables[0].Rows[0]["ps1m"].ToString()) / 2 + "</td><td>");
                sbStr.Append(ds_Nw.Tables[0].Rows[0]["ps2m"].ToString() == "" ? "0" : Convert.ToInt32(ds_Nw.Tables[0].Rows[0]["ps2m"].ToString()) / 2 + "</td><td>");
                sbStr.Append(ds_Nw.Tables[0].Rows[0]["pdk"].ToString() == "" ? "0" : Convert.ToInt32(ds_Nw.Tables[0].Rows[0]["pdk"].ToString()) / 2 + "</td><td>");
                sbStr.Append(ds_Nw.Tables[0].Rows[0]["pdh"].ToString() == "" ? "0" : Convert.ToInt32(ds_Nw.Tables[0].Rows[0]["pdh"].ToString()) / 2 + "</td><td>");
                sbStr.Append(ds_Nw.Tables[0].Rows[0]["ps1h"].ToString() == "" ? "0" : Convert.ToInt32(ds_Nw.Tables[0].Rows[0]["ps1h"].ToString()) / 2 + "</td><td>");
                sbStr.Append(ds_Nw.Tables[0].Rows[0]["p5dw"].ToString() == "" ? "0" : Convert.ToInt32(ds_Nw.Tables[0].Rows[0]["p5dw"].ToString()) / 2 + "</td><td>");
                sbStr.Append(ds_Nw.Tables[0].Rows[0]["p3dw"].ToString() == "" ? "0" : Convert.ToInt32(ds_Nw.Tables[0].Rows[0]["p3dw"].ToString()) / 2 + "</td><td>");
                sbStr.Append(ds_Nw.Tables[0].Rows[0]["pzx"].ToString() == "" ? "0" : Convert.ToInt32(ds_Nw.Tables[0].Rows[0]["pzx"].ToString()) / 2 + "</td><td>");
                sbStr.Append(ds_Nw.Tables[0].Rows[0]["p5m"].ToString() == "" ? "0" : Convert.ToInt32(ds_Nw.Tables[0].Rows[0]["p5m"].ToString()) / 2 + "</td>");
                sbStr.Append("</tr>");
            }
            sbStr.Append("<tr class=\"tr-red\">");
            sbStr.Append("<td colspan=\"2\">最大连错次数</td>");
            int n_err = 0;
            int n_errNum = 0;
            DataSet ds_errdd = get_p.Chipped_Table("v_ReCon", "*", "T_state='pdd' order by C_issue desc");
            for (int i = 0; i < ds_errdd.Tables[0].Rows.Count; i++)
            {
                if (i > 0)
                {
                    if (Convert.ToInt32(ds_errdd.Tables[0].Rows[i]["C_win"]) == 2)
                    {
                        //如果是当前年得第一期 
                        if (Convert.ToInt32(ds_errdd.Tables[0].Rows[i]["C_issue"]) == Convert.ToInt32(DateTime.Now.Year.ToString() + "001"))
                        {
                            //查询发布的最后一期
                            DataSet ds_f = DbHelperSQL1.Query("select top 1 issue from FC3DData order by issue desc");
                            if (Convert.ToInt32(ds_errdd.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_f.Tables[0].Rows[0]["issue"]) && Convert.ToInt32(ds_errdd.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(ds_errdd.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_errdd.Tables[0].Rows[i - 1]["C_issue"]) && Convert.ToInt32(ds_errdd.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                    }
                }
            }
            sbStr.Append("<td>" + n_errNum + "</td>");

            DataSet ds_errsd = get_p.Chipped_Table("v_ReCon", "*", "T_state='psd' order by C_issue desc");
            for (int i = 0; i < ds_errsd.Tables[0].Rows.Count; i++)
            {
                if (i > 0)
                {
                    if (Convert.ToInt32(ds_errsd.Tables[0].Rows[i]["C_win"]) == 2)
                    {
                        //如果是当前年得第一期 
                        if (Convert.ToInt32(ds_errsd.Tables[0].Rows[i]["C_issue"]) == Convert.ToInt32(DateTime.Now.Year.ToString() + "001"))
                        {
                            //查询发布的最后一期
                            DataSet ds_f = DbHelperSQL1.Query("select top 1 issue from FC3DData order by issue desc");
                            if (Convert.ToInt32(ds_errsd.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_f.Tables[0].Rows[0]["issue"]) && Convert.ToInt32(ds_errsd.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(ds_errsd.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_errsd.Tables[0].Rows[i - 1]["C_issue"]) && Convert.ToInt32(ds_errsd.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                    }
                }
            }
            sbStr.Append("<td>" + n_errNum + "</td>");

            DataSet ds_errzx1z = get_p.Chipped_Table("v_ReCon", "*", "T_state='pzx1z' order by C_issue desc");
            for (int i = 0; i < ds_errzx1z.Tables[0].Rows.Count; i++)
            {
                if (i > 0)
                {
                    if (Convert.ToInt32(ds_errzx1z.Tables[0].Rows[i]["C_win"]) == 2)
                    {
                        //如果是当前年得第一期 
                        if (Convert.ToInt32(ds_errzx1z.Tables[0].Rows[i]["C_issue"]) == Convert.ToInt32(DateTime.Now.Year.ToString() + "001"))
                        {
                            //查询发布的最后一期
                            DataSet ds_f = DbHelperSQL1.Query("select top 1 issue from FC3DData order by issue desc");
                            if (Convert.ToInt32(ds_errzx1z.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_f.Tables[0].Rows[0]["issue"]) && Convert.ToInt32(ds_errzx1z.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(ds_errzx1z.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_errzx1z.Tables[0].Rows[i - 1]["C_issue"]) && Convert.ToInt32(ds_errzx1z.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                    }
                }
            }
            sbStr.Append("<td>" + n_errNum + "</td>");

            DataSet ds_errs1m = get_p.Chipped_Table("v_ReCon", "*", "T_state='ps1m' order by C_issue desc");
            for (int i = 0; i < ds_errs1m.Tables[0].Rows.Count; i++)
            {
                if (i > 0)
                {
                    if (Convert.ToInt32(ds_errs1m.Tables[0].Rows[i]["C_win"]) == 2)
                    {
                        //如果是当前年得第一期 
                        if (Convert.ToInt32(ds_errs1m.Tables[0].Rows[i]["C_issue"]) == Convert.ToInt32(DateTime.Now.Year.ToString() + "001"))
                        {
                            //查询发布的最后一期
                            DataSet ds_f = DbHelperSQL1.Query("select top 1 issue from FC3DData order by issue desc");
                            if (Convert.ToInt32(ds_errs1m.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_f.Tables[0].Rows[0]["issue"]) && Convert.ToInt32(ds_errs1m.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(ds_errs1m.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_errs1m.Tables[0].Rows[i - 1]["C_issue"]) && Convert.ToInt32(ds_errs1m.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                    }
                }
            }
            sbStr.Append("<td>" + n_errNum + "</td>");

            DataSet ds_errs2m = get_p.Chipped_Table("v_ReCon", "*", "T_state='ps2m' order by C_issue desc");
            for (int i = 0; i < ds_errs2m.Tables[0].Rows.Count; i++)
            {
                if (i > 0)
                {
                    if (Convert.ToInt32(ds_errs2m.Tables[0].Rows[i]["C_win"]) == 2)
                    {
                        //如果是当前年得第一期 
                        if (Convert.ToInt32(ds_errs2m.Tables[0].Rows[i]["C_issue"]) == Convert.ToInt32(DateTime.Now.Year.ToString() + "001"))
                        {
                            //查询发布的最后一期
                            DataSet ds_f = DbHelperSQL1.Query("select top 1 issue from FC3DData order by issue desc");
                            if (Convert.ToInt32(ds_errs2m.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_f.Tables[0].Rows[0]["issue"]) && Convert.ToInt32(ds_errs2m.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(ds_errs2m.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_errs2m.Tables[0].Rows[i - 1]["C_issue"]) && Convert.ToInt32(ds_errs2m.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                    }
                }
            }
            sbStr.Append("<td>" + n_errNum + "</td>");

            DataSet ds_errdk = get_p.Chipped_Table("v_ReCon", "*", "T_state='pdk' order by C_issue desc");
            for (int i = 0; i < ds_errdk.Tables[0].Rows.Count; i++)
            {
                if (i > 0)
                {
                    if (Convert.ToInt32(ds_errdk.Tables[0].Rows[i]["C_win"]) == 2)
                    {
                        //如果是当前年得第一期 
                        if (Convert.ToInt32(ds_errdk.Tables[0].Rows[i]["C_issue"]) == Convert.ToInt32(DateTime.Now.Year.ToString() + "001"))
                        {
                            //查询发布的最后一期
                            DataSet ds_f = DbHelperSQL1.Query("select top 1 issue from FC3DData order by issue desc");
                            if (Convert.ToInt32(ds_errdk.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_f.Tables[0].Rows[0]["issue"]) && Convert.ToInt32(ds_errdk.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(ds_errdk.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_errdk.Tables[0].Rows[i - 1]["C_issue"]) && Convert.ToInt32(ds_errdk.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                    }
                }
            }
            sbStr.Append("<td>" + n_errNum + "</td>");

            DataSet ds_errdh = get_p.Chipped_Table("v_ReCon", "*", "T_state='pdh' order by C_issue desc");
            for (int i = 0; i < ds_errdh.Tables[0].Rows.Count; i++)
            {
                if (i > 0)
                {
                    if (Convert.ToInt32(ds_errdh.Tables[0].Rows[i]["C_win"]) == 2)
                    {
                        //如果是当前年得第一期 
                        if (Convert.ToInt32(ds_errdh.Tables[0].Rows[i]["C_issue"]) == Convert.ToInt32(DateTime.Now.Year.ToString() + "001"))
                        {
                            //查询发布的最后一期
                            DataSet ds_f = DbHelperSQL1.Query("select top 1 issue from FC3DData order by issue desc");
                            if (Convert.ToInt32(ds_errdh.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_f.Tables[0].Rows[0]["issue"]) && Convert.ToInt32(ds_errdh.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(ds_errdh.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_errdh.Tables[0].Rows[i - 1]["C_issue"]) && Convert.ToInt32(ds_errdh.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                    }
                }
            }
            sbStr.Append("<td>" + n_errNum + "</td>");

            DataSet ds_errs1h = get_p.Chipped_Table("v_ReCon", "*", "T_state='ps1h' order by C_issue desc");
            for (int i = 0; i < ds_errs1h.Tables[0].Rows.Count; i++)
            {
                if (i > 0)
                {
                    if (Convert.ToInt32(ds_errs1h.Tables[0].Rows[i]["C_win"]) == 2)
                    {
                        //如果是当前年得第一期 
                        if (Convert.ToInt32(ds_errs1h.Tables[0].Rows[i]["C_issue"]) == Convert.ToInt32(DateTime.Now.Year.ToString() + "001"))
                        {
                            //查询发布的最后一期
                            DataSet ds_f = DbHelperSQL1.Query("select top 1 issue from FC3DData order by issue desc");
                            if (Convert.ToInt32(ds_errs1h.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_f.Tables[0].Rows[0]["issue"]) && Convert.ToInt32(ds_errs1h.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(ds_errs1h.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_errs1h.Tables[0].Rows[i - 1]["C_issue"]) && Convert.ToInt32(ds_errs1h.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                    }
                }
            }
            sbStr.Append("<td>" + n_errNum + "</td>");

            DataSet ds_err5dw = get_p.Chipped_Table("v_ReCon", "*", "T_state='p5dw' order by C_issue desc");
            for (int i = 0; i < ds_err5dw.Tables[0].Rows.Count; i++)
            {
                if (i > 0)
                {
                    if (Convert.ToInt32(ds_err5dw.Tables[0].Rows[i]["C_win"]) == 2)
                    {
                        //如果是当前年得第一期 
                        if (Convert.ToInt32(ds_err5dw.Tables[0].Rows[i]["C_issue"]) == Convert.ToInt32(DateTime.Now.Year.ToString() + "001"))
                        {
                            //查询发布的最后一期
                            DataSet ds_f = DbHelperSQL1.Query("select top 1 issue from FC3DData order by issue desc");
                            if (Convert.ToInt32(ds_err5dw.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_f.Tables[0].Rows[0]["issue"]) && Convert.ToInt32(ds_err5dw.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(ds_err5dw.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_err5dw.Tables[0].Rows[i - 1]["C_issue"]) && Convert.ToInt32(ds_err5dw.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                    }
                }
            }
            sbStr.Append("<td>" + n_errNum + "</td>");

            DataSet ds_err3dw = get_p.Chipped_Table("v_ReCon", "*", "T_state='p3dw' order by C_issue desc");
            for (int i = 0; i < ds_err3dw.Tables[0].Rows.Count; i++)
            {
                if (i > 0)
                {
                    if (Convert.ToInt32(ds_err3dw.Tables[0].Rows[i]["C_win"]) == 2)
                    {
                        //如果是当前年得第一期 
                        if (Convert.ToInt32(ds_err3dw.Tables[0].Rows[i]["C_issue"]) == Convert.ToInt32(DateTime.Now.Year.ToString() + "001"))
                        {
                            //查询发布的最后一期
                            DataSet ds_f = DbHelperSQL1.Query("select top 1 issue from FC3DData order by issue desc");
                            if (Convert.ToInt32(ds_err3dw.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_f.Tables[0].Rows[0]["issue"]) && Convert.ToInt32(ds_err3dw.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(ds_err3dw.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_err3dw.Tables[0].Rows[i - 1]["C_issue"]) && Convert.ToInt32(ds_err3dw.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                    }
                }
            }
            sbStr.Append("<td>" + n_errNum + "</td>");

            DataSet ds_errzx = get_p.Chipped_Table("v_ReCon", "*", "T_state='pzx' order by C_issue desc");
            for (int i = 0; i < ds_errzx.Tables[0].Rows.Count; i++)
            {
                if (i > 0)
                {
                    if (Convert.ToInt32(ds_errzx.Tables[0].Rows[i]["C_win"]) == 2)
                    {
                        //如果是当前年得第一期 
                        if (Convert.ToInt32(ds_errzx.Tables[0].Rows[i]["C_issue"]) == Convert.ToInt32(DateTime.Now.Year.ToString() + "001"))
                        {
                            //查询发布的最后一期
                            DataSet ds_f = DbHelperSQL1.Query("select top 1 issue from FC3DData order by issue desc");
                            if (Convert.ToInt32(ds_errzx.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_f.Tables[0].Rows[0]["issue"]) && Convert.ToInt32(ds_errzx.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(ds_errzx.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_errzx.Tables[0].Rows[i - 1]["C_issue"]) && Convert.ToInt32(ds_errzx.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                    }
                }
            }
            sbStr.Append("<td>" + n_errNum + "</td>");

            DataSet ds_errm = get_p.Chipped_Table("v_ReCon", "*", "T_state='p5m' order by C_issue desc");
            for (int i = 0; i < ds_errm.Tables[0].Rows.Count; i++)
            {
                if (i > 0)
                {
                    if (Convert.ToInt32(ds_errm.Tables[0].Rows[i]["C_win"]) == 2)
                    {
                        //如果是当前年得第一期 
                        if (Convert.ToInt32(ds_errm.Tables[0].Rows[i]["C_issue"]) == Convert.ToInt32(DateTime.Now.Year.ToString() + "001"))
                        {
                            //查询发布的最后一期
                            DataSet ds_f = DbHelperSQL1.Query("select top 1 issue from FC3DData order by issue desc");
                            if (Convert.ToInt32(ds_errm.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_f.Tables[0].Rows[0]["issue"]) && Convert.ToInt32(ds_errm.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(ds_errm.Tables[0].Rows[i]["C_issue"]) - 1 == Convert.ToInt32(ds_errm.Tables[0].Rows[i - 1]["C_issue"]) && Convert.ToInt32(ds_errm.Tables[0].Rows[i]["C_win"]) == 2)
                            {
                                n_err = n_err + 2;
                                if (n_err > n_errNum)
                                {
                                    n_errNum = n_err;
                                    n_err = 0;
                                }
                            }
                        }
                    }
                }
            }
            sbStr.Append("<td>" + n_errNum + "</td>");
            sbStr.Append("</tr>");
            //                <tr>
            //                    <td colspan="2">最大连对次数</td>
            //                    <td>3</td>
            //                    <td>6</td>
            //                    <td>1</td>
            //                    <td>2</td>
            //                    <td>7</td>
            //                    <td>4</td>
            //                    <td>1</td>
            //                    <td>9</td>
            //                    <td>9</td>
            //                    <td>3</td>
            //                    <td>1</td>
            //                </tr>




            sbStr.Append("<tr class=\"tr-red\">");
            sbStr.Append("<td colspan=\"2\">准确率</td>");
            //红球3胆
            DataSet n_pdd = DbHelperSQL.Query("select count(*) from v_ReCon where T_state='pdd' and C_name=" + "'" + userName + "'" + " and C_win=1");
            if (n_pdd != null && n_pdd.Tables[0].Rows.Count > 0 && Convert.ToInt32(n_pdd.Tables[0].Rows[0][0]) != 0)
            {
                //计算准确率

                //会员发布次数
                DataSet dsWinN = DbHelperSQL.Query("select top " + issueNum + " count(*) from v_ReCon where T_state='pdd' and C_name=" + "'" + userName + "'");
                if (dsWinN != null && dsWinN.Tables[0].Rows.Count > 0)
                {
                    decimal n_twpdd = Convert.ToDecimal(n_pdd.Tables[0].Rows[0][0]) / Convert.ToDecimal(dsWinN.Tables[0].Rows[0][0]) * 100;
                    sbStr.Append("<td>" + n_twpdd.ToString("0.##") + "%</td>");
                }
            }
            else
            {
                sbStr.Append("<td>0.00%</td>");
            }
            DataSet n_psd = DbHelperSQL.Query("select count(*) from v_ReCon where T_state='psd' and C_name=" + "'" + userName + "'" + " and C_win=1");
            if (n_psd != null && n_psd.Tables[0].Rows.Count > 0 && Convert.ToInt32(n_psd.Tables[0].Rows[0][0]) != 0)
            {
                //计算准确率

                //会员发布次数
                DataSet dsWinN = DbHelperSQL.Query("select top " + issueNum + " count(*) from v_ReCon where T_state='psd' and C_name=" + "'" + userName + "'");
                if (dsWinN != null && dsWinN.Tables[0].Rows.Count > 0)
                {
                    decimal n_twpsd = Convert.ToDecimal(n_psd.Tables[0].Rows[0][0]) / Convert.ToDecimal(dsWinN.Tables[0].Rows[0][0]) * 100;
                    sbStr.Append("<td>" + n_twpsd.ToString("0.##") + "%</td>");
                }
            }
            else
            {
                sbStr.Append("<td>0.00%</td>");
            }

            DataSet n_pzx1z = DbHelperSQL.Query("select count(*) from v_ReCon where T_state='pzx1z' and C_name=" + "'" + userName + "'" + " and C_win=1");
            if (n_pzx1z != null && n_pzx1z.Tables[0].Rows.Count > 0 && Convert.ToInt32(n_pzx1z.Tables[0].Rows[0][0]) != 0)
            {
                //计算准确率

                //会员发布次数
                DataSet dsWinN = DbHelperSQL.Query("select top " + issueNum + " count(*) from v_ReCon where T_state='pzx1z' and C_name=" + "'" + userName + "'");
                if (dsWinN != null && dsWinN.Tables[0].Rows.Count > 0)
                {
                    decimal n_twpzx1z = Convert.ToDecimal(n_pzx1z.Tables[0].Rows[0][0]) / Convert.ToDecimal(dsWinN.Tables[0].Rows[0][0]) * 100;
                    sbStr.Append("<td>" + n_twpzx1z.ToString("0.##") + "%</td>");
                }
            }
            else
            {
                sbStr.Append("<td>0.00%</td>");
            }

            DataSet n_ps1m = DbHelperSQL.Query("select count(*) from v_ReCon where T_state='ps1m' and C_name=" + "'" + userName + "'" + " and C_win=1");
            if (n_ps1m != null && n_ps1m.Tables[0].Rows.Count > 0 && Convert.ToInt32(n_ps1m.Tables[0].Rows[0][0]) != 0)
            {
                //计算准确率

                //会员发布次数
                DataSet dsWinN = DbHelperSQL.Query("select top " + issueNum + " count(*) from v_ReCon where T_state='ps1m' and C_name=" + "'" + userName + "'");
                if (dsWinN != null && dsWinN.Tables[0].Rows.Count > 0)
                {
                    decimal n_twps1m = Convert.ToDecimal(n_ps1m.Tables[0].Rows[0][0]) / Convert.ToDecimal(dsWinN.Tables[0].Rows[0][0]) * 100;
                    sbStr.Append("<td>" + n_twps1m.ToString("0.##") + "%</td>");
                }
            }
            else
            {
                sbStr.Append("<td>0.00%</td>");
            }

            DataSet n_ps2m = DbHelperSQL.Query("select count(*) from v_ReCon where T_state='ps2m' and C_name=" + "'" + userName + "'" + " and C_win=1");
            if (n_ps2m != null && n_ps2m.Tables[0].Rows.Count > 0 && Convert.ToInt32(n_ps2m.Tables[0].Rows[0][0]) != 0)
            {
                //计算准确率
                //会员发布次数
                DataSet dsWinN = DbHelperSQL.Query("select top " + issueNum + " count(*) from v_ReCon where T_state='ps2m' and C_name=" + "'" + userName + "'");
                if (dsWinN != null && dsWinN.Tables[0].Rows.Count > 0)
                {
                    decimal n_twps2m = Convert.ToDecimal(n_ps2m.Tables[0].Rows[0][0]) / Convert.ToDecimal(dsWinN.Tables[0].Rows[0][0]) * 100;
                    sbStr.Append("<td>" + n_twps2m.ToString("0.##") + "%</td>");
                }
            }
            else
            {
                sbStr.Append("<td>0.00%</td>");
            }

            DataSet n_pdk = DbHelperSQL.Query("select count(*) from v_ReCon where T_state='pdk' and C_name=" + "'" + userName + "'" + " and C_win=1");
            if (n_pdk != null && n_pdk.Tables[0].Rows.Count > 0 && Convert.ToInt32(n_pdk.Tables[0].Rows[0][0]) != 0)
            {
                //计算准确率

                //会员发布次数
                DataSet dsWinN = DbHelperSQL.Query("select top " + issueNum + " count(*) from v_ReCon where T_state='pdk' and C_name=" + "'" + userName + "'");
                if (dsWinN != null && dsWinN.Tables[0].Rows.Count > 0)
                {
                    decimal n_twpdk = Convert.ToDecimal(n_pdk.Tables[0].Rows[0][0]) / Convert.ToDecimal(dsWinN.Tables[0].Rows[0][0]) * 100;
                    sbStr.Append("<td>" + n_twpdk.ToString("0.##") + "%</td>");
                }
            }
            else
            {
                sbStr.Append("<td>0.00%</td>");
            }

            DataSet n_pdh = DbHelperSQL.Query("select count(*) from v_ReCon where T_state='pdh' and C_name=" + "'" + userName + "'" + " and C_win=1");
            if (n_pdh != null && n_pdh.Tables[0].Rows.Count > 0 && Convert.ToInt32(n_pdh.Tables[0].Rows[0][0]) != 0)
            {
                //计算准确率

                //会员发布次数
                DataSet dsWinN = DbHelperSQL.Query("select top " + issueNum + " count(*) from v_ReCon where T_state='pdh' and C_name=" + "'" + userName + "'");
                if (dsWinN != null && dsWinN.Tables[0].Rows.Count > 0)
                {
                    decimal n_twpdh = Convert.ToDecimal(n_pdh.Tables[0].Rows[0][0]) / Convert.ToDecimal(dsWinN.Tables[0].Rows[0][0]) * 100;
                    sbStr.Append("<td>" + n_twpdh.ToString("0.##") + "%</td>");
                }
            }
            else
            {
                sbStr.Append("<td>0.00%</td>");
            }

            DataSet n_ps1h = DbHelperSQL.Query("select count(*) from v_ReCon where T_state='ps1h' and C_name=" + "'" + userName + "'" + " and C_win=1");
            if (n_ps1h != null && n_ps1h.Tables[0].Rows.Count > 0 && Convert.ToInt32(n_ps1h.Tables[0].Rows[0][0]) != 0)
            {
                //计算准确率

                //会员发布次数
                DataSet dsWinN = DbHelperSQL.Query("select top " + issueNum + " count(*) from v_ReCon where T_state='ps1h' and C_name=" + "'" + userName + "'");
                if (dsWinN != null && dsWinN.Tables[0].Rows.Count > 0)
                {
                    decimal n_twps1h = Convert.ToDecimal(n_ps1h.Tables[0].Rows[0][0]) / Convert.ToDecimal(dsWinN.Tables[0].Rows[0][0]) * 100;
                    sbStr.Append("<td>" + n_twps1h.ToString("0.##") + "%</td>");
                }
            }
            else
            {
                sbStr.Append("<td>0.00%</td>");
            }

            DataSet n_p5dw = DbHelperSQL.Query("select count(*) from v_ReCon where T_state='p5dw' and C_name=" + "'" + userName + "'" + " and C_win=1");
            if (n_p5dw != null && n_p5dw.Tables[0].Rows.Count > 0 && Convert.ToInt32(n_p5dw.Tables[0].Rows[0][0]) != 0)
            {
                //计算准确率

                 //会员发布次数
                DataSet dsWinN = DbHelperSQL.Query("select top " + issueNum + " count(*) from v_ReCon where T_state='p5dw' and C_name=" + "'" + userName + "'");
                if (dsWinN != null && dsWinN.Tables[0].Rows.Count > 0)
                {
                    decimal n_twp5dw = Convert.ToDecimal(n_p5dw.Tables[0].Rows[0][0]) / Convert.ToDecimal(dsWinN.Tables[0].Rows[0][0]) * 100;
                    sbStr.Append("<td>" + n_twp5dw.ToString("0.##") + "%</td>");
                }
            }
            else
            {
                sbStr.Append("<td>0.00%</td>");
            }

            DataSet n_p3dw = DbHelperSQL.Query("select count(*) from v_ReCon where T_state='p3dw' and C_name=" + "'" + userName + "'" + " and C_win=1");
            if (n_p3dw != null && n_p3dw.Tables[0].Rows.Count > 0 && Convert.ToInt32(n_p3dw.Tables[0].Rows[0][0]) != 0)
            {
                //计算准确率

                 //会员发布次数
                DataSet dsWinN = DbHelperSQL.Query("select top " + issueNum + " count(*) from v_ReCon where T_state='p3dw' and C_name=" + "'" + userName + "'");
                if (dsWinN != null && dsWinN.Tables[0].Rows.Count > 0)
                {
                    decimal n_twp3dw = Convert.ToDecimal(n_p3dw.Tables[0].Rows[0][0]) / Convert.ToDecimal(dsWinN.Tables[0].Rows[0][0]) * 100;
                    sbStr.Append("<td>" + n_twp3dw.ToString("0.##") + "%</td>");
                }
            }
            else
            {
                sbStr.Append("<td>0.00%</td>");
            }

            DataSet n_pzx = DbHelperSQL.Query("select count(*) from v_ReCon where T_state='pzx' and C_name=" + "'" + userName + "'" + " and C_win=1");
            if (n_pzx != null && n_pzx.Tables[0].Rows.Count > 0 && Convert.ToInt32(n_pzx.Tables[0].Rows[0][0]) != 0)
            {
                //计算准确率

                //会员发布次数
                DataSet dsWinN = DbHelperSQL.Query("select top " + issueNum + " count(*) from v_ReCon where T_state='pzx' and C_name=" + "'" + userName + "'");
                if (dsWinN != null && dsWinN.Tables[0].Rows.Count > 0)
                {
                    decimal n_twpzx = Convert.ToDecimal(n_pzx.Tables[0].Rows[0][0]) / Convert.ToDecimal(dsWinN.Tables[0].Rows[0][0]) * 100;
                    sbStr.Append("<td>" + n_twpzx.ToString("0.##") + "%</td>");
                }
            }
            else
            {
                sbStr.Append("<td>0.00%</td>");
            }

            DataSet n_p5m = DbHelperSQL.Query("select count(*) from v_ReCon where T_state='p5m' and C_name=" + "'" + userName + "'" + " and C_win=1");
            if (n_p5m != null && n_p5m.Tables[0].Rows.Count > 0 && Convert.ToInt32(n_p5m.Tables[0].Rows[0][0]) != 0)
            {
                //计算准确率

                 //会员发布次数
                DataSet dsWinN = DbHelperSQL.Query("select top " + issueNum + " count(*) from v_ReCon where T_state='p5m' and C_name=" + "'" + userName + "'");
                if (dsWinN != null && dsWinN.Tables[0].Rows.Count > 0)
                {
                    decimal n_twp5m = Convert.ToDecimal(n_p5m.Tables[0].Rows[0][0]) / Convert.ToDecimal(dsWinN.Tables[0].Rows[0][0]) * 100;
                    sbStr.Append("<td>" + n_twp5m.ToString("0.##") + "%</td>");
                }
            }
            else
            {
                sbStr.Append("<td>0.00%</td>");
            }

            sbStr.Append("</tr>");
            sbStr.Append("<tr>");
            sbStr.Append("<td colspan=\"2\">参数说明：</td>");
            sbStr.Append("<td colspan=\"12\" style=\"text-align: left; padding-left: 10px;\">");
            sbStr.Append("当前正确次数：会员预测正确次数的总和<br />");
            sbStr.Append("最大连对次数：连续出现正确次数的最大值<br />");
            sbStr.Append("当前连错次数：连续出现错误次数的最大值<br />");
            sbStr.Append("平均间隔期数：当前页面的总期数除以正确的次数<br />");
            sbStr.Append("成功率：正确的次数除以当前页面的总期数<br />");
            sbStr.Append("</td>");
            sbStr.Append("</tr>");
            sbStr.Append("</tbody>");
            sbStr.Append("</table>");
            return HttpContext.Current.Server.HtmlEncode(sbStr.ToString());
        }




        //查询12+3蓝  9红+2蓝所中的号码
        /// <summary>
        /// 返回 所中的个数
        /// </summary>
        /// <param name="WNum"></param>
        /// <param name="ChoiceNum"></param>
        /// <returns></returns>
        private string SelectNum(string WNum, string ChoiceNum)
        {
            //红球中奖个数
            int n_numR = 0;
            //蓝球中奖个数
            int n_numB = 0;

            //开奖号码红球
            string l_red = WNum.Split('+')[0].ToString();
            //开奖号码蓝球
            string l_blue = WNum.Split('+')[1].ToString();

            //自选号码红球
            string o_red = ChoiceNum.Split('+')[0].ToString();
            //自选号码蓝球
            string o_blue = ChoiceNum.Split('+')[1].ToString();

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

            return n_numR.ToString() +"+"+ n_numB.ToString();
        }
        #endregion

        #region    条件成绩对比
        /// <summary>
        /// 条件成绩列表   contrast.aspx 页
        /// </summary>
        /// <param name="cond"></param>
        /// <returns></returns>
        [WebMethod]
        public string LottCon(int num,string cond)
        {
            Pbzx.BLL.Challenge_Cinfo get_c = new Pbzx.BLL.Challenge_Cinfo();
            Pbzx.BLL.Challenge_integral get_i = new Pbzx.BLL.Challenge_integral();
            StringBuilder sbStr = new StringBuilder();

            sbStr.Append("<div class=\"cyc_box0\">");
            sbStr.Append("<table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\">");
            sbStr.Append("<tbody>");
            sbStr.Append("<tr class=\"cyc_fen cyc_hong\">");
            sbStr.Append("<td colspan=\"6\">近7期成绩</td></tr>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>选择</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>成绩</td>");
            sbStr.Append("<td>准确率</td>");
            sbStr.Append("<td>积分</td>");
            sbStr.Append("</tr>");
            sbStr.Append("</tbody>");

            //成绩排行
            DataSet ds = get_c.GetCompOFs(num,7, "T_state="+ "'"+ cond +"'" +" and C_win='1'");
            int n_rank = 1;
            sbStr.Append("<tbody id=\"results0\">");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td>"+ n_rank +"</td>");
                sbStr.Append("<td><input type=\"checkbox\" name=\"chk\" value=\"21903\" onclick=\"checkValue(this)\" /></td>");
                sbStr.Append("<td><img src=\"images/credit.gif\" />&nbsp;<a href='Person.aspx?name=" + Server.UrlEncode(dr[0].ToString()) + "' target=\"_blank\">" + dr[0].ToString() + "</a></td>");

                sbStr.Append("<td>7中<font color='#ff0000'>" + dr[cond].ToString() + "</font></td>");

                //DataSet n_ds = DbHelperSQL.Query("select top 7 count(*) from v_ReCon where T_state=" + "'" + cond + "'" + " and C_name=" + "'" + dr[0].ToString() + "'");
                //if (n_ds != null && n_ds.Tables[0].Rows.Count > 0 && Convert.ToInt32(n_ds.Tables[0].Rows[0][0]) != 0)
                //{
                //    //计算准确率
                //    decimal n_tw = Convert.ToDecimal(ds.Tables[0].Rows[0][""+ cond +""]) / Convert.ToDecimal(n_ds.Tables[0].Rows[0][0]) * 100;
                //    sbStr.Append("<td>" + n_tw.ToString("0.##") + "%</td>");
                //}
                //else
                //{
                //    sbStr.Append("<td>0.00%</td>");
                //}

                //计算准确率
                decimal n_tw = Convert.ToDecimal(dr[cond]) / 7 * 100;
                sbStr.Append("<td>" + n_tw.ToString("0.##") + "%</td>");

                //查询积分
                DataSet ds_i = get_i.GetList("I_name=" + "'" + dr[0].ToString() + "'" + " and I_condName="+"'"+ cond +"'");
                if (ds_i != null && ds_i.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td class=\"result\">" + ds_i.Tables[0].Rows[0]["I_Integral"].ToString() + "</td>");
                }
                else
                {
                    sbStr.Append("<td class=\"result\">0</td>");
                }
                
                sbStr.Append("</tr>");
                n_rank++;
            }
            sbStr.Append("</tbody>");

            sbStr.Append("</table>");
            sbStr.Append("</div>");

            sbStr.Append("<div class=\"cyc_box1\">");
            sbStr.Append("<table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\">");
            sbStr.Append("<tbody><tr class=\"cyc_fen cyc_hong\">");
            sbStr.Append("<td colspan=\"6\">近15期成绩</td></tr>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>选择</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>成绩</td>");
            sbStr.Append("<td>准确率</td>");
            sbStr.Append("<td>积分</td>");
            sbStr.Append("</tr>");
            sbStr.Append("</tbody>");

            //红球3胆成绩排行
            DataSet ds_f = get_c.GetCompOFs(num,15, "T_state=" + "'" + cond + "'" + " and C_win='1'");
            int n_rr = 1;
            sbStr.Append("<tbody id=\"results0\">");
            foreach (DataRow dr in ds_f.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td>"+ n_rr +"</td>");
                sbStr.Append("<td><input type=\"checkbox\" name=\"chk\" value=\"21903\" onclick=\"checkValue(this)\" /></td>");
                sbStr.Append("<td><img src=\"images/credit.gif\" />&nbsp;<a href='Person.aspx?name=" + Server.UrlEncode(dr[0].ToString()) + "' target=\"_blank\">" + dr[0].ToString() + "</a></td>");
                sbStr.Append("<td>15中<font color='#ff0000'>"+ dr[cond].ToString() +"</font></td>");
                //DataSet n_ds = DbHelperSQL.Query("select top 15 count(*) from v_ReCon where T_state=" + "'" + cond + "'" + " and C_name=" + "'" + dr[0].ToString() + "'");
                //if (n_ds != null && n_ds.Tables[0].Rows.Count > 0 && Convert.ToInt32(n_ds.Tables[0].Rows[0][0]) != 0)
                //{
                //    //计算准确率
                //    decimal n_tw = Convert.ToDecimal(ds_f.Tables[0].Rows[0][""+ cond +""]) / Convert.ToDecimal(n_ds.Tables[0].Rows[0][0]) * 100;
                //    sbStr.Append("<td>" + n_tw.ToString("0.##") + "%</td>");
                //}
                //else
                //{
                //    sbStr.Append("<td>0.00%</td>");
                //}
                decimal n_tw = Convert.ToDecimal(dr[cond]) / 15 * 100;
                sbStr.Append("<td>" + n_tw.ToString("0.##") + "%</td>");

                //查询积分
                DataSet ds_i = get_i.GetList("I_name=" + "'" + dr[0].ToString() + "'" + " and I_condName="+"'"+ cond +"'");
                if (ds_i != null && ds_i.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td class=\"result\">" + ds_i.Tables[0].Rows[0]["I_Integral"].ToString() + "</td>");
                }
                else
                {
                    sbStr.Append("<td class=\"result\">0</td>");
                }
                
                sbStr.Append("</tr>");
                n_rr++;
            }
            sbStr.Append("</tbody>");

            sbStr.Append("</table>");
            sbStr.Append("</div>");



            sbStr.Append("<div class=\"cyc_box2\">");
            sbStr.Append("<table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\">");
            sbStr.Append("<tbody><tr class=\"cyc_fen cyc_hong\">");
            sbStr.Append("<td colspan=\"6\">近30期成绩</td></tr>");
            sbStr.Append("<tr>");
            sbStr.Append("<td>排名</td>");
            sbStr.Append("<td>选择</td>");
            sbStr.Append("<td>会员</td>");
            sbStr.Append("<td>成绩</td>");
            sbStr.Append("<td>准确率</td>");
            sbStr.Append("<td>积分</td>");
            sbStr.Append("</tr>");
            sbStr.Append("</tbody>");

            //成绩排行
            DataSet ds_t = get_c.GetCompOFs(num,30, "T_state=" + "'" + cond + "'" + " and C_win='1'");
            int n_rt = 1;
            sbStr.Append("<tbody id=\"results0\">");
            foreach (DataRow dr in ds_t.Tables[0].Rows)
            {
                sbStr.Append("<tr>");
                sbStr.Append("<td>" + n_rt + "</td>");
                sbStr.Append("<td><input type=\"checkbox\" name=\"chk\" value=\"21903\" onclick=\"checkValue(this)\" /></td>");
                sbStr.Append("<td><img src=\"images/credit.gif\" />&nbsp;<a href='Person.aspx?name=" + Server.UrlEncode(dr[0].ToString()) + "' target=\"_blank\">" + dr[0].ToString() + "</a></td>");
                sbStr.Append("<td>30中<font color='#ff0000'>" + dr[cond].ToString() + "</font></td>");
                //DataSet n_ds = DbHelperSQL.Query("select top 30 count(*) from v_ReCon where T_state=" + "'" + cond + "'" + " and C_name=" + "'" + dr[0].ToString() + "'");
                //if (n_ds != null && n_ds.Tables[0].Rows.Count > 0 && Convert.ToInt32(n_ds.Tables[0].Rows[0][0]) != 0)
                //{
                //    //计算准确率
                //    decimal n_tw = Convert.ToDecimal(ds_t.Tables[0].Rows[0]["" + cond + ""]) / Convert.ToDecimal(n_ds.Tables[0].Rows[0][0]) * 100;
                //    sbStr.Append("<td>" + n_tw.ToString("0.##") + "%</td>");
                //}
                //else
                //{
                //    sbStr.Append("<td>0.00%</td>");
                //}
                decimal n_tw = Convert.ToDecimal(dr[cond]) / 30 * 100;
                sbStr.Append("<td>" + n_tw.ToString("0.##") + "%</td>");

                //查询积分
                DataSet ds_i = get_i.GetList("I_name=" + "'" + dr[0].ToString() + "'" + " and I_condName=" + "'" + cond + "'");
                if (ds_i != null && ds_i.Tables[0].Rows.Count > 0)
                {
                    sbStr.Append("<td class=\"result\">" + ds_i.Tables[0].Rows[0]["I_Integral"].ToString() + "</td>");
                }
                else
                {
                    sbStr.Append("<td class=\"result\">0</td>");
                }

                sbStr.Append("</tr>");
                n_rt++;
            }
            sbStr.Append("</tbody>");

            sbStr.Append("</table>");
            sbStr.Append("</div>");

            return HttpContext.Current.Server.HtmlEncode(sbStr.ToString());
        }

        #endregion



        /// <summary>
        /// 查询当前期号
        /// </summary>
        /// <param name="lottID">彩种编号</param>
        /// <returns></returns>
        [WebMethod]
        public string Period(int lottID)
        {
            string issue = "";
            if (lottID == 9999)
            {
                issue = Pbzx.BLL.publicMethod.Period(4);
            }
            else
            {
                issue = Pbzx.BLL.publicMethod.Period(lottID);
            }
            return issue;
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
            //双色球
            if (playName == "3")
            {
                dt = Pbzx.Common.Method.GetSSQDateTime.ToString();
            }
            //排列三五
            if (playName == "9999")
            {
                dt = Pbzx.Common.Method.GetTCPL35DateTime.ToString();
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
        /// 检查是已经截止发布
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string AllowTime(string playName)
        {
            string dt = "";
            //3D
            if (playName == "1")
            {
                dt = Pbzx.Common.Method.GetFCDateTime.ToString();
            }
            //双色球
            if (playName == "3")
            {
                dt = Pbzx.Common.Method.GetSSQDateTime.ToString();
            }
            //排列三五
            if (playName == "9999")
            {
                dt = Pbzx.Common.Method.GetTCPL35DateTime.ToString();
            }
            return dt;
        }

        #region 首页上下翻页处理
        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="lottN">彩种标识</param>
        /// <param name="issue">期号</param>
        /// <returns></returns>
        [WebMethod]
        public string Flip(string lottN, string issue,string name)
        {
            Pbzx.BLL.Challenge_Cinfo get_c = new Pbzx.BLL.Challenge_Cinfo();
            DataSet ds = new DataSet();
            StringBuilder sb = new StringBuilder();
            if (lottN == "s")
            {
                if (IsNumeric(issue))
                {
                    ds = get_c.GetBankTransfer("C_issue=" + "'" + issue + "'");
                }
                else
                {
                    ds = get_c.GetBankTransfer("C_name=" + "'" + name + "'");
                }
                sb.Append("<table class=\"ssq-expert-charts\">");
                sb.Append("<tr height=\"30px\" class=\"back-color color-blue\">");
                sb.Append("<td>序号</td>");
                sb.Append("<td>期号</td>");
                sb.Append("<td>会员</td>");
                sb.Append("<td><a href=\"contrast.aspx?Ind=hq3d&n=s\" target=\"_blank\" class=\"color-blue\">红球3胆</a></td>");
                sb.Append("<td><a href=\"contrast.aspx?Ind=hq6d&n=s\" target=\"_blank\" class=\"color-blue\">红球6胆</a></td>");
                sb.Append("<td><a href=\"contrast.aspx?Ind=s3hq&n=s\" target=\"_blank\" class=\"color-blue\">杀3红球</a></td>");
                sb.Append("<td><a href=\"contrast.aspx?Ind=s6hq&n=s\" target=\"_blank\" class=\"color-blue\">杀6红球</a></td>");
                sb.Append("<td><a href=\"contrast.aspx?Ind=lq1d&n=s\" target=\"_blank\" class=\"color-blue\">篮球1胆</a></td>");
                sb.Append("<td><a href=\"contrast.aspx?Ind=lq3d&n=s\" target=\"_blank\" class=\"color-blue\">蓝球3胆</a></td>");
                sb.Append("<td><a href=\"contrast.aspx?Ind=s3lq&n=s\" target=\"_blank\" class=\"color-blue\">杀3蓝球</a></td>");
                sb.Append("<td><a href=\"contrast.aspx?Ind=s6lq&n=s\" target=\"_blank\" class=\"color-blue\">杀6蓝球</a></td>");
                sb.Append("<td><a href=\"contrast.aspx?Ind=h3l&n=s\" target=\"_blank\" class=\"color-blue\">12红+3蓝</a></td>");
                sb.Append("<td><a href=\"contrast.aspx?Ind=h2l&n=s\" target=\"_blank\" class=\"color-blue\">9红+2蓝</a></td>");
                sb.Append("</tr>");
                int n_num = 1;
               
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    sb.Append("<tr>");
                    sb.Append("<td>" + n_num + "</td>");
                    sb.Append("<td>" + dr[0].ToString() + "</td>");
                    sb.Append("<td><a href='Person.aspx?name=" + Server.UrlEncode(dr[1].ToString()) + "' target=\"_blank\">" + dr[1].ToString() + "</a></td>");
                    if (dr[2].ToString() == "")
                    {
                        sb.Append("<td>--</td>");
                    }
                    else
                    {
                        string nball = WinNum(dr[0].ToString(), dr[2].ToString(), "hq3d", 3);
                        sb.Append("<td>" + nball + "</td>");
                    }
                    sb.Append("<td>");
                    string hq6d="";
                    if (dr[3].ToString() != "")
                    {
                        string nball = WinNum(dr[0].ToString(), dr[3].ToString(), "hq6d", 3);
                        string num = "";
                        for (int i = 1; i < nball.Split(',').Length + 1; i++)
                        {
                            if (i % 3 == 0)
                            {
                                num += nball.Split(',')[i - 1] + "</br>";
                            }
                            else
                            {
                                num += nball.Split(',')[i - 1] + ",";
                            }
                        }

                        hq6d = num.Substring(0, num.Length - 5);
                    }
                    else
                    {
                        hq6d = "--";
                    }
                    sb.Append(hq6d);
                    sb.Append("</td>");

                    if (dr[4].ToString() == "")
                    {
                        sb.Append("<td>--</td>");
                    }
                    else
                    {
                        string nball = WinNum(dr[0].ToString(), dr[4].ToString(), "s3hq", 3);
                        sb.Append("<td>" + dr[4].ToString() + "</td>");
                    }
                    sb.Append("<td>");
                    string s6hq = "";
                    if (dr[5].ToString() != "")
                    {
                        string nball = WinNum(dr[0].ToString(), dr[5].ToString(), "s6hq", 3);
                        string num = "";
                        for (int i = 1; i < nball.Split(',').Length + 1; i++)
                        {
                            if (i % 3 == 0)
                            {
                                num += nball.Split(',')[i - 1] + "</br>";
                            }
                            else
                            {
                                num += nball.Split(',')[i - 1] + ",";
                            }
                        }
                        s6hq = num.Substring(0, num.Length - 5);
                    }
                    else
                    {
                        s6hq = "--";
                    }
                    sb.Append(s6hq);
                    sb.Append("</td>");
                    if (dr[6].ToString() == "")
                    {
                        sb.Append("<td>--</td>");
                    }
                    else
                    {
                        string nball = WinNum(dr[0].ToString(), dr[6].ToString(), "lq1d", 3);
                        sb.Append("<td>" + nball + "</td>");
                    }
                    if (dr[7].ToString() == "")
                    {
                        sb.Append("<td>--</td>");
                    }
                    else
                    {
                        string nball = WinNum(dr[0].ToString(), dr[7].ToString(), "lq3d", 3);
                        sb.Append("<td>" + nball + "</td>");
                    }
                    if (dr[8].ToString() == "")
                    {
                        sb.Append("<td>--</td>");
                    }
                    else
                    {
                        string nball = WinNum(dr[0].ToString(), dr[8].ToString(), "s3lq", 3);
                        sb.Append("<td>" + nball + "</td>");
                    }
                    sb.Append("<td>");
                    string s6lq = "";
                    if (dr[9].ToString() != "")
                    {
                        string nball = WinNum(dr[0].ToString(), dr[9].ToString(), "s6lq", 3);
                        string num = "";
                        for (int i = 1; i < nball.Split(',').Length + 1; i++)
                        {
                            if (i % 3 == 0)
                            {
                                num += nball.Split(',')[i - 1] + "</br>";
                            }
                            else
                            {
                                num += nball.Split(',')[i - 1] + ",";
                            }
                        }
                        s6lq = num.Substring(0, num.Length - 5);
                    }
                    else
                    {
                        s6lq = "--";
                    }
                    sb.Append(s6lq);
                    sb.Append("</td>");

                    sb.Append("<td>");
                    string h3l = "";
                    if (dr[10].ToString() != "")
                    {
                        string nball = WinNum(dr[0].ToString(), dr[10].ToString(), "h3l", 3);
                        string num = "";
                        for (int i = 0; i < nball.Split(',').Length; i++)
                        {
                            if (i % 7 == 0 && i > 0)
                            {
                                num += nball.Split(',')[i] + "</br>";
                            }
                            else
                            {
                                num += nball.Split(',')[i] + ",";
                            }
                        }
                        h3l = num.Substring(0, num.Length - 1);
                    }
                    else
                    {
                        h3l= "--";
                    }
                    sb.Append(h3l);
                    sb.Append("</td>");

                    sb.Append("<td>");
                    string h2l = "";
                    if (dr[11].ToString() != "")
                    {
                        string nball = WinNum(dr[0].ToString(), dr[11].ToString(), "h2l", 3);
                        string num = "";
                        for (int i = 0; i < nball.Split(',').Length; i++)
                        {
                            if (i % 5 == 0 && i > 0)
                            {
                                num += nball.Split(',')[i] + "</br>";
                            }
                            else
                            {
                                num += nball.Split(',')[i] + ",";
                            }
                        }
                        h2l = num.Substring(0, num.Length - 1);
                    }
                    else
                    {
                        h2l= "--";
                    }
                    sb.Append(h2l);
                    sb.Append("</td>");
                    sb.Append("</tr>");
                    n_num++;
                }
                sb.Append("<tr height=\"30px\" class=\"back-color color-blue\">");
                sb.Append("<td>序号</td>");
                sb.Append("<td>期号</td>");
                sb.Append("<td>会员</td>");
                sb.Append("<td><a href=\"contrast.aspx?Ind=hq3d&n=s\" target=\"_blank\" class=\"color-blue\">红球3胆</a></td>");
                sb.Append("<td><a href=\"contrast.aspx?Ind=hq6d&n=s\" target=\"_blank\" class=\"color-blue\">红球6胆</a></td>");
                sb.Append("<td><a href=\"contrast.aspx?Ind=s3hq&n=s\" target=\"_blank\" class=\"color-blue\">杀3红球</a></td>");
                sb.Append("<td><a href=\"contrast.aspx?Ind=s6hq&n=s\" target=\"_blank\" class=\"color-blue\">杀6红球</a></td>");
                sb.Append("<td><a href=\"contrast.aspx?Ind=lq1d&n=s\" target=\"_blank\" class=\"color-blue\">篮球1胆</a></td>");
                sb.Append("<td><a href=\"contrast.aspx?Ind=lq3d&n=s\" target=\"_blank\" class=\"color-blue\">蓝球3胆</a></td>");
                sb.Append("<td><a href=\"contrast.aspx?Ind=s3lq&n=s\" target=\"_blank\" class=\"color-blue\">杀3蓝球</a></td>");
                sb.Append("<td><a href=\"contrast.aspx?Ind=s6lq&n=s\" target=\"_blank\" class=\"color-blue\">杀6蓝球</a></td>");
                sb.Append("<td><a href=\"contrast.aspx?Ind=h3l&n=s\" target=\"_blank\" class=\"color-blue\">12红+3蓝</a></td>");
                sb.Append("<td><a href=\"contrast.aspx?Ind=h2l&n=s\" target=\"_blank\" class=\"color-blue\">9红+2蓝</a></td>");
                sb.Append("</tr>");
                sb.Append("</table>");
            }
            if (lottN == "d")
            {
                if (IsNumeric(issue))
                {
                    ds = get_c.GetBankTransferD("C_issue=" + "'" + issue + "'");
                }
                else
                {
                    ds = get_c.GetBankTransferD("C_name=" + "'" + name + "'");
                }
                sb.Append("<table class=\"ssq-expert-charts\">");
                sb.Append("<tr height=\"30px\" class=\"back-color color-blue\">");
                 sb.Append("<td>序号</td>");
                 sb.Append("<td>期号</td>");
                 sb.Append("<td>会员</td>");
                 sb.Append("<td><a href=\"contrast.aspx?Ind=dd&n=d\" target=\"_blank\" class=\"color-blue\">独胆</a></td>");
                 sb.Append("<td><a href=\"contrast.aspx?Ind=sd&n=d\" target=\"_blank\" class=\"color-blue\">双胆</a></td>");
                 sb.Append("<td><a href=\"contrast.aspx?Ind=zx1z&n=d\" target=\"_blank\" class=\"color-blue\">组选一注</a></td>");
                 sb.Append("<td><a href=\"contrast.aspx?Ind=s1m&n=d\" target=\"_blank\" class=\"color-blue\">杀一码</a></td>");
                 sb.Append("<td><a href=\"contrast.aspx?Ind=s2m&n=d\" target=\"_blank\" class=\"color-blue\">杀二码</a></td>");
                 sb.Append("<td><a href=\"contrast.aspx?Ind=dk&n=d\" target=\"_blank\" class=\"color-blue\">独跨</a></td>");
                 sb.Append("<td><a href=\"contrast.aspx?Ind=dh&n=d\" target=\"_blank\" class=\"color-blue\">独合</a></td>");
                 sb.Append("<td><a href=\"contrast.aspx?Ind=s1h&n=d\" target=\"_blank\" class=\"color-blue\">杀1合</a></td>");
                 sb.Append("<td><a href=\"contrast.aspx?Ind=5dw&n=d\" target=\"_blank\" class=\"color-blue\">5*5*5定位</a></td>");
                 sb.Append("<td><a href=\"contrast.aspx?Ind=3dw&n=d\" target=\"_blank\" class=\"color-blue\">3*3*3定位</a></td>");
                 sb.Append("<td><a href=\"contrast.aspx?Ind=zx&n=d\" target=\"_blank\" class=\"color-blue\">直选1注</a></td>");
                 sb.Append("<td><a href=\"contrast.aspx?Ind=m&n=d\" target=\"_blank\" class=\"color-blue\">5码</a></td>");
                 sb.Append("</tr>");
                 int n_num = 1;
                 foreach (DataRow dr in ds.Tables[0].Rows)
                 {
                     sb.Append("<tr>");
                     sb.Append("<td>"+ n_num +"</td>");
                     sb.Append("<td>"+ dr[0].ToString() +"</td>");
                     sb.Append("<td><a href='Person.aspx?name=" + Server.UrlEncode(dr[1].ToString()) + "' target=\"_blank\">" + dr[1].ToString() + "</a></td>");
                     if (dr[2].ToString() == "")
                     {
                         sb.Append("<td>--</td>");
                     }
                     else
                     {
                         string nball = WinNum(dr[0].ToString(), dr[2].ToString(), "dd", 1);
                         sb.Append("<td>" + nball + "</td>");
                     }
                     if (dr[3].ToString() == "")
                     {
                         sb.Append("<td>--</td>");
                     }
                     else
                     {
                         string nball = WinNum(dr[0].ToString(), dr[3].ToString(), "sd", 1);
                         sb.Append("<td>" + nball + "</td>");
                     }
                     if (dr[4].ToString() == "")
                     {
                         sb.Append("<td>--</td>");
                     }
                     else
                     {
                         string nball = WinNum(dr[0].ToString(), dr[4].ToString(), "zx1z", 1);
                         sb.Append("<td>" + nball.Replace(",", "") + "</td>");
                     }
                     if (dr[5].ToString() == "")
                     {
                         sb.Append("<td>--</td>");
                     }
                     else
                     {
                         string nball = WinNum(dr[0].ToString(), dr[5].ToString(), "s1m", 1);
                         sb.Append("<td>" + nball + "</td>");
                     }
                     if (dr[6].ToString() == "")
                     {
                         sb.Append("<td>--</td>");
                     }
                     else
                     {
                         string nball = WinNum(dr[0].ToString(), dr[6].ToString(), "s2m", 1);
                         sb.Append("<td>" + nball + "</td>");
                     }
                     if (dr[7].ToString() == "")
                     {
                         sb.Append("<td>--</td>");
                     }
                     else
                     {
                         string nball = WinNum(dr[0].ToString(), dr[7].ToString(), "dk", 1);
                         sb.Append("<td>" + nball + "</td>");
                     }
                     if (dr[8].ToString() == "")
                     {
                         sb.Append("<td>--</td>");
                     }
                     else
                     {
                         string nball = WinNum(dr[0].ToString(), dr[8].ToString(), "dh", 1);
                         sb.Append("<td>" + nball + "</td>");
                     }
                     if (dr[9].ToString() == "")
                     {
                         sb.Append("<td>--</td>");
                     }
                     else
                     {
                         string nball = WinNum(dr[0].ToString(), dr[9].ToString(), "s1h", 1);
                         sb.Append("<td>" + nball + "</td>");
                     }
                     if (dr[10].ToString() == "")
                     {
                         sb.Append("<td>--</td>");
                     }
                     else
                     {
                         string nball = WinNum(dr[0].ToString(), dr[10].ToString(), "5dw", 1);
                         sb.Append("<td>" + nball.Replace(",", "/") + "</td>");
                     }
                     if (dr[11].ToString() == "")
                     {
                         sb.Append("<td>--</td>");
                     }
                     else
                     {
                         string nball = WinNum(dr[0].ToString(), dr[11].ToString(), "3dw", 1);
                         sb.Append("<td>" + nball.Replace(",", "/") + "</td>");
                     }
                     if (dr[12].ToString() == "")
                     {
                         sb.Append("<td>--</td>");
                     }
                     else
                     {
                         string nball = WinNum(dr[0].ToString(), dr[12].ToString(), "zx", 1);
                         sb.Append("<td>" + nball.Replace(",", "") + "</td>");
                     }
                     if (dr[13].ToString() == "")
                     {
                         sb.Append("<td>--</td>");
                     }
                     else
                     {
                         string nball = WinNum(dr[0].ToString(), dr[13].ToString(), "m", 1);
                         sb.Append("<td>" + nball + "</td>");
                     }
                     sb.Append("</tr>");
                     n_num++;
                 }
                 sb.Append("<tr height=\"30px\" class=\"back-color color-blue\">");
                 sb.Append("<td>序号</td>");
                 sb.Append("<td>期号</td>");
                 sb.Append("<td>会员</td>");
                 sb.Append("<td><a href=\"contrast.aspx?Ind=dd&n=d\" target=\"_blank\" class=\"color-blue\">独胆</a></td>");
                 sb.Append("<td><a href=\"contrast.aspx?Ind=sd&n=d\" target=\"_blank\" class=\"color-blue\">双胆</a></td>");
                 sb.Append("<td><a href=\"contrast.aspx?Ind=zx1z&n=d\" target=\"_blank\" class=\"color-blue\">组选一注</a></td>");
                 sb.Append("<td><a href=\"contrast.aspx?Ind=s1m&n=d\" target=\"_blank\" class=\"color-blue\">杀一码</a></td>");
                 sb.Append("<td><a href=\"contrast.aspx?Ind=s2m&n=d\" target=\"_blank\" class=\"color-blue\">杀二码</a></td>");
                 sb.Append("<td><a href=\"contrast.aspx?Ind=dk&n=d\" target=\"_blank\" class=\"color-blue\">独跨</a></td>");
                 sb.Append("<td><a href=\"contrast.aspx?Ind=dh&n=d\" target=\"_blank\" class=\"color-blue\">独合</a></td>");
                 sb.Append("<td><a href=\"contrast.aspx?Ind=s1h&n=d\" target=\"_blank\" class=\"color-blue\">杀1合</a></td>");
                 sb.Append("<td><a href=\"contrast.aspx?Ind=5dw&n=d\" target=\"_blank\" class=\"color-blue\">5*5*5定位</a></td>");
                 sb.Append("<td><a href=\"contrast.aspx?Ind=3dw&n=d\" target=\"_blank\" class=\"color-blue\">3*3*3定位</a></td>");
                 sb.Append("<td><a href=\"contrast.aspx?Ind=zx&n=d\" target=\"_blank\" class=\"color-blue\">直选1注</a></td>");
                 sb.Append("<td><a href=\"contrast.aspx?Ind=m&n=d\" target=\"_blank\" class=\"color-blue\">5码</a></td>");
                 sb.Append("</tr>");
                 sb.Append("</table>");
            }
            if (lottN == "p")
            {
                if (IsNumeric(issue))
                {
                    ds = get_c.GetBankTransferP("C_issue=" + "'" + issue + "'");
                }
                else
                {
                    ds = get_c.GetBankTransferP("C_name=" + "'" + name + "'");
                }
                sb.Append("<table class=\"ssq-expert-charts\">");
                sb.Append("<tr height=\"30px\" class=\"back-color color-blue\">");
                sb.Append("<td>序号</td>");
                sb.Append("<td>期号</td>");
                sb.Append("<td>会员</td>");
                sb.Append("<td><a href=\"contrast.aspx?Ind=dd&n=d\" target=\"_blank\" class=\"color-blue\">独胆</a></td>");
                sb.Append("<td><a href=\"contrast.aspx?Ind=sd&n=d\" target=\"_blank\" class=\"color-blue\">双胆</a></td>");
                sb.Append("<td><a href=\"contrast.aspx?Ind=zx1z&n=d\" target=\"_blank\" class=\"color-blue\">组选一注</a></td>");
                sb.Append("<td><a href=\"contrast.aspx?Ind=s1m&n=d\" target=\"_blank\" class=\"color-blue\">杀一码</a></td>");
                sb.Append("<td><a href=\"contrast.aspx?Ind=s2m&n=d\" target=\"_blank\" class=\"color-blue\">杀二码</a></td>");
                sb.Append("<td><a href=\"contrast.aspx?Ind=dk&n=d\" target=\"_blank\" class=\"color-blue\">独跨</a></td>");
                sb.Append("<td><a href=\"contrast.aspx?Ind=dh&n=d\" target=\"_blank\" class=\"color-blue\">独合</a></td>");
                sb.Append("<td><a href=\"contrast.aspx?Ind=s1h&n=d\" target=\"_blank\" class=\"color-blue\">杀1合</a></td>");
                sb.Append("<td><a href=\"contrast.aspx?Ind=5dw&n=d\" target=\"_blank\" class=\"color-blue\">5*5*5定位</a></td>");
                sb.Append("<td><a href=\"contrast.aspx?Ind=3dw&n=d\" target=\"_blank\" class=\"color-blue\">3*3*3定位</a></td>");
                sb.Append("<td><a href=\"contrast.aspx?Ind=zx&n=d\" target=\"_blank\" class=\"color-blue\">直选1注</a></td>");
                sb.Append("<td><a href=\"contrast.aspx?Ind=m&n=d\" target=\"_blank\" class=\"color-blue\">5码</a></td>");
                sb.Append("</tr>");
                int n_num = 1;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    sb.Append("<tr>");
                    sb.Append("<td>" + n_num + "</td>");
                    sb.Append("<td>" + dr[0].ToString() + "</td>");
                    sb.Append("<td><a href='Person.aspx?name=" + Server.UrlEncode(dr[1].ToString()) + "' target=\"_blank\">" + dr[1].ToString() + "</a></td>");
                    if (dr[2].ToString() == "")
                    {
                        sb.Append("<td>--</td>");
                    }
                    else
                    {
                        string nball = WinNum(dr[0].ToString(), dr[2].ToString(), "pdd", 4);
                        sb.Append("<td>" + nball + "</td>");
                    }

                    if (dr[3].ToString() == "")
                    {
                        sb.Append("<td>--</td>");
                    }
                    else
                    {
                        string nball = WinNum(dr[0].ToString(), dr[3].ToString(), "psd", 4);
                        sb.Append("<td>" + nball + "</td>");
                    }

                    if (dr[4].ToString() == "")
                    {
                        sb.Append("<td>--</td>");
                    }
                    else
                    {
                        string nball = WinNum(dr[0].ToString(), dr[4].ToString(), "pzx1z", 4);
                        sb.Append("<td>" + nball.Replace(",", "") + "</td>");
                    }

                    if (dr[5].ToString() == "")
                    {
                        sb.Append("<td>--</td>");
                    }
                    else
                    {
                        string nball = WinNum(dr[0].ToString(), dr[5].ToString(), "ps1m", 4);
                        sb.Append("<td>" + nball + "</td>");
                    }

                    if (dr[6].ToString() == "")
                    {
                        sb.Append("<td>--</td>");
                    }
                    else
                    {
                        string nball = WinNum(dr[0].ToString(), dr[6].ToString(), "ps2m", 4);
                        sb.Append("<td>" + nball + "</td>");
                    }

                    if (dr[7].ToString() == "")
                    {
                        sb.Append("<td>--</td>");
                    }
                    else
                    {
                        string nball = WinNum(dr[0].ToString(), dr[7].ToString(), "pdk", 4);
                        sb.Append("<td>" + nball + "</td>");

                    }

                    if (dr[8].ToString() == "")
                    {
                        sb.Append("<td>--</td>");
                    }
                    else
                    {
                        string nball = WinNum(dr[0].ToString(), dr[8].ToString(), "pdh", 4);
                        sb.Append("<td>" + nball + "</td>");
                    }

                    if (dr[9].ToString() == "")
                    {
                        sb.Append("<td>--</td>");
                    }
                    else
                    {
                        string nball = WinNum(dr[0].ToString(), dr[9].ToString(), "ps1h", 4);
                        sb.Append("<td>" + nball + "</td>");
                    }

                    if (dr[10].ToString() == "")
                    {
                        sb.Append("<td>--</td>");
                    }
                    else
                    {
                        string nball = WinNum(dr[0].ToString(), dr[10].ToString(), "p5dw", 4);
                        sb.Append("<td>" + nball.Replace(",", "/") + "</td>");
                    }

                    if (dr[11].ToString() == "")
                    {
                        sb.Append("<td>--</td>");
                    }
                    else
                    {
                        string nball = WinNum(dr[0].ToString(), dr[11].ToString(), "p3dw", 4);
                        sb.Append("<td>" + nball.Replace(",", "/") + "</td>");
                    }

                    if (dr[12].ToString() == "")
                    {
                        sb.Append("<td>--</td>");
                    }
                    else
                    {
                        string nball = WinNum(dr[0].ToString(), dr[12].ToString(), "pzx", 4);
                        sb.Append("<td>" + nball.Replace(",", "") + "</td>");
                    }

                    if (dr[13].ToString() == "")
                    {
                        sb.Append("<td>--</td>");
                    }
                    else
                    {
                        string nball = WinNum(dr[0].ToString(), dr[13].ToString(), "p5m", 4);
                        sb.Append("<td>" + nball + "</td>");
                    }
                    sb.Append("</tr>");
                    n_num++;
                }
                sb.Append("<tr height=\"30px\" class=\"back-color color-blue\">");
                sb.Append("<td>序号</td>");
                sb.Append("<td>期号</td>");
                sb.Append("<td>会员</td>");
                sb.Append("<td><a href=\"contrast.aspx?Ind=dd&n=d\" target=\"_blank\" class=\"color-blue\">独胆</a></td>");
                sb.Append("<td><a href=\"contrast.aspx?Ind=sd&n=d\" target=\"_blank\" class=\"color-blue\">双胆</a></td>");
                sb.Append("<td><a href=\"contrast.aspx?Ind=zx1z&n=d\" target=\"_blank\" class=\"color-blue\">组选一注</a></td>");
                sb.Append("<td><a href=\"contrast.aspx?Ind=s1m&n=d\" target=\"_blank\" class=\"color-blue\">杀一码</a></td>");
                sb.Append("<td><a href=\"contrast.aspx?Ind=s2m&n=d\" target=\"_blank\" class=\"color-blue\">杀二码</a></td>");
                sb.Append("<td><a href=\"contrast.aspx?Ind=dk&n=d\" target=\"_blank\" class=\"color-blue\">独跨</a></td>");
                sb.Append("<td><a href=\"contrast.aspx?Ind=dh&n=d\" target=\"_blank\" class=\"color-blue\">独合</a></td>");
                sb.Append("<td><a href=\"contrast.aspx?Ind=s1h&n=d\" target=\"_blank\" class=\"color-blue\">杀1合</a></td>");
                sb.Append("<td><a href=\"contrast.aspx?Ind=5dw&n=d\" target=\"_blank\" class=\"color-blue\">5*5*5定位</a></td>");
                sb.Append("<td><a href=\"contrast.aspx?Ind=3dw&n=d\" target=\"_blank\" class=\"color-blue\">3*3*3定位</a></td>");
                sb.Append("<td><a href=\"contrast.aspx?Ind=zx&n=d\" target=\"_blank\" class=\"color-blue\">直选1注</a></td>");
                sb.Append("<td><a href=\"contrast.aspx?Ind=m&n=d\" target=\"_blank\" class=\"color-blue\">5码</a></td>");
                sb.Append("</tr>");
                sb.Append("</table>");
            }
            
            return HttpContext.Current.Server.HtmlEncode(sb.ToString());
        }
        #region  主页开奖后数字标红
        /// <summary>
        /// 上一期的中奖号码显示红色
        /// </summary>
        /// <param name="oNum">开奖号码</param>
        /// <param name="zNum">自选号码</param>
        /// <param name="lottCond">彩种条件</param>
        /// <param name="lotID">彩种编号</param>
        /// <returns></returns>
        public string WinNum(string issue, string xNum, string lottCond, int lotID)
        {
            string oNum = Pbzx.Common.Method.RlotteryNum(lotID, Convert.ToInt32(issue));
            string Num = "";
           
            if (oNum != "" && xNum != "")
            {
                if (lottCond == "h3l" || lottCond == "h2l")
                {
                    //红球
                    string redBall = "";
                    //蓝球
                    string buleBall = "";

                    for (int j = 0; j < xNum.Split('+')[0].Split(',').Length; j++)
                    {
                        int flg = 0;
                        for (int i = 0; i < oNum.Split('+')[0].Split(',').Length; i++)
                        {
                            if (Convert.ToInt32(xNum.Split('+')[0].Split(',')[j]) == Convert.ToInt32(oNum.Split('+')[0].Split(',')[i]))
                            {
                                redBall += "<font color=\"red\">" + xNum.Split('+')[0].Split(',')[j] + "</font>,";
                                flg = 1;
                                break;
                            }
                        }
                        if (flg == 1)
                        {
                            continue;
                        }
                        else
                        {
                            redBall += xNum.Split('+')[0].Split(',')[j] + ",";
                        }

                    }

                    for (int j = 0; j < xNum.Split('+')[1].Split(',').Length; j++)
                    {
                        int flg = 0;
                        for (int i = 0; i < oNum.Split('+')[1].Split(',').Length; i++)
                        {
                            if (Convert.ToInt32(xNum.Split('+')[1].Split(',')[j]) == Convert.ToInt32(oNum.Split('+')[1].Split(',')[i]))
                            {
                                buleBall += "<font color=\"red\">" + xNum.Split('+')[1].Split(',')[j] + "</font>,";
                                flg = 1;
                                break;
                            }
                        }
                        if (flg == 1)
                        {
                            continue;
                        }
                        else
                        {
                            buleBall += xNum.Split('+')[1].Split(',')[j] + ",";
                        }
                    }


                    if (buleBall == "")
                    {
                        Num = redBall.Substring(0, redBall.Length - 1);
                    }
                    else
                    {
                        Num = redBall.Substring(0, redBall.Length - 1) + "+" + buleBall.Substring(0, buleBall.Length - 1);
                    }
                }
                if (lottCond == "3dw" || lottCond == "5dw" || lottCond == "p5dw" || lottCond == "p3dw")
                {
                    //重新获取开奖号码
                    string numD = ResNum_d(oNum);
                    string C_num = "";
                    for (int i = 0; i < 3; i++)
                    {
                       
                        for (int j = 0; j < xNum.Split(',')[i].Length; j++)
                        {
                            if (Convert.ToInt32(xNum.Split(',')[i].ToString().Substring(j, 1)) == Convert.ToInt32(numD.Split(',')[i]))
                            {
                                C_num += "<font color=\"red\">" + xNum.Split(',')[i].ToString().Substring(j, 1).ToString() + "</font>";
 
                            }
                            else
                            {
                                C_num += xNum.Split(',')[i].ToString().Substring(j, 1).ToString();
                            }
                        }
                        C_num = C_num + "/";
                        
                    }
                    Num = C_num.Substring(0, C_num.Length - 1);
                }
                if (lottCond == "hq3d" || lottCond == "hq6d")
                {
                    
                    string wball = "";

                    for (int j = 0; j < xNum.Split(',').Length; j++)
                    {
                        int flg = 0;
                        for (int i = 0; i < oNum.Split('+')[0].Split(',').Length; i++)
                        {
                            if (Convert.ToInt32(xNum.Split(',')[j]) == Convert.ToInt32(oNum.Split('+')[0].Split(',')[i]))
                            {
                                wball += "<font color=\"red\">" + xNum.Split(',')[j] + "</font>,";
                                flg = 1;
                                break;
                            }
                        }
                        if (flg == 1)
                        {
                            continue;
                        }
                        else
                        {
                            wball += xNum.Split(',')[j] + ",";
                        }
                       
                    }

                    Num = wball.Substring(0, wball.Length - 1);
                }
                if (lottCond == "s3hq" || lottCond == "s6hq")
                {

                    string wball = "";

                    for (int j = 0; j < xNum.Split(',').Length; j++)
                    {
                        int flg = 0;
                        for (int i = 0; i < oNum.Split('+')[0].Split(',').Length; i++)
                        {
                            if (Convert.ToInt32(xNum.Split(',')[j]) == Convert.ToInt32(oNum.Split('+')[0].Split(',')[i]))
                            {
                                wball += xNum.Split(',')[j] + ",";
                                flg = 1;
                                break;
                            }
                        }
                        if (flg == 1)
                        {
                            continue;
                        }
                        else
                        {
                            wball += "<font color=\"red\">" + xNum.Split(',')[j].ToString() + "</font>,";
                        }
                    }

                    Num = wball.Substring(0, wball.Length - 1);
                }

                if (lottCond == "lq1d" || lottCond == "lq3d")
                {
                    string wball = "";

                    for (int j = 0; j < xNum.Split(',').Length; j++)
                    {
                        int flg = 0;
                        for (int i = 0; i < oNum.Split('+')[1].Split(',').Length; i++)
                        {
                            if (Convert.ToInt32(xNum.Split(',')[j]) == Convert.ToInt32(oNum.Split('+')[1].Split(',')[i]))
                            {
                                wball += "<font color=\"red\">" + xNum.Split(',')[j].ToString() + "</font>,";
                                flg = 1;
                                break;
                            }
                        }
                        if (flg == 1)
                        {
                            continue;
                        }
                        else
                        {
                            wball += xNum.Split(',')[j].ToString() + ",";
                        }
                    }

                    Num = wball.Substring(0, wball.Length - 1);
                }
                if (lottCond == "s3lq" || lottCond == "s6lq")
                {

                    string wball = "";

                    for (int j = 0; j < xNum.Split(',').Length; j++)
                    {
                        int flg = 0;
                        for (int i = 0; i < oNum.Split('+')[1].Split(',').Length; i++)
                        {
                            if (Convert.ToInt32(xNum.Split(',')[j]) == Convert.ToInt32(oNum.Split('+')[1].Split(',')[i]))
                            {
                                wball += xNum.Split(',')[j].ToString() + ",";
                                flg = 1;
                                break;
                            }
                        }
                        if (flg == 1)
                        {
                            continue;
                        }
                        else
                        {
                            wball += "<font color=\"red\">" + xNum.Split(',')[j].ToString() + "</font>,";
                        }
                    }

                    Num = wball.Substring(0, wball.Length - 1);
                }
                if (lottCond == "dd" || lottCond == "pdd")
                {
                    string wball = "";
                    //重新获取开奖号码
                    string numD = ResNum_d(oNum);
                    for (int i = 0; i < numD.Split(',').Length; i++)
                    {
                        if (Convert.ToInt32(xNum) == Convert.ToInt32(numD.Split(',')[i]))
                        {
                            wball = "<font color=\"red\">" + xNum + "</font>";
                            break;
                        }
                        else
                        {
                            wball = xNum;
                        }
                    }
                    Num = wball;
                }
                if (lottCond == "sd" || lottCond == "psd")
                {
                    string wball = "";
                    string numD = ResNum_d(oNum);

                    for (int j = 0; j < xNum.Split(',').Length; j++)
                    {
                        int flg = 0;
                        for (int i = 0; i < numD.Split(',').Length; i++)
                        {
                            if (Convert.ToInt32(xNum.Split(',')[j]) == Convert.ToInt32(numD.Split(',')[i]))
                            {
                                wball += "<font color=\"red\">" + xNum.Split(',')[j] + "</font>,";
                                flg = 1;
                                break;
                            }
                        }
                        if (flg == 1)
                        {
                            continue;
                        }
                        else
                        {
                            wball += xNum.Split(',')[j] + ",";
                        }
                    }

                    Num = wball.Substring(0, wball.Length - 1);
                }
                if (lottCond == "s1m" || lottCond == "ps1m" || lottCond == "s2m" || lottCond == "ps2m")
                {

                    string wball = "";
                    string numD = ResNum_d(oNum);

                    for (int j = 0; j < xNum.Split(',').Length; j++)
                    {
                        int flg = 0;
                        for (int i = 0; i < numD.Split(',').Length; i++)
                        {
                            if (Convert.ToInt32(xNum.Split(',')[j]) == Convert.ToInt32(numD.Split(',')[i]))
                            {
                                wball += xNum.Split(',')[j] + ",";
                                flg = 1;
                                break;
                            }
                        }
                        if (flg == 1)
                        {
                            continue;
                        }
                        else
                        {
                            wball += "<font color=\"red\">" + xNum.Split(',')[j] + "</font>,";
                        }
                    }
                    
                    Num = wball.Substring(0, wball.Length - 1);
                }
                if (lottCond == "zx1z" || lottCond == "pzx1z")
                {
                    string wball = "";
                    string numD = ResNum_d(oNum);
                    for (int i = 0; i < xNum.Split(',').Length; i++)
                    {
                        if (numD.Contains(xNum.Split(',')[i]))
                        {
                            wball += "<font color=\"red\">" + xNum.Split(',')[i].ToString() + "</font>,";
                            int v = numD.IndexOf(xNum.Split(',')[i]);
                            if (v >= 0)
                            {
                                numD = numD.Remove(v, xNum.Split(',')[i].Length); // 结果在返回值中

                            }
                        }
                        else
                        {
                            wball += xNum.Split(',')[i].ToString() + ",";
                            int v = numD.IndexOf(xNum.Split(',')[i]);
                            if (v >= 0)
                            {
                                numD = numD.Remove(v, xNum.Split(',')[i].Length); // 结果在返回值中
                               
                            }
                        }
                    }
                  
                    Num = wball.Substring(0, wball.Length - 1);

                }
                if (lottCond == "zx" || lottCond == "pzx")
                {
                    string wball = "";
                    string numD = ResNum_d(oNum);
                    for (int j = 0; j < 3; j++)
                    {
                        if (Convert.ToInt32(xNum.Split(',')[j]) == Convert.ToInt32(numD.Split(',')[j]))
                        {
                            wball += "<font color=\"red\">" + xNum.Split(',')[j] + "</font>,";
                        }
                        else
                        {
                            wball += xNum.Split(',')[j] + ",";
                        }
                    }
                    Num = wball.Substring(0, wball.Length - 1);
                }
                if (lottCond == "dk" || lottCond == "pdk")
                { 
                    //独跨
                    string wball = "";
                    string numD = ResNum_d(oNum);

                    ArrayList arr = new ArrayList();
                    for (int k = 0; k < numD.Split(',').Length; k++)
                    {
                        arr.Add(numD.Split(',')[k]);
                    }
                    //排序号码
                    ArrayList arrSort = Input.arrlist(arr);
                    //计算独跨
                    int span=Convert.ToInt32(arr[2])-Convert.ToInt32(arr[0]);
                    if (Convert.ToInt32(xNum) == span)
                    {
                        wball = "<font color=\"red\">" + xNum + "</font>";
                    }
                    else
                    {
                        wball = xNum;
                    }
                    Num = wball;
                }
                if (lottCond == "dh" || lottCond == "pdh")
                {
                    string wball = "";
                    //获取开奖号码
                    string numD = ResNum_d(oNum);
                    int AlloyNum = Convert.ToInt32(numD.Split(',')[0]) + Convert.ToInt32(numD.Split(',')[1]) + Convert.ToInt32(numD.Split(',')[2]);
                    int alloy = -1;
                    if (AlloyNum > 9)
                    {
                        alloy =Convert.ToInt32(AlloyNum.ToString().Substring(1, 1));
                    }
                    else
                    {
                        alloy = AlloyNum;
                    }
                    if (Convert.ToInt32(xNum) == alloy)
                    {
                        wball = "<font color=\"red\">" + xNum + "</font>";
                    }
                    else
                    {
                        wball = xNum;
                    }
                    Num = wball;
                }
                if (lottCond == "s1h" || lottCond == "ps1h")
                {
                    string wball = "";
                    //获取开奖号码
                    string numD = ResNum_d(oNum);
                    int AlloyNum = Convert.ToInt32(numD.Split(',')[0]) + Convert.ToInt32(numD.Split(',')[1]) + Convert.ToInt32(numD.Split(',')[2]);
                    int alloy = -1;
                    if (AlloyNum > 9)
                    {
                        alloy = Convert.ToInt32(AlloyNum.ToString().Substring(1, 1));
                    }
                    else
                    {
                        alloy = AlloyNum;
                    }
                    if (Convert.ToInt32(xNum) != alloy)
                    {
                        wball = "<font color=\"red\">" + xNum + "</font>";
                    }
                    else
                    {
                        wball = xNum;
                    }
                    Num = wball;
                }
                if (lottCond == "m" || lottCond == "p5m")
                {

                    string wball = "";
                    string numD = ResNum_d(oNum);
                    for (int i = 0; i < xNum.Split(',').Length; i++)
                    {
                        int flg = 0;
                        for (int j = 0; j < 3; j++)
                        {
                            if (Convert.ToInt32(xNum.Split(',')[i]) == Convert.ToInt32(numD.Split(',')[j]))
                            {
                                wball += "<font color=\"red\">" + xNum.Split(',')[i].ToString() + "</font>,";
                                flg = 1;
                                break;
                            }
                        }
                        if (flg == 1)
                        {
                            continue;
                        }
                        else
                        {
                            wball += xNum.Split(',')[i].ToString() + ",";
                        }
                    }
                    Num = wball.Substring(0, wball.Length - 1);
                }
            }
            return Num;
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

        #endregion

        private static bool IsNumeric(string str)
        {
            System.Text.RegularExpressions.Regex reg1 = new System.Text.RegularExpressions.Regex(@"^[-]?\d+[.]?\d*$");
            return reg1.IsMatch(str.Trim());
        } 


        /// <summary>
        /// URL地址解码
        /// </summary>
        /// <param name="URLEncode">编码字符串</param>
        /// <returns></returns>
        [WebMethod]
        public string URLDecode(string URLEncode)
        {
            return Pbzx.Common.Input.URLDecode(URLEncode);
        }


        #region   计算中号码出现次数

        /// <summary>
        /// 双色球红球
        /// </summary>
        /// <param name="playName">彩种编号</param>
        /// <param name="top">查询数据条数 * 全部  </param> 
        /// <param name="cond">彩种的条件名称</param>
        /// <returns></returns>
        /// 
        [WebMethod]
        public string AppearNum(int playName, string top,string cond)
        {
            string issue = "";
            if (playName == 9999)
            {
                //获取当前期号
                issue = Pbzx.BLL.publicMethod.Period(4);
            }
            else
            {
                //获取当前期号
                issue = Pbzx.BLL.publicMethod.Period(playName);
            }
            //查询数据
            string n_num = "";
            int Zero = 0;
            int OneN = 0;
            int TwoN = 0;
            int ThreeN = 0;
            int FourN = 0;
            int FiveN = 0;
            int SixN = 0;
            int SevenN = 0;
            int EightN = 0;
            int NineN = 0;
            int TenN = 0;
            int ElevenN = 0;
            int TwelveN = 0;
            int ThirteenN = 0;
            int FourteenN = 0;
            int FifteenN = 0;
            int SixteenN = 0;
            int SevenTeenN = 0;
            int EightTeenN = 0;
            int NineTeenN = 0;
            int TwentyN = 0;
            int TwentyoneN = 0;
            int TwentytwoN = 0;
            int TwentythreeN = 0;
            int TwentyfourN = 0;
            int TwentyfiveN = 0;
            int TwentysixN = 0;
            int TwentysevenN = 0;
            int TwentyeightN = 0;
            int TwentynineN = 0;
            int ThirtyN = 0;
            int ThirtyoneN = 0;
            int ThirtytwoN = 0;
            int ThirtythreeN = 0;

            //蓝球
            string b_num = "";
            int b_OneN = 0;
            int b_TwoN = 0;
            int b_ThreeN = 0;
            int b_FourN = 0;
            int b_FiveN = 0;
            int b_SixN = 0;
            int b_SevenN = 0;
            int b_EightN = 0;
            int b_NineN = 0;
            int b_TenN = 0;
            int b_ElevenN = 0;
            int b_TwelveN = 0;
            int b_ThirteenN = 0;
            int b_FourteenN = 0;
            int b_FifteenN = 0;
            int b_SixteenN = 0;

            DataSet ds = new DataSet();
            ds = DbHelperSQL.Query("select "+ top +" from v_ReCon where C_lottID=" + playName + " and C_issue=" + "'" + issue + "'"+" and T_cond="+"'"+ cond +"'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (playName == 3)
                    {
                        if (ds.Tables[0].Rows[i]["T_state"].ToString() == "h3l" || ds.Tables[0].Rows[i]["T_state"].ToString() == "h2l")
                        {
                            //获取红球
                            string redBall = ds.Tables[0].Rows[i]["C_num"].ToString().Split('+')[0].ToString();
                            for (int j = 0; j < redBall.Split(',').Length; j++)
                            {
                                #region  判断出现次数
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 1)
                                {
                                    OneN = OneN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 2)
                                {
                                    TwoN = TwoN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 3)
                                {
                                    ThreeN = ThreeN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 4)
                                {
                                    FourN = FourN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 5)
                                {
                                    FiveN = FiveN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 6)
                                {
                                    SixN = SixN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 7)
                                {
                                    SevenN = SevenN + 1;

                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 8)
                                {
                                    EightN = EightN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 9)
                                {
                                    NineN = NineN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 10)
                                {
                                    TenN = TenN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 11)
                                {
                                    ElevenN = ElevenN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 12)
                                {
                                    TwelveN = TwelveN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 13)
                                {
                                    ThirtyN = ThirtyN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 14)
                                {
                                    FourteenN = FourteenN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 15)
                                {
                                    FifteenN = FifteenN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 16)
                                {
                                    SixteenN = SixteenN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 17)
                                {
                                    SevenTeenN = SevenTeenN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 18)
                                {
                                    EightTeenN = EightTeenN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 19)
                                {
                                    NineTeenN = NineTeenN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 20)
                                {
                                    TwentyN = TwentyN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 21)
                                {
                                    TwentyoneN = TwentyoneN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 22)
                                {
                                    TwentytwoN = TwentytwoN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 23)
                                {
                                    TwentythreeN = TwentythreeN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 24)
                                {
                                    TwentyfourN = TwentyfourN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 25)
                                {
                                    TwentyfiveN = TwentyfiveN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 26)
                                {
                                    TwentysixN = TwentysixN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 27)
                                {
                                    TwentysevenN = TwentysevenN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 28)
                                {
                                    TwentyeightN = TwentyeightN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 29)
                                {
                                    TwentynineN = TwentynineN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 30)
                                {
                                    ThirtyN = ThirtyN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 31)
                                {
                                    ThirtyoneN = ThirtyoneN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 32)
                                {
                                    ThirtytwoN = ThirtytwoN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 33)
                                {
                                    ThirtythreeN = ThirtythreeN + 1;
                                }
                                #endregion
                            }
                            //蓝球出现次数
                            string BlueBall = ds.Tables[0].Rows[i]["C_num"].ToString().Split('+')[1].ToString();
                            for (int j = 0; j < BlueBall.Split(',').Length; j++)
                            {
                                #region  判断出现次数
                                if (Convert.ToInt32(BlueBall.Split(',')[j]) == 1)
                                {
                                    b_OneN = b_OneN + 1;
                                }
                                if (Convert.ToInt32(BlueBall.Split(',')[j]) == 2)
                                {
                                    b_TwoN = b_TwoN + 1;
                                }
                                if (Convert.ToInt32(BlueBall.Split(',')[j]) == 3)
                                {
                                    b_ThreeN = b_ThreeN + 1;
                                }
                                if (Convert.ToInt32(BlueBall.Split(',')[j]) == 4)
                                {
                                    b_FourN = b_FourN + 1;
                                }
                                if (Convert.ToInt32(BlueBall.Split(',')[j]) == 5)
                                {
                                    b_FiveN = b_FiveN + 1;
                                }
                                if (Convert.ToInt32(BlueBall.Split(',')[j]) == 6)
                                {
                                    b_SixN = b_SixN + 1;
                                }
                                if (Convert.ToInt32(BlueBall.Split(',')[j]) == 7)
                                {
                                    b_SevenN = b_SevenN + 1;

                                }
                                if (Convert.ToInt32(BlueBall.Split(',')[j]) == 8)
                                {
                                    b_EightN = b_EightN + 1;
                                }
                                if (Convert.ToInt32(BlueBall.Split(',')[j]) == 9)
                                {
                                    b_NineN = b_NineN + 1;
                                }
                                if (Convert.ToInt32(BlueBall.Split(',')[j]) == 10)
                                {
                                    b_TenN = b_TenN + 1;
                                }
                                if (Convert.ToInt32(BlueBall.Split(',')[j]) == 11)
                                {
                                    b_ElevenN = b_ElevenN + 1;
                                }
                                if (Convert.ToInt32(BlueBall.Split(',')[j]) == 12)
                                {
                                    b_TwelveN = b_TwelveN + 1;
                                }
                                if (Convert.ToInt32(BlueBall.Split(',')[j]) == 13)
                                {
                                    b_ThirteenN = b_ThirteenN + 1;
                                }
                                if (Convert.ToInt32(BlueBall.Split(',')[j]) == 14)
                                {
                                    b_FourteenN = b_FourteenN + 1;
                                }
                                if (Convert.ToInt32(BlueBall.Split(',')[j]) == 15)
                                {
                                    b_FifteenN = b_FifteenN + 1;
                                }
                                if (Convert.ToInt32(BlueBall.Split(',')[j]) == 16)
                                {
                                    b_SixteenN = b_SixteenN + 1;
                                }
                                
                                #endregion
                            }
                        }
                        else
                        {
                            for (int j = 0; j < ds.Tables[0].Rows[i]["C_num"].ToString().Split(',').Length; j++)
                            {
                                #region  判断出现次数
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 1)
                                {
                                    OneN = OneN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 2)
                                {
                                    TwoN = TwoN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 3)
                                {
                                    ThreeN = ThreeN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 4)
                                {
                                    FourN = FourN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 5)
                                {
                                    FiveN = FiveN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 6)
                                {
                                    SixN = SixN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 7)
                                {
                                    SevenN = SevenN + 1;

                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 8)
                                {
                                    EightN = EightN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 9)
                                {
                                    NineN = NineN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 10)
                                {
                                    TenN = TenN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 11)
                                {
                                    ElevenN = ElevenN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 12)
                                {
                                    TwelveN = TwelveN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 13)
                                {
                                    ThirteenN = ThirteenN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 14)
                                {
                                    FourteenN = FourteenN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 15)
                                {
                                    FifteenN = FifteenN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 16)
                                {
                                    SixteenN = SixteenN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 17)
                                {
                                    SevenTeenN = SevenTeenN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 18)
                                {
                                    EightTeenN = EightTeenN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 19)
                                {
                                    NineTeenN = NineTeenN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 20)
                                {
                                    TwentyN = TwentyN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 21)
                                {
                                    TwentyoneN = TwentyoneN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 22)
                                {
                                    TwentytwoN = TwentytwoN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 23)
                                {
                                    TwentythreeN = TwentythreeN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 24)
                                {
                                    TwentyfourN = TwentyfourN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 25)
                                {
                                    TwentyfiveN = TwentyfiveN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 26)
                                {
                                    TwentysixN = TwentysixN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 27)
                                {
                                    TwentysevenN = TwentysevenN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 28)
                                {
                                    TwentyeightN = TwentyeightN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 29)
                                {
                                    TwentynineN = TwentynineN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 30)
                                {
                                    ThirtyN = ThirtyN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 31)
                                {
                                    ThirtyoneN = ThirtyoneN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 32)
                                {
                                    ThirtytwoN = ThirtytwoN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 33)
                                {
                                    ThirtythreeN = ThirtythreeN + 1;
                                }
                                #endregion
                            }
                        }
                    }
                    if (playName == 1 || playName == 9999)
                    {
                        for (int j = 0; j < ds.Tables[0].Rows[i]["C_num"].ToString().Split(',').Length; j++)
                        {
                            #region  判断出现次数  
                            if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 0)
                            {
                                Zero = Zero + 1;
                            }
                            if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 1)
                            {
                                OneN = OneN + 1;
                            }
                            if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 2)
                            {
                                TwoN = TwoN + 1;
                            }
                            if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 3)
                            {
                                ThreeN = ThreeN + 1;
                            }
                            if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 4)
                            {
                                FourN = FourN + 1;
                            }
                            if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 5)
                            {
                                FiveN = FiveN + 1;
                            }
                            if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 6)
                            {
                                SixN = SixN + 1;
                            }
                            if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 7)
                            {
                                SevenN = SevenN + 1;

                            }
                            if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 8)
                            {
                                EightN = EightN + 1;
                            }
                            if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 9)
                            {
                                NineN = NineN + 1;
                            }
                            
                            #endregion
                        }
                    }

                }
            }
            n_num = OneN.ToString() + "&" + TwoN.ToString() + "&" + ThreeN.ToString() + "&" + FourN.ToString() + "&" + FiveN.ToString() + "&" + SixN.ToString() + "&" + SevenN.ToString() + "&" + EightN.ToString() + "&" + NineN.ToString() + "&" + TenN.ToString() + "&" + ElevenN.ToString() + "&" + TwelveN.ToString() + "&" + ThirteenN.ToString() + "&" + FourteenN.ToString() + "&" + FifteenN.ToString() + "&" + SixteenN.ToString() + "&" + SevenTeenN.ToString() + "&" + EightTeenN.ToString() + "&" + NineTeenN.ToString() + "&" + TwentyN.ToString() + "&" + TwentyoneN.ToString() + "&" + TwentytwoN.ToString() + "&" + TwentythreeN.ToString() + "&" + TwentyfourN.ToString() + "&" + TwentyfiveN.ToString() + "&" + TwentysixN.ToString() + "&" + TwentysevenN.ToString() + "&" + TwentyeightN.ToString() + "&" + TwentynineN.ToString() + "&" + ThirtyN.ToString() + "&" + ThirtyoneN.ToString() + "&" + ThirtytwoN.ToString() + "&" + ThirtythreeN.ToString() + "&" + Zero.ToString();
            b_num = b_OneN.ToString() + "&" + b_TwoN.ToString() + "&" + b_ThreeN.ToString() + "&" + b_FourN.ToString() + "&" + b_FiveN.ToString() + "&" + b_SixN.ToString() + "&" + b_SevenN.ToString() + "&" + b_EightN.ToString() + "&" + b_NineN.ToString() + "&" + b_TenN.ToString() + "&" + b_ElevenN.ToString() + "&" + b_TwelveN.ToString() + "&" + b_ThirteenN.ToString() + "&" + b_FourteenN.ToString() + "&" + b_FifteenN.ToString() + "&" + b_SixteenN.ToString();
            string num = n_num + "+" + b_num;
            return num;
        }

        #endregion



        #region   计算中号码出现次数

        /// <summary>
        /// 双色球红球
        /// </summary>
        /// <param name="playName">彩种编号</param>
        /// <param name="top">查询数据条数 * 全部  </param> 
        /// <param name="cond">彩种的条件名称</param>
        /// <returns></returns>
        /// 
        [WebMethod]
        public string AppearNumIssue(int playName, string top, string cond,string issue)
        {
            //string issue = "";
            //if (playName == 9999)
            //{
            //    //获取当前期号
            //    issue = Pbzx.BLL.publicMethod.Period(4);
            //}
            //else
            //{
            //    //获取当前期号
            //    issue = Pbzx.BLL.publicMethod.Period(playName);
            //}
            //查询数据
            string n_num = "";
            int Zero = 0;
            int OneN = 0;
            int TwoN = 0;
            int ThreeN = 0;
            int FourN = 0;
            int FiveN = 0;
            int SixN = 0;
            int SevenN = 0;
            int EightN = 0;
            int NineN = 0;
            int TenN = 0;
            int ElevenN = 0;
            int TwelveN = 0;
            int ThirteenN = 0;
            int FourteenN = 0;
            int FifteenN = 0;
            int SixteenN = 0;
            int SevenTeenN = 0;
            int EightTeenN = 0;
            int NineTeenN = 0;
            int TwentyN = 0;
            int TwentyoneN = 0;
            int TwentytwoN = 0;
            int TwentythreeN = 0;
            int TwentyfourN = 0;
            int TwentyfiveN = 0;
            int TwentysixN = 0;
            int TwentysevenN = 0;
            int TwentyeightN = 0;
            int TwentynineN = 0;
            int ThirtyN = 0;
            int ThirtyoneN = 0;
            int ThirtytwoN = 0;
            int ThirtythreeN = 0;

            //蓝球
            string b_num = "";
            int b_OneN = 0;
            int b_TwoN = 0;
            int b_ThreeN = 0;
            int b_FourN = 0;
            int b_FiveN = 0;
            int b_SixN = 0;
            int b_SevenN = 0;
            int b_EightN = 0;
            int b_NineN = 0;
            int b_TenN = 0;
            int b_ElevenN = 0;
            int b_TwelveN = 0;
            int b_ThirteenN = 0;
            int b_FourteenN = 0;
            int b_FifteenN = 0;
            int b_SixteenN = 0;

            DataSet ds = new DataSet();
            ds = DbHelperSQL.Query("select " + top + " from v_ReCon where C_lottID=" + playName + " and C_issue=" + "'" + issue + "'" + " and T_cond=" + "'" + cond + "'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (playName == 3)
                    {
                        if (ds.Tables[0].Rows[i]["T_state"].ToString() == "h3l" || ds.Tables[0].Rows[i]["T_state"].ToString() == "h2l")
                        {
                            //获取红球
                            string redBall = ds.Tables[0].Rows[i]["C_num"].ToString().Split('+')[0].ToString();
                            for (int j = 0; j < redBall.Split(',').Length; j++)
                            {
                                #region  判断出现次数
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 1)
                                {
                                    OneN = OneN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 2)
                                {
                                    TwoN = TwoN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 3)
                                {
                                    ThreeN = ThreeN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 4)
                                {
                                    FourN = FourN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 5)
                                {
                                    FiveN = FiveN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 6)
                                {
                                    SixN = SixN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 7)
                                {
                                    SevenN = SevenN + 1;

                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 8)
                                {
                                    EightN = EightN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 9)
                                {
                                    NineN = NineN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 10)
                                {
                                    TenN = TenN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 11)
                                {
                                    ElevenN = ElevenN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 12)
                                {
                                    TwelveN = TwelveN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 13)
                                {
                                    ThirtyN = ThirtyN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 14)
                                {
                                    FourteenN = FourteenN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 15)
                                {
                                    FifteenN = FifteenN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 16)
                                {
                                    SixteenN = SixteenN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 17)
                                {
                                    SevenTeenN = SevenTeenN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 18)
                                {
                                    EightTeenN = EightTeenN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 19)
                                {
                                    NineTeenN = NineTeenN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 20)
                                {
                                    TwentyN = TwentyN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 21)
                                {
                                    TwentyoneN = TwentyoneN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 22)
                                {
                                    TwentytwoN = TwentytwoN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 23)
                                {
                                    TwentythreeN = TwentythreeN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 24)
                                {
                                    TwentyfourN = TwentyfourN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 25)
                                {
                                    TwentyfiveN = TwentyfiveN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 26)
                                {
                                    TwentysixN = TwentysixN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 27)
                                {
                                    TwentysevenN = TwentysevenN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 28)
                                {
                                    TwentyeightN = TwentyeightN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 29)
                                {
                                    TwentynineN = TwentynineN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 30)
                                {
                                    ThirtyN = ThirtyN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 31)
                                {
                                    ThirtyoneN = ThirtyoneN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 32)
                                {
                                    ThirtytwoN = ThirtytwoN + 1;
                                }
                                if (Convert.ToInt32(redBall.Split(',')[j]) == 33)
                                {
                                    ThirtythreeN = ThirtythreeN + 1;
                                }
                                #endregion
                            }
                            //蓝球出现次数
                            string BlueBall = ds.Tables[0].Rows[i]["C_num"].ToString().Split('+')[1].ToString();
                            for (int j = 0; j < BlueBall.Split(',').Length; j++)
                            {
                                #region  判断出现次数
                                if (Convert.ToInt32(BlueBall.Split(',')[j]) == 1)
                                {
                                    b_OneN = b_OneN + 1;
                                }
                                if (Convert.ToInt32(BlueBall.Split(',')[j]) == 2)
                                {
                                    b_TwoN = b_TwoN + 1;
                                }
                                if (Convert.ToInt32(BlueBall.Split(',')[j]) == 3)
                                {
                                    b_ThreeN = b_ThreeN + 1;
                                }
                                if (Convert.ToInt32(BlueBall.Split(',')[j]) == 4)
                                {
                                    b_FourN = b_FourN + 1;
                                }
                                if (Convert.ToInt32(BlueBall.Split(',')[j]) == 5)
                                {
                                    b_FiveN = b_FiveN + 1;
                                }
                                if (Convert.ToInt32(BlueBall.Split(',')[j]) == 6)
                                {
                                    b_SixN = b_SixN + 1;
                                }
                                if (Convert.ToInt32(BlueBall.Split(',')[j]) == 7)
                                {
                                    b_SevenN = b_SevenN + 1;

                                }
                                if (Convert.ToInt32(BlueBall.Split(',')[j]) == 8)
                                {
                                    b_EightN = b_EightN + 1;
                                }
                                if (Convert.ToInt32(BlueBall.Split(',')[j]) == 9)
                                {
                                    b_NineN = b_NineN + 1;
                                }
                                if (Convert.ToInt32(BlueBall.Split(',')[j]) == 10)
                                {
                                    b_TenN = b_TenN + 1;
                                }
                                if (Convert.ToInt32(BlueBall.Split(',')[j]) == 11)
                                {
                                    b_ElevenN = b_ElevenN + 1;
                                }
                                if (Convert.ToInt32(BlueBall.Split(',')[j]) == 12)
                                {
                                    b_TwelveN = b_TwelveN + 1;
                                }
                                if (Convert.ToInt32(BlueBall.Split(',')[j]) == 13)
                                {
                                    b_ThirteenN = b_ThirteenN + 1;
                                }
                                if (Convert.ToInt32(BlueBall.Split(',')[j]) == 14)
                                {
                                    b_FourteenN = b_FourteenN + 1;
                                }
                                if (Convert.ToInt32(BlueBall.Split(',')[j]) == 15)
                                {
                                    b_FifteenN = b_FifteenN + 1;
                                }
                                if (Convert.ToInt32(BlueBall.Split(',')[j]) == 16)
                                {
                                    b_SixteenN = b_SixteenN + 1;
                                }

                                #endregion
                            }
                        }
                        else
                        {
                            for (int j = 0; j < ds.Tables[0].Rows[i]["C_num"].ToString().Split(',').Length; j++)
                            {
                                #region  判断出现次数
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 1)
                                {
                                    OneN = OneN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 2)
                                {
                                    TwoN = TwoN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 3)
                                {
                                    ThreeN = ThreeN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 4)
                                {
                                    FourN = FourN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 5)
                                {
                                    FiveN = FiveN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 6)
                                {
                                    SixN = SixN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 7)
                                {
                                    SevenN = SevenN + 1;

                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 8)
                                {
                                    EightN = EightN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 9)
                                {
                                    NineN = NineN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 10)
                                {
                                    TenN = TenN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 11)
                                {
                                    ElevenN = ElevenN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 12)
                                {
                                    TwelveN = TwelveN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 13)
                                {
                                    ThirteenN = ThirteenN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 14)
                                {
                                    FourteenN = FourteenN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 15)
                                {
                                    FifteenN = FifteenN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 16)
                                {
                                    SixteenN = SixteenN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 17)
                                {
                                    SevenTeenN = SevenTeenN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 18)
                                {
                                    EightTeenN = EightTeenN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 19)
                                {
                                    NineTeenN = NineTeenN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 20)
                                {
                                    TwentyN = TwentyN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 21)
                                {
                                    TwentyoneN = TwentyoneN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 22)
                                {
                                    TwentytwoN = TwentytwoN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 23)
                                {
                                    TwentythreeN = TwentythreeN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 24)
                                {
                                    TwentyfourN = TwentyfourN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 25)
                                {
                                    TwentyfiveN = TwentyfiveN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 26)
                                {
                                    TwentysixN = TwentysixN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 27)
                                {
                                    TwentysevenN = TwentysevenN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 28)
                                {
                                    TwentyeightN = TwentyeightN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 29)
                                {
                                    TwentynineN = TwentynineN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 30)
                                {
                                    ThirtyN = ThirtyN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 31)
                                {
                                    ThirtyoneN = ThirtyoneN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 32)
                                {
                                    ThirtytwoN = ThirtytwoN + 1;
                                }
                                if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 33)
                                {
                                    ThirtythreeN = ThirtythreeN + 1;
                                }
                                #endregion
                            }
                        }
                    }
                    if (playName == 1 || playName == 9999)
                    {
                        for (int j = 0; j < ds.Tables[0].Rows[i]["C_num"].ToString().Split(',').Length; j++)
                        {
                            #region  判断出现次数
                            if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 0)
                            {
                                Zero = Zero + 1;
                            }
                            if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 1)
                            {
                                OneN = OneN + 1;
                            }
                            if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 2)
                            {
                                TwoN = TwoN + 1;
                            }
                            if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 3)
                            {
                                ThreeN = ThreeN + 1;
                            }
                            if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 4)
                            {
                                FourN = FourN + 1;
                            }
                            if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 5)
                            {
                                FiveN = FiveN + 1;
                            }
                            if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 6)
                            {
                                SixN = SixN + 1;
                            }
                            if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 7)
                            {
                                SevenN = SevenN + 1;

                            }
                            if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 8)
                            {
                                EightN = EightN + 1;
                            }
                            if (Convert.ToInt32(ds.Tables[0].Rows[i]["C_num"].ToString().Split(',')[j]) == 9)
                            {
                                NineN = NineN + 1;
                            }

                            #endregion
                        }
                    }

                }
            }
            n_num = OneN.ToString() + "&" + TwoN.ToString() + "&" + ThreeN.ToString() + "&" + FourN.ToString() + "&" + FiveN.ToString() + "&" + SixN.ToString() + "&" + SevenN.ToString() + "&" + EightN.ToString() + "&" + NineN.ToString() + "&" + TenN.ToString() + "&" + ElevenN.ToString() + "&" + TwelveN.ToString() + "&" + ThirteenN.ToString() + "&" + FourteenN.ToString() + "&" + FifteenN.ToString() + "&" + SixteenN.ToString() + "&" + SevenTeenN.ToString() + "&" + EightTeenN.ToString() + "&" + NineTeenN.ToString() + "&" + TwentyN.ToString() + "&" + TwentyoneN.ToString() + "&" + TwentytwoN.ToString() + "&" + TwentythreeN.ToString() + "&" + TwentyfourN.ToString() + "&" + TwentyfiveN.ToString() + "&" + TwentysixN.ToString() + "&" + TwentysevenN.ToString() + "&" + TwentyeightN.ToString() + "&" + TwentynineN.ToString() + "&" + ThirtyN.ToString() + "&" + ThirtyoneN.ToString() + "&" + ThirtytwoN.ToString() + "&" + ThirtythreeN.ToString() + "&" + Zero.ToString();
            b_num = b_OneN.ToString() + "&" + b_TwoN.ToString() + "&" + b_ThreeN.ToString() + "&" + b_FourN.ToString() + "&" + b_FiveN.ToString() + "&" + b_SixN.ToString() + "&" + b_SevenN.ToString() + "&" + b_EightN.ToString() + "&" + b_NineN.ToString() + "&" + b_TenN.ToString() + "&" + b_ElevenN.ToString() + "&" + b_TwelveN.ToString() + "&" + b_ThirteenN.ToString() + "&" + b_FourteenN.ToString() + "&" + b_FifteenN.ToString() + "&" + b_SixteenN.ToString();
            string num = n_num + "+" + b_num;
            return num;
        }

        #endregion

        //#region 号码历史出现情况
        //public string AppearTab(int playName,string cond)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("<table width=\"99%\" class=\"ssq-expert-charts\">");
        //     sb.Append("<tr>");
        //     sb.Append("<td>红球号码</td>");
        //     sb.Append("<td>1</td>");
        //     sb.Append("<td>2</td>");
        //     sb.Append("<td>3</td>");
        //     sb.Append("<td>4</td>");
        //     sb.Append("<td>5</td>");
        //     sb.Append("<td>6</td>");
        //     sb.Append("<td>7</td>");
        //     sb.Append("<td>8</td>");
        //     sb.Append("<td>9</td>");
        //     sb.Append("<td>10</td>");
        //     sb.Append("<td>11</td>");
        //     sb.Append("<td>12</td>");
        //     sb.Append("<td>13</td>");
        //     sb.Append("<td>14</td>");
        //     sb.Append("<td>15</td>");
        //     sb.Append("<td>16</td>");
        //     sb.Append("<td>17</td>");
        //     sb.Append("<td>18</td>");
        //     sb.Append("<td>19</td>");
        //     sb.Append("<td>20</td>");
        //     sb.Append("<td>21</td>");
        //     sb.Append("<td>22</td>");
        //     sb.Append("<td>23</td>");
        //     sb.Append("<td>24</td>");
        //     sb.Append("<td>25</td>");
        //     sb.Append("<td>26</td>");
        //     sb.Append("<td>27</td>");
        //     sb.Append("<td>28</td>");
        //     sb.Append("<td>29</td>");
        //     sb.Append("<td>30</td>");
        //     sb.Append("<td>31</td>");
        //     sb.Append("<td>32</td>");
        //     sb.Append("<td>33</td>");
                                
        //    sb.Append("</tr>");
        //    sb.Append("<tr>");
        //    sb.Append("<td>近30期内出现次数</td>");
        //    string BallNum=AppearNum(playName,"top 30",cond);
        //    sb.Append("<td>" + BallNum.Split('+')[0].Split('&')[0] + "</td>");
        //    sb.Append("<td>" + BallNum.Split('+')[0].Split('&')[1] + "</td>");
        //    sb.Append("<td>" + BallNum.Split('+')[0].Split('&')[2] + "</td>");
        //    sb.Append("<td>" + BallNum.Split('+')[0].Split('&')[3] + "</td>");
        //    sb.Append("<td>" + BallNum.Split('+')[0].Split('&')[4] + "</td>");
        //    sb.Append("<td>" + BallNum.Split('+')[0].Split('&')[5] + "</td>");
        //    sb.Append("<td>" + BallNum.Split('+')[0].Split('&')[6] + "</td>");
        //    sb.Append("<td>" + BallNum.Split('+')[0].Split('&')[7] + "</td>");
        //    sb.Append("<td>" + BallNum.Split('+')[0].Split('&')[8] + "</td>");
        //    sb.Append("<td>" + BallNum.Split('+')[0].Split('&')[9] + "</td>");
        //    sb.Append("<td>" + BallNum.Split('+')[0].Split('&')[10] + "</td>");
        //    sb.Append("<td>" + BallNum.Split('+')[0].Split('&')[11] + "</td>");
        //    sb.Append("<td>" + BallNum.Split('+')[0].Split('&')[12] + "</td>");
        //    sb.Append("<td>" + BallNum.Split('+')[0].Split('&')[13] + "</td>");
        //    sb.Append("<td>" + BallNum.Split('+')[0].Split('&')[14] + "</td>");
        //    sb.Append("<td>" + BallNum.Split('+')[0].Split('&')[15] + "</td>");
        //    sb.Append("<td>" + BallNum.Split('+')[0].Split('&')[16] + "</td>");
        //    sb.Append("<td>" + BallNum.Split('+')[0].Split('&')[17] + "</td>");
        //    sb.Append("<td>" + BallNum.Split('+')[0].Split('&')[18] + "</td>");
        //    sb.Append("<td>" + BallNum.Split('+')[0].Split('&')[19] + "</td>");
        //    sb.Append("<td>" + BallNum.Split('+')[0].Split('&')[20] + "</td>");
        //    sb.Append("<td>" + BallNum.Split('+')[0].Split('&')[21] + "</td>");
        //    sb.Append("<td>" + BallNum.Split('+')[0].Split('&')[22] + "</td>");
        //    sb.Append("<td>" + BallNum.Split('+')[0].Split('&')[23] + "</td>");
        //    sb.Append("<td>" + BallNum.Split('+')[0].Split('&')[24] + "</td>");
        //    sb.Append("<td>" + BallNum.Split('+')[0].Split('&')[25] + "</td>");
        //    sb.Append("<td>" + BallNum.Split('+')[0].Split('&')[26] + "</td>");
        //    sb.Append("<td>" + BallNum.Split('+')[0].Split('&')[27] + "</td>");
        //    sb.Append("<td>" + BallNum.Split('+')[0].Split('&')[28] + "</td>");
        //    sb.Append("<td>" + BallNum.Split('+')[0].Split('&')[29] + "</td>");
        //    sb.Append("<td>" + BallNum.Split('+')[0].Split('&')[30] + "</td>");
        //    sb.Append("<td>" + BallNum.Split('+')[0].Split('&')[31] + "</td>");
        //    sb.Append("<td>" + BallNum.Split('+')[0].Split('&')[32] + "</td>");

        //    sb.Append("</tr>");
        //    sb.Append("<tr>");
        //    sb.Append("<td>历史出现次数</td>");
        //    sb.Append("<td>1</td>");
        //    sb.Append("<td>2</td>");
        //    sb.Append("<td>3</td>");
        //    sb.Append("<td>4</td>");
        //    sb.Append("<td>5</td>");
        //    sb.Append("<td>6</td>");
        //    sb.Append("<td>7</td>");
        //    sb.Append("<td>8</td>");
        //    sb.Append("<td>9</td>");
        //    sb.Append("<td>10</td>");
        //    sb.Append("<td>11</td>");
        //    sb.Append("<td>12</td>");
        //    sb.Append("<td>13</td>");
        //    sb.Append("<td>14</td>");
        //    sb.Append("<td>15</td>");
        //    sb.Append("<td>16</td>");
        //    sb.Append("<td>17</td>");
        //    sb.Append("<td>18</td>");
        //    sb.Append("<td>19</td>");
        //    sb.Append("<td>20</td>");
        //    sb.Append("<td>21</td>");
        //    sb.Append("<td>22</td>");
        //    sb.Append("<td>23</td>");
        //    sb.Append("<td>24</td>");
        //    sb.Append("<td>25</td>");
        //    sb.Append("<td>26</td>");
        //    sb.Append("<td>27</td>");
        //    sb.Append("<td>28</td>");
        //    sb.Append("<td>29</td>");
        //    sb.Append("<td>30</td>");
        //    sb.Append("<td>31</td>");
        //    sb.Append("<td>32</td>");
        //    sb.Append("<td>33</td>");

        //    sb.Append("</tr>");
        //    sb.Append("</table>");
        //    return HttpContext.Current.Server.HtmlEncode(sb.ToString()); ;
        //}
        //#endregion
        #region 开奖号码
        /// <summary>
        /// 获取彩种的开奖号码
        /// </summary>
        /// <param name="lottID">彩种ID</param>
        /// <param name="issue">期号</param>
        /// <returns></returns>
        [WebMethod]
        public string lottOpenNum(int lottID,int issue)
        {
            string num = "";
            if (lottID == 9999)
            {
                num = Method.RlotteryNum(4, issue);
                num = num.Substring(0,3);
            }
            else
            {
                num = Method.RlotteryNum(lottID, issue);
            }
            if (num == "")
            {

                return "暂无开奖号码";
            }

            return num;
        }
        #endregion


        #region 添加 取消关注会员
        /// <summary>
        /// 添加关注
        /// </summary>
        /// <param name="IdolName">偶像名（关注人名称）</param>
        /// <param name="sign">平台标志</param>
        /// 返回 1  关注成功   返回 0 关注失败  返回 2 已经添加关注
        /// <returns></returns>
       [WebMethod]
        public int addTo(string IdolName, string sign)
        {
            if (Method.Get_UserName.ToString() == "0" || Method.Get_UserName.ToString() == "")
            {
                return 3;
            }
            else
            {
                Pbzx.BLL.PBnet_PayAtt pa = new Pbzx.BLL.PBnet_PayAtt();
                int returnValue = pa.AddPayAtt(Method.Get_UserName.ToString(),Server.UrlDecode(IdolName), sign);
                return returnValue;
            }
        }

        /// <summary>
        /// 取消关注
        /// </summary>
        /// <param name="IdolName">偶像名（关注人名称）</param>
        /// <param name="sign">平台标志</param>
        /// 返回 1  取消成功   返回 0 取消失败  返回 2 您还没有添加关注
        /// <returns></returns>
       [WebMethod]
        public int delTo(string IdolName, string sign)
        {
            if (Method.Get_UserName.ToString() == "0" || Method.Get_UserName.ToString() == "")
            {
                return 3;
            }
            else
            {
                Pbzx.BLL.PBnet_PayAtt pa = new Pbzx.BLL.PBnet_PayAtt();
                int returnValue = pa.DeletePayAtt(Method.Get_UserName.ToString(), Server.UrlDecode(IdolName), sign);
                return returnValue;
            }
        }

       /// <summary>
       /// 返回关注列表  我关注的人
       /// </summary>
       /// <param name="name">fans  用户名</param>
       /// <returns></returns>
       [WebMethod]
       public string Ipayatt(string name)
       {
           Pbzx.BLL.PBnet_PayAtt get_pt = new Pbzx.BLL.PBnet_PayAtt();
           DataSet ds = get_pt.GetList("Pa_fans=" + "'" + name + "'" + " and Pa_PSign='pblt'");
           StringBuilder sb = new StringBuilder();
           sb.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">");

           sb.Append("<tr>");
           sb.Append("<td>序号</td>");
           sb.Append("<td>会员名</td>");
           sb.Append("<td>关注时间</td>");
           sb.Append("<td>操作</td>");
           sb.Append("</tr>");
           int RowCount = 1;
           foreach (DataRow dr in ds.Tables[0].Rows)
           {
               sb.Append("<tr>");
               sb.Append("<td>" + RowCount + "</td>");
               sb.Append("<td><a href=\"Person.aspx?name=" + dr["Pa_Idol"].ToString() + "\" target=\"_blank\">" + dr["Pa_Idol"].ToString() + "</a></td>");
               sb.Append("<td>" + dr["Pa_time"].ToString() + "</td>");
               sb.Append("<td><a href=\"javascript:void(0)\" onClick=\"CancelPayAtt('" + name + "')\">取消关注</a></td>");
               sb.Append("</tr>");
               RowCount++;
           }
           sb.Append("<table>");
           return HttpContext.Current.Server.HtmlEncode(sb.ToString());
       }
       /// <summary>
       /// 返回关注列表 关注我的人
       /// </summary>
       /// <param name="name">Idol  用户名</param>
       /// <returns></returns>
       [WebMethod]
       public string batt(string name)
       {
           Pbzx.BLL.PBnet_PayAtt get_pt = new Pbzx.BLL.PBnet_PayAtt();
           DataSet ds = get_pt.GetList("Pa_Idol=" + "'" + name + "'" + " and Pa_PSign='pblt'");
           StringBuilder sb = new StringBuilder();
           sb.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">");

           sb.Append("<tr>");
           sb.Append("<td>序号</td>");
           sb.Append("<td>会员名</td>");
           sb.Append("<td>关注时间</td>");
           sb.Append("</tr>");
           int RowCount = 1;
           foreach (DataRow dr in ds.Tables[0].Rows)
           {
               sb.Append("<tr>");
               sb.Append("<td>" + RowCount + "</td>");
               sb.Append("<td><a href=\"Person.aspx?name=" + dr["Pa_fans"].ToString() + "\" target=\"_blank\">" + dr["Pa_fans"].ToString() + "</a></td>");
               sb.Append("<td>" + dr["Pa_time"].ToString() + "</td>");
               sb.Append("</tr>");
               RowCount++;
           }
           sb.Append("<table>");
           return HttpContext.Current.Server.HtmlEncode(sb.ToString());
       }


        #endregion
    }
}
