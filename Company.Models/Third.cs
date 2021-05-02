using System;
using System.Collections.Generic;

namespace Company.Models
{
    public partial class Third
    {
        public Third()
        {
            Roles = new HashSet<Role>();
            UserRoles = new HashSet<UserRole>();
        }

        public Guid ThirdId { get; set; }
        public int? ThirdTypeIdentificationId { get; set; }
        public int ThirdTypeId { get; set; }
        public string ThirdDocument { get; set; }
        public string ThirdName { get; set; }
        public string ThirdTradeName { get; set; }
        public DateTime? DateCreated { get; set; }
        public Guid? UserCreatedId { get; set; }
        public DateTime? DateModified { get; set; }
        public Guid? UserUpdateId { get; set; }

        public virtual ThirdType ThirdType { get; set; }
        public virtual TypeIdentification ThirdTypeIdentification { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}