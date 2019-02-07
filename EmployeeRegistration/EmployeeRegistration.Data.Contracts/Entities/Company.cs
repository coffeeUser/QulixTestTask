using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRegistration.Data.Contracts.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public string Form { get; set; }
    }
}
