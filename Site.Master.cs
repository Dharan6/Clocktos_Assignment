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
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DegreeLoad();

                BranchLoad();

                SectionLoad();

                CriteriaLoad();

                LoadSubjectCodes();

                LoadSubject();
            }
        }

        private void LoadSubjectCodes()
        {
            string projectConnection = ConfigurationManager.ConnectionStrings["clocktos_conn"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(projectConnection))
            {
                string query = "sp_subcode";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                sub_code.DataSource = reader;
                sub_code.DataTextField = "subject_code";
                sub_code.DataValueField = "subject_code";
                sub_code.DataBind();

                reader.Close();
            }
        }

        private void LoadSubject()
        {
            string projectConnection = ConfigurationManager.ConnectionStrings["clocktos_conn"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(projectConnection))
            {
                string query = "sp_subjectload";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                sub_name.DataSource = reader;
                sub_name.DataTextField = "subject";
                sub_name.DataValueField = "subject";
                sub_name.DataBind();

                reader.Close();
            }
        }

        private void DegreeLoad()
        {
            string projectConnection = ConfigurationManager.ConnectionStrings["clocktos_conn"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(projectConnection))
            {
                string query = "sp_degreeLoad";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                degree_name.DataSource = reader;
                degree_name.DataTextField = "degree";
                degree_name.DataValueField = "degree";
                degree_name.DataBind();

                reader.Close();
            }
        }

        private void BranchLoad()
        {
            string projectConnection = ConfigurationManager.ConnectionStrings["clocktos_conn"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(projectConnection))
            {
                string query = "sp_branchLoad";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                branch_name.DataSource = reader;
                branch_name.DataTextField = "branch";
                branch_name.DataValueField = "branch";
                branch_name.DataBind();

                reader.Close();
            }
        }

        private void SectionLoad()
        {
            string projectConnection = ConfigurationManager.ConnectionStrings["clocktos_conn"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(projectConnection))
            {
                string query = "sp_sectionLoad";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                sec_name.DataSource = reader;
                sec_name.DataTextField = "section";
                sec_name.DataValueField = "section";
                sec_name.DataBind();

                reader.Close();
            }
        }

        private void CriteriaLoad()
        {
            string projectConnection = ConfigurationManager.ConnectionStrings["clocktos_conn"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(projectConnection))
            {
                string query = "sp_criteriaLoad";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                criteria_name.DataSource = reader;
                criteria_name.DataTextField = "criteria";
                criteria_name.DataValueField = "criteria";
                criteria_name.DataBind();

                reader.Close();
            }
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            try
            {
                string Degree = degree_name.SelectedValue;
                string Branch = branch_name.SelectedValue;
                string section = sec_name.SelectedValue;
                string criteria = criteria_name.SelectedValue;


                string commonForSelected = sel_sub.Checked ? "yes" : "no";
                string commonForSame = same_sub.Checked ? "yes" : "no";
                string subjectCode = sub_code.SelectedValue;
                string subjectName = sub_name.SelectedValue;
                DateTime examDate = DateTime.Parse(TextBox1.Text);
                TimeSpan startTime = TimeSpan.Parse(start_Time.Text);
                TimeSpan endTime = TimeSpan.Parse(End_Time.Text);
                string examDuration = duration_txt.Text;
                string selectSubCategory = sub_category.Checked ? "yes" : "no";
                string isLock = is_lock.Checked ? "yes" : "no";
                DateTime lockDate = DateTime.Parse(lock_date.Text);
                int minMark = int.Parse(min_mark.Text);
                int maxMark = int.Parse(max_mark.Text);
                string visibility = visibilty.Checked ? "yes" : "no";

                string connectionString = ConfigurationManager.ConnectionStrings["clocktos_conn"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    SqlCommand cmd = new SqlCommand("sp_insertExam", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Degree", Degree);
                    cmd.Parameters.AddWithValue("@Branch", Branch);
                    cmd.Parameters.AddWithValue("@Section", section);
                    cmd.Parameters.AddWithValue("@Criteria", criteria);

                    cmd.Parameters.AddWithValue("@CommonForSelected", commonForSelected);
                    cmd.Parameters.AddWithValue("@CommonForSame", commonForSame);
                    cmd.Parameters.AddWithValue("@SubjectCode", subjectCode);
                    cmd.Parameters.AddWithValue("@SubjectName", subjectName);
                    cmd.Parameters.AddWithValue("@ExamDate", examDate);
                    cmd.Parameters.AddWithValue("@StartTime", startTime);
                    cmd.Parameters.AddWithValue("@EndTime", endTime);
                    cmd.Parameters.AddWithValue("@ExamDuration", examDuration);
                    cmd.Parameters.AddWithValue("@SelectSubCategory", selectSubCategory);
                    cmd.Parameters.AddWithValue("@IsLock", isLock);
                    cmd.Parameters.AddWithValue("@LockDate", lockDate);
                    cmd.Parameters.AddWithValue("@MinMark", minMark);
                    cmd.Parameters.AddWithValue("@MaxMark", maxMark);
                    cmd.Parameters.AddWithValue("@Visibility", visibility);

                    conn.Open();
                    int a = cmd.ExecuteNonQuery();

                    conn.Close();

                    if(a>0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Saved", "alert('Data saved successfully.'); window.location = 'Home.aspx';", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "CreationError", "alert('Failed to save data.');", true);
                    }
                }
            }
            catch (SqlException ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error", $"alert('Failed to save data. Error: {ex.Message}');", true);
            }
            finally
            {
                Response.Redirect("~/Home.aspx");
            }
        }

        protected void deleteButton_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("~/Delete_page.aspx");  
        }

    }
}