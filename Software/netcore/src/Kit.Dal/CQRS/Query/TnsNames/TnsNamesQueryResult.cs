using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Kit.Kernel.CQRS.Query;

namespace Kit.Dal.CQRS.Query.TnsNames
{
    public class TnsNamesQueryResult : IReadOnlyCollection<string>, IQueryResult
    {
        private string[] _items = new string[0];

        public int Count => _items.Length;

        public IEnumerable<string> Items
        {
            set
            {
                if (value != null)
                    _items = value.ToArray();
            }
        }

        public IEnumerator<string> GetEnumerator()
        {
            return _items.AsEnumerable().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
