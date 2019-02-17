using EmployeeRegistration.Data.Contracts.Entities;
using EmployeeRegistration.Data.Contracts.Repositories;
using EmployeeRegistration.Data.Repositories.Repositories;
using EmployeeRegistration.Domain.Contracts.Services;
using EmployeeRegistration.Domain.Contracts.ViewModels;
using EmployeeRegistration.Infrastructure;
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
                EmployeeViewModel employeeViewModel = Mapper.EmployeeMapper(employee);
                employeeViewModels.Add(employeeViewModel);
            }

            return employeeViewModels;
        }

        public void Add(EmployeeViewModel model)
        {
            Employee employee = Mapper.EmployeeViewModelMapper(model);
            employeeRepository.Add(employee);
            companyRepository.UpdateSize(model.CompanyId);
        }

        public void Update(EmployeeViewModel model)
        {
            Employee employeeEntity = employeeRepository.Get(model.Id);
            Employee employee = Mapper.EmployeeViewModelMapper(model);
            employeeRepository.Update(employee);

            if (model.CompanyId != employeeEntity.CompanyId)
            {
                companyRepository.UpdateSize(model.CompanyId);
                companyRepository.UpdateSize(employeeEntity.CompanyId);
            }
          
        }

        public IEnumerable<EmployeeViewModel> GetCompanyEmployees(int? companyId)
        {
            IEnumerable<Employee> employees = employeeRepository.GetCompanyEmployees(companyId);
            List<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>();

            foreach (var employee in employees)
            {
                EmployeeViewModel employeeViewModel = Mapper.EmployeeMapper(employee);
                employeeViewModels.Add(employeeViewModel);
            }

            return employeeViewModels;
        }

        public IEnumerable<EmployeeViewModel> GetEmployeesByPosition(int id)
        {
            IEnumerable<Employee> employees = employeeRepository.GetEmployeesByPosition(id);
            List<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>();

            foreach (var employee in employees)
            {
                EmployeeViewModel employeeViewModel = Mapper.EmployeeMapper(employee);
                employeeViewModels.Add(employeeViewModel);
            }

            return employeeViewModels;
        }

        public EmployeeViewModel Get(int? id)
        {
            Employee employee = employeeRepository.Get(id);
            EmployeeViewModel employeeViewModel = Mapper.EmployeeMapper(employee);
            return employeeViewModel;
        }

        public void Delete(int? id)
        {
            Employee employee = employeeRepository.Get(id);
            employeeRepository.Delete(id);
            companyRepository.UpdateSize(employee.CompanyId);
        }
    }
}
