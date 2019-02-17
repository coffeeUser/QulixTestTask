using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRegistration.Domain.Contracts.ViewModels
{
    public class CompanyViewModel
    {
        public CompanyViewModel()
        {
            this.Employees = new List<EmployeeViewModel>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Please, enter the name of company")]
        [MaxLength(20, ErrorMessage = "Max length 20 characters")]
        public string Name { get; set; }

        public int Size { get; set; }

        [Required(ErrorMessage = "Please, choose the form")]
        public int FormId { get; set; }

        public FormViewModel Form { get; set; }

        public List<EmployeeViewModel> Employees { get; set; }
    }
}
