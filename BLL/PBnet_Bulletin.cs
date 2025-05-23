using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Pbzx.Model;
using Pbzx.DALFactory;
using Pbzx.IDAL;
using System.Text;
using Pbzx.Common;
using System.Collections;
using System.Configuration;
using System.IO;
namespace Pbzx.BLL
{
    /// <summary>
    /// ҵ���߼���PBnet_Bulletin ��ժҪ˵����
    /// </summary>
    public class PBnet_Bulletin
    {
        private readonly IPBnet_Bulletin dal = DataAccess.CreatePBnet_Bulletin();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("PBnet_Bulletin", "IntID");
        public PBnet_Bulletin()
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
        public bool Add(Pbzx.Model.PBnet_Bulletin model)
        {
            return dal.Add(model) > 0 ? true : false;
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Pbzx.Model.PBnet_Bulletin model)
        {
            if (!model.BitIsPass)
            {
                if (!string.IsNullOrEmpty(model.SavePath))
                {
                    string htmlPath = System.Web.HttpContext.Current.Server.MapPath(model.SavePath);
                    if (File.Exists(htmlPath))
                    {
                        File.Delete(htmlPath);
                    }
                }
            }
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
        public Pbzx.Model.PBnet_Bulletin GetModel(int IntID)
        {

            return dal.GetModel(IntID);
        }
        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public Pbzx.Model.PBnet_Bulletin GetModelByCache(int IntID)
        {

            string CacheKey = "PBnet_BulletinModel-" + IntID;
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
            return (Pbzx.Model.PBnet_Bulletin)objModel;
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
        public List<Pbzx.Model.PBnet_Bulletin> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.PBnet_Bulletin> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.PBnet_Bulletin> modelList = new List<Pbzx.Model.PBnet_Bulletin>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_Bulletin model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_Bulletin();
                    if (dt.Rows[n]["IntID"].ToString() != "")
                    {
                        model.IntID = int.Parse(dt.Rows[n]["IntID"].ToString());
                    }
                    model.NvarTitle = dt.Rows[n]["NvarTitle"].ToString();
                    model.NvarShortTitle = dt.Rows[n]["NvarShortTitle"].ToString();
                    model.NteContent = dt.Rows[n]["NteContent"].ToString();
                    model.NvarAuthor = dt.Rows[n]["NvarAuthor"].ToString();
                    if (dt.Rows[n]["DatDateAndTime"].ToString() != "")
                    {
                        model.DatDateAndTime = DateTime.Parse(dt.Rows[n]["DatDateAndTime"].ToString());
                    }
                    if (dt.Rows[n]["IntChannelID"].ToString() != "")
                    {
                        model.IntChannelID = int.Parse(dt.Rows[n]["IntChannelID"].ToString());
                    }
                    if (dt.Rows[n]["IntShowType"].ToString() != "")
                    {
                        model.IntShowType = int.Parse(dt.Rows[n]["IntShowType"].ToString());
                    }
                    if (dt.Rows[n]["BitIsPass"].ToString() != "")
                    {
                        if ((dt.Rows[n]["BitIsPass"].ToString() == "1") || (dt.Rows[n]["BitIsPass"].ToString().ToLower() == "true"))
                        {
                            model.BitIsPass = true;
                        }
                        else
                        {
                            model.BitIsPass = false;
                        }
                    }
                    if (dt.Rows[n]["BitIsTop"].ToString() != "")
                    {
                        if ((dt.Rows[n]["BitIsTop"].ToString() == "1") || (dt.Rows[n]["BitIsTop"].ToString().ToLower() == "true"))
                        {
                            model.BitIsTop = true;
                        }
                        else
                        {
                            model.BitIsTop = false;
                        }
                    }
                    model.IntDisPosition = dt.Rows[n]["IntDisPosition"].ToString();
                    if (dt.Rows[n]["IntClick"].ToString() != "")
                    {
                        model.IntClick = int.Parse(dt.Rows[n]["IntClick"].ToString());
                    }
                    model.VarPicUrl = dt.Rows[n]["VarPicUrl"].ToString();
                    model.VarOperator = dt.Rows[n]["VarOperator"].ToString();
                    if (dt.Rows[n]["IntOrderID"].ToString() != "")
                    {
                        model.IntOrderID = int.Parse(dt.Rows[n]["IntOrderID"].ToString());
                    }
                    if (dt.Rows[n]["BitIsHot"].ToString() != "")
                    {
                        if ((dt.Rows[n]["BitIsHot"].ToString() == "1") || (dt.Rows[n]["BitIsHot"].ToString().ToLower() == "true"))
                        {
                            model.BitIsHot = true;
                        }
                        else
                        {
                            model.BitIsHot = false;
                        }
                    }
                    model.NKey = dt.Rows[n]["NKey"].ToString();
                    model.Metadesc = dt.Rows[n]["Metadesc"].ToString();
                    model.Source = dt.Rows[n]["Source"].ToString();
                    model.SourceUrl = dt.Rows[n]["SourceUrl"].ToString();
                    model.Attribute = dt.Rows[n]["Attribute"].ToString();
                    model.RandomFileName = dt.Rows[n]["RandomFileName"].ToString();
                    if (dt.Rows[n]["EffectDate"].ToString() != "")
                    {
                        model.EffectDate = DateTime.Parse(dt.Rows[n]["EffectDate"].ToString());
                    }
                    model.Templet = dt.Rows[n]["Templet"].ToString();
                    model.SavePath = dt.Rows[n]["SavePath"].ToString();
                    model.FileEXName = dt.Rows[n]["FileEXName"].ToString();
                    if (dt.Rows[n]["IsStatic"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IsStatic"].ToString() == "1") || (dt.Rows[n]["IsStatic"].ToString().ToLower() == "true"))
                        {
                            model.IsStatic = true;
                        }
                        else
                        {
                            model.IsStatic = false;
                        }
                    }
                    if (dt.Rows[n]["PageNum"].ToString() != "")
                    {
                        model.PageNum = int.Parse(dt.Rows[n]["PageNum"].ToString());
                    }
                    if (dt.Rows[n]["ShowIndex"].ToString() != "")
                    {
                        if ((dt.Rows[n]["ShowIndex"].ToString() == "1") || (dt.Rows[n]["ShowIndex"].ToString().ToLower() == "true"))
                        {
                            model.ShowIndex = true;
                        }
                        else
                        {
                            model.ShowIndex = false;
                        }
                    }
                    if (dt.Rows[n]["ShowInSoft"].ToString() != "")
                    {
                        if ((dt.Rows[n]["ShowInSoft"].ToString() == "1") || (dt.Rows[n]["ShowInSoft"].ToString().ToLower() == "true"))
                        {
                            model.ShowInSoft = true;
                        }
                        else
                        {
                            model.ShowInSoft = false;
                        }
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

        public DataTable GuestGetBySearch(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "PBnet_Bulletin", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }


        /// <summary>
        /// ���ݣɣ�����ɾ��ɾ������
        /// </summary>
        /// <param name="strID"></param>
        /// <returns></returns>
        public int BatchDel(string strID)
        {
            string[] ids = strID.Split(new char[] { ',' });


            foreach (string id in ids)
            {
                int IntID = 0;
                if (int.TryParse(id, out IntID))
                {
                    if (!string.IsNullOrEmpty(GetModel(IntID).SavePath))
                    {
                        string htmlPath = System.Web.HttpContext.Current.Server.MapPath(GetModel(IntID).SavePath);
                        if (File.Exists(htmlPath))
                        {
                            File.Delete(htmlPath);
                        }
                    }
                }
            }
            string sql = "DELETE FROM PBnet_Bulletin WHERE IntID IN(" + strID + ")";
            return dal.ExecuteBySql(sql);
        }

        /// <summary>
        /// ���ݣɣ�����ɾ��html�ļ�
        /// </summary>
        /// <param name="strID"></param>
        /// <returns></returns>
        public int BatchDelHtml(string strID)
        {
            string[] ids = strID.Split(new char[] { ',' });

            int DelCount = 0;
            foreach (string id in ids)
            {
                int IntID = 0;
                if (int.TryParse(id, out IntID))
                {
                    if (!string.IsNullOrEmpty(GetModel(IntID).SavePath))
                    {
                        string htmlPath = System.Web.HttpContext.Current.Server.MapPath(GetModel(IntID).SavePath);
                        if (File.Exists(htmlPath))
                        {
                            File.Delete(htmlPath);
                            DelCount++;
                        }
                    }
                }
            }
            return DelCount;
        }

        /// <summary>
        /// ���ݣɣ�������������
        /// </summary>
        /// <param name="strID"></param>
        /// <returns></returns>
        public int BatchUpdate(string strID, string column, bool isTrue)
        {
            int i = isTrue ? 1 : 0;
            if (!isTrue && column == "BitIsPass")
            {
                string[] ids = strID.Split(new char[] { ',' });
                foreach (string id in ids)
                {
                    int IntID = 0;
                    if (int.TryParse(id, out IntID))
                    {
                        if (!string.IsNullOrEmpty(GetModel(IntID).SavePath))
                        {
                            string htmlPath = System.Web.HttpContext.Current.Server.MapPath(GetModel(IntID).SavePath);
                            if (File.Exists(htmlPath))
                            {
                                File.Delete(htmlPath);
                            }
                        }
                    }
                }
            }
            string sql = "update PBnet_Bulletin set " + column + "=" + i + " WHERE IntID IN(" + strID + ")";
            return dal.ExecuteBySql(sql);
        }
        public DataTable GetTitleListByCount(string strWhere, int count)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top " + count + " IntID,NvarTitle,NvarShortTitle,NteContent,NvarAuthor,DatDateAndTime,IntChannelID,IntShowType,BitIsPass,BitIsTop,BitIsHot,IntDisPosition,IntClick,VarPicUrl,VarOperator,IntOrderID,NKey,Metadesc,Source,SourceUrl,Attribute,RandomFileName,EffectDate,Templet,SavePath,FileEXName,IsStatic,PageNum ");
            strSql.Append(" FROM PBnet_Bulletin ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return dal.Query(strSql.ToString());
        }
        public int GetInsertID()
        {

            return Convert.ToInt32(basicDAL.GetValue("TOP 1 IntNewsTypeID", "", " IntNewsTypeID DESC"));
        }

        /// <summary>
        /// ����Bool�����ֶ�״̬
        /// </summary>
        /// <param name="id">���</param>
        /// <param name="filed">�ֶ���</param>
        public static void ChangeAudit(int id, string filed)
        {
            Pbzx.SQLServerDAL.Basic basicDAL1 = new Pbzx.SQLServerDAL.Basic("PBnet_Bulletin", "IntID");
            basicDAL1.ChangeAudit(id, filed);
        }



        #region ���ɾ�̬ҳ

        /// <summary>
        /// ���Ŵ���
        /// </summary>
        /// <param name="moduleinfo">������Ϣ</param>
        /// <returns>��������ID</returns>
        public int ArticleCreate(Pbzx.Model.PBnet_Bulletin articleinfo)
        {
            int res = 0;
            try
            {
                //��ȡ��ҳ����
                Pbzx.BLL.PBnet_PaginAtion bpa = new Pbzx.BLL.PBnet_PaginAtion();

                string[] ContentStr = bpa.PaginationContent(articleinfo.NteContent);
                if (ContentStr != null)
                {
                    articleinfo.PageNum = ContentStr.Length;
                }
                //��ȡ����ļ���
                articleinfo.RandomFileName = BasicProcedure.RandomCreateFileName(0);
                //��������
                articleinfo.IntID = dal.Add(articleinfo);
                //������ҳ
                ArticleCreatePaginAtion(articleinfo);
                //���������ļ�
                if (!articleinfo.IsStatic)
                {
                    CreateContentFileByTemplate(articleinfo.IntID);
                }
                res = articleinfo.IntID;
            }
            catch (Exception)
            {
                res = 0;
            }
            return res;
        }

        /// <summary>
        /// ���ű༭
        /// </summary>
        /// <param name="moduleinfo">Ƶ����Ϣ</param>
        /// <returns>����bool</returns>
        public bool ArticleUpdate(Pbzx.Model.PBnet_Bulletin articleinfo)
        {

            bool flag = true;
            //try
            //{
            Pbzx.BLL.PBnet_PaginAtion bpa = new Pbzx.BLL.PBnet_PaginAtion();
            //ɾ�������ļ�
            ArticleDeleteFile(articleinfo.IntID);
            //ɾ����ҳ����
            bpa.PaginationDelete(articleinfo.IntID, EModuleType.Bulletins);
            //��������
            string[] ContentStr = bpa.PaginationContent(articleinfo.NteContent);
            if (ContentStr != null)
            {
                articleinfo.PageNum = ContentStr.Length;
            }
            dal.Update(articleinfo);
            //��������
            ArticleCreatePaginAtion(articleinfo);
            //���������ļ�
            CreateContentFileByTemplate(articleinfo.IntID);
            //}
            //catch (Exception)
            //{
            //    flag = false;
            //}
            return flag;
        }

        /// <summary>
        /// ��������IDɾ��
        /// </summary>
        /// <param name="moduleinfo">ģ����Ϣ</param>
        /// <returns>����bool</returns>
        public bool ArticleDelete(int articleID)
        {
            bool flag = true;
            try
            {
                Pbzx.BLL.PBnet_PaginAtion bpa = new Pbzx.BLL.PBnet_PaginAtion();
                //ɾ�������ļ�
                ArticleDeleteFile(articleID);
                //ɾ����ҳ����
                bpa.PaginationDelete(articleID, EModuleType.Bulletins);
                //ɾ�������ļ�
                dal.Delete(articleID);
            }
            catch (Exception)
            {
                flag = false;
            }
            return flag;
        }

        /// <summary>
        /// ����ɾ������
        /// </summary>
        /// <param name="articleID">����ID��","Ϊ�ָ���)</param>
        public void ArticleDelete(string articleID)
        {
            try
            {
                if (!string.IsNullOrEmpty(articleID))
                {
                    string[] articleIDs = articleID.Split(new char[] { ',' });

                    for (int i = 0; i < articleIDs.Length; i++)
                    {
                        ArticleDelete(Convert.ToInt32(articleIDs[i].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// ����ģ��IDɾ������
        /// </summary>
        /// <param name="moduleid">ģ��ID</param>
        /// <returns>����bool</returns>
        public bool ArticleDeleteByModuleID(int moduleid)
        {

            bool flag = true;
            try
            {
                IList<Pbzx.Model.PBnet_Bulletin> ais = ArticleGetByModuleID(moduleid);
                if (ais.Count > 0)
                {
                    foreach (Pbzx.Model.PBnet_Bulletin ai in ais)
                    {
                        ArticleDelete(ai.IntID);
                    }
                }
            }
            catch (Exception ex)
            {
                flag = false;
            }
            return flag;

        }

        /// <summary>
        /// ��ȡȫ��
        /// </summary>
        /// <returns></returns>
        public List<Pbzx.Model.PBnet_Bulletin> ArticleGetAll()
        {
            try
            {
                return DataTableToList(dal.GetList("").Tables[0]);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// ��������ID��ȡ����
        /// </summary>
        /// <param name="ArticleID">����ID</param>
        /// <returns></returns>
        public Pbzx.Model.PBnet_Bulletin ArticleGetByID(int ArticleID)
        {
            try
            {
                return dal.GetModel(ArticleID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// ����ģ��ID��ȡ����
        /// </summary>
        /// <param name="ModuleID">ģ��ID</param>
        /// <returns></returns>
        public List<Pbzx.Model.PBnet_Bulletin> ArticleGetByModuleID(int ModuleID)
        {
            try
            {
                return DataTableToList(dal.GetList(" IntShowType='" + ModuleID + "'").Tables[0]);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        /// <summary>
        /// ���ݹؼ��ֻ�ȡ����
        /// </summary>
        /// <param name="NKeyStr">�ؼ��ַ���</param>
        /// <returns></returns>
        public List<Pbzx.Model.PBnet_Bulletin> ArticleGetByNKey(string NKeyStr)
        {
            try
            {
                return DataTableToList(dal.GetList(" NKey like'%" + NKeyStr + "%'").Tables[0]);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// ���ݲ�ѯ�ַ�����ȡ��ҳ����
        /// </summary>
        /// <param name="TableName">����</param>
        /// <param name="SearchStr">��ѯ�ַ���</param>
        /// <param name="getFileds">��ȡ��</param>
        /// <param name="OrderStr">�����ֶ�</param>
        /// <param name="PageNum">��ȡ��������</param>
        /// <param name="CurrentPage">��ǰ��ҳ��</param>
        /// <param name="Counts">���ؼ�¼������</param>
        /// <returns></returns>
        public List<Pbzx.Model.PBnet_Bulletin> ArticleGetBySearch(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            try
            {
                return DataTableToList(basicDAL.GuestGetBySearch(basicDAL.strPKName, "PBnet_Bulletin", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts));
            }
            catch (Exception ex)
            {
                Counts = 0;
                return null;
            }
        }




        /// <summary>
        /// ���ű�־(Ϊbit����)ȡ��
        /// </summary>
        /// <param name="FlagField">��־�ֶ���</param>
        /// <param name="id">����ID</param>
        public void ArticleFlagUpdate(string FlagField, int id)
        {
            try
            {
                ChangeAudit(id, FlagField);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// ���
        /// </summary>
        /// <param name="FlagField"></param>
        /// <param name="id"></param>
        public void ArticleAudit(int id)
        {
            try
            {
                ArticleFlagUpdate("BitIsPass", id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        //������ҳ����
        public void ArticleCreatePaginAtion(Pbzx.Model.PBnet_Bulletin articleinfo)
        {
            try
            {
                Pbzx.BLL.PBnet_PaginAtion bpa = new Pbzx.BLL.PBnet_PaginAtion();
                Pbzx.BLL.PBnet_BulletinType bc = new PBnet_BulletinType();

                string ArticleUrl = ((DateTime)articleinfo.DatDateAndTime).Year.ToString() + "/" + ((DateTime)articleinfo.DatDateAndTime).Month.ToString() + "/"; //bc.ChannelGetFolder((int)articleinfo.IntShowType);
                for (int i = 1; i <= articleinfo.PageNum; i++)
                {
                    Pbzx.Model.PBnet_PaginAtion pai = new Pbzx.Model.PBnet_PaginAtion();

                    pai.ID = articleinfo.IntID;
                    pai.FileName = articleinfo.RandomFileName + i + ".htm";
                    pai.PhysicPath = BasicProcedure.PhysicalApplicationPath + WebInit.webFolderConfig.BulletinUrl + ArticleUrl + pai.FileName;
                    pai.FilePath = WebInit.webBaseConfig.WebUrl + WebInit.webFolderConfig.BulletinUrl + ArticleUrl + pai.FileName;
                    pai.PageNo = i;
                    pai.Suffix = ".htm";
                    pai.PageType = (int)EModuleType.Bulletins;
                    bpa.PaginationCreate(pai);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //ɾ����ҳ����
        public void ArticleDeleteFile(int Articleid)
        {
            try
            {
                BTemplate bt = new BTemplate();
                Pbzx.BLL.PBnet_PaginAtion bpa = new Pbzx.BLL.PBnet_PaginAtion();
                IList<Pbzx.Model.PBnet_PaginAtion> pais = bpa.PaginationGet(Articleid, EModuleType.Bulletins);
                if (pais.Count > 0)
                {
                    foreach (Pbzx.Model.PBnet_PaginAtion pai in pais)
                    {
                        bt.DeleteFile(pai.PhysicPath);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// ���������ļ�
        /// </summary>
        /// <param name="Articleid">�ļ�ID�������","����</param>
        public void CreateContentFileByTemplate(string Articleid)
        {
            try
            {
                if (!string.IsNullOrEmpty(Articleid))
                {
                    string[] articleIDs = Articleid.Split(new char[] { ',' });

                    for (int i = 0; i < articleIDs.Length; i++)
                    {
                        ArticleUpdate(dal.GetModel(int.Parse(articleIDs[i])));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// ȫ�������ļ�
        /// </summary>
        public void CreateAllArticleFile()
        {
            try
            {
                List<Pbzx.Model.PBnet_Bulletin> ais = ArticleGetAll();
                if (ais.Count > 0)
                {
                    foreach (Pbzx.Model.PBnet_Bulletin ai in ais)
                    {
                        ArticleUpdate(ai);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// ����ģ����������
        /// </summary>
        /// <param name="TemplateFile">ģ���ַ</param>
        /// <param name="CreateFile">���ɵ�ַ</param>
        /// <param name="articleInfo">������Ϣ</param>
        public void CreateContentFileByTemplate(int Articleid)
        {
            try
            {
                Pbzx.BLL.PBnet_Bulletin newsBLL = new PBnet_Bulletin();
                Pbzx.Model.PBnet_Bulletin articleInfo = ArticleGetByID(Articleid);
                BTemplate bt = new BTemplate();
                Pbzx.BLL.PBnet_PaginAtion bpa = new Pbzx.BLL.PBnet_PaginAtion();
                Pbzx.BLL.PBnet_BulletinType bc = new PBnet_BulletinType();
                //ģ���ַ
                string TemplateFile = BasicProcedure.PhysicalApplicationPath + "/" + WebInit.webFolderConfig.TemplateUrl + "/" + "BulletinShow.htm";
                //�ļ���ַ

                string CreateFile = BasicProcedure.PhysicalApplicationPath + "/" + WebInit.webFolderConfig.BulletinUrl + ((DateTime)articleInfo.DatDateAndTime).Year.ToString() + "/" + ((DateTime)articleInfo.DatDateAndTime).Month + "/"; //bc.ChannelGetFolder((int)articleInfo.IntShowType)

                if (articleInfo.IsStatic)
                    ArticleDeleteFile(Articleid);

                //���±�־λ
                if (!articleInfo.IsStatic)
                {
                    // ArticleFlagUpdate("IsStatic", articleInfo.IntID);
                    articleInfo.IsStatic = true;
                }
                if (string.IsNullOrEmpty(articleInfo.RandomFileName))
                {
                    articleInfo.RandomFileName = BasicProcedure.RandomCreateFileName(0);
                    Pbzx.BLL.PBnet_PaginAtion PA = new Pbzx.BLL.PBnet_PaginAtion();
                    //ɾ�������ļ�
                    ArticleDeleteFile(articleInfo.IntID);
                    //ɾ����ҳ����
                    PA.PaginationDelete(articleInfo.IntID, EModuleType.Bulletins);
                    //��������
                    string[] ContentStr = PA.PaginationContent(articleInfo.NteContent);
                    if (ContentStr != null)
                    {
                        articleInfo.PageNum = ContentStr.Length;
                    }
                    dal.Update(articleInfo);
                    //��������
                    ArticleCreatePaginAtion(articleInfo);
                }

                //�滻���ݱ�ǩ
                string TemplateContent = ReplaceLabel(bt.GetTemplateContent(TemplateFile), articleInfo);
                if (articleInfo.PageNum == null)
                {
                    articleInfo.PageNum = 1;
                }

                //�����Ϣû�з�ҳ
                if (articleInfo.PageNum == 1)
                {
                    TemplateContent = TemplateContent.Replace("{$Content$}", articleInfo.NteContent);
                    TemplateContent = TemplateContent.Replace("{$NextPage$}", "");
                    if (bpa.PaginationGet(articleInfo.IntID, EModuleType.Bulletins).Count < 1)
                    {
                        string[] ContentStr = bpa.PaginationContent(articleInfo.NteContent);
                        if (ContentStr != null)
                        {
                            articleInfo.PageNum = ContentStr.Length;
                        }
                        ArticleCreatePaginAtion(articleInfo);
                    }
                    List<Pbzx.Model.PBnet_PaginAtion> pai = bpa.PaginationGet(articleInfo.IntID, EModuleType.Bulletins);
                    bt.CreateFile(CreateFile + pai[0].FileName, TemplateContent);
                    articleInfo.SavePath = "/" + WebInit.webFolderConfig.BulletinUrl + ((DateTime)articleInfo.DatDateAndTime).Year.ToString() + "/" + ((DateTime)articleInfo.DatDateAndTime).Month + "/" + pai[0].FileName;
                    articleInfo.Templet = TemplateFile;
                    newsBLL.Update(articleInfo);
                }
                else//�����Ϣ�з�ҳ
                {
                    //��ȡ��ҳ����
                    string[] Contents = bpa.PaginationContent(articleInfo.NteContent);
                    //��ȡ��ҳ��Ϣ
                    if (bpa.PaginationGet(articleInfo.IntID, EModuleType.Bulletins).Count < 1)
                    {
                        if (Contents != null)
                        {
                            articleInfo.PageNum = Contents.Length;
                        }
                        ArticleCreatePaginAtion(articleInfo);
                    }
                    List<Pbzx.Model.PBnet_PaginAtion> pai = bpa.PaginationGet(articleInfo.IntID, EModuleType.Bulletins);
                    ArrayList stringPages = new ArrayList();
                    for (int i = 0; i < pai.Count; i++)
                    {
                        stringPages.Add(pai[i].FilePath);
                    }
                    //���ɷ�ҳ�ļ�
                    for (int i = 1; i <= articleInfo.PageNum; i++)
                    {
                        string nextpage = bpa.CreatePagination(stringPages, i, (int)articleInfo.PageNum, "pagination", "disablepage", "currentpage", "nextpage");
                        string tc = TemplateContent.Replace("{$NextPage$}", nextpage);
                        tc = tc.Replace("{$Content$}", Contents[i - 1].ToString());
                        //������ҳ�ļ�
                        bt.CreateFile(CreateFile + pai[i - 1].FileName.ToString(), tc);
                        articleInfo.SavePath = "/" + WebInit.webFolderConfig.BulletinUrl + ((DateTime)articleInfo.DatDateAndTime).Year.ToString() + "/" + ((DateTime)articleInfo.DatDateAndTime).Month + "/" + pai[i - 1].FileName;
                        articleInfo.Templet = TemplateFile;
                        newsBLL.Update(articleInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// �滻��ǩ
        /// </summary>
        /// <param name="TemplateContent"></param>
        /// <returns></returns>
        public string ReplaceLabel(string TemplateContent, Pbzx.Model.PBnet_Bulletin articleInfo)
        {
            if (!string.IsNullOrEmpty(articleInfo.VarPicUrl))
            {
                TemplateContent = TemplateContent.Replace("{$myImg$}", "<img src='" + articleInfo.VarPicUrl + "' alt='" + articleInfo.NvarTitle + "ͼƬ' />");
            }
            else
            {
                TemplateContent = TemplateContent.Replace("{$myImg$}", "");
            }
            TemplateContent = TemplateContent.Replace("{$Title$}", articleInfo.NvarTitle);
            TemplateContent = TemplateContent.Replace("{$DateAndTime$}", ((DateTime)articleInfo.DatDateAndTime).ToString("yyyy-MM-dd HH:mm").ToString());
            TemplateContent = TemplateContent.Replace("{$Author$}", articleInfo.NvarAuthor);
            TemplateContent = TemplateContent.Replace("{$SourceUrl$}", articleInfo.SourceUrl);
            TemplateContent = TemplateContent.Replace("{$Source$}", articleInfo.Source);
            TemplateContent = TemplateContent.Replace("{$Summary$}", articleInfo.Metadesc);
            TemplateContent = TemplateContent.Replace("{$Keywords$}", articleInfo.NKey);
            TemplateContent = TemplateContent.Replace("{$Copyright$}", articleInfo.NKey);
            TemplateContent = TemplateContent.Replace("{$click$}", articleInfo.IntClick.ToString());
            TemplateContent = TemplateContent.Replace("{$id$}", articleInfo.IntID.ToString());
            //
            Pbzx.BLL.PBnet_BulletinType bc = new PBnet_BulletinType();

            string hot = bc.ChannelGetNavigation((int)articleInfo.IntShowType, true, " >> ");
            TemplateContent = TemplateContent.Replace("{$Article_hot$}", hot);
            TemplateContent = TemplateContent.Replace("{$CssUrl$}", WebInit.webBaseConfig.WebUrl + WebInit.webFolderConfig.ArticleUrl + "shownews/shownews.css");
            string tempUrl = WebInit.webBaseConfig.WebUrl;

            //if (articleInfo.VarPicUrl != null && articleInfo.VarPicUrl != "" && articleInfo.VarPicUrl.Trim().Length > 0) 
            //{
            //    TemplateContent = TemplateContent.Replace("{$SinaWiki}", "<a href=\"javascript:void((function(s,d,e,r,l,p,t,z,c){var%20f='http://v.t.sina.com.cn/share/share.php?appkey=3374168135',u=z||d.location,p=['&url=',e(u),'&title=',e(t||d.title),'&source=',e(r),'&sourceUrl=',e(l),'&content=',c||'gb2312','&pic=',e(p||'')].join('');function%20a(){if(!window.open([f,p].join(''),'mb',['toolbar=0,status=0,resizable=1,width=440,height=430,left=',(s.width-440)/2,',top=',(s.height-430)/2].join('')))u.href=[f,p].join('');};if(/Firefox/.test(navigator.userAgent))setTimeout(a,0);else%20a();})(screen,document,encodeURIComponent,'','','" + tempUrl.Substring(0, tempUrl.Length - 1) + articleInfo.VarPicUrl + "','','','utf-8'));\"><img src='/Images/Web/SinaWiki.jpg' border='0' >����������΢��</a> ");
            //}
            //else
            //{
//            TemplateContent = TemplateContent.Replace("{$SinaWiki}", "<a href=\"javascript:void((function(s,d,e,r,l,p,t,z,c){var%20f='http://v.t.sina.com.cn/share/share.php?appkey=3374168135',u=z||d.location,p=['&url=',e(u),'&title=',e(t||d.title),'&source=',e(r),'&sourceUrl=',e(l),'&content=',c||'gb2312','&pic=',e(p||'')].join('');function%20a(){if(!window.open([f,p].join(''),'mb',['toolbar=0,status=0,resizable=1,width=440,height=430,left=',(s.width-440)/2,',top=',(s.height-430)/2].join('')))u.href=[f,p].join('');};if(/Firefox/.test(navigator.userAgent))setTimeout(a,0);else%20a();})(screen,document,encodeURIComponent,'','','" + ConfigurationManager.AppSettings["SinaPic_Path"] + "','','','utf-8'));\"><img src='/Images/Web/SinaWiki.jpg' border='0' >����������΢��</a> ");
            TemplateContent = TemplateContent.Replace("{$SinaWiki}", "");
            //  }
            return TemplateContent;
        }
        #endregion

    }
}

