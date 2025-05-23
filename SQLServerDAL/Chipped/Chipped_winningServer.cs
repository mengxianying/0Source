using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.IDAL;
using System.Data;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using Pbzx.Model;

namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// ���ݷ�����Chipped_winning��
    /// </summary>
    public class Chipped_winning : IChipped_winning
    {
        public Chipped_winning()
        { }
        #region  ��Ա����

        /// <summary>
        /// �õ����ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "Chipped_winning");
        }
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(string Qnum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Chipped_winning");
            strSql.Append(" where Qnum= @Qnum");
            SqlParameter[] parameters = {
					new SqlParameter("@Qnum", SqlDbType.NVarChar,50)
				};
            parameters[0].Value = Qnum;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Pbzx.Model.Chipped_winning model)
        {
            model.ID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Chipped_winning(");
            strSql.Append("RNumber,winningNum,bonus)");
            strSql.Append(" values (");
            strSql.Append("@RNumber,@winningNum,@bonus)");
            SqlParameter[] parameters = {
					new SqlParameter("@RNumber", SqlDbType.NVarChar),
					new SqlParameter("@winningNum", SqlDbType.NVarChar),
					new SqlParameter("@bonus", SqlDbType.Decimal,9)};
            parameters[0].Value = model.RNumber;
            parameters[1].Value = model.winningNum;
            parameters[2].Value = model.bonus;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            return model.ID;
        }
        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(Pbzx.Model.Chipped_winning model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Chipped_winning set ");
            strSql.Append("RNumber=@RNumber,");
            strSql.Append("winningNum=@winningNum,");
            strSql.Append("bonus=@bonus");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@RNumber", SqlDbType.NVarChar),
					new SqlParameter("@winningNum", SqlDbType.NVarChar),
					new SqlParameter("@bonus", SqlDbType.Decimal,9)};
            parameters[0].Value = model.RNumber;
            parameters[1].Value = model.winningNum;
            parameters[2].Value = model.bonus;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Chipped_winning ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
				};
            parameters[0].Value = ID;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.Chipped_winning GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Chipped_winning ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;
            Pbzx.Model.Chipped_winning model = new Pbzx.Model.Chipped_winning();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.RNumber = ds.Tables[0].Rows[0]["RNumber"].ToString();
                model.winningNum = ds.Tables[0].Rows[0]["winningNum"].ToString();
                if (ds.Tables[0].Rows[0]["bonus"].ToString() != "")
                {
                    model.bonus = decimal.Parse(ds.Tables[0].Rows[0]["bonus"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Chipped_winning ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ID ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  ��Ա����
    }
}
