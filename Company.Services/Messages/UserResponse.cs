using System;

namespace Company.Services.Messages
{
    /// <summary>
    /// Modelo de respuesta para usuarios
    /// </summary>
    public class UserResponse
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Mail { get; set; }

        public int StatusValue { get; set; }

        public string Status { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? LastAdmissionDate { get; set; }

        public bool RestoreKey { get; set; }

        public int Language { get; set; }
    }

    /// <summary>
    /// Modelo de respuesta para usuarios
    /// </summary>
    public class UserResponseData : BaseResponse
    {
        /// <summary>
        /// Respuesta para el modelo usuarios
        /// </summary>
        public UserResponse Response { get; set; }
    }
}