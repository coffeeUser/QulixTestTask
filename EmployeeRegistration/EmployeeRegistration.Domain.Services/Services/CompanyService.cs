using EmployeeRegistration.Data.Contracts.Entities;
using EmployeeRegistration.Data.Contracts.Repositories;
using EmployeeRegistration.Data.Repositories.Repositories;
using EmployeeRegistration.Domain.Contracts.Services;
using EmployeeRegistration.Domain.Contracts.ViewModels;
using EmployeeRegistration.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRegistration.Domain.Services.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository companyRepository;
        private readonly IEmployeeRepository employeeRepository;

        public CompanyService()
        {
            companyRepository = new CompanyRepository();
            employeeRepository = new EmployeeRepository();
        }

        public IEnumerable<CompanyViewModel> GetAll()
        {
            IEnumerable<Company> companies = companyRepository.GetAll();
            List<CompanyViewModel> companyViewModels = new List<CompanyViewModel>();

            foreach (var company in companies)
            {
                CompanyViewModel companyViewModel = Mapper.CompanyMapper(company);
                companyViewModels.Add(companyViewModel);
            }
            return companyViewModels;
        }

        public void Add(CompanyViewModel model)
        {
            Company company = Mapper.CompanyViewModelMapper(model);
            companyRepository.Add(company);
        }

        public void Update(CompanyViewModel model)
        {
            Company company = Mapper.CompanyViewModelMapper(model);
            companyRepository.Update(company);
        }

        public CompanyViewModel Get(int? id)
        {
            Company company = companyRepository.Get(id);
            CompanyViewModel companyViewModel = Mapper.CompanyMapper(company);
            return companyViewModel;
        }

        public void Delete(int? id)
        {
            IEnumerable<Employee> employees = employeeRepository.GetCompanyEmployees(id);
            if (employees.Count() > 0)
            {
                foreach (Employee employee in employees)
                {
                    employeeRepository.Delete(employee.Id);
                }
            }
            companyRepository.Delete(id);
        }
    }
}
