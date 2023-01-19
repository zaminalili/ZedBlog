using ZedBlog.Core.Entities;
using ZedBlog.Data.Repositories;

namespace ZedBlog.Data.UnitOfWorks
{
    public interface IUnitOfWork: IAsyncDisposable
    {
        Repository<T> GetRepository<T>() where T : class, IEntityBase, new();
        Task<int> SaveAsync();
        int Save();
    }
}
