using System;

namespace Company.Models
{
    public partial class RolMenu
    {
        public int RolMenuId { get; set; }
        public int MenuId { get; set; }
        public Guid RolId { get; set; }
        public bool? RolMenuStatus { get; set; }
        public DateTime? DateCreated { get; set; }
        public Guid? UserCreatedId { get; set; }
        public DateTime? DateModified { get; set; }
        public Guid? UserUpdateId { get; set; }

        public virtual Menu Menu { get; set; }
        public virtual Role Rol { get; set; }
    }
}