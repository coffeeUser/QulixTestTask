using EmployeeRegistration.Data.Contracts.Entities;
using EmployeeRegistration.Domain.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRegistration.Infrastructure
{
    public static class Mapper
    {
        public static CompanyViewModel CompanyMapper(Company model)
        {
            List<EmployeeViewModel> employees = new List<EmployeeViewModel>();
            CompanyViewModel company = new CompanyViewModel();
            company.Id = model.Id;
            company.Name = model.Name;
            company.Size = model.Size;
            company.FormId = model.FormId;
            if (model.Form != null)
            {
                company.Form = FormMapper(model.Form);
            }
            if (model.Employees.Count() != 0)
            {
                foreach (var item in model.Employees)
                {
                    EmployeeViewModel employee = EmployeeMapper(item);
                    employees.Add(employee);
                }
                company.Employees = employees;
            }
            return company;
        }

        public static FormViewModel FormMapper(Form model)
        {
            FormViewModel form = new FormViewModel();
            form.Id = model.Id;
            form.Name = model.Name;
            return form;
        }

        public static EmployeeViewModel EmployeeMapper(Employee model)
        {
            EmployeeViewModel employee = new EmployeeViewModel();
            employee.Id = model.Id;
            employee.Name = model.Name;
            employee.SecondName = model.SecondName;
            employee.Surname = model.Surname;
            employee.Date = model.Date;
            employee.PositionId = model.PositionId;
            if (model.Position != null)
            {
                employee.Position = PositionMapper(model.Position);
            }
            employee.CompanyId = model.CompanyId;
            if (model.Company != null)
            {
                employee.Company = CompanyMapper(model.Company);
            }
            return employee;
        }

        public static PositionViewModel PositionMapper(Position model)
        {
            PositionViewModel position = new PositionViewModel();
            position.Id = model.Id;
            position.Name = model.Name;
            return position;
        }

        public static Company CompanyViewModelMapper(CompanyViewModel model)
        {
            List<Employee> employees = new List<Employee>();
            Company company = new Company();
            company.Id = model.Id;
            company.Name = model.Name;
            company.Size = model.Size;
            company.FormId = model.FormId;
            if (model.Form != null)
            {
                company.Form = FormViewModelMapper(model.Form);
            }
            if (model.Employees.Count() != 0)
            {
                foreach (var item in model.Employees)
                {
                    Employee employee = EmployeeViewModelMapper(item);
                    employees.Add(employee);
                }
                company.Employees = employees;
            }
            return company;
        }

        public static Form FormViewModelMapper(FormViewModel model)
        {
            Form form = new Form();
            form.Id = model.Id;
            form.Name = model.Name;
            return form;
        }

        public static Employee EmployeeViewModelMapper(EmployeeViewModel model)
        {
            Employee employee = new Employee();
            employee.Id = model.Id;
            employee.Name = model.Name;
            employee.SecondName = model.SecondName;
            employee.Surname = model.Surname;
            employee.Date = model.Date;
            employee.PositionId = model.PositionId;
            if (model.Position != null)
            {
                employee.Position = PositionViewModelMapper(model.Position);
            }
            employee.CompanyId = model.CompanyId;
            if (model.Company != null)
            {
                employee.Company = CompanyViewModelMapper(model.Company);
            }
            return employee;
        }

        public static Position PositionViewModelMapper(PositionViewModel model)
        {
            Position position = new Position();
            position.Id = model.Id;
            position.Name = model.Name;
            return position;
        }
    }
}
