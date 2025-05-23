using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Configuration;

namespace Maticsoft.DBUtility
{

    /// <summary>
    /// SqlHelper����sql���ݲ���
    /// </summary>
    public abstract class SQLHelper
    {

        //���ݿ������ַ���
        private static string _connectionString = ConfigurationManager.AppSettings["ConnectionString"];

        public static string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        // ��������Դ
     //   public static SqlConnection con;



        ///// <summary>
        ///// �����ݿ�����.
        ///// </summary>
        //public static void Open()
        //{
        //    // �����ݿ�����
        //    if (con == null)
        //    {
        //        con = new SqlConnection(ConnectionString);
        //    }
        //    if (con.State == System.Data.ConnectionState.Closed)
        //        con.Open();
        //}

        // ���ڻ��������HASH��
        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());

        /// <summary>
        ///  �������ӵ����ݿ��ü������ִ��һ��sql������������ݼ���
        /// </summary>
        /// <param name="connectionString">һ����Ч�������ַ���</param>
        /// <param name="commandType">��������(�洢����, �ı�, �ȵ�)</param>
        /// <param name="commandText">�洢�������ƻ���sql�������</param>
        /// <param name="commandParameters">ִ���������ò����ļ���</param>
        /// <returns>ִ��������Ӱ�������</returns>
        public static int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    using(SqlCommand cmd = new SqlCommand())
                    {
                        if (cmdText.ToUpper().IndexOf("[PINBLE_WEB]") < 0 && cmdText.ToUpper().IndexOf("[PINBLE_CST]") < 0 && cmdText.ToUpper().IndexOf("SP_") >= 0 && !string.IsNullOrEmpty(cmdText))
                        {
                            cmdText = "[Pinble_Web].dbo." + cmdText;
                        }
                        conn.Open();
                        PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                        int val = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return val;
                    }

                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    conn.Close();
                    conn.Dispose();
                    throw new Exception(ex.Message);
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }

        /// <summary>
        /// �����е����ݿ�����ִ��һ��sql������������ݼ���
        /// </summary>
        /// <param name="conn">һ�����е����ݿ�����</param>
        /// <param name="commandType">��������(�洢����, �ı�, �ȵ�)</param>
        /// <param name="commandText">�洢�������ƻ���sql�������</param>
        /// <param name="commandParameters">ִ���������ò����ļ���</param>
        /// <returns>ִ��������Ӱ�������</returns>
        public static int ExecuteNonQuery(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            //string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            using (SqlConnection connection1 = new SqlConnection(ConnectionString))
            {
                try
                {
                    using( SqlCommand cmd = new SqlCommand())
                    {
                        connection1.Open();
                        PrepareCommand(cmd, connection1, null, cmdType, cmdText, commandParameters);
                        int val = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return val;    
                    }
                   

                 }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    connection1.Close();
                    connection1.Dispose();
                    throw new Exception(ex.Message);
                }
                finally
                {
                    connection1.Close();
                    connection1.Dispose();
                }
            }
        }

        /// <summary>
        ///ʹ�����е�SQL����ִ��һ��sql������������ݼ���
        /// </summary>
        /// <remarks>
        ///����:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="trans">һ�����е�����</param>
        /// <param name="commandType">��������(�洢����, �ı�, �ȵ�)</param>
        /// <param name="commandText">�洢�������ƻ���sql�������</param>
        /// <param name="commandParameters">ִ���������ò����ļ���</param>
        /// <returns>ִ��������Ӱ�������</returns>
        public static int ExecuteNonQuery(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            using(SqlCommand cmd = new SqlCommand())
            {
                 PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                
                cmd.Parameters.Clear();
                return val;
            }
            

        }

        /// <summary>
        /// ��ִ�е����ݿ�����ִ��һ���������ݼ���sql����
        /// </summary>
        /// <remarks>
        /// ����:  
        ///  SqlDataReader r = ExecuteReader(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">һ����Ч�������ַ���</param>
        /// <param name="commandType">��������(�洢����, �ı�, �ȵ�)</param>
        /// <param name="commandText">�洢�������ƻ���sql�������</param>
        /// <param name="commandParameters">ִ���������ò����ļ���</param>
        /// <returns>��������Ķ�ȡ��</returns>
        public static SqlDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            //����һ��SqlCommand����
            SqlCommand cmd = new SqlCommand();
            //����һ��SqlConnection����
            SqlConnection conn = new SqlConnection(connectionString);

            //������������һ��try/catch�ṹִ��sql�ı�����/�洢���̣���Ϊ��������������һ���쳣����Ҫ�ر����ӣ���Ϊû�ж�ȡ�����ڣ�
            //���commandBehaviour.CloseConnection �Ͳ���ִ��
            try
            {
                if (cmdText.ToUpper().IndexOf("[PINBLE_WEB]") < 0 && cmdText.ToUpper().IndexOf("[PINBLE_CST]") < 0 && cmdText.ToUpper().IndexOf("SP_") >= 0 && !string.IsNullOrEmpty(cmdText))
                {
                    cmdText = "[Pinble_Web].dbo." + cmdText;
                }
                //���� PrepareCommand �������� SqlCommand �������ò���
                conn.Open();
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                //���� SqlCommand  �� ExecuteReader ����
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //�������
                cmd.Parameters.Clear();
                return reader;
            }
            catch
            {
                //�ر����ӣ��׳��쳣
                conn.Close();
                conn.Dispose();
                throw;
            }
        }

        /// <summary>
        /// ��ָ�������ݿ������ַ���ִ��һ���������һ�����ݼ��ĵ�һ��
        /// </summary>
        /// <remarks>
        ///����:  
        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        ///<param name="connectionString">һ����Ч�������ַ���</param>
        /// <param name="commandType">��������(�洢����, �ı�, �ȵ�)</param>
        /// <param name="commandText">�洢�������ƻ���sql�������</param>
        /// <param name="commandParameters">ִ���������ò����ļ���</param>
        /// <returns>�� Convert.To{Type}������ת��Ϊ��Ҫ�� </returns>
        public static object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        connection.Open();

                        PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                        object val = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        return val;
                    }
                 }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    connection.Close();
                    connection.Dispose();
                    throw new Exception(ex.Message);
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        /// <summary>
        /// ��ָ�������ݿ�����ִ��һ���������һ�����ݼ��ĵ�һ��
        /// </summary>
        /// <remarks>
        /// ����:  
        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="conn">һ�����ڵ����ݿ�����</param>
        /// <param name="commandType">��������(�洢����, �ı�, �ȵ�)</param>
        /// <param name="commandText">�洢�������ƻ���sql�������</param>
        /// <param name="commandParameters">ִ���������ò����ļ���</param>
        /// <returns>�� Convert.To{Type}������ת��Ϊ��Ҫ�� </returns>
        public static object ExecuteScalar(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            //string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            using (SqlConnection connection1 = new SqlConnection(ConnectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        connection1.Open();
                        PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                        object val = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        return val;
                    }
                 }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    connection1.Close();
                    connection1.Dispose();
                    throw new Exception(ex.Message);
                }
                finally
                {
                    connection1.Close();
                    connection1.Dispose();
                }
            }
        }


                /// <summary>
        /// ��ָ�������ݿ������ַ���ִ��һ���������һ��DataSet���ݼ�
        /// </summary>
        /// <param name="connectionString">һ����Ч�������ַ���</param>
        /// <param name="cmdText">�洢�������ƻ���sql�������</param>
        /// <returns>����һ��DataSet���ݼ�</returns>
        public static DataSet GetDataSet(string connectionString, string cmdText, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (cmdText.ToUpper().IndexOf("[PINBLE_WEB]") < 0 && cmdText.ToUpper().IndexOf("[PINBLE_CST]") < 0 && cmdText.ToUpper().IndexOf("SP_") >= 0 && !string.IsNullOrEmpty(cmdText))
                {
                    cmdText = "[Pinble_Web].dbo." + cmdText;
                }
                DataSet ds = new DataSet();
                connection.Open();              
                using(  SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = cmdText;
                    cmd.Connection = connection;

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);

                    if (cmdParms != null)
                    {
                        foreach (SqlParameter parm in cmdParms)
                            cmd.Parameters.Add(parm);
                    }           
                    sda.Fill(ds);
                }
                return ds;
            }
        }

        
        /// <summary>
        ///ʹ�����е�SQL����ִ��һ��sql������������ݼ���
        /// </summary>
        /// <remarks>
        ///����:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="trans">һ�����е�����</param>
        /// <param name="commandType">��������(�洢����, �ı�, �ȵ�)</param>
        /// <param name="commandText">�洢�������ƻ���sql�������</param>
        /// <param name="commandParameters">ִ���������ò����ļ���</param>
        /// <returns>ִ��������Ӱ�������</returns>
        public static DataSet GetDataSet(string  strConn, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {  
            DataSet ds = new DataSet();
            //string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
           using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                if (cmdText.ToUpper().IndexOf("[PINBLE_WEB]") < 0 && cmdText.ToUpper().IndexOf("[PINBLE_CST]") < 0 && cmdText.ToUpper().IndexOf("SP_") >= 0 && !string.IsNullOrEmpty(cmdText))
                {
                    cmdText = "[Pinble_Web].dbo." + cmdText;
                }
                conn.Open();
                //string transName = "InsertOrders";
                SqlTransaction trans = conn.BeginTransaction();

              
                using (SqlCommand cmd = new SqlCommand())
                {
                    //׼������
                    PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(ds);
                        cmd.Parameters.Clear();
                    }
                    return ds;
                }
            }
            

        }       

        ///// <summary>
        ///// ��ָ�������ݿ������ַ���ִ��һ���������һ��DataSet���ݼ�
        ///// </summary>
        ///// <param name="connectionString">һ�����ڵ����ݿ�����</param>
        ///// <param name="cmdText">�洢�������ƻ���sql�������</param>
        ///// <returns>����һ��DataSet���ݼ�</returns>
        //public static DataSet GetDataSet(SqlConnection connection, string cmdText, params SqlParameter[] cmdParms)
        //{  DataSet ds = new DataSet();

        //    connection.Open();
        //    SqlCommand cmd = new SqlCommand();

        //    cmd.CommandText = cmdText;
        //    cmd.Connection = connection;

        //    SqlDataAdapter sda = new SqlDataAdapter(cmd);

        //    if (cmdParms != null)
        //    {
        //        foreach (SqlParameter parm in cmdParms)
        //            cmd.Parameters.Add(parm);
        //    }
          
        //    sda.Fill(ds);
        //    connection.Close();
        //    return ds;
        //}

        /// <summary>
        /// ������������ӵ�����
        /// </summary>
        /// <param name="cacheKey">��ӵ�����ı���</param>
        /// <param name="cmdParms">һ����Ҫ��ӵ������sql��������</param>
        public static void CacheParameters(string cacheKey, params SqlParameter[] commandParameters)
        {
            parmCache[cacheKey] = commandParameters;
        }

        /// <summary>
        /// �һػ����������
        /// </summary>
        /// <param name="cacheKey">�����һز����Ĺؼ���</param>
        /// <returns>����Ĳ�������</returns>
        public static SqlParameter[] GetCachedParameters(string cacheKey)
        {
            SqlParameter[] cachedParms = (SqlParameter[])parmCache[cacheKey];

            if (cachedParms == null)
                return null;

            SqlParameter[] clonedParms = new SqlParameter[cachedParms.Length];

            for (int i = 0, j = cachedParms.Length; i < j; i++)
                clonedParms[i] = (SqlParameter)((ICloneable)cachedParms[i]).Clone();

            return clonedParms;
        }

        /// <summary>
        /// ׼��ִ��һ������
        /// </summary>
        /// <param name="cmd">sql����</param>
        /// <param name="conn">Sql����</param>
        /// <param name="trans">Sql����</param>
        /// <param name="cmdType">������������ �洢���̻����ı�</param>
        /// <param name="cmdText">�����ı�,���磺Select * from Products</param>
        /// <param name="cmdParms">ִ������Ĳ���</param>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {
            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }


        /// <summary>
        /// ִ�з�ҳ�洢����--�����ܼ�¼��
        /// </summary>
        /// <param name="procName">�洢���̵�����</param>
        /// <param name="prams">�洢�����������</param>
        /// <param name="dataReader">�洢�����������</param>
        public static int RunProcPage(string procName, SqlParameter[] prams)
        {
            //string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try{
                    using( SqlCommand cmd = CreateCommand(connection,procName, prams))
                    {
                         return (int)cmd.ExecuteScalar();
                    }                   
                  
                 }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    connection.Close();
                    connection.Dispose();
                    throw new Exception(ex.Message);
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

        }

        /// <summary>
        /// ִ�з�ҳ�洢����--��������
        /// </summary>
        /// <param name="procName">�洢���̵�����</param>
        /// <param name="prams">�洢�����������</param>
        /// <param name="dataReader">�洢�����������</param>
        public static void RunProcPage(string procName, SqlParameter[] prams, out SqlDataReader dataReader)
        {
            //string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = CreateCommand(connection, procName, prams);
                try
                {
                    dataReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    cmd.Dispose();
                    connection.Close();
                    connection.Dispose();
                    throw new Exception(ex.Message);
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        /// <summary>
        /// ִ�д洢����
        /// </summary>
        /// <param name="storedProcName">�洢������</param>
        /// <param name="parameters">�洢���̲���</param>
        /// <param name="tableName">DataSet����еı���</param>
        /// <returns>DataSet</returns>
        public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName)
        {
            //string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                DataSet dataSet = new DataSet();
                try{
                    connection.Open();
                    SqlDataAdapter sqlDA = new SqlDataAdapter();
                    sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                    sqlDA.Fill(dataSet, tableName);
                 }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    connection.Close();
                    connection.Dispose();
                    throw new Exception(ex.Message);
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
                return dataSet;
            }
        }

        /// <summary>
        /// ִ�д洢����
        /// </summary>
        /// <param name="storedProcName">�洢������</param>
        /// <param name="parameters">�洢���̲���</param>
        /// <param name="tableName">DataSet����еı���</param>
        /// <returns>DataSet</returns>
        public static DataSet RunProcedure1(string storedProcName, IDataParameter[] parameters, string tableName, ref int Counts)
        {
            //string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                DataSet dataSet = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter sqlDA = new SqlDataAdapter();                   
                    SqlCommand cmd =   BuildQueryCommand(connection, storedProcName, parameters);
                    sqlDA.SelectCommand = cmd; 

                    sqlDA.Fill(dataSet, tableName);
                    Counts = (Int32)cmd.Parameters["@TotalCount"].Value;   
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    connection.Close();
                    connection.Dispose();
                    throw new Exception(ex.Message);
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
                return dataSet;
            }
        }


        /// <summary>
        /// ���� SqlCommand ����(��������һ���������������һ������ֵ)
        /// </summary>
        /// <param name="connection">���ݿ�����</param>
        /// <param name="storedProcName">�洢������</param>
        /// <param name="parameters">�洢���̲���</param>
        /// <returns>SqlCommand</returns>
        private static SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                if (parameter != null)
                {
                    // ���δ����ֵ���������,���������DBNull.Value.
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    command.Parameters.Add(parameter);
                }
            }

            return command;
        }




        /// <summary>
        /// ����һ��SqlCommand�����Դ���ִ�д洢����
        /// </summary>
        /// <param name="procName">�洢���̵�����</param>
        /// <param name="prams">�洢�����������</param>
        /// <returns>����SqlCommand����</returns>
        public static SqlCommand CreateCommand(SqlConnection connection, string procName, SqlParameter[] prams)
        {
            // ȷ�ϴ�����
                connection.Open();
                SqlCommand cmd = new SqlCommand(procName, connection);
                cmd.CommandType = CommandType.StoredProcedure;

                // ���ΰѲ�������洢����
                if (prams != null)
                {
                    foreach (SqlParameter parameter in prams)
                        cmd.Parameters.Add(parameter);
                }

                // ���뷵�ز���
                cmd.Parameters.Add(
                    new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null));
                return cmd;
        }


        /// <summary>
        /// ���ɴ洢���̲���
        /// </summary>
        /// <param name="ParamName">�洢��������</param>
        /// <param name="DbType">��������</param>
        /// <param name="Size">������С</param>
        /// <param name="Direction">��������</param>
        /// <param name="Value">����ֵ</param>
        /// <returns>�µ� parameter ����</returns>
        public static SqlParameter MakeParam(string ParamName, SqlDbType DbType, Int32 Size, ParameterDirection Direction, object Value)
        {
            SqlParameter param;

            if (Size > 0)
                param = new SqlParameter(ParamName, DbType, Size);
            else
                param = new SqlParameter(ParamName, DbType);

            param.Direction = Direction;
            if (!(Direction == ParameterDirection.Output && Value == null))
                param.Value = Value;

            return param;
        }



        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="ParamName">�洢��������</param>
        /// <param name="DbType">��������</param></param>
        /// <param name="Size">������С</param>
        /// <param name="Value">����ֵ</param>
        /// <returns>�µ� parameter ����</returns>
        public static SqlParameter MakeInParam(string ParamName, SqlDbType DbType, int Size, object Value)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value);
        }

        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="ParamName">�洢��������</param>
        /// <param name="DbType">��������</param></param>
        /// <param name="Size">������С</param>
        /// <param name="Value">����ֵ</param>
        /// <returns>�µ� parameter ����</returns>
        public static SqlParameter MakeOutParam(string ParamName, SqlDbType DbType, int Size, object Value)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Output, Value);
        }
    }
}
