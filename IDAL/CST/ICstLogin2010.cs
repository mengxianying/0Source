using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.IDAL
{
    public interface ICstLogin2010
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int ID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        void Add(Pbzx.Model.CstLogin2010 model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Update(Pbzx.Model.CstLogin2010 model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(int ID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Pbzx.Model.CstLogin2010 GetModel(int ID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        #endregion  成员方法
    }
}
