using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class schedule : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    protected void OnFileLoadEvent(object sender, EventArgs e)
    {
       // txtFileName.Text = FileToUpload.Text;
      
    }


    protected void DeleteButton_Click(object sender, EventArgs e)
    {
        SqlDataSource1.Delete();
    }

    protected void InsertButton_Click(object sender, EventArgs e)
    {
        GridViewSchedule.FooterRow.FindControl("LinkButtonInsert").Visible = false;
        GridViewSchedule.FooterRow.FindControl("LinkSubmit").Visible = true;
        GridViewSchedule.FooterRow.FindControl("InsertCanselButton").Visible = true;
        GridViewSchedule.FooterRow.FindControl("FileToUpload").Visible = true;
        GridViewSchedule.FooterRow.FindControl("InsertDesc").Visible = true;
        GridViewSchedule.FooterRow.FindControl("Calendar2").Visible = true;
    }

    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        FileUpload FileToUpLoad =
            (FileUpload)GridViewSchedule.FooterRow.FindControl("FileToUpload");

        if (FileToUpLoad.HasFile)
        {
            string fileName = Path.GetFileName(FileToUpLoad.FileName);
            FileToUpLoad.SaveAs(Server.MapPath("~/newsletters/") + fileName); // FileToUpLoad.FileName);

            //      FileToUpLoad.SaveAs(Server.MapPath("~/newsletters/") + FileToUpLoad.FileName); 

            SqlDataSource1.InsertParameters["Descript"].DefaultValue =
                ((TextBox)GridViewSchedule.FooterRow.FindControl("InsertDesc")).Text;

            SqlDataSource1.InsertParameters["SendFile"].DefaultValue =
                FileToUpLoad.FileName;

            SqlDataSource1.InsertParameters["SendDate"].DefaultValue =
               ((System.Web.UI.WebControls.Calendar)GridViewSchedule.FooterRow.FindControl("Calendar2")).SelectedDate.ToLongDateString();

            SqlDataSource1.Insert();
        }
        else
        {
            ((TextBox)GridViewSchedule.FooterRow.FindControl("InsertDesc")).Text = "<No File has been Selected - Please Select File>";
        }
    }
 }