using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace Pbzx.IDAL
{
    /// <summary>
    /// 接口层IDataRivalry_Result 的摘要说明。
    /// </summary>
    public interface IDataRivalry_Rt
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int Rt_ID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Pbzx.Model.DataRivalry_Rt model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(Pbzx.Model.DataRivalry_Rt model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        int Delete(int Rt_ID);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        int DeleteJoint(int Rt_AwardNum);
        
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Pbzx.Model.DataRivalry_Rt GetModel(int Rt_ID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        #endregion  成员方法
    }
}
