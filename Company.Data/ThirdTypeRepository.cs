using Company.Models;
using System;

namespace Company.Data
{
    public class ThirdTypeRepository : GenericRepository<ThirdType>, IThirdTypeRepository, IDisposable
    {
        public ThirdTypeRepository(CompanyDatabaseContext dbContext) : base(dbContext)
        {
        }
    }

    public interface IThirdTypeRepository : IGenericRepository<ThirdType>, IDisposable { }
}