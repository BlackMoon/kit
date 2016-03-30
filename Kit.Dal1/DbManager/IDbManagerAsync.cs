#if ASYNC
using System.Threading;
using System.Threading.Tasks;

namespace Kit.Dal.DbManager
{
    public partial interface IDbManager
    {
        Task OpenAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
#endif