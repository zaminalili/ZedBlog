using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZedBlog.Core.Entities;
using ZedBlog.Data.Repositories;

namespace ZedBlog.Data.UnitOfWorks
{
    public interface IUnitOfWork: IAsyncDisposable
    {
        IRepository<T> GetRepository<T>() where T : class, IEntityBase, new();
        int Save();
        Task<int> SaveAsync();
    }
}
