using System.Data.Common;
using System.Threading.Tasks;

namespace GibddApp.API.Data.Base
{
    public interface IEntity
    {
        int Id { get; protected set; }

        string GetProperties();
        string GetPropertiesValues();

        Task SetPropertiesValues(DbDataReader dataReader);
    }
}
