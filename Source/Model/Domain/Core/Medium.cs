namespace IMAS.Model.Domain.Core
{
    using Common.Enum;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("core.Media")]
    public partial class Media
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int? ContentId { get; set; }

        [Required]
        [StringLength(50)]
        public string FileName { get; set; }

        public int Size { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? CreateDate { get; set; }

        public MediaType Type { get; set; }

        public virtual Content Content { get; set; }

        public virtual User User { get; set; }
    }
}
