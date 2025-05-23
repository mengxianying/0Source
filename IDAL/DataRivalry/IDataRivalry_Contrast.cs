using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.IDAL
{
    /// <summary>
    /// 接口层IDataRivalry_Contrast 的摘要说明。
    /// </summary>
    public interface IDataRivalry_Contrast
    {
        #region  成员方法
        /// <summary>
        /// 得到最大ID
        /// </summary>
        int GetMaxId();
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int ct_id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Pbzx.Model.DataRivalry_Contrast model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(Pbzx.Model.DataRivalry_Contrast model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        int Delete(int ct_id);

        /// <summary>
        /// 删除一条数据 根据信息表ID 
        /// </summary>
        int DeleteJoint(int Ct_drID);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Pbzx.Model.DataRivalry_Contrast GetModel(int ct_id);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);


        #endregion  成员方法
    }
}
