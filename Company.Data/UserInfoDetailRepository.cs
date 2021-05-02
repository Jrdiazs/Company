using Company.Models;
using System;

namespace Company.Data
{
    public class UserInfoDetailRepository : GenericRepository<UserInfoDetail>, IUserInfoDetailRepository, IDisposable
    {
        public UserInfoDetailRepository(CompanyDatabaseContext dbContext) : base(dbContext)
        {
        }
    }

    public interface IUserInfoDetailRepository : IGenericRepository<UserInfoDetail>, IDisposable { }
}