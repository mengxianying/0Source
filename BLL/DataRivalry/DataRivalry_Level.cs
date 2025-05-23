using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.IDAL;
using Pbzx.DALFactory;
using System.Data;
namespace Pbzx.BLL
{
    /// <summary>
    /// 业务逻辑类DataRivalry_Level 的摘要说明。
    /// </summary>
    public class DataRivalry_Level
    {
        private static readonly IDataRivalry_Level dal = DataAccess.CreateDataRivalry_Level();
        public DataRivalry_Level()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Le_id)
        {
            return dal.Exists(Le_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.DataRivalry_Level model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Pbzx.Model.DataRivalry_Level model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int Le_id)
        {
            return dal.Delete(Le_id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.DataRivalry_Level GetModel(int Le_id)
        {
            return dal.GetModel(Le_id);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        #endregion  成员方法
    }
}
