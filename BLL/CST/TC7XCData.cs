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
    /// ҵ���߼���TC7XCData ��ժҪ˵����
    /// </summary>
    public class TC7XCData
    {
        private readonly ITC7XCData dal = DataAccess.CreateTC7XCData();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("TC7XCData", "issue");
        public TC7XCData()
        {
            basicDAL.IsCst = true;
        }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(string issue)
        {
            return dal.Exists(issue);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Add(Pbzx.Model.TC7XCData model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(Pbzx.Model.TC7XCData model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(string issue)
        {

            dal.Delete(issue);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.TC7XCData GetModel(string issue)
        {

            return dal.GetModel(issue);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public Pbzx.Model.TC7XCData GetModelByCache(string issue)
        {

            string CacheKey = "TC7XCDataModel-" + issue;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(issue);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Pbzx.Model.TC7XCData)objModel;
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
        public List<Pbzx.Model.TC7XCData> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<Pbzx.Model.TC7XCData> modelList = new List<Pbzx.Model.TC7XCData>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.TC7XCData model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.TC7XCData();
                    if (ds.Tables[0].Rows[n]["date"].ToString() != "")
                    {
                        model.date = DateTime.Parse(ds.Tables[0].Rows[n]["date"].ToString());
                    }
                    model.issue = ds.Tables[0].Rows[n]["issue"].ToString();
                    model.code = ds.Tables[0].Rows[n]["code"].ToString();
                    model.money = ds.Tables[0].Rows[n]["money"].ToString();
                    model.first = ds.Tables[0].Rows[n]["first"].ToString();
                    model.second = ds.Tables[0].Rows[n]["second"].ToString();
                    model.sum = ds.Tables[0].Rows[n]["sum"].ToString();
                    model.summoney = ds.Tables[0].Rows[n]["summoney"].ToString();
                    model.bigsmall = ds.Tables[0].Rows[n]["bigsmall"].ToString();
                    model.bigsmallmoney = ds.Tables[0].Rows[n]["bigsmallmoney"].ToString();
                    model.oddeven = ds.Tables[0].Rows[n]["oddeven"].ToString();
                    model.oddevenmoney = ds.Tables[0].Rows[n]["oddevenmoney"].ToString();
                    if (ds.Tables[0].Rows[n]["LastModifyTime"].ToString() != "")
                    {
                        model.LastModifyTime = DateTime.Parse(ds.Tables[0].Rows[n]["LastModifyTime"].ToString());
                    }
                    model.OpName = ds.Tables[0].Rows[n]["OpName"].ToString();
                    model.OpIp = ds.Tables[0].Rows[n]["OpIp"].ToString();
                    if (ds.Tables[0].Rows[n]["Sales"].ToString() != "")
                    {
                        model.Sales = int.Parse(ds.Tables[0].Rows[n]["Sales"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["BonusPool"].ToString() != "")
                    {
                        model.BonusPool = int.Parse(ds.Tables[0].Rows[n]["BonusPool"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["Count0"].ToString() != "")
                    {
                        model.Count0 = int.Parse(ds.Tables[0].Rows[n]["Count0"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["Bonus0"].ToString() != "")
                    {
                        model.Bonus0 = int.Parse(ds.Tables[0].Rows[n]["Bonus0"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["Count1"].ToString() != "")
                    {
                        model.Count1 = int.Parse(ds.Tables[0].Rows[n]["Count1"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["Bonus1"].ToString() != "")
                    {
                        model.Bonus1 = int.Parse(ds.Tables[0].Rows[n]["Bonus1"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["Count2"].ToString() != "")
                    {
                        model.Count2 = int.Parse(ds.Tables[0].Rows[n]["Count2"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["Bonus2"].ToString() != "")
                    {
                        model.Bonus2 = int.Parse(ds.Tables[0].Rows[n]["Bonus2"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["Count3"].ToString() != "")
                    {
                        model.Count3 = int.Parse(ds.Tables[0].Rows[n]["Count3"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["Count4"].ToString() != "")
                    {
                        model.Count4 = int.Parse(ds.Tables[0].Rows[n]["Count4"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["Count5"].ToString() != "")
                    {
                        model.Count5 = int.Parse(ds.Tables[0].Rows[n]["Count5"].ToString());
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
    }
}

