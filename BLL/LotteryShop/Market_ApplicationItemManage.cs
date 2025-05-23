using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.IDAL;
using Pbzx.DALFactory;
using System.Data;

namespace Pbzx.BLL
{
   public class Market_ApplicationItemManage
    {
    //���ݷ��䣬�ҵ���Ӧ�����ݲ�
       private readonly IMarket_ApplicationItem dal = DataAccess.CreateIMarket_ApplicationItem();
       #region  ��Ա����
       /// <summary>
       /// �Ƿ���ڸü�¼
       /// </summary>
       public bool Exists(int Id)
       {
           return dal.Exists(Id);
       }

       /// <summary>
       /// ����һ������
       /// </summary>
       public int Add(Pbzx.Model.Market_ApplicationItem model)
       {
           return dal.Add(model);
       }

       /// <summary>
       /// ����һ������
       /// </summary>
       public int Update(Pbzx.Model.Market_ApplicationItem model)
       {
          return dal.Update(model);
       }

       /// <summary>
       /// ɾ��һ������
       /// </summary>
       public int Delete(int Id)
       {
           return dal.Delete(Id);
       }

       /// <summary>
       /// �õ�һ������ʵ��
       /// </summary>
       public Pbzx.Model.Market_ApplicationItem GetModel(int Id)
       {
           return dal.GetMain(Id);
       }

       /// <summary>
       /// ��������б�
       /// </summary>
       public DataSet GetList(string strWhere)
       {
           return dal.GetList(strWhere);
       }

       #endregion  ��Ա����

    }
}
