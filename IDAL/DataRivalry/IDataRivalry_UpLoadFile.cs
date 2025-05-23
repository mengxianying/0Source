using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace Pbzx.IDAL
{
    /// <summary>
    /// 接口层IDataRivalry_UpLoadFile 的摘要说明。
    /// </summary>
    public interface IDataRivalry_UpLoadFile
    {
        #region  成员方法
        /// <summary>
        /// 得到最大ID
        /// </summary>
        int GetMaxId();
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int F_drID);
        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="FileName">文件名</param>
        /// <returns></returns>
        bool Exists(string UserName, string FileName, int FileSize);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Pbzx.Model.DataRivalry_UpLoadFile model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(Pbzx.Model.DataRivalry_UpLoadFile model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        int Delete(int F_drID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Pbzx.Model.DataRivalry_UpLoadFile GetModel(int F_drID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        DataSet GetListDesc(string strWhere);

        DataSet GetListView(string strWhere);

        #endregion  成员方法
    }
}