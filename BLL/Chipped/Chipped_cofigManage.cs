using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.IDAL;
using Pbzx.DALFactory;
using System.Data;

namespace Pbzx.BLL
{
    /// <summary>
    /// Chipped_cofig
    /// </summary>
    public partial class Chipped_cofig
    {
        private readonly IChipped_cofig dal = DataAccess.CreateChipped_cofig();
        public Chipped_cofig()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int cfg_id)
        {
            return dal.Exists(cfg_id);
        }
        public bool ExistsState(int cfg_state)
        {
            return dal.ExistsState(cfg_state);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Chipped_cofig model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Pbzx.Model.Chipped_cofig model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int cfg_id)
        {

            return dal.Delete(cfg_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string cfg_idlist)
        {
            return dal.DeleteList(cfg_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.Chipped_cofig GetModel(int cfg_id)
        {

            return dal.GetModel(cfg_id);
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
        public List<Pbzx.Model.Chipped_cofig> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.Chipped_cofig> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.Chipped_cofig> modelList = new List<Pbzx.Model.Chipped_cofig>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.Chipped_cofig model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.Chipped_cofig();
                    if (dt.Rows[n]["cfg_id"].ToString() != "")
                    {
                        model.cfg_id = int.Parse(dt.Rows[n]["cfg_id"].ToString());
                    }
                    model.cfg_lname = dt.Rows[n]["cfg_lname"].ToString();
                    if (dt.Rows[n]["cfg_state"].ToString() != "")
                    {
                        model.cfg_state = int.Parse(dt.Rows[n]["cfg_state"].ToString());
                    }
                    if (dt.Rows[n]["cfg_tarState"].ToString() != "")
                    {
                        model.cfg_tarState = int.Parse(dt.Rows[n]["cfg_tarState"].ToString());
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
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  Method
    }
}