using EmployeeRegistration.Domain.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRegistration.Domain.Contracts.Services
{
    public interface IEmployeeService
    {
        /// <summary>
        /// Gets all data from Employees table from database without any parameters,
        /// returns collection of employees.
        /// </summary>
        /// <returns></returns>
        IEnumerable<EmployeeViewModel> GetAll();

        /// <summary>
        /// Adds data to Employees table from database, expected certain model type of EmployeeViewModel in parameters.
        /// Takes into account the change in the field value of 'Size' of CompanyViewModel.
        /// </summary>
        void Add(EmployeeViewModel model);

        /// <summary>
        /// Updates specific entry in Employees table, expected model in parameters.
        /// Takes into account the change in the field value of 'Size' of CompanyViewModel.
        /// </summary>
        void Update(EmployeeViewModel model);

        /// <summary>
        /// Gets collection of entries from Employees table with the same company. Used to filter.
        /// </summary>
        IEnumerable<EmployeeViewModel> GetCompanyEmployees(int? companyId);

        /// <summary>
        /// Gets collection of entries from Employees table with the same position. Used to filter.
        /// </summary>
        IEnumerable<EmployeeViewModel> GetEmployeesByPosition(int id);

        /// <summary>
        /// Gets one entry with specific Id from Employees table.
        /// </summary>
        EmployeeViewModel Get(int? id);

        /// <summary>
        /// Removes one entry with specific Id from Employees table.
        /// Takes into account the change in the field value of 'Size' of CompanyViewModel.
        /// </summary>
        void Delete(int? id);
    }
}
