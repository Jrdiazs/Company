using Company.Models;
using System;

namespace Company.Data
{
    public class RolMenuRepository : GenericRepository<RolMenu>, IRolMenuRepository, IDisposable
    {
        public RolMenuRepository(CompanyDatabaseContext dbContext) : base(dbContext)
        {
        }
    }

    public interface IRolMenuRepository : IGenericRepository<RolMenu>, IDisposable { }
}