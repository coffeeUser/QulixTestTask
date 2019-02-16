using EmployeeRegistration.Data.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRegistration.Infrastructure
{
    public static class Creator
    {
        public static Company CompanyCreator(SqlDataReader reader)
        {
            Company company = new Company();
            company.Id = Convert.ToInt32(reader["CompanyId"]);
            company.Name = reader["CompanyName"].ToString();
            company.Size = Convert.ToInt32(reader["Size"]);
            company.FormId = Convert.ToInt32(reader["Form"]);
            return company;
        }

        public static Form FormCreator(SqlDataReader reader)
        {
            Form form = new Form();
            form.Id = Convert.ToInt32(reader["FormId"]);
            form.Name = reader["FormName"].ToString();
            return form;
        }

        public static Employee EmployeeCreator(SqlDataReader reader)
        {
            Employee employee = new Employee();
            employee.Id = Convert.ToInt32(reader["EmployeeId"]);
            employee.Name = reader["Name"].ToString();
            employee.Surname = reader["Surname"].ToString();
            employee.SecondName = reader["SecondName"].ToString();
            employee.Date = Convert.ToDateTime(reader["Date"]);
            employee.PositionId = Convert.ToInt32(reader["Position"]);
            employee.CompanyId = Convert.ToInt32(reader["Company"]);
            return employee;
        }

        public static Position PositionCreator(SqlDataReader reader)
        {
            Position position = new Position();
            position.Id = Convert.ToInt32(reader["PositionId"]);
            position.Name = reader["PositionName"].ToString();
            return position;
        }
    }
}
