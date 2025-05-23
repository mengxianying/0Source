using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Text;
using System.Web.UI;
using Maticsoft.DBUtility;
using System.IO;
using Pbzx.Common;
using Pbzx.SQLServerDAL;

namespace Pinble_DataRivalry
{
    /// <summary>
    /// DataList 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]

    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]
    public class DataList : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
    
        /// <summary>
        /// 3D直选列表
        /// </summary>
        /// <param name="pageNum">页数</param>
        /// <param name="lotteryName">彩种</param>
        /// <returns></returns>
        [WebMethod]
        public string atlarge(int pageNum,string lotteryName)
        {
            
            Pbzx.BLL.DataRivalry_UpLoadFile get_uplod = new Pbzx.BLL.DataRivalry_UpLoadFile();
            Pbzx.BLL.DataRivalry_Contrast get_con = new Pbzx.BLL.DataRivalry_Contrast();
            DataTable IsResult=new DataTable();

            StringBuilder sb=new StringBuilder();
            sb.Append("<table cellspacing=\"0\" width=\"100%\">");
            sb.Append("<tr style=\"background-color: #FFFFD9; text-align: center;\">");
            sb.Append("<td width=\"6%\" style=\"border-left: 1px dotted #CCC;\">会员名称</td>");
            sb.Append("<td width=\"10%\">提交时间</td>");
            sb.Append("<td width=\"5%\">期号</td>");
            sb.Append("<td width=\"3%\">注数</td>");
            sb.Append("<td width=\"3%\">组选</td>");
            sb.Append("<td width=\"3%\">2D</td>");
            sb.Append("<td width=\"3%\">1D</td>");
            sb.Append("<td width=\"3%\">0D</td>");
            sb.Append("<td width=\"3%\">开奖号</td>");
            sb.Append("<td width=\"2%\">奖励</td>");
            sb.Append("<td width=\"5%\">命中期数</td>");
            sb.Append("<td width=\"4%\">操作</td>");
            sb.Append("</tr>");
            StringBuilder strSql=new StringBuilder();
            if (lotteryName == "3Dzx")
            {
                strSql.Append("F_SingleGroup=1");
                strSql.Append(" and F_lottery=1");
            }
            if (lotteryName == "3Dzux")
            {
                strSql.Append("F_SingleGroup=2");
                strSql.Append(" and F_lottery=1");
            }
            if (lotteryName == "P3zx")
            {
                strSql.Append("F_SingleGroup=1");
                strSql.Append(" and F_lottery=2");
            }
            if (lotteryName == "P3zux")
            {
                strSql.Append("F_SingleGroup=2");
                strSql.Append(" and F_lottery=2");
            }
            string Searchstr = strSql.ToString();
            string order = "F_addTime desc";
            int mycount = 0;
            IsResult = get_uplod.GuestGetBySearchUp(Searchstr, "*", order, 40, 3, pageNum, out mycount);
            foreach( DataRow dr in IsResult.Rows)
            {
                sb.Append("<tr>");
                sb.Append("<td style=\"border-left: 1px dotted #CCC;\"><a href='UserStatistics.aspx?name="+ dr[2].ToString() +"' target=\"_bank\">" + dr[2] + "</a></td>");        
                sb.Append("<td>"+ Convert.ToDateTime(dr[9]).ToString("yyyy-MM-dd HH:mm:ss") +"</td>");
                sb.Append("<td>"+ dr[1] +"</td>");
                DataSet ds = get_con.GetList("ct_drID="+ Convert.ToInt32(dr[0]));
                sb.Append("<td>" + Convert.ToInt32(ds.Tables[0].Rows[0]["ct_Num"].ToString().Split(' ').Length) + "</td>");

                string dataStr = DataContrest("012", ds.Tables[0].Rows[0]["ct_Num"].ToString(), 1);
                sb.Append("<td>"+ dataStr.Split('|')[4].ToString() +"</td>");
                sb.Append("<td>"+ dataStr.Split('|')[1].ToString() +"</td>");
                sb.Append("<td>"+ dataStr.Split('|')[2].ToString() +"</td>");
                sb.Append("<td>"+ dataStr.Split('|')[3].ToString() +"</td>");
                
                //提取开奖号
                Pbzx.BLL.FC3DData get_3D = new Pbzx.BLL.FC3DData();
                DataSet ds3D = get_3D.GetList("issue="+"'"+ dr[1] +"'");
                if (ds3D == null || ds3D.Tables[0].Rows.Count <= 0)
                {
                    sb.Append("<td>未开奖</td>");
                }
                else
                {
                    sb.Append("<td>" + ds3D.Tables[0].Rows[0]["code"].ToString() + "</td>");
                }
                sb.Append("<td>奖励</td>");
                int winning = Convert.ToInt32(dataStr.Split('|')[0]) + Convert.ToInt32(dataStr.Split('|')[1]) + Convert.ToInt32(dataStr.Split('|')[2]) + Convert.ToInt32(dataStr.Split('|')[3]) + Convert.ToInt32(dataStr.Split('|')[4]);
                sb.Append("<td>" + winning +"/"+ Convert.ToInt32(ds.Tables[0].Rows[0]["ct_Num"].ToString().Split(' ').Length) + "</td>");
                sb.Append("<td>下载</td>");
                sb.Append("</tr>");
            }    
            sb.Append("</table>");

            return sb.ToString();
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
            if (singleGroup == 1)
            {
                //去除重复数据
                string[] str = new string[UpLoadNum.Split(' ').Length];
                for (int k = 0; k < UpLoadNum.Split(' ').Length; k++)
                {
                    str[k] = UpLoadNum.Split(' ')[k];
                }
                string[] array = removeDuplicate(str);
                //单选大底
                for (int i = 0; i < array.Length; i++)
                {
                    if (CorrectNum == array[i])
                    {
                        //计算全中个数
                        g_count++;
                    }
                    string Correct = CorrectNum.Substring(0, 1) + "*" + CorrectNum.Substring(2, 1);
                    string DataNum = array[i].Substring(0, 1) + "*" + array[i].Substring(2, 1);
                    if (CorrectNum.Substring(0, 2) == array[i].Substring(0, 2) || CorrectNum.Substring(1, 2) == array[i].Substring(1, 2) || Correct == DataNum)
                    {
                        //2D 中2个数
                        g_rd++;
                    }
                    if (CorrectNum.Substring(0, 1) == array[i].Substring(0, 1) || CorrectNum.Substring(1, 1) == array[i].Substring(1, 1) || CorrectNum.Substring(2, 1) == array[i].Substring(2, 1))
                    {
                        //1D 中一个数  分百位 十位  个位
                        g_ad++;
                    }
                    int num1 = 0;
                    int num2 = 0;
                    for (int j = 0; j < 3; j++)
                    {
                        num1 += Convert.ToInt32(CorrectNum.Substring(j, 1));
                        num2 += Convert.ToInt32(array[i].Substring(j, 1));
                    }

                    if (num1 == num2)
                    {
                        g_group++;
                    }
                    //中0位
                    for (int k = 0; k < 3; k++)
                    {
                        if (CorrectNum.Substring(k, 1) != array[i].Substring(0, 1) && CorrectNum.Substring(k, 1) != array[i].Substring(1, 1) && CorrectNum.Substring(k, 1) != array[i].Substring(2, 1))
                        {
                            g_zero++;
                        }
                    }
                }
                //g_result = "全中：" + g_count + "|2D：" + g_rd + "|1D：" + g_ad + "|中0：" + g_zero + "|中组：" + g_group;
                g_result =  g_count + "|" + g_rd + "|" + g_ad + "|" + g_zero + "|" + g_group;
            }
            if (singleGroup == 2)
            {
                //去除重复数据
                string[] str = new string[UpLoadNum.Split(' ').Length];
                for (int k = 0; k < UpLoadNum.Split(' ').Length; k++)
                {
                    str[k] = UpLoadNum.Split(' ')[k];
                }
                string[] array = removeDuplicate(str);
                //组选大底 没有中单
                for (int i = 0; i < array.Length; i++)
                {
                    string Correct = CorrectNum.Substring(0, 1) + "*" + CorrectNum.Substring(2, 1);
                    string DataNum = array[i].Substring(0, 1) + "*" + array[i].Substring(2, 1);
                    if (CorrectNum.Substring(0, 2) == array[i].Substring(0, 2) || CorrectNum.Substring(1, 2) == array[i].Substring(1, 2) || Correct == DataNum)
                    {
                        //2D 中2个数
                        g_rd++;
                    }
                    if (CorrectNum.Substring(0, 1) == array[i].Substring(0, 1) || CorrectNum.Substring(1, 1) == array[i].Substring(1, 1) || CorrectNum.Substring(2, 1) == array[i].Substring(2, 1))
                    {
                        //1D 中一个数  分百位 十位  个位
                        g_ad++;
                    }
                    int num1 = 0;
                    int num2 = 0;
                    for (int j = 0; j < 3; j++)
                    {
                        num1 += Convert.ToInt32(CorrectNum.Substring(j, 1));
                        num2 += Convert.ToInt32(array[i].Substring(j, 1));
                    }

                    if (num1 == num2)
                    {
                        g_group++;
                    }
                    //中0位
                    for (int k = 0; k < 3; k++)
                    {
                        if (CorrectNum.Substring(k, 1) != array[i].Substring(0, 1) && CorrectNum.Substring(k, 1) != array[i].Substring(1, 1) && CorrectNum.Substring(k, 1) != array[i].Substring(2, 1))
                        {
                            g_zero++;
                        }
                    }
                }
                //g_result = "|2D：" + g_rd + "|1D：" + g_ad + "|中0：" + g_zero + "|中组：" + g_group;
                g_result =  g_rd + "|" + g_ad + "|" + g_zero + "|" + g_group;

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
            int sum = 0;
            //ArrayList arr = new ArrayList();
            string[] arr = new string[number.Split(' ').Length];
            for (int i = 0; i < number.Split(' ').Length; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    sum += Convert.ToInt32(number.Split(' ')[i].Substring(j, 1));
                }
                arr[i] = sum.ToString();
                sum = 0;
            }
            string[] str = removeDuplicate(arr);
            return str.Length;
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
        #region 开奖号码
        /// <summary>
        /// 获取彩种的开奖号码
        /// </summary>
        /// <param name="lottID">彩种ID</param>
        /// <param name="issue">期号</param>
        /// <returns></returns>
        [WebMethod]
        public string lottOpenNum(int lottID, int issue)
        {
            string num = "";
            if (lottID == 9999)
            {
                num = Method.RlotteryNum(4, issue).Substring(0, 3);
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

        /// <summary>
        /// 返回关注列表  我关注的人
        /// </summary>
        /// <param name="name">fans  用户名</param>
        /// <returns></returns>
        [WebMethod]
        public string Ipayatt(string name)
        { 
            Pbzx.BLL.PBnet_PayAtt get_pt=new Pbzx.BLL.PBnet_PayAtt();
            DataSet ds = get_pt.GetList("Pa_fans=" + "'" + name + "'" + " and Pa_PSign='ddbp'");
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
               sb.Append("<td><a href=\"MemberInfo.aspx?name=" + dr["Pa_Idol"].ToString() + "\" target=\"_blank\">" + dr["Pa_Idol"].ToString() + "</a></td>");
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
            DataSet ds = get_pt.GetList("Pa_Idol=" + "'" + name + "'" + " and Pa_PSign='ddbp'");
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
                sb.Append("<td><a href=\"MemberInfo.aspx?name=" + dr["Pa_fans"].ToString() + "\" target=\"_blank\">" + dr["Pa_fans"].ToString() + "</a></td>");
                sb.Append("<td>" + dr["Pa_time"].ToString() + "</td>");
                sb.Append("</tr>");
                RowCount++;
            }
            sb.Append("<table>");
            return HttpContext.Current.Server.HtmlEncode(sb.ToString());
        }

        /// <summary>
        /// 添加关注
        /// </summary>
        /// <param name="fansName">粉丝名</param>
        /// <param name="idolName">偶像名</param>
        /// <returns></returns>
        [WebMethod]
        public int addPayAtt(string fansName, string idolName)
        {
            Pbzx.BLL.PBnet_PayAtt get_pt = new Pbzx.BLL.PBnet_PayAtt();
            int state = -1;
            if (fansName == idolName)
            {
                state = 3;
            }
            else
            {
                state = get_pt.AddPayAtt(fansName, idolName, "ddbp");
            }
            return state;
        }
        /// <summary>
        /// 取消关注
        /// </summary>
        /// <param name="fansName">粉丝名</param>
        /// <param name="idolName">偶像名</param>
        /// <returns></returns>
        [WebMethod]
        public int DeletePayAtt(string fansName, string idolName)
        {
            Pbzx.BLL.PBnet_PayAtt get_pt = new Pbzx.BLL.PBnet_PayAtt();
            int state = get_pt.DeletePayAtt(fansName, idolName, "ddbp");
            return state;
        }

    }
}
