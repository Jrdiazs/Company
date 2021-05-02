using System;

namespace Company.Models
{
    public partial class UserInfoDetail
    {
        public Guid UserId { get; set; }
        public int? TypeIdentificationId { get; set; }
        public string DocumentUser { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string AlternateEmail { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateCreated { get; set; }
        public Guid? UserCreatedId { get; set; }
        public DateTime? DateModified { get; set; }
        public Guid? UserUpdateId { get; set; }

        public virtual TypeIdentification TypeIdentification { get; set; }
        public virtual UserApp User { get; set; }
    }
}