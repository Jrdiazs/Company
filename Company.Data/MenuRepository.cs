using Company.Models;
using System;

namespace Company.Data
{
    public class MenuRepository : GenericRepository<Menu>, IMenuRepository, IDisposable
    {
        public MenuRepository(CompanyDatabaseContext dbContext) : base(dbContext)
        {
        }
    }

    public interface IMenuRepository : IGenericRepository<Menu>, IDisposable { }
}