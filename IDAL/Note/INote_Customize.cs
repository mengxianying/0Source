using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.IDAL
{
    /// <summary>
    /// 接口层INote_Customize 的摘要说明。
    /// </summary>
    public interface INote_Customize
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int ID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Pbzx.Model.Note_Customize model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(Pbzx.Model.Note_Customize model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        int Delete(int ID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Pbzx.Model.Note_Customize GetModel(int ID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);

        Pbzx.Model.Note_Customize GetModel(int sid, string username);

        List<Pbzx.Model.Note_Customize> GetModelByName(string username);

        List<Pbzx.Model.Note_Customize> GetModelBySid(int sid);

        #endregion  成员方法
    }
}
