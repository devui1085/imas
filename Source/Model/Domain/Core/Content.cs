using IMAS.Common.Enum;

namespace IMAS.Model.Domain.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("core.Content")]
    public partial class Content
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Content()
        {
            Comments = new HashSet<Comment>();
            FeaturedContents = new HashSet<FeaturedContent>();
            Media = new HashSet<Media>();
            Rates = new HashSet<Rate>();
            References = new HashSet<Reference>();
            Visits = new HashSet<Visit>();
            Tags = new HashSet<Tag>();
        }

        public int Id { get; set; }

        public int AuthorId { get; set; }

        public int? PublicationId { get; set; }

        public ContentType Type { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }

        [StringLength(250)]
        public string ShortAbstract { get; set; }

        public int CultureLcid { get; set; }

        public ContentState State { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? LastModifyDate { get; set; }

        public DateTime? PublishDate { get; set; }

        public string MetaDescription { get; set; }

        public short PersianCreateDateYear { get; set; }

        public byte PersianCreateDateMonth { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }

        public virtual Publication Publication { get; set; }

        public virtual User Author { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FeaturedContent> FeaturedContents { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Media> Media { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rate> Rates { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reference> References { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Visit> Visits { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
