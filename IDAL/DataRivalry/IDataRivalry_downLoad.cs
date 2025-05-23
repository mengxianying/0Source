using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.IDAL
{
    /// <summary>
    /// 接口层IDataRivalry_downLoad 的摘要说明。
    /// </summary>
    public interface IDataRivalry_downLoad
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int Dl_id);
        bool Exists(int Dl_ufID, string Dl_name);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Pbzx.Model.DataRivalry_downLoad model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(Pbzx.Model.DataRivalry_downLoad model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        int Delete(int Dl_id);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Pbzx.Model.DataRivalry_downLoad GetModel(int Dl_id);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetList(int Top, string strWhere, string filedOrder);
        #endregion  成员方法
    }
}
