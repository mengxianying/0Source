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
    /// 业务逻辑类TCDLTData 的摘要说明。
    /// </summary>
    public class TCDLTData
    {
        private readonly ITCDLTData dal = DataAccess.CreateTCDLTData();
        public TCDLTData()
        { }
        #region  成员方法
        /// <summary>s
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string issue)
        {
            return dal.Exists(issue);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Pbzx.Model.TCDLTData model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Pbzx.Model.TCDLTData model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string issue)
        {

            dal.Delete(issue);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.TCDLTData GetModel(string issue)
        {

            return dal.GetModel(issue);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public Pbzx.Model.TCDLTData GetModelByCache(string issue)
        {

            string CacheKey = "TCDLTDataModel-" + issue;
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
            return (Pbzx.Model.TCDLTData)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.TCDLTData> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.TCDLTData> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.TCDLTData> modelList = new List<Pbzx.Model.TCDLTData>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.TCDLTData model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.TCDLTData();
                    if (dt.Rows[n]["date"].ToString() != "")
                    {
                        model.date = DateTime.Parse(dt.Rows[n]["date"].ToString());
                    }
                    model.issue = dt.Rows[n]["issue"].ToString();
                    model.code = dt.Rows[n]["code"].ToString();
                    model.code2 = dt.Rows[n]["code2"].ToString();
                    if (dt.Rows[n]["LastModifytime"].ToString() != "")
                    {
                        model.LastModifytime = DateTime.Parse(dt.Rows[n]["LastModifytime"].ToString());
                    }
                    model.OpName = dt.Rows[n]["OpName"].ToString();
                    model.OpIp = dt.Rows[n]["OpIp"].ToString();
                    if (dt.Rows[n]["Sales"].ToString() != "")
                    {
                        model.Sales = int.Parse(dt.Rows[n]["Sales"].ToString());
                    }
                    if (dt.Rows[n]["BonusPool"].ToString() != "")
                    {
                        model.BonusPool = int.Parse(dt.Rows[n]["BonusPool"].ToString());
                    }
                    if (dt.Rows[n]["Count1"].ToString() != "")
                    {
                        model.Count1 = int.Parse(dt.Rows[n]["Count1"].ToString());
                    }
                    if (dt.Rows[n]["Bonus1"].ToString() != "")
                    {
                        model.Bonus1 = int.Parse(dt.Rows[n]["Bonus1"].ToString());
                    }
                    if (dt.Rows[n]["Count2"].ToString() != "")
                    {
                        model.Count2 = int.Parse(dt.Rows[n]["Count2"].ToString());
                    }
                    if (dt.Rows[n]["Bonus2"].ToString() != "")
                    {
                        model.Bonus2 = int.Parse(dt.Rows[n]["Bonus2"].ToString());
                    }
                    if (dt.Rows[n]["Count3"].ToString() != "")
                    {
                        model.Count3 = int.Parse(dt.Rows[n]["Count3"].ToString());
                    }
                    if (dt.Rows[n]["Bonus3"].ToString() != "")
                    {
                        model.Bonus3 = int.Parse(dt.Rows[n]["Bonus3"].ToString());
                    }
                    if (dt.Rows[n]["Count4"].ToString() != "")
                    {
                        model.Count4 = int.Parse(dt.Rows[n]["Count4"].ToString());
                    }
                    if (dt.Rows[n]["Count5"].ToString() != "")
                    {
                        model.Count5 = int.Parse(dt.Rows[n]["Count5"].ToString());
                    }
                    if (dt.Rows[n]["Count6"].ToString() != "")
                    {
                        model.Count6 = int.Parse(dt.Rows[n]["Count6"].ToString());
                    }
                    if (dt.Rows[n]["Count7"].ToString() != "")
                    {
                        model.Count7 = int.Parse(dt.Rows[n]["Count7"].ToString());
                    }
                    if (dt.Rows[n]["Count8"].ToString() != "")
                    {
                        model.Count8 = int.Parse(dt.Rows[n]["Count8"].ToString());
                    }
                    if (dt.Rows[n]["AppCount1"].ToString() != "")
                    {
                        model.AppCount1 = int.Parse(dt.Rows[n]["AppCount1"].ToString());
                    }
                    if (dt.Rows[n]["AppBonus1"].ToString() != "")
                    {
                        model.AppBonus1 = int.Parse(dt.Rows[n]["AppBonus1"].ToString());
                    }
                    if (dt.Rows[n]["AppCount2"].ToString() != "")
                    {
                        model.AppCount2 = int.Parse(dt.Rows[n]["AppCount2"].ToString());
                    }
                    if (dt.Rows[n]["AppBonus2"].ToString() != "")
                    {
                        model.AppBonus2 = int.Parse(dt.Rows[n]["AppBonus2"].ToString());
                    }
                    if (dt.Rows[n]["AppCount3"].ToString() != "")
                    {
                        model.AppCount3 = int.Parse(dt.Rows[n]["AppCount3"].ToString());
                    }
                    if (dt.Rows[n]["AppBonus3"].ToString() != "")
                    {
                        model.AppBonus3 = int.Parse(dt.Rows[n]["AppBonus3"].ToString());
                    }
                    if (dt.Rows[n]["AddSales"].ToString() != "")
                    {
                        model.AddSales = int.Parse(dt.Rows[n]["AddSales"].ToString());
                    }
                    if (dt.Rows[n]["AddCount1"].ToString() != "")
                    {
                        model.AddCount1 = int.Parse(dt.Rows[n]["AddCount1"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  成员方法
    }
}

