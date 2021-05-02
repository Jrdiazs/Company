using System;

namespace Company.Services.Request
{
    /// <summary>
    /// Modelo base para solicitudes
    /// </summary>
    public class BaseRequest
    {
        public Guid CreateId { get; set; }

        public DateTime Date { get; set; }
    }
}