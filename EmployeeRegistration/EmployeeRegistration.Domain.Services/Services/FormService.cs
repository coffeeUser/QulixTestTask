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
    public class FormService : IFormService
    {
        private readonly IFormRepository formRepository;

        public FormService()
        {
            formRepository = new FormRepository();
        }

        public IEnumerable<FormViewModel> GetAll()
        {
            IEnumerable<Form> formEntities = formRepository.GetAll();
            List<FormViewModel> forms = new List<FormViewModel>();

            foreach (var item in formEntities)
            {
                FormViewModel form = Mapper.FormMapper(item);
                forms.Add(form);
            }
            return forms;
        }
    }
}
