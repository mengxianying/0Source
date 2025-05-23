using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.IDAL;
using Pbzx.DALFactory;
using System.Data;

namespace Pbzx.BLL
{
    /// <summary>
    /// Chipped_Num
    /// </summary>
    public class Chipped_Num
    {
        private readonly IChipped_Num dal = DataAccess.CreateChipped_Num();
        public Chipped_Num()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int N_id)
        {
            return dal.Exists(N_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Chipped_Num model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Pbzx.Model.Chipped_Num model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int N_id)
        {

            return dal.Delete(N_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string N_idlist)
        {
            return dal.DeleteList(N_idlist);
        }

        public bool DeleteRn(int N_RnId)
        {
            return dal.DeleteRn(N_RnId);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.Chipped_Num GetModel(int N_id)
        {

            return dal.GetModel(N_id);
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
        public List<Pbzx.Model.Chipped_Num> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.Chipped_Num> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.Chipped_Num> modelList = new List<Pbzx.Model.Chipped_Num>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.Chipped_Num model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.Chipped_Num();
                    if (dt.Rows[n]["N_id"].ToString() != "")
                    {
                        model.N_id = int.Parse(dt.Rows[n]["N_id"].ToString());
                    }
                    if (dt.Rows[n]["N_InId"].ToString() != "")
                    {
                        model.N_InId = int.Parse(dt.Rows[n]["N_InId"].ToString());
                    }
                    if (dt.Rows[n]["N_RnId"].ToString() != "")
                    {
                        model.N_RnId = int.Parse(dt.Rows[n]["N_RnId"].ToString());
                    }
                    model.N_num = dt.Rows[n]["N_num"].ToString();
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
