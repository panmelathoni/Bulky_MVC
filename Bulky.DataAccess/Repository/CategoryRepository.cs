using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;

namespace Bulky.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {

        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        void ICategoryRepository.Save()
        {
            _db.SaveChanges();
        }

        void ICategoryRepository.Update(Category obj)
        {
            _db.Update(obj);
        }
    }
}
