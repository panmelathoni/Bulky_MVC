namespace Bulky.DataAccess.Repository.IRepository
{
    public interface IUnitOfWorkcs
    {
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }

        void Save();
    }
}
