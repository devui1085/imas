using System;
using System.Collections.Generic;

namespace IMAS.Model.Domain.Core
{
    using IMAS.Common.Enum;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("core.Advertisment")]
    public partial class Advertisment
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public DateTime RegisterDate { get; set; }

        public DateTime? ExpireDate { get; set; }

        [StringLength(200)]
        public string Comment { get; set; }

        [StringLength(200)]
        public string AdvertiserNote { get; set; }
        public int UserId { get; set; }

        public AdvertismentStatus Status { get; set; }

        [Required]
        [StringLength(100)]
        public string TypeIdentity { get; set; }

        [Required]
        public decimal Price { get; set; }
        //public virtual Machinery Machinery { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Picture> Pictures { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdvertismentVisit> AdvertismentVisits { get; set; }
    }
}
