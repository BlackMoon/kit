using System;
using System.Data.Entity;
using System.Linq.Expressions;
using Mappings;

namespace Kit.Dal.Repository
{
    public class SysMenuItemDbRepository : DbRepository<SysMenuItem>
    {
        public SysMenuItemDbRepository(DbContext ctx) : base(ctx)
        {
            
        }
        public SysMenuItem FindByKey(long key)
        {
            return Find(s => s.No == key);
        }
    }
}
