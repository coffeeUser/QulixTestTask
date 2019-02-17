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

        [Required(ErrorMessage = "Please, enter name")]
        [MaxLength(20, ErrorMessage = "Max length 20 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please, enter surname")]
        [MaxLength(20, ErrorMessage = "Max length 20 characters")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Please, enter second name")]
        [MaxLength(20, ErrorMessage = "Max length 20 characters")]
        public string SecondName { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please, choose the date")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Please, choose position")]
        public int PositionId { get; set; }
        public PositionViewModel Position { get; set; }

        [Required(ErrorMessage = "Please, choose company")]
        public int CompanyId { get; set; }
        public CompanyViewModel Company { get; set; }
    }
}
