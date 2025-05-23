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
    /// ҵ���߼���PBnet_QQ_Group ��ժҪ˵����
    /// </summary>
    public class PBnet_QQ_Group
    {
        private readonly IPBnet_QQ_Group dal = DataAccess.CreatePBnet_QQ_Group();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("PBnet_QQ_Group", "ID");
        public PBnet_QQ_Group()
        { }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Pbzx.Model.PBnet_QQ_Group model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Pbzx.Model.PBnet_QQ_Group model)
        {
            return dal.Update(model) > 0 ? true : false ;
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int ID)
        {

            return dal.Delete(ID) > 0 ? true : false; 
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.PBnet_QQ_Group GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public Pbzx.Model.PBnet_QQ_Group GetModelByCache(int ID)
        {

            string CacheKey = "PBnet_QQ_GroupModel-" + ID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(ID);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Pbzx.Model.PBnet_QQ_Group)objModel;
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
        public List<Pbzx.Model.PBnet_QQ_Group> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.PBnet_QQ_Group> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.PBnet_QQ_Group> modelList = new List<Pbzx.Model.PBnet_QQ_Group>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_QQ_Group model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_QQ_Group();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    model.QQ_GroupID = dt.Rows[n]["QQ_GroupID"].ToString();
                    model.QQ_GroupName = dt.Rows[n]["QQ_GroupName"].ToString();
                    if (dt.Rows[n]["QQ_GroupType"].ToString() != "")
                    {
                        model.QQ_GroupType = int.Parse(dt.Rows[n]["QQ_GroupType"].ToString());
                    }
                    if (dt.Rows[n]["IsSoftGroup"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IsSoftGroup"].ToString() == "1") || (dt.Rows[n]["IsSoftGroup"].ToString().ToLower() == "true"))
                        {
                            model.IsSoftGroup = true;
                        }
                        else
                        {
                            model.IsSoftGroup = false;
                        }
                    }
                    model.QQ_GroupAdmin = dt.Rows[n]["QQ_GroupAdmin"].ToString();
                    model.QQ_GroupDetails = dt.Rows[n]["QQ_GroupDetails"].ToString();
                    if (dt.Rows[n]["IsEnable"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IsEnable"].ToString() == "1") || (dt.Rows[n]["IsEnable"].ToString().ToLower() == "true"))
                        {
                            model.IsEnable = true;
                        }
                        else
                        {
                            model.IsEnable = false;
                        }
                    }
                    if (dt.Rows[n]["SortID"].ToString() != "")
                    {
                        model.SortID = int.Parse(dt.Rows[n]["SortID"].ToString());
                    }
                    if (dt.Rows[n]["CreateTime"].ToString() != "")
                    {
                        model.CreateTime = DateTime.Parse(dt.Rows[n]["CreateTime"].ToString());
                    }
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

        /// <summary>
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

        public DataTable GuestGetBySearch(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "PBnet_QQ_Group", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }


    }
}

