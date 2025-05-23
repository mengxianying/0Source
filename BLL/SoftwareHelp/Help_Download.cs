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
    /// Help_Download
    /// </summary>
    public partial class Help_Download
    {
        private readonly IHelp_Download dal = DataAccess.CreateHelp_Download();
        public Help_Download()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int d_id)
        {
            return dal.Exists(d_id);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists1(int d_type)
        {
            return dal.Exists1(d_type);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Help_Download model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Pbzx.Model.Help_Download model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int d_id)
        {

            return dal.Delete(d_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string d_idlist)
        {
            return dal.DeleteList(d_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.Help_Download GetModel(int d_id)
        {

            return dal.GetModel(d_id);
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
        public List<Pbzx.Model.Help_Download> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.Help_Download> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.Help_Download> modelList = new List<Pbzx.Model.Help_Download>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.Help_Download model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.Help_Download();
                    if (dt.Rows[n]["d_id"].ToString() != "")
                    {
                        model.d_id = int.Parse(dt.Rows[n]["d_id"].ToString());
                    }
                    if (dt.Rows[n]["d_type"].ToString() != "")
                    {
                        model.d_type = int.Parse(dt.Rows[n]["d_type"].ToString());
                    }
                    model.d_download = dt.Rows[n]["d_download"].ToString();
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
