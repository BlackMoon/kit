using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Kit.Kernel.CQRS.Query;

namespace Kit.Dal.CQRS.Query.TnsNames
{
    public class TnsNamesQueryResult : IEnumerable<string>, IQueryResult
    {
        private IEnumerable<string> _items = Enumerable.Empty<string>();

        public IEnumerable<string> Items
        {
            set { _items = value; } 
        }

        public IEnumerator<string> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}
