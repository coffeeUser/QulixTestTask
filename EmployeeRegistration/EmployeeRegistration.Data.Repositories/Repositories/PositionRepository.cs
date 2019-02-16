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
    public class PositionRepository : IPositionRepository
    {
        public IEnumerable<Position> GetAll()
        {
            List<Position> positions = new List<Position>();

            using (SqlConnection connection = new SqlConnection(AppSetting.ConnectionString))
            {
                SqlCommand command = new SqlCommand("GetAllPositions", connection);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Position position = Creator.PositionCreator(reader);
                        positions.Add(position);
                    }
                }

                finally
                {
                    connection.Close();
                }
                return positions;
            }
        }
    }
}
