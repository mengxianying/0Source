using System;
using System.Collections.Generic;
using System.Text;

using LTP.Common;
using Pbzx.Model;
using Pbzx.DALFactory;
using Pbzx.IDAL;
using System.Data;

namespace Pbzx.BLL
{
    public class CM_MainBySoftwareTypeManager
    {
        private readonly ICM_MainBySoftwareType dal = DataAccess.CreateCM_MainBySoftwareType();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("CM_MainBySoftwareType", "ID");
        public CM_MainBySoftwareTypeManager()
        {
            basicDAL.IsCst = true;

        }
        #region
        /// <summary>
        /// 根据ID判断数据是否存在
        /// </summary>
        /// <param name="ID">ID编号</param>
        /// <returns>bool值，找到返回true 否则为 false</returns>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }
        /// <summary>
        /// 消息添加方法
        /// </summary>
        /// <param name="main">消息对象</param>
        /// <returns>返回添加后的ID</returns>
        public int Add(Pbzx.Model.CM_MainBySoftwareType main)
        {
            return dal.Add(main);
        }
        /// <summary>
        /// 消息更新方法
        /// </summary>
        /// <param name="main">消息对象</param>
        /// <returns>返回1或 0</returns>
        public bool Update(Pbzx.Model.CM_MainBySoftwareType main)
        {
            return dal.Update(main) > 0 ? true : false;
        }
        /// <summary>
        /// 删除消息的方法
        /// </summary>
        /// <param name="ID">消息ID</param>
        /// <returns>成功为1 失败为 0</returns>
        public bool Delete(int ID)
        {
            return dal.Delete(ID) > 0 ? true : false;
        }

        /// <summary>
        /// 根据消息ID 得到单个实体对象
        /// </summary>
        /// <param name="ID">消息ID</param>
        /// <returns>消息对象</returns>
        public Pbzx.Model.CM_MainBySoftwareType GetMain(int ID)
        {
            return dal.GetMain(ID);
        }
        /// <summary>
        /// 查找整个满足条件的消息1
        /// </summary>
        /// <param name="strWhere">消息条件</param>
        /// <returns>数据表</returns>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        ///重载获得数据列表2没有条件
        /// </summary>
        public DataSet GetAllList()
        {
            return dal.GetList("");
        }

        /// <summary>
        /// 根据cmid删除
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int DeleteByCM_ID(int ID)
        {
            return dal.DeleteByCM_ID(ID);
        }
        #endregion
    }
}
