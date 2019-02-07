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
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        public int Size { get; set; }
        [Required]
        [MaxLength(20)]
        public string Form { get; set; }
    }
}
