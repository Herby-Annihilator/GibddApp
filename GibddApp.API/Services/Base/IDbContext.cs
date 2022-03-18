using System.Data;
using System.Data.Common;

namespace GibddApp.API.Services.Base
{
    public interface IDbContext
    {
        DbCommand Command { get; }
        DbConnection Connection { get; }
        string GetConnectionStriing();
    }
}
