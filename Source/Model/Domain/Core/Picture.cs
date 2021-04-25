using System;

namespace IMAS.Model.Domain.Core
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("core.Picture")]
    public partial class Picture
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public bool IsMainPicture { get; set; }

        public int AdvertismentId { get; set; }
 
        public virtual Advertisment Advertisment { get; set; }
    }
}
