using System.Collections.Generic;

namespace Company.Models
{
    public partial class LanguageApp
    {
        public LanguageApp()
        {
            UserApps = new HashSet<UserApp>();
        }

        public int LanguageId { get; set; }
        public string DescriptionLanguage { get; set; }
        public string CodeLanguage { get; set; }
        public string CodeHtmlLanguage { get; set; }

        public virtual ICollection<UserApp> UserApps { get; set; }
    }
}