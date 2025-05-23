using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Pbzx.Model;
using Pbzx.DALFactory;
using Pbzx.IDAL;
using Pbzx.Common;
using System.Text;
using System.Collections;
namespace Pbzx.BLL
{
    /// <summary>
    /// ҵ���߼���PBnet_PaginAtion ��ժҪ˵����
    /// </summary>
    public class PBnet_PaginAtion
    {
        private readonly Pbzx.IDAL.IPBnet_PaginAtion  dal = DataAccess.CreatePBnet_PaginAtion();
        public PBnet_PaginAtion()
        { }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int PaginationID)
        {
            return dal.Exists(PaginationID);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Pbzx.Model.PBnet_PaginAtion model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(Pbzx.Model.PBnet_PaginAtion model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int PaginationID)
        {

            dal.Delete(PaginationID);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.PBnet_PaginAtion GetModel(int PaginationID)
        {

            return dal.GetModel(PaginationID);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public Pbzx.Model.PBnet_PaginAtion GetModelByCache(int PaginationID)
        {

            string CacheKey = "PBnet_PaginAtionModel-" + PaginationID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(PaginationID);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Pbzx.Model.PBnet_PaginAtion)objModel;
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
        public List<Pbzx.Model.PBnet_PaginAtion> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.PBnet_PaginAtion> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.PBnet_PaginAtion> modelList = new List<Pbzx.Model.PBnet_PaginAtion>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_PaginAtion model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_PaginAtion();
                    if (dt.Rows[n]["PaginationID"].ToString() != "")
                    {
                        model.PaginationID = int.Parse(dt.Rows[n]["PaginationID"].ToString());
                    }
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    model.FilePath = dt.Rows[n]["FilePath"].ToString();
                    model.PhysicPath = dt.Rows[n]["PhysicPath"].ToString();
                    model.FileName = dt.Rows[n]["FileName"].ToString();
                    model.Suffix = dt.Rows[n]["Suffix"].ToString();
                    if (dt.Rows[n]["PageNo"].ToString() != "")
                    {
                        model.PageNo = int.Parse(dt.Rows[n]["PageNo"].ToString());
                    }
                    if (dt.Rows[n]["PageType"].ToString() != "")
                    {
                        model.PageType = int.Parse(dt.Rows[n]["PageType"].ToString());
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

        #region �������ݷ�ҳ
        /// <summary>
        /// ��ӷ�ҳ����
        /// </summary>
        public int PaginationCreate(Pbzx.Model.PBnet_PaginAtion paginAtionInfo)
        {            
            try
            {
                return dal.PaginationCreate(paginAtionInfo);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        /// <summary>
        /// ��������IDɾ����ҳ
        /// </summary>
        /// <param name="id">����ID</param>
        /// <param name="moduletype">��������</param>
        public void PaginationDelete(int id, EModuleType moduletype)
        {
            try
            {
                dal.PaginationDelete(id, moduletype);
            }
            catch (Exception)
            {

            }
        }
        /// <summary>
        /// ��������ID��ȡ��ҳ����
        /// </summary>
        /// <param name="id">����ID</param>
        /// <param name="moduletype">��������</param>
        /// <returns></returns>
        public List<Pbzx.Model.PBnet_PaginAtion> PaginationGet(int id, EModuleType moduletype)
        {
            try
            {
                return dal.PaginationGet(id, moduletype);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// ����ID��ȡ������ҳ��ַ
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="moduletype">����</param>
        /// <returns></returns>
        public string PaginationGetUrl(int id, EModuleType moduletype)
        {
            try
            {
                return PaginationGet(id, moduletype)[0].FilePath.ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }


        /// <summary>
        /// ���ݷ�ҳ��־�������
        /// </summary>
        /// <param name="source">Ҫ�ָ����ַ�</param>
        /// <returns>string[]</returns>
        public string[] PaginationContent(string source)
        {
            if (source.IndexOf(WebInit.webBaseConfig.PaginAtion) > -1)
            {
                string split = WebInit.webBaseConfig.PaginAtion;
                int len = split.Length;
                ArrayList al = new ArrayList();
                int start = 0; //��ʼλ��
                int j = -1; //ƥ������λ��
                while (true)
                {
                    j = source.IndexOf(split, start);
                    if (j > -1)
                    {
                        al.Add(source.Substring(start, j - start));
                        int s = j - start;
                        start = j + len;
                    }
                    else
                    {
                        al.Add(source.Substring(start));
                        break;
                    }
                }
                string[] result;
                if (al.Count == 0)
                {
                    string[] r = new string[1];
                    r[0] = source;
                    result = r;
                }
                else
                {
                    string[] r = new string[al.Count];
                    for (int i = 0; i < al.Count; i++)
                    {
                        r[i] = al[i].ToString();
                    }
                    result = r;
                }
                return result;
            }
            else
                return null;
        }



        /// <summary>
        /// ���ɷ�ҳ�ַ���
        /// </summary>
        /// <param name="PageUrls">���з�ҳ��ַ</param>
        /// <param name="CurrentPage">��ǰҳ��</param>
        /// <param name="PageCount">����ҳ��</param>
        /// <param name="paginationDIV">��ҳ��ʽ</param>
        /// <param name="disablepageDIV">ʧЧҳ��ʽ</param>
        /// <param name="currentpageDIV">��ǰҳ��ʽ</param>
        /// <param name="nextpageDIV">��ҳ��ʽ</param>
        /// <returns>��ҳ�ַ��������Ϊ�գ����ҳ��������1</returns>
        public string CreatePagination(ArrayList PageUrls, int CurrentPage, int PageCount, string paginationDIV, string disablepageDIV, string currentpageDIV, string nextpageDIV)
        {
            if (PageCount > 1)
            {
                StringBuilder sb = new StringBuilder();
                string FirstPageUrl = "";
                string LastPageUrl = "";
                if (CurrentPage == 1)
                {
                    LastPageUrl = PageUrls[CurrentPage].ToString();
                }
                else if (CurrentPage == PageCount)
                {
                }
                else
                {
                    FirstPageUrl = PageUrls[CurrentPage - 1].ToString();
                    LastPageUrl = PageUrls[CurrentPage].ToString();
                }


                sb.Append("<div class='" + paginationDIV + "'><ul>");
                if (CurrentPage == 1)
                {
                    sb.Append("<li class='" + disablepageDIV + "'>��һҳ</li>");
                }
                else if (CurrentPage == PageCount)
                {
                    FirstPageUrl = PageUrls[PageCount - 2].ToString();
                    sb.Append(@"<li class='" + nextpageDIV + "'> <a href='" + FirstPageUrl + "'>��һҳ</a></li>");
                }
                else
                {
                    FirstPageUrl = PageUrls[CurrentPage - 2].ToString();
                    sb.Append(@"<li class='" + nextpageDIV + "'><a href='" + FirstPageUrl + "'>��һҳ</a></li>");
                }

                for (int i = 1; i <= PageCount; i++)
                {
                    if (CurrentPage == i)
                    {
                        sb.Append(@"<li class='" + currentpageDIV + "'>" + i + "</li>");
                    }
                    else
                    {
                        sb.Append(@"<li><a href='" + PageUrls[i - 1].ToString() + "'>" + i + "</a></li>");
                    }
                }

                if (CurrentPage == 1)
                {
                    LastPageUrl = PageUrls[CurrentPage].ToString();
                    sb.Append(@"<li class='" + nextpageDIV + "'><a href='" + LastPageUrl + "'>��һҳ</a></li>");
                }
                else if (CurrentPage == PageCount)
                {
                    sb.Append("<li class='" + disablepageDIV + "'>��һҳ</li>");
                }
                else
                {
                    LastPageUrl = PageUrls[CurrentPage].ToString();
                    sb.Append(@"<li class='" + nextpageDIV + "'><a href='" + LastPageUrl + "'>��һҳ</a></li>");
                }
                sb.Append("</div>");
                return sb.ToString();
            }
            else
                return null;
        }
        #endregion
    }
}

