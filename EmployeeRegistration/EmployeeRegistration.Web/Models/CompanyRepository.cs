using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRegistration.Web.Models
{
    public class CompanyRepository
    {
        string connectionString = "Server=.\\SQLEXPRESS;Database=EmployeeRegistrationDb;Trusted_Connection=True;MultipleActiveResultSets=true";

        public IEnumerable<Company> GetAllCompanies()
        {
            List<Company> companies = new List<Company>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GetAllCompanies", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Company company = new Company();
                    company.Id = Convert.ToInt32(reader["Id"]);
                    company.Name = reader["Name"].ToString();
                    if (company.Size != 0)
                    {
                        company.Size = Convert.ToInt32(reader["Size"]);
                    }
                    else
                    {
                        company.Size = 0;
                    }
                    company.Form = reader["Form"].ToString();

                    companies.Add(company);
                }
                connection.Close();

                return companies;
            }
        }

        public void AddCompany(Company company)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("AddCompany", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Name", company.Name);
                command.Parameters.AddWithValue("@Form", company.Form);


                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void UpdateCompany(Company company)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("UpdateCompany", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", company.Id);
                command.Parameters.AddWithValue("@Name", company.Name);
                command.Parameters.AddWithValue("@Size", company.Size);
                command.Parameters.AddWithValue("@Form", company.Form);


                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public Company GetCompany(int? id)
        {
            Company company = new Company();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Companies WHERE ID= " + id;        //TODO: stringBuilder
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    company.Id = Convert.ToInt32(reader["Id"]);
                    company.Name = reader["Name"].ToString();
                    if (company.Size != 0)
                    {
                        company.Size = Convert.ToInt32(reader["Size"]);
                    }
                    else
                    {
                        company.Size = 0;
                    }
                    company.Form = reader["Form"].ToString();
                }
                connection.Close();

                return company;
            }
        }

        public void DeleteCompany(int? id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("DeleteCompany", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
