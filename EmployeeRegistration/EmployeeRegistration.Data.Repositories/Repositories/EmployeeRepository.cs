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

            using (SqlConnection connection = new SqlConnection(AppSetting.ConnectionString))
            {
                SqlCommand command = new SqlCommand("GetAllEmployees", connection);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Employee employee = Creator.EmployeeCreator(reader);
                        employee.Company = Creator.CompanyCreator(reader);
                        employee.Position = Creator.PositionCreator(reader);
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
            using (SqlConnection connection = new SqlConnection(AppSetting.ConnectionString))
            {
                SqlCommand command = new SqlCommand("AddEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Name", employee.Name);
                command.Parameters.AddWithValue("@Surname", employee.Surname);
                command.Parameters.AddWithValue("@SecondName", employee.SecondName);
                command.Parameters.AddWithValue("@Date", employee.Date);
                command.Parameters.AddWithValue("@Position", employee.PositionId);
                command.Parameters.AddWithValue("@Company", employee.CompanyId);

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
            using (SqlConnection connection = new SqlConnection(AppSetting.ConnectionString))
            {
                SqlCommand command = new SqlCommand("UpdateEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", employee.Id);
                command.Parameters.AddWithValue("@Name", employee.Name);
                command.Parameters.AddWithValue("@Surname", employee.Surname);
                command.Parameters.AddWithValue("@SecondName", employee.SecondName);
                command.Parameters.AddWithValue("@Date", employee.Date);
                command.Parameters.AddWithValue("@Position", employee.PositionId);
                command.Parameters.AddWithValue("@Company", employee.CompanyId);

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

            using (SqlConnection connection = new SqlConnection(AppSetting.ConnectionString))
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
                        Employee employee = Creator.EmployeeCreator(reader);
                        employee.Company = Creator.CompanyCreator(reader);
                        employee.Position = Creator.PositionCreator(reader);
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

        public IEnumerable<Employee> GetEmployeesByPosition(int id)
        {
            List<Employee> employees = new List<Employee>();

            using (SqlConnection connection = new SqlConnection(AppSetting.ConnectionString))
            {
                SqlCommand command = new SqlCommand("GetEmployeesByPosition", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@PositionId", id);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Employee employee = Creator.EmployeeCreator(reader);
                        employee.Company = Creator.CompanyCreator(reader);
                        employee.Position = Creator.PositionCreator(reader);
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
            Employee employee = null;

            using (SqlConnection connection = new SqlConnection(AppSetting.ConnectionString))
            {
                SqlCommand command = new SqlCommand("GetEmployeeById", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        employee = Creator.EmployeeCreator(reader);
                        employee.Company = Creator.CompanyCreator(reader);
                        employee.Position = Creator.PositionCreator(reader);
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
            using (SqlConnection connection = new SqlConnection(AppSetting.ConnectionString))
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
