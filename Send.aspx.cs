using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web.UI;


public partial class Send : System.Web.UI.Page
{
  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {   
            ButtonSendMail.Visible = false;
            TextBoxResponse.Visible = true;
        }
        TextBoxResponse.Visible = false;
        ButtonSendMail.Visible = true;
    }

    private void RemoveSentFromSchedule(Int32 pKey)
    {
        System.Configuration.Configuration rootwebconfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/Mohtisham");
        System.Configuration.ConnectionStringSettings conSql;
        conSql = rootwebconfig.ConnectionStrings.ConnectionStrings[Application["dbContect"].ToString()];

        SqlConnection dBConnection = new SqlConnection(conSql.ToString());
        string queryString =
            "DELETE FROM Schedule WHERE pKey = '" + pKey + "';";

        try
        { 
            dBConnection.Open();
            SqlCommand sqlCmd = new SqlCommand(queryString, dBConnection);
            sqlCmd.ExecuteNonQuery();
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
    }


    protected void ButtonSendMail_Click(object sender, EventArgs e)
    {
        SendMail();
    }

    protected void SendMail()
    {
        ProjectClasses pc = new ProjectClasses();
        Credentials credentials = new Credentials();

        DataTable dataTableContacts = 
            pc.GetData(
               Application["dbContect"].ToString(),
                Application["qryStrContacts"].ToString()
                );
        DataTable dataTableSchedules = 
            pc.GetData(
                Application["dbContect"].ToString(),
                Application["qryStrSchedule"].ToString()
                );
        StringBuilder strNewsLetterContent = new StringBuilder();
        MailMessage mailObj = new MailMessage();

        //  Check to see if there are any jobs scheduled
        TextBoxResponse.Visible = true;
        TextBoxResponse.Enabled = false;
        ButtonSendMail.Visible = false;

        if (dataTableSchedules.Rows.Count == 0)
        {
            TextBoxResponse.Text = "No Events Found in the scheduler";
            return;
        }


        SmtpClient SMTPServer = new SmtpClient();
        SMTPServer.DeliveryMethod = SmtpDeliveryMethod.Network;
        NetworkCredential mailCredentials = new NetworkCredential(credentials.getEmailAddress(), credentials.getEmailPassPhrase());

        SMTPServer.Host = "smtp.gmail.com";
        SMTPServer.Port = 587;
        SMTPServer.EnableSsl = true;
        SMTPServer.UseDefaultCredentials = false;
        SMTPServer.Credentials = mailCredentials;


        //  Check to see if there Contacts to send to 
        if (dataTableSchedules.Rows.Count == 0)
        {
            TextBoxResponse.Text = "There were no Contacts found in contact manager";
            return;
        }

        strNewsLetterContent.Append("<h1>Raspberry Pi Newletter</h1>");


        for (int i = 0; i < dataTableSchedules.Rows.Count; i++)
        {
            if (((DateTime)dataTableSchedules.Rows[i]["SendDate"]).Date <= DateTime.Now)
            {
                Int32 pKey = ((Int32)dataTableSchedules.Rows[i]["pKey"]);
                if (dataTableContacts.Rows.Count > 0)
                {
                    string MailReceiver = dataTableContacts.Rows[0]["eMail"].ToString();

                    mailObj.From = new MailAddress("truex.dean@gmail.com"); //    From
                    mailObj.To.Add(MailReceiver); //     To
                    if (dataTableContacts.Rows.Count > 1)
                        for (int j = 1; j < dataTableContacts.Rows.Count; j++)
                        {
                            MailReceiver = dataTableContacts.Rows[j]["eMail"].ToString();
                            mailObj.Bcc.Add(MailReceiver);
                        }
                    mailObj.Subject = "Raspberry Pi News";   //     Subject 
                    mailObj.Body = strNewsLetterContent.ToString();    //     Body

                    string FileName = dataTableSchedules.Rows[i]["SendFile"].ToString();
                    string FilePath =
                        Server.MapPath("~/newsletters/") + FileName;

                    mailObj.Attachments.Add(new Attachment(FilePath));

                    mailObj.SubjectEncoding = System.Text.Encoding.UTF8;
                    mailObj.BodyEncoding = System.Text.Encoding.UTF8;
                    mailObj.IsBodyHtml = true;
                    mailObj.Priority = MailPriority.Normal;

                    try
                    {
                        TextBoxResponse.Text =
                            "Sending: " + dataTableSchedules.Rows[i]["SendFile"].ToString();

                        SMTPServer.Send(mailObj);

                        TextBoxResponse.Text =
                            "Sent: " + dataTableSchedules.Rows[i]["SendFile"].ToString();

                        RemoveSentFromSchedule(pKey);
                    }
                    catch (Exception ex)
                    {
                        TextBoxResponse.Text =
                            "Unable to Sent: " + dataTableSchedules.Rows[i]["SendFile"].ToString();
                        TextBoxResponse.Text = ex.ToString();
                    }
                }
            }
        }
    }
}

