using Company.Models;
using System;

namespace Company.Data
{
    public class TypeIdentificationRepository : GenericRepository<TypeIdentification>, ITypeIdentificationRepository, IDisposable
    {
        public TypeIdentificationRepository(CompanyDatabaseContext dbContext) : base(dbContext)
        {
        }
    }

    public interface ITypeIdentificationRepository : IGenericRepository<TypeIdentification>, IDisposable { }
}