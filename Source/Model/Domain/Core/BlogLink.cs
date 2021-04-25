namespace IMAS.Model.Domain.Core
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("core.BlogLink")]
    public partial class BlogLink
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Url { get; set; }

        public int BlogId { get; set; }

        public virtual Blog Blog { get; set; }
    }
}
