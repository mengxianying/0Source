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
        /// ��ѯ
        /// </summary>
        /// <param name="TableName">��ѯ���ݿ�������</param>
        /// <param name="CheckCondition">��ѯ������ ȫ��Ϊ*</param>
        /// <param name="strWhere">����</param>
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
        /// �ϲ���ѯ ��Ա�� ������� ����ʱ��
        /// ������: zhouwei
        /// ����ʱ��: 2011-03-02
        /// </summary>
        /// <param name="SearchStr">��ѯ�ַ��� </param>
        /// <param name="getFileds">��ȡ��</param>
        /// <param name="OrderStr">�����ֶ�</param>
        /// <param name="PageNum">��ȡ��������</param>
        /// <param name="desc">�����ǽ���</param>
        /// <param name="CurrentPage">��ǰ��ҳ��</param>
        /// <param name="Counts">���ؼ�¼������</param>
        /// <returns></returns>         

        public DataTable GuestGetBySearch(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "v_Merger", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }

        /// <summary>
        /// ���򷢲����Ӻ���ĵ���ͼ
        /// </summary>
        /// <param name="SearchStr">��ѯ�ַ��� </param>
        /// <param name="getFileds">��ȡ��</param>
        /// <param name="OrderStr">�����ֶ�</param>
        /// <param name="PageNum">��ȡ��������</param>
        /// <param name="desc">�����ǽ���</param>
        /// <param name="CurrentPage">��ǰ��ҳ��</param>
        /// <param name="Counts">���ؼ�¼������</param>
        /// <returns></returns>
        public DataTable v_participation(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "v_participation", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }


        /// <summary>
        /// �ҵĹ����¼
        /// </summary>
        /// <param name="SearchStr">��ѯ�ַ��� </param>
        /// <param name="getFileds">��ȡ��</param>
        /// <param name="OrderStr">�����ֶ�</param>
        /// <param name="PageNum">��ȡ��������</param>
        /// <param name="desc">�����ǽ���</param>
        /// <param name="CurrentPage">��ǰ��ҳ��</param>
        /// <param name="Counts">���ؼ�¼������</param>
        /// <returns></returns>
        public DataTable v_BuyRecord(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "v_BuyRecord", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }

        /// <summary>
        /// ͳ���ܹ����۵ķ���
        /// </summary>
        /// <param name="QNumber">��ˮ��</param>
        /// <param name="strwhere">��������ˮ��</param>
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
        /// ����ٷֱȽ���
        /// </summary>
        /// <returns></returns>
        public string percent(string Qnum)
        {
            //���ֵ��ܵķ���
            DataSet ds = Chipped_Table("Chipped_LaunchInfo", "Share", "QNumber=" + "'" + Qnum + "'");
            //���۵ķ���
            DataSet dsNum = Statistics("QNumber=" + "'" + Qnum + "'");
            decimal percent = Convert.ToDecimal(dsNum.Tables[0].Rows[0][0]) / Convert.ToDecimal(ds.Tables[0].Rows[0][0]) * 100;
            return percent.ToString("0.##");
        }

        /// <summary>
        /// ��ӹ�ע�ķ���
        /// </summary>
        /// <param name="AName">����ע��</param>
        /// <param name="AttentionName">��ע��</param>
        public int Attention(string AName, string AttentionName)
        {
            Chipped_Attention get_att = new Chipped_Attention();
            Pbzx.Model.Chipped_Attention ModAtt = new Pbzx.Model.Chipped_Attention();
            if (get_att.Exists(AName, AttentionName))
            {
                //�����Ѵ��ڣ���ֹ�ظ���ע��
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
                //��ѯ�����û�
                Pbzx.Model.PBnet_UserTable get_Moduser = get_userTab.GetModelName(Method.Get_UserName);
                return Convert.ToDouble(get_Moduser.CurrentMoney - get_Moduser.FrozenMoney).ToString();
            }
            return "0";
        }
        /// <summary>
        /// �����ɹ� �۳����ѵĽ��
        /// </summary>
        /// <param name="QNumber">�����ı��</param>
        /// <param name="sponsors">������</param>
        /// <param name="UserMoney">�û����ѽ��</param>
        /// <param name="each">ÿ�ݵĽ��</param>
        public string deductMoney(string QNumber, string sponsors, decimal UserMoney, decimal each)
        {
            Pbzx.BLL.PBnet_UserTable get_userTab = new Pbzx.BLL.PBnet_UserTable();
            //�۳��û����������Ľ��
            DataSet dsRefund = Chipped_Table("v_Merger", "*", "QNumber=" + "'" + QNumber + "'");
            try
            {
                for (int l = 0; l < dsRefund.Tables[0].Rows.Count; l++)
                {
                    //��ѯ�����û�
                    Pbzx.Model.PBnet_UserTable get_Moduser = get_userTab.GetModelName(dsRefund.Tables[0].Rows[l]["ChippedName"].ToString());

                    //�û��Ƿ�����
                    if (get_Moduser.UserName.ToString() == sponsors)
                    {
                        //�۳��û������ԭ�еĶ�����-���������Ľ�
                        get_Moduser.FrozenMoney = get_Moduser.FrozenMoney - UserMoney;
                        get_Moduser.CurrentMoney = get_Moduser.CurrentMoney - UserMoney;
                        //�޸�
                        if (get_userTab.Update(get_Moduser))
                        {
                            return "true";
                        }
                    }
                    else
                    {
                        //�����û�

                        //���ѵĽ��  ����ķ���*ÿ�ݵĽ��
                        decimal ChippedMoney = Convert.ToDecimal(dsRefund.Tables[0].Rows[l]["ChippedShare"]) * each;

                        get_Moduser.CurrentMoney = get_Moduser.CurrentMoney - ChippedMoney;
                        get_Moduser.FrozenMoney = get_Moduser.FrozenMoney - ChippedMoney;

                        //�޸�
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
        /// ����ʧ�ܣ� �˻��û����
        /// </summary>
        /// <param name="QNumber">�����ı��</param>
        /// <param name="sponsors">������</param>
        /// <param name="UserMoney">�û����ѽ��</param>
        /// <param name="buyUser">������û�</param>
        /// <param name="each">û�ֵĽ��</param>
        public string ReturnDeductMoney(string QNumber, string sponsors, decimal UserMoney, decimal each)
        {
            Pbzx.BLL.PBnet_UserTable get_userTab = new Pbzx.BLL.PBnet_UserTable();
            //�۳��û����������Ľ��
            DataSet dsRefund = Chipped_Table("v_Merger", "*", "QNumber=" + "'" + QNumber + "'");
            try
            {
                for (int l = 0; l < dsRefund.Tables[0].Rows.Count; l++)
                {
                    //��ѯ�����û�
                    Pbzx.Model.PBnet_UserTable get_Moduser = get_userTab.GetModelName(dsRefund.Tables[0].Rows[l]["ChippedName"].ToString());
                    //�û��Ƿ�����
                    if (get_Moduser.UserName.ToString() == sponsors)
                    {
                        //�۳��û������ԭ�еĶ�����-���������Ľ�
                        get_Moduser.FrozenMoney = get_Moduser.FrozenMoney - UserMoney;
                        //�޸�
                        if (get_userTab.Update(get_Moduser))
                        {
                            return "true";
                        }
                    }
                    else
                    {
                        //�����û�

                        //���ѵĽ��  ����ķ���*ÿ�ݵĽ��
                        decimal ChippedMoney = Convert.ToDecimal(dsRefund.Tables[0].Rows[l]["ChippedShare"]) * each;
                        get_Moduser.FrozenMoney = get_Moduser.FrozenMoney - ChippedMoney;


                        //�޸�
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





        #region ͳ���н� �����н����
        /// <summary>
        /// ͳ���н� �����н����
        /// </summary>
        /// <param name="Num">Ͷ�ݵĽ���</param>
        /// <param name="RatherNum">������</param>
        /// <param name="playName">�淨</param>
        /// <returns></returns>
        public decimal StatsWinning(string Num, string RatherNum, int playName)
        {
            //3D
            if (playName == 1)
            {
                //��λ����(����)
                string SingleNumB = RatherNum.Substring(0, 1);
                //ʮλ����(����)
                string SingleNumS = RatherNum.Substring(1, 1);
                //��λ���루���ţ�
                string SingleNumG = RatherNum.Substring(2, 1);
                int flagB = 0;
                int flagS = 0;
                int flagG = 0;
                int flagNum = 0;
                int z_flagNum = 0;
                int z_flagB = 0;
                int z_flagS = 0;
                int z_flagG = 0;
                //�������ע
                int NoteNum = Num.Split(';').Length;
                for (int i = 0; i < NoteNum; i++)
                {
                    //��ʽֱѡ ��ÿע980��
                    if (Convert.ToInt32(Num.Split(';')[i].Split('|')[0]) == 1)
                    {
                        //��λ
                        for (int k = 0; k < Num.Split(';')[i].Split('|')[1].Split(',')[0].Length; k++)
                        {
                            if (SingleNumB == Num.Split(';')[i].Split('|')[1].Split(',')[0].Substring(k, 1).ToString())
                            {
                                flagB = 1;
                            }
                        }
                        //ʮλ
                        for (int f = 0; f < Num.Split(';')[i].Split('|')[1].Split(',')[1].Length; f++)
                        {
                            if (SingleNumS == Num.Split(';')[i].Split('|')[1].Split(',')[1].Substring(f, 1).ToString())
                            {
                                flagS = 1;
                            }
                        }
                        //��λ
                        for (int g = 0; g < Num.Split(';')[i].Split('|')[1].Split(',')[2].Length; g++)
                        {
                            if (SingleNumG == Num.Split(';')[i].Split('|')[1].Split(',')[2].Substring(g, 1).ToString())
                            {
                                flagG = 1;
                            }
                        }
                        //�н�
                        if (flagB == 1 && flagS == 1 && flagG == 1)
                        {
                            //��¼�м�ע�н���
                            flagNum++;
                        }

                    }
                    //��ѡ��ʽ
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
                            //��¼���˼�ע
                            z_flagNum++;
                        }
                    }
                }
                if (flagNum > 0)
                {
                    //���ؽ��
                    return Convert.ToDecimal(980 * flagNum);
                }

            }
            //˫ɫ��
            if (playName == 3)
            {
                int Red = 0;
                int blue = 0;
                //������㸴ʽ�н�
                int RedF = 0;
                int blueF = 0;

                int note = 0;
                //�������
                string RedNum = RatherNum.Split('+')[0].ToString();
                //�������
                string blueNum = RatherNum.Split('+')[1].ToString();
                int NoteNum = Num.Split(';').Length;
                for (int i = 0; i < NoteNum; i++)
                {
                    //�ж��Ƿ�ʽ
                    if (Num.Split(';')[i].Split('+')[0].Split(',').Length > 6)
                    {
                        //��ʽ
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
                        //�ȶ�����
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
                        //��ʽ�������

                        //

                    }
                    else
                    {
                        //��ʽ �������ļ��㣩
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
                        //����
                        if (Num.Split(';')[i].Split('+')[1].ToString() == blueNum)
                        {
                            blue = 1;
                        }
                        //6�Ƚ�
                        if (Red < 3 && blue == 1)
                        {
                            //�н�5��
                            return Convert.ToDecimal(5);
                        }
                        //5�Ƚ�
                        if (Red == 4 || (Red == 3 && blue == 1))
                        {
                            //5�Ƚ�  10��
                            return Convert.ToDecimal(10);
                        }
                        //4�Ƚ�
                        if (Red == 5 || (Red == 4 && blue == 1))
                        {
                            return Convert.ToDecimal(200);
                        }
                        //3�Ƚ�
                        if (Red == 5 && blue == 1)
                        {
                            return Convert.ToDecimal(3000);
                        }
                        //2�Ƚ�
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


        #region  �����н����
        /// <summary>
        /// ��Ӹ����н���Ϣ
        /// </summary>
        /// <param name="money">�н����</param>
        /// <param name="name">�н���</param>
        /// <param name="Qnum">����</param>
        /// <param name="playName">���ֱ�ʶ</param>
        /// <returns></returns>
        public int AllotMoney(decimal money, string name, string Qnum, int playName)
        {
            Pbzx.BLL.Chipped_bounsAllost get_ba = new Pbzx.BLL.Chipped_bounsAllost();
            Pbzx.Model.Chipped_bounsAllost mod_ba = new Pbzx.Model.Chipped_bounsAllost();
            try
            {
                //��֤�����Ƿ����
                if (!get_ba.Exists(Qnum, name, playName))
                {
                    //�����ڣ�  �������
                    mod_ba.AwardNum = Qnum;
                    mod_ba.AwardName = name;
                    mod_ba.bounsAllost = money;
                    mod_ba.lotteryState = playName;
                    mod_ba.AssignState = 1;
                    mod_ba.ATime = DateTime.Now;

                    if (get_ba.Add(mod_ba) > 0)
                    {
                        //��ӳɹ�
                    }
                    else
                    {
                        //���ʧ��
                    }

                }
                else
                {
                    //���� ����
                }
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
            }
            return 0;
        }
        #endregion

        #region  �û����Ѽ�¼
        /// <summary>
        /// �û����Ѽ�¼
        /// </summary>
        /// <param name="UserName">�û���</param>
        /// <param name="acctType">���� ֧��  ��ȡ</param>
        /// <param name="PayItem">��Ŀ����</param>
        /// <param name="specificItem">�������</param>
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
        /// ��ȡ���ֵ���һ�� �ں�
        /// </summary>
        /// <param name="lotteryName">����ID</param>
        /// <returns></returns>
        public static string Period(string NvarApp_name)
        {
            publicMethod pb = new publicMethod();
            //���ݲ��ֵ�id ��ѯ��������ʹ�õ����ݿ�
            DataSet dsData = pb.Chipped_Table("PBnet_LotteryMenu", "NvarApp_name", "NvarApp_name='" + NvarApp_name + "'");

            //��ѯ���ֵ��ں�(�ں��ڿ��꽱�����)

            DataSet dsperiod = null;
            int period = 0;
            if (NvarApp_name == "FC3DData")
            {
                dsperiod = Maticsoft.DBUtility.DbHelperSQL1.Query("select issue,code from " + dsData.Tables[0].Rows[0]["NvarApp_name"].ToString() + " order by issue desc");
                //���µ��ںţ���һ�ڵ��ں� �����ں�+1=��һ�ڵ��ںţ�
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
                //���µ��ںţ���һ�ڵ��ں� �����ں�+1=��һ�ڵ��ںţ�
                period = Convert.ToInt32(dsperiod.Tables[0].Rows[0]["issue"]) + 1;
            }



            XmlDocument doc = new XmlDocument();
            //�ж������ʲô�����޶�
            doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/DownIssue.xml"));

            //�õ����ڵ�
            XmlElement root = doc.DocumentElement;
            if (root.ChildNodes.Count > 0)
            {
                string name = dsData.Tables[0].Rows[0]["NvarApp_name"].ToString();

                XmlNode ISContent = root.SelectNodes(name)[0];
                if (ISContent != null)
                {
                    //�õ�����ID
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
        /// ��ȡ���ֵ���һ�� �ں�
        /// </summary>
        /// <param name="lotteryName">����ID</param>
        /// <returns></returns>
        public static string Period(int IntID)
        {
            publicMethod pb = new publicMethod();
            //���ݲ��ֵ�id ��ѯ��������ʹ�õ����ݿ�
            DataSet dsData = pb.Chipped_Table("PBnet_LotteryMenu", "NvarApp_name", "IntID='" + IntID + "'");
            DataSet dsperiod = new DataSet();
            int period = 0;
            if (dsData.Tables[0].Rows[0]["NvarApp_name"].ToString() == "FC3DData")
            {
                dsperiod = Maticsoft.DBUtility.DbHelperSQL1.Query("select issue,code from " + dsData.Tables[0].Rows[0]["NvarApp_name"].ToString() + " order by issue desc");
                //���µ��ںţ���һ�ڵ��ں� �����ں�+1=��һ�ڵ��ںţ�
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
                //��ѯ���ֵ��ں�(�ں��ڿ��꽱�����)
                dsperiod = Maticsoft.DBUtility.DbHelperSQL1.Query("select issue from " + dsData.Tables[0].Rows[0]["NvarApp_name"].ToString() + " order by issue desc");

                //���µ��ںţ���һ�ڵ��ں� �����ں�+1=��һ�ڵ��ںţ�
                period = Convert.ToInt32(dsperiod.Tables[0].Rows[0]["issue"]) + 1;
            }
            XmlDocument doc = new XmlDocument();
            //�ж������ʲô�����޶�
            doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/DownIssue.xml"));

            //�õ����ڵ�
            XmlElement root = doc.DocumentElement;
            if (root.ChildNodes.Count > 0)
            {
                string name = dsData.Tables[0].Rows[0]["NvarApp_name"].ToString();

                XmlNode ISContent = root.SelectNodes(name)[0];
                if (ISContent != null)
                {
                    //�õ�����ID
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
        /// ���ؿ�������
        /// </summary>
        /// <param name="dataName">��Ӧ�Ĳ������ݿ��</param>
        /// <param name="playName">����Id</param>
        /// <param name="issue">�ں�</param>
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
                //���ֲ�
                ds = Maticsoft.DBUtility.DbHelperSQL1.Query("select code,tcode from " + dataName + " where issue=" + issue);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    //���������
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
                //˫ɫ��
                ds = Maticsoft.DBUtility.DbHelperSQL1.Query("select redcode,bluecode from " + dataName + " where issue=" + issue);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    //���������
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
                //����5
                ds = Maticsoft.DBUtility.DbHelperSQL1.Query("select code5 from " + dataName + " where issue=" + issue);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0][0].ToString();
                }
            }
            if (playName == 9999)
            {
                //����3
                ds = Maticsoft.DBUtility.DbHelperSQL1.Query("select code3 from " + dataName + " where issue=" + issue);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0][0].ToString();
                }
            }
            if (playName == 5)
            {
                //���ǲ�
                ds = Maticsoft.DBUtility.DbHelperSQL1.Query("select code from " + dataName + " where issue=" + issue);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0][0].ToString();
                }
            }
            if (playName == 6)
            {
                //����͸
                ds = Maticsoft.DBUtility.DbHelperSQL1.Query("select code,code2 from " + dataName + " where issue=" + issue);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    //���������
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

        //�Ͳ�Ʊ�����̽�����������

        /// <summary>
        /// ����xml
        /// </summary>
        public string Receive(string xml)
        {

            //����һ��XMLDoc�ĵ�����LOAD����xml�ַ���
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            XmlNode node = doc.SelectSingleNode("./ActionResult");
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (XmlNode item in node.ChildNodes)
                sb.Append(item.Name + "|" + item.InnerText + ",");

            return sb.ToString();


        }

        /// <summary>
        /// ҵ�����
        /// </summary>
        /// <param name="wAgent">�����̱��</param>
        /// <param name="wAction">����������</param>
        /// <param name="wMsgID">������Ϣ���</param>
        /// <param name="wParam">ҵ�����</param>
        /// <param name="wSign">�ͻ���ǩ����MD5���ܣ� ע�⣺���ʹ��GB2312������ַ���������Կ���㡣���봮���</param>
        /// <returns></returns>
        public string PostStr(int wAgent, int wAction, string wMsgID, string wParam)
        {

            //��Ҫ���ܵ� �ַ���
            string EncMD5 = wAgent.ToString() + wAction + wMsgID + wParam + "a8b8c8d8e8f8g8h8";

            //ǩ�� 
            string nwSign = Input.MD5(EncMD5, false);

            string postStr = "wAgent=" + wAgent + "&wAction=" + wAction + "&wMsgID=" + wMsgID + "&wSign=" + nwSign + "&wParam=" + wParam;

            return postStr;
        }

        /// <summary>
        /// ���ͽ������� �����շ���ֵ
        /// </summary>
        /// <param name="prar">ҵ���������</param>
        public string PostUrl(string getStr)
        {
            string url = "http://t.zc310.net:8089/bin/LotSaleHttp.dll";

            string str = GetPage(url, getStr);

            return str;

        }
        /// <summary>
        /// ��post ����gb2312�ķ�ʽ ����http ����
        /// </summary>
        /// <param name="posturl">�ύ��·��</param>
        /// <param name="postData">�ύ�Ĳ���</param>
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
            // ׼������...
            try
            {
                // ���ò���
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
                //�������󲢻�ȡ��Ӧ��Ӧ����
                response = request.GetResponse() as HttpWebResponse;
                //ֱ��request.GetResponse()����ſ�ʼ��Ŀ����ҳ����Post����
                instream = response.GetResponseStream();
                sr = new StreamReader(instream, encoding);
                //���ؽ����ҳ��html������
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
        /// ����Ͷע ������������ַ���  �������
        /// </summary>
        /// <param name="OrderID">Ͷע�����ţ��̼��Լ����ɣ�ע��ֻ��ʹ�����ֺ�Ӣ����ĸ</param>
        /// <param name="LotID">������Ͷע�Ĳ�Ʊ���</param>
        /// <param name="LotIssue">Ͷע���ں�</param>
        /// <param name="LotMoney">Ͷע�ܽ������౶���ڵ��ܽ�</param>
        /// <param name="LotCode">Ͷע����</param>
        /// <param name="LotMulti">Ͷע������������Χ����Ϊ1��99</param>
        /// <param name="Attach">������Ϣ ����ʹ������</param>
        /// <param name="OneMoney">��עͶע���  ��͸׷��ͶעΪ3Ԫ</param>
        /// <returns></returns>
        public string PostBetting(string OrderID, int LotID, int LotIssue, int LotMoney, string LotCode, int LotMulti, string Attach, int OneMoney)
        {
            //ҵ�����

            string prar = "OrderID=" + OrderID + "_LotID=" + LotID + "_LotIssue=" + LotIssue + "_LotMoney=" + LotMoney + "_LotMulti=" + LotMulti + "_OneMoney=" + OneMoney + "_LotCode=" + LotCode + "_Attach=" + Attach;
            return prar;
        }

        /// <summary>
        /// Ͷע
        /// </summary>
        /// <param name="prar">ҵ�����</param>
        /// <returns></returns>
        public string bett(string prar)
        {
            
            //�������
            string getStr = PostStr(3821, 101, "zzzzzzz", prar);

            string str = PostUrl(getStr);

            //���շ����ַ���
            string xmlStr = Receive(str);

            return xmlStr;
        }

        /// <summary>
        /// ҵ�����
        /// </summary>
        /// <param name="prar">ҵ�����</param>
        /// <param name="code">ҵ�����</param>
        /// <returns></returns>
        public string bett(string prar,int code)
        {

            //�������
            string getStr = PostStr(3821, code, "zzzzzzz", prar);

            string str = PostUrl(getStr);

            //���շ����ַ���
            string xmlStr = Receive(str);

            return xmlStr;
        }

        //�Ͳ�Ʊ�����̽�����������


        /// <summary>
        /// �۳��û����򻨷ѽ�� �����������
        /// </summary>
        /// <param name="orderNum">������</param>
        public void DeductionMonery(string orderNum)
        {
            Pbzx.BLL.Chipped_LaunchInfoManage get_lif = new Chipped_LaunchInfoManage();
            Pbzx.BLL.PBnet_UserTable get_utab = new Pbzx.BLL.PBnet_UserTable();
            Pbzx.Model.PBnet_UserTable mod_utab = new Pbzx.Model.PBnet_UserTable();

            //��ѯ����
            DataSet ds = get_lif.GetList("QNumber=" + "'" + orderNum + "'");

            //�������
            if (Convert.ToInt32(ds.Tables[0].Rows[0]["Purchasing"]) == 1)
            {
                //����
                DataSet ds_user = Chipped_Table("PBnet_UserTable", "Id", "UserName=" + "'" + ds.Tables[0].Rows[0]["UserName"] + "'");
                mod_utab = get_utab.GetModel(Convert.ToInt32(ds_user.Tables[0].Rows[0]["Id"]));
                mod_utab.CurrentMoney = mod_utab.CurrentMoney - Convert.ToDecimal(ds.Tables[0].Rows[0]["AtotalMoney"]);
                mod_utab.FrozenMoney = mod_utab.FrozenMoney - Convert.ToDecimal(ds.Tables[0].Rows[0]["AtotalMoney"]);
                try
                {
                    if (get_utab.Update(mod_utab))
                    {
                        //��¼���ν���
                        //������֧�˻���¼
                        Pbzx.BLL.PlatformPublic_payments get_pmen = new Pbzx.BLL.PlatformPublic_payments();
                        get_pmen.payments(ds.Tables[0].Rows[0]["UserName"].ToString(),orderNum, 1, Convert.ToInt32(ds.Tables[0].Rows[0]["ExpectNum"]), Convert.ToInt32(ds.Tables[0].Rows[0]["playName"]),ds.Tables[0].Rows[0]["ExpectNum"].ToString()+"��"+"������Ʊ�ɹ��۳��ʽ�", Convert.ToInt32(ds.Tables[0].Rows[0]["AtotalMoney"]), "Chipped");
                    }
                }
                catch (Exception ex)
                {
                    //ȫ�ִ�����־
                    Pbzx.Common.ErrorLog.WriteLog(ex);
                }
            }
            if (Convert.ToInt32(ds.Tables[0].Rows[0]["Purchasing"]) == 2)
            {
                //��ѯ���к����û�
                DataSet ds_buy = Chipped_Table("v_Merger", "*", "QNumber=" + "'" + orderNum + "'");

                //�������ݵļ۸�
                decimal nEachMoney = Convert.ToDecimal(ds.Tables[0].Rows[0]["AtotalMoney"]) / Convert.ToInt32(ds.Tables[0].Rows[0]["Share"]);

                //���� ��ѯû�������û������ѵĽ��
                for (int i = 0; i < ds_buy.Tables[0].Rows.Count; i++)
                {
                    //�����ѵĽ��
                    decimal nConsumption = nEachMoney * Convert.ToInt32(ds_buy.Tables[0].Rows[i]["ChippedShare"]);

                    DataSet ds_user = Chipped_Table("PBnet_UserTable", "Id", "UserName=" + "'" + ds_buy.Tables[0].Rows[i]["ChippedName"] + "'");
                    mod_utab = get_utab.GetModel(Convert.ToInt32(ds_user.Tables[0].Rows[0]["Id"]));
                    mod_utab.CurrentMoney = mod_utab.CurrentMoney - nConsumption;
                    mod_utab.FrozenMoney = mod_utab.FrozenMoney - nConsumption;
                    try
                    {
                        if (get_utab.Update(mod_utab))
                        {
                            //��¼���ν���
                            //������֧�˻���¼
                            Pbzx.BLL.PlatformPublic_payments get_pmen = new Pbzx.BLL.PlatformPublic_payments();
                            get_pmen.payments(ds_buy.Tables[0].Rows[i]["ChippedName"].ToString(),orderNum, 1, Convert.ToInt32(ds.Tables[0].Rows[0]["ExpectNum"]), Convert.ToInt32(ds.Tables[0].Rows[0]["playName"]), ds.Tables[0].Rows[0]["ExpectNum"].ToString() + "��" + "������Ʊ�ɹ��۳��ʽ�", nConsumption, "Chipped");
                        }
                    }
                    catch (Exception ex)
                    {
                        //ȫ�ִ�����־
                        Pbzx.Common.ErrorLog.WriteLog(ex);
                    }
                }
            }

        }

        /// <summary>
        /// �۳��û�׷�����ý��  ����׷�Ŷ���
        /// </summary>
        /// <param name="OrderNum"></param>
        public void DedMoneyTackNum(string OrderNum)
        {
            Pbzx.BLL.Chipped_TrackNum get_tk = new Chipped_TrackNum();
            Pbzx.BLL.PBnet_UserTable get_ut = new PBnet_UserTable();
            Pbzx.Model.PBnet_UserTable mod_ut = new Model.PBnet_UserTable();
            //��ѯ����
            DataSet ds = get_tk.GetList("tn_orderNum=" + "'" + OrderNum + "'");
            DataSet ds_user = Chipped_Table("PBnet_UserTable", "IntId", "UserName=" + "'" + ds.Tables[0].Rows[0]["tn_username"].ToString() + "'");
            mod_ut = get_ut.GetModel(Convert.ToInt32(ds_user.Tables[0].Rows[0]["IntId"]));

            //�û��˵����ѽ��
            decimal nEachMoney = Convert.ToDecimal(ds.Tables[0].Rows[0]["tn_money"]);

            mod_ut.CurrentMoney = mod_ut.CurrentMoney - nEachMoney;
            mod_ut.FrozenMoney = mod_ut.FrozenMoney - nEachMoney;
            try
            {
                if (get_ut.Update(mod_ut))
                {
                    //��¼���ν���
                    //������֧�˻���¼
                    Pbzx.BLL.PlatformPublic_payments get_pmen = new Pbzx.BLL.PlatformPublic_payments();
                    get_pmen.payments(ds.Tables[0].Rows[0]["tn_username"].ToString(),OrderNum, 1, Convert.ToInt32(ds.Tables[0].Rows[0]["tn_issue"]), Convert.ToInt32(ds.Tables[0].Rows[0]["tn_playname"]), "׷�Ŷ�����Ʊ�ɹ��۳��ʽ�", nEachMoney, "Chipped");
                }
            }
            catch (Exception ex)
            {
                //ȫ�ִ�����־
                Pbzx.Common.ErrorLog.WriteLog(ex);
            }
        }
        /// <summary>
        /// �۳����ڻ�ѡ��� ����ǰ�ڵĹ����
        /// </summary>
        /// <param name="Qnum"></param>
        public void DeductionDqM(string Qnum)
        {
            Pbzx.BLL.PBnet_UserTable get_ut = new PBnet_UserTable();
            Pbzx.Model.PBnet_UserTable mod_ut = new Model.PBnet_UserTable();
            //��ѯ����
            DataSet ds = Chipped_Table("v_RandomNumIssue", "Rn_name,In_money,In_issue,Rn_play", "In_num=" + "'" + Qnum + "'");
            DataSet ds_user = Chipped_Table("PBnet_UserTable", "IntId", "UserName=" + "'" + ds.Tables[0].Rows[0]["Rn_name"].ToString() + "'");
            mod_ut = get_ut.GetModel(Convert.ToInt32(ds_user.Tables[0].Rows[0]["IntId"]));

            //�û��˵����ѽ��
            decimal nEachMoney = Convert.ToDecimal(ds.Tables[0].Rows[0]["In_money"]);

            mod_ut.CurrentMoney = mod_ut.CurrentMoney - nEachMoney;
            mod_ut.FrozenMoney = mod_ut.FrozenMoney - nEachMoney;
            try
            {
                if (get_ut.Update(mod_ut))
                {
                    //��¼���ν���
                    //������֧�˻���¼
                    Pbzx.BLL.PlatformPublic_payments get_pmen = new Pbzx.BLL.PlatformPublic_payments();
                    get_pmen.payments(ds.Tables[0].Rows[0]["Rn_name"].ToString(), Qnum, 1, Convert.ToInt32(ds.Tables[0].Rows[0]["In_issue"]), Convert.ToInt32(ds.Tables[0].Rows[0]["Rn_play"]), "���ڻ�ѡ��Ʊ�ɹ��۳��ʽ�", nEachMoney, "Chipped");
                }
            }
            catch (Exception ex)
            {
                //ȫ�ִ�����־
                Pbzx.Common.ErrorLog.WriteLog(ex);
            }
        }



        /// <summary>
        /// ���ֶԱȱ��
        /// </summary>
        /// <param name="playName">���ֱ��</param>
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
                //���ֲ�
                return 23528;
            }
            if (playName == 3)
            {
                //˫ɫ��
                return 51;
            }
            if (playName == 9999)
            {
                //����3
                return 33;
            }
            if (playName == 4)
            {
                //����5
                return 35;
            }
            if (playName == 5)
            {
                //���ǲ�
                return 10022;
            }
            if (playName == 6)
            {
                //����͸
                return 23529;
            }
            return 0;
        }
        /// <summary>
        /// ��ѯ��������
        /// </summary>
        /// <param name="LotID">��Ʊ���</param>
        /// <param name="LotIssue">�ں�</param>
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
