using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.IDAL
{
    /// <summary>
    /// 接口方法
    /// 创建人: zhouwei
    /// 创建时间: 2010-11-8
    /// </summary>
    public interface IMarket_CollASAtten
    {
        #region  成员方法
                /// <summary>
        /// 获取数据的个数
        /// 创建人: zhouwei
        /// 创建时间: 2010-11-8
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        DataSet Num(string strWhere);

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int ID);

        bool Exists(string Uname, string appName,int statc,int mark);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Pbzx.Model.Market_CollASAtten mod);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(Pbzx.Model.Market_CollASAtten mod);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        int Delete(int ID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Pbzx.Model.Market_CollASAtten GetModel(int ID);
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