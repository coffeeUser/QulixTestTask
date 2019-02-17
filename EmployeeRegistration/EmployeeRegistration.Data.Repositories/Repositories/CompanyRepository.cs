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
            Company company = new Company();

            using (SqlConnection connection = new SqlConnection(AppSetting.ConnectionString))
            {
                SqlCommand command = new SqlCommand("GetAllCompanies", connection);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        List<Employee> employees = new List<Employee>();
                        if (company.Id != Convert.ToInt32(reader["CompanyId"]))
                        {
                            company = Creator.CompanyCreator(reader);
                            company.Form = Creator.FormCreator(reader);

                            for (int i = 0; i < company.Size; i++)
                            {
                                employees.Add(Creator.EmployeeCreator(reader));
                            }
                            company.Employees = employees;
                        }
                        if (!companies.Contains(company))
                        {
                            companies.Add(company);
                        }
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
            using (SqlConnection connection = new SqlConnection(AppSetting.ConnectionString))
            {
                SqlCommand command = new SqlCommand("AddCompany", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@CompanyName", company.Name);
                command.Parameters.AddWithValue("@Size", 0);
                command.Parameters.AddWithValue("@Form", company.FormId);

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
            using (SqlConnection connection = new SqlConnection(AppSetting.ConnectionString))
            {
                SqlCommand command = new SqlCommand("UpdateCompany", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", company.Id);
                command.Parameters.AddWithValue("@CompanyName", company.Name);
                command.Parameters.AddWithValue("@Size", company.Employees.Count);
                command.Parameters.AddWithValue("@Form", company.FormId);

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
            Company company = null;

            using (SqlConnection connection = new SqlConnection(AppSetting.ConnectionString))
            {
                SqlCommand command = new SqlCommand("GetCompanyById", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    List<Employee> employees = new List<Employee>();
                    while (reader.Read())
                    {
                        company = Creator.CompanyCreator(reader);
                        company.Form = Creator.FormCreator(reader);
                        if (company.Size != 0)
                        {
                            employees.Add(Creator.EmployeeCreator(reader));
                        }
                    }
                    if (employees.Count != 0)
                    {
                        company.Employees = employees;
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
            using (SqlConnection connection = new SqlConnection(AppSetting.ConnectionString))
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

        public void UpdateSize(int? id)
        {
            using (SqlConnection connection = new SqlConnection(AppSetting.ConnectionString))
            {
                SqlCommand command = new SqlCommand("UpdateCompanySize", connection);
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
