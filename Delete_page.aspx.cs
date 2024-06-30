using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clocktos_Assignment
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void btncancel_Click(object sender, EventArgs e) 
        {
            Response.Redirect("~/Default.aspx");
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedSubjectCode = ddlSubjectCode.SelectedValue;
                DateTime selectedDate = DateTime.Parse(calendarDate.Text);


                string connectionString = ConfigurationManager.ConnectionStrings["clocktos_conn"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_deleteExam", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SubjectCode", selectedSubjectCode);
                    cmd.Parameters.AddWithValue("@ExamDate", selectedDate);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    conn.Close();


                    if (rowsAffected > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "DeleteSuccess", "alert('Data deleted successfully.'); window.location = 'Home.aspx';", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "DeleteError", "alert('Failed to delete data.');", true);
                    }
                }
            }
            catch (SqlException ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DeleteError", $"alert('Failed to delete data. Error: {ex.Message}');", true);
            }
        }
    }
}