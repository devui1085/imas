namespace IMAS.Model.Domain.Core
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("core.ExceptionLog")]
    public partial class ExceptionLog
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        [Required]
        [StringLength(4000)]
        public string Message { get; set; }

        [StringLength(4000)]
        public string InnerMessage { get; set; }

        [StringLength(4000)]
        public string HttpRequestUrl { get; set; }
    }
}
