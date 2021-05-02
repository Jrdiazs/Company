using Company.Models;
using Company.Services.MappingModels;
using Company.Services.Messages;
using Company.Services.Request;

namespace Company.Services.UserTo
{
    /// <summary>
    /// Clase para convertir los modelos de usuarios
    /// </summary>
    public static class UserConvertTo
    {
        /// <summary>
        /// Convierte el modelo request user al de base de datos
        /// </summary>
        /// <param name="request">UserRequest</param>
        /// <returns>UserApp</returns>
        public static UserApp RequestToModel(this UserRequest request)
        {
            var user = BootstrapperMapping.Mapper.Map<UserRequest, UserApp>(request);
            return user;
        }

        /// <summary>
        /// Convierte el modelo de base de datos al modelo response
        /// </summary>
        /// <param name="model">UserApp</param>
        /// <returns>UserResponse</returns>
        public static UserResponse ModelToResponse(this UserApp model)
        {
            var user = BootstrapperMapping.Mapper.Map<UserApp, UserResponse>(model);
            return user;
        }
    }
}