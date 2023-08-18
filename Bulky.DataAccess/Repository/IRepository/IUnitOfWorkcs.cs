using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository.IRepository
{
    public interface IUnitOfWorkcs
    {
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }

        void Save();
    }
}
