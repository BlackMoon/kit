using System.Threading;
using System.Threading.Tasks;

namespace Kit.Dal.DbManager
{
    public interface IDbManagerAsync
    {
        Task OpenAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}