using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.IDAL;
using Pbzx.DALFactory;
using System.Data;

namespace Pbzx.BLL
{
    /// <summary>
    /// 业务逻辑类Chipped_Tracking 的摘要说明。
    /// </summary>
    public partial class Chipped_Tracking
    {
        private readonly IChipped_Tracking dal = DataAccess.CreateChipped_Tracking();
        public Chipped_Tracking()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int TID)
        {
            return dal.Exists(TID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Chipped_Tracking model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Pbzx.Model.Chipped_Tracking model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int TID)
        {

            return dal.Delete(TID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string TIDlist)
        {
            return dal.DeleteList(TIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.Chipped_Tracking GetModel(int TID)
        {

            return dal.GetModel(TID);
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
        public List<Pbzx.Model.Chipped_Tracking> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.Chipped_Tracking> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.Chipped_Tracking> modelList = new List<Pbzx.Model.Chipped_Tracking>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.Chipped_Tracking model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.Chipped_Tracking();
                    if (dt.Rows[n]["TID"].ToString() != "")
                    {
                        model.TID = int.Parse(dt.Rows[n]["TID"].ToString());
                    }
                    model.TName = dt.Rows[n]["TName"].ToString();
                    if (dt.Rows[n]["Tplay"].ToString() != "")
                    {
                        model.Tplay = int.Parse(dt.Rows[n]["Tplay"].ToString());
                    }
                    if (dt.Rows[n]["TPeriod"].ToString() != "")
                    {
                        model.TPeriod = int.Parse(dt.Rows[n]["TPeriod"].ToString());
                    }
                    model.TorderNum = dt.Rows[n]["TorderNum"].ToString();
                    if (dt.Rows[n]["Tstate"].ToString() != "")
                    {
                        model.Tstate = int.Parse(dt.Rows[n]["Tstate"].ToString());
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
