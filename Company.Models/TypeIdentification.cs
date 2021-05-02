using System.Collections.Generic;

namespace Company.Models
{
    public partial class TypeIdentification
    {
        public TypeIdentification()
        {
            Thirds = new HashSet<Third>();
            UserInfoDetails = new HashSet<UserInfoDetail>();
        }

        public int TypeIdentificationId { get; set; }
        public string TypeIdentificationDescription { get; set; }
        public string TypeIdentificationAlias { get; set; }

        public virtual ICollection<Third> Thirds { get; set; }
        public virtual ICollection<UserInfoDetail> UserInfoDetails { get; set; }
    }
}