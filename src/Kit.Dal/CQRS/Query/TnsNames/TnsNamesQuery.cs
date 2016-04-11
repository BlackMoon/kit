using Kit.Kernel.CQRS.Query;

namespace Kit.Dal.CQRS.Query.TnsNames
{
    public class TnsNamesQuery : IQuery
    {
        public string ProviderInvariantName { get; set; }
    }
}
