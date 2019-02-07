using EmployeeRegistration.Data.Contracts.Entities;
using EmployeeRegistration.Data.Repositories.Repositories;
using EmployeeRegistration.Domain.Contracts.Services;
using EmployeeRegistration.Domain.Contracts.ViewModels;
using System.Collections.Generic;

namespace EmployeeRegistration.Domain.Services.Services
{
    public class EmployeeService : IEmployeeService
    {
        EmployeeRepository employeeRepository = new EmployeeRepository();

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
        }

        public void Update(EmployeeViewModel model)
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

            employeeRepository.Update(employee);
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
            return employeeViewModel;
        }

        public void Delete(int? id)
        {
            employeeRepository.Delete(id);
        }
    }
}
