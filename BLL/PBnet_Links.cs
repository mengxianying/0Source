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
    /// ҵ���߼���PBnet_Links ��ժҪ˵����
    /// </summary>
    public class PBnet_Links
    {
        private readonly IPBnet_Links dal = DataAccess.CreatePBnet_Links();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("PBnet_Links", "IntID");
        public PBnet_Links()
        { }
        #region  ��Ա����


        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int IntID)
        {
            return dal.Exists(IntID);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Add(Pbzx.Model.PBnet_Links model)
        {
            return dal.Add(model) > 0 ? true : false;
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Pbzx.Model.PBnet_Links model)
        {
            return dal.Update(model) > 0 ? true : false;
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int IntID)
        {

            return dal.Delete(IntID) > 0 ? true : false;
        }



        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.PBnet_Links GetModel(int IntID)
        {

            return dal.GetModel(IntID);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public Pbzx.Model.PBnet_Links GetModelByCache(int IntID)
        {

            string CacheKey = "PBnet_LinksModel-" + IntID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(IntID);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Pbzx.Model.PBnet_Links)objModel;
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
        public List<Pbzx.Model.PBnet_Links> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.PBnet_Links> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.PBnet_Links> modelList = new List<Pbzx.Model.PBnet_Links>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_Links model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_Links();
                    if (dt.Rows[n]["IntID"].ToString() != "")
                    {
                        model.IntID = int.Parse(dt.Rows[n]["IntID"].ToString());
                    }
                    if (dt.Rows[n]["IntLinkType"].ToString() != "")
                    {
                        model.IntLinkType = int.Parse(dt.Rows[n]["IntLinkType"].ToString());
                    }
                    model.IntSiteName = dt.Rows[n]["IntSiteName"].ToString();
                    model.NteSiteUrl = dt.Rows[n]["NteSiteUrl"].ToString();
                    model.NteSiteIntro = dt.Rows[n]["NteSiteIntro"].ToString();
                    model.NteLogoUrl = dt.Rows[n]["NteLogoUrl"].ToString();
                    model.NvarSiteAdmin = dt.Rows[n]["NvarSiteAdmin"].ToString();
                    model.NvarEmail = dt.Rows[n]["NvarEmail"].ToString();
                    model.NvarSitePassword = dt.Rows[n]["NvarSitePassword"].ToString();
                    if (dt.Rows[n]["BitIsGood"].ToString() != "")
                    {
                        if ((dt.Rows[n]["BitIsGood"].ToString() == "1") || (dt.Rows[n]["BitIsGood"].ToString().ToLower() == "true"))
                        {
                            model.BitIsGood = true;
                        }
                        else
                        {
                            model.BitIsGood = false;
                        }
                    }
                    if (dt.Rows[n]["BitIsOK"].ToString() != "")
                    {
                        model.BitIsOK = Convert.ToInt32(dt.Rows[n]["BitIsOK"].ToString());

                        //if ((dt.Rows[n]["BitIsOK"].ToString() == "1") || (dt.Rows[n]["BitIsOK"].ToString().ToLower() == "true"))
                        //{
                        //    model.BitIsOK = true;
                        //}
                        //else
                        //{
                        //    model.BitIsOK = false;
                        //}
                    }
                    if (dt.Rows[n]["ModifyTime"].ToString() != "")
                    {
                        model.ModifyTime = DateTime.Parse(dt.Rows[n]["ModifyTime"].ToString());
                    }
                    if (dt.Rows[n]["SortOrder"].ToString() != "")
                    {
                        model.SortOrder = int.Parse(dt.Rows[n]["SortOrder"].ToString());
                    }
                    model.QQ = dt.Rows[n]["QQ"].ToString();
                    model.Tel = dt.Rows[n]["Tel"].ToString();
                    model.Remark = dt.Rows[n]["Remark"].ToString();
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

        #region �Զ��巽��

        #region Delete:ɾ����������.
        /// <summary>
        /// ɾ����������.
        /// </summary>
        /// <param name="linkid">���ID.</param>
        /// <returns>��ɾ���ļ�¼��.</returns>
        public int Delete(string linkid)
        {
            return dal.Delete(linkid);
        }
        #endregion

        #region OK:�����������.
        /// <summary>
        /// �����������.
        /// </summary>
        /// <param name="linkid">���ID.</param>
        /// <returns>������������Ӽ�¼��.</returns>
        public int Auditing(string linkid)
        {
            return dal.Auditing(linkid);
        }
        #endregion


        #region No:�����������.
        /// <summary>
        /// �������������.
        /// </summary>
        /// <param name="linkid">���ID.</param>
        /// <returns>��������������Ӽ�¼��.</returns>
        public int NoAuditing(string linkid)
        {
            return dal.NoAuditing(linkid);
        }
        #endregion





        /// <summary>
        /// ���ݲ�ѯ�ַ�����ȡ��ҳ����
        /// </summary>
        /// <param name="SearchStr">��ѯ�ַ���</param>
        /// <param name="getFileds">��ȡ��</param>
        /// <param name="OrderStr">�����ֶ�</param>
        /// <param name="PageNum">��ȡ��������</param>
        /// <param name="CurrentPage">��ǰ��ҳ��</param>
        /// <param name="Counts">���ؼ�¼������</param>
        /// <returns></returns>
        public DataTable GuestGetBySearch(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "PBnet_Links", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }
        #endregion

        /// <summary>
        /// ����Bool�����ֶ�״̬
        /// </summary>
        /// <param name="id">���</param>
        /// <param name="filed">�ֶ���</param>
        public static void ChangeAudit(int id, string filed)
        {
            Pbzx.SQLServerDAL.Basic basicDAL1 = new Pbzx.SQLServerDAL.Basic("PBnet_Links", "IntID");
            basicDAL1.ChangeAudit(id, filed);
        }
        ///// <summary>
        ///// �Ƚϲ���������MusicEntry��������д���
        ///// </summary>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <returns></returns>
        //private int CompareProductEntry(Pbzx.Model.PBnet_Links x, Pbzx.Model.PBnet_Links y)
        //{
        //    return  x.SortOrder.CompareTo(y.SortOrder);
        //}

        /// <summary>
        /// �õ���������������б�
        /// </summary>
        /// <returns></returns>
        //public List<Pbzx.Model.PBnet_Links> GetProductListSort(string strWhere)
        //{
        //    if(strWhere == null)
        //    {
        //        strWhere = "";
        //    }
        //    List<Pbzx.Model.PBnet_Links> data = GetModelList(strWhere);
        //    if (data.Count > 1)
        //    {
        //        Pbzx.Model.PBnet_Links productM = new Pbzx.Model.PBnet_Links();
        //        data.Sort(productM);
        //    }
        //    return data;
        //}


    }
}

