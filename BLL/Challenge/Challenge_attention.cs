using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.DALFactory;
using System.Data;
using Pbzx.IDAL;

namespace Pbzx.BLL
{
    /// <summary>
    /// 业务逻辑类Challenge_attention 的摘要说明。
    /// </summary>
    public class Challenge_attention
    {
        private static readonly IChallenge_attention dal = DataAccess.CreateChallenge_attention();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("Challenge_attention", "Att_id");
        public Challenge_attention()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Att_id)
        {
            return dal.Exists(Att_id);
        }
        public bool Exists(string name)
        {
            return dal.Exists(name);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Challenge_attention model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Pbzx.Model.Challenge_attention model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int Att_id)
        {
            return dal.Delete(Att_id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.Challenge_attention GetModel(int Att_id)
        {
            return dal.GetModel(Att_id);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 根据查询字符串获取分页数据
        /// 创建人: zhouwei
        /// 创建时间: 2010-10-27
        /// </summary>
        /// <param name="SearchStr">查询字符串 </param>
        /// <param name="getFileds">获取列</param>
        /// <param name="OrderStr">排序字段</param>
        /// <param name="PageNum">获取的数据数</param>
        /// <param name="desc">升序还是降序</param>
        /// <param name="CurrentPage">当前的页数</param>
        /// <param name="Counts">返回记录集总数</param>
        /// <returns></returns>         

        public DataTable GuestGetBySearch(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "Challenge_attention", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }
        #endregion  成员方法
    }
}