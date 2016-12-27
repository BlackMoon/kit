using Kit.Core.CQRS.Query;

namespace Kit.Dal.Domain.TnsNames.Query
{
    public class TnsNamesQuery : IQuery
    {
        public string ProviderInvariantName { get; set; }
    }
}
