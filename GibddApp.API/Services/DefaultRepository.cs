using GibddApp.API.Data.Base;
using GibddApp.API.Services.Base;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GibddApp.API.Services
{
    public class DefaultRepository<T> : IRepository<T> where T : IEntity
    {
        public Task CreateEntity(T entity, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteById(int id, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<T> GetById(int id, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateEntity(T entity, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}
