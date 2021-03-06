﻿using EmployeeRegistration.Data.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRegistration.Data.Contracts.Repositories
{
    public interface ICompanyRepository : IRepository<Company>
    {
        void UpdateSize(int? id);
    }
}
