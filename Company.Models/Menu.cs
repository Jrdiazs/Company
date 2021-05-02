using System;
using System.Collections.Generic;

namespace Company.Models
{
    public partial class Menu
    {
        public Menu()
        {
            InverseMenuParent = new HashSet<Menu>();
            RolMenus = new HashSet<RolMenu>();
        }

        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public int? MenuParentId { get; set; }
        public string MenuUrl { get; set; }
        public string MenuClass { get; set; }
        public int? MenuOrder { get; set; }
        public bool MenuStatus { get; set; }
        public DateTime? DateCreated { get; set; }
        public Guid? UserCreatedId { get; set; }
        public Guid? UserUpdateId { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual Menu MenuParent { get; set; }
        public virtual ICollection<Menu> InverseMenuParent { get; set; }
        public virtual ICollection<RolMenu> RolMenus { get; set; }
    }
}