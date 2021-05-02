using System;
using System.Collections.Generic;

namespace Company.Models
{
    public partial class Role
    {
        public Role()
        {
            RolMenus = new HashSet<RolMenu>();
            UserRoles = new HashSet<UserRole>();
        }

        public Guid RolId { get; set; }
        public Guid? ThirdId { get; set; }
        public string RolDescription { get; set; }
        public bool IsSuperAdministrator { get; set; }
        public bool RolStatus { get; set; }
        public DateTime? DateCreated { get; set; }
        public Guid? UserCreatedId { get; set; }
        public DateTime? DateModified { get; set; }
        public Guid? UserUpdateId { get; set; }

        public virtual Third Third { get; set; }
        public virtual ICollection<RolMenu> RolMenus { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}