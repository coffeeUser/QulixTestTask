using EmployeeRegistration.Data.Contracts.Entities;
using EmployeeRegistration.Data.Contracts.Repositories;
using EmployeeRegistration.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EmployeeRegistration.Data.Repositories.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        public IEnumerable<Company> GetAll()
        {
            List<Company> companies = new List<Company>();

            using (SqlConnection connection = new SqlConnection(Consts.ConnectionString))
            {
                SqlCommand command = new SqlCommand("GetAllCompanies", connection);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Company company = new Company();
                        company.Id = Convert.ToInt32(reader["Id"]);
                        company.Name = reader["Name"].ToString();
                        company.Size = Convert.ToInt32(reader["Size"]);
                        company.Form = reader["Form"].ToString();

                        companies.Add(company);
                    }
                }

                finally
                {
                    connection.Close();
                }

                return companies;
            }
        }

        public void Add(Company company)
        {
            using (SqlConnection connection = new SqlConnection(Consts.ConnectionString))
            {
                SqlCommand command = new SqlCommand("AddCompany", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Name", company.Name);
                command.Parameters.AddWithValue("@Size", 0);
                command.Parameters.AddWithValue("@Form", company.Form);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }

                finally
                {
                    connection.Close();
                }
            }
        }

        public void Update(Company company)
        {
            using (SqlConnection connection = new SqlConnection(Consts.ConnectionString))
            {
                SqlCommand command = new SqlCommand("UpdateCompany", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", company.Id);
                command.Parameters.AddWithValue("@Name", company.Name);
                command.Parameters.AddWithValue("@Size", company.Size);
                command.Parameters.AddWithValue("@Form", company.Form);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }

                finally
                {
                    connection.Close();
                }
            }
        }

        public Company Get(int? id)
        {
            Company company = new Company();

            using (SqlConnection connection = new SqlConnection(Consts.ConnectionString))
            {
                StringBuilder sqlQuery = new StringBuilder("SELECT * FROM Companies WHERE ID=");
                sqlQuery.Append(id);

                SqlCommand command = new SqlCommand(sqlQuery.ToString(), connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        company.Id = Convert.ToInt32(reader["Id"]);
                        company.Name = reader["Name"].ToString();
                        company.Size = Convert.ToInt32(reader["Size"]);
                        company.Form = reader["Form"].ToString();
                    }
                }

                finally
                {
                    connection.Close();
                }

                return company;
            }
        }

        public void Delete(int? id)
        {
            using (SqlConnection connection = new SqlConnection(Consts.ConnectionString))
            {
                SqlCommand command = new SqlCommand("DeleteCompany", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }

                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
