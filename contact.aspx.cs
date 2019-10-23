using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

public partial class contact : System.Web.UI.Page
{
    int RecordCnt = 0;
    // protected string strSqlConnect = "Data Source=LAPTOP-KMD12G02\\SQLEXPRESS;Initial Catalog=dbNewsLetter;Integrated Security=True";

    Stack stkParam = new Stack();

    ProjectClasses pc = new ProjectClasses();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            Session["rowIndex"] = 0;
            DataTable dataTable =
                pc.GetData(
                    Application["dbContect"].ToString(),
                    Application["qryStrContacts"].ToString()
                    );

            if (dataTable.Rows.Count > 0)
            {
                // Populate the TextBox with the first entry on page load

                Session["PrimaryKey"] = dataTable.Rows[0]["pKey"].ToString();
                fName.Text = dataTable.Rows[0]["fName"].ToString();
                lName.Text = dataTable.Rows[0]["lName"].ToString();
                eMail.Text = dataTable.Rows[0]["eMail"].ToString();
                Phone.Text = dataTable.Rows[0]["Phone"].ToString();
                Comments.Text = dataTable.Rows[0]["Comments"].ToString();
                //query the DB on every postbacks
                Session["dataTable"] = dataTable;
            }

        }
    }

    protected void Next_Click(object sender, EventArgs e)
    {
        int rowIndex = (int)Session["rowIndex"];
        rowIndex++;
        if (Session["dataTable"] != null)
        {
            DataTable dataTable = (DataTable)Session["dataTable"];
            if (rowIndex < dataTable.Rows.Count)
            {
                Session["rowIndex"] = rowIndex;
                //get the next row entry on Button Click by setting the Row Index
                Session["PrimaryKey"] = dataTable.Rows[rowIndex]["pKey"].ToString();
                fName.Text = dataTable.Rows[rowIndex]["fName"].ToString();
                lName.Text = dataTable.Rows[rowIndex]["lName"].ToString();
                eMail.Text = dataTable.Rows[rowIndex]["eMail"].ToString();
                Phone.Text = dataTable.Rows[rowIndex]["Phone"].ToString();
                Comments.Text = dataTable.Rows[rowIndex]["Comments"].ToString();
            }
        }
    }

    protected void Prev_Click(object sender, EventArgs e)
    {
        int rowIndex = (int)Session["rowIndex"];
        rowIndex--;
        if (Session["dataTable"] != null)
        {
            DataTable dataTable = (DataTable)Session["dataTable"];
            if (rowIndex >= 0)
            {
                Session["rowIndex"] = rowIndex;
                //get the next row entry on Button Click by setting the Row Index
                Session["PrimaryKey"] = dataTable.Rows[rowIndex]["pKey"].ToString();
                fName.Text = dataTable.Rows[rowIndex]["fName"].ToString();
                lName.Text = dataTable.Rows[rowIndex]["lName"].ToString();
                eMail.Text = dataTable.Rows[rowIndex]["eMail"].ToString();
                Phone.Text = dataTable.Rows[rowIndex]["Phone"].ToString();
                Comments.Text = dataTable.Rows[rowIndex]["Comments"].ToString();
            }
        }
    }

    protected void Add_Click(object sender, EventArgs e)
    {
        stkParam.Push(Comments.Text);
        stkParam.Push(SqlDbType.VarChar);
        stkParam.Push("@Comments");
        stkParam.Push(Phone.Text);
        stkParam.Push(SqlDbType.VarChar);
        stkParam.Push("@Phone");
        stkParam.Push(eMail.Text);
        stkParam.Push(SqlDbType.VarChar);
        stkParam.Push("@eMail");
        stkParam.Push(lName.Text);
        stkParam.Push(SqlDbType.VarChar);
        stkParam.Push("@lName");
        stkParam.Push(fName.Text);
        stkParam.Push(SqlDbType.VarChar);
        stkParam.Push("@fName");

        processEvents(
            Application["qryStrInsertContact"].ToString());
    }

   
    protected void processEvents(string strEventCmd)
    {

        DataTable dataTable = new DataTable();
        System.Configuration.Configuration rootwebconfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/Mohtisham");
        System.Configuration.ConnectionStringSettings conSql;
        conSql = rootwebconfig.ConnectionStrings.ConnectionStrings[Application["dbContect"].ToString()];
        SqlConnection dBConnection = new SqlConnection(conSql.ToString());

        try
        {
            using (SqlCommand sqlCmd = new SqlCommand(strEventCmd, dBConnection)
            {
                CommandType = CommandType.StoredProcedure
             })
            {
                while (0 < stkParam.Count)
                {
                    // Passes - @Parameter, SqlDbType.VarChar, Parameter Value 
                    sqlCmd.Parameters.Add((string)stkParam.Pop(), (SqlDbType)stkParam.Pop()).Value = (string)stkParam.Pop();
                }     

                dBConnection.Open();
                sqlCmd.ExecuteNonQuery();

                dataTable =
                    pc.GetData(
                        this.Application["dbContect"].ToString(),
                        this.Application["qryStrContacts"].ToString()
                        );
                this.Session["dataTable"] = dataTable;
            }
        }
        catch (Exception eMsg)
        {
            Response.Write("Error: \n");
            Response.Write(eMsg.ToString());
        }
        finally
        {
            dBConnection.Close();
        }
    }
    
   

    protected void Remove_Click(object sender, EventArgs e)
    {
        stkParam.Push(Session["PrimaryKey"].ToString());
        stkParam.Push(SqlDbType.Int);
        stkParam.Push("@pKey");
    
        processEvents(Application["qryStrContactRemove"].ToString());
    }

    protected void Update_Click(object sender, EventArgs e)
    {

        stkParam.Push(Comments.Text);
        stkParam.Push(SqlDbType.VarChar);
        stkParam.Push("@Comments");
        stkParam.Push(Phone.Text);
        stkParam.Push(SqlDbType.VarChar);
        stkParam.Push("@Phone");
        stkParam.Push(eMail.Text);
        stkParam.Push(SqlDbType.VarChar);
        stkParam.Push("@eMail");
        stkParam.Push(lName.Text);
        stkParam.Push(SqlDbType.VarChar);
        stkParam.Push("@lName");
        stkParam.Push(fName.Text);
        stkParam.Push(SqlDbType.VarChar);
        stkParam.Push("@fName");
        stkParam.Push(Session["PrimaryKey"].ToString());
        stkParam.Push(SqlDbType.Int);
        stkParam.Push("@pKey");

        processEvents(
            Application["qryStrUpdateContact"].ToString());
    }

    protected void Reset_Click(object sender, EventArgs e)
    {
        fName.Text = "";
        lName.Text = "";
        eMail.Text = "";
        Phone.Text = "";
    }
}