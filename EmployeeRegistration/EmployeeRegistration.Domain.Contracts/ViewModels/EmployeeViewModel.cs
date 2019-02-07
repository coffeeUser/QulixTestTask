using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRegistration.Domain.Contracts.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string SecondName { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public int CompanyId { get; set; }
    }
}
