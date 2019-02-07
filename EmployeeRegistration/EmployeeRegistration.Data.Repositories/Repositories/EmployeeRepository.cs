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
    public class EmployeeRepository : IEmployeeRepository
    {        
        public IEnumerable<Employee> GetAll()
        {
            List<Employee> employees = new List<Employee>();

            using (SqlConnection connection = new SqlConnection(Consts.ConnectionString))
            {
                SqlCommand command = new SqlCommand("GetAllEmployees", connection);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Employee employee = new Employee();
                        employee.Id = Convert.ToInt32(reader["Id"]);
                        employee.Name = reader["Name"].ToString();
                        employee.Surname = reader["Surname"].ToString();
                        employee.SecondName = reader["SecondName"].ToString();
                        employee.Date = Convert.ToDateTime(reader["Date"]);
                        employee.Position = reader["Position"].ToString();
                        employee.CompanyId = Convert.ToInt32(reader["CompanyId"]);

                        employees.Add(employee);
                    }
                }

                finally
                {
                    connection.Close();
                }
                
                return employees;
            }
        }

        public void Add(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(Consts.ConnectionString))
            {
                SqlCommand command = new SqlCommand("AddEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Name", employee.Name);
                command.Parameters.AddWithValue("@Surname", employee.Surname);
                command.Parameters.AddWithValue("@SecondName", employee.SecondName);
                command.Parameters.AddWithValue("@Date", employee.Date);
                command.Parameters.AddWithValue("@Position", employee.Position);
                command.Parameters.AddWithValue("@CompanyId", employee.CompanyId);

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

        public void Update(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(Consts.ConnectionString))
            {
                SqlCommand command = new SqlCommand("UpdateEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", employee.Id);
                command.Parameters.AddWithValue("@Name", employee.Name);
                command.Parameters.AddWithValue("@Surname", employee.Surname);
                command.Parameters.AddWithValue("@SecondName", employee.SecondName);
                command.Parameters.AddWithValue("@Date", employee.Date);
                command.Parameters.AddWithValue("@Position", employee.Position);
                command.Parameters.AddWithValue("@CompanyId", employee.CompanyId);

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

        public IEnumerable<Employee> GetCompanyEmployees(int? companyId)
        {
            List<Employee> employees = new List<Employee>();

            using (SqlConnection connection = new SqlConnection(Consts.ConnectionString))
            {
                SqlCommand command = new SqlCommand("GetCompanyEmployees", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@CompanyId", companyId);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Employee employee = new Employee();
                        employee.Id = Convert.ToInt32(reader["Id"]);
                        employee.Name = reader["Name"].ToString();
                        employee.Surname = reader["Surname"].ToString();
                        employee.SecondName = reader["SecondName"].ToString();
                        employee.Date = Convert.ToDateTime(reader["Date"]);
                        employee.Position = reader["Position"].ToString();
                        employee.CompanyId = Convert.ToInt32(reader["CompanyId"]);

                        employees.Add(employee);
                    }
                }
                finally
                {
                    connection.Close();
                }
                
                return employees;
            }
        }

        public IEnumerable<Employee> GetEmployeesByPosition(string position)
        {
            List<Employee> employees = new List<Employee>();

            using (SqlConnection connection = new SqlConnection(Consts.ConnectionString))
            {
                SqlCommand command = new SqlCommand("GetEmployeesByPosition", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Position", position);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Employee employee = new Employee();
                        employee.Id = Convert.ToInt32(reader["Id"]);
                        employee.Name = reader["Name"].ToString();
                        employee.Surname = reader["Surname"].ToString();
                        employee.SecondName = reader["SecondName"].ToString();
                        employee.Date = Convert.ToDateTime(reader["Date"]);
                        employee.Position = reader["Position"].ToString();
                        employee.CompanyId = Convert.ToInt32(reader["CompanyId"]);

                        employees.Add(employee);
                    }
                }

                finally
                {
                    connection.Close();
                }
                
                return employees;
            }
        }

        public Employee Get(int? id)
        {
            Employee employee = new Employee();

            using (SqlConnection connection = new SqlConnection(Consts.ConnectionString))
            {
                StringBuilder sqlQuery = new StringBuilder("SELECT * FROM Employees WHERE ID=");
                sqlQuery.Append(id);

                SqlCommand command = new SqlCommand(sqlQuery.ToString(), connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        employee.Id = Convert.ToInt32(reader["Id"]);
                        employee.Name = reader["Name"].ToString();
                        employee.Surname = reader["Surname"].ToString();
                        employee.SecondName = reader["SecondName"].ToString();
                        employee.Date = Convert.ToDateTime(reader["Date"]);
                        employee.Position = reader["Position"].ToString();
                        employee.CompanyId = Convert.ToInt32(reader["CompanyId"]);
                    }
                }
                finally
                {
                    connection.Close();
                }
               
                return employee;
            }
        }

        public void Delete(int? id)
        {
            using (SqlConnection connection = new SqlConnection(Consts.ConnectionString))
            {
                SqlCommand command = new SqlCommand("DeleteEmployee", connection);
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
