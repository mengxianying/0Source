using System;
using System.Data;
using System.Collections.Generic;
using Pbzx.Model;
using Pbzx.DALFactory;
using Pbzx.IDAL;
namespace Pbzx.BLL
{
    /// <summary>
    /// Drawer_configure
    /// </summary>
    public partial class Drawer_configure
    {
        private readonly IDrawer_configure dal = DataAccess.CreateDrawer_configure();
        public Drawer_configure()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Dtc_id)
        {
            return dal.Exists(Dtc_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Drawer_configure model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Pbzx.Model.Drawer_configure model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Dtc_id)
        {

            return dal.Delete(Dtc_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string Dtc_idlist)
        {
            return dal.DeleteList(Dtc_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.Drawer_configure GetModel(int Dtc_id)
        {

            return dal.GetModel(Dtc_id);
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
        public List<Pbzx.Model.Drawer_configure> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.Drawer_configure> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.Drawer_configure> modelList = new List<Pbzx.Model.Drawer_configure>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.Drawer_configure model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.Drawer_configure();
                    if (dt.Rows[n]["Dtc_id"].ToString() != "")
                    {
                        model.Dtc_id = int.Parse(dt.Rows[n]["Dtc_id"].ToString());
                    }
                    model.Dtc_name = dt.Rows[n]["Dtc_name"].ToString();
                    if (dt.Rows[n]["Dtc_cf"].ToString() != "")
                    {
                        model.Dtc_cf = int.Parse(dt.Rows[n]["Dtc_cf"].ToString());
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
