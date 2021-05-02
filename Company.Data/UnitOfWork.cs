using System;

namespace Company.Data
{
    /// <summary>
    /// Unidad de trabajo con todos los repositorios de app
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="language">repositorio lenguaje</param>
        /// <param name="menu">repositorio menu</param>
        /// <param name="parameters">repositorio parametros</param>
        /// <param name="roles">repositorio roles</param>
        /// <param name="rolMenu">repositorio roles menu</param>
        /// <param name="third">repositorio tercero</param>
        /// <param name="thirdType">repositorio tipo tercero</param>
        /// <param name="typeIdentification">repositorio tipo identificación</param>
        /// <param name="userInfoDetail">repositorio informacion detalle de usuario</param>
        /// <param name="user">repositorio de usuarios</param>
        /// <param name="userRoles">repositorio de usuarios roles</param>
        /// <param name="userStatus">repositorio de estados de usuarios</param>
        public UnitOfWork(ILanguageAppRepository language, IMenuRepository menu, IParametersAppRepository parameters, IRolesRepository roles, IRolMenuRepository rolMenu, IThirdRepository third, IThirdTypeRepository thirdType, ITypeIdentificationRepository typeIdentification, IUserInfoDetailRepository userInfoDetail, IUserRepository user, IUserRolesRepository userRoles, IUserStatusRepository userStatus)
        {
            Language = language ?? throw new ArgumentNullException(nameof(language));
            Menu = menu ?? throw new ArgumentNullException(nameof(menu));
            Parameters = parameters ?? throw new ArgumentNullException(nameof(parameters));
            Roles = roles ?? throw new ArgumentNullException(nameof(roles));
            RolMenu = rolMenu ?? throw new ArgumentNullException(nameof(rolMenu));
            Third = third ?? throw new ArgumentNullException(nameof(third));
            ThirdType = thirdType ?? throw new ArgumentNullException(nameof(thirdType));
            TypeIdentification = typeIdentification ?? throw new ArgumentNullException(nameof(typeIdentification));
            UserInfoDetail = userInfoDetail ?? throw new ArgumentNullException(nameof(userInfoDetail));
            User = user ?? throw new ArgumentNullException(nameof(user));
            UserRoles = userRoles ?? throw new ArgumentNullException(nameof(userRoles));
            UserStatus = userStatus ?? throw new ArgumentNullException(nameof(userStatus));
        }

        /// <summary>
        /// Repositoreio de Lenguaje de aplicacion
        /// </summary>
        public ILanguageAppRepository Language { get; }
        /// <summary>
        /// Repositorio Menu
        /// </summary>
        public IMenuRepository Menu { get; }

        /// <summary>
        /// Repositorio parametros
        /// </summary>
        public IParametersAppRepository Parameters { get; }
        /// <summary>
        /// Repositorio Roles
        /// </summary>
        public IRolesRepository Roles { get; }

        /// <summary>
        /// Repositorio Rol Menu
        /// </summary>
        public IRolMenuRepository RolMenu { get; }

        /// <summary>
        /// Repositorio Terceros
        /// </summary>
        public IThirdRepository Third { get; }

        /// <summary>
        /// Repositorio Tipo Tercero
        /// </summary>
        public IThirdTypeRepository ThirdType { get; }

        /// <summary>
        /// Repositorio tipo identificacion
        /// </summary>
        public ITypeIdentificationRepository TypeIdentification { get; }

        /// <summary>
        /// Repositorio informacion usuario detalle
        /// </summary>
        public IUserInfoDetailRepository UserInfoDetail { get; }

        /// <summary>
        /// Repositorio de usuarios
        /// </summary>
        public IUserRepository User { get; }

        /// <summary>
        /// Repositorio de usuarios roles
        /// </summary>
        public IUserRolesRepository UserRoles { get; }

        /// <summary>
        /// Repositorio Estado de usuarios
        /// </summary>
        public IUserStatusRepository UserStatus { get; }

        #region [Dispose]

        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: eliminar el estado administrado (objetos administrados)
                    if (Language != null)
                        Language.Dispose();

                    if (Menu != null)
                        Menu.Dispose();

                    if (Parameters != null)
                        Parameters.Dispose();

                    if (Roles != null)
                        Roles.Dispose();

                    if (RolMenu != null)
                        RolMenu.Dispose();

                    if (Third != null)
                        Third.Dispose();

                    if (ThirdType != null)
                        ThirdType.Dispose();

                    if (TypeIdentification != null)
                        TypeIdentification.Dispose();

                    if (UserInfoDetail != null)
                        UserInfoDetail.Dispose();

                    if (User != null)
                        User.Dispose();

                    if (UserRoles != null)
                        UserRoles.Dispose();

                    if (UserStatus != null)
                        UserStatus.Dispose();
                }

                // TODO: liberar los recursos no administrados (objetos no administrados) y reemplazar el finalizador
                // TODO: establecer los campos grandes como NULL
                disposedValue = true;
            }
        }

        // // TODO: reemplazar el finalizador solo si "Dispose(bool disposing)" tiene código para liberar los recursos no administrados
        // ~UnitOfWork()
        // {
        //     // No cambie este código. Coloque el código de limpieza en el método "Dispose(bool disposing)".
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el método "Dispose(bool disposing)".
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion [Dispose]
    }

    /// <summary>
    /// Unidad de trabajo con todos los repositorios de app
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {

        /// <summary>
        /// Repositoreio de Lenguaje de aplicacion
        /// </summary>
        ILanguageAppRepository Language { get; }
        /// <summary>
        /// Repositorio Menu
        /// </summary>
        IMenuRepository Menu { get; }

        /// <summary>
        /// Repositorio parametros
        /// </summary>
        IParametersAppRepository Parameters { get; }
        /// <summary>
        /// Repositorio Roles
        /// </summary>
        IRolesRepository Roles { get; }

        /// <summary>
        /// Repositorio Rol Menu
        /// </summary>
        IRolMenuRepository RolMenu { get; }

        /// <summary>
        /// Repositorio Terceros
        /// </summary>
        IThirdRepository Third { get; }

        /// <summary>
        /// Repositorio Tipo Tercero
        /// </summary>
        IThirdTypeRepository ThirdType { get; }

        /// <summary>
        /// Repositorio tipo identificacion
        /// </summary>
        ITypeIdentificationRepository TypeIdentification { get; }

        /// <summary>
        /// Repositorio informacion usuario detalle
        /// </summary>
        IUserInfoDetailRepository UserInfoDetail { get; }

        /// <summary>
        /// Repositorio de usuarios
        /// </summary>
        IUserRepository User { get; }

        /// <summary>
        /// Repositorio de usuarios roles
        /// </summary>
        IUserRolesRepository UserRoles { get; }

        /// <summary>
        /// Repositorio Estado de usuarios
        /// </summary>
        IUserStatusRepository UserStatus { get; }
    }
}