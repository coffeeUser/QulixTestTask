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
        IEnumerable<CompanyViewModel> GetAll();
        void Add(CompanyViewModel model);
        void Update(CompanyViewModel model);
        CompanyViewModel Get(int? id);
        void Delete(int? id);
    }
}
