using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Collections.Specialized.BitVector32;

namespace Clocktos_Assignment
{
    public partial class _Default : Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                BindDefaultData();

            }
        }

        private void BindDefaultData()
        {
            
            DataTable dt = FetchDefaultDataFromDatabase();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        private DataTable FetchDefaultDataFromDatabase()
        {

            string connectionString = ConfigurationManager.ConnectionStrings["clocktos_conn"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand("sp_fetchAll", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    dt.Load(reader);

                    reader.Close();
                    conn.Close();
                }
                catch (SqlException ex)
                {
                    
                    throw ex; 
                }

                return dt;
            }
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {

            string selectedDegree = DropDownListDegree.SelectedValue;
            string selectedBranch = DropDownListBranch.SelectedValue;
            string selectedSubject = DropDownListSubject.SelectedValue;

            string connectionString = ConfigurationManager.ConnectionStrings["clocktos_conn"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand("sp_searchExam", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Degree", selectedDegree);
                cmd.Parameters.AddWithValue("@Branch", selectedBranch);
                cmd.Parameters.AddWithValue("@Subject", selectedSubject);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);

                GridView1.Visible = false;
                GridViewSearchResults.DataSource = dt;
                GridViewSearchResults.DataBind();
                GridViewSearchResults.Visible = true;

                conn.Close();

            }
        }

        public void ButtonRefresh_Click(object sender, EventArgs e)
        {
            BindDefaultData();
            GridView1.Visible = true;
            GridViewSearchResults.Visible = false;
        }
    }
}