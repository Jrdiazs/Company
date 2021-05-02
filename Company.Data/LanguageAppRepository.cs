using Company.Models;
using System;

namespace Company.Data
{
    public class LanguageAppRepository : GenericRepository<LanguageApp>, ILanguageAppRepository, IDisposable
    {
        public LanguageAppRepository(CompanyDatabaseContext dbContext) : base(dbContext)
        {
        }
    }

    public interface ILanguageAppRepository : IGenericRepository<LanguageApp>, IDisposable { }
}