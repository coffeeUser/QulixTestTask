using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRegistration.Data.Contracts.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string SecondName { get; set; }
        public DateTime Date { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
