using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Pbzx.IDAL;
using Pbzx.DALFactory;

namespace Pbzx.BLL
{
    /// <summary>
    /// ҵ���߼���Note_Customize ��ժҪ˵����
    /// </summary>
    public class Note_Customize
    {
        private static readonly INote_Customize dal = DataAccess.CreateNote_Customize();
        public Note_Customize()
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
        public int Add(Pbzx.Model.Note_Customize model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Update(Pbzx.Model.Note_Customize model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public int Delete(int ID)
        {
            return dal.Delete(ID);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.Note_Customize GetModel(int ID)
        {
            return dal.GetModel(ID);
        }

        public Pbzx.Model.Note_Customize GetModel(int sid, string username)
        {
            return dal.GetModel(sid, username);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList()
        {
            return dal.GetList("");
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.Note_Customize> GetByList(string strwhere)
        {
            return DataTableToList(dal.GetList(strwhere).Tables[0]);
        }

        public List<Pbzx.Model.Note_Customize> GetModelByName(string username)
        {
            return dal.GetModelByName(username);
        }
        /// <summary>
        /// ���������õ������б�
        /// </summary>
        /// <param name="username">�û���</param>
        /// <returns></returns>
        public List<Pbzx.Model.Note_Customize> GetModelBySid(int sid)
        {
            return dal.GetModelBySid(sid);
        }



        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.Note_Customize> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.Note_Customize> modelList = null;
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                modelList = new List<Pbzx.Model.Note_Customize>();
                Pbzx.Model.Note_Customize model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.Note_Customize();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    model.SID = Convert.ToInt32(dt.Rows[n]["SID"].ToString());

                    model.Phone = dt.Rows[n]["Phone"].ToString();
                    model.UserName = dt.Rows[n]["UserName"].ToString();
                    model.Price = Convert.ToDecimal(dt.Rows[n]["Price"].ToString());
                    model.BeginTime = Convert.ToDateTime(dt.Rows[n]["BeginTime"].ToString());
                    model.EndTime = Convert.ToDateTime(dt.Rows[n]["EndTime"].ToString());
                    model.ContinuationType = Convert.ToInt32(dt.Rows[n]["ContinuationType"].ToString());
                    model.Status = Convert.ToInt32(dt.Rows[n]["Status"].ToString());
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion  ��Ա����
    }
}
