using System.Collections.Generic;

namespace EmployeeRegistration.Data.Contracts.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        void Add(T model);
        void Update(T model);
        T Get(int? id);
        void Delete(int? id);
    }
}
