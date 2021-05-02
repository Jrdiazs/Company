using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Company.Data
{
    /// <summary>
    /// Repositorio generico para el contexto CompanyDatabaseContext
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class GenericRepository<TEntity> : IDisposable, IGenericRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Inicia un repositorio generico para el contecto CompanyDatabaseContext
        /// </summary>
        /// <param name="dbContext"></param>
        public GenericRepository(CompanyDatabaseContext dbContext) => DbContext = dbContext;

        /// <summary>
        /// Contexto CompanyDatabaseContext
        /// </summary>
        public CompanyDatabaseContext DbContext { get; }

        /// <summary>
        /// Inserta un nuevo registro en la base de datos
        /// </summary>
        /// <param name="entity">TEntity</param>
        /// <returns>filas afectadas</returns>
        public int Create(TEntity entity)
        {
            try
            {
                DbContext.Set<TEntity>().Add(entity);
                return DbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Elimina un registro de la base de datos por id
        /// </summary>
        /// <param name="id">id entidad</param>
        /// <returns>filas afectadas</returns>
        public int Delete(dynamic id)
        {
            try
            {
                var entity = GetById(id);
                DbContext.Set<TEntity>().Remove(entity);
                return DbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Consulta todos los registros de la tabla
        /// </summary>
        /// <returns>IQueryable</returns>

        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return DbContext.Set<TEntity>().AsNoTracking();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Consulta una entidad por id
        /// </summary>
        /// <param name="id">id de la entidad</param>
        /// <returns>TEntity</returns>
        public TEntity GetById(dynamic id)
        {
            try
            {
                return DbContext.Set<TEntity>().Find(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Actualiza la entidad 
        /// </summary>
        /// <param name="entity">TEntity</param>
        /// <returns>filas afectadas</returns>

        public int Update(TEntity entity)
        {
            try
            {
                DbContext.Set<TEntity>().Update(entity);
                return DbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Verifica si existe un registro en base de datos segun el filtro aplicado
        /// </summary>
        /// <param name="predicate">filtro</param>
        /// <returns>true si exsite, false si no existe</returns>
        public bool ExistData(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                var exists = DbContext.Set<TEntity>().Any(predicate);
                return exists;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Lista los registros segun el filtro aplicado
        /// </summary>
        /// <param name="predicate">filtro aplicado</param>
        /// <returns>IQueryable</returns>
        public IQueryable<TEntity> FilterData(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return DbContext.Set<TEntity>().Where(predicate);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region [Dispose]

        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    if (DbContext != null)
                        DbContext.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~GenericRepository()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion [Dispose]
    }
    /// <summary>
    /// Repositorio generico para el contexto CompanyDatabaseContext
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IGenericRepository<TEntity> : IDisposable where TEntity : class
    {
        /// <summary>
        /// Consulta todos los registros de la tabla
        /// </summary>
        /// <returns>IQueryable</returns>

        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Consulta una entidad por id
        /// </summary>
        /// <param name="id">id de la entidad</param>
        /// <returns>TEntity</returns>
        TEntity GetById(dynamic id);

        /// <summary>
        /// Inserta un nuevo registro en la base de datos
        /// </summary>
        /// <param name="entity">TEntity</param>
        /// <returns>filas afectadas</returns>
        int Create(TEntity entity);

        /// <summary>
        /// Actualiza la entidad 
        /// </summary>
        /// <param name="entity">TEntity</param>
        /// <returns>filas afectadas</returns>
        int Update(TEntity entity);
        /// <summary>
        /// Elimina un registro de la base de datos por id
        /// </summary>
        /// <param name="id">id entidad</param>
        /// <returns>filas afectadas</returns>
        int Delete(dynamic id);
        /// <summary>
        /// Verifica si existe un registro en base de datos segun el filtro aplicado
        /// </summary>
        /// <param name="predicate">filtro</param>
        /// <returns>true si exsite, false si no existe</returns>
        bool ExistData(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// Lista los registros segun el filtro aplicado
        /// </summary>
        /// <param name="predicate">filtro aplicado</param>
        /// <returns>IQueryable</returns>

        IQueryable<TEntity> FilterData(Expression<Func<TEntity, bool>> predicate);
    }
}