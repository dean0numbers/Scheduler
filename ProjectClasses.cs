using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ProjectClasses
/// </summary>
public class ProjectClasses
{
    public ProjectClasses()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetData(string conStr, string cmdSqlStr)
    {
        DataTable dataTable = new DataTable();
        System.Configuration.Configuration rootwebconfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/Mohtisham");
        System.Configuration.ConnectionStringSettings conSql;
        conSql = rootwebconfig.ConnectionStrings.ConnectionStrings[conStr];
        SqlConnection dBConnection = new SqlConnection(conSql.ToString());

        try
        {
            using (SqlCommand sqlCmd = new SqlCommand(cmdSqlStr, dBConnection)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                dBConnection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
                sqlDa.Fill(dataTable);
            }
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            string msg = "Fetch Error:";
            msg += ex.Message;
            throw new Exception(msg);
        }
        finally
        {
            dBConnection.Close();
        }
        return dataTable;
    }
}