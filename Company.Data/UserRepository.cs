using Company.Models;
using System;

namespace Company.Data
{
    /// <summary>
    /// Repositorio para la tabla de usuarios
    /// </summary>
    public class UserRepository : GenericRepository<UserApp>, IUserRepository, IDisposable
    {
        public UserRepository(CompanyDatabaseContext dbContext) : base(dbContext)
        {
        }
    }

    /// <summary>
    /// Repositorio para la tabla de usuarios
    /// </summary>
    public interface IUserRepository : IGenericRepository<UserApp>, IDisposable { }
}