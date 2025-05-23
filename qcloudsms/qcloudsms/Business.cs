using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Data.OleDb;
using System.Data.Sql;
using System.Data.SqlClient;

/// <summary>
/// Business 的摘要说明
/// </summary>
class Business
{
    public SqlConnection MYSQLConn = new SqlConnection();

    
    public void SaveException(String ex)
    {
        try
        {
            String filename = System.Guid.NewGuid().ToString().Replace("-", "").Replace("_", "");
            if (!Directory.Exists(Application.StartupPath + "\\Exception"))
            {
                Directory.CreateDirectory(Application.StartupPath + "\\Exception");
            }
            String logfile = Application.StartupPath + "\\Exception\\" + filename + ".log";

            FileStream objFileStream = new FileStream(logfile, FileMode.Append, FileAccess.Write);
            StreamWriter objStreamWriter = new StreamWriter(objFileStream, Encoding.UTF8);
            objStreamWriter.Write(ex);
            objStreamWriter.Close();
        }
        catch
        {

        }
    }
    public void SaveSqlText(String filetag, String content)
    {
        try
        {
            if (!Directory.Exists(Application.StartupPath + "\\SqlData"))
            {
                Directory.CreateDirectory(Application.StartupPath + "\\SqlData");
            }
            String filename = Application.StartupPath + "\\SqlData\\" + filetag + "_" + System.Guid.NewGuid().ToString() + ".txt";

            FileStream objFileStream = new FileStream(filename, FileMode.Append, FileAccess.Write);
            StreamWriter objStreamWriter = new StreamWriter(objFileStream, Encoding.UTF8);
            objStreamWriter.Write(content);
            objStreamWriter.Close();
        }
        catch
        {

        }
    }
    public void SaveDataText(String filename, String content)
    {
        try
        {
            if (!Directory.Exists(Application.StartupPath + "\\TextData"))
            {
                Directory.CreateDirectory(Application.StartupPath + "\\TextData");
            }
            String logfile = Application.StartupPath + "\\TextData\\" + filename + ".txt";

            FileStream objFileStream = new FileStream(logfile, FileMode.Append, FileAccess.Write);
            StreamWriter objStreamWriter = new StreamWriter(objFileStream, Encoding.UTF8);
            objStreamWriter.Write(content);
            objStreamWriter.Close();
        }
        catch
        {

        }
    }

   

    public void ExeCuteSQLSQLNoTrans(string Sqlstr, SqlConnection myconnection)
    {
        try
        {
            SqlCommand myCommand = new SqlCommand(Sqlstr, myconnection);
            myCommand.CommandTimeout = 99999999;
            myCommand.ExecuteNonQuery();
        }
        catch(Exception ex)
        {
            throw new Exception("存储过程错误 : " + Sqlstr + ex.ToString());
        }
    }



    public bool ConnectMYSQL(String SqlIp, String username, String password, String Dbname)
    {
        try
        {
            String constr = "packet size=4096;user id=" + username + ";data source=" + SqlIp + "; persist security info=True;initial catalog=" + Dbname + ";password=" + password + ";Min Pool Size=0;Max Pool Size=30000;Pooling=true";
            MYSQLConn = new SqlConnection(constr);
            
            MYSQLConn.Open();

            return true;

        }
        
        catch (SqlException ep)
        {
            MessageBox.Show(ep.ToString());
            return false;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
            return false;
        }
    }
   
    public void CloseSql()
    {
        try
        {
            MYSQLConn.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }
    public void ExeCuteSQLServerWithTrans(string mysql, SqlConnection myconnection, SqlTransaction mytrans)
    {
        try
        {
            SqlCommand myCommand = new SqlCommand(mysql, myconnection, mytrans);
            myCommand.CommandTimeout = 99999999;
            myCommand.ExecuteNonQuery();
            myCommand.Dispose();
        }
        catch (Exception ex)
        {
            throw new Exception("存储过程错误 : " + ex.ToString() + mysql);
        }
    }

    public String Readone(string mysql, SqlConnection myconnection)
    {
        try
        {
            String returnstr = "";

            SqlCommand myCommand = new SqlCommand(mysql, myconnection);
            SqlDataReader myReader = myCommand.ExecuteReader();

            if (myReader.Read())
            {
                if (myReader.GetValue(0).ToString().Trim().Length > 0)
                {
                    returnstr = myReader.GetValue(0).ToString().Trim();
                }
            }
            myReader.Close();
            myCommand.Dispose();

            return returnstr;
        }
        catch (Exception ex)
        {
            throw new Exception("存储过程错误 : " + ex.ToString() + mysql);
        }
    }


    public String ReturnTopOneRecordSQLWithTrans(string mysql, SqlConnection myconnection, SqlTransaction mytrans)
    {
        try
        {
            String returnstr = "";

            SqlCommand myCommand = new SqlCommand(mysql, myconnection, mytrans);
            SqlDataReader myReader = myCommand.ExecuteReader();

            if (myReader.Read())
            {
                if (myReader.GetValue(0).ToString().Trim().Length > 0)
                {
                    returnstr = myReader.GetValue(0).ToString().Trim();
                }
            }
            myReader.Close();
            myCommand.Dispose();

            return returnstr;
        }
        catch (Exception ex)
        {
            throw new Exception("存储过程错误 : " + ex.ToString() + mysql);
        }
    }

    public ArrayList ReturnAllArrayRecordSQLWithTrans(string mysql, SqlConnection myconnection, SqlTransaction mytrans, bool ifallownull)
    {
        try
        {
            ArrayList returnstr = new ArrayList();

            SqlCommand myCommand = new SqlCommand(mysql, myconnection, mytrans);
            SqlDataReader myReader = myCommand.ExecuteReader();

            while (myReader.Read())
            {
                if (ifallownull.Equals(true))
                {
                    returnstr.Add(myReader.GetValue(0).ToString().Trim());
                }
                else
                {
                    if (myReader.GetValue(0).ToString().Trim().Length > 0)
                    {
                        returnstr.Add(myReader.GetValue(0).ToString().Trim());
                    }
                }

            }
            myReader.Close();
            myCommand.Dispose();

            return returnstr;
        }
        catch (Exception ex)
        {
            throw new Exception("存储过程错误 : " + ex.ToString() + mysql);
        }
    }
}
public class OptionClass
{
    public String OptionValue;
    public String OptionText;

    public override string ToString()
    {
        return this.OptionText;
    }
}