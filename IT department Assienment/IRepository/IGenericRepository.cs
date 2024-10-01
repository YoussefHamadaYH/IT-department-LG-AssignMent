using IT_department_Assienment.Models;

namespace IT_department_Assienment.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void DeleteById(int id);
        void SaveChanges();
    }
}
