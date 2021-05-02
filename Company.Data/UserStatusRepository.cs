using Company.Models;
using System;

namespace Company.Data
{
    public class UserStatusRepository : GenericRepository<UserStatus>, IUserStatusRepository, IDisposable
    {
        public UserStatusRepository(CompanyDatabaseContext dbContext) : base(dbContext)
        {
        }
    }

    public interface IUserStatusRepository : IGenericRepository<UserStatus>, IDisposable { }
}