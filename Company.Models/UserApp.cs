using System;
using System.Collections.Generic;

namespace Company.Models
{
    public partial class UserApp
    {
        public UserApp()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserMail { get; set; }
        public int UserStatusId { get; set; }
        public DateTime DateCreated { get; set; }
        public Guid? UserCreatedId { get; set; }
        public Guid? UserUpdateId { get; set; }
        public DateTime? DateModified { get; set; }
        public int? NumberOfAttemps { get; set; }
        public string Pw { get; set; }
        public DateTime? LastAdmissionDate { get; set; }
        public bool? RestoreKey { get; set; }
        public int? LanguageId { get; set; }

        public virtual LanguageApp Language { get; set; }
        public virtual UserStatus UserStatus { get; set; }
        public virtual UserInfoDetail UserInfoDetail { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}