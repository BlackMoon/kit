using System;
using System.Data.Entity;
using System.Linq.Expressions;
using Mappings;

namespace Kit.Dal.Repository
{
    public class SysMenuItemRepository : Repository<SysMenuItem>
    {
        public SysMenuItemRepository(DbContext ctx) : base(ctx)
        {
            
        }
        public SysMenuItem FindByKey(long key)
        {
            return Find(s => s.No == key);
        }
    }
}
