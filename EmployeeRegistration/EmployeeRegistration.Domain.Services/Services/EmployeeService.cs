using EmployeeRegistration.Data.Contracts.Entities;
using EmployeeRegistration.Data.Contracts.Repositories;
using EmployeeRegistration.Data.Repositories.Repositories;
using EmployeeRegistration.Domain.Contracts.Services;
using EmployeeRegistration.Domain.Contracts.ViewModels;
using System.Collections.Generic;

namespace EmployeeRegistration.Domain.Services.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly ICompanyRepository companyRepository;

        public EmployeeService()
        {
            employeeRepository = new EmployeeRepository();
            companyRepository = new CompanyRepository();
        }

        public IEnumerable<EmployeeViewModel> GetAll()
        {
            IEnumerable<Employee> employees = employeeRepository.GetAll();
            List<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>();

            foreach (var employee in employees)
            {
                EmployeeViewModel employeeViewModel = new EmployeeViewModel()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Surname = employee.Surname,
                    SecondName = employee.SecondName,
                    Date = employee.Date,
                    Position = employee.Position,
                    CompanyId = employee.CompanyId
                };
                Company company = companyRepository.Get(employee.CompanyId);
                employeeViewModel.Company = new CompanyViewModel()
                {
                    Id = company.Id,
                    Name = company.Name,
                    Size = company.Size,
                    Form = company.Form
                };
                employeeViewModels.Add(employeeViewModel);
            }

            return employeeViewModels;
        }

        public void Add(EmployeeViewModel model)
        {
            Employee employee = new Employee()
            {
                Id = model.Id,
                Name = model.Name,
                Surname = model.Surname,
                SecondName = model.SecondName,
                Date = model.Date,
                Position = model.Position,
                CompanyId = model.CompanyId
            };

            employeeRepository.Add(employee);
            Company company = companyRepository.Get(model.CompanyId);
            company.Size = ++company.Size;
            companyRepository.Update(company);
        }

        public void Update(EmployeeViewModel model)
        {
            Employee employeeEntity = employeeRepository.Get(model.Id);
            if (model.CompanyId != employeeEntity.CompanyId)
            {
                Company company = companyRepository.Get(employeeEntity.CompanyId);
                company.Size = --company.Size;
                companyRepository.Update(company);
                company = companyRepository.Get(model.CompanyId);
                company.Size = ++company.Size;
                companyRepository.Update(company);
            }
            Employee employee = new Employee()
            {
                Id = model.Id,
                Name = model.Name,
                Surname = model.Surname,
                SecondName = model.SecondName,
                Date = model.Date,
                Position = model.Position,
                CompanyId = model.CompanyId
            };

            employeeRepository.Update(employee);           
        }

        public IEnumerable<EmployeeViewModel> GetCompanyEmployees(int? companyId)
        {
            IEnumerable<Employee> employees = employeeRepository.GetCompanyEmployees(companyId);
            List<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>();

            foreach (var employee in employees)
            {
                EmployeeViewModel employeeViewModel = new EmployeeViewModel()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Surname = employee.Surname,
                    SecondName = employee.SecondName,
                    Date = employee.Date,
                    Position = employee.Position,
                    CompanyId = employee.CompanyId
                };
                Company company = companyRepository.Get(employee.CompanyId);
                employeeViewModel.Company = new CompanyViewModel()
                {
                    Id = company.Id,
                    Name = company.Name,
                    Size = company.Size,
                    Form = company.Form
                };
                employeeViewModels.Add(employeeViewModel);
            }

            return employeeViewModels;
        }

        public IEnumerable<EmployeeViewModel> GetEmployeesByPosition(string position)
        {
            IEnumerable<Employee> employees = employeeRepository.GetEmployeesByPosition(position);
            List<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>();

            foreach (var employee in employees)
            {
                EmployeeViewModel employeeViewModel = new EmployeeViewModel()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Surname = employee.Surname,
                    SecondName = employee.SecondName,
                    Date = employee.Date,
                    Position = employee.Position,
                    CompanyId = employee.CompanyId
                };
                Company company = companyRepository.Get(employee.CompanyId);
                employeeViewModel.Company = new CompanyViewModel()
                {
                    Id = company.Id,
                    Name = company.Name,
                    Size = company.Size,
                    Form = company.Form
                };
                employeeViewModels.Add(employeeViewModel);
            }

            return employeeViewModels;
        }

        public EmployeeViewModel Get(int? id)
        {
            Employee employee = employeeRepository.Get(id);
            EmployeeViewModel employeeViewModel = new EmployeeViewModel()
            {
                Id = employee.Id,
                Name = employee.Name,
                Surname = employee.Surname,
                SecondName = employee.SecondName,
                Date = employee.Date,
                Position = employee.Position,
                CompanyId = employee.CompanyId
            };
            Company company = companyRepository.Get(employee.CompanyId);
            employeeViewModel.Company = new CompanyViewModel()
            {
                Id = company.Id,
                Name = company.Name,
                Size = company.Size,
                Form = company.Form
            };
            return employeeViewModel;
        }

        public void Delete(int? id)
        {
            Employee employee = employeeRepository.Get(id);
            Company company = companyRepository.Get(employee.CompanyId);
            company.Size = --company.Size;
            companyRepository.Update(company);
            employeeRepository.Delete(id);
        }
    }
}
