using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.DBUtility;
using System.IO;
using System.Net;
using System.Text;
using System.Security.Cryptography;
using System.Xml;

namespace Pinble_Chipped
{
    public partial class ceshiLottery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //合买代购开奖
                TheLottery();
                //追号开奖
                //CatchNum();
                //MultiPhase();
            }
        }
        #region 处理出票中的订单
        //即时处理 未处理的订单 （处理出票中的订单）
        public void Handle()
        {
            //查询 显示投注重的数据
            DataSet ds = DbHelperSQL.Query("select * from Chipped_LaunchInfo where State=3");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    //请求参数
                    string getStr = PostStr(3821, 102, "zzzzzzz", "QNumber=" + ds.Tables[0].Rows[i]["QNumber"].ToString());

                    string str = PostUrl(getStr);

                    //接收返回字符串
                    string xmlStr = Receive(str);

                    int code = -1;

                    for (int j = 0; j < xmlStr.Split(',').Length; j++)
                    {
                        if (xmlStr.Split(',')[j].Split('|')[0] == "xCode")
                        {
                            code = Convert.ToInt32(xmlStr.Split(',')[j].Split('|')[1]);
                            break;
                        }
                    }
                    if (code == 1)
                    {

                        try
                        {

                            if (DbHelperSQL.Exists("update Chipped_LaunchInfo set State=1 where QNumber=" + "'" + ds.Tables[0].Rows[i]["QNumber"].ToString() + "'"))
                            {
                                //扣除用户购买金额
                                //get_p.DeductionDqM(ds.Tables[0].Rows[0]["In_num"].ToString());
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
        #endregion

        #region  处理多期出票
        /// <summary>
        /// 处理多期出票
        /// </summary>
        /// <param name="issue">当前期号</param>
        public void MultiPeriod(int issue)
        {
            //下一期期号
            int issueNext = issue + 1;

            //根据当前期  多下一期 进行处理
            DataSet ds = DbHelperSQL.Query("select * from v_RandomNumIssue where In_issue=" + "'" + issueNext + "'" + " and In_mark=0 and Rn_state=0 and In_state=0");

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    //对应代理商的彩票编号
                    int nLotNum = LotContrast(Convert.ToInt32(ds.Tables[0].Rows[i]["Rn_play"]));
                    //投注号码
                    DataSet dsNum = DbHelperSQL.Query("slelect * from Chipped_Num where N_InId=" + Convert.ToInt32(ds.Tables[0].Rows[i]["In_id"]));
                    //投注 出票
                    string prar = PostBetting(ds.Tables[0].Rows[i]["In_num"].ToString(), nLotNum, 20120626, Convert.ToInt32(ds.Tables[0].Rows[i]["In_money"]), dsNum.Tables[0].Rows[i]["N_num"].ToString(), Convert.ToInt32(ds.Tables[0].Rows[i]["In_multiple"]), "wwwwwwwww", 2);
                    //返回的字符串
                    string xmlStr = bett(prar, 101);
                    int code = -1;

                    for (int j = 0; j < xmlStr.Split(',').Length; j++)
                    {
                        if (xmlStr.Split(',')[j].Split('|')[0] == "xCode")
                        {
                            code = Convert.ToInt32(xmlStr.Split(',')[j].Split('|')[1]);
                            break;
                        }
                    }
                    //投注成功  code=1 出票成功
                    if (code == 0)
                    {
                        ////投注成功 (投注成功，冻结资金， 可能有出票失败)
                        //modUserTab.FrozenMoney = modUserTab.FrozenMoney + Convert.ToDecimal(buyMoney);
                        ////修改账户金额
                        //if (get_userTab.Update(modUserTab))
                        //{
                        //    //个人收支账户记录
                        //    Pbzx.BLL.PlatformPublic_payments get_pmen = new Pbzx.BLL.PlatformPublic_payments();
                        //    get_pmen.payments(Method.Get_UserName.ToString(), ds.Tables[0].Rows[0]["In_num"].ToString(), 3, Convert.ToInt32(ds.Tables[0].Rows[0]["In_issue"]), Convert.ToInt32(ds.Tables[0].Rows[0]["Rn_play"]), "多期机选订单" + ds.Tables[0].Rows[0]["In_num"].ToString() + "扣除投注资金", Convert.ToDecimal(buyMoney), "Chipped");
                        //    return 1;
                        //}
                    }
                }
            }
        }
        #endregion



        /// <summary>
        /// 多期投注n
        /// </summary>
        /// <param name="issue"></param>
        public void issueDrawer(string issue, int playName)
        {
            //

        }


        #region  查询期号是否已经截止并派奖
        /// <summary>
        /// //查询该期是够已经截止
        /// </summary>
        /// <param name="LotID">代理商的彩种ID</param>
        /// <param name="Issue">彩种期号</param>
        /// <returns></returns>
        public int LotEnd(int LotID, int Issue)
        {
            //业务参数
            string prar = PostBetting(LotID, Issue);
            //返回的字符串
            string xmlStr = bett(prar, 117);  //117 :期号状态查询

            string nCode = "";
            for (int j = 0; j < xmlStr.Split(',').Length; j++)
            {
                if (xmlStr.Split(',')[j].Split('|')[0] == "xValue")
                {
                    nCode = xmlStr.Split(',')[j].Split('|')[1].ToString();
                    break;
                }
            }
            return Convert.ToInt32(nCode);
        }
        #endregion

        #region 合买代购开奖处理

        /// <summary>
        /// 彩票开奖  合买代购开奖
        /// </summary>
        public void TheLottery()
        {
            //查询所有订单出票成功的
            DataSet ds = DbHelperSQL.Query("select QNumber,ExpectNum,playName from Chipped_LaunchInfo where State=1 and Winning=0");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                int nState = -1;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    //查询该彩种是否截止 2 为截止； 2010280
                    //nState = LotEnd(LotContrast(Convert.ToInt32(ds.Tables[0].Rows[i]["playName"])), Convert.ToInt32(ds.Tables[0].Rows[i]["ExpectNum"]));

                    //测试数据
                    nState = LotEnd(LotContrast(Convert.ToInt32(ds.Tables[0].Rows[i]["playName"])), Convert.ToInt32(20120626));

                    //9：截止已经派奖
                    if (nState == 9 || nState==1 )
                    {
                        //彩种已经截止。下面开奖

                        //业务参数
                        string prar = PostBetting(ds.Tables[0].Rows[i]["QNumber"].ToString());
                        //返回的字符串 111： 查询投注订单奖金
                        string xmlStr = bett(prar, 111);

                        string nCode = "";
                        for (int j = 0; j < xmlStr.Split(',').Length; j++)
                        {
                            if (xmlStr.Split(',')[j].Split('|')[0] == "xValue")
                            {
                                nCode = xmlStr.Split(',')[j].Split('|')[1].ToString();
                                break;
                            }
                        }
                        if (Convert.ToDecimal(nCode.Split('_')[2]) > 0)
                        {
                            //修改订单的中奖金额
                            if (DbHelperSQL.ExecuteSql("update Chipped_LaunchInfo set Winning='1',bounsAllost='" + nCode.Split('_')[2].ToString() + "' where ExpectNum=" + Convert.ToInt32(ds.Tables[0].Rows[i]["ExpectNum"]) + " and QNumber=" + "'" + ds.Tables[0].Rows[i]["QNumber"].ToString() + "'") > 0)
                            {
                                //派奖
                                BonusD(Convert.ToDecimal(nCode.Split('_')[2]), ds.Tables[0].Rows[i]["QNumber"].ToString());
                                Response.Write("开奖完成");
                            }
                        }
                        else
                        {
                            //等于0 说明开奖未中奖
                            DbHelperSQL.ExecuteSql("update Chipped_LaunchInfo set Winning='2',bounsAllost='0' where ExpectNum=" + Convert.ToInt32(ds.Tables[0].Rows[i]["ExpectNum"]) + " and QNumber=" + "'" + ds.Tables[0].Rows[i]["QNumber"].ToString() + "'");
                            Response.Write("开奖完成");
                        }

                    }
                }
            }
        }
        #endregion

        #region 追号开奖处理
        /// <summary>
        /// 追号开奖
        /// </summary>
        public void CatchNum()
        {
            DataSet ds = DbHelperSQL.Query("select * from Chippend_TrackNum where tn_open=0 and tn_complete=1"); // tn_open:中奖标志   tn_complete: 出票标志
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                int nState = -1;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    //查询该彩种是否截止 2 为截止； 2010280
                    //nState = LotEnd(LotContrast(Convert.ToInt32(ds.Tables[0].Rows[i]["tn_playname"])), Convert.ToInt32(ds.Tables[0].Rows[i]["tn_issue"]));

                    //测试数据
                    nState = LotEnd(LotContrast(Convert.ToInt32(ds.Tables[0].Rows[i]["tn_playname"])), Convert.ToInt32(20120626));

                    //9：截止已经派奖
                    if (nState == 9)
                    {
                        //彩种已经截止。下面开奖

                        //业务参数
                        string prar = PostBetting(ds.Tables[0].Rows[i]["tn_orderNum"].ToString());
                        //返回的字符串 111： 查询投注订单奖金
                        string xmlStr = bett(prar, 111);

                        string nCode = "";
                        for (int j = 0; j < xmlStr.Split(',').Length; j++)
                        {
                            if (xmlStr.Split(',')[j].Split('|')[0] == "xValue")
                            {
                                nCode = xmlStr.Split(',')[j].Split('|')[1].ToString();
                                break;
                            }
                        }
                        if (Convert.ToDecimal(nCode.Split('_')[2]) > 0)
                        {
                            //修改订单的中奖金额
                            if (DbHelperSQL.ExecuteSql("update Chippend_TrackNum set tn_open=1,tn_Inward='" + Convert.ToDecimal(nCode.Split('_')[2]) + "' where tn_issue=" + Convert.ToInt32(ds.Tables[0].Rows[i]["tn_issue"]) + " and tn_orderNum=" + "'" + ds.Tables[0].Rows[i]["tn_orderNum"].ToString() + "'") > 0)
                            {
                                //派奖
                                CatchDistribution(Convert.ToDecimal(nCode.Split('_')[2]), ds.Tables[0].Rows[0]["tn_orderNum"].ToString());
                                Response.Write("开奖完成");
                            }
                        }
                        else
                        {
                            //等于0 说明开奖未中奖
                            DbHelperSQL.ExecuteSql("update Chippend_TrackNum set tn_open=2,tn_Inward=0 where tn_issue=" + Convert.ToInt32(ds.Tables[0].Rows[i]["tn_issue"]) + " and tn_orderNum=" + "'" + ds.Tables[0].Rows[i]["tn_orderNum"].ToString() + "'");
                            Response.Write("开奖完成");
                        }

                    }
                }
            }
        }

        #endregion

        #region 多期机选开奖
        /// <summary>
        /// 
        /// </summary>
        public void MultiPhase()
        {
            //查询 已经出票 并未开奖的数据
            DataSet ds = DbHelperSQL.Query("select * from v_RandomNumIssue where In_mark=1 and In_state=0");  //In_mark: 出票标识   In_state：中奖标识
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                int nState = -1;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    //查询该彩种是否截止 2 为截止； 2010280
                    //nState = LotEnd(LotContrast(Convert.ToInt32(ds.Tables[0].Rows[i]["Rn_play"])), Convert.ToInt32(ds.Tables[0].Rows[i]["tn_issue"]));

                    //测试数据
                    nState = LotEnd(LotContrast(Convert.ToInt32(ds.Tables[0].Rows[i]["Rn_play"])), Convert.ToInt32(20120626));

                    //9：截止已经派奖
                    if (nState == 9)
                    {
                        //彩种已经截止。下面开奖

                        //业务参数
                        string prar = PostBetting(ds.Tables[0].Rows[i]["In_num"].ToString());
                        //返回的字符串 111： 查询投注订单奖金
                        string xmlStr = bett(prar, 111);

                        string nCode = "";
                        for (int j = 0; j < xmlStr.Split(',').Length; j++)
                        {
                            if (xmlStr.Split(',')[j].Split('|')[0] == "xValue")
                            {
                                nCode = xmlStr.Split(',')[j].Split('|')[1].ToString();
                                break;
                            }
                        }
                        if (Convert.ToDecimal(nCode.Split('_')[2]) > 0)
                        {
                            //修改订单的中奖金额
                            if (DbHelperSQL.ExecuteSql("update Chipped_issueN set In_state=1,In_bouns='" + Convert.ToDecimal(nCode.Split('_')[2]) + "' where In_issue=" + Convert.ToInt32(ds.Tables[0].Rows[i]["In_issue"]) + " and In_num=" + "'" + ds.Tables[0].Rows[i]["In_num"].ToString() + "'") > 0)
                            {
                                //派奖
                                //CatchDistribution(Convert.ToDecimal(nCode.Split('_')[2]), ds.Tables[0].Rows[0]["tn_orderNum"].ToString());
                                Response.Write("开奖完成");
                            }
                        }
                        else
                        {
                            //等于0 说明开奖未中奖
                            DbHelperSQL.ExecuteSql("update Chipped_issueN set In_state=2,In_bouns=0 where In_issue=" + Convert.ToInt32(ds.Tables[0].Rows[i]["In_issue"]) + " and In_num=" + "'" + ds.Tables[0].Rows[i]["In_num"].ToString() + "'");
                            Response.Write("开奖完成");
                        }

                    }
                }
            }

        }

        #endregion


        #region  和大赢家平台交互的  各种业务参数

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
        /// 查询中奖结果
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public string PostBetting(string OrderID)
        {
            string prar = "OrderID=" + OrderID;
            return prar;
        }

        /// <summary>
        /// 期号状态查询(业务参数)
        /// </summary>
        /// <param name="LotID">彩种ID</param>
        /// <param name="LotIssue">期号</param>
        /// <returns></returns>
        public string PostBetting(int LotID, int LotIssue)
        {
            string prar = "LotID=" + LotID + "_LotIssue=" + LotIssue;
            return prar;
        }

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
        /// 代理商参数设定
        /// </summary>
        /// <param name="prar">业务参数</param>
        /// <param name="prar2">交易申请编码(101:投注，102：处理结果查询)</param>
        /// <returns></returns>
        public string bett(string prar, int prar2)
        {

            //请求参数
            string getStr = PostStr(3821, prar2, "zzzzzzz", prar);

            string str = PostUrl(getStr);

            //接收返回字符串
            string xmlStr = Receive(str);

            return xmlStr;
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
            string nwSign = MD5(EncMD5, false);

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
        /// MD5加密字符串处理
        /// </summary>
        /// <param name="Half">加密是16位还是32位；如果为true为16位</param>
        /// <param name="Input">待加密码字符串</param>
        /// <returns></returns>
        public static string MD5(string Input, bool Half)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.Default.GetBytes(Input);
            byte[] result = md5.ComputeHash(data);
            String strReturn = String.Empty;
            for (int i = 0; i < result.Length; i++)
            {
                strReturn += result[i].ToString("x").PadLeft(2, '0');
            }
            if (Half)
            {
                return strReturn.Substring(8, 16);
            }
            return strReturn;

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
        #endregion

        #region  彩种编号对比  （对比平台的彩种编号）

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
        #endregion

        #region 个人账户收支记录
        /// <summary>
        /// 个人收支记录
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="Pp_num">订单或是流水号</param>
        /// <param name="type">交易类型（收入 、 支出）</param>
        /// <param name="issue">期号</param>
        /// <param name="LotName">彩种编号</param>
        /// <param name="explain">说明</param>
        /// <param name="Pp_data">具体数据</param>
        /// <param name="Time">时间</param>
        /// <param name="belongs">平台标志（）</param>
        /// <returns></returns>
        public static void TransactionRecord(string name, string Pp_num, int type, int issue, int LotName, string explain, decimal Pp_data, DateTime Time, string belongs)
        {
            string sqlstring = "'" + name + "','" + Pp_num + "','" + type + "','" + issue + "','" + LotName + "','" + explain + "','" + Pp_data + "','" + Time + "','" + belongs + "'";
            DbHelperSQL.ExecuteSql("insert into PlatformPublic_payments (Pp_name,Pp_num,Pp_Type,Pp_issue,Pp_LotName,Pp_explain,Pp_data,Pp_Time,Pp_belongs) values (" + sqlstring + ")");

        }
        //public static void TransactionRecord(string name, int type, int issue, int LotName, string explain, decimal Pp_data, DateTime Time, string belongs)
        //{
        //    string sqlstring = "'" + name + "','" + type + "','" + issue + "','" + LotName + "','" + explain + "','" + Pp_data + "','" + Time + "','" + belongs + "'";
        //    DbHelperSQL.ExecuteSql("insert into PlatformPublic_payments (Pp_name,Pp_Type,Pp_issue,Pp_LotName,Pp_explain,Pp_data,Pp_Time,Pp_belongs) values (" + sqlstring + ")");

        //}
        #endregion

        #region 合买代购中奖分配 （金额的分配）
        /// <summary>
        /// 合买中奖分配 (合买代购中奖处理)
        /// </summary>
        /// <param name="BMoney">中奖金额</param>
        /// <param name="OrderNum">订单号</param>
        public static void BonusD(decimal BMoney, string OrderNum)
        {
            //每份的价格
            decimal EachCopy = 0;
            //个人获得的奖金
            decimal UMoney = 0;
            //根据订单查询
            DataSet ds = DbHelperSQL.Query("select * from Chipped_LaunchInfo where QNumber=" + "'" + OrderNum + "'");
            //处理合买
            if (Convert.ToInt32(ds.Tables[0].Rows[0]["Purchasing"]) == 2)
            {

                //每份的所得价格 中奖金额/划分的分数
                EachCopy = BMoney / Convert.ToInt32(ds.Tables[0].Rows[0]["Share"]);
                //发起人所中奖金
                UMoney = Convert.ToInt32(ds.Tables[0].Rows[0]["BuyShare"]) * EachCopy;
                //订单发起 单份价格
                decimal SpendMoney = Convert.ToDecimal(ds.Tables[0].Rows[0]["AtotalMoney"]) / Convert.ToInt32(ds.Tables[0].Rows[0]["Share"]);
                //花费的金额
                decimal MoneyS = Convert.ToDecimal(ds.Tables[0].Rows[0]["BuyShare"]) * SpendMoney;

                //修改用户的账户金额
                if (UpdateUserAmount(ds.Tables[0].Rows[0]["UserName"].ToString(), UMoney))
                {
                    //记录交易
                    TransactionRecord(ds.Tables[0].Rows[0]["UserName"].ToString(), OrderNum, 2, Convert.ToInt32(ds.Tables[0].Rows[0]["ExpectNum"]), Convert.ToInt32(ds.Tables[0].Rows[0]["playName"]), "合买代购中奖", UMoney, Convert.ToDateTime(DateTime.Now), "Chipped");
                }
                //处理合买用户
                DataSet ds_Buy = DbHelperSQL.Query("select * from Chipped_info where QNumber=" + "'" + OrderNum + "'");
                //有合买的用户。 
                if (ds_Buy != null && ds_Buy.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds_Buy.Tables[0].Rows.Count; i++)
                    {
                        //用户所获得的金额 
                        decimal Buy_Money = Convert.ToDecimal(ds_Buy.Tables[0].Rows[i]["ChippedShare"]) * EachCopy;

                        //花费金额
                        decimal S_money = Convert.ToDecimal(ds_Buy.Tables[0].Rows[i]["ChippedShare"]) * SpendMoney;

                        //修改用户的账户金额 
                        if (UpdateUserAmount(ds_Buy.Tables[0].Rows[i]["ChippedName"].ToString(), Buy_Money))
                        {
                            //记录交易
                            TransactionRecord(ds_Buy.Tables[0].Rows[i]["ChippedName"].ToString(), OrderNum, 2, Convert.ToInt32(ds.Tables[0].Rows[0]["ExpectNum"]), Convert.ToInt32(ds.Tables[0].Rows[0]["playName"]), "合买代购中奖", UMoney, Convert.ToDateTime(DateTime.Now), "Chipped");
                        }
                    }
                }
            }
            //处理代购
            if (Convert.ToInt32(ds.Tables[0].Rows[0]["Purchasing"]) == 1)
            {
                //修改用户的账户金额
                if (UpdateUserAmount(ds.Tables[0].Rows[0]["UserName"].ToString(), BMoney))
                {
                    //记录交易
                    TransactionRecord(ds.Tables[0].Rows[0]["UserName"].ToString(), OrderNum, 2, Convert.ToInt32(ds.Tables[0].Rows[0]["ExpectNum"]), Convert.ToInt32(ds.Tables[0].Rows[0]["playName"]), "合买代购中奖", UMoney, Convert.ToDateTime(DateTime.Now), "Chipped");
                }
            }


        }
        #endregion

        #region  追号中奖分配
        /// <summary>
        /// 追号中奖分配
        /// </summary>
        /// <param name="money">中奖金额</param>
        /// <param name="orderNum">订单号</param>
        public void CatchDistribution(decimal money, string orderNum)
        {
            try
            {
                DataSet ds = DbHelperSQL.Query("select tn_username,tn_issue,tn_playname from Chippend_TrackNum where tn_orderNum=" + "'" + orderNum + "'");
                if (UpdateUserAmount(ds.Tables[0].Rows[0]["tn_username"].ToString(), money))
                {
                    //记录交易
                    TransactionRecord(ds.Tables[0].Rows[0]["tn_username"].ToString(), orderNum, 2, Convert.ToInt32(ds.Tables[0].Rows[0]["tn_issue"]), Convert.ToInt32(ds.Tables[0].Rows[0]["tn_playname"]), "追号中奖分配奖金", money, Convert.ToDateTime(DateTime.Now), "Chipped");
                }
            }
            catch (Exception ex)
            {
                //全局错误日志
                Pbzx.Common.ErrorLog.WriteLog(ex);
            }

        }
        #endregion


        #region  多期机选奖金分配
        /// <summary>
        /// 多期机选中奖 奖金分配
        /// </summary>
        /// <param name="money">中奖金额</param>
        /// <param name="orderNum">订单号</param>
        public void MultiDistribution(decimal money, string orderNum)
        {
            try
            {
                DataSet ds = DbHelperSQL.Query("select Rn_name,In_issue,Rn_play from v_RandomNumIssue where In_num=" + "'" + orderNum + "'");
                if (UpdateUserAmount(ds.Tables[0].Rows[0]["Rn_name"].ToString(), money))
                {
                    //记录交易
                    TransactionRecord(ds.Tables[0].Rows[0]["Rn_name"].ToString(), orderNum, 2, Convert.ToInt32(ds.Tables[0].Rows[0]["In_issue"]), Convert.ToInt32(ds.Tables[0].Rows[0]["Rn_play"]), "多期机选中奖分配奖金", money, Convert.ToDateTime(DateTime.Now), "Chipped");
                }
            }
            catch (Exception ex)
            {
                //全局错误日志
                Pbzx.Common.ErrorLog.WriteLog(ex);
            }
        }

        #endregion




        #region 处理 中奖 (包括中奖、返还、奖励、提成)
        /// <summary>
        /// 修改会员账户金额
        /// </summary>
        /// <param name="username">会员名称</param>
        /// <param name="Money">中奖金额</param>
        /// <returns></returns>
        public static bool UpdateUserAmount(string username, decimal Money)
        {
            DataSet ds = DbHelperSQL.Query("select FrozenMoney,CurrentMoney from PBnet_UserTable where UserName=" + "'" + username + "'");
            //用户的中奖金额+原来用户的余额
            decimal UserMoney = Convert.ToDecimal(ds.Tables[0].Rows[0]["CurrentMoney"]) + Money;


            //修改用户的金额 成功返回 true  不成功返回false
            if (DbHelperSQL.ExecuteSql("update PBnet_UserTable set CurrentMoney=" + "'" + UserMoney + "'" + " where UserName=" + "'" + username + "'") > 0)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region  扣除购买金额 （合买代购，追号，多期）
        /// <summary>
        /// 扣除用户购买花费金额 合买代购订单
        /// </summary>
        /// <param name="orderNum">订单号</param>
        public void DeductionMonery(string orderNum)
        {


            //查询订单
            DataSet ds = DbHelperSQL.Query("select * from Chipped_LaunchInfo where QNumber=" + "'" + orderNum + "'");

            //合买代购
            if (Convert.ToInt32(ds.Tables[0].Rows[0]["Purchasing"]) == 1)
            {
                //代购
                DataSet ds_user = DbHelperSQL.Query("select CurrentMoney,FrozenMoney from PBnet_UserTable where UserName=" + "'" + ds.Tables[0].Rows[0]["UserName"] + "'");

                decimal CurrentMoney = Convert.ToDecimal(ds_user.Tables[0].Rows[0]["CurrentMoney"]) - Convert.ToDecimal(ds.Tables[0].Rows[0]["AtotalMoney"]);
                decimal FrozenMoney = Convert.ToDecimal(ds_user.Tables[0].Rows[0]["FrozenMoney"]) - Convert.ToDecimal(ds.Tables[0].Rows[0]["AtotalMoney"]);
                try
                {
                    if (DbHelperSQL.Exists("update Chipped_LaunchInfo set CurrentMoney=" + "'" + CurrentMoney + "'" + ",FrozenMoney=" + "'" + FrozenMoney + "'" + " where UserName=" + "'" + ds.Tables[0].Rows[0]["UserName"] + "'"))
                    {

                        //记录交易
                        //TransactionRecord(ds.Tables[0].Rows[0]["UserName"].ToString(), orderNum, 1, Convert.ToInt32(ds.Tables[0].Rows[0]["ExpectNum"]), Convert.ToInt32(ds.Tables[0].Rows[0]["playName"]), ds.Tables[0].Rows[0]["ExpectNum"].ToString() + "期" + "订单出票成功扣除资金", Convert.ToInt32(ds.Tables[0].Rows[0]["AtotalMoney"]), "Chipped");

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
                DataSet ds_buy = DbHelperSQL.Query("select * from v_Merger where QNumber=" + "'" + orderNum + "'");

                //方案单份的价格
                decimal nEachMoney = Convert.ToDecimal(ds.Tables[0].Rows[0]["AtotalMoney"]) / Convert.ToInt32(ds.Tables[0].Rows[0]["Share"]);

                //合买 查询没个合买用户所花费的金额
                for (int i = 0; i < ds_buy.Tables[0].Rows.Count; i++)
                {
                    //所花费的金额
                    decimal nConsumption = nEachMoney * Convert.ToInt32(ds_buy.Tables[0].Rows[i]["ChippedShare"]);

                    DataSet ds_user = DbHelperSQL.Query("select Id,CurrentMoney,FrozenMoney from PBnet_UserTable where UserName=" + "'" + ds_buy.Tables[0].Rows[i]["ChippedName"] + "'");

                    decimal CurrentMoney = Convert.ToDecimal(ds_user.Tables[0].Rows[0]["CurrentMoney"]) - nConsumption;
                    decimal FrozenMoney = Convert.ToDecimal(ds_user.Tables[0].Rows[0]["FrozenMoney"]) - nConsumption;
                    try
                    {
                        if (DbHelperSQL.Exists("update PBnet_UserTable set CurrentMoney=" + "'" + CurrentMoney + "'" + ",FrozenMoney=" + "'" + FrozenMoney + "'" + " where Id=" + Convert.ToInt32(ds_user.Tables[0].Rows[0]["Id"])))
                        {
                            ////记录本次交易
                            ////个人收支账户记录
                            //Pbzx.BLL.PlatformPublic_payments get_pmen = new Pbzx.BLL.PlatformPublic_payments();
                            //get_pmen.payments(ds_buy.Tables[0].Rows[i]["ChippedName"].ToString(), orderNum, 1, Convert.ToInt32(ds.Tables[0].Rows[0]["ExpectNum"]), Convert.ToInt32(ds.Tables[0].Rows[0]["playName"]), ds.Tables[0].Rows[0]["ExpectNum"].ToString() + "期" + "订单出票成功扣除资金", nConsumption, "Chipped");
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
            //Pbzx.BLL.Chipped_TrackNum get_tk = new Chipped_TrackNum();
            //Pbzx.BLL.PBnet_UserTable get_ut = new PBnet_UserTable();
            //Pbzx.Model.PBnet_UserTable mod_ut = new Model.PBnet_UserTable();
            ////查询数据
            //DataSet ds = get_tk.GetList("tn_orderNum=" + "'" + OrderNum + "'");
            //DataSet ds_user = Chipped_Table("PBnet_UserTable", "IntId", "UserName=" + "'" + ds.Tables[0].Rows[0]["tn_username"].ToString() + "'");
            //mod_ut = get_ut.GetModel(Convert.ToInt32(ds_user.Tables[0].Rows[0]["IntId"]));


            ////用户此单花费金额
            //decimal nEachMoney = Convert.ToDecimal(ds.Tables[0].Rows[0]["tn_money"]);

            //mod_ut.CurrentMoney = mod_ut.CurrentMoney - nEachMoney;
            //mod_ut.FrozenMoney = mod_ut.FrozenMoney - nEachMoney;
            //try
            //{
            //    if (get_ut.Update(mod_ut))
            //    {
            //        //记录本次交易
            //        //个人收支账户记录
            //        Pbzx.BLL.PlatformPublic_payments get_pmen = new Pbzx.BLL.PlatformPublic_payments();
            //        get_pmen.payments(ds.Tables[0].Rows[0]["tn_username"].ToString(), OrderNum, 1, Convert.ToInt32(ds.Tables[0].Rows[0]["tn_issue"]), Convert.ToInt32(ds.Tables[0].Rows[0]["tn_playname"]), "追号订单出票成功扣除资金", nEachMoney, "Chipped");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    //全局错误日志
            //    Pbzx.Common.ErrorLog.WriteLog(ex);
            //}
        }
        /// <summary>
        /// 扣除多期机选金额 （当前期的购买金额）
        /// </summary>
        /// <param name="Qnum"></param>
        public void DeductionDqM(string Qnum)
        {

            ////查询数据
            //DataSet ds = Chipped_Table("v_RandomNumIssue", "Rn_name,In_money,In_issue,Rn_play", "In_num=" + "'" + Qnum + "'");
            //DataSet ds_user = Chipped_Table("PBnet_UserTable", "IntId", "UserName=" + "'" + ds.Tables[0].Rows[0]["Rn_name"].ToString() + "'");
            //mod_ut = get_ut.GetModel(Convert.ToInt32(ds_user.Tables[0].Rows[0]["IntId"]));

            ////用户此单花费金额
            //decimal nEachMoney = Convert.ToDecimal(ds.Tables[0].Rows[0]["In_money"]);

            //mod_ut.CurrentMoney = mod_ut.CurrentMoney - nEachMoney;
            //mod_ut.FrozenMoney = mod_ut.FrozenMoney - nEachMoney;
            //try
            //{
            //    if (get_ut.Update(mod_ut))
            //    {
            //        //记录本次交易
            //        //个人收支账户记录
            //        Pbzx.BLL.PlatformPublic_payments get_pmen = new Pbzx.BLL.PlatformPublic_payments();
            //        get_pmen.payments(ds.Tables[0].Rows[0]["Rn_name"].ToString(), Qnum, 1, Convert.ToInt32(ds.Tables[0].Rows[0]["In_issue"]), Convert.ToInt32(ds.Tables[0].Rows[0]["Rn_play"]), "多期机选出票成功扣除资金", nEachMoney, "Chipped");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    //全局错误日志
            //    Pbzx.Common.ErrorLog.WriteLog(ex);
            //}
        }
        #endregion

    }
}