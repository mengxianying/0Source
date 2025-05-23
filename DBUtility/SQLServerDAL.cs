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
    /// SqlHelper类是sql数据操作
    /// </summary>
    public abstract class SQLHelper
    {

        //数据库连接字符串
        private static string _connectionString = ConfigurationManager.AppSettings["ConnectionString"];

        public static string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        // 连接数据源
     //   public static SqlConnection con;



        ///// <summary>
        ///// 打开数据库连接.
        ///// </summary>
        //public static void Open()
        //{
        //    // 打开数据库连接
        //    if (con == null)
        //    {
        //        con = new SqlConnection(ConnectionString);
        //    }
        //    if (con.State == System.Data.ConnectionState.Closed)
        //        con.Open();
        //}

        // 用于缓存参数的HASH表
        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());

        /// <summary>
        ///  给定连接的数据库用假设参数执行一个sql命令（不返回数据集）
        /// </summary>
        /// <param name="connectionString">一个有效的连接字符串</param>
        /// <param name="commandType">命令类型(存储过程, 文本, 等等)</param>
        /// <param name="commandText">存储过程名称或者sql命令语句</param>
        /// <param name="commandParameters">执行命令所用参数的集合</param>
        /// <returns>执行命令所影响的行数</returns>
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
        /// 用现有的数据库连接执行一个sql命令（不返回数据集）
        /// </summary>
        /// <param name="conn">一个现有的数据库连接</param>
        /// <param name="commandType">命令类型(存储过程, 文本, 等等)</param>
        /// <param name="commandText">存储过程名称或者sql命令语句</param>
        /// <param name="commandParameters">执行命令所用参数的集合</param>
        /// <returns>执行命令所影响的行数</returns>
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
        ///使用现有的SQL事务执行一个sql命令（不返回数据集）
        /// </summary>
        /// <remarks>
        ///举例:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="trans">一个现有的事务</param>
        /// <param name="commandType">命令类型(存储过程, 文本, 等等)</param>
        /// <param name="commandText">存储过程名称或者sql命令语句</param>
        /// <param name="commandParameters">执行命令所用参数的集合</param>
        /// <returns>执行命令所影响的行数</returns>
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
        /// 用执行的数据库连接执行一个返回数据集的sql命令
        /// </summary>
        /// <remarks>
        /// 举例:  
        ///  SqlDataReader r = ExecuteReader(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">一个有效的连接字符串</param>
        /// <param name="commandType">命令类型(存储过程, 文本, 等等)</param>
        /// <param name="commandText">存储过程名称或者sql命令语句</param>
        /// <param name="commandParameters">执行命令所用参数的集合</param>
        /// <returns>包含结果的读取器</returns>
        public static SqlDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            //创建一个SqlCommand对象
            SqlCommand cmd = new SqlCommand();
            //创建一个SqlConnection对象
            SqlConnection conn = new SqlConnection(connectionString);

            //在这里我们用一个try/catch结构执行sql文本命令/存储过程，因为如果这个方法产生一个异常我们要关闭连接，因为没有读取器存在，
            //因此commandBehaviour.CloseConnection 就不会执行
            try
            {
                if (cmdText.ToUpper().IndexOf("[PINBLE_WEB]") < 0 && cmdText.ToUpper().IndexOf("[PINBLE_CST]") < 0 && cmdText.ToUpper().IndexOf("SP_") >= 0 && !string.IsNullOrEmpty(cmdText))
                {
                    cmdText = "[Pinble_Web].dbo." + cmdText;
                }
                //调用 PrepareCommand 方法，对 SqlCommand 对象设置参数
                conn.Open();
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                //调用 SqlCommand  的 ExecuteReader 方法
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //清除参数
                cmd.Parameters.Clear();
                return reader;
            }
            catch
            {
                //关闭连接，抛出异常
                conn.Close();
                conn.Dispose();
                throw;
            }
        }

        /// <summary>
        /// 用指定的数据库连接字符串执行一个命令并返回一个数据集的第一列
        /// </summary>
        /// <remarks>
        ///例如:  
        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        ///<param name="connectionString">一个有效的连接字符串</param>
        /// <param name="commandType">命令类型(存储过程, 文本, 等等)</param>
        /// <param name="commandText">存储过程名称或者sql命令语句</param>
        /// <param name="commandParameters">执行命令所用参数的集合</param>
        /// <returns>用 Convert.To{Type}把类型转换为想要的 </returns>
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
        /// 用指定的数据库连接执行一个命令并返回一个数据集的第一列
        /// </summary>
        /// <remarks>
        /// 例如:  
        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="conn">一个存在的数据库连接</param>
        /// <param name="commandType">命令类型(存储过程, 文本, 等等)</param>
        /// <param name="commandText">存储过程名称或者sql命令语句</param>
        /// <param name="commandParameters">执行命令所用参数的集合</param>
        /// <returns>用 Convert.To{Type}把类型转换为想要的 </returns>
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
        /// 用指定的数据库连接字符串执行一个命令并返回一个DataSet数据集
        /// </summary>
        /// <param name="connectionString">一个有效的连接字符串</param>
        /// <param name="cmdText">存储过程名称或者sql命令语句</param>
        /// <returns>返回一个DataSet数据集</returns>
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
        ///使用现有的SQL事务执行一个sql命令（不返回数据集）
        /// </summary>
        /// <remarks>
        ///举例:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="trans">一个现有的事务</param>
        /// <param name="commandType">命令类型(存储过程, 文本, 等等)</param>
        /// <param name="commandText">存储过程名称或者sql命令语句</param>
        /// <param name="commandParameters">执行命令所用参数的集合</param>
        /// <returns>执行命令所影响的行数</returns>
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
                    //准备命令
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
        ///// 用指定的数据库连接字符串执行一个命令并返回一个DataSet数据集
        ///// </summary>
        ///// <param name="connectionString">一个存在的数据库连接</param>
        ///// <param name="cmdText">存储过程名称或者sql命令语句</param>
        ///// <returns>返回一个DataSet数据集</returns>
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
        /// 将参数集合添加到缓存
        /// </summary>
        /// <param name="cacheKey">添加到缓存的变量</param>
        /// <param name="cmdParms">一个将要添加到缓存的sql参数集合</param>
        public static void CacheParameters(string cacheKey, params SqlParameter[] commandParameters)
        {
            parmCache[cacheKey] = commandParameters;
        }

        /// <summary>
        /// 找回缓存参数集合
        /// </summary>
        /// <param name="cacheKey">用于找回参数的关键字</param>
        /// <returns>缓存的参数集合</returns>
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
        /// 准备执行一个命令
        /// </summary>
        /// <param name="cmd">sql命令</param>
        /// <param name="conn">Sql连接</param>
        /// <param name="trans">Sql事务</param>
        /// <param name="cmdType">命令类型例如 存储过程或者文本</param>
        /// <param name="cmdText">命令文本,例如：Select * from Products</param>
        /// <param name="cmdParms">执行命令的参数</param>
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
        /// 执行分页存储过程--返回总记录数
        /// </summary>
        /// <param name="procName">存储过程的名称</param>
        /// <param name="prams">存储过程所需参数</param>
        /// <param name="dataReader">存储过程所需参数</param>
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
        /// 执行分页存储过程--返回数据
        /// </summary>
        /// <param name="procName">存储过程的名称</param>
        /// <param name="prams">存储过程所需参数</param>
        /// <param name="dataReader">存储过程所需参数</param>
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
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="tableName">DataSet结果中的表名</param>
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
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="tableName">DataSet结果中的表名</param>
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
        /// 构建 SqlCommand 对象(用来返回一个结果集，而不是一个整数值)
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlCommand</returns>
        private static SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                if (parameter != null)
                {
                    // 检查未分配值的输出参数,将其分配以DBNull.Value.
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
        /// 创建一个SqlCommand对象以此来执行存储过程
        /// </summary>
        /// <param name="procName">存储过程的名称</param>
        /// <param name="prams">存储过程所需参数</param>
        /// <returns>返回SqlCommand对象</returns>
        public static SqlCommand CreateCommand(SqlConnection connection, string procName, SqlParameter[] prams)
        {
            // 确认打开连接
                connection.Open();
                SqlCommand cmd = new SqlCommand(procName, connection);
                cmd.CommandType = CommandType.StoredProcedure;

                // 依次把参数传入存储过程
                if (prams != null)
                {
                    foreach (SqlParameter parameter in prams)
                        cmd.Parameters.Add(parameter);
                }

                // 加入返回参数
                cmd.Parameters.Add(
                    new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null));
                return cmd;
        }


        /// <summary>
        /// 生成存储过程参数
        /// </summary>
        /// <param name="ParamName">存储过程名称</param>
        /// <param name="DbType">参数类型</param>
        /// <param name="Size">参数大小</param>
        /// <param name="Direction">参数方向</param>
        /// <param name="Value">参数值</param>
        /// <returns>新的 parameter 对象</returns>
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
        /// 传入输入参数
        /// </summary>
        /// <param name="ParamName">存储过程名称</param>
        /// <param name="DbType">参数类型</param></param>
        /// <param name="Size">参数大小</param>
        /// <param name="Value">参数值</param>
        /// <returns>新的 parameter 对象</returns>
        public static SqlParameter MakeInParam(string ParamName, SqlDbType DbType, int Size, object Value)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value);
        }

        /// <summary>
        /// 传入输出参数
        /// </summary>
        /// <param name="ParamName">存储过程名称</param>
        /// <param name="DbType">参数类型</param></param>
        /// <param name="Size">参数大小</param>
        /// <param name="Value">参数值</param>
        /// <returns>新的 parameter 对象</returns>
        public static SqlParameter MakeOutParam(string ParamName, SqlDbType DbType, int Size, object Value)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Output, Value);
        }
    }
}
