using System;

namespace Company.Models
{
    public partial class LogApp
    {
        public Guid IdLog { get; set; }
        public DateTime? DateCreate { get; set; }
        public string ThreadLog { get; set; }
        public string LeveLog { get; set; }
        public string Logger { get; set; }
        public string MessagLog { get; set; }
        public string ExceptionLog { get; set; }
    }
}