namespace IMAS.Model.Domain.Core
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("core.Rate")]
    public partial class Rate
    {
        public int Id { get; set; }

        public int ContentId { get; set; }

        public int UserId { get; set; }

        public byte Value { get; set; }

        public DateTime CreateDate { get; set; }

        public virtual Content Content { get; set; }

        public virtual User User { get; set; }
    }
}
