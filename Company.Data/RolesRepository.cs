using Company.Models;
using System;

namespace Company.Data
{
    public class RolesRepository : GenericRepository<Role>, IRolesRepository, IDisposable
    {
        public RolesRepository(CompanyDatabaseContext dbContext) : base(dbContext)
        {
        }
    }

    public interface IRolesRepository : IGenericRepository<Role>, IDisposable { }
}