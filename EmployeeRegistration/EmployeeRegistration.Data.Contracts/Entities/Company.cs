using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRegistration.Data.Contracts.Entities
{
    public class Company
    {
        public Company()
        {
            this.Employees = new List<Employee>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public int FormId { get; set; }
        public Form Form { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}
