using Company.Data;
using Company.Models;
using Company.Services.Messages;
using Company.Services.Request;
using Company.Services.UserTo;
using Company.Tools;
using System;
using System.Transactions;

namespace Company.Services
{
    /// <summary>
    /// Clase de servicio para el manejo de usuarios de la aplicación
    /// </summary>
    public class UserServices : IDisposable, IUserServices
    {
        /// <summary>
        /// Unidad de trabajo
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        public UserServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        /// <summary>
        /// Crea un usuario en base de datos, crea el usuario rol como invitado temporal
        /// crear la información detalle del usuario con los datos vacios
        /// </summary>
        /// <param name="user">usuario a crear</param>
        /// <returns>UserResponseData</returns>
        public UserResponseData SaveUser(UserRequest user)
        {
            UserResponseData response = new UserResponseData();

            try
            {
                var userAppModel = user.RequestToModel();
                if (_unitOfWork.User.ExistData(x => x.UserName == userAppModel.UserName))
                {
                    response.Fail($"Ya existe un usuario con el nombre {userAppModel.UserName}, verifique!!");
                    return response;
                }

                Guid guestRole = _unitOfWork.Parameters.GetValueFromKey<Guid>("RolInvitadoId");
                Guid thirdId = _unitOfWork.Parameters.GetValueFromKey<Guid>("EmptyGuid");
                int typeDocumentCC = _unitOfWork.Parameters.GetValueFromKey<int>("TipoCedulaId");

                using (var trx = new TransactionScope())
                {
                    _unitOfWork.User.Create(userAppModel);

                    var userInfo = new UserInfoDetail()
                    {
                        UserId = userAppModel.UserId,
                        DateCreated = DateTime.Now,
                        UserCreatedId = user.CreateId,
                        TypeIdentificationId = typeDocumentCC
                    };

                    _unitOfWork.UserInfoDetail.Create(userInfo);

                    var role = new UserRole()
                    {
                        UserId = userAppModel.UserId,
                        DateCreated = DateTime.Now,
                        RolId = guestRole,
                        ThirdId = thirdId,
                        UserCreatedId = user.CreateId,
                        UserRolStatus = true,
                        UserRolId = Guid.NewGuid()
                    };

                    _unitOfWork.UserRoles.Create(role);
                    trx.Complete();
                }

                var userResponse = userAppModel.ModelToResponse();

                response.Response = userResponse;
                response.SuccesRequest($"Usuario con id {userAppModel.UserId} creado correctamente");
            }
            catch (Exception ex)
            {
                Logger.ErrorFatal($"{nameof(SaveUser)}", ex);
                response.Fail(ex);
            }
            return response;
        }

        /// <summary>
        /// Modifica el correo del usuario en base de datos
        /// </summary>
        /// <param name="user">usuario a modificar</param>
        /// <returns>UserResponseData</returns>
        public UserResponseData UpdateMailUser(UserRequest user)
        {
            UserResponseData response = new UserResponseData();

            try
            {
                var userAppModel = user.RequestToModel();

                if (!_unitOfWork.User.ExistData(x =>x.UserId == userAppModel.UserId))
                {
                    response.Fail($"No existe el usuario con id {userAppModel.UserId}, verifique!!");
                    return response;
                }

                if (_unitOfWork.User.ExistData(x => x.UserName == userAppModel.UserName && x.UserId != userAppModel.UserId))
                {
                    response.Fail($"Ya existe un usuario con el nombre {userAppModel.UserName}, verifique!!");
                    return response;
                }


                var userBd = _unitOfWork.User.GetById(userAppModel.UserId);

                userBd.UserMail = userAppModel.UserMail;
                userBd.UserUpdateId = user.CreateId;
                userBd.DateModified = DateTime.Now;

                _unitOfWork.User.Update(userBd);

                var userResponse = userBd.ModelToResponse();

                response.Response = userResponse;
                response.SuccesRequest($"Usuario con id {userAppModel.UserId} modificado correctamente");
            }
            catch (Exception ex)
            {
                Logger.ErrorFatal($"{nameof(UpdateMailUser)}", ex);
                response.Fail(ex);
            }
            return response;
        }

        #region [Dispose]

        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: eliminar el estado administrado (objetos administrados)
                    if (_unitOfWork != null)
                        _unitOfWork.Dispose();
                }

                // TODO: liberar los recursos no administrados (objetos no administrados) y reemplazar el finalizador
                // TODO: establecer los campos grandes como NULL
                disposedValue = true;
            }
        }

        // // TODO: reemplazar el finalizador solo si "Dispose(bool disposing)" tiene código para liberar los recursos no administrados
        // ~UserServices()
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
    /// Clase de servicio para el manejo de usuarios de la aplicación
    /// </summary>
    public interface IUserServices : IDisposable
    {
        /// <summary>
        /// Crea un usuario en base de datos, crea el usuario rol como invitado temporal
        /// crear la información detalle del usuario con los datos vacios
        /// </summary>
        /// <param name="user">usuario a crear</param>
        /// <returns>UserResponseData</returns>
        UserResponseData SaveUser(UserRequest user);

        /// <summary>
        /// Modifica el correo del usuario en base de datos
        /// </summary>
        /// <param name="user">usuario a modificar</param>
        /// <returns>UserResponseData</returns>
        UserResponseData UpdateMailUser(UserRequest user);
    }
}