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
    /// 业务逻辑类PBnet_broker_content 的摘要说明。
    /// </summary>
    public class PBnet_broker_content
    {
        private readonly IPBnet_broker_content dal = DataAccess.CreatePBnet_broker_content();
        public PBnet_broker_content()
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
        public bool Add(Pbzx.Model.PBnet_broker_content model)
        {
            return dal.Add(model) > 0 ? true : false;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Pbzx.Model.PBnet_broker_content model)
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
        public Pbzx.Model.PBnet_broker_content GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public Pbzx.Model.PBnet_broker_content GetModelByCache(int ID)
        {

            string CacheKey = "PBnet_broker_contentModel-" + ID;
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
            return (Pbzx.Model.PBnet_broker_content)objModel;
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
        public List<Pbzx.Model.PBnet_broker_content> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.PBnet_broker_content> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.PBnet_broker_content> modelList = new List<Pbzx.Model.PBnet_broker_content>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_broker_content model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_broker_content();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    model.Btitle = dt.Rows[n]["Btitle"].ToString();
                    model.Bcontent = dt.Rows[n]["Bcontent"].ToString();
                    model.Btype = dt.Rows[n]["Btype"].ToString();
                    if (dt.Rows[n]["IntSortID"].ToString() != "")
                    {
                        model.IntSortID = int.Parse(dt.Rows[n]["IntSortID"].ToString());
                    }
                    if (dt.Rows[n]["IsAuditing"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IsAuditing"].ToString() == "1") || (dt.Rows[n]["IsAuditing"].ToString().ToLower() == "true"))
                        {
                            model.IsAuditing = true;
                        }
                        else
                        {
                            model.IsAuditing = false;
                        }
                    }
                    if (dt.Rows[n]["BaddTime"].ToString() != "")
                    {
                        model.BaddTime = DateTime.Parse(dt.Rows[n]["BaddTime"].ToString());
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
            Pbzx.SQLServerDAL.Basic basicDAL1 = new Pbzx.SQLServerDAL.Basic("PBnet_broker_content", "ID");
            basicDAL1.ChangeAudit(id, filed);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.PBnet_broker_content> GetTopList()
        {
            DataSet ds = dal.GetList(1, "IsAuditing=1", "ID asc");
            return DataTableToList(ds.Tables[0]);
        }


        /// <summary>
        /// 自己定义根据用户名得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_broker_content GetModelName()
        {
            List<Pbzx.Model.PBnet_broker_content> ls = GetTopList();
            if (ls.Count > 0)
            {
                return ls[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 自己定义根据用户名得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_broker_content GetTypeName(string TypeName)
        {

            List<Pbzx.Model.PBnet_broker_content> ls = GetModelList(" Btype='" + TypeName + "'");
            if (ls.Count > 0)
            {
                return ls[0];
            }
            else
            {
                return null;
            }
        }

    }
}

