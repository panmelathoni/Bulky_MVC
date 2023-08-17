using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Bulky.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

     

        public ApplicationDbContext Db { get; }

        public void Add(T entity)
        {
            this.dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = this.dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {         
            IQueryable<T> query = this.dbSet;
            return query.ToList();
        }

        public void Remove(T entity)
        {
           this.dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            this.dbSet.RemoveRange(entity);
        }

    
    }
}
