using System.Collections.Generic;

namespace Company.Models
{
    public partial class ThirdType
    {
        public ThirdType()
        {
            Thirds = new HashSet<Third>();
        }

        public int ThirdTypeId { get; set; }
        public string ThirdTypeDescription { get; set; }

        public virtual ICollection<Third> Thirds { get; set; }
    }
}