using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Pbzx.Model;
using Pbzx.DALFactory;
using Pbzx.IDAL;
namespace Pbzx.BLL
{
    /// <summary>
    /// ҵ���߼���PBnet_LyBook ��ժҪ˵����
    /// </summary>
    public class PBnet_LyBook
    {
        private readonly IPBnet_LyBook dal = DataAccess.CreatePBnet_LyBook();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("PBnet_LyBook", "SystemNumber");
        public PBnet_LyBook()
        { }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int SystemNumber)
        {
            return dal.Exists(SystemNumber);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Add(Pbzx.Model.PBnet_LyBook model)
        {
            return dal.Add(model) > 0 ? true : false;
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Pbzx.Model.PBnet_LyBook model)
        {
           return dal.Update(model) > 0 ? true : false;
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int SystemNumber)
        {

            return dal.Delete(SystemNumber) > 0 ? true : false;
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.PBnet_LyBook GetModel(int SystemNumber)
        {

            return dal.GetModel(SystemNumber);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public Pbzx.Model.PBnet_LyBook GetModelByCache(int SystemNumber)
        {

            string CacheKey = "PBnet_LyBookModel-" + SystemNumber;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(SystemNumber);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Pbzx.Model.PBnet_LyBook)objModel;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.PBnet_LyBook> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.PBnet_LyBook> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.PBnet_LyBook> modelList = new List<Pbzx.Model.PBnet_LyBook>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_LyBook model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_LyBook();
                    if (dt.Rows[n]["SystemNumber"].ToString() != "")
                    {
                        model.SystemNumber = int.Parse(dt.Rows[n]["SystemNumber"].ToString());
                    }
                    model.LyUserName = dt.Rows[n]["LyUserName"].ToString();
                    if (dt.Rows[n]["LyUserID"].ToString() != "")
                    {
                        model.LyUserID = int.Parse(dt.Rows[n]["LyUserID"].ToString());
                    }
                    if (dt.Rows[n]["LySort"].ToString() != "")
                    {
                        model.LySort = int.Parse(dt.Rows[n]["LySort"].ToString());
                    }
                    model.Ly_Phone = dt.Rows[n]["Ly_Phone"].ToString();
                    model.Ly_Email = dt.Rows[n]["Ly_Email"].ToString();
                    model.LyContent = dt.Rows[n]["LyContent"].ToString();
                    if (dt.Rows[n]["LyState"].ToString() != "")
                    {
                        model.LyState = int.Parse(dt.Rows[n]["LyState"].ToString());
                    }
                    if (dt.Rows[n]["LyLogTime"].ToString() != "")
                    {
                        model.LyLogTime = DateTime.Parse(dt.Rows[n]["LyLogTime"].ToString());
                    }
                    model.LyLogIp = dt.Rows[n]["LyLogIp"].ToString();
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  ��Ա����

        //public static string GetType(object nType)
        //{
        //    string type = "";
        //    int intType = int.Parse(nType.ToString());
        //    switch (intType)
        //    {
        //        case 1:
        //            type = "������ѯ";
        //            break;
        //        case 2:
        //            type = "����";
        //            break;
        //        case 3:
        //            type = "����";
        //            break;
        //        default:
        //            type = "<font color=red>δ֪</font>";
        //            break;

        //    }
        //    return type.ToString();
        //}



        public DataTable GuestGetBySearch(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "PBnet_LyBook", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }


        /// ���ݲ�ѯ�ַ�����ȡ��ҳ����
        /// </summary>
        /// <param name="SearchStr">��ѯ�ַ��� </param>
        /// <param name="getFileds">��ȡ��</param>
        /// <param name="OrderStr">�����ֶ�</param>
        /// <param name="PageNum">��ȡ��������</param>
        /// <param name="desc">�����ǽ���</param>
        /// <param name="CurrentPage">��ǰ��ҳ��</param>
        /// <param name="Counts">���ؼ�¼������</param>
        /// <returns></returns>
        public DataTable GuestGetBySearch2(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "PBnet_LyBook", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }
        /// <summary>
        /// ����Bool�����ֶ�״̬
        /// </summary>
        /// <param name="id">���</param>
        /// <param name="filed">�ֶ���</param>
        public static void ChangeAudit(int id, string filed)
        {
            Pbzx.SQLServerDAL.Basic basicDAL1 = new Pbzx.SQLServerDAL.Basic("PBnet_LyBook", "SystemNumber");
            basicDAL1.ChangeAudit(id, filed);
        }
    }
}

