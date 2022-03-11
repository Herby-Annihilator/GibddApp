using GibddApp.Core.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GibddApp.Core.Services
{
    public interface IStorageEntityHandler<T> where T : IEntity
    {
        Task SaveEntity(T entity);
        Task DeleteEntity(T entity);
        Task UpdateEntity(T oldEntity, T newEntity);
        Task<T> GetEntity(Func<string> query);
    }
}
