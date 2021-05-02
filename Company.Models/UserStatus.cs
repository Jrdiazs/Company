using System.Collections.Generic;

namespace Company.Models
{
    public partial class UserStatus
    {
        public UserStatus()
        {
            UserApps = new HashSet<UserApp>();
        }

        public int UserStatusId { get; set; }
        public string UserStatusDescriptions { get; set; }
        public string UserStatusAlias { get; set; }

        public virtual ICollection<UserApp> UserApps { get; set; }
    }
}