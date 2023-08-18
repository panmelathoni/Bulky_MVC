﻿using Bulky.DataAccess.Data;
using Bulky.Models;

namespace Bulky.DataAccess.Repository.IRepository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product obj)
        {
            _db.Update(obj);
        }
    }

}