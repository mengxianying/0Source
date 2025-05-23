using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.Model;
using System.Data;

namespace Pbzx.IDAL
{
    /// <summary>
    /// 新消息接口类
    /// 2010-9-16
    /// --------杨良伟
    /// </summary>
    public interface ICM_Main
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int ID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Pbzx.Model.CM_Main main);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(Pbzx.Model.CM_Main main);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        int Delete(int ID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Pbzx.Model.CM_Main GetMain(int ID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        #endregion
    }
}
