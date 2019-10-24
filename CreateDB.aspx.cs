using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

public partial class CreateDB : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String queryString, tempStr;
        String sqlFile = "newsletterdb.sql";
        string FilePath =
            Server.MapPath("~/") + sqlFile;
    
        Response.Write("<img src=\"./images/sql.png\" alt=\"Database\" >");
     
        Response.Write("<p><h1>Creating Database </br> ~ dbNewsLetter ~ </br> for Contact Manager </br> and News Letter Scheduler</h></p> </br>");
        Response.Write("<p><h3>Version 1.0</h3> </p>");
        Response.Write("<h3>October 23, 2019 </h3></br>");
        Response.Write("</ br >");
        Response.Flush();

        try
        {
            System.Configuration.Configuration rootwebconfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/Mohtisham");
            System.Configuration.ConnectionStringSettings conSql;
            conSql = rootwebconfig.ConnectionStrings.ConnectionStrings[Application["dbContect"].ToString()];

            SqlConnection dBConnection = new SqlConnection(conSql.ToString());

            StreamReader dbCmdsFile = File.OpenText(FilePath);

            dBConnection.Open();

            while (!dbCmdsFile.EndOfStream)
            {
                queryString = "";
                tempStr = dbCmdsFile.ReadLine();
                while (tempStr != "")
                {
                    if (dbCmdsFile.EndOfStream) break;

                    queryString += tempStr;
                    tempStr = dbCmdsFile.ReadLine();
                }

                Response.Write("<p>Command: {");
                Response.Write(queryString);
                Response.Write("}</p>");
                Response.Write("</ br>");
                Response.Flush();

                SqlCommand sqlCmd = new SqlCommand(queryString, dBConnection);
                sqlCmd.ExecuteNonQuery();

                Response.Write("<p>Sucessful</p>");
                Response.Flush();
            }

            Response.Write("<p>dbNewsLetter Build Complete</p>");
            Response.Flush();

            dbCmdsFile.Close();
            dBConnection.Close();
        }

        catch (System.Data.SqlClient.SqlException ex)
        {
            Response.Write("<p>Last Comammand Failed</p>");
            Response.Flush();

            string msg = "Database Creatation Error: ";
            msg += ex.Message;
            throw new Exception(msg);
        }

        finally
        {
          //  dBConnection.Close();
        }
    }
}