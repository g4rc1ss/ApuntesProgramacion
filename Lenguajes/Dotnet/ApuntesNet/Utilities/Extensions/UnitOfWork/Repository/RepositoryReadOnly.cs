using Microsoft.EntityFrameworkCore;
using UnitOfWork.Repository.Interfaces;

namespace UnitOfWork.Repository;

internal class RepositoryReadOnly<T> : BaseRepository<T>, IRepositoryReadOnly<T> where T : class
{
    public RepositoryReadOnly(DbContext context) : base(context)
    {
    }
}
