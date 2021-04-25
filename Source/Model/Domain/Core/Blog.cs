namespace IMAS.Model.Domain.Core
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("core.Blog")]
    public partial class Blog : Publication
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Blog()
        {
            Links = new HashSet<BlogLink>();
        }

        [StringLength(4000)]
        public string Description { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        //public virtual Publication Publication { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BlogLink> Links { get; set; }
    }
}
