using System;

namespace Company.Services.Messages
{
    /// <summary>
    /// Modelo base para respuestas
    /// </summary>
    public class BaseResponse
    {
        /// <summary>
        /// Indica si el modelo fue exitoso o no
        /// </summary>
        public bool Succes { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Indica que el proceso fue exitoso
        /// </summary>
        /// <param name="msg">mensaje de exito</param>
        public void SuccesRequest(string msg = "")
        {
            Succes = true;
            Message = msg;
        }

        /// <summary>
        /// Indica que la respuesta no fue exitosa
        /// </summary>
        /// <param name="msg">mensaje de error</param>

        public void Fail(string msg = "")
        {
            Succes = false;
            Message = msg;
        }

        /// <summary>
        /// Indica que la respuesta no fue exitosa
        /// </summary>
        /// <param name="ex">excepcion</param>
        public void Fail(Exception ex)
        {
            Succes = false;
            Message = ex.Message;
        }
    }
}