using Company.Data;
using Company.Tools.String;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Company.Services
{
    /// <summary>
    /// Contenedor  de servicios y repositorios
    /// </summary>
    public class ConfigureInit
    {
        /// <summary>
        /// Inicia el contenedor de servicios y la base de datos sql
        /// </summary>
        /// <param name="services">servicios</param>
        public static void InitServices(IServiceCollection services)
        {
            Container(services);
            DataBaseInit(services);
        }

        /// <summary>
        /// Inicia la base de datos
        /// </summary>
        /// <param name="services">servicios</param>
        private static void DataBaseInit(IServiceCollection services)
        {
            var connection = "DefaultConnection".ReadConnections();
            services.AddDbContext<CompanyDatabaseContext>(options => options.UseSqlServer(connection));
        }

        /// <summary>
        /// Inicia el contenedor de servicios y repositorios
        /// </summary>
        /// <param name="services"></param>
        private static void Container(IServiceCollection services)
        {
            //DataBase
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ILanguageAppRepository, LanguageAppRepository>();
            services.AddScoped<IUserInfoDetailRepository, UserInfoDetailRepository>();
            services.AddScoped<IUserRolesRepository, UserRolesRepository>();
            services.AddScoped<IUserStatusRepository, UserStatusRepository>();
            services.AddScoped<IRolesRepository, RolesRepository>();
            services.AddScoped<IRolMenuRepository, RolMenuRepository>();
            services.AddScoped<ITypeIdentificationRepository, TypeIdentificationRepository>();
            services.AddScoped<IParametersAppRepository, ParametersAppRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IThirdRepository, ThirdRepository>();
            services.AddScoped<IThirdTypeRepository, ThirdTypeRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Services

            services.AddScoped<IUserServices, UserServices>();
        }
    }
}