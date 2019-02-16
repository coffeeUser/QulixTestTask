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
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository positionRepository;

        public PositionService()
        {
            positionRepository = new PositionRepository();
        }

        public IEnumerable<PositionViewModel> GetAll()
        {
            IEnumerable<Position> positionEntities = positionRepository.GetAll();
            List<PositionViewModel> positions = new List<PositionViewModel>();

            foreach (var item in positionEntities)
            {
                PositionViewModel position = Mapper.PositionMapper(item);
                positions.Add(position);
            }
            return positions;
        }
    }
}
