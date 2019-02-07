using System.Collections.Generic;

namespace EmployeeRegistration.Data.Contracts.Repositories
{
    public interface IRepository<T>
    {
        /// <summary> 
        /// Gets all data from specific table from database without any parameters,
        /// returns collection of objects of certain type.
        /// </summary>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Adds data to specific table from database, expected certain model type of T in parameters.
        /// </summary>
        void Add(T model);

        /// <summary>
        /// Updates specific entry in certain table, expected model in parameters.
        /// </summary>
        void Update(T model);

        /// <summary>
        /// Gets one entry with specific Id from certain table.
        /// </summary>
        T Get(int? id);

        /// <summary>
        /// Removes one entry with specific Id from certain table.
        /// </summary>
        void Delete(int? id);
    }
}
