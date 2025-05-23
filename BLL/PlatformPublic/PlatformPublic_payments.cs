using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.DALFactory;
using Pbzx.IDAL;
using System.Data;

namespace Pbzx.BLL
{
    /// <summary>
    /// ҵ���߼���PlatformPublic_payments ��ժҪ˵����
    /// </summary>
    public class PlatformPublic_payments
    {
        private static readonly IPlatformPublic_payments dal = DataAccess.CreatePlatformPublic_payments();

        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("PlatformPublic_payments", "Pp_id");
        public PlatformPublic_payments()
        { }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int Pp_id)
        {
            return dal.Exists(Pp_id);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Pbzx.Model.PlatformPublic_payments model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Update(Pbzx.Model.PlatformPublic_payments model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public int Delete(int Pp_id)
        {
            return dal.Delete(Pp_id);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.PlatformPublic_payments GetModel(int Pp_id)
        {
            return dal.GetModel(Pp_id);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// ����û���֧��Ϣ
        /// </summary>
        /// <param name="userName">�û���</param>
        /// <param name="Pp_num">����ƽ̨Ϊ�����ţ�����ƽ̨����ˮ�š�����Ϊ��</param>
        /// <param name="type">�������ͣ�1��֧��  2����ȡ 3������</param>
        /// <param name="issue">�ں�</param>
        /// <param name="LotName">���ֱ�ʶ</param>
        /// <param name="explain">˵������</param>
        /// <param name="data">������֧���</param>
        /// <param name="date_Time">���ʱ��</param>
        /// <param name="belongs">ƽ̨��ʶ</param>
        public void payments(string UserName,string Pp_num, int type, int issue,int LotName, string explain,decimal data, string belongs)
        {
            Pbzx.Model.PlatformPublic_payments mod_pt = new Pbzx.Model.PlatformPublic_payments();
            mod_pt.Pp_name = UserName;
            mod_pt.Pp_num = Pp_num;
            mod_pt.Pp_Type = type;
            mod_pt.Pp_issue = Convert.ToInt32(issue);
            mod_pt.Pp_LotName = LotName;
            mod_pt.Pp_Time = Convert.ToDateTime(DateTime.Now);
            mod_pt.Pp_explain = explain;
            mod_pt.Pp_data = data;
            mod_pt.Pp_belongs = belongs;
            try
            {
                Add(mod_pt);
            }
            catch (Exception ex)
            {
                Pbzx.Common.ErrorLog.WriteLog(ex);
            }
        }
        /// <summary>
        /// ���ݲ�ѯ�ַ�����ȡ��ҳ����
        /// ������: zhouwei
        /// ����ʱ��: 2011-02-28
        /// </summary>
        /// <param name="SearchStr">��ѯ�ַ��� </param>
        /// <param name="getFileds">��ȡ��</param>
        /// <param name="OrderStr">�����ֶ�</param>
        /// <param name="PageNum">��ȡ��������</param>
        /// <param name="desc">�����ǽ���</param>
        /// <param name="CurrentPage">��ǰ��ҳ��</param>
        /// <param name="Counts">���ؼ�¼������</param>
        /// <returns></returns>         

        public DataTable GuestGetBySearchChipped(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "PlatformPublic_payments", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }
        #endregion  ��Ա����
    }
}
