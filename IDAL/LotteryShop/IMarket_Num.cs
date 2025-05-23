using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.IDAL
{
    /// <summary>
    /// 数据接口层
    /// 创建人：杨良伟
    /// 创建时间：2010-10-22
    /// </summary>
   public interface IMarket_Num
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int ID);
        /// <summary>
            /// 重载方法
            /// 创建人: zhouwei
            /// 创建时间: 2010-11-25
            /// </summary>
            /// <param name="id">项目ID</param>
            /// <param name="expctNum">期号</param>
            /// <returns></returns>
       bool Exists(int id, string expctNum, string radio);
        /// <summary>
        /// 增加一条数据
        /// </summary>
       int Add(Pbzx.Model.Market_Num issueinfo);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(Pbzx.Model.Market_Num issueinfo);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        int Delete(int ID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
       Pbzx.Model.Market_Num GetModel(int ID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetList(int Top, string strWhere, string filedOrder);
        #endregion
    }
}
