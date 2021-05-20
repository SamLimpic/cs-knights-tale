using System.Collections.Generic;

namespace cs_knights_tale.Repositories
{
    public interface IRepository<T>
    {
        T Create(T t);

        T GetById(int id);

        IEnumerable<T> GetAll();

        bool Delete(int id);
    }
}