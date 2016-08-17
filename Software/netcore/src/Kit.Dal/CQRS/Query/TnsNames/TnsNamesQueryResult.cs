﻿using System.Collections;
using System.Collections.Generic;
using Kit.Kernel.CQRS.Query;

namespace Kit.Dal.CQRS.Query.TnsNames
{
    public class TnsNamesQueryResult : IEnumerable<string>, IQueryResult
    {
        private IEnumerable<string> _items = new string[0];

        public IEnumerable<string> Items
        {
            set
            {
                if (value != null)
                    _items = value;
            }
        }

        public IEnumerator<string> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
