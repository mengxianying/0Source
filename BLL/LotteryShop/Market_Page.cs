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


namespace Pbzx.BLL
{
    public class Market_Page
    {
        private readonly IMarket_BuyInfo dal = DataAccess.CreateIMarket_BuyInfo();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("v_NumGut", "appendid");

        /// <summary>
        /// �󶨲�Ʊ�����̼�������Ϣ
        /// </summary>
        /// <param name="count">��ʾ�ĸ���</param>
        /// <param name="strWhere">sql����</param>
        /// <returns>��ΰ10-21</returns>
        public DataTable Mark_GetUserGueue(int count, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Top " + count + " * ");
            strSql.Append(" From PBnet_UserTable ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return dal.Query(strSql.ToString());
        }

        /// <summary>
        /// �󶨲�Ʊ������ҳ��Ŀ�б�
        /// ������: zhouwei
        /// ����ʱ��: 2010-10-22
        /// </summary>
        /// <param name="count">��ʾ����</param>
        /// <param name="steWhere">sql����</param>
        /// <returns></returns>
        public DataSet Market_GetItme(int count, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Top " + count + " * ");
            strSql.Append(" From v_appendItem");
            if (strWhere.Trim() != "")
            {
                //strSql.Append(" where " + strWhere);
                strSql.Append(strWhere);
            }

            return dal.QuerySet(strSql.ToString());
        }
        /// <summary>
        ///  ����Market_GetItme����
        /// ������: zhouwei
        /// ����ʱ��: 2010-11-3
        /// </summary>
        /// <param name="strWhere">sql����</param>
        /// <returns></returns>
        public DataSet Market_GetItme(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *");
            strSql.Append(" From v_appendItem");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);

            }

            return dal.QuerySet(strSql.ToString());
        }
        /// <summary>
        /// ��ѯv_appendItem��ͼ
        /// </summary>
        /// <param name="strBy">���ص�����ֵ</param>
        /// <param name="strWhere">��ѯ����</param>
        /// <returns></returns>
        public DataSet Market_GetItme(string strBy, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select "+strBy);
            strSql.Append(" From v_appendItem");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);

            }

            return dal.QuerySet(strSql.ToString());
        }

        /// <summary>
        /// �����ںŸ���������Ϣ
        /// </summary>
        /// <param name="strBy">���ص�����ֵ</param>
        /// <param name="strWhere">��ѯ����</param>
        /// <returns></returns>
        public DataSet Market_GetNum(string strBy, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + strBy);
            strSql.Append(" From v_NumGut");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);

            }

            return dal.QuerySet(strSql.ToString());
        }

        /// <summary>
        /// ��ѯ
        /// </summary>
        /// <param name="TableName">��ѯ���ݿ�������</param>
        /// <param name="CheckCondition">��ѯ������ ȫ��Ϊ*</param>
        /// <param name="strWhere">����</param>
        /// <returns></returns>
        public DataSet Market_Table(string TableName, string CheckCondition, string strWhere)
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
        /// ���ݲ�ѯ�ַ�����ȡ��ҳ����
        /// ������: zhouwei
        /// ����ʱ��: 2010-12-09
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
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "v_NumGut", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }
        /// <summary>
        /// ������Ŀ����֤
        /// </summary>
        /// <param name="name">�����˵��û���</param>
        /// <param name="item">�������Ŀ������</param>
        /// 
        public string BuyItem(string name, string item)
        {
            Pbzx.BLL.Market_BuyInfo buy = new Pbzx.BLL.Market_BuyInfo();

            //�ж��Ƿ������Ŀ
            if (buy.Exists(name, Convert.ToInt32(item)) == true)
            {
                return "0";

            }
            else
            {
                Pbzx.BLL.Market_appendItemManager app = new Pbzx.BLL.Market_appendItemManager();
                Pbzx.Model.Market_appendItem Modapp = new Pbzx.Model.Market_appendItem();
                Modapp = app.GetModel(Convert.ToInt32(item));

                //Page.RegisterStartupScript("upscript", "<script>window.open('Market_buy.aspx?id='+ '" + Input.Encrypt(Modapp.TypeID.ToString()) + "'+ '&price='+ '" + Input.Encrypt(Modapp.Price.ToString()) + "'+ '&appendId='+'" + Input.Encrypt(item.ToString()) + "')</script>");
                //return "Market_buy.aspx?id="+  Input.Encrypt(Modapp.TypeID.ToString())  + "&price="+ Input.Encrypt(Modapp.Price.ToString()) + "&appendId="+ Input.Encrypt(item.ToString());
                return "buy.aspx?appendId=" + Input.Encrypt(item.ToString());
            }

        }
        /// <summary>
        /// �ղ���Ŀ
        /// </summary>
        /// 
        public string CollectionItem(string name, string item)
        {
            Pbzx.BLL.Market_CollASAtten get_collasAtten = new Pbzx.BLL.Market_CollASAtten();
            //�ж���û���ղع�����Ŀ
            if (get_collasAtten.Exists(name, item, 1, 1)==true)
            {
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "alert('���Ѿ��ղ��˴���Ŀ')", true);
                return "���Ѿ��ղ��˴���Ŀ����";
            }
            else
            {
                Pbzx.Model.Market_CollASAtten get_mod = new Pbzx.Model.Market_CollASAtten();
                get_mod.Uname = name;
                get_mod.appName = item;
                get_mod.statc = 1;
                get_mod.mark = 1;
                get_mod.appTime = Convert.ToDateTime(string.Format("{0:T}", DateTime.Today.Date));
                if (get_collasAtten.Add(get_mod) > 0)
                {
                    //Page.RegisterStartupScript("upscripe", "<script>alert('�ղسɹ�')</script>");
                    return "�ղسɹ�";
                }
            }
            return "�ղ�ʧ��";
        }
        /// <summary>
        /// ��ע��Ŀ
        /// </summary>
        /// 
        public string AttentionItem(string name, string item)
        {
            Pbzx.BLL.Market_CollASAtten get_collasAtten = new Pbzx.BLL.Market_CollASAtten();
            if (get_collasAtten.Exists(name, item, 1, 2))
            {
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "alert('���Ѿ���ע�Ĵ���Ŀ')", true);
                return "���Ѿ���ע�˴���Ŀ����";
            }
            else
            {
                Pbzx.Model.Market_CollASAtten get_mod = new Pbzx.Model.Market_CollASAtten();
                get_mod.Uname = name;
                get_mod.appName = item;
                get_mod.statc = 1;
                get_mod.mark = 2;
                get_mod.appTime = Convert.ToDateTime(string.Format("{0:T}", DateTime.Today.Date));
                if (get_collasAtten.Add(get_mod) > 0)
                {
                    //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "alert('�ɹ���ע�˴���Ŀ')", true);
                    return "�ɹ���ע����Ŀ����";
                }
            }
            return "��עʧ��";
        }

        /// <summary>
        /// ͳ���̻�©��ʵ���ں�
        /// </summary>
        /// <param name="itemID">��ĿID</param>
        /// <param name="UserName">��Ա��</param>
        /// <param name="ExpectNum">���µ��ں�</param>
        /// <returns></returns>
        public string CancelIndentNum(int itemID, string UserName, string ExpectNum)
        {
            string str = "";
            int sign = 0;
            //��¼�ںż�ļ��
            int count = 0;
            Market_Page get_page = new Market_Page();
            DataSet dsNum = get_page.Market_GetNum("NvarName,ExpectNum", "appendId=" + itemID + " and Userid=" + "'" + UserName + "'" + " order by ExpectNum desc");

            if (dsNum.Tables[0].Rows[0]["ExpectNum"].ToString() == ExpectNum)
            {
                for (int i = 0; i < dsNum.Tables[0].Rows.Count - 1; i++)
                {
                    //�ǲ����������ں�
                    if (Convert.ToInt32(dsNum.Tables[0].Rows[i]["ExpectNum"]) - 1 == Convert.ToInt32(dsNum.Tables[0].Rows[i + 1]["ExpectNum"]))
                    {
                        //�ں�����������¼
                    }
                    else
                    {
                        if (Convert.ToInt32(dsNum.Tables[0].Rows[i]["ExpectNum"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i+1]["ExpectNum"]) > 2)
                        {
                            if (Convert.ToInt32(dsNum.Tables[0].Rows[i]["ExpectNum"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i+1]["ExpectNum"]) > 365)
                            {
                                //����ǲ�������ĵ�һ��
                                if (Convert.ToInt32(dsNum.Tables[0].Rows[i]["ExpectNum"]) == Convert.ToInt32(DateTime.Now.Year + "001"))
                                {
                                    //��ѯ��ȥ��һ������һ�� ���磺2010-12-31����һ�ڵ��ں�
                                    if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "3D")
                                    {
                                        //��ѯ��һ���12��31�ŵ���һ��
                                        DataSet ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from FC3DData where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");
                                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                                        {
                                            //������ĵ�һ�� 001��
                                            count = Convert.ToInt32(ds.Tables[0].Rows[0]["issue"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i + 1]["ExpectNum"]);
                                        }
                                    }
                                    if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "˫ɫ��")
                                    {
                                        //��ѯ��һ���12��31�ŵ���һ��
                                        DataSet ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from FCSSData where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");
                                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                                        {
                                            //������ĵ�һ�� 001��
                                            count = Convert.ToInt32(ds.Tables[0].Rows[0]["issue"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i + 1]["ExpectNum"]);
                                        }
                                    }
                                    if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "���ǲ�")
                                    {
                                        //��ѯ��һ���12��31�ŵ���һ��
                                        DataSet ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from TC7XCData where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");
                                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                                        {
                                            //������ĵ�һ�� 001��
                                            count = Convert.ToInt32(ds.Tables[0].Rows[0]["issue"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i + 1]["ExpectNum"]);
                                        }
                                    }
                                    if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "����͸")
                                    {
                                        //��ѯ��һ���12��31�ŵ���һ��
                                        DataSet ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from TCDLTData where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");
                                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                                        {
                                            //������ĵ�һ�� 001��
                                            count = Convert.ToInt32(ds.Tables[0].Rows[0]["issue"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i + 1]["ExpectNum"]);
                                        }
                                    }
                                    if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "���ֲ�")
                                    {
                                        //��ѯ��һ���12��31�ŵ���һ��
                                        DataSet ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from FC7LC where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");
                                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                                        {
                                            //������ĵ�һ�� 001��
                                            count = Convert.ToInt32(ds.Tables[0].Rows[0]["issue"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i + 1]["ExpectNum"]);
                                        }
                                    }
                                    if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "����5")
                                    {
                                        //��ѯ��һ���12��31�ŵ���һ��
                                        DataSet ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from TCPL35Data where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");
                                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                                        {
                                            //������ĵ�һ�� 001��
                                            count = Convert.ToInt32(ds.Tables[0].Rows[0]["issue"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i + 1]["ExpectNum"]);
                                        }
                                    }
                                    if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "22ѡ5")
                                    {
                                        //��ѯ��һ���12��31�ŵ���һ��
                                        DataSet ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from TC22X5Data where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");
                                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                                        {
                                            //������ĵ�һ�� 001��
                                            count = Convert.ToInt32(ds.Tables[0].Rows[0]["issue"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i + 1]["ExpectNum"]);
                                        }
                                    }
                                }
                                else
                                {
                                    //��������ĵ�һ��
                                    count = Convert.ToInt32(dsNum.Tables[0].Rows[i]["ExpectNum"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i+1]["ExpectNum"]);
                                }
                            }
                            else
                            {
                                count = Convert.ToInt32(dsNum.Tables[0].Rows[i]["ExpectNum"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i+1]["ExpectNum"]);
                            }
                            for (int j = 1; j < count; j++)
                            {
                                if (sign == Convert.ToInt32(dsNum.Tables[0].Rows[i+1]["ExpectNum"]))
                                {
                                    break;
                                }
                                if (Convert.ToInt32(dsNum.Tables[0].Rows[i]["ExpectNum"]) - j == Convert.ToInt32(DateTime.Now.Year + "000"))
                                {
                                    DataSet ds = new DataSet();
                                    //��ѯ��ȥ��һ������һ�� ���磺2010-12-31����һ�ڵ��ں�
                                    if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "3D")
                                    {
                                        //��ѯ��һ������һ�ڡ�12��31�ŵ���һ�ڡ�
                                        ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from FC3DData where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");

                                    }
                                    if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "˫ɫ��")
                                    {
                                        //��ѯ��һ���12��31�ŵ���һ��
                                        ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from FCSSData where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");

                                    }
                                    if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "���ǲ�")
                                    {
                                        //��ѯ��һ���12��31�ŵ���һ��
                                        ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from TC7XCData where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");

                                    }
                                    if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "����͸")
                                    {
                                        //��ѯ��һ���12��31�ŵ���һ��
                                        ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from TCDLTData where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");

                                    }
                                    if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "���ֲ�")
                                    {
                                        //��ѯ��һ���12��31�ŵ���һ��
                                        ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from FC3DData where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");

                                    }
                                    if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "����5")
                                    {
                                        //��ѯ��һ���12��31�ŵ���һ��
                                        ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from TCPL35Data where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");

                                    }
                                    if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "22ѡ5")
                                    {
                                        //��ѯ��һ���12��31�ŵ���һ��
                                        ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from TC22X5Data where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");

                                    }
                                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                                    {
                                        for (int k = 0; k < Convert.ToInt32(ds.Tables[0].Rows[0]["issue"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i + 1]["ExpectNum"]); k++)
                                        {
                                            if (Convert.ToInt32(ds.Tables[0].Rows[0]["issue"]) - k == Convert.ToInt32(dsNum.Tables[0].Rows[i + 1]["ExpectNum"]))
                                            {

                                                break;
                                            }
                                            else
                                            {
                                                str += Convert.ToInt32(ds.Tables[0].Rows[0]["issue"]) - k + "|";
                                            }

                                        }
                                        sign = Convert.ToInt32(ds.Tables[0].Rows[0]["issue"]) - (Convert.ToInt32(ds.Tables[0].Rows[0]["issue"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i + 1]["ExpectNum"]));
                                    }
                                }
                                else
                                {
                                    str += Convert.ToInt32(dsNum.Tables[0].Rows[i]["ExpectNum"]) - j + "|";
                                }
                            }
                        }
                        else
                        {
                            str += Convert.ToInt32(dsNum.Tables[0].Rows[i]["ExpectNum"]) - 1 + "|";
                        }
                    }
                }
                return str;
            }
            else
            {
                if (Convert.ToInt32(ExpectNum) > Convert.ToInt32(dsNum.Tables[0].Rows[0]["ExpectNum"]))
                {
                    for (int l = 0; l < Convert.ToInt32(ExpectNum) - Convert.ToInt32(dsNum.Tables[0].Rows[0]["ExpectNum"]); l++)
                    {
                        str += Convert.ToInt32(ExpectNum) - l + "|";
                    }
                    for (int i = 0; i < dsNum.Tables[0].Rows.Count - 1; i++)
                    {
                        //�ǲ����������ں�
                        if (Convert.ToInt32(dsNum.Tables[0].Rows[i]["ExpectNum"]) - 1 == Convert.ToInt32(dsNum.Tables[0].Rows[i+1]["ExpectNum"]))
                        {
                            //�ں�����������¼
                        }
                        else
                        {
                            if (Convert.ToInt32(dsNum.Tables[0].Rows[i]["ExpectNum"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i+1]["ExpectNum"]) > 2)
                            {
                                if (Convert.ToInt32(dsNum.Tables[0].Rows[i]["ExpectNum"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i+1]["ExpectNum"]) > 365)
                                {
                                    //����ǲ�������ĵ�һ��
                                    if (Convert.ToInt32(dsNum.Tables[0].Rows[i]["ExpectNum"]) == Convert.ToInt32(DateTime.Now.Year + "001"))
                                    {
                                        //��ѯ��ȥ��һ������һ�� ���磺2010-12-31����һ�ڵ��ں�
                                        if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "3D")
                                        {
                                            //��ѯ��һ���12��31�ŵ���һ��
                                            DataSet ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from FC3DData where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");
                                            if (ds != null && ds.Tables[0].Rows.Count > 0)
                                            {
                                                //������ĵ�һ�� 001��
                                                count = Convert.ToInt32(ds.Tables[0].Rows[0]["issue"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i + 1]["ExpectNum"]);
                                            }

                                        }
                                        if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "˫ɫ��")
                                        {
                                            //��ѯ��һ���12��31�ŵ���һ��
                                            DataSet ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from FCSSData where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");
                                            if (ds != null && ds.Tables[0].Rows.Count > 0)
                                            {
                                                //������ĵ�һ�� 001��
                                                count = Convert.ToInt32(ds.Tables[0].Rows[0]["issue"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i + 1]["ExpectNum"]);
                                            }
                                        }
                                        if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "���ǲ�")
                                        {
                                            //��ѯ��һ���12��31�ŵ���һ��
                                            DataSet ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from TC7XCData where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");
                                            if (ds != null && ds.Tables[0].Rows.Count > 0)
                                            {
                                                //������ĵ�һ�� 001��
                                                count = Convert.ToInt32(ds.Tables[0].Rows[0]["issue"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i + 1]["ExpectNum"]);
                                            }
                                        }
                                        if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "����͸")
                                        {
                                            //��ѯ��һ���12��31�ŵ���һ��
                                            DataSet ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from TCDLTData where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");
                                            if (ds != null && ds.Tables[0].Rows.Count > 0)
                                            {
                                                //������ĵ�һ�� 001��
                                                count = Convert.ToInt32(ds.Tables[0].Rows[0]["issue"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i + 1]["ExpectNum"]);
                                            }
                                        }
                                        if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "���ֲ�")
                                        {
                                            //��ѯ��һ���12��31�ŵ���һ��
                                            DataSet ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from FC7LC where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");
                                            if (ds != null && ds.Tables[0].Rows.Count > 0)
                                            {
                                                //������ĵ�һ�� 001��
                                                count = Convert.ToInt32(ds.Tables[0].Rows[0]["issue"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i + 1]["ExpectNum"]);
                                            }
                                        }
                                        if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "����5")
                                        {
                                            //��ѯ��һ���12��31�ŵ���һ��
                                            DataSet ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from TCPL35Data where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");
                                            if (ds != null && ds.Tables[0].Rows.Count > 0)
                                            {
                                                //������ĵ�һ�� 001��
                                                count = Convert.ToInt32(ds.Tables[0].Rows[0]["issue"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i + 1]["ExpectNum"]);
                                            }
                                        }
                                        if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "22ѡ5")
                                        {
                                            //��ѯ��һ���12��31�ŵ���һ��
                                            DataSet ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from TC22X5Data where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");
                                            if (ds != null && ds.Tables[0].Rows.Count > 0)
                                            {
                                                //������ĵ�һ�� 001��
                                                count = Convert.ToInt32(ds.Tables[0].Rows[0]["issue"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i + 1]["ExpectNum"]);
                                            }
                                        }
                                       
                                    }
                                    else
                                    {
                                        //��������ĵ�һ��
                                        count = Convert.ToInt32(dsNum.Tables[0].Rows[i]["ExpectNum"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i + 1]["ExpectNum"]);
                                    }
                                }
                                else
                                {
                                    count = Convert.ToInt32(dsNum.Tables[0].Rows[i]["ExpectNum"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i + 1]["ExpectNum"]);
                                }
                                for (int j = 1; j < count; j++)
                                {
                                    if (sign == Convert.ToInt32(dsNum.Tables[0].Rows[i + 1]["ExpectNum"]))
                                    {
                                        break;
                                    }
                                    if (Convert.ToInt32(dsNum.Tables[0].Rows[i]["ExpectNum"]) - j == Convert.ToInt32(DateTime.Now.Year + "000"))
                                    {
                                        DataSet ds = new DataSet();
                                        //��ѯ��ȥ��һ������һ�� ���磺2010-12-31����һ�ڵ��ں�
                                        if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "3D")
                                        {
                                            //��ѯ��һ���12��31�ŵ���һ��
                                            ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from FC3DData where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");

                                        }
                                        if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "˫ɫ��")
                                        {
                                            //��ѯ��һ���12��31�ŵ���һ��
                                            ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from FCSSData where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");

                                        }
                                        if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "���ǲ�")
                                        {
                                            //��ѯ��һ���12��31�ŵ���һ��
                                            ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from TC7XCData where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");

                                        }
                                        if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "����͸")
                                        {
                                            //��ѯ��һ���12��31�ŵ���һ��
                                            ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from TCDLTData where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");

                                        }
                                        if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "���ֲ�")
                                        {
                                            //��ѯ��һ���12��31�ŵ���һ��
                                            ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from FC7LC where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");
 
                                        }
                                        if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "����5")
                                        {
                                            //��ѯ��һ���12��31�ŵ���һ��
                                            ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from TCPL35Data where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");

                                        }
                                        if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "22ѡ5")
                                        {
                                            //��ѯ��һ���12��31�ŵ���һ��
                                            ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from TC22X5Data where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");

                                        }
                                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                                        {
                                            for (int k = 0; k < Convert.ToInt32(ds.Tables[0].Rows[0]["issue"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i + 1]["ExpectNum"]); k++)
                                            {
                                                if (Convert.ToInt32(ds.Tables[0].Rows[0]["issue"]) - k == Convert.ToInt32(dsNum.Tables[0].Rows[i + 1]["ExpectNum"]))
                                                {

                                                    break;
                                                }
                                                else
                                                {
                                                    str += Convert.ToInt32(ds.Tables[0].Rows[0]["issue"]) - k + "|";
                                                }

                                            }
                                            sign = Convert.ToInt32(ds.Tables[0].Rows[0]["issue"]) - (Convert.ToInt32(ds.Tables[0].Rows[0]["issue"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i + 1]["ExpectNum"]));
                                        }
                                    }
                                    else
                                    {
                                        str += Convert.ToInt32(dsNum.Tables[0].Rows[i]["ExpectNum"]) - j + "|";
                                    }
                                }
                            }
                            else
                            {
                                str += Convert.ToInt32(dsNum.Tables[0].Rows[i]["ExpectNum"]) - 1 + "|";
                            }
                        }
                    }
                }
                return str;
            }
           
        }

        /// <summary>
        /// ȫ���˿�
        /// </summary>
        /// <param name="UserName"> �˿��û�</param>
        /// <param name="item"> Ҫ�˵���Ŀ</param>
        /// <returns></returns>
        public int cancelState(string username, int item)
        { 
            //��ѯ�����Ŀ�ļ۸�
            DataSet dsPrice=Market_GetItme("Price,UserId","appendId="+item);
            //��ѯ�̼ҵ��ʻ����
            DataSet dsShop = Maticsoft.DBUtility.DbHelperSQLBBS.Query("select UserMoney from Dv_User where UserName=" + "'" + dsPrice.Tables[0].Rows[0]["UserId"].ToString() + "'");
            DataSet ds = Maticsoft.DBUtility.DbHelperSQLBBS.Query("select UserMoney from Dv_User where UserName=" + "'" + username + "'");
            
            //�۳��̼ҵ��ʻ����
            int moneyShop=Convert.ToInt32(dsShop.Tables[0].Rows[0][0])-Convert.ToInt32(dsPrice.Tables[0].Rows[0]["Price"]);
            int Shopmoney = Maticsoft.DBUtility.DbHelperSQLBBS.ExecuteSql("update Dv_User set UserMoney=" + moneyShop + " where UserName=" + "'" + dsPrice.Tables[0].Rows[0]["UserId"].ToString() + "'");
            if (Shopmoney > 0)
            {
                //�޸��˿��û����˻����
                int money = Convert.ToInt32(ds.Tables[0].Rows[0][0]) + Convert.ToInt32(dsPrice.Tables[0].Rows[0]["Price"]);
                int dsmoney = Maticsoft.DBUtility.DbHelperSQLBBS.ExecuteSql("update Dv_User set UserMoney=" + money + " where UserName=" + "'" + username + "'");
                if (dsmoney > 0)
                {
                    //ɾ�������¼
                    Market_BuyInfo buy = new Market_BuyInfo();
                    Model.Market_BuyInfo modbuy = new Model.Market_BuyInfo();
                    modbuy = buy.GetModel(item);
                    modbuy.market = 1;
                    if (buy.Update(modbuy) > 0)
                    {
                        //�˿�ɹ�
                        return 1;
                    }
                    else
                    { 
                        //�Ѿ����û��˿�ǹ����¼δɾ��
                        return 3;
                    }
                    
                }
                else
                {
                    return 0;
                }
                //�ѿ۳��̼ҵĽ�� �����˿�û�гɹ�
//                return 2;
            }
            else
            {
                //�˿�ʧ��
                return 0;
            }
        }

       /// <summary>
        /// �۳�ʹ�÷��˿�
       /// </summary>
       /// <param name="username">�˿��û�</param>
       /// <param name="item">Ҫ�˵���ĿID</param>
        public void comtepency(string username, int item)
        {

            //��ѯ�û��������Ϣ
            DataSet ds = Market_Table("Market_BuyInfo", "*", "BuyUserid=" + "'" + username + "'" + " and issueInfoId=" + item);
            //��ѯ�û��˿��ʱ��
            DataSet dstime = Market_Table("Market_CancelIndent", "CTime", "CancelName=" + "'" + username + "'" + " and CancelItem=" + item);
            TimeSpan time=toResult(ds.Tables[0].Rows[0]["BeginTime"].ToString(),dstime.Tables[0].Rows[0]["CTime"].ToString());

            //�ѹ����ǵ�����ת������
            TimeSpan shoptime = toResult(ds.Tables[0].Rows[0]["BeginTime"].ToString(), ds.Tables[0].Rows[0]["EndTime"].ToString());

            //�ж϶����˼�����
            if (time.Days >shoptime.Days)
            {
                //�����˿�
                //return 3;
            }
            //���°������ڡ� ������һ�����ˡ�
            else if (time.Days > 27)
            { 
                //���Ƴ���һ���°�һ���µļ۸���ȡ����


                //�������۳�����Ȼ���˷�

                //�˿�ɹ����޸Ĺ������޺�ʱ�䡣
                
            }
            //����2����
            if (time.Days > 57)
            { 
                //���Ƴ����������� ��2���µļ۸���ȡ����
            }
            if (time.Days > 180)
            { 
                //���Ƴ��������� �������ʱ��*һ���µļ۸�
            }
            //�����˿���޸�����û��Ĺ������ʱ��Ϊ�˿�ɹ�ʱ�䡣
        }

        /// <summary>
        /// �̻�ȡ���շ���Ŀ������
        /// </summary>
        /// <param name="ShopUser">�̻�����</param>
        /// <param name="item">ȡ������Ŀ����ID</param>
        public void ShopCancel(string ShopUser, int item)
        { 
            
            

            //ȡ���������� Ҫ�����ڶ��ƴ���Ŀ�������û��� ���ȫ���˻���


            //Ҫȷ���̻����㹻�����۳��������������ȡ���շ���Ŀ

            //���ȡ���ɹ���Ҫ����Ŀ���շѱ�ʶ�ͽ���޸Ĺ�����

        }
        /// <summary>
        /// �������ڼ��
        /// </summary>
        /// <param name="d1">Ҫ������������һ�������ַ���</param>
        /// <param name="d2">Ҫ����������һ�������ַ���</param>
        /// <returns>һ����ʾ���ڼ����TimeSpan����</returns>

        public static TimeSpan toResult(string d1, string d2)
        {
            try
            {
                DateTime date1 = DateTime.Parse(d1);
                DateTime date2 = DateTime.Parse(d2);
                return toResult(date1, date2);
            }
            catch
            {
                throw new Exception("�ַ�����������ȷ!");
            }
        }
        /// <summary>
        /// �������ڼ��
        /// </summary>
        /// <param name="d1">Ҫ������������һ������</param>
        /// <param name="d2">Ҫ����������һ������</param>
        /// <returns>һ����ʾ���ڼ����TimeSpan����</returns>
        public static TimeSpan toResult(DateTime d1, DateTime d2)
        {
            TimeSpan ts;
            if (d1 > d2)
            {
                ts = d1 - d2;
            }
            else
            {
                ts = d2 - d1;
            }
            return ts;
        }
    }
}
