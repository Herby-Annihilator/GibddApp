using GibddApp.API.Data.Base;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GibddApp.API.Services.Base
{
    public interface IRepository<T> where T : IEntity
    {
        Task<T> GetById(int id, CancellationToken cancellationToken = default);

        Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken = default);

        Task CreateEntity(T entity, CancellationToken cancellationToken = default);

        Task DeleteById(int id, CancellationToken cancellationToken = default);

        Task UpdateEntity(T entity, CancellationToken cancellationToken = default);
    }
}
