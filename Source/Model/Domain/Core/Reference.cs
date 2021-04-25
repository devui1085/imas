namespace IMAS.Model.Domain.Core
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("core.Reference")]
    public partial class Reference
    {
        public int Id { get; set; }

        public int ContentId { get; set; }

        public int CultureLcid { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [StringLength(2048)]
        public string Url { get; set; }

        public virtual Content Content { get; set; }
    }
}
