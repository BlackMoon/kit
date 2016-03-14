using System;
using System.Data.Entity;
using System.Linq;

namespace Kit.Dal.Repository
{
    public class SysMenuItemRepository : IDbRepository<SysMenuItem>
    {
        public SysMenuItem Find(Predicate<SysMenuItem> predicate)
        {
            throw new NotImplementedException();
        }

        public SysMenuItemRepository(DbContext ctx)
        {
            

        }

        public void Add(SysMenuItem entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(SysMenuItem entity)
        {
            throw new NotImplementedException();
        }

        public void Update(SysMenuItem entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<SysMenuItem> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
