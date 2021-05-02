using Company.Models;
using System;

namespace Company.Data
{
    public class ThirdRepository : GenericRepository<Third>, IThirdRepository, IDisposable
    {
        public ThirdRepository(CompanyDatabaseContext dbContext) : base(dbContext)
        {
        }
    }

    public interface IThirdRepository : IGenericRepository<Third>, IDisposable { }
}