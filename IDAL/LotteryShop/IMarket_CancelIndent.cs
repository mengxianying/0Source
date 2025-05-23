using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.IDAL
{
   public interface IMarket_CancelIndent
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int CancelID);
        bool Exists(string name, int Item);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Pbzx.Model.Market_CancelIndent model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(Pbzx.Model.Market_CancelIndent model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        int Delete(int CancelID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Pbzx.Model.Market_CancelIndent GetModel(int CancelID);
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
