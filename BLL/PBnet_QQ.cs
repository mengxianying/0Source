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
    /// 业务逻辑类PBnet_QQ 的摘要说明。
    /// </summary>
    public class PBnet_QQ
    {
        private readonly IPBnet_QQ dal = DataAccess.CreatePBnet_QQ();
        public PBnet_QQ()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int IntId)
        {
            return dal.Exists(IntId);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Pbzx.Model.PBnet_QQ model)
        {
            return dal.Add(model) > 0 ? true : false;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Pbzx.Model.PBnet_QQ model)
        {
            return dal.Update(model) > 0 ? true : false;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int IntId)
        {

            return dal.Delete(IntId) > 0 ? true : false;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_QQ GetModel(int IntId)
        {

            return dal.GetModel(IntId);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public Pbzx.Model.PBnet_QQ GetModelByCache(int IntId)
        {

            string CacheKey = "PBnet_QQModel-" + IntId;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(IntId);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Pbzx.Model.PBnet_QQ)objModel;
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
        public List<Pbzx.Model.PBnet_QQ> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.PBnet_QQ> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.PBnet_QQ> modelList = new List<Pbzx.Model.PBnet_QQ>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_QQ model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_QQ();
                    if (dt.Rows[n]["IntId"].ToString() != "")
                    {
                        model.IntId = int.Parse(dt.Rows[n]["IntId"].ToString());
                    }
                    model.VarQQNumber = dt.Rows[n]["VarQQNumber"].ToString();
                    model.VarName = dt.Rows[n]["VarName"].ToString();
                    if (dt.Rows[n]["IntDisplayPosition"].ToString() != "")
                    {
                        model.IntDisplayPosition = int.Parse(dt.Rows[n]["IntDisplayPosition"].ToString());
                    }
                    if (dt.Rows[n]["IntOrderID"].ToString() != "")
                    {
                        model.IntOrderID = int.Parse(dt.Rows[n]["IntOrderID"].ToString());
                    }
                    if (dt.Rows[n]["BitIsAuditing"].ToString() != "")
                    {
                        if ((dt.Rows[n]["BitIsAuditing"].ToString() == "1") || (dt.Rows[n]["BitIsAuditing"].ToString().ToLower() == "true"))
                        {
                            model.BitIsAuditing = true;
                        }
                        else
                        {
                            model.BitIsAuditing = false;
                        }
                    }
                    model.Team = dt.Rows[n]["Team"].ToString();
                    model.Tel = dt.Rows[n]["Tel"].ToString();
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
