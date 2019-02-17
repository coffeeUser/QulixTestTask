using EmployeeRegistration.Domain.Contracts.Services;
using EmployeeRegistration.Domain.Contracts.ViewModels;
using EmployeeRegistration.Domain.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRegistration.Domain.Services
{
    public static class SelectHelper
    {
        private static ICompanyService companyService;
        private static IFormService formService;
        private static IPositionService positionService;

        static SelectHelper()
        {
            companyService = new CompanyService();
            formService = new FormService();
            positionService = new PositionService();
        }

        public static IEnumerable<PositionViewModel> Positions { get; set; }
        public static IEnumerable<FormViewModel> Forms { get; set; }
        public static IEnumerable<CompanyViewModel> Companies { get; set; }

        public static IEnumerable<FormViewModel> GetForms()
        {
            if (Forms == null)
            {
                Forms = formService.GetAll();
            }
            return Forms;
        }

        public static IEnumerable<CompanyViewModel> GetCompanies()
        {
            if (Companies == null)
            {
                Companies = companyService.GetAll();
            }
            return Companies;
        }

        public static IEnumerable<PositionViewModel> GetPositions()
        {
            if (Positions == null)
            {
                Positions = positionService.GetAll();
            }
            return Positions;
        }
    }
}
