using IMAS.Common.Enum;

namespace IMAS.Model.Domain.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("core.Publication")]
    public partial class Publication
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Publication()
        {
            Contents = new HashSet<Content>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public PublicationType Type { get; set; }

        public int CreatorId { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public DateTime CreateDate { get; set; }

        //public virtual Blog Blog { get; set; }

        //public virtual Channel Channel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Content> Contents { get; set; }

        public virtual User Creator { get; set; }
    }
}
