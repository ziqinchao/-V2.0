using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for DataBaseHelper
/// </summary>
public class DataBaseHelper
{ 
    //声明数据连接对象和数据访问对象
    private SqlConnection connection;
    private SqlCommand command;
    private SqlDataAdapter adapter;

	public DataBaseHelper()
	{
        this.connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RiceShop"].ConnectionString);//取得连接字符处;

        this.command = new SqlCommand();
        this.command.Connection = this.connection;

        this.adapter = new SqlDataAdapter(command);
	}


    /// <summary>
    /// 执行无返回数据操作；
    /// </summary>
    /// <param name="sql">sql语句</param>
    /// <returns>成功返回影响行数</returns>
    public int ExecuteNonQuery(string sql)
    {
        return ExecuteNonQuery(sql, new SqlParameter[0]);
    }


    /// <summary>
    /// 执行无返回数据操作；
    /// </summary>
    /// <param name="sql">sql语句</param>
    /// <param name="param">参数</param>
    /// <returns>成功返回影响行数</returns>
    public int ExecuteNonQuery(string sql, SqlParameter[] param)
    {
        this.command.CommandText = sql;
        this.command.Parameters.Clear();
        for (int i = 0; i < param.Length; i++)
        {
            if(param[i] != null)
                this.command.Parameters.Add(param[i]);
        }

        int result = 0;
        try
        {
            this.connection.Open();
            result = this.command.ExecuteNonQuery();  
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            this.connection.Close();
        }

        return result;       
    }


    /// <summary>
    /// 根据sql和参数取得数据；
    /// </summary>
    /// <param name="sql">sql语句</param>
    /// <param name="param">参数数组</param>
    /// <returns>取得数据集</returns>
    public DataTable Select(string sql, SqlParameter[] param)
    {
        this.command.CommandText = sql;
        this.command.Parameters.Clear();
        for (int i = 0; i < param.Length; i++)
        {
            if(param[i] != null)
                this.command.Parameters.Add(param[i]);
        }

        DataTable dtData = new DataTable();

        //连接数据库取得数据,出现异常则像上级抛出；
        try
        {
            this.adapter.Fill(dtData);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dtData;
    }

    /// <summary>
    /// 根据sql和参数取得数据；
    /// </summary>
    /// <param name="sql">sql语句</param>
    /// <returns>取得数据集</returns>
    public DataTable Select(String sql)
    {
        return this.Select(sql, new SqlParameter[0]);
    }


    /// <summary>
    /// 将参数添加到参数数组
    /// </summary>
    /// <param name="paramArray">参数数组</param>
    /// <param name="param">参数</param>
    /// <returns></returns>
    public static SqlParameter[] AddParameter(SqlParameter[] paramArray, SqlParameter param)
    {

        Array.Resize<SqlParameter>(ref paramArray, paramArray.Length + 1);
        paramArray[paramArray.Length - 1] = param;
        return paramArray;
    }
}
