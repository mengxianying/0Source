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
    /// Drawer_Ticket
    /// </summary>
    public partial class Drawer_Ticket
    {
        private readonly IDrawer_Ticket dal = DataAccess.CreateDrawer_Ticket();
        public Drawer_Ticket()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Tic_id)
        {
            return dal.Exists(Tic_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Drawer_Ticket model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Pbzx.Model.Drawer_Ticket model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Tic_id)
        {

            return dal.Delete(Tic_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string Tic_idlist)
        {
            return dal.DeleteList(Tic_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.Drawer_Ticket GetModel(int ID)
        {
            return dal.GetModel(ID);
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
        public List<Pbzx.Model.Drawer_Ticket> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.Drawer_Ticket> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.Drawer_Ticket> modelList = new List<Pbzx.Model.Drawer_Ticket>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.Drawer_Ticket model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.Drawer_Ticket();
                    if (dt.Rows[n]["Tic_id"].ToString() != "")
                    {
                        model.Tic_id = int.Parse(dt.Rows[n]["Tic_id"].ToString());
                    }
                    model.Tic_DName = dt.Rows[n]["Tic_DName"].ToString();
                    model.Tic_mark = dt.Rows[n]["Tic_mark"].ToString();
                    model.Tic_Condition = dt.Rows[n]["Tic_Condition"].ToString();
                    model.Tic_state = dt.Rows[n]["Tic_state"].ToString();
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