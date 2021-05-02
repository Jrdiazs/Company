using System;

namespace Company.Models
{
    public partial class UserRole
    {
        public Guid UserRolId { get; set; }
        public Guid UserId { get; set; }
        public Guid RolId { get; set; }
        public Guid ThirdId { get; set; }
        public bool UserRolStatus { get; set; }
        public DateTime? DateCreated { get; set; }
        public Guid? UserCreatedId { get; set; }
        public DateTime? DateModified { get; set; }
        public Guid? UserUpdateId { get; set; }

        public virtual Role Rol { get; set; }
        public virtual Third Third { get; set; }
        public virtual UserApp User { get; set; }
    }
}