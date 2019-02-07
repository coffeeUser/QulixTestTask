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
        IEnumerable<EmployeeViewModel> GetAll();
        void Add(EmployeeViewModel model);
        void Update(EmployeeViewModel model);
        IEnumerable<EmployeeViewModel> GetCompanyEmployees(int? companyId);
        IEnumerable<EmployeeViewModel> GetEmployeesByPosition(string position);
        EmployeeViewModel Get(int? id);
        void Delete(int? id);
    }
}
