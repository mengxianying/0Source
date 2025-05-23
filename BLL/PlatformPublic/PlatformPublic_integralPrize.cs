using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.IDAL;
using Pbzx.DALFactory;
using System.Data;

namespace Pbzx.BLL
{
    /// <summary>
    /// 业务逻辑类PlatformPublic_integralPrize 的摘要说明。
    /// </summary>
    public class PlatformPublic_integralPrize
    {
        private static readonly IPlatformPublic_integralPrize dal = DataAccess.CreatePlatformPublic_integralPrize();
        public PlatformPublic_integralPrize()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Pip_id)
        {
            return dal.Exists(Pip_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.PlatformPublic_integralPrize model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Pbzx.Model.PlatformPublic_integralPrize model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int Pip_id)
        {
            return dal.Delete(Pip_id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PlatformPublic_integralPrize GetModel(int Pip_id)
        {
            return dal.GetModel(Pip_id);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 扣除用户所使用的金币
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="platform">平台标识</param>
        /// <param name="money">扣除的金币</param>
        /// <returns></returns>
        public int deductMoney(string UserName, string platform,int money)
        {
            DataSet ds_money = GetList("Pip_user=" + "'" + UserName + "'" + " and Pip_belongs=" + "'" + platform + "'");
            Model.PlatformPublic_integralPrize mod_ilp = GetModel(Convert.ToInt32(ds_money.Tables[0].Rows[0]["Pip_id"]));
            mod_ilp.Pip_money = Convert.ToInt32(ds_money.Tables[0].Rows[0]["Pip_money"]) - money;
            if (Update(mod_ilp) > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        
        #endregion  成员方法
    }
}
