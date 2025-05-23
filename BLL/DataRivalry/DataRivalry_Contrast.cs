using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.IDAL;
using Pbzx.DALFactory;
using System.Data;

namespace Pbzx.BLL
{
    /// <summary>
    /// 业务逻辑类DataRivalry_Contrast 的摘要说明。
    /// </summary>
    public class DataRivalry_Contrast
    {
        private static readonly IDataRivalry_Contrast dal = DataAccess.CreateDataRivalry_Contrast();
        
        public DataRivalry_Contrast()
        { }
        #region  成员方法


        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ct_id)
        {
            return dal.Exists(ct_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.DataRivalry_Contrast model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Pbzx.Model.DataRivalry_Contrast model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ct_id)
        {
            return dal.Delete(ct_id);
        }

        /// <summary>
        /// 删除一条数据 根据信息表ID 
        /// </summary>
        public int DeleteJoint(int Ct_drID)
        {
            return dal.DeleteJoint(Ct_drID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.DataRivalry_Contrast GetModel(int ct_id)
        {
            return dal.GetModel(ct_id);
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