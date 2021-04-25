namespace IMAS.Model.Domain.Core
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("core.Visit")]
    public partial class Visit
    {
        public int Id { get; set; }

        public int ContentId { get; set; }

        public int Count { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public virtual Content Content { get; set; }
    }
}
