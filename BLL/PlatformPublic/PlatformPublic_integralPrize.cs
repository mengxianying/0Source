using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.IDAL;
using Pbzx.DALFactory;
using System.Data;

namespace Pbzx.BLL
{
    /// <summary>
    /// ҵ���߼���PlatformPublic_integralPrize ��ժҪ˵����
    /// </summary>
    public class PlatformPublic_integralPrize
    {
        private static readonly IPlatformPublic_integralPrize dal = DataAccess.CreatePlatformPublic_integralPrize();
        public PlatformPublic_integralPrize()
        { }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int Pip_id)
        {
            return dal.Exists(Pip_id);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Pbzx.Model.PlatformPublic_integralPrize model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Update(Pbzx.Model.PlatformPublic_integralPrize model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public int Delete(int Pip_id)
        {
            return dal.Delete(Pip_id);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.PlatformPublic_integralPrize GetModel(int Pip_id)
        {
            return dal.GetModel(Pip_id);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// �۳��û���ʹ�õĽ��
        /// </summary>
        /// <param name="UserName">�û���</param>
        /// <param name="platform">ƽ̨��ʶ</param>
        /// <param name="money">�۳��Ľ��</param>
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
        
        #endregion  ��Ա����
    }
}
