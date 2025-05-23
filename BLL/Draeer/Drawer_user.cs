using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.IDAL;
using Pbzx.DALFactory;
using System.Data;

namespace Pbzx.BLL
{
    /// <summary>
    /// Drawer_user
    /// </summary>
    public partial class Drawer_user
    {
        private readonly IDrawer_user dal = DataAccess.CreateDrawer_user();
        public Drawer_user()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int D_id)
        {
            return dal.Exists(D_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Drawer_user model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Pbzx.Model.Drawer_user model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int D_id)
        {

            return dal.Delete(D_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string D_idlist)
        {
            return dal.DeleteList(D_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.Drawer_user GetModel(int D_id)
        {

            return dal.GetModel(D_id);
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
        public List<Pbzx.Model.Drawer_user> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.Drawer_user> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.Drawer_user> modelList = new List<Pbzx.Model.Drawer_user>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.Drawer_user model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.Drawer_user();
                    if (dt.Rows[n]["D_id"].ToString() != "")
                    {
                        model.D_id = int.Parse(dt.Rows[n]["D_id"].ToString());
                    }
                    model.D_userName = dt.Rows[n]["D_userName"].ToString();
                    model.D_passsWord = dt.Rows[n]["D_passsWord"].ToString();
                    model.D_code = dt.Rows[n]["D_code"].ToString();
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

