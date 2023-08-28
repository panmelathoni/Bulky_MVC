using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models.ViewModels;
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
            _db.Products.Include(u => u.Category).Include(u => u.CategoryId);
        }

     

        public ApplicationDbContext Db { get; }

        public void Add(T entity)
        {
            this.dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = this.dbSet;
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(string? includeProperties = null)
        {         
            IQueryable<T> query = this.dbSet;
            if(!string.IsNullOrEmpty(includeProperties))
            {
                foreach(var includeProp in includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries)) 
                {
                    query = query.Include(includeProp);
                }
            }
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
        public void Update(T entity)
        {
            _db.Update(entity);
        }
    }

}

