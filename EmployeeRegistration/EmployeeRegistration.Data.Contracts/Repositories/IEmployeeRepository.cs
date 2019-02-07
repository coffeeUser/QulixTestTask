using EmployeeRegistration.Data.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRegistration.Data.Contracts.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        /// <summary>
        /// Gets collection of entries from Employees table with the same company. Used to filter.
        /// </summary>
        IEnumerable<Employee> GetCompanyEmployees(int? companyId);

        /// <summary>
        /// Gets collection of entries from Employees table with the same position. Used to filter.
        /// </summary>
        IEnumerable<Employee> GetEmployeesByPosition(string position);
    }
}
