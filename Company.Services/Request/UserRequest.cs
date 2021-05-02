using System;

namespace Company.Services.Request
{
    /// <summary>
    /// Modelo solicitud para usuarios
    /// </summary>
    public class UserRequest : BaseRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public int Status { get; set; }
        public string Pw { get; set; }
        public int NumberOfAttemps { get; set; }
        public DateTime? LastAdmissionDate { get; set; }
        public bool? RestoreKey { get; set; }
        public int Language { get; set; }
    }
}