using EmployeeRegistration.Domain.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRegistration.Domain.Contracts.Services
{
    public interface ICompanyService
    {
        /// <summary>
        /// Gets all data from Companies table from database without any parameters,
        /// returns collection of companies.
        /// </summary>
        IEnumerable<CompanyViewModel> GetAll();

        /// <summary>
        /// Adds data to Companies table from database, expected certain model type of CompanyViewModel in parameters.
        /// </summary>
        void Add(CompanyViewModel model);

        /// <summary>
        /// Updates specific entry in Companies table, expected model in parameters.
        /// </summary>
        void Update(CompanyViewModel model);

        /// <summary>
        /// Gets one entry with specific Id from Companies table.
        /// </summary>
        CompanyViewModel Get(int? id);

        /// <summary>
        /// Removes one entry with specific Id from Companies table.
        /// It's necessary to foresee the deletion of dependent entries from Employees table.
        /// </summary>
        void Delete(int? id);
    }
}
