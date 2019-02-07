using EmployeeRegistration.Data.Contracts.Entities;
using EmployeeRegistration.Data.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EmployeeRegistration.Data.Repositories.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        string connectionString = "Server=.\\SQLEXPRESS;Database=EmployeeRegistrationDb;Trusted_Connection=True;MultipleActiveResultSets=true";

        public IEnumerable<Employee> GetAll()
        {
            List<Employee> employees = new List<Employee>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GetAllEmployees", connection);
                command.CommandType = CommandType.StoredProcedure;

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
                connection.Close();

                return employees;
            }
        }

        public void Add(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("AddEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Name", employee.Name);
                command.Parameters.AddWithValue("@Surname", employee.Surname);
                command.Parameters.AddWithValue("@SecondName", employee.SecondName);
                command.Parameters.AddWithValue("@Date", employee.Date);
                command.Parameters.AddWithValue("@Position", employee.Position);
                command.Parameters.AddWithValue("@CompanyId", employee.CompanyId);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Update(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
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

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public Employee Get(int? id)
        {
            Employee employee = new Employee();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                StringBuilder sqlQuery = new StringBuilder("SELECT * FROM Employees WHERE ID=");
                sqlQuery.Append(id);

                SqlCommand command = new SqlCommand(sqlQuery.ToString(), connection);

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
                connection.Close();

                return employee;
            }
        }

        public void Delete(int? id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("DeleteEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
