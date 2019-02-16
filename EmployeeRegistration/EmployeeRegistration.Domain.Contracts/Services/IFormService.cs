using EmployeeRegistration.Domain.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRegistration.Domain.Contracts.Services
{
    public interface IFormService
    {
        IEnumerable<FormViewModel> GetAll();
    }
}
