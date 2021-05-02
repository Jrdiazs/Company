using System;

namespace Company.Models
{
    public partial class ParametersApp
    {
        public Guid ParameterId { get; set; }
        public string ParameterKey { get; set; }
        public string ParameterDescription { get; set; }
        public Guid? ValueGuid { get; set; }
        public int? ValueNumber { get; set; }
        public DateTime? ValueDateTime { get; set; }
        public string ValueString { get; set; }
        public long? ValueBingInt { get; set; }
        public bool? ValueBoleano { get; set; }
        public DateTime? DateCreated { get; set; }
        public Guid? UserCreatedId { get; set; }
        public Guid? UserUpdateId { get; set; }
        public DateTime? DateModified { get; set; }
    }
}