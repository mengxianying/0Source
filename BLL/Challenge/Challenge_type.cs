using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.IDAL;
using System.Data;
using Pbzx.DALFactory;

namespace Pbzx.BLL
{
    /// <summary>
    /// Challenge_type
    /// </summary>
    public partial class Challenge_type
    {
        private readonly IChallenge_type dal = DataAccess.CreateChallenge_type();
        public Challenge_type()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int T_id)
        {
            return dal.Exists(T_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Challenge_type model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Pbzx.Model.Challenge_type model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int T_id)
        {

            return dal.Delete(T_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string T_idlist)
        {
            return dal.DeleteList(T_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.Challenge_type GetModel(int T_id)
        {

            return dal.GetModel(T_id);
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
        public List<Pbzx.Model.Challenge_type> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.Challenge_type> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.Challenge_type> modelList = new List<Pbzx.Model.Challenge_type>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.Challenge_type model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.Challenge_type();
                    if (dt.Rows[n]["T_id"].ToString() != "")
                    {
                        model.T_id = int.Parse(dt.Rows[n]["T_id"].ToString());
                    }
                    model.T_cond = dt.Rows[n]["T_cond"].ToString();
                    model.T_state = dt.Rows[n]["T_state"].ToString();
                    if (dt.Rows[n]["T_lottID"].ToString() != "")
                    {
                        model.T_lottID = int.Parse(dt.Rows[n]["T_lottID"].ToString());
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
