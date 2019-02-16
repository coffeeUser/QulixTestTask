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

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public int Size { get; set; }

        [Required]
        public int FormId { get; set; }

        [MaxLength(20)]
        public FormViewModel Form { get; set; }

        public IEnumerable<EmployeeViewModel> Employees { get; set; }
    }
}
