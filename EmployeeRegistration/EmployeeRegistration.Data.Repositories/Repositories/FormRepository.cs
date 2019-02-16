using EmployeeRegistration.Data.Contracts.Entities;
using EmployeeRegistration.Data.Contracts.Repositories;
using EmployeeRegistration.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRegistration.Data.Repositories.Repositories
{
    public class FormRepository : IFormRepository
    {
        public IEnumerable<Form> GetAll()
        {
            List<Form> forms = new List<Form>();

            using (SqlConnection connection = new SqlConnection(AppSetting.ConnectionString))
            {
                SqlCommand command = new SqlCommand("GetAllForms", connection);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Form form = Creator.FormCreator(reader);
                        forms.Add(form);
                    }
                }

                finally
                {
                    connection.Close();
                }
                return forms;
            }
        }
    }
}
