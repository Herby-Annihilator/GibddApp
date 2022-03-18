using System.Data.Common;
using System.Threading.Tasks;

namespace GibddApp.API.Data.Base
{
    public abstract class Entity : IEntity
    {
        protected int _id = 0;
        [DbAttributeName($"id_{nameof(Entity)}")]
        public int Id => _id;

        public abstract string GetProperties();

        public abstract string GetPropertiesValues();

        public abstract Task SetPropertiesValues(DbDataReader dataReader);
    }
}
