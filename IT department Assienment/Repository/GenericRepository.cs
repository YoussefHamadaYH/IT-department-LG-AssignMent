using IT_department_Assienment.IRepository;
using IT_department_Assienment.Models;
using Microsoft.EntityFrameworkCore;

namespace IT_department_Assienment.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ITdepartmentContext _dbcontext; 
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ITdepartmentContext dbcontext)
        {
            _dbcontext = dbcontext; 
            _dbSet = _dbcontext.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void DeleteById(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void SaveChanges()
        {
            _dbcontext.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
