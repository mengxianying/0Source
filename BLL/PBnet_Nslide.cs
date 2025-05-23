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
    /// 业务逻辑类PBnet_Nslide 的摘要说明。
    /// </summary>
    public class PBnet_Nslide
    {
        private readonly IPBnet_Nslide dal = DataAccess.CreatePBnet_Nslide();
        public PBnet_Nslide()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Pbzx.Model.PBnet_Nslide model)
        {
            return dal.Add(model) > 0 ? true : false;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Pbzx.Model.PBnet_Nslide model)
        {
            return dal.Update(model) > 0 ? true : false;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            return dal.Delete(ID) > 0 ? true : false;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_Nslide GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public Pbzx.Model.PBnet_Nslide GetModelByCache(int ID)
        {

            string CacheKey = "PBnet_NslideModel-" + ID;
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
            return (Pbzx.Model.PBnet_Nslide)objModel;
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
        public List<Pbzx.Model.PBnet_Nslide> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.PBnet_Nslide> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.PBnet_Nslide> modelList = new List<Pbzx.Model.PBnet_Nslide>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_Nslide model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_Nslide();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    model.LinkUrl = dt.Rows[n]["LinkUrl"].ToString();
                    model.PicUrl = dt.Rows[n]["PicUrl"].ToString();
                    if (dt.Rows[n]["NOrder"].ToString() != "")
                    {
                        model.NOrder = int.Parse(dt.Rows[n]["NOrder"].ToString());
                    }
                    model.Title = dt.Rows[n]["Title"].ToString();
                    if (dt.Rows[n]["IsEnable"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IsEnable"].ToString() == "1") || (dt.Rows[n]["IsEnable"].ToString().ToLower() == "true"))
                        {
                            model.IsEnable = true;
                        }
                        else
                        {
                            model.IsEnable = false;
                        }
                    }
                    if (dt.Rows[n]["IsInitial"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IsInitial"].ToString() == "1") || (dt.Rows[n]["IsInitial"].ToString().ToLower() == "true"))
                        {
                            model.IsInitial = true;
                        }
                        else
                        {
                            model.IsInitial = false;
                        }
                    }
                    if (dt.Rows[n]["width"].ToString() != "")
                    {
                        model.width = int.Parse(dt.Rows[n]["width"].ToString());
                    }
                    if (dt.Rows[n]["height"].ToString() != "")
                    {
                        model.height = int.Parse(dt.Rows[n]["height"].ToString());
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


        /// <summary>
        /// 更改Bool类型字段状态
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="filed">字段名</param>
        public static void ChangeAudit(int id, string filed)
        {
            Pbzx.SQLServerDAL.Basic basicDAL1 = new Pbzx.SQLServerDAL.Basic("PBnet_Nslide", "ID");
            basicDAL1.ChangeAudit(id, filed);
        }

    }
}

