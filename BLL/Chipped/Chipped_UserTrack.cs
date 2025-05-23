using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Pbzx.DALFactory;
using System.Collections.Generic;
namespace Pbzx.BLL
{
    /// <summary>
    /// Chipped_UserTrack
    /// </summary>
    public partial class Chipped_UserTrack
    {
        private readonly IChipped_UserTrack dal = DataAccess.CreateChipped_UserTrack();
        public Chipped_UserTrack()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ut_id)
        {
            return dal.Exists(ut_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Chipped_UserTrack model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Pbzx.Model.Chipped_UserTrack model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ut_id)
        {

            return dal.Delete(ut_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string ut_idlist)
        {
            return dal.DeleteList(ut_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.Chipped_UserTrack GetModel(int ut_id)
        {

            return dal.GetModel(ut_id);
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
        public List<Pbzx.Model.Chipped_UserTrack> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.Chipped_UserTrack> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.Chipped_UserTrack> modelList = new List<Pbzx.Model.Chipped_UserTrack>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.Chipped_UserTrack model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.Chipped_UserTrack();
                    if (dt.Rows[n]["ut_id"].ToString() != "")
                    {
                        model.ut_id = int.Parse(dt.Rows[n]["ut_id"].ToString());
                    }
                    model.ut_username = dt.Rows[n]["ut_username"].ToString();
                    if (dt.Rows[n]["ut_Lname"].ToString() != "")
                    {
                        model.ut_Lname = int.Parse(dt.Rows[n]["ut_Lname"].ToString());
                    }
                    if (dt.Rows[n]["ut_state"].ToString() != "")
                    {
                        model.ut_state = int.Parse(dt.Rows[n]["ut_state"].ToString());
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
