using Company.Models;
using System;

namespace Company.Data
{
    public class UserRolesRepository : GenericRepository<UserRole>, IUserRolesRepository, IDisposable
    {
        public UserRolesRepository(CompanyDatabaseContext dbContext) : base(dbContext)
        {
        }
    }

    public interface IUserRolesRepository : IGenericRepository<UserRole>, IDisposable { }
}