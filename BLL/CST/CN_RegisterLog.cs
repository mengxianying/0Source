using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Pbzx.Model;
using Pbzx.DALFactory;
using Pbzx.IDAL;
namespace Pbzx.BLL
{
    /// <summary>
    /// ҵ���߼���CN_RegisterLog ��ժҪ˵����
    /// </summary>
    public class CN_RegisterLog
    {
        private readonly ICN_RegisterLog dal = DataAccess.CreateCN_RegisterLog();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("CN_Log", "ID");
        public CN_RegisterLog()
        {
            basicDAL.IsCst = true;
        }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Add(Pbzx.Model.CN_RegisterLog model)
        {
            return dal.Add(model) > 0 ? true : false;
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Pbzx.Model.CN_RegisterLog model)
        {
            return dal.Update(model) > 0 ? true : false;
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int ID)
        {

            return dal.Delete(ID) > 0 ? true : false;
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.CN_RegisterLog GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public Pbzx.Model.CN_RegisterLog GetModelByCache(int ID)
        {

            string CacheKey = "CN_RegisterLogModel-" + ID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(ID);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Pbzx.Model.CN_RegisterLog)objModel;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.CN_RegisterLog> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<Pbzx.Model.CN_RegisterLog> modelList = new List<Pbzx.Model.CN_RegisterLog>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.CN_RegisterLog model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.CN_RegisterLog();
                    if (ds.Tables[0].Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(ds.Tables[0].Rows[n]["ID"].ToString());
                    }
                    model.BbsName = ds.Tables[0].Rows[n]["BbsName"].ToString();
                    if (ds.Tables[0].Rows[n]["SoftwareType"].ToString() != "")
                    {
                        model.SoftwareType = int.Parse(ds.Tables[0].Rows[n]["SoftwareType"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["InstallType"].ToString() != "")
                    {
                        model.InstallType = int.Parse(ds.Tables[0].Rows[n]["InstallType"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["UseType"].ToString() != "")
                    {
                        model.UseType = int.Parse(ds.Tables[0].Rows[n]["UseType"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["UseValue"].ToString() != "")
                    {
                        model.UseValue = int.Parse(ds.Tables[0].Rows[n]["UseValue"].ToString());
                    }
                    model.PayType = ds.Tables[0].Rows[n]["PayType"].ToString();
                    if (ds.Tables[0].Rows[n]["PayMoney"].ToString() != "")
                    {
                        model.PayMoney = decimal.Parse(ds.Tables[0].Rows[n]["PayMoney"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["PayStatus"].ToString() != "")
                    {
                        model.PayStatus = int.Parse(ds.Tables[0].Rows[n]["PayStatus"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["PayTime"].ToString() != "")
                    {
                        model.PayTime = DateTime.Parse(ds.Tables[0].Rows[n]["PayTime"].ToString());
                    }
                    model.PayDetails = ds.Tables[0].Rows[n]["PayDetails"].ToString();
                    if (ds.Tables[0].Rows[n]["RegisterType"].ToString() != "")
                    {
                        model.RegisterType = int.Parse(ds.Tables[0].Rows[n]["RegisterType"].ToString());
                    }
                    model.Operator = ds.Tables[0].Rows[n]["Operator"].ToString();
                    model.AgentName = ds.Tables[0].Rows[n]["AgentName"].ToString();
                    model.CardInfo = ds.Tables[0].Rows[n]["CardInfo"].ToString();
                    if (ds.Tables[0].Rows[n]["CreateTime"].ToString() != "")
                    {
                        model.CreateTime = DateTime.Parse(ds.Tables[0].Rows[n]["CreateTime"].ToString());
                    }
                    model.Username = ds.Tables[0].Rows[n]["Username"].ToString();
                    model.Remarks = ds.Tables[0].Rows[n]["Remarks"].ToString();
                    if (ds.Tables[0].Rows[n]["CNUserID"].ToString() != "")
                    {
                        model.CNUserID = int.Parse(ds.Tables[0].Rows[n]["CNUserID"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["CNUserDetailsID"].ToString() != "")
                    {
                        model.CNUserDetailsID = int.Parse(ds.Tables[0].Rows[n]["CNUserDetailsID"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["Old_UserType"].ToString() != "")
                    {
                        model.Old_UserType = int.Parse(ds.Tables[0].Rows[n]["Old_UserType"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["Old_ExpireDate"].ToString() != "")
                    {
                        model.Old_ExpireDate = DateTime.Parse(ds.Tables[0].Rows[n]["Old_ExpireDate"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["Old_ValidDays"].ToString() != "")
                    {
                        model.Old_ValidDays = int.Parse(ds.Tables[0].Rows[n]["Old_ValidDays"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["RegisterMode"].ToString() != "")
                    {
                        model.RegisterMode = int.Parse(ds.Tables[0].Rows[n]["RegisterMode"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  ��Ա����

        #region
        /// ���ݲ�ѯ�ַ�����ȡ��ҳ����
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
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "CN_RegisterLog", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }


        /// <summary>
        /// ִ��SQL��ȡ�����б�.
        /// </summary>
        public DataTable GetLisBySql(string strSql)
        {
            return basicDAL.GetLisBySql(strSql);
        }

        public string GetTotalMoney(string where)
        {
            string result = "";
            string sql = "select count(ID) as TotalID,sum(PayMoney) as TotalMoney from [CN_RegisterLog]";
            if (!string.IsNullOrEmpty(where))
            {
                sql += " where " + where;
            }
            DataSet ds = dal.Query(sql);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                object objTotalID = ds.Tables[0].Rows[0]["TotalID"];
                object objTotalMoney = ds.Tables[0].Rows[0]["TotalMoney"];
                //Public_Content.aspx
                if (objTotalID != null && !string.IsNullOrEmpty(objTotalID.ToString()) && objTotalMoney != null && !string.IsNullOrEmpty(objTotalMoney.ToString()))
                {
                    result = ds.Tables[0].Rows[0]["TotalID"] + "&" + ds.Tables[0].Rows[0]["TotalMoney"];
                }
                else
                {
                    result = "0&0";
                }
            }
            else
            {
                result = "0&0";
            }
            return result;
        }


        #endregion

    }
}

