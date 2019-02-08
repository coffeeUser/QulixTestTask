using EmployeeRegistration.Data.Contracts.Entities;
using EmployeeRegistration.Data.Contracts.Repositories;
using EmployeeRegistration.Data.Repositories.Repositories;
using EmployeeRegistration.Domain.Contracts.Services;
using EmployeeRegistration.Domain.Contracts.ViewModels;
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
                CompanyViewModel companyViewModel = new CompanyViewModel()
                {
                    Id = company.Id,
                    Name = company.Name,
                    Size = company.Size,
                    Form = company.Form
                };
                companyViewModels.Add(companyViewModel);
            }
            return companyViewModels;
        }

        public void Add(CompanyViewModel model)
        {
            Company company = new Company()
            {
                Id = model.Id,
                Name = model.Name,
                Size = model.Size,
                Form = model.Form
            };
            companyRepository.Add(company);
        }

        public void Update(CompanyViewModel model)
        {
            Company company = new Company()
            {
                Id = model.Id,
                Name = model.Name,
                Size = model.Size,
                Form = model.Form
            };
            companyRepository.Update(company);
        }

        public CompanyViewModel Get(int? id)
        {
            Company company = companyRepository.Get(id);
            CompanyViewModel companyViewModel = new CompanyViewModel()
            {
                Id = company.Id,
                Name = company.Name,
                Size = company.Size,
                Form = company.Form
            };
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
